using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GMap.NET;
using Taxi.Business;
using Taxi.Common.Attributes;
using Taxi.Common.Attributes.Validator;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Data.FastTaxi;
using Taxi.Services;
using Taxi.Utils.Enums;
using Taxi.Utils.Enums.DieuXeChieuVe;
using Taxi.Business.Staxi;
using Taxi.Business.DM;

namespace Taxi.Controls.FastTaxis.TaxiTrip
{
    public partial class frmUpdateTrip : FormBase
    {
        public frmUpdateTrip()
        {
            InitializeComponent();
        }
        public frmUpdateTrip(XeDiDuongDai model)
        {
            _model = model;
            InitializeComponent();
        }
        #region Field

        private int h;
        private frmUpdateTrip_Map _bando;
        private float xe_lat;
        private float xe_lng;
        private int pic1;
        private int loaiXe;
      
        /// <summary>
        /// Tổng tiền của Trip đề cử
        /// </summary>
        float G_TongTien = 0;          
        private double Distance = 0;
        private XeDiDuongDai _model;
        private bool IsProcess = false;
        private LoTrinh LoTrinh;
        public XeDiDuongDai Model
        {
            get { return _model ?? (_model = new XeDiDuongDai()); }
        }
        #endregion

        #region Hàm xử lý
      
        /// <summary>
        /// đẩy dữ liệu lên form
        /// </summary>
        public void DoFill()
        {
            try
            {
                txtXe.EditValue = Model.FK_SoHieuXe;
                txtDienThoai.EditValue = Model.SoDienThoai;
                txtTenLaiXe.Text = Model.TenLaiXe;
                auDiaChiDon.Text = Model.DiaDiemDi;
                auDiaChiDon.ReSearch();
                auDiaChiDon.TempLat = Model.Di_ViDo;
                auDiaChiDon.TempLng = Model.Di_KinhDo;
                auDiaChiTra.Text = Model.DiaDiemDen;
                auDiaChiTra.ReSearch();
                auDiaChiTra.TempLat = Model.Den_ViDo;
                auDiaChiTra.TempLng = Model.Den_KinhDo;

                this.LoTrinh.Distance = Model.KmDuKien;
                this.LoTrinh.LoTrinh_DiaChi = Model.LoTrinh;
                this.LoTrinh.LoTrinh_ToaDo = Model.LoTrinh_Diem;
                if (Model.Is1Chieu)
                {
                    ckb1Chieu.Checked = true;
                }
                else
                {
                    ckb2Chieu.Checked = true;
                }
                ckbFastTaxi.Checked = Model.isChiaSeChuyenDi;
                lue_TrangThai.EditValue = Model.TrangThai;
                lue_TrangThaiDuyet.EditValue = Model.TrangThaiDuyet;
                txtCoDau.EditValue = Model.CoDau;
                txtCoCuoi.EditValue = Model.CoCuoi;
                deGioDon.EditValue = Model.ThoiDiemDi;
                deGioTra.EditValue = Model.ThoiDiemVe;
                txtTongTien.EditValue = Model.TongTien;
                txtGhiChu.Text = Model.GhiChu;
                btnHuy.Visible = true;
                txtKmDuKien.EditValue = Model.KmDuKien;
                txtLoTrinh.Text = Model.LoTrinh;
                deTGDuKienDen.EditValue = Model.TGDuKien;
                txtTienDuKien.EditValue = Model.TienDuKien;
                G_TongTien = Model.TienDuKien;
                DataTable dt = XeDiDuongDai.Inst.GetThongTinXeVaLaiXeTheoSoXe(txtXe.EditValue.To<string>().Trim());
                if (dt.Rows.Count > 0)
                {
                    this.loaiXe = dt.Rows[0]["LoaiXeID"] == DBNull.Value ? 0 : dt.Rows[0]["LoaiXeID"].To<int>();
                }
                Xe objXe = new Xe().GetChiTietXe(_model.FK_SoHieuXe);
                if (objXe != null)
                {
                    lblBienSoXe.Text = objXe.BienKiemSoat;
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DoFill: ", ex);
            }

        }

        /// <summary>
        /// đưa dữ liệu vào model từ form
        /// </summary>
        public void DoParse()
        {
            try
            {
                if (Model.Line == 0)
                {
                    Model.Line = ThongTinCauHinh.CacLineCuaTaxiOperation.Split(';').First().To<int>();
                }
                Model.FK_SoHieuXe = txtXe.EditValue.To<string>();
                Model.SoDienThoai = txtDienThoai.Text;
                Model.TenLaiXe = txtTenLaiXe.Text;
                Model.DiaDiemDi = auDiaChiDon.Text;
                Model.FK_TinhThanhDiID = auDiaChiDon.TinhId;
                Model.FK_QuanHuyenDiID = auDiaChiDon.HuyenId;
                Model.DiaDiemDen = auDiaChiTra.Text;
                Model.FK_TinhThanhDenID = auDiaChiTra.TinhId;
                Model.FK_QuanHuyenDenID = auDiaChiTra.HuyenId;
                if (!string.IsNullOrEmpty(txtKmDuKien.Text))
                    Model.KmDuKien = txtKmDuKien.Text.To<int>();
                else Model.KmDuKien = 0;
                if (deTGDuKienDen.DateTime > DateTime.MinValue)
                    Model.TGDuKien = deTGDuKienDen.DateTime;
                else Model.TGDuKien = DateTime.Now;

                if (txtTienDuKien.EditValue != null && txtTienDuKien.EditValue.ToString().Trim() != "")
                {
                    Model.TienDuKien = G_TongTien;
                }
                else Model.TienDuKien = 0;
                Model.LoTrinh = txtLoTrinh.Text;
                Model.LoTrinh_Diem = LoTrinh.LoTrinh_ToaDo;
                Model.Is1Chieu = ckb1Chieu.Checked;
                Model.isChiaSeChuyenDi = ckbFastTaxi.Checked;
                Model.TrangThai = lue_TrangThai.EditValue.To<int>();
                Model.TrangThaiDuyet = lue_TrangThaiDuyet.EditValue.To<int>();
                if (txtCoDau.EditValue != null && txtCoDau.EditValue.ToString() != string.Empty)
                    Model.CoDau = txtCoDau.EditValue.To<int>();
                else Model.CoDau = 0;
                if (txtCoCuoi.EditValue != null && txtCoCuoi.EditValue.ToString() != string.Empty)
                    Model.CoCuoi = txtCoCuoi.EditValue.To<int>();
                else
                    Model.CoCuoi = 0;
                Model.ThoiDiemDi = deGioDon.EditValue.To<DateTime>();
                if (deGioTra.EditValue == null)
                {
                    Model.ThoiDiemVe = null;
                }
                else
                    Model.ThoiDiemVe = deGioTra.EditValue.To<DateTime>();
                //float tongTien = 0;
                //float.TryParse(txtTongTien.EditValue.ToString(), out tongTien);   
                if (!string.IsNullOrEmpty(txtTongTien.Text) && txtTongTien.Text.Trim() != "")
                    Model.TongTien = txtTongTien.Text.To<decimal>();
                else
                {
                    Model.TongTien = 0;
                }
                Model.GhiChu = txtGhiChu.Text;

                Model.Xe_ViDo = xe_lat;
                Model.Xe_KinhDo = xe_lng;
                if (auDiaChiDon.TempLat > 0 && auDiaChiDon.TempLng > 0)
                {
                    Model.Di_ViDo = auDiaChiDon.TempLat;
                    Model.Di_KinhDo = auDiaChiDon.TempLng;
                }
                else
                {
                    Model.Di_ViDo = auDiaChiDon.Lat;
                    Model.Di_KinhDo = auDiaChiDon.Lng;
                }
                if (auDiaChiTra.TempLat > 0 && auDiaChiTra.TempLng > 0)
                {
                    Model.Den_ViDo = auDiaChiTra.TempLat;
                    Model.Den_KinhDo = auDiaChiTra.TempLng;
                }
                else
                {
                    Model.Den_ViDo = auDiaChiTra.Lat;
                    Model.Den_KinhDo = auDiaChiTra.Lng;
                }
                Model.IsKetThuc = ckb_KetThuc.Checked;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DoParse: ", ex);                
            }

        }
        /// <summary>
        /// Kiểm tra dữ liệu
        /// </summary>
        /// <returns></returns>
        public bool DoVaidate()
        { 
            ShowError("");
            if (!KiemTraDuLieuCoThayDoiChua())
            {
                ShowError("Bạn chưa thay đổi dữ liệu");
                txtXe.Focus();
                return false;
            }
           
            if (txtXe.EditValue == null || string.IsNullOrEmpty(txtXe.EditValue.To<string>().Trim()))
            {
                ShowError("Chưa nhập số xe");
                txtXe.Focus();
                return false;
            }
            else
            {
                Xe objXe = new Xe().GetChiTietXe(txtXe.Text);
              
                if (objXe==null)
                {
                    ShowError("Số xe không thuộc xe hệ thống");
                    txtXe.Focus();
                    return false;
                }
                if ((Model == null || Model.ID==0)&& XeDiDuongDai.Inst.CheckXeChuaKetThucDuongDai(txtXe.EditValue.To<string>().Trim()))
                {
                    ShowError(string.Format("Xe {0} chưa kết thúc cuốc đường dài", txtXe.EditValue.To<string>().Trim()));
                    txtXe.Focus();
                    return false;
                }
            }
           
            if (txtDienThoai.EditValue == null || string.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                ShowError("Chưa nhập số điện thoại");
                txtDienThoai.Focus();
                return false;
            }
            else
            {
                var validatePhone = new ValidatorPhoneAttribute();
                validatePhone.IsSim = true;
                validatePhone.SetData(txtDienThoai.EditValue, txtDienThoai.EditValue, "Điện thoại lái xe");
                if (!validatePhone.Validate())
                {
                    ShowError("Số điện thoại không đúng định dạng.");
                    txtDienThoai.Focus();
                    return false;

                }
                if ((Model == null || Model.ID == 0) && XeDiDuongDai.Inst.CheckSoDienThoai(txtDienThoai.Text))
                {
                    ShowError(string.Format("Số điện thoại {0} trùng xe chưa kết thúc cuốc đường dài", txtDienThoai.Text));
                    txtDienThoai.Focus();
                    return false;
                }
            }
           
            //if (string.IsNullOrEmpty(txtTenLaiXe.Text.Trim()))
            //{
            //    ShowError("Chưa nhập tên lái xe");
            //    txtTenLaiXe.Focus();
            //    return false;
            //}
            if (auDiaChiDon.DataRowSelect == null)
            {
                ShowError("Chưa chọn đúng địa chỉ đón");
                auDiaChiDon.Focus();
                return false;
            }
            if (auDiaChiTra.DataRowSelect == null)
            {
                ShowError("Chưa chọn đúng địa chỉ trả");
                auDiaChiTra.Focus();
                return false;
            }            
            // txtKmDuKien.EditValue = Model.KmDuKien;
            // deTGDuKienDen.DateTime = Model.TGDuKien;
            //txtLoTrinh.EditValue = Model.LoTrinh;
            //if (Model.Is1Chieu)
            //{
            //    ckb1Chieu.Checked = true;
            //}
            //else
            //{
            //    ckb2Chieu.Checked = true;
            //}
            //ckbFastTaxi.Checked = Model.isChiaSeChuyenDi;
            //LueTrangThai.EditValue = Model.TrangThai;
            ////Chờ duyệt
            if (groupBox_ExtendInfo.Visible)
            {
               // if (!string.IsNullOrEmpty(txtCoDau.Text) && !string.IsNullOrEmpty(txtCoCuoi.Text) &&
               //txtCoDau.EditValue.To<long>() > txtCoCuoi.EditValue.To<long>())
               // {
               //     ShowError("Cơ đầu phải nhỏ hơn cơ cuối");
               //     txtCoCuoi.Focus();
               //     return false;
               // }
                //if (deGioDon.EditValue != null && deGioDon.EditValue.To<DateTime>() < deThoiDiem.EditValue.To<DateTime>())
                //{
                //    ShowError("Giờ đón phải lơn hơn giờ hiện tại");
                //    deGioDon.Focus();
                //    return false;
                //}
                if (deGioDon.EditValue != null && deGioTra.EditValue != null &&
                    deGioDon.DateTime >= deGioTra.DateTime)
                {
                    ShowError("Giờ đón phải nhỏ hơn giờ trả");
                    deGioDon.Focus();
                    return false;
                }
            }
            int trangThai = lue_TrangThai.EditValue.To<int>();
            if ((trangThai == (int)Enum_XeBaoDiDuongDai_TrangThai.DaGhepKhach || trangThai == (int)Enum_XeBaoDiDuongDai_TrangThai.KhachDaLenXe) && (Model.ID == 0 || !Model.CheckTripDaGhepChua(Model.ID)))
            {
                ShowError(string.Format("Xe {0} chưa có cuốc khách nào chấp nhận",txtXe.Text));
                lue_TrangThai.Focus();
                return false;
            }
            if (ckb_KetThuc.Checked && trangThai == (int)Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach)
            {
                var rs=new MessageBox.MessageBoxBA().Show("Cuốc đang ở trạng thái chờ ghép khách, bạn có chắc chắn kết thúc không?", "Thông báo",MessageBox.MessageBoxButtonsBA.YesNo);
                if (rs== "Yes")
                {
                    return true;
                }
                else return false;
            }
            
            //txtTongTien.EditValue = Model.TongTien; 
            //txtGhiChu.Text = Model.GhiChu;
            return true;
        }
        /// <summary>
        /// Thực hiện thao tác lưu trữ dữ liệu.
        /// </summary>
        public void DoSave()
        {
            var fw = new ProgressBar();
            try                 
            {
                if (Model.ID <= 0)
                {
                    Model.CreatedByUser = ThongTinDangNhap.USER_ID;
                    Model.CreatedDate = TaxiReturn_Process.timerServer;
                    Model.Insert();

                    #region Xử lý thông tin gửi lên server

                    if (ckb1Chieu.Checked && ckbFastTaxi.Visible && ckbFastTaxi.Checked && lue_TrangThaiDuyet.EditValue.To<int>() == (int)Enum_XeBaoDiDuongDai_TrangThaiDuyet.DaDuyet)
                    {
                        if (Distance >= 500)
                        {
                            ShowError("Hệ thống Staxi không hỗ trợ cuốc đi đường dài lớn hơn 500 km");
                        }
                        else
                        {
                            fw.Show();
                            var rs = TaxiReturn_Process.AddTrip(Model);
                            fw.Close();
                            if (rs!= null && rs.AddTripSuccess)
                            {
                                //Add Trip lên server Thành Công
                                Model.IsAddedStaxi = true;
                            }
                            else
                            {
                                //Add Trip lên server thất bại
                                Model.IsAddedStaxi = false;
                            }
                            // cập nhật trạng thái
                            Model.UpdateIsAddedStaxi(Model.ID,ThongTinDangNhap.USER_ID,Model.IsAddedStaxi);
                            #region Quét xem có booking đề cử cho cuốc chiều về này hay ko
                            //kiểm tra Có danh sách các book đề cử cho xe này.
                            if (rs != null && rs.TripBookingsSend != null && rs.TripBookingsSend.Bookings.Length > 0)
                            {
                                frmListBooking frm = new frmListBooking()
                                {
                                    rs = rs.TripBookingsSend,
                                    Books = rs.TripBookingsSend.Bookings,
                                    G_TongTien = G_TongTien
                                };
                                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (frm.Book != null) //chấp nhận
                                    {
                                        var book = new Booking();
                                        book.PK_BooID = frm.Book.PK_BooID;

                                        if (!book.GetByKey()) //trường hợp server chưa đẩy về thì sẽ tự động thêm book đã đc chấp nhận.
                                        {
                                            //Tạo book mới trên hệ thống.
                                            // dán lại xe nào được chấp nhận.
                                            book = ParseBooking(frm.Book);
                                            book.FK_TaxiReturn = rs.TripBookingsSend.TripID;
                                            book.OpVehicle = Model.FK_SoHieuXe;
                                            book.OpStatus = (int)Enum_Bookings_OpStatus.ChapNhan;
                                            book.OpAcceptedUser = ThongTinDangNhap.USER_ID;
                                            book.OpAcceptedTime = book.GetTimeServer();
                                            book.CreatedDate = book.OpAcceptedTime;
                                            book.Insert();
                                            //Tạo book deltail trên hệ thống.
                                            BookingsDetail detail = new BookingsDetail();
                                            detail.TripID = Model.ID;
                                            detail.FK_BookID = book.PK_BooID;
                                           // detail.CalF
                                            var AB = TaxiReturn_Process.LayLoTrinh(Model.Den_ViDo, Model.Den_KinhDo, book.FromLat, book.FromLng);
                                            detail.ABRoute = AB.LoTrinh_ToaDo;
                                            var CD = TaxiReturn_Process.LayLoTrinh(book.ToLat, book.ToLng, Model.Di_ViDo, Model.Di_KinhDo);
                                            detail.CDRoute= CD.LoTrinh_ToaDo;
                                            detail.Status = (int)Enum_BookingsDetail_Status.DuocChapNhan;
                                            detail.DateUpdated = TaxiReturn_Process.timerServer;
                                            detail.Insert();
                                        }
                                        else
                                        {
                                            // dán lại xe nào được chấp nhận.
                                            book.FK_TaxiReturn = rs.TripBookingsSend.TripID;
                                            book.OpVehicle = Model.FK_SoHieuXe;
                                            book.OpStatus = (int)Enum_Bookings_OpStatus.ChapNhan;
                                            book.OpAcceptedUser = ThongTinDangNhap.USER_ID;
                                            book.OpAcceptedTime = book.GetTimeServer();
                                            book.Update();
                                        }

                                        book.DaDieuDuocXe(frm.Book.PK_BooID, rs.TripBookingsSend.TripID, ThongTinDangNhap.USER_ID, ThongTinCauHinh.CompanyID);
                                    }
                                    else // Hủy điều
                                    {
                                        //Xác nhận hủy điều.
                                        if (new MessageBox.MessageBoxBA().Show("Bạn có muốn hủy cuốc này không","Thông báo",MessageBox.MessageBoxButtonsBA.YesNo) == "Yes")
                                        {
                                            if (_model != null && _model.ID > 0)
                                            {
                                                _model.UpdatedByUser = ThongTinDangNhap.USER_ID;
                                                _model.HuyDieu();
                                                TaxiReturn_Process.TripUpdateStatus(_model.ID, ThongTinCauHinh.CompanyID,Services.FastTaxi_OperationService.Trip.Status.HuyDieu);
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }

                    #endregion                        

                    DialogResult = DialogResult.OK;
                    this.BeginInvoke((Action)(() => this.Close()));
                }
                else
                {
                    Model.UpdatedByUser = ThongTinDangNhap.USER_ID;
                    Model.UpdatedDate = TaxiReturn_Process.timerServer;
                    Model.Update();

                    #region Gửi lên server
                        if (ckb1Chieu.Checked && ckbFastTaxi.Visible && ckbFastTaxi.Checked && lue_TrangThaiDuyet.EditValue.To<int>() == (int)Enum_XeBaoDiDuongDai_TrangThaiDuyet.DaDuyet)
                        {
                            if (Distance >= 500)
                            {
                                ShowError("Hệ thống Staxi không hỗ trợ cuốc đi đường dài lớn hơn 500 km");
                            }
                            else
                            {
                                //nếu gửi rồi thì sẽ EditTrip
                                if (Model.IsAddedStaxi)
                                    TaxiReturn_Process.EditTrip(Model);
                                else // Chưa gửi lên thì sẽ AddTrip
                                {
                                    var rs = TaxiReturn_Process.AddTrip(Model);
                                    if (rs != null)
                                    {
                                        // cập nhật trạng thái
                                        Model.UpdateIsAddedStaxi(Model.ID, ThongTinDangNhap.USER_ID, rs.AddTripSuccess);
                                    }
                                }
                            }
                        }
                    #endregion
                    
                    DialogResult = DialogResult.OK;
                    try
                    {
                        this.BeginInvoke((Action)(() => this.Close()));
                    }
                    catch (Exception ex) { }
                }
                if (Model.IsKetThuc)
                {
                    Model.UpdateStatus(Model.ID, Enum_XeBaoDiDuongDai_TrangThai.None, ThongTinDangNhap.USER_ID, true);
                    TaxiReturn_Process.TripUpdateStatus(Model.ID, ThongTinCauHinh.CompanyID, Services.FastTaxi_OperationService.Trip.Status.KetThuc);
                }

            }
            catch (Exception ex)
            {
                try
                {
                    fw.Invoke((MethodInvoker)fw.Close);

                }
                catch(Exception ex2) 
                {
                    new MessageBox.MessageBoxBA().Show("fw:" + ex2.Message);
                }

                new MessageBox.MessageBoxBA().Show("Lỗi ngoại lệ xảy ra:" + ex.Message);
            }
        }

        /// <summary>
        /// parse Booking từ book của service trả về
        /// </summary>
        /// <param name="bookingItem"></param>
        /// <returns></returns>
        private Booking ParseBooking(Services.FastTaxi_OperationService.Booking bookingItem)
        {
            Booking objBooking = new Booking();
            objBooking.PK_BooID = bookingItem.PK_BooID;
            objBooking.Mobile = bookingItem.Mobile;
            objBooking.Password = bookingItem.Password;
            objBooking.ClientKey = bookingItem.ClientKey;
            objBooking.FromName = bookingItem.FromName;
            objBooking.FromAddress = bookingItem.FromAddress;
            objBooking.FromLat = bookingItem.FromLat;
            objBooking.FromLng = bookingItem.FromLng;
            objBooking.ToName = bookingItem.ToName;
            objBooking.ToAdress = bookingItem.ToAdress;
            objBooking.ToLat = bookingItem.ToLat;
            objBooking.ToLng = bookingItem.ToLng;
            objBooking.GPSLat = bookingItem.GPSLat;
            objBooking.GPSLng = bookingItem.GPSLng;
            objBooking.FromTime = bookingItem.FromTime;
            objBooking.ToTime = bookingItem.ToTime;
            objBooking.DateCreated = bookingItem.DateCreated;
            objBooking.Status = (int)bookingItem.Status;
            objBooking.IsCancel = bookingItem.IsCancel;
            objBooking.IsSchedule = bookingItem.IsSchedule;
            objBooking.Description = bookingItem.Note;
            objBooking.CreatedDate = objBooking.GetTimeServer();
            objBooking.OpLastModifyTime = objBooking.CreatedDate.Value;
            objBooking.BC_Route_Distance = (float)bookingItem.BC_Route.Distance;
            objBooking.BC_Route = bookingItem.BC.Coordinates;
            objBooking.OpLine = Model.Line;
            return objBooking;
        }
        public void ShowError(string msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowError), msg);
                return;
            }
               
            lblMsg.Text = msg;
            lblMsg.ForeColor = Color.Red;
        }
        /// <summary>
        /// hàm sử dụng khi đang xử lý trong thread và thao tác thay đổi tới TextBox trên form
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="o"></param>
        public void AppendTextBox(TextBox edit, string o)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<TextBox, string>(AppendTextBox), new object[] { edit, o });
                return;
            }
            edit.Text = o;
        }
        /// <summary>
        /// hàm sử dụng khi đang xử lý trong thread và thao tác thay đổi tới TextEdit trên form
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="o"></param>
        public void AppendTextBox(TextEdit edit, object o)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<TextEdit, object>(AppendTextBox), new object[] {edit, o});
                return;
            }
            edit.EditValue = o;
        }
        /// <summary>
        /// hàm xử lý địa chỉ chạy ngầm để cải thiện tốc độ load form.
        /// -Trong khi đó có 1 cờ bật lên.không cho phép lưu hoặc tắt form trong khi đang xử lý.
        /// </summary>
        private void ProcessAutoDiaChi()
        {
            G_TongTien = 0;
            AppendTextBox(txtKmDuKien, string.Empty);
            AppendTextBox(deTGDuKienDen, string.Empty);
            AppendTextBox(txtTienDuKien, string.Empty);
            AppendTextBox(txtLoTrinh, string.Empty);
            IsProcess = true;
            PointLatLng start = auDiaChiDon.TempLat > 0 ? new PointLatLng(auDiaChiDon.TempLat, auDiaChiDon.TempLng) : new PointLatLng(auDiaChiDon.Lat, auDiaChiDon.Lng);
            PointLatLng end = new PointLatLng(auDiaChiTra.Lat, auDiaChiTra.Lng);

          var loTrinh= TaxiReturn_Process.LayLoTrinh(start,end);
          if (!string.IsNullOrEmpty(loTrinh.LoTrinh_DiaChi))
          {
              try
              {
                  this.LoTrinh = loTrinh;
                  string address = loTrinh.LoTrinh_DiaChi;
                  Distance = (double)loTrinh.Distance;
                  TinhTienTheoKm objTinhTien = new TinhTienTheoKm(this.loaiXe, Distance.To<int>());
                  G_TongTien = objTinhTien.TongTien1Chieu;
                  AppendTextBox(txtKmDuKien, Distance.To<int>());
                  AppendTextBox(deTGDuKienDen, deGioDon.DateTime.AddHours(Distance / 40));
                  AppendTextBox(txtTienDuKien, G_TongTien);
                  AppendTextBox(txtLoTrinh, address.RemoveRoutePr());
              }
              catch (Exception)
              {
                  AppendTextBox(txtLoTrinh, "Không có lộ trình");
              }
            }
            
            IsProcess = false;
        }
        [MethodWithKey(Keys = Keys.Control | Keys.B)]
        private void ShowBanDo()
        {
            try
            {
                _bando = new frmUpdateTrip_Map();
                PointLatLng? start = null;
                PointLatLng? end = null;
                lblMsg.Text = "";
                {
                    if (auDiaChiDon.TempLat > 0 && auDiaChiDon.TempLng > 0)
                    {
                        start = new PointLatLng(auDiaChiDon.TempLat, auDiaChiDon.TempLng);
                    }
                    else if (auDiaChiDon.TinhId > 0) start = new PointLatLng(auDiaChiDon.Lat, auDiaChiDon.Lng);
                }


                {
                    if (auDiaChiTra.TempLat > 0 && auDiaChiTra.TempLng > 0)
                    {
                        end = new PointLatLng(auDiaChiTra.TempLat, auDiaChiTra.TempLng);
                    }
                    else if (auDiaChiTra.TinhId > 0) end = new PointLatLng(auDiaChiTra.Lat, auDiaChiTra.Lng);
                }

                _bando.ShowBanDo(start, end, auDiaChiDon.Text, auDiaChiTra.Text);
                _bando.pic = pic1;
                _bando.SoXe = txtXe.Text.Trim();
                _bando.LoaiXeId = this.loaiXe;
                if (_model != null)
                {
                    var _LoTrinh = new LoTrinh();
                    _LoTrinh.Distance = _model.KmDuKien;
                    _LoTrinh.LoTrinh_DiaChi = _model.LoTrinh;
                    _LoTrinh.LoTrinh_ToaDo = _model.LoTrinh_Diem;
                    _LoTrinh.ListPoint = TaxiReturn_Process.ConvertToPointLatLng(_LoTrinh.LoTrinh_ToaDo);
                    _bando.LoTrinh = _LoTrinh;
                }
                _bando.ShowDialog();
                pic1 = 0;
                if (_bando.IsOk)
                {
                    if (auDiaChiDon.Text != _bando.AddressA)
                    {
                        auDiaChiDon.Text = _bando.AddressA;
                        auDiaChiDon.ReSearch();
                        auDiaChiDon.TempLat = (float)_bando._gMapMarkerA.Position.Lat;
                        auDiaChiDon.TempLng = (float)_bando._gMapMarkerA.Position.Lng;
                        auDiaChiDon.IsChangeText = true;
                    }
                    if (auDiaChiTra.Text != _bando.AddressB)
                    {
                        auDiaChiTra.Text = _bando.AddressB;
                        auDiaChiTra.ReSearch();
                        auDiaChiTra.TempLat = (float)_bando._gMapMarkerB.Position.Lat;
                        auDiaChiTra.TempLng = (float)_bando._gMapMarkerB.Position.Lng;
                        auDiaChiTra.IsChangeText = true;
                    }
                    if (auDiaChiDon.TinhId > 0 && auDiaChiTra.TinhId > 0)
                    {
                        //  new Thread(new ThreadStart(ProcessAutoDiaChi)).Start();
                    }
                    txtKmDuKien.EditValue = _bando.Distance;
                    txtKmDuKien.IsChangeText = true;
                    deTGDuKienDen.EditValue = deGioDon.DateTime.AddHours(_bando.time);
                    deTGDuKienDen.IsChangeText = true;
                    this.LoTrinh = _bando.LoTrinh;
                    txtLoTrinh.Text = LoTrinh.LoTrinh_DiaChi;
                    txtLoTrinh.IsChangeText = true;
                    G_TongTien = _bando.TienDuKien;
                    txtTienDuKien.EditValue = G_TongTien;
                    txtTienDuKien.IsChangeText = true;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ShowBanDo: ", ex);                
            }
        }
        [MethodWithKey(Keys = Keys.Control | Keys.Space)]
        private void ShowHideThongTinThem()
        {
            groupBox_ExtendInfo.Visible = !groupBox_ExtendInfo.Visible;
            int r = this.Height;
            if (groupBox_ExtendInfo.Visible)
                this.Height = r + h;
            else
                this.Height = (r - h);
        }
        /// <summary>
        /// Kiểm thay đổi dữ liệu trên form
        /// </summary>        
        private bool KiemTraDuLieuCoThayDoiChua()
        {
            return this.CheckDataForm();
        }
        #endregion

        #region Event

        private void frmXeBaoDiDuongDai_Load(object sender, System.EventArgs e)
        {
            this.BindShControl();
            ckb1Chieu.Checked = true;
            this.shPicture1.EditValue = global::Taxi.Controls.Properties.Resources.question;
            h = groupBox_ExtendInfo.Height > 0 ? groupBox_ExtendInfo.Height : 201;
            if (!ThongTinCauHinh.FT_ChieuVe_CoDuyet)
            {
                shLabel13.Visible = false;
                lue_TrangThaiDuyet.Visible = false; 
            }
            else
            {
                #region kiểm tra Quyền
                if (ThongTinDangNhap.USER_ID.ToLower()!="Admin".ToLower()&& !ThongTinDangNhap.HasPermission(StaxiPermission.DuyetXeDiDuongDai))
                {
                    shLabel13.Visible = false;
                    lue_TrangThaiDuyet.Visible = false;
                }
                #endregion
            }
            if (!ThongTinCauHinh.FT_ChieuVe_CoChotCo)
            {
                ShowHideThongTinThem();
            }
            if (_model != null)
            {
                DoFill();
                txtXe.Enabled = false; 
                txtDienThoai.Focus();
            }
            else
            {
                lue_TrangThai.EditValue = (int)Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach;
                txtXe.Focus();
            }
            if (_model == null || _model.ID == 0) // Thêm mới
            {
                lblKetThuc.Visible = false;
                ckb_KetThuc.Visible = false;
                lue_TrangThai.BindNew();
            }
        }

        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            if (DoVaidate()) // kiểm tra dữ liệu/
            {
                DoParse();
                if (IsProcess) // nếu đang xử lý thì sẽ hiển thị process.
                {
                    Action a = () =>
                    {
                        var frm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ giây lát.", "Hệ thống đang Xử lý....");
                        while (IsProcess)
                        {
                            frm.Refresh();
                            Thread.Sleep(100);
                        }
                        frm.Close();
                        DoSave();
                    };
                    new Thread(() => a()).Start();
                    return;
                }
                DoSave();
            }
        }

        private void auDiaChiDon_EventSelectAutoComplete(System.Data.DataRow row)
        {
            if (auDiaChiDon.TinhId==0) auDiaChiDon.ReSearch();
            if (auDiaChiTra.TinhId == 0) auDiaChiTra.ReSearch();
            if (auDiaChiDon.TinhId > 0 && auDiaChiTra.TinhId > 0)
            {
                txtKmDuKien.EditValue = null;
                deTGDuKienDen.EditValue = null;
                new Thread(new ThreadStart(ProcessAutoDiaChi)).Start();
            }       
        }

        private void txtXe_Leave(object sender, EventArgs e)
        {
            if (txtXe.IsForceChangeText && txtXe.Text != "")
            {
                try
                {
                    lblMsg.Text = string.Empty;
                    lblBienSoXe.Text = "";
                    Xe objXe = new Xe().GetChiTietXe(txtXe.Text);
                    if (objXe != null)
                    {
                        txtDienThoai.EditValue = objXe.DienThoai;
                        txtTenLaiXe.EditValue = objXe.TenNhanVien;
                        this.loaiXe = objXe.LoaiXeID;
                        lblBienSoXe.Text = objXe.BienKiemSoat;
                    }
                    var xe = WCFService_Common.GetXeOnlineBySHX(txtXe.Text);
                    if (xe != null)
                    {
                        // lblBienSoXe.Text = xe.BienSoXe;
                        float lat = (float) xe.ViDo;
                        float lng = (float) xe.KinhDo;
                        auDiaChiDon.Text = string.Empty;
                        if (lng > 0)
                        {
                            string address = Service_Common.GetAddressByGeoBA(lat, lng).RemoveRoutePr();
                            if (!string.IsNullOrEmpty(address) && address.Trim() != "*")
                            {
                                auDiaChiDon.Text = address;
                                auDiaChiDon.ReSearch();
                                auDiaChiDon.TempLat = lat;
                                auDiaChiDon.TempLng = lng;
                            }
                        }
                        xe_lat = lat;
                        xe_lng = lng;
                        Model.BienSoXe = xe.BienSoXe;
                    }
                    auDiaChiDon_EventSelectAutoComplete(null);
                    if (txtDienThoai.EditValue == null || txtDienThoai.Text == string.Empty)
                    {
                        txtDienThoai.Focus();
                    }
                    else if (string.IsNullOrEmpty(auDiaChiDon.Text)) auDiaChiDon.Focus();
                    else
                        auDiaChiTra.Focus();
                    if (XeDiDuongDai.Inst.CheckXeChuaKetThucDuongDai(txtXe.EditValue.To<string>().Trim()))
                    {
                        ShowError(string.Format("Xe {0} chưa kết thúc cuốc đường dài",
                            txtXe.EditValue.To<string>().Trim()));
                    }
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("txtXe_Leave: ",ex);
                }
            }
        }

        private void deGioDon_EditValueChanged(object sender, EventArgs e)
        {
            if (txtKmDuKien.EditValue != null && txtKmDuKien.EditValue != "")
            {
                deTGDuKienDen.EditValue = deGioDon.DateTime.AddHours(txtKmDuKien.EditValue.To<Double>()/40);
            }

        }

        private void btnBanDo_Click(object sender, EventArgs e)
        {
            ShowBanDo();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Confirm("Bạn có muốn hủy không?"))
                {
                    if (_model != null && _model.ID > 0)
                    {
                        _model.UpdateStatus(_model.ID, Enum_XeBaoDiDuongDai_TrangThai.HuyDieu, ThongTinDangNhap.USER_ID, true);
                        TaxiReturn_Process.TripUpdateStatus(_model.ID, ThongTinCauHinh.CompanyID, Services.FastTaxi_OperationService.Trip.Status.HuyDieu);
                    }
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnHuy_Click: ", ex);                
            }
        }

        private bool flgckbchieu = false;

        private void ckb1Chieu_CheckedChanged(object sender, EventArgs e)
        {
            if (!flgckbchieu)
                flgckbchieu = true;
            ckb2Chieu.Checked = !ckb1Chieu.Checked;
            if (ckb1Chieu.Checked)
            {
                ckbFastTaxi.Visible = true;
                shPicture1.Visible = true;
                ckbFastTaxi.Checked = true;
            }
            flgckbchieu = false;
        }

        private void ckb2Chieu_CheckedChanged(object sender, EventArgs e)
        {
            if (!flgckbchieu)
                flgckbchieu = true;
            ckb1Chieu.Checked = !ckb2Chieu.Checked;
            if (ckb2Chieu.Checked)
            {
                ckbFastTaxi.Visible = false;
                shPicture1.Visible = false;
                ckbFastTaxi.Checked = false;
            }
            flgckbchieu = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (((PictureBox) sender).Name == "pictureBox1")
                pic1 = 1;
            else pic1 = 2;
            ShowBanDo();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowHideThongTinThem();
        }
        #endregion

        private void frmXeBaoDiDuongDai_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                if (KiemTraDuLieuCoThayDoiChua())
                {
                    var rs = new MessageBox.MessageBoxBA().Show("Bạn đã thay đổi dữ liệu,bạn có muốn lưu không?","Thông báo",MessageBox.MessageBoxButtonsBA.YesNoCancel);
                    if (rs.ToLower() == "YES".ToLower())
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                      //  e.Cancel = true;
                        if (DoVaidate())
                        {
                            DoParse();
                            DoSave();
                        }
                       
                        // btnLuu.PerformClick();
                    }
                    else if (rs.ToLower() == "Cancel".ToLower())
                    {
                     
                        e.Cancel = true;
                    }
                    DialogResult = System.Windows.Forms.DialogResult.OK;

                }
            }
        }

        private void auDiaChiTra_Leave(object sender, EventArgs e)
        {
            if (auDiaChiTra.IsForceChangeText)
            {
                auDiaChiTra.ReSearch();
                new Thread(new ThreadStart(ProcessAutoDiaChi)).Start();
            }
        }

        private void auDiaChiDon_Leave(object sender, EventArgs e)
        {
            if (auDiaChiDon.IsForceChangeText)
            {
                auDiaChiDon.ReSearch();
                new Thread(new ThreadStart(ProcessAutoDiaChi)).Start();
            }
        }

        private void lue_TrangThai_EditValueChanged(object sender, EventArgs e)
        {
            if (lue_TrangThai.EditValue != null)
            {
               if( lue_TrangThai.EditValue.To<int>()==(int)Enum_XeBaoDiDuongDai_TrangThai.HuyDieu){
                   ckb_KetThuc.Enabled = false;
                   ckb_KetThuc.Checked = true;
                  
               }else
               {
                   ckb_KetThuc.Enabled = true;
                   ckb_KetThuc.Checked = false;
               }
               
            }
        }

        int timemsg = 5;
        private void timer_Msg_Tick(object sender, EventArgs e)
        {
            timemsg--;
            if (timemsg <= 0)
            {
                lblMsg.Text = string.Empty;
                timer_Msg.Stop();
                timemsg = 5;
            }

        }

        private void lblMsg_TextChanged(object sender, EventArgs e)
        {
            if (lblMsg.Text != "")
                timer_Msg.Start();
        }

        private void txtXe_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (txtDienThoai.Text.Length <2)
            {
                return;
            }
            if (txtDienThoai.Text.Substring(0, 2) == "09")
            {
                txtDienThoai.Properties.MaxLength = 10;
            }
            else if (txtDienThoai.Text.Substring(0, 2) == "01")
            {
                txtDienThoai.Properties.MaxLength = 11;
            }
            else
            {
                txtDienThoai.Properties.MaxLength = 2;
            }
        }
    }
}
