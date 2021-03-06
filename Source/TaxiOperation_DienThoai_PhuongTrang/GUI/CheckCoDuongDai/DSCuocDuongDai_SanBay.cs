using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Taxi.Business;
using Taxi.Business.CheckCoDuongDai;

namespace TaxiOperation_DienThoai.CheckCoDuongDai
{
    public partial class DSCuocDuongDai_SanBay : Form
    {
        #region declare variable

        List<Taxi.Business.CheckCoDuongDai.CheckCoDuongDai> lstCuocDuongDaiSanBay = new List<Taxi.Business.CheckCoDuongDai.CheckCoDuongDai>();
        private string g_strUsername = "";
        private string g_IPAddress = "";
        private List<Province> G_arrProvince;
        private List<District> G_arrDistrict;
        private List<Commune> G_arrCommune;
        #endregion

        public DSCuocDuongDai_SanBay()
        {
            InitializeComponent();
        }

        public DSCuocDuongDai_SanBay(List<Province> arrProvince, List<District> arrDistrict, List<Commune> arrCommune)
        {
            InitializeComponent();
            G_arrCommune = arrCommune;
            G_arrDistrict = arrDistrict;
            G_arrProvince = arrProvince;
        }

        private void DSCuocDuongDai_SanBay_Load(object sender, EventArgs e)
        {
            LoadDSCuoc();
            LoadGara();
            cbThoiGian.SelectedValue = 1;
        }

        public void LoadGara()
        {
            DataTable dt = Taxi.Business.DM.Gara.GetAllGara();
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

        public void LoadDSCuoc()
        {
            lstCuocDuongDaiSanBay = new Taxi.Business.CheckCoDuongDai.CheckCoDuongDai().GetDSCuocDuongDaiSanBay(string.Empty, 0);
            grdCuocSanBayDuongDai.DataMember = "SanBayDuongDai";
            grdCuocSanBayDuongDai.SetDataBinding(lstCuocDuongDaiSanBay, "SanBayDuongDai");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int thoiGian;
            if (cbThoiGian.SelectedIndex < 0)
            {
                thoiGian = 0;
            }
            else
            {
                thoiGian = int.Parse(cbThoiGian.SelectedValue.ToString());
            }
            int gara;
            if (cbGara.SelectedIndex < 0)
            {
                gara = 0;
            }
            else
            {
                gara = int.Parse(cbGara.SelectedValue.ToString());
            }
           List<Taxi.Business.CheckCoDuongDai.CheckCoDuongDai> lstCheckCo  = new Taxi.Business.CheckCoDuongDai.CheckCoDuongDai().GetDSCuocDuongDaiSanBay_Gara(txtSoHieuXe.Text.Trim(),thoiGian, gara);

            grdCuocSanBayDuongDai.DataMember = "SanBayDuongDai";
            grdCuocSanBayDuongDai.SetDataBinding(lstCheckCo , "SanBayDuongDai");
        }

        private void grdCuocSanBayDuongDai_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.Cells["ThoiDiemVe"].Value.ToString() == "01/01/1900 00:00:00")
            {
                e.Row.Cells["ThoiDiemVe"].Text = string.Empty;
            }
            if ((DateTime)e.Row.Cells["ThoiDiemDuyet"].Value == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
            {
                e.Row.Cells["TrangThaiDuyet"].Text = "Chờ xử lý";
                e.Row.Cells["NguoiDuyet"].Text = "";
                e.Row.Cells["ThoiDiemDuyet"].Text = "";
            }
            else
            {
                if ((bool)e.Row.Cells["TrangThaiDuyet"].Value == false)
                    e.Row.Cells["TrangThaiDuyet"].Text = "Không duyệt";
                else
                    e.Row.Cells["TrangThaiDuyet"].Text = "Đã duyệt";

            }
        }       
        
        #region Nhập dữ liệu vào truyền đi

        private void grdCuocSanBayDuongDai_DoubleClick(object sender, EventArgs e)
        {
            grdCuocSanBayDuongDai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdCuocSanBayDuongDai.SelectedItems.Count > 0)
            {
                NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)grdCuocSanBayDuongDai.SelectedItems[0]).Position);
            }
        }

        private void grdCuocSanBayDuongDai_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                grdCuocSanBayDuongDai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdCuocSanBayDuongDai.SelectedItems.Count > 0)
                {
                    NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)grdCuocSanBayDuongDai.SelectedItems[0]).Position);
                }
            }           
        }

        private void NhapDuLieuVaoTruyenDi(int rowPosition)
        {
            grdCuocSanBayDuongDai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            Taxi.Business.CheckCoDuongDai.CheckCoDuongDai objCheckCo = (Taxi.Business.CheckCoDuongDai.CheckCoDuongDai)((GridEXSelectedItem)    
                                                                grdCuocSanBayDuongDai.SelectedItems[0]).GetRow().DataRow;
            
            if(grdCuocSanBayDuongDai.SelectedItems.Count >0)
            {
               if ( DateTime.Now.AddHours(-24)<= objCheckCo.NgayTao)
               {
                    ThongTinSanBay_DuongDai frmSanBayDuongDai = new ThongTinSanBay_DuongDai(objCheckCo,G_arrProvince,G_arrDistrict,G_arrCommune);
                    DialogResult diaResult = frmSanBayDuongDai.ShowDialog();
                    if (diaResult == DialogResult.OK)
                    {
                        LoadDSCuoc();
                    }
               }
               else if (ThongTinDangNhap.USER_ID == "admin" || ThongTinDangNhap.IsInRole("TC") || ThongTinDangNhap.IsInRole("GD"))
               {
                   ThongTinSanBay_DuongDai frmSanBayDuongDai = new ThongTinSanBay_DuongDai(objCheckCo, G_arrProvince, G_arrDistrict, G_arrCommune);
                   DialogResult diaResult = frmSanBayDuongDai.ShowDialog();
                   if (diaResult == DialogResult.OK)
                   {
                       LoadDSCuoc();
                   }
               }
               else 
               {
                   MessageBox.Show("Bạn chỉ có thể sửa dữ liệu trong vòng 24h");
               }
            }
        }

        #endregion    
    }
       
}