using System.Security.Cryptography;
using System.Text;

namespace ToDolistMVC.HelperClasses
{
    public class CryptoHelper
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("MySecretKey12345"); // 16 bytes
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("MySecretIV123456"); // 16 bytes

        // Encrypt text
        public static string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        // Decrypt text
        public static string Decrypt(string cipherText)
        {
            var buffer = Convert.FromBase64String(cipherText);

            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(buffer);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }

    }
}
