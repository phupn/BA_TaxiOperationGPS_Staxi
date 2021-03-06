using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Entity;

namespace Taxi.Business
{
    public class ManHinhBL
    {
        private static ManHinhEntity getManHinhEntity(DataRow row)
        {
            ManHinhEntity ManHinh = new ManHinhEntity();
            ManHinh.DiaChiDonKhach = row["DiaChiDonKhach"].ToString();
            ManHinh.FK_CuocGoiID = long.Parse(row["FK_CuocGoiID"].ToString());
            ManHinh.GuiChoAi = row["GuiChoAi"].ToString();
            ManHinh.ID = row["ID"].ToString();
            ManHinh.LenhDienThoai = row["LenhDienThoai"].ToString();
            ManHinh.LenhTongDai = row["LenhTongDai"].ToString();
            ManHinh.Line = int.Parse(row["Line"].ToString());
            ManHinh.LoaiCuocKhach = (Taxi.Utils.LoaiCuocKhach)int.Parse(row["LoaiCuocKhach"].ToString());
            ManHinh.LoaiTinNhan = (Taxi.Utils.LoaiTinNhanMH)int.Parse(row["LoaiTinNhan"].ToString());
            ManHinh.MaNhanVienDienThoai = row["MaNhanVienDienThoai"].ToString();
            ManHinh.MaNhanVienTongDai = row["MaNhanVienTongDai"].ToString();
            ManHinh.PhoneNumber = row["PhoneNumber"].ToString();
            ManHinh.SoHieuXe = row["SoHieuXe"].ToString();
            ManHinh.ThoiDiemChen = DateTime.Parse(row["ThoiDiemChen"].ToString());
            ManHinh.ThoiDiemCuaXe = DateTime.Parse(row["ThoiDiemCuaXe"].ToString());
            ManHinh.ThoiDiemGoi = DateTime.Parse(row["ThoiDiemGoi"].ToString());
            ManHinh.TinNhan = row["TinNhan"].ToString();
            ManHinh.TrangThaiLenh = (Taxi.Utils.TrangThaiLenhTaxi)int.Parse(row["TrangThaiLenh"].ToString());
            ManHinh.Vung = int.Parse( row["Vung"].ToString());
            ManHinh.XeDon = row["XeDon"].ToString();
            ManHinh.XeNhan = row["XeNhan"].ToString();
            ManHinh.SoLuong = int.Parse( row["SoLuong"].ToString());
            return ManHinh;
        }

        //private static ManHinhEntity getManHinhEntity2(DataRow row)
        //{
        //    return new ManHinhEntity(
        //    row["ID"].ToString()
        //    ,long.Parse(row["FK_CuocGoiID"].ToString())
        //    ,row["SoHieuXe"].ToString()
        //    ,row["TinNhan"].ToString()
        //    ,row["GuiChoAi"].ToString()
        //    ,(Taxi.Utils.LoaiTinNhanMH)int.Parse(row["LoaiTinNhan"].ToString())
        //    ,DateTime.Parse(row["ThoiDiemCuaXe"].ToString())
        //    ,DateTime.Parse(row["ThoiDiemChen"].ToString())
        //    ,DateTime.Parse(row["ThoiDiemGoi"].ToString())
        //    ,int.Parse(row["Line"].ToString())
        //    ,row["PhoneNumber"].ToString()
        //    ,row["DiaChiDonKhach"].ToString()
        //    ,int.Parse(row["Vung"].ToString())
        //    ,(Taxi.Utils.LoaiCuocKhach)int.Parse(row["LoaiCuocKhach"].ToString())
        //    ,row["LenhDienThoai"].ToString()
        //    ,row["LenhTongDai"].ToString()
        //    ,(Taxi.Utils.TrangThaiLenhTaxi)int.Parse(row["TrangThaiLenh"].ToString())
        //    ,row["MaNhanVienDienThoai"].ToString()
        //    ,row["MaNhanVienTongDai"].ToString()
        //    ,row["XeNhan"].ToString()
        //    ,row["XeDon"].ToString()
        //    ,int.Parse(row["SoLuong"].ToString())
        //    );
        //}

        /// <summary>
        /// Trả về nội dung tin nhắn mới co tin nhan moi
        /// </summary>
        /// <param name="Vung">Vung</param>
        /// <param name="GuiChoAi">Bo Phan</param>
        /// <returns></returns>
        public List<ManHinhEntity> GetNewManHinh(string Vung, string GuiChoAi)
        {            
            try
            {
                List<ManHinhEntity> lstManHinh = new List<ManHinhEntity>();
                using (DataTable dt = new Taxi.Data.ManHinhDA().GetNewManHinh(Vung, GuiChoAi))
                {
                    if (dt == null || dt.Rows.Count <= 0)
                        return null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstManHinh.Add(getManHinhEntity(dr));
                    }
                }
                return lstManHinh;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        /// <summary>
        /// Trả về nội dung tin nhắn mới co tin nhan moi_Loc chi lay nhung tin nhan moi
        /// </summary>
        /// <param name="Vung">Vung</param>
        /// <param name="GuiChoAi">Bo Phan</param>
        /// <param name="ThoiDiemChen">Thoi Diem Chen cua Lai Xe</param>
        /// <returns></returns>
        public List<ManHinhEntity> GetNewManHinh_ThoiDiemChen(string Vung, string GuiChoAi, DateTime ThoiDiemChen)
        {
            try
            {
                List<ManHinhEntity> lstManHinh = new List<ManHinhEntity>();
                using (DataTable dt = new Taxi.Data.ManHinhDA().GetNewManHinh_ThoiDiemChen(Vung, GuiChoAi, ThoiDiemChen))
                {
                    if (dt == null || dt.Rows.Count <= 0)
                        return null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstManHinh.Add(getManHinhEntity(dr));
                    }
                }
                return lstManHinh;
            }
            catch (Exception ex)
            {
                // //  LogError.WriteLog("GetAllOf_DienThoai :", ex);
                return null;
            }
        }

        /// <summary>
        /// Cap nhat thong tin cuoc goi theo thong tin lai xe gui ve
        /// </summary>
        /// <param name="_Id"></param>
        /// <param name="_IDCuocGoi"></param>
        /// <param name="_SoHieuXe"></param>
        /// <param name="_TinNhan"></param>
        /// <param name="_GuiChoAi"></param>
        /// <param name="_LoaiTinNhan"></param>
        /// <returns></returns>
        public bool UpdateCuocGoi_ByManHinh(string _Id, long _IDCuocGoi, string _SoHieuXe, string _TinNhan, string _GuiChoAi, string _LoaiTinNhan,string _XeNhan, string _XeDon)
        {
            return new Taxi.Data.ManHinhDA().UpdateCuocGoi_ByManHinh(_Id, _IDCuocGoi, _SoHieuXe, _TinNhan, _GuiChoAi, _LoaiTinNhan,_XeNhan, _XeDon);
        }

        /// <summary>
        /// chuyen tin nhan man hinh sang ket thuc
        /// </summary>
        /// <param name="_Id"></param>
        /// <returns></returns>
        public bool DeleteManHinh(string _Id)
        {
            return new Taxi.Data.ManHinhDA().DeleteManHinh(_Id);
        }
    }
}
