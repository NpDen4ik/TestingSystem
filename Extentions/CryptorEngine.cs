using System;
using System.Security.Cryptography;
using System.Text;

namespace TestingSystem.Extentions
{
    public class CryptorEngine
    {
        public static string Encrypt(string salt, string toEncrypt)
        {
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var hashed5 = new MD5CryptoServiceProvider();
            var keyArray = hashed5.ComputeHash(Encoding.UTF8.GetBytes(salt));
            hashed5.Clear();
            var tades = new TripleDESCryptoServiceProvider
            {
                Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7
            };
            var cTransform = tades.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tades.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        public static string Decrypt(string salt, string cipherString)
        {
            var toEncryptArray = Convert.FromBase64String(cipherString);
            var hashed5 = new MD5CryptoServiceProvider();
            var keyArray = hashed5.ComputeHash(Encoding.UTF8.GetBytes(salt));
            var tades = new TripleDESCryptoServiceProvider
            {
                Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7
            };
            var cTransform = tades.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tades.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }

    }
}