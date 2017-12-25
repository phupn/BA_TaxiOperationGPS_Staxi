using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.TuyenThueBao;

namespace Taxi.Controls.ThueBaoTuyen
{
    public partial class frm_VuotGioQuyDinh : FormRibbon
    {
        #region Khai báo và khởi tạo
        private VuotGioQuyDinh vgqd;
        private int LoaiXe;
        private float isNum=0f;
        public frm_VuotGioQuyDinh()
        {
            InitializeComponent();
            TuDien_LoaiXe td = new TuDien_LoaiXe();
            lueXe.DataSource = td.GetDanhSachXe();
            lueXe.DisplayMember = "TenLoaiXe";
            lueXe.ValueMember = "LoaiXeID";
            vgqd = new VuotGioQuyDinh();
        }
        #endregion

        private void LoadData()
        {
            grcDinhMuc.DataSource = vgqd.getAllVuotGio();
            grvDinhMuc.FocusedRowHandle = -2147483647;
        }

        private void frm_VuotGioQuyDinh_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Thêm sửa trên lưới
        private void grvDinhMuc_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool bVali = true;
            #region gan gia tri
            string GiaDinhMucVuot1GioMotChieu = grvDinhMuc.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioMotChieu").ToString();
            string GiaDinhMucVuot1KmMotChieu = grvDinhMuc.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmMotChieu").ToString();
            string GiaDinhMucVuot1GioHaiChieu = grvDinhMuc.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioHaiChieu").ToString();
            string GiaDinhMucVuot1KmHaiChieu = grvDinhMuc.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmHaiChieu").ToString();
            string TienLuuNgay = grvDinhMuc.GetRowCellValue(e.RowHandle, "TienLuuNgay").ToString();
            string TienLuuDem = grvDinhMuc.GetRowCellValue(e.RowHandle, "TienLuuDem").ToString();
            string TienBuXangDiChuyenXa = grvDinhMuc.GetRowCellValue(e.RowHandle, "TienBuXangDiChuyenXa").ToString();
            string TienBuXangVuotKm = grvDinhMuc.GetRowCellValue(e.RowHandle, "TienBuXangVuotKm").ToString();
            string TienBuXangTruotHang = grvDinhMuc.GetRowCellValue(e.RowHandle, "TienBuXangTruotHang").ToString();
            #endregion

            #region validate
            //if (GiaDinhMucVuot1GioMotChieu == "")
            //{
            //    new MessageBox.MessageBox().Show("Bạn chưa nhập giá trị định mức 1 giờ 1 chiều");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[1];
            //    return;
            //}
            
            //if (!float.TryParse(GiaDinhMucVuot1GioMotChieu, out isNum))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị là số");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[1];
            //    return;
            //}
            //if (float.Parse(GiaDinhMucVuot1GioMotChieu) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá trị không được âm");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[1];
            //    return;
            //}
            if (GiaDinhMucVuot1KmMotChieu == "")
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa nhập giá trị định mức 1 km 1 chiều");
                bVali = false;
                e.Valid = false;
                grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[2];
                return;
            }

            if (!float.TryParse(GiaDinhMucVuot1KmMotChieu, out isNum))
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập giá trị là số");
                bVali = false;
                e.Valid = false;
                grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[2];
                return;
            }
            if (float.Parse(GiaDinhMucVuot1KmMotChieu) < 0)
            {
                new MessageBox.MessageBoxBA().Show("Giá trị không được âm");
                bVali = false;
                e.Valid = false;
                grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[2];
                return;
            }
            if (GiaDinhMucVuot1GioHaiChieu == "")
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa nhập giá trị định mức 1 giờ 2 chiều");
                bVali = false;
                e.Valid = false;
                grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[3];
                return;
            }

            if (!float.TryParse(GiaDinhMucVuot1GioHaiChieu, out isNum))
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập giá trị là số");
                bVali = false;
                e.Valid = false;
                grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[3];
                return;
            }
            if (float.Parse(GiaDinhMucVuot1GioHaiChieu) < 0)
            {
                new MessageBox.MessageBoxBA().Show("Giá trị không được âm");
                bVali = false;
                e.Valid = false;
                grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[3];
                return;
            }
            if (GiaDinhMucVuot1KmHaiChieu == "")
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa nhập giá trị định mức 1 km 2 chiều");
                bVali = false;
                e.Valid = false;
                grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[4];
                return;
            }

            if (!float.TryParse(GiaDinhMucVuot1KmHaiChieu, out isNum))
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập giá trị là số");
                bVali = false;
                e.Valid = false;
                grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[4];
                return;
            }
            if (float.Parse(GiaDinhMucVuot1KmHaiChieu) < 0)
            {
                new MessageBox.MessageBoxBA().Show("Giá trị không được âm");
                bVali = false;
                e.Valid = false;
                grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[4];
                return;
            }
            //if (TienLuuNgay == "")
            //{
            //    new MessageBox.MessageBox().Show("Bạn chưa nhập giá tiền lưu ngày");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[5];
            //    return;
            //}
            //if (!float.TryParse(TienLuuNgay, out isNum))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị là số");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[5];
            //    return;
            //}
            //if (float.Parse(TienLuuNgay) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá trị tiền không được âm");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[5];
            //    return;
            //}

            //if (TienLuuDem == "")
            //{
            //    new MessageBox.MessageBox().Show("Bạn chưa nhập giá tiền lưu đêm");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[6];
            //    return;
            //}
            //if (!float.TryParse(TienLuuDem, out isNum))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị là số");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[6];
            //    return;
            //}
            //if (float.Parse(TienLuuDem) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá trị tiền không được âm");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[6];
            //    return;
            //}

            //if (TienBuXangDiChuyenXa == "")
            //{
            //    new MessageBox.MessageBox().Show("Bạn chưa nhập giá tiền bù xăng di chuyển xa");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[7];
            //    return;
            //}
            //if (!float.TryParse(TienBuXangDiChuyenXa, out isNum))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị là số");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[7];
            //    return;
            //}
            //if (float.Parse(TienBuXangDiChuyenXa) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá trị tiền không được âm");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[7];
            //    return;
            //}

            //if (TienBuXangVuotKm == "")
            //{
            //    new MessageBox.MessageBox().Show("Bạn chưa nhập giá tiền bù xăng vượt km");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[8];
            //    return;
            //}
            //if (!float.TryParse(TienBuXangVuotKm, out isNum))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị là số");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[8];
            //    return;
            //}
            //if (float.Parse(TienBuXangVuotKm) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá trị tiền không được âm");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[8];
            //    return;
            //}
            //if (TienBuXangTruotHang == "")
            //{
            //    new MessageBox.MessageBox().Show("Bạn chưa nhập giá tiền bù xăng trượt hàng");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[9];
            //    return;
            //}
            //if (!float.TryParse(TienBuXangTruotHang, out isNum))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị là số");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[9];
            //    return;
            //}
            //if (float.Parse(TienBuXangTruotHang) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá trị tiền không được âm");
            //    bVali = false;
            //    e.Valid = false;
            //    grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[9];
            //    return;
            //}
            #endregion

            if (bVali)
            {
                try
                {
                    if (e.RowHandle < 0)
                    {
                        if (LoaiXe == 0)
                        {
                            new MessageBox.MessageBoxBA().Show("Bạn chưa chọn loại xe");
                            e.Valid = false;
                            grvDinhMuc.FocusedColumn = grvDinhMuc.VisibleColumns[0];
                            return;
                        }
                        int dtInsert = vgqd.InsertVuotGio(LoaiXe,
                            GiaDinhMucVuot1KmMotChieu,
                            GiaDinhMucVuot1GioMotChieu,
                            GiaDinhMucVuot1KmHaiChieu,
                            GiaDinhMucVuot1GioHaiChieu,
                            TienLuuNgay,
                            TienLuuDem,
                            TienBuXangDiChuyenXa,
                            TienBuXangVuotKm,
                            TienBuXangTruotHang);
                        if (dtInsert > 0)
                        {
                            new MessageBox.MessageBoxBA().Show("Thêm mới thành công");
                            LoadData();
                            grcDinhMuc.Update();
                            LoaiXe = 0;
                        }
                    }
                    else
                    {
                        try
                        {
                            int dtUpdate = vgqd.UpdateVuotGio(grvDinhMuc.GetRowCellValue(e.RowHandle, "FK_LoaiXeID").ToString(),
                            GiaDinhMucVuot1KmMotChieu,
                            GiaDinhMucVuot1GioMotChieu,
                            GiaDinhMucVuot1KmHaiChieu,
                            GiaDinhMucVuot1GioHaiChieu,
                            TienLuuNgay,
                            TienLuuDem,
                            TienBuXangDiChuyenXa,
                            TienBuXangVuotKm,
                            TienBuXangTruotHang);
                            if (dtUpdate > 0)
                            {
                                new MessageBox.MessageBoxBA().Show("Cập nhật thành công");
                                LoadData();
                                grcDinhMuc.Update();
                                LoaiXe = 0;
                            }
                            else
                            {
                                new MessageBox.MessageBoxBA().Show("Không thể sửa loại xe!");
                                LoadData();
                            }
                        }
                        catch 
                        {
                            new MessageBox.MessageBoxBA().Show("lỗi!");
                            LoadData();
                        }

                    }
                }
                catch
                {
                    e.Valid = false;
                }
            }

        }


        private void grvDinhMuc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion

        #region Lấy value của lookupEdit
        private void lueXe_EditValueChanged(object sender, EventArgs e)
        {
            LoaiXe = 0;
            object value = (sender as LookUpEdit).EditValue;
            LoaiXe = int.Parse(value.ToString());
        }
        #endregion

        #region Xử lý xóa bằng phím tắt và menu xóa
        private void grcDinhMuc_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (grvDinhMuc.FocusedRowHandle > 0)
            {
                try
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        if (new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn có thực sự muốn xóa?", "Xác nhận", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                        {
                            int dtXoa = vgqd.DeleteVuotGio(int.Parse(grvDinhMuc.GetRowCellValue(grvDinhMuc.FocusedRowHandle, "FK_LoaiXeID").ToString()));

                            if (dtXoa > 0)
                            {
                                new Taxi.MessageBox.MessageBoxBA().Show("Xóa thành công");
                                LoadData();
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Bạn không thế xóa dòng này");
                    return;
                }
            }
        }

        private void grvDinhMuc_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    grvDinhMuc.FocusedRowHandle = e.RowHandle;
                    ctmtXoa.Show(PointToScreen(e.Location));
                    break;
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            if (grvDinhMuc.FocusedRowHandle > 0)
            {
                if (new Taxi.MessageBox.MessageBoxBA().Show("Bạn có thực sự muốn xóa?", "Xác nhận", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    int dtXoa = vgqd.DeleteVuotGio(int.Parse(grvDinhMuc.GetRowCellValue(grvDinhMuc.FocusedRowHandle, "FK_LoaiXeID").ToString()));

                    if (dtXoa > 0)
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Xóa thành công");
                        LoadData();
                    }

                }
            }
        }
        #endregion

        #region Validate
        private bool IsValid(string GiaDinhMucVuot1GioMotChieu, string GiaDinhMucVuot1KmMotChieu, string GiaDinhMucVuot1GioHaiChieu, string GiaDinhMucVuot1KmHaiChieu)
        {
            
            return true;
        }
        #endregion

        private void grvDinhMuc_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void frm_VuotGioQuyDinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void grvDinhMuc_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            new MessageBox.MessageBoxBA().Show("Bạn phải nhập giá trị số","Thông báo");
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
    }
}
