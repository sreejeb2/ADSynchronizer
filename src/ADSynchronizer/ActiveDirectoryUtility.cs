using NLog;
using NLog.Filters;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ADSynchronizer
{
    public class ActiveDirectoryUtility : IDisposable
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private const string LdapProtocolBase = "LDAP://";
        private const string BaseGroupFilter = "(&(objectCategory=group)(cn={0}))";
        private const string BaseGroupSidFilter = "(&(objectCategory=group)(objectsid={0}))";
        private const string BaseListUsersFilter = "(&(objectCategory=person)(objectClass=user)(memberOf={0}))";
        private const string BaseFindUsersFilter = "(&(objectCategory=person)(objectClass=user)(anr={0}))";
        private const string BaseGetUserFilter = "(&(objectCategory=person)(objectClass=user)(distinguishedName={0}))";
        private const string BaseGetUserBySIdFilter = "(&(objectCategory=person)(objectClass=user)(objectSid={0}))";
        private const string BaseGetUserBySamAccountNameFilter = "(&(objectCategory=person)(objectClass=user)(samAccountName={0}))";
        private const string BaseListAllUsersFilter = "(&(objectCategory=person)(objectClass=user))";

        private const string UserDistiguishedNameProperty = "distinguishedName";
        private const string UserSidProperty = "objectsid";
        private const string UserCommonNameProperty = "cn";
        private const string SamAccountNameProperty = "samAccountName";
        private const string MailProperty = "mail";

        private static readonly string[] UserProperties = new[] { UserDistiguishedNameProperty, UserSidProperty, UserCommonNameProperty, SamAccountNameProperty, MailProperty };

        private bool _disposed;
        private DirectoryEntry _rootEntry;

        public ActiveDirectoryUtility(string rootServerDns, string? username = null, string? password = null)
        {
            if (rootServerDns == null) throw new ArgumentNullException("rootServerDns");

            _rootEntry = CreateRootDirectoryEntry(rootServerDns, username, password);
        }

        #region Static Methods

        public static bool TestConnectionToLdapServer(string rootServerDns, string? username = null, string? password = null)
        {
            using (var rootEntry = CreateRootDirectoryEntry(rootServerDns, username, password))
            {
                return TestConnectionToLdapServer(rootEntry);
            }
        }

        private static bool TestConnectionToLdapServer(DirectoryEntry rootEntry)
        {
            try
            {
                return rootEntry.NativeObject != null || rootEntry.Guid != Guid.Empty;
            }
            catch (Exception ex)
            {
                Logger.Error("Could not connect to the specified AD server", ex);
                return false;
            }
        }

        public static IEnumerable<string> SearchAllProp(string rootServerDns, string? username = null, string? password = null)
        {
            var context = new DirectoryContext(DirectoryContextType.Forest, rootServerDns);

            using (var schema = ActiveDirectorySchema.GetSchema(context))
            {
                var userClass = schema.FindClass("user");

                foreach (ActiveDirectorySchemaProperty property in userClass.GetAllProperties())
                {
                    yield return property.Name;
                }
            }
        }

        public static IEnumerable<string> SearchAllPropFromUser(string rootServerDns, string? username = null, string? password = null, string testADUser = null)
        {
            using (var rootEntry = CreateRootDirectoryEntry(rootServerDns, username, password))
            {
                using (var searcher = new DirectorySearcher(rootEntry))
                {
                    //searcher.Filter = BaseListAllUsersFilter;
                    searcher.Filter = $"(uid={testADUser})";                    
                    searcher.PropertiesToLoad.Add("*");

                    var result = searcher.FindOne();

                    if (result != null)
                    {
                        foreach (string field in result.Properties.PropertyNames)
                        {
                            yield return field;
                        }
                    }
                    else
                    {
                        throw new ApplicationException("Search failed, null result!");
                    }
                }
            }
        }

        private static DirectoryEntry CreateRootDirectoryEntry(string rootServerDns, string? username = null, string? password = null)
        {
            return new DirectoryEntry(BuildLdapUrl(rootServerDns), username, password)
            {
                AuthenticationType = AuthenticationTypes.ServerBind
            };
        }
        #endregion

        #region Public Methods

        public string GetActiveDirectoryGroupSid(string groupName)
        {
            using (var groupSearcher = new DirectorySearcher(_rootEntry) { SearchScope = SearchScope.Subtree })
            {
                groupName = LdapCanonicalization.CanonicalizeStringForLdapFilter(groupName.Trim());
                groupSearcher.Filter = string.Format(CultureInfo.CurrentCulture, BaseGroupFilter, groupName);

                //make sure we have a clean collection
                groupSearcher.PropertiesToLoad.Clear();
                groupSearcher.PropertiesToLoad.Add(UserSidProperty);


                //find the first search result
                var results = groupSearcher.FindOne();

                if (results == null) return null;

                var sid = new SecurityIdentifier((byte[])results.Properties[UserSidProperty][0], 0).Value.ToUpper(CultureInfo.CurrentCulture);

                return string.IsNullOrEmpty(sid) ? null : sid;

            }
        }

        public string GetActiveDirectoryGroupName(string membershipIdentifier)
        {
            using (var groupSearcher = new DirectorySearcher(_rootEntry) { SearchScope = SearchScope.Subtree })
            {
                membershipIdentifier = LdapCanonicalization.CanonicalizeStringForLdapFilter(membershipIdentifier);
                groupSearcher.Filter = string.Format(CultureInfo.CurrentCulture, BaseGroupSidFilter, membershipIdentifier);

                //make sure we have a clean collection
                groupSearcher.PropertiesToLoad.Clear();
                groupSearcher.PropertiesToLoad.AddRange(UserProperties);

                //find the first search result
                var results = groupSearcher.FindOne();

                if (results == null) return null;

                var groupName = results.Properties[UserCommonNameProperty][0].ToString();

                return string.IsNullOrEmpty(groupName) ? null : groupName;

            }
        }

        public IEnumerable<ImportableUser> ListUsersInGroup(string groupName)
        {
            if (groupName == null) throw new ArgumentNullException("groupName");
            if (_disposed) throw new ObjectDisposedException("Root DirectoryEntry is disposed");

            groupName = LdapCanonicalization.CanonicalizeStringForLdapFilter(groupName);
            var groupDn = GetGroupDn(groupName);

            return string.IsNullOrEmpty(groupDn) ? null : SearchDirectory(_rootEntry, string.Format(CultureInfo.CurrentCulture, BaseListUsersFilter, groupDn));

        }

        public IEnumerable<ImportableUser> FindUsers(string searchString)
        {
            if (searchString == null) throw new ArgumentNullException("searchString");
            if (_disposed) throw new ObjectDisposedException("Root DirectoryEntry is disposed");

            searchString = LdapCanonicalization.CanonicalizeStringForLdapFilter(searchString);
            return SearchDirectory(_rootEntry, string.Format(CultureInfo.CurrentCulture, BaseFindUsersFilter, searchString));
        }

        public ImportableUser GetUser(string distinguishedName)
        {
            if (distinguishedName == null) throw new ArgumentNullException("distinguishedName");
            if (_disposed) throw new ObjectDisposedException("Root DirectoryEntry is disposed.");

            distinguishedName = LdapCanonicalization.CanonicalizeStringForLdapFilter(distinguishedName);
            return SearchDirectory(_rootEntry, string.Format(CultureInfo.CurrentCulture, BaseGetUserFilter, distinguishedName)).FirstOrDefault();
        }

        public ImportableUser GetUserBySId(string sId)
        {
            if (sId == null) throw new ArgumentNullException("sId");
            if (_disposed) throw new ObjectDisposedException("Root DirectoryEntry is disposed.");

            sId = LdapCanonicalization.CanonicalizeStringForLdapFilter(sId);
            return SearchDirectory(_rootEntry, string.Format(CultureInfo.CurrentCulture, BaseGetUserBySIdFilter, sId)).FirstOrDefault();
        }

        public ImportableUser GetUserBySamAccountName(string samAccountName,
            IList<string> userProperties,
            Func<SearchResult, ImportableUser> mapAdUser)
        {
            if (string.IsNullOrWhiteSpace(samAccountName)) throw new ArgumentNullException("samAccountName");
            if (userProperties.Count <= 0) throw new ArgumentException("userProperties");
            if (_disposed) throw new ObjectDisposedException("Root DirectoryEntry is disposed.");

            samAccountName = LdapCanonicalization.CanonicalizeStringForLdapFilter(samAccountName);
            var filter = string.Format(CultureInfo.CurrentCulture, BaseGetUserBySamAccountNameFilter, samAccountName);
            
            return SearchDirectory(_rootEntry, userProperties, mapAdUser).FirstOrDefault();
        }

        private static IEnumerable<ImportableUser> SearchDirectory(DirectoryEntry entry, IList<string> userProperties, 
            Func<SearchResult, ImportableUser> mapAdUser, string? filter = null)
        {
            using (var searcher = new DirectorySearcher(entry))
            {
                searcher.PropertiesToLoad.Clear();
                searcher.PropertiesToLoad.AddRange(userProperties.ToArray());

                if (!string.IsNullOrEmpty(filter))
                    searcher.Filter = filter;

                var results = searcher.FindAll();

                return results
                    .Cast<SearchResult>()
                    .Select(mapAdUser);
            }
        }

        private static string BuildLdapUrl(string path)
        {
            // path = LdapCanonicalization.CanonicalizeStringForLdapDN(path);
            if (path.StartsWith(LdapProtocolBase, StringComparison.CurrentCulture))
                return path;
            else
                return LdapProtocolBase + path;
        }

        private string GetGroupDn(string groupName)
        {
            using (var groupSearcher = new DirectorySearcher(_rootEntry) { SearchScope = SearchScope.Subtree })
            {
                groupName = LdapCanonicalization.CanonicalizeStringForLdapFilter(groupName);
                groupSearcher.Filter = string.Format(CultureInfo.CurrentCulture, BaseGroupFilter, groupName);

                //make sure we have a clean collection
                groupSearcher.PropertiesToLoad.Clear();
                groupSearcher.PropertiesToLoad.Add("distinguishedName");

                //find the first search result
                var results = groupSearcher.FindOne();

                return results != null ? results.Properties["distinguishedName"][0].ToString() : null;
            }
        }

        private static IEnumerable<ImportableUser> SearchDirectory(DirectoryEntry entry, string? filter = null)
        {
            using (var searcher = new DirectorySearcher(entry))
            {
                searcher.PropertiesToLoad.Clear();
                searcher.PropertiesToLoad.AddRange(UserProperties);

                if (!string.IsNullOrEmpty(filter))
                    searcher.Filter = filter;

                var results = searcher.FindAll();

                return results
                    .Cast<SearchResult>()
                    .Select(CreateAdUser)
                    .ToList();
            }
        }

        private static ImportableUser CreateAdUser(SearchResult result)
        {
            return new ImportableUser
            {
                DistiguishedName = result.Properties[UserDistiguishedNameProperty][0].ToString(),
                Sid = ConvertToSidString((byte[])result.Properties[UserSidProperty][0]),
                DisplayName = result.Properties[UserCommonNameProperty][0].ToString(),
                SamAccountName = result.Properties[SamAccountNameProperty][0].ToString(),
                Email = result.Properties[MailProperty].Count > 0 ? result.Properties[MailProperty][0].ToString() : string.Empty
            };
        }

        private static string ConvertToSidString(byte[] bytes)
        {
            return new SecurityIdentifier(bytes, 0).Value.ToUpper(CultureInfo.CurrentCulture);
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these 
            // operations, as well as in your methods that use the resource.
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_rootEntry != null)
                        _rootEntry.Dispose();
                }

                // Indicate that the instance has been disposed.
                _rootEntry = null;

                _disposed = true;
            }
        }

        #endregion
    }
}