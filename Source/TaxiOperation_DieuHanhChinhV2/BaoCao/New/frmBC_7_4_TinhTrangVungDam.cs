using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Taxi.Utils;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    public partial class frmBC_7_4_TinhTrangVungDam : Form
    {
        public frmBC_7_4_TinhTrangVungDam()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TimKiem_BaoCao objTinhTrangVungDam = new TimKiem_BaoCao();
            DataTable dt = objTinhTrangVungDam.GROUP_BC_TinhTrangVungDam();

            grdVungDam.DataMember = "TongHop";
            grdVungDam.SetDataBinding(dt, "TongHop");

            gridEX1.DataMember = "TongHop";
            gridEX1.SetDataBinding(dt, "TongHop");
            btnExportExcel.Enabled = true;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BC_TinhTrangVungDam.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export((Stream)objFile);
                    if (MessageBox.Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                    {
                        FileTools.OpenFileExcel(saveFileDialog1.FileName);
                    }
                }
                btnExportExcel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi : " + ex.Message);
            }
        }

        private void frmBC_7_4_TinhTrangVungDam_Load(object sender, EventArgs e)
        {
            btnExportExcel.Enabled = false;
        }
    }
}