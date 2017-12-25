using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.Controls
{
    public partial class XeLienLacControl : UserControl
    {
        private KiemSoatXeLienLac mKSXeLienLac=new KiemSoatXeLienLac ();
      
        public XeLienLacControl()
        {
            InitializeComponent();

        }

        public delegate void XeLienLacChangeHandler(object XeLienLac,XeLienLacEventArgs XeLienLacInfo);
        // The event we publish
        public event XeLienLacChangeHandler OnXeLienLacChangeHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentTime"></param>
        /// <param name="KieuXeMatLienLac"></param>
        /// <param name="KSXeLien"></param>
        public void SetXeKSLienLac(KiemSoatXeLienLac KSXeLienLac)
        {
            mKSXeLienLac = KSXeLienLac;
            if(KSXeLienLac.IsMatLienLac )
                lblSoHieuXe.ForeColor = Color.Red;
            else lblSoHieuXe.ForeColor = Color.Blue ;
            lblSoHieuXe.Text = KSXeLienLac.SoHieuXe;
            
            lblThoiGianLienLacCuoi.Text = string.Format("{0: HH:mm}", KSXeLienLac.ThoiDiemBao);
            if (KSXeLienLac.TongDaiCheckCuoi == DateTime.MinValue)
            {
                lblTongDaiDaLienLacLanCuoi.Text = "00:00";
            }
            else
            {
                this.lblTongDaiDaLienLacLanCuoi.Text = string.Format("{0: HH:mm}", KSXeLienLac.TongDaiCheckCuoi);
            }
            this.lblViTri.Text = "";

            if (KSXeLienLac.LoaiChoKhach == LoaiChoKhach.ChoKhachDuongDai)
            {
                this.lblViTri.Text = KSXeLienLac.ViTriDiemDen;
                lblTongDaiDaLienLacLanCuoi.Text = string.Format("{0: dd/MM}", KSXeLienLac.ThoiDiemBao);
                 

            }
            if(KSXeLienLac.TrangThaiLaiXeBao==KieuLaiXeBao .BaoNghi) this.lblViTri.Text = KSXeLienLac.ViTriDiemBao;
            
            Refresh();
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            if (mKSXeLienLac.IsMatLienLac)
            {
                XeLienLacEventArgs XeInfo = new XeLienLacEventArgs(this.mKSXeLienLac.SoHieuXe);
                if (OnXeLienLacChangeHandler != null)
                {
                    OnXeLienLacChangeHandler(this, XeInfo);
                }
            }
        }
    }
}
