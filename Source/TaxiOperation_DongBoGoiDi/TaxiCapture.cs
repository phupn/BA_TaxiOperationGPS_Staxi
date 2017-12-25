using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Taxi.Business;
using TaxiCapture.Common;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using EFiling.Utils;
using Taxi.Utils;
using System.Drawing;

namespace DongBoGoiDi
{
    public class TaxiCapture
    {
        /// <summary>
        /// so dien thoai da co so 0 o dau
        /// truong hop do dien thoai du thua so cuoi
        /// vi du 0912 345 567 5 thua so (5)
        /// </summary>
        /// <param name="SDT"></param>
        /// <returns></returns>
        public static string LocSoDienThoai(string SDT)
        {
            string Sodienthoai = SDT;
            string sodau = SDT.Substring(1, 1);
            if ((sodau == "4") || (sodau == "9")) Sodienthoai = SDT.Substring(0, 10);
            else if (sodau == "1") Sodienthoai = SDT.Substring(0, 11);

            return Sodienthoai;
        }


        // @PhoneNumber varchar(11),	 
        //@DiaChiKhach nvarchar(255) output,
        //@KieuKhachHangGoiDen char(1)output ,
        //@GiaiMa char(1) Output

        /// <summary>
        /// hamf lay ra dia chi tu mot so dien thoai theo thu tu
        /// -- khach ao
        /// -- khach vip
        /// -- khach moi gioi
        /// -- khach dang hoat dong
        /// -- danh ba riwng cua cong ty
        /// -- danh ba buu dien
        /// neu GiaiMa= true --> giai ma du lieu dia chi
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="KieuKhachHangGoi"></param>
        /// <param name="GiaiMa"></param>
        /// <returns></returns>
        public static string GetAddressFromPhoneNumber(string ConnectString, string PhoneNumber, out EFiling.Utils.KieuKhachHangGoiDen KieuKhachHangGoi, out string MaDoiTac, out int Vung, out bool IsKhachGoiLai)
        {
            try
            {
                bool GiaiMa = false;
                SqlParameter[] parameters = new SqlParameter[] {
                  new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11) ,    
                  new SqlParameter("@DiaChiKhach",SqlDbType.NVarChar ,255) ,
                  new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.VarChar , 1) ,
                  new SqlParameter("@GiaiMa",SqlDbType.VarChar , 1) ,
                   new SqlParameter("@MaDoiTac",SqlDbType.VarChar , 10) ,
                  new SqlParameter("@Vung",SqlDbType.Int),
                   new SqlParameter("@IsGoiLai",SqlDbType.TinyInt) // bit OUTPUT
                };
                parameters[0].Value = PhoneNumber;
                parameters[1].Direction = ParameterDirection.Output;
                parameters[2].Direction = ParameterDirection.Output;
                parameters[3].Direction = ParameterDirection.Output;
                parameters[4].Direction = ParameterDirection.Output;
                parameters[5].Direction = ParameterDirection.Output;
                parameters[6].Direction = ParameterDirection.Output;



                SqlHelper.ExecuteNonQuery(ConnectString, "[DANHBA.sp_GetAddressFromPhoneNumber]", parameters);


                if (parameters[3].Value.ToString() == "1") GiaiMa = true;
                KieuKhachHangGoi = ((EFiling.Utils.KieuKhachHangGoiDen)int.Parse(parameters[2].Value.ToString()));



                string DiaChi = parameters[1].Value.ToString();
                if (GiaiMa)
                {
                    DiaChi = MaHoaDuLieu.GiaiMa(DiaChi);
                }

                MaDoiTac = "";
                Vung = 0;
                if (KieuKhachHangGoi == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    try
                    {
                        Vung = Vung = Convert.ToInt32(parameters[5].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        Vung = 0;
                    }

                    MaDoiTac = parameters[4].Value.ToString();
                }
                IsKhachGoiLai = false;
                try
                {
                    int iT = Convert.ToInt32(parameters[6].Value.ToString());
                    if (iT > 0) IsKhachGoiLai = true;
                }
                catch (Exception ex)
                {
                    IsKhachGoiLai = false;
                }


                return DiaChi;
            }
            catch (Exception ex)
            {
                KieuKhachHangGoi = EFiling.Utils.KieuKhachHangGoiDen.KhachHangBinhThuong;
                MaDoiTac = "";
                Vung = 0;
                IsKhachGoiLai = false;
                return "";
            }
        }



        /// <summary>
        /// lay vi tri cuoi cung cua ban ghi trong file logincoming
        /// </summary>
        /// <param name="FileLogInComingPath"></param>
        /// <returns></returns>
        public static Int32 GetViTriCuoiLogInComing(string FileLogInComingPath)
        {

            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();

            try
            {
                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + FileLogInComingPath);

                string strSQL = "SELECT  count(*) as ViTriCuoiCung FROM SMS_table  ";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();


                Int32 ViTriCuoiCung = -1;
                while (dbReader.Read())
                {
                    try
                    {
                        string strViTriCuoiCung = dbReader["ViTriCuoiCung"].ToString();
                        if (strViTriCuoiCung.Length > 0)
                            ViTriCuoiCung = Int32.Parse(strViTriCuoiCung);
                    }
                    catch (Exception ex)
                    {
                        ViTriCuoiCung = -1;
                        LogError.WriteLogError("Loi doc du lieu LogIncoming, Vi tri cuoi dung", ex);
                    }
                }

                dbReader.Close();
                dbReader.Dispose();

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return ViTriCuoiCung;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi doc du lieu LogIncoming, GetViTriCuoiLogInComing", ex);
                return -1;
            }
        }

        /// <summary>
        ///  lay vi tri cuoi cung cua ban ghi trong file InCom
        /// </summary>
        /// <param name="FileInComPath"></param>
        /// <returns></returns>
        public static Int32 GetViTriCuoiInCom(string FileInComPath)
        {

            OleDbConnection dbConn;
            OleDbCommand dbComm;

            try
            {
                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + FileInComPath);

                string strSQL = "SELECT  count(*) as ViTriCuoiCung FROM  INLOG  ";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();


                Int32 ViTriCuoiCung = -1;
                while (dbReader.Read())
                {
                    try
                    {
                        string strViTriCuoiCung = dbReader["ViTriCuoiCung"].ToString();
                        if (strViTriCuoiCung.Length > 0)
                            ViTriCuoiCung = Int32.Parse(strViTriCuoiCung);
                    }
                    catch (Exception ex)
                    {
                        ViTriCuoiCung = -1;
                        LogError.WriteLogError("Loi doc du lieu LogIncoming, Vi tri cuoi dung", ex);
                    }
                }

                dbReader.Close();
                dbReader.Dispose();

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return ViTriCuoiCung;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi doc du lieu LogIncoming, GetViTriCuoiLogInComing", ex);
                return -1;
            }
        }

        /// <summary>
        /// laays vi tri cuoi fung ca file VOC...
        /// </summary>
        /// <param name="FileVOCPath"></param>
        /// <returns></returns>
        public static Int32 GetViTriCuoiVOC(string FileVOCPath)
        {

            OleDbConnection dbConn;
            OleDbCommand dbComm;

            try
            {
                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + FileVOCPath);

                string strSQL = "SELECT  count(*) as ViTriCuoiCung FROM  VOC  ";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();


                Int32 ViTriCuoiCung = -1;
                while (dbReader.Read())
                {
                    try
                    {
                        string strViTriCuoiCung = dbReader["ViTriCuoiCung"].ToString();
                        if (strViTriCuoiCung.Length > 0)
                            ViTriCuoiCung = Int32.Parse(strViTriCuoiCung);
                    }
                    catch (Exception ex)
                    {
                        ViTriCuoiCung = -1;
                        LogError.WriteLogError("Loi doc du lieu LogIncoming, Vi tri cuoi dung", ex);
                    }
                }

                dbReader.Close();
                dbReader.Dispose();

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return ViTriCuoiCung;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi doc du lieu LogIncoming, GetViTriCuoiLogInComing", ex);
                return -1;
            }
        }

        /// <summary>
        /// ham tra ve ds cac cuoi moi nhat trong logfile
        /// </summary>
        /// <param name="FileLogInComingPath"></param>
        /// <param name="TuViTri"></param>
        /// <param name="DenViTri"></param>
        /// <returns></returns>
        public static List<StructCuocGoi> GetNhungCuocGoiMoiCuaLogInComing(string FileLogInComingPath, int TuViTri, int DenViTri)
        {

            OleDbCommand dbComm = new OleDbCommand();


            List<StructCuocGoi> ListCuocGoiMoi = new List<StructCuocGoi>();
            try
            {
                OleDbDataReader dbReader;

                using (OleDbConnection dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + FileLogInComingPath))
                {

                    string strSQL = "SELECT ChanelNo,InCode, IiDateTime FROM SMS_table ";


                    dbConn.Open();
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbReader = dbComm.ExecuteReader();


                    int iRecordNO = 01;
                    while (dbReader.Read())
                    {

                        // den vi tri moi 
                        if ((iRecordNO > TuViTri) && (iRecordNO <= DenViTri))
                        {
                            StructCuocGoi structCuocGoi = new StructCuocGoi();
                            structCuocGoi.CuocGoiID = -1; // chua co ma cuoc goi
                            structCuocGoi.Line = dbReader["ChanelNo"].ToString();
                            structCuocGoi.PhoneNumber = dbReader["InCode"].ToString();

                            if (dbReader["IiDateTime"].ToString().Length > 0)
                                structCuocGoi.ThoiDiemGoiDen = DateTime.Parse(dbReader["IiDateTime"].ToString());
                            else structCuocGoi.ThoiDiemGoiDen = DateTime.Now;

                            ListCuocGoiMoi.Add(structCuocGoi);
                        }
                        iRecordNO += 1;
                    }


                    dbReader.Close();
                    dbReader.Dispose();
                    dbComm.Dispose();

                    return ListCuocGoiMoi;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi  GetNhungCuocGoiMoiCuaLogInComing TuViTr  ", ex);
                return null;
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }

            }

        }


        /// <summary>
        /// Get cac cuoc goi môi nhất của LogInComming
        ///     UPDATE T1  SET Phonumber = '1'
        ///        WHERe Phonumber in ('012345','01236','012347')
        /// </summary>
        /// <param name="FileLogInComingPath"></param>

        /// <returns></returns>
        public static List<StructCuocGoi> GetNhungCuocGoiMoiCuaLogInComing(string FileLogInComingPath)
        {

            OleDbCommand dbComm = new OleDbCommand();


            List<StructCuocGoi> ListCuocGoiMoi = new List<StructCuocGoi>();
            try
            {
                OleDbDataReader dbReader;

                using (OleDbConnection dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + FileLogInComingPath))
                {

                    string strSQL = "SELECT ChanelNo,InCode, IiDateTime FROM SMS_table  WHERE T1 <> '1' ORDER BY IiDateTime DESC";


                    dbConn.Open();
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbReader = dbComm.ExecuteReader();

                    string SQLQueries = " IN (";
                    bool bHasData = false;
                    while (dbReader.Read())
                    {
                        string Line = string.Format("{0}", Convert.ToInt16(dbReader["ChanelNo"].ToString()));
                        if (IsLineOfTaxiOperation(Line))
                        {

                            StructCuocGoi structCuocGoi = new StructCuocGoi();
                            structCuocGoi.CuocGoiID = -1; // chua co ma cuoc goi
                            structCuocGoi.Line = Line;

                            structCuocGoi.PhoneNumber = dbReader["InCode"].ToString();


                            if (dbReader["IiDateTime"].ToString().Length > 0)
                            {
                                DateTime ThoiDiemGoiDen = DateTime.Parse(dbReader["IiDateTime"].ToString());
                                Random ran = new Random();
                                structCuocGoi.ThoiDiemGoiDen = new DateTime(ThoiDiemGoiDen.Year, ThoiDiemGoiDen.Month, ThoiDiemGoiDen.Day, ThoiDiemGoiDen.Hour, ThoiDiemGoiDen.Minute, ThoiDiemGoiDen.Second, ran.Next(1, 999));
                            }
                            else structCuocGoi.ThoiDiemGoiDen = DateTime.Now;


                            structCuocGoi.ThoiDiemKhongNhacMay = DateTime.MinValue;
                            structCuocGoi.ThoiDiemNgheMay = DateTime.MinValue;

                            ListCuocGoiMoi.Add(structCuocGoi);

                            SQLQueries += "'" + structCuocGoi.PhoneNumber + "',";
                            bHasData = true;
                        }
                    }
                    if (bHasData)
                    {
                        SQLQueries.Remove(SQLQueries.Length - 1, 1); // xóa ký tự ","
                        SQLQueries = SQLQueries + ") ";

                        //Thiet lap T=1 den danh dau nhung cuoc goi da nhan
                        strSQL = "UPDATE  SMS_table SET T1 = '1' WHERE T1 <> '1' AND  ( InCode  " + SQLQueries + ")";

                        try
                        {
                            dbComm = new OleDbCommand(strSQL, dbConn);
                            dbComm.ExecuteNonQuery();
                        }
                        catch (Exception ext)
                        {
                            LogError.WriteLogError("Loi UPDATE LogInCom trong GetNhungCuocGoiMoiCuaLogInComing ", ext);
                            return null;
                        }
                    }

                    dbReader.Close();
                    dbReader.Dispose();
                    dbComm.Dispose();

                    return ListCuocGoiMoi;
                }
            }
            catch (Exception ex)
            {

                LogError.WriteLogError("Loi  GetNhungCuocGoiMoiCuaLogInComing ", ex);
                return null;
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }

            }

        }
        /// <summary>
        /// kiểm tra xem line này có nằm trong các line của hệ thông điên thoại được cấp phép không.
        /// </summary>
        /// <param name="Line"></param>
        /// <returns></returns>
        public static bool IsLineOfTaxiOperation(string Line)
        {
            string[] arrLinesTaxi = ThongTinCauHinh.CacLineCuaTaxiOperation.Split(";".ToCharArray());

            for (int i = 0; i < arrLinesTaxi.Length; i++)
            {
                if (arrLinesTaxi[i].ToString() == Line) return true;
            }

            return false;
        }

        /// <summary>
        /// lấy thông tin cuộc goị nhớ của số máy đã có trong LogInComing
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="StartTime"></param>
        /// <param name="FileInComPath"></param>
        /// <returns></returns>
        public static DateTime GetThongTinCuaCuocGoiNhoInCom(string PhoneNumber, DateTime StartTime, string FileInComPath)
        {
            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();
            try
            {
                DateTime dateTime = DateTime.MinValue; ;


                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + FileInComPath);

                string strSQL = "SELECT  *  FROM inlog WHERE (incode ='" + PhoneNumber + "') AND (settime >= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", StartTime) + "' )";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();
                bool HasData = false;
                while (dbReader.Read())
                {
                    dateTime = DateTime.Parse(dbReader["settime"].ToString());
                    HasData = true;
                    break;
                }
                dbReader.Close();

                if (HasData)
                {
                    //Thiet lap T=1 den danh dau nhung cuoc goi da nhan
                    strSQL = "DELETE FROM inlog  WHERE (incode ='" + PhoneNumber + "') AND    (settime >= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", StartTime) + "' )";
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbComm.ExecuteNonQuery();


                }
                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return dateTime;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi  GetThongTinCuaCuocGoiNhoInCom ", ex);
                return DateTime.MinValue;
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }
            }

            return DateTime.MinValue;
        }


        /// <summary>
        /// Lay thoi gian thoi diem bat dau nghe
        /// Tim la so chuong do
        /// </summary>
        /// <returns>thoi gian bat dau nhac may nghe</returns>
        public static DateTime GetThongTinCuaCuocGoiDaNgheMay_VOC(string PhoneNumber, DateTime StartTimeCall, string VOCFilenamePath)
        {
            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();
            try
            {
                DateTime dateTime = DateTime.MinValue; ;


                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);

                string strSQL = "SELECT  *  FROM voc WHERE (code ='" + PhoneNumber + "') AND (StartTime >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", StartTimeCall) + "')  AND (Fomin='Incoming') ";

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();

                while (dbReader.Read())
                {
                    dateTime = DateTime.Parse(dbReader["StartTime"].ToString());
                    break;
                }
                dbReader.Close();
                dbReader.Dispose();

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return dateTime;
            }
            catch (Exception ex)
            {

                LogError.WriteLogError("Loi  GetThongTinCuaCuocGoiDaNgheMay_VOC ", ex);
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }

            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// lay thong tin cua VOC tu thoi dieem den thoi diem
        /// </summary>
        /// <param name="TuThoiDiem"></param>
        /// <param name="DenThoiDiem"></param>
        /// <param name="VOCFilenamePath"></param>
        /// <returns></returns>
        public static List<VOC> GetThongTinCuocGoiTrongVOC(DateTime TuThoiDiem, DateTime DenThoiDiem, string VOCFilenamePath)
        {
            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();

            List<VOC> lstVOC = new List<VOC>();
            try
            {
                DateTime dateTime = DateTime.MinValue; ;


                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);

                string strSQL = "SELECT  *  FROM voc WHERE   (StartTime > '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuThoiDiem) + "') AND (StartTime <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenThoiDiem) + "')  ";

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();

                while (dbReader.Read())
                {

                    VOC objVOC = new VOC();
                    //StartTime
                    bool bValidate = true;
                    objVOC.StartTime = DateTime.Parse(dbReader["StartTime"].ToString());

                    try
                    {
                        string sDuration = dbReader["Duration"].ToString();
                        int Hours = Convert.ToInt32(sDuration.Substring(0, 2));
                        int Minute = Convert.ToInt32(sDuration.Substring(3, 2));
                        int Second = Convert.ToInt32(sDuration.Substring(6, 2));



                        objVOC.Duration = new DateTime(1900, 1, 1, Hours, Minute, Second);
                    }
                    catch (Exception ets)
                    {
                        objVOC.Duration = new DateTime(1900, 1, 1, 0, 0, 0);
                        bValidate = false;
                    }
                    if (dbReader["filepalh"] != null)
                    {
                        objVOC.FilePath = dbReader["filepalh"].ToString();
                    }
                    else bValidate = false;
                    if (dbReader["channel"] != null && dbReader["channel"].ToString().Length > 0)
                    {
                        objVOC.Channel = Convert.ToInt32(dbReader["channel"].ToString());
                    }
                    else bValidate = false;
                    if (dbReader["code"] != null)
                    {
                        objVOC.Code = dbReader["code"].ToString();
                    }
                    else bValidate = false;
                    if (dbReader["Fomin"] != null)
                    {
                        objVOC.Fomin = dbReader["Fomin"].ToString();
                    }
                    else bValidate = false;

                    DateTime temp = new DateTime(2011, 1, 1, 0, 0, 0);
                    DateTime temp2 = new DateTime(2100, 1, 1, 0, 0, 0);
                    if (bValidate && objVOC.StartTime > temp && objVOC.StartTime < temp2 && objVOC.Code.Length >= 3)
                        lstVOC.Add(objVOC);
                }

                dbReader.Close();
                dbReader.Dispose();

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return lstVOC;
            }
            catch (Exception ex)
            {

                LogError.WriteLogError("Loi  GetThongTinCuocGoiTrongVOC ", ex);
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }

            }
            return lstVOC;

        }

        /// <summary>
        /// Ham thuc hien lay ra ds cac cuoc goi di, co line dua vao
        /// </summary>
        /// <param name="TuThoiDiem"></param>
        /// <param name="DenThoiDiem"></param>
        /// <param name="VOCFilenamePath"></param>
        /// <param name="listLines"> 35,36,37,38,39,40,41,43,42,44,45,46,47,48,53,54 </param>
        /// <returns></returns>
        public static List<VOC> GetThongTinCuocGoiDiTrongVOC(DateTime TuThoiDiem, DateTime DenThoiDiem, string VOCFilenamePath, string listLines)
        {
            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();

            List<VOC> lstVOC = new List<VOC>();
            try
            {
                DateTime dateTime = DateTime.MinValue; ;


                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);

                string strSQL = "SELECT  *  FROM voc WHERE    Fomin = 'DialOut' AND  (StartTime > '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuThoiDiem) + "') AND (StartTime <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenThoiDiem) + "')  ";
                if (listLines.Length > 0)
                    strSQL += " AND  channel  in (" + listLines + " ) ";

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();

                while (dbReader.Read())
                {

                    VOC objVOC = new VOC();
                    //StartTime
                    bool bValidate = true;
                    objVOC.StartTime = DateTime.Parse(dbReader["StartTime"].ToString());

                    try
                    {
                        string sDuration = dbReader["Duration"].ToString();
                        int Hours = Convert.ToInt32(sDuration.Substring(0, 2));
                        int Minute = Convert.ToInt32(sDuration.Substring(3, 2));
                        int Second = Convert.ToInt32(sDuration.Substring(6, 2));



                        objVOC.Duration = new DateTime(1900, 1, 1, Hours, Minute, Second);
                    }
                    catch (Exception ets)
                    {
                        objVOC.Duration = new DateTime(1900, 1, 1, 0, 0, 0);
                        bValidate = false;
                    }
                    if (dbReader["filepalh"] != null)
                    {
                        objVOC.FilePath = dbReader["filepalh"].ToString();
                    }
                    else bValidate = false;
                    if (dbReader["channel"] != null && dbReader["channel"].ToString().Length > 0)
                    {
                        objVOC.Channel = Convert.ToInt32(dbReader["channel"].ToString());
                    }
                    else bValidate = false;
                    if (dbReader["code"] != null)
                    {
                        objVOC.Code = dbReader["code"].ToString();
                    }
                    else bValidate = false;
                    if (dbReader["Fomin"] != null)
                    {
                        objVOC.Fomin = dbReader["Fomin"].ToString();
                    }
                    else bValidate = false;

                    DateTime temp = new DateTime(2011, 1, 1, 0, 0, 0);
                    DateTime temp2 = new DateTime(2100, 1, 1, 0, 0, 0);
                    if (bValidate && objVOC.StartTime > temp && objVOC.StartTime < temp2 && objVOC.Code.Length >= 3)
                        lstVOC.Add(objVOC);
                }

                dbReader.Close();
                dbReader.Dispose();

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return lstVOC;
            }
            catch (Exception ex)
            {

                LogError.WriteLogError("Loi  GetThongTinCuocGoiTrongVOC ", ex);
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }

            }
            return lstVOC;

        }



        /// <summary>
        /// Get nhung cuoc goi da nghe may co Duration
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="StartTimeCall"></param>
        /// <param name="VOCFilenamePath"></param>
        /// <returns></returns>

        public static bool GetThongTinCuaCuocGoiDaNgheMayCo_Duration_VOC(string PhoneNumber, DateTime StartTimeCallGoi, string VOCFilenamePath, out DateTime StartTimeNghe, out DateTime Duration, out string VoiceFilePath)
        {
            Duration = DateTime.MinValue;
            VoiceFilePath = string.Empty;
            StartTimeNghe = DateTime.MinValue;

            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();
            try
            {
                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);

                string strSQL = "SELECT  *  FROM voc WHERE (code ='" + PhoneNumber + "') AND (StartTime >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", StartTimeCallGoi) + "') AND (Duration <> '00:00:00')  AND (Fomin='Incoming') AND ( LEN (filepalh)>0) ";

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();
                bool HasData = false;
                while (dbReader.Read())
                {
                    //StartTime
                    StartTimeNghe = DateTime.Parse(dbReader["StartTime"].ToString());
                    string sDuration = dbReader["Duration"].ToString();
                    int Hours = Convert.ToInt32(sDuration.Substring(0, 2));
                    int Minute = Convert.ToInt32(sDuration.Substring(3, 2));
                    int Second = Convert.ToInt32(sDuration.Substring(6, 2));

                    Duration = new DateTime(1900, 1, 1, Hours, Minute, Second);
                    VoiceFilePath = dbReader["filepalh"].ToString();

                    HasData = true;
                    break;
                }
                dbReader.Close();
                dbReader.Dispose();


                dbComm.Dispose();
                dbConn.Close();
                dbConn.Dispose();

                return HasData;
            }
            catch (Exception ex)
            {

                LogError.WriteLogError("Loi  GetThongTinCuaCuocGoiDaNgheMayCo_Duration_VOC ", ex);
                return false;
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }
            }
            return false;
        }

        /// <summary>
        /// hàm lấy thông tin tất cả các cuộc gọi có thời điểm 
        /// </summary>
        /// <param name="ThoiDiemLayDuLieu"></param>
        /// <param name="VOCFilenamePath"></param>
        /// <returns></returns>
        public static List<VOC> GetThongTinCuaCuocGoiDaNgheMayCo_Duration_VOC(DateTime ThoiDiemLayDuLieu, string VOCFilenamePath)
        {
            List<VOC> lstVOC = new List<VOC>();



            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();
            try
            {
                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);

                string strSQL = "SELECT  *  FROM voc WHERE  (StartTime >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", ThoiDiemLayDuLieu) + "') AND (Duration <> '00:00:00')  AND ( LEN (filepalh)>0) "; // AND (Fomin='Incoming')

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();

                while (dbReader.Read())
                {
                    VOC objVOC = new VOC();
                    //StartTime
                    objVOC.StartTime = DateTime.Parse(dbReader["StartTime"].ToString());
                    string sDuration = dbReader["Duration"].ToString();
                    int Hours = Convert.ToInt32(sDuration.Substring(0, 2));
                    int Minute = Convert.ToInt32(sDuration.Substring(3, 2));
                    int Second = Convert.ToInt32(sDuration.Substring(6, 2));

                    objVOC.Duration = new DateTime(1900, 1, 1, Hours, Minute, Second);
                    objVOC.FilePath = dbReader["filepalh"].ToString();
                    objVOC.Channel = Convert.ToInt32(dbReader["channel"].ToString());
                    objVOC.Code = dbReader["code"].ToString();
                    objVOC.Fomin = dbReader["Fomin"].ToString();

                    lstVOC.Add(objVOC);

                }
                dbReader.Close();
                dbReader.Dispose();


                dbComm.Dispose();
                dbConn.Close();
                dbConn.Dispose();


            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi  GetThongTinCuaCuocGoiDaNgheMayCo_Duration_VOC ", ex);
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }
            }
            return lstVOC;
        }

        /// <summary>
        /// hàm thực hiện lấy ra các cuộc gọi nhỡ, từ vị trí, đến vị trí
        /// </summary>
        /// <param name="g_FileInComPath"></param>
        /// <param name="g_ViTriCuoiCungInCom"></param>
        /// <param name="DenViTriInCom"></param>
        /// <returns></returns>
        public static List<StructCuocGoi> GetNhungCuocGoiNhoMoiCuaInCom(string FileInComPath, int TuViTri, int DenViTri)
        {

            List<StructCuocGoi> ListCuocGoiNho = new List<StructCuocGoi>();
            OleDbCommand dbComm = new OleDbCommand();
            try
            {
                OleDbDataReader dbReader;

                using (OleDbConnection dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + FileInComPath))
                {

                    string strSQL = "SELECT  incode , channel , settime FROM INLOG ";


                    dbConn.Open();
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbReader = dbComm.ExecuteReader();


                    int iRecordNO = 01;
                    while (dbReader.Read())
                    {
                        // den vi tri moi 
                        if ((iRecordNO > TuViTri) && (iRecordNO <= DenViTri))
                        {
                            StructCuocGoi structCuocGoi = new StructCuocGoi();
                            structCuocGoi.CuocGoiID = -1; // chua co ma cuoc goi
                            structCuocGoi.Line = string.Format("{0}", Convert.ToInt16(dbReader["channel"].ToString())); ;
                            structCuocGoi.PhoneNumber = dbReader["incode"].ToString();

                            if (dbReader["settime"].ToString().Length > 0)
                                structCuocGoi.ThoiDiemKhongNhacMay = DateTime.Parse(dbReader["settime"].ToString());
                            else structCuocGoi.ThoiDiemKhongNhacMay = DateTime.Now;

                            ListCuocGoiNho.Add(structCuocGoi);
                        }

                        iRecordNO += 1;
                    }

                    dbReader.Close();
                    dbReader.Dispose();
                    dbComm.Dispose();

                    return ListCuocGoiNho;
                }
            }
            catch (Exception ex)
            {


                LogError.WriteLogError("Loi  GetNhungCuocGoiNhoMoiCuaInCom ", ex);
                return null;
            }
            finally
            {

                if (dbComm != null)
                    dbComm.Dispose();

            }

        }



        public static List<StructCuocGoi> GetNhungCuocGoiMoiNgheVOC(string FileVOCPath, int TuViTri, int DenViTri)
        {

            OleDbCommand dbComm = new OleDbCommand();

            List<StructCuocGoi> ListCuocGoiMoiNghe = new List<StructCuocGoi>();
            try
            {
                OleDbDataReader dbReader;

                using (OleDbConnection dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + FileVOCPath))
                {

                    string strSQL = "SELECT StartTime ,code FROM VOC ";


                    dbConn.Open();
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbReader = dbComm.ExecuteReader();


                    int iRecordNO = 01;
                    while (dbReader.Read())
                    {
                        // den vi tri moi 
                        if ((iRecordNO > TuViTri) && (iRecordNO <= DenViTri))
                        {
                            StructCuocGoi structCuocGoi = new StructCuocGoi();
                            structCuocGoi.CuocGoiID = -1; // chua co ma cuoc goi

                            structCuocGoi.PhoneNumber = dbReader["code"].ToString();

                            if (dbReader["StartTime"].ToString().Length > 0)
                                structCuocGoi.ThoiDiemNgheMay = DateTime.Parse(dbReader["StartTime"].ToString());
                            else structCuocGoi.ThoiDiemNgheMay = DateTime.Now;

                            ListCuocGoiMoiNghe.Add(structCuocGoi);
                        }
                        iRecordNO += 1;
                    }

                    dbReader.Close();
                    dbReader.Dispose();
                    dbComm.Dispose();

                    return ListCuocGoiMoiNghe;
                }
            }
            catch (Exception ex)
            {

                LogError.WriteLogError("Loi  xoa GetNhungCuocGoiMoiNgheVOC ", ex);
                return null;
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }

            }

        }



        /// <summary>
        /// xoa nhung cuoc goi den cach day 
        /// </summary>
        /// <param name="LogIncomingFullPath"></param>
        /// <returns></returns>
        public static bool DeletePhoneCallLogIncomming(DateTime CurrentTime, string LogIncomingFullPath)
        {
            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();

            try
            {
                DateTime XoaTu = CurrentTime.Subtract(new TimeSpan(0, 0, 0));


                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + LogIncomingFullPath);

                string strSQL = "DELETE  FROM SMS_table WHERE   IiDateTime <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", XoaTu) + "'";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbComm.ExecuteNonQuery();


                return true;
            }
            catch (Exception ex)
            {

                LogError.WriteLogError("Loi Loi xoa DeletePhoneCallLogIncomming ", ex);
                return false;
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }

            }
            return false;
        }

        /// <summary>
        /// xoa nhung cuoc goi den cach day , xoa nhhung cuoc goi den
        /// </summary>
        /// <param name="LogIncomingFullPath"></param>
        /// <returns></returns>
        public static bool DeletePhoneCallVocFile(DateTime CurrentTime, string VOCFilenamePath)
        {
            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();
            try
            {
                DateTime XoaTu = CurrentTime.Subtract(new TimeSpan(0, 0, 0));

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);

                string strSQL = "DELETE  FROM VOC WHERE  (Fomin='Incoming') AND  (Duration <> '00:00:00') AND   StartTime <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", XoaTu) + "'";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbComm.ExecuteNonQuery();

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return true;
            }
            catch (Exception ex)
            {


                LogError.WriteLogError("Loi Loi xoa DeletePhoneCallVocFile ", ex);

                return false;
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }

            }
            return false;
        }


        public static bool DeletePhoneCallVocFile_CuocGoiDi(string VOCFilenamePath)
        {
            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();
            try
            {


                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);

                string strSQL = "DELETE  FROM VOC WHERE  (Fomin='DialOut') ";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbComm.ExecuteNonQuery();

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return true;
            }
            catch (Exception ex)
            {


                LogError.WriteLogError("Loi Loi xoa DeletePhoneCallVocFile ", ex);

                return false;
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }

            }
            return false;
        }

        /// <summary>
        /// xoa nhung cuoc goi nho
        /// </summary>
        /// <param name="LogIncomingFullPath"></param>
        /// <returns></returns>
        public static bool DeletePhoneCallInCom(DateTime CurrentTime, string InComFullPath)
        {
            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();

            try
            {



                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + InComFullPath);

                string strSQL = "DELETE  FROM INLOG   ";


                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbComm.ExecuteNonQuery();


                return true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi Loi xoa DeletePhoneCallLogIncomming ", ex);

                return false;
            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }

            }
            return false;
        }


        /// <summary>
        /// hàm thực hiện lấy giá trị của cuộc gọi PhoneNumber xem cuộc gọi có đã có duration chưa
        /// nếu rồi thì trả về Duration != "00:00:00"
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="ThoiDiemNghe"></param>
        /// <param name="Duration"></param>
        /// <param name="FileAmThanh"></param>
        public static void GetLayDutationCuaCuocGoi_VOC(string FileVOCPath, string PhoneNumber, DateTime ThoiDiemNghe, out string Duration, out string FileAmThanh)
        {
            Duration = "00:00:00";
            FileAmThanh = "";
            OleDbCommand dbComm = new OleDbCommand();


            List<StructCuocGoi> ListCuocGoiNho = new List<StructCuocGoi>();
            try
            {
                OleDbDataReader dbReader;

                using (OleDbConnection dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + FileVOCPath))
                {
                    //VOC(channel,StartTime,Duration,code[phoneNumber], Fomin[Incoming/DialOut],filepalh) 
                    //IiDateTime <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", XoaTu) + "'";
                    string strSQL = "SELECT Duration , filepalh  FROM VOC WHERE  code='" + PhoneNumber + "' AND StartTime= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", ThoiDiemNghe) + "' AND (Fomin='Incoming') ";


                    dbConn.Open();
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbReader = dbComm.ExecuteReader();



                    while (dbReader.Read())
                    {

                        Duration = StringTools.TrimSpace(dbReader["Duration"].ToString());
                        FileAmThanh = StringTools.TrimSpace(dbReader["filepalh"].ToString());
                        break;
                    }

                    dbReader.Close();
                    dbReader.Dispose();
                    dbComm.Dispose();


                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;

                LogError.WriteLogError("Loi GetLayDutationCuaCuocGoi_VOC ", ex);

            }
            finally
            {

                if (dbComm != null)
                {
                    dbComm.Dispose();
                }

            }
        }

        #region THAO TAC VOI DATABASE
        /// <summary>
        /// Chen mot cuoc goi dau vào DB
        /// hàm trả về IDCuocGoi
        /// </summary>
        /// <param name="Line"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="ThoiDiemGoi"></param>
        /// <returns></returns>
        public static long InsertCuocGoiLanDau(string ConnString, string Line, string PhoneNumber, DateTime ThoiDiemGoi)
        {
            long IDCuocGoi = -1; // Loi

            try
            {


                KieuKhachHangGoiDen kieukhachhang;
                kieukhachhang = KieuKhachHangGoiDen.KhachHangBinhThuong;

                string MaDoiTac = "";
                int Vung = 0;
                int iLine = 0;
                bool IsGoiLai = false;  // la cuocs khach goi lai
                try
                {
                    iLine = Convert.ToInt32(Line);
                    if (iLine <= 0) Line = "1";
                }
                catch (Exception ex)
                {
                    Line = "1";
                }



                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,2 ), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ), 
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10  ), 
                    new SqlParameter("@Vung",SqlDbType.Int  ),  // 8
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt) ,
                    new SqlParameter("@CuocGoiLaiIDs",SqlDbType.VarChar ,255) 
                };

                string strDiaChi = StringTools.TrimSpace(TaxiCapture.GetAddressFromPhoneNumber(ConnString, PhoneNumber, out kieukhachhang, out MaDoiTac, out Vung, out IsGoiLai));
                string sID = "";
                if (IsGoiLai) // xu ly chuoi dia chi tra ve // 1929,dia chi
                {
                    sID = strDiaChi.Substring(0, strDiaChi.IndexOf(","));
                    strDiaChi = strDiaChi.Substring(strDiaChi.IndexOf(",") + 1, strDiaChi.Length - (strDiaChi.IndexOf(",") + 1));
                }

                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                parameters[2].Value = ThoiDiemGoi;
                parameters[3].Value = strDiaChi;
                parameters[4].Value = ((int)(KieuKhachHangGoiDen)kieukhachhang).ToString();
                parameters[5].Value = "0"; //((int)(TrangThaiCuocGoi)TrangThaiCuocGoi).ToString();
                parameters[6].Value = "0"; //((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();

                if (kieukhachhang == KieuKhachHangGoiDen.KhachHangMoiGioi || kieukhachhang == KieuKhachHangGoiDen.KhachHangVIP
                    || kieukhachhang == KieuKhachHangGoiDen.KhachHangVang || kieukhachhang == KieuKhachHangGoiDen.KhachHangBac)
                    parameters[7].Value = MaDoiTac;
                else parameters[7].Value = "";

                if (Vung > 0)
                    parameters[8].Value = Vung;
                else
                    parameters[8].Value = 0;

                parameters[9].Direction = ParameterDirection.Output;
                if (IsGoiLai)
                {
                    parameters[10].Value = sID;
                }
                else parameters[10].Value = "";

                int iRet = SqlHelper.ExecuteNonQuery(ConnString, "sp_T_TAXIOPERATION_Insert_CuocGoiLanDauCoDiaChi", parameters);

                if (iRet > 0)
                {
                    IDCuocGoi = long.Parse(parameters[9].Value.ToString());
                }
                else
                    LogError.WriteLogError(" [DL] Chen cuoc goi len dau.", new Exception("Khong cap duoc IDCuocGoi"));

                return IDCuocGoi;
            }
            catch (Exception e)
            {
                LogError.WriteLogError(" [DL] Chen cuoc goi len dau.", e);
                return IDCuocGoi;
            }
        }

        /// <summary>
        /// Update so chuong cua cuoc goi
        /// </summary>
        /// <param name="ConnString"></param>
        /// <param name="IDDieuHanh"></param>

        public static bool Update_DienThoai_SoChuong(string ConnString, long IDDieuHanh, int SoLuotDoChuong)
        {
            try
            {
                //@ID bigint,	
                //@SoLuotDoChuong int,
                //@TrangThaiCuocGoi char(1) 
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@SoLuotDoChuong",SqlDbType.Int)  };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = SoLuotDoChuong;

                rowAffected = SqlHelper.ExecuteNonQuery(ConnString, "[sp_T_TAXIOPERATION_Update_SoChuong]", parameters);

                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                LogError.WriteLogError("Loi Update_DienThoai_SoChuong ", e);
                return false;
            }
        }

        /// <summary>
        /// update thông tin cuộc gọi nhỡ 
        /// 
        /// </summary>
        /// <param name="ConnString"></param>
        /// <param name="IDDieuHanh"></param>
        /// <param name="SoLuotDoChuong"></param>
        /// <param name="GhiChuDienThoai"></param>
        /// <param name="TrangThaiCuocGoi"></param>
        /// <param name="TrangThaiLenh"></param>
        /// <returns></returns>
        public static bool Update_DienThoai_CuocGoiNho(string ConnString, long IDDieuHanh, int SoLuotDoChuong, string GhiChuDienThoai, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh)
        {
            try
            {

                if (IDDieuHanh <= 0) return false; // 

                // không cập nhật trangthaicuocgoi  - sql đặt kieucuocgoi = 7
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@SoLuotDoChuong",SqlDbType.Int),                   
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar,255),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char,1),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1) 
                      
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = SoLuotDoChuong;
                parameters[2].Value = GhiChuDienThoai;
                parameters[3].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[4].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();
                rowAffected = SqlHelper.ExecuteNonQuery(ConnString, "sp_T_TAXIOPERATION_Update_CuocGoiNho", parameters);

                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                LogError.WriteLogError("Loi Update_DienThoai_CuocGoiNho ", e);
                return false;
            }
        }


        /// <summary>
        /// cap nhat thong tin cua cuoc goi da nghe may
        ///   - so chuong
        ///   - duration
        ///   - filevoicepath
        /// </summary>
        /// <param name="ConnString"></param>
        /// <param name="IDDieuHanh"></param>
        /// <param name="SoLuotDoChuong"></param>
        /// <param name="Duration"></param>
        /// <param name="FileVoicePath"></param>
        /// <param name="TrangThaiCuocGoi"></param>
        /// <param name="TrangThaiLenh"></param>
        /// <returns></returns>
        public static bool Update_DienThoai_KetThucCuocGoiDenCoBatMay(string ConnString, long IDDieuHanh, int SoChuong, DateTime Duration, string FileVoicePath, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh)
        {
            try
            {
                if (IDDieuHanh <= 0) return false; // khong ton tai id

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ),
                    new SqlParameter("@SoChuong",SqlDbType.Int ),
                    new SqlParameter("@Duration",SqlDbType.DateTime ),                     
                    new SqlParameter("@FileVoicePath",SqlDbType.VarChar,255),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char,1),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1) 
                      
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = SoChuong;
                parameters[2].Value = Duration;
                parameters[3].Value = FileVoicePath;
                parameters[4].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[5].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();
                rowAffected = SqlHelper.ExecuteNonQuery(ConnString, "sp_T_TAXIOPERATION_UpdateKetThucCuocGoiDenCoBatMay", parameters);

                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                LogError.WriteLogError("[DataLayer]Loi Update_DienThoai_KetThucCuocGoiDenCoBatMay  ", e);
                return false;
            }
        }
        #endregion THAO TAC VOI DATABASE

        /// <summary>
        /// Chen mot cuoc goi khach dat vào DB
        /// hàm trả về IDCuocGoi
        /// </summary>
        /// <param name="ConnString"></param>
        /// <param name="Line"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="ThoiDiemGoi"></param>
        /// <param name="DiaChiDon"></param>
        /// <param name="GhiChu"></param>
        /// <returns></returns>
        public static long InsertCuocGoiLanDau_KhachDat(string ConnString, int Line, int VungKenh, string PhoneNumber, DateTime ThoiDiemGoi, string DiaChiDon, string GhiChu, string LoaiXe, int SoLuong, int KhachDatID, double KinhDo, double ViDo)
        {
            long IDCuocGoi = -1; // Loi

            KieuKhachHangGoiDen kieukhachhang;
            kieukhachhang = KieuKhachHangGoiDen.KhachHangBinhThuong;
            try
            {
                string MaDoiTac = "";
                int Vung = 0;
                bool IsGoiLai = false;  // la cuocs khach goi lai
                if (Line <= 0) Line = 1;

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,5 ), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ), 
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10  ),
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt),
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@LoaiXe",SqlDbType.VarChar, 50 ),
                    new SqlParameter("@SoLuongXe",SqlDbType.Int ),
                    new SqlParameter("@KhachDatID",SqlDbType.Int ),
                    new SqlParameter("@VungKenh",SqlDbType.Int ),
                    new SqlParameter("@KinhDo",SqlDbType.Float ),
                    new SqlParameter("@ViDo",SqlDbType.Float )

                };

                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                parameters[2].Value = ThoiDiemGoi;
                parameters[3].Value = DiaChiDon;
                parameters[4].Value = "0";  // TrangThaiCuocGoi
                parameters[5].Value = "1";  // Trang Thai Len

                //TaxiCapture.GetAddressFromPhoneNumber(ConnString, PhoneNumber, out kieukhachhang, out MaDoiTac, out Vung, out IsGoiLai);
                //string sID = "";
                //if (IsGoiLai) // xu ly chuoi dia chi tra ve // 1929,dia chi
                //{
                //    sID = strDiaChi.Substring(0, strDiaChi.IndexOf(","));
                //    strDiaChi = strDiaChi.Substring(strDiaChi.IndexOf(",") + 1, strDiaChi.Length - (strDiaChi.IndexOf(",") + 1));
                //}

                //if (kieukhachhang == KieuKhachHangGoiDen.KhachHangMoiGioi)
                //    parameters[6].Value = MaDoiTac;
                //else
                parameters[6].Value = "";

                //if (Vung > 0)
                //    parameters[7].Value = Vung;
                //else
                //    parameters[7].Value = 0;

                parameters[7].Direction = ParameterDirection.Output;
                parameters[8].Value = GhiChu;
                parameters[9].Value = LoaiXe;
                parameters[10].Value = SoLuong;
                parameters[11].Value = KhachDatID;
                parameters[12].Value = VungKenh;
                parameters[13].Value = KinhDo;
                parameters[14].Value = ViDo;
                int iRet = SqlHelper.ExecuteNonQuery(ConnString, "V3_SP_T_TAXIOPERATION_INSERT_KHACHDAT", parameters);

                if (iRet > 0)
                {
                    IDCuocGoi = long.Parse(parameters[7].Value.ToString());
                }
                else
                    LogError.WriteLogError(" [DL] Chen cuoc goi len dau.", new Exception("Khong cap duoc IDCuocGoi"));

                return IDCuocGoi;
            }
            catch (Exception e)
            {
                LogError.WriteLogError(" [DL] Chen cuoc goi len dau.", e);
                return IDCuocGoi;
            }
        }


        #region  CUOC GOI DI
        /// <summary>
        /// lay thông tin cuộc gọi đi
        /// </summary>
        /// <param name="VOCFilenamePath"></param>
        /// <returns></returns>
        public static DataTable GetEarlyPhoneDialOut(string VOCFilenamePath)
        {
            DataTable dt = new DataTable();
            OleDbConnection dbConn = new OleDbConnection();
            OleDbCommand dbComm = new OleDbCommand();
            try
            {
                //Line, PhoneNumber,ThoiDiemGoi,DoDaiCuocGoi,VoiceFilePath

                //channel
                DataColumn dcChannel = new DataColumn("Line", Type.GetType("System.String"));
                dt.Columns.Add(dcChannel);
                //StartTime
                DataColumn dcStartTime = new DataColumn("PhoneNumber", Type.GetType("System.String"));
                dt.Columns.Add(dcStartTime);
                //Duration
                DataColumn dcInMemo = new DataColumn("ThoiDiemGoi", Type.GetType("System.DateTime"));
                dt.Columns.Add(dcInMemo);
                //code  
                DataColumn dcCode = new DataColumn("DoDaiCuocGoi", Type.GetType("System.DateTime"));
                dt.Columns.Add(dcCode);
                //Fomin
                DataColumn dcT1 = new DataColumn("VoiceFilePath", Type.GetType("System.String"));
                dt.Columns.Add(dcT1);



                OleDbDataReader dbReader;

                dbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" + VOCFilenamePath);
                //Fomin='DialOut'
                string strSQL = "SELECT  channel,code,StartTime,Duration ,filepalh  FROM VOC WHERE (K1 <> '1') AND (Fomin='DialOut') AND (Duration > '00:00:10') ";

                dbConn.Open();
                dbComm = new OleDbCommand(strSQL, dbConn);
                dbReader = dbComm.ExecuteReader();
                bool boolHasData = false;
                while (dbReader.Read())
                {
                    //Line, PhoneNumber,ThoiDiemGoi,DoDaiCuocGoi,VoiceFilePath
                    DataRow dr = dt.NewRow();
                    dr["Line"] = dbReader["channel"].ToString();
                    dr["PhoneNumber"] = dbReader["code"].ToString();
                    dr["ThoiDiemGoi"] = DateTime.Parse(dbReader["StartTime"].ToString());

                    string sDuration = dbReader["Duration"].ToString();
                    int Hours = Convert.ToInt32(sDuration.Substring(0, 2));
                    int Minute = Convert.ToInt32(sDuration.Substring(3, 2));
                    int Second = Convert.ToInt32(sDuration.Substring(6, 2));
                    dr["DoDaiCuocGoi"] = new DateTime(1900, 1, 1, Hours, Minute, Second);

                    dr["VoiceFilePath"] = dbReader["filepalh"].ToString();

                    dt.Rows.Add(dr);
                    boolHasData = true;
                }

                dbReader.Close();
                dbReader.Dispose();

                if (boolHasData)
                {
                    //Thiet lap T=1 den danh dau nhung cuoc goi da nhan
                    strSQL = "UPDATE  VOC SET K1 = '1' WHERE (K1 <> '1') AND (Fomin='DialOut') AND  (Duration <> '00:00:00')";
                    dbComm = new OleDbCommand(strSQL, dbConn);
                    dbComm.ExecuteNonQuery();
                }

                dbComm.Dispose();

                dbConn.Close();
                dbConn.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception("DL: Không đọc được dữ liệu phần cứng - Doc du lieu cuoc goi di " + s);

            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
                if (dbComm != null)
                {
                    dbComm.Dispose();
                }
                if (dbConn != null)
                {
                    dbConn.Close();
                    dbConn.Dispose();
                }

            }
            return null;
        }

        #endregion
        /// <summary>
        /// hàm trả về ds các cuốc khách mới nhận từ tổng đài (COM port)
        /// </summary>
        /// <returns></returns>
        public static List<StructCuocGoi> GetNhungCuocGoiMoiCuaTongDai_COMPort(string ConnnectString, DateTime ThoiDiemTruocDay/*,out DateTime ThoiDiemDaLay*/)
        {
            List<StructCuocGoi> ListCuocGoiMoi = new List<StructCuocGoi>();
            try
            {
                //[sp_T_LogIncoming_Select] 
                // @ThoiDiemLayTruocDay Datetim
                // @ThoiDiemDaLay  // Max cua gia tri tra ve thoi diem da lay
                //  SELECT [ChanelNo]
                //      ,[Phone]
                //      ,[ThoiDiemGoi]
                //      ,[IsRead]
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ThoiDiemLayTruocDay",SqlDbType.DateTime ), // thoi lan truoc da lay du lieu
                    new SqlParameter("@ThoiDiemDaLay",SqlDbType.DateTime ) 
                };
                parameters[0].Value = ThoiDiemTruocDay;
                parameters[1].Direction = ParameterDirection.Output;

                DataSet ds = SqlHelper.ExecuteDataset(ConnnectString, "sp_T_LogIncoming_Select", parameters);
                //ThoiDiemDaLay = Convert.ToDateTime(parameters[1].Value.ToString());

                DataTable dt = new DataTable(); ;
                if (ds != null)
                    dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        StructCuocGoi structCuocGoi = new StructCuocGoi();
                        structCuocGoi.CuocGoiID = -1; // chua co ma cuoc goi
                        structCuocGoi.Line = dr["ChanelNo"].ToString();

                        structCuocGoi.PhoneNumber = dr["Phone"].ToString();
                        structCuocGoi.ThoiDiemGoiDen = Convert.ToDateTime(dr["ThoiDiemGoi"].ToString());


                        structCuocGoi.ThoiDiemKhongNhacMay = DateTime.MinValue;
                        structCuocGoi.ThoiDiemNgheMay = DateTime.MinValue;

                        ListCuocGoiMoi.Add(structCuocGoi);
                    }
                }
                ds = null;
                dt = null;
                return ListCuocGoiMoi;
            }
            catch (Exception ex)
            {

                LogError.WriteLogError("Loi  GetNhungCuocGoiMoiCuaTongDai_COMPort ", ex);
                //ThoiDiemDaLay = DateTime.Now;
                return null;
            }

        }

        /// <summary>
        /// chen VOC vao db, db se chen vao cac bảng khác
        /// 
        /// </summary>
        /// <param name="objVOC"></param>
        public static bool InsertVOC(VOC Voc, string ConnectString)
        {
            try
            {
                //.[sp_T_VOC_Insert]
                //    @channel INT,
                //    @StartTime Datetime,
                //    @Duration DateTime,
                //    @code varchar(50),
                //    @Fomin varchar(30),
                //    @FilePath varchar (250)
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@channel",SqlDbType.Int ), //0
                    new SqlParameter("@StartTime",SqlDbType.DateTime),                   
                    new SqlParameter("@Duration",SqlDbType.DateTime ),
                    new SqlParameter("@code",SqlDbType.VarChar ,50),
                    new SqlParameter("@Fomin",SqlDbType.VarChar ,30),
                    new SqlParameter("@FilePath",SqlDbType.VarChar ,250) 
                      
                };
                parameters[0].Value = Voc.Channel;
                parameters[1].Value = Voc.StartTime;
                parameters[2].Value = Voc.Duration;
                parameters[3].Value = Voc.Code;
                parameters[4].Value = Voc.Fomin;
                parameters[5].Value = Voc.FilePath;

                rowAffected = SqlHelper.ExecuteNonQuery(ConnectString, "sp_T_VOC_Insert", parameters);

                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                try
                {
                    int rowAffected2 = 0;
                    SqlParameter[] parameters2 = new SqlParameter[] {
                        new SqlParameter("@channel",SqlDbType.Int ), //0
                        new SqlParameter("@StartTime",SqlDbType.DateTime),                   
                        new SqlParameter("@Duration",SqlDbType.DateTime ),
                        new SqlParameter("@code",SqlDbType.VarChar ,50),
                        new SqlParameter("@Fomin",SqlDbType.VarChar ,30),
                        new SqlParameter("@FilePath",SqlDbType.VarChar ,250) 
                          
                    };
                    parameters2[0].Value = Voc.Channel;
                    parameters2[1].Value = DateTime.Now;
                    parameters2[2].Value = Voc.Duration;
                    parameters2[3].Value = Voc.Code;
                    parameters2[4].Value = Voc.Fomin;
                    parameters2[5].Value = Voc.FilePath;

                    rowAffected2 = SqlHelper.ExecuteNonQuery(ConnectString, "sp_T_VOC_Insert", parameters2);

                    return (rowAffected2 > 0);

                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("InsertVOC Channel: " + Voc.Channel.ToString() + " ThoiDiem : " + string.Format("{0: HH:mm:ss dd/MM/yyyy}", Voc.StartTime) + " Duratioon : " + string.Format("{0: HH:mm:ss dd/MM/yyyy}", Voc.Duration) + " Phone : " + Voc.Code + " Formin " + Voc.Fomin + " filepath : " + Voc.FilePath, e);
                }
                return false;
            }
        }

        public static string GetLineDialOutCS(string ConnectString)
        {
            string lines = string.Empty;
            string sql = "  SELECT [ID],[IP_Address],[Line_Vung],[IsMayTinh],[IsHoatDong] FROM  [T_QUANTRICAUHINH_LINEGOIRA] WHERE IsHoatDong = 1 AND IsMayTinh = 2 ";
            DataSet ds = SqlHelper.ExecuteDataset(ConnectString, CommandType.Text, sql);
            //ThoiDiemDaLay = Convert.ToDateTime(parameters[1].Value.ToString());

            DataTable dt = new DataTable(); ;
            if (ds != null)
                dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lines += dr["Line_Vung"].ToString() + ",";
                }
                if (lines.EndsWith(","))
                    lines = lines.Substring(0, lines.Length - 1);
            }
            return lines;
        }
        /// <summary>
        /// hàm thực hiện lấy thông tin check in của nhân viên
        /// </summary>
        /// <param name="ConnectString"></param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <returns></returns>
        public static List<CheckInCheckOut> GetCheckInCheckOut(string ConnectString, DateTime tuNgay, DateTime denNgay)
        {
            List<CheckInCheckOut> listCheckIO = new List<CheckInCheckOut>();
           string sql = string.Empty;
           sql =  " SELECT UPPER(CIO.[Username])Username ,CIO.[ThoiDiemCheckIn] ,CIO.[IPAddress] ,CIO.[ThoiDiemCheckOut]  ,T.Line_Vung ";
           sql += " FROM [T_CHECKIN_CHECKOUT] CIO ";
           sql += " INNER JOIN ";
           sql += " ( ";
	       sql += "   SELECT [IP_Address] ,[Line_Vung]	";     
	       sql += "    FROM  [T_QUANTRICAUHINH_LINEGOIRA] WHERE IsHoatDong = 1 AND IsMayTinh = 2 ";
           sql += "  ) T ";
           sql += "  ON T.[IP_Address] = CIO.IPAddress ";
           sql += "  WHERE CIO.ThoiDiemCheckIn >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", tuNgay) + "' AND CIO.ThoiDiemCheckIn <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", denNgay) + "' ";
           sql += "  ORDER BY Line_Vung ASC , ThoiDiemCheckIn DESC ";

           DataSet ds = SqlHelper.ExecuteDataset(ConnectString, CommandType.Text,sql);
            

            DataTable dt = new DataTable(); ;
            if (ds != null)
                dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CheckInCheckOut checkIO = new CheckInCheckOut();
                    checkIO.UserName =  dr["Username"] == DBNull.Value ? string.Empty  : dr["Username"].ToString();
                    checkIO.TimeCheckIn = dr["ThoiDiemCheckIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["ThoiDiemCheckIn"].ToString());
                    checkIO.TimeCheckOut = dr["ThoiDiemCheckOut"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["ThoiDiemCheckOut"].ToString());
                    checkIO.Line_Vung = dr["Line_Vung"] == DBNull.Value ? string.Empty : dr["Line_Vung"].ToString();
                    checkIO.IPAdress = dr["IPAddress"] == DBNull.Value ? string.Empty : dr["IPAddress"].ToString();
                    if(checkIO.UserName != string.Empty && checkIO.TimeCheckIn != DateTime.MinValue && checkIO.Line_Vung != string.Empty && checkIO.IPAdress != string.Empty )
                        listCheckIO.Add(checkIO);
                }
            }
            return listCheckIO;
        }

        /// <summary>
        /// hàm tìm ra người đang gọi đi của Line, giờ
        /// </summary>
        /// <param name="Line"></param>
        /// <param name="thoiDiemGoi"></param>
        /// <param name="listCheckIO"></param>
        /// <returns>username của line</returns>
        public  static string GetUserGoiDi(string  Line, DateTime thoiDiemGoi, List<CheckInCheckOut> listCheckIO)
        {
            string username = string.Empty;
            List<CheckInCheckOut> subListCheckIO = listCheckIO.FindAll(delegate(CheckInCheckOut checkIO) { return (checkIO.Line_Vung == Line); });
            if(subListCheckIO != null && subListCheckIO.Count >0)
            {
                int index = 0;
                while (index < subListCheckIO.Count &&  Line == subListCheckIO[index].Line_Vung && subListCheckIO[index].TimeCheckIn > thoiDiemGoi)
                {
                    index++;
                }
                if (index < subListCheckIO.Count) // có lấy được 
                {
                    // lấy vị trí INDEX
                    if((subListCheckIO[index].TimeCheckIn <= thoiDiemGoi && subListCheckIO[index].TimeCheckOut >= thoiDiemGoi) // nằm trong khoảng giờ
                        || ((subListCheckIO[index].TimeCheckIn <= thoiDiemGoi && subListCheckIO[index].TimeCheckOut == DateTime.MinValue)) ) // năm trong khoang giờ chưa check out
                    {
                        username = subListCheckIO[index].UserName;
                    }  
                }
            }
            return username;
        }


        public  static void InsertCuocGoiDi(string connectString, VOC cuocGoi, string username)
        {
            string sql = string.Empty;
            try
            {
                sql = " INSERT INTO [T_TAXIOPERATION_CUOCGOIDI] ";
                sql += " (Line ,[PhoneNumber] ,[ThoiDiemGoi] ,[DoDaiCuocGoi] ,[VoiceFilePath] ,[FK_NhanVienID] ,[ThuocViTriGoi]) ";
                sql += string.Format(" VALUES ('{0}','{1}','{2:yyyy-MM-dd HH:mm:ss}','{3:yyyy-MM-dd HH:mm:ss}','{4}','{5}', '2') ", cuocGoi.Channel.ToString(), cuocGoi.Code.Length > 11 ? cuocGoi.Code.Substring(0, 11) : cuocGoi.Code, cuocGoi.StartTime, cuocGoi.Duration, cuocGoi.FilePath, username);

                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(sql, ex);
            }

        }
        /// <summary>
        /// ham thuc hien xoa cuooc goi di trong khooang thoi gian
        /// voi line
        /// </summary>
        /// <param name="connecString"></param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="listLine"></param>
        public static void DeleteXoaCuocGoiDi(string connectString, DateTime tuNgay, DateTime denNgay, string listLine)
        {
            string sql = string.Empty;
            sql = "DELETE  FROM [T_TAXIOPERATION_CUOCGOIDI] ";
            if(listLine!= null && listLine.Length >0)
                sql += " WHERE ThoiDiemGoi >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", tuNgay) + "' AND ThoiDiemGoi <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", denNgay) + "' AND Line IN ("+listLine +") ";
            else 
                sql += " WHERE ThoiDiemGoi >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", tuNgay) + "' AND ThoiDiemGoi <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", denNgay) + "' ";

            SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, sql);
        }
    }
    /// <summary>
    /// lớp chứa dữ liệu file VOC
    /// </summary>
    public class VOC
    {

        private int _channel;  
        /// <summary>
        /// Line - máy số
        /// </summary>
        public int Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }
        private DateTime _StartTime;
        /// <summary>
        /// thời điểm gọi
        /// </summary>
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }

        private DateTime _Duration;
        /// <summary>
        /// khoảng thời gian gọi
        /// </summary>
        public DateTime Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }
        private string _Code;
        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Fomin;
        /// <summary>
        /// định dạng liểu gọi đi hay gọi đến
        /// </summary>
        public string Fomin
        {
            get { return _Fomin; }
            set { _Fomin = value; }
        }

        private string _FilePath;
        /// <summary>
        /// đường dẫn file âm thanh
        /// </summary>
        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }
    }
    /// <summary>
    /// hàm luu bảng cuộc gọi nhỡ
    /// </summary> 
    public class InCom
    {
        private string _InCode;

        public string InCode
        {
            get { return _InCode; }
            set { _InCode = value; }
        }
        private int _Channel;

        public int Channel
        {
            get { return _Channel; }
            set { _Channel = value; }
        }
        private DateTime _Settime;

        public DateTime Settime
        {
            get { return _Settime; }
            set { _Settime = value; }
        }
    }

    /// <summary>
    /// thoong tin user check in
    /// </summary>
    public class CheckInCheckOut
    {
        public string UserName;
        public DateTime TimeCheckIn;
        public DateTime TimeCheckOut;
        public string IPAdress;
        public string Line_Vung;
    }
}
