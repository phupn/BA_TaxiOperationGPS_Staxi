using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OneTaxi.Utils.Settings
{


    /// <summary>
    /// Performs simple encryption and decryption
    /// </summary>
    public class SimpleEncryption
    {
        // Key used to generate encrypted string
        private string _key;

        // Initialization vector for DES encryption routine
        private readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        /// <summary>
        /// SimpleEncryption constructor.
        /// </summary>
        /// <param name="key">Key to use for encryption and decryption.</param>
        public SimpleEncryption(string key)
        {
            _key = key;
        }

        /// <summary>
        /// Key used for encryption and decryption
        /// </summary>
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="s">String to encrypt</param>
        /// <returns>The encrypted string</returns>
        public string Encrypt(string s)
        {
            if (s == null) return string.Empty;
            byte[] buffer = Encoding.UTF8.GetBytes(s);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            des.Key = MD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
            des.IV = IV;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="s">Encrypted string to decrypt</param>
        /// <returns>The unencrypted string</returns>
        public string Decrypt(string s)
        {
            try
            {
                byte[] buffer = Convert.FromBase64String(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
                des.IV = IV;
                return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}
