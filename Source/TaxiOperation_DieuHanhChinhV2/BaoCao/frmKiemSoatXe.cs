using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.MessageBox;

namespace Taxi.GUI
{
    public partial class frmKiemSoatXe : Form
    {
        private DataTable g_dtKiemSoatXe;

        public frmKiemSoatXe()
        {
            InitializeComponent();
            g_dtKiemSoatXe = CreateTableKiemSoatXe("KiemSoatXe");
        }

        private void frmKiemSoatXe_Load(object sender, EventArgs e)
        {
            LoadDataKiemSoatXe();
          
            dataGridView1.DataSource = g_dtKiemSoatXe;
            HideColumn();

        }

        private void HideColumn()
        {
            DateTime NgayServer = DieuHanhTaxi.GetTimeServer();
             for (int iGio = 0; iGio <= 23; iGio++)
            {
                 if(iGio <= NgayServer.Hour+1)
                 {
                     dataGridView1.Columns[ "Gio_" + iGio.ToString()].Visible= true;
                 }
                 else
                 {
                     dataGridView1.Columns["Gio_" + iGio.ToString()].Visible = false ;
                 }
               
             }             
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
            return dtKiemSoatTaxi;
        }

        private void LoadDataKiemSoatXe()
        {
            try
            {
                DateTime NgayServer = DieuHanhTaxi.GetTimeServer();
                // lay danh sach xe
                List<string> lstXes = KiemSoatXeLienLac.GetDanhSachXeHoatDongTrongNgay(NgayServer);
                // cho tung xe vao tao du lieu cho bang g_dtKiemSoatXe
                if (lstXes != null)
                {
                    foreach (string SoHieuXe in lstXes)
                    {   // Moi mot so hieu xe la mot dong cua bang 
                        DataRow dr = g_dtKiemSoatXe.NewRow();
                        dr["SoHieuXe"] = SoHieuXe;
                        // lay cac su kien cua xe trong ngay
                        List<KiemSoatXeLienLac> lstKSXLL = new List<KiemSoatXeLienLac>();
                        lstKSXLL = KiemSoatXeLienLac.GetDanhSachCacSuKienCuaXeTrongNgay(SoHieuXe, NgayServer);
                        if (lstKSXLL != null)
                        {
                            // Du lieu theo tung co
                            foreach (KiemSoatXeLienLac objKS in lstKSXLL)
                            {
                                // Gan du lieu vao bang
                                string strColumnName = "Gio_" + objKS.ThoiDiemBao.Hour.ToString();
                                dr[strColumnName] = dr[strColumnName].ToString() + LayDuLieuVaoBang(objKS);

                            }
                        }

                        g_dtKiemSoatXe.Rows.Add(dr);
                    }
                }
                // du len grid
            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi khởi tạo dữ liệu xe hoạt động trong ngày.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }
        // Lay du lieu can thiet du KiemSoatXeLienLac, ra chuoi
        private string LayDuLieuVaoBang(KiemSoatXeLienLac objKS)
        {
            string strReturn = string.Empty;
            if (!objKS.IsHoatDong)
            {
                strReturn = "[VE] " + string.Format("{0: HH:mm }", objKS.ThoiDiemBao) + " ; " + objKS.ViTriDiemBao;
                return strReturn;
            }
            if (objKS.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.BaoRaHoatDong) strReturn = "[HĐ] ";
            else if (objKS.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.BaoDonDuocKhach) strReturn = "[ĐK] ";
            else if (objKS.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.BaoNghi) strReturn = "[NG] ";
            else if (objKS.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.BaoDiemDo) strReturn = "[ĐĐ] ";

            strReturn += string.Format("{0: HH:mm }", objKS.ThoiDiemBao) + " ; " + objKS.ViTriDiemBao;
            return strReturn;
        }

        
    }
}