using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Business.DM;
using Taxi.Controls.Maps;

namespace Taxi.GUI
{
    public partial class frmKhachQuen: Form
    {
        #region ==========================Init=================================
        private DanhBaKhachQuen G_KhachQuen;
        private List<DanhBaKhachQuen_Type> G_lstKhachQuen_Type;
        private List<DanhBaKhachQuen_Rank> G_lstKhachQuen_Rank;
        private bool mIsAdd = false;
        private float G_KinhDo;
        private float G_ViDo; 
        private bool g_DiaChi_TimKiem;
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return mIsAdd; }
        }
        #endregion

        #region =======================Constructor=============================
        public frmKhachQuen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        /// <param name="DoiTac"></param>
        /// <param name="boolAdd"></param>
        public frmKhachQuen(DanhBaKhachQuen KhachQuen, bool boolAdd, List<DanhBaKhachQuen_Type> lstKhachQuen_Type, List<DanhBaKhachQuen_Rank> lstKhachQuen_Rank)
        {
            InitializeComponent();
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới khách thân thiết";
            }
            else
            {
                this.Text = "Sửa đổi thông tin khách thân thiết";
                txt_Phones.Enabled = false;
            }
            G_KhachQuen = KhachQuen;
            G_lstKhachQuen_Type = lstKhachQuen_Type;
            G_lstKhachQuen_Rank = lstKhachQuen_Rank;
        }
        #endregion

        #region ========================Load Form==============================
        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            LoadCB_Type();
            LoadCB_Rank();
            SetKhachQuen(G_KhachQuen);
            if (txt_MaKH.Text != "")
                txt_MaKH.Enabled = false;
            txt_MaKH.Focus();            
        }

        private void LoadCB_Type()
        {
            cb_Type.DisplayMember = "Type";
            cb_Type.ValueMember = "ID";
            cb_Type.DataSource = G_lstKhachQuen_Type;
        }

        private void LoadCB_Rank()
        {
            cb_Rank.DisplayMember = "Rank";
            cb_Rank.ValueMember = "ID";
            cb_Rank.DataSource = G_lstKhachQuen_Rank;
        }

        #endregion

        private void SetKhachQuen(DanhBaKhachQuen KhachQuen)
        {
            txt_Phones.Text  = KhachQuen.Phones;
            txt_Name .Text  = KhachQuen.Name;
            txt_Address .Text  = KhachQuen.Address;
            txt_MaKH.Text = KhachQuen.MaKH;
            txt_Notes.Text = KhachQuen.Notes;
            txt_Email.Text = KhachQuen.Email;
            txt_Fax.Text = KhachQuen.Fax;
            cb_Type.SelectedValue = KhachQuen.Type;
            cb_Rank.SelectedValue = KhachQuen.Rank;
            date_Birthday.Value = KhachQuen.BirthDay;
            chk_IsActive.Checked = KhachQuen.IsActive;
        }

        public DanhBaKhachQuen GetKhachQuen()
        {
            G_KhachQuen.Phones  = StringTools.TrimSpace (txt_Phones.Text);
            G_KhachQuen.Name = StringTools.TrimSpace (txt_Name.Text);
            G_KhachQuen.Address = StringTools.TrimSpace (txt_Address.Text);
            G_KhachQuen.BirthDay = date_Birthday.Value;
            G_KhachQuen.Email = txt_Email.Text.Trim();
            G_KhachQuen.Fax = txt_Fax.Text.Trim();
            G_KhachQuen.IsActive = chk_IsActive.Checked;
            G_KhachQuen.MaKH = txt_MaKH.Text.Trim();
            G_KhachQuen.Notes = txt_Notes.Text.Trim() ;
            if (cb_Rank.SelectedValue!=null)
            G_KhachQuen.Rank = (int)cb_Rank.SelectedValue;
            else
            {
                G_KhachQuen.Rank = 0;
            }
            if (cb_Type.SelectedValue != null)
                G_KhachQuen.Type = (int) cb_Type.SelectedValue;
            else G_KhachQuen.Type = 0;
            if (this.g_DiaChi_TimKiem)
            {
                G_KhachQuen.KinhDo = this.G_KinhDo;
                G_KhachQuen.ViDo = this.G_ViDo;
            }
            return G_KhachQuen;
        }


        #region Validate du lieu
        private void Validate()
        {
            if (StringTools.TrimSpace(txt_Name.Text).Length <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập tên khách hàng");
                return;
            }
            else if (StringTools.TrimSpace(txt_Phones.Text).Length <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập số điện thoại");
                return;
            }
            else if (StringTools.TrimSpace(txt_Phones.Text).Length < 8)
            {
                new MessageBox.MessageBoxBA().Show("Điện thoại phải lớn hơn 8 số");
                return;
            }
        }
        #endregion Validate du lieu

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.B))
            {
                picMap_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_MaKH.Text == "" || !txt_MaKH.HasText)
            {
                g_Cancel = true;
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập mã KH");
                txt_MaKH.Focus();
                return;    
            }
            if (txt_Phones.Text == "" || !txt_Phones.HasText)
            {
                g_Cancel = true;
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập SĐT");
                txt_Phones.Focus();
                return;
            } 
            if (txt_Name.Text == "" || !txt_Name.HasText)
            {
                g_Cancel = true;
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập tên KH");
                txt_Name.Focus();
                return;
            }
            if (cb_Type.SelectedValue == null)
            {
                g_Cancel = true;
                new MessageBox.MessageBoxBA().Show("Vui lòng chọn loại KH");
                cb_Type.Focus();
                return;
            }
            if (cb_Rank.SelectedValue == null)
            {
                g_Cancel = true;
                new MessageBox.MessageBoxBA().Show("Vui lòng chọn xếp hạng KH");
                cb_Rank.Focus();
                return;
            } 
            DialogResult=DialogResult.OK;
            //this.GetKhachQuen();
            this.Close();
        }

        private void frmXe_FormClosing(object sender, FormClosingEventArgs e)
        {
             
        }

        private void editSoHieuXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //    e.Handled = true;
        }

        private void picMap_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void picMap_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmBanDo();
                frm.userMap1.DiaChiTimKiem = txt_Address.Text;
                frm.userMap1.Lng = G_KinhDo;
                frm.userMap1.Lat = G_ViDo;
                frm.userMap1.Bind();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txt_Address.Text = frm.userMap1.DiaChi;
                    G_KinhDo = frm.userMap1.Lng;
                    G_ViDo = frm.userMap1.Lat;
                    g_DiaChi_TimKiem = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void frmKhachQuen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (g_Cancel)
            {
                e.Cancel = true;
                g_Cancel = false;
            }
        }

        private bool g_Cancel = false;


    }
}