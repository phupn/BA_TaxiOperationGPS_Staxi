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
    public partial class frmNhapThoiGianCheckOutCuongChe : Form
    {
        private DateTime mThoiDiemCheckOut = DateTime.MinValue;

        public DateTime ThoiDiemCheckOut
        {
            get { return mThoiDiemCheckOut; }
             
        }

        public frmNhapThoiGianCheckOutCuongChe()
        {
            InitializeComponent();
        }

        public frmNhapThoiGianCheckOutCuongChe(DateTime ThoiDiemCheckIn)
        {
            InitializeComponent();
            try
            {
                lblThoiDiemDangNhap.Text = ThoiDiemCheckIn.ToString("HH:mm:ss dd/MM/yyyy");

                DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                if (ThoiDiemCheckIn.Add(new TimeSpan(8, 0, 0)) > timeServer)
                {
                    calThoiDiemDangXuat.Value = timeServer;
                }
                else calThoiDiemDangXuat.Value = ThoiDiemCheckIn.Add(new TimeSpan(8, 0, 0)); // thiết lập bằng một ca làm việc
        
            }
            catch (Exception ex )
            {
            }
        }

        
        private void btnChon_Click(object sender, EventArgs e)
        {
            mThoiDiemCheckOut = calThoiDiemDangXuat.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }




    }
}