using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Business;
using Taxi.Controls.FastTaxis;
using Taxi.Data.EnVang;
using Taxi.Services;
using Taxi.Utils;

namespace TaxiApplication.ServiceEnVang
{
    public class EnVangProcess
    {
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
                
                return true;
            }
            return false;
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
                return Service_Common.EnvangVip.TryGet(p => p.SendOperatorCancel(cuocGoi.IDCuocGoi.ToString(), string.Empty)).Success;
            else return false;
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
            return Service_Common.EnvangVip.TryGet(p => p.SendConfirmDone(message.IDCuocGoi.ToString(), result, string.Empty)).Success;
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
        public static bool SendConfirmLandmark(MessageConfirm message, byte ok, long landMarkID, int node)
        {
            var vehiclePlates = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(message.XeDon, ",");
            if (string.IsNullOrEmpty(vehiclePlates)) return false;
            var landMarkAndDriver = message.MessageContent.Split("-".ToCharArray());
            
            if (ok == 1)
            {
                node = CuocGoi.EnVangVIP_NhapDuLieuGiamSatXe(vehiclePlates, 
                                                        landMarkAndDriver[1], 
                                                        "", 
                                                        ((int)Enum_TrangThaiLaiXeBao.BaoDiemDo).ToString(), 
                                                        landMarkID, 
                                                        "1", 
                                                        null, 
                                                        null, node);
            }
            return Service_Common.EnvangVip.TryGet(p => p.SendConfirmLandmark(vehiclePlates, (int)landMarkID, ok == 1, node)).Success;
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
            var vehiclePlates = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(message.XeDon, ",");
            if (string.IsNullOrEmpty(vehiclePlates)) return false;
            return Service_Common.EnvangVip.TryGet(p => p.SendACKActiveChange(vehiclePlates, status, driverCode, message.XeDon, message.MaMessage, commandId)).Success;
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
            var vehiclePlates = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(soHieuXe, ",");
            if (string.IsNullOrEmpty(vehiclePlates)) return false;
            return Service_Common.EnvangVip.TryGet(p => p.SendOperatorCmd(command, vehiclePlates)).Success;
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
    }
}
