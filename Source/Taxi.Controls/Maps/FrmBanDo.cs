using System;
using Taxi.Controls.Base;

namespace Taxi.Controls.Maps
{
    public partial class FrmBanDo : FormBase
    {
        public FrmBanDo()
        {
            InitializeComponent();
            this.Text = "[F3-Tìm kiếm] - Bản đồ";
        }

        private void userMap1_AlterSearch(string ChuoiTimKiem)
        {
            if (ChuoiTimKiem != "")
                this.Text = string.Format("[F3-Tìm kiếm] - Bản đồ - Tìm kiếm [{0}]", ChuoiTimKiem);
            else this.Text = "[F3-Tìm kiếm] - Bản đồ";
        }

        private void userMap1_EventOk(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
