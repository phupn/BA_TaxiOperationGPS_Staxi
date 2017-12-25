using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.MasterData;

namespace TaxiOperation_BanCo.GiamSatXe
{
    public partial class frmGiamSatXe_BaoRaKinhDoanh : FormBase
    {
        #region ==== Define ====
        private GiamSatXe_LienLac lienlac = new GiamSatXe_LienLac();
        DateTime dtServer;
        float isF = 0f;
        bool isValid = false;
        private BanCo_GiamSatXe objGiamSatXe;
        /// <summary>
        /// Biến để đánh dấu xe này đã khai báo ra kinh doanh trong ngày mà chưa báo về
        /// Hoặc đang có cuốc hàng chưa giải quyết
        /// Trường hợp này sẽ không cho báo ra kd tiếp
        /// </summary>
        private bool isSameDay = false;
        /// <summary>
        /// Đã báo về chưa.
        /// </summary>
        private bool isNotReturn = false;
        private bool isRefresh = false;
        List<GiamSatXe_HoatDong> DanhSachXeHoatDong = new List<GiamSatXe_HoatDong>();
        #endregion

        #region === INI ====
        public frmGiamSatXe_BaoRaKinhDoanh()
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        #endregion

        #region ==== Function ====
        private void RefreshForm()
        {
            isRefresh = true;
            lookUp_SoHieu.Properties.DataSource = CommonBL.ListXe_NotIn_GiamSatXe;
            lookUp_SoHieu.Properties.DisplayMember = "SoHieuXe";
            lookUp_SoHieu.Properties.ValueMember = "SoHieuXe";
            DanhSachXeHoatDong=lienlac.GetNhanVienList();
            lookUp_LaiXe.Properties.DataSource = DanhSachXeHoatDong;
            lookUp_LaiXe.Properties.DisplayMember = "TenVietTat";
            lookUp_LaiXe.Properties.ValueMember = "MaLaiXe";

            dtServer = Taxi.Business.CommonBL.GetTimeServer();
            deGioDi.DateTime = dtServer;

            spin_ChiSoDi.Text = "";
            spin_ChiSoDi.EditValue = null;
            lVungDieuHanh.EditValue = null;
            txtGhiChu.Text = "";
            txtNode.EditValue = null;
            lookUp_LaiXe.EditValue = null;
            lookUp_SoHieu.EditValue = null;
            lookUp_SoHieu.Focus();
            chkTrucDem.Checked = false;
            chk2Lai.Checked = false;
            chkCa3.Checked = false;
            lblmsg.Text = string.Empty;
            isRefresh = false;
        }
        private bool Validate()
        {
            if (lookUp_SoHieu.EditValue == null || lookUp_SoHieu.Text.Trim() == "" || lookUp_SoHieu.Text.Trim() == "Chọn xe")
            {
                isSameDay = false;
                lblmsg.Text = ("Bạn chưa nhập số xe");
                lookUp_SoHieu.Focus();
                return false;
            }
            if (isSameDay && !chkCa3.Checked && !chkTrucDem.Checked)
            {
                lblmsg.Text = string.Format("Xe {0}-{1} báo KD ngày: {2:HH:mm dd/MM} chưa báo về", objGiamSatXe.SoHieuXe, objGiamSatXe.TenLaiXe, objGiamSatXe.ThoiDiemBao);
                lookUp_SoHieu.Focus();
                return false;
            }
            if (isNotReturn)
            {
                lblmsg.Text = "Bạn nhập số xe chưa báo về";
                lookUp_SoHieu.Focus();
                return false;
            }
            if (lookUp_LaiXe.EditValue == null || lookUp_LaiXe.Text.Trim() == "" || lookUp_LaiXe.Text.Trim() == "Chọn xe")
            {
                lblmsg.Text = ("Bạn chưa nhập lái xe");
                lookUp_LaiXe.Focus();
                return false;
            }
            if (deGioDi.EditValue == null)
            {
                lblmsg.Text = "Giờ đi chưa nhập"; deGioDi.Focus(); return false;
            }

            string err = "";
            if (!Validate_TrangThaiGiamSatXe_LaiXe(lookUp_LaiXe.EditValue.ToString(), ref err))
            {
                lblmsg.Text = err;
                return false;
            }
            if (spin_ChiSoDi.Text.Trim() == "")
            {
                lblmsg.Text = ("Bạn chưa nhập chỉ số đi"); spin_ChiSoDi.Focus(); return false;
            }
            if (!float.TryParse(spin_ChiSoDi.Text, out isF))
            {
                lblmsg.Text = "Chỉ số đi quá lớn"; spin_ChiSoDi.Focus(); return false;
            }

            if (spin_ChiSoDi.Value <= 0)
            {
                lblmsg.Text = ("Chỉ số đi không hợp lệ"); spin_ChiSoDi.Focus(); return false;
            }
            //if (lVungDieuHanh.Text.Trim() == "" || lVungDieuHanh.Text.Trim() == "Chọn vùng") 
            //{ 
            //    lblmsg.Text = ("Bạn chưa nhập vùng"); lVungDieuHanh.Focus(); return false; }

            if (deGioDi.DateTime > dtServer)
            {
                lblmsg.Text = "Giờ đi không quá ngày hiện tại"; deGioDi.Focus(); return false;
            }
            if (txtGhiChu.Text.Length > 250)
            {
                lblmsg.Text = "Ghi chú vượt quá ký tự cho phép"; txtGhiChu.Focus(); return false;
            }
            if (deGioDi.DateTime.Year < 2000)
            {
                lblmsg.Text = "Giờ đi quá nhỏ"; deGioDi.Focus(); return false;
            }
            else
                lblmsg.Text = "";

            return true;
        }

        private bool Validate_TrangThaiGiamSatXe_LaiXe(string MaLaiXe, ref string strErr)
        {
            List<GiamSatXe_LienLac> lstGiamSatLienLac = new GiamSatXe_LienLac().Get_GiamSatXe_Status_ByMaLaiXe(MaLaiXe, DBNull.Value);
            bool check = false;
            if (lstGiamSatLienLac != null && lstGiamSatLienLac.Count > 0)
            {
                foreach (GiamSatXe_LienLac row in lstGiamSatLienLac)
                {
                    if (row.MaLaiXe == MaLaiXe)
                    {
                        check = false;
                        if (row.TrangThaiLaiXeBao == ((int)Enum_TrangThaiLaiXeBao.MatLienLac).ToString())
                        {
                            strErr = string.Format("Lái xe {0} đang mất liên lạc", row.TenLaiXe);
                        }
                        else if (row.TrangThaiLaiXeBao == ((int)Enum_TrangThaiLaiXeBao.BaoNghi_RoiXe).ToString())
                        {
                            strErr = string.Format("Lái xe {0} đang báo rời xe", row.TenLaiXe);
                        }
                        else if (row.TrangThaiLaiXeBao == ((int)Enum_TrangThaiLaiXeBao.BaoNghi_AnCa).ToString())
                        {
                            strErr = string.Format("Lái xe {0} đang báo ăn ca", row.TenLaiXe);
                        }
                        else if (row.TrangThaiLaiXeBao == ((int)Enum_TrangThaiLaiXeBao.BaoSuCoTaiNanCongAn).ToString())
                        {
                            strErr = string.Format("Lái xe {0} đang báo gặp sự cố", row.TenLaiXe);
                        }
                        else if (row.TrangThaiLaiXeBao == ((int)Enum_TrangThaiLaiXeBao.BaoRaKinhDoanh).ToString()
                            || row.TrangThaiLaiXeBao == ((int)Enum_TrangThaiLaiXeBao.BaoDiemDo).ToString())
                        {
                            strErr = string.Format("Lái xe {0} đã báo ra kinh doanh", row.TenLaiXe);
                        }
                        break;
                    }
                }
            }
            else
            {
                check = true;
            }
            if (check)
            {
                //nếu là Trực đêm và ca 3 thì không kiểm tra xe có báo không đi kinh doanh.
                if (!chkTrucDem.Checked && !chkCa3.Checked)
                {
                    if (GiamSatXe_LienLac.Inst.CheckXeKhongDiKinhDoanh(lookUp_SoHieu.Text, deGioDi.DateTime))
                    {
                        check = false;
                        strErr = string.Format("Xe {0} đã báo không ra kinh doanh ngày hôm nay", lookUp_SoHieu.Text);
                    }
                }
            }
            return check;
        }

        #endregion

        #region ==== Event Form ====
        private void frmGiamSatXe_BaoRaKinhDoanh_Load(object sender, EventArgs e)
        {
            
            RefreshForm();

            lVungDieuHanh.Properties.DataSource = new VungDieuHanh().GetTenVungDieuHanh();
            lVungDieuHanh.Properties.DisplayMember = "TenVung";
            lVungDieuHanh.Properties.ValueMember = "Id";
         
            lookUp_SoHieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            lookUp_SoHieu.Properties.Mask.EditMask = @"\d+";
         
        }

        void lookUp_SoHieu_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.ForeColor = Color.Red;
                if (Validate())
                {
                    dtServer = deGioDi.DateTime;
                    string TenDiemDo = "";
                    int DiemDo = 0;
                    if (lVungDieuHanh.EditValue != null)
                    {
                        TenDiemDo = lVungDieuHanh.GetColumnValue("NameVungDH").ToString();
                        DiemDo = int.Parse(lVungDieuHanh.GetColumnValue("Id").ToString());
                    }
                    lienlac.GSX_BaoRaKinhDoanh_V2(lookUp_SoHieu.Text.Trim(), 
                                        dtServer, 
                                        lookUp_LaiXe.GetColumnValue("MaLaiXe").ToString(), 
                                        lookUp_LaiXe.GetColumnValue("TenNhanVien").ToString(), 
                                        1, 
                                        TenDiemDo, 
                                        DiemDo, 
                                        spin_ChiSoDi.EditValue, 
                                        txtGhiChu.Text, 
                                        Taxi.Business.ThongTinDangNhap.USER_ID,
                                        new Guid(), 0, chkTrucDem.Checked, chk2Lai.Checked, chkCa3.Checked, txtNode.EditValue);

                    RefreshForm();

                    lblmsg.Text = "Khai báo ra kinh doanh thành công";
                    lblmsg.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Khai báo không thành công" + ex.Message;
                lblmsg.ForeColor = Color.Red;
                return;
            }

        }

        private void lookUp_SoHieu_Leave(object sender, EventArgs e)
        {
            if (isRefresh) return;
            isNotReturn = false;
            lblmsg.Text = "";
            if (lookUp_LaiXe.EditValue == null)
            {
               var xe= DanhSachXeHoatDong.Where(p => p.SoHieuXe == lookUp_SoHieu.Text).FirstOrDefault();
               if (xe != null)
               {
                   lookUp_LaiXe.SetValue(xe.MaLaiXe);
               }
               else
               {
                   lookUp_LaiXe.SetValue(null);
               }
            }
            //SoHieuXe
            //if (lookUp_SoHieu.Text == "" || lookUp_SoHieu.Text == "Chọn xe")
            //{
            //    isSameDay = false;
            //    lblmsg.Text = ("Bạn chưa nhập số xe"); return;
            //}
            //else
            //    lblmsg.Text = "";
            isSameDay = false;
            if (lookUp_SoHieu.EditValue != null)
            {
                objGiamSatXe = CommonBL.ListXe_XeChuaVe.Find(T => T.SoHieuXe == lookUp_SoHieu.EditValue.ToString());
                if (objGiamSatXe != null)
                {
                    isNotReturn = true;
                    isSameDay = objGiamSatXe.ThoiDiemBao.Value.Date.Equals(dtServer.Date);
                    if (!isSameDay && TaxiOperation_Truck.Inst.IsTruckProcessing(objGiamSatXe.SoHieuXe))
                    {
                        lblmsg.Text = string.Format("Xe {0}-{1} đang có cuốc hàng chưa giải quyết", objGiamSatXe.SoHieuXe, objGiamSatXe.TenLaiXe);
                        isSameDay = true;

                    }
                    else
                        lblmsg.Text = string.Format("Xe {0}-{1} báo KD ngày: {2:HH:mm dd/MM} chưa báo về", objGiamSatXe.SoHieuXe, objGiamSatXe.TenLaiXe, objGiamSatXe.ThoiDiemBao);

                }
                else isSameDay = false;
            }
           
           
        }
      
        private void lookUp_SoHieu_EditValueChanged(object sender, EventArgs e)
        {
            if (isRefresh) return;
            var objSoHieuXe = lookUp_SoHieu.GetColumnValue("MaLaiXe");
            var objCoVe = lookUp_SoHieu.GetColumnValue("CoVe");
            if (objSoHieuXe != null && objSoHieuXe != DBNull.Value)
            {
                isValid = true;
                lookUp_LaiXe.EditValue = objSoHieuXe.ToString();
            }
            //else
            //{
            //    lookUp_LaiXe.EditValue = null;
            //}
            if (objCoVe != null && objCoVe != DBNull.Value)
            {
                spin_ChiSoDi.Text = objCoVe.ToString();
            }
            var xe = DanhSachXeHoatDong.Where(p => p.SoHieuXe == lookUp_SoHieu.Text).FirstOrDefault();
            if (xe != null)
            {
                lookUp_LaiXe.SetValue(xe.MaLaiXe);
            }
            else
            {
                lookUp_LaiXe.SetValue(null);
            }
        }

        private void txtChiSoDi_TextChanged(object sender, EventArgs e)
        {
            if (isRefresh) return;
            lblmsg.Text = "";
            if (spin_ChiSoDi.Value < 0)
            {
                spin_ChiSoDi.Value = 1;
                spin_ChiSoDi.SelectAll();
            }
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            if (isRefresh) return;
            lblmsg.Text = "";
        }

        private void lookUp_SoHieu_TextChanged(object sender, EventArgs e)
        {
            if (isRefresh) return;
            lblmsg.Text = "";
        }

        private void lVungDieuHanh_TextChanged(object sender, EventArgs e)
        {
            if (isRefresh) return;
            lblmsg.Text = "";
        }


        private void txtSoHieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !lookUp_SoHieu.IsPopupOpen)
            {
                spin_ChiSoDi.Focus();
            }

        }

        private void txtChiSoDi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                lookUp_LaiXe.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                e.Handled = true;
                lookUp_SoHieu.Focus();
            }
            else if (e.KeyData == Keys.Down)
            {
                e.Handled = true;
                lookUp_LaiXe.Focus();
            }
        }

        private void lueLaiXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !lookUp_LaiXe.IsPopupOpen)
            {
                lVungDieuHanh.Focus();
            }
        }

        private void lVungDieuHanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !lVungDieuHanh.IsPopupOpen)
            {
                txtNode.Focus();
            }
        }

        private void deGioDi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !deGioDi.IsPopupOpen)
            {
                chkTrucDem.Focus();
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                deGioDi.Focus();
            }
        }

        private void chkTrucDem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                chk2Lai.Focus();
            }
        }

        private void chk2Lai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLuu.Focus();
            }
        }
        private void txtSoHieu_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (lookUp_SoHieu.EditValue == null)
            {
                lookUp_SoHieu.Focus();
                lblmsg.Text = "Số hiệu xe không tồn tại";
            }
            else
            {
                spin_ChiSoDi.Focus();
            }
        }

        private void lueLaiXe_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            lVungDieuHanh.Focus();
        }

        private void lVungDieuHanh_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            txtNode.Focus();
        }
      

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.H))
            {
                chk2Lai.Checked = !chk2Lai.Checked;
            }
            else if (keyData == (Keys.Control | Keys.D3) || keyData == (Keys.Control | Keys.NumPad3))
            {
                chkCa3.Checked = !chkCa3.Checked;
            }
            else if (keyData == (Keys.Control | Keys.T))
            {
                chkTrucDem.Checked = !chkTrucDem.Checked;
            }
            //else if (keyData == Keys.F2)
            //{
            //    btnLuu_Click(null, null);
            //}
            //else if (keyData == Keys.Escape)
            //{
            //    btnLuu_Click(null, null);
            //}
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
             
    }
}