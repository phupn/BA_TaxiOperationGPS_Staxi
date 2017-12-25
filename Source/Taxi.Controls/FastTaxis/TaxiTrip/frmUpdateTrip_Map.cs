using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Taxi.Business;
using Taxi.Common.Attributes;
using Taxi.Controls.Base;
using Taxi.Services;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Controls.Base.Controls;

namespace Taxi.Controls.FastTaxis.TaxiTrip
{
    public partial class frmUpdateTrip_Map : FormBase
    {
        private void frmXeBaoDiDuongDai_BanDo_Load(object sender, EventArgs e)
        {
            LoadViTriXe();                
            if (pic == 1)
                picDiemDon_Click(null, null);
            else if (pic == 2)
            {
                picDiemTra_Click(null, null);
            }
            if (ThongTinCauHinh.FT_ServiceMap == Utils.Enums.Enum_FT_ServiceMap.Google)
            {
                shPicture_LayLoTrinhTheoGoogle.Visible = false;
            }
        }
        #region Các biến dữ liệu

        public int countRouteThread = 0;
        public bool IsOk { get; set; }
        public string SoXe { get; set; }
        public int LoaiXeId { get; set; }
        public int pic;
        public bool IsProcess { get; set; }
        public string AddressA
        {
            get { return txtDiemDau.Text; }
            set { txtDiemDau.Text = value; }
        }

        public string AddressB
        {
            get { return txtDiemCuoi.Text; }
            set { txtDiemCuoi.Text = value; }
        }
        public GMapMarker _gMapMarkerA;
        public GMapMarker _gMapMarkerB;
        private GMapMarkerRedCircle AddMarkerRed;
        private bool processFisrt;
        public int Distance;
        public float TienDuKien { get; set; }
        public LoTrinh LoTrinh { get; set; }
        public float time { get; set; }
        #endregion

        #region hàm mở rộng
        /// <summary>
        /// Vẽ cung đường của 2 điểm A và B
        /// </summary>
        private void Route()
        {
            new Thread(new ThreadStart(RouteThread)).Start();        
        }

        public void RouteThread()
        {
            IsProcess = true;
            new Thread(p =>
            {
                if (IsProcess)
                {
                    var frm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ giây lát.", "Hệ thống đang Xử lý....");
                    while (IsProcess)
                    {
                        frm.Refresh();
                        Thread.Sleep(100);
                    }
                    frm.Close();
                }
            }).Start();
            try
            {
               
                string khoangcach;
                string thoigian;
                string addressA = string.Empty;
                string addressB = string.Empty;
                string address = string.Empty;
                MapRoute route = null;
                InsertDataControl(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null);
                // if (_gMapMarkerA == null || _gMapMarkerB == null)
                {
                    if (_gMapMarkerA != null)
                    {

                        addressA =
                            Service_Common.GetAddressByGeoBA((float)_gMapMarkerA.Position.Lat, (float)_gMapMarkerA.Position.Lng).RemoveRoutePr();

                    }
                    if (_gMapMarkerB != null)
                    {
                        addressB = Service_Common.GetAddressByGeoBA((float)_gMapMarkerB.Position.Lat, (float)_gMapMarkerB.Position.Lng).RemoveRoutePr();

                    }

                }
                //  else
                {   
                    if (!(LoTrinh.Distance > 0 && !processFisrt))
                        this.LoTrinh = Taxi.Controls.FastTaxis.TaxiChieuVe.TaxiReturn_Process.LayLoTrinh(_gMapMarkerA.Position, _gMapMarkerB.Position);
                    processFisrt = true;
                    if (!string.IsNullOrEmpty(LoTrinh.LoTrinh_DiaChi))
                    {
                        this.Distance = (int)LoTrinh.Distance;
                        khoangcach = (this.Distance).ToString("#,##0.##") + " km";
                        TinhTienTheoKm objTinhTien = new TinhTienTheoKm(this.LoaiXeId, Distance);
                        TienDuKien = objTinhTien.TongTien1Chieu;
                        time = (float)((float)this.Distance / 40);
                        if (time < 1)
                        {
                            thoigian = ((int)(time * 60)).ToString() + " phút";
                        }
                        else
                        {
                            thoigian = ((int)time).ToString() + " giờ " + ((int)(((time - ((int)time))) * 60)).ToString() + " phút";
                        }
                        address = this.LoTrinh.LoTrinh_DiaChi.Replace("=>", "<br/>=>");
                        
                        route = new MapRoute(this.LoTrinh.ListPoint, "Lộ trình");
                    }
                    else
                    {
                        khoangcach = "-1";
                        thoigian = "Không tồn tại đường";
                    }
                }

                InsertDataControl(khoangcach, thoigian, addressA, addressB, address, route);
            }
            catch (Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "frmUpdateTrip_Map\\RouteThread", DateTime.Now,string.Format("Số lần {0}:{1}",countRouteThread, ex.Message));
                if (countRouteThread < 5)
                {
                    countRouteThread++;
                    RouteThread();
                }
                else
                {
                    countRouteThread = 0;
                }
            }
            countRouteThread = 0;
            IsProcess = false;
        }
        public void RouteThreadGoogle()
        {
            IsProcess = true;
            new Thread(p =>
            {
                if (IsProcess)
                {
                    var frm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ giây lát.", "Hệ thống đang Xử lý....");
                    while (IsProcess)
                    {
                        frm.Refresh();
                        Thread.Sleep(100);
                    }
                    frm.Close();
                }
            }).Start();
            try
            {

                string khoangcach;
                string thoigian;
                string addressA = string.Empty;
                string addressB = string.Empty;
                string address = string.Empty;
                MapRoute route = null;
                InsertDataControl(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null);
                // if (_gMapMarkerA == null || _gMapMarkerB == null)
                {
                    if (_gMapMarkerA != null)
                    {

                        addressA =
                            Service_Common.GetAddressByGeoBA((float)_gMapMarkerA.Position.Lat,
                                (float)_gMapMarkerA.Position.Lng).RemoveRoutePr();

                    }
                    if (_gMapMarkerB != null)
                    {
                        addressB = Service_Common.GetAddressByGeoBA((float)_gMapMarkerB.Position.Lat,
                                (float)_gMapMarkerB.Position.Lng).RemoveRoutePr();

                    }

                }
                //  else
                {
                   // if (!(LoTrinh.Distance > 0 && !processFisrt))
                        this.LoTrinh = Taxi.Controls.FastTaxis.TaxiChieuVe.TaxiReturn_Process.LayLoTrinh(_gMapMarkerA.Position, _gMapMarkerB.Position,Utils.Enums.Enum_FT_ServiceMap.Google);
                   // processFisrt = true;
                    if (!string.IsNullOrEmpty(LoTrinh.LoTrinh_DiaChi))
                    {
                        this.Distance = (int)LoTrinh.Distance;
                        khoangcach = (this.Distance).ToString("#,##0.##") + " km";
                        TinhTienTheoKm objTinhTien = new TinhTienTheoKm(this.LoaiXeId, Distance);
                        TienDuKien = objTinhTien.TongTien1Chieu;
                        time = (float)((float)this.Distance / 40);
                        if (time < 1)
                        {
                            thoigian = ((int)(time * 60)).ToString() + " phút";
                        }
                        else
                        {
                            thoigian = ((int)time).ToString() + " giờ " + ((int)(((time - ((int)time))) * 60)).ToString() + " phút";
                        }
                        address = this.LoTrinh.LoTrinh_DiaChi.Replace("=>", "<br/>=>");

                        route = new MapRoute(this.LoTrinh.ListPoint, "Lộ trình");
                    }
                    else
                    {
                        khoangcach = "-1";
                        thoigian = "Không tồn tại đường";
                    }
                }

                InsertDataControl(khoangcach, thoigian, addressA, addressB, address, route);
            }
            catch (Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "frmUpdateTrip_Map\\RouteThread", DateTime.Now, string.Format("Số lần {0}:{1}", countRouteThread, ex.Message));
                if (countRouteThread < 5)
                {
                    countRouteThread++;
                    RouteThread();
                }
                else
                {
                    countRouteThread = 0;
                }
            }
            countRouteThread = 0;
            IsProcess = false;
        }

        public void InsertDataControl(string khoangcach, string thoigian, string addressA, string addressB,
            string address, MapRoute route)
        {
            if (txtLoTrinh.InvokeRequired)
            {
                txtLoTrinh.Invoke(new Action<string, string, string, string, string, MapRoute>(InsertDataControl), khoangcach, thoigian, addressA, addressB, address, route);
                return;
            }
            txtTienDuKien.EditValue = TienDuKien.ToString("#,###.##");
            txtKhoangCach.EditValue = khoangcach;
            txtThoiGian.EditValue = thoigian;
            txtLoTrinh.HtmlText = address;
          //  while()
            MainMap.ClearRoute();
            AddressA = addressA;
            AddressB = addressB;
            MainMap.AddRoute(route, Color.FromArgb(95, Color.Blue));
            if (_gMapMarkerA == null && _gMapMarkerB != null)
            {
                MainMap.Position = _gMapMarkerB.Position;
            }
            if (_gMapMarkerA != null && _gMapMarkerB == null)
            {
                MainMap.Position = _gMapMarkerA.Position;
            }
            MainMap.Refresh();
        }
        /// <summary>
        /// Lấy vị trí và hiển trị lên bản đồ nếu có xe
        /// </summary>
        public void LoadViTriXe()
        {
            if (!string.IsNullOrEmpty(SoXe))
            {
                try
                {
                    var xe = WCFService_Common.GetXeOnlineBySHX(SoXe);
                    if (xe != null)
                        MainMap.addMarkerXeNhan(1, xe.KinhDo, xe.ViDo, SoXe);
                }
                catch (Exception ex)
                {
                    new Log().WriteLog(ThongTinDangNhap.USER_ID, "frmUpdateTrip_Map\\LoadViTriXe", DateTime.Now, ex.Message);
                }
                
            }
        }
        /// <summary>
        /// Gọi Tác vụ đến bản đồ
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="diemDau"></param>
        /// <param name="diemCuoi"></param>
        public void ShowBanDo(PointLatLng? start, PointLatLng? end,string diemDau,string diemCuoi)
        {
           
            if (start!=null)
            this._gMapMarkerA = MainMap.AddMarkerEnum(start.Value,GMapResources.EnumMarkerCustom.MarkerD);
            if (end!=null)
                this._gMapMarkerB = MainMap.AddMarkerEnum(end.Value,GMapResources.EnumMarkerCustom.MarkerA); 
            Route();
            AddressA = diemDau;
            AddressB = diemCuoi;
        }
        [MethodWithKey(Keys = Keys.Control | Keys.F)]
        private void FindKey()
        {
            txtSearch.PerformClick(txtSearch.Properties.Buttons[0]);
        }

        private void ProcessOk()
        {
            if (IsProcess)
            {
                var frm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ giây lát.", "Hệ thống đang Xử lý....");
                while (IsProcess)
                {
                    frm.Refresh();
                    Thread.Sleep(100);
                }
                frm.Close();
            }
            if (_gMapMarkerA == null || _gMapMarkerB == null)
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa chọn điểm đón hoặc điểm trả");
                return;
            }
            IsOk = true;
            this.Invoke((MethodInvoker)this.Close);
        }
        #endregion

        #region Sự kiện
        private void btnOk_Click(object sender, EventArgs e)
        {
            new Thread(ProcessOk).Start();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var txt = TaxiReturn_Process.Search(txtSearch.Text);
                if (txt != null)
                {
                    MainMap.Position = new PointLatLng(txt.Value.Key, txt.Value.Value);
                    if (AddMarkerRed == null)
                        AddMarkerRed = MainMap.AddMarkerRed(MainMap.Position);
                    else AddMarkerRed.Position = MainMap.Position;
                    MainMap.Zoom = 16;
                }
                else
                    new MessageBox.MessageBoxBA().Show("Không tìm thấy địa chỉ");
            }
        }
        private void txtSearch_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var txt = TaxiReturn_Process.Search(txtSearch.Text);
                if (txt != null)
                {
                    MainMap.Position = new PointLatLng(txt.Value.Key, txt.Value.Value);
                    if (AddMarkerRed == null)
                        AddMarkerRed = MainMap.AddMarkerRed(MainMap.Position);
                    else AddMarkerRed.Position = MainMap.Position;
                    MainMap.Zoom = 16;
                }
                else
                    new MessageBox.MessageBoxBA().Show("Không tìm thấy địa chỉ");
            }
             
        }
        private void picViTriXe_Click(object sender, EventArgs e)
        {
            LoadViTriXe();
        }
        private void picDiemDon_Click(object sender, EventArgs e)
        {
            if (_gMapMarkerA == null)
            {
                _gMapMarkerA = MainMap.AddMarkerEnum(MainMap.Position,GMapResources.EnumMarkerCustom.MarkerD);
                Route();
            }
            else
            {
                MainMap.Position = _gMapMarkerA.Position;
            }
        }

        private void picDiemTra_Click(object sender, EventArgs e)
        {
            if (_gMapMarkerB == null)
            {
                _gMapMarkerB = MainMap.AddMarkerEnum(MainMap.Position,GMapResources.EnumMarkerCustom.MarkerA);
                Route();
            }
            else
            {
                MainMap.Position = _gMapMarkerB.Position;
            }
        }
        #endregion

        private void trackBarMap_EditValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }

        private void shPicture_LayLoTrinhTheoGoogle_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(RouteThreadGoogle)).Start();        
        }

        

       

       
    }
}
