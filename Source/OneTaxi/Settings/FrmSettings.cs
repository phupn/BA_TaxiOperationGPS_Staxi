using OneTaxi.Controls.Base.Forms;
using OneTaxi.Utils.Settings;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OneTaxi.Settings
{
    public partial class FrmSettings : FormBase
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        private OneTaxiSettings Settings;

        private void FrmSettings_Load(object sender, System.EventArgs e)
        {
            try
            {
                // Get "My Documents" folder
                string path = Application.StartupPath;
                path = Path.Combine(path, "Settings");

                // Create folder if it doesn't already exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                // Initialize settings
                Settings = new OneTaxiSettings();
                Settings.SettingsPath = Path.Combine(path, "Settings.xml");
                Settings.EncryptionKey = "binhanh.vn";

                lblMsg.Text = string.Empty;
                lupModule.Bind();
                Settings.Load();
                panelInput1.Fill(Settings);
            }
            catch (Exception ex) {
                //MessageBox.Show(ex.Message);            
            }
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            panelInput1.ParseTo(Settings, false);
            Settings.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            panelInput1.ParseTo(Settings, false);
            if (!Settings.CheckConnect())
            {
                lblMsg.Text = "Lỗi kết nối đến máy chủ";
                lblMsg.ForeColor = Color.Red;
            }
            else
            {
                lblMsg.Text = "Kết nối thành công";
                lblMsg.ForeColor = Color.Blue;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
