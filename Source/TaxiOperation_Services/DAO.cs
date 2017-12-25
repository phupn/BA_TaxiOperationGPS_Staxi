using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TaxiOperation_Services;

namespace TaxiOperation
{
    public class DAO : DBObject
    {
        //get tat ca loai xe
        //public DataTable GetLoaiXe()
        //{
        //    return this.RunProcedure("sp_T_TUDIEN_LOAIXE_LayDS", new IDataParameter[] { }, "T_TUDIEN_LOAIXE").Tables[0];
        //}
        private string myConnectionString = "";
        //insert vao bang TaxiOperation
        public int bookTaxi(TaxiOperation taxi)
        {
            int kq = 0;
            SqlParameter[] para = new SqlParameter[]{
              new SqlParameter("TenKhachHang",taxi.TenKhachHang),
              new SqlParameter("PhoneNumber",taxi.SoDienThoai),
              new SqlParameter("DiaChiDonKhach",taxi.DiaChiDon),
              new SqlParameter("LoaiXe",taxi.LoaiXe),
              new SqlParameter("SoLuong",taxi.SoLuongXe),
              new SqlParameter("DiaChiTraKhach",taxi.DiaChiTraKhach),
              new SqlParameter("GhiChuDienThoai",taxi.GhiChu),
              new SqlParameter("GioDon",taxi.GioDon),
              new SqlParameter("Email",taxi.Email),
              new SqlParameter("LenhDienThoai",taxi.LenhDienThoai),
              new SqlParameter("Line",taxi.Line),
              new SqlParameter("Source",taxi.Source)
          };
            if (taxi.brand == Brand.VinhPhuc)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_VinhPhuc"];
            }
            else if (taxi.brand == Brand.HaNam)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_HaNam"];
            }
            else if (taxi.brand == Brand.ThuaThienHue)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_ThuaThienHue"];
            }
            else
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            }
            return SqlHelper.ExecuteNonQuery(myConnectionString, "SP_T_TaxiOperation_BookTaxi", para);
        }

        public long bookTaxi_V2(TaxiOperation taxi)
        {
            int kq = 0;
            SqlParameter[] para = new SqlParameter[]{
              new SqlParameter("TenKhachHang",taxi.TenKhachHang),
              new SqlParameter("PhoneNumber",taxi.SoDienThoai),
              new SqlParameter("DiaChiDonKhach",taxi.DiaChiDon),
              new SqlParameter("LoaiXe",taxi.LoaiXe),
              new SqlParameter("SoLuong",taxi.SoLuongXe),
              new SqlParameter("DiaChiTraKhach",taxi.DiaChiTraKhach),
              new SqlParameter("GhiChuDienThoai",taxi.GhiChu),
              new SqlParameter("GioDon",taxi.GioDon),
              new SqlParameter("Email",taxi.Email),
              new SqlParameter("LenhDienThoai",taxi.LenhDienThoai),
              new SqlParameter("Line",taxi.Line),
              new SqlParameter("Source",taxi.Source),
              new SqlParameter("Lat",taxi.Lat),
              new SqlParameter("Lng",taxi.Lng),
              new SqlParameter("SenderId",taxi.SenderID),
              new SqlParameter("Ext1",taxi.Ext1),
              new SqlParameter("Ext2",taxi.Ext2),
              new SqlParameter("TickedId", SqlDbType.BigInt)
          };
            para[17].Direction = ParameterDirection.Output;

            if (taxi.brand == Brand.VinhPhuc)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_VinhPhuc"];
            }
            else if (taxi.brand == Brand.HaNam)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_HaNam"];
            }
            else if (taxi.brand == Brand.ThuaThienHue)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_ThuaThienHue"];
            }
            else if (taxi.brand == Brand.QuangNinh)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_QuangNinh"];
            } 
            else
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            }
            DataSet dataset = SqlHelper.ExecuteDataset(myConnectionString, "SP_T_TaxiOperation_BookTaxi_V2", para);
            if (dataset != null && dataset.Tables != null && dataset.Tables.Count > 0)
            {
                DataTable dt = dataset.Tables[0];
                return (long)dt.Rows[0][0];
            }
            return 0;
        }

        public List<CallInfo> GetCallsInfo(DateTime CallDate)
        {
            DateTime fromDate = CallDate.Date;
            DateTime toDate = fromDate.AddDays(1);
            SqlParameter[] para = new SqlParameter[]{
              new SqlParameter("FromDate", fromDate),
              new SqlParameter("ToDate", toDate)
            };
            List<CallInfo> lstItem = new List<CallInfo>();
            myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            using (DataSet ds = SqlHelper.ExecuteDataset(myConnectionString, "SP_T_TaxiOperation_GetCallsInfo", para))
            {
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        long ID = Convert.ToInt64(item["ID"]);
                        try
                        {
                            string G5_Type = item["G5_Type"].ToString();
                            string BookId = item["BookId"].ToString();
                            lstItem.Add(
                                new CallInfo()
                                {
                                    AddressPick = item["DiaChiDonKhach"].ToString(),
                                    CallSource = Convert.ToInt16(item["SourceType"]),
                                    CallType = Convert.ToInt16(item["CallType"]),
                                    Region = Convert.ToInt16(item["Vung"]),
                                    UniqueID = item["MPCC_UniqueID"].ToString(),
                                    Phone = item["PhoneNumber"].ToString(),
                                    TripType = Convert.ToInt16(item["TripType"]),
                                    CallStatus = Convert.ToInt16(item["CallStatus"]),
                                    StartTime = Convert.ToDateTime(item["ThoiDiemGoi"])
                                }
                                );

                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError("GetCallsInfo :" + ID, ex);
                            continue;
                        }
                    }
                }
            }
            return lstItem;
        }

        public bool Cancel_Booking_V2(Brand brand, long ID)
        {
            SqlParameter[] para = new SqlParameter[]{
              new SqlParameter("ID",ID)
            };
            if (brand == Brand.VinhPhuc)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_VinhPhuc"];
            }
            else if (brand == Brand.HaNam)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_HaNam"];
            }
            else if (brand == Brand.ThuaThienHue)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_ThuaThienHue"];
            }
            else
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            }
            return SqlHelper.ExecuteNonQuery(myConnectionString, "SP_TAXIOPERATION_CHATBOT_Cancel", para) > 0;
        }

        public DataTable GetThongSoTinhTien(int LoaiXe, Brand brand)
        {
            if (brand == Brand.VinhPhuc)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_VinhPhuc"];
            }
            else if (brand == Brand.HaNam)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_HaNam"];
            }
            else if (brand == Brand.ThuaThienHue)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_ThuaThienHue"];
            }
            else if (brand == Brand.QuangNinh)
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString_QuangNinh"];
            }
            else
            {
                myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            }
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@LoaiXe",SqlDbType.Int)                    
            };
            parameters[0].Value = LoaiXe;

            return RunProcedure("sp_T_TINHTOAN_GIATIEN_NEW_SelectByLoaiXe", parameters, "tblUser").Tables[0];
        }
    }
}