﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OneTaxi.Utils.Settings
{
    public class UserSettingsReader
    {
        protected XmlDocument _doc = null;
        protected string _encryptionKey;

        public UserSettingsReader(string encryptionKey)
        {
            _encryptionKey = encryptionKey;
            _doc = new XmlDocument();
        }

        /// <summary>
        /// Loads data from the specified file
        /// </summary>
        /// <param name="filename"></param>
        public void Load(string filename)
        {
            try
            {
                _doc.Load(filename);
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// Reads a string value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string Read(string key, string defaultValue)
        {
            string result = ReadNodeValue(key);
            if (result != null)
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads an integer value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int Read(string key, int defaultValue)
        {
            int result;
            string s = ReadNodeValue(key);
            if (int.TryParse(s, out result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads a floating-point value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public double Read(string key, double defaultValue)
        {
            double result;
            string s = ReadNodeValue(key);
            if (double.TryParse(s, out result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads a Boolean value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool Read(string key, bool defaultValue)
        {
            bool result;
            string s = ReadNodeValue(key);
            if (bool.TryParse(s, out result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads a DateTime value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public DateTime Read(string key, DateTime defaultValue)
        {
            DateTime result;
            string s = ReadNodeValue(key);
            if (DateTime.TryParse(s, out result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads an encrypted string value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string ReadEncrypted(string key, string defaultValue)
        {
            string result = ReadNodeValue(key);
            if (result != null)
            {
                SimpleEncryption enc = new SimpleEncryption(_encryptionKey);
                return enc.Decrypt(result);
            }
            return defaultValue;
        }

        /// <summary>
        /// Internal method to read a node from the XML document
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string ReadNodeValue(string key)
        {
            try
            {
                if (_doc != null && _doc.DocumentElement != null)
                {
                    XmlNode node = _doc.DocumentElement.SelectSingleNode(key);
                    if (node != null && !String.IsNullOrEmpty(node.InnerText))
                        return node.InnerText;
                }
            }
            catch (Exception) {  }
          
            return null;
        }
    }
}
