using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmSanh : Form
    {
        private int ID;
        private string Name;



        public frmSanh()
        {
            InitializeComponent();
            ID = 0;
            Name = "";
        }

        public frmSanh(int _ID, string _Name)
        {
            InitializeComponent();

            ID = _ID;
            Name = _Name;
            txtTenSanh.Text = Name;
        }


       
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(txtTenSanh.Text).Length <= 0)
            {

                new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập tên sảnh.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                return;


            }
            // Kiem tra tồn tại tên sảnh
            if (Sanh.CheckTonTaiTenSanh (StringTools.TrimSpace(txtTenSanh.Text)))
            {
                new MessageBox.MessageBoxBA().Show(this, "Tên sảnh này đã tồn tại.Bạn cần nhập tên khác.", "Thông báo",
                  Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                return;
            }


             Sanh objSanh = new Sanh (this.ID,StringTools.TrimSpace(txtTenSanh.Text));
            if (ID > 0) // Update 
            {
                if (objSanh.Update())
                {
                    new MessageBox.MessageBoxBA().Show(this, "Cập nhật sảnh thành công.", "Thông báo",
                   Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Lỗi cập nhật sảnh.", "Thông báo",
                   Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                     
                }
            }
            else // them moi
            {
                 
                this.ID =objSanh.Insert();
                if(this.ID>0 )
                {
                     new MessageBox.MessageBoxBA().Show(this, "Thêm mới sảnh thành công.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                      
                }
                else
                {
                     new MessageBox.MessageBoxBA().Show(this, "Lỗi thêm mới sảnh.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                      
                }
            }
            this.Close();
        }
    }
}