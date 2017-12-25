using System;
using System.Drawing;
using DevExpress.XtraEditors;
using Taxi.Controls.Base;

namespace TaxiOperation_BanCo.Config
{
    public partial class frmConfigDHBanCo : FormBase
    {
        #region ---------------------Init Form---------------------------------

        public frmConfigDHBanCo()
        {
            InitializeComponent();
        }

        #endregion ------------------End of Init Form--------------------------

        #region ---------------------Load Form---------------------------------

        private void frmConfigDHBanCo_Load(object sender, EventArgs e)
        {
            //LoadData();
        }

        

        #endregion ----------------- End of Load Form--------------------------

        #region ---------------------Validate Form-----------------------------
        /// <summary>
        /// kiểm tra tính hợp lệ của form
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            return true;
        }

        #endregion ----------------- End of Validate Form----------------------

        #region ----------------- Process Methods------------------------------
        /// <summary>
        /// Check đã tồn tại bản ghi
        /// </summary>
        /// <returns></returns>
        private bool IsExistObject()
        {
            return true;
        }

        /// <summary>
        /// Xử lý lưu dữ liệu xuống db
        /// </summary>
        private void SaveForm()
        {
        }
        #endregion----------------- End of Process Methods---------------------

        #region ---------------------Event Handlers----------------------------
        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    groupControl_TrangThai.Size = new Size((this.Size.Width - 20) * 8 / 17, this.Size.Height);
        //    groupControl_Cauhinh.Size = new Size((this.Size.Width - 20) * 9 / 17, this.Size.Height);

        //    base.OnSizeChanged(e);
        //}
        #endregion ------------------End of Event Handlers---------------------

    }
}