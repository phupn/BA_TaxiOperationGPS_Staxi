using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.QuanLyVe;
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.IO;
using Taxi.Business.DM;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmBC_5_2_ThongTinVeHuy : Form
    {
        public frmBC_5_2_ThongTinVeHuy()
        {
            InitializeComponent();
        }
        private void frmVePhatHanh_Load(object sender, EventArgs e)
        {
            btnThemMoi.Enabled = true;
            btnXuatExcel.Enabled = false;
            
            LoadDSCongTy(0);
        }
        /// <summary>
        /// load ds cong ty, đặt thông tin công ty mặc định theo id truyền vào.
        /// </summary>
        /// <param name="CongTyID"></param>
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
       
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = new DateTime(calTuNgay.Value.Year, calTuNgay.Value.Month, calTuNgay.Value.Day, 0, 0, 0);
            DateTime denNgay = new DateTime(calDenNgay.Value.Year, calDenNgay.Value.Month, calDenNgay.Value.Day, 23, 59, 59);
            int soHopDong = 0;
            int congTyID  = 0;
            int seriVe = 0;
            string tenKhachHang = string.Empty ;

            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            { 
                soHopDong = Convert.ToInt32 ( numSoHopDong.Text);
                seriVe    = Convert.ToInt32 ( numSeri.Text );
                tenKhachHang = StringTools.TrimSpace (txtTenKhachHang.Text );     
                try
                {
                    congTyID = Convert.ToInt32(cboCongTy.SelectedValue.ToString());
                }
                catch (Exception ex)
                {
                    congTyID = 0;
                }
                DataTable dt = Ve.GetBCVe(tuNgay, denNgay, soHopDong, congTyID, seriVe, tenKhachHang, chkQuyDinhHanMuc.Checked, chkHopDongHuy.Checked);
                grdVePhatHanh.DataMember = "ListVehopDong";
                grdVePhatHanh.SetDataBinding(dt, "ListVehopDong");
                if (dt != null && dt.Rows.Count > 0)
                {
                    btnXuatExcel.Enabled = true;
                    btnThemMoi.Enabled = false;
                }
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }

        }
        /// <summary>
        /// Load ds ve phat hanh
        /// </summary>
        private void LoadDSHopDongVe(int SoHopDong, DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt = Ve.GetDSVeTheoHopDong(SoHopDong, TuNgay, DenNgay);
            grdVePhatHanh.DataMember = "ListVehopDong";
            grdVePhatHanh.SetDataBinding(dt, "ListVehopDong");

            if ((dt != null) && (dt.Rows.Count > 0))
            {
                
            }
        }

        private void LoadDSVeSuDung(int SoHopDong, DateTime TuNgay, DateTime DenNgay)
        {
            
        }

         
         
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

            string FilenameDefault = "5.2BCThongTinVeHuy.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                objFile.Close();
            }
        }

        private void grdVePhatHanh_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void grdVePhatHanh_DoubleClick(object sender, EventArgs e)
        {

        }

        private void grdVePhatHanh_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void SetActiveRefreshButton()
        {
            btnXuatExcel.Enabled = false;
            btnThemMoi.Enabled = true;
        }

        private void SetUnActiveRefreshButton()
        {
            btnXuatExcel.Enabled = true;
            btnThemMoi.Enabled = false;
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void numSoHopDong_Click(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void cboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void numSeri_Click(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkHopDongHuy_CheckedChanged(object sender, EventArgs e)
        {
            
            SetActiveRefreshButton();
            numSeri.Enabled = !chkHopDongHuy.Checked;
            if (chkHopDongHuy.Checked)
            {
                numSeri.Text = "0";
            }

        } 
        
    }
}