using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Taxi.Utils;
using Taxi.Business.DM;
using Taxi.Business.BaoCao;
using Janus.Windows.GridEX;
using EFiling.Utils;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoCSKHChiTiet : Form
    {
        public const string KYTU_GOIDEN = "A";
        public const string KYTU_GOIDI = "B";

        private fmProgress m_fmProgress = null;

        List<CSKHChiTiet> g_ListDuLieu;

        private string g_MaNhanVien = "";
        private int g_SoChuyen = -1; // tat ca
        private int g_CongTyID = 0;
        private bool g_DaLoadDuLieu = false; // da thuc hien load du lieu
        private DataTable g_dtDuLieu;
        public frmBaoCaoCSKHChiTiet()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnExportExcel.Enabled = false;

            chkGoiTaxi.Checked = false;
            chkDonDuoc.Enabled = chkGoiTaxi.Checked;
            chkTruotHoan.Enabled = chkGoiTaxi.Checked;
            chkKhongXe.Enabled = chkGoiTaxi.Checked;
            chkDonDuocXe888.Enabled = chkGoiTaxi.Checked;
            chkXe999.Enabled = chkGoiTaxi.Checked;
        }



        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            g_DaLoadDuLieu = false;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;

            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                string sVung = "";
                int  SoLanKhachGoiLai =0;
                if(StringTools.TrimSpace(txtSoLanGoiLai.Text ).Length >0)
                    SoLanKhachGoiLai = Convert.ToInt32 (StringTools.TrimSpace(txtSoLanGoiLai.Text ));

                bool isGoiTaxi = chkGoiTaxi.Checked;
                bool isGoiLai = chkGoiLai.Checked;
                bool isDonDuoc = (chkDonDuoc.Checked & isGoiTaxi);
                bool isDonDuoc888 = (chkDonDuocXe888.Checked & isGoiTaxi);
                bool isTruotHoan  = (chkTruotHoan.Checked & isGoiTaxi);
                bool isKhongXe = (chkKhongXe.Checked & isGoiTaxi);
                bool isKhongXe999 = (chkXe999.Checked & isGoiTaxi);

                string idTongDai = StringTools.TrimSpace (txtIDTD.Text );
                string idCS = StringTools.TrimSpace(txtIDCS.Text);
                string idDienThoai = StringTools.TrimSpace(txtIDDT.Text);
                if (idCS.Length < 2) idCS = string.Empty;
                sVung = StringTools.TrimSpace(txtVung.Text);
                


                g_ListDuLieu = Taxi.Business.BaoCao.CSKHChiTiet.GetBCCSKHChiTiet(calTuNgay.Value, calDenNgay.Value, sVung, SoLanKhachGoiLai,isDonDuoc,isDonDuoc888, isTruotHoan,isKhongXe,isKhongXe999, idTongDai,idCS,idDienThoai,isGoiTaxi,isGoiLai);
                gridEX1.DataMember = "ListDienThoai";
                gridEX1.SetDataBinding(g_ListDuLieu, "ListDienThoai"); 
                SetUnActiveRefreshButton();
            }
            else
            {
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                return;
            }
        }

        private void editPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editSoChuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editPhut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        private void gridDienThoai_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BaoCao_CSKH_ChiTiet.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    List<CSKHChiTiet>  ListTemp;
                    if (g_ListDuLieu != null && g_ListDuLieu.Count > 0)
                    {
                         ListTemp = new List<CSKHChiTiet>();
                        foreach (CSKHChiTiet objCSKH in g_ListDuLieu)
                        {
                            ListTemp.Add(objCSKH);
                        }
                    }
                    else return;
                    gridEX2.Visible = true ;
                    gridEX2.DataMember = "ListDienThoai";

                    gridEX2.SetDataBinding(ListTemp, "ListDienThoai");

                    gridEXExporter1.GridEX = this.gridEX2;

                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export((Stream)objFile);
                    gridEX2.Visible = false   ;
                    if (new MessageBox.MessageBox().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNoCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                    {
                        FileTools.OpenFileExcel(saveFileDialog1.FileName);
                    }

                }
            }
            catch (Exception ex)
            {
               
                new MessageBox.MessageBox().Show("Có lỗi tạo file Excel.", "Thông báo");
            }
        }
        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void editNhanVien_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void cboNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void editSochuyen_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radSapXepMaKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radSapXepSoChuyen_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void intSoChuyen_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            CSKHChiTiet objCSKH = (CSKHChiTiet)e.Row.DataRow;
            if (objCSKH.LAN1_Gio == DateTime.MinValue)
            {
                e.Row.Cells["LAN1_Gio"].Text = "";
            }
            if (objCSKH.LAN2_Gio == DateTime.MinValue)
            {
                e.Row.Cells["LAN2_Gio"].Text = "";
            }
            if (objCSKH.LAN3_Gio == DateTime.MinValue)
            {
                e.Row.Cells["LAN3_Gio"].Text = "";
            }
            else
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Yellow ;
                e.Row.RowStyle = RowStyle;
            }
            if (objCSKH.LAN4_Gio == DateTime.MinValue)
            {
                e.Row.Cells["LAN4_Gio"].Text = "";
            }
            else
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Red ;
                e.Row.RowStyle = RowStyle;
            }

            if (objCSKH.CSKH_Lan1_Gio == DateTime.MinValue)
            {
                e.Row.Cells["CSKH_Lan1_Gio"].Text = "";
            }
            if (objCSKH.CSKH_Lan2_Gio == DateTime.MinValue)
            {
                e.Row.Cells["CSKH_Lan2_Gio"].Text = "";
            }
            if (objCSKH.CSKH_Lan3_Gio == DateTime.MinValue)
            {
                e.Row.Cells["CSKH_Lan3_Gio"].Text = "";
            }
            if (objCSKH.CSKH_Lan4_Gio == DateTime.MinValue)
            {
                e.Row.Cells["CSKH_Lan4_Gio"].Text = "";
            }

            if (objCSKH.GioDonKhach == DateTime.MinValue)
            {
                e.Row.Cells["GioDon"].Text = "";
            }


        }

        private void gridEX1_SelectionChanged(object sender, EventArgs e)
        {
            gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection; 
            CSKHChiTiet objOtem = new CSKHChiTiet(); 

            if (gridEX1.SelectedItems.Count > 0)
            {
                objOtem = (CSKHChiTiet)(gridEX1.SelectedItems[0]).GetRow().DataRow;

                HienThiLuaChoNgheGhiAm(objOtem);
                 
            }
        }

        private void HienThiLuaChoNgheGhiAm(CSKHChiTiet objOtem)
        {
            if (objOtem.LAN1_Gio != DateTime.MinValue)
                radGoiDenLan1.Visible = true;
            else radGoiDenLan1.Visible = false;

            if (objOtem.LAN2_Gio != DateTime.MinValue)
                radGoiDenLan2.Visible = true;
            else radGoiDenLan2.Visible = false;

            if (objOtem.LAN3_Gio != DateTime.MinValue)
                radGoiDenLan3.Visible = true;
            else radGoiDenLan3.Visible = false;

            if (objOtem.LAN4_Gio != DateTime.MinValue)
                radGoiDenLan4.Visible = true;
            else radGoiDenLan4.Visible = false;

            if (objOtem.CSKH_Lan1_Gio != DateTime.MinValue)
                radGoiCSLan1.Visible = true;
            else
                radGoiCSLan1.Visible = false ;

            if (objOtem.CSKH_Lan2_Gio != DateTime.MinValue)
                radGoiCSLan2.Visible = true;
            else
                radGoiCSLan2.Visible = false ;

            if (objOtem.CSKH_Lan3_Gio != DateTime.MinValue)
                radGoiCSLan3.Visible = true;
            else
                radGoiCSLan3.Visible = false ;

            if (objOtem.CSKH_Lan4_Gio != DateTime.MinValue)
                radGoiCSLan4.Visible = true;
            else
                radGoiCSLan4.Visible = false ;
        }

        #region play wave sound
        private void btnPlay_Click(object sender, EventArgs e)
        {
            string filenameDB = "";
            string filenameVoice = "";
            gridEX1 .SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            CSKHChiTiet objItem = null ;
            string KyTuDaiDienCuocGoi ="";
            DateTime ThoiDiemCuocGoiDiDen  = DateTime.MinValue;
            if (gridEX1.SelectedItems.Count > 0)
            {
                objItem = (CSKHChiTiet)(gridEX1.SelectedItems[0]).GetRow().DataRow;
                
                filenameDB = GetFileOfCuocGoi(objItem, out KyTuDaiDienCuocGoi,out ThoiDiemCuocGoiDiDen);   
                lblFilename.Text = filenameDB;

                if(filenameDB.Length >0)
                    filenameVoice = NgheLaiCuocGoi.GetFileNameCuocDi(filenameDB);

            }
            else return;
            // Xay dung Tools tìm kiếm file.

            //if (!FileTools.IsExsitFile(filenameVoice))
            //{
            //    filenameVoice = NgheLaiCuocGoi.GetFileVoiceCuaMotCuocGoi(objItem.Line, objItem.PhoneNumber, objItem.ThoiDiemGoi, EFiling.Utils.TypeCall.Incoming, ThongTinCauHinh.ThuMucFileAmThanh);
            //}

            if (filenameVoice.Length > 0)
            {
                player1.FileName = filenameVoice;
                if (player1.FileName != "")
                {
                    player1.Play();
                    btnPause.Text = "Pause";
                    this.timer1.Enabled = true;
                }
                else
                {
                    new MessageBox.MessageBox().Show(@"File không tồn tại.Bạn cần kiểm tra lại đường dẫn tới thư mục lưu file âm thanh.Thư mục này phải được lưu cùng với thư mục của hệ thống bắt số.Ví dụ : \\\maychu\GhiAm. Hoặc bạn có thể tìm ở file gốc.");
                }
            }
            else
            {
                if (objItem == null) return;

                if (new MessageBox.MessageBox().Show(this, "Chọn file gốc để nghe.", "Thong bao", Taxi.MessageBox.MessageBoxButtons.OKCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.OK.ToString())
                {

                    string FileNameWildcard = StringTools.GetFilenameWidlcard(KyTuDaiDienCuocGoi, objItem.SoDienThoai);
                    frmTimFile frmTim = new frmTimFile(NgheLaiCuocGoi.GetFullDirectory(ThongTinCauHinh.ThuMucFileAmThanh, ThoiDiemCuocGoiDiDen)      , FileNameWildcard);
                    frmTim.ShowDialog();
                    if (frmTim.DialogResult == DialogResult.OK)
                    {
                        player1.FileName = frmTim.GetFilename();
                        this.lblFilename.Text = player1.FileName;
                        if (player1.FileName != "")
                        {
                            player1.Play();
                            btnPause.Text = "Pause";
                            this.timer1.Enabled = true;
                        }
                        else
                        {
                            new MessageBox.MessageBox().Show(@"File không tồn tại.Bạn cần kiểm tra lại đường dẫn tới thư mục lưu file âm thanh.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// hàm trả về ký tự wildcard của 
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="WidlCard"></param>
        /// <returns></returns>
        private string GetFileOfCuocGoi(CSKHChiTiet Item, out string WidlCard,out DateTime  ThoiDiemGoiDiDen )
        {
            string fileName = "";
            WidlCard = ""; ThoiDiemGoiDiDen = DateTime.MinValue;
            if (radGoiDenLan1.Checked) { fileName = Item.LAN1_FileGhiAm; WidlCard = KYTU_GOIDEN; ThoiDiemGoiDiDen = Item.LAN1_Gio; }
            else if (radGoiDenLan2.Checked) { fileName = Item.LAN2_FileGhiAm; WidlCard = KYTU_GOIDEN; ThoiDiemGoiDiDen = Item.LAN2_Gio; }
            else if (radGoiDenLan3.Checked) { fileName = Item.LAN3_FileGhiAm; WidlCard = KYTU_GOIDEN; ThoiDiemGoiDiDen = Item.LAN3_Gio ; }
            else if (radGoiDenLan4.Checked) { fileName = Item.LAN4_FileGhiAm; WidlCard = KYTU_GOIDEN; ThoiDiemGoiDiDen = Item.LAN4_Gio; }
            else if (radGoiCSLan1.Checked) { fileName = CuocGoiDi.GetFileGhiAmCuocGoiDi(Item.SoDienThoai, Item.CSKH_Lan1_Gio); WidlCard = KYTU_GOIDI; ThoiDiemGoiDiDen = Item.CSKH_Lan1_Gio; }
            else if (radGoiCSLan2.Checked) { fileName = CuocGoiDi.GetFileGhiAmCuocGoiDi(Item.SoDienThoai, Item.CSKH_Lan2_Gio); WidlCard = KYTU_GOIDI; ThoiDiemGoiDiDen = Item.CSKH_Lan2_Gio; }
            else if (radGoiCSLan3.Checked) { fileName = CuocGoiDi.GetFileGhiAmCuocGoiDi(Item.SoDienThoai, Item.CSKH_Lan3_Gio); WidlCard = KYTU_GOIDI; ThoiDiemGoiDiDen = Item.CSKH_Lan3_Gio; }
            else if (radGoiCSLan4.Checked) { fileName = CuocGoiDi.GetFileGhiAmCuocGoiDi(Item.SoDienThoai, Item.CSKH_Lan4_Gio); WidlCard = KYTU_GOIDI; ThoiDiemGoiDiDen = Item.CSKH_Lan4_Gio; }

            return fileName;
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnPause.Enabled = player1.Status != "stopped";
            btnStop.Enabled = player1.Status != "stopped";
            int pos = (player1.PositionInMS * this.tbPosition.Maximum) / player1.DurationInMS;
            this.tbPosition.Value = pos;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (player1.Status == "paused")
            {
                player1.Resume();
                btnPause.Text = "Pause";
            }
            else
            {
                player1.Pause();
                btnPause.Text = "Resume";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player1.Stop();
            this.timer1.Enabled = false;
            this.tbPosition.Value = 0;
        }
        #endregion

        private void radGoiDenLan1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkDonDuoc_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkTruotHoan_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkKhongXe_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void txtIDTD_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void txtIDCS_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void txtSoLanGoiLai_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkXe999_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXe999.Checked)
            {
                chkKhongXe.Checked = false;
            }
            SetActiveRefreshButton();
        }

        private void chkDonDuocXe888_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDonDuocXe888.Checked)
            {
                chkDonDuoc.Checked = false;
            }
            SetActiveRefreshButton();
        }

        private void txtVung_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void txtIDDT_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            chkGoiLai.Checked = !chkGoiTaxi.Checked;
            chkDonDuoc.Enabled = chkGoiTaxi.Checked;
            chkTruotHoan.Enabled = chkGoiTaxi.Checked;
            chkKhongXe.Enabled = chkGoiTaxi.Checked;
            chkDonDuocXe888.Enabled = chkGoiTaxi.Checked;
            chkXe999.Enabled = chkGoiTaxi.Checked;

            SetActiveRefreshButton();
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            chkGoiTaxi.Checked = ! chkGoiLai.Checked;
            SetActiveRefreshButton();
        }
 
    }
}