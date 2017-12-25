using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Taxi.Business
{
   public  class MaHoaDuLieu
    {
        public static string MaHoa(string ChuoiCanMaHoa)
        {
            string Khoa = "congquy07";
            if (ChuoiCanMaHoa == "")
            {
                return "";
            }
            try
            {
                byte[] byKey = new byte[0];
                byte[] IV = { 1, 2, 3, 4, 1, 2, 3, 4 };
                byKey = System.Text.Encoding.UTF8.GetBytes(Khoa.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(ChuoiCanMaHoa);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }
        
        public static string GiaiMa(string ChuoiCanGiaiMa)
        {
            string Khoa = "congquy07";
            if (ChuoiCanGiaiMa == "")
                return "";
            try
            {
                byte[] byKey = new byte[0];
                byte[] IV = { 1, 2, 3, 4, 1, 2, 3, 4 };
                byte[] inputByteArray = new byte[ChuoiCanGiaiMa.Length];
                byKey = System.Text.Encoding.UTF8.GetBytes(Khoa.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(ChuoiCanGiaiMa);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }
    }
}
