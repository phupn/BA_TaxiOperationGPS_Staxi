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
    public partial class frmThemThoatCuoc999 : Form
    {
        private int g_Vung;
        private int g_SoCuocGioiHan;
        private int g_SoPhutGioiHan;
        private bool g_IsAdd = false;

        public frmThemThoatCuoc999()
        {
            InitializeComponent();
        }
         
        public frmThemThoatCuoc999(int vung,int soCuocGoiGioiHan, int soPhutGioiHan,  bool IsAdd)
        {
            InitializeComponent(); 

            g_IsAdd = IsAdd;
            g_Vung  = vung;
            g_SoCuocGioiHan = soCuocGoiGioiHan;
            g_SoPhutGioiHan = soPhutGioiHan; 

            if (!IsAdd)
            {
                txtVung.Text = vung.ToString();
                txtVung.Enabled = false;
                txtGioiHanSoCuocDuocBat.Text = soCuocGoiGioiHan.ToString();
                txtSoPhutGioiHan.Text = soPhutGioiHan.ToString();
            }
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {            
            bool bOK = false;
            MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
            // validate du lieu
            
            #region Validate
            if (g_IsAdd)
            {
                if (!int.TryParse(txtVung.Text, out g_Vung))
                {

                    msg.Show(" Bạn phải nhập chính xác vùng. Vùng là kiểu số.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK); 
                     return;
                }
                if (g_Vung <= 0)
                {
                   
                     msg.Show(" Bạn phải nhập chính xác vùng. Vùng là kiểu số và lớn hơn 0.", "Thông báo"  , Taxi.MessageBox.MessageBoxButtonsBA.OK);
                     return;

                }
                // kiểm trả vùng nằm trong vùng cho phép
                if (!CheckVungNamTrongVungCauHinh(g_Vung))
                {

                    msg.Show(" Bạn phải nhập chính xác vùng. Vùng phải nằm trong danh sách vùng cho phép. Nếu thiếu bạn phải cấu hình phần vùng của taxi.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                    return;
                }
            }
            if (!int.TryParse(txtGioiHanSoCuocDuocBat.Text, out g_SoCuocGioiHan))
            {
               
                 msg.Show(" Bạn phải nhập chính xác số cuốc giới hạn cho phép bật 999. Số cuốc là kiểu số.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                    return;
            }
            if (g_SoCuocGioiHan <= 0)
            {
               
                 msg.Show(" Bạn phải nhập chính xác số cuốc giới hạn. Số cuốc là kiểu số và lớn hơn 0.", "Thông báo"  , Taxi.MessageBox.MessageBoxButtonsBA.OK);
                    return;

            }

            if (!int.TryParse(txtSoPhutGioiHan.Text , out g_SoPhutGioiHan))
            {
                
                 msg.Show(" Bạn phải nhập chính xác số phút giới hạn. Số phút giới hạn là kiểu số.", "Thông báo" , Taxi.MessageBox.MessageBoxButtonsBA.OK);
                    return;
            }
            if (g_SoPhutGioiHan  <= 0)
            {  
                msg.Show(" Bạn phải nhập chính xác số phút giới hạn. Số phút giới hạn là kiểu số và lớn hơn 0.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                    return;

            }

            #endregion 
            
            // Insert update
            if (g_IsAdd)
            {
                // kiem tra ton tai chua
                DataTable dt = ThoatCuoc999.GetCauHinhByVung(g_Vung);
                if (dt != null && dt.Rows.Count > 0)
                {
                    msg.Show("Vùng đã được cấu hình. Bạn cần chọn vùng khác.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                    return;
                }

                if (ThoatCuoc999.InsertCauHinh(g_Vung, g_SoCuocGioiHan, g_SoPhutGioiHan, ThongTinDangNhap.USER_ID))
                {
                    msg.Show(" Tạo mới thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                }
                else
                {
                    msg.Show(" Lỗi thêm mới thoát cuốc 999.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                }
            }
            else
            {
                if (ThoatCuoc999.UpdateCauHinh (g_Vung, g_SoCuocGioiHan, g_SoPhutGioiHan, ThongTinDangNhap.USER_ID))
                {
                    msg.Show(" Cập nhật mới thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                }
                else
                {
                    msg.Show(" Lỗi cập nhật thoát cuốc 999.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                }
            }
            this.Close();
        }

        /// <summary>
        /// check vung nhan năm trong vùng cấu hình.
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if (ThongTinCauHinh.CacVungTongDai != null && ThongTinCauHinh.CacVungTongDai.Length > 0)
            {
                string[] arrVung = ThongTinCauHinh.CacVungTongDai.Split(";".ToCharArray());
                for (int i = 0; i < arrVung.Length; i++)
                {
                    if (Convert.ToInt32(arrVung[i]) == Vung)
                    {
                        bCheck = true; break;
                    }
                }
            }
            else bCheck = false;
            return bCheck;
        } 
    }
}