using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Data.G5.DanhMuc;

namespace Taxi.Controls.Base.Controls.Grids.Extends
{
    public delegate void GridStyle(AppearanceObject Appearance,string FieldName,int RowIndex,bool IsRow);
    public class DienThoaiGridView : RealTimeGridView<CuocGoi, long, G5Command>
    {
        public override void IniGridView()
        {
            #region === Ini Process ===
            this.GetKey = (cg) => cg.IDCuocGoi;
            this.GetLastUpdate = (cg) => cg.ThoiDiemThayDoiDuLieu;
            this.IsPopUp = true;
            this.CheckPopup = (cg) => !cg.FT_IsFT;
            
            this.ActionUpdateData = (T1, T2) =>
            {
                T1.TrangThaiCuocGoi = T2.TrangThaiCuocGoi;
                T1.LenhTongDai = T2.LenhTongDai;
                T1.GhiChuTongDai = T2.GhiChuTongDai;
                T1.MaNhanVienTongDai = T2.MaNhanVienTongDai;
                T1.LenhDienThoai = T2.LenhDienThoai;
                T1.GhiChuDienThoai = T2.GhiChuDienThoai;
                T1.MaNhanVienDienThoai = T2.MaNhanVienDienThoai;
                T1.XeNhan = T2.XeNhan;
                T1.XeNhan_TD = T2.XeNhan_TD;
                T1.ThoiGianDieuXe = T2.ThoiGianDieuXe;
                T1.FileVoicePath = T2.FileVoicePath;
                T1.VungGPSID = T2.VungGPSID;
                T1.GPS_KinhDo = T2.GPS_KinhDo;
                T1.GPS_ViDo = T2.GPS_ViDo;
                T1.DanhSachXeDeCu = T2.DanhSachXeDeCu;
                T1.ThoiDiemCapNhatXeDeCu = T2.ThoiDiemCapNhatXeDeCu;
                T1.TrangThaiLenh = T2.TrangThaiLenh;
                T1.MOIKHACH_LenhMoiKhach = T2.MOIKHACH_LenhMoiKhach;
                T1.MOIKHACH_NhanVien = T2.MOIKHACH_NhanVien;
                T1.XeDenDiem = T2.XeDenDiem;
                T1.XeDenDiemDonKhach = T2.XeDenDiemDonKhach;
                T1.XeDon = T2.XeDon;
                T1.Vung = T2.Vung;
                T1.DiaChiDonKhach = T2.DiaChiDonKhach;
                T1.PhoneNumber = T2.PhoneNumber;
                //G5
                T1.BookId = T2.BookId;
                T1.LenhLaiXe = T2.LenhLaiXe;
                T1.GhiChuLaiXe = T2.GhiChuLaiXe;
                T1.G5_Type = T2.G5_Type;
                T1.G5_CarType = T2.G5_CarType;
                T1.XeDungDiem = T2.XeDungDiem;
                T1.SaleOffCode = T2.SaleOffCode;
                T1.BTBG_NoiDungXuLy = T2.BTBG_NoiDungXuLy;
                T1.G5_SendDate = T2.G5_SendDate;
                T1.G5_Step = T2.G5_Step;
                T1.G5_StepLast = T2.G5_StepLast;
                T1.KieuCuocGoi = T2.KieuCuocGoi;
                T1.KieuKhachHangGoiDen = T2.KieuKhachHangGoiDen;
            };
            #endregion
           
                this.RowCellStyle += DienThoaiGridView_RowCellStyle;
                this.RowStyle += DienThoaiGridView_RowStyle;
        }
        /// <summary>
        /// Giúp thay đổi Line Theo cho từng điều kiện
        /// </summary>
        /// <returns></returns>
        public override string GetLineVung()
        {
            if (!DieuKienGopLai(RealTimeEnvironment.TimeServer.TimeOfDay, ThongTinCauHinh.GopKenh_GioBD, ThongTinCauHinh.GopKenh_GioKT))
            {
                return RealTimeEnvironment.LineVung;
            }
            else
            {
                return RealTimeEnvironment.LineGop;
            }
        }
        /// <summary>
        /// Điều kiện gôp line
        /// </summary>
        /// <param name="now"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool DieuKienGopLai(TimeSpan now, TimeSpan start, TimeSpan end)
        {
            if (!Config_Common.GopLine || string.IsNullOrEmpty(RealTimeEnvironment.LineGop)) return false;
            if (start <= end) //Nếu thời điểm bắt đầu lớn hơn kết thúc ví dụ: BD-05:00:00 và KT-23:00:00
                return ThongTinCauHinh.GopKenh_TrangThai && start <= now && now <= end;
            return ThongTinCauHinh.GopKenh_TrangThai && !(start > now && now > end); // Ngược lại ví dụ: BD-23:00:00 và KT-05:00:00 thì không lấy thời điểm từ KT-BD tức là Khoảng (05:00:00-23:00:00) là không lấy
        }

        #region === Style ===
        public event GridStyle GridStyles;
        private void OnGridStyle(AppearanceObject appearance, string FieldName, int RowIndex, bool IsRow = false)
        {
            try
            {
                if (GridStyles != null)
                {
                    GridStyles(appearance, FieldName, RowIndex, IsRow);
                }
            }
            catch (Exception ex)
            {
                ExceptionError("OnGridStyle", ex);
            }

        }
        void DienThoaiGridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (DicCommand != null)
                    {
                        var LenhDienThoai = this.GetRowCellValue(e.RowHandle, "LenhDienThoai");
                        if (LenhDienThoai != null && LenhDienThoai.ToString() != string.Empty)
                        {

                            var color = DicCommand.FirstOrDefault(p => p.Command.Equals(LenhDienThoai));
                            if (color != null && !string.IsNullOrEmpty(color.CommandColor) && (color.IsColorRow == Utils.CommandBool.True))
                            {
                                e.Appearance.BackColor = Color.FromName(color.CommandColor);
                            }
                        }
                        var LenhTongDai = this.GetRowCellValue(e.RowHandle, "LenhTongDai");
                        if (LenhTongDai != null && LenhTongDai.ToString() != null)
                        {
                            var color2 = DicCommand.FirstOrDefault(p => p.Command.Equals(LenhTongDai));
                            if (color2 != null && color2.IsColorAll == Utils.CommandBool.True && !string.IsNullOrEmpty(color2.CommandColor) && (color2.IsColorRow == Utils.CommandBool.True))
                            {
                                e.Appearance.BackColor = Color.FromName(color2.CommandColor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError("DienThoaiGridView_RowStyle", ex);
            }

            OnGridStyle(e.Appearance, string.Empty, e.RowHandle, true);
        }

        void DienThoaiGridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (DicCommand != null && e.CellValue != null && e.CellValue.ToString()!=string.Empty)
                {
                    if (e.Column.FieldName.Contains("LenhDienThoai"))
                    {

                        var color = DicCommand.FirstOrDefault(p => p.Command.Equals(e.CellValue));
                        if (color != null && !string.IsNullOrEmpty(color.CommandColor) && !(color.IsColorRow == Utils.CommandBool.True))
                        {
                            e.Appearance.BackColor = Color.FromName(color.CommandColor);
                        }
                    }
                    else if (e.Column.FieldName.Contains("LenhTongDai"))
                    {
                        var color = DicCommand.FirstOrDefault(p => p.Command.Equals(e.CellValue));
                        if (color != null && !string.IsNullOrEmpty(color.CommandColor) && !(color.IsColorRow == Utils.CommandBool.True))
                        {
                            e.Appearance.BackColor = Color.FromName(color.CommandColor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError("DienThoaiGridView_RowCellStyle", ex);
            }

            OnGridStyle(e.Appearance, e.Column.FieldName, e.RowHandle);
        }
        #endregion

        #region === Commmand ===
        public override List<G5Command> DicCommand
        {
            get
            {
                return RealTimeEnvironment.DicCommand;
            }
        }
        public override bool CheckCommand(CuocGoi data, G5Command command)
        {
            string msg = string.Empty;
            if (
                (command.RequireTaxi == Utils.CommandBool.True && data.KieuCuocGoi != Utils.KieuCuocGoi.GoiTaxi)
                || (command.RequireTaxi == Utils.CommandBool.False && data.KieuCuocGoi == Utils.KieuCuocGoi.GoiTaxi)
                || (command.RequireApp == Utils.CommandBool.True && data.G5_Type != Utils.Enum_G5_Type.DieuApp)
                || (command.RequireApp == Utils.CommandBool.False && data.G5_Type == Utils.Enum_G5_Type.DieuApp)
                || (command.RequireVehicle == Utils.CommandBool.True && string.IsNullOrEmpty(data.XeNhan))
                || (command.RequireVehicle == Utils.CommandBool.False && !string.IsNullOrEmpty(data.XeNhan))
                || (command.RequireVehicleCancel == Utils.CommandBool.False && !string.IsNullOrEmpty(data.XeDungDiem))
                || (command.RequireVehicleCancel == Utils.CommandBool.True && string.IsNullOrEmpty(data.XeDungDiem))
                || (command.CommandType != Utils.G5CommandType.NhapMoRong && !string.IsNullOrEmpty(command.ParentCommand) && ((data.G5_Type == Utils.Enum_G5_Type.DieuApp && !data.LenhLaiXe.Contains(command.ParentCommand)) || !data.LenhLaiXe.Contains(command.ParentCommand)))
                )
            {
                if (command.RequireTaxi == Utils.CommandBool.True)
                {
                    msg += "và cuốc taxi ";
                }
                else if (command.RequireTaxi == Utils.CommandBool.False)
                {
                    msg += "và cuốc không gọi taxi ";
                }
                if (command.RequireApp == Utils.CommandBool.True)
                {
                    msg += "và cuốc điều app ";
                }
                else if (command.RequireApp == Utils.CommandBool.False)
                {
                    msg += "và cuốc không điều app ";
                }
                if (command.RequireVehicle == Utils.CommandBool.True)
                {
                    msg += "và cuốc có xe nhận ";
                }
                else if (command.RequireVehicle == Utils.CommandBool.False)
                {
                    msg += "và cuốc chưa có xe nhận ";
                }
                if (command.RequireVehicleCancel == Utils.CommandBool.True)
                {
                    msg += "và cuốc có xe hủy ";
                }
                else if (command.RequireVehicleCancel == Utils.CommandBool.False)
                {
                    msg += "và cuốc chưa có xe hủy ";
                }
                if (!string.IsNullOrEmpty(command.ParentCommand))
                {
                    msg += data.G5_Type == Utils.Enum_G5_Type.DieuApp ? string.Format("và lái xe yêu cầu {0} ", command.ParentCommand) : string.Format("và tổng đài yêu cầu {0} ", command.ParentCommand);
                }
            }
            if (msg == string.Empty)
            {
                if (command.IsRequited==Utils.CommandBool.True&& System.Windows.Forms.MessageBox.Show(string.Format("{1}...\nBạn có muốn thực hiện lệnh {0} không?", command.Command,data.DiaChiDonKhach), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return false;
                return true; 
            }
            else
            {
                msg = msg.Substring(3);
                System.Windows.Forms.MessageBox.Show(string.Format("[{0}] Cuốc gọi phải là {1}",command.Command,msg),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
        }
        #endregion

       
    }
    /// <summary>
    /// Giúp đăng ký vào class GridControl.
    /// 
    /// </summary>
    public class GridInfoDienThoaiRegistrator : DevExpress.XtraGrid.Registrator.GridInfoRegistrator
    {
        public GridInfoDienThoaiRegistrator() : base() { }
        public override string ViewName { get { return "DienThoaiGridView"; } }
        public override DevExpress.XtraGrid.Views.Base.BaseView CreateView(DevExpress.XtraGrid.GridControl grid)
        {
            var view = new DienThoaiGridView();
            view.SetGrid(grid);
            return view;
        }
    }
}
