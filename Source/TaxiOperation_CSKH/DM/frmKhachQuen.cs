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

namespace Taxi.GUI
{
    public partial class frmKhachQuen: Form
    {
        #region ==========================Init=================================
        private DanhBaKhachQuen G_KhachQuen;
        private List<DanhBaKhachQuen_Type> G_lstKhachQuen_Type;
        private List<DanhBaKhachQuen_Rank> G_lstKhachQuen_Rank;
        private bool mIsAdd = false;
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
        public frmKhachQuen(DanhBaKhachQuen KhachQuen, bool boolAdd) 

        {
            InitializeComponent();
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới khách thân thiết";
                // lấy mã khách hàng.
                int maxMaKH = DanhBaKhachQuen.GetMaKH() ;
                txt_MaKH.Enabled = false;
                if (maxMaKH <= 0)
                {
                    txt_MaKH.Text = "";
                    txt_MaKH.Enabled = true;
                }
                else
                {
                    maxMaKH++; // tăng thêm một giá trị
                    txt_MaKH.Text = maxMaKH.ToString();
                }
            }
            else
            {
                this.Text = "Sửa đổi thông tin khách thân thiết";
                txt_Phones.Enabled = false;
            }
            G_KhachQuen = KhachQuen;
           // G_lstKhachQuen_Type = lstKhachQuen_Type;
           // G_lstKhachQuen_Rank = lstKhachQuen_Rank;


        }
        #endregion

        #region ========================Load Form==============================
        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            //LoadCB_Type();
            //LoadCB_Rank();
            SetKhachQuen(G_KhachQuen);            
        }

       

        #endregion

        private void SetKhachQuen(DanhBaKhachQuen KhachQuen)
        {
            txt_Phones.Text  = string.IsNullOrEmpty( KhachQuen.Phones) ? string.Empty :KhachQuen.Phones  ;
            txt_Name .Text  = KhachQuen.Name;
            txt_Address .Text  = KhachQuen.Address;
            
            if(KhachQuen.MaKH != null && KhachQuen.MaKH.Length >0)
                txt_MaKH.Text = KhachQuen.MaKH;
            
            txt_Notes.Text = KhachQuen.Notes;
            txt_Email.Text = KhachQuen.Email;
            txt_Fax.Text = KhachQuen.Fax;
             
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
            G_KhachQuen.Rank = 0;// (int)cb_Rank.SelectedValue;
            G_KhachQuen.Type = 0;// (int)cb_Type.SelectedValue;
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            Validate(); 

            this.Close();
        }

        private void frmXe_FormClosing(object sender, FormClosingEventArgs e)
        {
             
        }

        private void editSoHieuXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

  
       
    }
}