using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Inputs;
using Taxi.Controls.Base.Extender;
namespace Taxi.GUI
{
    public partial class frmDoiTac : FormBase
    {
        private DoiTac _doiTac;
        private bool _isAdd = false;
        private bool _isThayDoiDienThoai = false;
        private bool _isFocusAddress = false;
        public DoiTac DoiTac
        {
            get { return _doiTac; }
        }

        #region Validate du lieu
        private void editName_TextChanged(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
                errorProvider.SetError(editName, "Trường tin Tên đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editName, "");
        }
        private void editName_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
                errorProvider.SetError(editName, "Trường tin Tên đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editName, "");
        }





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
        private void ShowMapOnForm()
        {
            if (grpViTri.Visible == true)
            {
                this.ClientSize = new System.Drawing.Size(425, 515);
                grpViTri.Visible = false;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(934, 515);
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
            catch (Exception)
            {

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
            if (e.KeyCode == Keys.Enter)
            {
                string diaChi = txtAddress.Text.Trim();
                if (!string.IsNullOrEmpty(diaChi))
                {
                    double viDo = 0;
                    double kinhDo = 0;
                    string toaDo = Taxi.Services.Service_Common.GetGeobyAddress(diaChi, ThongTinCauHinh.GPS_TenTinh).Replace(',', '.'); 
                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        viDo = Convert.ToDouble(arrString[0]);
                        kinhDo = Convert.ToDouble(arrString[1]);
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy địa chỉ", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                    }
                    if (kinhDo == 0 && viDo == 0)
                        return;
                    MainMap.Position = new PointLatLng(viDo, kinhDo);
                    //MainMap.AddMarkerBlueCircle(kinhDo, viDo);
                }
            }
        }
        #endregion

        #region===Form events===
        public frmDoiTac()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        public frmDoiTac(DoiTac DoiTac, bool boolAdd)
        {
            InitializeComponent();
            _isAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới đối tác";
                editMaDoiTac.ReadOnly = false;
            }
            else
            {
                this.Text = "Sửa đổi thông tin đối tác";
                editMaDoiTac.ReadOnly = true;
                if (ThongTinDangNhap.HasPermission("01050100"))
                {
                    editMaDoiTac.ReadOnly = false;
                }
            }

            _doiTac = DoiTac;
        }
        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện bind dữ liệu cho các input
                pnlControls.FindAllChildrenByType<IShControl>().ToList().ForEach(c => c.Bind());

                ConfigMap();
                ShowMapOnForm();
                LoadLoaiDoiTac();
                if (!_isAdd)
                {
                    SetDoiTac(_doiTac);
                    if (_doiTac.ViDo > 0 && _doiTac.KinhDo > 0)
                    {
                        MainMap.addMarkerMG(new PointLatLng(_doiTac.ViDo, _doiTac.KinhDo), _doiTac.Name);
                        _currentMarker = MainMap.MarkerCustomer;
                        txtKinhDo.Text = _doiTac.KinhDo.ToString();
                        txtViDo.Text = _doiTac.ViDo.ToString();
                    }
                    else
                    {
                        txtKinhDo.Text = "0";
                        txtViDo.Text = "0";
                    }

                    LoadNhanVien(_doiTac.MaNhanVien);
                }
                else
                {
                    LoadNhanVien(string.Empty);
                    editMaDoiTac.Text = _doiTac.MaDoiTac;
                    txtKinhDo.Text = "0";
                    txtViDo.Text = "0";
                }
                txtAddress.LostFocus += txtAddress_LostFocus;
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
                string Phones = StringTools.TrimSpace(editPhones.Text);
                if (editMaDoiTac.Text.Trim().Length >= 50)
                {
                    new MessageBox.MessageBoxBA().Show("Mã đối tác không được dài quá 50 ký tự", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    return;
                }
                string mes = this.CheckSoDienThoai(Phones);
                if (mes.Length > 0)
                {
                    if (new MessageBox.MessageBoxBA().Show("Số điện thoại lỗi : " + mes + ". Bạn có đồng ý nhập không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() != DialogResult.Yes.ToString())
                    {
                        return;
                    }
                }

                if (Phones.Length > 1)
                {
                    if (this.CheckTrungTrongChinhMinh(Phones))
                    {
                        new MessageBox.MessageBoxBA().Show("Số điện thoại trùng nhau.", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        return;
                    }

                }
                string MessageTrung = "";
                if (this.CheckTonTaiSoDienThoai(IsAdd, Phones, _doiTac, out MessageTrung))
                {
                    new MessageBox.MessageBoxBA().Show(MessageTrung, "Thông báo", MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
                string[] arrDigitFail = { ":", "'", "\\", "|", ",", ".", "/", "?", ">", "<", "_", "-", "=", "+", "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", };
                if (Array.Exists(arrDigitFail,E => E == Phones))
                {
                    new MessageBox.MessageBoxBA().Show("Các số điện thoại phải cách nhau bởi dấu chấm phẩy", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    return;
                }
                GetDoiTac();
                if (_doiTac == null)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn chọn công ty để nhập điểm môi giới.", "", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnSave_Click: ", ex);                
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btn_ViTri_Click(object sender, EventArgs e)
        {
            ShowMapOnForm();
        }

        private void MainMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                txtKinhDo.Text = point.Lng.ToString();
                txtViDo.Text = point.Lat.ToString();
                if (string.IsNullOrEmpty(editName.Text))
                {
                    errorProvider.SetError(editName, "Trường tin Tên đối tác bắt buộc phải nhập");
                }
                else
                {
                    MainMap.addMarkerMG(point, editName.Text);
                }
            }
        }

        #endregion

        #region===Methods===
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return _isAdd; }
        }

        private void LoadNhanVien(string MaNhanVien)
        {
            try
            {
                cboNhanVien.ValueMember = "USER_ID";
                cboNhanVien.DisplayMember = "FULLNAME";
                cboNhanVien.DataSource = null;
                cboNhanVien.DataSource = new Users().GetDSUserLaTiepThi();

                if (MaNhanVien.Length > 0)
                {
                    int iIndex = -1;
                    foreach (Janus.Windows.EditControls.UIComboBoxItem objItem in cboNhanVien.Items)
                    {
                        iIndex += 1;
                        if (objItem.Value.ToString() == MaNhanVien)
                        {
                            break;
                        }
                    }
                    cboNhanVien.SelectedIndex = iIndex;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadNhanVien: ", ex);
            }
        }

        private void SetDoiTac(DoiTac pDoiTac)
        {
            editMaDoiTac.Text = pDoiTac.MaDoiTac;
            editName.Text = pDoiTac.Name;
            editAddress.Text = pDoiTac.Address;
            editPhones.Text = pDoiTac.Phones;
            numericHHNoiTinh.Text = pDoiTac.TiLeHoaHongNoiTinh.ToString();
            numericHHNgoaiTinh.Text = pDoiTac.TiLeHoaHongDuongDai.ToString();
            editNotes.Text = pDoiTac.Notes;
            chkIsActive.Checked = pDoiTac.IsActive;
            calNgayKyKet.Value = _doiTac.NgayKyKet;
            editSoNha.Text = _doiTac.SoNha;
            editTenDuong.Text = _doiTac.TenDuong;
            cboLoaiDT.SelectedValue = pDoiTac.LoaiDoiTacID;
            txtVietTat.Text = _doiTac.VietTat;
            if (_doiTac.FK_Step != null && _doiTac.FK_Step > 0)
                cbDoiTacStep.EditValue = _doiTac.FK_Step;
        }

        public DoiTac GetDoiTac()
        {
            _doiTac.MaDoiTac = editMaDoiTac.Text.Trim();
            if (_doiTac.MaDoiTac.Length > 0)
            {
                _doiTac.Name = editName.Text;
                _doiTac.Address = editAddress.Text;
                _doiTac.Phones = StringTools.TrimSpace(editPhones.Text);
                _doiTac.TiLeHoaHongNoiTinh = float.Parse(numericHHNoiTinh.Text);
                _doiTac.TiLeHoaHongDuongDai = float.Parse(numericHHNgoaiTinh.Text);
                _doiTac.Notes = editNotes.Text;
                _doiTac.IsActive = chkIsActive.Checked;
                if (cboNhanVien.SelectedValue != null)
                    _doiTac.MaNhanVien = cboNhanVien.SelectedValue.ToString();
                else
                    _doiTac.MaNhanVien = "";
                if (cboNhanVien != null)
                    _doiTac.TenNhanVien = cboNhanVien.Text;
                else _doiTac.TenNhanVien = "";
                _doiTac.NgayKyKet = calNgayKyKet.Value;
                _doiTac.SoNha = StringTools.TrimSpace(editSoNha.Text);
                _doiTac.TenDuong = StringTools.TrimSpace(editTenDuong.Text);
                if (cboLoaiDT.Items.Count>0)
                {
                    if (cboLoaiDT.SelectedValue!=null)
                    {
                        _doiTac.LoaiDoiTacID = (int)cboLoaiDT.SelectedValue;
                    }
                }
                _doiTac.KinhDo = float.Parse(txtKinhDo.Text);
                _doiTac.ViDo = float.Parse(txtViDo.Text);
                _doiTac.VietTat = txtVietTat.Text;
                if (cbDoiTacStep.Properties.DataSource != null)
                {
                    if (cbDoiTacStep.EditValue != null)
                    {
                        _doiTac.FK_Step = (int)cbDoiTacStep.EditValue;
                    }
                }
                return _doiTac;
            }
            return null;
        }

        private void LoadLoaiDoiTac()
        {
            DataTable dt = Data.DM.LoaiDoiTac.Inst.GetAll();
            cboLoaiDT.DataSource = dt;
            cboLoaiDT.DisplayMember = "Name";
            cboLoaiDT.ValueMember = "Id";
            if (dt.Rows.Count>0)
            {
                cboLoaiDT.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Hàm trả về số điện thoại nghi ngờ là sai
        /// Phones : 0437856099;0908090909
        /// </summary>
        private string CheckSoDienThoai(string Phones)
        {
            String strReturn = "";
            string[] arrPhones = Phones.Split(";".ToCharArray());
            for (int i = 0; i < arrPhones.Length; i++)
            {
                for (int k = 0; k < arrPhones[i].Length; k++)
                {
                    if (!char.IsDigit(Convert.ToChar(arrPhones[i].Substring(k, 1)))) { strReturn += " Số có ký tự " + arrPhones[i]; break; }
                }
                if (!arrPhones[i].StartsWith("0") && arrPhones[i].Length == 7) //Nhập số máy bàn ko có mã tỉnh ví dụ:3541142142
                {
                    continue;
                }
                if (arrPhones[i].Length <= 9 || arrPhones[i].Length > 11)
                {
                    strReturn += " Số điện thoại nghi ngờ sai " + arrPhones[i];
                }
            }

            return strReturn;
        }

        /// <summary>
        /// check so điện thọai trùng trong chính mình
        /// </summary>
        private bool CheckTrungTrongChinhMinh(string ListPhone)
        {
            string[] lstPhone = ListPhone.Split(";".ToCharArray());
            if (lstPhone.Length <= 1) return false;
            for (int i = 0; i < lstPhone.Length - 1; i++)
            {
                for (int j = i + 1; j < lstPhone.Length; j++)
                {
                    if (lstPhone[i] == lstPhone[j])
                        return true;
                }
            }
            return false;
        }

        private bool CheckTonTaiSoDienThoai(bool IsNew, string ListPhones, DoiTac doitac, out string MessageTrung)
        {
            List<DoiTac> lstDoiTac = new DoiTac().GetListOfDoiTacs();
            string[] lstPhone = ListPhones.Split(";".ToCharArray());
            if (IsNew) // tạo mới thì check cả
            {

                foreach (DoiTac dt in lstDoiTac)
                {
                    for (int i = 0; i < lstPhone.Length; i++)
                    {
                        if (dt.Phones.Contains(lstPhone[i]))
                        {
                            MessageTrung = " Trùng số điện thoại có mã môi giới: " + dt.MaDoiTac + ";  số điện thoại: " + dt.Phones;
                            return true;
                        }
                    }                   
                }
            }
            else
            {
                foreach (DoiTac dt in lstDoiTac)
                {
                    for (int i = 0; i < lstPhone.Length; i++)
                    {
                        if (doitac.MaDoiTac != dt.MaDoiTac)
                        {
                            if (dt.Phones.Contains(lstPhone[i]))
                            {
                                MessageTrung = " Trùng số điện thoại có mã môi giới: " + dt.MaDoiTac + ";  số điện thoại: " + dt.Phones;
                                return true;
                            }
                        }
                    }

                    if (editMaDoiTac.Text != doitac.MaDoiTac && doitac.MaDoiTac != dt.MaDoiTac && editMaDoiTac.Text == dt.MaDoiTac)
                    {
                        MessageTrung = "Bị trùng mã đối tác tồn tại trong database!";
                        return true;
                    }
                }
            }
            MessageTrung = "";
            return false;
        }

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
                ShowMapOnForm();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}