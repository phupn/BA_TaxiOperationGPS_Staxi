using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.BanGiaGoc;

namespace Taxi.Controls.ThueBaoTuyen
{
    public partial class frmTraCuuBangGiaGoc : Form
    {
        private int Flat = 0;
        private string TuyenDuongID = "";
        private int LoaixeID = 0;
        private bool g_IsQuanToan = false;
        public frmTraCuuBangGiaGoc()
        {
            InitializeComponent();
        }
        private void frmNhapBangGiaGoc_Load(object sender, EventArgs e)
        {
            cboKieuTuyen.SelectedIndex = 0;
            LoadKieuTuyenDuong();
            LoadTuyenDuong();
        }
        public void LoadKieuTuyenDuong()
        {
            try
            {
                TuyenDuong TuyendDuongcontrol = new TuyenDuong();
                DataTable dt = TuyendDuongcontrol.GetKieuTuyenDuong();
                cboKieuTuyen.DataSource = dt;
                cboKieuTuyen.DisplayMember = "KieuTuyen";
                cboKieuTuyen.ValueMember = "Id";

                cboViTri.Properties.DataSource = new AllCodeEntity().GetAllCodeByCode("DIEMXUATPHAT");
                cboViTri.Properties.DisplayMember = "Display";
                cboViTri.Properties.ValueMember = "Value";
                cboViTri.ItemIndex = 0;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadKieuTuyenDuong: ", ex);                
            }

        }

        public void LoadTuyenDuong()
        {
            int Kieutuyen = cboKieuTuyen.SelectedIndex;
            TuyenDuong TuyendDuongcontrol = new TuyenDuong();
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
        /// Hien thi ds cac gia cua cac loai xe tren mot tuyen duong
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