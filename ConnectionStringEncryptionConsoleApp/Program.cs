using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


class Program
{
    static void Main()
    {
        while (true)
        {

            Console.WriteLine("Ingrese la cadena de conexión:");
            string originalConnectionString = Console.ReadLine();

            string key = "prueba00000012345678901234567890";//16 bit
            string iv = "uIV16Bytes123456";//32 bit

            string encryptedConnectionString = Encrypt(originalConnectionString, key, iv);
            string decryptedConnectionString = Decrypt(encryptedConnectionString, key, iv);

            Console.WriteLine($"Cadena de conexión original: {originalConnectionString}");
            Console.WriteLine($"Cadena de conexión encriptada: {encryptedConnectionString}");
            Console.WriteLine($"Cadena de conexión desencriptada: {decryptedConnectionString}");
        }
    }

    static string Encrypt(string text, string key, string iv)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        aesAlg.IV = Encoding.UTF8.GetBytes(iv);

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        byte[] bytes = Encoding.UTF8.GetBytes(text);

        using MemoryStream msEncrypt = new MemoryStream();
        using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

        csEncrypt.Write(bytes, 0, bytes.Length);
        csEncrypt.FlushFinalBlock();

        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    static string Decrypt(string encryptedText, string key, string iv)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        aesAlg.IV = Encoding.UTF8.GetBytes(iv);

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText));
        using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

        using StreamReader srDecrypt = new StreamReader(csDecrypt);
        return srDecrypt.ReadToEnd();
    }
}