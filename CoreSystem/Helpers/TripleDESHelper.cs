﻿using CoreSystem.Infrastructure.Config;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CoreSystem.Helpers
{
    /// <summary>
    /// Helper for encrypt/decrypt operations using TripleDES.
    /// </summary>
    public class TripleDESHelper
    {
        private static string passphrase;
        private static string Passphrase
        {
            get
            {
                return passphrase ?? (passphrase = new CoreSystemConfigurationManager().Passphrase);
            }
        }

        private static TripleDESCryptoServiceProvider GetProvider()
        {
            try
            {
                return new TripleDESCryptoServiceProvider
                {
                    Key = Encoding.UTF8.GetBytes(Passphrase),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
            }
            catch (Exception)
            {
                throw new CryptographicException("appSetting CoreSystem.Passphrase must be of correct length (16 chars)");
                throw;
            }
        }

        public static string Encrypt(string cleartext)
        {
            return Convert.ToBase64String(EncryptBytes(Encoding.UTF8.GetBytes(cleartext).Take(24).ToArray()));
        }

        public static string Decrypt(string ciphertext)
        {
            return Encoding.UTF8.GetString(DecryptBytes(Convert.FromBase64String(ciphertext)));
        }
        
        public static byte[] EncryptBytes(byte[] input)
        {
            using (var tripleDES = GetProvider())
            using (var cTransform = tripleDES.CreateEncryptor())
            {
                return Transform(input, cTransform);
            }
        }

        public static byte[] DecryptBytes(byte[] input)
        {
            using (var tripleDES = GetProvider())
            using (var cTransform = tripleDES.CreateDecryptor())
            {
                return Transform(input, cTransform);
            }
        }

        /// <summary>
        /// Encrypt or Decrypt bytes.
        /// </summary>
        private static byte[] Transform(byte[] input, ICryptoTransform cryptoTransform)
        {
            // Create the necessary streams
            using (var memory = new MemoryStream())
            {
                using (var stream = new CryptoStream(memory, cryptoTransform, CryptoStreamMode.Write))
                {
                    // Transform the bytes as requested
                    stream.Write(input, 0, input.Length);
                    stream.FlushFinalBlock();

                    // Read the memory stream and convert it back into byte array
                    memory.Position = 0;
                    var result = new byte[memory.Length];
                    memory.Read(result, 0, result.Length);

                    // Return result
                    return result;
                }
            }
        }
    }
}