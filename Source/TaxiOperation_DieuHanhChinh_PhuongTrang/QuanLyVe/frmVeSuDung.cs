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
    public partial class frmVeSuDung : Form
    {
        private KhachHang g_objKhachHang = new KhachHang();
        private bool  g_ThemMoi = false ;

        DateTime g_NgaySuDung; //phuc vu xoa        
        int g_SeriDau;    //phuc vu xoa

        public frmVeSuDung()
        {
            InitializeComponent();
        }
        private void frmVeSuDung_Load(object sender, EventArgs e)
        {

            LockControl(); g_ThemMoi = false;
            LoadDSVeSuDung();
        }

        private void LockControl()
        {
            calNgaySuDung.Enabled = false;
            lblHopDong.Text = ""; lblHopDong.Visible = false;
            numSeriDau.Enabled = false; numSeriDau.Value = 0;
            numSoTien.Enabled = false; numSoTien.Value = 0;
            txtGhiChu.Enabled = false; txtGhiChu.Text = "";
            txtSoHieuXe.Enabled = false; txtSoHieuXe.Text = "";
          

            btnThemMoi.Enabled = true;
            btnHuyBo.Enabled = false ;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = true;
        }
        private void UnLockControl()
        {
            calNgaySuDung.Enabled = true;
             lblHopDong.Visible = false;
            numSeriDau.Enabled = true;
            numSoTien.Enabled = true;
            txtGhiChu.Enabled = true;  
            txtSoHieuXe.Enabled = true;  ;

            btnThemMoi.Enabled = false;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnXuatExcel.Enabled = true;
        }
       
         
        /// <summary>
        /// Load ds ve da su dung
        /// </summary>
        private void LoadDSVeSuDung()
        {
            grdVeSuDung.DataMember = "ListVeSuDung";
            grdVeSuDung.SetDataBinding(Ve.GetDSVeSuDung(), "ListVeSuDung");  
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
            DateTime NgaySuDung = DateTime.MinValue;             
            int SeriDau = -1;
            int SoTien = -1;
            string GhiChu = "";
            string SoHieuXe = "";

            try
            {
                NgaySuDung = calNgaySuDung.Value;                 
                SeriDau = int.Parse(numSeriDau.Value.ToString());
                SoTien =   int.Parse(numSoTien.Value.ToString());
                GhiChu = StringTools.TrimSpace(txtGhiChu.Text);
                SoHieuXe = StringTools.TrimSpace(txtSoHieuXe.Text);
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
            }

            //// check validate du lieu
         
            if (SeriDau <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin seri đầu của hợp đồng."); return;
            }
            if (SoTien <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin số tiền."); return;
            }
            
            //KIEM TRADA PHAT HANH
            DataTable dt = Ve.GetVePhatHanhBySeri(SeriDau);
            if (!((dt != null) && (dt.Rows.Count > 0)))
            {
                new MessageBox.MessageBoxBA().Show("Seri đầu này không có trong dữ liệu vé phát hành.Bạn cần kiểm tra lại dữ  liệu nhập.");
                return;
            }


            if (g_ThemMoi) // chen mới
            {
                bool bSuccess = Ve.InsertVeSuDung(NgaySuDung, SeriDau, SoHieuXe,SoTien, GhiChu);
                if (bSuccess)
                {
                    LoadDSVeSuDung();
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
                bool bSuccess = Ve.UpdateVeSuDung(NgaySuDung, SeriDau, SoHieuXe,SoTien, GhiChu); 
                if (bSuccess)
                {
                    LoadDSVeSuDung();
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
                 grdVeSuDung.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                 if (grdVeSuDung.SelectedItems.Count > 0)
                 {
                      
                     UnLockControl(); btnXoa.Enabled = true; g_ThemMoi = false;
                     calNgaySuDung.Value = DateTime.Parse(grdVeSuDung.SelectedItems[0].GetRow().Cells["NgaySuDung"].Value.ToString());
                     numSeriDau.Value = grdVeSuDung.SelectedItems[0].GetRow().Cells["SeriDau"].Value;
                     numSoTien.Value = grdVeSuDung.SelectedItems[0].GetRow().Cells["SoTien"].Value;
                     txtGhiChu.Text = grdVeSuDung.SelectedItems[0].GetRow().Cells["GhiChu"].Value.ToString();
                     txtSoHieuXe.Text = grdVeSuDung.SelectedItems[0].GetRow().Cells["SoHieuXe"].Value.ToString();
                     //@NgayHuy datetime,
                     //@SoHopDong int,
                     //@SeriDau int,	 
                     //@FK_IDKhachHang int
                     g_NgaySuDung = calNgaySuDung.Value;
                     g_SeriDau = int.Parse(numSeriDau.Value.ToString());
                 }
             }
        }
        
        private void grdVePhatHanh_DoubleClick(object sender, EventArgs e)
        {
           
                grdVeSuDung.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdVeSuDung.SelectedItems.Count > 0)
                {

                    UnLockControl(); btnXoa.Enabled = true; g_ThemMoi = false;
                    calNgaySuDung.Value = DateTime.Parse(grdVeSuDung.SelectedItems[0].GetRow().Cells["NgaySuDung"].Value.ToString());
                    numSeriDau.Value = grdVeSuDung.SelectedItems[0].GetRow().Cells["SeriDau"].Value;
                    numSoTien.Value = grdVeSuDung.SelectedItems[0].GetRow().Cells["SoTien"].Value;
                    txtGhiChu.Text = grdVeSuDung.SelectedItems[0].GetRow().Cells["GhiChu"].Value.ToString();
                    txtSoHieuXe.Text = grdVeSuDung.SelectedItems[0].GetRow().Cells["SoHieuXe"].Value.ToString();
                    //@NgayHuy datetime,
                    //@SoHopDong int,
                    //@SeriDau int,	 
                    //@FK_IDKhachHang int
                    g_NgaySuDung = calNgaySuDung.Value;
                    g_SeriDau = int.Parse(numSeriDau.Value.ToString());
                }
             
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (g_NgaySuDung != DateTime.MinValue)
            {
                if (new MessageBox.MessageBoxBA().Show("Bạn có đồng ý xóa vé phát hành không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {

                    bool bSuccess = Ve.DeleteVeSuDung(g_NgaySuDung, g_SeriDau); 
                    if (bSuccess)
                    {
                        LoadDSVeSuDung();
                        new MessageBox.MessageBoxBA().Show("Xóa vé thành công.");
                        
                        numSeriDau.Value = 0;
                        numSoTien.Value = 0;
                        txtSoHieuXe.Text = "";                       
                        txtGhiChu.Text = "";
                        g_NgaySuDung = DateTime.MinValue;
                        LockControl();
                        return;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi xóa vé."); return;
                    }
                }

            }
            else new MessageBox.MessageBoxBA().Show("Bạn chọn vé để xóa.");
        }
        /// <summary>
        /// tính số lượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numSeriDau_ValueChanged(object sender, EventArgs e)
        {

            //int SeriDau = -1;
            //int SeriCuoi = -1;


            //try
            //{

            //    SeriDau = int.Parse(numSeriDau.Value.ToString());
                 
            //    if (SeriDau > 0)
            //    {
            //        DataTable dt = Ve.GetVePhatHanhBySeri(SeriDau);
            //        if ((dt != null) && (dt.Rows.Count > 0))
            //        {
            //           lblHopDong.Text  = "["+dt.Rows[0]["SoLuong"].ToString()+"] " +  dt.Rows[0]["FK_IDKhachHang"].ToString() ;
                         
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    new MessageBox.MessageBox().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
            //}
        }

        private void numSeriCuoi_ValueChanged(object sender, EventArgs e)
         {
        //    int SeriDau = -1;
        //    int SeriCuoi = -1;


        //    try
        //    {

        //        SeriDau = int.Parse(numSeriDau.Value.ToString());
        //        SeriCuoi = int.Parse(numSeriCuoi.Value.ToString());
        //        if ((SeriDau > 0) && (SeriDau <= SeriCuoi))
        //        {
        //            numSoLuong.Text = string.Format("{0}", SeriCuoi - SeriDau + 1);
        //        }

        //        // lay du lieu cong ty hop dong
        //        if (SeriCuoi > 0)
        //        {
        //            DataTable dt = Ve.GetVePhatHanhBySeri(SeriCuoi);
        //            if ((dt != null) && (dt.Rows.Count > 0))
        //            {
        //                cboKhachHang.SelectedValue = (object)(dt.Rows[0]["FK_IDKhachHang"].ToString());
        //                numSoHopDong.Text = dt.Rows[0]["SoLuong"].ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        new MessageBox.MessageBox().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
        //    }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

            string FilenameDefault = "DanhMucSuDung.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                objFile.Close();
            }
        }

        private void numSeriDau_Leave(object sender, EventArgs e)
        {
            int SeriDau = -1;
              

            try
            {

                SeriDau = int.Parse(numSeriDau.Value.ToString());

                if (SeriDau > 0)
                {
                    DataTable dt = Ve.GetVePhatHanhBySeri(SeriDau);
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        lblHopDong.Text = "[" + dt.Rows[0]["SoLuong"].ToString() + "] " + dt.Rows[0]["TenKhachHang"].ToString();
                        lblHopDong.Visible = true;
                    }
                    else { numSeriDau.Focus(); lblHopDong.Text = ""; lblHopDong.Visible = false; new MessageBox.MessageBoxBA().Show("Vé chưa có trong dữ liệu phát hành. Bạn cần kiểm tra lại hoặc nhập thêm vào dữ liệu vé phát hành."); }
                }
                
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
            }
        }

      

              
    }
}