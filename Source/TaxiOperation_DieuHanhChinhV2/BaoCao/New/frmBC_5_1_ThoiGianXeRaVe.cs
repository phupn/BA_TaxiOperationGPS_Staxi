using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using ChartDirector;
using System.IO;
using Janus.Windows.GridEX;
using Taxi.Business.DM;
using Taxi.Utils;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBC_5_1_ThoiGianXeRaVe : Form
    {
          
        public frmBC_5_1_ThoiGianXeRaVe()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            
            LoadDSCongTy();
            btnExportExcel.Enabled = false ;
            btnRefresh.Enabled = true ;
             
        }
        private void LoadDSCongTy()
        {
            comboBox1.ValueMember = "CongTyID";
            comboBox1.DisplayMember = "TenCongTy";
            comboBox1.DataSource = CongTy.GetListOfCongTys_NAME();
            comboBox1.SelectedIndex = 0;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBaoCao();
            btnExportExcel.Enabled = true;
            btnRefresh.Enabled = false;
        }

        private void LoadBaoCao()
        {
            DateTime thoiDiem = calTuThoiDiem.Value;
             
            string soHieuXe = StringTools.TrimSpace(txtSoHieuXe.Text );
            string laiXeID= StringTools .TrimSpace (txtLaiXeID.Text );
            int congtyID = (int) comboBox1.SelectedValue ;


            gridBaoCaoBieuMau1.DataSource = TimKiem_BaoCao.GROUP_BC_5_1_LaiXeBaoRaVeTheoThoiDiem(thoiDiem,  soHieuXe, laiXeID, congtyID);
            
        }

        
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
             
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BCLaiXeRaVe_5_1.xls";
            gridBaoCaoBieuMau1.RootTable.CellLayoutMode = CellLayoutMode.UseColumns;
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
            gridBaoCaoBieuMau1.RootTable.CellLayoutMode = CellLayoutMode.UseColumnSets;
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
            try
            {
                if (e.Row.RowType == RowType.Record)
                {
                    GridEXRow row = e.Row;

                    if (row.Cells["HDTruoc"] != null && row.Cells["HDTruoc"].Value.ToString() == "1")
                        row.Cells["HDTruoc"].Text = "x";
                    else
                        row.Cells["HDTruoc"].Text = "";
                    if (row.Cells["KhongHDTruoc"] != null && row.Cells["KhongHDTruoc"].Value.ToString() == "1")
                        row.Cells["KhongHDTruoc"].Text = "x";
                    else
                        row.Cells["KhongHDTruoc"].Text = "";

                     if (row.Cells["HDSau"] != null && row.Cells["HDSau"].Value.ToString() == "1")
                        row.Cells["HDSau"].Text = "x";
                    else
                        row.Cells["HDSau"].Text = "";

                    if (row.Cells["KhongHDSau"] != null && row.Cells["KhongHDSau"].Value.ToString() == "1")
                        row.Cells["KhongHDSau"].Text = "x";
                    else
                        row.Cells["KhongHDSau"].Text = "";
                         
                }
            }
            catch (Exception ex)
            {

            }
        }

        
        private void SetActiveButton()
        {
            btnExportExcel.Enabled = false;
            btnRefresh.Enabled = true;
        }
        private void txtSoHieuXe_TextChanged(object sender, EventArgs e)
        {
            SetActiveButton();
        }

        private void txtLaiXeID_TextChanged(object sender, EventArgs e)
        {
            SetActiveButton();
        }

        private void cboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveButton();
        }

        private void calTuThoiDiem_ValueChanged(object sender, EventArgs e)
        {
            SetActiveButton();
        }

        private void calDenThoiDiem_ValueChanged(object sender, EventArgs e)
        {
            SetActiveButton();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveButton();
        } 
    }
}