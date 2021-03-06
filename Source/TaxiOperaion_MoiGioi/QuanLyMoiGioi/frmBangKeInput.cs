using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmBangKeInput : Form
    {
        private DataTable DTDoiTac;
        private int IDBangKe;
        private BangKe mBangKe;
        public BangKe BangKe
        {
            get { return mBangKe; }

        }

        private bool mIsAdd = true;
        private bool IsAdd
        {
            get { return mIsAdd; }
        }

        public frmBangKeInput()
        {
            InitializeComponent();
        }

        public frmBangKeInput(DataTable dtDoiTac)
        {
            InitializeComponent();
            DTDoiTac = dtDoiTac;
        }

        public frmBangKeInput(BangKe BangKe, DataTable dtDoiTac, bool boolAdd)
        {
            InitializeComponent();
            DTDoiTac = dtDoiTac;
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới bảng kê";
                calNgayDon.Value = DateTime.Now;
            }
            else
            {
                this.Text = "Sửa đổi thông tin bảng kê";
            }

            mBangKe = BangKe;
            SetBangKe(BangKe);
        }

        private void frmBangKeInput_Load(object sender, EventArgs e)
        {
            LoadDSCongTy();
            LoadDSDoiTac();
        }

        public void LoadDSCongTy()
        {
            cbCongTy.ValueMember = "CongTyID";
            cbCongTy.DisplayMember = "TenCongTy";
            cbCongTy.DataSource = null;
            DataTable a = CongTy.GetListOfCongTys_NAME();
            cbCongTy.DataSource = CongTy.GetListOfCongTys_NAME();
            if (mIsAdd)
            {
                cbCongTy.SelectedIndex = 0;
            }
        }

        private void LoadDSDoiTac()
        {
            DoiTac objDoiTac = new DoiTac();
            cbMoiGioi.DisplayMember = "Name";
            cbMoiGioi.ValueMember = "Ma_DoiTac";
            cbMoiGioi.DataSource = DTDoiTac;
            if (mIsAdd)
            {
                cbMoiGioi.SelectedIndex = 0;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                GetBangKe();
                if (mIsAdd)
                {
                    if (BangKe.Insert())
                    {
                        new MessageBox.MessageBox().Show("Thêm bảng kê thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                        refreshForm();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show("Lỗi thêm bảng kê", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (BangKe.Update())
                    {
                        new MessageBox.MessageBox().Show("Cập nhật bảng kê thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                        refreshForm();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show("Lỗi cập nhật bảng kê", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private BangKe GetBangKe()
        {
            mBangKe = new BangKe();
            string strCongtyID = cbCongTy.SelectedValue.ToString();            
            if(!strCongtyID.Equals(""))
            {
                mBangKe.FK_CongTyID = int.Parse(strCongtyID);
            }
            else
            {
                mBangKe.FK_CongTyID = 0;
            }
            string strMaDoiTac = cbMoiGioi.SelectedValue.ToString();
            if (!strCongtyID.Equals(""))
            {
                mBangKe.FK_MaDoiTac = strMaDoiTac;
            }
            else
            {
                mBangKe.FK_MaDoiTac = "";
            }
            mBangKe.DSXeDon = txtDSXeDon.Text;           
            mBangKe.CreatedBy = ThongTinDangNhap.USER_ID;
            mBangKe.UpdatedBy = ThongTinDangNhap.USER_ID;            
            mBangKe.NgayDon = calNgayDon.Value;
            mBangKe.ID = IDBangKe;
            return mBangKe;
        }        

        private void SetBangKe(BangKe objBangKe)
        {
            IDBangKe = objBangKe.ID;
            int intCongTyID = objBangKe.FK_CongTyID;
            if (intCongTyID >= 0)
            {
                cbCongTy.SelectedValue = intCongTyID;
            }
            string strMaDoiTac = objBangKe.FK_MaDoiTac;
            if (!strMaDoiTac.Equals(""))
            {
                cbMoiGioi.SelectedValue = strMaDoiTac;
            }
            txtDSXeDon.Text = objBangKe.DSXeDon;
            calNgayDon.Value = objBangKe.NgayDon;
        }

        private bool validate()
        {
            bool returnValue = true;
            string dsXeDon = txtDSXeDon.Text;
            if (cbCongTy.SelectedIndex == 0)
            {
                new MessageBox.MessageBox().Show("Bạn chưa chọn Công Ty", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                returnValue = false;                
            }
            else if (cbMoiGioi.SelectedIndex == 0)
            {
                new MessageBox.MessageBox().Show("Bạn chưa chọn Đối tác", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                returnValue = false;
            }
            else
            {
                if (!dsXeDon.Equals(""))
                {
                    string[] listXeDon = dsXeDon.Split(',');
                    foreach (string xeDon in listXeDon)
                    {
                        if (Xe.KiemTraTonTaiCuaSoHieuXe(xeDon) == false)
                        {
                            new MessageBox.MessageBox().Show("Xe : " + xeDon + " không tồn tại trong hệ thống", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                            returnValue = false;
                            break;
                        }
                    }
                }
                else
                {
                    new MessageBox.MessageBox().Show("Bạn chưa nhập xe đón", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    returnValue = false;
                }
            }
            return returnValue;
        }

        private void refreshForm()
        {
            calNgayDon.Value = DateTime.Now;
            cbCongTy.SelectedIndex = 0;
            cbMoiGioi.SelectedIndex = 0;
            txtDSXeDon.Text = "";
        }
    }
}