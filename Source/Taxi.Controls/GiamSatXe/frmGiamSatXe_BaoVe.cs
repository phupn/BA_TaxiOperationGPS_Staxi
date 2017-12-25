using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Common.Attributes;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Extender;
using Taxi.Utils;
using Taxi.Services;
using Taxi.Business;
namespace TaxiOperation_BanCo.GiamSatXe
{
    public partial class frmGiamSatXe_BaoVe : FormBase
    {
        #region ==== Define ====
        private GiamSatXe_LienLac lienlac = new GiamSatXe_LienLac();
        DataTable dulieu;
        DataTable lydo;
        DateTime TimeServer;
        /// <summary>
        /// id của lý do báo về hết ca làm việc
        /// </summary>
        public const int GiamSatXe_Reasons_HetCaLamViec_ID = 1;
        #endregion

        #region ==== INI ====
        public frmGiamSatXe_BaoVe()
        {
            InitializeComponent();
            lookupEdit_BanCo_GiamSatXe_Reason.TypeReason = Enum_ReasonType.LyDoBaoVe;
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        #endregion

        #region ==== Function =====
        private bool ValidateData()
        {  

                if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); txtSoHieu.Focus(); return false; }
                if (txtChiSoVe.Text.Trim() == "") { lblmsg.Text = ("Bạn chưa nhập chỉ số về"); txtChiSoVe.Focus(); return false; }
                if (deGioVe.DateTime > TimeServer) { lblmsg.Text = "Giờ về không quá ngày hiện tại"; deGioVe.Focus(); return false; }
                if (lookupEdit_BanCo_GiamSatXe_Reason.Text.Trim() == "") { lblmsg.Text = ("Bạn chưa nhập lý do về"); lookupEdit_BanCo_GiamSatXe_Reason.Focus(); return false; }
                if (Int64.Parse(txtChiSoDi.Text) > Int64.Parse(txtChiSoVe.Text)) { lblmsg.Text = "Bạn phải nhập chỉ số về lớn hơn chỉ số đi"; txtChiSoVe.Focus(); return false; }
                if (deGioDi.DateTime > deGioVe.DateTime) { lblmsg.Text = "Bạn phải nhập giờ về lớn hơn giờ đi"; deGioVe.Focus(); return false; }
                if (txtGhiChu.Text.Length > 250) { lblmsg.Text = "Ghi chú có quá nhiều ký tự"; txtGhiChu.Focus(); return false; }

                else
                {
                    lblmsg.Text = "";
                }
                if (txtChiSoDi.Text.To<int>() == 0 || txtChiSoVe.Text.To<int>() == 0)
                {
                    lblmsg.Text = "Chỉ số đi và chỉ số về phải là số lớn hơn 0";
                    return false;
                } 
                if (TaxiOperation_Truck.Inst.CheckSoXe(txtSoHieu.Text) > 0)
                {
                    lblmsg.Text = string.Format("Số hiệu xe {0} chưa kết thúc cuốc khách", txtSoHieu.Text);
                    return false;
                }
                return true;

        }


        /// <summary>
        /// Làm mới form
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  08/09/2014   created
        /// </Modified>
        [MethodWithKey(Keys = Keys.F5)]
        private void LamMoi()
        {
            deGioDi.Text = "";
            deGioVe.DateTime = TimeServer.AddSeconds(-1);
            deGioDi.DateTime = deGioVe.DateTime;
            dulieu = lienlac.GetNVHoatDong_ForBaoVe();//.ToDataTableEnVang("SoHieuXe");
            txtSoHieu.Properties.DataSource = dulieu;
            txtSoHieu.Properties.DisplayMember = "SoHieuXe";
            txtSoHieu.Properties.ValueMember = "MaLaiXe";

            txtSoHieu.EditValue = null;
            txtChiSoDi.Text = string.Empty;
            txtChiSoVe.Text = string.Empty;
            lookupEdit_BanCo_GiamSatXe_Reason.EditValue = null;
            txtGhiChu.Text = string.Empty;
            lblmsg.Text = "";
            lblTenLaiXe.Text = "";
            ActiveControl = txtSoHieu;
            lookupEdit_BanCo_GiamSatXe_Reason.EditValue = GiamSatXe_Reasons_HetCaLamViec_ID;

        }
        #endregion

        #region ==== Event ====
        private void frmGiamSatXe_BaoVe_Load(object sender, EventArgs e)
        {
            TimeServer = Taxi.Business.CommonBL.GetTimeServer();

            LamMoi();
            //Binding dữ liệu vào các control
            this.BindShControl();
            txtSoHieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtSoHieu.Properties.Mask.EditMask = @"\d+";
        }
        // lưu thông tin xe báo về
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateData())
                {
                    string soHieuXe = txtSoHieu.GetColumnValue("SoHieuXe").ToString();
                    lienlac.GSX_BaoVe_XuLy(int.Parse(txtSoHieu.GetColumnValue("Id").ToString()),
                                            txtChiSoDi.EditValue,
                                            txtChiSoVe.EditValue,
                                            deGioVe.DateTime,
                                            lookupEdit_BanCo_GiamSatXe_Reason.GetColumnValue("Id").ToString(),
                                            txtGhiChu.Text,
                                            new Guid(),
                                            soHieuXe,
                                            txtSoHieu.GetColumnValue("MaLaiXe").ToString(),
                                            "Xe báo về - " + lookupEdit_BanCo_GiamSatXe_Reason.GetColumnValue("Reason").ToString(),
                                            Taxi.Business.ThongTinDangNhap.USER_ID,
                                            deGioDi.DateTime);
                    TaxiApplication.ServiceEnVang.EnVangProcess.SendLogoutDriver(soHieuXe);
                    LamMoi();
                    lblmsg.Text = "Xe báo về thành công";
                    lblmsg.ForeColor = Color.Blue;
                    lookupEdit_BanCo_GiamSatXe_Reason.ItemIndex = 0;

                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GiamSatXe_BaoVe", ex);
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Báo xe về không thành công";
                return;
            }

        }
    
        private void lueLyDoVe_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            string lydotxt = lookupEdit_BanCo_GiamSatXe_Reason.Text.Trim();
            if (lydotxt.Length > 0)
            {
                foreach (DataRow r in lydo.Rows)
                {
                    if (lydotxt.Equals(r["TenLyDo"]))
                    {
                        return;
                    }
                }
                try
                {
                    //Show dialog confirm
                    if (new Taxi.MessageBox.MessageBoxBA().Show("Bạn có muốn thêm mới lý do không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question) == Taxi.MessageBox.MessageBoxResult.Yes)
                    {
                        int ID = new StatusManagement().InsertLyDo(lookupEdit_BanCo_GiamSatXe_Reason.Text, StringTools.GetFirstsCharOfAString(lookupEdit_BanCo_GiamSatXe_Reason.Text), Taxi.Utils.Enum_ReasonType.LyDoBaoVe, 0);
                        //check ID đã insert thành công
                        if (ID <= 0) return ;
                        //
                        DataRow row = lydo.NewRow();
                        row["TenLyDo"] = e.DisplayValue;
                        row["id"] = ID;
                        (lookupEdit_BanCo_GiamSatXe_Reason.Properties.DataSource as DataTable).Rows.Add(row);
                        lookupEdit_BanCo_GiamSatXe_Reason.EditValue = ID;
                        e.Handled = true;
                    }
                }
                catch
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Đã xảy ra lỗi trong quá trình thêm mới lý do", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
        }
        private void txtSoHieu_TextChanged(object sender, EventArgs e)
        {
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); return ; }
            else lblmsg.Text = "";

        }

        private void txtSoHieu_Leave(object sender, EventArgs e)
        {
            //if (txtSoHieu.EditValue != null)
            //{
            //    if (!txtSoHieu.Text.Equals("") && !txtSoHieu.Text.Equals(" "))
            //    {
            //        txtChiSoDi.Text = txtSoHieu.GetColumnValue("ChiSoDi").ToString();
            //        //txtGhiChu.Text = txtSoHieu.GetColumnValue("GhiChu").ToString();
            //        deGioDi.DateTime = (DateTime)txtSoHieu.GetColumnValue("GioDi");
            //        string r = (string)txtSoHieu.GetColumnValue("TenNhanVien");
            //        if (r != "") lblTenLaiXe.Text = r;
            //        else lblTenLaiXe.Text = "";
            //    }
            //    //if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); return false; }
            //    //else lblmsg.Text = "";
            //}
        }

        private void txtSoHieu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (!txtSoHieu.Text.Equals("") && !txtSoHieu.Text.Equals(" "))
                if (txtSoHieu.EditValue != null)
                {
                    txtChiSoDi.Text = txtSoHieu.GetColumnValue("ChiSoDi").ToString();
                    //txtGhiChu.Text = txtSoHieu.GetColumnValue("GhiChu").ToString();
                    deGioDi.DateTime = (DateTime)txtSoHieu.GetColumnValue("GioDi");
                    string r = (string)txtSoHieu.GetColumnValue("TenNhanVien");
                    if (r != "") lblTenLaiXe.Text = r;
                    else lblTenLaiXe.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Đã xảy ra lỗi khi thay đổi giá trị của số hiệu xe";
            }
        }

        private void txtChiSoVe_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtChiSoDi.Text.Equals("")) { txtChiSoDi.Text = "0"; }
                if (txtChiSoVe.Text.Trim() == "") { lblmsg.Text = ("Bạn chưa nhập chỉ số về"); return; }
                if (Int64.Parse(txtChiSoDi.Text) > Int64.Parse(txtChiSoVe.Text)) { lblmsg.Text = "Bạn phải nhập chỉ số về lớn hơn chỉ số đi"; return ; }
                else lblmsg.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Chỉ số đi và chỉ số về phải là số";
            }
        }

        private void deGioVe_Leave(object sender, EventArgs e)
        {
            if (deGioVe.DateTime > TimeServer) { lblmsg.Text = "Giờ về không quá ngày hiện tại"; return; }
            if (deGioDi.DateTime > deGioVe.DateTime) { lblmsg.Text = "Bạn phải nhập giờ về lớn hơn giờ đi"; }
            else lblmsg.Text = "";
        }

        private void lueLyDoVe_Leave(object sender, EventArgs e)
        {
            lookupEdit_BanCo_GiamSatXe_Reason.Text = lookupEdit_BanCo_GiamSatXe_Reason.Text.TrimStart();
            if (lookupEdit_BanCo_GiamSatXe_Reason.Text.Trim() == "") { lblmsg.Text = ("Bạn chưa nhập lý do về"); return; }
            else lblmsg.Text = "";
        }

        private void deGioVe_TextChanged(object sender, EventArgs e)
        {
            if (deGioVe.DateTime > TimeServer) { lblmsg.Text = "Giờ về không quá ngày hiện tại"; return; }
            if (deGioDi.DateTime > deGioVe.DateTime) { lblmsg.Text = "Bạn phải nhập giờ về lớn hơn giờ đi"; }
            else lblmsg.Text = "";
        }

        private void txtSoHieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !txtSoHieu.IsPopupOpen)
            {
                txtChiSoVe.Focus();
            }
        }

        private void txtChiSoDi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                deGioDi.Focus();
            }
        }

        private void deGioDi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtChiSoVe.Focus();
            }
        }

        private void txtChiSoVe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                deGioVe.Focus();
            }
        }

        private void deGioVe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                lookupEdit_BanCo_GiamSatXe_Reason.Focus();
            }
        }

        private void lueLyDoVe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !lookupEdit_BanCo_GiamSatXe_Reason.IsPopupOpen)
            {
                txtGhiChu.Focus();
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLuu.Focus();
            }
        }

        private void txtSoHieu_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            txtChiSoVe.Focus();
        }
       
        private void txtChiSoDi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int result = 0;
            if (e.NewValue != null && int.TryParse(e.NewValue.ToString(), out result))
            {
                if (result < 0)
                {
                    e.NewValue = 0;
                    e.Cancel = true;
                }
            }
        }

        private void txtChiSoVe_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int result = 0;
            if (e.NewValue != null && int.TryParse(e.NewValue.ToString(), out result))
            {
                if (result < 0)
                {
                    e.NewValue = 0;
                    e.Cancel = true;
                }
            }
        }

        private void lookupEdit_BanCo_GiamSatXe_Reason_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            var lydo = new StatusManagement().GetReasonsByType(Taxi.Utils.Enum_ReasonType.LyDoBaoVe);
            string lydotxt = lookupEdit_BanCo_GiamSatXe_Reason.Text.Trim();
            if (lydotxt.Length > 0)
            {
                foreach (DataRow r in lydo.Rows)
                {
                    if (lydotxt.Equals(r["TenLyDo"]))
                    {
                        return;
                    }
                }
                try
                {
                    //Show dialog confirm
                    if (new Taxi.MessageBox.MessageBoxBA().Show("Bạn có muốn thêm mới lý do không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question) == Taxi.MessageBox.MessageBoxResult.Yes)
                    {
                        string name = lookupEdit_BanCo_GiamSatXe_Reason.Text;
                        string shortName = StringTools.GetFirstsCharOfAString(lookupEdit_BanCo_GiamSatXe_Reason.Text);
                        int ID = new StatusManagement().InsertLyDo(name, shortName, Taxi.Utils.Enum_ReasonType.LyDoBaoVe, 0);
                        //check ID đã insert thành công
                        if (ID <= 0) return;
                        BanCo_GiamSatXe_Reason reason = new BanCo_GiamSatXe_Reason();
                        reason.Reason = name;
                        reason.ShortName = shortName;
                        reason.Type = Taxi.Utils.Enum_ReasonType.LyDoBaoVe.GetHashCode();

                        (lookupEdit_BanCo_GiamSatXe_Reason.Properties.DataSource as List<BanCo_GiamSatXe_Reason>).Add(reason);
                        lookupEdit_BanCo_GiamSatXe_Reason.EditValue = ID;
                        e.Handled = true;
                    }
                }
                catch
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Đã xảy ra lỗi trong quá trình thêm mới lý do", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
        }
        #endregion
    }
}
