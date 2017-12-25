using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace ToolTest
{
    public partial class frmToolTestBatSo : Form
    {
        #region Khai bao va khoi tao!
        
        private string _connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectStringDB"];
        public frmToolTestBatSo()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods & Events!
        private void frmToolTestBatSo_Load(object sender, EventArgs e)
        {
            try
            {
                string test = "Minh    testst     ";
                test = StringTools.TrimSpace(test);//Nhap thanh 1 khoang trang de split

                test = StringTools.RemoveSpace(test);//Bo het khoang trang
            }
            catch
            {

            }
        }
        //Gọi điện lên tổng đài theo số lượng!
        private void btnGoiDien_Click(object sender, EventArgs e)
        {
            try
            {
                int soLuongCuoc = 0;
                if (!string.IsNullOrWhiteSpace(txtSLCuoc.Text))
                {
                    soLuongCuoc = int.Parse(txtSLCuoc.Text);
                }

                for (int i = 0; i < soLuongCuoc; i++)
                {
                    InsertCallToDB();//Them cuoc goi vao DB!
                }

                MessageBox.Show(@"Chèn thêm "+soLuongCuoc+ @" cuộc gọi thành công");
            }
            catch 
            {
                
            }
        }

        private void InsertCallToDB()
        {
            try
            {
                #region -----------Code hệ thống cũ--------------

                string linePhone = "1";
                string maDoiTac;
                KieuKhachHangGoiDen kieuKHGoi;
                string strDiaChiDonKhach = StringTools.TrimSpace(GetDiaChiGoiDen(StringTools.TrimSpace(txtSDT.Text), out  kieuKHGoi, out maDoiTac));
                {
                    DieuHanhTaxi objDHTaxi = new DieuHanhTaxi
                    {
                        Line = linePhone,
                        PhoneNumber = StringTools.TrimSpace(txtSDT.Text),
                        DiaChiDonKhach = StringTools.TrimSpace(strDiaChiDonKhach),
                        KieuKhachHangGoiDen = kieuKHGoi,
                        MaDoiTac = maDoiTac,
                        TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.TrangThaiKhac,
                        TrangThaiLenh = TrangThaiLenhTaxi.KhongTruyenDi,
                        SoLuotDoChuong = 1,
                        GPS_KinhDo = (float)0.0,
                        GPS_ViDo = (float)0.0
                    };

                    bool bInsertOK = false;
                    int icount = 0;
                    // Lap lai 5 lan neu khong insert vao duoc
                    while ((!bInsertOK) && (icount < 5))
                    {
                        //Là cuốc gọi lại!
                        if (cbkGoiLai.Visible && cbkGoiLai.Checked)
                        {
                            bInsertOK = objDHTaxi.Insert_DienThoai_LanDau_ToaDo_TestCuocGoiLai_ToolTest(_connectionString);
                        }
                        else
                        {
                            bInsertOK = objDHTaxi.Insert_DienThoai_LanDau_ToaDo_ToolTest(_connectionString);
                        }
                        icount++;
                        if (!bInsertOK)
                            System.Threading.Thread.Sleep(50);
                    }
                }
                #endregion
            }
            catch 
            {
                
            }
        }

        #region 2 hàm mượn

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
        private string GetDiaChiGoiDen(string phoneNumber, out KieuKhachHangGoiDen outKieuKhachHang, out string outMaDoiTac)
        {
            try
            {
                if (StringTools.TrimSpace(phoneNumber).Length <= 0)
                {
                    outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    outMaDoiTac = "";
                    return string.Empty;
                }
                //// xu ly co tong dai
                //if (PhoneNumber[0].ToString() == "5")
                //{
                //    PhoneNumber = PhoneNumber.Substring(1, PhoneNumber.Length - 1); 
                //}

                string strDiaChiKhachAo = DanhBaKhachAo.GetDanhBa(DanhBa.GetSoDienThoaiToiThieu(phoneNumber));

                if (strDiaChiKhachAo.Length > 0)
                {
                    outKieuKhachHang = KieuKhachHangGoiDen.KhachHangKhongHieu;//khach ao
                    outMaDoiTac = "";
                    return strDiaChiKhachAo;
                }

                // Tim kiem trong khach VIP (3_)
                DanhBaKhachQuen objKhachQuen = DanhBaKhachQuen.GetKhachQuen_Phones_Search(DanhBa.GetSoDienThoaiToiThieu(phoneNumber));

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
                    outMaDoiTac = objKhachQuen.MaKH;

                    return String.Format("[{0}]{1}", objKhachQuen.Name, objKhachQuen.Address);
                }

                //Tim kiem trong DOI TAC (2)
                DoiTac objDoiTac = DoiTac.GetDoiTacByOPhoneNumber(DanhBa.GetSoDienThoaiToiThieu(phoneNumber));

                if (objDoiTac != null && objDoiTac.MaDoiTac.Length > 0)
                {
                    outKieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                    outMaDoiTac = objDoiTac.MaDoiTac;
                    return objDoiTac.Address;
                }

                //Tim kiem trong danh ba dien thoai cua rieng cong ty (1)

                string strDiaChiCuocGoiGanNhat = GetDiaChiCuaCuocGoiGanNhatTrongNgay(DanhBa.GetSoDienThoaiToiThieu(phoneNumber));

                if (strDiaChiCuocGoiGanNhat.Length > 0)
                {
                    outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    outMaDoiTac = "";
                    return strDiaChiCuocGoiGanNhat;
                }

                //Tim kiem trong danh ba cong ty

                string strDiaChiDanhBaCongTy = DanhBaCongTy.GetDanhBa(DanhBa.GetSoDienThoaiToiThieu(phoneNumber));

                if (strDiaChiDanhBaCongTy.Length > 0)
                {
                    outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;//khach ao
                    outMaDoiTac = "";
                    return strDiaChiDanhBaCongTy;
                }

                //Tim kiem trong danh ba dien thoai (1_)
                outKieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                outMaDoiTac = "";
                return DanhBa.GetDanhBa(DanhBa.GetSoDienThoaiToiThieu(phoneNumber));
            }
            catch
            {
                outKieuKhachHang = KieuKhachHangGoiDen.KhachHangKhongHieu;
                outMaDoiTac = string.Empty;
                return string.Empty;
            }
        }

        /// <summary>
        /// tim dia chi cua cuoc goi gan day nhat
        /// -- uu tien tim trong cuoc goi hien tai
        /// -- tim theo cuoc goi da ket thuc trong ngay
        /// </summary>
        private string GetDiaChiCuaCuocGoiGanNhatTrongNgay(string phoneNumber)
        {
            try
            {
                string strDiaChi = "";
                //Lay danh sach cac cuoc goi con hoat dong (chua ket thuc)
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                const string sqlCondition = " ORDER BY ThoiDiemGoi DESC";
                List<DieuHanhTaxi> lstDienThoai = objDHTaxi.FT_GetAllOf_DienThoai(sqlCondition);
                if (lstDienThoai != null)
                {
                    if (lstDienThoai.Count > 0)
                    {
                        foreach (DieuHanhTaxi objDieuHanhTaxi in lstDienThoai)
                        {
                            if (objDieuHanhTaxi.PhoneNumber != null)
                            {
                                if (objDieuHanhTaxi.PhoneNumber.Contains(phoneNumber))
                                {
                                    strDiaChi = objDieuHanhTaxi.DiaChiDonKhach;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (lstDienThoai != null) lstDienThoai.Clear();
                return strDiaChi;
            }
            catch 
            {
                return string.Empty;
            }
        }

        #endregion

        #endregion
    }
}
