﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using ChartDirector;
using System.IO;
using Taxi.Utils;
using Janus.Windows.GridEX;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBC_1_3_ChiTietCuocGoiDen : Form
    {
        public const string KYTU_GOIDEN = "A";
        public const string KYTU_GOIDI = "B";

        List<BaoCaoBieuMau3> g_lstBaoCaoBieuMau3;
        private fmProgress m_fmProgress = null;
        public frmBC_1_3_ChiTietCuocGoiDen()
        {
            InitializeComponent();
          
        }
        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;           
            btnExportExcel.Enabled = btnRefresh.Enabled;
            KhoiTao();
        }

        private void KhoiTao()
        {
            panelLoaiXe.Enabled = chkGoiTaxi.Checked;
            panelKetQua.Enabled = chkGoiTaxi.Checked;
            calTuNgay.Value = DateTime.Now.Date;
            calDenNgay.Value = DateTime.Now;
        }

        /// <summary>
        /// hàm kiểm tra xem có bao nhiêu loại cuộc gọi chọn
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetLoaiCuocGoiLuaChon()
        {
            int LoaiCuocGoi = 0;

            if (chkGoiTaxi.Checked && chkGoiLai.Checked && chkGoiKhac.Checked && chkGoiKhieuNai.Checked && chkGoiDichVu.Checked && chkHoiDam.Checked ) LoaiCuocGoi  = 63;

            return LoaiCuocGoi;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {

                string phoneNumber = string.Empty;
                int LoaiCuocGoi = 0;
                int LoaiKH = 0;
                int SoLuotDoChuong = 0;
                DateTime ThoiGianDamThoai = DateTime.MinValue;
                string Line = string.Empty;

                if (StringTools.TrimSpace(editPhoneNumber.Text).Length >0)
                {
                    if (StringTools.TrimSpace(editPhoneNumber.Text).Length <3)
                    {
                        MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                        msgDialog.Show(this, "Bạn phải nhập chính xác số điện thoại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        return;
                    }
                    else
                        phoneNumber = StringTools.TrimSpace(editPhoneNumber.Text);
                }
                // Line
                Line = StringTools.TrimSpace(txtLine.Text);
                // Loai cuoc goi
                if (chkGoiTaxi.Checked) LoaiCuocGoi += 1;
                if (chkGoiLai.Checked) LoaiCuocGoi += 2;
                if (chkGoiKhac.Checked) LoaiCuocGoi += 4;
                if (chkGoiKhieuNai.Checked) LoaiCuocGoi += 8;
                if (chkGoiDichVu.Checked) LoaiCuocGoi += 16;
                if (chkHoiDam.Checked) LoaiCuocGoi += 32;
                if (chkGNho.Checked) LoaiCuocGoi += 64;
                // Loai xe
                int loaiXe = 0;
                // Ket quả cuộc gọi
                int KetQua = 0;
                if (chkGoiTaxi.Checked)
                {
                   
                    if (radXe7Cho.Checked) loaiXe = 7;
                    else if (radXe4Cho.Checked) loaiXe = 4;

                    if (radDonDuoc.Checked) KetQua = 1;
                    else if (radTruotHoan.Checked) KetQua = 2;
                    else if (rbtHoan.Checked) KetQua = 5;
                    else if (radKhongXe.Checked) KetQua = 3;
                    else if (radKhac999.Checked) KetQua = 4; // chọn xe don=999
                }
                // SoLuotDoChuong
                if (StringTools.TrimSpace(editSoChuong .Text).Length > 0)
                {
                    SoLuotDoChuong = int.Parse(StringTools.TrimSpace(editSoChuong.Text));
                    if (SoLuotDoChuong <= 1) SoLuotDoChuong = 0;
                }
                // SoPhutDamThoai
                if ((timeThoiGianDamThoai.Value.Hour != 0) || (timeThoiGianDamThoai.Value.Minute  != 0) || (timeThoiGianDamThoai.Value.Second  != 0))
                {
                    ThoiGianDamThoai = new DateTime(1900, 1, 1, timeThoiGianDamThoai.Value.Hour, timeThoiGianDamThoai.Value.Minute, timeThoiGianDamThoai.Value.Second);
                }
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                List<DieuHanhTaxi> lstCuocGoiKetThuc = new List<DieuHanhTaxi>();
                string NRecords = "";
                string XeNhan = StringTools.TrimSpace(txtXeNhan.Text );
                string XeDon = StringTools.TrimSpace(txtXeDon.Text);
                // Địa chỉ
                string diaChi = StringTools.TrimSpace(txtDiaChi.Text);
               
               
                // NV
                string NVDTTD = StringTools.TrimSpace(txtNVID.Text);
                string NVCS = StringTools.TrimSpace(txtNVCS.Text);

                if (rbKH_All.Checked)
                    LoaiKH = 0;
                else if (rbKH_ThanThiet.Checked)
                    LoaiKH = 1;
                else if (rbKH_VangLai.Checked)
                    LoaiKH = 2;

                int SoGiayChuyenTongdai = calThoiGianChuyenTongDai.Value.Hour*60*60 + calThoiGianChuyenTongDai.Value.Minute *60 + calThoiGianChuyenTongDai.Value.Second ;
                string SQLCondition = this.BuildStringQuery(calTuNgay.Value, calDenNgay.Value, LoaiCuocGoi,diaChi, phoneNumber,
                                                            SoLuotDoChuong, ThoiGianDamThoai, SoGiayChuyenTongdai, editVung.Text, XeNhan, XeDon,Line,
                                                            loaiXe, KetQua, NVDTTD, NVCS, LoaiKH);  

                lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, SQLCondition);
                g_lstBaoCaoBieuMau3 = new List<BaoCaoBieuMau3>();
                g_lstBaoCaoBieuMau3 = ConvertToBaoCaoBieuMau3(lstCuocGoiKetThuc);
                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(g_lstBaoCaoBieuMau3, "lstCuocGoiKetThuc");

                //gridEX_Export.DataMember = "lstCuocGoiKetThuc_ex";
                //gridEX_Export.SetDataBinding(g_lstBaoCaoBieuMau3, "lstCuocGoiKetThuc_ex");
                
                btnRefresh.Enabled = false;
                 
                btnExportExcel.Enabled = !btnRefresh.Enabled;;

            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
            }
        }

        /// <summary>
        /// Kieu du lieu vung co dang
        /// 1;2;3 Cac vung phan cach bang dau ';' 
        /// </summary>
        private string GetSQLStringQueryVung(string Vung)
        {
            if (Vung.Length <= 0) return "";
            string strReturn = string.Empty;

            string[] arrVung = Vung.Split(";".ToCharArray());
            strReturn = " (1<>1) ";
            for (int i = 0; i < arrVung.Length; i++)
            {
                strReturn += "OR   (Vung = " + arrVung[i] + " ) ";
            }
            strReturn = " AND (" + strReturn + ")";
            return strReturn;
        }

        private List<BaoCaoBieuMau3> ConvertToBaoCaoBieuMau3(List<DieuHanhTaxi> lstCuocGoiKetThuc)
        {
            List<BaoCaoBieuMau3> lstBaoCaoBieuMau3 = new List<BaoCaoBieuMau3>();
            if (lstCuocGoiKetThuc != null)
            {
                foreach (DieuHanhTaxi objDHTX in lstCuocGoiKetThuc)
                {
                    if (objDHTX == null) continue;
                    BaoCaoBieuMau3 objBM3 = new BaoCaoBieuMau3();
                    objBM3.ID_DieuHanh = objDHTX.ID_DieuHanh;
                    objBM3.Line = objDHTX.Line;
                    objBM3.PhoneNumber = objDHTX.PhoneNumber;
                    objBM3.MaVung =  objDHTX.MaVung;
                    objBM3.ThoiDiemGoi = objDHTX.ThoiDiemGoi;
                    objBM3.SoLuotDoChuong  = objDHTX.SoLuotDoChuong ;
                    objBM3.GoiTaxi  = objDHTX.GoiTaxi ;
                    objBM3.GoiLai  = objDHTX.GoiLai ;
                    objBM3.SoLuong = objDHTX.SoLuong;
                    objBM3.LoaiXe = objDHTX.LoaiXe ;
                    objBM3.ThongTinKhac  = objDHTX.ThongTinKhac ;
                    objBM3.DiaChiDonKhach  = objDHTX.DiaChiDonKhach ;
                    objBM3.KieuKhachHangGoiDen = objDHTX.KieuKhachHangGoiDen;
                    if(objDHTX.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiTaxi)
                    {
                        if(objDHTX.TrangThaiCuocGoi == Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach )
                            objBM3.DonDuocKhach = true;
                        else objBM3.DonDuocKhach = false  ;

                    if (objDHTX .TrangThaiCuocGoi == Taxi.Utils.TrangThaiCuocGoiTaxi .CuocGoiTruot)
                        objBM3.TruotKhach = true;
                    else objBM3.TruotKhach=false;

                    if (objDHTX.TrangThaiCuocGoi == Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiHoan)
                        objBM3.KhachHoan  = true;
                    else objBM3.KhachHoan = false;
                    if (objDHTX.TrangThaiCuocGoi == Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                        objBM3.KhongXe  = true;
                    else objBM3.KhongXe = false;
                    }
                    objBM3.DoDaiCuocGoi  = objDHTX.DoDaiCuocGoi.AddYears(1900) ;
                    objBM3.FileVoicePath = objDHTX.FileVoicePath;
                    objBM3.MaNhanVienDienThoai  = objDHTX.MaNhanVienDienThoai ;
                    objBM3.MaNhanVienTongDai = objDHTX.MaNhanVienTongDai;
                    objBM3.ThoiDiemChuyenTongDai = objDHTX.ThoiDiemChuyenTongDai;
                    objBM3.ThoiGianDieuXe = objDHTX.ThoiGianDieuXe;
                    objBM3.ThoiGianDonKhach = objDHTX.ThoiGianDonKhach;
                    objBM3.LenhDienThoai = objDHTX.LenhDienThoai;
                    objBM3.LenhTongDai = objDHTX.LenhTongDai;
                    objBM3.GhiChuDienThoai = objDHTX.GhiChuDienThoai;
                    objBM3.GhiChuTongDai = objDHTX.GhiChuTongDai;
                    objBM3.DanhSachXe_DeCu = objDHTX.DanhSachXe_DeCu;
                    objBM3.XeDenDiem = objDHTX.XeDenDiem;
                    objBM3.XeNhan = objDHTX.XeNhan;
                    objBM3.XeDon = objDHTX.XeDon;
                    objBM3.DiaChiTraKhach = objDHTX.DiaChiTraKhach;                    
                    objBM3.PhanLoai = objDHTX.PhanLoai;
                    objBM3.KetQua = objDHTX.KetQua;
                    objBM3.MOIKHACH_NhanVien = objDHTX.MOIKHACH_NhanVien;
                    objBM3.MOIKHACH_LenhMoiKhach = objDHTX.MOIKHACH_LenhMoiKhach;
                    if (objDHTX.MOIKHACH_ThoiDiemMoi_Giu.Year>2010)
                    objBM3.ThoiGianMoiKhach = (int)(objDHTX.MOIKHACH_ThoiDiemMoi_Giu - objDHTX.ThoiDiemGoi).TotalSeconds;
                    lstBaoCaoBieuMau3.Add(objBM3);
                }

            }
            return lstBaoCaoBieuMau3;
        }

        #region XuLyCacCuocGoi ket thuc
        private void LoadCacCuocGoiKetThuc()
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                List<DieuHanhTaxi> lstCuocGoiKetThuc = new List<DieuHanhTaxi>();

                DateTime TimeServer = DieuHanhTaxi.GetTimeServer();

                string strDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TimeServer);

                string NRecords = " TOP 50 ";
                string SQLCondition = "  ORDER BY ThoiDiemGoi DESC";
                lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, SQLCondition);
                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(lstCuocGoiKetThuc, "lstCuocGoiKetThuc");
            }
            catch (Exception ex)
            {
                //TimerCapturePhone.Stop();
                // new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            }

        }
        #endregion XuLyCacCuocGoi ket thuc

        /// <summary>
        /// xay dung chuoi query 
        ///     - TuNgay, Den ngay (bat buoc)
        ///     - Loai Cuoc goi, 1 : Goi Taxi, 3 : GoiLai 7 : GoiKhac
        ///                      4 : GoiTaxi + GoiLai
        ///                      8 : GoiTaxi+GoiKhac
        ///                      10 : GoiLai + Goi Khac
        ///     - PhoneNumber : lay ra voi so may; rống : thì không so
        ///     - SoLuotDoChung : Số lượt đổ chuông lớn hơn ; >1
        ///     - ThoiGianDamThoại : Tính theo phút >1
        /// Ket Qua : 0 - không xe, 1 : đón được, 2 : trượt hoãn, 3 không xe
        /// </summary>
        private string BuildStringQuery(DateTime TuNgay, DateTime DenNgay, int LoaiCuocGoi, string DiaChi, string PhoneNumber, int SoLuotDoChuong,
                                        DateTime  ThoiGianDamThoai, int SoGiayChuyenTongDay, string Vungs,string XeNhan,string XeDon, string Line, int loaiXe,
                                        int KetQua, string NVDTTD, string NVCS , int LoaiKH)
        {
            string SQLCondition = string.Empty;
            string strTuNgay = string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay);
            string strDenNgay = string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay);

            SQLCondition = String.Format(" AND ((ThoiDiemGoi >={0}) AND (ThoiDiemGoi <= {1} ) ", strTuNgay, strDenNgay);
            SQLCondition += String.Format(" OR ((LenhDienThoai like N'Khách đặt' Or LenhDienThoai like N'Khách hẹn') and ThoiDiemThayDoiDuLieu between{0} AND {1} )) ", strTuNgay, strDenNgay);
            //(LenhDienThoai like N'Khách đặt' Or LenhDienThoai like N'Khách hẹn') and ThoiDiemThayDoiDuLieu between '2012-09-10 00:02:30.210' and '2012-09-12 12:02:30.210'

            if (LoaiCuocGoi > 0)
            {
                SQLCondition += GetSQLStringQueryLoaiCuocGoi(LoaiCuocGoi);
            }
            if (DiaChi.Length > 0)
                SQLCondition += String.Format(" AND ( DiaChiDonKhach LIKE N'%{0}%') ", DiaChi);

            if (Line.Length > 0)
            {
                SQLCondition += String.Format(" AND (Line ='{0}') ", Line);
            }
            if (Vungs.Length > 0) 
                SQLCondition += GetSQLStringQueryVung(Vungs);

            // phonenumber
            if(PhoneNumber.Length >0)
                SQLCondition += GetSQLStringQueryPhoneNumbers(PhoneNumber);

            if (loaiXe>0)
            {
                SQLCondition += String.Format(" AND (LoaiXe LIKE '%{0}%') ", loaiXe);
            }
            if (KetQua > 0)
            {
                SQLCondition += GetSQLStringQueryTheoKetQuaCuocGoi(KetQua);
            }
           
            if (XeNhan.Length > 0)
            {
                SQLCondition += String.Format(" AND (XeNhan  LIKE '%{0}%') ", XeNhan);
            }
            if (XeDon.Length > 0)
            {
                SQLCondition += String.Format(" AND (XeDon  LIKE '%{0}%') ", XeDon);
            }
           
            if (SoLuotDoChuong > 1)
                SQLCondition += String.Format(" AND ( SoLuotDoChuong >= {0}) ", SoLuotDoChuong);

            if (LoaiKH == 1)
                SQLCondition += " AND ( KieuKhachHangGoiDen = 3 Or KieuKhachHangGoiDen = 5 Or KieuKhachHangGoiDen = 6) ";
            else if (LoaiKH == 2)
                SQLCondition += " AND ( KieuKhachHangGoiDen <> 3 AND KieuKhachHangGoiDen <> 5 AND KieuKhachHangGoiDen <> 6) ";

            if (ThoiGianDamThoai != DateTime.MinValue)
                SQLCondition += String.Format(" AND ( Duration > cast('{0}' as Datetime ) )", string.Format("{0:yyyy-MM-dd HH:mm:ss}", ThoiGianDamThoai));
            if(SoGiayChuyenTongDay>0)  SQLCondition += " AND (ThoiDiemChuyenTongDai > "+ SoGiayChuyenTongDay.ToString() + ") ";

            if (NVDTTD.Length > 0)
            {
                SQLCondition += " AND (MaNhanVienDienThoai = '" + NVDTTD + "' OR MaNhanVienTongDai = '" + NVDTTD + "')";
            }
            if (NVCS.Length > 0)
            {
                SQLCondition += " AND (MOIKHACH_NhanVien = '" + NVCS + "')";
            }

            return SQLCondition;
        }

        private string GetSQLStringQueryTheoKetQuaCuocGoi(int KetQua)
        {
            string sql = "";
            if (KetQua == 1) // cuoc goi taxi don duoc
            {
                sql += " AND (KieuCuocGoi = 1 AND (LEN([XeDon]) > 0 AND (TrangThaiCuocGoi = 6 OR TrangThaiCuocGoi = 5 OR TrangThaiCuocGoi = 1 OR TrangThaiCuocGoi = 0))) ";
            }
            else if (KetQua == 2) // trượt
            {
                sql += " AND (KieuCuocGoi = 1 AND TrangThaiCuocGoi =2 ) ";
            }
            else if (KetQua == 3) // khong xe
            {
                sql += " AND (KieuCuocGoi = 1 AND TrangThaiCuocGoi =4 ) ";
            }
            else if (KetQua == 4) // chọn xe 999 
            {
                sql += " AND (KieuCuocGoi = 1 AND ( TrangThaiCuocGoi = 5) AND (LEN([XeDon]) <= 0 OR [XeDon] IS NULL) ) ";
            }
            else if (KetQua == 5) // hoãn
            {
                sql += " AND (KieuCuocGoi = 1 AND TrangThaiCuocGoi =3 ) ";
            }
            //else
            //{
            //    sql += " AND (KieuCuocGoi = 1 AND TrangThaiCuocGoi =3 ) ";
            //}
            return sql;
        }
         /// <summary>
         /// loai cuoc goi 
         /// </summary>
        private string GetSQLStringQueryLoaiCuocGoi(int LoaiCuocGoi)
        {
            //GoiTaxi = 1,  
            //GoiLai = 2,
            //GoiKhieuNai = 3,
            //GoiDichVu = 4, 
            //GoiHoiDam = 5, // thoong tin lai xe bao dam, ..
            //GoiKhac = 6,   // các cuộc hỏi gì đó không thuộc các cuộc trên
            string sql = string.Empty;
            string sqlGoiTaxi = "";
            string sqlGoiLai ="";
            string sqlGoiKhieuNai = "";
            string sqlGoiDichVu = "";
            string sqlGoiKhac = "";
            string sqlGoiHoiDam = "";
            string sqlGoiNho = "";
            if(LoaiCuocGoi > 0) {
                if ((LoaiCuocGoi & 1) > 0) sqlGoiTaxi = "(KieuCuocGoi=1 AND Vung <= 8)";
                if ((LoaiCuocGoi & 2) > 0) sqlGoiLai = "(KieuCuocGoi = 2 AND Vung <= 8)";
                if( (LoaiCuocGoi & 4)>0) sqlGoiKhac = "(KieuCuocGoi = 6)";
                if(( LoaiCuocGoi & 8)>0) sqlGoiKhieuNai = "(KieuCuocGoi = 3)";
                if( (LoaiCuocGoi & 16)>0) sqlGoiDichVu  = "( KieuCuocGoi = 4 OR ( KieuCuocGoi=1 AND (Vung=9 OR Vung=10)) )";
                if ((LoaiCuocGoi & 32) > 0) sqlGoiHoiDam = "(KieuCuocGoi = 5)";
                if ((LoaiCuocGoi & 64) > 0) sqlGoiNho = "(KieuCuocGoi = 7 or LenhDienThoai=N'Cuốc gọi nhỡ')";

                if (sqlGoiTaxi.Length > 0) sql += sqlGoiTaxi + "OR";
                if (sqlGoiLai.Length > 0) sql += sqlGoiLai + "OR";
                if (sqlGoiKhac.Length > 0) sql += sqlGoiKhac + "OR";
                if (sqlGoiKhieuNai.Length > 0) sql += sqlGoiKhieuNai + "OR";
                if (sqlGoiDichVu.Length > 0) sql += sqlGoiDichVu + "OR";
                if (sqlGoiHoiDam.Length > 0) sql += sqlGoiHoiDam + "OR";
                if (sqlGoiNho.Length > 0) sql += sqlGoiNho + "OR";

                if (sql.EndsWith("OR")) sql = sql.Substring(0, sql.Length - 2);
                if (sql.Length > 0) sql = "  AND (" + sql + ") ";
            }
            
            return  sql; 
        }

        /// <summary>
        /// nhieu so dien thoi cach nhau = ";"
        /// vd : 043494950;0980030404
        /// </summary>
        private string GetSQLStringQueryPhoneNumbers(string PhoneNumbers)
        {
            string strReturn = "";
            //if (PhoneNumbers.Length < 6) return strReturn;

            string[] arrPhone = PhoneNumbers.Split(";".ToCharArray());
            strReturn = " (1<>1) ";
            for (int i = 0; i < arrPhone.Length; i++)
            {
                strReturn +=  "OR ( PhoneNumber  LIKE '%" +  arrPhone[i].ToString () + "%') ";
            }
            strReturn = " AND (" + strReturn + ")";
            return strReturn;
        }
        
        private void editPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char  chr = Convert.ToChar(";");
            if(char.IsDigit ( e.KeyChar) || (e.KeyChar == (char) Keys.Back ) || (e.KeyChar == chr  ))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editSoChuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar ==(char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editPhut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void gridDienThoai_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                HienThiAnhTrangThai_MauChu(e.Row);
                    
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// - Hien thi anh trang thai tuong ung voi trang thai lenh
        /// - thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
        /// - Thay mau chu cua dia chi cua khach goi lai
        /// - thay doi may cua cuoc goi khong phai cua minh phu trach
        /// </summary>
        private void HienThiAnhTrangThai_MauChu(GridEXRow row)
        {
            try
            {
                BaoCaoBieuMau3 objBC3 = (BaoCaoBieuMau3)row.DataRow;

                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                if (objBC3.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.MediumOrchid;
                    RowStyle.ForeColor = Color.White;
                    row.Cells["PhoneNumber"].FormatStyle = RowStyle;
                }
                else if (objBC3.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangVIP)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Blue;
                    row.Cells["PhoneNumber"].FormatStyle = RowStyle;
                }
                else if (objBC3.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangVang
                    || objBC3.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangBac)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.ForestGreen;
                    row.Cells["PhoneNumber"].FormatStyle = RowStyle;
                }
                if (objBC3.GoiLai || objBC3.LenhDienThoai.Contains("gọi lại"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    row.RowStyle = RowStyle;
                }
                if (objBC3.FileVoicePath.Length <= 0)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Violet;
                    row.Cells["RingNumber"].FormatStyle = RowStyle;
                }
            }
            catch (Exception ex)
            {
                ////  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau3.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);               
                gridEXExporter1.Export((Stream)objFile);
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }
        /// <summary>
        /// hàm check tất cả các cuộc gọi được chọn
        /// nếu chọn tất cả các cuộc gọi thì 'Tất cả' dược chọn. 
        /// Ngược lại thì không chọn.
        /// </summary>
        private void CheckTatCaCuocGoiDuocChon()
        {
            if (GetLoaiCuocGoiLuaChon() == 63) // tất cả được chọn
            {
                chkTatCaLoaiCuocGoi.Checked = true;
            }
            else chkTatCaLoaiCuocGoi.Checked = false;
        }
        private void chkTatCaLoaiCuocGoi_CheckedChanged(object sender, EventArgs e)
        {

            chkGoiTaxi.Checked = chkTatCaLoaiCuocGoi.Checked;
            chkGoiLai.Checked = chkTatCaLoaiCuocGoi.Checked;
            chkGoiKhieuNai.Checked = chkTatCaLoaiCuocGoi.Checked;
            chkHoiDam.Checked = chkTatCaLoaiCuocGoi.Checked;
            chkGoiDichVu.Checked = chkTatCaLoaiCuocGoi.Checked;
            chkGoiKhac.Checked = chkTatCaLoaiCuocGoi.Checked;

            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled; ;
        }
        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;             
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            panelKetQua.Enabled = chkGoiTaxi.Checked;
            panelLoaiXe.Enabled = chkGoiTaxi.Checked;

            
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
            
        }
        private void chkGoiKhieuNai_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;             
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            
        }
        private void chkGoiDichVu_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            if (chkGoiDichVu.Checked)
            {
             //   editVung.Text = "9;10";
            }
            else
            {
           //     editVung.Text = "";
            }            
        }
        private void editPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }
        private void chkHoiDam_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            
        }
        private void editSoChuong_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }


        #region Play wave sound 

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string filenameDB = "";
            string filenameVoice = "";
            gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            BaoCaoBieuMau3 objItem = null;

            if (gridDienThoai.SelectedItems.Count > 0)
            {
                objItem = (BaoCaoBieuMau3)(gridDienThoai.SelectedItems[0]).GetRow().DataRow;

                filenameDB = (gridDienThoai.SelectedItems[0]).GetRow().Cells["FileVoicePath"].Text;
                filenameVoice = NgheLaiCuocGoi.GetFileNameCuocDi(filenameDB);
            } 

            if (filenameVoice.Length > 0)
            {
                player1.FileName = filenameVoice;
                if (player1.FileName != "")
                {
                    player1.Play();
                    btnPause.Text = "Pause";
                    this.timer1.Enabled = true;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(@"File không tồn tại.Bạn cần kiểm tra lại đường dẫn tới thư mục lưu file âm thanh.Thư mục này phải được lưu cùng với thư mục của hệ thống bắt số.Ví dụ : \\\maychu\GhiAm. Hoặc bạn có thể tìm ở file gốc.");
                }
            }
            else
            { 
                if (new MessageBox.MessageBoxBA().Show(this, "Chọn file gốc để nghe.", "Thong bao", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                {

                    string FileNameWildcard = StringTools.GetFilenameWidlcard (KYTU_GOIDEN,objItem.PhoneNumber );
                    frmTimFile frmTim = new frmTimFile(NgheLaiCuocGoi.GetFullDirectory(ThongTinCauHinh.ThuMucFileAmThanh,objItem.ThoiDiemGoi), FileNameWildcard);
                    frmTim.ShowDialog();
                    if (frmTim.DialogResult == DialogResult.OK)
                    {
                        player1.FileName = frmTim.GetFilename();
                        this.lblFilename.Text = player1.FileName;
                        if (player1.FileName != "")
                        {
                            player1.Play();
                            btnPause.Text = "Pause";
                            this.timer1.Enabled = true;
                        }
                        else
                        {
                            new MessageBox.MessageBoxBA().Show(@"File không tồn tại.Bạn cần kiểm tra lại đường dẫn tới thư mục lưu file âm thanh.");
                        }
                    }
                }
            }
        }


     
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnPause.Enabled = player1.Status != "stopped";
            btnStop.Enabled = player1.Status != "stopped";
            int pos = (player1.PositionInMS * this.tbPosition.Maximum) / player1.DurationInMS;
            this.tbPosition.Value = pos;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (player1.Status == "paused")
            {
                player1.Resume();
                btnPause.Text = "Pause";
            }
            else
            {
                player1.Pause();
                btnPause.Text = "Resume";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            player1.Stop();
            this.timer1.Enabled = false;
        }
        #endregion


        #region Cap nhat du lieu duration + filepathvoice
        /// <summary>
        /// nhan thong tin cac cuoc goi di va cap nhat vao DB
        /// </summary>
        private void CaptureCuocGoiDi()
        {
            try
            {
                // lay du lieu
                DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                string VOCFileName = ProcessVocFile.GetVOCFileFullPath(timeServer);
                DataTable dt = new DataTable();
                dt = ProcessVocFile.GetEarlyPhoneDialOut(VOCFileName);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CuocGoiDi objGoiDi = new CuocGoiDi(dr["Line"].ToString(), dr["PhoneNumber"].ToString(), (DateTime)dr["ThoiDiemGoi"], (DateTime)dr["DoDaiCuocGoi"], dr["VoiceFilePath"].ToString());
                        if (!objGoiDi.Insert())
                        {
                            //  LogError.WriteLog("Loi luu xuong DB cuoc goi di ", new Exception("[ Cuoc goi di ]"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Loi luu xuong DB cuoc goi di ", ex);
            }
        }

        #endregion 

        private void timeThoiGianDamThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void calThoiGianChuyenTongDai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void editVung_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void txtXeNhan_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }
        private void txtXeDon_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;

            btnExportExcel.Enabled = !btnRefresh.Enabled; ;
        }
        private void radDonDuoc_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void radTruotHoan_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void radKhongXe_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }
        private void radKhac999_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;

            btnExportExcel.Enabled = !btnRefresh.Enabled; ;
        }
        private void txtNVID_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void txtLine_TextChanged(object sender, EventArgs e)
        {
             btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void timeThoiGianDamThoai_ValueChanged(object sender, EventArgs e)
        {
             btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calThoiGianChuyenTongDai_ValueChanged(object sender, EventArgs e)
        {
             btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void txtNVCS_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void radTatCaLoaiXe_CheckedChanged(object sender, EventArgs e)
        { 
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;  
        }

        private void radXe4Cho_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;  
        }

        private void radXe7Cho_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;  
        }

        private void radTatCa_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void gridDienThoai_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == (Keys.Control | Keys.C))
            {
                int col = gridDienThoai.Col;
                if (col == 2 || col == 10)
                {
                    var val = gridDienThoai.CurrentRow.Cells[col].Value;
                    Clipboard.SetText(val.ToString());
                }
            }        
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int col = gridDienThoai.Col;
            if (col == 2 || col == 10)
            {
                var val = gridDienThoai.CurrentRow.Cells[col].Value;
                Clipboard.SetText(val.ToString());
            }
        }

        private void gridDienThoai_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int col = gridDienThoai.Col;
                if (col == 2 || col == 10)
                {
                    menuCopy.Show(gridDienThoai, e.X, e.Y);
                }
            }
        }
    }
}