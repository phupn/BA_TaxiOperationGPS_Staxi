using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Data.G5.DanhMuc;
using Taxi.Utils;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;

namespace Taxi.GUI
{
    public partial class frmPOI : Form
    {
        private POICommon _commonPOI;
        private bool _isFocusAddress = false;
        
        #region Validate du lieu
        #endregion Validate du lieu

        #region MAP
        private PointLatLng _currentPoint = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
        private GMapProvider _mapType;
        private MapModeEnum _mapMode;
        private int _mapZoom;
        private GMapMarkerCustom _centerMarker;
        private GMapMarker _currentMarker;
        private List<GMapMarker> _otherMarkers;
        private GMapOverlay top;
        private bool _isMouseDown;
        private void ShowMap()
        {
            if (grpViTri.Visible == true)
            {
                this.ClientSize = new System.Drawing.Size(425, 329);
                grpViTri.Visible = false;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(934, 329);
                grpViTri.Visible = true;
            }
        }

        private void ConfigMap()
        {
            try
            {
                // config gmaps
                MainMap.CacheLocation = Application.StartupPath + "\\Map";
                MainMap.Manager.Mode = AccessMode.ServerAndCache;
                MainMap.MapProvider = GMapProviders.GoogleMap;

                MainMap.MaxZoom = 19;
                MainMap.MinZoom = 7;
                MainMap.Zoom = 15;

                MainMap.Position = _currentPoint;
                MainMap.PolygonsEnabled = false;
                MainMap.AllowDrawPolygon = false;

                // map events
                MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
                

                if (_mapMode == MapModeEnum.EditPoint)
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

                // add custom layers  
                {
                    top = new GMapOverlay("top");
                    MainMap.Overlays.Add(top);
                }

                CustomInitMap();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ConfigMap: ", ex);
            }

        }

        private void CustomInitMap()
        {
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            //initConfigGPS();

        }

        private void InitConfigGPS()
        {
            //if (currentMarker != null && currentMarker.Position.Lat > 0)
            //{
            //    lblGPS_KinhDo.Text = currentMarker.Position.Lng.ToString();
            //    lblGPS_ViDo.Text = currentMarker.Position.Lat.ToString();
            //}
            //lblGPS_mucZoom.Text = MainMap.Zoom.ToString();
            //lblGPS_LoaiBanDo.Text = MainMap.MapProvider.Name;
        }

        #region===================Map Events==================================

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
            InitConfigGPS();
        }

        private void MainMap_OnMapZoomChanged()
        {
            trackBarMap.Value = (int)MainMap.Zoom;
            InitConfigGPS();
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
                _isMouseDown = false;
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_currentMarker != null)
                {
                    _isMouseDown = true;
                    if (_currentMarker.IsVisible)
                        _currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
                else
                {
                    MainMap.addMarkerCustomer(MainMap.FromLocalToLatLng(e.X, e.Y), txtAddress.Text.Trim());
                    _currentMarker = MainMap.MarkerCustomer;
                    //currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
                InitConfigGPS();
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _isMouseDown)
            {
                if (_currentMarker.IsVisible)
                {
                    _currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }

            }
            MainMap.Refresh(); // force instant invalidation
        }

        private void trackBarMap_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }

        #endregion=============================================================

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string diaChi = txtAddress.Text.Trim();
                    if (!string.IsNullOrEmpty(diaChi))
                    {
                        double viDo = 0;
                        double kinhDo = 0;
                        string toaDo = Services.Service_Common.GetGeobyAddress(diaChi, ThongTinCauHinh.GPS_TenTinh).Replace(',', '.');
                        if (toaDo != "*" && toaDo != string.Empty)
                        {
                            string[] arrString = toaDo.Split(' ');
                            if (arrString.Length > 0)
                            {
                                viDo = Convert.ToDouble(arrString[0]);
                                kinhDo = Convert.ToDouble(arrString[1]);   
                            }
                        }
                        else
                        {
                            new MessageBox.MessageBoxBA().Show("Không tìm thấy địa chỉ", "Thông báo", MessageBox.MessageBoxButtonsBA.OK);
                        }

                        if (kinhDo != 0 && viDo != 0)
                        {
                            MainMap.AddMarkerA(new PointLatLng(viDo, kinhDo), diaChi, true, true, 0, true);
                            MainMap.Position = new PointLatLng(viDo, kinhDo);
                            txtKinhDo.Text = viDo.ToString();
                            txtViDo.Text = kinhDo.ToString();
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("txtAddress_KeyDown: ", ex);                
            }
        }
        #endregion

        #region===Form events===
        public frmPOI()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        private void frmPOI_Load(object sender, EventArgs e)
        {
            try
            {                
                ConfigMap();
                ShowMap();
                txtAddress.LostFocus += txtAddress_LostFocus;
                txtPOIName.Focus();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("", ex);
            }
        }

        #endregion

        #region=== Control events===
        private void btnSave_Click(object sender, EventArgs e)
        {
            try 
	        {	        
		        if (CheckValidate())
                {
                    GetBaseInfo();
                    POICommon.Inst.InsertObject(_commonPOI.NameVN,_commonPOI.Type,_commonPOI.Acronym,_commonPOI.Address,_commonPOI.Lat,_commonPOI.Lng);
                    new MessageBox.MessageBoxBA().Show("Thêm mới POI thành công!", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
	        }
	        catch (Exception ex)
	        {
                new MessageBox.MessageBoxBA().Show("Thêm mới thất bại!", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                LogError.WriteLogError("btnSave_Click: " ,ex);
	        }
        }

        private void GetBaseInfo()
        {
            _commonPOI = new POICommon();
            _commonPOI.NameVN = txtPOIName.Text;
            _commonPOI.Type = 1;
            _commonPOI.Acronym = txtVietTat.Text;
            _commonPOI.Address = txtDiaChi.Text;
            _commonPOI.Lat = Convert.ToDouble(txtViDo.Text);
            _commonPOI.Lng = Convert.ToDouble(txtKinhDo.Text);
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtPOIName.Text))
            {
                new MessageBox.MessageBoxBA().Show("Tên POI không được để trống!", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                return false;
            }

            return true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btn_ViTri_Click(object sender, EventArgs e)
        {
            //425, 405
            ShowMap();
            //950, 405
        }

        private void MainMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                txtKinhDo.Text = point.Lng.ToString();
                txtViDo.Text = point.Lat.ToString();
                if (string.IsNullOrEmpty(txtPOIName.Text))
                {
                    errorProvider.SetError(txtPOIName, "Trường tin Tên POI bắt buộc phải nhập");
                    txtPOIName.Focus();
                }
                else
                {
                    MainMap.addMarkerMG(point, txtPOIName.Text);
                }
            }
        }

        #endregion

        #region===Methods===
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>

        #endregion

        private void txtAddress_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_isFocusAddress)
            {
                txtAddress.SelectAll();
                _isFocusAddress = true;
            }
        }

        private void txtAddress_LostFocus(object sender, EventArgs e)
        {
            _isFocusAddress = false;
        }

        private void frmDoiTac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.F1))
            {
                ShowMap();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}