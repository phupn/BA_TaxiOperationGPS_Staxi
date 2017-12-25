using System.Windows.Forms;
using Taxi.Common.Attributes;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.FastTaxis.TaxiChieuVe;

namespace Taxi.Controls.FastTaxis.TaxiTrip
{
    public partial class frmListBooking : FormBase
    {
        #region Field
        public Services.FastTaxi_OperationService.Booking[] Books { get; set; }
        public Services.FastTaxi_OperationService.Booking Book { get; set; }
        public Taxi.Services.FastTaxi_OperationService.TripBookingsSend rs { get; set; }
        public float G_TongTien { set; get; }
        #endregion

        #region frmListBooking
        public frmListBooking()
        {
            InitializeComponent();
        }
        #endregion

        #region EnterBooking
        /// <summary>
        /// thực hiện nhận book đã được chọn trên lưới.
        /// </summary>
        [MethodWithKey(Keys=Keys.Enter)]
        public void EnterBooking()
        {
            Book = gridView_Bookings.GetFocusedRow().As<Services.FastTaxi_OperationService.Booking>();
            Taxi.Services.FastTaxi_OperationService.TimerSendTripTimerSendTripAnswer item = new Services.FastTaxi_OperationService.TimerSendTripTimerSendTripAnswer()
            {
                BookID = Book.PK_BooID,
                Trip = rs.TripID,
                XNCode = rs.XNCode,
                Money = G_TongTien
            };
            if (!TaxiReturn_Process.OperationAnswer2(item))
            {
                new MessageBox.MessageBoxBA().Show("Cuốc này khách hàng đã hủy.");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        #endregion
        
        #region Sự kiện
        private void frmListBooking_Load(object sender, System.EventArgs e)
        {
            shGridControl_Bookings.DataSource = Books;
            shGridControl_Bookings.Refresh();
            shGridControl_Bookings.Focus();
            gridView_Bookings.FocusedRowHandle = 0;
            shProgressBar1.EditValue = 300; 
            timer_ThoiGianXuLy.Start();
        }
        private void btnChapNhan_Click(object sender, System.EventArgs e)
        {
            EnterBooking();
        }

        private void btnHuyDieu_Click(object sender, System.EventArgs e)
        {
            Book = null;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            Book = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                EnterBooking();
            }
        }
        #endregion

        private void timer_ThoiGianXuLy_Tick(object sender, System.EventArgs e)
        {
            shProgressBar1.EditValue = shProgressBar1.EditValue.To<int>() - 1;
            if (shProgressBar1.EditValue.To<int>() <= 0)
            {
                timer_ThoiGianXuLy.Stop();
                this.Close();
            }
        }

        private void shProgressBar1_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            int sophut = (e.Value.To<int>() / 60);
            int soGiay = e.Value.To<int>() - sophut * 60;
            e.DisplayText = string.Format("Còn lại {0}:{1}", sophut, soGiay);
        }
    }
}
