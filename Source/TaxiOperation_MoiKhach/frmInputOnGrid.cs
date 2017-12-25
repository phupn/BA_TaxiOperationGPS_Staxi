using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Utils;
using System.Configuration;
using Taxi.Services.Operations;

namespace Taxi.GUI
{
    public partial class frmInputOnGrid : Form
    {
        private CuocGoi g_CuocGoi;
        private KieuNhapTrenGridTongDai g_KieuNhap;
        private List<string> g_listSoHieuXe;
        private string g_Return = string.Empty;
        private bool g_CoThayDoiDuLieu = false;
        private bool g_IsThoatDuoc999 = false;
        private  bool g_CloseForm = false ;
        private int G_XeDonLength = 0;
        private bool g_IsKetThuc = false;

        public string GetGiaTriNhap()
        {
            return g_Return;
        }

        public bool IsKetThuc()
        {
            return g_IsKetThuc;
        }

        /// <summary>
        /// chuỗi Tọa độ xe nhận
        /// </summary>
        /// <returns></returns>
        public string GetGiaTriNhap_TD()
        {
            return g_Return_TD;
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
                    if (Convert.ToInt32(arrVung[i]) == Vung)
                    {
                        bCheck = true; break;
                    }
                }
            }
            else bCheck = false;
            return bCheck;
        } 
       
        public frmInputOnGrid(CuocGoi cuocGoi, KieuNhapTrenGridTongDai kieuNhap, List<string> listSoHieuXe,bool IsThoat999)
        {
            InitializeComponent();
            g_KieuNhap = kieuNhap;
            g_CuocGoi = cuocGoi;
            g_listSoHieuXe = listSoHieuXe;
            g_IsThoatDuoc999 = IsThoat999;
        }

        private void frmInputOnGrid_Load(object sender, EventArgs e)
        {
            HienThiControl();
        }

        /// <summary>
        /// hiển thị control
        /// </summary>
        private void HienThiControl()
        {
            if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapChuyenKenh)
            {
                lblLabel.Text = "Chuyển kênh";
                txtInputGrid.Text = g_CuocGoi.Vung.ToString();
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhan)
            {
                lblLabel.Text = "Xe nhận";
                txtInputGrid.Text = g_CuocGoi.XeNhan == null ? string.Empty : g_CuocGoi.XeNhan;
                g_XeNhan_Truoc = txtInputGrid.Text.Trim();//-------Lấy dữ liệu xe nhận đã nhập trước đó
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDon)
            {
                lblLabel.Text = "Xe đón";
                txtInputGrid.Text = string.Empty;
            }
            int length = txtInputGrid.Text.Length;
            if (length > 0)
            {
                txtInputGrid.Select(length, 0);
            }
        }

        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                this.DialogResult = DialogResult.Cancel;
                g_Return = string.Empty;
                g_CloseForm = true;
                return true;
            }
            //else if (keyData == Keys.Enter)
            //{
            //    this.Close();
            //    this.DialogResult = DialogResult.OK;
            //    return true;
            //}
            return false;
        }
        #endregion XU LY HOTKEY

        private void txtInputGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                g_CloseForm = true;
                MessageBox.MessageBoxBA msgBox = new Taxi.MessageBox.MessageBoxBA();
                string s = StringTools.TrimSpace( txtInputGrid.Text );
                #region KENH
                if (s.Length > 0)
                {
                    g_Return = s;
                    if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapChuyenKenh)
                    {
                        int kenhVung = 0;
                        try
                        {
                            kenhVung = Convert.ToInt32(s);
                            if (!CheckVungNamTrongVungCauHinh(kenhVung))
                            {
                                kenhVung = -1;
                            }
                        }
                        catch (Exception ex)
                        {
                            kenhVung = 0;
                        }
                        if (kenhVung <= 0)
                        {
                            msgBox.Show(this, "Vùng phải lớn hơn 0 và nằm trong vùng được cấp phép.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Question);
                            this.DialogResult = DialogResult.Cancel;
                            g_CloseForm = false;
                            return;
                        }
                        g_CuocGoi.Vung = kenhVung;
                        if (CuocGoi.DIENTHOAI_UpdateThongTinCuocGoi(g_CuocGoi))
                        {
                            this.DialogResult = DialogResult.OK;
                            g_CloseForm = true ;
                        }
                    }
                #endregion KENH

                    #region XENHAN
                    else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhan)
                    {
                        // Check xe nhận
                        string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(s);
                        if (xeNhan != null && xeNhan.Length > 0)
                        {
                            if (!KiemTraXeNhan(xeNhan, g_listSoHieuXe) && (!KiemTraTrungLapXeChay(xeNhan)))
                            {
                                msgBox.Show(this, "Bạn nhập chính xác xe nhận.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Question);
                                g_CloseForm = false;
                                this.DialogResult = DialogResult.Cancel;
                                return;
                            }
                        }
                        //----------Nếu không update được xe nhận và tọa độ
                        //if(!updateDSXeNhan_ToaDo())
                            g_Return = xeNhan;
                    }
                    #endregion XENHAN

                    #region XEDON
                    else if (s.Length > 0 && g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDon)
                    {
                        // Kiểm tra xe đó có nằm trong xe nhận
                        string xeDon = StringTools.ConvertToChuoiXeNhanChuan(s);
                        g_Return = xeDon;
                        if (xeDon != null && xeDon.Length > 0)
                        {
                            if (xeDon == "999")
                            {
                                if (g_IsThoatDuoc999)
                                {
                                    xeDon = "999";
                                    g_IsKetThuc = true;
                                }
                                else
                                {
                                    xeDon = "";
                                    new MessageBox.MessageBoxBA().Show(this, "Chưa cho phép thoát cuốc 999", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                }
                            }
                            else
                            {
                                if (!KiemTraXeNhan(xeDon) && (!KiemTraTrungLapXeChay(xeDon)))
                                {
                                    msgBox.Show(this, "Vui lòng nhập chính xác xe đón.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Question);
                                    g_CloseForm = false;
                                    this.DialogResult = DialogResult.Cancel;
                                    return;
                                }
                                //string KenhVung_Trung = "";
                                //string xeDangCoKhach = new CuocGoi().TONGDAI_UPDATE_XEDON_CHECKVALID(xeDon, g_CuocGoi.ThoiDiemGoi, out KenhVung_Trung);
                                //if (xeDangCoKhach != "")
                                //{
                                //    string message = String.Format("Xe {0} đã đón khách ở vùng {1} khoảng 5 phút gần đây", xeDangCoKhach, KenhVung_Trung);
                                //    using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.TrungXeDon, message))
                                //    {
                                //        confirmXeDon.ShowDialog();
                                //        if (confirmXeDon.DialogResult == DialogResult.OK)
                                //        {
                                //            if (confirmXeDon.Result == 1)
                                //            {
                                //                if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, Taxi.Utils.KieuCanhBaoKhiNhapThongTin.TrungXeDon))
                                //                {
                                //                    new MessageBox.MessageBox().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                                //                    return;
                                //                }
                                //                g_IsKetThuc = true;
                                //            }
                                //            else
                                //            {
                                //                g_IsKetThuc = false;
                                //                return;
                                //            }
                                //        }
                                //        else
                                //        {
                                //            g_IsKetThuc = false;
                                //            return;
                                //        }
                                //    }
                                //}
                                if (G_XeDonLength < g_CuocGoi.SoLuong)
                                {
                                    string message = "Chưa đủ xe số lượng xe yêu cầu";
                                    using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon, message))
                                    {
                                        confirmXeDon.ShowDialog();
                                        if (confirmXeDon.DialogResult == DialogResult.OK)
                                        {
                                            if (confirmXeDon.Result == 2)
                                            {
                                                if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon))
                                                {
                                                    new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                                    return;
                                                }
                                                g_IsKetThuc = true;
                                            }
                                            else
                                            {
                                                g_IsKetThuc = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            g_IsKetThuc = false;
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    g_IsKetThuc = true;
                                }
                                string XeNhan = g_CuocGoi.XeNhan;
                                //if (g_CuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                                //{
                                if (!KiemTraXeDonThuocXeNhan(xeDon, XeNhan))
                                {
                                    string message = string.Format("Xe {0} đón nhưng không thuộc Xe Nhận", xeDon);
                                    using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan, message,xeDon))
                                    {
                                        confirmXeDon.ShowDialog();
                                        if (confirmXeDon.DialogResult == DialogResult.OK)
                                        {
                                            xeDon = confirmXeDon.XeDonResult;
                                            if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan))
                                            {
                                                new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            g_IsKetThuc = false;
                                            return;
                                        }
                                    }
                                }
                                //}
                            }
                        }
                        g_Return = xeDon;
                    }
                    #endregion
                    g_CloseForm = true;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }

                this.Close();
            }
        }

        private bool KiemTraXeNhan(string xeNhan)
        {
            if (g_listSoHieuXe == null || g_listSoHieuXe.Count <= 0) return false;
            if (string.IsNullOrEmpty(xeNhan)) return true;

            string[] arrXeNhan = xeNhan.Split('.');
            G_XeDonLength = arrXeNhan.Length;

            for (int i = 0; i < G_XeDonLength; i++)
            {
                if (!g_listSoHieuXe.Contains(arrXeNhan[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// có thông tin xe đón
        /// </summary>
        private bool XuLyCoThongTinXeDon(string XeDon)
        {
            MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

            if (XeDon == "999")
            {
                if (g_IsThoatDuoc999)
                {
                    if (g_CuocGoi.XeNhan.Length <= 0)
                        g_CuocGoi.XeNhan = "999";
                    else
                        g_CuocGoi.XeNhan += ".999";  // cong them xe cu
                }
                else
                {
                    XeDon = "";
                }
            }

            if (KiemTraTrungLapXeChay(XeDon))
            {
                msg.Show("Bạn phải nhập xe taxi chạy chính xác");
                txtInputGrid.Focus();
                return false;
            }
            return true;
        }

        #region -----------------------Xe nhận - GPS--------------------------------
        private string g_Return_TD = string.Empty;
        private string g_XeNhan_Truoc = string.Empty;
        private bool updateDSXeNhan_ToaDo()
        {
            try
            {
                double KD = g_CuocGoi.GPS_KinhDo;
                double VD = g_CuocGoi.GPS_ViDo;
                if (KD == 0 || VD == 0)
                    return false;

                string dsXeNhan = txtInputGrid.Text.Trim();//Chuỗi xe nhận hiện tại vừa nhập
                if (dsXeNhan == "")
                    return false;

                string dsToaDo = "";
                string[] arrDSToaDoTruoc = null;
                string[] arrDSXeNhan = dsXeNhan.Split('.');//-----Cắt chuỗi xe nhận vừa nhập
                string[] arrDSXeNhanTruoc = null;
                string dsXeNhanTruoc = "";
                string dsToaDoTruoc = "";
                string dsXeNhanMoi = "";
                string[] arrDSToaDoMoi;

                if (g_XeNhan_Truoc != "")//-----TH đã có xe nhận đã nhập trước đó
                {
                    if (g_CuocGoi.XeNhan_TD == null || g_CuocGoi.XeNhan_TD == "")
                    {
                        //-------Nếu Tọa độ xe nhận cũ không có, lấy lại tọa độ của xe nhận cũ
                        string toaDoTruoc = getToaDoXeNhanMoi(g_CuocGoi.XeNhan, KD, VD);
                        if (toaDoTruoc != "")
                            arrDSToaDoTruoc = toaDoTruoc.Split(',');//-----Cắt chuỗi tọa độ xe nhận cũ
                    }
                    else
                    {
                        arrDSToaDoTruoc = g_CuocGoi.XeNhan_TD.Split(',');//-----Cắt chuỗi tọa độ xe nhận cũ
                    }

                    arrDSXeNhanTruoc = g_XeNhan_Truoc.Split('.');//-----Cắt chuỗi xe nhận cũ
                    //----phân tích chuỗi xe nhận vừa nhập để so sánh xem xe nhận nào là cũ và xe nào là mới nhập
                    for (int i = 0; i < arrDSXeNhan.Length; i++)
                    {
                        if (arrDSXeNhan[i] != "")//-----Nếu xe nhận khác rỗng
                        {
                            //---duyệt trong chuỗi xe nhận trước đó
                            for (int j = 0; j < arrDSXeNhanTruoc.Length; j++)
                            {
                                if (arrDSXeNhanTruoc[j] == arrDSXeNhan[i])//----Nếu xe nhận cũ có nằm trong danh sách xe nhận vừa nhập
                                {//---Gán xe nhận và tọa độ trước ra 1 chuỗi khác (1)
                                    dsXeNhanTruoc = string.Format("{0}{1}.", dsXeNhanTruoc, arrDSXeNhan[i]);
                                    dsToaDoTruoc = string.Format("{0}{1},", dsToaDoTruoc, arrDSToaDoTruoc[j]);
                                    break;
                                }
                                else//----Nếu xe nhận cũ không nằm trong danh sách xe nhận vừa nhập 
                                {
                                    //-----Kiểm tra xem xe nhận có tồn tại trong chuỗi đã nhập trước đó ko.
                                    if (Array.IndexOf(arrDSXeNhanTruoc, arrDSXeNhan[j]) == 0)
                                    {
                                        dsXeNhanMoi = string.Format("{0}{1}.", dsXeNhanMoi, arrDSXeNhan[i]);//Gán xe nhận mới vào chuỗi khác (2)
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (dsXeNhanMoi.LastIndexOf('.') > 0)
                        dsXeNhanMoi = dsXeNhanMoi.Substring(0, dsXeNhanMoi.Length - 1);
                }
                else//-----TH chưa có xe nhận trước đó
                {
                    dsXeNhanMoi = dsXeNhan;
                }

                if (dsXeNhanMoi != "")
                {
                    dsToaDo = string.Format("{0}{1},", dsToaDoTruoc, getToaDoXeNhanMoi(dsXeNhanMoi, KD, VD));//----Tọa độ của danh sách xe nhận đã sắp xếp
                    g_Return = string.Format("{0}{1}.", dsXeNhanTruoc, dsXeNhanMoi);//----Danh sách xe nhận đã sắp xếp
                }
                else
                {
                    dsToaDo = dsToaDoTruoc;//----Tọa độ của danh sách xe nhận đã sắp xếp
                    g_Return = dsXeNhanTruoc;//----Danh sách xe nhận đã sắp xếp
                }
                if (dsToaDo.LastIndexOf(',') > 0)
                    dsToaDo = dsToaDo.Substring(0, dsToaDo.Length - 1);
                if (g_Return.LastIndexOf('.') > 0)
                    g_Return = g_Return.Substring(0, g_Return.Length - 1);

                g_Return_TD = dsToaDo;// chuoi toa do cua xe nhan da sap xep

                return CuocGoi.TONGDAI_UPDATE_XENHAN_TOADO(g_CuocGoi.IDCuocGoi, dsToaDo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string getToaDoXeNhanMoi(string dsXeNhan, double KD, double VD)
        {
            string dsToaDo = "";
            string[] arrDSXeNhan = dsXeNhan.Split('.');
            for (int i = 0; i < arrDSXeNhan.Length; i++)
            {
                //gọi service trả về tọa độ của 1 xe đang có tín hiệu
               // dsToaDo = string.Format("{0}{1},", dsToaDo, ServiceOnlineFactory.Inst.LayToaDoXeNhan(KD, VD, arrDSXeNhan[i]));
            }
            if (dsToaDo.Length > 1)
                dsToaDo = dsToaDo.Substring(0, dsToaDo.Length - 1);
            return dsToaDo;
        }
        #endregion
        
        /// <summary>
        /// Hàm kiểm tra xe nhận có nằm trong dsXe hệ thống đã nhập
        /// INPUT :
        ///      - xeNhan : 2343.6732.9000
        /// OUPPUT : True : xe nhan nằm trong dsXe của hệ thống
        ///          False: xe nhận không nằm trong ds xe của hệ thống.
        /// </summary>
        /// <param name="xeNhan"></param>
        /// <returns></returns>
        private bool KiemTraXeNhan(string xeNhan, List<string> dsXe)
        {
            bool ret = true;
            if (xeNhan.Length <= 0) return true;
            if (dsXe == null || dsXe.Count <= 0) return false;

            string[] arrXeNhan = xeNhan.Split(".".ToCharArray());
            for (int i = 0; i < arrXeNhan.Length; i++)
            {
                bool timThayXe = false;
                foreach (string xe in dsXe)
                {
                    if (xe == arrXeNhan[i])
                    {
                        timThayXe = true;
                        break; // thoát khỏi vòng ds xe
                    }
                }
                ret &= timThayXe;
                if (!ret) { break; }  // có một xe không thuộc ds
            }
            return ret;
        }
        /// <summary>
        /// hàm thực hiện kiểm tra xe đón thuộc xe nhận        
        /// INPUT :
        ///    xeDon : 3210.2900.3213
        ///    xeNhan: 3211.2900.0900.3210.3213
        /// OUTPUT
        ///    true : xeDon nằm trong xe nhận
        ///    false: xeDon không nằm trong xe nhận
        /// </summary>
        /// <param name="xeDon"></param>
        /// <param name="xeNhan"></param>
        /// <returns></returns>
        private bool KiemTraXeDonThuocXeNhan(string xeDon, string xeNhan)
        {
            string[] arrXeDon = xeDon.Split(".".ToCharArray());
            string[] arrXeNhan = xeNhan.Split(".".ToCharArray());
            bool ret = true;
            for (int i = 0; i < arrXeDon.Length; i++)
            {
                bool timThayXe = false;
                for (int j = 0; j < arrXeNhan.Length; j++)
                {
                    if (arrXeDon[i] == arrXeNhan[j])
                    {
                        timThayXe = true;
                        break;
                    }
                }
                ret &= timThayXe;
                if (!ret) { break; };
            }
            return ret;
        }

        /// <summary>
        /// Kiem tra trong cac xe da trung nhau khong
        /// </summary>
        /// <param name="DanhSachTaxi"></param>
        /// <returns></returns>
        private bool KiemTraTrungLapXeChay(string DanhSachTaxi)
        {

            string[] arrTaxi = DanhSachTaxi.Split(".".ToCharArray());
            for (int i = 0; i < arrTaxi.Length - 1; i++)
            {
                for (int j = i + 1; j < arrTaxi.Length; j++)
                {

                    if (arrTaxi[j] == arrTaxi[i]) return true;
                }
            }
            return false;

        }

        private void frmInputOnGrid_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = !g_CloseForm;
            
        }
    }
}