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
            var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeNhan, ".");
            if (string.IsNullOrEmpty(privateCodes)) return false;
            if (privateCodes.IndexOf("..") > -1 || privateCodes.StartsWith(".")) return false;
            CuocGoi.EnVangVIP_GuiTinChoLaiXe(cuocGoi.IDCuocGoi);
            if(Global.HasInternet == 1)
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

        /// <summary>
        /// Gửi lệnh có thể/không thể mời được khách sang service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <param name="coMoiKhach">The co moi khach.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        public static bool SendACKInvite(CuocGoi cuocGoi, byte coMoiKhach, string msg)
        {
            var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeDon, ",");
            if (string.IsNullOrEmpty(privateCodes)) return false;

            if (Global.HasInternet == 1)
            {
                return Service_Common.EnvangVip.TryGet(p => p.SendACKInvite(cuocGoi.IDCuocGoi.ToString(), privateCodes, coMoiKhach, msg)).Success;
            }
            else
            {
                return SendSMSMessage(cuocGoi, "Đã mời khách");
            }
        }

        /// <summary>
        /// Gửi lệnh có thể/không thể mời được khách sang service EnVang
        /// </summary>
        /// <param name="message">The cuoc goi.</param>
        /// <param name="coMoiKhach">The co moi khach.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/3/2015   created
        /// </Modified>
        public static bool SendACKInvite(MessageConfirm message, byte coMoiKhach)
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
            

            if (Global.HasInternet == 1)
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
            if (Global.HasInternet == 1)
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
            return Service_Common.EnvangVip.TryGet(p => p.SendOperatorCancel(cuocGoi.IDCuocGoi.ToString(), string.Empty, true)).Success;
        }

        /// <summary>
        /// Confirm message báo kết thúc cuốc
        /// </summary>
        /// <param name="message">The cuoc goi.</param>
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
        /// Gửi text cho service EnVang
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/7/2015   created
        /// </Modified>
        public static bool SendText(CuocGoi cuocGoi)
        {
            var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(cuocGoi.XeDon, ",");
            if (string.IsNullOrEmpty(privateCodes)) return false;
            return Service_Common.EnvangVip.TryGet(p => p.SendText(privateCodes, cuocGoi.GhiChuDienThoai)).Success;
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
