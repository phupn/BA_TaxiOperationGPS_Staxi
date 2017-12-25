using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AutoUpdate.Engine;
using AutoUpdate.Engine.Entity;
using AutoUpdate.Engine.Utility;

namespace AutoUpdate
{
    public delegate void DisplayDownloadInformation(bool status);

    public partial class XFMain : DevExpress.XtraEditors.XtraForm
    {
        public static event DisplayDownloadInformation eventDisplayDownloadInformation;

        private List<FileDownload> m_FileDownloadList = null;
        /// <summary>
        /// Đã update thành công
        /// </summary>
        private string m_Successfull = "NO";
        private bool m_State = false;
        private string m_Message = "";

        private bool m_ContinuesDisplay = false;
        private bool m_ContinuesUpdate = false;

        private bool m_ContinuesProcess = false;
        private bool m_ContinuesDownload = false;
        private int m_FileDownloadIndex = 0;
        private UODownloadStep m_DownloadStep = UODownloadStep.GET_LIST_FILE;

        private BackgroundWorker m_BackgroundWorkerDisplay = new BackgroundWorker();
        private BackgroundWorker m_BackgroundWorkerProcess = new BackgroundWorker();

        private FTPDownload m_FTPDownload = new FTPDownload();

        public XFMain()
        {
            InitializeComponent();

            //LogFile.Write(System.AppDomain.CurrentDomain.FriendlyName);
            
            eventDisplayDownloadInformation = new DisplayDownloadInformation(ProcessDisplayDownloadInformation);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (m_ContinuesDisplay == true || m_ContinuesProcess == true || m_FTPDownload.State() != DevExpress.Utils.DefaultBoolean.Default)
                e.Cancel = true;
            else
                base.OnClosing(e);
        }

        private void InitService()
        {
            List<UODownloadState> dowloadStateList = new List<UODownloadState>();
            dowloadStateList.Add(new UODownloadState(UODState.NORMAL, "Đang chờ..."));
            dowloadStateList.Add(new UODownloadState(UODState.DOWLOADING, "Đang tải..."));
            dowloadStateList.Add(new UODownloadState(UODState.SUCCESS, "Thành công"));
            dowloadStateList.Add(new UODownloadState(UODState.FAIL, "Lỗi"));
            rptItmLookUpEditState.DataSource = dowloadStateList;
            rptItmLookUpEditState.DropDownRows = dowloadStateList.Count;

            m_BackgroundWorkerDisplay.DoWork += new DoWorkEventHandler(m_BackgroundWorkerDisplay_DoWork);
            m_BackgroundWorkerDisplay.RunWorkerAsync();

            m_BackgroundWorkerProcess.DoWork += new DoWorkEventHandler(m_BackgroundWorkerProcess_DoWork);
            m_BackgroundWorkerProcess.RunWorkerAsync();

            m_FTPDownload.eventFTPDownloadFinshed += new UI.FTPDownloadFinshed(m_FTPDownload_eventFTPDownloadFinshed);
            m_FTPDownload.Start();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void m_FTPDownload_eventFTPDownloadFinshed(UODownloadKind kind, object data)
        {
            try
            {
                switch (kind)
                {
                    case UODownloadKind.FILE_LIST_SUCCESS:
                        #region ==================== Lay danh sach file thanh cong ====================
                        //Lay du lieu
                        m_FileDownloadList = (List<FileDownload>)data;
                        //Hien thi danh sach file
                        m_ContinuesUpdate = true;
                        //Chuyen sang tai file
                        m_DownloadStep = UODownloadStep.DOWNLOAD_FILE;
                        //Bat dau tai file dau tien
                        m_FileDownloadIndex = 0;
                        //Bat co download
                        m_ContinuesDownload = true;
                        #endregion
                        break;
                    case UODownloadKind.FILE_LIST_FAIL:
                        #region ==================== Lay danh sach file loi ====================
                        //Thong bao
                        m_State = false;
                        m_Message = "Lỗi lấy danh sách file cần cập nhật";
                        //Dung hien thi
                        m_ContinuesDisplay = false;
                        //Dung tai file
                        m_ContinuesProcess = false;
                        #endregion
                        break;
                    case UODownloadKind.FILE_DOWNLOAD_SUCCESS:
                        #region ==================== Tai file thanh cong ====================
                        //Cap nhat hien thi danh sach file
                        m_ContinuesUpdate = true;
                        //Cap nhat trang thai
                        m_FileDownloadList[m_FileDownloadIndex].State = UODState.SUCCESS;
                        //Tang chi muc de download file tiep theo
                        m_FileDownloadIndex++;
                        //Bat co download
                        m_ContinuesDownload = true;
                        #endregion
                        break;
                    case UODownloadKind.FILE_DOWNLOAD_FAIL:
                        #region ==================== Tai file loi ====================
                        //Thong bao
                        m_State = false;
                        m_Message = "Lỗi tải file cập nhật";
                        //Cap nhat trang thai
                        m_FileDownloadList[m_FileDownloadIndex].State = UODState.FAIL;
                        //Dung hien thi
                        m_ContinuesDisplay = false;
                        //Dung tai file
                        m_ContinuesProcess = false;
                        #endregion
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogFile.Write("DownloadFinshed, ex: " + ex.ToString());
            }
        }

        private void m_BackgroundWorkerDisplay_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int timeout = 200;
                m_ContinuesDisplay = true;
                m_ContinuesUpdate = false;
                while (true)
                {
                    System.Threading.Thread.Sleep(timeout);
                    
                    if (m_ContinuesDisplay == false)
                        break;
                    if (m_ContinuesUpdate == false)
                        continue;

                    timeout = 10;

                    this.Invoke(eventDisplayDownloadInformation, false);

                    m_ContinuesUpdate = false;
                }
            }
            catch { }

            this.Invoke(eventDisplayDownloadInformation, true);
        }

        private void m_BackgroundWorkerProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                #region ==================== Tai file ====================
                m_Successfull = "NO";
                int timeout = 2000;
                m_ContinuesProcess = true;
                m_ContinuesDownload = true;
                while (true)
                {
                    //Tam nghi
                    System.Threading.Thread.Sleep(timeout);
                    //Kiem tra thoat vong lap
                    if (m_ContinuesProcess == false)
                        break;
                    //Kiem tra cho tai xong file hien tai
                    if (m_ContinuesDownload == false)
                        continue;

                    timeout = 100;

                    if (m_DownloadStep == UODownloadStep.GET_LIST_FILE)
                    {
                        //Khoi tao trang thai
                        m_State = true;
                        //Ngung tai file
                        m_ContinuesDownload = false;
                        //Lay danh sach file
                        m_FTPDownload.GetListFile();
                    }
                    else if(m_DownloadStep == UODownloadStep.DOWNLOAD_FILE)
                    {
                        if (m_FileDownloadList == null || m_FileDownloadIndex >= m_FileDownloadList.Count)
                        {
                            //Ngung hien thi
                            m_ContinuesDisplay = false;
                            //Ket thuc tai file
                            m_ContinuesProcess = false;
                        }
                        else
                        {
                            //Ngung tai file
                            m_ContinuesDownload = false;
                            //Cap nhat hien thi
                            m_ContinuesUpdate = true;
                            //Cap nhat trang thai
                            m_FileDownloadList[m_FileDownloadIndex].State = UODState.DOWLOADING;
                            //Tai file
                            m_FTPDownload.Download(m_FileDownloadIndex, m_FileDownloadList[m_FileDownloadIndex].Name, m_FileDownloadList[m_FileDownloadIndex].Path);
                        }
                    }
                }
                #endregion

                m_FTPDownload.Stop();

                ProcessResult();
            }
            catch { }
        }

        private void ProcessResult()
        {
            try
            {
                #region ==================== Xu ly ket qua ====================
                if (m_State == true)
                {
                    m_Message = "Cập nhật thành công, bạn có muốn khởi động chương trình không?";
                    //Lấy tên chương trình AutoUpdate
                    string applicationName = System.AppDomain.CurrentDomain.FriendlyName.ToLower();
                    for (int i = 0; i < m_FileDownloadList.Count; i++)
                    {
                        //Kiểm tra nếu file tải về là của chương trình AutoUpdate thì không làm gì cả
                        if (m_FileDownloadList[i].Name.ToLower().Contains(applicationName) == true)
                            continue;
                        //Xóa file cũ của file vừa mới tải về
                        if (File.Exists(Constants.APP_FOLDER + m_FileDownloadList[i].Name) == true)
                            File.Delete(Constants.APP_FOLDER + m_FileDownloadList[i].Name);
                        //Đổi tên file mới tải về thành file của chương trình
                        File.Move(m_FileDownloadList[i].Name + ".tmp", m_FileDownloadList[i].Name);
                    }
                    lbcMessage.Appearance.ForeColor = Color.Blue;
                    
                }
                else
                {
                    if (m_FileDownloadList != null)
                    {
                        for (int i = 0; i < m_FileDownloadList.Count; i++)
                        {
                            if (File.Exists(Constants.APP_FOLDER + m_FileDownloadList[i].Name + ".tmp") == true)
                                File.Delete(Constants.APP_FOLDER + m_FileDownloadList[i].Name + ".tmp");
                        }
                    }
                    lbcMessage.Appearance.ForeColor = Color.Red;
                }

                lbcMessage.Text = m_Message;
                btnRun.Enabled = m_State;
                m_Successfull = "YES";
                #endregion
            }
            catch (Exception ex)
            {
                LogFile.Write("ProcessResult, ex: " + ex.ToString());
            }
        }

        private void StartDownload()
        {
            InitService();

            m_ContinuesDownload = true;
        }

        private void ProcessDisplayDownloadInformation(bool status)
        {
            if (status == true)
            {
                prgBarCtr.EditValue = prgBarCtr.Properties.Maximum;
            }
            else
            {
                prgBarCtr.Properties.Maximum = m_FileDownloadList != null ? m_FileDownloadList.Count : 0;
                prgBarCtr.EditValue = m_FileDownloadIndex + 1;
                grcResult.DataSource = m_FileDownloadList;
                grcResult.RefreshDataSource();
            }
        }

        private void XFMain_Shown(object sender, EventArgs e)
        {
            if (Constants.APP_NAME.Length == 0)
                this.Close();
            else
                StartDownload();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Constants.APP_FOLDER + Constants.APP_NAME + ".exe", m_Successfull);
            this.Close();
        }

        private void grvResult_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle > -1)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}