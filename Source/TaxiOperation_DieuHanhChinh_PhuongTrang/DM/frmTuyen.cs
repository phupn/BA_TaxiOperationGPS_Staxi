using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business.DM;
using Taxi.Business.BanGiaGoc;

namespace Taxi.GUI
{
    public partial class frmTuyen : Form
    {
        private string  IDTuyenDuong;
        private string TenTuyenDuong;
        private int KieuTuyenDuong;



        public frmTuyen()
        {
            InitializeComponent();
            
            IDTuyenDuong = "";
            TenTuyenDuong = "";
            KieuTuyenDuong = 1;
        }

        public frmTuyen(string _IDTuyenDuong, string _TenTuyenDuong, int _KieuTuyenDuong)
        {
            InitializeComponent();

            IDTuyenDuong = _IDTuyenDuong;
            TenTuyenDuong = _TenTuyenDuong;
            KieuTuyenDuong = _KieuTuyenDuong;

            txtTenTuyen.Text = TenTuyenDuong;
            if (KieuTuyenDuong == 1) radNgoaiThanh.Checked = true;
            else radNgoaiTinh.Checked = true;

        }


       
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(txtTenTuyen.Text).Length <= 0)
            {

                new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập tên .", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                return;


            }
            TuyenDuong objTuyenDuong = new TuyenDuong ();

            // Kiem tra tồn tại tên gara
            if (objTuyenDuong.CheckTonTaiTenTuyenDuong(StringTools.TrimSpace(txtTenTuyen.Text)))
            {
                new MessageBox.MessageBoxBA().Show(this, "Tên tuyến đường  này đã tồn tại.Bạn cần nhập tên khác.", "Thông báo",
                  Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                return;
            } 

            this.TenTuyenDuong = StringTools.TrimSpace(txtTenTuyen.Text );
            if(radNgoaiTinh.Checked)
                 this.KieuTuyenDuong =2;
            else this.KieuTuyenDuong =1;

            if (IDTuyenDuong.Length  > 0) // Update 
            {
                if (TuyenDuong.Update(IDTuyenDuong,TenTuyenDuong,KieuTuyenDuong))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Cập nhật tuyến đường thành công.", "Thông báo",
                   Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Lỗi cập nhật tuyến đường.", "Thông báo",
                   Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                     
                }
            }
            else // them moi
            {
                bool bOK = TuyenDuong.Insert(TenTuyenDuong, KieuTuyenDuong);
                if ( bOK  )
                {
                     new MessageBox.MessageBoxBA().Show(this, "Thêm mới tuyến đường thành công.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                      
                }
                else
                {
                     new MessageBox.MessageBoxBA().Show(this, "Lỗi thêm mới tuyến đường.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                      
                }
            }
            this.Close();
        }
    }
}