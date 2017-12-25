using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DM;
using Janus.Windows.GridEX;

namespace Taxi.GUI
{
    public partial class frmDMGara : Form
    {
        public frmDMGara()
        {
            InitializeComponent();
        }

        private void frmDMGara_Load(object sender, EventArgs e)
        {
            GetDSGara();
        }

         private void GetDSGara()
        {

            grdDSGara.DataMember = "listGara";
            grdDSGara.SetDataBinding(Gara.GetAllGara() , "listGara");
        }
        private void lnkThemMoi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmGara().ShowDialog();
            this.GetDSGara();
        }
        private void grdDSGara_DoubleClick(object sender, EventArgs e)
        {
            grdDSGara.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDSGara.SelectedItems.Count > 0)
            {
                GridEXRow row = grdDSGara.SelectedItems[0].GetRow();
                int ID = int.Parse( row.Cells["ID"].Value.ToString());
                string Name = row.Cells["Name"].Value.ToString();
                  
                new frmGara(ID,Name).ShowDialog();
                this.GetDSGara();
            }
        }

        private void lnkXoa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grdDSGara.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDSGara.SelectedItems.Count > 0)
            {
                GridEXRow row = grdDSGara.SelectedItems[0].GetRow();
                int ID = int.Parse(row.Cells["ID"].Value.ToString());
                string Name = row.Cells["Name"].Value.ToString();

                if (new MessageBox.MessageBoxBA().Show(this, "Bạn có đồng ý xóa gara, xóa thông tin gara ảnh hưởng tới thông tin xe", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
                    Gara objGara = new Gara(ID, Name);
                    if (objGara.Delete())
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Xóa gara thành công.", "Thông báo",
                       Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        this.GetDSGara();
                        return;

                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Lỗi xóa gara.", "Thông báo",
                       Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        return;
                    }
                    
                }
            }
        }

        private void lnkSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grdDSGara.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDSGara.SelectedItems.Count > 0)
            {
                GridEXRow row = grdDSGara.SelectedItems[0].GetRow();
                int ID = int.Parse(row.Cells["ID"].Value.ToString());
                string Name = row.Cells["Name"].Value.ToString();

                new frmGara(ID, Name).ShowDialog();
                this.GetDSGara();                    
            }
        } 
    }
}