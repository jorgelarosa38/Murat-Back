using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Murat.WebApi.Utilities
{
    public static class AESstring
    {
        static string key = "bXVyYXQtZm9yZGFuLWFudGFtaW5rYQ==";
        public static string iv = "bXVyLWZvci1hbnQ=";

        public static string EncryptAES(string plainText, int keyByteSize = 16, bool useHex = false)
        {
            byte[] keyBytes = new byte[keyByteSize];
            byte[] ivBytes = new byte[16];
            byte[] cipherBytes;

            if (useHex)
            {
                int len = keyByteSize * 2;
                for (int i = 0; i < len; i += 2)
                {
                    keyBytes[i / 2] = Convert.ToByte(key.Substring(i, 2), 16);
                    if (i < 32)
                        ivBytes[i / 2] = Convert.ToByte(iv.Substring(i, 2), 16);
                }
            }
            else
            {
                keyBytes = Encoding.ASCII.GetBytes(key);
                ivBytes = Encoding.ASCII.GetBytes(iv);
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using MemoryStream memoryStream = new MemoryStream();
                using CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(plainText);
                }
                cipherBytes = memoryStream.ToArray();
            }
            return Convert.ToBase64String(cipherBytes);
        }

        public static string DecryptAES(string cipherText, int keyByteSize = 16, bool useHex = false)
        {
            byte[] keyBytes = new byte[keyByteSize];
            byte[] ivBytes = new byte[16];
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            if (useHex)
            {
                int len = keyByteSize * 2;
                for (int i = 0; i < len; i += 2)
                {
                    keyBytes[i / 2] = Convert.ToByte(key.Substring(i, 2), 16);
                    if (i < 32)
                        ivBytes[i / 2] = Convert.ToByte(iv.Substring(i, 2), 16);
                }
            }
            else
            {
                keyBytes = Encoding.ASCII.GetBytes(key);
                ivBytes = Encoding.ASCII.GetBytes(iv);
            }

            using Aes aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = ivBytes;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using MemoryStream memoryStream = new MemoryStream(cipherBytes);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }
    }
}
