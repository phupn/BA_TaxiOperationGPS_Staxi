using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Janus.Windows.GridEX;

namespace Taxi.GUI 
{
    public partial class frmBaoCaoBieuMau14 : Form
    {
         
       
        List<BaoCaoBieuMau14> ListBC14 = new List<BaoCaoBieuMau14>();
        public frmBaoCaoBieuMau14()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            //DateTime dateCurrent = DieuHanhTaxi.GetTimeServer ();

             
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDulieuBaoCao_BieuMau14(); 
        }

        /// <summary>
        /// HÀM LẤY THÔNG TIN GẦN ĐÂY NHẤT XE TRONG MỘT KHOẢNG THỜI GIAN NÀO ĐÓ CỦA XE
        /// 
        /// </summary>
        private void LoadDulieuBaoCao_BieuMau14()
        {




            // lay trang thai cua tung xe insert vao bieu 14

            DataTable dt = new DataTable();
            dt = TimKiem_BaoCao.GetTrangThaiBaoRa_Ve_TrongKhoang(calTuThoiDiem.Value, calDenThoiDiem.Value);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                //   [SoHieuXe]
                //,[ThoiDiemBao]
                //,[MaLaiXe]
                //,[ViTriDiemBao]
                //,[ViTriDiemDen]
                //,[LoaiChoKhach]
                //,[TrangThaiLaiXeBao]
                //,[GhiChu]
                //,[IsHoatDong] =
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BaoCaoBieuMau14 objBC14 = new BaoCaoBieuMau14();
                    objBC14.Sohieutaxi = dt.Rows[i]["SoHieuXe"].ToString();
                    objBC14.Tenlaixe = dt.Rows[i]["MaLaiXe"].ToString();
                    if (dt.Rows[i]["IsHoatDong"] == null)
                    {
                        if (dt.Rows[i]["IsHoatDong"].ToString() == "1")
                        {
                            objBC14.Is_Hoatdong = true;
                            objBC14.Khonghoatdong = false;
                            objBC14.Giorahoatdong = DateTime.Parse(dt.Rows[i]["ThoiDiemBao"].ToString());
                            objBC14.GioveGara = DateTime.MinValue;

                            if (calTuThoiDiem.Value.Day != objBC14.Giorahoatdong.Day)
                            {
                                TimeSpan timeSpan = calTuThoiDiem.Value - objBC14.Giorahoatdong;
                                objBC14.Ghichu = timeSpan.Days + " ngày";
                            }
                        }
                        else
                        {
                            objBC14.Is_Hoatdong = false;
                            objBC14.Khonghoatdong = true;
                            objBC14.Giorahoatdong = DateTime.MinValue;
                            objBC14.GioveGara = DateTime.Parse(dt.Rows[i]["ThoiDiemBao"].ToString());
                        }

                    }
                    else  // xe chua hoat dong va chua ve
                    {

                        objBC14.Sohieutaxi = dt.Rows[i]["SoHieuXe"].ToString();
                        objBC14.Is_Hoatdong = false;
                        objBC14.Khonghoatdong = false;
                        objBC14.Giorahoatdong = DateTime.MinValue;
                        objBC14.GioveGara = DateTime.MinValue;
                        objBC14.Ghichu = "xe cần kiểm tra";

                    }
                    ListBC14.Add(objBC14);
                }
            }
            gridBaoCaoBieuMau1.DataSource = ListBC14;
           // btnPrint.Enabled = true;
            //btnExportExcel.Enabled = true;
        }
        
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
             //frmInBaoCao frmPrint = new frmInBaoCao();
             //frmPrint.InBaoCaoBieuMau14(Configuration.GetReportPath() + "\\Baocao_Bieumau14.rpt", ListBC14, calTuThoiDiem.Value );
             //frmPrint.ShowDialog(this);
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau14.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBox().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }


       
 

        private BaoCaoBieuMau14 Hienthiluoi_Bieu14(DataRow rowBC14)
        {

            BaoCaoBieuMau14 objBC14 = new BaoCaoBieuMau14();
            objBC14.Sohieutaxi = rowBC14["Sohieuxe"].ToString();
            objBC14.Ghichu = rowBC14["Ghichu"].ToString();
            objBC14.Tenlaixe = rowBC14["MaLaixe"].ToString();
            objBC14.Is_Hoatdong = rowBC14["IsHoatdong"].ToString() == "1" ? true : false;
            objBC14.Khonghoatdong = !objBC14.Is_Hoatdong; 
            if( objBC14.Is_Hoatdong == true  )
            {
                objBC14.Giorahoatdong =  DateTime.Parse (rowBC14["ThoiDiemBao"].ToString ());  
            }

            if (objBC14.Khonghoatdong == true )
            {
                objBC14.GioveGara  = DateTime.Parse(rowBC14["ThoiDiemBao"].ToString());
            }
            return objBC14;
        }

        private void gridBaoCaoBieuMau1_FormattingRow_1(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            DinhDangCells(e.Row);
        }

        private void DinhDangCells(GridEXRow row)
        {
            try
            {
                BaoCaoBieuMau14 objBC14 = (BaoCaoBieuMau14)row.DataRow;

                if (!objBC14.Is_Hoatdong)
                {
                    row.Cells[3].Text = "";
                }
                if (!objBC14.Khonghoatdong)
                {                    
                    row.Cells[4].Text = "";
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnExportExcel_Click_1(object sender, EventArgs e)
        {

        }

        

    }
}