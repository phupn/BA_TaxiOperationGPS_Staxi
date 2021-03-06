using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using System.Data.OleDb;
using Taxi.Business;

namespace Taxi.GUI
{
   

    public partial class frmImportTenLaiXeTuExcel : Form
    {
        private List <clsXeLaiXe> g_ListXeLaiXe ;
        private DateTime g_GioHienTaiServer;
        public frmImportTenLaiXeTuExcel(DateTime GioHienTaiServer)
        {
            InitializeComponent();
            g_ListXeLaiXe = new List<clsXeLaiXe> ();
            g_GioHienTaiServer = GioHienTaiServer;
          
        }
        private void frmImportTenLaiXeTuExcel_Load(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            /// Update ten lái xe
             

            bool bError = false;
            if (g_ListXeLaiXe != null && g_ListXeLaiXe.Count > 0)
            {
                foreach (clsXeLaiXe objXeLaiXe in g_ListXeLaiXe)
                {
                    try
                    {
                        KiemSoatXeLienLac.UpdateTenLaiXe(objXeLaiXe.SoHieuXe, objXeLaiXe.GioRa, g_GioHienTaiServer , objXeLaiXe.TenLaiXe);
                    }
                    catch (Exception ex)
                    {
                        bError = true;
                    }
                }
            }
            MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
            if (bError)
            {                
                msg.Show("Có một số xe chưa nhập được do lỗi định dạng file Excel. Bạn sử dụng phần nhập bằng tay để nhập lại hoặc sửa lại định dạng file Excel.","Thông báo ");
                
            }
            else msg.Show("Cập nhật thông tin xe thành công.", "Thông báo ");
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            g_ListXeLaiXe.Clear();
            this.openFileDialog1.FileName = "*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = StringTools.TrimSpace(openFileDialog1.FileName); 

                txtPath.Text = filename;
                if (filename.Length > 0)
                {

                    string m_sConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filename + "; Extended Properties=\"Excel 8.0;HDR=YES\"";

                    OleDbConnection conn = new OleDbConnection(m_sConn);
                    conn.Open();

                    // SoHieuXe
                    // TenLaiXe
                    // SoThe
                    // GioRa

                    OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("SELECT SoHieuXe,TenLaiXe,SoThe,GioRa FROM [DSLaiXe$] ", conn);

                    OleDbDataReader rdr; //= new OleDbDataReader();
                    rdr = cmd.ExecuteReader();

                     

                    while (rdr.Read())
                    {
                        try
                        {
                            int iSoHieuXe = Convert.ToInt32(rdr["SoHieuXe"].ToString());
                            string GioRa = rdr["GioRa"].ToString();
                            string SoThe = Convert.ToString(rdr["SoThe"].ToString());
                            clsXeLaiXe objXeLaiXe = new clsXeLaiXe(this.GetSoHieuXe(iSoHieuXe), rdr["TenLaiXe"].ToString(), this.GetGioRa(GioRa, g_GioHienTaiServer ), SoThe);
                            g_ListXeLaiXe.Add(objXeLaiXe);
                        }
                        catch (Exception ex)
                        {
                            // loại bỏ các dòng lỗi
                        }
                    }

                    dataGridView1.DataSource = g_ListXeLaiXe;
                    

                    rdr.Close();
                    conn.Close();

                    if ((g_ListXeLaiXe != null) && (g_ListXeLaiXe.Count>0))
                    {
                        btnImport.Enabled = true;
                    }
                }
            }
        }
        /// <summary>
        /// hàm nhận mộ số hiệu xe, chuyển đổi về chuỗi
        /// iSoHieuXe =1 ---> 001
        /// iSoHieuXe  11 --> 011
        /// iSoHieuXe  111 --> 111
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        private string GetSoHieuXe(int iSoHieuXe)
        {

            string sSoHieuXe="";
            if (iSoHieuXe > 0 && iSoHieuXe <= 9999)
            {
                sSoHieuXe = Convert.ToString(iSoHieuXe);
                while (sSoHieuXe.Length < 3)
                {
                    sSoHieuXe = "0" + sSoHieuXe;
                }
            }
            return sSoHieuXe;
        }

        /// <summary>
        /// gio ra có dạng 
        /// GioRa = 6 --> '06:00:00 01/12/2009'
        /// GioRa = 6.3 --> '06:30:00 01/12/2009'
        /// else --> DateTime.MinValue
        /// </summary>
        /// <param name="GioRa"></param>
        /// <param name="GioHienTaiServer"></param>
        /// <returns></returns>
        private DateTime GetGioRa(string GioRa, DateTime GioHienTaiServer)
        {
            try
            {
                DateTime retDate;
                int Gio = 0; int Phut = 0;
                if (GioRa.Contains("."))
                {
                    Gio  = Convert.ToInt32(  GioRa.Substring(0, GioRa.IndexOf(".") ));
                    Phut = Convert.ToInt32(GioRa.Substring(GioRa.IndexOf(".") + 1, GioRa.Length - (GioRa.IndexOf(".") + 1)));
                    if (Phut == 3) Phut = 30;
                }
                else
                {
                    Gio = Convert.ToInt32(GioRa);
                    Phut = 0;
                }
                retDate = new DateTime(GioHienTaiServer.Year, GioHienTaiServer.Month, GioHienTaiServer.Day, Gio, Phut, 0);
                return retDate;
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        
    }
}