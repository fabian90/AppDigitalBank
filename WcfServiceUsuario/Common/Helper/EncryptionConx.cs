using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WcfServiceUsuario.Common.Helper
{
    public class EncryptionConx
    {

        public static string DecryptConnectionString(string encryptedConnectionString)
        {
            string decryptedConnectionString;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("prueba00000012345678901234567890");
                aesAlg.IV = Encoding.UTF8.GetBytes("uIV16Bytes123456");
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedConnectionString)))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    decryptedConnectionString = srDecrypt.ReadToEnd();
                    return decryptedConnectionString;

                }
            }
        }

        private static byte[] GenerateRandomBytes(int length)
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);
                return randomBytes;
            }
        }
    }
}