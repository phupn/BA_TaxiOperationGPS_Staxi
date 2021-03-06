using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
namespace Taxi.Controls
{
    public partial class ctrlSearchCuocGoi : UserControl
    {
        public DateTime gCurrentTime;
        public ctrlSearchCuocGoi()
        {
            InitializeComponent();
            txtDiaChi.Text = "";
            txtDiaChi.Focus();
            txtDiaChi.Select();
            if (!this.DesignMode)
            {
                DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                dtpDenNgay.SetValue(timeServer);
                dtpTuNgay.SetValue(timeServer.AddHours(-8));
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.U:
                    dtpTuNgay.Focus();
                    return true;
                case Keys.Alt | Keys.E:
                    dtpDenNgay.Focus();
                    return true;
                case Keys.Alt | Keys.G:
                    txtSoDienThoai.Focus();
                    return true;
                case Keys.Alt | Keys.C:
                    txtDiaChi.Focus();
                    return true;
                case Keys.Alt | Keys.O:
                    txtXeDon.Focus();
                    return true;
                case Keys.Alt | Keys.X:
                    txtXeNhan.Focus();
                    return true;
                case Keys.Alt | Keys.L:
                    txtLine.Focus();
                    return true;
                case Keys.Alt | Keys.K:
                    txtVung.Focus();
                    return true;
                case Keys.Alt | Keys.D1:
                    if (chkGoiTaxi.Checked == true)
                        chkGoiTaxi.Checked = false;
                    else
                        chkGoiTaxi.Checked = true;
                    return true;
                case Keys.Alt | Keys.D2:
                    if (chkGoiLai.Checked == true)
                        chkGoiLai.Checked = false;
                    else
                        chkGoiLai.Checked = true;
                    return true;
                case Keys.Alt | Keys.D3:
                    if (chkKhieuNai.Checked == true)
                        chkKhieuNai.Checked = false;
                    else
                        chkKhieuNai.Checked = true;
                    return true;
                case Keys.Alt | Keys.D4:
                    if (chkDichVu.Checked == true)
                        chkDichVu.Checked = false;
                    else
                        chkDichVu.Checked = true;
                    return true;
                case Keys.Alt | Keys.D5:
                    if (chkGoiKhac.Checked == true)
                        chkGoiKhac.Checked = false;
                    else
                        chkGoiKhac.Checked = true;
                    return true;
                case Keys.Alt | Keys.D:
                    if (chkDaGiaiQuyet.Checked == true)
                        chkDaGiaiQuyet.Checked = false;
                    else
                        chkDaGiaiQuyet.Checked = true;
                    return true;
                case Keys.Alt | Keys.A:
                    if (chkChuaGiaiQuyet.Checked == true)
                        chkChuaGiaiQuyet.Checked = false;
                    else
                        chkChuaGiaiQuyet.Checked = true;
                    return true;
                case Keys.F5:
                    btn5_Click(null, null);
                    return true;
                case Keys.F10:
                    btn10_Click(null, null);
                    return true;
                case Keys.Enter:
                    btnTimKiem_Click(null, null);
                    return true;
            }
            return false;
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            //HienThiControl_GoiTaxi();
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            //HienThiControl_GoiLai();
        }

        private void chkKhieuNai_CheckedChanged(object sender, EventArgs e)
        {
            //HienThiControl_GoiKhieuNai();
        }

        private void chkDichVu_CheckedChanged(object sender, EventArgs e)
        {
            //HienThiControl_GoiDichVu();
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            //HienThiControl_GoiKhac();
        }

        #region Xu ly hien thi control


        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            DateTime tuNgay = (DateTime)dtpTuNgay.GetValue();
            DateTime denNgay = (DateTime)dtpDenNgay.GetValue();
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(tuNgay, denNgay))
            {
                try
                {
                    var data = GetDataForSearch(tuNgay, denNgay);
                    if (data != null && data.Count > 0)
                    {
                        grcCuocGoiDen.DataSource = data;
                        grvCuocGoiDen.FocusedRowHandle = 0;
                    }
                    else
                    {
                        grcCuocGoiDen.DataSource = null;
                        lblMsg.Text = "Không tìm thấy dữ liệu";
                    }
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("ctrlSearchCuocGoi", ex);
                    lblMsg.Text = "Quá trình tìm kiếm sảy ra lỗi ngoại lệ.Vui lòng liên hệ với quản lý.";
                }
                
            }
            else
            {
                lblMsg.Text = "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].";
                dtpTuNgay.Focus();
            }
        }



        private void btn5_Click(object sender, EventArgs e)
        {
            gCurrentTime = DieuHanhTaxi.GetTimeServer();
            DateTime tuNgay = gCurrentTime.AddMinutes(-5);
            DateTime denNgay = gCurrentTime;
            getDataForSearch_Fix(tuNgay, denNgay);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            gCurrentTime = DieuHanhTaxi.GetTimeServer();
            DateTime tuNgay = gCurrentTime.AddMinutes(-10);
            DateTime denNgay = gCurrentTime;
            getDataForSearch_Fix(tuNgay, denNgay);
        }

        private List<DieuHanhTaxi> GetDataForSearch(DateTime TuNgay, DateTime DenNgay)
        {   
            
            //lấy ra chuỗi kiểu gọi
            string kieuCuocGoi = string.Empty;
            if (!chkGoiTaxi.Checked && !chkGoiLai.Checked && !chkKhieuNai.Checked
                && !chkDichVu.Checked && !chkGoiKhac.Checked)
            {
                kieuCuocGoi = string.Empty;
            }
            else
            {
                if (chkGoiTaxi.Checked) kieuCuocGoi += "A";
                if (chkGoiLai.Checked) kieuCuocGoi += ";B";
                if (chkKhieuNai.Checked) kieuCuocGoi += ";C";
                if (chkDichVu.Checked) kieuCuocGoi += ";D";
                if (chkGoiKhac.Checked) kieuCuocGoi += ";E";
            }
            if ((kieuCuocGoi != string.Empty) && (kieuCuocGoi.Substring(0, 1) == ";"))
            {
                kieuCuocGoi = kieuCuocGoi.Substring(1, kieuCuocGoi.Length - 1);
            }
            //Lấy trạng thái cuộc gọi
            int loaiCuocGoi = 0;
            if (chkDaGiaiQuyet.Checked && chkChuaGiaiQuyet.Checked)
            {
                loaiCuocGoi = 0;
            }
            else if (chkDaGiaiQuyet.Checked || chkChuaGiaiQuyet.Checked)
            {
                if (chkChuaGiaiQuyet.Checked) loaiCuocGoi = 1;
                if (chkDaGiaiQuyet.Checked) loaiCuocGoi = 2;
            }
            
            //Các tham số điều kiện
            string diaChi = StringTools.TrimSpace(txtDiaChi.Text);
            string soDienThoai = StringTools.TrimSpace(txtSoDienThoai.Text);
            string vung = StringTools.TrimSpace(txtVung.Text);
            string line = StringTools.TrimSpace(txtLine.Text);

            string xeNhan = StringTools.TrimSpace(txtXeNhan.Text);
            string xeDon = StringTools.TrimSpace(txtXeDon.Text);

            return new DieuHanhTaxi().ML_GetCuocGoi_Search_V4(TuNgay, DenNgay, kieuCuocGoi, string.Empty, diaChi,
                vung, soDienThoai, line, loaiCuocGoi, xeNhan, xeDon);
        }

        /// <summary>
        /// Get data search theo 5/10 phút
        /// </summary>
        private void getDataForSearch_Fix(DateTime TuNgay, DateTime DenNgay)
        {
            //Lấy trạng thái cuộc gọi
            int loaiCuocGoi = 0;
            if (chkDaGiaiQuyet.Checked && chkChuaGiaiQuyet.Checked)
            {
                loaiCuocGoi = 0;
            }
            else if (chkDaGiaiQuyet.Checked || chkChuaGiaiQuyet.Checked)
            {
                if (chkChuaGiaiQuyet.Checked) loaiCuocGoi = 1;
                if (chkDaGiaiQuyet.Checked) loaiCuocGoi = 2;
            }
            DieuHanhTaxi objCuocGoiDen = new DieuHanhTaxi();
            List<DieuHanhTaxi> lstCuocGoiDen = objCuocGoiDen.ML_GetCuocGoi_Search(TuNgay, DenNgay, "", "", "",
                "", "", "", loaiCuocGoi);

            if (lstCuocGoiDen != null && lstCuocGoiDen.Count > 0)
            {
                grcCuocGoiDen.DataSource = lstCuocGoiDen;
                grvCuocGoiDen.FocusedRowHandle = 0;
            }
            else
            {
                grcCuocGoiDen.DataSource = null;
                lblMsg.Text = "Không tìm thấy dữ liệu";
            }
        }
    }
}