using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Taxi.Data.BanCo.Entity;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.MasterData;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Taxi.Common.Extender;
using Taxi.Controls.BanCo;
using Taxi.Services;
using Taxi.Services.WCFServices;
using Taxi.Utils;
using Taxi.Data.BanCo.Entity.DM;
using Taxi.Business;
using Taxi.Data.BanCo;
using Taxi.Controls.Base.Extender;
using System.Timers;
namespace Taxi.Controls.BanCo
{
    public struct Style_LoaiXe
    {
        public Font FontChu;
        public Color BackColor;
        public Color ForeColor;
    }
    public partial class Control_DieuHanhBanCo_BanCo : XtraUserControl
    {
        #region Properties
        public int MinWidthVung { get; set; }
        public int MaxWidthVung { get; set; }
        public int HeighVung { get; set; }
        public int WidthVung { get; set; }
        public int HeighCell { get; set; }
        public int DistanceVung { get; set; }
        /// <summary>
        /// cho biết trạng thái sử dụng của bàn cờ
        /// </summary>
        public bool IsBanCo = false;

        public System.Timers.Timer Timer_BanCo;
        #endregion

        #region Private Variables
        /// <summary>
        /// Vùng điều hành ( điểm đỗ)
        /// </summary>
        public Dictionary<int, Vung> dicVung;
        /// Lưu thông tin ID của vùng (ID + ID trên GPS)
        /// </summary>
        public Dictionary<int, int> dicVungId_IDGPS;

        private readonly List<GroupControl> listGroupControl;
        /// <summary>
        /// Dic chứa tất cả các grid điểm đỗ
        /// </summary>
        private readonly Dictionary<int, MyDgv> dicDataGrid;
        /// <summary>
        /// Group chứa grid các điểm đỗ
        /// </summary>
        public readonly Dictionary<int, GroupControl> dicGroupControl;
        private SyncServiceOnlineClient client;
        /// <summary>
        /// thông tin cấu hình màu sắc của trạng thái
        /// </summary>
        private Dictionary<int, Color> dicStatusForeColor;
        /// <summary>
        /// thông tin cấu hình màu sắc của trạng thái
        /// </summary>
        private Dictionary<int, Color> dicStatusBackColor;

        private float cellFontSize = 7f;
        private const int MinWidthVungCuoi = 250;
        private T_XeOnline[] listXeOnline;
        private Point currentMouseLocation;
        private List<string> listXeNhan = new List<string>();
        /// <summary>
        /// Dict lưu thông tin online của các xe nhận
        /// </summary>
        private Dictionary<string, T_XeOnline> dicXeNhan_Online;
        private Dictionary<string, int> dicCountSpeedLessThan3;
        /// <summary>
        /// Lưu trữ xe - Font hiển thị theo loại xe
        /// </summary>
        //private Dictionary<string, Font> dicXe_Font;

        /// <summary>
        /// Lưu trữ xe - Style hiển thị theo loại xe
        /// </summary>
        private Dictionary<string, Style_LoaiXe> dicLoaiXe_Style;

        public delegate void TimXeTrenBanDoEventHandler(object sender, MouseEventArgs e, string sohieuxe);
        public delegate void VungDieuHanhTrongEventHandler(object sender);
        public event VungDieuHanhTrongEventHandler VungDieuHanhTrong;
        public event TimXeTrenBanDoEventHandler TimXeTrenBanDo;
        private MyDgv dgvTinhTrangPhuongTien;
        public Dictionary<string, GiamSatXe_LienLac> dicGiamSat_AnCa;
        public Dictionary<string, GiamSatXe_LienLac> dicGiamSat_MatLL;
        public Dictionary<string, GiamSatXe_LienLac> dicGiamSat_MatTH;
        public Dictionary<string, GiamSatXe_LienLac> dicGiamSat_RoiXe;
        public Dictionary<string, GiamSatXe_LienLac> dicGiamSat_BaoHong;
        private Dictionary<string, GiamSatXe_LienLac> dicGiamSat_KhaiThac;
        private Dictionary<string, GiamSatXe_LienLac> dicGiamSat_RaKinhDoanh;
        public Dictionary<string, GiamSatXe_HoatDong> dicXeHoatDong;
        private Dictionary<string, GiamSatXe_HoatDong> dicXeHoatDong_BaoDiemTra;
        private Dictionary<string, GiamSatXe_HoatDong> dicXeKhongHoatDong;
        /// <summary>
        /// Dic chứa thông tin Xe thuộc điểm đỗ nào và node nào
        /// Xe - Object DiemDo_Node
        /// </summary>
        public Dictionary<string, DiemDo_Node> dicXe_DiemDo_Node;
        private int dgvTinhTrangPhuongTienWidth = 35;
        private Dictionary<int, int> dicGara_ColumnIndex;
        private Dictionary<string, int> dicXe_Gara;
        private Dictionary<int, DMGara> dicGara;
        private List<int> listGaraRowsCount;
        private MyDgv dgvCanhBaoXe;
        private List<GiamSatXe_LienLac> listGiamSatXe;
        public List<string> listTaxiOperationKetThuc;
        private List<string> listXeDiTuyen;
        /// <summary>
        /// Danh sach xe chua mo hang, hien thi o cot canh bao tren ban co.
        /// Lay du lieu tu ben Dong bo xe online
        /// </summary>
        private string[] lsXeChuaMoHang;

        public Dictionary<int, int> MappingTrangThaiColumns = new Dictionary<int, int>()
        {
            { 1, 4 },
            { 2, 1 }, 
            { 3, 2 }, 
            { 4, 3 }, 
            { 5, 5 }, 
            { 6, 6 }, 
            { 7, 7 }, 
        };
        private int G_TimerStep = 0;
        BackgroundWorker bwBanCo = new BackgroundWorker();
        /// <summary>
        /// Ghi nhận là load lúc khởi tạo
        /// </summary>
        private bool IsInit = true;
        /// <summary>
        /// Là bên tổng đài hay ko
        /// </summary>
        public bool IsTongDai = false;
        #endregion

        #region Constructer

        #region DllImport user32.dll
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            ShowScrollBar(this.Handle, 0, false);
            base.WndProc(ref m);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        #endregion

        public Control_DieuHanhBanCo_BanCo()
        {
            InitializeComponent();
            try
            {
                if (!DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                {
                    Timer_BanCo = new System.Timers.Timer();
                    Timer_BanCo.Interval = 1000;
                    LoadGlobalCommonData();
                    this.listGroupControl = new List<GroupControl>();
                    Global.HasGPS = true;

                    ReadStatusColor();

                    this.dicDataGrid = new Dictionary<int, MyDgv>();
                    this.dicGroupControl = new Dictionary<int, GroupControl>();
                    this.dicCountSpeedLessThan3 = new Dictionary<string, int>();
                    LoadListXe_Font();

                    this.Load += Control_DieuHanhBanCo_BanCo_Load;

                    this.client = new SyncServiceOnlineClient();
                    this.MouseMove += Control_DieuHanhBanCo_BanCo1_MouseMove;
                    this.Timer_BanCo.Elapsed += timer_Tick;
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Control_DieuHanhBanCo_BanCo:" + ex.Message);
                LogError.WriteLogError("Control_DieuHanhBanCo_BanCo", ex);
            }
        }

        /// <summary>
        /// Khởi tạo các dữ liệu dùng chu cho hệ thống
        /// </summary>
        private void LoadGlobalCommonData()
        {
            try
            {
                //Load danh sách khách hàng
                CommonBL.ListKH = null;
                //Load dữ liệu autocomplete
                //CommonBL.LoadDuLieuForAutoComplete();
                //Load dữ liệu danh sách xe
                CommonBL.LoadVehicles();
                //CommonBL.ListVungDieuHanh;
                CommonBL.DataTypeOfGoods = null;
                CommonBL.ListGroup = null;
                CommonBL.ListNhanVien = null;
                CommonBL.Commands = null;
                CommonBL.ListLoaiXe = null;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi LoadGlobalCommonData " + ex.Message);
            }

        }
        /// <summary>
        /// Load danh sách xe và font hiển thị
        /// </summary>
        private void LoadListXe_Font()
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                //string strFont = converter.ConvertToString(new Font(new FontFamily("Tahoma"), cellFontSize, FontStyle.Bold));
                //Font a = (Font)converter.ConvertFromString(strFont);
                //dicXe_Font = new Dictionary<string, Font>();
                dicLoaiXe_Style = new Dictionary<string, Style_LoaiXe>();
                string strFontDefault = "Tahoma, 8.25pt, style=Regular";
                Font font;
                Color BackColor;
                Color ForeColor;
                string strFont;
                float fontSize = 0;
                foreach (var item in CommonBL.ListXe)
                {
                    TuDien_LoaiXe objLoaiXe = CommonBL.ListLoaiXe.Find(T => T.LoaiXeID == item.FK_LoaiXeID);

                    strFont = objLoaiXe != null ? objLoaiXe.Font : strFontDefault;
                    BackColor = objLoaiXe != null && string.IsNullOrEmpty(objLoaiXe.BackColor) ? Color.FromArgb(Convert.ToInt32(objLoaiXe.BackColor)) : Color.White;
                    ForeColor = objLoaiXe != null && string.IsNullOrEmpty(objLoaiXe.ForeColor) ? Color.FromArgb(Convert.ToInt32(objLoaiXe.ForeColor)) : Color.Black;
                    font = converter.IsValid(strFont) ? (Font)converter.ConvertFromInvariantString(strFont) :
                                                        (Font)converter.ConvertFromInvariantString(strFontDefault);
                    if (font.Size < cellFontSize)
                    {
                        fontSize = cellFontSize;
                    }
                    else
                    {
                        fontSize = font.Size;
                    }
                    //if (dicXe_Font.ContainsKey(item.PK_SoHieuXe)) continue;
                    if (dicLoaiXe_Style.ContainsKey(item.PK_SoHieuXe)) continue;
                    Style_LoaiXe objStyle = new Style_LoaiXe();
                    objStyle.BackColor = BackColor;
                    objStyle.ForeColor = ForeColor;
                    objStyle.FontChu = new Font(font.FontFamily, fontSize, font.Style);
                    dicLoaiXe_Style.Add(item.PK_SoHieuXe, objStyle);
                    //dicXe_Font.Add(item.PK_SoHieuXe, font);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadListXe_Font", ex);
            }

        }

        /// <summary>
        /// Lấy thông tin cấu hình màu sắc của trạng thái
        /// </summary>
        private void ReadStatusColor()
        {
            var listStatusColor = new ColorOfStatusModel().GetAllData();
            this.dicStatusForeColor = listStatusColor.ToDictionary(t => (int)t.Id, t => (t.Color == null || t.Color.ToString().Length == 0) ? Color.Black : Color.FromArgb(Convert.ToInt32(t.Color.ToString())));
            this.dicStatusBackColor = listStatusColor.ToDictionary(t => (int)t.Id, t => (t.BackColor == null || t.BackColor.Length == 0) ? Color.White : Color.FromArgb(Convert.ToInt32(t.BackColor)));
        }
        #endregion
        //Khởi tạo ô tình trạng phương tiện
        //List<int> listTinhTrangPhuongTienRowsCount = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1 };
        //List<int> listCanhBaoXeRowsCount = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        //Dictionary<int, List<int>> dicVungRowsCount = new Dictionary<int, List<int>>();
        #region Form Load
        private void Control_DieuHanhBanCo_BanCo_Load(object sender, EventArgs e)
        {
            try
            {
                Global.TaxiOperation_Module = TaxiOperation_Module.DieuXeTaxi;
                //if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                //    return;
                dicXeNhan_Online = new Dictionary<string, T_XeOnline>();
                cellFontSize = 7f;
                if (MaxWidthVung >= 90)
                {
                    cellFontSize = 9.5f;
                }
                if (MaxWidthVung >= 120)
                {
                    cellFontSize = 9.5f;
                }
                if (MaxWidthVung > 150)
                {
                    cellFontSize = 11.5f;
                    //  dgvTinhTrangPhuongTienWidth = 45;
                }
                if (MaxWidthVung >= 200)
                {
                    cellFontSize = 13f;
                    //  dgvTinhTrangPhuongTienWidth = 50;
                }
                if (dicVung.Count == 0)
                {
                    if (VungDieuHanhTrong != null)
                    {
                        VungDieuHanhTrong(this);
                        return;
                    }
                }


                LoadListXe_Font();

                if (IsBanCo)
                {
                    dgvTinhTrangPhuongTienWidth = MaxWidthVung > 120 ? 30 : 27;
                }
                this.SizeChanged += Control_DieuHanhBanCo_BanCo_SizeChanged;

                #region Vung Dieu Hanh
                DistanceVung = 1;
                int i = 0;
                foreach (var vung in dicVung.Values)
                {
                    var group = new GroupControl
                    {
                        Text = vung.Ten,
                        Location = new Point(3, 3),
                        Width = MinWidthVung,
                        Height = HeighVung,
                        FireScrollEventOnMouseWheel = true
                    };
                    //group.AutoScroll
                    //group.Controls.Add(new DevExpress.XtraEditors.XtraScrollableControl
                    //{  

                    //    Dock = DockStyle.Right,
                    //    AutoScroll = true,
                    //    AlwaysScrollActiveControlIntoView = true,

                    //});

                    listGroupControl.Add(group);

                    dicGroupControl[vung.VungGPSID] = listGroupControl[i];
                    {
                        var backColor = Color.FromName(vung.MauChu);
                        listGroupControl[i].AppearanceCaption.BackColor = backColor;


                        float b = backColor.GetBrightness();
                        float h = backColor.GetHue();
                        float s = backColor.GetSaturation();
                        if (b >= 0.9f || b == 0.5f || (s == 1f && h < 128f) || (h == 0 && s == 0 && b == 0))
                            listGroupControl[i].AppearanceCaption.ForeColor = Color.Black;
                    }
                    listGroupControl[i].BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                    listGroupControl[i].LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
                    listGroupControl[i].LookAndFeel.UseDefaultLookAndFeel = false;
                    listGroupControl[i].Margin = new System.Windows.Forms.Padding(0);
                    listGroupControl[i].AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    this.Controls.Add(listGroupControl[i]);

                    var dgvXe = InitGridBanCo(vung.VungGPSID);
                    dicDataGrid[vung.VungGPSID] = dgvXe;
                    var xtraScrollable = new MyPanelControl
                    {
                        Dock = DockStyle.Fill,
                    };

                    xtraScrollable.AddControl(dgvXe);
                    //listGroupControl[i].Controls.Add(dgvXe);
                    listGroupControl[i].Controls.Add(xtraScrollable);
                    i++;
                }
                #endregion

                #region Tinh trang phuong tien
                var groupTinhTrangPhuongTien = new GroupControl();
                groupTinhTrangPhuongTien.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                groupTinhTrangPhuongTien.Text = "Tình trạng phương tiện";
                groupTinhTrangPhuongTien.Height = HeighVung;
                groupTinhTrangPhuongTien.AppearanceCaption.BackColor = Color.MediumVioletRed;
                groupTinhTrangPhuongTien.AppearanceCaption.BackColor2 = Color.Pink;
                groupTinhTrangPhuongTien.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
                groupTinhTrangPhuongTien.LookAndFeel.UseDefaultLookAndFeel = false;

                listGroupControl.Add(groupTinhTrangPhuongTien);

                InitGridTinhTrangPhuongTien();

                listGroupControl[i].Controls.Add(dgvTinhTrangPhuongTien);
                this.Controls.Add(listGroupControl[i++]);
                #endregion

                #region Canh Bao Xe
                var groupCanhBao = new GroupControl();
                groupCanhBao.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                groupCanhBao.Text = "Cảnh báo xe";
                groupCanhBao.Height = HeighVung;
                groupCanhBao.AppearanceCaption.BackColor = Color.SteelBlue;
                groupCanhBao.AppearanceCaption.BackColor2 = Color.DeepSkyBlue;
                groupCanhBao.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
                groupCanhBao.LookAndFeel.UseDefaultLookAndFeel = false;
                //groupCanhBao.Width = 200;
                listGroupControl.Add(groupCanhBao);

                InitGridCanhBao();

                listGroupControl[i].Controls.Add(dgvCanhBaoXe);

                this.Controls.Add(listGroupControl[i]);
                #endregion

                dicXe_Gara = Taxi.Business.CommonBL.ListXe.ToDictionary(t => t.PK_SoHieuXe, t => t.FK_GaraID);
                listGaraRowsCount = new List<int>();
                for (int j = 0; j < dicGara.Count; j++)
                {
                    listGaraRowsCount.Add(1);
                }
                ResetListGaraRowsCount();

                InitDictionary();
                
                ProcessBanCo();
                Timer_BanCo.Start();
                bwBanCo_Init();
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi Control_DieuHanhBanCo_BanCo_Load " + ex.Message);
            }
        }

        string statusBaoHong = string.Empty;
        string statusAnCa = string.Empty;
        string statusMatLL = string.Empty;
        string statusMatTH = string.Empty;
        string statusRoiXe = string.Empty;
        string statusKhaiThac = string.Empty;
        string statusRaKinhDoanh = string.Empty;
        private List<GiamSatXe_HoatDong> List_GiamSatXe_HoatDong = new List<GiamSatXe_HoatDong>();
        private List<GiamSatXe_HoatDong> List_GiamSatXe_HoatDong_BaoDiemTra = new List<GiamSatXe_HoatDong>();

        private void bwBanCo_Init()
        {
            bwBanCo.WorkerSupportsCancellation = true;
            bwBanCo.DoWork += bwBanCo_DoWork;
        }

        private void InitDictionary()
        {
            statusAnCa = ((int)Enum_TrangThaiLaiXeBao.BaoNghi_AnCa).ToString();
            dicGiamSat_AnCa = new Dictionary<string, GiamSatXe_LienLac>();

            statusMatLL = ((int)Enum_TrangThaiLaiXeBao.MatLienLac).ToString();
            dicGiamSat_MatLL = new Dictionary<string, GiamSatXe_LienLac>();

            statusMatTH = ((int)Enum_TrangThaiLaiXeBao.MatTinHieu).ToString();
            dicGiamSat_MatTH = new Dictionary<string, GiamSatXe_LienLac>();

            statusRoiXe = ((int)Enum_TrangThaiLaiXeBao.BaoNghi_RoiXe).ToString();
            dicGiamSat_RoiXe = new Dictionary<string, GiamSatXe_LienLac>();

            statusBaoHong = ((int)Enum_TrangThaiLaiXeBao.BaoSuCoTaiNanCongAn).ToString();
            dicGiamSat_BaoHong = new Dictionary<string, GiamSatXe_LienLac>();

            statusKhaiThac = ((int)Enum_TrangThaiLaiXeBao.KhaiThac).ToString();
            dicGiamSat_KhaiThac = new Dictionary<string, GiamSatXe_LienLac>();

            statusRaKinhDoanh = ((int)Enum_TrangThaiLaiXeBao.BaoRaKinhDoanh).ToString();
            dicGiamSat_RaKinhDoanh = new Dictionary<string, GiamSatXe_LienLac>();

            dicXe_DiemDo_Node = new Dictionary<string, DiemDo_Node>();

        }
        /// <summary>
        /// Khởi tạo grid Bàn cờ
        /// </summary>
        private MyDgv InitGridBanCo(int VungGPSID)
        {
            try
            {
                var dgvXe = new MyDgv();
                dgvXe.AllowUserToAddRows = false;
                dgvXe.AllowUserToDeleteRows = false;
                dgvXe.AllowUserToResizeRows = false;
                dgvXe.AllowUserToResizeColumns = false;
                dgvXe.CellBeginEdit += (sender1, e1) => { e1.Cancel = true; };
                dgvXe.RowsAdded += (sender1, e1) => { ResizeVungColumns(sender1); };
                dgvXe.RowsRemoved += (sender1, e1) => { ResizeVungColumns(sender1); };
                dgvXe.LostFocus += (sender1, e1) => { (sender1 as MyDgv).ClearSelection(); };
                dgvXe.MouseClick += dgv_MouseClick;
                dgvXe.MouseDoubleClick += dgvXe_MouseDoubleClick;

                for (int i = 1; i <= 4; i++)
                {
                    dgvXe.Columns.Add(String.Format("c{0}{1}", VungGPSID, i), "");
                }

                dgvXe.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dgvXe.RowHeadersVisible = false;
                dgvXe.ColumnHeadersVisible = false;
                dgvXe.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0);
                dgvXe.BorderStyle = System.Windows.Forms.BorderStyle.None;
                dgvXe.ScrollBars = System.Windows.Forms.ScrollBars.None;
                dgvXe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvXe.DefaultCellStyle.Font = new Font(new FontFamily("Tahoma"), cellFontSize, FontStyle.Bold);
                dgvXe.Margin = new System.Windows.Forms.Padding(0);
                dgvXe.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0);
                //dgvXe.Dock = DockStyle.Left;
                dgvXe.MultiSelect = false;
                dgvXe.RowTemplate.Height = HeighCell;
                dgvXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvXe.SelectionMode = DataGridViewSelectionMode.CellSelect;
                //dgvXe.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                return dgvXe;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi InitGridBanCo " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Khởi tạo grid Tình trạng phương tiện
        /// </summary>
        private void InitGridTinhTrangPhuongTien()
        {
            try
            {
                dgvTinhTrangPhuongTien = new MyDgv()
                {
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToResizeRows = false,
                    AllowUserToResizeColumns = false,
                    Dock = DockStyle.Fill,
                    RowHeadersVisible = false,
                    MultiSelect = false,
                    SelectionMode = DataGridViewSelectionMode.CellSelect
                };

                dicGara = new DMGara().GetListAll().ToDictionary(t => t.ID, t => t);
                dicGara_ColumnIndex = new Dictionary<int, int>();
                foreach (var gara in dicGara.Values)
                {
                    dicGara_ColumnIndex[gara.ID] = dgvTinhTrangPhuongTien.Columns.Add(string.Format("col{0}", gara.VietTat), gara.VietTat, gara.Name);
                }

                dgvTinhTrangPhuongTien.Columns.Add("colChua", "P", "Chưa báo điểm đỗ");
                dgvTinhTrangPhuongTien.Columns.Add("colDon", "Đ", "Đi đón khách");
                dgvTinhTrangPhuongTien.Columns.Add("colCo", "C", "Có khách");
                dgvTinhTrangPhuongTien.Columns.Add("colTuyen", "T", "Đi tuyến");
                dgvTinhTrangPhuongTien.Columns.Add("colAn", "A", "Ăn cơm");
                dgvTinhTrangPhuongTien.Columns.Add("colRoi", "R", "Rời xe");
                dgvTinhTrangPhuongTien.Columns.Add("colTH", "H", "Mất tín hiệu");
                dgvTinhTrangPhuongTien.Columns.Add("colMat", "M", "Mất liên lạc");
                dgvTinhTrangPhuongTien.Columns.Add("colHong", "S", "Báo hỏng, sự cố");

                dgvTinhTrangPhuongTien.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dgvTinhTrangPhuongTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (IsBanCo)
                    dgvTinhTrangPhuongTien.DefaultCellStyle.Font = new Font(new FontFamily("Tahoma"), cellFontSize - 2F, FontStyle.Bold);
                else
                    dgvTinhTrangPhuongTien.DefaultCellStyle.Font = new Font(new FontFamily("Tahoma"), cellFontSize, FontStyle.Bold);
                dgvTinhTrangPhuongTien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTinhTrangPhuongTien.Margin = new System.Windows.Forms.Padding(0);
                dgvTinhTrangPhuongTien.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0);
                //dgvTinhTrangPhuongTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvTinhTrangPhuongTien.MouseDoubleClick += dgvTinhTrangPhuongTien_MouseDoubleClick;
                dgvTinhTrangPhuongTien.RowsAdded += (sender1, e1) => { Resize2LastDgv(); };
                dgvTinhTrangPhuongTien.RowsRemoved += (sender1, e1) => { Resize2LastDgv(); };
                dgvTinhTrangPhuongTien.MouseClick += dgv_MouseClick;

                dgvTinhTrangPhuongTien.Rows.Add();
                dgvTinhTrangPhuongTien.Rows[0].DefaultCellStyle.BackColor = Color.Silver;
                if (IsBanCo)
                    dgvTinhTrangPhuongTien.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F);
                else
                    dgvTinhTrangPhuongTien.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F);
                dgvTinhTrangPhuongTien.Rows[0].Height = 15;
                dgvTinhTrangPhuongTien.RowTemplate.Height = HeighCell;
                // Set cell in first row to zero
                for (int j = 0; j < dgvTinhTrangPhuongTien.Columns.Count; j++)
                {
                    dgvTinhTrangPhuongTien.Rows[0].Cells[j].Value = 0;
                }

                dgvTinhTrangPhuongTien.CellBeginEdit += (sender1, e1) => { e1.Cancel = true; };

                for (int j = 0; j < dgvTinhTrangPhuongTien.Columns.Count; j++)
                {
                    dgvTinhTrangPhuongTien.Columns[j].Width = dgvTinhTrangPhuongTienWidth;
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi InitGridTinhTrangPhuongTien " + ex.Message);
            }
        }

        /// <summary>
        /// Khởi tạo grid cảnh báo
        /// </summary>
        private void InitGridCanhBao()
        {
            try
            {
                dgvCanhBaoXe = new MyDgv()
                {
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToResizeRows = false,
                    AllowUserToResizeColumns = false,
                    Dock = DockStyle.Fill,
                    RowHeadersVisible = false,
                    SelectionMode = DataGridViewSelectionMode.CellSelect

                };
                dgvCanhBaoXe.AllowUserToOrderColumns = false;

                dgvCanhBaoXe.Columns.Add("colCCMH", "K", "Rời Gara ko báo");// Chưa mở hàng
                dgvCanhBaoXe.Columns.Add("colCChua", "T", "KD tràn ca (qua 24 tiếng)"); // 
                dgvCanhBaoXe.Columns.Add("colCK", "C", "Có khách không báo về T.tâm"); // CÓ khách không báo về trung tâm
                dgvCanhBaoXe.Columns.Add("colCDi", "Đ", "Trả xong ko báo Điểm Đỗ"); // Di chuyển không có lệnh của tâm
                dgvCanhBaoXe.Columns.Add("colCDo", "D", "Di chuyển ko có lệnh của T.Tâm"); // Xe đỗ quá lâu so với cấu hình
                dgvCanhBaoXe.Columns.Add("colCDon", "L", "Đỗ lâu ko được điều");  // Đón mà ko báo về tâm. D
                dgvCanhBaoXe.Columns.Add("colCToi", "H", "Lái xe báo");
                dgvCanhBaoXe.Columns.Add("colCBao", "A", "Ăn ca quá giờ");
                dgvCanhBaoXe.Columns.Add("colCSai", "R", "Rời xe quá giờ đăng ký"); // 
                dgvCanhBaoXe.Columns.Add("colCAn", "X", "SmartPhone cách xe quá (100m)"); // Ăn cơm quá giờ           

                dgvCanhBaoXe.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dgvCanhBaoXe.CellBeginEdit += (sender1, e1) => { e1.Cancel = true; };
                dgvCanhBaoXe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCanhBaoXe.DefaultCellStyle.Font = new Font(new FontFamily("Tahoma"), cellFontSize, FontStyle.Bold);                                
                dgvCanhBaoXe.Margin = new System.Windows.Forms.Padding(0);
                dgvCanhBaoXe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCanhBaoXe.MouseDoubleClick += dgvTinhTrangPhuongTien_MouseDoubleClick;
                dgvCanhBaoXe.RowsAdded += (sender1, e1) => { Resize2LastDgv(); };
                dgvCanhBaoXe.RowsRemoved += (sender1, e1) => { Resize2LastDgv(); };
                dgvCanhBaoXe.MouseClick += dgv_MouseClick;
                dgvCanhBaoXe.Rows.Add();
                dgvCanhBaoXe.Rows[0].DefaultCellStyle.BackColor = Color.Silver;
                if(IsBanCo)
                    dgvCanhBaoXe.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F);
                else dgvCanhBaoXe.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F);
                dgvCanhBaoXe.Rows[0].Height = 15;
                dgvCanhBaoXe.RowTemplate.Height = HeighCell;
                for (int j = 0; j < dgvCanhBaoXe.Columns.Count; j++)
                {
                    dgvCanhBaoXe.Rows[0].Cells[j].Value = 0;
                }

                for (int j = 0; j < dgvCanhBaoXe.Columns.Count; j++)
                    dgvCanhBaoXe.Columns[j].Width = dgvTinhTrangPhuongTienWidth;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi InitGridCanhBao " + ex.Message);
            }
        }

        private void ResetListGaraRowsCount()
        {
            for (var i = 0; i < listGaraRowsCount.Count; i++)
                listGaraRowsCount[i] = 1;
        }

        #endregion

        #region Timer Update

        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            G_TimerStep++;
            if (G_TimerStep >= 2 && !bwBanCo.IsBusy)
            {
                bwBanCo.RunWorkerAsync();
                G_TimerStep = 0;
            }
            if (G_TimerStep >= 2 && bwBanCo.IsBusy)
            {
                LogError.WriteLogErrorForDebug("bwSyncXeOnline_DoWork Busy");
            }
        }

        private void bwBanCo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ProcessBanCo();
            }
            catch( Exception ex)
            {
                LogError.WriteLogError("bwSyncXeOnline_DoWork", ex);
            }
        }

        private void ProcessBanCo()
        {
            try
            {
                InitData();
                //Khởi tạo ô tình trạng phương tiện
                var listTinhTrangPhuongTienRowsCount = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                //Add thêm gara vào ô tình trạng phương tiện
                foreach (var gara in dicGara_ColumnIndex)
                {
                    listTinhTrangPhuongTienRowsCount.Add(1);
                }
                var listCanhBaoXeRowsCount = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

                ResetListGaraRowsCount();
                var dicVungRowsCount = new Dictionary<int, List<int>>();
                //var listDefault = new List<int>();
                //for (var i = 0; i < 4; i++) listDefault.Add(0);
                foreach (var vung in dicVung.Values)
                {
                    dicVungRowsCount.Add(vung.VungGPSID, new List<int>() { 0, 0, 0, 0 });
                }


                #region Xe xin diem do

                // Tìm trong vùng nào thì có những xe nào hoạt động
                dicVungId_IDGPS.GroupJoin(dicXeHoatDong, vk => vk.Key, xhd => xhd.Value.DiemDo, (vk, xhds) =>
                {
                    var dgvXe = dicDataGrid[vk.Value];
                    int NodeOfDiemDo = 0;
                    int IDDiemDoGPS = vk.Value;
                    string soHieuXe = "";
                    // Sắp xếp lại theo Loại xe trước, sau đó sắp xếp thời gian
                    xhds.OrderBy(xhd => xhd.Value.Sort_BanCo).ThenBy(xhd => xhd.Value.Node).ThenBy(xhd => xhd.Value.ThoiDiemBao).Select((xhd, stt) =>
                    {
                        //Check xem xe này có thuộc xe nhận điểm không
                        bool isXeNhan = listXeNhan != null
                                        && (listXeNhan.Contains(xhd.Value.SoHieuXe)
                                            || dicXeNhan_Online.ContainsKey(xhd.Value.SoHieuXe)
                                        );
                        int col = isXeNhan ? 2 : 0;

                        // Tìm dòng cần hiển thị số hiệu xe
                        // Nếu số dòng vượt quá hiện tại thì tạo thêm dòng mới
                        var i = dicVungRowsCount[vk.Value][col];
                        if (i >= dgvXe.Rows.Count)
                        {
                            this.Invoke( new MethodInvoker(delegate
                            {
                                i = dgvXe.Rows.Add();
                            }));
                        }
                        //if (xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.XeBaoTraKhach && isXeNhan)
                        //{
                        //    col = 3;
                        //    var row = dicVungRowsCount[vk.Value][col];
                        //    AddToDataGrid(dgvXe, ref row, col, xhd.Value.SoHieuXe
                        //        , StatusToForeColor(Enum_ColorOfVehicleStatus.XeXinRaNgoai)
                        //        , StatusToBackColor(Enum_ColorOfVehicleStatus.XeXinRaNgoai), cellFontSize, false);
                        //    dicVungRowsCount[vk.Value][col] = row;
                        //}
                        //else 
                        if (isXeNhan)
                        {
                            #region Cột 2 có nhận xe nhận
                            var row = dicVungRowsCount[vk.Value][col];

                            Enum_ColorOfVehicleStatus status = dicXeNhan_Online == null || dicXeNhan_Online.Count == 0 || !dicXeNhan_Online.ContainsKey(xhd.Value.SoHieuXe) ?
                                                                Enum_ColorOfVehicleStatus.XeMTH : GetTrangThaiXe(dicXeNhan_Online[xhd.Value.SoHieuXe], isXeNhan);
                            this.Invoke(new MethodInvoker(delegate
                            {
                                AddToDataGrid(dgvXe, ref row, col, xhd.Value.SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize, false);
                            }));

                            dicVungRowsCount[vk.Value][col] = row;

                            #endregion
                        }
                        else
                        {
                            #region Cột 3 xe xin điểm đỗ
                            this.Invoke(new MethodInvoker(delegate
                            {
                                if ((xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoNghi_RoiXe && xhd.Value.IsHidden == false)
                                    || xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.MatLienLac
                                    || xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoDiemDo
                                    || (xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoRaKinhDoanh && xhd.Value.DiemDo != null && xhd.Value.DiemDo.Value > 0))
                                {
                                    dgvXe.Rows[i].Cells[col].Value = xhd.Value.SoHieuXe;

                                    dicVungRowsCount[vk.Value][col] = i + 1;
                                }
                            }));

                            #region Send Node to Mobile
                            if (IsTongDai)
                            {
                                NodeOfDiemDo++;
                                soHieuXe = xhd.Value.SoHieuXe;
                                if (dicXe_DiemDo_Node.ContainsKey(soHieuXe))
                                {
                                    DiemDo_Node itemDiemDo_Node = dicXe_DiemDo_Node[soHieuXe];
                                    if (itemDiemDo_Node.DiemDo != IDDiemDoGPS)
                                    {
                                        itemDiemDo_Node.DiemDo = IDDiemDoGPS;
                                        itemDiemDo_Node.Node = NodeOfDiemDo;
                                        itemDiemDo_Node.Time = xhd.Value.ThoiDiemBao;
                                        if (!IsInit)
                                            TaxiApplication.ServiceEnVang.EnVangProcess.SendNewLandMarkInfo(soHieuXe, IDDiemDoGPS, NodeOfDiemDo);
                                    }
                                    else
                                    {
                                        if ((xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoNghi_RoiXe && xhd.Value.IsHidden == false)
                                            || xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.MatLienLac
                                            || xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.MatTinHieu)
                                        {
                                            dicXe_DiemDo_Node.Remove(soHieuXe);
                                        }
                                        else if (itemDiemDo_Node.Node != NodeOfDiemDo || itemDiemDo_Node.Time != xhd.Value.ThoiDiemBao)
                                        {
                                            itemDiemDo_Node.Node = NodeOfDiemDo;
                                            itemDiemDo_Node.Time = xhd.Value.ThoiDiemBao;
                                            if (!IsInit)
                                                TaxiApplication.ServiceEnVang.EnVangProcess.SendNewLandMarkInfo(soHieuXe, IDDiemDoGPS, NodeOfDiemDo);
                                        }
                                    }
                                    dicXe_DiemDo_Node[soHieuXe] = itemDiemDo_Node;
                                }
                                else
                                {
                                    if ((xhd.Value.TrangThaiLaiXeBao != (int)Enum_TrangThaiLaiXeBao.BaoNghi_RoiXe) && xhd.Value.TrangThaiLaiXeBao != (int)Enum_TrangThaiLaiXeBao.MatLienLac)
                                    {
                                        dicXe_DiemDo_Node.Add(soHieuXe, new DiemDo_Node() { DiemDo = IDDiemDoGPS, Node = NodeOfDiemDo, Time = xhd.Value.ThoiDiemBao });

                                        if (!IsInit)
                                            TaxiApplication.ServiceEnVang.EnVangProcess.SendNewLandMarkInfo(soHieuXe, IDDiemDoGPS, NodeOfDiemDo);
                                    }
                                }
                            }
                            #endregion

                            //Nếu xe xin ra ngoài mà không bật cờ ẩn trên bàn cờ thì hiển thị màu khác để nhận biết
                            if (xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoNghi_RoiXe && xhd.Value.IsHidden == false)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    dgvXe.Rows[i].Cells[col].Style.ForeColor = StatusToForeColor(Enum_ColorOfVehicleStatus.XeXinRaNgoai);
                                    dgvXe.Rows[i].Cells[col].Style.BackColor = StatusToBackColor(Enum_ColorOfVehicleStatus.XeXinRaNgoai);
                                }));
                            }
                            else if (xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.MatLienLac)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    dgvXe.Rows[i].Cells[col].Style.ForeColor = StatusToForeColor(Enum_ColorOfVehicleStatus.XeMatLienLac);
                                    dgvXe.Rows[i].Cells[col].Style.BackColor = StatusToBackColor(Enum_ColorOfVehicleStatus.XeMatLienLac);
                                }));
                            }
                            else
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    dgvXe.Rows[i].Cells[col].Style.ForeColor = StatusToForeColor(Enum_ColorOfVehicleStatus.XinDiemDo);
                                    dgvXe.Rows[i].Cells[col].Style.BackColor = StatusToBackColor(Enum_ColorOfVehicleStatus.XinDiemDo);
                                }));                                
                            }
                            //Nếu không thuộc các trường hợp đặc biệt trên thì hiển thị xe theo cấu hình loại xe
                            if (dicLoaiXe_Style.ContainsKey(xhd.Value.SoHieuXe))
                            {
                                Style_LoaiXe objStype = dicLoaiXe_Style[xhd.Value.SoHieuXe];
                                if (IsBanCo)
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        dgvXe.Rows[i].Cells[col].Style.Font = new Font(objStype.FontChu.FontFamily, this.cellFontSize, objStype.FontChu.Style);
                                    }));
                                }
                                else
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        dgvXe.Rows[i].Cells[col].Style.Font = objStype.FontChu;
                                    }));
                                }
                                //Riêng các trạng thái rời xe, mất liên lạc đều có màu riêng để phân biệt
                                if (col == 2 &&
                                    !(xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoNghi_RoiXe && xhd.Value.IsHidden == false) &&
                                    !(xhd.Value.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.MatLienLac)
                                )
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        dgvXe.Rows[i].Cells[col].Style.BackColor = objStype.BackColor;
                                        dgvXe.Rows[i].Cells[col].Style.ForeColor = objStype.ForeColor;
                                    }));
                                }
                            }

                            #endregion
                            i++;
                        }
                        return stt;
                    }).Count();

                    return false;
                }).Count();
                #endregion

                #region Xe xin điểm trả
                foreach (var item in dicXeHoatDong_BaoDiemTra.Values)
                {
                    if (item.DiemDo == null) continue;
                    int idDiemTraKhach = item.DiemDo.Value;
                    if (dicVungId_IDGPS.ContainsKey(idDiemTraKhach))
                    {
                        int idDiemTraKhach_GPS = dicVungId_IDGPS[idDiemTraKhach];
                        int col = 3;
                        var dgvXe = dicDataGrid[idDiemTraKhach_GPS];
                        var row = dicVungRowsCount[idDiemTraKhach_GPS][col];
                        this.Invoke(new MethodInvoker(delegate
                        {
                            AddToDataGrid(dgvXe, ref row, col, item.SoHieuXe
                                , StatusToForeColor(Enum_ColorOfVehicleStatus.XeXinRaNgoai)
                                , StatusToBackColor(Enum_ColorOfVehicleStatus.XeXinRaNgoai), cellFontSize, false);
                        }));
                        dicVungRowsCount[idDiemTraKhach_GPS][col] = row;
                    }
                }
                #endregion

                #region Xe online
                if (listXeOnline != null && listXeOnline.Count() > 0)
                {
                    dicXeNhan_Online.Clear();
                    foreach (var xe in listXeOnline)
                    {
                        UpdateSpeedLessThan3Counter(xe);
                        try
                        {
                            if (listXeNhan != null && listXeNhan.Contains(xe.SoHieuXe))
                            {
                                if (dicXeNhan_Online == null || !dicXeNhan_Online.ContainsKey(xe.SoHieuXe))
                                    dicXeNhan_Online.Add(xe.SoHieuXe, xe);
                                else
                                    dicXeNhan_Online[xe.SoHieuXe] = xe;
                            }
                            Enum_ColorOfVehicleStatus status = GetTrangThaiXe(xe, false);

                            //Check xe xe này có nằm ngoài điểm đỗ ko
                            bool isNgoaiVung = !dicDataGrid.ContainsKey(xe.VungID);

                            if (!isNgoaiVung)
                            {
                                #region Cột 2 : hiển thị xe online
                                var dgvXe = dicDataGrid[xe.VungID];
                                //Nếu là xe nhận thì add vào cột 1, ngược lại cột 0
                                int col = 1;
                                var row = dicVungRowsCount[xe.VungID][col];
                                //if(dicXeKhongHoatDong.ContainsKey(xe.SoHieuXe))
                                //    AddToDataGrid(dgvXe, ref row, col, xe.SoHieuXe, StatusToForeColor(status), StatusToBackColor(Enum_ColorOfVehicleStatus.XeBaoNghi));
                                //else
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    AddToDataGrid(dgvXe, ref row, col, xe.SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize, false);
                                }));
                                dicVungRowsCount[xe.VungID][col] = row;

                                #endregion
                            }
                            this.Invoke(new MethodInvoker(delegate
                            {
                                AddToGridTinhTrangPhuongTien(status, xe, listTinhTrangPhuongTienRowsCount, xe.SoHieuXe, false, isNgoaiVung);
                                AddToGridCanhBaoXe(status, xe, listCanhBaoXeRowsCount, xe.SoHieuXe, false);
                                AddToGaraCol(status, listTinhTrangPhuongTienRowsCount, xe.SoHieuXe);
                            }));
                        }
                        catch (Exception ex)
                        {
                            new MessageBox.MessageBoxBA().Show("Lỗi timer_Tick listXeOnline " + ex.Message);
                            bwBanCo.CancelAsync();
                        }
                    }
                }
                else
                {
                    foreach (var item in CommonBL.ListXe)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            //trường hợp không có internet hoặc ko bật đồng bộ online
                            AddToGridTinhTrangPhuongTien(Enum_ColorOfVehicleStatus.KhongKhach, null, listTinhTrangPhuongTienRowsCount, item.PK_SoHieuXe, false, false);
                            AddToGridCanhBaoXe(Enum_ColorOfVehicleStatus.KhongKhach, null, listCanhBaoXeRowsCount, item.PK_SoHieuXe, false);
                            AddToGaraCol(Enum_ColorOfVehicleStatus.KhongKhach, listTinhTrangPhuongTienRowsCount, item.PK_SoHieuXe);
                        }));
                    }
                }
                #endregion

                IsInit = false;
                try
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        //Cập nhật lại số đếm trên tiêu đề của Vùng
                        DeleteVungEmptyRows(dicVungRowsCount);
                    }));
                    this.Invoke(new MethodInvoker(delegate
                    {
                        ClearDgvSelection();
                    }));
                    this.Invoke(new MethodInvoker(delegate
                    {
                        DeleteTinhTrangPhuongTienEmptyRows(listTinhTrangPhuongTienRowsCount);
                    }));
                    this.Invoke(new MethodInvoker(delegate
                    {
                        DeleteCanhCaoXeEmptyRows(listCanhBaoXeRowsCount);
                    }));
                }
                catch (Exception ex)
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi Timer_Tick DeleteVungEmptyRows" + ex.Message);
                    bwBanCo.CancelAsync();
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi timer_Tick Control ban co" + ex.Message);
                bwBanCo.CancelAsync();
            }
        }

        /// <summary>
        /// 1 giay lay lai du lieu moi mot lan
        /// Xe online
        /// Xe dang dieu
        /// Xe bao (giam sat xe)
        /// Xe di tuyen
        /// </summary>
        private void InitData()
        {
            try
            {
                #region Get Xe online
                if (ThongTinCauHinh.GPS_TrangThai)
                {
                    try
                    {
                        if (Global.HasGPS)
                        {
                            listXeOnline = client.GetListObjectXeOnline(Taxi.Business.ThongTinCauHinh.GPS_MaCungXN);
                            UpdateListXeOnline(listXeOnline);
                        }
                    }
                    catch (Exception ex)
                    {
                        Timer_BanCo.Stop();
                        if (new MessageBox.MessageBoxBA().Show("Không thể kết nối đến dịch vụ đồng bộ xe GPS. Bạn có muốn thử lại không?", "Lỗi", MessageBox.MessageBoxButtonsBA.RetryCancel, MessageBox.MessageBoxIconBA.Error) == MessageBox.MessageBoxResult.Retry)
                        {
                            client = new SyncServiceOnlineClient();
                        }
                        else
                        {
                            Global.HasGPS = false;
                            Timer_BanCo.Start();
                            //Application.Exit();
                        }
                        Timer_BanCo.Start();
                    }
                }
                #endregion

                #region Get Xe điều
                List<TaxiOperation_Truck> lstTruck = null;
                if (Global.TaxiOperation_Module == TaxiOperation_Module.DieuXeTai)
                    lstTruck = new TaxiOperation_Truck().GetAllXeNhan_TaxiTai();
                else if (Global.TaxiOperation_Module == TaxiOperation_Module.DieuXeTaxi)
                    lstTruck = new TaxiOperation_Truck().GetAllXeNhanDon_TaxiKhach();
                listXeNhan.Clear();
                if (lstTruck != null && lstTruck.Count > 0)
                {
                    listXeNhan = String.Join(".", lstTruck.Select(t => t.SoXe)).Split('.').ToList();
                }
                #endregion

                const int thoigian = 30;
                #region Get Giám sát xe
                List_GiamSatXe_HoatDong = new GiamSatXe_HoatDong().GetAllXeHoatDong_V2();
                dicXeHoatDong_BaoDiemTra = new GiamSatXe_HoatDong().GetAllXeHoatDong_BaoDiemTra_V2().ToDictionary(T=>T.SoHieuXe,T=>T);

                dicXeHoatDong = new Dictionary<string, GiamSatXe_HoatDong>();
                foreach (var item in List_GiamSatXe_HoatDong)
                {
                    if (!dicXeHoatDong.ContainsKey(item.SoHieuXe))
                    {
                        if ((item.SoPhutNghi <= thoigian
                            && item.IsHoatDong == '0'
                            && item.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoNghi_RoiXe
                            && item.IsHidden == false )
                            || item.IsHoatDong == '0' && item.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.MatLienLac
                            || item.IsHoatDong == '1' )
                        {
                            dicXeHoatDong.Add(item.SoHieuXe, item);
                        }
                    }
                }

                dicXeKhongHoatDong = List_GiamSatXe_HoatDong.Where(p => p.IsHoatDong == '0' && ((p.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoNghi_AnCa) ||
                                                                                                (p.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoVe))).ToDictionary(t => t.SoHieuXe, t => t);
                listGiamSatXe = new GiamSatXe_LienLac().GetListAllXeChuaVe();
                dicGiamSat_AnCa.Clear();
                dicGiamSat_MatLL.Clear();
                dicGiamSat_MatTH.Clear();
                dicGiamSat_RoiXe.Clear();
                dicGiamSat_BaoHong.Clear();
                dicGiamSat_KhaiThac.Clear();
                dicGiamSat_RaKinhDoanh.Clear();
                foreach (var gsx in listGiamSatXe)
                {
                    if (gsx.TrangThaiLaiXeBao == statusAnCa && !dicGiamSat_AnCa.ContainsKey(gsx.SoHieuXe.Value))
                        dicGiamSat_AnCa.Add(gsx.SoHieuXe.Value, gsx);
                    if (gsx.TrangThaiLaiXeBao == statusMatLL && !dicGiamSat_MatLL.ContainsKey(gsx.SoHieuXe.Value))
                        dicGiamSat_MatLL.Add(gsx.SoHieuXe.Value, gsx);
                    if (gsx.TrangThaiLaiXeBao == statusMatTH && !dicGiamSat_MatTH.ContainsKey(gsx.SoHieuXe.Value))
                        dicGiamSat_MatTH.Add(gsx.SoHieuXe.Value, gsx);
                    if (gsx.TrangThaiLaiXeBao == statusRoiXe && !dicGiamSat_RoiXe.ContainsKey(gsx.SoHieuXe.Value))
                        dicGiamSat_RoiXe.Add(gsx.SoHieuXe.Value, gsx); 
                    if (gsx.TrangThaiLaiXeBao == statusBaoHong && !dicGiamSat_BaoHong.ContainsKey(gsx.SoHieuXe.Value))
                        dicGiamSat_BaoHong.Add(gsx.SoHieuXe.Value, gsx);
                    if (gsx.TrangThaiLaiXeBao == statusKhaiThac && !dicGiamSat_KhaiThac.ContainsKey(gsx.SoHieuXe.Value))
                        dicGiamSat_KhaiThac.Add(gsx.SoHieuXe.Value, gsx);
                    if (gsx.TrangThaiLaiXeBao == statusRaKinhDoanh && !dicGiamSat_RaKinhDoanh.ContainsKey(gsx.SoHieuXe.Value))
                        dicGiamSat_RaKinhDoanh.Add(gsx.SoHieuXe.Value, gsx);
                }

                #endregion

                #region Get xe đi tuyến - xe nhan trong cuoc goi thue bao tuyen

                List<TaxiOperation_Truck> lstTruckTuyen = null;
                if (Global.TaxiOperation_Module == TaxiOperation_Module.DieuXeTai)
                    lstTruckTuyen = new TaxiOperation_Truck().GetAllXeNhan_ThueBaoTuyen_TaxiTai();

                if (lstTruckTuyen != null)
                {
                    listXeDiTuyen = String.Join(".", lstTruckTuyen.Select(t => t.SoXe)).Split('.').ToList();
                }
                #endregion

                #region Xe Chưa mở hàng
                //if (Global.TaxiOperation_Module == TaxiOperation_Module.DieuXeTai || Global.TaxiOperation_Module == TaxiOperation_Module.Luong)
                //{
                //    if (Global.HasGPS)
                //        lsXeChuaMoHang = WCFService_Common.Truck_GetDanhSachXeChuaMoHang();
                //    else
                //        lsXeChuaMoHang = BanCo_GiamSatXe.Inst.GetXeChuaMoHang().Rows.OfType<DataRow>().AsEnumerable().Select(p => p["SoHieuXe"].ToString()).ToArray();
                //}
                #endregion
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi InitData " + ex.Message);
                Global.HasGPS = false;
            }
        }

        /// <summary>
        /// Xóa các cùng không có dữ liệu và cập nhật lại số đếm trên tiêu đề
        /// </summary>
        /// <param name="dicVungRowsCount"></param>
        private void DeleteVungEmptyRows(Dictionary<int, List<int>> dicVungRowsCount)
        {
            foreach (var vung in dicVungRowsCount)
            {
                var dgv = dicDataGrid[vung.Key];
                //Tạm thời fix riêng cho Lạng Sơn
                if (ThongTinCauHinh.GPS_MaCungXN == "771")
                {
                    dicGroupControl[vung.Key].Text = string.Format("{0} ({1})", dicVung[vung.Key].Ten, vung.Value[2] );         //+ vung.Value[2]           
                    dicGroupControl[vung.Key].Tag = vung.Value[2];
                }
                else
                {
                    dicGroupControl[vung.Key].Text = string.Format("{0} ({1})", dicVung[vung.Key].Ten, vung.Value[0]);
                    dicGroupControl[vung.Key].Tag = vung.Value[0];
                }
                int maxRows = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (maxRows < vung.Value[i]) maxRows = vung.Value[i];
                }
                while (dgv.Rows.Count > maxRows)
                    dgv.Rows.RemoveAt(dgv.Rows.Count - 1);
                for (int i = 0; i < 4; i++)
                {
                    for (; vung.Value[i] < maxRows; vung.Value[i]++)
                    {
                        if (vung.Value[i] < dgv.RowCount)
                        {
                            dgv.Rows[vung.Value[i]].Cells[i].Value = null;
                            dgv.Rows[vung.Value[i]].Cells[i].Style.BackColor = Color.White;
                        }
                        
                    }
                }
            }
        }

        /// <summary>
        /// add xe vào lưới điễm đỗ vùng điều hành
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="rowIndex">Dòng hiển thị</param>
        /// <param name="colIndex">Cột hiển thị</param>
        /// <param name="val">Số xe</param>
        /// <param name="foreColor">màu chữ</param>
        /// <param name="backColor">màu nền</param>
        private void AddToDataGrid(MyDgv dgv, ref int rowIndex, int colIndex, string val, Color foreColor, Color backColor, float Fonsize, bool isFixFontSize)
        {
            if (rowIndex >= dgv.Rows.Count)
                rowIndex = dgv.Rows.Add();
            
            dgv.Rows[rowIndex].Cells[colIndex].Value = val;
            //if (colIndex < 2)
            {
                dgv.Rows[rowIndex].Cells[colIndex].Style.ForeColor = foreColor;
                dgv.Rows[rowIndex].Cells[colIndex].Style.BackColor = backColor;
            }
            //if(dicXe_Font.ContainsKey(val))
            //    dgv.Rows[rowIndex].Cells[colIndex].Style.Font = dicXe_Font[val];
            if (dicLoaiXe_Style.ContainsKey(val))
            {
                Style_LoaiXe objStype = dicLoaiXe_Style[val];

                if (IsBanCo)
                {
                    dgv.Rows[rowIndex].Cells[colIndex].Style.Font = new Font(objStype.FontChu.FontFamily, Fonsize, objStype.FontChu.Style);
                }
                else
                {
                    dgv.Rows[rowIndex].Cells[colIndex].Style.Font = objStype.FontChu;
                }
                if (isFixFontSize)
                {
                    Font fontFix = dgv.Rows[rowIndex].Cells[colIndex].Style.Font;
                    dgv.Rows[rowIndex].Cells[colIndex].Style.Font = new Font(fontFix.FontFamily, 8F, fontFix.Style);
                }
                //if (colIndex == 2)
                //{
                //    dgv.Rows[rowIndex].Cells[colIndex].Style.BackColor = objStype.BackColor;
                //    dgv.Rows[rowIndex].Cells[colIndex].Style.ForeColor = objStype.ForeColor;
                //}
            }
            rowIndex++;
        }
        
        #region Tình trạng phương tiện

        private void AddToGaraCol(Enum_ColorOfVehicleStatus status, List<int> listTinhTrangPhuongTienRowsCount, string SoHieuXe)
        {
            try
            {
                if (!dicGiamSat_RaKinhDoanh.ContainsKey(SoHieuXe) && dicXe_Gara.ContainsKey(SoHieuXe))
                {
                    int colIndex = dicGara_ColumnIndex[dicXe_Gara[SoHieuXe]];
                    int rowIndex = listTinhTrangPhuongTienRowsCount[colIndex];
                    AddToDataGrid(dgvTinhTrangPhuongTien, ref rowIndex, colIndex, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                    listTinhTrangPhuongTienRowsCount[colIndex] = rowIndex;
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi timer_Tick AddToGaraCol " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm dữ liệu vào lưới tình trạng phương tiện
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="listTinhTrangPhuongTienRowsCount">The list tinh trang phuong tien rows count.</param>
        /// <param name="SoHieuXe">The so hieu xe.</param>
        /// <param name="color">The color.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/26/2015   created
        /// </Modified>
        private void AddDataTinhTrangPhuongTien(int index, List<int> listTinhTrangPhuongTienRowsCount, string SoHieuXe, Color foreColor, Color backColor)
        {
            var row = listTinhTrangPhuongTienRowsCount[index];
            AddToDataGrid(dgvTinhTrangPhuongTien, ref row, index, SoHieuXe, foreColor, backColor, cellFontSize - 2F, true);
            listTinhTrangPhuongTienRowsCount[index] = row;
        }

        /// <summary>
        /// Thêm vào lưới tình trạng phương tiện
        /// </summary>
        /// <param name="status"></param>
        /// <param name="xe"></param>
        /// <param name="listTinhTrangPhuongTienRowsCount"></param>
        /// <param name="SoHieuXe"></param>
        /// <param name="isXeNhan"></param>
        /// <param name="isNgoaiVung"></param>
        private void AddToGridTinhTrangPhuongTien(Enum_ColorOfVehicleStatus status, T_XeOnline xe, List<int> listTinhTrangPhuongTienRowsCount, string SoHieuXe, bool isXeNhan = false, bool isNgoaiVung = false)
        {
            try
            {
                int i = dicGara_ColumnIndex.Count;
                Color defaultForeColor = StatusToForeColor(status);
                Color defaultBackColor = StatusToBackColor(status);
                                
                ////KD
                //if (status == Enum_ColorOfVehicleStatus.KhongKhach || status == Enum_ColorOfVehicleStatus.TatMay)
                //{
                //    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, defaultForeColor, defaultBackColor);
                //}
                //i++;
                bool baoRaKinhDoanh = dicGiamSat_RaKinhDoanh.ContainsKey(SoHieuXe);

                //Chưa : check Xe KD chưa có điểm đỗ
                if (baoRaKinhDoanh && dicXeHoatDong.ContainsKey(SoHieuXe) && (!dicXeHoatDong[SoHieuXe].DiemDo.HasValue || dicXeHoatDong[SoHieuXe].DiemDo == null || dicXeHoatDong[SoHieuXe].DiemDo <= 0))
                {
                    //var row = listTinhTrangPhuongTienRowsCount[i];
                    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, defaultForeColor, defaultBackColor);
                }
                i++;
                //Đ
                if (status == Enum_ColorOfVehicleStatus.NhanDonKhach_TatMay || status == Enum_ColorOfVehicleStatus.NhanDonKhach_DangDiChuyen)
                {
                    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, defaultForeColor, defaultBackColor);
                }
                i++;

                //C
                if (status == Enum_ColorOfVehicleStatus.CoKhach || status == Enum_ColorOfVehicleStatus.NhanDonKhach_DangCoKhach)
                {
                    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, defaultForeColor, defaultBackColor);
                }
                i++;

                //Tuyen : Xe thuộc danh sách xe đi tuyến thì add vào ô Tuyến
                if (listXeDiTuyen != null && listXeDiTuyen.Contains(SoHieuXe))
                {
                    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, defaultForeColor, defaultBackColor);
                }
                i++;

                //An
                if (dicGiamSat_AnCa.ContainsKey(SoHieuXe))
                {
                    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, defaultForeColor, defaultBackColor);
                }
                i++;

                //Ra
                if (dicGiamSat_RoiXe.ContainsKey(SoHieuXe))
                {
                    //Nếu bật cờ (IsHidden = true) thì hiển thị màu theo cấu hình.
                    status = dicGiamSat_RoiXe[SoHieuXe].IsHidden == true ? Enum_ColorOfVehicleStatus.XeXinRaBatCo : status;
                    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status));
                }
                i++;

                //Mat tín hiệu
                if (dicGiamSat_MatTH.ContainsKey(SoHieuXe))
                {
                    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status));
                }
                i++;

                //Mat liên lạc
                if (dicGiamSat_MatLL.ContainsKey(SoHieuXe))
                {
                    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status));
                }
                i++;


                //Xe báo hỏng, sự cố
                if (dicGiamSat_BaoHong.ContainsKey(SoHieuXe))
                {
                    AddDataTinhTrangPhuongTien(i, listTinhTrangPhuongTienRowsCount, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status));
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi AddToGridTinhTrangPhuongTien " + ex.Message);
            }
        }

        private void DeleteTinhTrangPhuongTienEmptyRows(List<int> listTinhTrangPhuongTienRowsCount)
        {
            var maxRowTinhTrangPhuongTien = 0;
            for (var i = 0; i < listTinhTrangPhuongTienRowsCount.Count; i++)
            {
                if (maxRowTinhTrangPhuongTien < listTinhTrangPhuongTienRowsCount[i])
                {
                    maxRowTinhTrangPhuongTien = listTinhTrangPhuongTienRowsCount[i];
                }
                dgvTinhTrangPhuongTien.Rows[0].Cells[i].Value = listTinhTrangPhuongTienRowsCount[i] - 1;
            }
            while (dgvTinhTrangPhuongTien.Rows.Count > maxRowTinhTrangPhuongTien)
            {
                dgvTinhTrangPhuongTien.Rows.RemoveAt(dgvTinhTrangPhuongTien.Rows.Count - 1);
            }
            for (var i = 0; i < listTinhTrangPhuongTienRowsCount.Count; i++)
            {
                for (; listTinhTrangPhuongTienRowsCount[i] < maxRowTinhTrangPhuongTien; listTinhTrangPhuongTienRowsCount[i]++)
                {
                    dgvTinhTrangPhuongTien.Rows[listTinhTrangPhuongTienRowsCount[i]].Cells[i].Value = null;
                    dgvTinhTrangPhuongTien.Rows[listTinhTrangPhuongTienRowsCount[i]].Cells[i].Style.BackColor = Color.White;
                }
            }
        }

        #endregion

        #region Cảnh báo xe

        private void AddToGridCanhBaoXe(Enum_ColorOfVehicleStatus status, T_XeOnline xe, List<int> listCanhBaoXeRowsCount, string SoHieuXe, bool isXeNhan = false)
        {
            try
            {
                int i = 0;
                DateTime timeServer = DateTime.Now;
                try
                {
                    if (Global.HasGPS)
                        timeServer = WCFService_Common.GetTimeServer();
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("time server", ex);
                    Global.HasGPS = false;
                }
                bool baoRaKinhDoanh = dicGiamSat_RaKinhDoanh.ContainsKey(SoHieuXe);
                // K : Rời gara không báo
                if (xe != null && ThongTinCauHinh.GPS_TrangThai && !baoRaKinhDoanh && dicXe_Gara.ContainsKey(SoHieuXe))
                {
                    var gara = dicGara[dicXe_Gara[SoHieuXe]];
                    if (gara.KinhDo.HasValue && gara.ViDo.HasValue && gara.BanKinh.HasValue
                        && DistanceAlgorithm.DistanceBetweenPlaces(xe.KinhDo, xe.ViDo, gara.KinhDo.Value, gara.ViDo.Value) * 1000 > gara.BanKinh.Value)
                    {
                        var row = listCanhBaoXeRowsCount[i];
                        AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                        listCanhBaoXeRowsCount[i] = row;
                    }
                }
                i++;
                //T : Check Xe kinh doanh quá giờ (Tràn ca)
                if (baoRaKinhDoanh && dicGiamSat_RaKinhDoanh.ContainsKey(SoHieuXe))
                {
                    var xeGS = dicGiamSat_RaKinhDoanh[SoHieuXe];
                    var sophutnghi = 0;
                    if (!xeGS.SoPhutNghi.IsNull) sophutnghi = xeGS.SoPhutNghi.Value;
                    if ((DateTime.Now - xeGS.ThoiDiemBao.Value).Add(new TimeSpan(0, sophutnghi, 0)).TotalHours > Convert.ToInt32(CommonBL.ConfigsBanCo[Enum_Config_Alert.KDQuaGio].Value))
                    {
                        var row = listCanhBaoXeRowsCount[i];
                        AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                        listCanhBaoXeRowsCount[i] = row;
                    }
                }
                i++;

                //C : Xe có khách không báo về trung tâm
                if (status == Enum_ColorOfVehicleStatus.CoKhach && !listXeNhan.Contains(SoHieuXe))
                {
                    var row = listCanhBaoXeRowsCount[i];
                    AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                    listCanhBaoXeRowsCount[i] = row;
                }
                i++;

                //Đ : Check Xe KD chưa có điểm đỗ
                if (baoRaKinhDoanh && dicXeHoatDong.ContainsKey(SoHieuXe) && (!dicXeHoatDong[SoHieuXe].DiemDo.HasValue || dicXeHoatDong[SoHieuXe].DiemDo == null || dicXeHoatDong[SoHieuXe].DiemDo <= 0))
                {
                    var row = listCanhBaoXeRowsCount[i];
                    AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                    listCanhBaoXeRowsCount[i] = row;
                }
                i++;
                
                // chưa mở hàng
                if (xe != null && lsXeChuaMoHang != null && lsXeChuaMoHang.Any(p => p == xe.SoHieuXe))
                {
                    var row = listCanhBaoXeRowsCount[i];
                    AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                    listCanhBaoXeRowsCount[i] = row;
                }
                i++;

                //L : Đỗ lâu không được điều
                bool xeXinDiemDo = dicXeHoatDong.ContainsKey(SoHieuXe);
                if (xeXinDiemDo)
                {
                    try
                    {

                        GiamSatXe_HoatDong item = dicXeHoatDong[SoHieuXe];
                        if (item.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoDiemDo)
                        {                            
                            TimeSpan span = timeServer - item.ThoiDiemBao;

                            if (span.TotalMinutes > Convert.ToInt32(CommonBL.ConfigsBanCo[Enum_Config_Alert.XeDoLauChuaCoCK].Value))
                            {
                                var row = listCanhBaoXeRowsCount[i];
                                AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                                listCanhBaoXeRowsCount[i] = row;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogErrorUtils.WriteLogError("Đỗ lâu không được điều", ex);
                    }                    
                }
                i++;
                // Đi
                if (status == Enum_ColorOfVehicleStatus.KhongKhach && ThongTinCauHinh.GPS_TrangThai && xe != null && xe.SoKm > Convert.ToInt32(CommonBL.ConfigsBanCo[Enum_Config_Alert.DiChuyenRong].Value))
                {
                    var row = listCanhBaoXeRowsCount[i];
                    AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                    listCanhBaoXeRowsCount[i] = row;
                }
                i++;

                // Đỗ
                //if (baoRaKinhDoanh && !listTaxiOperationKetThuc.Contains(xe.SoHieuXe) && status!=Enum_ColorOfVehicleStatus.NhanDonKhach_DangCoKhach && status!=Enum_ColorOfVehicleStatus.CoKhach )
                //{
                //    var row = listCanhBaoXeRowsCount[i];
                //    AddToDataGrid(dgvCanhBaoXe, ref row, i, xe.SoHieuXe, StatusToForeColor(status), StatusToBackColor(status));
                //    listCanhBaoXeRowsCount[i] = row;
                //}
                //if (xe != null && baoRaKinhDoanh && status != Enum_ColorOfVehicleStatus.NhanDonKhach_DangCoKhach && status != Enum_ColorOfVehicleStatus.CoKhach
                //    && ThongTinCauHinh.GPS_TrangThai && xe.VGPS < 3
                //    && (xe.ThoiDiemChenDuLieu - xe.TGDiChuyenGanNhat).TotalMinutes > Convert.ToInt32(CommonBL.ConfigsBanCo[Enum_Config_Alert.DungDoLau].Value)
                //    && xe.TrangThaiKhac != -2
                //    )
                //{
                //    var row = listCanhBaoXeRowsCount[i];
                //    AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                //    listCanhBaoXeRowsCount[i] = row;
                //}
                //i++;

                //// Đón
                //if (!dicGiamSat_KhaiThac.ContainsKey(SoHieuXe) && status == Enum_ColorOfVehicleStatus.CoKhach)
                //{
                //    var row = listCanhBaoXeRowsCount[i];
                //    AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                //    listCanhBaoXeRowsCount[i] = row;
                //}
                //i++;

                //Tới
                //if (status == Enum_ColorOfVehicleStatus.KhongKhach && xe.SoKm > Convert.ToInt32(dicCauHinh[Enum_Config_Alert.DiChuyenRong]))
                //{
                //    var row=listCanhBaoXeRowsCount[i];
                //AddToDataGrid(dgvCanhBaoXe, ref row, i, xe.SoHieuXe, StatusToForeColor(status), StatusToBackColor(status));
                //listCanhBaoXeRowsCount[i] = row;
                //}
                //i++;

                //Sai
                //if (xe != null && ThongTinCauHinh.GPS_TrangThai && dicXeHoatDong.ContainsKey(SoHieuXe) && dicXeHoatDong[SoHieuXe].DiemDo.HasValue && dicXeHoatDong[SoHieuXe].DiemDo.Value != xe.VungID)
                //{
                //    var row = listCanhBaoXeRowsCount[i];
                //    AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                //    listCanhBaoXeRowsCount[i] = row;
                //}
                //i++;

                //Ăn
                if (dicGiamSat_AnCa.ContainsKey(SoHieuXe))
                {
                    var xeGS = dicGiamSat_AnCa[SoHieuXe];
                    var sophutnghi = 0;
                    if (!xeGS.SoPhutNghi.IsNull) sophutnghi = xeGS.SoPhutNghi.Value;
                    if ((timeServer - xeGS.ThoiDiemBao.Value).TotalMinutes > sophutnghi)
                    {
                        var row = listCanhBaoXeRowsCount[i];
                        AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                        listCanhBaoXeRowsCount[i] = row;
                    }
                }
                i++;

                //Ra
                if (dicGiamSat_RoiXe.ContainsKey(SoHieuXe))
                {
                    var xeGS = dicGiamSat_RoiXe[SoHieuXe];
                    var sophutnghi = 0;
                    //var sophutnghi_CauHinh = Convert.ToInt32(CommonBL.ConfigsBanCo[Enum_Config_Alert.RoiXe].Value);
                    if (!xeGS.SoPhutNghi.IsNull)
                    {
                        sophutnghi = xeGS.SoPhutNghi.Value;
                    }

                    //if (sophutnghi > sophutnghi_CauHinh)
                    //{
                    //    //Nếu số phút xin nghỉ lớn hơn số phút cấu hình thì lấy số phút xin nghỉ để so sánh
                    //    sophutnghi_CauHinh = sophutnghi;
                    //}
                    if ((DateTime.Now - xeGS.ThoiDiemBao.Value).TotalMinutes > sophutnghi)
                    {
                        var row = listCanhBaoXeRowsCount[i];
                        AddToDataGrid(dgvCanhBaoXe, ref row, i, SoHieuXe, StatusToForeColor(status), StatusToBackColor(status), cellFontSize - 2F, true);
                        listCanhBaoXeRowsCount[i] = row;
                    }
                }
                i++;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi AddToGridCanhBaoXe " + ex.Message);
            }
        }

        /// <summary>
        /// Update Header đếm số lượng xe (Grid cảnh Báo)
        /// </summary>
        /// <param name="listCanhBaoXeRowsCount"></param>
        private void DeleteCanhCaoXeEmptyRows(List<int> listCanhBaoXeRowsCount)
        {
            var maxRowCanhBaoXe = 0;
            for (var i = 0; i < listCanhBaoXeRowsCount.Count; i++)
            {
                if (maxRowCanhBaoXe < listCanhBaoXeRowsCount[i]) maxRowCanhBaoXe = listCanhBaoXeRowsCount[i];
                dgvCanhBaoXe.Rows[0].Cells[i].Value = listCanhBaoXeRowsCount[i] - 1;
            }
            while (dgvCanhBaoXe.Rows.Count > maxRowCanhBaoXe)
                dgvCanhBaoXe.Rows.RemoveAt(dgvCanhBaoXe.Rows.Count - 1);
            for (var i = 0; i < listCanhBaoXeRowsCount.Count; i++)
            {
                for (; listCanhBaoXeRowsCount[i] < maxRowCanhBaoXe; listCanhBaoXeRowsCount[i]++)
                {
                    dgvCanhBaoXe.Rows[listCanhBaoXeRowsCount[i]].Cells[i].Value = null;
                    dgvCanhBaoXe.Rows[listCanhBaoXeRowsCount[i]].Cells[i].Style.BackColor = Color.White;
                }
            }
        }

        #endregion
        private void ClearDgvSelection()
        {
          foreach (var vung in dicVung.Values)
            {
                var dgvXe = dicDataGrid[vung.VungGPSID];

                if (!vung.clearSelectionFirstRun)
                {
                    vung.clearSelectionFirstRun = true;
                    dgvXe.ClearSelection();
                }
            }
        }
                
        public void UpdateListXeOnline(T_XeOnline[] sThongTinXe)
        {
            try
            {
                if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                if (!ThongTinCauHinh.GPS_TrangThai || !Global.HasGPS) return;

                for (int i = 0; i < sThongTinXe.Length; i++)
                {
                    VehicleOnline xe = new VehicleOnline();
                    xe.SoHieuXe = sThongTinXe[i].SoHieuXe;
                    xe.MaXN = sThongTinXe[i].MaCungXN;
                    xe.BienSoXe = sThongTinXe[i].BienSoXe;
                    xe.KinhDo = sThongTinXe[i].KinhDo;
                    xe.ViDo = sThongTinXe[i].ViDo;
                    xe.Huong = sThongTinXe[i].HuongDiChuyen;
                    xe.SoChoNgoi = sThongTinXe[i].SoCho;
                    xe.LoaiXeGPS = sThongTinXe[i].LoaiXeGPS;
                    xe.LoaiXe = sThongTinXe[i].LoaiXe;
                    xe.TGCapNhat = sThongTinXe[i].TGCapNhat;
                    xe.Gara = sThongTinXe[i].Gara;
                    xe.Trangthai = sThongTinXe[i].TrangThai;
                    xe.TGDungXeNoMay = sThongTinXe[i].TGDungXeNoMay;
                    xe.VCo = sThongTinXe[i].VCo;
                    xe.VGPS = sThongTinXe[i].VGPS;
                    xe.ThoidiemChenDL = sThongTinXe[i].ThoiDiemChenDuLieu;
                    xe.ThoiDiemDiChuyenGanNhat = sThongTinXe[i].TGDiChuyenGanNhat;
                    xe.TGGPS = sThongTinXe[i].TGGPS;
                    xe.TrangThaiKhac = sThongTinXe[i].TrangThaiKhac;
                    xe.TrangThaiKhacText = sThongTinXe[i].TrangThaiKhacText;
                    xe.VungID = sThongTinXe[i].VungID;
                    if (CommonData.G_Dict_Vehicle == null)
                    {
                        CommonData.G_Dict_Vehicle = new Dictionary<string, string>();
                    }
                    if (CommonData.G_Dict_Vehicle.ContainsKey(sThongTinXe[i].BienSoXe))
                        CommonData.G_Dict_Vehicle[sThongTinXe[i].BienSoXe] = sThongTinXe[i].SoHieuXe;
                    else
                        CommonData.G_Dict_Vehicle.Add(sThongTinXe[i].BienSoXe, sThongTinXe[i].SoHieuXe);

                    if (CommonData.G_Dict_VehicleOnline == null)
                    {
                        CommonData.G_Dict_VehicleOnline = new Dictionary<string, VehicleOnline>();
                    }
                    if (CommonData.G_Dict_VehicleOnline.ContainsKey(sThongTinXe[i].SoHieuXe))
                        CommonData.G_Dict_VehicleOnline[sThongTinXe[i].SoHieuXe] = xe;
                    else
                        CommonData.G_Dict_VehicleOnline.Add(sThongTinXe[i].SoHieuXe, xe);
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Không thể kết nối tới Service", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
            }
        }

        /// <summary>
        /// Check xe dừng đỗ (VGPS <= 3)
        /// </summary>
        /// <param name="xe"></param>
        private void UpdateSpeedLessThan3Counter(T_XeOnline xe)
        {
            if (!dicCountSpeedLessThan3.ContainsKey(xe.SoHieuXe))
            {
                dicCountSpeedLessThan3[xe.SoHieuXe] = 0;
            }
            if (xe.VGPS <= 3)
            {
                dicCountSpeedLessThan3[xe.SoHieuXe]++;
            }
            else
                dicCountSpeedLessThan3[xe.SoHieuXe] = 0;
        }

        /// <summary>
        /// Lấy trạng thái xe. Convert sang enum
        /// </summary>
        /// <param name="xe"></param>
        /// <param name="isXeNhan"></param>
        /// <returns></returns>
        private Enum_ColorOfVehicleStatus GetTrangThaiXe(T_XeOnline xe, bool isXeNhan = false)
        {
            if (xe == null || xe.TrangThaiKhac == -2)
            {
                return Enum_ColorOfVehicleStatus.XeMTH;
            }
            if (!isXeNhan)
            {
                return ((xe.TrangThai & 3) > 0) ? Enum_ColorOfVehicleStatus.CoKhach : ((xe.TrangThai & 8) > 0) ? Enum_ColorOfVehicleStatus.TatMay : Enum_ColorOfVehicleStatus.KhongKhach;
            }
            else
            {
                return (xe.TrangThai & 3) > 0 ? Enum_ColorOfVehicleStatus.NhanDonKhach_DangCoKhach : (((xe.TrangThai & 8) > 0) || dicCountSpeedLessThan3[xe.SoHieuXe] >= 3) ? Enum_ColorOfVehicleStatus.NhanDonKhach_TatMay : Enum_ColorOfVehicleStatus.NhanDonKhach_DangDiChuyen;
            }
        }

        private Color StatusToBackColor(Enum_ColorOfVehicleStatus status)
        {
            return dicStatusBackColor[(int)status];
        }

        private Color StatusToForeColor(Enum_ColorOfVehicleStatus status)
        {
            return dicStatusForeColor[(int)status];
        }
        #endregion

        #region SizeChange Processing

        private void ResizeVungColumns(object sender)
        {
            var dgv = sender as MyDgv;
            ResizeWidthVungColumns(dgv);
             dgv.Height = (dgv.RowCount + 1) * (dgv.RowTemplate.Height + 2) + 2;
            if (dgv.Height <= HeighVung) dgv.Height = this.HeighVung;
        }

        /// <summary>
        /// Xử lý tính và chỉnh sửa cột cho grid vùng
        /// </summary>
        /// <param name="dgv">The DGV.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/25/2015   created
        /// </Modified>
        private void ResizeWidthVungColumns(MyDgv dgv)
        {
            int colWidth = (dgv.VerticalScrollbarVisible ? dgv.Width - 18 : dgv.Width - 3) / 4;
            for (var i = 0; i < 4; i++ )
            {
                dgv.Columns[i].Width = colWidth;
            }
        }

        private void Control_DieuHanhBanCo_BanCo_SizeChanged(object sender, EventArgs e)
        {
            int totalWidthVung = this.Width - 6;
            int widthVung = MinWidthVung;
            int colNum;
            for (colNum = 1; ; colNum++)
            {
                widthVung = (totalWidthVung - DistanceVung * (colNum - 1)) / colNum;
                int lastRowCols = (listGroupControl.Count - 2) % colNum;
                if (widthVung < MinWidthVung)
                {
                    //colNum--;
                    widthVung = MinWidthVung;
                    break;
                }
                else if (widthVung <= MaxWidthVung && lastRowCols != 0 && (totalWidthVung - (widthVung + DistanceVung) * lastRowCols - DistanceVung) / 2 >= MinWidthVungCuoi)
                    break;

            }
            this.WidthVung = widthVung-4;
            int rowNum = (listGroupControl.Count - 2) % colNum == 0 ? (listGroupControl.Count - 2) / colNum : (listGroupControl.Count - 2) / colNum + 1;
            int heighVung = HeighVung;
            if(rowNum!=0)
                heighVung = (this.Height - 6 - (rowNum - 1) * DistanceVung) / rowNum;
            if (heighVung < HeighVung) heighVung = HeighVung;
            for (int i = 0; i < listGroupControl.Count; i++)
            {
                int x = (i % colNum) * (widthVung + DistanceVung) + 3;
                int y = ((int)(i / colNum)) * (heighVung + DistanceVung) + 3;
                if (i >= listGroupControl.Count - 2)
                {
                    x = listGroupControl[i - 1].Location.X + listGroupControl[i - 1].Width + DistanceVung;
                    y = listGroupControl[listGroupControl.Count - 3].Location.Y;
                    widthVung = (totalWidthVung - (listGroupControl[listGroupControl.Count - 3].Location.X + listGroupControl[listGroupControl.Count - 3].Width + 2 * DistanceVung)) / 2;
                }
                listGroupControl[i].Width = widthVung;
                listGroupControl[i].Height = heighVung;
                listGroupControl[i].Location = new Point(x, y);
            }
            this.HeighVung = heighVung - 23;
            foreach (var dgvXe in dicDataGrid.Values)
            {
                dgvXe.Width = this.WidthVung;
                dgvXe.Height = this.HeighVung;
                //int colWidth = (dgvXe.VerticalScrollbarVisible ? dgvXe.Width - 18 : dgvXe.Width - 3) / 3;
                //dgvXe.Columns[0].Width = colWidth;
                //dgvXe.Columns[1].Width = colWidth;
                //dgvXe.Columns[2].Width = colWidth;
                ResizeVungColumns(dgvXe);
                dgvXe.Height = (dgvXe.RowCount + 1) * (dgvXe.RowTemplate.Height + 2) + 4;
                if (dgvXe.Height <= HeighVung) dgvXe.Height = heighVung - 23;
            }
           
            Resize2LastDgv();
        }

        private void Resize2LastDgv()
        {
            if (dgvTinhTrangPhuongTien == null || dgvCanhBaoXe == null) return;
            int w = ((dgvTinhTrangPhuongTien.VerticalScrollbarVisible ? dgvTinhTrangPhuongTien.Width - 15 : dgvTinhTrangPhuongTien.Width) - dgvTinhTrangPhuongTien.Columns.Count) / dgvTinhTrangPhuongTien.Columns.Count;
            if (w < dgvTinhTrangPhuongTienWidth)
            {
                w = dgvTinhTrangPhuongTienWidth;
            }
            foreach (DataGridViewColumn col in dgvTinhTrangPhuongTien.Columns)
            {
                col.Width = w;
            }
            w = ((dgvCanhBaoXe.VerticalScrollbarVisible ? dgvCanhBaoXe.Width - 15 : dgvCanhBaoXe.Width) - dgvCanhBaoXe.Columns.Count) / dgvCanhBaoXe.Columns.Count;
            if (w < dgvTinhTrangPhuongTienWidth)
            {
                w = dgvTinhTrangPhuongTienWidth;
            }
            foreach (DataGridViewColumn col in dgvCanhBaoXe.Columns)
            {
                col.Width = w;// dgvTinhTrangPhuongTienWidth; //35;//w;
            }
        }
        #endregion

        #region Cell Click Processing

        private void dgvTinhTrangPhuongTien_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm_HienTrangXe(sender as DataGridView, e.Location, null, string.Empty);
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedDgv = sender as DataGridView;

            if (selectedDgv.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect ||
                selectedDgv.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect) return;
            ClearOtherDgvSelection(selectedDgv);
            bool ignoreFirstRow = false;
            if (selectedDgv == dgvTinhTrangPhuongTien || selectedDgv == dgvCanhBaoXe)
            {
                ignoreFirstRow = true;
            }
            if (e.Button == MouseButtons.Right && TimXeTrenBanDo != null)
            {
                foreach (DataGridViewRow row in selectedDgv.Rows)
                {
                    if (ignoreFirstRow && row.Index == 0) continue;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        var rectange = selectedDgv.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                        if (rectange.Left <= e.X && e.X < rectange.Right && rectange.Top <= e.Y && e.Y <= rectange.Bottom)
                        {
                            cell.Selected = true;
                            if (cell.Value != null)
                            {
                                string sohieuxe = cell.Value.ToString();
                                TimXeTrenBanDo(sender, e, sohieuxe);
                                break;
                            }
                        }
                    }
                }

            }

            HienTrangXe.Visible = false;
        }

        private void ClearOtherDgvSelection(DataGridView selectedDgv)
        {
            foreach (var dgv in dicDataGrid.Values)
            {
                if (dgv != selectedDgv) dgv.ClearSelection();
            }
            if (selectedDgv != dgvTinhTrangPhuongTien) dgvTinhTrangPhuongTien.ClearSelection();
            if (selectedDgv != dgvCanhBaoXe) dgvCanhBaoXe.ClearSelection();
        }

        private void dgvXe_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm_HienTrangXe(sender as DataGridView, e.Location, null, string.Empty);
        }

        private void Control_DieuHanhBanCo_BanCo1_MouseMove(object sender, MouseEventArgs e)
        {
            currentMouseLocation = e.Location;
        }
        #endregion

        /// <summary>
        /// Hiển thị thông tin xe
        /// </summary>
        /// <param name="selectedDgv">Lưới được chọn, để xác định vị trí dòng và cột được click</param>
        /// <param name="locationCursor">vị trí con trỏ chuột</param>
        /// <param name="vehicle">Có thể truyền vào T_XeOnline, ko thì để Null</param>
        /// <param name="strSoHieuXe">Có thể truyền vào strSoHieuXe, ko thì để null</param>
        public void ShowForm_HienTrangXe(DataGridView selectedDgv, Point locationCursor, T_XeOnline vehicle, string strSoHieuXe)
        {
            if (selectedDgv != null)
            {
                int w = 50, h = 50;
                if (selectedDgv.SelectedCells.Count > 0)
                {
                    var selectedCell = selectedDgv.SelectedCells[0];
                    w = selectedDgv.Columns[selectedCell.ColumnIndex].Width;
                    h = selectedDgv.Rows[selectedCell.RowIndex].Height;
                }

                ClearOtherDgvSelection(selectedDgv);

                if (selectedDgv.SelectedCells.Count > 0 && selectedDgv.SelectedCells[0].Value != null)
                {                
                    strSoHieuXe = selectedDgv.SelectedCells[0].Value.ToString();
                    var appearPosition = this.PointToClient(selectedDgv.PointToScreen(locationCursor));
                    if (appearPosition.X + HienTrangXe.Width > this.Width)
                        appearPosition.X = appearPosition.X - HienTrangXe.Width - w;
                    if (appearPosition.Y + HienTrangXe.Height > this.Height)
                        appearPosition.Y = appearPosition.Y - HienTrangXe.Height - h;
                    if (appearPosition.Y < 0) appearPosition.Y = 0;
                    if (appearPosition.X < 0) appearPosition.X = 0;

                    locationCursor = appearPosition;
                }
            }

            if (vehicle != null)
            {
                HienTrangXe.ThongTinXe(vehicle, strSoHieuXe);
            }
            else if (strSoHieuXe != null && strSoHieuXe != string.Empty)
            {
                HienTrangXe.ThongTinXe(strSoHieuXe);
            }
            else if (listXeOnline != null && listXeOnline.Count(t => t.SoHieuXe == strSoHieuXe || t.BienSoXe == strSoHieuXe) > 0)
                HienTrangXe.ThongTinXe(listXeOnline.Single(t => t.SoHieuXe == strSoHieuXe || t.BienSoXe == strSoHieuXe), strSoHieuXe);
            else
                HienTrangXe.ThongTinXe(strSoHieuXe);

            HienTrangXe.Location = locationCursor;

            HienTrangXe.Visible = true;
            HienTrangXe.Focus();
        }

        #region Tim xe
        public void TimXe(string sohieuxe)
        {
            if (sohieuxe == "") return;

            bool timthay = false;
            if (listXeOnline != null && listXeOnline.Count(t => t.SoHieuXe == sohieuxe || t.BienSoXe == sohieuxe) > 0)
            {
                var xe = listXeOnline.Single(t => t.SoHieuXe == sohieuxe || t.BienSoXe == sohieuxe);
                if (dicDataGrid.ContainsKey(xe.VungID))
                {
                    var dgv = dicDataGrid[xe.VungID];
                    ClearOtherDgvSelection(dgv);
                    foreach (DataGridViewRow row in dgv.Rows)
                    {                        
                        int i = -1;
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(xe.SoHieuXe)) i = 0;
                        if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Equals(xe.SoHieuXe)) i = 1;
                        if (i != -1)
                        {
                            dgv.ClearSelection();
                            timthay = true;
                            row.Cells[i].Selected = true;
                            ScrollToGroupControl(dicGroupControl[xe.VungID]);
                            //if (ShowHienTrangXe != null)
                            {
                                var p = dgv.GetCellDisplayRectangle(row.Cells[i].ColumnIndex, row.Cells[i].RowIndex, true);
                                ShowForm_HienTrangXe(dgv, new MouseEventArgs(MouseButtons.Left, 1, p.Right, p.Bottom, 0).Location, xe, xe.SoHieuXe);
                            }
                            break;
                        }
                        //else
                        //{                            
                        //    Rectangle screenRect = Screen.GetBounds(Bounds);
                        //    point = new Point((this.Width + this.Location.X) / 2 - screenRect.Width / 2, (this.Height + this.Location.Y) / 2 - screenRect.Height / 2);
                        //}
                    }
                }
            }
            else
            {
                if (dicXeHoatDong.ContainsKey(sohieuxe))
	            {
                    var objXeHoatDong = dicXeHoatDong[sohieuxe];
                    if (dicVungId_IDGPS.ContainsKey(objXeHoatDong.DiemDo.Value))
                    {
                        var idVungGPS = dicVungId_IDGPS[objXeHoatDong.DiemDo.Value];
                        if (dicDataGrid.ContainsKey(idVungGPS))
                        {
                            var dgv = dicDataGrid[idVungGPS];
                            ClearOtherDgvSelection(dgv);
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                int i = -1;
                                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString().Equals(sohieuxe)) i = 2;
                                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Equals(sohieuxe)) i = 1;
                                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(sohieuxe)) i = 0;
                                if (i != -1)
                                {
                                    dgv.ClearSelection();
                                    timthay = true;
                                    row.Cells[i].Selected = true;
                                    ScrollToGroupControl(dicGroupControl[idVungGPS]);
                                    //if (ShowHienTrangXe != null)
                                    {
                                        var p = dgv.GetCellDisplayRectangle(row.Cells[i].ColumnIndex, row.Cells[i].RowIndex, true);
                                        ShowForm_HienTrangXe(dgv, new MouseEventArgs(MouseButtons.Left, 1, p.Right, p.Bottom, 0).Location, null, string.Empty);
                                    }
                                    break;
                                }
                            }
                        }
                    }
	            }
            }
            if (!timthay)
            {
                var lastCol = dgvTinhTrangPhuongTien.Columns.Count-1;
                foreach (DataGridViewRow row in dgvTinhTrangPhuongTien.Rows)
                {
                    var cell = row.Cells[lastCol];
                    if (cell.Value != null && cell.Value.ToString().Equals(sohieuxe))
                    {
                        dgvTinhTrangPhuongTien.ClearSelection();
                        timthay = true;
                        row.Cells[lastCol].Selected = true;
                        
                        ScrollToGroupControl(listGroupControl[listGroupControl.Count - 2]);
                        //if (ShowHienTrangXe != null)
                        {
                            var p = dgvTinhTrangPhuongTien.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                            ShowForm_HienTrangXe(dgvTinhTrangPhuongTien, new MouseEventArgs(MouseButtons.Left, 1, p.Right, p.Bottom, 0).Location, null, sohieuxe);
                            //ShowHienTrangXe(dgvTinhTrangPhuongTien, new MouseEventArgs(MouseButtons.Left, 1, p.Right, p.Bottom, 0), null, sohieuxe);
                        }
                        break;
                    }
                }
            }
            if (!timthay)
            {
                Rectangle screenRect = Screen.GetBounds(Bounds);
                Point point = new Point((this.Width + this.Location.X) / 2 - screenRect.Width / 2, (this.Height + this.Location.Y) / 2 - screenRect.Height / 2);
                ShowForm_HienTrangXe(null, point, null, sohieuxe);
                new MessageBox.MessageBoxBA().Show("Xe không nằm trong các vùng trên đây.");
            }
        }

        private void ScrollToGroupControl(GroupControl gc)
        {
            var scrollValue = (this.VerticalScroll.Maximum - this.VerticalScroll.LargeChange) * (gc.Location.Y + gc.Height) / this.VerticalScroll.LargeChange; ;
            if (scrollValue >= this.VerticalScroll.Minimum && scrollValue <= this.VerticalScroll.Maximum)
                this.VerticalScroll.Value = scrollValue;
        }
        #endregion

        #region Dong bo du lieu
        public void DongBoDuLieuXe()
        {
        }
        #endregion 

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    HienTrangXe.Visible = false;
                    break;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Thực hiện dừng mọi công việc của timer
        /// </summary>
        public void Stop()
        {
            Timer_BanCo.Stop();
            Timer_BanCo.Enabled = false;
            Timer_BanCo.Dispose();
        }

        /// <summary>
        /// Mobile xin điểm đỗ thì trả về số node cho mobile
        /// </summary>
        /// <param name="IDDiemDoGPS"></param>
        /// <param name="soHieuXe"></param>
        /// <returns></returns>
        public int GetNodeNum(int IDDiemDoGPS, string soHieuXe)
        {
            int node = 0;
            if (dicXe_DiemDo_Node.ContainsKey(soHieuXe))
            {
                if (dicXe_DiemDo_Node[soHieuXe].DiemDo == IDDiemDoGPS)
                {
                    node = dicGroupControl[IDDiemDoGPS].Tag == null ? 0 : dicGroupControl[IDDiemDoGPS].Tag.To<int>();
                }
                else
                {
                    node = dicGroupControl[IDDiemDoGPS].Tag == null ? 0 : dicGroupControl[IDDiemDoGPS].Tag.To<int>() + 1;
                }
            }
            else
                node = 1;
            return node;
        }

        public int GetIDVung(int IDVungGPS)
        {
            if (dicVungId_IDGPS.ContainsValue(IDVungGPS))
            {
                return dicVungId_IDGPS.FirstOrDefault(x=>x.Value.Equals(IDVungGPS)).Key;
            }
            return 0;
        }
    }

    #region Class
    
    public class Vung
    {
        public int Id;
        public int VungGPSID;
        public string Ten;
        public string MauChu;
        public bool clearSelectionFirstRun;
    }

    public class MyDgv : DataGridView
    {
        public event EventHandler ScrollbarVisibleChanged;
        public MyDgv()
        {
            this.VerticalScrollBar.VisibleChanged += VerticalScrollBar_VisibleChanged;
        }
        public bool VerticalScrollbarVisible
        {
            get
            {
                return VerticalScrollBar.Visible;
            }
        }
        private void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            EventHandler handler = ScrollbarVisibleChanged;
            if (handler != null) handler(this, e);
        }
        
    }

    class DistanceAlgorithm
    {
        const double PIx = 3.141592653589793;
        const double RADIUS = 6378.16;
        const double DeltaCoordinate = 0.0000089805297042448772;

        /// <summary>
        /// This class cannot be instantiated.
        /// </summary>
        private DistanceAlgorithm() { }

        /// <summary>
        /// Convert degrees to Radians
        /// </summary>
        /// <param name="x">Degrees</param>
        /// <returns>The equivalent in radians</returns>
        public static double Radians(double x)
        {
            return x * PIx / 180;
        }

        /// <summary>
        /// Calculate the distance between two places.
        /// </summary>
        /// <param name="lon1"></param>
        /// <param name="lat1"></param>
        /// <param name="lon2"></param>
        /// <param name="lat2"></param>
        /// <returns></returns>
        public static double DistanceBetweenPlaces(
            double lon1,
            double lat1,
            double lon2,
            double lat2)
        {
            double dlon = Radians(lon2 - lon1);
            double dlat = Radians(lat2 - lat1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return angle * RADIUS;
        }
        /// <summary>
        /// check điểm trong hình chữ nhật
        /// chính là hình chữ nhật ngoại tiếp đường tròn
        /// </summary>
        /// <param name="point">điểm cần check</param>
        /// <param name="radius">bán kính</param>
        /// <param name="center">tâm đường tròn</param>
        /// <returns></returns>
        public static bool CheckPointInRectangle(Coordinate point, Coordinate center, double radius)
        {
            // độ rộng vĩ độ
            double deltaLat = radius * DeltaCoordinate;
            // độ rộng kinh độ
            double deltaLng = deltaLat / (Math.Cos(center.Latitude * Math.PI / 180));
            // check điểm có nằm trong khoảng vĩ độ
            if (point.Latitude > center.Latitude + deltaLat || point.Latitude < center.Latitude - deltaLat)
                return false;
            // check điểm có nằm trong khoảng kinh độ
            if (point.Longitude > center.Longitude + deltaLng || point.Longitude < center.Longitude - deltaLng)
                return false;
            return true;
        }
    }

    class Coordinate
    {
        public double Latitude;
        public double Longitude;
    }
    #endregion
}
