using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmCapNhatThongTinMoiGioi : Taxi.Controls.Base.FormBase
    {
        private List<DoiTac> g_lstDoiTacChon = new List<DoiTac>();
        private List<DoiTac> g_lstDoiTac = new List<DoiTac>();
        private fmProgress m_fmProgress = null;

        public frmCapNhatThongTinMoiGioi()
        {
            InitializeComponent();
        }
        private void frmCapNhatThongTinMoiGioi_Load(object sender, EventArgs e)
        {
            listMoiGioi.DisplayMember = "Name";
            listMoiGioi.ValueMember = "MaDoiTac";

            listMoiGioiChon.DisplayMember = "Name";
            listMoiGioiChon.ValueMember = "MaDoiTac";

            LoadDSMoiGioi();
            //cboKhoangThoiGianCapNhatLai.SelectedIndex = 0;
        }
        private void LoadDSMoiGioi()
        {

            g_lstDoiTac = ChuyenDoiDSMoiGoi(new DoiTac().GetListOfDoiTacs());

            listMoiGioi.DataSource = g_lstDoiTac;
        }

        /// <summary>
        /// hàm trảe về ds chuyển đổi moi gói dạng
        /// Ten : [MaDoiTac] -Ten - Dia chi
        /// </summary>
        /// <param name="ListDSMoiGioi"></param>
        /// <returns></returns>
        private List<DoiTac> ChuyenDoiDSMoiGoi(List<DoiTac> ListDSMoiGioi)
        {
            List<DoiTac> listTemp = new List<DoiTac>();
            if ((ListDSMoiGioi != null) && (ListDSMoiGioi.Count > 0))
            {
                foreach (DoiTac objDoiTac in ListDSMoiGioi)
                {
                    DoiTac objDT = new DoiTac(objDoiTac.MaDoiTac, "[" + objDoiTac.MaDoiTac + "] " + objDoiTac.Name + " - " + objDoiTac.Address, objDoiTac.Address, objDoiTac.Phones, objDoiTac.Fax, objDoiTac.Email, objDoiTac.TiLeHoaHongNoiTinh, objDoiTac.TiLeHoaHongDuongDai, objDoiTac.Notes, objDoiTac.IsActive, objDoiTac.MaNhanVien, objDoiTac.TenNhanVien, objDoiTac.CongTyID, objDoiTac.TenCongTy,objDoiTac.VietTat);
                    listTemp.Add(objDT);
                }
            }
            return listTemp;
        }

        private void btnnChonHet_Click(object sender, EventArgs e)
        {
            if (g_lstDoiTac != null)
            {
                foreach (DoiTac dtac in g_lstDoiTac)
                {
                    g_lstDoiTacChon.Add(dtac);
                }
                g_lstDoiTac.Clear();
                listMoiGioi.DataSource = null;
                listMoiGioiChon.DisplayMember = "Name";
                listMoiGioiChon.ValueMember = "MaDoiTac";
                listMoiGioiChon.DataSource = g_lstDoiTacChon;
            }

        }

        private void btnTroLaiHet_Click(object sender, EventArgs e)
        {
            if (g_lstDoiTacChon != null)
            {
                foreach (DoiTac dtac in g_lstDoiTacChon)
                {
                    g_lstDoiTac.Add(dtac);
                }

                g_lstDoiTacChon.Clear();
                listMoiGioiChon.DataSource = null;
                listMoiGioi.DisplayMember = "Name";
                listMoiGioi.ValueMember = "MaDoiTac";
                listMoiGioi.DataSource = g_lstDoiTac;
            }
        }

        private void btnChon1_Click(object sender, EventArgs e)
        {
            List<DoiTac> lstDoiTacAddRemoves = new List<DoiTac>();
            if (listMoiGioi.SelectedItems != null)
            {
                foreach (DoiTac doitac in listMoiGioi.SelectedItems)
                {
                    lstDoiTacAddRemoves.Add(doitac);
                }

            }
            // xoa o ben doi tac
            if (lstDoiTacAddRemoves.Count > 0)
            {
                foreach (DoiTac doitac in lstDoiTacAddRemoves)
                {
                    g_lstDoiTac.Remove(doitac);
                }
                // hien thi lai
                listMoiGioi.DataSource = null;
                listMoiGioi.DisplayMember = "Name";
                listMoiGioi.ValueMember = "MaDoiTac";
                listMoiGioi.DataSource = g_lstDoiTac.ToArray();

                foreach (DoiTac doitac in lstDoiTacAddRemoves)
                {
                    g_lstDoiTacChon.Add(doitac);
                }
                // hien thi lai
                listMoiGioiChon.DataSource = null;
                listMoiGioiChon.DisplayMember = "Name";
                listMoiGioiChon.ValueMember = "MaDoiTac";
                listMoiGioiChon.DataSource = g_lstDoiTacChon.ToArray();
            }
        }

        private void btnTroLai1_Click(object sender, EventArgs e)
        {
            List<DoiTac> lstDoiTacAddRemoves = new List<DoiTac>();
            if (listMoiGioiChon.SelectedItems != null)
            {
                foreach (DoiTac doitac in listMoiGioiChon.SelectedItems)
                {
                    lstDoiTacAddRemoves.Add(doitac);
                }

            }
            // xoa o ben doi tac
            if (lstDoiTacAddRemoves.Count > 0)
            {
                foreach (DoiTac doitac in lstDoiTacAddRemoves)
                {
                    g_lstDoiTacChon.Remove(doitac);
                }
                // hien thi lai
                listMoiGioiChon.DataSource = null;
                listMoiGioiChon.DisplayMember = "Name";
                listMoiGioiChon.ValueMember = "MaDoiTac";
                listMoiGioiChon.DataSource = g_lstDoiTacChon.ToArray();

                foreach (DoiTac doitac in lstDoiTacAddRemoves)
                {
                    g_lstDoiTac.Add(doitac);
                }
                // hien thi lai
                listMoiGioi.DataSource = null;
                listMoiGioi.DisplayMember = "Name";
                listMoiGioi.ValueMember = "MaDoiTac";
                listMoiGioi.DataSource = g_lstDoiTac.ToArray();

            }

        }

        private void btnCapNhatThongtinMoiGioi_Click(object sender, EventArgs e)
        {

            if ((g_lstDoiTacChon == null) || (g_lstDoiTacChon.Count <= 0))
            {

                new MessageBox.MessageBoxBA().Show(this, " Không có môi giới nào được chọn.");
                return;
            }

            // Create a background thread
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            // Create a progress form on the UI thread
            m_fmProgress = new fmProgress();
            // Kick off the Async thread
            bw.RunWorkerAsync();
            // Lock up the UI with this modal progress form.
            try
            {
                m_fmProgress.ShowDialog(this);
                m_fmProgress = null;
                new MessageBox.MessageBoxBA().Show(this, " Cập nhật cuộc gọi môi giới thành công.");
                return;
            }
            catch (Exception ex)
            {

            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime DenNgay = date_ToDate.Value;
            DateTime TuNgay = date_FromDate.Value;
            //if (cboKhoangThoiGianCapNhatLai.SelectedText.Contains("1")) // 1 tháng
            //{
            //    TuNgay = DenNgay.Subtract (new TimeSpan (30,0,0,0));
            //}
            //else
            //{
            //    TuNgay = DenNgay.Subtract (new TimeSpan (90,0,0,0));
            //}

            if (g_lstDoiTacChon.Count > 0)
            {

                // Lay cuoc goi da ket thuc
                //  List<DieuHanhTaxi> lstDieuHanhTaxi = new List<DieuHanhTaxi> ();
                //  lstDieuHanhTaxi = new DieuHanhTaxi ().Get_CuocGoi_KetThuc(" ", " "); 
                int i = 0;
                foreach (DoiTac objDT in g_lstDoiTacChon)
                {
                    if (!DieuHanhTaxi.UpdateLaiCuocGoiMoiGioi(TuNgay, DenNgay, objDT.MaDoiTac))
                    {
                        e.Cancel = true;
                    }
                    i++;
                    m_fmProgress.lblDescription.Invoke(
                       (MethodInvoker)delegate()
                       {
                           m_fmProgress.lblDescription.Text = "Processing ... " + objDT.Name;
                           m_fmProgress.progressBar.Value = Convert.ToInt32(i * (100.0 / g_lstDoiTacChon.Count));
                       }
                   );
                    if (m_fmProgress.Cancel)
                    {
                        // Set the e.Cancel flag so that the WorkerCompleted event
                        // knows that the process was canceled.
                        e.Cancel = true;
                        return;
                    }
                }
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
                // new Taxi.MessageBox.MessageBox().Show("Processing cancelled.");
                return;
            }
        }
    }
}