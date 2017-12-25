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
using Taxi.Business;
using System.Runtime.InteropServices;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmTheHuy : Form
    {
         
        private bool  g_ThemMoi = false ;
       
        int  g_MaDonViVe = 0;
        DateTime g_Ngay;
        public frmTheHuy()
        {
            InitializeComponent();
        }
        private void frmVeHuy_Load(object sender, EventArgs e)
        {
            LockControl(); g_ThemMoi = false;
            LoadDSTheHuy();
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

        /// <summary>
        /// set don vi quan lý ve
        /// và - lý do hủy
        /// </summary>
        private void SetGiaTriMacDinh()
        {
          
        }

        private void LockControl()
        {
            calNgayPhatHanh.Enabled = false;
            cboCongTy.Enabled = false;
            txtTenKhachHang.Enabled = false;
            txtGhiChu.Enabled = false; 
            txtGhiChu.Text = "";
            txtMaSoThe.Enabled = false; txtMaSoThe.Text = "";
            btnThemMoi.Enabled = true;
            btnHuyBo.Enabled = false ;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = true;
        }
        private void UnLockControl()
        {
            calNgayPhatHanh.Enabled = true;
            cboCongTy.Enabled = true;
            txtGhiChu.Enabled = true;
            txtTenKhachHang.Enabled = true;
            txtMaSoThe.Enabled = true;  
            btnThemMoi.Enabled = false;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnXuatExcel.Enabled = true;
        }
       
        /// <summary>
        /// load ds khach hang cho vo combo
        /// </summary>
        private void LoadDSKhachHang()
        {
          //  cboKhachHang.DisplayMember = "TenKhachHang";
           // cboKhachHang.ValueMember = "IDKhachHang";
          //  cboKhachHang.DataSource = KhachHang.GetDSKhachHang("");
              
        }
        /// <summary>
        /// Load ds ve phat hanh
        /// </summary>
        private void LoadDSTheHuy()
        {
            grdTheHuy.DataMember = "ListTheHuy";
            grdTheHuy.SetDataBinding(The.GetDSThe (), "ListTheHuy");  
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            UnLockControl();
            g_ThemMoi = true;
            calNgayPhatHanh.Focus();
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LockControl();
        } 
        private void btnLuu_Click(object sender, EventArgs e)
        { 
            //GetDuLieu nhap
            DateTime Ngay = DateTime.MinValue;            
            string GhiChu = "";           
            string TenKhachHang ="";
            int MaDonViVe=0;
            string MaSoThe = "";
             
            try
            {
                Ngay = calNgayPhatHanh.Value;
                TenKhachHang = StringTools.TrimSpace (txtTenKhachHang .Text );
                MaDonViVe = Convert.ToInt32(cboCongTy.SelectedValue.ToString());
                GhiChu = StringTools.TrimSpace(txtGhiChu.Text);
                MaSoThe = StringTools.TrimSpace(txtMaSoThe.Text);
                
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
            }  
            if (g_ThemMoi) // chen mới
            {
                DataTable dt = The.GetChiTietThe(MaSoThe,MaDonViVe,calNgayPhatHanh.Value.Year);
                if((dt!=null) && (dt.Rows.Count>0))
                {
                    new MessageBox.MessageBoxBA().Show("Đã tồn tại mã thẻ.Bạn cần kiểm tra lại.");
                    return;
                }
                 
                bool bSuccess = The.Insert(MaSoThe, Ngay, TenKhachHang, GhiChu, MaDonViVe);
                if (bSuccess)
                {
                    LoadDSTheHuy();
                    new MessageBox.MessageBoxBA().Show("Thêm mới thành công.");
                    UnLockControl();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi thêm mới.");
                }
                LockControl(); return;
            }
            else
            { 

            }
        }

        

        private void grdVePhatHanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdTheHuy.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdTheHuy.SelectedItems.Count > 0)
                {


                    UnLockControl(); btnXoa.Enabled = true; g_ThemMoi = false; btnLuu.Enabled = false;
                    calNgayPhatHanh.Value = DateTime.Parse(grdTheHuy.SelectedItems[0].GetRow().Cells["NgayHuy"].Value.ToString());
                     
                    g_Ngay = calNgayPhatHanh.Value;
                    txtGhiChu.Text = grdTheHuy.SelectedItems[0].GetRow().Cells["GhiChu"].Value.ToString();
                    cboCongTy.SelectedValue = grdTheHuy.SelectedItems[0].GetRow().Cells["MaDonViVe"].Value;
                    txtMaSoThe.Text = grdTheHuy.SelectedItems[0].GetRow().Cells["MaSoThe"].Value.ToString ();
                    txtTenKhachHang.Text = grdTheHuy.SelectedItems[0].GetRow().Cells["TenCongTy"].Value.ToString();
                    //@NgayHuy datetime,
                    //@SoHopDong int,
                    //@SeriDau int,	 
                    //@FK_IDKhachHang int
                    g_MaDonViVe = Convert.ToInt32(cboCongTy.SelectedValue.ToString());
                }
            }
        }
        
        private void grdVePhatHanh_DoubleClick(object sender, EventArgs e)
        {
            grdTheHuy.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdTheHuy.SelectedItems.Count > 0)
            {
                UnLockControl(); btnXoa.Enabled = true; g_ThemMoi = false; btnLuu.Enabled = false;
                calNgayPhatHanh.Value = DateTime.Parse(grdTheHuy.SelectedItems[0].GetRow().Cells["NgayHuy"].Value.ToString());
                g_Ngay = calNgayPhatHanh.Value;                 
                 txtGhiChu.Text = grdTheHuy.SelectedItems[0].GetRow().Cells["GhiChu"].Value.ToString();
                 cboCongTy.SelectedValue = grdTheHuy.SelectedItems[0].GetRow().Cells["MaDonViVe"].Value;
                 txtMaSoThe.Text = grdTheHuy.SelectedItems[0].GetRow().Cells["MaSoThe"].Value.ToString ();
                 txtTenKhachHang.Text = grdTheHuy.SelectedItems[0].GetRow().Cells["TenCongTy"].Value.ToString();
                //@NgayHuy datetime,
                //@SoHopDong int,
                //@SeriDau int,	 
                //@FK_IDKhachHang int
                 g_MaDonViVe = Convert.ToInt32(cboCongTy.SelectedValue.ToString());
                
           }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (g_Ngay != DateTime.MinValue)
            {
                if (new MessageBox.MessageBoxBA().Show("Bạn có đồng ý xóa thẻ hủy không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {

                    bool bSuccess = The.Delete(txtMaSoThe.Text, g_MaDonViVe);
                    if (bSuccess)
                    {
                        LoadDSTheHuy();
                        new MessageBox.MessageBoxBA().Show("Xóa thẻ thành công.");
                        txtGhiChu.Text = "";

                        LockControl();
                        return;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi xóa thẻ."); return;
                    }
                }

            }
            else new MessageBox.MessageBoxBA().Show("Bạn chọn thẻ để xóa.");
        }
       
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

            string FilenameDefault = "DanhMucVeHuy.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                objFile.Close();
            }
        }

      

              
    }
}