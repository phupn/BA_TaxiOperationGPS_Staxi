using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DM;
using Taxi.Common.Extender;
using Taxi.Controls.Base;

namespace TaxiOperation_BanCo.DM
{
    public partial class frmLoaiXe_Truck : FormBase
    {
        #region biến toàn cục
        int g_ID = 0;
        decimal so = 0;
        #endregion

        #region khởi tạo form
        // thêm mới
        public frmLoaiXe_Truck(string title)
        {
            InitializeComponent();
            this.Text = title;
            setPhimTat();
            g_ID = -1;
        }

        // cập nhật
        public frmLoaiXe_Truck(int ID, string TenLoaiXe, string HangXe, string KichThuoc, string TaiTrongQuyDinh, string TaiTrongChoPhep,string PhimTat,string VietTat, string font,string backColor,string foreColor, string title)
        {
            InitializeComponent();
            this.Text = title;
            setPhimTat();
            g_ID = ID;
            txtTenLoaiXe.Text = TenLoaiXe;
            txtHangXe.Text = HangXe;
            txtKichThuoc.Text = KichThuoc;
            txtTaiTrongQuyDinh.Text = TaiTrongQuyDinh;
            txtTaiTrongChoPhep.Text = TaiTrongChoPhep;
            luePhimTat.EditValue = PhimTat;
            txtVietTat.Text = VietTat;
            inputColorPicker_BackColor.EditValue = System.Drawing.Color.FromArgb(int.Parse(backColor));
            inputColorPicker_ForeColor.EditValue = System.Drawing.Color.FromArgb(int.Parse(foreColor));
            BindLookupsFont();
            //cắt chuỗi font
            //chuỗi font có dạng : kiểu font, font size,style=font style : Tahoma, 8.25pt, style=Bold
            //khi insert thì insert cố định theo dạng này
            try
            {
                string[] arr = font.Split(',');
                fontEdit.EditValue = arr[0].Trim();
                string temp1 = arr[1].Replace("pt", string.Empty).Trim();
                lueFontSize.Properties.NullText = temp1;
                lueFontStyle.EditValue = arr[2].Replace("style=", string.Empty).Trim();
            }
            catch { }
        }
        #endregion

        #region hàm tạo phím tắt
        private void setPhimTat()
        {
            string[] t = new string[36] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
                                        ,"1","2","3","4","5","6","7","8","9","0"};
            luePhimTat.Properties.DataSource = t;
        }
        #endregion

        #region xử lý nút
        // thêm mới
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                var TenLoaiXe = txtTenLoaiXe.Text;
                var HangXe = txtHangXe.Text;
                var KichThuoc = txtKichThuoc.Text;
                var TaiTrongQuyDinh = txtTaiTrongQuyDinh.Text;
                var TaiTrongChoPhep = txtTaiTrongChoPhep.Text;
                var PhimTat = luePhimTat.Text;
                var VietTat = txtVietTat.Text;
                var font = fontEdit.EditValue.ToString();
                font += ", " + lueFontSize.Text +"pt";
                font += ", style=" + lueFontStyle.EditValue.ToString();
                var backColor = inputColorPicker_BackColor.Color.GetHashCode().ToString();
                var foreColor = inputColorPicker_ForeColor.Color.GetHashCode().ToString();

                if (g_ID > 0) // Update
                {
                    if (!(new LoaiXe().UpdateLoaiXe_BC_Truck(g_ID, TenLoaiXe, HangXe, KichThuoc, TaiTrongQuyDinh, TaiTrongChoPhep, PhimTat, font, VietTat, backColor,foreColor)))
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi cập nhật thông tin.", "Thông báo",
                         Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);

                        return;
                    }
                    else
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật thông tin thành công.", "Thông báo",
                         Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        Taxi.Business.CommonBL.ListLoaiXe = null;
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else // insert
                {
                    if (LoaiXe.CheckTrungTen_LoaiXe_Truck(TenLoaiXe))
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn kiểm tra lại tên loại xe bị trùng.", "Thông báo",
                             Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        return;
                    }

                    if (!(new LoaiXe().InsertLoaiXe_BC_Truck(TenLoaiXe, HangXe, KichThuoc, TaiTrongQuyDinh, TaiTrongChoPhep, PhimTat, VietTat, backColor, foreColor)))
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Lỗi thêm mới thông tin.", "Thông báo",
                         Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        return;
                    }
                    else
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Thêm mới thông tin thành công.", "Thông báo",
                         Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        Taxi.Business.CommonBL.ListLoaiXe = null;
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        // hủy bỏ
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region validate
        private bool IsValid() {
            if (txtTenLoaiXe.Text.Length <= 0) {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn chưa nhập tên loại xe.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtTenLoaiXe.Focus();
                return false;
            }
            if (txtHangXe.Text.Length <= 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn chưa nhập hãng xe.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtHangXe.Focus();
                return false;
            }
            if (txtKichThuoc.Text.Length <= 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn chưa nhập kích thước.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtKichThuoc.Focus();
                return false;
            }
            if (txtTaiTrongQuyDinh.Text.Length <= 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn chưa nhập tải trọng quy định.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtTaiTrongQuyDinh.Focus();
                return false;
            }
            if (txtTaiTrongChoPhep.Text.Length <= 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn chưa nhập tải trọng cho phép.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtTaiTrongChoPhep.Focus();
                return false;
            }
            if (txtTenLoaiXe.Text.Length > 50)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Nhập tên loại xe quá dài.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtTenLoaiXe.Focus();
                return false;
            }
            if (txtHangXe.Text.Length > 20)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Nhập hãng xe quá dài.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtHangXe.Focus();
                return false;
            }
            if (txtKichThuoc.Text.Length > 50)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Nhập kích thước quá dài.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtKichThuoc.Focus();
                return false;
            }
            if (txtTaiTrongQuyDinh.Text.Length > 20)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Nhập tải trọng quy định quá dài.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtTaiTrongQuyDinh.Focus();
                return false;
            }
            if (txtTaiTrongChoPhep.Text.Length > 20)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Nhập tải trọng cho phép quá dài.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtTaiTrongChoPhep.Focus();
                return false;
            } 
            if (txtVietTat.Text.Length > 6)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Tên viết tắt quá dài.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtVietTat.Focus();
                return false;
            }
            if (fontEdit.EditValue == null)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Chưa chọn font.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                fontEdit.Focus();
                return false;
            }
            if (lueFontStyle.EditValue == null)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Chưa chọn font style.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                lueFontStyle.Focus();
                return false;
            }
            return true;
        }

        private void txtTenLoaiXe_TextChanged(object sender, EventArgs e)
        {
            txtTenLoaiXe.Text = txtTenLoaiXe.Text.TrimStart();
        }

        private void txtHangXe_TextChanged(object sender, EventArgs e)
        {
            txtHangXe.Text = txtHangXe.Text.TrimStart();
        }

        private void txtKichThuoc_TextChanged(object sender, EventArgs e)
        {
            txtKichThuoc.Text = txtKichThuoc.Text.TrimStart();
        }

        private void txtTaiTrongQuyDinh_TextChanged(object sender, EventArgs e)
        {
            txtTaiTrongQuyDinh.Text = txtTaiTrongQuyDinh.Text.TrimStart();
        }

        private void txtTaiTrongChoPhep_TextChanged(object sender, EventArgs e)
        {
            txtTaiTrongChoPhep.Text = txtTaiTrongChoPhep.Text.TrimStart();
        }
        

        private void txtVietTat_TextChanged(object sender, EventArgs e)
        {
            txtVietTat.Text = txtVietTat.Text.TrimStart();
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (!fontEdit.IsPopupOpen && !lueFontSize.IsPopupOpen && !lueFontStyle.IsPopupOpen)
                {
                    SelectNextControl(ActiveControl, true, true, true, true);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Bind dữ liệu cho các lookup font size và font style
        /// </summary>
        private void BindLookupsFont()
        {
            List<double> ls = new List<double>() { 8,9,10,11,12,14,16,18,20,22,24,26,28,36,48,72};
            lueFontSize.Properties.DataSource = ls;
            //
            List<string> lsStyle = new List<string>() { "Regular", "Italic", "Bold", "Bold Italic"};
            lueFontStyle.Properties.DataSource = lsStyle;
        }

        private void lueFontSize_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            List<double> source = (List<double>)(sender as LookUpEdit).Properties.DataSource;
            if (source != null)
            {
                string s = (sender as LookUpEdit).Text;
                if (s.Length > 0)
                {
                    double temp = 0;
                    double.TryParse(s, out temp);
                    if (temp > 0)
                    {
                        source.Add(temp);
                        e.DisplayValue = temp;
                        (sender as LookUpEdit).Refresh();
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
