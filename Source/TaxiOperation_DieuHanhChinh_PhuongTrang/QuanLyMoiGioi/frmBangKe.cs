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
using TaxiOperation_DieuHanhChinh.QuanLyMoiGioi;

namespace Taxi.GUI
{
    public partial class frmBangKe : Form
    {
        private BackgroundWorker bw;
        private DataTable dtDoiTac;
        public frmBangKe()
        {
            InitializeComponent();
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWorkNew);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
          
            this.Load += new EventHandler(frmBangKe_Load);
        }

        void frmBangKe_Load(object sender, EventArgs e)
        {
            LoadListBangKe();
            
        }

        private void LoadListBangKe()
        {
            List<BangKe> lstBangKe = new List<BangKe>();
            lstBangKe = new BangKe().GetListOfBangKes();

            grdDoiTac.DataMember = "ListOfBangKe";
            grdDoiTac.SetDataBinding(lstBangKe, "ListOfBangKe"); 
        }

        private void cmdAdd_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdNew cmdEdit cmdDelete cmdExit cmdHelp
            if (e.Command.Key == "cmdNew")
            {
                this.ThemBangKe(dtDoiTac);
            }
            else if (e.Command.Key == "cmdEdit")
            {
                this.SuaBangKe();
            }
            else if (e.Command.Key == "cmdDelete")
            {
                this.XoaBangKe();
            }
            else if (e.Command.Key == "cmdExit")
            {
                this.Close();
                this.Dispose();
            }
            else if (e.Command.Key == "cmdExcel")
            {
                this.XuatExcel();
            }
            else if (e.Command.Key == "cmdHelp")
            {
                frmBangKeTimKiem frm = new frmBangKeTimKiem(dtDoiTac);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    List<BangKe> mListOfBangKe = frm.GetResultListOfBangKe();

                    if (mListOfBangKe.Count > 0)
                    {
                        grdDoiTac.DataSource = null;
                        grdDoiTac.DataMember = "ListOfBangKe";
                        grdDoiTac.SetDataBinding(mListOfBangKe, "ListOfBangKe");
                    }
                    else
                    {
                        grdDoiTac.DataSource = null;
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy kết quả nào");
                        return;
                    }
                }
            }
        }        

        public DataTable getDataDoiTac(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return null;
            }
            else
            {
                DoiTac objDoiTac = new DoiTac();
                return objDoiTac.GetListOfDoiTacs_NAME();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void bw_DoWorkNew(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = getDataDoiTac(worker, e);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
            if (e.Error != null)
            {               
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
                return;
            }
            else if (e.Cancelled)
            {
                bw = null;
                return;
            }
            else
            {
                dtDoiTac = (DataTable)e.Result;
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
                BangKe objBangKe = (BangKe)((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow().DataRow;
                frmBangKeInput frm = new frmBangKeInput(objBangKe, dtDoiTac, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadListBangKe();
                }
                else return;
            }
        }

        private void grdDoiTac_FormattingRow(object sender, RowLoadEventArgs e)
        {
            //HienThiAnhTrangThai_MauChu(e.Row);
        }

        #region Add, Delete BangKe

        private void ThemBangKe(DataTable dt)
        {            
            frmBangKeInput frm = new frmBangKeInput(dt);// them moi
            
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                LoadListBangKe();
            }
        }

        private void SuaBangKe()
        {
            grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDoiTac.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow();
                BangKe objBangKe = (BangKe)((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow().DataRow;
                frmBangKeInput frm = new frmBangKeInput(objBangKe, dtDoiTac, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadListBangKe();
                }
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa nhập bảng kê để cập nhật", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }

        private void XoaBangKe()
        {
            grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDoiTac.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow();
                BangKe objBangKe = (BangKe)((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

                if (msg.Show(this, "Bạn có xóa bảng kê này không ?", "Xóa bảng kê", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                {
                    if (!objBangKe.Delete(objBangKe.ID))
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi xóa đối tác");
                        return;
                    }
                    else
                    {
                        LoadListBangKe();
                    }
                }
            }
        }

        private void XuatExcel()
        {
            string FilenameDefault = "DSBangKe.xls";
            saveFileDialog1.FileName = FilenameDefault;
            saveFileDialog1.DefaultExt = "xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.GridEX = this.grdDoiTac;
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