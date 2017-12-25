using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using Taxi.Business;
using Taxi.Business.CheckCoDuongDai;

namespace Taxi.Controls.FormCheckCoDuongDai
{
    public partial class DSCuocDuongDai_SanBay_V2 : Form
    {
        #region declare variable

        List<Business.CheckCoDuongDai.CheckCoDuongDai> lstCuocDuongDaiSanBay = new List<Business.CheckCoDuongDai.CheckCoDuongDai>();
        private List<Province> G_arrProvince;
        private List<District> G_arrDistrict;
        private List<Commune> G_arrCommune;
        #endregion

        public DSCuocDuongDai_SanBay_V2()
        {
            InitializeComponent();
        }

        public DSCuocDuongDai_SanBay_V2(List<Province> arrProvince, List<District> arrDistrict, List<Commune> arrCommune)
        {
            InitializeComponent();
            G_arrCommune = arrCommune;
            G_arrDistrict = arrDistrict;
            G_arrProvince = arrProvince;
        }

        private void DSCuocDuongDai_SanBay_V2_Load(object sender, EventArgs e)
        {
            LoadDSCuoc();
            LoadGara();
            LoadComBoboxThoiGian();
            cboThoiGian.EditValue = 1;
            btnSearch_Click(null, null);
            
        }

        public void LoadGara()
        {
            DataTable dt = Business.DM.Gara.GetAllGara();
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
            lstCuocDuongDaiSanBay = new Business.CheckCoDuongDai.CheckCoDuongDai().GetDSCuocDuongDaiSanBay(string.Empty, 0);
            grdCuocSanBayDuongDai.DataSource = lstCuocDuongDaiSanBay;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int thoiGian;
            List<Business.CheckCoDuongDai.CheckCoDuongDai> lstCheckCo = new List<Business.CheckCoDuongDai.CheckCoDuongDai>();
            if (cboThoiGian.ItemIndex < 0)
            {
                thoiGian = 0;
            }
            else
            {
                thoiGian = int.Parse(cboThoiGian.EditValue.ToString());
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
           lstCheckCo  = new Business.CheckCoDuongDai.CheckCoDuongDai().GetDSCuocDuongDaiSanBay_Gara(txtSoHieuXe.Text.Trim(),thoiGian, gara);

            //grdCuocSanBayDuongDai.DataMember = "SanBayDuongDai";
            //grdCuocSanBayDuongDai.SetDataBinding(lstCheckCo , "SanBayDuongDai");
            grdCuocSanBayDuongDai.DataSource = lstCheckCo;
        }

        #region Nhập dữ liệu vào truyền đi

        private void grdCuocSanBayDuongDai_DoubleClick(object sender, EventArgs e)
        {            
            if (grvCuocSanBayDuongDai.RowCount > 0)
            {
                int index = grvCuocSanBayDuongDai.FocusedRowHandle;
                NhapDuLieuVaoTruyenDi(index);
            }
        }

        private void grdCuocSanBayDuongDai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {               
                if (grvCuocSanBayDuongDai.RowCount > 0)
                {
                    int index = grvCuocSanBayDuongDai.FocusedRowHandle;
                    NhapDuLieuVaoTruyenDi(index);
                }
            }
        }

        private void NhapDuLieuVaoTruyenDi(int rowPosition)
        {
            if (grvCuocSanBayDuongDai.RowCount > 0)
            {
                Business.CheckCoDuongDai.CheckCoDuongDai objCheckCo = (Business.CheckCoDuongDai.CheckCoDuongDai)(grvCuocSanBayDuongDai.GetFocusedRow());
                if (DateTime.Now.AddHours(-24) <= objCheckCo.NgayTao)
                {
                    ThongTinSanBay_DuongDai frmSanBayDuongDai = new ThongTinSanBay_DuongDai(objCheckCo, G_arrProvince, G_arrDistrict, G_arrCommune);
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
                    System.Windows.Forms.MessageBox.Show("Bạn chỉ có thể sửa dữ liệu trong vòng 24h");
                }
            }
        }

        #endregion    

       

        private void LoadComBoboxThoiGian()
        {
            List<KhoangThoiGian> lstcbo = new List<KhoangThoiGian>();
            lstcbo.Add(new KhoangThoiGian { SoNgay = 1, ThoiGian = "--- 1 ngày gần đây ---" });
            lstcbo.Add(new KhoangThoiGian { SoNgay = 3, ThoiGian = "--- 3 ngày gần đây ---" });
            lstcbo.Add(new KhoangThoiGian { SoNgay = 5, ThoiGian = "--- 5 ngày gần đây ---" });
            lstcbo.Add(new KhoangThoiGian { SoNgay = 15, ThoiGian = "--- 15 ngày gần đây ---" });
            cboThoiGian.Properties.DataSource = lstcbo;
            cboThoiGian.Properties.DisplayMember = "ThoiGian";
            cboThoiGian.Properties.ValueMember = "SoNgay";
        }
    }

    public class KhoangThoiGian
    {
        public string ThoiGian { get; set; }
        public int SoNgay { get; set; }
    }
}
