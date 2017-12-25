using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBC_5_6_SuCoVeThe : Form
    {
        private DataTable G_ReportDataSoure;

        public frmBC_5_6_SuCoVeThe()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string SoHieuXe = txtSoXe.Text.Trim();
            DateTime TuNgay = calTuNgay.Value;
            DateTime DenNgay = date_DenNgay.Value;
            G_ReportDataSoure = TimKiem_BaoCao.GROUP_BC_SuCoVeThe(SoHieuXe, TuNgay, DenNgay);
            //string NoiDungSuCo = e.Row.Cells["NoiDungSuCo"].Value.ToString();

            if (G_ReportDataSoure != null)
            {
                foreach (DataRow row in G_ReportDataSoure.Rows)
                {
                    if (row["SoHieuXe"] != "")
                    {
                        string strSoHieuXe = row["SoHieuXe"].ToString();
                        if (strSoHieuXe.StartsWith("1") || strSoHieuXe.StartsWith("81"))
                        {
                            row["DonVi"] = "HN";
                        }
                        else if (strSoHieuXe.StartsWith("2") || strSoHieuXe.StartsWith("82"))
                        {
                            row["DonVi"] = "CP";
                        }
                        else if (strSoHieuXe.StartsWith("3") || strSoHieuXe.StartsWith("83"))
                        {
                            row["DonVi"] = "TOU";
                        }
                        else if (strSoHieuXe.StartsWith("4") || strSoHieuXe.StartsWith("84"))
                        {
                            row["DonVi"] = "3A";
                        }
                        else if (strSoHieuXe.StartsWith("6") || strSoHieuXe.StartsWith("86"))
                        {
                            row["DonVi"] = "JAC";
                        }
                        else
                        {
                            row["DonVi"] = "GROUP";
                        }
                    }
                }
            }

            gridEX.DataSource = G_ReportDataSoure;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = String.Format("BC_5_6_SuCoVeThe{0:dd_MM_yyyy}.xls", calTuNgay.Value);
            saveFileDialog.FileName = FilenameDefault;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                gridEXExporter.Export((Stream)objFile);
                new MessageBox.MessageBox().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

        private void frmBC_5_5_XeGapSuCo_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();
            calTuNgay.Value = dateCurrent.Date;
            date_DenNgay.Value = dateCurrent;
        }

        private void gridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            
            
        }
    }
}
