using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSynchronizer
{
    public interface IEncryptionService
    {
        string Decrypt(string encryptedValue);
        string Encrypt(string value);
    }

    public class EncryptionService : IEncryptionService
    {

        public EncryptionService()
        {
            Encryption.SetAlgorthym(EncryptionEnums.AlgorythymType.SHA1);
            Encryption.SetEncryptionKey("|ÁäSè—âþET£]&=É=ÒéîÌ„í¡òUËóªä9J");
            Encryption.SetSaltValue("cHa1n1TsA1T");
            Encryption.SetVector("eKiMNAIlUApdivaD");
            Encryption.SetKeySize(EncryptionEnums.KeySize.Two_Fifty_Six);
        }

        public string Decrypt(string encryptedValue)
        {
            return Encryption.DecryptData(encryptedValue);
        }

        public string Encrypt(string value)
        {
            return Encryption.EncryptData(value);
        }
    }
}
