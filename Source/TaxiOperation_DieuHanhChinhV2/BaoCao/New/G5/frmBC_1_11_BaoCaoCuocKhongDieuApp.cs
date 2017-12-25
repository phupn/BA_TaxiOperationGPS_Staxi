#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Drawing;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using System.Collections.Generic;
using System.Linq;
using Taxi.Business;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using Femiani.Forms.UI.Input;
using System.Data;
using Taxi.Data.G5.DanhMuc;
using Taxi.Services;
using System.Globalization;
#endregion ============= Copyright © 2016 BinhAnh =============


namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "1.12 Báo cáo cuốc không điều app")]
    public partial class frmBC_1_11_BaoCaoCuocKhongDieuApp : FrmReportBase
    {
        #region===properties===
        private AutoCompleteEntryCollection g_ListDataAutoComplete;
        private float _kinhDo;
        private float _viDo;
        private TenDuongVietTat _objTenDuongVietTat;
        private bc_1_11_BaoCaoCuocKhongDieuApp _item;
        private List<bc_1_11_BaoCaoCuocKhongDieuApp> _lst;
        #endregion
        public frmBC_1_11_BaoCaoCuocKhongDieuApp()
        {
            InitializeComponent();
        }

        #region=== override===
        protected override void AfterLoad()
        {
            ConfigMap();
            LoadDuLieuForAutoComplete();
            txtDiaChi_GPS.Text = "";
            txtCachLay.Text = "";
        }
        protected override object GetData()
        {
            _lst = bc_1_11_BaoCaoCuocKhongDieuApp.GetReport(ipFromDate.DateTime, ipToDate.DateTime,txtSoDienThoai.Text);
            if (_lst != null && _lst.Count > 0)
            {
                btnTongHop.Visible = true;
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                btnTongHop.Visible = false;
            }
            return _lst;
        }
        #endregion

        #region MAP

        private int KenhID = 0;
        private string MaCungXN = string.Empty;
        private string g_DSXeDeCu;
        private string g_DSXeDeCu_TD;
        bool isMarker = false;
        XeOnline clsXeOnline = new XeOnline();
        private GMapProvider _mapType;
        private Taxi.Utils.MapModeEnum _mapMode;
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
            try
            {
                //Config gmaps
                MainMap.CacheLocation = Application.StartupPath + "\\Map";
                MainMap.Manager.Mode = AccessMode.ServerAndCache;
                MainMap.MapProvider = GMapProviders.GoogleMap;
                MainMap.MaxZoom = 19;
                MainMap.MinZoom = 7;
                MainMap.Zoom = 15;
                MainMap.Dock = DockStyle.Fill;

                {
                    top = new GMapOverlay("top");
                    MainMap.Overlays.Add(top);

                    OverlayXeDeCu = new GMapOverlay("OverlayXeDeCu");
                    MainMap.Overlays.Add(OverlayXeDeCu);
                }

                pnlBanDo.Controls.Add(MainMap);


                if (_mapMode == Taxi.Utils.MapModeEnum.EditPoint)
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


                //Get zoom  
                trackBarMap.Minimum = MainMap.MinZoom;
                trackBarMap.Maximum = MainMap.MaxZoom;
                trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);

                CustomInitMap();

                // kiểm tra và thiết lặp vị trí mặc định của bản đồ
                if (ThongTinCauHinh.GPS_KinhDo > 0 && ThongTinCauHinh.GPS_ViDo > 0)
                    MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            }
            catch (Exception exx)
            {
                LogError.WriteLogError("frmDienThoaiInputDataNew_V3.ConfigMap", exx);
            }

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
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0)
                {
                    MainMap.OverlayCustom.Markers.Clear();
                }
                PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                try
                {
                    string strDiaChi = Service_Common.GetAddressByGeoBA((float)point.Lat, (float)point.Lng);

                    MainMap.addMarkerCustomer(point, strDiaChi);
                    txtTenDiem.Text = strDiaChi;
                    txtDiaChi_GPS.Text = strDiaChi;
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("MainMap_MouseDown:", ex);
                }
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        #endregion=============================================================
        #endregion=============================================================

        #region===Events control===
        private void btnTaoDiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVietTat.Text) || string.IsNullOrEmpty(txtTenDiem.Text))
            {
                txtVietTat.Focus();
                lblMsg.Text = "Chưa nhập đủ tên điểm và tên viết tắt";
            }
            else
            {
                try
                {
                    lblMsg.Text = "";
                    string NameVN = txtTenDiem.Text.Trim();
                    string NameEN = Taxi.Utils.UnicodeStrings.LatinToAscii(NameVN);
                    if (_objTenDuongVietTat == null)
                    {
                        _objTenDuongVietTat = new TenDuongVietTat();
                    }
                    _objTenDuongVietTat.NameEN = NameEN;
                    _objTenDuongVietTat.NameVN = NameVN;
                    _objTenDuongVietTat.KinhDo = _kinhDo;
                    _objTenDuongVietTat.ViDo = _viDo;
                    _objTenDuongVietTat.VietTat = txtVietTat.Text.Trim();
                    _objTenDuongVietTat.FK_CuocGoiID = _item.ID;
                    _objTenDuongVietTat.Save();
                    lblMsg.ForeColor = Color.Blue;
                    lblMsg.Text = "Tạo điểm thành công";
                    txtTenDiem.Text = string.Empty;
                    txtVietTat.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.ToString();
                }
            }
        }
        private void btnGPS_Click(object sender, EventArgs e)
        {
            if (XacDinhViTri(txtCachLay.Text, txtCachLay.KinhDo, txtCachLay.ViDo))
            {
                gridView2.SetFocusedRowCellValue("CachLay", txtCachLay.Text);
            }
        }
        private void txtDiaChi_GPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XacDinhViTri(txtDiaChi_GPS.Text, txtDiaChi_GPS.KinhDo, txtDiaChi_GPS.ViDo);
            }
        }
        private void shGridControl2_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                txtTenDiem.Text = "";
                txtVietTat.Text = "";
                if (gridView2.RowCount > 0)
                {
                    groupBox1.Enabled = true;
                    txtCachLay.Text = "";
                    _item = gridView2.GetFocusedRow() as bc_1_11_BaoCaoCuocKhongDieuApp;
                    _kinhDo = _item.GPS_KinhDo;
                    _viDo = _item.GPS_ViDo;
                    txtCachLay.Text = _item.DiaChiDonKhach;
                    if (_viDo != 0 && _kinhDo != 0)
                    {
                        MainMap.addMarkerMG(new PointLatLng(_viDo, _kinhDo), _item.DiaChiDonKhach);
                        var va = TenDuongVietTat.Inst.GetPoint(_item.ID);
                        if (va != null && va.Count > 0)
                        {
                            _objTenDuongVietTat = va[0];
                            txtTenDiem.Text = _objTenDuongVietTat.NameVN;
                            txtVietTat.Text = _objTenDuongVietTat.VietTat;
                        }
                        else
                        {
                            _objTenDuongVietTat = null;
                        }
                    }
                }
                else
                {
                    groupBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("shGridControl2_Click: ",ex);                
            }
        }
        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (btnTongHop.Visible)
            {
                object obj = _lst.GroupBy(x => x.MaNhanVienDienThoai).Select(p => new TongHopNhanVien() { MaNhanVienDienThoai = p.Key, SoCuoc = p.Count() }).ToList();
                new frmBC_1_11_1_BaoCaoCuocKhongDieuAppTongHopTheoNhanVien(obj).Show();
            }
        }
        #endregion
      
        #region===Methods===
        /// <summary>
        /// hàm thực hiện lấy dữ liệu autocomplete
        /// </summary>
        private void LoadDuLieuForAutoComplete()
        {
            if (g_ListDataAutoComplete == null)
                g_ListDataAutoComplete = new AutoCompleteEntryCollection();

            string address = "";
            string streetAbbr = "";
            float kd = 0;
            float vd = 0;
            using (DataTable dt = new DiaDanh().GetRoadData_Autocomplete())
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        address = row["Street"].ToString();
                        streetAbbr = row["StreetAbbr"].ToString();
                        kd = float.Parse(row["KinhDo"].ToString());
                        vd = float.Parse(row["ViDo"].ToString());

                        g_ListDataAutoComplete.Add(new AutoCompleteEntry(address, kd, vd, streetAbbr));
                        i++;
                    }
                }
                txtDiaChi_GPS.Items = g_ListDataAutoComplete;
                txtCachLay.Items = g_ListDataAutoComplete;
            }
        }
        private bool XacDinhViTri(string diaChi, float kinhDo, float viDo)
        {
            try
            {
                if (viDo == 0 && kinhDo == 0)
                {
                    string toaDo = Service_Common.GetGeobyAddress(diaChi, ThongTinCauHinh.GPS_TenTinh).Replace(',', '.');
                    if ((toaDo != "*" && toaDo != string.Empty))
                    {
                        string[] arrString = toaDo.Split(' ');
                        viDo = float.Parse(arrString[0], CultureInfo.InvariantCulture);
                        kinhDo = float.Parse(arrString[1], CultureInfo.InvariantCulture);
                        MainMap.addMarkerMG(new PointLatLng(viDo, kinhDo), diaChi);
                        return true;
                    }
                    else
                    {
                        lblMsg.Text = "Không tìm thấy địa chỉ này trên bản đồ";
                        return false;
                    }
                }
                else
                {
                    MainMap.addMarkerMG(new PointLatLng(viDo, kinhDo), diaChi);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("XacDinhViTri: ", ex);
                return false;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                txtDiaChi_GPS.Focus();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.C))
            {
                if (txtCachLay.Focus())
                {
                    shGridControl2.Focus();
                }
                else if (shGridControl2.Focus())
                {
                    txtCachLay.Focus();
                }
                else
                {
                    txtCachLay.Focus();
                }
                return true;
            }
            if (keyData == (Keys.Alt | Keys.T))
            {
                if (txtTenDiem.Focus())
                {
                    shGridControl2.Focus();
                }
                else if (shGridControl2.Focus())
                {
                    txtTenDiem.Focus();
                }
                else
                {
                    txtTenDiem.Focus();
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
    public class TongHopNhanVien
    {
        public string MaNhanVienDienThoai { get; set; }
        public int SoCuoc { get; set; }
    }
}
