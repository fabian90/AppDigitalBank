using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace monitoreo.Commons.Helper
{
    public class Encryption
    {

        public static string DecryptConnectionString(string encryptedConnectionString)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes("prueba00000012345678901234567890");
            aesAlg.IV = Encoding.UTF8.GetBytes("uIV16Bytes123456");
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedConnectionString));
            using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

            using StreamReader srDecrypt = new StreamReader(csDecrypt);
            string decryptedConnectionString= srDecrypt.ReadToEnd();
            return decryptedConnectionString;
        }

            static byte[] GenerateRandomBytes(int length)
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