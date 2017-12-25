using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Femiani.Forms.UI.Input;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
//using DienThoai;
using GMap.NET.WindowsForms.Markers;
using EFiling.Utils;
using DienThoai;
using System.Drawing.Drawing2D;
using Taxi.Entity;

namespace Taxi.GUI
{
    /// <summary>
    ///  - Tach phan validate thong tin nhập 
    ///  - Tách phần báo lỗi validate
    ///  
    /// 
    /// </summary>
    /// <Modified>        
    ///	Name		Date		    Comment 
    /// Congnt      07/14            Update
    /// Phupn       22/3/2012           Update
    /// </Modified> 
    public partial class frmBangGiaInputData_V3 : Form
    {
        #region ==========================Init=================================
        private KieuKhachHangGoiDen g_KieuKHGoi;
        private string G_MaDoiTac = string.Empty;
        // Gửi sự kiện có cuộc gọi mới. Hiển thị thông báo có cuộc gọi mới có chuyển tới
        public delegate void HienThiCuocMoiEventHandler(object sender, EventArgs e);
        public event HienThiCuocMoiEventHandler HienThiCuocMoiEvent;
        public void OnHienThiCuocMoiEvent(EventArgs e)
        {
            if (HienThiCuocMoiEvent != null)
                HienThiCuocMoiEvent(new object(), e);
        }
        //-------------------------------------------------------

        public double G_ViDo = 0;
        public double G_KinhDo = 0;

        public enum BangMaValidate
        {
            ValidateSuccess = 0,
            NhapThongTinDiaChi = 1,    // Bạn phải nhập thông tin vào trường địa chỉ.
            NhapMotLoaiCuocGoi = 2,    // Bạn phải chọn một loại cuộc gọi.
            NhapSoLuongXe = 3,    // Bạn phải nhập số lượng xe.
            NhapKenh = 4,    // Bạn phải nhập kênh (vùng) theo quy định.
            ChonKhongXeXinLoiKhach = 5, // Bạn không thể chọn không xe xin lỗi khách, khi có xe nhận.
            Msg6_KhongTimThayDCBanDo = 6,
            Msg7_ChuaNhapKenh = 7,
            Msg8_TaiBanDo = 8,
            Msg9_ChonKenhTK = 9,
            Msg10_ChonLoaiXe = 10,
            NhapThongTinDienThoai = 13,    // Bạn phải nhập thông tin số điện thoại.
        }

        private const string MSG_VALIDATESUCCESS = "";
        private const string MSG_1_NHAPTHONGTINDIACHI = "Bạn phải nhập thông tin vào trường địa chỉ.";
        private const string MSG_2_NHAPTHONGTINLOAICUOCGOI = "Bạn phải chọn một loại cuộc gọi.";
        private const string MSG_3_NHAPSOLUONGXE = "Bạn phải nhập số lượng xe.";
        private const string MSG_4_NHAPKENH = "Bạn phải nhập kênh (vùng) theo quy định. Kiểm tra lại kênh (vùng) cấu hình.";
        private const string MSG_5_CHONKHONGXE = "Bạn không thể chọn không xe xin lỗi khách, khi có xe nhận.";
        private const string MSG_6_BANDO = "Không tìm thấy địa chỉ này trên bản đồ";
        private const string MSG_7_CHUANHAPKENH = "Hãy nhập số kênh";
        private const string MSG_8_TAIBANDO = "Lỗi tải bản đồ";
        private const string MSG_9_CHONKENHTK = "Bạn hãy chọn kênh cần tìm kiếm";
        private const string MSG_10_BANDO = "Lỗi trong quá trình xử lý lấy tọa độ trên bản đồ";
        private const string MSG_11_BANDO = "Lỗi vẽ xe đề cử lên bản đồ";
        private const string MSG_12_BANDO = "Lỗi vẽ xe nhận lên bản đồ";
        private const string MSG_12_CHONLOAIXE = "Chưa chọn loại xe";
        private const string MSG_13_NHAPDIENTHOAI = "Bạn phải nhập số điện thoại";
        public enum LenhDienThoaiKieu
        {
            DaMoi = 1,  // đã mời
            GapXe = 2,  // gặp xe
            MayBan = 3,  // máy bận
            KhongLienLacDuoc = 4, // Không LL được
            HuyXe = 5,    // Hủy xe
        }

        private const string LENH_DAMOI = "Đã mời";
        private const string LENH_GAPXE = "Gặp xe";
        private const string LENH_MAYBAN = "Máy bận";
        private const string LENH_KHONGLIENLACDUOC = "Không LL được";
        private const string LENH_HUYXE = "Hủy xe";
        private const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        private string g_LoaiXeMacDinh = "KIA";
        //private string g_IDLoaiXe;
        private CuocGoi g_CuocGoi;
        private bool g_CloseForm = false;
        /// <summary>
        /// cuộc gọi có GPS hay không
        /// </summary>
        private bool g_GPS = false;
        /// <summary>
        /// Cuộc gọi đã vượt mức giới hạn cho phép hoặc không được phép sử dụng GPS
        /// g_CGLimit = true : giới hạn, không được phép sử dụng GPS
        /// </summary>
        private bool g_CGLimit = false; //
        private AutoCompleteEntryCollection g_ListDataAutoComplete;
        private string G_DiaChi = "";
        private int G_BanKinhTimXe = 0;
        private List<DMVung_GPSEntity> G_DMVung_GPS;
        private TaxiOperation_TongDai.BAGPS.Service BAService = new TaxiOperation_TongDai.BAGPS.Service();
        private string G_DiaChiFull = string.Empty;
        private string[] G_Address = new string[2];
        private int[] arrINum = new int[4];//1[~] 2[/] 3[-] 4[ ]
        private string[] arrRegex = new string[] { "N", "/", "-", " " };
        private string G_LineVungCapPhep = "0";
        public CuocGoi GetCuocGoi
        {
            get { return g_CuocGoi; }
        }
        #endregion

        #region =======================Constructor=============================
        public frmBangGiaInputData_V3(AutoCompleteEntryCollection listDataAutoComplete, string LineVungCapPhep, List<DMVung_GPSEntity> DMVung_GPS)
        {
            InitializeComponent();
            editSoLuongXe.Text = "1";
            chkGoiTaxi.Checked = true;
            G_LineVungCapPhep = LineVungCapPhep;
            g_ListDataAutoComplete = listDataAutoComplete;
            ConfigMap();
            G_DMVung_GPS = DMVung_GPS;
        }
        /// <summary>
        /// hàm khởi tạo truyển dữ liệu lên
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="listDataAutoComplete"></param>
        public frmBangGiaInputData_V3(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete, string LineVungCapPhep, List<DMVung_GPSEntity> DMVung_GPS)
        {
            InitializeComponent();
            editSoLuongXe.Text = "1";
            chkGoiTaxi.Checked = true;
            G_LineVungCapPhep = LineVungCapPhep;
            g_CuocGoi = cuocGoi;
            g_ListDataAutoComplete = listDataAutoComplete;
            ConfigMap();
            G_DMVung_GPS = DMVung_GPS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="listDataAutoComplete"></param>
        /// <param name="IDLoaiXeMacDinh">Loại xe mặc định config trên PC</param>
        //public frmBangGiaInputData_V3(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete, string IDLoaiXeMacDinh)
        //{
        //    InitializeComponent();
        //    editSoLuongXe.TextBox.Text = "1";
        //    chkGoiTaxi.Checked = true;

        //    g_CuocGoi = cuocGoi;
        //    g_ListDataAutoComplete = listDataAutoComplete;
        //    ConfigMap();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="listDataAutoComplete"></param>
        /// <param name="IDLoaiXeMacDinh">Loại xe mặc định config trên PC</param>
        public frmBangGiaInputData_V3(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete, bool CGLimit)
        {
            InitializeComponent();
            //this.SetDisplayRectLocation(550,550);
            this.SetDesktopLocation(440, 100);
            editSoLuongXe.TextBox.Text = "1";
            chkGoiTaxi.Checked = true;

            g_CuocGoi = cuocGoi;
            g_ListDataAutoComplete = listDataAutoComplete;
            g_CGLimit = CGLimit;

            //---------------------Initial Map----------------------------
            ConfigMap();            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="listDataAutoComplete"></param>
        /// <param name="IDLoaiXeMacDinh">Loại xe mặc định config trên PC</param>
        public frmBangGiaInputData_V3(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete, bool CGLimit, List<DMVung_GPSEntity> DMVung_GPS)
        {
            InitializeComponent();
            //this.SetDisplayRectLocation(550,550);
            this.SetDesktopLocation(440, 100);
            editSoLuongXe.TextBox.Text = "1";
            chkGoiTaxi.Checked = true;

            g_CuocGoi = cuocGoi;
            g_ListDataAutoComplete = listDataAutoComplete;
            g_CGLimit = CGLimit;

            G_DMVung_GPS = DMVung_GPS;
            //---------------------Initial Map----------------------------
            ConfigMap();
        }

        #endregion

        #region ===================Load Form-Set Data==========================

        private void frmDienThoaiInputDataMaiLinh_Load(object sender, EventArgs e)
        {            
            txtDiaChiDonKhach.Items = g_ListDataAutoComplete;
            SetDuLieuLenForm(g_CuocGoi);
            g_CloseForm = false;
            //lblCoCuocGoiMoi.Visible = false;
            
        }

        /// <summary>
        /// Dia chi de lay GPS
        /// </summary>
        /// <param name="diaChi"></param>
        /// <returns></returns>
        private string getDiaChiChuan(string diaChi)
        {
            string strDiaChi = diaChi;
            G_DiaChiFull = StringTools.TrimSpace(diaChi);
            //----Bỏ phần xe nhận cuộc gọi lại
            int count2 = diaChi.IndexOfAny(new char[] { ']' }, 0, diaChi.Length);
            if (count2 >= 0)
            {
                strDiaChi = diaChi.Substring(count2 + 1, diaChi.Length - count2 - 1);
                
            }

            int index = strDiaChi.IndexOf("-");
            if (index > 0)
            {
                strDiaChi = StringTools.TrimSpace(strDiaChi.Substring(0, index));
            }
            return strDiaChi;
        }

        private void ValidateDiaChiNhap(string strValue)
        {
            if (strValue.Length > 0)
                {
                    string returnValue = string.Empty;
                    // Giải thích viết trước
                    arrINum[2] = strValue.IndexOf(arrRegex[2]);//Có ghi giải thích hay không
                    if (arrINum[2] > 0)
                    {                        
                        returnValue = strValue.Substring(0,arrINum[2]);// phần trước ghi chú
                        G_Address[1] = strValue.Substring(arrINum[2]);// phần ghi chú
                        arrINum[3] = returnValue.IndexOf(arrRegex[3]);//Có Số nhà hay ko
                        if (arrINum[3] > 0)
                        {
                            returnValue = returnValue.Substring(arrINum[3] + 1);
                            G_Address[0] = StringTools.FormatBuilding(strValue.Substring(0, arrINum[3])) + returnValue;
                        }
                    }
                    else
                    {
                        returnValue = strValue;
                        arrINum[3] = strValue.IndexOf(arrRegex[3]);//Có Số nhà hay ko
                        if (arrINum[3] > 0)
                        {
                            returnValue = returnValue.Substring(arrINum[3] + 1);
                            G_Address[0] = StringTools.FormatBuilding(strValue.Substring(0, arrINum[3])) + returnValue;
                        }
                    }
                }
        }

        /// <summary>
        /// hàm thực hiện set dữ liệu lên form
        /// </summary>
        /// <param name="cuocGoi"></param>
        private void SetDuLieuLenForm(CuocGoi cuocGoi)
        {
            if (cuocGoi != null)
            {
                //if (!cuocGoi.IsCuocGiaLap && cuocGoi.Line.ToString() != G_LineVungCapPhep)
                //{
                //    txtDiaChiDonKhach.Enabled = false;
                //    editLenhDienThoai.Enabled = false;

                //    chkGoiLai.Enabled = false;
                //    chkGoiDichVu.Enabled = false;
                //    chkGoiHoiDam.Enabled = false;
                //    chkGoiKhac.Enabled = false;
                //    chkGoiKhieuNai.Enabled = false;
                //    chkGoiTaxi.Enabled = false;
                //    editSoLuongXe.Enabled = false;

                //    chkKhongXe.Enabled = false;
                //    chkXe4.Enabled = false;
                //    chkXe7.Enabled = false;

                //    btnGPS.Enabled = false;
                //    btnRemoveGPS.Enabled = false;
                //}
                txtDienThoai.Text = cuocGoi.PhoneNumber;
                txtDienThoai.Enabled = false;
                lblInfo.Text = cuocGoi.ThoiDiemGoi.ToString("HH:mm:ss dd/MM/yyyy");
                txtDiaChiDonKhach.Text = cuocGoi.DiaChiDonKhach;
                chkDaXuLy.Checked = cuocGoi.BTBG_IsDaXuLy;
                editKetQua.Text = cuocGoi.BTBG_NoiDungXuLy;
                SetThongTinLoaiCuocGoi(cuocGoi.KieuCuocGoi);
                SetThongTinLoaiXe(cuocGoi.LoaiXe);
                if (cuocGoi.SoLuong > 0)
                {
                    editSoLuongXe.TextBox.Text = cuocGoi.SoLuong.ToString();
                }

                else
                {
                    // neeus cuoc goi chua chuyen mot kenh nao va so lan goi >= 2 thi dat ma dinh la cuoc goi lai
                    if (cuocGoi.SoLanGoi >= 2)
                    {
                        chkGoiLai.Checked = true;
                    }
                }
                editLenhDienThoai.Text = cuocGoi.LenhDienThoai;
                editKetQua.Text = cuocGoi.GhiChuDienThoai;
                // hiển thị lựa chọn không xe
                //if (cuocGoi.XeNhan.Length <= 0 && cuocGoi.LenhTongDai.Contains("không xe"))
                //{
                //    chkKhongXeXinLoi.Enabled = true;
                //    SetControlForKhongXe();
                //}
                //else
                //{
                //    chkKhongXeXinLoi.Enabled = false;
                //}
                if (g_CGLimit == false)
                {
                    //Cuộc gọi đối tác
                    if (string.IsNullOrEmpty(cuocGoi.MaDoiTac) && cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                    {
                        if (cuocGoi.GPS_KinhDo != 0 && cuocGoi.GPS_ViDo != 0)
                        {
                            btnGPS.Enabled = true;
                            btnGPS.Enabled = true;
                            g_CGLimit = false;
                        }
                        else
                        {
                            btnGPS.Enabled = false;
                            btnGPS.Enabled = false;
                            g_CGLimit = true;
                        }
                    }
                    //Set Marker nếu có tọa độ.
                    if (cuocGoi.GPS_KinhDo != 0 && cuocGoi.GPS_ViDo != 0)
                    {
                        G_KinhDo = cuocGoi.GPS_KinhDo;
                        G_ViDo = cuocGoi.GPS_ViDo;

                        MainMap.addMarkerCustomer2(cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo, cuocGoi.DiaChiDonKhach);


                        if (cuocGoi.Vung > 0)
                        {
                            editVung.TextBox.Text = cuocGoi.Vung.ToString();
                        }
                        else
                        {
                            setKenhByDiaChi((float)cuocGoi.GPS_ViDo, (float)cuocGoi.GPS_KinhDo);
                        }

                        //set marker xe de cu
                        if (!string.IsNullOrEmpty(cuocGoi.DanhSachXeDeCu) && !string.IsNullOrEmpty(cuocGoi.DanhSachXeDeCu_TD))
                        {
                            setMarkerDSXeDeCu(cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD);
                            g_DSXeDeCu = cuocGoi.DanhSachXeDeCu;
                            g_DSXeDeCu_TD = cuocGoi.DanhSachXeDeCu_TD;
                        }
                        else
                        {
                            getXeByToaDo(cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo);
                        }
                        //set market xe nhan
                        if (!string.IsNullOrEmpty(cuocGoi.XeNhan) && !string.IsNullOrEmpty(cuocGoi.XeNhan_TD))
                        {
                            setMarkerDSXeNhan(cuocGoi.XeNhan, cuocGoi.XeNhan_TD);
                        }
                    }
                    else
                    {
                        if (cuocGoi.Vung > 0)
                        {
                            editVung.TextBox.Text = cuocGoi.Vung.ToString();
                        }
                    }
                }

                g_GPS = cuocGoi.CoGPS;
            }
            else
            {                
                lblInfo.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                txtDiaChiDonKhach.Text = "";
                editSoLuongXe.TextBox.Text = "1";
                g_CuocGoi = new CuocGoi();
                txtDienThoai.Select();
            }
        }

        private void SetControlForKhongXe()
        {
            chkGoiTaxi.Enabled = false;
            chkGoiLai.Enabled = false;
            chkGoiKhieuNai.Enabled = false;
            chkGoiDichVu.Enabled = false;
            chkGoiHoiDam.Enabled = false;
            chkGoiKhac.Enabled = false;
            //txtDiaChiDonKhach .Enabled = !chkKhongXeXinLoi.Enabled;
            editLenhDienThoai.Enabled = true;
            editKetQua.Enabled = false;
            //chkXe4.Enabled = !chkKhongXeXinLoi.Enabled;
            //chkXe7.Enabled = !chkKhongXeXinLoi.Enabled;
            //chkKhongXe.Enabled = !chkKhongXeXinLoi.Enabled;
            //chkXeLIMO7.Enabled = !chkKhongXeXinLoi.Enabled;
            //editSoLuongXe.Enabled = !chkKhongXeXinLoi.Enabled;
            //editVung.Enabled = !chkKhongXeXinLoi.Enabled;
            //chkKhachHoan.Enabled = !chkKhongXeXinLoi.Enabled;


        }

        private void SetThongTinLoaiCuocGoi(KieuCuocGoi kieuCuocGoi)
        {
            if (kieuCuocGoi == KieuCuocGoi.GoiTaxi)
            {
                chkGoiTaxi.Checked = true;
            }
            else if (kieuCuocGoi == KieuCuocGoi.GoiLai)
            {
                chkGoiLai.Checked = true;
            }
            else if (kieuCuocGoi == KieuCuocGoi.GoiKhieuNai)
            {
                chkGoiKhieuNai.Checked = true;
            }
            else if (kieuCuocGoi == KieuCuocGoi.GoiDichVu)
            {
                chkGoiDichVu.Checked = true;
            }
            else if (kieuCuocGoi == KieuCuocGoi.GoiHoiDam)
            {
                chkGoiHoiDam.Checked = true;
            }
            else if (kieuCuocGoi == KieuCuocGoi.GoiKhac)
            {
                chkGoiKhac.Checked = true;
            }
        }
        /// <summary>
        /// hàm thực hiện set thông tin loại xe
        /// Input : 
        ///     - KIA,VIO,INO,LIMO
        /// Ouput :
        ///      Set lên check box
        /// </summary>
        /// <param name="p"></param>
        private void SetThongTinLoaiXe(string loaiXe)
        {
            if (loaiXe != null && loaiXe.Length > 0)
            {
                chkXe4.Checked = false;
                chkXe7.Checked = false;
                chkKhongXe.Checked = false;
                //chkXeLIMO7.Checked = false;
                if (loaiXe.Contains("4  cho") || loaiXe.Contains("4  chỗ"))
                {
                    chkXe4.Checked = true;
                }
                if (loaiXe.Contains("7  cho") || loaiXe.Contains("7  chỗ"))
                {
                    chkXe7.Checked = true;
                }
                if (loaiXe.Contains("0"))
                {
                    chkKhongXe.Checked = true;
                }
            }

        }

        /// <summary>
        /// Nhập kênh tự động theo địa chỉ.
        /// </summary>
        /// <param name="viDo">kinh độ của địa chỉ khách</param>
        /// <param name="kinhDo">Vi độ của địa chỉ khách</param>
        private void setKenhByDiaChi(float viDo, float kinhDo)
        {
            int vung = getKenhByDiaChi((float)viDo, (float)kinhDo);
            if (vung > 0)
                editVung.Text = vung.ToString();
            else
                editVung.Text = "";
        }
        
        #endregion        

        #region ======================Validation Form==========================
        /// <summary>
        /// hàm thực hiện validate thông tin form nhập
        /// co cuoc goi truyen vao
        /// </summary>
        /// <returns></returns>
        private BangMaValidate ValidateFormNhap(CuocGoi cuocGoi)
        {
            if (txtDienThoai.Text.Trim().Length <= 0)
            {
                txtDienThoai.Focus();
                return BangMaValidate.NhapThongTinDienThoai;
            }
            // Không nhập địa chỉ
            string diaChi = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
            if (diaChi.Length <= 0)
            {
                txtDiaChiDonKhach.Focus();
                return BangMaValidate.NhapThongTinDiaChi;
            }
            // Không chọn một loại cuộc gọi nào
            if ((chkGoiTaxi.Checked == false) && (chkGoiLai.Checked == false) && (chkGoiKhieuNai.Checked == false) && (chkGoiDichVu.Checked == false) &&
                (chkGoiHoiDam.Checked == false) && (chkGoiKhac.Checked == false))
            {
                chkGoiTaxi.Focus();
                return BangMaValidate.NhapMotLoaiCuocGoi;
            }

            if (chkGoiTaxi.Checked || chkGoiLai.Checked || chkGoiKhieuNai.Checked || chkGoiHoiDam.Checked)
            {
                #region Kenh
                //Kenh
                //byte kenh = 0;
                try
                {
                    string kenh = editVung.Text.Trim();
                    if (editVung.Text.Trim() == "" || !CheckVungNamTrongVungCauHinh(Convert.ToInt16(kenh)))  // kiểm tra kênh có nằm trong vùng quy đinh.
                    {
                        editVung.Focus();
                        return BangMaValidate.NhapKenh;
                    }
                }
                catch (Exception ex)
                {
                    editVung.Focus();
                    return BangMaValidate.NhapKenh;
                }


                #endregion Kenh
                if (chkGoiTaxi.Checked)
                {
                    #region So luong xe
                    // Kiểm tra số lượng xe
                    byte soLuongXe = 0;
                    try
                    {
                        soLuongXe = Convert.ToByte(editSoLuongXe.Text);
                    }
                    catch (Exception ex)
                    {
                        soLuongXe = 0;
                    }
                    if (soLuongXe == 0)
                    {
                        editSoLuongXe.Focus();
                        return BangMaValidate.NhapSoLuongXe;
                    }
                    #endregion So luong xe

                    #region loai xe
                    if (!chkKhongXe.Checked && !chkXe4.Checked && !chkXe7.Checked)
                    {
                        return BangMaValidate.Msg10_ChonLoaiXe;
                    }
                    #endregion
                }
            }

            
            #region KhongXe
            //if (chkKhongXeXinLoi.Checked && cuocGoi.XeNhan .Length>0 )
            //{
            //    chkKhongXeXinLoi.Focus();
            //    return BangMaValidate.ChonKhongXeXinLoiKhach;
            //}
            #endregion

            return BangMaValidate.ValidateSuccess;
        }

        /// <summary>
        /// check vung nhan năm trong vùng cấu hình.
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if (ThongTinCauHinh.CacVungTongDai != null && ThongTinCauHinh.CacVungTongDai.Length > 0)
            {
                string[] arrVung = ThongTinCauHinh.CacVungTongDai.Split(";".ToCharArray());
                for (int i = 0; i < arrVung.Length; i++)
                {
                    if (Convert.ToInt32(arrVung[i]) == Vung)
                    {
                        bCheck = true; break;
                    }
                }
            }
            else bCheck = false;
            return bCheck;
        }

        /// <summary>
        /// hàm hiển thị thông báo yêu cầu nhập dữ liệu
        /// </summary>
        /// <param name="maValidate"></param>
        private void HienThiThongBao(BangMaValidate maValidate)
        {
            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                lblThongBao.Text = MSG_VALIDATESUCCESS;
            }
            else if (maValidate == BangMaValidate.NhapThongTinDiaChi)
            {
                lblThongBao.Text = MSG_1_NHAPTHONGTINDIACHI;
            }
            else if (maValidate == BangMaValidate.NhapMotLoaiCuocGoi)
            {
                lblThongBao.Text = MSG_2_NHAPTHONGTINLOAICUOCGOI;
            }
            else if (maValidate == BangMaValidate.NhapSoLuongXe)
            {
                lblThongBao.Text = MSG_3_NHAPSOLUONGXE;
            }
            else if (maValidate == BangMaValidate.NhapKenh)
            {
                lblThongBao.Text = MSG_4_NHAPKENH;
            }
            else if (maValidate == BangMaValidate.ChonKhongXeXinLoiKhach)
            {
                lblThongBao.Text = MSG_5_CHONKHONGXE;
            }
            else if (maValidate == BangMaValidate.Msg6_KhongTimThayDCBanDo)
            {
                lblThongBao.Text = MSG_6_BANDO;
            }
            else if (maValidate == BangMaValidate.Msg7_ChuaNhapKenh)
            {
                lblThongBao.Text = MSG_7_CHUANHAPKENH;
            }
            else if (maValidate == BangMaValidate.Msg8_TaiBanDo)
            {
                lblThongBao.Text = MSG_8_TAIBANDO;
            }
            else if (maValidate == BangMaValidate.Msg9_ChonKenhTK)
            {
                lblThongBao.Text = MSG_9_CHONKENHTK;
            }
            else if (maValidate == BangMaValidate.Msg10_ChonLoaiXe)
            {
                lblThongBao.Text = MSG_12_CHONLOAIXE;
            }
            else if (maValidate == BangMaValidate.NhapThongTinDienThoai)
            {
                lblThongBao.Text = MSG_13_NHAPDIENTHOAI;
            }
        }

        /// <summary>
        /// hàm thực hiện đặt cấu hình các 
        /// control khi có cuộc gọi là taxi
        /// </summary>
        private void HienThiControl_GoiTaxi()
        {
            if (chkGoiTaxi.Checked)
            {
                chkGoiLai.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false; 
            }
        }

        /// <summary>
        /// thay đổi dữ liệu hàm checkbox gọi lại
        /// </summary>
        private void HienThiControl_GoiLai()
        {
            if (chkGoiLai.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
            }
                // loai xe
            chkXe4.Enabled = !chkGoiLai.Checked;
            chkXe7.Enabled = !chkGoiLai.Checked;
            chkKhongXe.Enabled = !chkGoiLai.Checked;
            //chkXeLIMO7.Enabled = !chkGoiLai.Checked;
            editSoLuongXe.Enabled = !chkGoiLai.Checked;
            //editVung.Enabled = chkGoiLai.Checked;
            //chkKhachHoan.Enabled = !chkGoiLai.Checked;
            //chkKhongXeXinLoi.Enabled = !chkGoiLai.Checked;
             
        }

        private void HienThiControl_GoiKhieuNai()
        {
            if (chkGoiKhieuNai.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
            }
            // loai xe
            chkXe4.Enabled = !chkGoiKhieuNai.Checked;
            chkXe7.Enabled = !chkGoiKhieuNai.Checked;
            chkKhongXe.Enabled = !chkGoiKhieuNai.Checked;
            //chkXeLIMO7.Enabled = !chkGoiKhieuNai.Checked;
            editSoLuongXe.Enabled = !chkGoiKhieuNai.Checked;
            //chkKhachHoan.Enabled = !chkGoiKhieuNai.Checked;
            //chkKhongXeXinLoi.Enabled = !chkGoiKhieuNai.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        private void HienThiControl_GoiDichVu()
        {
            if (chkGoiDichVu.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiKhieuNai .Checked = false;
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
            }
            chkXe4.Enabled = !chkGoiDichVu.Checked;
            chkXe7.Enabled = !chkGoiDichVu.Checked;
            chkKhongXe.Enabled = !chkGoiDichVu.Checked;
            //chkXeLIMO7.Enabled = !chkGoiDichVu.Checked;
            editSoLuongXe.Enabled = !chkGoiDichVu.Checked;
            //editVung.Enabled = !chkGoiDichVu.Checked;
            //chkKhachHoan.Enabled = !chkGoiDichVu.Checked;
            //chkKhongXeXinLoi.Enabled = !chkGoiDichVu.Checked;
        }

        private void HienThiControl_GoiHoiDam()
        {
            if (chkGoiHoiDam.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiKhac.Checked = false;
            }
            chkXe4.Enabled = !chkGoiHoiDam.Checked;
            chkXe7.Enabled = !chkGoiHoiDam.Checked;
            chkKhongXe.Enabled = !chkGoiHoiDam.Checked;
            //chkXeLIMO7.Enabled = !chkGoiHoiDam.Checked;
            editSoLuongXe.Enabled = !chkGoiHoiDam.Checked;
            //chkKhachHoan.Enabled = !chkGoiHoiDam.Checked;
            //chkKhongXeXinLoi.Enabled = !chkGoiHoiDam.Checked;
            editVung.Enabled = true;
        }

        private void HienThiControl_GoiKhac()
        {
            if (chkGoiKhac.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiHoiDam.Checked = false;
            }
            chkXe4.Enabled = !chkGoiKhac.Checked;
            chkXe7.Enabled = !chkGoiKhac.Checked;
            chkKhongXe.Enabled = !chkGoiKhac.Checked;
            //chkXeLIMO7.Enabled = !chkGoiKhac.Checked;
            editSoLuongXe.Enabled = !chkGoiKhac.Checked;
            editVung.Enabled = !chkGoiKhac.Checked;
            //chkKhachHoan.Enabled = !chkGoiKhac.Checked;
            //chkKhongXeXinLoi.Enabled = !chkGoiKhac.Checked;
        }

        private void setVung(string vung)
        {
            //DateTime gopKenhTuGio = ThongTinCauHinh.GopKenh_TuGio;

            editVung.Focus();
            editVung.Text = vung;
        }
        #endregion 
        
        #region =======================Get Data Form===========================
        /// <summary>
        /// hàm cập nhật thông tin cuộc gọi mới nhập vào
        /// </summary>
        /// <param name="cuocGoi"></param>
        private void GetThongTinNhapMoi(ref CuocGoi cuocGoi)
        {
            //cuocGoi.Line = int.Parse(G_LineVungCapPhep);
            cuocGoi.MaDoiTac = G_MaDoiTac;
            cuocGoi.KieuKhachHangGoiDen = g_KieuKHGoi;
            
            cuocGoi.PhoneNumber = StringTools.TrimSpace(txtDienThoai.Text);
            cuocGoi.DiaChiDonKhach = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
            cuocGoi.LenhDienThoai = StringTools.TrimSpace(editLenhDienThoai.Text);
            cuocGoi.GhiChuDienThoai = StringTools.TrimSpace(editKetQua.Text);
            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
            cuocGoi.BTBG_NhanVien = ThongTinDangNhap.USER_ID;
            cuocGoi.BTBG_NoiDungXuLy = StringTools.TrimSpace(editKetQua.Text);

            cuocGoi.BTBG_IsDaXuLy = chkDaXuLy.Checked;
            
            if (chkGoiTaxi.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiTaxi;
                cuocGoi.LoaiXe = GetThongTinLoaiXeChon();
                cuocGoi.SoLuong = Convert.ToByte(editSoLuongXe.Text);
                if (editVung.Text.Trim() != "")
                {
                    cuocGoi.Vung = Convert.ToByte(editVung.Text);
                }
                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;
                //if (chkKhachHoan.Checked)
                //{
                //    cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                //}
                //if (chkKhongXeXinLoi.Checked)
                //{
                //    cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                //    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                //}
                cuocGoi.SoLanGoi = 1;

                // Kiểm tra nếu có CuocGoiLaiIDs >0 --> thi set lại để không phải là cuộc gọi lại
                //if (cuocGoi.CuocGoiLaiIDs != null && cuocGoi.CuocGoiLaiIDs.Length > 0)
                //{
                //    cuocGoi.CuocGoiLaiIDs = "";
                //}
            }
            else if (chkGoiLai.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiLai;
                cuocGoi.Vung = Convert.ToByte(editVung.Text);
            }
            else if (chkGoiKhieuNai.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiKhieuNai;
                 cuocGoi.Vung = Convert.ToByte(editVung.Text);
            }
            else if (chkGoiDichVu.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiDichVu;
                cuocGoi.Vung = Convert.ToByte(editVung.Text);
                //cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
            }
            else if (chkGoiHoiDam.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiHoiDam;
                cuocGoi.Vung = Convert.ToByte(editVung.Text);
            }
            else if (chkGoiKhac.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiKhac;
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
            }
            if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.IsVisible && g_GPS)
            {
                cuocGoi.GPS_ViDo = MainMap.MarkerCustomer.Position.Lat;
                cuocGoi.GPS_KinhDo = MainMap.MarkerCustomer.Position.Lng;
                cuocGoi.DanhSachXeDeCu = g_DSXeDeCu;
                cuocGoi.DanhSachXeDeCu_TD = g_DSXeDeCu_TD;
            }
            else
            {
                cuocGoi.GPS_ViDo = 0;
                cuocGoi.GPS_KinhDo = 0;
                cuocGoi.DanhSachXeDeCu = "";
                cuocGoi.DanhSachXeDeCu_TD = "";
            }
            cuocGoi.CoGPS = g_GPS;
        }

        private string GetThongTinLoaiXeChon()
        {
            string loaiXe = string.Empty;
            if (chkXe4.Checked)
            {
                loaiXe += "4  cho,";
            }
            if (chkXe7.Checked)
            {
                loaiXe += "7  cho,";
            }
            if (chkKhongXe.Checked)
            {
                loaiXe += "0,";
            }            

            if (loaiXe.Length > 0)
            {
                loaiXe = loaiXe.Substring(0, loaiXe.Length - 1);
            }
            return loaiXe;
        }

        private string GetThongTinLoaiXeChon2()
        {
            string loaiXe = string.Empty;
            if (chkXe4.Checked)
            {
                loaiXe += "4,";
            }
            if (chkXe7.Checked)
            {
                loaiXe += "7,";
            }
            if (chkKhongXe.Checked)
            {
                loaiXe += "0,";
            }

            if (loaiXe.Length > 0)
            {
                loaiXe = loaiXe.Substring(0, loaiXe.Length - 1);
            }
            return loaiXe;
        }

        /// <summary>
        /// function get kenh vung theo dia chi (toa do)
        /// </summary>
        /// <param name="LatDes"></param>
        /// <param name="LngDes"></param>
        /// <returns></returns>
        private int getKenhByDiaChi(float LatDes, float LngDes)
        {
            int numVung = 0;
            string[] arrToaDoVung;
            string[] ToaDo;
            string[] ToaDoCuoi;
            float[] x = new float[2], y = new float[2];
            foreach (DMVung_GPSEntity DMVung_GPS in G_DMVung_GPS)
            {
                if (string.IsNullOrEmpty(DMVung_GPS.ToaDoVung)) continue;
		        
                arrToaDoVung = DMVung_GPS.ToaDoVung.Split('-');// danh sach cac diem thuoc vung GPS
                if (arrToaDoVung.Length <= 0) continue;

                int length = arrToaDoVung.Length - 1;
                int cn = 0;
                for (int i = 0; i < arrToaDoVung.Length - 1; i++)
                {
                    ToaDo = arrToaDoVung[i].Split(';');                    
                    x[0] = float.Parse(ToaDo[1]);// KD
                    y[0] = float.Parse(ToaDo[0]);//VD

                    ToaDoCuoi = arrToaDoVung[i + 1].Split(';');
                    x[1] = float.Parse(ToaDoCuoi[1]);
                    y[1] = float.Parse(ToaDoCuoi[0]);

                    if (((x[0] <= LngDes) && (x[1] > LngDes)) || ((x[0] > LngDes) && (x[1] <= LngDes)))
                    {
                        double vt = (LngDes - x[0]) / (x[1] - x[0]);
                        if (LatDes < y[0] + vt * (y[1] - y[0]))
                            ++cn;
                    }
                }
                if ((cn & 1) > 0)
                {
                    G_BanKinhTimXe = DMVung_GPS.BanKinhTimXe;
                    if (G_BanKinhTimXe == 0)
                        G_BanKinhTimXe = ThongTinCauHinh.GPS_BKGioiHan;
                    numVung = DMVung_GPS.KenhVung;
                    break;
                }// 0 if even (out), and 1 if odd (in)
            }
            return numVung;
        }        

        // ham check 1 diem trong 1 da giac
        // input: point,objVungNoiThanh
        // output: 1->in da giac,0 out da giac
        //public int CheckPointInsidePolyon(Point point, Point[] Polygon)
        //{
        //    int cn = 0;
        //    for (int i = 0; i < Polygon.Length - 1; i++)
        //    {
        //        if (((Polygon[i].X <= point.X) && (Polygon[i + 1].X > point.X))
        //         || ((Polygon[i].X > point.X) && (Polygon[i + 1].X <= point.X)))
        //        {
        //            double vt = (point.X - Polygon[i].X) / (Polygon[i + 1].X - Polygon[i].X);
        //            if (point.Y < Polygon[i].Y + vt * (Polygon[i + 1].Y - Polygon[i].Y))
        //                ++cn;
        //        }
        //    }
        //}
        #endregion        

        #region ========================Form Events============================

        private void btnOK_Click(object sender, EventArgs e)
        {            
            BangMaValidate maValidate = ValidateFormNhap(g_CuocGoi);
            HienThiThongBao(maValidate);
            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                g_CloseForm = true;
                GetThongTinNhapMoi(ref g_CuocGoi);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                g_CloseForm = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            g_CloseForm = true;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnRemoveGPS_Click(object sender, EventArgs e)
        {
            if (g_CGLimit == false)
            {
                g_GPS = false;
                MainMap.ClearAllMarkers();
                g_DSXeDeCu = "";
                g_DSXeDeCu_TD = "";
            }
        }

        private void btnGPS_Click(object sender, EventArgs e)
        {
            try
            {
                if (g_CGLimit) return;
                string diaChiGPS = string.Empty;
                
                if (ThongTinCauHinh.GPS_TrangThai == true)
                {
                    if (MainMap.OverlayXeDeCu != null && MainMap.OverlayXeDeCu.Markers != null)
                        MainMap.OverlayXeDeCu.Markers.Clear();

                    string strDiaChi = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
                    //Kinh độ và vĩ độ đã gán sẵn theo địa chỉ
                    G_ViDo = txtDiaChiDonKhach.ViDo;
                    G_KinhDo = txtDiaChiDonKhach.KinhDo;
                    diaChiGPS = getDiaChiChuan(strDiaChi);

                    if (G_ViDo == 0 && G_KinhDo == 0)
                    {
                        if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.Position.Lat > 0)
                        {
                            G_ViDo = MainMap.MarkerCustomer.Position.Lat;
                            G_KinhDo = MainMap.MarkerCustomer.Position.Lng;
                            //strDiaChi = MainMap.MarkerCustomer.ToolTipText;
                        }
                        else
                        {


                            string toaDo = GetGeobyAddressBA2(diaChiGPS);
                            if (toaDo != "*" && toaDo != string.Empty)
                            {
                                string[] arrString = toaDo.Split(' ');
                                G_ViDo = Convert.ToDouble(arrString[0]);
                                G_KinhDo = Convert.ToDouble(arrString[1]);
                            }
                            else
                            {
                                lblThongBao.Text = MSG_6_BANDO;
                            }
                        }
                    }
                    txtDiaChiDonKhach.Text = G_DiaChiFull;
                    txtDiaChi_GPS.Text = diaChiGPS;
                    if (G_KinhDo == 0 && G_ViDo == 0)
                    {
                        g_GPS = false;
                        return;
                    }
                    else
                    {
                        g_GPS = true;
                        MainMap.addMarkerCustomer2(G_KinhDo, G_ViDo, diaChiGPS);
                        //Nhập Kênh tự động theo địa chỉ vùng
                        setKenhByDiaChi((float)G_ViDo, (float)G_KinhDo);

                        getXeByToaDo(G_KinhDo, G_ViDo);
                    }
                }
                //editVung.Select();
            }
            catch (Exception ex)
            {
                lblThongBao.Text = MSG_10_BANDO;
                g_GPS = false;
            }
        }

        private void btnGPS_SanBay_Click(object sender, EventArgs e)
        {
            try
            {
                if (g_CGLimit) return;
                string diaChiGPS = string.Empty;

                if (ThongTinCauHinh.GPS_TrangThai == true)
                {
                    if (MainMap.OverlayXeDeCu != null && MainMap.OverlayXeDeCu.Markers != null)
                        MainMap.OverlayXeDeCu.Markers.Clear();

                    string strDiaChi = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
                    //Kinh độ và vĩ độ đã gán sẵn theo địa chỉ
                    G_ViDo = txtDiaChiDonKhach.ViDo;
                    G_KinhDo = txtDiaChiDonKhach.KinhDo;
                    diaChiGPS = getDiaChiChuan(strDiaChi);

                    if (G_ViDo == 0 && G_KinhDo == 0)
                    {
                        if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.Position.Lat > 0)
                        {
                            G_ViDo = MainMap.MarkerCustomer.Position.Lat;
                            G_KinhDo = MainMap.MarkerCustomer.Position.Lng;
                            //strDiaChi = MainMap.MarkerCustomer.ToolTipText;
                        }
                        else
                        {


                            string toaDo = GetGeobyAddressBA2(diaChiGPS);
                            if (toaDo != "*" && toaDo != string.Empty)
                            {
                                string[] arrString = toaDo.Split(' ');
                                //double a = double.Parse(arrString[0]);
                                G_ViDo = double.Parse(arrString[0]);
                                G_KinhDo = double.Parse(arrString[1]);
                            }
                            else
                            {
                                lblThongBao.Text = MSG_6_BANDO;
                            }
                        }
                    }
                    txtDiaChiDonKhach.Text = G_DiaChiFull;
                    txtDiaChi_GPS.Text = diaChiGPS;
                    if (G_KinhDo == 0 && G_ViDo == 0)
                    {
                        g_GPS = false;
                        return;
                    }
                    else
                    {
                        g_GPS = true;
                        MainMap.addMarkerCustomer2(G_KinhDo, G_ViDo, diaChiGPS);
                        //Nhập Kênh tự động theo địa chỉ vùng
                        setKenhByDiaChi((float)G_ViDo, (float)G_KinhDo);

                        getXeByToaDo_SANBAY(G_KinhDo, G_ViDo);
                    }
                }
                //editVung.Select();
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBox().Show(ex.Message);
                lblThongBao.Text = MSG_10_BANDO;
                g_GPS = false;
            }
        }

        /// <summary>
        /// Determines if a Point is inside a polygon.
        /// </summary>
        /// <returns>Return True if the point is inside Polygon.</returns>
        public static bool IsInsidePolygon(PointF[] polygon, PointF point)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddPolygon(polygon);
                return gp.IsVisible(point.X, point.Y);
            }
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)  
        {
            HienThiControl_GoiTaxi();
            //if (chkGoiTaxi.Checked && ThongTinCauHinh.GPS_TrangThai)
            //{
            //    setMarker();
            //}
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiLai();
            if (chkGoiLai.Checked)
            {
                editLenhDienThoai.TextBox.Text = "gọi lại";
            }
            else
            {
                editLenhDienThoai.TextBox.Text = "";
            }
        }

        private void chkGoiKhieuNai_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiKhieuNai();
            if (chkGoiKhieuNai.Checked)
            {
                editVung.TextBox.Text = "11";
            }
            else
            {
                editVung.TextBox.Text = "";
            }
        }

        private void chkGoiDichVu_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiDichVu();
            //editVung.TextBox.Text = "9";
        }

        private void chkGoiHoiDam_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiHoiDam();
            if (chkGoiHoiDam.Checked)
            {                
                editLenhDienThoai.TextBox.Text = "hỏi đàm";
                editVung.Focus();
            }
            else
            {
                editLenhDienThoai.TextBox.Text = "";
            }
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiKhac();
            editVung.TextBox.Text = "";
        }

        private void editLenhDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (editLenhDienThoai.TextBox.Text.StartsWith("3"))
            {
                editLenhDienThoai.TextBox.Text = LENH_KHACHDAT;
            }
        }

        private void chkKhongXeXinLoi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChiDonKhach_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //{
            //    btnOK.Focus();
            //}
            //else if (e.KeyCode == Keys.Down)
            //{
            //    chkGoiTaxi.Focus();
            //}
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if(txtDiaChiDonKhach.TextReturn != "")
            //        new MessageBox.MessageBox().Show("test");
            //}
        }

        #region Xử lý HOTKEY

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (FindFocusedControl(txtDiaChiDonKhach) && txtDiaChiDonKhach.IsCompleted)
            {
                switch (keyData)
                {
                    //case Keys.Enter:
                    //    if (txtDiaChiDonKhach.KinhDo != 0)
                    //    {
                    //        MainMap.addMarkerCustomer2(txtDiaChiDonKhach.KinhDo, txtDiaChiDonKhach.ViDo, getDiaChiChuan(txtDiaChiDonKhach.Text));
                    //    }                        
                    //    return true;
                    case Keys.Down:
                        chkGoiTaxi.Focus();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// function tim xem control do co dang dc focus khong
        /// </summary>
        /// <param name="control"></param>
        /// <returns>focused = true</returns>
        public static bool FindFocusedControl(Control control)
        {
            var container = control as ContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as ContainerControl;
            }
            return control != null;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                g_CloseForm = true;
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.G) && chkGoiTaxi.Enabled == true)
            {
                chkGoiTaxi.Focus();
                if (chkGoiTaxi.Checked)
                {
                    chkGoiTaxi.Checked = false;
                }
                else
                {
                    chkGoiTaxi.Checked = true;
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.L) && chkGoiLai.Enabled == true)
            {
                chkGoiLai.Focus();
                if (chkGoiLai.Checked)
                {
                    chkGoiLai.Checked = false;
                }
                else
                {
                    chkGoiLai.Checked = true;
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.I) && chkGoiKhieuNai.Enabled == true)
            {
                chkGoiKhieuNai.Focus();
                if (chkGoiKhieuNai.Checked)
                {
                    chkGoiKhieuNai.Checked = false;
                }
                else
                {
                    chkGoiKhieuNai.Checked = true;
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D) && chkGoiDichVu.Enabled == true)
            {
                chkGoiDichVu.Focus();
                if (chkGoiDichVu.Checked)
                    chkGoiDichVu.Checked = false;
                else
                    chkGoiDichVu.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.M) && chkGoiHoiDam.Enabled == true)
            {
                chkGoiHoiDam.Focus();
                if (chkGoiHoiDam.Checked)
                    chkGoiHoiDam.Checked = false;
                else
                    chkGoiHoiDam.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.K) && chkGoiKhac.Enabled == true)
            {
                chkGoiKhac.Focus();
                if (chkGoiKhac.Checked)
                    chkGoiKhac.Checked = false;
                else
                    chkGoiKhac.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.N) && txtDiaChiDonKhach.Enabled == true)
            {
                txtDiaChiDonKhach.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.S) && editSoLuongXe.Enabled == true)
            {
                editSoLuongXe.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.V))
            {
                editVung.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.T) && editLenhDienThoai.Enabled == true)
            {
                editLenhDienThoai.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.Q))
            {
                editKetQua.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {
                txtDiaChi_GPS.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.P) && btnGPS.Enabled == true)
            {
                btnGPS_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.B) && btnRemoveGPS.Enabled == true)
            {
                btnRemoveGPS_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.Y) && btnRemoveGPS.Enabled == true)
            {
                btnGPS_SanBay_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.X))
            {
                if (chkDaXuLy.Checked)
                    chkDaXuLy.Checked = false;
                else
                    chkDaXuLy.Checked = true;
                return true;
            }
            else if ((keyData == (Keys.Alt | Keys.NumPad4) || keyData == (Keys.Alt | Keys.D4))
                 && chkXe4.Enabled == true && chkKhongXe.Enabled == true && chkXe7.Enabled == true)
            {
                chkXe4.Checked = true;
                chkKhongXe.Checked = false;
                txtDiaChiDonKhach.Focus();
                return true;
            }
            else if ((keyData == (Keys.Alt | Keys.NumPad7) || keyData == (Keys.Alt | Keys.D7))
                && chkXe4.Enabled == true && chkKhongXe.Enabled == true && chkXe7.Enabled == true)
            {
                chkXe7.Checked = true;
                chkKhongXe.Checked = false;
                txtDiaChiDonKhach.Focus();
                return true;
            }
            else if ((keyData == (Keys.Alt | Keys.NumPad0) || keyData == (Keys.Alt | Keys.D0))
                && chkXe4.Enabled == true && chkKhongXe.Enabled == true && chkXe7.Enabled == true)
            {
                chkKhongXe.Focus();
                if (chkKhongXe.Checked == true)
                    chkKhongXe.Checked = false;
                else
                    chkKhongXe.Checked = true;

                chkXe7.Checked = false;
                chkXe4.Checked = false;

                txtDiaChiDonKhach.Focus();
                return true;
            }
            else if (keyData == (Keys.Tab) && chkGoiTaxi.Focused)
            {
                chkGoiTaxi.Focus();
                chkGoiTaxi.Checked = !chkGoiTaxi.Checked;
                return true;
            }
            else if (keyData == (Keys.Down) && txtDiaChiDonKhach.Focused)
            {
                chkGoiTaxi.Focus();
                chkGoiTaxi.Checked = !chkGoiTaxi.Checked;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {
                txtDiaChi_GPS.Focus();
                return true;
            }            
            else if (keyData == Keys.Enter) // Mo nhap du lieu dong 1
            {
                if (txtDiaChi_GPS.Focused == false)
                {
                    btnOK_Click(null, null);
                    if (DialogResult == DialogResult.Cancel) return true;
                    if (!g_CloseForm) return true;
                    DialogResult = DialogResult.OK;
                    Close();
                    return true;
                }

            }
            //else if (keyData == Keys.F1)
            //{
            //    OnHienThiCuocMoiEvent(new EventArgs());
            //}
            //else if (keyData == (Keys.Shift | Keys.D1) || keyData == (Keys.Shift | Keys.NumPad1))
            //{
            //    setVung("1");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D2) || keyData == (Keys.Shift | Keys.NumPad2))
            //{
            //    setVung("2");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D3) || keyData == (Keys.Shift | Keys.NumPad3))
            //{
            //    setVung("3");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D4) || keyData == (Keys.Shift | Keys.NumPad4))
            //{
            //    setVung("4");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D5) || keyData == (Keys.Shift | Keys.NumPad5))
            //{
            //    setVung("5");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D6) || keyData == (Keys.Shift | Keys.NumPad6))
            //{
            //    setVung("6");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D7) || keyData == (Keys.Shift | Keys.NumPad6))
            //{
            //    setVung("7");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D8) || keyData == (Keys.Shift | Keys.NumPad8))
            //{
            //    setVung("8");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D9) || keyData == (Keys.Shift | Keys.NumPad9))
            //{
            //    setVung("9");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D0) || keyData == (Keys.Shift | Keys.NumPad0))
            //{
            //    setVung("10");
            //    return true;
            //}
            else if (keyData == Keys.F10)
            {
                //using (Taxi.GUI.QuanLyThe.TraCuuTheMCC traCuuTheMCC = new Taxi.GUI.QuanLyThe.TraCuuTheMCC())
                //{
                //    traCuuTheMCC.ShowDialog();
                //}
                return true;
            }
            else if (keyData == (Keys.F11))
            {
                //using (Taxi.GUI.CheckCoDuongDai.ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new Taxi.GUI.CheckCoDuongDai.ThongTinSanBay_DuongDai())
                //{
                //    thongTinSanBay_DuongDai.ShowDialog();
                //}
                return true;
            }
            else if (keyData == (Keys.Shift | Keys.F11))
            {
                //using (TaxiOperation_DienThoai.CheckCoDuongDai.DSCuocDuongDai_SanBay dsSanBay_DuongDai = new TaxiOperation_DienThoai.CheckCoDuongDai.DSCuocDuongDai_SanBay())
                //{
                //    dsSanBay_DuongDai.ShowDialog();
                //}
                return true;
            }
            else if (keyData == (Keys.F7))
            {
                //new Taxi.GUI.frmTinhTienTheoKm().Show();
                return true;
            }
            else if (keyData == (Keys.F8))
            {
                new frmDMDiaDanh().Show();
                return true;
            }
            else if (keyData == (Keys.F9))
            {
                //new Taxi.GUI.TimKiemCuocGoi(DieuHanhTaxi.GetTimeServer(), "", 1, g_LoaiXeMacDinh).Show();            
                return true;
            }
            else if (keyData == (Keys.F12))
            {
                if (string.IsNullOrEmpty(g_CuocGoi.XeNhan))
                {
                    //using (Taxi.GUI.KhachDat.frmKhachDat frmKhachDat = new Taxi.GUI.KhachDat.frmKhachDat(g_CuocGoi, g_ListDataAutoComplete))
                    //{
                    //    DialogResult dialog = frmKhachDat.ShowDialog();
                    //    if (dialog == DialogResult.OK)
                    //    {
                    //        Close();
                    //    }
                    //}
                }
                else
                {
                    new MessageBox.MessageBox().Show(this, "Phải là cuộc gọi mới(Chưa được chuyển sang tổng đài và chưa có thông tin xe nhận-đón)", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                }
                return true;
            }

            return false;
        }

        //Tìm điểm theo địa chỉ
        private void txtDiaChi_GPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string diaChi = getDiaChiChuan(txtDiaChi_GPS.Text);
                if (!string.IsNullOrEmpty(diaChi))
                {
                    double viDo = 0;
                    double kinhDo = 0;
                    string toaDo = GetGeobyAddressBA2(diaChi);
                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        viDo = Convert.ToDouble(arrString[0]);
                        kinhDo = Convert.ToDouble(arrString[1]);                        
                    }
                    else
                    {
                        lblThongBao.Text = MSG_6_BANDO;
                    }
                    if (kinhDo == 0 && viDo == 0)
                        return;

                    MainMap.addMarkerCustomer2(kinhDo, viDo, diaChi); 
                }                
            }
        }        

        // Xử lý phím lên xuống
        private void txtDiaChiDonKhach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnOK.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiTaxi.Focus();
            }
        }

        private void chkGoiTaxi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtDiaChiDonKhach.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiLai.Focus();
            }
        }

        private void chkGoiLai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiTaxi.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiKhieuNai.Focus();
            }
        }

        private void chkGoiKhieuNai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiLai.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiDichVu.Focus();
            }
        }

        private void chkGoiDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiKhieuNai.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiHoiDam.Focus();
            }
        }

        private void chkGoiHoiDam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiDichVu.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiKhac.Focus();
            }
        }

        private void chkGoiKhac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiHoiDam.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkXe4.Focus();
            }
        }

        //LOAI XE
        private void chkXeKI4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiKhac.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkXe7.Focus();
            }
        }

        private void chkXeVIOS4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkXe4.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkKhongXe.Focus();
            }
        }

        private void chkXeINOVA7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkXe7.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                //chkXeLIMO7.Focus();
            }
        }

        private void editSoLuongXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkKhongXe.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editVung.Focus();
            }
        }

        private void editVung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                editSoLuongXe.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editLenhDienThoai.Focus();
            }

        }

        private void editLenhDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                editVung.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editKetQua.Focus();
            }
            
        }

        private void editGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                editLenhDienThoai.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnOK.Focus();
            }
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
               editKetQua.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnCancel.Focus();
            }
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnOK.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnGPS.Focus();
            }
        }
        #endregion Xử lý HOTKEY
        #endregion
        
        #region ==========================MAPS=================================
        private int KenhID = 0;
        private string MaCungXN = string.Empty;
        private string g_DSXeDeCu;
        private string g_DSXeDeCu_TD;
        bool isMarker = false;
        XeOnline clsXeOnline = new XeOnline();
        private GMapProvider _mapType;
        private EFiling.Utils.MapModeEnum _mapMode;
        private int _mapZoom;
        //private object Object;

        // markers
        GMapMarkerCustom centerMarker;
        //GMapMarker currentMarker;
        private List<GMapMarker> _otherMarkers;
        // layers
        GMapOverlay top;
        GMapOverlay OverlayXeDeCu;
        GMapOverlay OverlayXeNhan;

        bool isMouseDown;

        private void ConfigMap()
        {
            if (ThongTinCauHinh.GPS_TrangThai == true && g_CGLimit == false)
            {
                btnGPS.Enabled = true;
                btnRemoveGPS.Enabled = true;
            }
            else
            {
                if (g_CGLimit)
                    lblThongBao.Text = "Thông báo : Tạm thời ngắt GPS vì có quá nhiều cuộc gọi chưa giải quyết!";
                btnGPS.Enabled = false;
                btnRemoveGPS.Enabled = false;
            }
            // config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            //MainMap.CacheLocation = System.Configuration.ConfigurationManager.AppSettings["MapPath"]; 
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 7;
            MainMap.Zoom = 15;
            MainMap.Dock = DockStyle.Fill;
            
            //MainMap.PolygonsEnabled = false;            
            // map events

            // add custom layers  
            {
                top = new GMapOverlay("top");
                MainMap.Overlays.Add(top);

                OverlayXeDeCu = new GMapOverlay("OverlayXeDeCu");
                MainMap.Overlays.Add(OverlayXeDeCu);
            }

            pnlBanDo.Controls.Add(MainMap);
            MainMap.Position = new PointLatLng(21.029094, 105.779958);
            if (_mapMode == EFiling.Utils.MapModeEnum.EditPoint)
            {
                MainMap.MouseMove += MainMap_MouseMove;
                MainMap.MouseDown += MainMap_MouseDown;
                MainMap.MouseUp += MainMap_MouseUp;
            }
            else
            {
                MainMap.MouseMove -= MainMap_MouseMove;
                MainMap.MouseDown -= MainMap_MouseDown;
                MainMap.MouseUp -= MainMap_MouseUp;
            }
            MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;


            // get zoom  
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
            trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);

            
            //CbMapType.ValueMember = "Name";
            //CbMapType.DataSource = GMapProviders.List;
            //CbMapType.SelectedItem = GMapProviders.GoogleMap;

            CustomInitMap();
        }

        private void CustomInitMap()
        {
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            
        }

        #region===================Map Events==================================

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
        }

        private void MainMap_OnMapZoomChanged()
        {
            trackBarMap.Value = (int)MainMap.Zoom;
        }

        private void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainMap.Zoom < MainMap.MaxZoom)
            {
                int zoom = (int)(MainMap.Zoom + 1);
                if (zoom > MainMap.MaxZoom)
                {
                    zoom = MainMap.MaxZoom;
                }
                trackBarMap.Value = zoom;
                MainMap.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = false;
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = true;
                if (MainMap.OverlayCustom == null || MainMap.OverlayCustom.Markers.Count <= 0)
                    //currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                //else
                {
                    PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                    string strDiaChi = BAService.GetAddressByGeo((float)point.Lat, (float)point.Lng);

                    MainMap.addMarkerCustomer(point, strDiaChi);
                    //currentMarker = MainMap.MarkerCustomer;
                }
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown)
            {
                if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.IsVisible)
                {

                    MainMap.MarkerCustomer.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                    string strDiaChi = BAService.GetAddressByGeo((float)MainMap.MarkerCustomer.Position.Lat, (float)MainMap.MarkerCustomer.Position.Lng);
                    MainMap.MarkerCustomer.ToolTipText = strDiaChi;
                    if (MainMap.OverlayXeDeCu != null)
                        MainMap.OverlayXeDeCu.Markers.Clear();
                }
            }
            MainMap.Refresh(); // force instant invalidation
        }

        #endregion=============================================================        

        private void setMarker()
        {
            if (top.Markers.Count == 0)
            {
                if (g_CuocGoi.GPS_KinhDo != 0)
                {
                    MainMap.addMarkerCustomer2(g_CuocGoi.GPS_KinhDo, g_CuocGoi.GPS_ViDo, g_CuocGoi.DiaChiDonKhach);
                }
                else
                {
                    string strDiaChi =getDiaChiChuan( StringTools.TrimSpace(txtDiaChiDonKhach.Text));
                    string toaDo = GetGeobyAddressBA2(strDiaChi);

                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        double viDo = Convert.ToDouble(arrString[0]);
                        double kinhDo = Convert.ToDouble(arrString[1]);
                        MainMap.addMarkerCustomer2(kinhDo, viDo,strDiaChi);
                    }
                    else
                    {
                        lblThongBao.Text = MSG_6_BANDO;
                    }
                }
            }
        }       
        
        /// <summary>
        /// lấy tọa độ theo địa chỉ
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private string GetGeobyAddressBA2(string address)
        {
            try
            {  
                string street = address;
                string city = ThongTinCauHinh.GPS_TenTinh;
                //int count2 = address.IndexOfAny(new char[] { ']' }, 0, address.Length);
                //if (count2 >= 0)
                //{
                //    street = address.Substring(count2 + 1, address.Length - count2-1);
                //}
                //int count = street.IndexOfAny(new char[] { '-' }, 0, street.Length);
                //if (count >= 0)
                //{
                //    street = street.Substring(0, count); 
                //}
                return BAService.GetGeobyAddressBA_HN(String.Format("{0},{1}", street, city));
            }
            catch (Exception ex)
            {
                return "*";
            }
        }        

        /// <summary>
        /// Lấy danh sách xe đề cử
        /// </summary>
        /// <param name="kinhDo"></param>
        /// <param name="viDo"></param>
        private void getXeByToaDo(double kinhDo, double viDo)
        {
            string loaiXeGPS = "";
            string loaiXe = GetThongTinLoaiXeChon2();
            int SoXeTraVe = 4 + Convert.ToInt16(editSoLuongXe.Text);

            if(string.IsNullOrEmpty(loaiXe)) // neu ko co chon loai xe thi tat ca loai xe           
                loaiXeGPS = new Taxi.Business.DM.Xe().LayDanhSachLoaiXe_GPS("0,4,7");
            else
                loaiXeGPS = new Taxi.Business.DM.Xe().LayDanhSachLoaiXe_GPS(loaiXe);

            string dsXeDeCu = string.Empty;
            
            dsXeDeCu = new TaxiOperation_TongDai.WCFSyncService.SyncServiceOnlineClient().LayDanhSachXeDeCu_ToaDo(kinhDo,
                                                               viDo,
                                                               ThongTinCauHinh.GPS_MaCungXN,
                                                               loaiXeGPS,
                                                               G_BanKinhTimXe,
                                                               true, SoXeTraVe);
            setResult(dsXeDeCu.Trim());            
        }

        private void getXeByToaDo_SANBAY(double kinhDo, double viDo)
        {
            string loaiXeGPS = "";
            string loaiXe = GetThongTinLoaiXeChon2();
            int soluong = 0;
            int.TryParse(editSoLuongXe.Text,out soluong);
            int SoXeTraVe = 4 + soluong;

            if (string.IsNullOrEmpty(loaiXe)) // neu ko co chon loai xe thi tat ca loai xe           
                loaiXeGPS = new Taxi.Business.DM.Xe().LayDanhSachLoaiXe_GPS("0,4,7");
            else
                loaiXeGPS = new Taxi.Business.DM.Xe().LayDanhSachLoaiXe_GPS(loaiXe);

            string dsXeDeCu = string.Empty;

            dsXeDeCu = new TaxiOperation_TongDai.WCFSyncService.SyncServiceOnlineClient().LayDanhSachXeDeCu_ToaDo_SANBAY(kinhDo,
                                                               viDo,
                                                               ThongTinCauHinh.GPS_MaCungXN,
                                                               loaiXeGPS,
                                                                SoXeTraVe);
            setResult(dsXeDeCu.Trim());
        }

        /// <summary>
        /// Vẽ xe đề cử lên bản đồ
        /// </summary>
        /// <param name="result">danh sách xe đề cử có tọa độ - Service trả về</param>
        private void setResult(string result)
        {
            try
            {
                if (String.IsNullOrEmpty(result))
                    return;
                string[] Values;
                string dsXeDeCu = "";
                int trangThai = 0;
                foreach (string strValue in result.Split(','))
                {
                    //"SHXe_KhoangCach_KD_VD_TrangThai"
                    Values = strValue.Split('_');
                    if (Values.Length > 0)
                    {
                        // --TH SHX = '1234-2' chi lay 1234 (4 ky tu dau tien)
                        string SHX = Values[0].Substring(0, 4);
                        dsXeDeCu = string.Format("{0}{1}.", dsXeDeCu, SHX);
                        if (!String.IsNullOrEmpty(Values[4]))
                        {
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0; //---0 : xe tắt máy; 1 : xe bật máy.
                        }

                        MainMap.addMarkerXeDeCu(trangThai,
                            Convert.ToDouble(Values[2]), 
                            Convert.ToDouble(Values[3]),
                            string.Format("{0}-{1}", SHX, Values[1]));
                    }
                }
                if (dsXeDeCu.LastIndexOf('.') > 0)
                {
                    g_DSXeDeCu = dsXeDeCu.Substring(0,dsXeDeCu.Length-1);
                    g_DSXeDeCu_TD = result;
                }
            }
            catch (Exception ex)
            {
                g_DSXeDeCu = "";
                g_DSXeDeCu_TD = "";
            }
        }

        /// <summary>
        /// vẽ xe đề cử lên bản đô
        /// </summary>
        /// <param name="DSXeDeCu"></param>
        /// <param name="DSXeDeCu_TD"></param>
        private void setMarkerDSXeDeCu(string DSXeDeCu, string DSXeDeCu_TD)
        {
            try
            {
                int trangThai = 0;
                string[] arrDSXeDeCu = DSXeDeCu.Split('.');
                string[] arrDSXeDeCu_TD = DSXeDeCu_TD.Split(',');
                string[] Values;
                for (int i = 0; i < arrDSXeDeCu.Length; i++)
                {
                    //"SHXe-KhoangCach-KD-VD-TrangThai"
                    Values = arrDSXeDeCu_TD[i].Split('_');
                    if (Values.Length > 0)
                    {
                        if (Values[4] != "")
                        {
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;//---0 : xe tắt máy; 1 : xe bật máy.
                        }
                        MainMap.addMarkerXeDeCu(trangThai, Convert.ToDouble(Values[2]), Convert.ToDouble(Values[3]), string.Format("{0}-{1}", arrDSXeDeCu[i], Values[1]));
                    }
                }                
            }
            catch(Exception ex)
            {
                lblThongBao.Text = MSG_11_BANDO;
            }
        }

        /// <summary>
        /// vẽ xe nhận lên bản đồ
        /// </summary>
        /// <param name="DSXeNhan"></param>
        /// <param name="DSXeNhan_TD"></param>
        private void setMarkerDSXeNhan(string DSXeNhan, string DSXeNhan_TD)
        {
            try
            {
                int trangThai = 0;
                string[] arrDSXeNhan = DSXeNhan.Split('.');
                string[] arrDSXeNhan_TD = DSXeNhan_TD.Split(',');
                string[] Values;
                for (int i = 0; i < arrDSXeNhan.Length; i++)
                {
                    //"SHXe-KhoangCach-KD-VD-TrangThai"
                    Values = arrDSXeNhan_TD[i].Split('-');
                    if (Values.Length > 0)
                    {
                        if (!String.IsNullOrEmpty(Values[4]))
                        {
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;//---0 : xe tắt máy; 1 : xe bật máy.
                        }
                        MainMap.addMarkerXeNhan(trangThai, Convert.ToDouble(Values[2]), Convert.ToDouble(Values[3]), string.Format("{0}-{1}", arrDSXeNhan[i], Values[1]));
                    }
                }
            }
            catch (Exception ex)
            {
                lblThongBao.Text = MSG_12_BANDO;
            }
        }

        private void trackBarMap_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }

        private void editVung_TextChanged(object sender, EventArgs e)
        {
            string sVung = StringTools.TrimSpace(editVung.Text);
            if (sVung == "11")
            {
                chkGoiKhieuNai.Checked = true;
            }
            if (sVung != "9" && sVung != "10" && sVung != g_CuocGoi.Vung.ToString())
            {
                //editKetQua.Enabled = false;
                chkDaXuLy.Enabled = false;
            }
            else
            {
                editKetQua.Enabled = true;
                chkDaXuLy.Enabled = true;
            }
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (txtDienThoai.Text == ThongTinCauHinh.SoDienThoaiCongTy) return;

            if (StringTools.TrimSpace(txtDienThoai.Text).Length >= 8)
            {
                txtDiaChiDonKhach.Text = StringTools.TrimSpace(GetDiaChiGoiDen(StringTools.TrimSpace(txtDienThoai.Text), out  g_KieuKHGoi, out G_MaDoiTac));
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
        /// <param name="PhoneNumber"></param>
        /// <param name="outKieuKhachHang"></param>
        /// <returns></returns>
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

            if (objDoiTac.Address.Length > 0)
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
        /// <returns></returns>
        private string GetDiaChiCuaCuocGoiGanNhatTrongNgay(string PhoneNumber)
        {
            try
            {
                string strDiaChi = "";
                List<DieuHanhTaxi> lstDienThoai = new List<DieuHanhTaxi>();
                //Lay danh sach cac cuoc goi con hoat dong (chua ket thuc)
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                string SQLCondition = " ORDER BY ThoiDiemGoi DESC";
                lstDienThoai = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
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