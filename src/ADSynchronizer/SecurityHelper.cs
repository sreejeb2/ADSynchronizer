//using System;
//using System.Globalization;
//using System.Security.Principal;
//using System.Text.RegularExpressions;
//using System.Diagnostics.CodeAnalysis;
//using System.DirectoryServices.AccountManagement;
//using System.Security.Claims;
//using System.Threading;
//using FIS.Ambit.Optimist.Core.Helpers;
//using NLog;
//using System.Configuration;
//using System.DirectoryServices;

//namespace frmSyncSettings
//{
//    public static class SecurityHelper
//    {
//        public const string RequestHeaderUserKey = "SID";
//        public const string RequestHeaderUserIdentifierKey = "X-User-Identifier";
//        private static AuthenticationType? _authenticationType;
//        private static MembershipType? _membershipType;

//        public static AuthenticationType AuthenticationType
//        {
//            get
//            {
//                if (_authenticationType == null)
//                {
//                    _authenticationType = AppSettingReader.GetEnumSetting(ApplicationSettingKeys.AuthenticationType,
//                        AuthenticationType.Windows);
//                }

//                return _authenticationType.Value;
//            }
//        }

//        public static MembershipType MembershipType
//        {
//            get
//            {
//                if (_membershipType == null)
//                {
//                    _membershipType = AppSettingReader.GetEnumSetting(ApplicationSettingKeys.MembershipIdentifierType,
//                        MembershipType.Sid);
//                }

//                return _membershipType.Value;
//            }
//        }

//        private static readonly Logger Logger;

//        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline",
//            Justification = "This code is used to initialize logger object")]
//        static SecurityHelper()
//        {
//            Logger = LogManager.GetCurrentClassLogger();
//        }

//        public static string ConvertToSidString(byte[] bytes)
//        {
//            return new SecurityIdentifier(bytes, 0).Value.ToUpper(CultureInfo.CurrentCulture);
//        }

//        public static string GetUserNameFromIdentity(IIdentity identity)
//        {
//            return MembershipType == MembershipType.SamAccountName
//                ? GetSamAccountNameFromDisplayName(identity)
//                : identity.Name;
//        }

//        public static string GetSamAccountNameFromDisplayName(WindowsIdentity windowsIdentity)
//        {
//            if (windowsIdentity == null)
//                return string.Empty;

//            Regex regex = new Regex("\\\\");
//            string samAccountName = windowsIdentity.Name;
//            if (regex.IsMatch(windowsIdentity.Name))
//            {
//                samAccountName = windowsIdentity.Name.Split('\\')[1];
//            }

//            return samAccountName.ToUpper(CultureInfo.CurrentCulture);
//        }

//        public static string GetMembershipKey(ImportableStudent importUser)
//        {
//            switch (SecurityHelper.MembershipType)
//            {
//                case MembershipType.Email:
//                    return importUser.Email;
//                case MembershipType.SamAccountName:
//                    return importUser.SamAccountName;
//                default:
//                    return importUser.Sid;
//            }
//        }

//        public static string GetSamAccountNameFromDisplayName(IIdentity identity)
//        {
//            if (identity == null)
//                return string.Empty;

//            var regex = new Regex("\\\\");
//            var samAccountName = identity.Name;
//            if (regex.IsMatch(identity.Name))
//            {
//                samAccountName = identity.Name.Split('\\')[1];
//            }

//            return samAccountName.ToUpper(CultureInfo.CurrentCulture);
//        }

//        // this method to get Windows identity using useridentifier.
//        // It will look into Ldap server base to find user which is a time consuming.

//        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification =
//            "We don't know what exception may be thrown from the compiler so we catch all.")]
//        public static WindowsIdentity GetWindowsIdentity(string securityIdentifier)
//        {

//            try
//            {
//                if (string.IsNullOrEmpty(securityIdentifier))
//                    return null;
//                var identityType = MembershipType == MembershipType.SamAccountName
//                    ? IdentityType.SamAccountName
//                    : IdentityType.Sid;
//                var user = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), identityType,
//                    securityIdentifier);
//                if (user == null) return null;

//                return GetWindowsIdentityByUserName(user.UserPrincipalName);
//            }
//            catch (Exception ex)
//            {
//                Logger.Error(string.Format(CultureInfo.InvariantCulture, "Unable to get User "), ex);
//                return null;
//            }
//        }

//        // this method will return windows identity based on user Name or SamAccount Name.  it will not lock for user in Ldap 
//        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification =
//            "We don't know what exception may be thrown from the compiler so we catch all.")]
//        public static WindowsIdentity GetWindowsIdentityByUserName(string userName)
//        {

//            try
//            {
//                if (string.IsNullOrEmpty(userName))
//                    return null;

//                var identity = new WindowsIdentity(userName, null);
//                var principal = new ClaimsPrincipal(identity);
//                Thread.CurrentPrincipal = principal;
//                return identity;
//            }
//            catch (Exception ex)
//            {
//                Logger.Error(string.Format(CultureInfo.InvariantCulture, "Unable to get User "), ex);
//                return null;
//            }

//        }
//    }
//}
