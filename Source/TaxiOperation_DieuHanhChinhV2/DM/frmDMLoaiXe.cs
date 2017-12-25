using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmDMLoaiXe : Form
    {
        public frmDMLoaiXe()
        {
            InitializeComponent();
            LoadDiaDanh();
        }

        private void LoadDiaDanh()
        {
            gridLoaiXe.DataMember = "listLoaiXe";
            gridLoaiXe.SetDataBinding(new TinhTienTheoKm().GetAllLoaiXe(), "listLoaiXe");            
        }

        private void lnkThemMoi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLoaiXe().ShowDialog();
            this.LoadDiaDanh();
        }

        private void lnkXoa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridLoaiXe.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridLoaiXe.SelectedItems.Count > 0)
            {
                GridEXRow row = gridLoaiXe.SelectedItems[0].GetRow();
                int ID = int.Parse(row.Cells["LoaiXeID"].Value.ToString());

                if (new MessageBox.MessageBoxBA().Show(this, "Bạn có đồng ý xóa loại xe.", "Thông báo", 
                                                        MessageBox.MessageBoxButtonsBA.YesNoCancel, 
                                                        MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    if (new LoaiXe().DeleteLoaiXe(ID))
                    {
                        this.LoadDiaDanh();
                        return;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Lỗi xóa loại xe.", "Thông báo",
                       MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                        return;
                    }
                }
            }
        }

        private void lnkSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateRecord();
        }

        private void gridLoaiXe_DoubleClick(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void UpdateRecord()
        {
            gridLoaiXe.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridLoaiXe.SelectedItems.Count > 0)
            {
                GridEXRow row = gridLoaiXe.SelectedItems[0].GetRow();
                int ID = int.Parse(row.Cells["LoaiXeID"].Value.ToString());
                string Name = row.Cells["TenLoaiXe"].Value.ToString();
                int SoCho = 4;
                Int32.TryParse(row.Cells["SoCho"].Value.ToString(), out SoCho);
                if (SoCho < 4)
                {
                    SoCho = 4;
                }
                new frmLoaiXe(ID, Name, SoCho).ShowDialog();
                this.LoadDiaDanh();
            }
        }

        #region Xử lý hot key

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }
}