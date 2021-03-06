using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Taxi.Utils
{
    /// <summary>
    /// 
    /// </summary>
    
    public static class Global
    {
        #region =============== Common ==============
        private static DateTime _gDateTimeServer;
        /// <summary>
        /// Get datetime from Database Server.
        /// </summary>
        public static DateTime DateTimeServer
        {
            get { return _gDateTimeServer; }
            set { _gDateTimeServer = value; }
        }


        private static bool isInternetStatus;
        /// <summary>
        /// Trạng thái kết nối internet
        /// 
        /// </summary>
        public static bool InternetStatus
        {
            get { return isInternetStatus; }
            set { isInternetStatus = value; }
        }

        public static bool checkInternet()
        {
            try
            {
                System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("www.binhanh.com.vn");
                Global.InternetStatus = true;
                return true;
                
            }
            catch
            {
                Global.InternetStatus = false;
                return false;
            }
        }

        /// <summary>
        /// Convert Text to Image để hiển thị màu chữ cho cảnh báo xe nhận không nằm trong xe đề cử.
        /// </summary>
        /// <param name="XeCB">danh sách Xe cảnh báo</param>
        /// <param name="XeDeCu">danh sách Xe đề cử</param>
        /// <param name="bgColor">Background</param>
        /// <param name="bgColor">Background</param>
        /// <param name="mauChuCanhBao">Màu chữ cảnh báo</param>
        /// <returns>Bitmap image</returns>
        public static Bitmap ConvertTextToImage(string XeCB_TD, string XeCB, string XeDeCu, Color bgColor, Color mauChuCanhBao, int ColWidth, int ColHeight, float FontSize)
        {
            int curLen = 0;
            int len = ColWidth;
            Font font = new Font("Time New Roman", FontSize);
            if (!string.IsNullOrEmpty(XeCB) || !string.IsNullOrEmpty(XeCB_TD))
                len = (XeCB.Length *( 8 + (int)FontSize));
            Bitmap bmp = new Bitmap(len, ColHeight);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
              
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);//Vẽ Rectangle
             var sizeF=   graphics.MeasureString(" ", font);
                graphics.FillRectangle(new SolidBrush(bgColor), rect);//Fill Color to Rectagle
              
                   // bmp = new Bitmap(len, ColHeight);
              
                if (XeCB.Length >= 2)
                {
                    string[] ArrXeCB = XeCB.Split('.');
                    string[] ArrXeCB_TD = null;
                    bool isMatTinHieu = false;
                    if (!string.IsNullOrEmpty(XeCB_TD))
                    {
                        ArrXeCB_TD = XeCB_TD.Split(',');
                    }


                    if (ArrXeCB.Length > 0)
                    {
                        for (int i = 0; i < ArrXeCB.Length; i++)
                        {

                            if (ArrXeCB_TD != null && ArrXeCB_TD.Length == ArrXeCB.Length && ArrXeCB_TD[0] != "")
                            {
                                string[] arrXeCB_Detail = ArrXeCB_TD[i].Split('_');
                                //Neu trang thai = -1 thi xe dang mat tin hieu
                                if (arrXeCB_Detail.Length > 3 && arrXeCB_Detail[4] == "-1")
                                    isMatTinHieu = true;
                                else
                                    isMatTinHieu = false;
                            }
                            if (i == 0)
                            {
                                if (isMatTinHieu)
                                    graphics.DrawString(ArrXeCB[i], font, new SolidBrush(Color.Green), 0, 0);
                                else
                                {
                                    if (XeDeCu.Contains(ArrXeCB[i]))
                                        graphics.DrawString(ArrXeCB[i], font, new SolidBrush(Color.Black), 0, 0);
                                    else
                                        graphics.DrawString(ArrXeCB[i], font, new SolidBrush(mauChuCanhBao), 0, 0);
                                }
                            }
                            else
                            {

                                if (isMatTinHieu)
                                    graphics.DrawString("." + ArrXeCB[i], font, new SolidBrush(Color.Green), (ArrXeCB[0].Length * sizeF.Width + FontSize ) + curLen, 0);
                                else
                                {
                                    if (XeDeCu.Contains(ArrXeCB[i]))
                                        graphics.DrawString("." + ArrXeCB[i], font, new SolidBrush(Color.Black), (ArrXeCB[0].Length * sizeF.Width + FontSize ) + curLen, 0);
                                    else
                                        graphics.DrawString("." + ArrXeCB[i], font, new SolidBrush(mauChuCanhBao), (ArrXeCB[0].Length * sizeF.Width + FontSize ) + curLen, 0);
                                }
                                curLen = curLen + (int)((ArrXeCB[0].Length +1)* sizeF.Width + FontSize);
                                 // curLen = curLen + (ArrXeCB[i].Length * 7) + 4;
                            }
                        }
                    }
                    else
                    {
                        if (XeDeCu.Contains(XeCB))
                            graphics.DrawString(XeCB, font, new SolidBrush(Color.Black), 0, 0);
                        else
                            graphics.DrawString(XeCB, font, new SolidBrush(mauChuCanhBao), 0, 0);
                    }
                }
                graphics.Flush(); 
               
            }
            return bmp;
        }

        public static Bitmap ConvertTextToImage(string XeCB_TD, string XeCB, string XeDeCu, Color bgColor, Color mauChuCanhBao, int ColWidth, int ColHeight, float FontSize ,Graphics g)
        {
            int curLen = 0;
            int len = ColWidth;
            Font font = new Font("Time New Roman", FontSize);
            var sizeF = g.MeasureString(" ", font);
           
            if (!string.IsNullOrEmpty(XeCB))
                len = (int)(XeCB.Length * sizeF.Width);
             if(!string.IsNullOrEmpty(XeCB_TD))
                 len = (int)(XeCB_TD.Length * sizeF.Width);
            Bitmap bmp = new Bitmap(len, ColHeight);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {

                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);//Vẽ Rectangle
                
                graphics.FillRectangle(new SolidBrush(bgColor), rect);//Fill Color to Rectagle

                // bmp = new Bitmap(len, ColHeight);

                if (XeCB.Length >= 2)
                {
                    string[] ArrXeCB = XeCB.Split('.');
                    string[] ArrXeCB_TD = null;
                    bool isMatTinHieu = false;
                    if (!string.IsNullOrEmpty(XeCB_TD))
                    {
                        ArrXeCB_TD = XeCB_TD.Split(',');
                    }


                    if (ArrXeCB.Length > 0)
                    {
                        for (int i = 0; i < ArrXeCB.Length; i++)
                        {

                            if (ArrXeCB_TD != null && ArrXeCB_TD.Length == ArrXeCB.Length && ArrXeCB_TD[0] != "")
                            {
                                string[] arrXeCB_Detail = ArrXeCB_TD[i].Split('_');
                                //Neu trang thai = -1 thi xe dang mat tin hieu
                                if (arrXeCB_Detail.Length > 3 && arrXeCB_Detail[4] == "-1")
                                    isMatTinHieu = true;
                                else
                                    isMatTinHieu = false;
                            }
                            if (i == 0)
                            {
                                if (isMatTinHieu)
                                    graphics.DrawString(ArrXeCB[i], font, new SolidBrush(Color.Green), 0, 0);
                                else
                                {
                                    if (XeDeCu.Contains(ArrXeCB[i]))
                                        graphics.DrawString(ArrXeCB[i], font, new SolidBrush(Color.Black), 0, 0);
                                    else
                                        graphics.DrawString(ArrXeCB[i], font, new SolidBrush(mauChuCanhBao), 0, 0);
                                }
                            }
                            else
                            {

                                if (isMatTinHieu)
                                    graphics.DrawString("." + ArrXeCB[i], font, new SolidBrush(Color.Green), (ArrXeCB[0].Length * sizeF.Width + FontSize) + curLen, 0);
                                else
                                {
                                    if (XeDeCu.Contains(ArrXeCB[i]))
                                        graphics.DrawString("." + ArrXeCB[i], font, new SolidBrush(Color.Black), (ArrXeCB[0].Length * sizeF.Width + FontSize) + curLen, 0);
                                    else
                                        graphics.DrawString("." + ArrXeCB[i], font, new SolidBrush(mauChuCanhBao), (ArrXeCB[0].Length * sizeF.Width + FontSize) + curLen, 0);
                                }
                                curLen = curLen + (int)((ArrXeCB[0].Length + 1) * sizeF.Width + FontSize);
                                // curLen = curLen + (ArrXeCB[i].Length * 7) + 4;
                            }
                        }
                    }
                    else
                    {
                        if (XeDeCu.Contains(XeCB))
                            graphics.DrawString(XeCB, font, new SolidBrush(Color.Black), 0, 0);
                        else
                            graphics.DrawString(XeCB, font, new SolidBrush(mauChuCanhBao), 0, 0);
                    }
                }
                graphics.Flush();

            }
            return bmp;
        }
        public static Bitmap ConvertTextToImage2(string XeCB, string XeDenDiem, Color bgColor, Color mauChuCanhBao, int ColWidth, int ColHeight, float FontSize)
        {
            //int len = ColWidth;
            //if (!string.IsNullOrEmpty(XeCB))
            //    len = ColWidth;

            Bitmap bmp = new Bitmap(ColWidth, ColHeight);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);//Vẽ Rectangle
                Font font = new Font("Time New Roman", FontSize);
                graphics.FillRectangle(new SolidBrush(bgColor), rect);//Fill Color to Rectagle
                if (XeCB != null && XeCB.Length >= 3)
                {
                    string[] ArrXeCB = XeCB.Split('.');
                    string[] ArrXeDenDiem = XeDenDiem.Split('.');
                    string strXeCB = "";
                    string strXeDenDiem = "";
                    if (ArrXeDenDiem.Length > 0)
                    {
                        //for (int i = 0; i < ArrXeDenDiem.Length; i++)
                        //{
                        for (int j = 0; j < ArrXeCB.Length; j++)
                        {

                            if (XeDenDiem.Contains(ArrXeCB[j]))
                            {
                                if (strXeCB == "")
                                    strXeCB = ArrXeCB[j];
                                else
                                    strXeCB = string.Format("{0}.{1}", strXeCB, ArrXeCB[j]);
                            }
                            else
                            {
                                if (strXeDenDiem == "")
                                    strXeDenDiem = ArrXeCB[j];
                                else
                                    strXeDenDiem = string.Format("{0}.{1}", strXeDenDiem, ArrXeCB[j]);
                            }
                        }
                        //}
                        if (strXeCB != "")
                        {
                            graphics.DrawString(strXeCB, font, new SolidBrush(mauChuCanhBao), 0, 0);
                        }
                        if (strXeDenDiem != "")
                        {
                            if (strXeCB != "")
                                strXeDenDiem = "." + strXeDenDiem;
                            graphics.DrawString(strXeDenDiem, font, new SolidBrush(Color.Black), strXeCB.Length * 7, 0);
                        }
                    }
                }
                else
                    graphics.DrawString(XeDenDiem, font, new SolidBrush(Color.Black), 0, 0);
                graphics.Flush();
            }
            return bmp;
        }

        public static DataTable GroupBy(string i_sGroupByColumn, string i_sAggregateColumn, DataTable i_dSourceTable)
        {

            DataView dv = new DataView(i_dSourceTable);

            //getting distinct values for group column
            DataTable dtGroup = dv.ToTable(true, new string[] { i_sGroupByColumn });

            //adding column for the row count
            dtGroup.Columns.Add("Count", typeof(int));

            //looping thru distinct values for the group, counting
            foreach (DataRow dr in dtGroup.Rows)
            {
                dr["Count"] = i_dSourceTable.Compute("Count(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
            }

            //returning grouped/counted result
            return dtGroup;
        }

        public static DataTable GroupBy_Multi_Custom(string i_sGroupByColumn, string i_sGroupByColumnCount1, string i_sGroupByColumnCount2, string i_sAggregateColumn, DataTable i_dSourceTable)
        {

            DataView dv = new DataView(i_dSourceTable);

            //getting distinct values for group column
            DataTable dtGroup = dv.ToTable(true, new string[] { i_sGroupByColumn, "MaDoiTac" });

            //adding column for the row count
            dtGroup.Columns.Add(i_sGroupByColumnCount1 + "Count", typeof(int));
            dtGroup.Columns.Add(i_sGroupByColumnCount2 + "Count", typeof(int));
            //DataTable dt = dtGroup.AsEnumerable
            //looping thru distinct values for the group, counting
            foreach (DataRow dr in dtGroup.Rows)
            {
                if (dr["MaDoiTac"].ToString() == i_sGroupByColumnCount2)
                {
                    dr[i_sGroupByColumnCount2 + "Count"] = i_dSourceTable.Compute("Count(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
                }
                else
                {
                    dr[i_sGroupByColumnCount1 + "Count"] = i_dSourceTable.Compute("Count(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
                }
            }

            //returning grouped/counted result
            return dtGroup;
        }
        
        public static CultureInfo CultureSystem
        {
            get {
                    return new CultureInfo("en-US");
                }
            
        }

        private static MoHinh _MoHinh;
        /// <summary>
        /// Mô hình điều hành
        /// </summary>
        public static MoHinh MoHinh
        {
            get
            {
                if (_MoHinh == Utils.MoHinh.None)
                {
                    _MoHinh= ConfigurationManager.AppSettings["MoHinh"] != null ? (MoHinh)Convert.ToInt32(ConfigurationManager.AppSettings["MoHinh"]) : MoHinh.TD_DT;
                }
                return _MoHinh;
            }
            set
            {
                _MoHinh = value;
            }
        }

        private static byte _HasInternet;
        /// <summary>
        /// Dùng SMS hay điều hành
        /// </summary>
        public static byte HasInternet
        {
            get
            {
                _HasInternet = ConfigurationManager.AppSettings["HasInternet"] != null ? Convert.ToByte(ConfigurationManager.AppSettings["HasInternet"]) : Convert.ToByte(1);

                return _HasInternet;
            }
        }

        /// <summary>
        /// Cho phép điện thoại nhập xe hay không
        /// </summary>
        /// <value>
        /// <c>true</c> if [cho phep dien thoai nhap xe]; otherwise, <c>false</c>.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/11/2015   created
        /// </Modified>
        public static bool ChoPhepDienThoaiNhapXe
        {
            get
            {
                return ConfigurationManager.AppSettings["ChoPhepDienThoaiNhapXe"] != null ? Convert.ToByte(ConfigurationManager.AppSettings["ChoPhepDienThoaiNhapXe"]) == 1 : true;
            }
        }

        /// <summary>
        /// Không check xe online
        /// </summary>
        public static bool KhongCheckXeOnline
        {
            get
            {
                return ConfigurationManager.AppSettings["KhongCheckXeOnline"] != null ? Convert.ToByte(ConfigurationManager.AppSettings["KhongCheckXeOnline"]) == 1 : false;
            }
        }

        private static Grid_Config _GridConfig_CuocGoi;
        /// <summary>
        /// Cấu hình hiển thị lưới điều hành
        /// </summary>
        public static Grid_Config GridConfig_CuocGoi
        {
            get
            {
                if (_GridConfig_CuocGoi != null)
                {
                    return ConfigurationManager.AppSettings["GridConfig"] != null ? (Grid_Config)Convert.ToInt32(ConfigurationManager.AppSettings["GridConfig"]) : Grid_Config.Default;
                }
                return Grid_Config.Default;
            }
            set
            {
                _GridConfig_CuocGoi = value;
            }
        }

        public static bool HasCarRole { get; set; }

        private static bool _HasSOS;
        /// <summary>
        /// Cấu hình hiển thị cảnh báo SOS
        /// </summary>
        public static bool HasSOS
        {
            get
            {
                if (_HasSOS != null)
                {
                    return ConfigurationManager.AppSettings["HasSOS"] != null ? Convert.ToInt32(ConfigurationManager.AppSettings["HasSOS"]) == 1 : false;
                }
                return false;
            }
            set
            {
                _HasSOS = value;
            }
        }

        private static bool _RemoveCallAuto;
        /// <summary>
        /// Cấu hình hiển thị cảnh báo SOS
        /// </summary>
        public static bool RemoveCallAuto
        {
            get
            {
                if (_RemoveCallAuto != null)
                {
                    return ConfigurationManager.AppSettings["RemoveCallAuto"] != null ? Convert.ToInt32(ConfigurationManager.AppSettings["RemoveCallAuto"]) == 1 : false;
                }
                return false;
            }
            set
            {
                _RemoveCallAuto = value;
            }
        }
        
        #endregion

        #region =============== Bàn Cờ ==============
        /// <summary>
        /// Nếu trong trường hợp mất internet hoặc chương trình đồng bộ không hoạt động thì active cờ này lên
        /// </summary>
        public static bool HasGPS { get; set; }

        public static TaxiOperation_Module TaxiOperation_Module
        {
            get;
            set;
        }

        private static bool? _isDebug;
        /// <summary>
        /// Cấu hình hiển thị cảnh báo SOS
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                return (bool) (_isDebug ?? (_isDebug = ConfigurationManager.AppSettings["IsDebug"] == "1"));
            }
            set
            {
                _isDebug = value;
            }
        }
        #endregion

        #region =============== Project G5  =========

        public static EnumModule Module;
        public static bool IsDieuSanBay;
        public static bool IsDieuSanBayTongDai;
        public static string LineDuocCapPhep;
        public static string LineDuocCapPhep_MacDinh;
        #endregion

        public static string ExecuteURL(string url)
        {
            if (Debugger.IsAttached) return "";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Credentials = CredentialCache.DefaultCredentials;
                var response = Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null);
                response.Wait();
                //using (Stream responseStream = response.GetResponseStream())
                //{
                //    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                //    return reader.ReadToEnd();
                //}
                response.Result.Close();
                request.Abort();
                return "SUCCESS";
            }
            catch (WebException ex)
            {
                LogErrorUtils.WriteLogError("ProcessGoiDi:", ex);
                return "";
            }
        }
    }

}
