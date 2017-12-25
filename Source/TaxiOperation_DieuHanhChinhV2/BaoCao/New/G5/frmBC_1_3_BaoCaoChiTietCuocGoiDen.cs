using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using Taxi.GUI;
using Taxi.Services;
using Taxi.Utils;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "Báo cáo chi tiết cuộc gọi đến")]
    public partial class frmBC_1_3_BaoCaoChiTietCuocGoiDen : FrmReportBase
    {
        #region Properties
        public string KieuCuocGoi { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string ID_DTTD { get; set; }
        public string ID_CS { get; set; }
        public string Line { get; set; }
        public string Vung { get; set; }
        public string NhacMaySau { get; set; }
        public string XeNhan { get; set; }
        public string XeDon { get; set; }
        public TimeSpan TGDamThoai { get; set; }
        public TimeSpan TGChuyenDam { get; set; }
        public int KetQua { get; set; }
        public int CachDieu { get; set; }
        public int LoaiKH { get; set; }
        public string LoaiXe { get; set; }
        public string LenhDienThoai { get; set; }
        public string MaDoiTac { get; set; }
        
        #endregion

        #region Khởi tạo và khai báo
        private string _fileVoicePath;
        private bool _checkChange = false;
        private bool _isPlay = false;
        private fmProgress _frmProgress;
        private DataTable _dataTable;
        public frmBC_1_3_BaoCaoChiTietCuocGoiDen()
        {
            InitializeComponent();
            if (!Config_Common.NhapTuyenDuongDai)
            {
                HideAllLongColumns();
            }
        }
        #endregion

        #region Events!
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Config_Common.NhapTuyenDuongDai)
            {
                rgDuongDai.Visible = true;
            }
            if (ThongTinDangNhap.HasPermission(DanhSachQuyen.BaoCao_1_2_XoaCuocGoi))
            {
                mnuXoaCuoc.Visible = true;
            }
            else
            {
                mnuXoaCuoc.Visible = false;
            }
        }
        private void lsLoaiCuocGoi_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                _fileVoicePath = null;
                TrackBarFileVoicePath.Value = 0;
                btnStop.PerformClick();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridView1_FocusedRowChanged: ", ex);
            }
        }
        private void lsLoaiCuocGoi_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (_checkChange) return; _checkChange = true;
            if (e.Index == 0)
            {
                if (e.State == CheckState.Checked)
                {
                    for (int i = 1; i < lsLoaiCuocGoi.Items.Count; i++)
                    {
                        lsLoaiCuocGoi.Items[i].CheckState = CheckState.Unchecked;
                    }
                }
            }
            else
            {
                if (e.State ==CheckState.Checked)
                {
                    lsLoaiCuocGoi.Items[0].CheckState = CheckState.Unchecked;
                }
            }
            _checkChange = false;

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                string _line = string.Empty;
                string filenameVoice;
                bool isPlay = false;
                if (string.IsNullOrEmpty(_fileVoicePath))
                {
                    var dr = gridView1.GetFocusedDataRow();
                    if (dr != null && dr.Table.Columns.Contains("FileVoicePath"))
                    {
                        isPlay = true;
                        _fileVoicePath = dr["FileVoicePath"].ToString();
                        _line = dr["Line"].ToString();
                    }
                }
                if (string.IsNullOrEmpty(_fileVoicePath))
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Không tìm thấy tệp ghi âm");
                    return;
                }
                btnPause.Enabled = true;
                btnStop.Enabled = true;
                btnPlay.Enabled = false;
                if (!string.IsNullOrEmpty(_line) && !DieuHanhTaxi.IsPBXIP(_line)) // binh thuong nhu cu
                {
                    filenameVoice = NgheLaiCuocGoi.GetFileNameCuocDi(_fileVoicePath);
                }
                else
                {
                    filenameVoice = Config_Common.PBXIPVoicePath + "\\" + _fileVoicePath;
                }
                //filenameVoice = @"C:\Users\haunv.HN-BINHANH\AppData\Roaming\Skype\My Skype Received Files\03--A-0313741098---20141028153714.wav";
                //if (player_Play.FileName == "")
                //    isPlay = true;
                if (filenameVoice.Length > 0)
                {
                    if (isPlay)
                    {
                        player_Play.FileName = filenameVoice;
                        if (player_Play.FileName != "")
                        {
                            player_Play.Play();
                            lblAudio.Text = player_Play.FileName;
                            btnPause.Text = "Pause";
                            this.timer1.Enabled = true;
                        }
                        else
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(@"File không tồn tại.Bạn cần kiểm tra lại đường dẫn tới thư mục lưu file âm thanh.Thư mục này phải được lưu cùng với thư mục của hệ thống bắt số.Ví dụ : \\\maychu\GhiAm. Hoặc bạn có thể tìm ở file gốc.");
                        }
                    }
                    else
                    {
                        if (player_Play.Status == "stopped")
                        {
                            int pos = (TrackBarFileVoicePath.Value * player_Play.DurationInMS) / this.TrackBarFileVoicePath.Properties.Maximum;
                            player_Play.Play();
                            player_Play.ChangePosition(pos);
                        }
                        else
                            player_Play.Resume();
                        this.timer1.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnPlay_Click: ", ex);                
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fileVoicePath))
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Không tìm thấy tệp ghi âm");
                return;
            }
            timer1.Enabled = false;
            btnPlay.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = true;
            player_Play.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnPlay.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            _fileVoicePath = null;
            player_Play.Stop();
            player_Play.FileName = string.Empty;
            lblAudio.Text = string.Empty;
        }
        private void TrackBarFileVoicePath_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPlay) return;
            int pos = (TrackBarFileVoicePath.Value * player_Play.DurationInMS) / this.TrackBarFileVoicePath.Properties.Maximum;
            player_Play.ChangePosition(pos);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            _isPlay = true;
            int pos = (player_Play.PositionInMS * this.TrackBarFileVoicePath.Properties.Maximum) / player_Play.DurationInMS;
            this.TrackBarFileVoicePath.Value = pos;

            if (player_Play.Status == "stopped")
            {
                btnStop.PerformClick();
                this.TrackBarFileVoicePath.Value = 0;
            }
            _isPlay = false;
        }
        private void frmBC_1_3_BaoCaoChiTietCuocGoiDen_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnStop.PerformClick();
        }
        private void mnuXoaCuoc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn có muốn xóa những cuốc gọi đang chọn không.\nLưu ý:Đã xóa những cuốc gọi này sẽ không khôi phục lại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo).ToLower() == "Yes".ToLower())
                {
                    string idDelete = "";
                    List<Guid> lstGuid = new List<Guid>();
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        DataRow r = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                        idDelete += "," + r["ID"];
                        lstGuid.Add(Guid.Parse(r["BookID"].ToString()));
                    }
                    try
                    {

                        idDelete = idDelete.Trim(',');
                        if (idDelete.Length == 0) return;
                        if (!bc_1_3_BaoCaoChiTietCuocGoiDen.DeleteMultilCuocGoi(idDelete))
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show("Bạn chỉ được xóa cuốc hoa hồng loại sảnh.", "Thông báo");
                        }
                        else
                        {
                            WCFServicesApp.SendDeleteBook(lstGuid.ToArray(), ThongTinDangNhap.USER_ID);

                            btnTim.Enabled = true;
                            btnTim.PerformClick();
                        }
                    }
                    catch (Exception ex)
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Lỗi" + ex.Message);
                    }
                }
            }
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var dr = gridView1.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                HienThiAnhTrangThai_MauChu(dr, false, e.RowHandle, e.Column.FieldName, e.CellValue, e.Appearance);
            }
        }
        private void mnuLayFileGhiAm_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                // lấy file ghi âm.  lấy đường dẫn 
                string filenameDB = "";
                string filenameVoice = "";
                var objItem = gridView1.GetFocusedRow() as BaoCaoBieuMau3;
                filenameDB = objItem.FileVoicePath;
                // neu len(line) >=3 thi la PBXIP 
                // nguoc lai thi la binh thuong tansonic
                if (!DieuHanhTaxi.IsPBXIP(objItem.Line)) // binh thuong nhu cu
                {
                    filenameVoice = NgheLaiCuocGoi.GetFileNameCuocDi(filenameDB);
                }
                else
                {
                    filenameVoice = Config_Common.PBXIPVoicePath + "\\" + filenameDB;
                }

                //TEST
                //filenameVoice = @"\\192.168.1.8\Share Data\PPM\Congnt\Taxi.Data.dll"; 
                // Lưu vào
                if (filenameVoice.Length > 0)
                {
                    // check file tồn tại
                    if (File.Exists(filenameVoice))
                    {
                        // bật cửa sổ lưu file
                        string soDienThoai = objItem.PhoneNumber;

                        FileInfo fi = new FileInfo(filenameVoice);
                        SaveFileDialog sv = new SaveFileDialog();


                        sv.FileName = string.Format("{0}_{1}", soDienThoai, fi.Name);
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(filenameVoice, sv.FileName);
                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Lưu file thành công", "Thông báo");
                        }
                    }
                }
            }
        }
        #endregion

        #region Methods
        private void HideAllLongColumns()
        {
            colTuyenDuong.Visible = false;
            colChieu.Visible = false;
            colHangXe.Visible = false;
            colGia.Visible = false;
            colKm.Visible = false;
            colThoiGian.Visible = false;
        }
        protected override void AfterFind()
        {
            Thread.Sleep(10);
            this.Activate();
            this.MinimizeBox = false;
        }

        /// <summary>
        /// Hàm thực hiện hiển thị dữ liệu báo cáo trong hệ thống!
        /// </summary>        
        protected override object GetData()
        {
            //Dùng backgroundworker để chia nhỏ dữ liệu lấy lên!
            BackgroundWorker bwWorker = new BackgroundWorker();
            bwWorker.DoWork += bwWorker_DoWork;
            bwWorker.RunWorkerCompleted += bwWorker_Completed;
            _frmProgress = new fmProgress();
            bwWorker.RunWorkerAsync();            
            try
            {
                _frmProgress.ShowDialog(this);
                _frmProgress = null;
                this.Activate();
                this.MinimizeBox = false;
            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(ex.ToString(), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }

            return _dataTable;
        }

        private void bwWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_frmProgress != null)
            {
                _frmProgress.Hide();
                _frmProgress = null;                
            }

            if (e.Error != null)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
            }
        }

        
        private  void bwWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (_frmProgress.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (Config_Common.NhapTuyenDuongDai)
                    _dataTable = bc_1_3_BaoCaoChiTietCuocGoiDen.GetReportLongTrip(FromDate.Value, ToDate.Value, KieuCuocGoi, SoDienThoai, DiaChi, ID_DTTD, ID_CS, Line, Vung, NhacMaySau, XeNhan, XeDon, TGDamThoai, TGChuyenDam, KetQua, CachDieu, LoaiKH, LoaiXe, LenhDienThoai, MaDoiTac, rgDuongDai.EditValue.ToString(), chkCuocChen.Checked);
                else
                    _dataTable = bc_1_3_BaoCaoChiTietCuocGoiDen.GetReport(FromDate.Value, ToDate.Value, KieuCuocGoi, SoDienThoai, DiaChi, ID_DTTD, ID_CS, Line, Vung, NhacMaySau, XeNhan, XeDon, TGDamThoai, TGChuyenDam, KetQua, CachDieu, LoaiKH, LoaiXe, LenhDienThoai, MaDoiTac, chkCuocChen.Checked);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("bwWorker_DoWork: ",ex);
            }
        }
        protected override void AfterLoad()
        {
            var listXe = CommonBL.ListStaxiLoaiXe;
            if (license.IsThanhCong)
            {
                listXe.Add(new Taxi.Data.FastTaxi.StaxiCarType { Name="Avante" });
            }
            ipLoaiXe.Properties.DataSource = listXe;
            ipLoaiXe.EditValue = null;
            ipLoaiXe.RefreshEditValue();
            ipLoaiXe.Refresh();
        }
        private void HienThiAnhTrangThai_MauChu(DataRow cuocGoi, bool IsRow, int RowIndex, string colName, object valueCell, DevExpress.Utils.AppearanceObject style)
        {
            try
            {
                if (colName != null && colName.Equals("PhoneNumber"))
                {
                    // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                    if ((KieuKhachHangGoiDen)Convert.ToInt16(cuocGoi["KieuKhachHangGoiDen"]) == KieuKhachHangGoiDen.KhachHangMoiGioi)
                    {
                        style.BackColor = Color.Yellow;
                    }
                    else if ((KieuKhachHangGoiDen)Convert.ToInt16(cuocGoi["KieuKhachHangGoiDen"]) == KieuKhachHangGoiDen.KhachHangVIP)
                    {
                        style.BackColor = Color.Blue;
                    }
                    else if ((KieuKhachHangGoiDen)Convert.ToInt16(cuocGoi["KieuKhachHangGoiDen"]) == KieuKhachHangGoiDen.KhachHangVang
                          || (KieuKhachHangGoiDen)Convert.ToInt16(cuocGoi["KieuKhachHangGoiDen"]) == KieuKhachHangGoiDen.KhachHangBac)
                    {
                        style.BackColor = Color.ForestGreen;
                    }
                    else if ((KieuKhachHangGoiDen)Convert.ToInt16(cuocGoi["KieuKhachHangGoiDen"]) == KieuKhachHangGoiDen.KhachHangKhongHieu)
                    {
                        style.BackColor = Color.LightSalmon;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiAnhTrangThai_MauChu: ", ex);
            }
        }

        #endregion

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRowView item = (DataRowView)gridView1.GetFocusedRow();
                if (item != null)
                {
                    string maMoiGioi = item["MaDoiTac"].ToString();
                    string id = item["ID"].ToString();
                    if (!string.IsNullOrEmpty(maMoiGioi)&&KiemTraLaCuocSanh(maMoiGioi))
                    {                        
                        frmGhiChu objGhiChu = new frmGhiChu();
                        objGhiChu.ID = id;
                        objGhiChu.ShowDialog();
                        MessageBox.Show("Sửa thông tin ghi chú cuốc thành công");
                    }
                }
            }
            catch(Exception ex)
            {
                LogError.WriteLogError("gridControl_DoubleClick: ", ex);
            }
        }

        private bool KiemTraLaCuocSanh(string maMoiGioi)
        {
            return bc_1_3_BaoCaoChiTietCuocGoiDen.Inst.KiemTraLaCuocSanh(maMoiGioi);            
        }
    }
}
