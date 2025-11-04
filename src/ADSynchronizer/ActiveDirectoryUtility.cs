using NLog;
using NLog.Filters;
using NLog.Fluent;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.IO;
using System.Security.Principal;

namespace ADSynchronizer
{
    public class ActiveDirectoryUtility : IDisposable
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static readonly Logger AuditLogger = LogManager.GetLogger("AuditLog");

        private const string LdapProtocolBase = "LDAP://";
        private const string BaseFilter = "(objectClass=*)";
        private const string BaseGroupFilter = "(&(objectCategory=group)(cn={0}))";
        private const string BaseGroupSidFilter = "(&(objectCategory=group)(objectsid={0}))";
        private const string BaseFindUsersFilter = "(&(objectCategory=person)(objectClass=user)(anr={0}))";
        private const string BaseGetUserBySIdFilter = "(&(objectCategory=person)(objectClass=user)(objectSid={0}))";
        private const string BaseGetUserBySamAccountNameFilter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName={0}))";
        private const string BaseListUsersFilter = "(&(objectCategory=person)(objectClass=user){0})";
        private const string BaseListAllUsersFilter = "(&(objectCategory=person)(objectClass=user))";

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
                Logger.Error(ex, "Could not connect to the specified AD server");
                return false;
            }
        }

        public static IEnumerable<string> SearchAllProp(string rootServerDns, string? username = null, string? password = null,
            string? filter = null)
        {
            using (var rootEntry = CreateRootDirectoryEntry(rootServerDns, username, password))
            {
                using (var searcher = new DirectorySearcher(rootEntry))
                {
                    searcher.Filter = GetAllUsersFilter(filter);
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

        public static IEnumerable<string> SearchAllProp(string rootServerDns, string className)
        {
            var rootEntry = new DirectoryContext(DirectoryContextType.Forest, rootServerDns);

            using (var searcher = ActiveDirectorySchema.GetSchema(rootEntry))
            {
                var result = searcher.FindClass(className);

                if (result != null)
                {
                    foreach (ActiveDirectorySchemaProperty field in result.GetAllProperties())
                    {
                        yield return field.Name;
                    }
                }
                else
                {
                    throw new ApplicationException("Search failed, null result!");
                }
            }
        }

        public static IEnumerable<string> SearchAllProp(string className)
        {
            using (var searcher = ActiveDirectorySchema.GetCurrentSchema())
            {
                var result = searcher.FindClass(className);

                if (result != null)
                {
                    foreach (ActiveDirectorySchemaProperty field in result.GetAllProperties())
                    {
                        yield return field.Name;
                    }
                }
                else
                {
                    throw new ApplicationException("Search failed, null result!");
                }
            }
        }

        public static IEnumerable<string> SearchAllPropFromUser(string rootServerDns, string? username = null, string? password = null, string testADUser = null)
        {
            using (var rootEntry = CreateRootDirectoryEntry(rootServerDns, username, password))
            {
                using (var searcher = new DirectorySearcher(rootEntry))
                {
                    searcher.Filter = string.Format(CultureInfo.CurrentCulture, BaseGetUserBySamAccountNameFilter, testADUser);                   
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
            username = string.IsNullOrEmpty(username) ? null : username;
            password = string.IsNullOrEmpty(password) ? null : password;

            return new DirectoryEntry(BuildLdapUrl(rootServerDns), username, password)
            {
                AuthenticationType = AuthenticationTypes.ServerBind
            };
        }

        public (DataTable, int) PreviewUsers(IList<Mapping> mappings, int count = 1, string? filter = null)
        {
            if (mappings.Count <= 0) throw new ArgumentException("mappings");
            if (_disposed) throw new ObjectDisposedException("Root DirectoryEntry is disposed.");

            return SearchDirectory(_rootEntry, mappings, count, filter);
        }

        public Dictionary<string, Dictionary<string, string>> GetUser(string searchValue, IList<Mapping> mappings, string? filter = null)
        {
            if (string.IsNullOrWhiteSpace(searchValue)) throw new ArgumentNullException("searchValue");
            if (mappings.Count <= 0) throw new ArgumentException("mappings");
            if (_disposed) throw new ObjectDisposedException("Root DirectoryEntry is disposed.");

            searchValue = LdapCanonicalization.CanonicalizeStringForLdapFilter(searchValue);
            var primaryKeyMap = mappings.First(m => m.DestinationField == DataAccess.PrimaryKey);
            var userfilter = $"({primaryKeyMap.SourceField}={searchValue})";
            var adFilter = string.IsNullOrEmpty(filter) ? userfilter : $"{GetFilteredUsersFilter(filter)}{userfilter}";

            return SearchDirectory(_rootEntry, mappings, adFilter);
        }

        public Dictionary<string, Dictionary<string, string>> GetAllUsers(IList<Mapping> mappings, string? filter = null)
        {
            if (mappings.Count <= 0) throw new ArgumentException("mappings");
            if (_disposed) throw new ObjectDisposedException("Root DirectoryEntry is disposed.");

            return SearchDirectory(_rootEntry, mappings, filter);
        }

        private static Dictionary<string, Dictionary<string, string>> SearchDirectory(DirectoryEntry entry, IList<Mapping> mappings, 
            string? filter = null)
        {
            var adProperties = mappings.Select(m => m.SourceField).ToArray();
            var primaryKeyMap = mappings.First(m => m.DestinationField == DataAccess.PrimaryKey);
            var results = new Dictionary<string, Dictionary<string, string>>();

            using (var searcher = new DirectorySearcher(entry))
            {
                searcher.PropertiesToLoad.Clear();
                searcher.PropertiesToLoad.AddRange(adProperties);
                searcher.PageSize = int.MaxValue;
                searcher.Filter = GetAllUsersFilter(filter);

                using (SearchResultCollection searchResults = searcher.FindAll())
                {
                    AuditLogger.Info($"Got {searchResults.Count} users from AD");

                    foreach (SearchResult searchResult in searchResults)
                    {                        
                        try
                        {
                            var primaryKeyValue = GetProperty(searchResult, primaryKeyMap.SourceField);

                            if (!string.IsNullOrWhiteSpace(primaryKeyValue))
                            {
                                var allPropValues = new Dictionary<string, string>();

                                foreach (var map in mappings)
                                {
                                    allPropValues.Add(map.DestinationField, GetProperty(searchResult, map.SourceField));
                                }

                                results.Add(primaryKeyValue, allPropValues);

                                AuditLogger.Info($"Got user {primaryKeyValue} with {allPropValues.Count} properties from AD");
                            }
                            else
                            {
                                AuditLogger.Warn($"Got AD search result with empty primary key({DataAccess.PrimaryKey})");
                            }
                        }
                        catch (Exception ex)
                        {
                            AuditLogger.Error("Exception reading data from AD, will continue");
                            Logger.Error(ex, "Exception reading data from AD, will continue");
                        }
                    }
                }

                return results;
            }
        }
        
        private static string GetProperty(SearchResult searchResult, string? propertyName)
        {
            return !string.IsNullOrEmpty(propertyName) && searchResult.Properties.Contains(propertyName)
                ? searchResult.Properties[propertyName][0].ToString() ?? ""
                : string.Empty;
        }

        private static string BuildLdapUrl(string path)
        {
            // path = LdapCanonicalization.CanonicalizeStringForLdapDN(path);
            if (path.StartsWith(LdapProtocolBase, StringComparison.CurrentCulture))
                return path;
            else
                return LdapProtocolBase + path;
        }

        private static string GetAllUsersFilter(string? adFilter)
        {
            return string.IsNullOrEmpty(adFilter)
                ? BaseFilter
                : GetFilteredUsersFilter(adFilter);
        }

        private static string GetFilteredUsersFilter(string? additionalFilter)
        {
            if (string.IsNullOrEmpty(additionalFilter))
                return additionalFilter;

            if (additionalFilter.StartsWith('(') && additionalFilter.EndsWith(')'))
                return string.Format(BaseListUsersFilter, additionalFilter);
            else
                return string.Format(BaseListUsersFilter, $"({additionalFilter})");
        }

        private static (DataTable, int) SearchDirectory(DirectoryEntry entry, IList<Mapping> mappings, int count, string? filter = null)
        {
            var adProperties = mappings.Select(m => m.SourceField).ToArray();
            var result = new DataTable();
            var totalResults = 0;

            using (var searcher = new DirectorySearcher(entry))
            {
                searcher.PropertiesToLoad.Clear();
                searcher.PropertiesToLoad.AddRange(adProperties);
                searcher.PageSize = int.MaxValue;
                searcher.Filter = GetAllUsersFilter(filter);

                using (SearchResultCollection searchResults = searcher.FindAll())
                {
                    int counter = 0;
                    totalResults = searchResults.Count;

                    foreach (var map in mappings)
                    {
                        result.Columns.Add(map.DestinationField);
                    }

                    foreach (SearchResult searchResult in searchResults)
                    {
                        try
                        {
                            if (counter >= count)
                                break;

                            counter++;

                            result.Rows.Add(GetMappedRow(searchResult, mappings));
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, $"Exception reading for preview, will continue");
                        }
                    }
                }
            }

            return (result, totalResults);
        }

        private static object[] GetMappedRow(SearchResult result, IList<Mapping> mappings)
        {
            var row = new object[mappings.Count];

            foreach (var map in mappings.Select((value, i) => new { i, value.SourceField }))
            {
                row[map.i] = GetProperty(result, map.SourceField);
            }

            return row;
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