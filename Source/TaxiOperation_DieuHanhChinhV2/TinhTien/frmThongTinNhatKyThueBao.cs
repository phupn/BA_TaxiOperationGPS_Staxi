using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.BanGiaGoc; 
using Janus.Windows.GridEX;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmThongTinNhatKyThueBao : Form
    {

      //  [ID]
      //,[ThoiDiem]
      //,[SoHieuXe]
      //,[TenLaiXe]
      //,[TuyenDuongID]
      //,[TenTuyenDuong]
      //,[ThoiGianDon]
      //,[KmDon]
      //,[ThoiGianTra]
      //,[KmTra]
      //,[KmThucDi]
      //,[DongHoTien]
      //,[PhuTroi]
      //,[TienThucThu]
      //,[MaNhanVienNhap]
      //,[GhiChu]
      //,[Chieu]
      //,[SoLanSua]
      //,[LoaiXeID]

        public frmThongTinNhatKyThueBao()
        {
            InitializeComponent();
        }

        private void frmThongTinNhatKyThueBao_Load(object sender, EventArgs e)
        {
            LoadDSThueBao();
            //if (ThongTinDangNhap.USER_ID != "admin")
            //{
            //    cmdXoa.Visible =  Janus.Windows.UI.InheritableBoolean.False ;
            //}
            if (ThongTinDangNhap.USER_ID.Length <= 0)
            {
                new Taxi.MessageBox.MessageBox().Show("Bạn phải đăng nhập để thực hiện nhập thông tin thuê bao.");
                this.Close();
            }
        }
        private void LoadDSThueBao()
        {
            NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();
            DataTable dt = NhatkyThuebaoControl.GetAll();
            try
            {
                grdNhanVien.DataMember = "lID";
                grdNhanVien.SetDataBinding(dt, "lID");
                grdNhanVien.Refresh();
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdAdd_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdNew cmdEdit cmdDelete cmdExit cmdHelp
            if (e.Command.Key == "cmdThemMoi")
            {
                 
                frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao();
                frmNhapNhatKyThueBaocontrol.ShowDialog();
                LoadDSThueBao();
            }
            else if (e.Command.Key == "cmdEdit")
            {
                 
            }
            else if (e.Command.Key == "cmdXoa")
            {
                grdNhanVien.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdNhanVien.SelectedItems.Count > 0)
                {
                    if (ThongTinDangNhap.USER_ID == "admin" || ThongTinDangNhap.HasPermission(DanhSachQuyen.UpdateThueBaoTuyen))
                     {
                        MessageBox.MessageBox msgBox = new Taxi.MessageBox.MessageBox();
                        if (msgBox.Show(this, "Bạn có đồng ý xóa không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNoCancel, Taxi.MessageBox.MessageBoxIcon.Question) == DialogResult.Yes.ToString())
                        {

                            GridEXRow row = ((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow();
                            int ID = Convert.ToInt32(row.Cells["ID"].Text);
                            // ID cua ban ghi
                            NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();


                            int So = NhatkyThuebaoControl.Delete(ID);
                            if (So > 0)
                            {
                                new MessageBox.MessageBox().Show(" xóa thành công");
                                //  NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();
                                DataTable dt = NhatkyThuebaoControl.GetAll();
                                grdNhanVien.DataMember = "ID";
                                grdNhanVien.SetDataBinding(dt, "ID");
                            }
                            else
                            {
                                new MessageBox.MessageBox().Show("xóa không thành công");
                            }
                         }
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show("Chỉ có quản trị hệ thống mới được xóa.");
                    }
                }
            }
            else if (e.Command.Key == "cmdXeChuaNhapDuDuLieu")
            {
                NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();
                DataTable dt = NhatkyThuebaoControl.GetDSNhungCuocChuaNhapDuThongTin();
                grdNhanVien.DataMember = "lID";
                grdNhanVien.SetDataBinding(dt, "lID");
            }
            else if (e.Command.Key == "cmdXeNhapDu")
            {
                LoadDSThueBao();
            }
            else if (e.Command.Key == "cmdTimKiem")
            {
                  frmTimKiemXeThueBao frm = new frmTimKiemXeThueBao ();
                  if (frm.ShowDialog() == DialogResult.OK)
                  {
                      NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();
                      DataTable dt = NhatkyThuebaoControl.GetDSCuocThuebao(frm.TuNgay(), frm.DenNgay(), frm.SoHieuXe(),frm.NoiDungTimKhac());
                      grdNhanVien.DataMember = "lID";
                      grdNhanVien.SetDataBinding(dt, "lID");
                  }
                 
            }
            else if (e.Command.Key == "cmdThoat")
            {
                this.Close();                 
            }
        }

        /// <summary>
        /// hiển thị thay đổi màu đồi với những những dòng chưa có Kmtrả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdNhanVien_FormattingRow(object sender, RowLoadEventArgs e)
        {
            //objThueBao.ThoiGianTra = new DateTime(1900, 01, 01);
            //objThueBao.KmTra = -1;
            //objThueBao.TienThucThu = -1;
            //objThueBao.KmThucDi = -1;
            //objThueBao.DongHoTien = -1;
            //objThueBao.GhiChu = "";
            //objThueBao.PhuTroi = "";
            GridEXRow row = e.Row;
            if (row.Cells["KmTra"].Text == "-1")
            {
                row.Cells["ThoiGianTra"].Text = "";
                row.Cells["KmTra"].Text = "";
                row.Cells["KmThucDi"].Text = "";
                row.Cells["DongHoTien"].Text = "";
                row.Cells["TienThucThu"].Text = "";
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Yellow;
                row.Cells["SoHieuXe"].FormatStyle = RowStyle;

            }
        }

        private void grdNhanVien_DoubleClick(object sender, EventArgs e)
        {
            grdNhanVien.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdNhanVien.SelectedItems.Count > 0)
            {
             GridEXRow row = ((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow();
             int KmTra = int.Parse(row.Cells["KmTra"].Value.ToString());
             int ID = int.Parse(row.Cells["ID"].Value.ToString());
             if (KmTra > 0)
             {
                 DateTime ThoiDiem = Convert.ToDateTime(row.Cells["ThoiDiem"].Value.ToString());
                 DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                 TimeSpan timeSpan = timeServer - ThoiDiem;
                 if (ThongTinDangNhap.HasPermission(DanhSachQuyen.UpdateThueBaoTuyen))
                 {
                     frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao(ID, true);
                     frmNhapNhatKyThueBaocontrol.ShowDialog();
                 }
                 else
                 {
                     new MessageBox.MessageBox().Show("Bạn chỉ sửa thông tin trong vòng 4 giờ khi đã nhập.");
                 }
                 
             }
             else{
              
                 frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao(ID);
                 frmNhapNhatKyThueBaocontrol.ShowDialog();
               } 
             this.LoadDSThueBao();
            }
        } 

        private void grdNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                grdNhanVien.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdNhanVien.SelectedItems.Count > 0)
                {
                    GridEXRow row = ((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow();
                    int KmTra = int.Parse(row.Cells["KmTra"].Value.ToString());
                    int ID = int.Parse(row.Cells["ID"].Value.ToString());
                    
                    if (KmTra > 0)
                    {
                        DateTime ThoiDiem = Convert.ToDateTime (row.Cells["ThoiDiem"].Value.ToString());
                        DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                        TimeSpan timeSpan = timeServer - ThoiDiem;
                        if (ThongTinDangNhap.HasPermission(DanhSachQuyen.UpdateThueBaoTuyen))
                        {
                            frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao(ID, true);
                            frmNhapNhatKyThueBaocontrol.Show();
                        }
                        else
                        {
                            new MessageBox.MessageBox().Show("Bạn chỉ sửa thông tin trong vòng 4 giờ khi đã nhập.");
                        }

                    }
                    else
                    {

                        frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao(ID);
                        frmNhapNhatKyThueBaocontrol.Show();
                    }
                    this.LoadDSThueBao();
                }

            }
        } 
    }
}