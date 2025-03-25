using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace BusWebAPI.Application.Utility
{
    public class EncDecStringSHA256 : IEncDecString
    {
        private readonly IConfiguration _configuration;

        public EncDecStringSHA256(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string DecString(string decString)
        {
            var keyAES = _configuration.GetSection("KeyAES").Value;
            string data = null;
            byte[][] keys = GetHashKeys(keyAES);

            try
            {
                data = DecryptStringFromBytes_Aes(decString, keys[0], keys[1]);
            }
            catch (CryptographicException) { throw; }
            catch (ArgumentNullException) { throw; }

            return data;
        }

        public string EncString(string encString)
        {
            var keyAES = _configuration.GetSection("KeyAES").Value;

            if (keyAES == null || keyAES.Trim() == "")
                throw new ArgumentNullException("key is null or empty");
            string data = null;
            byte[][] keys = GetHashKeys(keyAES);

            try
            {
                data = EncryptStringToBytes_Aes(encString, keys[0], keys[1]);
            }
            catch (CryptographicException) { throw; }
            catch (ArgumentNullException) { throw; }
            return data;
        }
        private byte[][] GetHashKeys(string key)
        {
            byte[][] result = new byte[2][];
            Encoding enc = Encoding.UTF8;
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] rawKey = enc.GetBytes(key);
            byte[] rawIV = enc.GetBytes(key);

            byte[] hashKey = sha256.ComputeHash(rawKey);
            byte[] hashIV = sha256.ComputeHash(rawIV);

            Array.Resize(ref hashIV, 16);

            result[0] = hashKey;
            result[1] = hashIV;

            return result;
        }
        private static string EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt =
                            new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }
        private static string DecryptStringFromBytes_Aes(string cipherTextString, byte[] Key, byte[] IV)
        {
            byte[] cipherText = Convert.FromBase64String(cipherTextString);

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (System.Security.Cryptography.Aes aesAlg = System.Security.Cryptography.Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt =
                            new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
