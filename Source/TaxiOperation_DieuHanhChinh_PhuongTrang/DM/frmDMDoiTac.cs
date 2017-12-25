using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Utils;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using Taxi.Common.Extender;
using System.Text.RegularExpressions;
namespace Taxi.GUI
{
    public partial class frmDMDoiTac : Form
    {
        BackgroundWorker bw;
        private fmProgress m_fmProgress = null;
        private List<DoiTac> ListDoiTac = new List<DoiTac>();
        public frmDMDoiTac()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDMDoiTac_Load);
        }

        void frmDMDoiTac_Load(object sender, EventArgs e)
        {
            LoadListDoiTac();

        }

        private void LoadListDoiTac()
        {
            ListDoiTac = new DoiTac().GetListOfDoiTacs();
            grdDoiTac.DataSource = ListDoiTac;
            grdDoiTac.DataMember = "ListOfDoiTac";
            grdDoiTac.SetDataBinding(ListDoiTac, "ListOfDoiTac");


            gridExport.DataSource = null;
            gridExport.DataMember = "ListOfDoiTacEx";
            gridExport.SetDataBinding(ListDoiTac, "ListOfDoiTacEx");

        }

        private void cmdAdd_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdNew cmdEdit cmdDelete cmdExit cmdHelp
            if (e.Command.Key == "cmdNew")
            {
                this.ThemDoiTac();
            }
            else if (e.Command.Key == "cmdEdit")
            {
                this.SuaDoiTac();
            }
            else if (e.Command.Key == "cmdDelete")
            {
                DeleteDoiTac();
            }
            else if (e.Command.Key == "cmdActive")
            {
                this.ActiveDoiTac(true);
            }
            else if (e.Command.Key == "cmdUnActive")
            {
                this.ActiveDoiTac(false);
            }
            else if (e.Command.Key == "cmdExit")
            {
                this.Close();
                this.Dispose();
            }
            else if (e.Command.Key == "cmdHelp")
            {
                frmDoiTacTimKiem frm = new frmDoiTacTimKiem();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ListDoiTac = frm.GetResultListOfDoiTac();
                    if (ListDoiTac.Count > 0)
                    {
                        grdDoiTac.DataSource = null;
                        grdDoiTac.DataMember = "ListOfDoiTac";
                        grdDoiTac.SetDataBinding(ListDoiTac, "ListOfDoiTac");

                        gridExport.DataSource = null;
                        gridExport.DataMember = "ListOfDoiTacEx";
                        gridExport.SetDataBinding(ListDoiTac, "ListOfDoiTacEx");
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy kết quả nào");
                        return;
                    }
                }
            }
            else if (e.Command.Key == "cmdCapNhatMoiGioi")
            {
                frmCapNhatThongTinMoiGioi frm = new frmCapNhatThongTinMoiGioi();
                frm.ShowDialog();
                // // Create a background thread
                //bw  = new BackgroundWorker();
                // bw.DoWork += new DoWorkEventHandler(bw_DoWorkNew);
                // bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

                // // Create a progress form on the UI thread
                // m_fmProgress = null;
                // m_fmProgress = new fmProgress();

                // // Kick off the Async thread
                // bw.RunWorkerAsync();

                // // Lock up the UI with this modal progress form.
                // try
                // {

                //     m_fmProgress.ShowDialog(this);
                //     m_fmProgress = null;

                // }
                // catch (Exception ex)
                // {

                // }
            }
            else if (e.Command.Key == "cmdKiemTraTrung")
            {
                frmKiemTraTrungSoDoiTac frm = new frmKiemTraTrungSoDoiTac();
                frm.Show();
            }
            else if (e.Command.Key == "cmdExcel")
            {
                this.XuatExcel();
            }
        }

        private void bw_DoWorkNew(object sender, DoWorkEventArgs e)
        {

            try
            {
                m_fmProgress.lblDescription.Invoke(
                   (MethodInvoker)delegate()
                   {
                       m_fmProgress.lblDescription.Text = "Hệ thống đang xử lý dữ liệu ... ";
                   }
               );
            }
            catch (Exception ex)
            {
            }

            DoiTac.CapNhatDuLieu();

            if (m_fmProgress.Cancel)
            {
                // Set the e.Cancel flag so that the WorkerCompleted event
                // knows that the process was canceled.
                e.Cancel = true;
                return;
            }

        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. First we should hide the
            // modal Progress Form to unlock the UI. The we need to inspect our
            // response to see if an error occured, a cancel was requested or
            // if we completed succesfully.

            // Hide the Progress Form
            if (m_fmProgress != null)
            {
                m_fmProgress.Hide();
                m_fmProgress = null;
                new MessageBox.MessageBoxBA().Show(this, "Cập nhật cuộc gọi môi giới thành công.");
                this.bw = null;
            }

            // Check to see if an error occured in the 
            // background process.
            if (e.Error != null)
            {
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                bw = null;
                return;
            }


        }

        /// <summary>
        /// Mo form DOiTac de edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDoiTac_DoubleClick(object sender, EventArgs e)
        {
            grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDoiTac.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow();
                DoiTac objDoiTac = (DoiTac)((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow().DataRow;
                string MaDoiTacCu = objDoiTac.MaDoiTac;
                frmDoiTac frm = new frmDoiTac(objDoiTac, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objDoiTac = frm.DoiTac;
                    frm.Dispose();
                    //Insert DataBase
                    objDoiTac.NguoiSua = ThongTinDangNhap.USER_ID;
                    if (!objDoiTac.Update(MaDoiTacCu))
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi cập nhật đối tác");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListDoiTac();
                        //if (frm.IsThayDoiDienThoai)
                        //{
                        //    //if (new MessageBox.MessageBox().Show("Có một môi giới mới, bạn cần cập nhật lại cuộc gọi môi giới", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                        //    //{
                        //    //    // Lay cuoc goi da ket thuc
                        //    //    List<DieuHanhTaxi> lstDieuHanhTaxi = new List<DieuHanhTaxi>();
                        //    //    lstDieuHanhTaxi = new DieuHanhTaxi().Get_CuocGoi_KetThuc(" ", " ");

                        //    //    if (!DieuHanhTaxi.UpdateLaiCuocGoiMoiGioi(objDoiTac, lstDieuHanhTaxi))
                        //    //    {
                        //    //        new MessageBox.MessageBox().Show("Lỗi cập nhật cuộc gọi môi giới");
                        //    //        return;
                        //    //    }
                        //    //    else
                        //    //    {
                        //    //        new MessageBox.MessageBox().Show("Cập nhật cuộc gọi môi giới thành công");
                        //    //        return;
                        //    //    }
                        //    //}
                        //}
                    }
                }
                else return;
            }
        }

        private void grdDoiTac_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);

        }

        private void HienThiAnhTrangThai_MauChu(GridEXRow row)
        {
            try
            {
                DateTime tempDate = new DateTime(2000, 1, 1, 0, 0, 1);
                DoiTac objDoiTac = (DoiTac)row.DataRow;
                if (objDoiTac.NgayTao <= tempDate)
                {

                    row.Cells["NgayTao"].Text = string.Empty;
                }
                if (objDoiTac.NgaySua <= tempDate)
                {
                    row.Cells["NgaySua"].Text = string.Empty;
                }
                if (objDoiTac.NgayKetThuc <= tempDate)
                {
                    row.Cells["NgayKetThuc"].Text = string.Empty;
                }
                else
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Pink;
                    row.RowStyle = RowStyle;
                }

            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }
        #region Add, Delete DOITAC

        private void ThemDoiTac()
        {
            string MaDT = "DT1";
            // Khoi tao doi tuong DoiTac voi ma
            if (ListDoiTac != null && ListDoiTac.Count > 0)
            {
               var l= ListDoiTac.Select(p=>new {Ma=Regex.Replace(p.MaDoiTac, @"[^\d]", "")}).OrderBy(p => p.Ma).Last();
              MaDT= string.Format("DT{0:0000}",l.Ma.To<int>()+1);
            }
            DoiTac objDoiTac = new DoiTac(MaDT, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, true, "", "", 0, "");
            frmDoiTac frm = new frmDoiTac(objDoiTac, true);// them moi
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                objDoiTac = frm.GetDoiTac();
                //Insert DataBase
                if (StringTools.TrimSpace(objDoiTac.Name).Length <= 0) return;

                if (StringTools.TrimSpace(objDoiTac.Address).Length <= 0) return;

                //if (StringTools.TrimSpace(objDoiTac.Phones).Length < 8) return;
                objDoiTac.NguoiTao = ThongTinDangNhap.USER_ID;
                bool Success = objDoiTac.Insert();
                if (!Success)
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi thêm mới đối tác");
                    return;
                }
                else
                {
                    //Load lai grid
                    LoadListDoiTac();
                    //if (new MessageBox.MessageBox().Show("Có một môi giới mới, bạn cần cập nhật lại cuộc gọi môi giới", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                    //{
                    //    // Lay cuoc goi da ket thuc
                    //    List<DieuHanhTaxi> lstDieuHanhTaxi = new List<DieuHanhTaxi>();
                    //    lstDieuHanhTaxi = new DieuHanhTaxi().Get_CuocGoi_KetThuc(" ", " ");

                    //    if (!DieuHanhTaxi.UpdateLaiCuocGoiMoiGioi(objDoiTac, lstDieuHanhTaxi))
                    //    {
                    //        new MessageBox.MessageBox().Show("Lỗi cập nhật cuộc gọi môi giới");
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        new MessageBox.MessageBox().Show("Cập nhật cuộc gọi môi giới thành công");
                    //        return;
                    //    }
                    //}
                }

            }


        }

        private void SuaDoiTac()
        {
            grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDoiTac.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow();
                DoiTac objDoiTac = (DoiTac)((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow().DataRow;
                string MaDoiTacCu = objDoiTac.MaDoiTac;
                frmDoiTac frm = new frmDoiTac(objDoiTac, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objDoiTac = frm.GetDoiTac();
                    if (StringTools.TrimSpace(objDoiTac.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objDoiTac.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objDoiTac.Phones).Length < 8) return;
                    //Insert DataBase
                    objDoiTac.NguoiSua = ThongTinDangNhap.USER_ID;
                    bool Success = objDoiTac.Update(MaDoiTacCu);
                    if (!Success)
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi cập nhật đối tác");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListDoiTac();
                        //if (frm.IsThayDoiDienThoai)
                        //{
                        //    if (new MessageBox.MessageBox().Show("Có một môi giới mới, bạn cần cập nhật lại cuộc gọi môi giới", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                        //    {
                        //        // Lay cuoc goi da ket thuc
                        //        List<DieuHanhTaxi> lstDieuHanhTaxi = new List<DieuHanhTaxi>();
                        //        lstDieuHanhTaxi = new DieuHanhTaxi().Get_CuocGoi_KetThuc(" ", " ");

                        //        if (!DieuHanhTaxi.UpdateLaiCuocGoiMoiGioi(objDoiTac, lstDieuHanhTaxi))
                        //        {
                        //            new MessageBox.MessageBox().Show("Lỗi cập nhật cuộc gọi môi giới");
                        //            return;
                        //        }
                        //        else
                        //        {
                        //            new MessageBox.MessageBox().Show("Cập nhật cuộc gọi môi giới thành công");
                        //            return;
                        //        }
                        //    }
                        //}
                    }

                }
            }
        }

        private void ActiveDoiTac(bool isActive)
        {
            grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDoiTac.SelectedItems.Count > 0)
            {
                GridEXRow[] rows = grdDoiTac.GetCheckedRows();
                if (rows != null && rows.Length > 0)
                {
                    string Msg_Active = "";
                    if (isActive)
                    {
                        Msg_Active = "cập nhật đang hoạt động";
                    }
                    else
                    {
                        Msg_Active = "tạm ngừng hoạt động";
                    }
                    MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
                    if (msg.Show(this, String.Format("Bạn có muốn {0} không ?", Msg_Active), "Xóa môi giới", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                    {
                        foreach (GridEXRow row in rows)
                        {
                            DoiTac objDoiTac = (DoiTac)row.DataRow;
                            objDoiTac.Active(objDoiTac.MaDoiTac,isActive,ThongTinDangNhap.USER_ID);
                        }
                        LoadListDoiTac();
                    }
                }
            }
        }

        private void DeleteDoiTac()
        {
            grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDoiTac.SelectedItems.Count > 0)
            {
                GridEXRow[] rows = grdDoiTac.GetCheckedRows();
                if (rows != null && rows.Length > 0)
                {
                    MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
                    if (msg.Show(this, "Bạn có xóa danh sách môi giới không ?", "Xóa môi giới", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                    {
                        foreach (GridEXRow row in rows)
                        {
                            DoiTac objDoiTac = (DoiTac)row.DataRow;
                            objDoiTac.Delete(objDoiTac.MaDoiTac);
                        }
                        LoadListDoiTac();
                    }
                }
            }
        }

        private void XuatExcel()
        {
            string FilenameDefault = "DSMoiGioi.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                //gridEXExporter1.GridEX = this.grdDoiTac;
                gridEXExporter1.IncludeHeaders = true;
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

        private void NhapTuExcel()
        {

        }
        #endregion Add, Delete DOITAC



    }
}