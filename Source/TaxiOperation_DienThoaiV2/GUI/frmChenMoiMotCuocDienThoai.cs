using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Femiani.Forms.UI.Input;
namespace Taxi.GUI
{
    public partial class frmChenMoiMotCuocDienThoai : Form
    {
        #region Fields and Properties
        private string g_Line = "";
        private KieuKhachHangGoiDen g_KieuKHGoi;
        private string G_MaDoiTac = string.Empty;
        private string g_LinesDuocCapPhep = string.Empty;
        private bool IsTextChange = false;
        #region --------new v3----------------
        
        private AutoCompleteEntryCollection g_ListDataAutoComplete;
        public frmChenMoiMotCuocDienThoai(string lineCapPhep, AutoCompleteEntryCollection listDataAutoComplete)
        {
            InitializeComponent();
            g_LinesDuocCapPhep = lineCapPhep;
            g_ListDataAutoComplete = listDataAutoComplete;
        }
        #endregion
        #endregion

        public frmChenMoiMotCuocDienThoai(string LinesDuocCapPhep, DateTime TimeServer)
        {
            InitializeComponent();
            this.g_LinesDuocCapPhep = LinesDuocCapPhep;
        }

        #region Events
        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {
            KhoiTao();
            editPhoneNumber.Focus();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                objDHTaxi.Line = g_Line;
                objDHTaxi.PhoneNumber = StringTools.TrimSpace(editPhoneNumber.Text);
                objDHTaxi.DiaChiDonKhach = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
                objDHTaxi.KieuKhachHangGoiDen = g_KieuKHGoi;
                objDHTaxi.MaDoiTac = G_MaDoiTac;
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
                    bInsertOK = objDHTaxi.Insert_DienThoai_LanDau_ToaDo();
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

        private void editPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            this.IsTextChange = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer_LoadDiaChi_Tick(object sender, EventArgs e)
        {
            if (IsTextChange)
            {
                if (editPhoneNumber.Text.Length > 8)
                    txtDiaChiDonKhach.Text = StringTools.TrimSpace(GetDiaChiGoiDen(StringTools.TrimSpace(editPhoneNumber.Text), out  g_KieuKHGoi, out G_MaDoiTac));
                IsTextChange = false;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// khoi tao cuoc goi 
        /// Line, thoi gio
        /// </summary>
        private void KhoiTao()
        { 
            g_Line = this.GetLineCuaMay();            
            g_KieuKHGoi = KieuKhachHangGoiDen.KhachHangBinhThuong;
            //lblInfo.Text = g_Line + "  " + string.Format("{0:HH:mm:ss dd/MM/yyyy}", g_TimeServer);
            editPhoneNumber.Text = Configuration.GetSoDienThoaiCongTy();
            txtDiaChiDonKhach.Text = "";
            txtDiaChiDonKhach.Items = g_ListDataAutoComplete;
        }
        /// <summary>
        /// ham thuc hien tra ve line cua may hien tai
        /// </summary>
        /// <returns></returns>
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
            //// xu ly co tong dai
            //if (PhoneNumber[0].ToString() == "5")
            //{
            //    PhoneNumber = PhoneNumber.Substring(1, PhoneNumber.Length - 1); 
            //}

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

            if (objDoiTac != null && objDoiTac.Address.Length > 0)
            {
                outKieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                MaDoiTac = objDoiTac.MaDoiTac;
                return objDoiTac.Address;
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
            return Business.DanhBa.GetDanhBa(DanhBa.GetSoDienThoaiToiThieu(PhoneNumber));

        }
        /// <summary>
        /// tim dia chi cua cuoc goi gan day nhat
        /// -- uu tien tim trong cuoc goi hien tai
        /// -- tim theo cuoc goi da ket thuc trong ngay
        /// </summary>
        private string GetDiaChiCuaCuocGoiGanNhatTrongNgay(string PhoneNumber)
        {
            try
            {
                string strDiaChi = "";
                List<DieuHanhTaxi> lstDienThoai = new List<DieuHanhTaxi>();
                //Lay danh sach cac cuoc goi con hoat dong (chua ket thuc)
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                string SQLCondition = " ORDER BY ThoiDiemGoi DESC";
                lstDienThoai = objDHTaxi.FT_GetAllOf_DienThoai(SQLCondition);
                if (lstDienThoai != null)
                {
                    if (lstDienThoai.Count > 0)
                    {
                        foreach (DieuHanhTaxi objDHTX in lstDienThoai)
                        {
                            if (objDHTX.PhoneNumber != null)
                            {
                                if (objDHTX.PhoneNumber.Contains(PhoneNumber))
                                {
                                    strDiaChi = objDHTX.DiaChiDonKhach;
                                    break;
                                }
                            }
                        }
                    }
                }
                lstDienThoai.Clear();
                lstDienThoai = null;
                // lay trong da ket thuc trong ngay
                return strDiaChi;
            }
            catch (Exception ex)
            {
               
                return string.Empty;
            }
        }
        #endregion

    }
}