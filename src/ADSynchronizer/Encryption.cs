using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADSynchronizer
{
    public class EncryptionEnums
    {
        public enum AlgorythymType
        {
            UnKnown,
            MD5,
            SHA1
        }

        public enum KeySize
        {
            Unknown = 0,
            One_Twenty_Eight = 128,
            One_Ninety_Two = 192,
            Two_Fifty_Six = 256
        }
    }

    public class Encryption
    {
        private static string m_EncryptionKey = "";
        private static string m_SaltValue = "";
        private static readonly int m_PasswordIterations = 2;
        private static string m_Vector = "";
        private static EncryptionEnums.KeySize m_KeySize = EncryptionEnums.KeySize.Unknown;
        private static EncryptionEnums.AlgorythymType m_Algorythm = EncryptionEnums.AlgorythymType.UnKnown;
        public static string EncryptionKey => m_EncryptionKey;
        public static string SaltValue => m_SaltValue;
        public static int PasswordIterations => m_PasswordIterations;
        public static string Vector => m_Vector;
        public static EncryptionEnums.KeySize KeySize => m_KeySize;
        public static EncryptionEnums.AlgorythymType Algorthym => m_Algorythm;

        public static void SetEncryptionKey(string mKey)
        {
            m_EncryptionKey = mKey;
        }

        public static void SetSaltValue(string mKey)
        {
            m_SaltValue = mKey;
        }

        public static void SetVector(string mKey)
        {
            m_Vector = mKey;
        }

        public static void SetKeySize(EncryptionEnums.KeySize mKeySize)
        {
            m_KeySize = mKeySize;
        }

        public static void SetAlgorthym(EncryptionEnums.AlgorythymType mAlgorthym)
        {
            m_Algorythm = mAlgorthym;
        }

        public static string EncryptData(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            if (Encryption.EncryptionKey == "" || Encryption.KeySize ==
                EncryptionEnums.KeySize.Unknown || Encryption.SaltValue == ""
                || Encryption.Algorthym == EncryptionEnums.AlgorythymType.UnKnown)
                throw new Exception("Encryption Values Have Not Been Implemented");

            var initVectorBytes = Encoding.ASCII.GetBytes(Encryption.Vector /*initVector*/);
            var saltValueBytes = Encoding.ASCII.GetBytes(Encryption.SaltValue /*saltValue*/);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            var Algorithm = "";
            switch (Encryption.Algorthym)
            {
                case EncryptionEnums.AlgorythymType.MD5:
                    Algorithm = "MD5";
                    break;
                case EncryptionEnums.AlgorythymType.SHA1:
                    Algorithm = "SHA1";
                    break;
            }

            var KeySize = 1;
            switch (Encryption.KeySize)
            {
                case EncryptionEnums.KeySize.One_Twenty_Eight:
                    KeySize = 128;
                    break;
                case EncryptionEnums.KeySize.One_Ninety_Two:
                    KeySize = 192;
                    break;
                case EncryptionEnums.KeySize.Two_Fifty_Six:
                    KeySize = 256;
                    break;
            }

            var password =
                new PasswordDeriveBytes(Encryption.EncryptionKey,
                    saltValueBytes, Algorithm, Encryption.PasswordIterations);

            var keyBytes = password.GetBytes(KeySize / 8);
            var symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            var encryptor = symmetricKey.CreateEncryptor(keyBytes,
                initVectorBytes);

            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, encryptor,
                CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            var cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            var cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        public static string DecryptData(string cipherText)
        {
            if (Encryption.EncryptionKey == "" || Encryption.KeySize ==
                EncryptionEnums.KeySize.Unknown || Encryption.SaltValue == ""
                || Encryption.Algorthym == EncryptionEnums.AlgorythymType.UnKnown)
                throw new Exception("Encryption Values Have Not Been Implemented");

            var initVectorBytes = Encoding.ASCII.GetBytes(Encryption.Vector);
            var saltValueBytes = Encoding.ASCII.GetBytes(Encryption.SaltValue);
            var cipherTextBytes = Convert.FromBase64String(cipherText);

            var Algorithm = "";
            switch (Encryption.Algorthym)
            {
                case EncryptionEnums.AlgorythymType.MD5:
                    Algorithm = "MD5";
                    break;
                case EncryptionEnums.AlgorythymType.SHA1:
                    Algorithm = "SHA1";
                    break;
            }

            var KeySize = 1;
            switch (Encryption.KeySize)
            {
                case EncryptionEnums.KeySize.One_Twenty_Eight:
                    KeySize = 128;
                    break;
                case EncryptionEnums.KeySize.One_Ninety_Two:
                    KeySize = 192;
                    break;
                case EncryptionEnums.KeySize.Two_Fifty_Six:
                    KeySize = 256;
                    break;
            }

            var password =
                new PasswordDeriveBytes(Encryption.EncryptionKey,
                    saltValueBytes, Algorithm, Encryption.PasswordIterations);

            var keyBytes = password.GetBytes(KeySize / 8);

            var symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            var decryptor =
                symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream =
                new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            var plainTextBytes = new byte[cipherTextBytes.Length];
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            var plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

            return plainText;
        }
    }
}