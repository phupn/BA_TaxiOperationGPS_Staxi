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
using Taxi.Business.CheckCoDuongDai;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoDiSanBayDuongDai : Form 
    {

        private List<Province> G_arrProvince;
        private DataTable g_dt = new DataTable();
        public frmBaoCaoDiSanBayDuongDai(List<Province> arrProvince)
        {
            InitializeComponent();
            G_arrProvince = arrProvince;
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();
            cbTuNgay.Value = dateCurrent.Date;
            cbDenNgay.Value = dateCurrent;
            LoadTinhThanh();
            LoadGara();
            cbGara.SelectedIndex = 0;
        }

        public void LoadTinhThanh()
        {
            if (G_arrProvince != null && G_arrProvince.Count > 0)
            {
                cbTinhThanh.DisplayMember = "NameVN";
                cbTinhThanh.ValueMember = "PK_ProvinceID";
                cbTinhThanh.DataSource = G_arrProvince;
            }
            if (cbTinhThanh.Items.Count > 0)
                cbTinhThanh.SelectedValue = 0;


            //Taxi.Business.CheckCoDuongDai.CheckCoDuongDai objCheckCo = new Taxi.Business.CheckCoDuongDai.CheckCoDuongDai();
            //if (objCheckCo != null)
            //{
            //    DataTable dt =objCheckCo.GetDMTinhThanh();
            //    if (dt != null)
            //    {
            //        if (dt.Rows.Count > 0)
            //        {
            //            DataRow row = dt.NewRow();
            //            row["TinhThanhID"] = 0;
            //            row["MaTinhThanh"] = "0";
            //            row["TenTinhThanh"] = "--Tất cả--";
            //            dt.Rows.InsertAt(row, 0);

            //            cbTinhThanh.DisplayMember = "TenTinhThanh";
            //            cbTinhThanh.ValueMember = "TinhThanhID";
            //            cbTinhThanh.DataSource = dt;                        
            //        }
            //    }
            //}
        }

        public void LoadGara()
        {
            DataTable dt = Gara.GetAllGara();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = "0";
                    row["Name"] = "--Tất cả--";
                    dt.Rows.InsertAt(row, 0);

                    cbGara.DisplayMember = "Name";
                    cbGara.ValueMember = "ID";
                    cbGara.DataSource = dt;
                }
            }            
        }
       
        /// <summary>
        /// Load phan len bieu mau
        /// </summary>        
        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            LoadData();             
        }

        /// <summary>
        /// lấy thông tin xe đi san bay đường dài theo ngày
        /// </summary>
        /// <param name="Ngay"></param>
        private void LoadData()
        {

            g_dt = TimKiem_BaoCao.GetBaoCaoXeDiSanBayDuongDai(cbTuNgay.Value, cbDenNgay.Value, Convert.ToInt16(cbTinhThanh.SelectedValue), Convert.ToInt16(cbGara.SelectedValue));
            
            gridBaoCaoBieuMau1.DataMember = "ListDienThoai";
            gridBaoCaoBieuMau1.SetDataBinding(g_dt, "ListDienThoai");
            btnExport.Enabled = true;
            btnExportExcel.Enabled = true;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string param = string.Format("{0} đến {1}",cbTuNgay.Value.ToString("HH:mm dd/MM/yyyy"),cbDenNgay.Value.ToString("HH:mm dd/MM/yyyy"));
            //    frmInBaoCao frmPrint = new frmInBaoCao();
            //}
            //catch (Exception ex)
            //{
            //    new Taxi.MessageBox.MessageBox().Show(ex.Message);
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BaoCao_DS_CheckCoDuongDai.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export((Stream)objFile);
                    string result = new Taxi.MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo",
                                                Taxi.MessageBox.MessageBoxButtonsBA.YesNo,
                                                Taxi.MessageBox.MessageBoxIconBA.Question);
                    if (result == "Yes")
                    {
                        Taxi.Utils.FileTools.OpenFileExcel(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Có lỗi tạo file excel", "Thông báo",
                                                Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                Taxi.MessageBox.MessageBoxIconBA.Error);
            }
            btnExport.Enabled = false;
        }

        #region Xử lí hot key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.L))
            {
                btnRefresh_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.I))
            {
                btnExportExcel_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.P))
            {
                btnExportExcel_Click(null, null);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion


        //private void gridBaoCaoBieuMau1_FormattingRow(object sender, RowLoadEventArgs e)
        //{
        //    if (e.Row.Cells["SanBay"].Value.ToString() == "0")
        //    {
        //        e.Row.Cells["SanBay"].Text = "";
        //    }
        //    if (e.Row.Cells["DuongDai"].Value.ToString() == "0")
        //    {
        //        e.Row.Cells["DuongDai"].Text = "";
        //    }
        //}
    }
}