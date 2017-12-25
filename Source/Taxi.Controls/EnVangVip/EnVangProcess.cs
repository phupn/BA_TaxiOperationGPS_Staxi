using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Business;
using Taxi.Business.DM;
using Taxi.Controls.FastTaxis;
using Taxi.Data.EnVang;
using Taxi.Services;
using Taxi.Utils;

namespace TaxiApplication.ServiceEnVang
{
    public class EnVangProcess
    {
        #region Chung
        /// <summary>
        /// Dictionary Xe - Biển số xe
        /// </summary>
        public static Dictionary<string, string> Vehicles_Dict = new Dictionary<string, string>();

        public static List<Xe> Vehicles { set; get; }

        /// <summary>
        /// Load lại danh sách xe
        /// </summary>
        public static void ReloadData()
        {
            Vehicles = new Xe().GetListXes();
            Vehicles_Dict.Clear();
            foreach (var item in Vehicles)
            {
                if (!Vehicles_Dict.ContainsKey(item.SoHieuXe))
                {
                    Vehicles_Dict.Add(item.SoHieuXe, item.BienKiemSoat);
                }
            }
        }
        /// <summary>
        /// Gửi tin nhắn
        /// </summary>
        /// <param name="cacSoDienThoai">The cac so dien thoai.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        private static bool SendSMSMessage(CuocGoi cuocGoi, string message)
        {
            return true;
        }
        /// <summary>
        /// Confirm message báo kết thúc cuốc
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/7/2015   created
        /// </Modified>
        public static bool SendConfirmDone(MessageConfirm message, byte result)
        {
            if (!HasSendMobile(null)) return false;
            return Service_Common.EnvangVip.TryGet(p => p.SendConfirmDone(message.IDCuocGoi.ToString(), result, string.Empty)).Success;
        }
        /// <summary>
        /// Hủy cuộc gọi
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        public static bool SendOperatorCancel(CuocGoi cuocGoi)
        {
            if (HasSendMobile(cuocGoi.KhongDungMobileService.Value))
                return Service_Common.EnvangVip.TryGet(p => p.SendOperatorCancel(cuocGoi.IDCuocGoi.ToString(), string.Empty, false)).Success;
            else return false;
        }

        /// <summary>
        /// LOgout lái xe
        /// </summary>
        /// <param name="BienSoXe"></param>
        /// <returns></returns>
        public static bool SendLogoutDriver(string soHieuXe)
        {
            string BienSoXe = Vehicles_Dict.ContainsKey(soHieuXe) ? Vehicles_Dict[soHieuXe] : "";
            return Service_Common.EnvangVip.TryGet(p => p.SendLogoutDriver(BienSoXe)).Success;
        }

        /// <summary>
        /// Gửi lệnh tạo cuốc cho các xe trong danh sách xe nhận
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        public static bool SendInitTrip(CuocGoi cuocGoi)
        {
            if (HasSendMobile(cuocGoi.KhongDungMobileService))
            {
                var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeNhan, ".");
                if (string.IsNullOrEmpty(privateCodes)) return false;
                if (privateCodes.IndexOf("..") > -1 || privateCodes.StartsWith(".")) return false;
                CuocGoi.EnVangVIP_GuiTinChoLaiXe(cuocGoi.IDCuocGoi);

                return Service_Common.EnvangVip.TryGet(p => p.SendInitTrip(cuocGoi.IDCuocGoi.ToString(), cuocGoi.DiaChiDonKhach, cuocGoi.DiaChiDonKhach
                , Convert.ToSingle(cuocGoi.GPS_ViDo), Convert.ToSingle(cuocGoi.GPS_KinhDo), cuocGoi.DiaChiTraKhach, cuocGoi.DiaChiTraKhach, 0, 0, cuocGoi.GhiChuDienThoai
                , Convert.ToByte(cuocGoi.SoLuong), Convert.ToByte(cuocGoi.KieuCuocGoi), Convert.ToByte(cuocGoi.KieuKhachHangGoiDen), cuocGoi.PhoneNumber
                , privateCodes.Split(".".ToCharArray()), false, string.Empty, 0)).Success;
            }
            return false;
        }
        #endregion

        #region Tổng đài
        /// <summary>
        /// Check xem có gửi xuống cho mobile ko
        /// </summary>
        /// <param name="KhongDungMobileService">thuộc tính cuộc gọi</param>
        /// <returns></returns>
        private static bool HasSendMobile(bool? KhongDungMobileService)
        {
            return Global.HasInternet == 1 && ThongTinCauHinh.GPS_TrangThai && (KhongDungMobileService == null || !KhongDungMobileService.Value);
        }
        /// <summary>
        /// Có cho phép liên lạc với service mobile không
        /// </summary>
        /// <param name="khongDungMobileService">The khong dung mobile service.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/1/2015   created
        /// </Modified>
        private static bool CheckAllowInteractMobile(bool? khongDungMobileService)
        {
            return khongDungMobileService == null || !khongDungMobileService.Value;
        }

        /// <summary>
        /// Gets the vehicle plates from private code.
        /// </summary>
        /// <param name="soHieuXe">The so hieu xe.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/14/2015   created
        /// </Modified>
        public static string GetVehiclePlatesFromPrivateCode(string soHieuXe)
        {
            return ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(soHieuXe, ",");
        }

        /// <summary>
        /// Gửi lệnh có thể/không thể mời được khách sang service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="coMoiKhach">The co moi khach.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        //public static bool SendACKInvite(CuocGoi cuocGoi, byte coMoiKhach, string msg)
        //{
        //    if (HasSendMobile(cuocGoi.KhongDungMobileService.Value))
        //    { 
        //        var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeDon, ",");
        //        if (string.IsNullOrEmpty(privateCodes)) return false;

        //        return Service_Common.EnvangVip.TryGet(p => p.SendACKInvite(cuocGoi.IDCuocGoi.ToString(), privateCodes, coMoiKhach, msg)).Success;
        //    }
        //    else
        //    {
        //        return SendSMSMessage(cuocGoi, "Đã mời khách");
        //    }
        //}

        /// <summary>
        /// Gửi lệnh có thể/không thể mời được khách sang service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="coMoiKhach">The co moi khach.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        //public static bool SendACKInvite(MessageConfirm message, byte coMoiKhach)
        //{
        //    var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(message.XeDon, ",");
        //    if (string.IsNullOrEmpty(privateCodes)) return false;

        //    if (Global.HasInternet == 1)
        //    {
        //        return Service_Common.EnvangVip.TryGet(p => p.SendACKInvite(message.IDCuocGoi.ToString(), privateCodes, coMoiKhach, string.Empty)).Success;
        //    }
        //    else
        //    {
        //        return SendSMSMessage(null, "Đã mời khách");
        //    }
        //}

        /// <summary>
        /// Gửi lệnh đồng ý/không đồng ý cho số sang service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="coChoSo">The co cho so.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        //public static bool SendACKGetPhone(CuocGoi cuocGoi, byte coChoSo)
        //{
        //    var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeDon, ",");
        //    if (string.IsNullOrEmpty(privateCodes)) return false;
            

        //    if (Global.HasInternet == 1)
        //    {
        //        return Service_Common.EnvangVip.TryGet(p => p.SendACKGetPhone(cuocGoi.IDCuocGoi.ToString(), coChoSo, privateCodes)).Success;
        //    }
        //    else
        //    {
        //        string message = string.Format("So dien thoai khach hang: {0}", cuocGoi.PhoneNumber);
        //        return SendSMSMessage(cuocGoi, message);
        //    }
        //}

        /// <summary>
        /// Gửi lệnh đồng ý/không đồng ý cho số sang service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="coChoSo">The co cho so.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        //public static bool SendACKGetPhone(MessageConfirm message, byte coChoSo)
        //{
        //    var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(message.XeDon, ",");
        //    if (string.IsNullOrEmpty(privateCodes)) return false;


        //    if (Global.HasInternet == 1)
        //    {
        //        return Service_Common.EnvangVip.TryGet(p => p.SendACKGetPhone(message.IDCuocGoi.ToString(), coChoSo, privateCodes)).Success;
        //    }
        //    else
        //    {
        //        //string message = string.Format("So dien thoai khach hang: {0}", cuocGoi.PhoneNumber);
        //        return SendSMSMessage(null, string.Empty);
        //    }
        //}

        /// <summary>
        /// Gửi tin báo kết thúc cho service én vàng
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        //public static bool SendOperatorCatched(CuocGoi cuocGoi)
        //{
        //    if (Global.HasInternet == 1)
        //    {
        //        return Service_Common.EnvangVip.TryGet(p => p.SendOperatorCatched(cuocGoi.IDCuocGoi.ToString())).Success;
        //    }
        //    else
        //    {
        //        return SendSMSMessage(cuocGoi, "Đã kết thúc cuốc");
        //    }
        //}
        
        /// <summary>
        /// Confirm message báo kết thúc cuốc
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/7/2015   created
        /// </Modified>
        public static bool SendConfirmDone(CuocGoi cuocGoi, byte result)
        {
            if (HasSendMobile(cuocGoi.KhongDungMobileService.Value))
                return Service_Common.EnvangVip.TryGet(p => p.SendConfirmDone(cuocGoi.IDCuocGoi.ToString(), result, string.Empty)).Success;
            else return false;
        }

        /// <summary>
        /// Gửi text cho service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/7/2015   created
        /// </Modified>
        //public static bool SendText(CuocGoi cuocGoi)
        //{
        //    var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeDon, ".");
        //    if (string.IsNullOrEmpty(privateCodes)) return false;
        //    CuocGoi.EnVangVIP_TaoMessageConfirm(cuocGoi.IDCuocGoi, 3242, false, true, cuocGoi.GhiChuDienThoai, privateCodes);
        //    return Service_Common.EnvangVip.TryGet(p => p.SendText(privateCodes, cuocGoi.GhiChuDienThoai)).Success;
        //}

        /// <summary>
        /// Gửi confirm landmark.
        /// </summary>
        /// <param name="soHieuXe">The so hieu xe.</param>
        /// <param name="landMarkID">The land mark identifier.</param>
        /// <param name="ok">if set to <c>true</c> [ok].</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/27/2015   created
        /// </Modified>
        public static bool SendConfirmLandmark(MessageConfirm message, byte ok, long landMarkGPSID, int node, long landMarkID)
        {
            if (!HasSendMobile(null)) return false;

            var landMarkAndDriver = message.MessageContent.Split("-".ToCharArray());
            
            if (ok == 1)
            {
                CuocGoi.EnVangVIP_NhapDuLieuGiamSatXe(message.SoHieuXe, 
                                                        landMarkAndDriver[1], 
                                                        "", 
                                                        ((int)Enum_TrangThaiLaiXeBao.BaoDiemDo).ToString(), 
                                                        landMarkID, 
                                                        "1", 
                                                        null, 
                                                        null, node);
            }

            var result = Service_Common.EnvangVip.TryGet(p => p.SendConfirmLandmark(message.BienSoXe, (int)landMarkGPSID, ok == 1, node)).Success;

            return result;
        }
        
        /// <summary>
        /// Trả lời confirm ăn ca, rời xe
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/8/2015   created
        /// </Modified>
        public static bool SendACKActiveChange(MessageConfirm message, byte status, string driverCode, short commandId)
        {
            if (!HasSendMobile(null)) return false;

            return Service_Common.EnvangVip.TryGet(p => p.SendACKActiveChange(message.BienSoXe, status, driverCode, message.XeDon, message.MaMessage, commandId)).Success;
        }

        /// <summary>
        /// Gửi lệnh cho lái xe
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="soHieuXe">The so hieu xe.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/8/2015   created
        /// </Modified>
        public static bool SendOperatorCmd(int command, string soHieuXe)
        {
            if (!HasSendMobile(null)) return false;
            var vehiclePlates = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(soHieuXe, ",");
            if (string.IsNullOrEmpty(vehiclePlates)) return false;
            return Service_Common.EnvangVip.TryGet(p => p.SendOperatorCmd(command, vehiclePlates)).Success;
        }

        /// <summary>
        /// Gửi mobile thông tin điểm đỗ
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="LandmarkGPSID"></param>
        /// <param name="Node"></param>
        /// <returns></returns>
        public static bool SendNewLandMarkInfo(string soHieuXe, int LandmarkGPSID, int Node)
        {
            if (!HasSendMobile(null)) return false;
            var vehiclePlates = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(soHieuXe, ",");
            if (string.IsNullOrEmpty(vehiclePlates)) return false;
            return Service_Common.EnvangVip.TryGet(p => p.SendLandmark(vehiclePlates, LandmarkGPSID, Node, 0)).Success;
        }
        #endregion

        #region Điện Thoại
        
        /// <summary>
        /// Check xem có gửi xuống cho mobile ko
        /// </summary>
        /// <param name="KhongDungMobileService">thuộc tính cuộc gọi</param>
        /// <returns></returns>
        private static bool HasSendMobile(bool KhongDungMobileService)
        {
            return Global.HasInternet == 1 && ThongTinCauHinh.GPS_TrangThai && !KhongDungMobileService;
        }

        /// <summary>
        /// Gửi lệnh có thể/không thể mời được khách sang service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="coMoiKhach">The co moi khach.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        public static bool SendACKInvite(CuocGoi cuocGoi, byte coMoiKhach, string message)
        {
            if (HasSendMobile(cuocGoi.KhongDungMobileService.Value))
            {
                var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeDon, ",");
                if (string.IsNullOrEmpty(privateCodes)) return false;
                return Service_Common.EnvangVip.TryGet(p => p.SendACKInvite(cuocGoi.IDCuocGoi.ToString(), privateCodes, coMoiKhach, message)).Success;
            }
            else
            {
                return SendSMSMessage(cuocGoi, "Đã mời khách");
            }
        }

        /// <summary>
        /// Gửi lệnh có thể/không thể mời được khách sang service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="coMoiKhach">The co moi khach.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        public static bool SendACKInvite(MessageConfirm message, byte coMoiKhach, string msg)
        {
            if (!HasSendMobile(null)) return false;
            var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(message.XeDon, ",");
            if (string.IsNullOrEmpty(privateCodes)) return false;

            if (Global.HasInternet == 1)
            {
                return Service_Common.EnvangVip.TryGet(p => p.SendACKInvite(message.IDCuocGoi.ToString(), privateCodes, coMoiKhach, string.Empty)).Success;
            }
            else
            {
                return SendSMSMessage(null, "Đã mời khách");
            }
        }

        /// <summary>
        /// Gửi lệnh đồng ý/không đồng ý cho số sang service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="coChoSo">The co cho so.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        public static bool SendACKGetPhone(CuocGoi cuocGoi, byte coChoSo)
        {
            if (!HasSendMobile(cuocGoi.KhongDungMobileService)) return false;
            var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeDon, ",");
            if (string.IsNullOrEmpty(privateCodes)) return false;

            if (HasSendMobile(cuocGoi.KhongDungMobileService.Value))
            {
                return Service_Common.EnvangVip.TryGet(p => p.SendACKGetPhone(cuocGoi.IDCuocGoi.ToString(), coChoSo, privateCodes)).Success;
            }
            else
            {
                string message = string.Format("So dien thoai khach hang: {0}", cuocGoi.PhoneNumber);
                return SendSMSMessage(cuocGoi, message);
            }
        }

        /// <summary>
        /// Gửi lệnh đồng ý/không đồng ý cho số sang service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="coChoSo">The co cho so.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        public static bool SendACKGetPhone(MessageConfirm message, byte coChoSo)
        {
            if (!HasSendMobile(null)) return false;
            var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(message.XeDon, ",");
            if (string.IsNullOrEmpty(privateCodes)) return false;
            
            if (Global.HasInternet == 1)
            {
                return Service_Common.EnvangVip.TryGet(p => p.SendACKGetPhone(message.IDCuocGoi.ToString(), coChoSo, privateCodes)).Success;
            }
            else
            {
                //string message = string.Format("So dien thoai khach hang: {0}", cuocGoi.PhoneNumber);
                return SendSMSMessage(null, string.Empty);
            }
        }

        /// <summary>
        /// Gửi tin báo kết thúc cho service én vàng
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        public static bool SendOperatorCatched(CuocGoi cuocGoi)
        {
            if (HasSendMobile(cuocGoi.KhongDungMobileService.Value))
            {
                return Service_Common.EnvangVip.TryGet(p => p.SendOperatorCatched(cuocGoi.IDCuocGoi.ToString())).Success;
            }
            else
            {
                return SendSMSMessage(cuocGoi, "Đã kết thúc cuốc");
            }
        }

        /// <summary>
        /// Gửi text cho service EnVangVip
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/7/2015   created
        /// </Modified>
        public static bool SendText(CuocGoi cuocGoi)
        {
            if (HasSendMobile(cuocGoi.KhongDungMobileService.Value))
            {
                var vehiclePlates = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeDon, ",");
                if (string.IsNullOrEmpty(vehiclePlates)) return false;
                CuocGoi.EnVangVIP_TaoMessageConfirm(cuocGoi.IDCuocGoi, 3242, false, false, cuocGoi.GhiChuDienThoai, cuocGoi.XeDon);
                return Service_Common.EnvangVip.TryGet(p => p.SendText(vehiclePlates, cuocGoi.GhiChuDienThoai)).Success;
            }
            return false;
        }

        /// <summary>
        /// Gửi text cho service EnVangVip
        /// </summary>
        /// <param name="soHieuXe">The so hieu xe.</param>
        /// <param name="idCuocGoi">The identifier cuoc goi.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/21/2015   created
        /// </Modified>
        public static bool SendText(string soHieuXe, long idCuocGoi, string message)
        {
            if (!HasSendMobile(null)) return false;
            var vehiclePlates = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(soHieuXe, ",");
            if (string.IsNullOrEmpty(vehiclePlates)) return false;
            CuocGoi.EnVangVIP_TaoMessageConfirm(idCuocGoi, 3242, false, false, message, soHieuXe);
            return Service_Common.EnvangVip.TryGet(p => p.SendText(vehiclePlates, message)).Success;
        }

        /// <summary>
        /// Gửi confirm landmark.
        /// </summary>
        /// <param name="soHieuXe">The so hieu xe.</param>
        /// <param name="landMarkID">The land mark identifier.</param>
        /// <param name="ok">if set to <c>true</c> [ok].</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/27/2015   created
        /// </Modified>
        public static bool SendConfirmLandmark(MessageConfirm message, byte ok)
        {
            if (!HasSendMobile(null)) return false;
            var vehiclePlates = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(message.XeDon, ",");
            if (string.IsNullOrEmpty(vehiclePlates)) return false;
            var landMarkAndDriver = message.MessageContent.Split("-".ToCharArray());
            int node = 0;
            if(ok == 1)
            {
                node = CuocGoi.EnVangVIP_NhapDuLieuGiamSatXe(vehiclePlates, landMarkAndDriver[1], ""
                    , ((int)Enum_TrangThaiLaiXeBao.BaoDiemDo).ToString(), Convert.ToInt32(landMarkAndDriver[0]),
                    "1", null, null);
            }
            return Service_Common.EnvangVip.TryGet(p => p.SendConfirmLandmark(vehiclePlates, Convert.ToInt32(landMarkAndDriver[0]), ok == 1, node)).Success;
        }
        #endregion
    }
}
