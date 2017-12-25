using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
 
using System.IO;
using Janus.Windows.GridEX;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmBaoCaoTrangThaiXe : Form
    {
        DataTable g_dt = new DataTable();
        private const int MAX_DATES = 100;

        public frmBaoCaoTrangThaiXe()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer ();
            lblThoiDiem.Text = string.Format("{0: dd/MM/yyyy HH:mm}", dateCurrent);
            LoadDulieuBaoCao_BieuMau14();       
        }
        private void LoadDulieuBaoCao_BieuMau14()
        {
            List<BaoCaoBieuMau14> ListBC14 = new List<BaoCaoBieuMau14>();
            // lay danh muc xe 
            List<Xe> listXes = new List<Xe>();
            Xe objXe = new Xe();
            listXes = objXe.GetListXes();
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            // lay trang thai cua tung xe insert vao bieu 14
            if (listXes != null)
            {
                foreach (Xe xe in listXes)
                {
                    DataTable dt = new DataTable();
                    BaoCaoBieuMau14 objBC14 = new BaoCaoBieuMau14();
                    dt = TimKiem_BaoCao.GetTrangThaiBaoRa_Ve_GanNhat(xe.SoHieuXe);
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
                        //,[IsHoatDong]

                        objBC14.Sohieutaxi = xe.SoHieuXe;
                        objBC14.Tenlaixe = dt.Rows[0]["MaLaiXe"].ToString();
                        if (dt.Rows[0]["IsHoatDong"].ToString() == "1")
                        {
                            objBC14.Is_Hoatdong = true;
                            objBC14.Khonghoatdong = false;
                            objBC14.Giorahoatdong = DateTime.Parse(dt.Rows[0]["ThoiDiemBao"].ToString());
                            objBC14.GioveGara = DateTime.MinValue;

                            if (timeServer.Day != objBC14.Giorahoatdong.Day)
                            {
                                TimeSpan timeSpan = timeServer - objBC14.Giorahoatdong;
                                objBC14.Ghichu = timeSpan.Days + " ngày";
                            }
                        }
                        else
                        {
                            objBC14.Is_Hoatdong = false;
                            objBC14.Khonghoatdong = true;
                            objBC14.Giorahoatdong = DateTime.MinValue;
                            objBC14.GioveGara = DateTime.Parse(dt.Rows[0]["ThoiDiemBao"].ToString());
                        }

                    }
                    else  // xe chua hoat dong va chua ve
                    {

                        objBC14.Sohieutaxi = xe.SoHieuXe;
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

    }
}