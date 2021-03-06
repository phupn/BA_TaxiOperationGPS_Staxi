using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DM;
using Janus.Windows.GridEX;
using Taxi.Business;

namespace TaxiOperation_DieuHanhChinh.DM
{
    public partial class frmDMLoaiPhanAnh : Form
    {
        public frmDMLoaiPhanAnh()
        {
            InitializeComponent();
        }            

        private void frmDMLoaiPhanAnh_Load(object sender, EventArgs e)
        {
            GetLoaiPhanAnh();
            this.ActiveControl = grdLoaiPhanAnh;
            grdLoaiPhanAnh.Focus();
        }

        #region Load Du Lieu
        public void GetLoaiPhanAnh()
        {
            grdLoaiPhanAnh.DataMember = "lstLoaiPhanAnh";
            grdLoaiPhanAnh.SetDataBinding(LoaiPhanAnh.SelectAll(), "lstLoaiPhanAnh");

            grdLoaiPhanAnh.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
        }
        #endregion

        private void hlkThem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLoaiPhanAnh().ShowDialog();
            GetLoaiPhanAnh();
        }

        private void hlkSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grdLoaiPhanAnh.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if(grdLoaiPhanAnh.SelectedItems.Count >0)
            {
                GridEXRow row = grdLoaiPhanAnh.SelectedItems[0].GetRow();
                int id = int.Parse(row.Cells["ID"].Value.ToString());
                string tenPA = row.Cells["LoaiPhanAnh"].Value.ToString();
               
                new frmLoaiPhanAnh(id, tenPA, ThongTinDangNhap.USER_ID).ShowDialog();
                GetLoaiPhanAnh();
            }
        }

        private void hlkXoa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grdLoaiPhanAnh.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if(grdLoaiPhanAnh.SelectedItems.Count >0)
            {
                GridEXRow row = grdLoaiPhanAnh.SelectedItems[0].GetRow();
                int id = int.Parse(row.Cells["ID"].Value.ToString());
                string tenPA = row.Cells["LoaiPhanAnh"].Value.ToString();
                if(MessageBox.Show("Bạn có muốn xóa loại phản ánh. Thao tác này có thể ảnh hưởng đến thông tin phản ánh","Thông báo",
                    MessageBoxButtons.YesNoCancel ,MessageBoxIcon.Question ).ToString() == DialogResult.Yes.ToString())
                {
                    LoaiPhanAnh objPhanAnh = new LoaiPhanAnh(id,tenPA);
                    if (objPhanAnh.Delete())
                    {
                        MessageBox.Show("Xóa loại phản ánh thành công", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetLoaiPhanAnh();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa loại phản ánh bị lỗi", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void grdLoaiPhanAnh_DoubleClick(object sender, EventArgs e)
        {
            grdLoaiPhanAnh.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdLoaiPhanAnh.SelectedItems.Count > 0)
            {
                GridEXRow row = grdLoaiPhanAnh.SelectedItems[0].GetRow();
                int id = int.Parse(row.Cells["ID"].Value.ToString());
                string tenPA = row.Cells["LoaiPhanAnh"].Value.ToString();

                new frmLoaiPhanAnh(id, tenPA, ThongTinDangNhap.USER_ID).ShowDialog();
                GetLoaiPhanAnh();
            }
        }


        private void btnLen_Click(object sender, EventArgs e)
        {
            grdLoaiPhanAnh.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection ;
            if (grdLoaiPhanAnh.SelectedItems.Count > 0)
            {
                GridEXRow row = grdLoaiPhanAnh.SelectedItems[0].GetRow();
                int id = int.Parse(row.Cells["ID"].Value.ToString());
                int thuTu = int.Parse(row.Cells["ThuTu"].Value.ToString());
                LoaiPhanAnh objPhanAnh = new LoaiPhanAnh();
                objPhanAnh.SortDMPhanAnh(id, thuTu, 1);//chọn đi lên 
                GetLoaiPhanAnh();
                
            }
            
        }

        private void btnXuong_Click(object sender, EventArgs e)
        {
            grdLoaiPhanAnh.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdLoaiPhanAnh.SelectedItems.Count > 0)
            {
                GridEXRow row = grdLoaiPhanAnh.SelectedItems[0].GetRow();
                int id = int.Parse(row.Cells["ID"].Value.ToString());
                int thuTu = int.Parse(row.Cells["ThuTu"].Value.ToString());
                LoaiPhanAnh objPhanAnh = new LoaiPhanAnh();
                objPhanAnh.SortDMPhanAnh(id, thuTu, 0);//chọn đi xuống
                GetLoaiPhanAnh();
            }

        }
        #region Xu li hot key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData == Keys.Escape )
            {
                this.Close();
                return true;
            }
            else if(keyData == Keys.U)
            {
                btnLen.Focus();
                return true;
            }
            else if(keyData == Keys.D)
            {
                btnXuong.Focus();
                return true;
            }
            else if(keyData == Keys.T)
            {
                hlkThem.Focus();
                return true;
            }
            else if(keyData == Keys.S)
            {
                hlkSua.Focus();
                return true;
            }
            else if (keyData == Keys.X)
            {
                hlkXoa.Focus();
                return true;
            }
            return false;
        }
        #endregion

        private void btnLen_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down )
            {
                btnXuong.Focus();
            }
        }

        private void btnXuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnLen.Focus();
            }
            else if (e.KeyCode == Keys.Down )
            {
                hlkThem.Focus();
            }
        }

        private void grdLoaiPhanAnh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                btnLen.Focus();
            }
        }

    }
}