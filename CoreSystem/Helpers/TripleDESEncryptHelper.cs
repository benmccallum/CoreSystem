using System;
using System.Security.Cryptography;
using System.Text;

namespace CoreSystem.Helpers
{
    /// <summary>
    /// Helper for encrypt/decrypt operations using TripleDES.
    /// </summary>
    public class TripleDESEncryptHelper
    {
        private const string passphrase = "ram's38reLeasejollA48fartHestuNproven26Abjured";

        public static string Encrypt(string cleartext)
        {
            byte[] Results;
            var UTF8 = new UTF8Encoding();

            using (var HashProvider = new MD5CryptoServiceProvider())
            {
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
                using (var TDESAlgorithm = new TripleDESCryptoServiceProvider() { Key = TDESKey, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    byte[] DataToEncrypt = UTF8.GetBytes(cleartext);
                    try
                    {
                        using (ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor())
                        {
                            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                        }
                    }
                    finally
                    {
                        TDESAlgorithm.Clear();
                        HashProvider.Clear();
                    }
                }
            }

            return Convert.ToBase64String(Results);
        }

        public static string Decrypt(string ciphertext)
        {
            byte[] Results;
            var UTF8 = new UTF8Encoding();

            using (var HashProvider = new MD5CryptoServiceProvider())
            {
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
                using (var TDESAlgorithm = new TripleDESCryptoServiceProvider() { Key = TDESKey, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    byte[] DataToDecrypt = Convert.FromBase64String(ciphertext);
                    try
                    {
                        using (ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor())
                        {
                            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                        }
                    }
                    finally
                    {
                        TDESAlgorithm.Clear();
                        HashProvider.Clear();
                    }
                }
            }

            return UTF8.GetString(Results);
        }
    }
}