using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.DM
{
    public class LoaiXe
    {
        public DataTable GetAllLoaiXe()
        {
            return new Data.TinhTienTheoKm().GetAllLoaiXe();
        }
        /// <summary>
        /// kiem tra trung tên loai xe-So cho
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="TenDiaDanh"></param>
        /// <param name="soCho"></param>
        /// <returns></returns>
        public static bool CheckTrungTen_LoaiXe(int ID, string TenDiaDanh, int soCho)
        {
            return new Data.DM.LoaiXe().CheckTrungTen_LoaiXe(ID, TenDiaDanh, soCho);
        }

        /// <summary>
        /// Insert  Loại xe
        /// </summary>
        /// <param name="TenLoaiXe"></param>
        /// <param name="SoCho"></param>
        /// <returns></returns>
        public bool InsertLoaiXe(string TenLoaiXe, int SoCho)
        {
            return new Data.DM.LoaiXe().InsertLoaiXe(TenLoaiXe, SoCho);
        }
        /// <summary>
        /// update Loại xe
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="TenLoaiXe"></param>
        /// <param name="SoCho"></param>
        /// <returns></returns>
        public bool UpdateLoaiXe(int ID, string TenLoaiXe, int SoCho)
        {
            return new Data.DM.LoaiXe().UpdateLoaiXe(ID, TenLoaiXe, SoCho);
        }

        public bool DeleteLoaiXe(int ID)
        {
            return new Data.DM.LoaiXe().DeleteLoaiXe(ID);
        }

        public DataTable GetAll()
        {
            return new Data.DM.LoaiXe().GetAll();
        }
        public bool DeleteLoaiXe_BC_Truck(int ID)
        {
            return new Data.DM.LoaiXe().DeleteLoaiXe_BC_Truck(ID);
        }
        public static bool CheckTrungTen_LoaiXe_Truck(string TenDiaDanh)
        {
            return new Data.DM.LoaiXe().CheckTrungTen_LoaiXe_Truck(TenDiaDanh);
        }
        public bool InsertLoaiXe_BC_Truck(string TenLoaiXe, string HangXe, string KichThuoc, string TaiTrongQuyDinh, string TaiTrongChoPhep, string PhimTat, string VietTat, string backColor, string foreColor)
        {

            return new Data.DM.LoaiXe().InsertLoaiXe_BC_Truck(TenLoaiXe, HangXe, KichThuoc, TaiTrongQuyDinh, TaiTrongChoPhep, PhimTat, VietTat, backColor, foreColor);
        }
        public bool UpdateLoaiXe_BC_Truck(int ID, string TenLoaiXe, string HangXe, string KichThuoc, string TaiTrongQuyDinh, string TaiTrongChoPhep, string PhimTat, string font, string VietTat, string backColor, string foreColor)
        {
            return new Data.DM.LoaiXe().UpdateLoaiXe_BC_Truck(ID, TenLoaiXe, HangXe, KichThuoc, TaiTrongQuyDinh, TaiTrongChoPhep, PhimTat, font, VietTat, backColor, foreColor);
        }
    }
}
