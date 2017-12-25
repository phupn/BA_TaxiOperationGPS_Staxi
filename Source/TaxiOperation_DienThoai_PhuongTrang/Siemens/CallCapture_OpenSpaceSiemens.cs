using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.CallCaptureOpenSpaceSiemens;
using Taxi.Utils;
using Taxi.Business;
namespace TaxiApplication.Siemens
{
    /// <summary>
    /// Hệ thống bắt số của Siemens - OpenSpace
    /// </summary>
    public class CallCapture_OpenSpaceSiemens : CallCaptureOpenSpaceSiemens
    {
        public CallCaptureOpenSpaceSiemens callCapture;
        /// <summary>
        /// Trạng thái kết nối
        /// </summary>
        public string StatusConnect { get; set; }
        /// <summary>
        /// Trạng thái insert cuộc gọi
        /// </summary>
        public bool StatusCallCapture { get; set; }
        /// <summary>
        /// Số điện thoại gọi đến
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Line cấp phép
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// Thông tin danh bạ
        /// </summary>
        public GlobalContacts G_GlobalContacts { get; set; }

        public CallCapture_OpenSpaceSiemens(string strLine)
        {
            G_GlobalContacts = new GlobalContacts();
            G_GlobalContacts.LoadGlobalContacts();
            Line = int.Parse(strLine.Split(';')[0]);
        }
        /// <summary>
        /// Khởi tạo thông tin bắt số cuộc gọi đến từ hệ thống Open Space Siemens 
        /// </summary>
        /// <param name="serverNameAddress"></param>
        /// <param name="userNameWindowsLogin"></param>
        /// <param name="userNamePBXPMĐHExtensionID"></param>
        /// <param name="fullName"></param>
        /// <param name="password"></param>
        public CallCapture_OpenSpaceSiemens(string strLine, string serverNameAddress, string userNameWindowsLogin, string userNamePBXPMĐHExtensionID, string fullName, string password = "")
        {
            try
            {
                G_GlobalContacts = new GlobalContacts();
                G_GlobalContacts.LoadGlobalContacts();
                Line = int.Parse(strLine.Split(';')[0]);
                int status = ProfileOpenSpaceSiemens.UpdateFileProfileOpenSpaceSiemens(userNameWindowsLogin, userNamePBXPMĐHExtensionID, fullName, password);

                callCapture = new CallCaptureOpenSpaceSiemens(serverNameAddress, userNamePBXPMĐHExtensionID);

                callCapture.Connect();

                if (callCapture.IsConnected)
                {
                    StatusConnect = string.Format("{0} Đã kết nối tổng đài.{1}:{2}", userNamePBXPMĐHExtensionID, userNameWindowsLogin, status);
                    callCapture.StartListening();

                    callCapture.NewCall += callCapture_NewCall;
                }
                else
                    StatusConnect = string.Format(" Kết nối tổng đài thất bại:{0}", status);
                if (Global.IsDebug)
                {
                    LogError.WriteLogInfo("StatusConnect :" + StatusConnect);
                }
                //new Taxi.MessageBox.MessageBox().Show(StatusConnect);

            }
            catch (Exception ex)
            {
                StatusConnect = "Lỗi đã kết nối tổng đài";
                Taxi.Business.LogError.WriteLogError("CallCapture_OpenSpaceSiemens:", ex);
            }
        }

        void callCapture_NewCall(NewCallEvent e)
        {
            if (Global.IsDebug)
            {
                LogError.WriteLogInfo("callCapture_NewCall:" + e.PhoneNumber);
            }
            PhoneNumber = e.PhoneNumber;
            CuocGoi objCuocGoi = GetAddress(PhoneNumber);
            StatusCallCapture = InsertCallCapture(objCuocGoi);
            //if (Global.IsDebug)
            //    new Taxi.MessageBox.MessageBox().Show(PhoneNumber + "-" + StatusCallCapture.ToString());
        }

        private CuocGoi GetAddress(string phoneNumber)
        {
            CuocGoi objCuocGoiMoi = new CuocGoi();
            try
            {
                objCuocGoiMoi.PhoneNumber = phoneNumber;
                objCuocGoiMoi.ThoiDiemGoi = DateTime.Now;
                DanhBaEx objDanhBaEx = G_GlobalContacts.GetGlobalContacsInfo(phoneNumber);
                if (objDanhBaEx != null && !string.IsNullOrEmpty(objDanhBaEx.Address))
                {
                    objCuocGoiMoi.KieuKhachHangGoiDen = objDanhBaEx.KieuKHGoiDen;
                    objCuocGoiMoi.DiaChiDonKhach = objDanhBaEx.Address;
                    objCuocGoiMoi.DiaChiTraKhach = objDanhBaEx.Address_Destination;
                    objCuocGoiMoi.Vung = objDanhBaEx.Vung;
                    objCuocGoiMoi.MaDoiTac = objDanhBaEx.MaDoiTac;
                    objCuocGoiMoi.LoaiXe = objDanhBaEx.LoaiXe;
                    objCuocGoiMoi.GPS_KinhDo = objDanhBaEx.GPS_KinhDo;
                    objCuocGoiMoi.GPS_ViDo = objDanhBaEx.GPS_ViDo;
                    objCuocGoiMoi.GhiChuDienThoai = objDanhBaEx.GhiChuTiepNhan;
                    objCuocGoiMoi.CuocGoiLaiIDs = objDanhBaEx.IdCuocGoi.ToString();
                    objCuocGoiMoi.SoLanGoi = objDanhBaEx.SoLanGoi + 1;
                    objCuocGoiMoi.LenhDienThoai = objDanhBaEx.LenhTiepNhan;

                }
                else
                {
                    objCuocGoiMoi.KieuKhachHangGoiDen = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    objCuocGoiMoi.DiaChiDonKhach = "";
                    objCuocGoiMoi.DiaChiTraKhach = "";
                    objCuocGoiMoi.MaDoiTac = "";
                    objCuocGoiMoi.LoaiXe = "";
                    objCuocGoiMoi.GPS_KinhDo = 0;
                    objCuocGoiMoi.GPS_ViDo = 0;
                    objCuocGoiMoi.GhiChuDienThoai = "";
                    objCuocGoiMoi.LenhDienThoai = "";
                    objCuocGoiMoi.CuocGoiLaiIDs = "0";
                    objCuocGoiMoi.SoLanGoi = 0;
                    objCuocGoiMoi.Vung = 0;
                }
                objCuocGoiMoi.Line = Line;

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CallCapture_OpenSpaceSiemens GetAddress:", ex);
            }
            return objCuocGoiMoi;
        }

        private bool InsertCallCapture(CuocGoi objCuocGoiMoi)
        {
            return new CuocGoi().InsertCuocGoiLanDauByDiaChiFromMEM_V2(objCuocGoiMoi) > 0;
        }
    }
}
