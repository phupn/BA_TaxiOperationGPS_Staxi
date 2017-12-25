using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Data.G5;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    public partial class frmBC_1_10_BaoCaoCuocKhachTTDHDieuApp : FormBase
    {
        #region ==Form events==
        public frmBC_1_10_BaoCaoCuocKhachTTDHDieuApp()
        {
            InitializeComponent();
        }

        private void frmBC_1_10_BaoCaoCuocKhachTTDHDieuApp_Load(object sender, EventArgs e)
        {
            //Set center panel
            this.panHeader.Location = new Point((this.panTop.Width - this.panHeader.Width) / 2, (this.panTop.Height - this.panHeader.Height) / 2);
            this.panHeader.Anchor = AnchorStyles.None;
            dtpTuNgay.SetValue(DateTime.Now.Date);
            dtpDenNgay.SetValue(DateTime.Now);
        }
        #endregion

        #region==control events==
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatExcel();
        }
        #endregion

        #region ==method==
        /// <summary>
        /// Xuất grid ra excel
        /// </summary>
        /// <param name="fileNameDefault"></param>
        private void XuatExcel()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                DateTime tuNgay = (DateTime)dtpTuNgay.GetValue();
                DateTime denNgay = (DateTime)dtpDenNgay.GetValue();
                string fileNamDefault = "BaoCaoCuocKhachTTDHDieuApp_";
              //  string rptDate1 = string.Format("{0}-{1}", tuNgay.ToString(), denNgay.ToString());
                string rptDate = String.Format("{0}{1}{2}-{3}{4}{5}", tuNgay.Day, tuNgay.Month, tuNgay.Year, denNgay.Day, denNgay.Month, denNgay.Year);
                saveDialog.FileName = String.Format("{0}_{1}.xls", fileNamDefault, rptDate);
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx ";//|RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsPrint.AutoWidth = false;
                    switch (fileExtenstion)
                    {
                        case ".xls": grcBaoCaoCuocKhachTTDHDieuApp.ExportToXls(exportFilePath); break;
                        case ".xlsx": grcBaoCaoCuocKhachTTDHDieuApp.ExportToXlsx(exportFilePath); break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            if (MessageBox.Show("Xuất file thành công, bạn có muốn mở file ngay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                //try to open the file and let windows decide how to open it
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                        }
                        catch (Exception ex)
                        {
                            String msg = "Có lỗi không thể mở file." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string msg = "Có lỗi không thể lưu file." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error");
                    }
                }
            }
        }

        private void GetData()
        {
            DateTime tuNgay = (DateTime)dtpTuNgay.GetValue();
            DateTime denNgay = (DateTime)dtpDenNgay.GetValue();
            if (tuNgay>=denNgay)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn đến ngày", "Thông báo");
                btnXuatExcel.Enabled = false;
                return;
            }
            else
            {
                var model = G5_1_10_BCCuocKhachTTDHDieuApp.Inst.GetData(tuNgay,denNgay);
                if (model!=null && model.Count>0)
                {
                    grcBaoCaoCuocKhachTTDHDieuApp.DataSource = model;
                    btnXuatExcel.Enabled = true;
                }
                else
                {
                    grcBaoCaoCuocKhachTTDHDieuApp.DataSource = null;
                    btnXuatExcel.Enabled = false;
                    MessageBox.Show("Không tìm thấy dữ liệu nào", "Thông báo");
                }
            }
        }
        #endregion
    }
}
