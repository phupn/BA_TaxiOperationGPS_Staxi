using System.Reflection;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Collections.Generic;
using System;
namespace Taxi.Controls
{
    public partial class FrmInputGridView : FormBase
    {
        private PropertyInfo pro;
        private CuocGoi _cuocGoi;
        private G5Command _cmd;
        public G5CommandType CommandType { get; set; }
        public FrmInputGridView()
        {
            InitializeComponent();
        }
        public FrmInputGridView(CuocGoi cuocgoi)
        {
            InitializeComponent();
            _cuocGoi = cuocgoi;
        }
        public FrmInputGridView(CuocGoi cuocgoi, G5Command cmd)
        {
            InitializeComponent();
            _cuocGoi = cuocgoi;
            _cmd = cmd;
        }
        public void IniInput()
        {
            pro = null;
            if (_cmd != null)
            {

                if (_cmd.CommandType == G5CommandType.NhapMoRong)
                {
                    pro = _cuocGoi.GetType().GetProperty(_cmd.ParentCommand);
                    if (pro == null)
                    {
                        this.Close();
                        return;
                    }
                    lbl.Text = _cmd.Command;
                    txtInput.Properties.Mask.EditMask = ".+";
                    txtInput.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    txtInput.EditValue = pro.GetValue(_cuocGoi, null);
                }
                else if (_cmd.CommandType == G5CommandType.ChuyenVung)
                {
                    lbl.Text = _cmd.Command;
                    txtInput.Properties.Mask.EditMask = "[0-9]+";
                    txtInput.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    txtInput.EditValue = _cuocGoi.Vung;
                }
                else//Nhập số xe
                {
                    lbl.Text = _cmd.Command;
                    txtInput.Properties.Mask.EditMask = "[0-9.]+";
                    txtInput.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    if (_cmd.CommandType == G5CommandType.NhapXeNhan)
                    {
                        txtInput.Text = _cuocGoi.XeNhan;
                    }
                    else if (_cmd.CommandType == G5CommandType.NhapXeDienDiem)
                    {
                        txtInput.Text = _cuocGoi.XeDenDiem;
                    }
                    else if (_cmd.CommandType == G5CommandType.NhapXeDungDiem)
                    {
                        txtInput.Text = _cuocGoi.XeDungDiem;
                    }
                    else if (_cmd.CommandType == G5CommandType.NhapXeDon)
                    {
                        txtInput.Text = _cuocGoi.XeDon;
                    }
                    if (!string.IsNullOrEmpty(txtInput.Text))
                    {
                        txtInput.Text = txtInput.Text + '.';
                        txtInput.Select(txtInput.Text.Length, 0);
                    }
                }
                panel1.Width = lbl.Width + 15;
            }

        }

        private void FrmInputGridView_Load(object sender, System.EventArgs e)
        {
            IniInput();
            this.Size = new System.Drawing.Size(374, 30);
        }

        private bool CheckValidate()
        {
            var msgBox = new Taxi.MessageBox.MessageBoxBA();
            if (_cmd.CommandType == G5CommandType.ChuyenVung)
            {
                var vung = txtInput.Text.To<int>();
                if (CheckVungNamTrongVungCauHinh(vung))
                {
                    msgBox.Show("Vùng phải lớn hơn 0 và nằm trong vùng được cấp phép.", "Thông báo");
                    return false;
                }
            }
            else if (_cmd.CommandType == G5CommandType.NhapXeNhan)
            {
                if (Config_Common.CanhBaoKhiNhapXe == 0 && StringTools.KiemTraTrungLapXeChay(txtInput.Text))
                {
                    msgBox.Show(this, "Nhập trùng xe nhận", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);

                    return false;
                }
            }
            else if (_cmd.CommandType == G5CommandType.NhapXeDienDiem)
            {
                return false;
            }
            else if (_cmd.CommandType == G5CommandType.NhapXeDungDiem)
            {
                return false;
            }
            else if (_cmd.CommandType == G5CommandType.NhapXeDon)
            {
                string xeDon = txtInput.Text;
                if (Config_Common.CanhBaoKhiNhapXe == 0)
                {
                    var G_XeDonLength = xeDon.Split('.').Length;
                    if (!KiemTraXeNhan(xeDon) && (!StringTools.KiemTraTrungLapXeChay(xeDon)))
                    {
                        msgBox.Show(this, "Vui lòng nhập chính xác xe đón.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Question);
                        return false;
                    }
                    string KenhVung_Trung = string.Empty;
                    string xeDangCoKhach = new CuocGoi().TONGDAI_UPDATE_XEDON_CHECKVALID(xeDon, _cuocGoi.ThoiDiemGoi, out KenhVung_Trung);
                    if (xeDangCoKhach != "")
                    {
                        string message = String.Format("Xe {0} đã đón khách ở vùng {1} khoảng 5 phút gần đây", xeDangCoKhach, KenhVung_Trung);
                        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.TrungXeDon, message))
                        {
                            confirmXeDon.ShowDialog();
                            if (confirmXeDon.DialogResult == System.Windows.Forms.DialogResult.OK)
                            {
                                if (confirmXeDon.Result == 1)
                                {
                                    if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(_cuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, Taxi.Utils.KieuCanhBaoKhiNhapThongTin.TrungXeDon))
                                    {
                                        new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else if (G_XeDonLength > _cuocGoi.SoLuong)
                    {
                        new MessageBox.MessageBoxBA().Show("Xe đón vượt số lượng yêu cầu. Vui lòng kiểm tra lại");

                        return false;
                    }

                    string XeNhan = _cuocGoi.XeNhan;
                    if (Config_Common.TongDai_HienThiCanhBao_XeDonTrungXeNhan > 0 && !StringTools.KiemTraXeDonThuocXeNhan(xeDon, XeNhan))
                    {
                        string message = string.Format("Xe {0} đón nhưng không thuộc Xe Nhận", xeDon);
                        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan, message, xeDon))
                        {
                            confirmXeDon.ShowDialog();
                            if (confirmXeDon.DialogResult == System.Windows.Forms.DialogResult.OK)
                            {
                                xeDon = confirmXeDon.XeDonResult;
                                if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(_cuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan))
                                {
                                    new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                    return false;
                                }
                            }
                            else
                            {

                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }

        /// <summary>
        /// check vung nhan năm trong vùng cấu hình.
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if (ThongTinCauHinh.CacVungTongDai != null && ThongTinCauHinh.CacVungTongDai.Length > 0)
            {
                string[] arrVung = ThongTinCauHinh.CacVungTongDai.Split(";".ToCharArray());
                for (int i = 0; i < arrVung.Length; i++)
                {
                    if (arrVung[i].To<int>() == Vung)
                    {
                        bCheck = true; break;
                    }
                }
            }
            else bCheck = false;
            return bCheck;
        }
        /// <summary>
        /// Hàm kiểm tra xe nhận có nằm trong dsXe hệ thống đã nhập
        /// INPUT :
        ///      - xeNhan : 2343.6732.9000
        /// OUPPUT : True : xe nhan nằm trong dsXe của hệ thống
        ///          False: xe nhận không nằm trong ds xe của hệ thống.
        /// </summary>
        /// <param name="xeNhan"></param>
        /// <returns></returns>
        private bool KiemTraXeNhan(string xeNhan)
        {
            if (CommonBL.DicXe.ContainsKey(xeNhan))
                if (CommonBL.DicXe == null || CommonBL.DicXe.Count <= 0) return false;
            if (string.IsNullOrEmpty(xeNhan)) return true;

            string[] arrXeNhan = xeNhan.Split('.');
            var G_XeDonLength = arrXeNhan.Length;

            for (int i = 0; i < G_XeDonLength; i++)
            {
                if (!CommonBL.DicXe.ContainsKey(arrXeNhan[i]))
                    return false;
            }
            return true;
        }
        private void txtInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                if (CheckValidate())
                {
                    txtInput.Text = txtInput.Text.Trim('.');
                    if (_cmd.CommandType == G5CommandType.NhapXeNhan)
                    {
                        _cuocGoi.XeNhan = StringTools.ConvertToChuoiXeNhanChuan(txtInput.Text);
                    }
                    else if (_cmd.CommandType == G5CommandType.NhapXeDienDiem)
                    {
                        _cuocGoi.XeDenDiem = StringTools.ConvertToChuoiXeNhanChuan(txtInput.Text);
                    }
                    else if (_cmd.CommandType == G5CommandType.NhapXeDungDiem)
                    {
                        _cuocGoi.XeDungDiem = StringTools.ConvertToChuoiXeNhanChuan(txtInput.Text);
                    }
                    else if (_cmd.CommandType == G5CommandType.NhapXeDon)
                    {
                        _cuocGoi.XeDon = StringTools.ConvertToChuoiXeNhanChuan(txtInput.Text);
                        _cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                        _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                        if (_cuocGoi.XeDon == "000")
                        {
                            if (_cuocGoi.XeNhan.Length <= 0)
                                _cuocGoi.XeNhan = "000";
                            else
                                _cuocGoi.XeNhan += ".000";
                        }
                        else
                        {
                            //Nếu xe đón không thuộc xe nhận thì tự động nhập xe đón vào xe nhận
                            if (!_cuocGoi.XeNhan.Contains(_cuocGoi.XeDon))
                            {
                                if (_cuocGoi.XeNhan.Length <= 0)
                                    _cuocGoi.XeNhan = _cuocGoi.XeDon;
                                else
                                    _cuocGoi.XeNhan += "." + _cuocGoi.XeDon;
                            }
                        }
                    }
                    else
                        if (pro != null)
                        {
                            pro.SetValue(_cuocGoi, txtInput.Text, null);
                        }

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
