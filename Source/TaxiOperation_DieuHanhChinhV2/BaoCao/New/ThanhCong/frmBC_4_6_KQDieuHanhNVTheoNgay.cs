﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using ChartDirector;
using System.IO;
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.Threading;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.ThanhCong
{
    public partial class frmBC_4_6_KQDieuHanhNVTheoNgay : Form
    {
         
        private Taxi.GUI.fmProgress m_fmProgress = null;
        DataTable g_dtNVDienThoai;
        DataTable g_dtNVTongDai;

        public frmBC_4_6_KQDieuHanhNVTheoNgay()
        {
            InitializeComponent();          
        }        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            btnRefresh.Enabled = false;          
            btnExportExcel.Enabled = btnRefresh.Enabled;            

        }

        private void LoadNhanVien()
        {
            cboNhanVien.ValueMember = "USER_ID";
            cboNhanVien.DisplayMember = "FULLNAME";             
            DataTable dt = new Users().GetAllUserInfo();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cboNhanVien.Items.Add( dr["USER_ID"].ToString() + " - " + dr["FULLNAME"].ToString(), dr["USER_ID"].ToString());
                }
            }

            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {

                string NhanVienID = "";
                if ((cboNhanVien.SelectedIndex != 0) && (cboNhanVien.SelectedIndex != -1))
                {
                    NhanVienID = cboNhanVien.SelectedItem.Value.ToString();
                    if (NhanVienID == "000") NhanVienID = "";
                }
                if (NhanVienID.Length > 0)
                {
                    g_dtNVDienThoai = new Taxi.Business.TimKiem_BaoCao().GROUP_BC4_6_KetQuaDieuHanhNVTheoNgay(calTuNgay.Value, calDenNgay.Value, NhanVienID);
                    gridEX1.DataMember = "ListDienThoai";
                    gridEX1.SetDataBinding(g_dtNVDienThoai, "ListDienThoai");

                    btnExportExcel.Enabled = true;
                }
                else
                {
                    new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn phải chọn nhân viên để báo cáo.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
 
                }
            }
            else
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        } 
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            
            string NhanVienID = "";
            if ((cboNhanVien.SelectedIndex != 0) && (cboNhanVien.SelectedIndex != -1))
            {
                NhanVienID = cboNhanVien.SelectedItem.Value.ToString();
                if (NhanVienID == "000") NhanVienID = "";
            }
            NhanVienID = "dh100";
            g_dtNVDienThoai = new Taxi.Business.TimKiem_BaoCao().GROUP_BC4_6_KetQuaDieuHanhNVTheoNgay(calTuNgay.Value, calDenNgay.Value, NhanVienID);
            gridEX1.DataMember = "ListDienThoai";
            gridEX1.SetDataBinding(g_dtNVDienThoai, "ListDienThoai");

            m_fmProgress.lblDescription.Invoke(
               (MethodInvoker)delegate()
               {
                   m_fmProgress.lblDescription.Text = " Kết thúc ";
                   m_fmProgress.progressBar.Value = 100;
               }
           ); 


            if (m_fmProgress.Cancel)
            {
                // Set the e.Cancel flag so that the WorkerCompleted event
                // knows that the process was canceled.
                e.Cancel = true;
                return;
            }
            
            

        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. First we should hide the
            // modal Progress Form to unlock the UI. The we need to inspect our
            // response to see if an error occured, a cancel was requested or
            // if we completed succesfully.

            // Hide the Progress Form
            if (m_fmProgress != null)
            {
                m_fmProgress.Hide();
                m_fmProgress = null;
            }

            // Check to see if an error occured in the 
            // background process.
            if (e.Error != null)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                // new Taxi.MessageBox.MessageBox().Show("Processing cancelled.");
                return;
            }
        }

        private void gridKQDHNV_DienThoai_FormattingRow(object sender, RowLoadEventArgs e)
        {
            // tinh %

            try
            {
                if(int.Parse(e.Row .Cells["SoCuocTaxi"] .Value.ToString ()) != 0)
                    e.Row.Cells["PhanTramChuyenCham"].Text = string.Format("{0: ##.##}",  ((double.Parse(e.Row.Cells["SoCuocBiCham"].Value.ToString()) / double.Parse(e.Row.Cells["SoCuocTaxi"].Value.ToString()) * 100))); 
            }
            catch (Exception ex)
            {
                ////  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }
        private void gridKQDHNV_TongDai_FormattingRow(object sender, RowLoadEventArgs e)
        {
            try
            {
                if (int.Parse(e.Row.Cells["SoCuocTaxi"].Value.ToString()) != 0)
                    e.Row.Cells["PhanTramDonDuoc"].Text = string.Format("{0: ##.##}", ((double.Parse(e.Row.Cells["SoCuocDonDuoc"].Value.ToString()) / double.Parse(e.Row.Cells["SoCuocTaxi"].Value.ToString()) * 100)));
            }
            catch (Exception ex)
            {
                ////  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }
 
        private void editPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char  chr = Convert.ToChar(";");
            if(char.IsDigit ( e.KeyChar) || (e.KeyChar == (char) Keys.Back ) || (e.KeyChar == chr  ))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editSoChuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar ==(char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editPhut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

         
        private void btnPrint_Click(object sender, EventArgs e)
        {
           //// DataTable dtNVTongDai = CreateBangDuLieuChoReport_NVTongDai();
           // DataTable dtNVDienThoai = this.CreateBangDuLieuChoReport_NVDienThoai();
           //   frmInBaoCao frmPrint = new frmInBaoCao();
           //   frmPrint.InBaoCaoBieuMau16(Configuration.GetReportPath() + "\\Baocao_Bieumau16.rpt", dtNVDienThoai, dtNVTongDai, calTuNgay.Value, calDenNgay.Value);  
           //   frmPrint .ShowDialog();
        }

         

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BC_4_6_BaoCaoKQNhanVienDieuHanh_" + cboNhanVien.SelectedItem.Text.UnicodeFormat().Replace(' ','_') + ".xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEX2.DataMember = "ListDienThoai";
                gridEX2.SetDataBinding(g_dtNVDienThoai, "ListDienThoai");
                gridEXExporter1.GridEX = gridEX2;
                gridEXExporter1.Export((Stream)objFile);
                Thread.Sleep(200);
                objFile.Close();

                if (new Taxi.MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
                 
            } 
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
          //  btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editSoChuong_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhut_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
          //  btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
 
 
        private void timeThoiGianDamThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
         //   btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            //   btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            //   btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        

       
    }
}