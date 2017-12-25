using System.Windows.Forms;
using Taxi.Utils.Settings;

namespace StaxiManClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.Staxi_96_ic_launcher;
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            status_ServerInfo.Text = string.Format("{0}-{1}", ConnectionSetting.MySettingObject.DataSource, ConnectionSetting.MySettingObject.InitialCatalog);
            statusbar_Version.Text = Taxi.Utils.license.VersionInfo.Version_License();
        }
    }
}
