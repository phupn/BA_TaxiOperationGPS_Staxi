using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Taxi.Business;
using Janus.Windows.GridEX.EditControls;

namespace Taxi.GUI
{
    public partial class frmCapNhatBangGia_New : Form
    {
        private bool isUpdate = false;
        public frmCapNhatBangGia_New()
        {
            InitializeComponent();
        }

        private void frmTinhTienTheoKm_Load(object sender, EventArgs e)
        {
            loadLoaiXe();
        }

        private void loadLoaiXe()
        {
            DataTable dt = new TinhTienTheoKm().GetAllLoaiXe();
            if (dt != null && dt.Rows.Count > 0)
            {
                cbLoaiXe.DisplayMember = "TenLoaiXe_SoCho";
                cbLoaiXe.ValueMember = "LoaiXeID";
                cbLoaiXe.DataSource = dt;
                cbLoaiXe.SelectedIndex = 0;
            }
        }

        private void LoadDuLieu(int idLoaiXe)
        {
            try
            {
                TinhTienTheoKm obj4 = TinhTienTheoKm.GetThongSoTinhTen(idLoaiXe);
                if (obj4.LoaiXe == 0)
                {
                    isUpdate = false;
                }
                else
                {
                    isUpdate = true;
                }
                //mTongTien1Chieu = TinhTien1Chieu(SoKm);
                //if (SoKm < KmNguong2Chieu) mTongTien2Chieu = mTongTien1Chieu;
                //else mTongTien2Chieu = ((100 - TiLeGiamGia2Chieu) / 100) * mTongTien1Chieu;

                if (obj4.N1_ChieuDiTu <= 0 && obj4.N1_ChieuDiDen <= 0 && obj4.N1_Giam <= 0)
                {
                    chk_Type.Checked = true;
                }

                numGiaMoCua.Value = (float)obj4.GiaMoCua;
                numKmMoCua.Value = (float)obj4.KmMoCua;
                numKmNguong1.Value = (float)obj4.KmNguong1;
                numGiaNguong1.Value = (float)obj4.GiaNguong1;
                numKmNguong2.Value = (float)obj4.KmNguong2;
                numGiaNguong2.Value = (float)obj4.GiaNguong2;
                numKmNguong3.Value = (float)obj4.KmNguong3;
                numGiaNguong3.Value = (float)obj4.GiaNguong3;
                CV_N1_NumDiTu.Value = (float)obj4.N1_ChieuDiTu;
                CV_N1_NumDiDen.Value = (float)obj4.N1_ChieuDiDen;
                CV_N1_NumGiam.Value = (float)obj4.N1_Giam;
                CV_N2_NumDiTu.Value = (float)obj4.N2_ChieuDiTu;
                CV_N2_NumGiam.Value = (float)obj4.N2_Giam;
                CV_N2_ChkAll.Checked = obj4.IsAll;
                //numGiaNguong3.Value = (float)obj4.GiaNguong3;
                //numKmNguong2.Value = (float)obj4.KmNguong2Chieu;
                //num.Value = (float)obj4.TiLeGiamGia2Chieu;
                txtThongTinThueBao.Text = obj4.ThongTinThueBao;

                LoadTinhTien_TG(idLoaiXe);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CapNhatBangGiaCuoc_New.LoadDuLieu", ex);
            }
            
            
        }

        private void LoadTinhTien_TG(int idLoaiXe)
        {
            List<TinhTien_SuDungXe> lstTinhTien_TG = new TinhTien_SuDungXe().GetTinhTien_SuDungXe(idLoaiXe);
            
            int n = lstTinhTien_TG.Count;
            for (int i = 1; i < 9; i++)
            {
                ((NumericEditBox)(this.Controls.Find("N" + i + "_ID", true)[0])).Value = i>=n ? 0 : lstTinhTien_TG[i - 1].ID;
                ((NumericEditBox)(this.Controls.Find("N" + i + "_KmTu", true)[0])).Value = i >= n ? 0 : lstTinhTien_TG[i - 1].Km_Tu;
                ((NumericEditBox)(this.Controls.Find("N" + i + "_KmDen", true)[0])).Value = i >= n ? 0 : lstTinhTien_TG[i - 1].Km_Den;
                ((NumericEditBox)(this.Controls.Find("N" + i + "_VTB", true)[0])).Value = i >= n ? 0 : lstTinhTien_TG[i - 1].Vtb;
                ((NumericEditBox)(this.Controls.Find("N" + i + "_TG", true)[0])).Value = i >= n ? 0 : lstTinhTien_TG[i - 1].TG;
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            float KmMoCua = (float)numKmMoCua.Value;
            float GiaMoCua = (float)numGiaMoCua.Value;
            float KmNguong1 = (float)numKmNguong1.Value;
            float GiaNguong1 = (float)numGiaNguong1.Value;
            float KmNguong2 = (float)numKmNguong2.Value;
            float GiaNguong2 = (float)numGiaNguong2.Value;
            float KmNguong3 = (float)numKmNguong3.Value;
            float GiaNguong3 = (float)numGiaNguong3.Value;
            float CVN1_NumDiTu = (float)CV_N1_NumDiTu.Value;
            float CVN1_NumDiDen = (float)CV_N1_NumDiDen.Value;
            float CVN1_NumGiam = (float)CV_N1_NumGiam.Value;
            float CVN2_NumDiTu = (float)CV_N2_NumDiTu.Value;
            float CVN2_NumGiam = (float)CV_N2_NumGiam.Value;
            int loaiXe  = Convert.ToInt16(cbLoaiXe.SelectedValue.ToString());
            TinhTienTheoKm objTinhTien = new TinhTienTheoKm(
                KmMoCua,
                GiaMoCua,
                KmNguong1,
                GiaNguong1,
                KmNguong2,
                GiaNguong2,
                KmNguong3,
                GiaNguong3,
                CVN1_NumDiTu,
                CVN1_NumDiDen,
                CVN1_NumGiam,
                CVN2_NumDiTu,
                CVN2_NumGiam,
                CV_N2_ChkAll.Checked,
                0,
                0,
                loaiXe,
                txtThongTinThueBao.Text );
            if (isUpdate)
            {
                if (!objTinhTien.Update_New())
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi cập nhật thông tin giá cước mới.");
                    return;
                }
            }
            else
            {
                if (!objTinhTien.Insert())
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi cập nhật thông tin giá cước mới.");
                    return;
                }
            }
            objTinhTien = null;
            
            SaveTinhTienSuDung(loaiXe);

            new MessageBox.MessageBoxBA().Show("Cập nhật thông tin giá cước mới thành công.");
        }

        private void SaveTinhTienSuDung(int LoaiXe)
        {
            try
            {
                for (int i = 1; i < 9; i++)
                {
                    int ID = 0;
                    var NId = this.Controls.Find("N" + i + "_ID", true);
                    if (NId != null && NId.Length > 0 && ((NumericEditBox)(NId[0])).Value!=null)
                    {
                        int.TryParse(((NumericEditBox)(NId[0])).Value.ToString(), out ID);
                    }
                    int KmTu =0;
                    var NKmTu = this.Controls.Find("N" + i + "_KmTu", true);
                    if (NKmTu != null && NKmTu.Length > 0)
                    {
                        int.TryParse(((NumericEditBox)(NKmTu[0])).Value.ToString(), out KmTu);
                    }
                    int KmDen = 0;
                    var NKmDen = this.Controls.Find("N" + i + "_KmDen", true);
                    if (NKmDen != null && NKmDen.Length > 0 && ((NumericEditBox)(NKmDen[0])).Value != null)
                    {
                        int.TryParse(((NumericEditBox)(NKmDen[0])).Value.ToString(), out KmDen);
                    }
                    int VTB = 0;
                    var NVTB = this.Controls.Find("N" + i + "_VTB", true);
                    if (NVTB != null && NVTB.Length > 0 && ((NumericEditBox)(NVTB[0])).Value != null)
                    {
                        int.TryParse(((NumericEditBox)(NVTB[0])).Value.ToString(), out VTB);
                    }
                    float TG = 0;
                    var NTG = this.Controls.Find("N" + i + "_TG", true);
                    if (NTG != null && NTG.Length > 0 && ((NumericEditBox)(NTG[0])).Value != null)
                    {
                        float.TryParse(((NumericEditBox)(NTG[0])).Value.ToString(), out TG);
                    }
                    new TinhTien_SuDungXe(ID, LoaiXe, KmTu, KmDen, VTB, TG).Save();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SaveTinhTienSuDung", ex);
            }
            
        }

        private void btnThoai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiXe.SelectedValue != null && cbLoaiXe.SelectedValue!="")
            {
                LoadDuLieu(Convert.ToInt16(cbLoaiXe.SelectedValue.ToString()));
            }
            else
            {
                LoadDuLieu(0);
            }
        }

        private void numKmNguong2_Click(object sender, EventArgs e)
        {

        }

        private void numericEditBox5_Click(object sender, EventArgs e)
        {

        }

        private void chk_Type_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Type.Checked)
            {
                CV_N2_ChkAll.Checked = true;
                CV_N2_ChkAll.Enabled = false;
                CV_N1_NumGiam.Value = "0";
                CV_N1_NumDiTu.Value = "0";
                CV_N1_NumDiDen.Value = "0";
                cv_panel1.Enabled = false;
            }
            else
            {
                CV_N2_ChkAll.Checked = false;
                CV_N2_ChkAll.Enabled = true;
                cv_panel1.Enabled = true;
            }
        }
    }
}