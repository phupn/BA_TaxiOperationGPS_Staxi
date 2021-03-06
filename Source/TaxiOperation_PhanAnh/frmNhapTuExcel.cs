using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business.ThongTinPhanAnh;
using Janus.Windows.GridEX;
using System.IO;
using Taxi.Business;
using System.Data.OleDb;

namespace Taxi.GUI
{
    public partial class frmNhapTuExcel : Form
    {
        private string g_Filename = string.Empty;
        
        public frmNhapTuExcel()
        {
            InitializeComponent();
        }
        private void frmNhapTuExcel_Load(object sender, EventArgs e)
        {
            btnChonFile.Enabled = true;
            btnNhap.Enabled = false;
        }
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                g_Filename =StringTools.TrimSpace (openFileDialog1.FileName);
                if (g_Filename.Length <= 0)
                {
                    MessageBox.MessageBox ms = new Taxi.MessageBox.MessageBox();
                    ms.Show(this, "Bạn chọn file để nhập dữ liệu.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK);
                    btnChonFile.Enabled = true;
                    btnNhap.Enabled = false;
                }
                else
                {
                    txtPath.Text = g_Filename;
                    btnChonFile.Enabled = true;
                    btnNhap.Enabled = true ;
                }
            }
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (g_Filename.Length > 0)
            {
                NhapTuFileExcel(g_Filename);
            }
        }

        private void NhapTuFileExcel(string filename)
        {
            List<ThongTinPhanAnh> lstPhanAnh = new List<ThongTinPhanAnh>();
            try
            {
                string m_sConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filename + "; Extended Properties=\"Excel 8.0;HDR=YES\"";

                OleDbConnection conn = new OleDbConnection(m_sConn);
                conn.Open();

                OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("SELECT  MaTT, KQGQ FROM [Sheet1$]", conn);

                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader(); 

                while (rdr.Read())
                {
                    ThongTinPhanAnh phanAnh = new ThongTinPhanAnh();
                    phanAnh.MaThongTin = StringTools.TrimSpace ( rdr["MaTT"].ToString());
                    phanAnh .KetQua =  StringTools.TrimSpace (rdr["KQGQ"].ToString());
                    lstPhanAnh.Add(phanAnh);
                }
                rdr.Close();
                conn.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.MessageBox ms = new Taxi.MessageBox.MessageBox();
                ms.Show(this, "Có lỗi xảy ra, bạn cần kiểm tra lại cấu trúc file có đúng format đã định.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK);
            }
            // Nhập vào database
            List<string> lstLog = new List<string> ();
            if (lstPhanAnh != null && lstPhanAnh.Count > 0)
            {
                
                foreach (ThongTinPhanAnh phanAnh in lstPhanAnh )
                {
                    if (phanAnh.MaThongTin!=null && phanAnh.MaThongTin.Length > 0)
                    {
                        if(ThongTinPhanAnh.UpdateKetQuaGiaiQuyet(phanAnh.MaThongTin, phanAnh.KetQua))
                        {
                            lstLog.Add(string.Format("Mã thông tin {0} : CẬP NHẬT THÀNH CÔNG",phanAnh.MaThongTin));
                        }
                        else
                        {
                            lstLog.Add(string.Format("Mã thông tin {0} : CẬP NHẬT LỖI - HOẶC KHÔNG TỒN TẠI",phanAnh.MaThongTin));
                        }
                    }
                }

            }
            txtKetQua.Lines = lstLog.ToArray();
        }
    }
}