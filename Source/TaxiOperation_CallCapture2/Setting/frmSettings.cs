using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils.Settings;
using TaxiOperation_CallCapture;

namespace Settings
{
    public partial class frmSettings : Form
    {
        // Declare application settings object
        private MySettings Settings;
        public frmSettings()
        {
            InitializeComponent();
            // Get "My Documents" folder
            string path = Application.StartupPath;
            path = Path.Combine(path, "Settings");

            // Create folder if it doesn't already exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // Initialize settings
            Settings = new MySettings();
            Settings.SettingsPath = Path.Combine(path, "Settings.xml");
            Settings.EncryptionKey = "sampleKey";
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadDefault();
        }

        /// <summary>
        /// Load mặc định
        /// </summary>
        private void LoadDefault()
        {
            // Load settings
            Settings.Load();
            //txtIPAddress.Text = Settings.IPAddress;
            txtDataSource.Text = Settings.DataSource;
            txtCatalog.Text = Settings.InitialCatalog;
            txtUsername.Text = Settings.UserID;
            txtPassword.Text = Settings.Password;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            TestConnection();
            Program.OpenDetailFormOnClose = true;

            this.Close();
        }

        private void SaveSetting()
        {
            // Save settings
            //Settings.IPAddress = txtIPAddress.Text.Trim();
            Settings.DataSource = txtDataSource.Text.Trim();
            Settings.InitialCatalog = txtCatalog.Text.Trim();
            Settings.UserID = txtUsername.Text.Trim();
            Settings.Password = txtPassword.Text.Trim();
            Settings.Save();

            Taxi.Utils.CommonUtils.MySettingObject = Settings;
        }

        private void TestConnection()
        {
            SaveSetting();

            if (Taxi.Business.DieuHanhTaxi.GetTimeServer() == DateTime.MinValue)
            {
                lblMessage.Text = "Lỗi kết nối đến máy chủ";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                return;
            }
            else
            {
                lblMessage.Text = "Kết nối thành công";
                lblMessage.ForeColor = Color.Blue;
                lblMessage.Visible = true;
                return;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            TestConnection();
        }
    }
}
