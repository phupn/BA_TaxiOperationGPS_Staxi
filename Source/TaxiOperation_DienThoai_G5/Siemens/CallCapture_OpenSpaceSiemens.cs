using System;
using BA.CallCaptureOpenSpaceSiemens;
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
        /// Thông tin danh bạ
        /// </summary>
        public GlobalContacts G_GlobalContacts { get; set; }

        /// <summary>
        /// Khởi tạo thông tin bắt số cuộc gọi đến từ hệ thống Open Space Siemens 
        /// </summary>
        public CallCapture_OpenSpaceSiemens(string serverNameAddress, string userNameWindowsLogin, string userNamePBXPMĐHExtensionID, string fullName, string password = "")
        {
            try
            {
                G_GlobalContacts.LoadGlobalContacts();

                ProfileOpenSpaceSiemens.UpdateFileProfileOpenSpaceSiemens(userNameWindowsLogin, userNamePBXPMĐHExtensionID, fullName, password);

                callCapture = new CallCaptureOpenSpaceSiemens(serverNameAddress, userNamePBXPMĐHExtensionID);

                callCapture.Connect();

                if (callCapture.IsConnected)
                {
                    StatusConnect = " Đã kết nối tổng đài";
                    callCapture.StartListening();

                    callCapture.NewCall += callCapture_NewCall;
                }
                else
                    StatusConnect = " Kết nối tổng đài thất bại";


            }
            catch (Exception ex)
            {
                StatusConnect = "Lỗi đã kết nối tổng đài";
                LogError.WriteLogError("CallCapture_OpenSpaceSiemens:", ex);
            }
        }

        private void callCapture_NewCall(NewCallEvent e)
        {
            PhoneNumber = e.PhoneNumber;
            CuocGoi objCuocGoi = GetAddress(PhoneNumber);
            StatusCallCapture = InsertCallCapture(objCuocGoi);
        }

        private CuocGoi GetAddress(string phoneNumber)
        {
            CuocGoi objCuocGoiMoi = new CuocGoi();

            DanhBaEx objDanhBaEx = G_GlobalContacts.GetGlobalContacsInfo(phoneNumber);
            if (objDanhBaEx != null && string.IsNullOrEmpty(objDanhBaEx.Address))
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
            }
            else
            {
                objCuocGoiMoi.CuocGoiLaiIDs = "0";
                objCuocGoiMoi.SoLanGoi = 0;
                objCuocGoiMoi.Vung = 0;
            }

            return objCuocGoiMoi;
        }

        private bool InsertCallCapture(CuocGoi objCuocGoiMoi)
        {
            return new CuocGoi().InsertCuocGoiLanDauByDiaChiFromMEM_V2(objCuocGoiMoi) > 0;
        }
    }
}
