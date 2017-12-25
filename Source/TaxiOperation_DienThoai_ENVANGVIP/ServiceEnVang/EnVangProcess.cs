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
        private static bool HasSendMobile(bool KhongDungMobileService)
        {
            return Global.HasInternet == 1 && ThongTinCauHinh.GPS_TrangThai && !KhongDungMobileService;
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
            if (HasSendMobile(cuocGoi.KhongDungMobileService.Value))
            {
                var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeNhan, ".");
                if (string.IsNullOrEmpty(privateCodes)) return false;
                if (privateCodes.IndexOf("..") > -1 || privateCodes.StartsWith(".")) return false;
                CuocGoi.EnVangVIP_GuiTinChoLaiXe(cuocGoi.IDCuocGoi);
                if (Global.HasInternet == 1)
                {
                    return Service_Common.EnvangVip.TryGet(p => p.SendInitTrip(cuocGoi.IDCuocGoi.ToString(), cuocGoi.DiaChiDonKhach, cuocGoi.DiaChiDonKhach
                    , Convert.ToSingle(cuocGoi.GPS_ViDo), Convert.ToSingle(cuocGoi.GPS_KinhDo), cuocGoi.DiaChiTraKhach, cuocGoi.DiaChiTraKhach, 0, 0, cuocGoi.GhiChuDienThoai
                    , Convert.ToByte(cuocGoi.SoLuong), Convert.ToByte(cuocGoi.KieuCuocGoi), Convert.ToByte(cuocGoi.KieuKhachHangGoiDen), cuocGoi.PhoneNumber
                    , privateCodes.Split(".".ToCharArray()), false, string.Empty, 0)).Success;
                }
                else
                {
                    string message = string.Format("Moi nhan cuoc don o: {0}", cuocGoi.DiaChiDonKhach);
                    return SendSMSMessage(cuocGoi, message);
                }
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
