using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.QuanLyVe;
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.IO;
using Taxi.Business;
using System.Configuration;

namespace Taxi.GUI
{
    public partial class frmCauHinhChuyenChamSoc : Form
    {
        private int SeriVe = -1;

        public frmCauHinhChuyenChamSoc()
        {
            InitializeComponent();
          
        }
        private void frmTraCuu_Load(object sender, EventArgs e)
        {
            SetCauHinhChuyenCS();           
        } 
  
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
            try
            {
                this.SaveChuyenCSConfig(this.GetCauHinhChuyenCS());

                msgDialog.Show("Lưu thành công cấu hình CS. Chương trình tự động khởi động lại.");
                Application.Restart();
            }
            catch (Exception ex)
            {
               
                msgDialog.Show("Lỗi lưu thông tin cấu hình chuyển CS.");
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// - hàm thực hiện lưu vào config, thông tin ChuyenCS
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        private bool SaveChuyenCSConfig(string Value)
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["ChuyenCS"].Value = Value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string GetCauHinhChuyenCS()
        {
            if (rad1CS.Checked) return "1";
            else if (rad2CS.Checked) return "2";
            else return "0";
        }
        /// <summary>
        /// hàm thực hiện lấy thông tin trong file config, đặt lên GUI
        /// </summary>
        private void SetCauHinhChuyenCS()
        {
            string Value = Taxi.Business.Configuration.GetThongTinCauHinhChuyenCS();
            if (Value != null & Value.Length > 0)
            {
                if (Value == "2") rad2CS.Checked = true;
                else if (Value == "1") rad1CS.Checked = true;
                else radTongDaiTuXuLy.Checked = true;
            }
            else radTongDaiTuXuLy.Checked = true;
        }
           
    }
}