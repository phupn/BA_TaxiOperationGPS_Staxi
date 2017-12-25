using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.BanGiaGoc;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmNhapBangGiaGoc : Form
    {
        int Flat = 0;
        string TuyenDuongID = "";
        int LoaixeID = 0;
        bool g_IsQuanToan = false;
        public frmNhapBangGiaGoc()
        {
            InitializeComponent();
        }
        private void frmNhapBangGiaGoc_Load(object sender, EventArgs e)
        {
            LoadLoaiXe();
            
            cboKieuTuyen.SelectedIndex = 0;
            //LoadTuyenDuong();
            Lock();
            cboViTri.SelectedIndex = 0;
            g_IsQuanToan = (bool)cboViTri.SelectedValue;
        }
        public void LoadTuyenDuong()
        {
            int Kieutuyen;
            Kieutuyen = cboKieuTuyen.SelectedIndex;
            Taxi.Business.BanGiaGoc.TuyenDuong TuyendDuongcontrol = new Taxi.Business.BanGiaGoc.TuyenDuong();
            DataTable dt = TuyendDuongcontrol.TableTuyenDuong(Kieutuyen);

            lstTuyenDuong.DataSource = dt;
            lstTuyenDuong.DisplayMember = "TenTuyenDuong";
            lstTuyenDuong.ValueMember = "TuyenDuongID";
        }
        private void cboKieuTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTuyenDuong();
        }


        /// <summary>
        /// hien thi ds cac gia cua cac loai xe tren mot tuyen duong
        /// </summary>
        /// <param name="IsQuanToan"></param>
        /// <param name="MaTuyenDuong"></param>
        public void LoadGiaGoc(bool IsQuanToan, string MaTuyenDuong)
        {
            Dulieudauvaotinhtien objDuLieuDauVao = new Dulieudauvaotinhtien();         
            grdLoaiXeTuyenDuong.AutoGenerateColumns = false;
            grdLoaiXeTuyenDuong.DataSource = objDuLieuDauVao.GetDSGiaCuaMotTuyen(IsQuanToan, MaTuyenDuong);
         
 
        }
         
        public void LoadGiaGoc()
        {
            int Loaixeid = 0;
           
            try { Loaixeid = Convert.ToInt32(cboLoaiXe.SelectedValue); }
            catch { return; }


            Taxi.Business.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Business.BanGiaGoc.Dulieudauvaotinhtien();
            List<Dulieudauvaotinhtien> ListDulieudauvaotinhtien;
            if (Loaixeid > 0)
            {
              ListDulieudauvaotinhtien = DulieudauvaotinhtienControl.GetAllGroupLoaixe(g_IsQuanToan , Loaixeid);
            }
            else
            {
                ListDulieudauvaotinhtien = DulieudauvaotinhtienControl.GetAll(g_IsQuanToan);
            }
           // DataTable dt = DulieudauvaotinhtienControl.GetAll();
            grdLoaiXeTuyenDuong.AutoGenerateColumns = false;
            grdLoaiXeTuyenDuong.DataSource = ListDulieudauvaotinhtien;
          
            
        //    grdLoaiXeTuyenDuong.b
        //    grdLoaiXeTuyenDuong.DataBindingComplete();
        }
        public void LoadLoaiXe()
        {
            Taxi.Business.DM.LoaiXe LoaiXecontrol = new Taxi.Business.DM.LoaiXe();
            DataTable dt = LoaiXecontrol.GetAll();
            cboLoaiXe.DataSource = dt;
            cboLoaiXe.DisplayMember = "TenLoaiXe";

            cboLoaiXe.ValueMember = "LoaiXeID"; 
        
        }
      
        public void Lock()
        {
            txtGiaTien1Chieu.Enabled = false;
            txtGiaTien2Chieu.Enabled = false;
            
            btnHuybo.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThemMoi.Enabled = true;
        }
        public void UnLock()
        {
            txtGiaTien1Chieu.Enabled = true;
            txtGiaTien2Chieu.Enabled = true;       
            btnHuybo.Enabled = true;
            btnLuu.Enabled = true;
            btnThemMoi.Enabled = false ;
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            UnLock();
            Flat = 1;
            Clearcontrol();
            cboLoaiXe .Focus();

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Taxi.Business.BanGiaGoc.Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Taxi.Business.BanGiaGoc.Dulieudauvaotinhtien();
            if (CheckGiatrinhapvao() == false)
            {
                new MessageBox.MessageBoxBA().Show("Bạn cần nhập đầy đủ thông tin");
            }
            else
            {
                if (Chechvalue() == true)
                { 
                    try
                    {
                        DulieudauvaotinhtienControl.GiaTien1Chieu = Convert.ToDouble(txtGiaTien1Chieu.Text);
                        DulieudauvaotinhtienControl.GiaTien2Chieu = Convert.ToDouble(txtGiaTien2Chieu.Text);
                        DulieudauvaotinhtienControl.KmQuyDinh1Chieu = Convert.ToDouble(txtKmQD1Chieu.Text);
                        DulieudauvaotinhtienControl.KmQuyDinh2Chieu = Convert.ToDouble(txtKmQD2Chieu.Text);
                        DulieudauvaotinhtienControl.ThoiGianQuyDinh1Chieu = Convert.ToDouble(txtThoiGianQD1Chieu.Text);
                        DulieudauvaotinhtienControl.ThoiGianQuyDinh2Chieu = Convert.ToDouble(txtThoiGianQD2Chieu.Text);
                        DulieudauvaotinhtienControl.IsQuanToan = (bool)cboViTri.SelectedValue;
                        DulieudauvaotinhtienControl.VeTram =   StringTools.TrimSpace (txtVeTram.Text); 
                        string TuyenDuong = lstTuyenDuong.Text;
                        Taxi.Business.BanGiaGoc.TuyenDuong TuyenDuongControl = new Taxi.Business.BanGiaGoc.TuyenDuong();
                        Dulieudauvaotinhtien Dulieudauvaotinhtienobj = new Dulieudauvaotinhtien(); 
                        if (Flat == 1)
                        {
                            // Kiểm tra tuyến đưồng loại xe này đã có dữ liệu chua

                            DulieudauvaotinhtienControl.TuyenDuongID = lstTuyenDuong.SelectedValue.ToString();
                            try
                            {
                                string S = cboLoaiXe.SelectedValue.ToString();
                                DulieudauvaotinhtienControl.LoaiXeID = Convert.ToInt32(S);
                            }
                            catch
                            {
                                new MessageBox.MessageBoxBA().Show("Bạn chọn Tuyến đường !");
                                return;
                            }

                            //Kiem tra dữ liệu tuyến đuwongf loại xe đã tồn tại chưa
                            ///
                            Dulieudauvaotinhtienobj = DulieudauvaotinhtienControl.Selectone(g_IsQuanToan, DulieudauvaotinhtienControl.TuyenDuongID, DulieudauvaotinhtienControl.LoaiXeID);

                            if (Dulieudauvaotinhtienobj != null)
                            {

                                if (Dulieudauvaotinhtienobj.LoaiXeID == DulieudauvaotinhtienControl.LoaiXeID && DulieudauvaotinhtienControl.TuyenDuongID == Dulieudauvaotinhtienobj.TuyenDuongID)
                                {
                                    new MessageBox.MessageBoxBA().Show("Dữ liệu nhập cho loại xe trên tuyến đường này đã có.");
                                }
                                else
                                {
                                    int so = DulieudauvaotinhtienControl.insert(DulieudauvaotinhtienControl);
                                    if (so > 0)
                                    {
                                        Lock();
                                        string MaTuyenDuong = lstTuyenDuong.SelectedValue.ToString();
                                        LoadGiaGoc(g_IsQuanToan, MaTuyenDuong);                                        
                                        new MessageBox.MessageBoxBA().Show("Cập nhật thành công");
                                       
                                    }
                                    else
                                    {
                                        new MessageBox.MessageBoxBA().Show("Cập nhật không thành công");
                                    }
                                }
                            }
                            else
                            {

                                int so = DulieudauvaotinhtienControl.insert(DulieudauvaotinhtienControl);
                                if (so > 0)
                                {
                                    new MessageBox.MessageBoxBA().Show("Cập nhật thành công");
                                    Lock();
                                    string MaTuyenDuong = lstTuyenDuong.SelectedValue.ToString();
                                    LoadGiaGoc(g_IsQuanToan, MaTuyenDuong);    
                                }
                                else
                                {
                                    new MessageBox.MessageBoxBA().Show("Cập nhật không thành công");
                                }
                            }
                        }
                        else if (Flat == 2)
                        {
                            DulieudauvaotinhtienControl.TuyenDuongID = TuyenDuongID;

                            DulieudauvaotinhtienControl.LoaiXeID = LoaixeID;
                            int so = DulieudauvaotinhtienControl.Update(DulieudauvaotinhtienControl);
                            if (so > 0)
                            {
                                new MessageBox.MessageBoxBA().Show("Cập nhật thành công");
                                Lock();
                                string MaTuyenDuong = lstTuyenDuong.SelectedValue.ToString();
                                LoadGiaGoc(g_IsQuanToan, MaTuyenDuong); 
                            }
                            else
                            {
                                new MessageBox.MessageBoxBA().Show("Cập nhật không thành công");
                            }
                        }



                    }
                    catch

                    { new MessageBox.MessageBoxBA().Show("Bạn cận chọn Tuyến đường !"); }
                }
            }
            
        }
        public bool CheckGiatrinhapvao()
        {
            if (txtGiaTien1Chieu.Text == "")
                return false;
            if (txtGiaTien2Chieu.Text == "")
                return false;
            if (txtKmQD1Chieu.Text == "")
                return false;
            if (txtKmQD2Chieu.Text == "")
                return false;
            if (txtThoiGianQD1Chieu.Text == "")
                return false;
            if (txtThoiGianQD2Chieu.Text == "")
                return false;


            return true; 
        
        }
       public bool Chechvalue()
        {
            try
            {
                double txtKmQD1Chieus = Convert.ToDouble(txtKmQD1Chieu.Text);
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Km quy định 1 chiều không đúng định dạng");
                return false; 
            }
            try
            {
                double txtKmQD2Chieus = Convert.ToDouble(txtKmQD2Chieu.Text);
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Km quy định 2 chiều không đúng định dạng");
                return false; 
            }
            try
            {
                double txtKmQD1Chieus = Convert.ToDouble(txtThoiGianQD1Chieu.Text);
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Thời  gian quy định 1 chiều không đúng định dạng");
                return false; 
            }
            try
            {
                double txtKmQD2Chieus = Convert.ToDouble(txtThoiGianQD2Chieu.Text);
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Thời  gian quy định 2 chiều không đúng định dạng");
                return false; 
            }
            try
            {
                double txtKmQD2Chieus = Convert.ToDouble(txtGiaTien1Chieu.Text);
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Giá tiền 1  chiều không đúng định dạng");
                return false; 
            }
            try
            {
                double txtKmQD2Chieus = Convert.ToDouble(txtGiaTien2Chieu.Text);
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Giá tiền 2  chiều không đúng định dạng");
                return false; 
            }
            return true;
        }
        public void getValue(bool IsQuanToan, string TuyenDuongID, int LoaiXe)
        {
            Dulieudauvaotinhtien Dulieudauvaotinhtienobj = new Dulieudauvaotinhtien();
            Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Dulieudauvaotinhtien();
            Dulieudauvaotinhtienobj = DulieudauvaotinhtienControl.Selectone(IsQuanToan,TuyenDuongID, LoaiXe);
            if (Dulieudauvaotinhtienobj != null)
            {
                txtGiaTien1Chieu.Text = Dulieudauvaotinhtienobj.GiaTien1Chieu.ToString();
                txtGiaTien2Chieu.Text = Dulieudauvaotinhtienobj.GiaTien2Chieu.ToString();
                txtKmQD1Chieu.Text = Dulieudauvaotinhtienobj.KmQuyDinh1Chieu.ToString();
                txtKmQD2Chieu.Text = Dulieudauvaotinhtienobj.KmQuyDinh2Chieu.ToString();
                txtThoiGianQD1Chieu.Text = Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu.ToString();
                txtThoiGianQD2Chieu.Text = Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu.ToString();
                txtVeTram.Text = StringTools.TrimSpace ( Dulieudauvaotinhtienobj.VeTram);
                cboLoaiXe.SelectedValue = LoaiXe;
            }
            else
            {
                 txtGiaTien1Chieu.Text ="";
                 txtGiaTien2Chieu.Text = "";

            }
        }
     
        private void grdLoaiXeTuyenDuong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                LoaixeID = Convert.ToInt32(grdLoaiXeTuyenDuong.Rows[row].Cells["MaLoaiXe"].Value.ToString());
                TuyenDuongID = grdLoaiXeTuyenDuong.Rows[row].Cells[0].Value.ToString();
                btnXoa.Enabled = true;
                UnLock();
                bool IsQuanToan =  cboViTri.SelectedValue.ToString() == "1" ? true : false;
                getValue(IsQuanToan,TuyenDuongID, LoaixeID);
                Flat = 2;
            }
            catch

            { }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            Lock();
            Clearcontrol();
        }

        public void Clearcontrol()
        {
            txtGiaTien1Chieu.Text = "";
             txtGiaTien2Chieu.Text = ""; 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if ((new MessageBox.MessageBoxBA().Show(this,"Bạn có đồng ý xóa xe của tuyến đường?","Thông báo",Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel ,Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())) 
            {
                Dulieudauvaotinhtien Dulieudauvaotinhtienobj = new Dulieudauvaotinhtien();
                Dulieudauvaotinhtien DulieudauvaotinhtienControl = new Dulieudauvaotinhtien();
                bool IsQuanToan = (bool)cboViTri.SelectedValue;
                int so = DulieudauvaotinhtienControl.Delete(IsQuanToan, TuyenDuongID, LoaixeID);
                if (so > 0)
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật thành công");
                    Lock();
                    string MaTuyenDuong = lstTuyenDuong.SelectedValue.ToString();
                    LoadGiaGoc(g_IsQuanToan, MaTuyenDuong);
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật không thành công");
                }
            }
            
        }
        private void cboLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboLoaiXe.SelectedValue == null) || (lstTuyenDuong.SelectedValue == null)) return;
            // Load thông tin cua một 
            LoaixeID = Convert.ToInt32(cboLoaiXe.SelectedValue.ToString ());
            TuyenDuongID = lstTuyenDuong.SelectedValue.ToString();
            btnXoa.Enabled = true;
            UnLock();
            bool IsQuanToan = cboViTri.SelectedValue.ToString() == "1" ? true : false;
            getValue(IsQuanToan, TuyenDuongID, LoaixeID);

            
        }

        private void cboViTri_SelectedValueChanged(object sender, EventArgs e)
        {
            g_IsQuanToan = (bool)cboViTri.SelectedValue ;
            string MaTuyenDuong = lstTuyenDuong.SelectedValue.ToString();
            LoadGiaGoc(g_IsQuanToan, MaTuyenDuong); 
        }

        private void txtGiaTien1Chieu_Leave(object sender, EventArgs e)
        {
            txtGiaTien2Chieu.Focus();
        }

        private void cboLoaiXe_Leave(object sender, EventArgs e)
        {
            txtGiaTien1Chieu.Focus();
        }

        private void txtGiaTien2Chieu_Leave(object sender, EventArgs e)
        {
            btnLuu.Focus();
        }

        private void txtThoiGianQD2Chieu_Leave(object sender, EventArgs e)
        {
            btnThemMoi.Focus();
        }

        private void lstTuyenDuong_Leave(object sender, EventArgs e)
        {
            txtKmQD1Chieu.Focus();
        }

        private void lstTuyenDuong_SelectedValueChanged(object sender, EventArgs e)
        {
            // get thong tin cua tuyen duong va loai xe
            // if Get (TuyenDuongID,LoaiXeID) has data then set
            // else  get (TuyenDuongID)  
            // lay gia tri dinh muc
            string MaTuyenDuong = "";
            int Loaixeid = 0;

            try
            {
                Loaixeid = Convert.ToInt32(cboLoaiXe.SelectedValue);
            }
            catch { return; }
            if (lstTuyenDuong.SelectedValue != null)
                MaTuyenDuong = lstTuyenDuong.SelectedValue.ToString();
            LoadGiaGoc(g_IsQuanToan, MaTuyenDuong);
            Dulieudauvaotinhtien objDuLieu = new Dulieudauvaotinhtien();
            Dulieudauvaotinhtien objDuLieuLay;
            objDuLieuLay = objDuLieu.Selectone(g_IsQuanToan, MaTuyenDuong, Loaixeid);
            if (objDuLieuLay == null)
            {
                List<Dulieudauvaotinhtien> listDuLieuCua1TuyenDuong = Dulieudauvaotinhtien.GetDulieuCuaMotTuyen(g_IsQuanToan, MaTuyenDuong);
                if ((listDuLieuCua1TuyenDuong != null) && (listDuLieuCua1TuyenDuong.Count > 0))
                {
                    txtKmQD1Chieu.Text = listDuLieuCua1TuyenDuong[0].KmQuyDinh1Chieu.ToString();
                    txtThoiGianQD1Chieu.Text = listDuLieuCua1TuyenDuong[0].ThoiGianQuyDinh1Chieu.ToString();
                    txtKmQD2Chieu.Text = listDuLieuCua1TuyenDuong[0].KmQuyDinh2Chieu.ToString();
                    txtThoiGianQD2Chieu.Text = listDuLieuCua1TuyenDuong[0].ThoiGianQuyDinh2Chieu.ToString();
                    txtVeTram.Text = listDuLieuCua1TuyenDuong[0].VeTram.ToString();
                }
                else
                {
                    txtKmQD1Chieu.Text = "";
                    txtThoiGianQD1Chieu.Text = "";
                    txtKmQD2Chieu.Text = "";
                    txtThoiGianQD2Chieu.Text = "";
                    txtVeTram.Text = "";

                }
            }
            else
            {
                txtKmQD1Chieu.Text = objDuLieuLay.KmQuyDinh1Chieu.ToString();
                txtThoiGianQD1Chieu.Text = objDuLieuLay.ThoiGianQuyDinh1Chieu.ToString();
                txtKmQD2Chieu.Text = objDuLieuLay.KmQuyDinh2Chieu.ToString();
                txtThoiGianQD2Chieu.Text = objDuLieuLay.ThoiGianQuyDinh2Chieu.ToString();
                txtVeTram.Text = objDuLieuLay.VeTram;
            }
            Lock();
        }

        private void lnkXoaTuyen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             string  MaTuyenDuong = lstTuyenDuong.SelectedValue.ToString();
             if (new MessageBox.MessageBoxBA().Show(this, "Bạn có đồng ý xóa tuyến đường này không? .", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
             {
                 TuyenDuong.Delete(MaTuyenDuong); LoadTuyenDuong();
             }

        }

        private void lnkThemTuyen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmTuyen().ShowDialog();

            LoadTuyenDuong();
        }

        private void lnkSuaTuyen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string TenTuyenDuong = lstTuyenDuong.Text;
            DataTable dt = new TuyenDuong().TableTuyenDuongbyTen(TenTuyenDuong);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                //[TuyenDuongID]
              //,[TenTuyenDuong]
              //,[KieuTuyenDuong]
                int KieuTuyenDuong  = Convert.ToInt16 (dt.Rows[0]["KieuTuyenDuong"].ToString());
                new frmTuyen(dt.Rows[0]["TuyenDuongID"].ToString(), dt.Rows[0]["TenTuyenDuong"].ToString(), KieuTuyenDuong).ShowDialog();
                LoadTuyenDuong();
            }
            else
                new MessageBox.MessageBoxBA().Show(this, "Lỗi không tìm thấy dữ liệu. .", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);

        }
    }
}