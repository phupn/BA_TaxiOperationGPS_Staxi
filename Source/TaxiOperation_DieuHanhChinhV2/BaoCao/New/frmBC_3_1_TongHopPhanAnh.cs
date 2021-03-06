using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Taxi.Business.ThongTinPhanAnh;
using Taxi.Utils;

namespace TaxiOperation_DieuHanhChinh
{
    public partial class frmBC_3_1_TongHopPhanAnh : Form
    {
        public frmBC_3_1_TongHopPhanAnh()
        {
            InitializeComponent();
        }
        private void frmBC_3_1_TongHopPhanAnh_Load(object sender, EventArgs e)
        {
            this.ActiveControl = calTuNgay;
            calTuNgay.Focus();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (calDenNgay.Value < calTuNgay.Value)
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc lớn hơn hoặc bằng ngày bắt đầu","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
                grdTongHop.DataMember = "tblTongHop";
                grdTongHop.DataSource = objPhanAnh.GetReport(calTuNgay.Value, calDenNgay.Value);
                btnExportExcel.Enabled = true;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_TongHop_PhanAnh.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                if ( MessageBox.Show("Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
            }
            btnExportExcel.Enabled = false;
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled= false ;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {            
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false ;

        }
        #region Xu li hotkey
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData == Keys.Escape )
            {
                this.Close();
                return true;
            }
            else if(keyData== Keys.T)
            {
                calTuNgay.Focus();
                return true;
            }
            else if(keyData == Keys.D)
            {
                calDenNgay.Focus();
                return true;
            }
            else if (keyData == Keys.L)
            {
                btnRefresh.Focus();
                return true;
            }
            else if (keyData == Keys.X)
            {
                btnExportExcel.Focus();
                return true;
            }
            return false;
        }
        #endregion

      
        #region xu li mui ten
        private void calTuNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right )
            {
                calDenNgay.Focus();
            }
        }

        private void calDenNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnRefresh.Focus();
            }
            else if(e.KeyCode == Keys.Left )
            {
                calTuNgay.Focus();
            }
        }

        private void btnRefresh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnExportExcel.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                calDenNgay.Focus();
            }
        }

        private void btnExportExcel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                calTuNgay.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                btnRefresh.Focus();
            }
        }
        #endregion

       
    }
}