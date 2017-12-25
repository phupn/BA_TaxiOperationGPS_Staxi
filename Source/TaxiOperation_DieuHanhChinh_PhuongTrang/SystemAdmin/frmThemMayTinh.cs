using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.QuanTri;
using Taxi.Utils;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmThemMayTinh : Form
    {
        private string g_IP;
        private string g_Line_Vung;
        private string g_Line_Gop;
        private bool g_IsActive;
        private string g_KieuMayTinh;
        private bool g_IsAdd = false;
        private int g_No = 0;
        public frmThemMayTinh()
        {
            InitializeComponent();
        }
        /// <summary>
        /// form khởi tạo thêm và update
        /// IF KieuMayTinh = DT --> thêm máy điện thoại
        /// IF KieuMayTinh = TD --> thêm máy tổng đài
        /// IF KieuMayTinh = MK --> thêm máy mời khách
        /// IF KieuMayTinh = CO --> Thêm máy cám ơn
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Line_Vung"></param>
        /// <param name="IsActive"></param>
        /// <param name="KieuMayTinh"></param>
        /// <param name="IsAdd"></param>
        public frmThemMayTinh(string IP, string Line_Vung, bool IsActive, string KieuMayTinh, bool IsAdd,int No, string LineGop )
        {
            InitializeComponent();

            txtIP.Text = g_IP = IP;
            txtLine_Vung.Text = g_Line_Vung = Line_Vung;
            txtLineGop.Text = g_Line_Gop = LineGop;
            chkChoPhep.Checked= g_IsActive = IsActive;
            g_KieuMayTinh = KieuMayTinh;
            if(IsAdd)
                this.Text = "Thêm mới";
            else 
                this.Text = "Sửa đổi";
            if(KieuMayTinh == Taxi.Business.KieuMayTinh.MAYDIENTHOAI)
            {
                lblLine_Vung.Text = "Lines";
                this.Text += " - Máy điện thoại"; 
            }
            else 
            {
                lblLine_Vung.Text = "Vùng";            
                if(KieuMayTinh ==  Taxi.Business.KieuMayTinh.MAYTONGDAI)
                {
                     this.Text += " - Máy tổng đài";
                     label3.Text = "Vùng gộp";
                } 
                else if (KieuMayTinh == Taxi.Business.KieuMayTinh.MAYMOIKHACH)
                {
                    this.Text += " - Máy mời khách - vùng";
                    num_No.Visible = true;
                   // num_No.Value = No;
                    lblNo.Visible = true;
                    label3.Text = "Vùng gộp";
                }
                else if (KieuMayTinh == Taxi.Business.KieuMayTinh.MAYKHACHMOI)
                {
                    lblLine_Vung.Text = "Lines";
                    this.Text += " - Máy mời khách - line điện thoại";
                    label3.Text = "Line gộp";
                }
                
            }
   
                g_IsAdd = IsAdd;
            if (!g_IsAdd) txtIP.Enabled = false;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool bOK = false;

            g_IP = StringTools.TrimSpace(txtIP.Text);
            g_Line_Vung = StringTools.TrimSpace(txtLine_Vung.Text);
            g_Line_Gop = StringTools.TrimSpace(txtLineGop.Text);
            g_No = Convert.ToInt16(num_No.Value);
            if ((g_IP.Length > 0) && (g_Line_Vung.Length > 0))
            {
                if (g_IsAdd)
                {
                    if (QuanTriCauHinh.GetLineVungOfPC(g_IP,"").Length >0)
                    {
                        MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
                        if(msg.Show("Đã tồn tại IP này trong hệ thống bạn cần kiểm tra lại.Bạn có đồng ý lưu trùng IP không ?","Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.No.ToString ())
                        return;
                    }
                }
                g_IsActive = chkChoPhep.Checked;
                bOK = QuanTriCauHinh.InsertIP_V2(g_IP, g_Line_Vung, g_KieuMayTinh, g_IsActive, g_No, g_Line_Gop,true);
                 
                if (bOK)
                {
                    new MessageBox.MessageBoxBA().Show("Tạo thông tin máy tính thành công");
                    this.Close();
                }
                else
                    new MessageBox.MessageBoxBA().Show("Lỗi tạo thông tin máy tính thành công");
            }
            else new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin địa chỉ IP của các máy con và line hoặc vùng.");
        }
    }
}