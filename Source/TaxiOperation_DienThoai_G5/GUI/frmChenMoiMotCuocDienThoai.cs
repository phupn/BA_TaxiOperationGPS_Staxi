using System;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Femiani.Forms.UI.Input;

namespace Taxi.GUI
{
    public partial class frmChenMoiMotCuocDienThoai : Form
    {
        private string g_Line = "";
        private KieuKhachHangGoiDen g_KieuKHGoi;
        private string g_MaDoiTac = string.Empty;
        private string g_LinesDuocCapPhep = string.Empty;
        private bool g_IsTextChange = false;
        private float g_kinhdo;
        private float g_vido;
        #region --------new v3----------------
        
        private AutoCompleteEntryCollection g_ListDataAutoComplete;
        public frmChenMoiMotCuocDienThoai(string lineCapPhep, AutoCompleteEntryCollection listDataAutoComplete)
        {
            InitializeComponent();
            g_LinesDuocCapPhep = lineCapPhep;
            g_ListDataAutoComplete = listDataAutoComplete;
        }
        #endregion

        public frmChenMoiMotCuocDienThoai(string LinesDuocCapPhep, DateTime TimeServer)
        {
            InitializeComponent();
            this.g_LinesDuocCapPhep = LinesDuocCapPhep;
        }
         
        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {
            KhoiTao();
            editPhoneNumber.Focus();
        }
        /// <summary>
        /// khoi tao cuoc goi 
        /// Line, thoi gio
        /// </summary>
        private void KhoiTao()
        {
            timer_LoadDiaChi.Start();
            g_Line = this.GetLineCuaMay();            
            g_KieuKHGoi = KieuKhachHangGoiDen.KhachHangBinhThuong;
            //lblInfo.Text = g_Line + "  " + string.Format("{0:HH:mm:ss dd/MM/yyyy}", g_TimeServer);
            editPhoneNumber.Text = Configuration.GetSoDienThoaiCongTy();
            txtDiaChiDonKhach.Text = "";
            txtDiaChiDonKhach.Items = g_ListDataAutoComplete;
        }
        /// <summary>
        /// Ham thuc hien tra ve line cua may hien tai
        /// </summary>
        private string GetLineCuaMay()
        {
            if (this.g_LinesDuocCapPhep != null && g_LinesDuocCapPhep.Length > 0)
            {
                string[] arrLine = (g_LinesDuocCapPhep.Split(";".ToCharArray()));
                string  Line = "";
                if (arrLine.Length > 0)
                {
                    Line = arrLine[0];
                }
                else Line = "1";
                            
                return Line;
            }
            return "1"; // khoong tin thay line nao
        }

        private void editPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (editPhoneNumber.Text == ThongTinCauHinh.SoDienThoaiCongTy) return;

            if (StringTools.TrimSpace(editPhoneNumber.Text).Length >= 8)
            {
                g_IsTextChange = true;
            }
        }

        /// <summary>        
        /// Input : SoDienThoai
        /// Output
        ///     : KieuKhachHangGoiDen
        ///     : DiaChicuakhach hang
        ///  //Tim trong kho Khach VIP
        ///  Tim trong kho doi tac
        ///  Tim trong kho danh ba tam
        ///  Tim trong kho danh ba buu dien
        /// </summary>
        private string GetDiaChiGoiDen(string PhoneNumber, out KieuKhachHangGoiDen outKieuKhachHang, out string MaDoiTac)
        {
            if (StringTools.TrimSpace(PhoneNumber).Length <= 0)
            {
                outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                MaDoiTac = "";
                return string.Empty;
            }

            string strDiaChiKhachAo = DanhBaKhachAo.GetDanhBa(DanhBa.GetSoDienThoaiToiThieu(PhoneNumber));

            if (strDiaChiKhachAo.Length > 0)
            {
                outKieuKhachHang = KieuKhachHangGoiDen.KhachHangKhongHieu;//khach ao
                MaDoiTac = "";
                return strDiaChiKhachAo;
            }

            // Tim kiem trong khach VIP (3_)
            DanhBaKhachQuen objKhachQuen = DanhBaKhachQuen.GetKhachQuen_Phones_Search(DanhBa.GetSoDienThoaiToiThieu(PhoneNumber));

            if (objKhachQuen != null && objKhachQuen.Name.Length > 0)
            {
                if (objKhachQuen.Type == 1)
                    outKieuKhachHang = KieuKhachHangGoiDen.KhachHangVIP;
                else if (objKhachQuen.Type > 1 && objKhachQuen.Rank == 1)
                    outKieuKhachHang = KieuKhachHangGoiDen.KhachHangVang;
                else if (objKhachQuen.Type > 1 && objKhachQuen.Rank == 2)
                    outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBac;
                else
                    outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                MaDoiTac = objKhachQuen.MaKH;

                return String.Format("[{0}]{1}", objKhachQuen.Name, objKhachQuen.Address);
            }

            // Tim kiem trong DOI TAC (2_)
            DoiTac objDoiTac = DoiTac.GetDoiTacByOPhoneNumber(DanhBa.GetSoDienThoaiToiThieu(PhoneNumber));

            if (objDoiTac != null)
            {
                outKieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                MaDoiTac = objDoiTac.MaDoiTac;
                g_kinhdo = objDoiTac.KinhDo;
                g_vido = objDoiTac.ViDo;
                return objDoiTac.Name + "-" + objDoiTac.Address;
            }

            //Tim kiem trong danh ba dien thoai cua rieng cong ty (1_)
            string strDiaChiCuocGoiGanNhat = GetDiaChiCuaCuocGoiGanNhatTrongNgay(DanhBa.GetSoDienThoaiToiThieu(PhoneNumber));

            if (strDiaChiCuocGoiGanNhat.Length > 0)
            {
                outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                MaDoiTac = "";
                return strDiaChiCuocGoiGanNhat;
            }

            // tim kiem trong danh ba cong ty
            string strDiaChiDanhBaCongTy = DanhBaCongTy.GetDanhBa(DanhBa.GetSoDienThoaiToiThieu(PhoneNumber));

            if (strDiaChiDanhBaCongTy.Length > 0)
            {
                outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;//khach ao
                MaDoiTac = "";
                return strDiaChiDanhBaCongTy;
            }

            //Tim kiem trong danh ba dien thoai (1_)
            outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
            MaDoiTac = "";
            return DanhBa.GetDanhBa(DanhBa.GetSoDienThoaiToiThieu(PhoneNumber));

        }
        /// <summary>
        /// tim dia chi cua cuoc goi gan day nhat
        /// -- uu tien tim trong cuoc goi hien tai
        /// -- tim theo cuoc goi da ket thuc trong ngay
        /// </summary>
        private string GetDiaChiCuaCuocGoiGanNhatTrongNgay(string PhoneNumber)
        {
            //Lay danh sach cac cuoc goi con hoat dong (chua ket thuc)
            return new DieuHanhTaxi().G5_GetAddressOfDienThoai(PhoneNumber);
        }

        private void btnFastTaxi_Click(object sender, EventArgs e)
        {
            //if (StringTools.TrimSpace(editPhoneNumber.Text).Length >= 8)
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                objDHTaxi.Line = g_Line;
                objDHTaxi.PhoneNumber = StringTools.TrimSpace(editPhoneNumber.Text);
                objDHTaxi.DiaChiDonKhach = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
                objDHTaxi.KieuKhachHangGoiDen = g_KieuKHGoi;
                objDHTaxi.MaDoiTac = g_MaDoiTac;
                objDHTaxi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.TrangThaiKhac; // TrangThaiCuocGoi.CuocGoiDen;// 
                //Luon luon la cuoc goi den
                objDHTaxi.TrangThaiLenh = TrangThaiLenhTaxi.KhongTruyenDi;
                objDHTaxi.SoLuotDoChuong = 1;
                objDHTaxi.GPS_KinhDo = txtDiaChiDonKhach.KinhDo;
                objDHTaxi.GPS_ViDo = txtDiaChiDonKhach.ViDo;

                bool bInsertOK = false;
                int iLan = 0;

                while ((!bInsertOK) && (iLan < 5))
                {
                    bInsertOK = objDHTaxi.Insert_DienThoai_LanDau_ToaDo_fastTaxi();
                    iLan++;
                    if (!bInsertOK)
                        System.Threading.Thread.Sleep(50);
                }
                if (!bInsertOK)
                {
                    return;
                }
                this.Close();
            }                  
        }
        
        private void timer_LoadDiaChi_Tick(object sender, EventArgs e)
        {
            if (g_IsTextChange)
            {
                if(editPhoneNumber.Text.Length>8)
                    txtDiaChiDonKhach.Text = StringTools.TrimSpace(GetDiaChiGoiDen(StringTools.TrimSpace(editPhoneNumber.Text), out  g_KieuKHGoi, out g_MaDoiTac));
                g_IsTextChange = false;
            }
        }
        private void editPhoneNumber_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChiDonKhach_Load(object sender, EventArgs e)
        {

        }

        private void cbkGoiLai_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
            objDHTaxi.Line = g_Line;
            objDHTaxi.PhoneNumber = StringTools.TrimSpace(editPhoneNumber.Text);
            objDHTaxi.DiaChiDonKhach = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
            objDHTaxi.KieuKhachHangGoiDen = g_KieuKHGoi;
            objDHTaxi.MaDoiTac = g_MaDoiTac;
            objDHTaxi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.TrangThaiKhac; // TrangThaiCuocGoi.CuocGoiDen;// 
            //Luon luon la cuoc goi den
            objDHTaxi.TrangThaiLenh = TrangThaiLenhTaxi.KhongTruyenDi;
            objDHTaxi.SoLuotDoChuong = 1;
            if (g_vido > 0 && g_kinhdo > 0)
            {
                objDHTaxi.GPS_KinhDo = g_kinhdo;
                objDHTaxi.GPS_ViDo = g_vido;
            }
            else
            {
                objDHTaxi.GPS_KinhDo = txtDiaChiDonKhach.KinhDo;
                objDHTaxi.GPS_ViDo = txtDiaChiDonKhach.ViDo;
            }
            // Lap lai 5 lan neu khong chen duoc
            bool bInsertOK = false;
            int iLan = 0;

            while ((!bInsertOK) && (iLan < 5))
            {
                //Là cuốc gọi lại!
                if (cbkGoiLai.Visible && cbkGoiLai.Checked)
                {
                    bInsertOK = objDHTaxi.Insert_DienThoai_LanDau_ToaDo_TestCuocGoiLai();
                }
                else
                {
                    bInsertOK = objDHTaxi.Insert_DienThoai_LanDau_ToaDo();
                }
                iLan++;
                if (!bInsertOK)
                    System.Threading.Thread.Sleep(50);
            }
            if (!bInsertOK)
            {
                return;
            }
            //new MessageBox.MessageBox().Show("Chèn thêm cuộc gọi thành công");
            this.Close();
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}