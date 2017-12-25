using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business.BanGiaGoc;

namespace Taxi.GUI
{
    public partial class frmTraCuuBangGiaGoc : Form
    {
        int Flat = 0;
        string TuyenDuongID = "";
        int LoaixeID = 0;
        bool g_IsQuanToan = false;
        public frmTraCuuBangGiaGoc()
        {
            InitializeComponent();
        }
        private void frmNhapBangGiaGoc_Load(object sender, EventArgs e)
        {
           
          
            cboKieuTuyen.SelectedIndex = 0;
            LoadTuyenDuong();
          
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
        public void LoadGiaGoc(bool IsQuanToan, string MaTuyenDuong)
        {
            Dulieudauvaotinhtien objDuLieuDauVao = new Dulieudauvaotinhtien();         
            grdLoaiXeTuyenDuong.AutoGenerateColumns = false;
            grdLoaiXeTuyenDuong.DataSource = objDuLieuDauVao.GetDSGiaCuaMotTuyen(IsQuanToan, MaTuyenDuong);
         
 
        }
         
        private void lstTuyenDuong_SelectedValueChanged(object sender, EventArgs e)
        { 
             string MaTuyenDuong =  lstTuyenDuong.SelectedValue .ToString ();
             LoadGiaGoc(g_IsQuanToan, MaTuyenDuong);       
        }
    }
}