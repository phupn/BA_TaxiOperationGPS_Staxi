using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using System.IO;
using System.Globalization;

namespace Taxi.GUI
{
    public partial class frmThongTinNhanVienLamViec : Form
    {
        private bool g_bChonDangLamViec = false;

        public frmThongTinNhanVienLamViec()
        {
            InitializeComponent();
        }

        private void frmThongTinNhanVienLamViec_Load(object sender, EventArgs e)
        {

             
           
            DateTime timerServer = DieuHanhTaxi.GetTimeServer();
            calTuNgay.Text = string.Format("{0:HH:mm:ss dd/MM/yyyy}", timerServer);
            calDenNgay.Text = string.Format("{0:HH:mm:ss dd/MM/yyyy}", timerServer);         
            gridNhanVienLamViec .DataMember = "lstNhanvienDangLamViec";
            gridNhanVienLamViec.SetDataBinding(ThongTinDangNhap.GetNhungNhanVienDangLamViec() , "lstNhanvienDangLamViec");
            g_bChonDangLamViec = true;
            btnRefresh.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        private void LoadNhanVienDangLamViec(DateTime TuNgayGio, DateTime DenNgayGio)
        {
             gridNhanVienLamViec.DataMember = "lstNhanvienDangLamViec";
            gridNhanVienLamViec.SetDataBinding(ThongTinDangNhap.GetDSNhungNhanVienLamViec(calTuNgay.Value,calDenNgay.Value), "lstNhanvienDangLamViec");
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false ;

            LoadNhanVienDangLamViec(calDenNgay.Value, calDenNgay.Value);
            g_bChonDangLamViec = false;
        }

        /// <summary>
        /// đăng xuất cưỡng chế dùng khi người dùng quên không check out ra khoi hệ thống
        /// phải có thời gian dăn xuất = null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckOutCuongChe_Click(object sender, EventArgs e)
        {
            new MessageBox.MessageBoxBA().Show(this, "Đăng xuất cưỡng chế vẫn ghi nhận thời điểm ra khỏi hệ thống. Bạn cần hỏi người bị cưỡng chế đã ra khỏi hệ thống thời điểm nào.Sau đó nhập vào form thời gian cưỡng chế.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);

            if (new MessageBox.MessageBoxBA().Show(this, "Bạn có đồng ý đăng xuất cưỡng chế không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
            {

                DateTime ThoiDiemCheckIn = DateTime.MinValue;
                DateTime ThoiDiemCheckOut = DateTime.MinValue;
                string UserName = "";
                string IPAddress = "";
                gridNhanVienLamViec.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;

                if (gridNhanVienLamViec.SelectedItems.Count > 0)
                {
                    // [Username]
                    //,[ThoiDiemCheckIn]
                    //,[IPAddress]

                    GridEXRow dr = gridNhanVienLamViec.SelectedItems[0].GetRow();
                    UserName = dr.Cells["Username"].Text;
                    IPAddress = dr.Cells["IPAddress"].Text;

                    ThoiDiemCheckIn = DateTime.Parse(dr.Cells["ThoiDiemCheckIn"].Text, new CultureInfo("vi-VN", false));
                    
                    frmNhapThoiGianCheckOutCuongChe frm = new frmNhapThoiGianCheckOutCuongChe(ThoiDiemCheckIn);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ThoiDiemCheckOut = frm.ThoiDiemCheckOut;
                    }
                    else return;

                    if (ThoiDiemCheckOut != DateTime.MinValue)
                    {
                        if (ThongTinDangNhap.CheckOutByTime(UserName, IPAddress, ThoiDiemCheckOut))
                        {
                            new MessageBox.MessageBoxBA().Show(this, "CheckOut thành công.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            btnRefresh.Enabled = false;
                            if (g_bChonDangLamViec)
                            {
                                gridNhanVienLamViec.DataMember = "lstNhanvienDangLamViec";
                                gridNhanVienLamViec.SetDataBinding(ThongTinDangNhap.GetNhungNhanVienDangLamViec(), "lstNhanvienDangLamViec");

                            }
                            else
                                LoadNhanVienDangLamViec(calDenNgay.Value, calDenNgay.Value);
                        }
                        else
                        {
                            new MessageBox.MessageBoxBA().Show(this, "Lỗi CheckOut bạn cần thực hiện lại, hoặc liên lạc với quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        }
                    }

                }
                else return;

            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

            string FilenameDefault = "NhanVienDangLamVien" + string.Format("{0:ddMMyyyy}",DateTime.Now) +  ".xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }
    }
}