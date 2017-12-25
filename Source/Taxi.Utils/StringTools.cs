using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Linq;

namespace Taxi.Utils
{
    public class StringTools
    {
        public static string TrimSpace(string str)
        {
            if (str == null) return string.Empty;
            string sT = str.TrimEnd().TrimStart();

            while (sT.Contains("  "))
            {
                sT = sT.Remove(sT.IndexOf("  "), 1);
            }
            return sT;
        }
        public static string LocBoTrungXe(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return str.Split('.').Select(p => p.Trim()).Where(p=>!string.IsNullOrEmpty(p)).Distinct().Aggregate((a, b) => a + '.' + b);
        }
        public static string RemoveSpace(string strTemp)
        {
            if (strTemp == null) return string.Empty;
            string sT = strTemp;
            while (sT.Contains(" "))
            {
                sT = sT.Remove(sT.IndexOf(" "), 1);
            }
            return sT;
        }
        public static string Remove_DauHaiPhay_Dau_Cuoi(string str)
        {
            
            if (str.StartsWith("\""))
            {
                str = str.Substring(1, str.Length-1);  
            }
            if(str.EndsWith( "\""))
            {
                str = str.Substring(0, str.Length-1);
            }

            return str;
        }
        /// <summary>
        ///  remove ky tu 0 o dau
        /// </summary>
        public static string RemoveSoKhongODau(string p)
        {
            while (p.StartsWith("0") && p.Length >0)
                p = p.Substring(1, p.Length - 1);

            return p;
        }
        /// <summary>
        /// line dien thoai
        /// </summary>
        public static string GetLineString(int Line)
        {
            if (Line < 10) 
            {
                return "0" + Line.ToString();
            }
            else
            {
                return Line.ToString();
            }
        }
        /// <summary>
        /// Tra ve chuoi thang co dang '06'
        /// </summary>
       
        public static string GeMonthString(int Months)
        {
            if (Months < 10)
            {
                return "0" + Months.ToString();
            }
            else
            {
                return Months.ToString();
            }
        }

        public static string GeDayString(int Day)
        {
            if (Day < 10)
            {
                return "0" + Day.ToString();
            }
            else
            {
                return Day.ToString();
            }
        }

        public static string GeHourString(int Hour)
        {
            if (Hour < 10)
            {
                return "0" + Hour.ToString();
            }
            else
            {
                return Hour.ToString();
            }
        }

        public static string GeMinuteString(int Minute)
        {
            if (Minute < 10)
            {
                return "0" + Minute.ToString();
            }
            else
            {
                return Minute.ToString();
            }
        }

        public static string GeSecondString(int Second)
        {
            if (Second < 10)
            {
                return "0" + Second.ToString();
            }
            else
            {
                return Second.ToString();
            }
        }

        public static DateTime GetDateFromStringLogFile(string sDate)
        {
            try{
            int Y = int.Parse(sDate.Substring(0, 4).ToString());
            int M = int.Parse(sDate.Substring(5, 2).ToString());
            int D = int.Parse(sDate.Substring(8, 2).ToString());
            int H = int.Parse(sDate.Substring(11, 2).ToString());
            int m = int.Parse(sDate.Substring(14,2).ToString());
            int s = int.Parse(sDate.Substring(17, 2).ToString());

            return new DateTime(Y, M, D, H, m, s);
        }
        catch
        {   
            return DateTime.MinValue ;
        }
        }

        public static DateTime GetDate(string yyyy, string MM, string dd, string HH, string mm, string ss)
        {
            try
            {
                return new DateTime (int.Parse(yyyy),int.Parse (MM),int.Parse (dd),int.Parse (HH),int.Parse (mm),int.Parse (ss));
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }

        }

        public static DateTime GetDate(int yyyy, int MM, int dd, int HH, int mm, int ss)
        {
            try
            {
                return new DateTime( yyyy,  MM,  dd,  HH,  mm,  ss);
            }
            catch 
            {
                return DateTime.MinValue;
            }

        }

        /// <summary>
        /// chuyển đổi SoGiay 135 -> ra "02:15"
        /// </summary>
        public static string ConvertSoGiay_PhutGiay(int SoGiay)
        {
            if (SoGiay >= 0)
            {
                int iPhut = Convert.ToInt32(SoGiay / 60);
                int iGiay = SoGiay - iPhut * 60;

                return StringTools.GeMinuteString(iPhut) + ":" + StringTools.GeSecondString(iGiay);    
            }
            return "00:00";          
        }

        public static string ConvertSoGiay_PhutGiay(int SoPhut,int SoGiay)
        {
            
                int iPhut = SoPhut;
                int iGiay = SoGiay;

                return StringTools.GeMinuteString(iPhut) + ":" + StringTools.GeSecondString(iGiay);
             
             
        }
        /// <summary>
        /// trả về tổng số giây trong một khoảng thời gian
        /// </summary>
        public static int GetSoGiayTuKhoangThoiGian(TimeSpan timeKhoangThoiGian)
        {
            return timeKhoangThoiGian.Hours * 3600 + timeKhoangThoiGian.Minutes * 60 + timeKhoangThoiGian.Seconds;   
        }

        public static int GetDayOfMonth(int Year,int Month)
        {
            return DateTime.DaysInMonth(Year, Month);
        }

        /// <summary>
        /// Mã hóa mật khẩu
        /// </summary>
        public static string EncryptPassword(string Password)
        {
            System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();
            byte[] hashBytes = encoding.GetBytes(Password);

            //Compute the SHA-1 hash
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] cryptPassword = sha1.ComputeHash(hashBytes);

            return BitConverter.ToString(cryptPassword);
        }

        /// <summary>
        /// remove nhưng ký tự đặc biệt của XML, lưu vào DB
        ///  &lt; 
        ///  > -> &gt; 
        ///  " -> &quot; 
        ///  ' -> &apos; 
        ///  & -> &amp; 
        /// </summary>
        public static string RemoveSpCharacterXML(string strXML)
        {
            return strXML.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }

        /// <summary>
        /// hàm trả về chỗi widlcard cho chuối
        /// kieuCuocGoi = GoiDen : 'A'
        /// kieucuocgoi = goidi := 'B'
        /// SoDienThoai = "";
        /// </summary>

        public static string GetFilenameWidlcard(string KyTuDaiDienCuocGoi, string SoDienThoai)
        {
            return "*" + KyTuDaiDienCuocGoi + "*" + SoDienThoai + "*.wav";
        }

        #region String Query
        /// <summary>
        /// Kieu du lieu vung co dang
        /// 1;2;3 Cac vung phan cach bang dau ';' 
        /// --> chuyển đổi về kiểu string có dạng câu query vùng.
        /// </summary>
        public static  string GetSQLStringQueryVung(string Vung , string KyTuPhanCach)
        {
            if (Vung.Length <= 0) return "";

            string[] arrVung = Vung.Split(KyTuPhanCach.ToCharArray());
            string strReturn = " (1<>1) ";
            for (int i = 0; i < arrVung.Length; i++)
            {
                strReturn += "OR   (Vung = " + arrVung[i] + " ) ";
            }
            strReturn = " AND (" + strReturn + ")";
            return strReturn;
        }
        #endregion

        #region-------New v3------------------------
        /// <summary>
        /// hàm thực hiện đưa về chuỗi chuẩn của chuỗi xe nhận
        /// Định nghĩa :
        ///     - Chuỗi xe nhập chuẩn là chuỗi có dạng '2132.4323.9088', '0299'
        /// INPUT
        ///     - Chuỗi xe nhập
        /// OUTPUT 
        ///     - Đưa về dạng chuỗi chuẩn
        /// METHOD
        ///     - Loại bỏ các ký tự khoảng trắng
        ///     - Loại bỏ các ký tự '.' ở hai đầu
        ///     - Loại bỏ các ký tự '..' ở giữa
        /// </summary>
        /// <param name="xeNhan"></param>
        public static string ConvertToChuoiXeNhanChuan(string xeNhan)
        {
            string retXeNhan = xeNhan;
            if (string.IsNullOrEmpty(retXeNhan)) return retXeNhan;
            // Loại bỏ ký tự khoảng trắng.
            while (retXeNhan.Contains(" "))
            {
                retXeNhan = retXeNhan.Remove(retXeNhan.IndexOf(" "), 1);
            }
            // Loại bỏ các ký tự '.' ở hai đầu
            retXeNhan = retXeNhan.TrimEnd(".".ToCharArray());
            retXeNhan = retXeNhan.TrimStart(".".ToCharArray());
            // Loại bỏ các ký tự '..' ở giữa
            while (retXeNhan.Contains(".."))
            {
                retXeNhan = retXeNhan.Remove(retXeNhan.IndexOf(".."), 1);
            }
            return retXeNhan;
        }

        public static string GetXeNhanMoi(string xeNhanCu, string xeNhanMoi)
        {
            //string[] arrXeNhanCu = xeNhanCu.Split('.');
            string[] arrXeNhanMoi = xeNhanMoi.Split('.');
            xeNhanMoi = "";
            foreach (string item in arrXeNhanMoi)
            {
                if (!xeNhanCu.Contains(item))
                {
                    xeNhanMoi = string.Format("{0}{1}.", xeNhanMoi, item);
                }
            }

            return xeNhanMoi.TrimEnd('.');
        }

        /// <summary>
        /// Kiểm tra xem danh sách xe nhận có trùng hay không
        /// </summary>
        /// <param name="DanhSachXe">danh sách xe nhận. cách nhau dấu chấm</param>
        /// <returns></returns>
        public static bool KiemTraTrungLapXeChay(string DanhSachXe)
        {
            string[] arrTaxi = DanhSachXe.Split('.');
            var hash = new HashSet<string>(arrTaxi);
            if (hash.Count < arrTaxi.Length)
            {
                return true;
            }
            //foreach (var str in arrTaxi)
            //    if (hash.Contains(str))
            //        return true;
            return false;
        }

        /// <summary>
        /// Kiểm tra xem xe đón có thuộc xe nhận hay không ?
        /// </summary>
        /// <param name="xeDon">danh sách xe đón(cách nhau bởi dấu chấm)</param>
        /// <param name="xeNhan">danh sách xe nhận(cách nhau bởi dấu chấm)</param>
        /// <returns></returns>
        public static bool KiemTraXeDonThuocXeNhan(string xeDon, string xeNhan)
        {
            if (string.IsNullOrEmpty(xeDon) || string.IsNullOrEmpty(xeNhan)) return true;
            string[] arrXeDon = xeDon.Split(".".ToCharArray());
            for (int i = 0; i < arrXeDon.Length; i++)
            {
                if (!xeNhan.Contains(arrXeDon[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Hàm kiểm tra xe nhận có nằm trong dsXe hệ thống đã nhập
        /// INPUT :
        ///      - xeNhan : 2343.6732.9000
        /// OUPPUT : True : xe nhan nằm trong dsXe của hệ thống
        ///          False: xe nhận không nằm trong ds xe của hệ thống.
        /// </summary>
        /// <param name="xeNhan"></param>
        /// <param name="lstSoHieuXe">Danh Sach xe trong he thong</param>
        /// <returns></returns>
        public static bool KiemTraXeNamTrongHeThong(string xeNhan, List<string> lstSoHieuXe)
        {
            if (lstSoHieuXe == null || lstSoHieuXe.Count <= 0) return false;
            if (string.IsNullOrEmpty(xeNhan)) return true;

            string[] arrXeNhan = xeNhan.Split('.');

            for (int i = 0; i < arrXeNhan.Length; i++)
            {
                if (!lstSoHieuXe.Contains(arrXeNhan[i]))
                    return false;
            }
            return true;
        }
        public static string FormatBuilding(string Building)
        {
            string Address = string.Empty;
            int[] arrINum = new int[4];//1[~] 2[/] 3[-] 4[ ]
            string[] arrRegex = new string[] { "N", "/", "-", " " };
            arrINum[0] = Building.IndexOf(arrRegex[0]);//Số nhà có ngõ[~] đầu tiên hay không
            if (arrINum[0] == 0)
            {
                Address = string.Format("NGÕ {0} ", Building.Substring(arrINum[0] + 1));
            }
            else
            {
                Address = Building + ",";
                string[] arrBuilding = Building.Split(arrRegex[1].ToCharArray());//Số nhà có ngõ, ngách hay không
                if (arrBuilding.Length > 0)
                {
                    if (arrBuilding.Length == 2 && arrBuilding[0].Length > 0 && arrBuilding[1].Length > 0)
                    {
                        Address = string.Format("SỐ {0}, NGÕ {1} ", arrBuilding[0], arrBuilding[1]);
                    }
                    else if (arrBuilding.Length == 3 && arrBuilding[0].Length > 0 && arrBuilding[1].Length > 0 && arrBuilding[2].Length > 0)
                    {
                        Address = string.Format("SỐ {0},NGÕ {1}/{2} ", arrBuilding[0], arrBuilding[1], arrBuilding[2]);
                    }
                }
            }
            return Address;
        }
        #endregion

        /// <summary>
        /// hàm thực hiện lấy số điện thoại chuẩn
        /// Một số cái rule lấy chuẩn.
        ///   - Nếu lớn hơn 11 thì lấy 10 số : ví du : 090906280111  --> 0906280111
        ///   - Nếu bắt đầu là 09, thì chỉ lấy 10 ký tự
        ///   - Nếu bắt đầu bằng 04 thì lấy 10 ký tự
        ///   - Nếu bắt đầu là 01 thì lấy 11 ký tự ()
        /// </summary>
        public static string GetSoDienThoaiChuan(string soDienThoaiRaw, string soCongTy, string DauSoCuaTinh)
        {
            try
            {
                //01698390011
                string ret = string.Empty;

                if (soDienThoaiRaw == null) ret = string.Empty;
                var index = soDienThoaiRaw.IndexOfAny("*&#".ToCharArray()) != -1;
                if (index)
                {
                    soDienThoaiRaw = soDienThoaiRaw.Replace("*", string.Empty);
                    soDienThoaiRaw = soDienThoaiRaw.Replace("&", string.Empty);
                    soDienThoaiRaw = soDienThoaiRaw.Replace("#", string.Empty);
                }
                //Xóa ký tự hai chấm.
                if (soDienThoaiRaw.IndexOf(':') != -1)
                    soDienThoaiRaw = soDienThoaiRaw.Replace(":","");

                soDienThoaiRaw = soDienThoaiRaw.Replace("\0", string.Empty);

                if (soDienThoaiRaw.StartsWith("D"))
                {
                    soDienThoaiRaw.Substring(1, soDienThoaiRaw.Length - 1);
                }
                if (soDienThoaiRaw.EndsWith("C"))
                {
                    soDienThoaiRaw = soDienThoaiRaw.Replace("C", "");
                    // soDienThoaiRaw.Substring(0, soDienThoaiRaw.Length - 2);
                }
                //soDienThoaiRaw = soDienThoaiRaw.Trim(new Char[] { 'D', 'C' });

                if (soDienThoaiRaw.Length <= 8)
                {
                    //Neu bat dau la so 0 thi tra ve luon so dien thoai
                    if (soDienThoaiRaw.StartsWith("0"))
                        ret = soDienThoaiRaw;
                    else
                        //Nguoc lai thi cong them ma vung 052 + 3845999
                        ret = string.Format("{0}{1}", DauSoCuaTinh, soDienThoaiRaw);
                }
                else if (soDienThoaiRaw.Length < 11)
                {
                    ret = soDienThoaiRaw;
                }
                else if (soDienThoaiRaw.Length >= 11)  // lớn hơn 11  -- lỗi số.
                {
                    string temp;
                    if (soDienThoaiRaw.Length > 11)
                    {

                        temp = soDienThoaiRaw.Substring(soDienThoaiRaw.Length - 11, 11);
                        //> 11 số mà ký tự đầu ko phải 0 thì sdt sai
                        if (!temp.StartsWith("0") )
                        {
                            temp = soDienThoaiRaw.Substring(soDienThoaiRaw.Length - 10, 10);
                        }
                        else if (temp.StartsWith("00"))
                        {
                            temp = soDienThoaiRaw.Substring(soDienThoaiRaw.Length - 10, 10);
                        }

                    }
                    else
                    {

                        temp = soDienThoaiRaw;
                        // nếu bắt đầu là đầu số 0 thì trả về luôn
                        if (temp.StartsWith("0")) return temp;
                        else
                        {
                            // cắt lấy 10 số cuối 
                            temp = soDienThoaiRaw.Substring(soDienThoaiRaw.Length - 10, 10);

                        }
                    }
                    ret = temp;
                } 
                // kiểm tra có ký tự lạ
                //bool checkPhoneError = false;
                //int i = 0;
                //while (i < ret.Length && !checkPhoneError)
                //{
                //    if (!char.IsDigit(ret[i])) checkPhoneError = true;
                //    i++;
                //}

                //if (checkPhoneError) ret = soCongTy;

                return ret;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message );
            }
        }


        /// <summary>
        /// hàm thực hiện lấy số điện thoại chuẩn
        /// Một số cái rule lấy chuẩn.
        ///   - Nếu lớn hơn 11 thì lấy 10 số : ví du : 090906280111, D09090628011C  --> 0906280111
        ///   - Nếu bắt đầu là 09, thì chỉ lấy 10 ký tự
        ///   - Nếu bắt đầu bằng 04 thì lấy 10 ký tự
        ///   - Nếu bắt đầu là 01 thì lấy 11 ký tự ()
        /// --SDT Bàn của Viettel : 02416565656
        /// </summary>
        /// <param name="soDienThoaiRaw"></param>
        /// <returns></returns>
        public static string GetSoDienThoaiChuan2(string soDienThoaiRaw, string soCongTy, string DauSoCuaTinh)
        {
            try
            {
                string ret = string.Empty;
                if (soDienThoaiRaw == null) ret = string.Empty;

                #region Xóa các ký tự đặc biệt khi bắt số!
                if (soDienThoaiRaw.IndexOf(':') != -1)
                    soDienThoaiRaw = soDienThoaiRaw.Replace(":", string.Empty);

                new List<string> { "@", ",", ".", ";", "'","&","#","$","%","^","*","(",")","~","`" ,">","<","[","]",":","'","\"","|","\\","/","+","-","_","=","?"}
                    .ForEach(s => soDienThoaiRaw = soDienThoaiRaw.Replace(s, ""));
                soDienThoaiRaw = soDienThoaiRaw.Replace("\0", string.Empty);
                soDienThoaiRaw = soDienThoaiRaw.Replace("*", string.Empty);
                #endregion

                #region Thêm bớt cho đúng định dạng số điện thoại!
                if (soDienThoaiRaw.Length == 7 || soDienThoaiRaw.Length == 8)
                {
                    //Nguoc lai thi cong them ma vung 052 + 3845999
                    ret = string.Format("{0}{1}", DauSoCuaTinh, soDienThoaiRaw);
                }
                else if (soDienThoaiRaw.Length <= 10)
                {
                    if (soDienThoaiRaw.Length == 10 && soDienThoaiRaw.StartsWith("1"))
                    {
                        ret = "0"+soDienThoaiRaw;
                    }
                    else
                    {
                        ret = soDienThoaiRaw;
                    }
                }
                else if (soDienThoaiRaw.Length > 10)  // lớn hơn  = 11  -- lỗi số.
                {
                    string temp;
                    if (soDienThoaiRaw.StartsWith("D"))
                    {
                        soDienThoaiRaw = soDienThoaiRaw.Substring(1, soDienThoaiRaw.Length - 1);
                    }
                    if (soDienThoaiRaw.EndsWith("C"))
                    {
                        soDienThoaiRaw = soDienThoaiRaw.Substring(0, soDienThoaiRaw.Length - 1);
                    }

                    if (soDienThoaiRaw.StartsWith("9") && soDienThoaiRaw.Length>11)
                        soDienThoaiRaw = soDienThoaiRaw.Substring(1, soDienThoaiRaw.Length - 1);

                    if (soDienThoaiRaw.Length > 11)
                        temp = soDienThoaiRaw.Substring(0, 11);
                    else
                        temp = soDienThoaiRaw;

                    if (temp.StartsWith("0"))
                    {
                        if (DauSoCuaTinh.Length > 3)
                            temp = soDienThoaiRaw.Substring(0, 11);
                        else
                        {                            
                            temp = soDienThoaiRaw.Substring(0, 11);
                        }
                    }
                    else
                        //Cắt lấy 10 số cuối 
                        temp = soDienThoaiRaw.Substring(soDienThoaiRaw.Length - 10, 10);
                    ret = temp;
                }
                #endregion              

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Convert có dấu sang không dấu
        /// </summary>
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        /// <summary>
        /// trả về các ký tự đầu tiên trong 1 chuỗi
        /// vd : mot hai ba => mhb
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  08/09/2014   created
        /// </Modified>
        public static string GetFirstsCharOfAString(string str)
        {
            str = ConvertToUnSign(str.Trim());
            string s = string.Empty;
            try
            {
                char[] cs = str.Trim().ToCharArray();
                if (cs.Length > 0)
                {
                    s += cs[0];
                    for (int i = 0; i < cs.Length; i++)
                    {
                        if (Char.IsWhiteSpace(cs[i]) && i + 1 < cs.Length)
                        {
                            s += cs[i + 1];
                        }
                    }
                }
                return s;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// chuyển ký tự tiếng việt thành ko dấu
        /// </summary>
        /// <param name="s">The s.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  08/09/2014   created
        /// </Modified>
        public static string ConvertToUnSign(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }

        /// <summary>
        /// Convert 09 => 849
        /// </summary>
        /// <param name="phonenumber"></param>
        /// <returns></returns>
        public static string ConvertPhoneNumber(string phonenumber)
        {
            if (phonenumber.StartsWith("0"))
            {
                return string.Format("84{0}", phonenumber.Substring(1));
            }
            return phonenumber;
        }
    }
}
