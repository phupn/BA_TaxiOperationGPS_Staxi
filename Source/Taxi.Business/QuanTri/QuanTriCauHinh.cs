using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Data;
using Taxi.Utils;
using System.Net.Sockets;

namespace Taxi.Business.QuanTri
{
    public  class QuanTriCauHinh
    {
        public static string IpAddress;
        /// <summary>
        /// Quản lý theo từng máy 1
        /// </summary>
        public static MoHinh MoHinh;

        public static string GetIPPC()
        {
            try
            {
                return getAddress(); 
            } 
            catch (Exception)
            {
                return "";
            } 
        }

        public static string getAddress()
        {
            // First get the host name of local machine.
            String strHostName = "";
            strHostName = Dns.GetHostName();

            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
                         
            string selectedAddress = String.Empty;
            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[i]!=null&&addr[i].AddressFamily != AddressFamily.InterNetworkV6)
                {
                    if ((!IPAddress.IsLoopback(addr[i])) || (addr[i].ToString()=="127.0.0.1"))
                    {
                        if (string.IsNullOrEmpty(Config_Common.IP_DefaultGateway) || (Config_Common.IP_DefaultGateway != "" && addr[i].ToString().Contains(Config_Common.IP_DefaultGateway)))
                        {
                            selectedAddress = addr[i].ToString();
                            break;                            
                        }
                    }
                }
            }             

            return (selectedAddress);
        }
        public static string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                throw new Exception("Local IP Address Not Found!");

            }
            catch (Exception ex) { }
            return string.Empty;
        }
       // tham so
        /// <summary>
        /// tra ve danh sach lines cua PC co dia chi IP duoc cap
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <returns></returns>
        public static string GetLinesOfPCDienThoai(string IPAddress)
        {
            return new Taxi.Data.QuanTri.QuanTriCauHinh().GetLinesOfPCDienThoai(IPAddress);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <returns></returns>
        public static string GetVungsOfPCTongDai(string IPAddress)
        {
            return new Taxi.Data.QuanTri.QuanTriCauHinh().GetVungsOfPCTongDai(IPAddress);
        }

        
            /// <summary>
        /// ham tra ve vung cua mot may tinh 
        /// voi thong tin truyen vao
        ///  IP : dia chi IP cua may
        ///  KieuMayTinh : 'TD', 'CO', 'MK', DT,''
        /// IF NULL thì trả về tất cả máy 
        /// Tra ve : cac vung cua may tinh co the nhan thong tin
        /// </summary>
        public static string GetLineVungOfPC(string IPAddress, string KieuMayTinh)
        {
            return new Data.QuanTri.QuanTriCauHinh().GetLineVungOfPC(IPAddress, KieuMayTinh);
        }

        /// <summary>
        /// lay danh sach cac may tinh dien thoai
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDSMayDienThoai()
        {

            return new Data.QuanTri.QuanTriCauHinh().GetDSMay("DT");  
        }

        /// <summary>
        /// lay danh sach cac may tinh Tong dai 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDSMayTongDai()
        {

            return new Data.QuanTri.QuanTriCauHinh().GetDSMay("TD");  
        }
        /// <summary>
        /// hàm trả về ds máy MoiKhach
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDSMayMoiKhach()
        {
            return new Data.QuanTri.QuanTriCauHinh().GetDSMay( KieuMayTinh.MAYMOIKHACH );  
        }
        /// <summary>
        /// hàm trả về ds máy tính cám ơn khách
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDSMayKhachMoi()
        {
            return new Data.QuanTri.QuanTriCauHinh().GetDSMay(KieuMayTinh.MAYKHACHMOI);
        }
        /// <summary>
        /// hàm trả về ds máy tính mời khách bởi vùng
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        public static List<String> GetDSMayTinhMoiKhachByVung(string Vung)
        {
            return new Data.QuanTri.QuanTriCauHinh().GetDSMayTinhMoiKhachByVung(Vung );
        }

        /// <summary>
        /// luu di chi ip cho may tinh
        ///   - xoa 
        ///   - chen moi
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Line_Vung"></param>
        /// <param name="IsMayTinh"></param>
        /// <param name="g_IsActive"></param>
        /// <returns></returns>
        public static bool InsertIP(string  IP, string  Line_Vung, string IsMayTinh, bool  IsActive,int No)
        {
            return new Data.QuanTri.QuanTriCauHinh().InsertIP(IP, Line_Vung, IsMayTinh, IsActive, No);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Line_Vung"></param>
        /// <param name="IsMayTinh"></param>
        /// <param name="IsActive"></param>
        /// <param name="No"></param>
        /// <param name="Line_Vung_Gop"></param>
        /// <returns></returns>
        public static bool InsertIP_V2(string IP, string Line_Vung, string IsMayTinh, bool IsActive, int No, string Line_Vung_Gop, bool G5Type)
        {
            try
            {
                return new Data.QuanTri.QuanTriCauHinh().InsertIP_V2(IP, Line_Vung, IsMayTinh, IsActive, No, Line_Vung_Gop, G5Type);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("QuanTriCauHinh.InsertIP_V2", ex);
                return false;
            }
            
        } 

        public static bool InsertIP_V3(string IP, string Line_Vung, string IsMayTinh, bool IsActive, int No, string Line_Vung_Gop, bool G5Type, string Extension)
        {
            try
            {
                return new Data.QuanTri.QuanTriCauHinh().InsertIP_V3(IP, Line_Vung, IsMayTinh, IsActive, No, Line_Vung_Gop, G5Type, Extension);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("QuanTriCauHinh.InsertIP_V2", ex);
                return false;
            }

        }

        public static bool Delete(string IP)
        {
            return new Data.QuanTri.QuanTriCauHinh().Delete(IP);
        }

        public static DataTable GetThongTinCauHinh()
        {
            return new Data.QuanTri.QuanTriCauHinh().GetThongTinCauHinh();
        }

        #region -----New V3-----

        /// <summary>
        /// Lấy số line và Loại xe của Máy tính
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <returns></returns>
        public static DataTable GetLines_LoaiXeOfPCDienThoai(string IPAddress)
        {

            return new Data.QuanTri.QuanTriCauHinh().GetLines_LoaiXeOfPCDienThoai(IPAddress);
        }

        public static DataTable GetLines_LoaiXeOfPCTongDai(string IPAddress)
        {

            return new Data.QuanTri.QuanTriCauHinh().GetLines_LoaiXeOfPCTongDai(IPAddress);
        }
        public static DataTable G5_GetLines_LoaiXeOfPCDienThoai(string ipAddress)
        {
            return new Data.QuanTri.QuanTriCauHinh().G5_GetLines_LoaiXeOfPCDienThoai(ipAddress);
        }
        public static void G5_Update_PinMap(string ipAddress, string value)
        {
            try
            {

                new Data.QuanTri.QuanTriCauHinh().G5_Update_PinMap(ipAddress, value);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_Update_PinMap",ex);
            }
        }
        public static DataTable GetLINEGOIRA_ByIpAddress(string IPAddress)
        {
            return new Data.QuanTri.QuanTriCauHinh().GetLINEGOIRA_ByIpAddress(IPAddress);
        }
        #endregion

    
    }
}
