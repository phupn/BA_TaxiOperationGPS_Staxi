using System;
using System.Windows.Forms;
using Taxi.Business.AutoUpdate;
using Taxi.Controls.Base;
using Taxi.Data.FastTaxi;
using Taxi.Utils;

namespace Taxi.Controls.VersionInfo
{
    public partial class FrmRequired : FormBase
    {
        public SYS_VersionInfo versionInfo;
        public FrmRequired()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, System.EventArgs e)
        {
            UpdateStatus("Đang khởi động lại");
            Application.Restart();
        }

        private void btnDeSau_Click(object sender, System.EventArgs e)
        {
            UpdateStatus("Để sau");
            this.Close();
        }

        private void FrmRequired_Load(object sender, System.EventArgs e)
        {
            var info = AutoUpdate.GetVersionNew(Global.Module);
            txtDescription.Text = info.Description;
            lblVer.Text = info.Version;
            lblHanCapNhat.Text = info.UpdateDate.ToString("HH:mm dd/MM/yyyy");
        }
        private void UpdateStatus(string name)
        {
            try
            {
                versionInfo.LastUpdate = versionInfo.GetTimeServer();
                versionInfo.Status = name;
                versionInfo.IsRequired = false;
                versionInfo.Save();
            }
            catch (Exception ex) { 
            
            }
        }
    }
}
