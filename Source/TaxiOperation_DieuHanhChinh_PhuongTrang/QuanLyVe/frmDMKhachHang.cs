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

namespace Taxi.GUI
{
    public partial class frmDMKhachHang : Form
    {
        private KhachHang g_objKhachHang = new KhachHang();
        private bool  g_ThemMoi = false ;
        public frmDMKhachHang()
        {
            InitializeComponent();
        }
        private void frmDMKhachHang_Load(object sender, EventArgs e)
        {

            LockControl(); g_ThemMoi = false;
            //load ds khach hang
            LoadDSKhachHang();
        }

        private void LockControl()
        {
            txtTenKhachHang.Enabled = false; txtTenKhachHang.Text = "";
            txtDiaChi.Enabled = false; txtDiaChi.Text = "";
            txtNguoiLienHe.Enabled = false; txtNguoiLienHe.Text = "";
            txtDienThoai.Enabled = false; txtDienThoai.Text = "";
            txtNVPhuTrach.Enabled = false; txtNVPhuTrach.Text = "";

            btnThemMoi.Enabled = true;
            btnHuyBo.Enabled = false ;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void UnLockControl()
        {
            txtTenKhachHang.Enabled = true;
            txtDiaChi.Enabled = true;
            txtNguoiLienHe.Enabled = true;
            txtDienThoai.Enabled = true;
            txtNVPhuTrach.Enabled = true;

            btnThemMoi.Enabled = false ;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
        }
       

        private void LoadDSKhachHang()
        {
            grdKhachHang.DataMember = "ListKhachHang";
            grdKhachHang.SetDataBinding(KhachHang.GetDSKhachHang(""), "ListKhachHang");            
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            UnLockControl();
            g_ThemMoi = true;
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LockControl();
        } 
        private void btnLuu_Click(object sender, EventArgs e)
        {
            
           
            GetDuLieuKhachHang();
            // check validate du lieu
            if (g_objKhachHang.TenKhachHang.Length <= 0)
            {
                new MessageBox.MessageBoxBA ().Show ("Bạn phải nhập thông tin tên khách hàng.");return;
            }
            if (g_objKhachHang.DiaChi.Length <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin địa chỉ của khách hàng."); return;
            }
            if (g_objKhachHang.NguoiLienHe.Length <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin người liên hệ."); return;
            }
            if (g_objKhachHang.DienThoai.Length <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin điện thoại liên hệ."); return;
            }

            if (g_ThemMoi)
            {
                if (g_objKhachHang.Insert() > 0)
                {
                   
                    LoadDSKhachHang();
                    LockControl();
                    new MessageBox.MessageBoxBA().Show("Thêm mới khách hàng thành công.");
                    return;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách hàng."); return;
                }

                LockControl();
            }
            else
                if (g_objKhachHang.Update() )
                {
                    
                    LoadDSKhachHang();
                    LockControl();
                    new MessageBox.MessageBoxBA().Show("Cập nhật thông tin khách hàng thành công.");
                    return;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi cập nhật thông tin khách hàng."); return;
                }
        }

        private void SetDuLieuKhachHangLenForm()
        {
            if (g_objKhachHang.IDKhachHang > 0)
            {
                txtTenKhachHang.Text = g_objKhachHang.TenKhachHang;
                txtDiaChi.Text = g_objKhachHang.DiaChi;
                txtNguoiLienHe.Text = g_objKhachHang.NguoiLienHe;
                txtDienThoai.Text = g_objKhachHang.DienThoai;
                txtNVPhuTrach.Text = g_objKhachHang.MaNhanVienQuanLy;
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi lấy dữ liệu");                
                LockControl();
            }
        }

        private void GetDuLieuKhachHang()
        {
            g_objKhachHang.TenKhachHang = StringTools.TrimSpace(txtTenKhachHang.Text);
            g_objKhachHang.DiaChi = StringTools.TrimSpace(txtDiaChi.Text);
            g_objKhachHang.NguoiLienHe = StringTools.TrimSpace(txtNguoiLienHe.Text);
            g_objKhachHang.DienThoai = StringTools.TrimSpace(txtDienThoai.Text);
            g_objKhachHang.MaNhanVienQuanLy = StringTools.TrimSpace(txtNVPhuTrach.Text);
            g_objKhachHang.NgayKyKet = DateTime.Now;
        }

        private void GetDuLieuKhachHangFromGrid( int iRowPosition)
        {             
                g_objKhachHang = (KhachHang)grdKhachHang .GetRow(iRowPosition).DataRow;                
        }
        private void grdKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdKhachHang.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdKhachHang.SelectedItems.Count > 0)
                {
                    UnLockControl(); btnXoa.Enabled = true; g_ThemMoi = false;
                    GetDuLieuKhachHangFromGrid(((GridEXSelectedItem)grdKhachHang.SelectedItems[0]).Position);
                    SetDuLieuKhachHangLenForm();
                }
            }
        }

        private void grdKhachHang_DoubleClick(object sender, EventArgs e)
        {
            grdKhachHang.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdKhachHang.SelectedItems.Count > 0)
            {
                UnLockControl(); btnXoa.Enabled = true; ; g_ThemMoi = false;
                GetDuLieuKhachHangFromGrid(((GridEXSelectedItem)grdKhachHang.SelectedItems[0]).Position);
                SetDuLieuKhachHangLenForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (new MessageBox.MessageBoxBA().Show("Bạn có đồng ý xóa khách hàng ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
            {
                if (g_objKhachHang.Delete())
                {
                    
                        new MessageBox.MessageBoxBA().Show("Xóa thông tin khách hàng thành công.");
                        LoadDSKhachHang();
                        LockControl();
                        return;                    
                    
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi xóa thông tin khách hàng."); return;
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "DanhMucKhachHang.xls";
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