using System;
using System.Collections.Generic;
using Taxi.Utils;
using System.Data.SqlClient;
using System.Data;

namespace Taxi.Data.KhachDat
{
    public class KhachDatDA : DBObject
    {
        /// <summary>
        /// Insert Khách Đặt Lịch Xe
        /// </summary>
        /// <returns>Thành công = 1, Không thành công = 0 </returns>
        public bool InsertKhachDat(DateTime ThoiDiemTiepNhan, string TenKhachHang, string DiaChiDon, string SoDienThoai, int VungKenh
                                , bool IsLapLai, DateTime GioDon, DateTime ThoiDiemBatDau, DateTime ThoiDiemKetThuc, string NgayTrongTuanLapLai
                                , int SoPhutBaoTruoc, long FK_CuocGoiID, string CreatedBy, string GhiChu, string LoaiXe, int SoLuongXe)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@ThoiDiemTiepNhan",SqlDbType.DateTime),
                    new SqlParameter ("@TenKhachHang",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@DiaChiDon",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@SoDienThoai",SqlDbType.VarChar,15 ),
                    new SqlParameter ("@VungKenh",SqlDbType.Int ),
                    new SqlParameter ("@IsLapLai",SqlDbType.Bit),
                    new SqlParameter ("@GioDon",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemBatDau",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemKetThuc",SqlDbType.DateTime),
                    new SqlParameter ("@NgayLapLai",SqlDbType.VarChar ,30),
                    new SqlParameter ("@SoPhutBaoTruoc",SqlDbType.Int),
                    new SqlParameter ("@FK_CuocGoiID",SqlDbType.BigInt),
                    new SqlParameter ("@CreatedBy",SqlDbType.NVarChar ,50 ),
                    new SqlParameter ("@GhiChu",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@LoaiXe",SqlDbType.VarChar ,50 ),
                    new SqlParameter ("@SoLuongXe",SqlDbType.Int)
                };
                parameters[0].Value = ThoiDiemTiepNhan;
                parameters[1].Value = TenKhachHang;
                parameters[2].Value = DiaChiDon;
                parameters[3].Value = SoDienThoai;
                parameters[4].Value = VungKenh;
                parameters[5].Value = IsLapLai;
                parameters[6].Value = GioDon;
                parameters[7].Value = new DateTime(ThoiDiemBatDau.Year, ThoiDiemBatDau.Month, ThoiDiemBatDau.Day, 0, 0, 0);
                parameters[8].Value = new DateTime(ThoiDiemKetThuc.Year, ThoiDiemKetThuc.Month, ThoiDiemKetThuc.Day, 23, 59, 0);
                parameters[9].Value = NgayTrongTuanLapLai;
                parameters[10].Value = SoPhutBaoTruoc;
                parameters[11].Value = FK_CuocGoiID;
                parameters[12].Value = CreatedBy;
                parameters[13].Value = GhiChu;
                parameters[14].Value = LoaiXe;
                parameters[15].Value = SoLuongXe;
                rowAffect = this.RunProcedure("SP_T_KHACHDAT_INSERT", parameters, rowAffect);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Áp dụng PhươngTrang
        /// </summary>
        public bool InsertKhachDat_V2(DateTime ThoiDiemTiepNhan, string TenKhachHang, string DiaChiDon, string SoDienThoai, int VungKenh
                              , bool IsLapLai, DateTime GioDon, DateTime ThoiDiemBatDau, DateTime ThoiDiemKetThuc, string NgayTrongTuanLapLai
                              , int SoPhutBaoTruoc, long FK_CuocGoiID, string CreatedBy, string GhiChu, string LoaiXe, int SoLuongXe, string DiaChiTra, float SoKm, int FK_SystemBookID)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@ThoiDiemTiepNhan",SqlDbType.DateTime),
                    new SqlParameter ("@TenKhachHang",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@DiaChiDon",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@SoDienThoai",SqlDbType.VarChar,15 ),
                    new SqlParameter ("@VungKenh",SqlDbType.Int ),
                    new SqlParameter ("@IsLapLai",SqlDbType.Bit),
                    new SqlParameter ("@GioDon",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemBatDau",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemKetThuc",SqlDbType.DateTime),
                    new SqlParameter ("@NgayLapLai",SqlDbType.VarChar ,30),
                    new SqlParameter ("@SoPhutBaoTruoc",SqlDbType.Int),
                    new SqlParameter ("@FK_CuocGoiID",SqlDbType.BigInt),
                    new SqlParameter ("@CreatedBy",SqlDbType.NVarChar ,50 ),
                    new SqlParameter ("@GhiChu",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@LoaiXe",SqlDbType.VarChar ,50 ),
                    new SqlParameter ("@SoLuongXe",SqlDbType.Int),
                    new SqlParameter("@DiaChiTra",SqlDbType.NVarChar,250),
                    new SqlParameter("@SoKm",SqlDbType.Float),
                    new SqlParameter("@FK_SystemBookID",SqlDbType.Int)
                };
                parameters[0].Value = ThoiDiemTiepNhan;
                parameters[1].Value = TenKhachHang;
                parameters[2].Value = DiaChiDon;
                parameters[3].Value = SoDienThoai;
                parameters[4].Value = VungKenh;
                parameters[5].Value = IsLapLai;
                parameters[6].Value = GioDon;
                parameters[7].Value = new DateTime(ThoiDiemBatDau.Year, ThoiDiemBatDau.Month, ThoiDiemBatDau.Day, 0, 0, 0);
                parameters[8].Value = new DateTime(ThoiDiemKetThuc.Year, ThoiDiemKetThuc.Month, ThoiDiemKetThuc.Day, 23, 59, 0);
                parameters[9].Value = NgayTrongTuanLapLai;
                parameters[10].Value = SoPhutBaoTruoc;
                parameters[11].Value = FK_CuocGoiID;
                parameters[12].Value = CreatedBy;
                parameters[13].Value = GhiChu;
                parameters[14].Value = LoaiXe;
                parameters[15].Value = SoLuongXe;
                parameters[16].Value = DiaChiTra;
                parameters[17].Value = SoKm;
                parameters[18].Value = FK_SystemBookID;
                rowAffect = this.RunProcedure("SP_T_KHACHDAT_INSERT_V2", parameters, rowAffect);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Update Khách Đặt Lịch Xe
        /// </summary>
        /// <returns>Thành công = 1, Không thành công = 0 </returns>
        public bool UpdateKhachDat(string TenKhachHang, string DiaChiDon, string SoDienThoai, int VungKenh
                                , bool IsLapLai, DateTime GioDon, DateTime ThoiDiemBatDau, DateTime ThoiDiemKetThuc, string NgayTrongTuanLapLai
                                , int SoPhutBaoTruoc, string UpdatedBy, int PK_KhachDatID, string GhiChu, string LoaiXe, int SoLuongXe, double SoTien)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@TenKhachHang",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@DiaChiDon",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@SoDienThoai",SqlDbType.VarChar,15 ),
                    new SqlParameter ("@VungKenh",SqlDbType.Int ),
                    new SqlParameter ("@IsLapLai",SqlDbType.Bit),
                    new SqlParameter ("@GioDon",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemBatDau",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemKetThuc",SqlDbType.DateTime),
                    new SqlParameter ("@NgayLapLai",SqlDbType.VarChar ,30),
                    new SqlParameter ("@SoPhutBaoTruoc",SqlDbType.Int),
                    new SqlParameter ("@UpdatedBy",SqlDbType.NVarChar ,50 ),
                    new SqlParameter ("@PK_KhachDatID",SqlDbType.Int),
                    new SqlParameter ("@GhiChu",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@LoaiXe",SqlDbType.VarChar ,50 ),
                    new SqlParameter ("@SoLuongXe",SqlDbType.Int),
                    new SqlParameter ("@SoTien",SqlDbType.Money)
                };
                parameters[0].Value = TenKhachHang;
                parameters[1].Value = DiaChiDon;
                parameters[2].Value = SoDienThoai;
                parameters[3].Value = VungKenh;
                parameters[4].Value = IsLapLai;
                parameters[5].Value = GioDon;
                parameters[6].Value = new DateTime(ThoiDiemBatDau.Year, ThoiDiemBatDau.Month, ThoiDiemBatDau.Day, 0, 0, 0);
                parameters[7].Value = new DateTime(ThoiDiemKetThuc.Year, ThoiDiemKetThuc.Month, ThoiDiemKetThuc.Day, 23, 59, 0);
                parameters[8].Value = NgayTrongTuanLapLai;
                parameters[9].Value = SoPhutBaoTruoc;
                parameters[10].Value = UpdatedBy;
                parameters[11].Value = PK_KhachDatID;
                parameters[12].Value = GhiChu;
                parameters[13].Value = LoaiXe;
                parameters[14].Value = SoLuongXe;
                parameters[15].Value = SoTien;

                rowAffect = RunProcedure("SP_T_KHACHDAT_UPDATE", parameters, rowAffect);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Áp dụng PhuongTrang
        /// </summary>
        public bool UpdateKhachDat_V2(string TenKhachHang, string DiaChiDon, string SoDienThoai, int VungKenh
                              , bool IsLapLai, DateTime GioDon, DateTime ThoiDiemBatDau, DateTime ThoiDiemKetThuc, string NgayTrongTuanLapLai
                              , int SoPhutBaoTruoc, string UpdatedBy, int PK_KhachDatID, string GhiChu, string LoaiXe, int SoLuongXe, double SoTien, string DiaChiTra, float SoKm, int FK_SystemBookID)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@TenKhachHang",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@DiaChiDon",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@SoDienThoai",SqlDbType.VarChar,15 ),
                    new SqlParameter ("@VungKenh",SqlDbType.Int ),
                    new SqlParameter ("@IsLapLai",SqlDbType.Bit),
                    new SqlParameter ("@GioDon",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemBatDau",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemKetThuc",SqlDbType.DateTime),
                    new SqlParameter ("@NgayLapLai",SqlDbType.VarChar ,30),
                    new SqlParameter ("@SoPhutBaoTruoc",SqlDbType.Int),
                    new SqlParameter ("@UpdatedBy",SqlDbType.NVarChar ,50 ),
                    new SqlParameter ("@PK_KhachDatID",SqlDbType.Int),
                    new SqlParameter ("@GhiChu",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@LoaiXe",SqlDbType.VarChar ,50 ),
                    new SqlParameter ("@SoLuongXe",SqlDbType.Int),
                    new SqlParameter ("@SoTien",SqlDbType.Money),
                    new SqlParameter ("@DiaChiTra",SqlDbType.NVarChar ,250 ),
                    new SqlParameter ("@SoKm",SqlDbType.Float),
                    new SqlParameter ("@FK_SystemBookID",SqlDbType.Int)
                };
                parameters[0].Value = TenKhachHang;
                parameters[1].Value = DiaChiDon;
                parameters[2].Value = SoDienThoai;
                parameters[3].Value = VungKenh;
                parameters[4].Value = IsLapLai;
                parameters[5].Value = GioDon;
                parameters[6].Value = new DateTime(ThoiDiemBatDau.Year, ThoiDiemBatDau.Month, ThoiDiemBatDau.Day, 0, 0, 0);
                parameters[7].Value = new DateTime(ThoiDiemKetThuc.Year, ThoiDiemKetThuc.Month, ThoiDiemKetThuc.Day, 23, 59, 0);
                parameters[8].Value = NgayTrongTuanLapLai;
                parameters[9].Value = SoPhutBaoTruoc;
                parameters[10].Value = UpdatedBy;
                parameters[11].Value = PK_KhachDatID;
                parameters[12].Value = GhiChu;
                parameters[13].Value = LoaiXe;
                parameters[14].Value = SoLuongXe;
                parameters[15].Value = SoTien;
                parameters[16].Value = DiaChiTra;
                parameters[17].Value = SoKm;
                parameters[18].Value = FK_SystemBookID;
                rowAffect = RunProcedure("SP_T_KHACHDAT_UPDATE_V2", parameters, rowAffect);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// Áp dụng PhuongTrang
        /// </summary>
        public bool UpdateKhachDat_ACTIVE(int PK_KhachDatID, string UserUpdate)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@PK_KhachDatID",SqlDbType.Int),
                    new SqlParameter ("@UserUpdate",SqlDbType.NVarChar ,250)
                };
                parameters[0].Value = PK_KhachDatID;
                parameters[1].Value = UserUpdate;
                rowAffect = RunProcedure("SP_T_KHACHDAT_UPDATE_ACTIVE", parameters, rowAffect);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Khách Đặt Lịch Xe
        /// </summary>
        /// <param name="PK_KhachDatID">Id Khach Dat</param>
        /// <returns>Thành công = 1, Không thành công = 0 </returns>
        public bool DeleteKhachDat(int PK_KhachDatID)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter ("@PK_KhachDatID",SqlDbType.Int)
                };
                parameters[0].Value = PK_KhachDatID;

                rowAffect = this.RunProcedure("SP_T_KHACHDAT_DELETE", parameters, rowAffect);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Status Row
        /// </summary>
        /// <param name="PK_KhachDatID"></param>
        /// <returns></returns>
        public bool KhachDat_UpdateStatus(int PK_KhachDatID, int StatusRow, DateTime UpdateDate, string UpdateBy)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter ("@PK_KhachDatID",SqlDbType.Int),
                    new SqlParameter ("@StatusRow",SqlDbType.Int),
                    new SqlParameter ("@UpdateDate",SqlDbType.DateTime),
                    new SqlParameter ("@UpdateBy",SqlDbType.VarChar, 20)
                };
                parameters[0].Value = PK_KhachDatID;
                parameters[1].Value = StatusRow;
                parameters[2].Value = UpdateDate;
                parameters[3].Value = UpdateBy;

                rowAffect = this.RunProcedure("SP_T_KHACHDAT_UPDATE_STATUS", parameters, rowAffect);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("KhachDat_UpdateStatus", ex);
                return false;
            }
        }

        /// <summary>
        /// lay ra tat ca thong tin khach dat cua 1 ban ghi
        /// </summary>
        public DataTable GetKhachDat(int PK_KhachDatID)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@PK_KhachDatID", SqlDbType.Int)
            };
            parameters[0].Value = PK_KhachDatID;
            return (RunProcedure("SP_T_KHACHDAT_SELECT_BY_ID", parameters, "tblDatXe")).Tables[0];
        }

        /// <summary>
        /// lay ra tat ca thong tin khach dat theo ngay tiếp nhận
        /// </summary>
        /// <param name="ThoiDiemTiepNhan"></param>
        /// <returns></returns>
        public DataTable GetKhachDat_TGTiepNhan(DateTime ThoiDiemTiepNhan)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ThoiDiemTiepNhan", SqlDbType.DateTime)
                };
                parameters[0].Value = ThoiDiemTiepNhan;
                return (RunProcedure("SP_T_KHACHDAT_SELECT_NGAYTIEPNHAN", parameters, "tblDatXe")).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// lay ra tat ca thong tin khach dat theo ngay tiếp nhận
        /// </summary>
        /// <param name="ThoiDiemTiepNhan"></param>
        /// <returns></returns>
        public DataTable GetKhachDat_ChenCuocGoi(DateTime ThoiDiemTiepNhan)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ThoiDiemTiepNhan", SqlDbType.DateTime)
                };
                parameters[0].Value = ThoiDiemTiepNhan;
                return (RunProcedure("SP_T_KHACHDAT_CHECK_LAPLAI_CHENCUOCGOI", parameters, "tblDatXe")).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// lay ra tat ca thong tin khach dat cua tất cả ban ghi
        /// </summary>
        /// <returns></returns>
        public DataTable GetKhachDat_All()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { };

                return (RunProcedure("SP_T_KHACHDAT_SELECT_ALL", parameters, "tblDatXe")).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetKhachDat_Search(DateTime TGTiepNhanTu, DateTime TGTiepNhanDen, string TenKhachHang, string DiaChiDon, string SoDienThoai, int VungKenh
                                , int IsLapLai, DateTime GioDonTu, DateTime GioDonDen, DateTime ThoiDiemBatDau, DateTime ThoiDiemKetThuc, int SoPhutBaoTruoc, string LoaiXe, int SoLuongXe)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@TGTiepNhanTu",SqlDbType.DateTime),
                    new SqlParameter ("@TGTiepNhanDen",SqlDbType.DateTime),
                    new SqlParameter ("@TenKhachHang",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@DiaChiDon",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@SoDienThoai",SqlDbType.VarChar,15 ),
                    new SqlParameter ("@VungKenh",SqlDbType.Int ),
                    new SqlParameter ("@IsLapLai",SqlDbType.Bit),
                    new SqlParameter ("@GioDonTu",SqlDbType.DateTime),
                    new SqlParameter ("@GioDonDen",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemBatDau",SqlDbType.DateTime),
                    new SqlParameter ("@ThoiDiemKetThuc",SqlDbType.DateTime),
                    new SqlParameter ("@SoPhutBaoTruoc",SqlDbType.Int),
                    new SqlParameter ("@LoaiXe",SqlDbType.VarChar,50),
                    new SqlParameter ("@SoLuongXe",SqlDbType.Int)
                };
                parameters[0].Value = TGTiepNhanTu;
                parameters[1].Value = TGTiepNhanDen;
                parameters[2].Value = TenKhachHang;
                parameters[3].Value = DiaChiDon;
                parameters[4].Value = SoDienThoai;
                parameters[5].Value = VungKenh;
                if (IsLapLai == 0)
                    parameters[6].Value = false;
                else if (IsLapLai == 1)
                    parameters[6].Value = true;
                parameters[7].Value = GioDonTu;
                parameters[8].Value = GioDonDen;
                if (ThoiDiemBatDau != DateTime.MinValue)
                    parameters[9].Value = ThoiDiemBatDau;
                if (ThoiDiemKetThuc != DateTime.MinValue)
                    parameters[10].Value = ThoiDiemKetThuc;
                parameters[11].Value = SoPhutBaoTruoc;
                parameters[12].Value = LoaiXe;
                parameters[13].Value = SoLuongXe;

                return (RunProcedure("SP_T_KHACHDAT_SELECT_SEARCH", parameters, "tblDatXe")).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetKhachDat_Search_V2(DateTime TGTiepNhanTu, DateTime TGTiepNhanDen, string TenKhachHang, string DiaChiDon, string SoDienThoai)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@TGTiepNhanTu",SqlDbType.DateTime),
                    new SqlParameter ("@TGTiepNhanDen",SqlDbType.DateTime),
                    new SqlParameter ("@TenKhachHang",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@DiaChiDon",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@SoDienThoai",SqlDbType.VarChar,15 )
                };
                parameters[0].Value = TGTiepNhanTu;
                parameters[1].Value = TGTiepNhanDen;
                parameters[2].Value = TenKhachHang;
                parameters[3].Value = DiaChiDon;
                parameters[4].Value = SoDienThoai;

                return (RunProcedure("SP_T_KHACHDAT_SELECT_SEARCH_V2", parameters, "tblDatXe")).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
