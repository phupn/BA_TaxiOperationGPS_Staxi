using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Taxi.Business.PhanAnh;
using Taxi.Business;
using Taxi.Utils;
using Janus.Windows.GridEX;

namespace Taxi.GUI
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
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập ngày kết thúc lớn hơn hoặc bằng ngày bắt đầu", "Thông báo",
                                                        Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                        Taxi.MessageBox.MessageBoxIconBA.Information);
            }
            else
            {
                PhanAnh objPhanAnh = new PhanAnh();
                grdTongHop.DataMember = "tblTongHop";
                grdTongHop.DataSource = objPhanAnh.GetBaoCaoTongHop(calTuNgay.Value, calDenNgay.Value.AddMinutes(1439));
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
                if (new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
                    //FileTools.OpenFileExcel(saveFileDialog1.FileName);
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

        private void btnExportExcelNew_Click(object sender, EventArgs e)
        {
            KetXuatBienBan(grdTongHop);
        }

        private void KetXuatBienBan(Janus.Windows.GridEX.GridEX parGridTongHop)
        {
            try
            {
                //1. Lay du lieu
                DataTable dtFile = (DataTable)parGridTongHop.DataSource;
                DataSet ds = new DataSet();
                ds.Tables.Add(dtFile.Copy());
                //2. Truyen du lieu di
                if (parGridTongHop.SelectedItems.Count > 0)
                {
                    int rowIndex = ((GridEXSelectedItem)parGridTongHop.SelectedItems[0]).Position;
                    int reportType = ConstParam.TongHopPhanAnh;
                    frmPreviewReport frmPre = new frmPreviewReport(ds, reportType, rowIndex);
                    frmPre.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KetXuatBienBan", ex);
            }
        }
    }
}