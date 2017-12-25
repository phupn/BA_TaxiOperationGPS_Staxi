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
using Janus.Windows.GridEX;

namespace Taxi.GUI
{
    public partial class frmGiamSatXe : Form
    {
        #region Init Form
        private Form m_frmParent = null;
        private Size m_MaxSize;
        private Size m_MinSize;
        private Timer TimerCapturePhone;
        private bool g_TimKiem = false;
        private bool g_PhongTo = true;
        private int g_RowPostionChoose = 0;
        private int g_VerticalScrollPosition = 0;
        private int g_HorizontalScrollPosition = 0;
        private bool g_bLoadLaiDuLieu = true;
        private bool g_HasThayDoiDongChon = false;
        public static bool g_ChayQuetXe = false;
        private List<NhanVien> G_ListLaiXe = new List<NhanVien>();

        public frmGiamSatXe()
        {
            InitializeComponent();
            this.Opacity = 0.4;
        }

        public frmGiamSatXe(Form _frmParent, List<NhanVien> ListLaiXe)
        {
            InitializeComponent();
            if (m_frmParent == null) m_frmParent = new Form();
            m_frmParent = _frmParent;
            this.Opacity = 0.4;
            G_ListLaiXe = ListLaiXe;

        }
        #endregion

        #region Load Form
        
        private void frmGiamSatXe_Load(object sender, EventArgs e)
        {
            radSBDD.Checked = true; 
            //this.LoadDSXeMatLienLac(chkSapXepTG.Checked, chkAnSBDD.Checked);
            m_MinSize = new Size(this.Width, 22);
            m_MaxSize = new Size(this.Width, this.Height);
            this.MinimumSize = m_MinSize;
            this.MaximumSize = m_MaxSize;
            SetViTriDatTrenManHinh(); g_PhongTo = true;
            InitTimerCapturePhone();
         }


        private void LoadDSXeMatLienLac(bool SapXepTheoThoiGian, bool AnMatLLSBDD)
        {
            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            gridDSXe.AutomaticSort = false;
            gridDSXe.DataSource = null;
            gridDSXe.DataMember = "listDSXe";
            gridDSXe.SetDataBinding(objKSXe.LayDSXeDangMatLienLac(SapXepTheoThoiGian, AnMatLLSBDD), "listDSXe");
        }

        public void SetViTriDatTrenManHinh()
        {
            this.Size = this.MaximumSize;
            this.Top = Screen.PrimaryScreen.Bounds.Height - 450 - 22; // do cao cua  form và do cao cua status
            this.Left = Screen.PrimaryScreen.Bounds.Width - 800;

        }

        private void SetViTriMinDatTrenManHinh()
        {
            this.Size = this.MinimumSize;
            this.Top = Screen.PrimaryScreen.Bounds.Height - 22; // do cao cua  form và do cao cua status
            this.Left = Screen.PrimaryScreen.Bounds.Width - 800;

        }
        #endregion

        #region Load Data
        public void LoadTrangThaiCuaXe()
        {
            if (radXeMatLienLac.Checked) this.LoadDSXeMatLienLac(chkSapXepTG.Checked, chkAnSBDD.Checked);
            else if (radXeHoatDong.Checked) this.LoadDSXeHoatDong();
            else if (radXeVe.Checked) this.LoadDSXeVe();
            else if (radXeNghi.Checked) this.LoadDSXeNghi();
            else if (radSBDD.Checked) this.LoadDSXeSBDD();
            else if (radTatCa.Checked) this.LoadTatCaCacXe();
        }

        private void LoadDSXeHoatDong()
        {
            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            gridDSXe.AutomaticSort = false;
            gridDSXe.DataSource = null;
            gridDSXe.DataMember = "listDSXe";
            gridDSXe.SetDataBinding(objKSXe.LayDSXeDangHoatDong(), "listDSXe");
        }

        private void LoadDSXeVe()
        {
            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            gridDSXe.AutomaticSort = false;
            gridDSXe.DataSource = null;
            gridDSXe.DataMember = "listDSXe";
            gridDSXe.SetDataBinding(objKSXe.LayDSXeDangVe(), "listDSXe");
        }

        private void LoadDSXeNghi()
        {
            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            gridDSXe.AutomaticSort = false;
            gridDSXe.DataSource = null;
            gridDSXe.DataMember = "listDSXe";
            gridDSXe.SetDataBinding(objKSXe.LayDSXeDangNghi(), "listDSXe");
        }

        private void LoadDSXeSBDD()
        {
            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            gridDSXe.AutomaticSort = false;
            gridDSXe.DataSource = null;
            gridDSXe.DataMember = "listDSXe";
            gridDSXe.SetDataBinding(objKSXe.LayDSXeDangDiSBDD(), "listDSXe");
        
        }

        private void LoadThongTinXeChiTiet(string SoHieuXe)
        {
            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            List<KiemSoatXeLienLac> ListKSXe = new List<KiemSoatXeLienLac> ();
            ListKSXe = objKSXe.LayThongTinChiTietCuaXe(SoHieuXe);
           

            if(ListKSXe != null && ListKSXe .Count>0)
            {
              objKSXe =  ListKSXe[0];
              if (objKSXe.IsHoatDong)
              {
                  if (objKSXe.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.BaoNghi)
                  {
                      radXeNghi.Checked = true;
                  }
                  else if (objKSXe.LoaiChoKhach == Taxi.Utils.LoaiChoKhach.ChoKhachDuongDai || objKSXe.LoaiChoKhach == Taxi.Utils.LoaiChoKhach.ChoKhachSanBay)
                  {
                      radSBDD.Checked = true;
                  }
                  else radXeHoatDong.Checked = true;
              }
              else radXeVe.Checked = true;              
            }
            gridDSXe.DataMember = "listDSXe";
            gridDSXe.SetDataBinding(ListKSXe, "listDSXe");
           
        }

        private void LoadTatCaCacXe( )
        {
            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            gridDSXe.AutomaticSort = false;
            gridDSXe.DataSource = null;
            gridDSXe.DataMember = "listDSXe";
            gridDSXe.SetDataBinding(objKSXe.LayTatcaDSXe(), "listDSXe");
        }

        public void LoadDSXe()
        {
            if (radXeMatLienLac.Checked) LoadDSXeMatLienLac(chkSapXepTG.Checked,chkAnSBDD.Checked );
            else if (radXeHoatDong.Checked) LoadDSXeHoatDong();
            else if (radXeVe .Checked) LoadDSXeVe();
            else if (radXeNghi.Checked) LoadDSXeNghi();
            else if (radSBDD.Checked) LoadDSXeSBDD();
            else if (radTatCa.Checked) LoadTatCaCacXe();
        }       

        private void LoadHanhTrinhXeTheoNgay(string SoHieuXe, DateTime Ngay)
        {
            List<KiemSoatXeLienLac> ListKSXe = new List<KiemSoatXeLienLac> ();
            ListKSXe = KiemSoatXeLienLac.GetDanhSachCacSuKienCuaXeTrongNgay(SoHieuXe, Ngay);
            gridHanhTrinhXe.DataMember = "listDSXe";
            gridHanhTrinhXe.SetDataBinding(ListKSXe, "listDSXe");

            
        }
        #endregion
       
        #region Cac ham lien quan toi Timer Capture Phone
        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Configuration.GetTimerCapturePhone();

            TimerCapturePhone = new Timer();
            TimerCapturePhone.Interval = 5000; // 1 giay mot lan refesh
            TimerCapturePhone.Tick += new EventHandler(TimerCapturePhone_Tick);
            TimerCapturePhone.Start();

        }
        /// <summary>
        /// Nhan cac cuoc goi moi 
        /// Nhan thong tin moi chuyen ve
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        public void TimerCapturePhone_Tick(object sender, EventArgs eArgs)
        {
            try
            {
                if (g_bLoadLaiDuLieu) // form active
                {
                    if (!g_TimKiem) LoadTrangThaiCuaXe();

                    if (gridDSXe.VerticalScrollPosition != g_VerticalScrollPosition)
                        gridDSXe.VerticalScrollPosition = g_VerticalScrollPosition;

                    if (gridDSXe.HorizontalScrollPosition != g_HorizontalScrollPosition)
                        gridDSXe.HorizontalScrollPosition = g_HorizontalScrollPosition;
                    SetRowSelect(g_RowPostionChoose);
                }
                System.Threading.Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Lỗi trong timer - giam sat xe", ex);
            }
        }

        #endregion Cac ham lien quan toi Timer Capture Phone

        #region Find
        private void radXeMatLienLac_CheckedChanged(object sender, EventArgs e)
        {
            LoadDSXe();
        }
        private void radXeNghi_CheckedChanged(object sender, EventArgs e)
        {

            LoadDSXe();
        }
        private void radXeHoatDong_CheckedChanged(object sender, EventArgs e)
        {

            LoadDSXe();
        }
        private void radXeVe_CheckedChanged(object sender, EventArgs e)
        {

            LoadDSXe();
        }
        private void radSBDD_CheckedChanged(object sender, EventArgs e)
        {
            LoadDSXe();
        }
        private void radTatCa_CheckedChanged(object sender, EventArgs e)
        {

            LoadDSXe();
        }
        #endregion

        #region Form Event
        /// <summary>
        /// hiênt hị hàng trình xe theo ngày.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimXeHanhTrinh_Click(object sender, EventArgs e)
        {
            string SoHieuXe = StringTools.TrimSpace(txtSoHieuXe.Text);
            if (SoHieuXe.Length > 0)
                LoadHanhTrinhXeTheoNgay(SoHieuXe, calNgay.Value);

        }

        private void frmGiamSatXe_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    e.Cancel = true;
            //}
            //else e.Cancel = false;
        }

        private void frmGiamSatXe_Activated(object sender, EventArgs e)
        {
            SetViTriDatTrenManHinh(); this.Opacity = 1;
            g_bLoadLaiDuLieu = true;
        }

        private void frmGiamSatXe_Deactivate(object sender, EventArgs e)
        {
            g_bLoadLaiDuLieu = false;
        }

        private void txtSoHieuXeKS_TextChanged(object sender, EventArgs e)
        {

            if (StringTools.TrimSpace(txtSoHieuXeKS.Text).Length > 0)
            {
                if (!Xe.KiemTraTonTaiCuaSoHieuXe(txtSoHieuXeKS.Text))
                {
                    errorProvider.SetError(txtSoHieuXeKS, "Số hiệu xe này không tồn tại");
                    //new MessageBox.MessageBox().Show(this, "Số hiệu xe này không tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);

                    return;
                }
                else
                {
                    errorProvider.SetError(txtSoHieuXeKS, "");
                }

            }
        }

        private void txtSoHieuXeKS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string SoHieuXe = StringTools.TrimSpace(txtSoHieuXeKS.Text);
                LoadThongTinXeChiTiet(SoHieuXe); g_TimKiem = true;
            }
        }

        private void btnTimKiemKS_Click(object sender, EventArgs e)
        {
            string SoHieuXe = StringTools.TrimSpace(txtSoHieuXeKS.Text);
            LoadThongTinXeChiTiet(SoHieuXe); g_TimKiem = true;
        }

        /// <summary>
        /// Xe ra hoạt động
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label6_Click(object sender, EventArgs e)
        {
            new frmRaHoatDong(this, G_ListLaiXe).ShowDialog();
        }

        /// <summary>
        /// báo nghỉ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label11_Click(object sender, EventArgs e)
        {
            new frmRaHoatDong(this, 3, G_ListLaiXe).ShowDialog();
        }

        /// <summary>
        /// Xe báo về
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label13_Click(object sender, EventArgs e)
        {
            new frmRaHoatDong(this, 4, G_ListLaiXe).ShowDialog();
        }

        /// <summary>
        /// Xe báo điểm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label9_Click(object sender, EventArgs e)
        {
            new frmRaHoatDong(this, 2, G_ListLaiXe).ShowDialog();
        }

        private void txtSoHieuXe_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                string SoHieuXe = StringTools.TrimSpace(txtSoHieuXe.Text);
                if(SoHieuXe.Length >0)
                    LoadHanhTrinhXeTheoNgay(SoHieuXe, calNgay.Value);
            }
        }
               
        #endregion

        #region Grid Event -- gridDSXe ---

        private void gridDSXe_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            KiemSoatXeLienLac objKSLL = (KiemSoatXeLienLac)e.Row.DataRow;
            if (objKSLL.ThoiDiemBao == DateTime.MinValue)
            {
                e.Row.Cells["ThoiDiemBao"].Text = "";
            }
            if (objKSLL.TrangThaiTong == 1) // ve mat lien lac Ăn ca
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.ForeColor = Color.Red;
                e.Row.RowStyle = RowStyle;
            }
            else if (objKSLL.TrangThaiTong == 2) // xe hoat dong
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.ForeColor = Color.Blue;
                e.Row.RowStyle = RowStyle;
            }
            else if (objKSLL.TrangThaiTong == 3) //  xe vê
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.ForeColor = Color.DeepPink;
                e.Row.Cells["SoHieuXe"].FormatStyle = RowStyle;
            }
            else if (objKSLL.TrangThaiTong == 4) //  xe nghi
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.ForeColor = Color.Gold;
                e.Row.Cells["SoHieuXe"].FormatStyle = RowStyle;
            }
            else if (objKSLL.TrangThaiTong == 5) //  xe 
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.ForeColor = Color.Green;
                e.Row.Cells["SoHieuXe"].FormatStyle = RowStyle;
            }

            else
            {

                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.ForeColor = Color.Black;
                e.Row.Cells["SoHieuXe"].FormatStyle = RowStyle;
            }

        }

        private void gridDSXe_Click(object sender, EventArgs e)
        {

        }

        private void gridDSXe_SelectionChanged(object sender, EventArgs e)
        {
            // luu dong dang duoc chon            
            if (gridDSXe.Row >= 0)
            {
                g_RowPostionChoose = gridDSXe.Row;
                g_HasThayDoiDongChon = true;
            }
        }

        private void SetRowSelect(int ViTri)
        {
            if (gridDSXe.RowCount > 0)
            {
                if ((ViTri >= 0) && (ViTri < gridDSXe.RowCount))
                {
                    gridDSXe.Row = ViTri;
                }
            }
        }

        private void gridDSXe_Scroll(object sender, EventArgs e)
        {
           
            g_VerticalScrollPosition = gridDSXe.VerticalScrollPosition;
            g_HorizontalScrollPosition = gridDSXe.HorizontalScrollPosition;
        }
        #endregion

        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5: // Mo nhap du lieu dong 1
                    {
                        if (gridDSXe.Focused)
                        {
                            if (gridDSXe.SelectedItems != null && gridDSXe.SelectedItems.Count > 0)
                            {
                                //Thu doi mau
                                GridEXRow rowSelect = ((GridEXSelectedItem)gridDSXe.SelectedItems[0]).GetRow();
                                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                                rowSelect.RowStyle = RowStyle;
                                //End - Thu doi mau


                                string SoHieuXe = StringTools.TrimSpace(rowSelect.Cells["SoHieuXe"].Text);
                                if (SoHieuXe.Length > 0) new frmRaHoatDong(this, 1, SoHieuXe, G_ListLaiXe).ShowDialog();
                                else new frmRaHoatDong(this, 1, G_ListLaiXe).ShowDialog();
                                //tra ve mau cu
                                RowStyle = new GridEXFormatStyle();
                                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                                rowSelect.RowStyle = RowStyle;
                            }
                            else new frmRaHoatDong(this, 1, G_ListLaiXe).ShowDialog();
                        }
                        else new frmRaHoatDong(this, 1, G_ListLaiXe).ShowDialog();
                        break;
                    }
                //case Keys.F6:
                //    {
                //        if (gridDSXe.Focused)
                //        {
                //            if (gridDSXe.SelectedItems != null && gridDSXe.SelectedItems.Count > 0)
                //            {
                //                //Thu doi mau
                //                GridEXRow rowSelect = ((GridEXSelectedItem)gridDSXe.SelectedItems[0]).GetRow();
                //                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                //                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                //                rowSelect.RowStyle = RowStyle;
                //                //End - Thu doi mau


                //                string SoHieuXe = StringTools.TrimSpace(rowSelect.Cells["SoHieuXe"].Text);
                //                if (SoHieuXe.Length > 0) new frmRaHoatDong(this, 2, SoHieuXe, G_ListLaiXe).ShowDialog();
                //                else new frmRaHoatDong(this, 2, G_ListLaiXe).ShowDialog();

                //                //tra ve mau cu
                //                RowStyle = new GridEXFormatStyle();
                //                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                //                rowSelect.RowStyle = RowStyle;
                //            }
                //            else new frmRaHoatDong(this, 2, G_ListLaiXe).ShowDialog();
                //        }
                //        else new frmRaHoatDong(this, 2, G_ListLaiXe).ShowDialog();
                //        break;
                //    }
                case Keys.F7: // Mo nhap du lieu dong 1
                    {
                        if (gridDSXe.Focused)
                        {
                            if (gridDSXe.SelectedItems != null && gridDSXe.SelectedItems.Count > 0)
                            {
                                //Thu doi mau
                                GridEXRow rowSelect = ((GridEXSelectedItem)gridDSXe.SelectedItems[0]).GetRow();
                                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                                rowSelect.RowStyle = RowStyle;
                                //End - Thu doi mau

                                string SoHieuXe = StringTools.TrimSpace(rowSelect.Cells["SoHieuXe"].Text);
                                if (SoHieuXe.Length > 0) new frmRaHoatDong(this, 3, SoHieuXe, G_ListLaiXe).ShowDialog();
                                else new frmRaHoatDong(this, 3, G_ListLaiXe).ShowDialog();


                                //tra ve mau cu
                                RowStyle = new GridEXFormatStyle();
                                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                                rowSelect.RowStyle = RowStyle;
                            }
                            else new frmRaHoatDong(this, 3, G_ListLaiXe).ShowDialog();
                        }
                        else new frmRaHoatDong(this, 3, G_ListLaiXe).ShowDialog();
                        break;
                    }
                case Keys.F8:  // Mo nhap du lieu dong 1
                    {
                        if (gridDSXe.Focused)
                        {
                            if (gridDSXe.SelectedItems != null && gridDSXe.SelectedItems.Count > 0)
                            {
                                //Thu doi mau
                                GridEXRow rowSelect = ((GridEXSelectedItem)gridDSXe.SelectedItems[0]).GetRow();
                                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                                rowSelect.RowStyle = RowStyle;
                                //End - Thu doi mau

                                string SoHieuXe = StringTools.TrimSpace(rowSelect.Cells["SoHieuXe"].Text);
                                if (SoHieuXe.Length > 0) new frmRaHoatDong(this, 4, SoHieuXe, G_ListLaiXe).ShowDialog();
                                else new frmRaHoatDong(this, 4, G_ListLaiXe).ShowDialog();


                                //tra ve mau cu
                                RowStyle = new GridEXFormatStyle();
                                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                                rowSelect.RowStyle = RowStyle;
                            }
                            else new frmRaHoatDong(this, 4, G_ListLaiXe).ShowDialog();
                        }
                        else new frmRaHoatDong(this, 4, G_ListLaiXe).ShowDialog();
                        break;
                    }
                case Keys.F2: // Minimine
                    {
                        if (g_PhongTo)
                        {
                            this.SetViTriMinDatTrenManHinh(); g_PhongTo = false;
                        }
                        else
                        {
                            this.SetViTriDatTrenManHinh(); g_PhongTo = true;
                        }
                        break;
                    }
                case Keys.Alt | Keys.S: // Minimine
                    {
                        txtSoHieuXe.Focus(); return true;
                        break;
                    }
                case Keys.Alt | Keys.X: // Minimine
                    {
                        txtSoHieuXeKS.Focus(); return true;
                        break;
                    }
                case Keys.F1:
                    {
                        m_frmParent.Activate(); this.Opacity = 0.4;
                        return true;
                        break;
                    }
                default:
                    {


                    }
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        void frmGiamSatXe_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.OnMinimumSizeChanged(e);
        }

        #endregion XU LY HOTKEY
    }
}