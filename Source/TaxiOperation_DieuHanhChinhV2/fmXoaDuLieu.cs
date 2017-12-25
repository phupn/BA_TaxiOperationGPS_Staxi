using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.GUI
{
	public partial class fmXoaDuLieu : Form
	{ 
        public fmXoaDuLieu()
		{
			InitializeComponent();
		}

		 

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongTinDangNhap.USER_ID.ToLower() == "admin")
            {
                int SoPhut = 0; int SoCuocGiuLai = 0;
                if (rad60.Checked) SoPhut = 60;
                else if (rad30.Checked) SoPhut = 30;
                else if (rad15.Checked) SoPhut = 15;
                else if (rad1000Cuoc.Checked) SoCuocGiuLai = 1000;
                else if (rad100Cuoc.Checked) SoCuocGiuLai = 100;

                if (SoCuocGiuLai == 0)
                {
                    if (SoPhut < 5) SoPhut = 5;
                    DieuHanhTaxi.XoaTuDongCacCuocKhachQuaLau(SoPhut, ThongTinCauHinh.CacVungTongDai);
                }
                else
                {
                    if (SoCuocGiuLai < 100) SoCuocGiuLai = 100;
                    DieuHanhTaxi.XoaTuDongCacCuocKhachQuaLau(SoCuocGiuLai);
                }
            }
        }

        
         
	}
}