using System;
using Taxi.Business;
using Taxi.Controls.Base;

namespace TaxiApplication.GUI
{
    public partial class frmDSLaiXe : FormBase
    {
        #region===Form===
        public frmDSLaiXe()
        {
            InitializeComponent();
        }
        private void frmDSLaiXe_Load(object sender, EventArgs e)
        {
            ucDSLaiXe.SetListNhanVien(CommonBL.ListDriver_Active);
        }
        #endregion
    }
}
