using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business.BaoCao;
//using Taxi.Business;

namespace TaxiOperation_DieuHanhChinh.SystemAdmin
{
    public partial class HeThong_PhanQuyenKhaiThacMoiGioi : Form
    {
        Taxi.Business.Users objUser = new Taxi.Business.Users();
        public HeThong_PhanQuyenKhaiThacMoiGioi()
        {
            InitializeComponent();
        }
        private void LoadCongTy()
        {
            DoiTac objThongTinDT = new DoiTac();
            DataTable dtCongTy = objThongTinDT.GetTenCongTy();
          
            cbCongTy.DisplayMember = "TenCongTy";
            cbCongTy.ValueMember = "CongtyID";
            cbCongTy.DataSource = dtCongTy;

        }
        private void HeThong_PhanQuyenKhaiThacMoiGioi_Load(object sender, EventArgs e)
        {
            LoadCongTy();
           
        }
        public void LoadListNhanVienKhaiThac()
        {
           
            if (cbCongTy.SelectedValue != null)
            {
                DataTable dtDuocKhaiThac = objUser.GetQuyenKhaiThacMoiGioi(int.Parse(cbCongTy.SelectedValue.ToString()), true);
                if (dtDuocKhaiThac != null && dtDuocKhaiThac.Rows.Count > 0)
                {
                    lstNVKhaiThac.DisplayMember = "FULLNAME";
                    lstNVKhaiThac.ValueMember = "USER_ID";
                    lstNVKhaiThac.DataSource = dtDuocKhaiThac;
                    return;
                }
            }
            lstNVKhaiThac.DataSource = null; 
        }
        public void LoadListNhanVienChuaDuocPhan()
        {
            if (cbCongTy.SelectedValue != null)
            {
                DataTable dtChuaDuocPhan = objUser.GetQuyenKhaiThacMoiGioi(int.Parse(cbCongTy.SelectedValue.ToString()), false);

                if (dtChuaDuocPhan != null && dtChuaDuocPhan.Rows.Count > 0)
                {
                    lstNVChuaDuocPhan.DisplayMember = "FULLNAME";
                    lstNVChuaDuocPhan.ValueMember = "USER_ID";
                    lstNVChuaDuocPhan.DataSource = dtChuaDuocPhan;
                    return;
                }
            }
            lstNVChuaDuocPhan.DataSource = null;
        }
        private void cbCongTy_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                LoadListNhanVienKhaiThac();
                LoadListNhanVienChuaDuocPhan();               
            }
            catch(Exception ex)
            {
            
            }
                      
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            int congTyID = int.Parse(cbCongTy.SelectedValue.ToString());
           
            if (congTyID == 0)
            {
                MessageBox.Show("Hãy chọn tên công ty");
            }
            else if (lstNVChuaDuocPhan.DataSource == null)
            {
                MessageBox.Show("Bạn phải chọn tên nhân viên");
            }
            else
            {
                string userID = lstNVChuaDuocPhan.SelectedValue.ToString();
                if (objUser.InserUpdateNVTiepThi(congTyID, userID, true) < 0)
                {
                    MessageBox.Show("Có lỗi trong quá trình thêm NVTT vào công ty");
                }
                else
                {
                    LoadListNhanVienChuaDuocPhan();
                    LoadListNhanVienKhaiThac();
                }
            }
        }

        private void btnFoward_Click(object sender, EventArgs e)
        {
            int congTyID = int.Parse(cbCongTy.SelectedValue.ToString());
            
            if (congTyID == 0 )
            {
                MessageBox.Show("Hãy chọn tên công ty");
            }
            else if (lstNVKhaiThac.DataSource == null)
            {
                MessageBox.Show("Bạn phải chọn tên nhân viên");
            }
            else
            {
                string userID = lstNVKhaiThac.SelectedValue.ToString();
                if (objUser.InserUpdateNVTiepThi(congTyID, userID, false) <= 0)
                {
                    MessageBox.Show("Có lỗi trong quá trình xóa NVTT khỏi công ty này");
                }
                else
                {
                    LoadListNhanVienChuaDuocPhan();
                    LoadListNhanVienKhaiThac();
                }
            }
        }
        #region xu ly hot key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return false;
        }
        #endregion

    }
}