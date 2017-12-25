using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.MessageBox;
using Taxi.Utils;
using System.IO;
using Janus.Windows.GridEX;

namespace Taxi.GUI
{
    public partial class frmBCXeHanhTrinhCuocKhach : Form
    {
        private DataTable g_dtKiemSoatXe;

        public frmBCXeHanhTrinhCuocKhach()
        {
            InitializeComponent();
           
        }
        private void frmKiemSoatXe_Load(object sender, EventArgs e)
        {
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                g_dtKiemSoatXe = null;
                g_dtKiemSoatXe = CreateTableKiemSoatXe("tbHanhTrinhXe");
                if (radCuocKhach.Checked)
                {
                    LoadHanhTrinhXeTheoCuocKhach();
                    CreateGrid();
                    gridEX1.DataMember = "lstXeHanhTrinhXe";
                    gridEX1.SetDataBinding(g_dtKiemSoatXe, "lstXeHanhTrinhXe");
                    ResizeColumn();
                }
                else
                {
                    LoadHanhTrinhXeTheoDiaChi();
                    CreateGridDiaChi();
                    gridEX1.DataMember = "lstXeHanhTrinhXe";
                    gridEX1.SetDataBinding(g_dtKiemSoatXe, "lstXeHanhTrinhXe");
                }
                btnXuatExcel.Enabled = true;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi tạo báo cáo dữ liệu báo cáo.", "Thông báo");
                btnSave.Enabled = false;
                btnXuatExcel.Enabled = false;
            }        
        }
        private void ResizeColumn()
        {            
            //for (int iGio = 0; iGio <= 23; iGio++)
            //{
            //    if(dataGridView1.Columns["Gio_" + iGio.ToString()] !=null)
            //     dataGridView1.Columns["Gio_" + iGio.ToString()].Width = 50;   
            //}
        }
        private void HideColumn()
        {
            //DateTime NgayServer = calendarCombo1.Value; ;
            // for (int iGio = 0; iGio <= 23; iGio++)
            //{
            //     if(iGio <= NgayServer.Hour+1)
            //     {
            //         dataGridView1.Columns[ "Gio_" + iGio.ToString()].Visible= true;
            //     }
            //     else
            //     {
            //         dataGridView1.Columns["Gio_" + iGio.ToString()].Visible = false ;
            //     }
               
            // }             
        }
        /// <summary>
        /// Tao bang kiem soat xe
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        private DataTable CreateTableKiemSoatXe(string TableName)
        {
            DataTable dtKiemSoatTaxi = new DataTable(TableName);

            DataColumn dcSoHieuXe = new DataColumn("SoHieuXe", Type.GetType("System.String"));
            dtKiemSoatTaxi.Columns.Add(dcSoHieuXe);

            for (int iGio = 0; iGio <= 23; iGio++)
            {
                DataColumn dcGio = new DataColumn("Gio_" + iGio.ToString() , Type.GetType("System.String"));
                dtKiemSoatTaxi.Columns.Add(dcGio);
            }
            DataColumn dcTong = new DataColumn("Tong", Type.GetType("System.String"));
            dtKiemSoatTaxi.Columns.Add(dcTong); 

            return dtKiemSoatTaxi;
        }

        /// <summary>
        /// tạo grid janus
        /// </summary>
        private void CreateGrid()
        {
            gridEX1.RootTable.Columns.Clear();
              GridEXColumn col1 = new GridEXColumn ();
                col1.DataMember = "SoHieuXe";
                col1.Key = "SoHieuXe";
                col1.Caption = " Số hiệu xe";
                col1.TextAlignment = TextAlignment.Center;
                col1.Width = 90;
                gridEX1.RootTable.Columns.Add(col1);

            for (int iGio = 0; iGio <= 23; iGio++)
            {
                GridEXColumn col = new GridEXColumn ();
                col.DataMember = "Gio_"+iGio.ToString ();
                col.Key = "Gio_"+iGio.ToString ();
                col.Caption = " " + iGio.ToString () + " h";
                col.TextAlignment = TextAlignment.Center;
                col.Width = 50;
                GridEXFormatStyle headerStyle = new GridEXFormatStyle ();
                headerStyle.TextAlignment = TextAlignment .Center;
                col.HeaderStyle = headerStyle;
                gridEX1.RootTable.Columns.Add(col);
            }

            GridEXColumn col2 = new GridEXColumn();
            col2.DataMember = "Tong";
            col2.Key = "Tong";
            col2.Caption = "  Tổng ";
            col2.TextAlignment = TextAlignment.Center;
            col2.Width = 90;
            gridEX1.RootTable.Columns.Add(col2);
        }

        private void CreateGridDiaChi()
        {
            gridEX1.RootTable.Columns.Clear();
            GridEXColumn col1 = new GridEXColumn();
            col1.DataMember = "SoHieuXe";
            col1.Key = "SoHieuXe";
            col1.Caption = " Số hiệu xe";
            col1.TextAlignment = TextAlignment.Center;
            col1.Width = 90;
            gridEX1.RootTable.Columns.Add(col1);

            for (int iGio = 0; iGio <= 23; iGio++)
            {
                GridEXColumn col = new GridEXColumn();
                col.DataMember = "Gio_" + iGio.ToString();
                col.Key = "Gio_" + iGio.ToString();
                col.Caption = " " + iGio.ToString() + " h";
                col.TextAlignment = TextAlignment.Center;
                col.Width = 150;
                GridEXFormatStyle headerStyle = new GridEXFormatStyle();
                headerStyle.TextAlignment = TextAlignment.Center;
                col.HeaderStyle = headerStyle;
                col.MaxLines = 10; 
                gridEX1.RootTable.Columns.Add(col);
            }

            GridEXColumn col2 = new GridEXColumn();
            col2.DataMember = "Tong";
            col2.Key = "Tong";
            col2.Caption = "  Tổng ";
            col2.TextAlignment = TextAlignment.Center;
            col2.Width = 90;
            gridEX1.RootTable.Columns.Add(col2);
        }

        /// <summary>
        /// hanh trình xe thao cuoc khách
        /// </summary>
        private void LoadHanhTrinhXeTheoCuocKhach()
        {
            try
            {
               
                 // lay danh sach xe
                DataTable dt = TimKiem_BaoCao.GetXeHanhTrinh_CuocKhach_TrongNgay(calendarCombo1.Value);
                
                // cho tung xe vao tao du lieu cho bang g_dtKiemSoatXe
                if ((dt != null) && (dt.Rows.Count>0))
                {
                        int Tong = 0;
                        int iIndex = 0;                        
                        int LenRows = dt.Rows.Count;
                        string SoHieuXe ="";
                        bool bNewRow = true;
                        // Moi mot so hieu xe la mot dong cua bang 

                        DataRow dr = null;
                        while(iIndex < LenRows)
                        {                            
                            if(bNewRow)  // tạo dòng mới
                            {
                                SoHieuXe = StringTools.TrimSpace(dt.Rows[iIndex]["SoHieuXe"].ToString ());
                                dr = g_dtKiemSoatXe.NewRow();
                                dr["SoHieuXe"] = SoHieuXe ;
                                string strColumnName = "Gio_" +  dt.Rows[iIndex]["MUIGIO"].ToString ();
                                dr[strColumnName] =  dt.Rows[iIndex]["CUOCKHACH"].ToString ();
                                dr["Tong"] =  dt.Rows[iIndex]["CUOCKHACH"].ToString ();

                                Tong = Convert.ToInt16 ( dt.Rows[iIndex]["CUOCKHACH"].ToString ());

                                bNewRow =  false ;iIndex++;
                            }
                            else
                            {
                                if(SoHieuXe == StringTools.TrimSpace(dt.Rows[iIndex]["SoHieuXe"].ToString ())) // chua co cot moi
                                {
                                    string strColumnName = "Gio_" +  dt.Rows[iIndex]["MUIGIO"].ToString ();
                                    dr[strColumnName] =  dt.Rows[iIndex]["CUOCKHACH"].ToString ();
                                    Tong += Convert.ToInt16 ( dt.Rows[iIndex]["CUOCKHACH"].ToString ()); 
                                    dr["Tong"] =  Tong.ToString ();
                                    iIndex++;
                                    bNewRow = false ;
                                }
                                else
                                {
                                    Tong = 0;
                                    bNewRow = true;
                                    g_dtKiemSoatXe.Rows.Add(dr);
                                }
                            }
                            if(iIndex==LenRows)  g_dtKiemSoatXe.Rows.Add(dr);                            
                        }                         
                        
                    }               
            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi khởi tạo dữ liệu xe hoạt động trong ngày.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }

        private void LoadHanhTrinhXeTheoDiaChi()
        {
            try
            {
                DataTable dt = TimKiem_BaoCao.GetXeHanhTrinh_DiaChi_TrongNgay(calendarCombo1.Value);
                // cho tung xe vao tao du lieu cho bang g_dtKiemSoatXe
                if ((dt != null) && (dt.Rows.Count>0))
                {
                    int Tong = 0;
                    int iIndex = 0;                        
                    int LenRows = dt.Rows.Count;
                    string SoHieuXe ="";
                    bool bNewRow = true;
                    string MuiGio = "";
                    // Moi mot so hieu xe la mot dong cua bang 
                    DataRow dr = null;
                    while(iIndex < LenRows)
                    {
                        
                        if(bNewRow)  // tạo dòng mới
                        {
                            //DC.SoHieuXe,DC.MUIGIO,DC.DiaChi,CK.CUOCKHACH
                            SoHieuXe = StringTools.TrimSpace(dt.Rows[iIndex]["SoHieuXe"].ToString ());
                            dr = g_dtKiemSoatXe.NewRow();
                            dr["SoHieuXe"] = SoHieuXe ;
                            MuiGio = dt.Rows[iIndex]["MUIGIO"].ToString();
                            string strColumnName = "Gio_" +  dt.Rows[iIndex]["MUIGIO"].ToString ();
                            dr[strColumnName] =  dt.Rows[iIndex]["DiaChi"].ToString ();
                            dr["Tong"] =  dt.Rows[iIndex]["CUOCKHACH"].ToString ();
                            Tong = Convert.ToInt16(dt.Rows[iIndex]["CUOCKHACH"].ToString());
                            bNewRow =  false ;iIndex++;
                        }
                        else
                        {
                            if(SoHieuXe == StringTools.TrimSpace(dt.Rows[iIndex]["SoHieuXe"].ToString ())) // chua co dong moi
                            {
                                string strColumnName = "Gio_" + dt.Rows[iIndex]["MUIGIO"].ToString();
                                dr[strColumnName] += "\n" + dt.Rows[iIndex]["DiaChi"].ToString();                           
                                if (MuiGio != dt.Rows[iIndex]["MUIGIO"].ToString()) // chua thay moi gio thi chi cong dia chi
                                {
                                    Tong += Convert.ToInt16(dt.Rows[iIndex]["CUOCKHACH"].ToString());
                                    dr["Tong"] = Tong.ToString();                               
                                 } 
                                iIndex++;
                                bNewRow = false ;
                            }
                            else
                            {
                                Tong = 0;
                                bNewRow = true; MuiGio = "";
                                g_dtKiemSoatXe.Rows.Add(dr);
                            }
                        }
                        if(iIndex==LenRows)  g_dtKiemSoatXe.Rows.Add(dr);                            
                    } 
                }               
            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi khởi tạo dữ liệu xe hoạt động trong ngày.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }


        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCaoHanhTrinhXeTheo.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

        private void calendarCombo1_ValueChanged(object sender, EventArgs e)
        {
            btnXuatExcel.Enabled = false;
            btnSave.Enabled = true;
        }

        private void radCuocKhach_CheckedChanged(object sender, EventArgs e)
        {
            gridEX1.DataSource = null; 
            btnXuatExcel.Enabled = false;
            btnSave.Enabled = true;
        }

         
       

        
    }
}