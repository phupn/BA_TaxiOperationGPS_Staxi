using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Business.DM;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using Taxi.Services.BAGIS;

namespace Taxi.GUI
{
    public partial class frmDoiTac : Form
    {
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DoiTac mDoiTac;

        public DoiTac DoiTac
        {
            get { return mDoiTac; }            
        }

        private bool mIsAdd = false;
        private bool mIsThayDoiDienThoai = false;
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return mIsAdd; }           
        }

        public bool  IsThayDoiDienThoai
        {
            get { return mIsThayDoiDienThoai; }
        }

        public frmDoiTac()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

        }

        /// <summary>
        /// Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        /// <param name="DoiTac"></param>
        /// <param name="boolAdd"></param>
        public frmDoiTac(DoiTac  DoiTac , bool boolAdd)
        {
            InitializeComponent();
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới đối tác";
                editMaDoiTac.ReadOnly = false;

            }
            else
            {
                this.Text = "Sửa đổi thông tin đối tác";
                editMaDoiTac.ReadOnly = true;
            }

            mDoiTac = DoiTac;
        }

        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigMap();
                ShowMap();
                if (!mIsAdd)
                {
                    SetDoiTac(mDoiTac);
                    if (mDoiTac.ViDo > 0 && mDoiTac.KinhDo > 0)
                    {
                        MainMap.addMarkerMG(new PointLatLng(mDoiTac.ViDo, mDoiTac.KinhDo), mDoiTac.Name);
                        currentMarker = MainMap.MarkerCustomer;
                    }

                    LoadNhanVien(mDoiTac.MaNhanVien);
                }
                else
                {
                    LoadNhanVien(string.Empty);
                    editMaDoiTac.Text = mDoiTac.MaDoiTac;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDoiTac_Load", ex);
            }
           
        }
        
        private void LoadNhanVien(string MaNhanVien)
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

        private void SetDoiTac(DoiTac DoiTac)
        {
            editMaDoiTac.Text = DoiTac.MaDoiTac;
            editName.Text = DoiTac.Name;
            editAddress.Text = DoiTac.Address;
            editPhones.Text = DoiTac.Phones;
            //editFax.Text = DoiTac.Fax;
            //editEmail.Text = DoiTac.Email;
            //numericHHNgoaiTinh.Text = DoiTac.TiLeHoaHongDuongDai.ToString ();
            numericHHNoiTinh.Text = DoiTac.TiLeHoaHongNoiTinh.ToString ();
            editNotes.Text = DoiTac.Notes;
            chkIsActive.Checked = DoiTac.IsActive;

             //editVung.Text = mDoiTac.Vung.ToString () ;
             //if (editVung.Text == "0") editVung.Text = "1";
             calNgayKyKet.Value = mDoiTac.NgayKyKet;

             editSoNha.Text = mDoiTac.SoNha;
             editTenDuong.Text = mDoiTac.TenDuong;

           


        }

        public DoiTac GetDoiTac()
        {
            //int CongtyID  =  0;
            //try{                
            //    CongtyID = int.Parse(cboCongTy.SelectedValue.ToString());
            //}catch (Exception ex)
            //{
            //    CongtyID = 0;
            //}
            mDoiTac.MaDoiTac = editMaDoiTac.Text;
            if (mDoiTac.MaDoiTac.Length > 0)
            {                
                mDoiTac.Name = editName.Text;
                mDoiTac.Address = editAddress.Text;
                mDoiTac.Phones = StringTools.TrimSpace(editPhones.Text);
                //mDoiTac.Fax = editFax.Text;
                //mDoiTac.Email = editEmail.Text;
                //mDoiTac.TiLeHoaHongDuongDai = float.Parse(numericHHNgoaiTinh.Text);
                mDoiTac.TiLeHoaHongNoiTinh = float.Parse(numericHHNoiTinh.Text);
                mDoiTac.Notes = editNotes.Text;
                mDoiTac.IsActive = chkIsActive.Checked;
                if (cboNhanVien.SelectedValue != null)
                    mDoiTac.MaNhanVien = cboNhanVien.SelectedValue.ToString();
                else
                    mDoiTac.MaNhanVien = "";
                if (cboNhanVien != null)
                    mDoiTac.TenNhanVien = cboNhanVien.Text;
                else mDoiTac.TenNhanVien = "";
                //mDoiTac.Vung = editVung.Text.Trim().Length > 0 ? int.Parse(editVung.Text.Trim()) : 1;
                mDoiTac.NgayKyKet = calNgayKyKet.Value;
                //mDoiTac.CongTyID = CongtyID;

                mDoiTac.SoNha =  StringTools.TrimSpace( editSoNha.Text);
                mDoiTac.TenDuong = StringTools.TrimSpace(editTenDuong.Text);

                //if (chkKetThuc.Checked)
                //    mDoiTac.NgayKetThuc = calNgayKetThuc.Value;
                //else mDoiTac.NgayKetThuc = new DateTime(1900, 01, 01, 0, 0, 0);

                if (currentMarker != null && currentMarker.IsVisible)
                {
                    float kinhdo = 0;
                   float.TryParse(currentMarker.Position.Lng.ToString(), out kinhdo);
                   mDoiTac.KinhDo = kinhdo;
                   float vido = 0;
                   float.TryParse(currentMarker.Position.Lat.ToString(), out vido);
                   mDoiTac.ViDo = vido;
                }
                else
                {
                    mDoiTac.KinhDo = 0;
                    mDoiTac.ViDo = 0;
                }
               
                return mDoiTac;
            }
            return null ;
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
        private void editAddress_TextChanged(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editAddress.Text).Length <= 0)
                errorProvider.SetError(editAddress, "Trường tin Địa chỉ đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editAddress, "");
        }
        private void editAddress_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editAddress.Text).Length <= 0)
                errorProvider.SetError(editAddress, "Trường tin Địa chỉ đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editAddress, "");
        }
        private void editPhones_TextChanged(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editPhones.Text).Length <= 0)
                errorProvider.SetError(editPhones, "Trường tin Điện thoại đối tác bắt buộc phải nhập");
            else
            {
                errorProvider.SetError(editPhones, "");
            }

            mIsThayDoiDienThoai = true;

        }
        private void editPhones_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editPhones.Text).Length <= 0)
                errorProvider.SetError(editPhones, "Trường tin Điện thoại đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editPhones, "");
        }

        #endregion Validate du lieu

        private void btnSave_Click(object sender, EventArgs e)
        {
            string  Phones;
            Phones = StringTools.TrimSpace(editPhones.Text);
            bool boolCheckError = false;
            // check trong chuoi so dien thoai, co so nao trung ngay khong

            string mes = this.CheckSoDienThoai(Phones);

            if (mes.Length > 0)
            {
                if (new MessageBox.MessageBoxBA().Show("Số điện thoại lỗi : " + mes + ". Bạn có đồng ý nhập không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() != DialogResult.Yes.ToString())
                {
                    return;
                }
            }

            if(Phones.Length>1)
            {
                if (this.CheckTrungTrongChinhMinh(Phones))
                {
                    boolCheckError = true;
                    new MessageBox.MessageBoxBA().Show("Số điện thoại trùng nhau.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
                
            }
            string MessageTrung ="";
            if (this.CheckTonTaiSoDienThoai(IsAdd, Phones, mDoiTac, out MessageTrung))
            {
                new MessageBox.MessageBoxBA().Show("Số điện thoại trùng nhau với môi giới khác đã tạo.[" + MessageTrung +"]" , "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }

             
             
            GetDoiTac();

            if (mDoiTac == null)
            {
                new MessageBox.MessageBoxBA().Show("Bạn chọn công ty để nhập điểm môi giới.","", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                this.DialogResult = DialogResult.Cancel ;
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
             
        }
        
        /// <summary>
        /// hàm trả về số điện thoại nghi ngờ là sai
        /// Phones : 0437856099;0908090909
        /// </summary>
        /// <param name="Phones"></param>
        /// <returns></returns>
        private string CheckSoDienThoai(string Phones)
        {
            String strReturn = "";
            // so phones ghi ngở sai là nhưng số nhỏ hơn 9 và lớn hơn 11
            string[] arrPhones = Phones.Split(";".ToCharArray());
            for (int i = 0; i < arrPhones.Length; i++)
            {
                for (int k = 0; k < arrPhones[i].Length; k++)
                {
                    if (!char.IsDigit(Convert.ToChar(arrPhones[i].Substring(k, 1)))) { strReturn += " Số có ký tự " + arrPhones[i]; break; }
                }
                if ((arrPhones[i].StartsWith("0")&&arrPhones[i].Length <= 9)||(!arrPhones[i].StartsWith("0")&&arrPhones[i].Length < 6) || arrPhones[i].Length > 11)
                {
                    strReturn += " Số điện thoại nghi ngờ sai " + arrPhones[i]; 
                }
            }

              return strReturn;
        }
        
        /// <summary>
        /// check so điện thọai trùng trong chính mình
        /// </summary>
        /// <param name="ListPhone"></param>
        /// <returns></returns>
        private bool CheckTrungTrongChinhMinh(string ListPhone)
        {
            string[] lstPhone = ListPhone.Split(";".ToCharArray());
            if (lstPhone.Length <= 1) return false;
            else
            {
                for (int i = 0; i < lstPhone.Length - 1; i++)
                {
                    for (int j = i + 1; j < lstPhone.Length; j++)
                    {
                        if (lstPhone[i] == lstPhone[j])
                            return true;
                    }
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
                        if(doitac.MaDoiTac != dt.MaDoiTac)
                        {
                            if (dt.Phones.Contains(lstPhone[i]))
                            {
                                MessageTrung = " Trùng số điện thoại có mã môi giới: " + dt.MaDoiTac + ";  số điện thoại: " + dt.Phones;
                                return true;
                            }
                        }
                    }
                }

            }
            MessageTrung = "";
            return false;
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            //// Khoi tao doi tuong nhan vien voi ma tu dong 
            //string strMaNhanVien = NhanVien.GetNextMaNhanVien();
            //if (strMaNhanVien.Length > 0)
            //{
            //    NhanVien objNhanVien = new NhanVien(strMaNhanVien, string.Empty, DateTime.Now, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
            //    frmNhanVien frm = new frmNhanVien(objNhanVien, true);// them moi
            //    if (frm.ShowDialog(this) == DialogResult.OK)
            //    {
            //        objNhanVien = frm.GetNhanVien();
            //        frm.Dispose();
            //        //Insert DataBase
            //        if (!objNhanVien.Insert())
            //        {
            //            new MessageBox.MessageBox().Show("Lỗi thêm mới nhân viên");
            //            return;
            //        }
            //        else
            //        {
            //            //Load lai grid
            //            LoadNhanVien(objNhanVien.MaNhanVien);
            //        }
            //    }
            //    else return;

            //}
            //else
            //{
            //    new MessageBox.MessageBox().Show("Lỗi cấp mã cho nhân viên, liên hệ với quản trị");
            //    return;
            //}
           
        }

        private void chkSuaMa_CheckedChanged(object sender, EventArgs e)
        {
            //editMaDoiTac.Enabled = chkSuaMa.Checked;
        }


        private void ShowMap()
        {
            if (grpViTri.Visible == true)
            {
                this.ClientSize = new System.Drawing.Size(425, 367);
                grpViTri.Visible = false;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(934, 367);
                grpViTri.Visible = true;
            }
        }

        private void btn_ViTri_Click(object sender, EventArgs e)
        {
            //425, 405
            ShowMap();
            //950, 405
        }

        #region MAP

        // Toyota MyDinh Building
        private PointLatLng currentPoint = new PointLatLng(ThongTinCauHinh.GPS_ViDo,ThongTinCauHinh.GPS_KinhDo);
        private GMapProvider _mapType;
        private Taxi.Utils.MapModeEnum _mapMode;
        private int _mapZoom;
        //private object Object;

        // markers
        GMapMarkerCustom centerMarker;
        GMapMarker currentMarker;
        private List<GMapMarker> _otherMarkers;
        // layers
        GMapOverlay top;

        bool isMouseDown;

        private void ConfigMap()
        {
            // config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 7;
            MainMap.Zoom = 15;

            MainMap.Position = currentPoint;
            MainMap.PolygonsEnabled = false;
            MainMap.AllowDrawPolygon = false;

            // map events
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

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

        private void CustomInitMap()
        {
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            //initConfigGPS();

        }

        private void initConfigGPS()
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
            initConfigGPS();
        }

        private void MainMap_OnMapZoomChanged()
        {
            trackBarMap.Value = (int)MainMap.Zoom;
            initConfigGPS();
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
                if (currentMarker != null)
                {
                    isMouseDown = true;
                    if (currentMarker.IsVisible)
                        currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
                else
                {
                    MainMap.addMarkerCustomer(MainMap.FromLocalToLatLng(e.X, e.Y), txtAddress.Text.Trim());
                    currentMarker = MainMap.MarkerCustomer;
                    //currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
                initConfigGPS();
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown)
            {
                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
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
                    string toaDo = GetGeobyAddressBA_HN(diaChi);
                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        viDo = Convert.ToDouble(arrString[0]);
                        kinhDo = Convert.ToDouble(arrString[1]);                        
                    }
                    else
                    {
                       new MessageBox.MessageBoxBA().Show("Không tìm thấy địa chỉ","Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK);
                    }
                    if (kinhDo == 0 && viDo == 0)
                        return;

                    MainMap.AddMarkerBlueCircle(kinhDo, viDo,"", true);
                } 
            }
        }

        private string GetGeobyAddressBA_HN(string address)
        {
            try
            {
                using (gisSoapClient BAgis = new gisSoapClient())
                {
                    GSAuthenticationHeader auth = new GSAuthenticationHeader();
                    auth.Username = "gps";
                    auth.Password = "binhanh";
                    //BAgis.GSAuthenticationHeaderValue = auth;
                    GSAddressResult rs = BAgis.GetGeoByNameHaNoi(auth, address, "vn");
                    return String.Format("{0} {1}", rs.Lat, rs.Lng);
                }
            }
            catch (Exception ex)
            {
                return "*";
            }
        }        
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                ShowMap();
                return true;
            }

            return false;
        }
    }
}