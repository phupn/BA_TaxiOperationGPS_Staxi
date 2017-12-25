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

namespace Taxi.GUI
{
    public partial class frmDMDiaDanhKm : Form
    {
        public frmDMDiaDanhKm()
        {
            InitializeComponent();
            LoadDiaDanh();
        }

        private void LoadDiaDanh()
        {
            gridDiaDanhKm.DataMember = "listDiaDanh";
            gridDiaDanhKm.SetDataBinding(TinhTienTheoKm.GetAllDiaDanh() , "listDiaDanh");
            
        }

        private void lnkThemMoi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmDiaDanhKm().ShowDialog();
            this.LoadDiaDanh();
        }

        private void gridDiaDanhKm_DoubleClick(object sender, EventArgs e)
        {
            gridDiaDanhKm.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDiaDanhKm.SelectedItems.Count > 0)
            {
                GridEXRow row = gridDiaDanhKm.SelectedItems[0].GetRow();
                int ID = int.Parse(row.Cells["ID"].Value.ToString());
                string Name = row.Cells["TenDiaDanh"].Value.ToString();
                int  Km = Convert.ToInt16(row.Cells["Km"].Value.ToString());

                new frmDiaDanhKm(ID, Name,Km).ShowDialog();
                this.LoadDiaDanh();
            }
        }

        private void lnkXoa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridDiaDanhKm.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDiaDanhKm.SelectedItems.Count > 0)
            {
                GridEXRow row = gridDiaDanhKm.SelectedItems[0].GetRow();
                int ID = int.Parse(row.Cells["ID"].Value.ToString());
              

                if (new MessageBox.MessageBoxBA().Show(this, "Bạn có đồng ý xóa địa danh.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
                     
                    if (TinhTienTheoKm.DeleteDiaDanhKm(ID))
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Xóa địa danh thành công.", "Thông báo",
                       Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        this.LoadDiaDanh();
                        return;

                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Lỗi xóa địa danh.", "Thông báo",
                       Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        return;
                    }

                }
            }
        }

        private void lnkSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridDiaDanhKm.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDiaDanhKm.SelectedItems.Count > 0)
            {
                GridEXRow row = gridDiaDanhKm.SelectedItems[0].GetRow();
                int ID = int.Parse(row.Cells["ID"].Value.ToString());
                string Name = row.Cells["TenDiaDanh"].Value.ToString();
                int Km = Convert.ToInt16(row.Cells["Km"].Value.ToString());

                new frmDiaDanhKm(ID, Name, Km).ShowDialog();
                this.LoadDiaDanh();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TenDiaDanh = StringTools.TrimSpace(txtTimKiem.Text);
            if (TenDiaDanh.Length <= 0)
                this.LoadDiaDanh();
            else
            {
                gridDiaDanhKm.DataMember = "listDiaDanh";
                gridDiaDanhKm.SetDataBinding(TinhTienTheoKm.SearchDiaDanhByTen(TenDiaDanh), "listDiaDanh");
     

            }
        }

        
    }
}