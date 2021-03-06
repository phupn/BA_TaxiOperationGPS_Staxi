using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Taxi.Utils;
using Taxi.Business;
using Janus.Windows.GridEX;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    public partial class frmBC_4_3_KetQuaDieuHanhTheoGio : Form
    {
        public frmBC_4_3_KetQuaDieuHanhTheoGio()
        {
            InitializeComponent();
        }
        private void frmBC_4_3_KetQuaDieuHanhTheoGio_Load(object sender, EventArgs e)
        {
            KhoiTaoDuLieu();
            btnExportExcel.Enabled = false;
            chkTongNgay.Enabled = false;
        }
        private void KhoiTaoDuLieu()
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();

            dateCurrent = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0);
            calTuNgay.Value = dateCurrent;
            calDenNgay.Value = dateCurrent;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                DateTime dateGioDauCa;
                // lay gio cua ca
                DataTable dt = ThongTinCauHinh.GetThongTinCa(1);
                try
                {
                    dateGioDauCa = Convert.ToDateTime(dt.Rows[0]["DauCa1"].ToString());
                }
                catch 
                {
                    dateGioDauCa = new DateTime(1900, 1, 1, 6, 0, 0);
                }
                DateTime TuNgay = new DateTime(calTuNgay.Value.Year, calTuNgay.Value.Month, calTuNgay.Value.Day, dateGioDauCa.Hour, dateGioDauCa.Minute, dateGioDauCa.Second);
                DateTime DenNgay = calDenNgay.Value;
                DenNgay = DenNgay.AddDays(1).Add(TuNgay.TimeOfDay.Add(new TimeSpan(0, 0, -1)));
                                
                lblTuNgayDen.Text = string.Format("({0:HH:mm dd/MM} - {1:HH:mm dd/MM})", TuNgay, DenNgay);
                //load du lieu
                DataTable dtDHTheoNgay = new TimKiem_BaoCao().GROUP_BaoCaoKetQuaDieuHanh_TheoGio(TuNgay, DenNgay);
                //khai bao doi tuong tong
                object objSum;

                float TyTrong;
                for (int i = 0; i < dtDHTheoNgay.Rows.Count; i++)
                {
                    if (i != 0)
                    {
                        string ngayInGroup = dtDHTheoNgay.Rows[i - 1]["NgayHienThi"].ToString();
                      
                        string Gio = dtDHTheoNgay.Rows[i - 1]["Gio"].ToString();
                        if ((dtDHTheoNgay.Rows[i]["Gio"].ToString() != Gio && dtDHTheoNgay.Rows[i]["NgayHienThi"].ToString() == ngayInGroup)
                            || (dtDHTheoNgay.Rows[i]["Gio"].ToString() != Gio && dtDHTheoNgay.Rows[i]["NgayHienThi"].ToString() != ngayInGroup)
                            || i == (dtDHTheoNgay.Rows.Count - 1))
                        {
                            if (ngayInGroup == "TONG")
                            {
                                objSum = dtDHTheoNgay.Compute("Sum(TongGoiTaxi)", " NgayHienThi= " + "'" + ngayInGroup + "'" + " and Gio is null");
                            }
                            else
                            {
                                objSum = dtDHTheoNgay.Compute("Sum(TongGoiTaxi)", " NgayHienThi= " + "'" + ngayInGroup + "'" + " and Gio= " + "'" + Gio + "'");
                            }
                            
                            foreach (DataRow dr in dtDHTheoNgay.Rows)
                            {
                                
                                if (dr["NgayHienThi"].ToString() == ngayInGroup && dr["Gio"].ToString() == Gio)
                                {
                                    TyTrong = (float.Parse(dr["TongGoiTaxi"].ToString()) / float.Parse(objSum.ToString())) * 100;                                                                    
                                    dr["TyTrong"] = TyTrong;                                  
                                }
                            }                                                  
                        }
                    }
                }

                string sVung = StringTools.TrimSpace(txtVung.Text);
                // khi co dữ liệu thì bật expand/coll
                if (dtDHTheoNgay.Rows.Count > 0)
                {
                    chkTongNgay.Enabled = true;
                }
                if (sVung.Length > 0)
                {
                    DataView dw = new DataView(dtDHTheoNgay, "Vung=" + sVung, "", DataViewRowState.ModifiedCurrent);

                    grdDieuHanhTheoGio.DataMember = "KetQuaDieuHanh";
                    grdDieuHanhTheoGio.SetDataBinding(dw, "KetQuaDieuHanh");
                    gridExport.DataMember = "KetQuaDieuHanh";
                    gridExport.SetDataBinding(dw, "KetQuaDieuHanh");
                }
                else
                {
                    grdDieuHanhTheoGio.DataMember = "KetQuaDieuHanh";
                    grdDieuHanhTheoGio.SetDataBinding(dtDHTheoNgay, "KetQuaDieuHanh");
                    gridExport.DataMember = "KetQuaDieuHanh";
                    gridExport.SetDataBinding(dtDHTheoNgay, "KetQuaDieuHanh");
                }
                btnExportExcel.Enabled = true;
            }
            else
            {
                MessageBox.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BC_KetQua_DieuHanh_TheoGio.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export(objFile);
                    if (MessageBox.Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                    {
                        FileTools.OpenFileExcel(saveFileDialog1.FileName);
                    }
                }
                btnExportExcel.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi : " + ex.Message);
            }
        }

        private void chkTongNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTongNgay.Checked)
            {
                grdDieuHanhTheoGio.CollapseGroups();
            }
            else
            {
                grdDieuHanhTheoGio.ExpandGroups();
            }
        }

        private void grdDieuHanhTheoGio_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.GroupFooter)
            {
                try
                {
                    double donDuoc = Convert.ToDouble(e.Row.Cells["TongDonDuoc"].Value.ToString());
                    double cuocTaxi = Convert.ToDouble(e.Row.Cells["TongGoiTaxi"].Value.ToString());
                    double goiLai = Convert.ToDouble(e.Row.Cells["TongGoiLai"].Value.ToString());
                    if (cuocTaxi > 0)
                    {
                        e.Row.Cells["PhanTramDonDuoc"].Text = string.Format("{0:#.#}", Convert.ToDouble(donDuoc / cuocTaxi * 100));
                        e.Row.Cells["PhanTramGoiLai"].Text = string.Format("{0:#.#}", Convert.ToDouble(goiLai / cuocTaxi * 100));
                    }
                }
                catch 
                {
                }
            }
        }
    }
}