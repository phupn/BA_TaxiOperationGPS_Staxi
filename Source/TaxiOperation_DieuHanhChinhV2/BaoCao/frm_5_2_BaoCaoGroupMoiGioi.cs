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
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoGroupMoiGioi : Form
    {
        private fmProgress m_fmProgress = null;
        List<BacCao_CuocGoiMoiGioi> g_lstBacCao_CuocGoiMoiGioi=new List<BacCao_CuocGoiMoiGioi> ();
        

        private string g_MaNhanVien="";
        private int  g_SoChuyen = -1; // tat ca
        private int g_CongTyID = 0;
        private bool g_DaLoadDuLieu = false; // da thuc hien load du lieu
        private DataTable g_dtDuLieu;
        public frmBaoCaoGroupMoiGioi()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false ; 
            btnExportExcel.Enabled = false;  
            LoadDSCongTy(0);
        }
     
        private void LoadDSCongTy(int CongTyID)
        {
            cboCongTy.ValueMember = "CongTyID";
            cboCongTy.DisplayMember = "TenCongTy";
            cboCongTy.DataSource = null;
            cboCongTy.DataSource = CongTy.GetAllDSCongTy();

            if (CongTyID > 0)
            { 
                int iIndex = -1;
                foreach (Janus.Windows.EditControls.UIComboBoxItem objItem in cboCongTy.Items)
                {
                    iIndex += 1;
                    if (objItem.Value.ToString() == CongTyID.ToString())
                    {
                        break;
                    }
                }
                cboCongTy.SelectedIndex = iIndex;
            }
        }

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true; 
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            g_DaLoadDuLieu = false;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                int CongtyID = 0;
                try
                {
                    CongtyID = int.Parse( cboCongTy.SelectedValue.ToString()); 
                }
                catch (Exception ex)
                
                { }
                g_dtDuLieu = TimKiem_BaoCao.MoiGioi_GetBaoCaoGroupMoiGioi(calTuNgay.Value, calDenNgay.Value, CongtyID);                 
                gridDienThoai.DataMember = "ListDienThoai";
                gridDienThoai.SetDataBinding(g_dtDuLieu, "ListDienThoai");

                gridCuoc999.DataMember = "ListCuoc999";
                gridCuoc999.SetDataBinding(TimKiem_BaoCao.MoiGioi_GetChiTietCuoc999(calTuNgay.Value, calDenNgay.Value, CongtyID), "ListCuoc999");

                gridCuocTuXoa.DataMember = "ListCuocTuXoa";
                gridCuocTuXoa.SetDataBinding(TimKiem_BaoCao.MoiGioi_GetChiTietCuocTuXoa(calTuNgay.Value, calDenNgay.Value, CongtyID), "ListCuocTuXoa");


                gridDienThoai.Visible = true ;
                gridCuoc999.Visible = false;
                gridCuocTuXoa.Visible = false ;

                SetUnActiveRefreshButton();  
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }
 
        private void editPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit ( e.KeyChar) || (e.KeyChar == (char) Keys.Back ))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editSoChuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar ==(char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editPhut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        } 
        private void gridDienThoai_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            
        } 
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BaoCao_MoiGioi_TongHop.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (gridDienThoai.Visible)
                    {
                        gridEX1.Visible = true;
                        gridEX1.DataMember = "ListDienThoai";
                        gridEX1.SetDataBinding(g_dtDuLieu, "ListDienThoai");

                        gridEXExporter1.GridEX = this.gridEX1;
                    }
                    else if (gridCuoc999.Visible)
                    {
                        gridEXExporter1.GridEX = this.gridCuoc999 ;
                    }
                    else if (gridCuocTuXoa.Visible)
                    {
                        gridEXExporter1.GridEX = this.gridCuocTuXoa;
                    }
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export((Stream)objFile);
                    gridEX1.Visible = false;
                    new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                gridEX1.Visible = false;
                new MessageBox.MessageBoxBA().Show("Có lỗi tạo file Excel.", "Thông báo");
            }
        } 
        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void editNhanVien_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void cboNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void editSochuyen_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radSapXepMaKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radSapXepSoChuyen_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void intSoChuyen_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void cboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetActiveRefreshButton();
            try
            {
                g_CongTyID = int.Parse(cboCongTy.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                g_CongTyID = 0;
            }
        }

        private void lnkCuocKhach999_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridDienThoai.Visible = false ;
            gridCuoc999.Visible = true ;
            gridCuocTuXoa.Visible = false;
        }

        private void lnkCuocXoaTuDong_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridDienThoai.Visible = false ;
            gridCuoc999.Visible = false;
            gridCuocTuXoa.Visible = true ;
        }

        private void lnkTongHop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridDienThoai.Visible = true;
            gridCuoc999.Visible = false;
            gridCuocTuXoa.Visible = false;
        }
        
    }
}