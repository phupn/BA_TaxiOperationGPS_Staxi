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
    public partial class frmVePhatHanh : Form
    {
        private KhachHang g_objKhachHang = new KhachHang();
        private bool  g_ThemMoi = false ;

        DateTime  g_Ngay;
        int g_SoHopDong;
        int g_IDKhachHang;

        public frmVePhatHanh()
        {
            InitializeComponent();
        }
        private void frmVePhatHanh_Load(object sender, EventArgs e)
        {

            LockControl(); g_ThemMoi = false;
            //load ds khach hang
            LoadDSKhachHang();
            LoadDSVePhatHanh();
        }

        private void LockControl()
        {
            calNgayPhatHanh.Enabled = false;
            cboKhachHang.Enabled = false;
            numSoHopDong.Enabled = false; numSoHopDong.Value = 0;
            numSeriDau.Enabled = false; numSeriDau.Value = 0;
            numSeriCuoi.Enabled = false; numSeriCuoi.Value = 0;
            numSoLuong.Enabled = false; numSoLuong.Value = 0;
            txtGhiChu.Enabled = false; txtGhiChu.Text = "";


            btnThemMoi.Enabled = true;
            btnHuyBo.Enabled = false ;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = true;
        }
        private void UnLockControl()
        {

            calNgayPhatHanh.Enabled = true;
            cboKhachHang.Enabled = true;
            numSoHopDong.Enabled = true;
            numSeriDau.Enabled = true;
            numSeriCuoi.Enabled = true;
            numSoLuong.Enabled = true;
            txtGhiChu.Enabled = true;


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
            cboKhachHang.DisplayMember = "TenKhachHang";
            cboKhachHang.ValueMember = "IDKhachHang";
            cboKhachHang.DataSource = KhachHang.GetDSKhachHang("");
              
        }
        /// <summary>
        /// Load ds ve phat hanh
        /// </summary>
        private void LoadDSVePhatHanh()
        {
            grdVePhatHanh.DataMember = "ListVePhatHanh";
            grdVePhatHanh.SetDataBinding(Ve.GetDSVePhatHanh() , "ListVePhatHanh");  
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
            
           
            //GetDuLieu nhap
            DateTime Ngay = DateTime.MinValue ;
            int IDKhachHang = -1;
             int SoHopDong = -1;
            int SeriDau = -1;
             int SeriCuoi = -1;
            string GhiChu = "";

            try
            {
                 Ngay = calNgayPhatHanh.Value;
                 IDKhachHang = int.Parse(cboKhachHang.SelectedValue.ToString());
                 SoHopDong = int.Parse(numSoHopDong.Value.ToString());
                 SeriDau = int.Parse(numSeriDau.Value.ToString());
                 SeriCuoi = int.Parse(numSeriCuoi.Value.ToString());
                 GhiChu = StringTools.TrimSpace(txtGhiChu.Text);
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
            }

            // check validate du lieu
            if (IDKhachHang <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin khách hàng."); return;
            }
            if (SoHopDong <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin số hợp đồng."); return;
            }
            if (SeriDau <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin seri đầu của hợp đồng."); return;
            }
            if (SeriCuoi <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin seri cuối của hợp đồng."); return;
            }
            if (SeriDau > SeriCuoi)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập seri đầu nhỏ hoặc bằng seri cuối của hợp đồng."); return;
            }

            if (g_ThemMoi) // chen mới
            {
                DataTable dt = Ve.GetVePhatHanhBySeri(SeriDau);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    new MessageBox.MessageBoxBA().Show("Seri vé này đã tồn tại trong dữ liệu vé phát hành.Bạn cần kiểm tra lại dữ  liệu nhập.");
                    return;
                }
                dt = Ve.GetVePhatHanhBySeri(SeriCuoi);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    new MessageBox.MessageBoxBA().Show("Seri vé này đã tồn tại trong dữ liệu vé phát hành.Bạn cần kiểm tra lại dữ  liệu nhập.");
                    return;
                }

                bool bSuccess = Ve.InsertVePhatHanh(Ngay, SoHopDong, SeriDau, SeriCuoi, IDKhachHang, GhiChu);
                if (bSuccess)
                {
                    LoadDSVePhatHanh();
                    new MessageBox.MessageBoxBA().Show("Thêm mới thành công.");                   
                    
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi thêm mới."); 
                }
                LockControl(); return;
            }
            else
            {
                bool bSuccess = Ve.UpdateVePhatHanh(Ngay, SoHopDong, SeriDau, SeriCuoi, IDKhachHang, GhiChu);
                if (bSuccess)
                {                    
                    LoadDSVePhatHanh();
                    new MessageBox.MessageBoxBA().Show("Cập nhật thành công.");
                    return;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi cập nhật."); return;
                }         
            }
        }

        

        private void grdVePhatHanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdVePhatHanh.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdVePhatHanh.SelectedItems.Count > 0)
                {
                    

                    UnLockControl(); btnXoa.Enabled = true; g_ThemMoi = false;
                    calNgayPhatHanh.Value = DateTime.Parse(grdVePhatHanh.SelectedItems[0].GetRow().Cells["NgayPhatHanh"].Value.ToString());
                    cboKhachHang.SelectedValue = grdVePhatHanh.SelectedItems[0].GetRow().Cells["FK_IDKhachHang"].Value ;
                    numSoHopDong.Value = grdVePhatHanh.SelectedItems[0].GetRow().Cells["SoHopDong"].Value;
                    numSeriDau.Value = grdVePhatHanh.SelectedItems[0].GetRow().Cells["SeriDau"].Value;
                    numSeriCuoi.Value = grdVePhatHanh.SelectedItems[0].GetRow().Cells["SeriCuoi"].Value;
                    txtGhiChu.Text = grdVePhatHanh.SelectedItems[0].GetRow().Cells["GhiChu"].Value.ToString ();

                    g_Ngay = DateTime.Parse(grdVePhatHanh.SelectedItems[0].GetRow().Cells["NgayPhatHanh"].Value.ToString());
                    g_SoHopDong = int.Parse(grdVePhatHanh.SelectedItems[0].GetRow().Cells["SoHopDong"].Value.ToString());
                    g_IDKhachHang = int.Parse(grdVePhatHanh.SelectedItems[0].GetRow().Cells["FK_IDKhachHang"].Value.ToString());
                }
            }
        }
        
        private void grdVePhatHanh_DoubleClick(object sender, EventArgs e)
        {
            grdVePhatHanh.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdVePhatHanh.SelectedItems.Count > 0)
            {
                grdVePhatHanh.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdVePhatHanh.SelectedItems.Count > 0)
                {


                    UnLockControl(); btnXoa.Enabled = true; g_ThemMoi = false;
                    calNgayPhatHanh.Value = DateTime.Parse(grdVePhatHanh.SelectedItems[0].GetRow().Cells["NgayPhatHanh"].Value.ToString());
                    cboKhachHang.SelectedValue = grdVePhatHanh.SelectedItems[0].GetRow().Cells["FK_IDKhachHang"].Value;
                    numSoHopDong.Value = grdVePhatHanh.SelectedItems[0].GetRow().Cells["SoHopDong"].Value;
                    numSeriDau.Value = grdVePhatHanh.SelectedItems[0].GetRow().Cells["SeriDau"].Value;
                    numSeriCuoi.Value = grdVePhatHanh.SelectedItems[0].GetRow().Cells["SeriCuoi"].Value;
                    txtGhiChu.Text = grdVePhatHanh.SelectedItems[0].GetRow().Cells["GhiChu"].Value.ToString();

                    g_Ngay = DateTime.Parse(grdVePhatHanh.SelectedItems[0].GetRow().Cells["NgayPhatHanh"].Value.ToString());
                    g_SoHopDong = int.Parse(grdVePhatHanh.SelectedItems[0].GetRow().Cells["SoHopDong"].Value.ToString());
                    g_IDKhachHang = int.Parse(grdVePhatHanh.SelectedItems[0].GetRow().Cells["FK_IDKhachHang"].Value.ToString());
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (g_Ngay != DateTime.MinValue)
            {
            if (new MessageBox.MessageBoxBA().Show("Bạn có đồng ý xóa vé phát hành không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
            {
                
                    bool bSuccess = Ve.DeleteVePhatHanh(g_Ngay, g_SoHopDong, g_IDKhachHang);
                    if (bSuccess)
                    {
                        LoadDSVePhatHanh();
                        new MessageBox.MessageBoxBA().Show("Xóa hợp đồng vé thành công.");
                        numSoHopDong.Value = 0;
                        numSeriDau.Value = 0;
                        numSeriCuoi.Value = 0;
                        numSoLuong.Value = 0; 
                        txtGhiChu.Text = "";
                        g_Ngay = DateTime.MinValue;
                        LockControl();
                        return;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi xóa hợp đồng."); return;
                    }
                }
               
            }
            else new MessageBox.MessageBoxBA().Show("Bạn chọn hợp đồng vé để xóa.");
        }
        /// <summary>
        /// tính số lượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numSeriDau_ValueChanged(object sender, EventArgs e)
        {
            
            int SeriDau = -1;
            int SeriCuoi = -1;
            

            try
            {
               
                SeriDau = int.Parse(numSeriDau.Value.ToString());
                SeriCuoi = int.Parse(numSeriCuoi.Value.ToString());
                if ((SeriDau > 0) && (SeriDau <= SeriCuoi))
                {
                    numSoLuong.Text = string.Format("{0}", SeriCuoi - SeriDau + 1);
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
            }
        }

        private void numSeriCuoi_ValueChanged(object sender, EventArgs e)
        {
            int SeriDau = -1;
            int SeriCuoi = -1;


            try
            {

                SeriDau = int.Parse(numSeriDau.Value.ToString());
                SeriCuoi = int.Parse(numSeriCuoi.Value.ToString());
                if ((SeriDau > 0) && (SeriDau <= SeriCuoi))
                {
                    numSoLuong.Text = string.Format("{0}", SeriCuoi - SeriDau + 1);
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

            string FilenameDefault = "DanhMucVePhatHanh.xls";
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