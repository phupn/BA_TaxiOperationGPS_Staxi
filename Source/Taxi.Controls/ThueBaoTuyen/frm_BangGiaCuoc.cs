using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.TuyenThueBao;
using BAMessage = Taxi.MessageBox;
namespace Taxi.Controls.ThueBaoTuyen
{
    public partial class frm_BangGiaCuoc : FormRibbon
    {
        #region Biến toàn cục
        private List<TuDien_LoaiXe> lLoaiXe;
        private List<BangGiaCuoc> lBgc;
        private BangGiaCuoc bgc;
        private DiemXuatPhat dxp;
        private DMTuyenThueBao ttb;
        private TuDien_LoaiXe td;
        private int LoaiXe;
        private DataTable dtLoaiTuyen = new DataTable();
        private DataTable dtbangCuoc = new DataTable();
        private bool isUpdate = true;
        private THUEBAO_T_ChayTuyen chaytuyen;
        private decimal isNum;
        private static int _IdKieuTuyen;
        #endregion

        #region Khai báo form
        public frm_BangGiaCuoc()
        {
            InitializeComponent();
            bgc = new BangGiaCuoc();
            lBgc = new List<BangGiaCuoc>();
            dxp = new DiemXuatPhat();
            ttb = new DMTuyenThueBao();
            chaytuyen = new THUEBAO_T_ChayTuyen();
            td = new TuDien_LoaiXe();
            lLoaiXe = new List<TuDien_LoaiXe>();
            pnTuyen2.Visible = false;
            pnTuyen1.Visible = false;
            pnTuyen3.Visible = false;

            lueDiemXuatPhat.Properties.DataSource = dxp.getListDiemXP();
            lueDiemXuatPhat.Properties.DisplayMember = "TenDiemXuatPhat";
            lueDiemXuatPhat.Properties.ValueMember = "ID";

            lueChayTuyen.Properties.DataSource = new THUEBAO_T_ChayTuyen().GetAllChayTuyen();
            lueChayTuyen.Properties.DisplayMember = "ChayTuyen";
            lueChayTuyen.Properties.ValueMember = "Id";

            lueLoaiXe.DataSource = td.GetDanhSachXe();
            lueLoaiXe.DisplayMember = "TenLoaiXe";
            lueLoaiXe.ValueMember = "LoaiXeID";
        }
        #endregion

        #region Form load
        private void frm_BangGiaCuoc_Load(object sender, EventArgs e)
        {
            lueDiemXuatPhat.EditValue = lueDiemXuatPhat.Properties.GetDataSourceValue(lueDiemXuatPhat.Properties.ValueMember, 0);
            lueChayTuyen.EditValue = lueChayTuyen.Properties.GetDataSourceValue(lueChayTuyen.Properties.ValueMember, 0);
        }
        #endregion

        #region Chọn tuyến load bảng giá
        private void lbDsTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lueChayTuyen.EditValue != null)
            {
                string idChayTuyen = "";
                idChayTuyen = lueChayTuyen.EditValue.ToString();
                if (lbDsTuyen.SelectedValue.ToString() != "System.Data.DataRowView" && lueDiemXuatPhat.EditValue != null && int.Parse(idChayTuyen) != 3 && int.Parse(idChayTuyen) != 4)
                {
                    lblTuyen.Text = lueDiemXuatPhat.GetColumnValue("TenDiemXuatPhat") + " --> " + lbDsTuyen.Text;
                    dtbangCuoc = bgc.getBangCuoc(lueDiemXuatPhat.EditValue, lbDsTuyen.SelectedValue.ToString());
                    grcBangGia.DataSource = dtbangCuoc;
                    grcBangGia.Update();
                    grvBangGia.FocusedRowHandle = -2147483647;
                    pnTuyen1.Visible = true;
                    pnTuyen2.Visible = false;
                    pnTuyen3.Visible = false;

                    lLoaiXe = new TuDien_LoaiXe().GetListAll();
                    lBgc = new BangGiaCuoc().GetInfoBangCuoc(lueDiemXuatPhat.EditValue, lbDsTuyen.SelectedValue.ToString());
                }
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lueDiemXuatPhat control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  04/09/2014   created
        /// </Modified>
        private void lueDiemXuatPhat_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDiemXuatPhat.EditValue != null)
            {
                lbDsTuyen_SelectedIndexChanged(null, null);
            }
        }
        #endregion

        #region Thêm, sửa lưới *sign
        private void grvBangGia_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            #region Validate
            //GiaTien1Chieu
            if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien1Chieu").ToString().Equals(""))
            {                               
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập giá tiền 1 chiều");
                e.Valid = false;
                grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[1];
                return;
            }
            if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien1Chieu").ToString().Contains('.'))
            {
                new MessageBox.MessageBoxBA().Show("Giá tiền phải là số");
                e.Valid = false;
                grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[1];
                return;
            }
            if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien1Chieu").ToString()) < 0)
            {
                new MessageBox.MessageBoxBA().Show("Giá tiền không âm");
                e.Valid = false;
                grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[1];
                return;
            }

            //KmQuyDinh1Chieu
            if (grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh1Chieu").ToString().Equals(""))
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập km quy định 1 chiều");
                e.Valid = false;
                grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[2];
                return;
            }
            if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh1Chieu").ToString()) < 0)
            {
                new MessageBox.MessageBoxBA().Show("Km không nhỏ hơn 0");
                e.Valid = false;
                grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[2];
                return;
            }

            // ThoiGianQuyDinh1Chieu
            if (grvBangGia.GetRowCellValue(e.RowHandle, "ThoiGianQuyDinh1Chieu").ToString().Equals(""))
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thời gian quy định 1 chiều");
                e.Valid = false;
                grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[3];
                return;
            }
            if (float.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "ThoiGianQuyDinh1Chieu").ToString()) < 0)
            {
                new MessageBox.MessageBoxBA().Show("Thời gian không nhỏ hơn 0");
                e.Valid = false;
                grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[3];
                return;
            }
            //GiaTien2Chieu
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien2Chieu").ToString().Equals(""))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá tiền 2 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[4];
            //    return;
            //}
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien2Chieu").ToString().Contains('.'))
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền phải là số");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[4];
            //    return;
            //}
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien2Chieu").ToString()) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền không âm");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[4];
            //    return;
            //}
                //KmQuyDinh2Chieu
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh2Chieu").ToString().Equals(""))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập km quy định 2 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[5];
            //    return;
            //}
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh2Chieu").ToString()) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Km không được nhỏ hơn 0");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[5];
            //    return;
            //}

                //ThoiGianQuyDinh2Chieu
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "ThoiGianQuyDinh2Chieu").ToString().Equals(""))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập thời gian quy định 2 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[6];
            //    return;
            //}
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh2Chieu").ToString()) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Thời gian không nhỏ hơn 0");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[6];
            //    return;
            //}

            #region Không lấy giá định mức vượt số KM và thời gian trong bảng giá cước với BaSao
            //GiaDinhMucVuot1KmMotChieu
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmMotChieu").ToString().Equals(""))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị định mức vượt 1 giờ 1 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[7];
            //    return;
            //}
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmMotChieu").ToString().Contains('.'))
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền phải là số");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[7];
            //    return;
            //}
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmMotChieu").ToString()) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền không âm");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[7];
            //    return;
            //}
            ////GiaDinhMucVuot1GioMotChieu
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioMotChieu").ToString().Equals(""))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị định mức vượt 1 giờ 1 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[8];
            //    return;
            //}
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioMotChieu").ToString().Contains('.'))
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền phải là số");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[8];
            //    return;
            //}
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioMotChieu").ToString()) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền không âm");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[8];
            //    return;
            //}
            ////GiaDinhMucVuot1KmHaiChieu
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmHaiChieu").ToString().Equals(""))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị định mức vượt 1 km 2 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[9];
            //    return;
            //}
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmHaiChieu").ToString().Contains('.'))
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền phải là số");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[9];
            //    return;
            //}
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmHaiChieu").ToString()) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền không âm");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[9];
            //    return;
            //}
            ////GiaDinhMucVuot1GioHaiChieu
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioHaiChieu").ToString().Equals(""))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập giá trị định mức vượt 1 giờ 2 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[10];
            //    return;
            //}
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioHaiChieu").ToString().Contains('.'))
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền phải là số");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[10];
            //    return;
            //}
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioHaiChieu").ToString()) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền không âm");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[10];
            //    return;
            //}
            ////vetram
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "VeTram").ToString().Equals(""))
            //{
            //    new MessageBox.MessageBox().Show("Bạn phải nhập vé trạm");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[11];
            //    return;
            //}
            //if (grvBangGia.GetRowCellValue(e.RowHandle, "VeTram").ToString().Contains('.'))
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền phải là số");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[11];
            //    return;
            //}
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "VeTram").ToString()) < 0)
            //{
            //    new MessageBox.MessageBox().Show("Giá tiền không âm");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[11];
            //    return;
            //}
            #endregion

            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien1Chieu").ToString()) > int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien2Chieu").ToString()))
            //{
            //    new MessageBox.MessageBox().Show("Tiền 1 chiều phải nhỏ hơn Tiền 2 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[1];
            //    return;
            //}
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh1Chieu").ToString()) > int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh2Chieu").ToString()))
            //{
            //    new MessageBox.MessageBox().Show("Km 1 chiều phải nhỏ hơn Km 2 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[2];
            //    return;
            //}
            
            //if (int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "ThoiGianQuyDinh1Chieu").ToString()) > int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "ThoiGianQuyDinh2Chieu").ToString()))
            //{
            //    new MessageBox.MessageBox().Show("Thời gian 1 chiều phải nhỏ hơn Thời gian 2 chiều");
            //    e.Valid = false;
            //    grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[3];
            //    return;
            //}
            #endregion

            try
            {
                if (e.RowHandle < 0)
                {
                    if (LoaiXe == 0)
                    {
                        new MessageBox.MessageBoxBA().Show("Bạn chưa chọn loại xe");
                        e.Valid = false;
                        grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[0];
                        return;
                    }
                    int them = bgc.InsertBangGiaCuoc(
                        lbDsTuyen.SelectedValue.ToString(),
                        lueDiemXuatPhat.EditValue,
                        LoaiXe,
                        grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh1Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "ThoiGianQuyDinh1Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien1Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh2Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "ThoiGianQuyDinh2Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien2Chieu").ToString(),
                        "0", //grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmMotChieu").ToString(),
                        "0", //grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioMotChieu").ToString(),
                        "0", //grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmHaiChieu").ToString(),
                        "0", //grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioHaiChieu").ToString(),
                        "0");//grvBangGia.GetRowCellValue(e.RowHandle, "VeTram").ToString());
                    if (them > 0)
                    {
                        new MessageBox.MessageBoxBA().Show("Thêm mới thành công");
                        dtbangCuoc = bgc.getBangCuoc(lueDiemXuatPhat.EditValue, lbDsTuyen.SelectedValue.ToString());
                        grcBangGia.DataSource = dtbangCuoc;
                        grcBangGia.Update();
                        LoaiXe = 0;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Loại xe không phù hợp hoặc đã tồn tại bảng giá.", "Thông báo");
                        e.Valid = false;
                        grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[0];                        
                    }
                }
                else
                {
                    if (LoaiXe != 0)
                    {
                        //LoaiXe = int.Parse(grvBangGia.GetRowCellValue(e.RowHandle, "FK_LoaiXeID").ToString());
                        new MessageBox.MessageBoxBA().Show("Bạn không được sửa loại xe", "Thông báo");
                        dtbangCuoc = bgc.getBangCuoc(lueDiemXuatPhat.EditValue, lbDsTuyen.SelectedValue.ToString());
                        grcBangGia.DataSource = dtbangCuoc;
                        grcBangGia.Update();
                        return;
                    }
                    int capnhat = bgc.UpdateBangGiaCuoc(
                        grvBangGia.GetRowCellValue(e.RowHandle, "ID").ToString(),
                        lbDsTuyen.SelectedValue.ToString(),
                        lueDiemXuatPhat.EditValue,
                        grvBangGia.GetRowCellValue(e.RowHandle, "FK_LoaiXeID").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh1Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "ThoiGianQuyDinh1Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien1Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "KmQuyDinh2Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "ThoiGianQuyDinh2Chieu").ToString(),
                        grvBangGia.GetRowCellValue(e.RowHandle, "GiaTien2Chieu").ToString(),
                        "0", //grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmMotChieu").ToString(),
                        "0", //grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioMotChieu").ToString(),
                        "0", //grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1KmHaiChieu").ToString(),
                        "0", //grvBangGia.GetRowCellValue(e.RowHandle, "GiaDinhMucVuot1GioHaiChieu").ToString(),
                        "0");//grvBangGia.GetRowCellValue(e.RowHandle, "VeTram").ToString());
                    if (capnhat > 0)
                    {
                        new MessageBox.MessageBoxBA().Show("Cập nhật thành công");
                        dtbangCuoc = bgc.getBangCuoc(lueDiemXuatPhat.EditValue, lbDsTuyen.SelectedValue.ToString());
                        grcBangGia.DataSource = dtbangCuoc;
                        grcBangGia.Update();
                        LoaiXe = 0;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Loại xe bị trùng. Bạn kiểm tra lại");
                        dtbangCuoc = bgc.getBangCuoc(lueDiemXuatPhat.EditValue, lbDsTuyen.SelectedValue.ToString());
                        grcBangGia.DataSource = dtbangCuoc;
                        grcBangGia.Update();
                    }
                }

            }
            catch 
            {
                new MessageBox.MessageBoxBA().Show("Loại xe không phù hợp hoặc đã tồn tại bảng giá.");
                //dtbangCuoc = bgc.getBangCuoc(lueDiemXuatPhat.EditValue, lbDsTuyen.SelectedValue.ToString());
                e.Valid = false;
                grvBangGia.FocusedColumn = grvBangGia.VisibleColumns[0];                
            }
            
        }
        #endregion

        #region Lấy loại xe id
        private void lueLoaiXe_EditValueChanged(object sender, EventArgs e)
        {
            LoaiXe = 0;
            object value = (sender as LookUpEdit).EditValue;
            LoaiXe = int.Parse(value.ToString());
        }
        #endregion

        #region Xóa
        private void grcBangGia_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (LoaiXe == 0)
                    {
                        if (new MessageBox.MessageBoxBA().Show("Bạn có thực sự muốn xóa?", "Xác nhận", MessageBox.MessageBoxButtonsBA.YesNo, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                        {
                            int dtXoa = bgc.DeleteBangGiaCuoc(int.Parse(grvBangGia.GetRowCellValue(grvBangGia.FocusedRowHandle, "ID").ToString()));
                            if (dtXoa > 0)
                            {
                                new MessageBox.MessageBoxBA().Show("Xóa thành công");
                                dtbangCuoc = bgc.getBangCuoc(lueDiemXuatPhat.EditValue, lbDsTuyen.SelectedValue.ToString());
                                grcBangGia.DataSource = dtbangCuoc;
                                grcBangGia.Update();
                            }
                        }
                        else
                            e.Handled = true;
                    }
                    LoaiXe = 0;
                }
            }
            catch 
            {
                new MessageBox.MessageBoxBA().Show("Bạn không thế xóa dòng này");                
            }
        }
        #endregion

        private void lueChayTuyen_EditValueChanged(object sender, EventArgs e)
        {
            lblHelp_Xoa.Visible = true;
            lbDsTuyen.DataSource = bgc.GetTuyenByChayTuyen(lueChayTuyen.EditValue);
            lbDsTuyen.DisplayMember = "TenTuyenDuong";
            lbDsTuyen.ValueMember = "TuyenDuongID";
            if (lbDsTuyen.Items.Count < 1)
            {
                pnTuyen1.Visible = false;
            }
            else
            {
                lbDsTuyen_SelectedIndexChanged(null, null);
            }

            string idChayTuyen = "";
            idChayTuyen = lueChayTuyen.EditValue.ToString();


            if (int.Parse(idChayTuyen) == 3)
            {
                pnTuyen1.Visible = false;
                pnTuyen2.Visible = true;
                pnTuyen3.Visible = false;
                lblHelp_Xoa.Visible = false;

                lblTuyen1.Visible = false;
                lblTuyen.Visible = false;
                lbDsTuyen.Visible = false;
                lblDsTuyen.Visible = false;
            }
            else if (int.Parse(idChayTuyen) == 4)
            {
                pnTuyen1.Visible = false;
                pnTuyen2.Visible = false;
                pnTuyen3.Visible = true;
                lblHelp_Xoa.Visible = false;

                lblTuyen1.Visible = false;
                lblTuyen.Visible = false;
                lbDsTuyen.Visible = false;
                lblDsTuyen.Visible = false;
            }
            else
            {
                lblTuyen1.Visible = true;
                lblTuyen.Visible = true;
                lbDsTuyen.Visible = true;
                lblDsTuyen.Visible = true;
                pnTuyen2.Visible = false;
                pnTuyen3.Visible = false;
                lblHelp_Xoa.Visible = true;
            }
        }

        private void grvBangGia_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void frm_BangGiaCuoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void grvBangGia_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            new MessageBox.MessageBoxBA().Show("Bạn phải nhập giá trị số", "Thông báo");
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvBangGia_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Processes the command key.
        /// enter to focus next control
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="keyData">The key data.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  04/09/2014   created
        /// </Modified>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
