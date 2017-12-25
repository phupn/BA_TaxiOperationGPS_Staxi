using System.Drawing;
using System.Windows.Forms;
using Taxi.Controls.Base;

namespace Taxi.Controls.FastTaxis.FormFastTaxi
{
    public partial class frmPopupSendFastTaxiFail : FormBase
    {
        public delegate void ThuHienGuiLai(SendFastTaxiData data);
        /// <summary>
        /// sự kiện gửi vào hàng đợi xử lý.
        /// </summary>
        public event ThuHienGuiLai GuiLaiFastTaxi;
        public frmPopupSendFastTaxiFail()
        {
            InitializeComponent();
        }
        public SendFastTaxiData Data { get; set; }

        private void shButton1_Click(object sender, System.EventArgs e)
        {
            if (GuiLaiFastTaxi != null)
            {
                GuiLaiFastTaxi(Data);
            }
            this.Close();
        }

        private void shButton2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmPopupSendFastTaxiFail_Load(object sender, System.EventArgs e)
        {
            if (Data != null)
            {
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height);
                string msg = "[" +Data.Msg+": Gửi thất bại]" + System.Environment.NewLine;
                msg += "[SDT]:" + Data.PhoneNumber + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(Data.DiaChiDon)) msg += "[Địa chỉ đón]:" + Data.DiaChiDon  +System.Environment.NewLine;
                if (!string.IsNullOrEmpty(Data.XeDon)) msg += "[Xe đón]:" + Data.XeDon + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(Data.XeNhan)) msg += "[Xe Nhận]:" + Data.XeNhan + System.Environment.NewLine;
                txtMsg.Text = msg;
            }
        }
    }
}
