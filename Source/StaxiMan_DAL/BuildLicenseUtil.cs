using System;
using System.Security.Cryptography;
using System.Text;

namespace StaxiMan_DAL
{
    public class BuildLicenseUtil
    {
        // Key used to generate encrypted string
        protected static string _key = "binhanh.com/Staxi";

        // Initialization vector for DES encryption routine
        protected static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        /// <summary>
        /// Key used for encryption and decryption
        /// </summary>
        protected static string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public static string BuildEncrypt(string s)
        {
            return Encrypt(s);
        }

        public static string BuildDecrypt(string s)
        {
            return Decrypt(s);
        }
        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="s">String to encrypt</param>
        /// <returns>The encrypted string</returns>
        protected static string Encrypt(string s)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(s);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            des.Key = MD5.ComputeHash(Encoding.UTF8.GetBytes(_key));
            des.IV = IV;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="s">Encrypted string to decrypt</param>
        /// <returns>The unencrypted string</returns>
        protected static string Decrypt(string s)
        {
            try
            {
                byte[] buffer = Convert.FromBase64String(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(Encoding.UTF8.GetBytes(_key));
                des.IV = IV;
                return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        public static int ParentCompanyID { get; set; }
    }
}
