using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSynchronizer
{
    /// <summary>
    /// http://projects.webappsec.org/w/page/13246947/LDAP%20Injection
    /// </summary>
    public static class LdapCanonicalization
    {
        /// <summary>
        /// Characters that must be escaped in an LDAP filter path
        /// WARNING: Always keep '\\' at the very beginning to avoid recursive replacements
        /// </summary>
        private static readonly char[] LdapFilterEscapeSequence = new[] { '\\', '*', '(', ')', '\0', '/' };

        /// <summary>
        /// Mapping strings of the LDAP filter escape sequence characters
        /// </summary>
        private static readonly string[] LdapFilterEscapeSequenceCharacter = new[] { "\\5c", "\\2a", "\\28", "\\29", "\\00", "\\2f" };

        /// <summary>
        /// Characters that must be escaped in an LDAP DN path
        /// </summary>
        private static readonly char[] LdapDnEscapeSequence = new[] { '\\', ',', '+', '"', '<', '>', ';' };

        /// <summary>
        /// Canonicalize a ldap filter string by inserting LDAP escape sequences.
        /// </summary>
        /// <param name="userInput">User input string to canonicalize</param>
        /// <returns>Canonicalized user input so it can be used in LDAP filter</returns>
        public static string CanonicalizeStringForLdapFilter(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return userInput;
            }

            var name = (string)userInput.Clone();

            for (int charIndex = 0; charIndex < LdapFilterEscapeSequence.Length; ++charIndex)
            {
                int index = name.IndexOf(LdapFilterEscapeSequence[charIndex]);
                if (index != -1)
                {
                    name = name.Replace(new String(LdapFilterEscapeSequence[charIndex], 1), LdapFilterEscapeSequenceCharacter[charIndex]);
                }
            }

            return name;
        }

        /// <summary>
        /// Canonicalize a ldap dn string by inserting LDAP escape sequences.
        /// </summary>
        /// <param name="userInput">User input string to canonicalize</param>
        /// <returns>Canonicalized user input so it can be used in LDAP filter</returns>
        public static string CanonicalizeStringForLdapDN(string userInput)
        {
            if (String.IsNullOrEmpty(userInput))
            {
                return userInput;
            }

            var name = (string)userInput.Clone();

            for (int charIndex = 0; charIndex < LdapDnEscapeSequence.Length; ++charIndex)
            {
                int index = name.IndexOf(LdapDnEscapeSequence[charIndex]);
                if (index != -1)
                {
                    name = name.Replace(new string(LdapDnEscapeSequence[charIndex], 1),
                                        @"\" + LdapDnEscapeSequence[charIndex]);
                }
            }

            return name;
        }

        /// <summary>
        /// Ensure that a user provided string can be plugged into an LDAP search filter 
        /// such that there is no risk of an LDAP injection attack.
        /// </summary>
        /// <param name="userInput">String value to check.</param>
        /// <returns>True if value is valid or null, false otherwise.</returns>
        public static bool IsUserGivenStringPluggableIntoLdapSearchFilter(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return true;
            }

            if (userInput.IndexOfAny(LdapDnEscapeSequence) != -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Ensure that a user provided string can be plugged into an LDAP DN 
        /// such that there is no risk of an LDAP injection attack.
        /// </summary>
        /// <param name="userInput">String value to check.</param>
        /// <returns>True if value is valid or null, false otherwise.</returns>
        public static bool IsUserGivenStringPluggableIntoLdapDN(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return true;
            }

            if (userInput.IndexOfAny(LdapFilterEscapeSequence) != -1)
            {
                return false;
            }

            return true;
        }
    }
}
