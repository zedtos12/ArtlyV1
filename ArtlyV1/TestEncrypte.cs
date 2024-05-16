using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ArtlyV1
{
    public class TestEncrypte
    {
        private static readonly byte[] AesKey = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); // 32 bytes for AES-256
        private static readonly byte[] AesIV = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes for AES block size

        public static void Main()
        {
            string plainText = "ABC123";
            string encryptedText = EncryptText(plainText);
            Console.WriteLine($"Encrypted Text: {encryptedText}");
        }

        private static string EncryptText(string text)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = AesKey;
                aesAlg.IV = AesIV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }
    }
}