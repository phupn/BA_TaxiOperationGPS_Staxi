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
    public partial class frmGara : Form
    {
        private int ID;
        private string Name;



        public frmGara()
        {
            InitializeComponent();
            ID = 0;
            Name = "";
        }

        public frmGara(int _ID, string _Name)
        {
            InitializeComponent();

            ID = _ID;
            Name = _Name;
            txtTenGara.Text = Name;
        }


       
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(txtTenGara.Text).Length <= 0)
            {

                new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập tên gara.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                return;


            }
            // Kiem tra tồn tại tên gara
            if (Gara.CheckTonTaiTenGara(StringTools.TrimSpace(txtTenGara.Text)))
            {
                new MessageBox.MessageBoxBA().Show(this, "Tên gara này đã tồn tại.Bạn cần nhập tên khác.", "Thông báo",
                  Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                return;
            }


             Gara objGara = new Gara (this.ID,StringTools.TrimSpace(txtTenGara.Text));
            if (ID > 0) // Update 
            {
                if (objGara.Update())
                {
                    new MessageBox.MessageBoxBA().Show(this, "Cập nhật gara thành công.", "Thông báo",
                   Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Lỗi cập nhật gara.", "Thông báo",
                   Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                     
                }
            }
            else // them moi
            {
                 
                this.ID =objGara.Insert();
                if(this.ID>0 )
                {
                     new MessageBox.MessageBoxBA().Show(this, "Thêm mới gara thành công.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                      
                }
                else
                {
                     new MessageBox.MessageBoxBA().Show(this, "Lỗi thêm mới gara.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                      
                }
            }
            this.Close();
        }
    }
}