using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

using AutoUpdate.Engine.Entity;
using AutoUpdate.Engine.Utility;

using AutoUpdate.UI;

namespace AutoUpdate.Engine
{
    public class FTPDownload
    {
        public event FTPDownloadFinshed eventFTPDownloadFinshed;

        private Thread m_thread;
        private DevExpress.Utils.DefaultBoolean m_continues = DevExpress.Utils.DefaultBoolean.Default;
        private bool m_IsDownload = false;

        private int m_idx = -1;
        private string m_url = "";
        private string m_fnm = "";

        public void Start()
        {
            try
            {
                m_continues = DevExpress.Utils.DefaultBoolean.True;
                m_thread = new Thread(InitThread);
                m_thread.Start();
            }
            catch (Exception ex)
            {
                LogFile.Write("FTPDownload.Start, ex: " + ex.ToString());
            }
        }

        public void Download(int idx, string fnm, string url)
        {
            try
            {
                if (m_continues != DevExpress.Utils.DefaultBoolean.True)
                    return;
                m_idx = idx;
                m_fnm = fnm;
                m_url = url;

                m_IsDownload = true;
            }
            catch (Exception ex)
            {
                LogFile.Write("FTPDownload.Download, ex: " + ex.ToString());
            }
        }

        public void Redownload()
        {
            m_IsDownload = true;
        }

        public void Stop()
        {
            try
            {
                m_continues = DevExpress.Utils.DefaultBoolean.False;
                m_IsDownload = false;
            }
            catch (Exception ex)
            {
                LogFile.Write("FTPDownload.Stop, ex: " + ex.ToString());
            }
        }

        public DevExpress.Utils.DefaultBoolean State()
        {
            return m_continues;
        }

        private void InitThread()
        {
            try
            {
                m_continues = DevExpress.Utils.DefaultBoolean.True;
                while (true)
                {
                    if (m_continues != DevExpress.Utils.DefaultBoolean.True)
                        break;
                    if (m_IsDownload == true)
                    {
                        m_IsDownload = false;
                        DownloadFile(m_url, m_fnm);
                    }
                    Thread.Sleep(Constants.DOWNLOAD_TIME_SLEEP);
                }

                m_continues = DevExpress.Utils.DefaultBoolean.Default;
            }
            catch (Exception ex)
            {
                LogFile.Write("FTPDownload.InitThread, ex: " + ex.ToString());
                m_continues = DevExpress.Utils.DefaultBoolean.Default;
            }
        }

        public void GetListFile()
        {
            try
            {
                string requestUrlString = Constants.FTP_URL + Constants.APP_NAME;
                if(Constants.APP_SUB.Length > 0)
                    requestUrlString = Constants.FTP_URL + Constants.APP_NAME + "/" + Constants.APP_SUB;
                //Tao ket noi FTP
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requestUrlString);
                //Gan phuong thuc lay danh sach file
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                //Dang nhap
                request.EnableSsl = Constants.FTP_ENABLE_SSL;
                request.Credentials = new NetworkCredential(Constants.FTP_USERNAME, Constants.FTP_PASSWORD);
                request.KeepAlive = false;

                if (Constants.FTP_ENABLE_SSL == true)
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptAllCertifications);

                //Lay ket qua
                List<FileDownload> fileDownloadList = new List<FileDownload>();
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    //Doc ket qua
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            //Xu ly ket qua
                            while (reader.EndOfStream == false)
                            {
                                FileDownload fileDownloadItem = new FileDownload();
                                if (fileDownloadItem.FromString(reader.ReadLine()) == false)
                                {
                                    fileDownloadList = null;
                                    break;
                                }
                                else
                                {
                                    fileDownloadItem.IndexID = fileDownloadList.Count + 1;
                                    fileDownloadList.Add(fileDownloadItem);
                                }
                            }
                            reader.Close();
                        }
                        responseStream.Close();
                    }
                    response.Close();
                }
                request.Abort();

                if (eventFTPDownloadFinshed != null)
                {
                    if (fileDownloadList != null && fileDownloadList.Count > 0)
                        eventFTPDownloadFinshed(UODownloadKind.FILE_LIST_SUCCESS, fileDownloadList);
                    else
                        eventFTPDownloadFinshed(UODownloadKind.FILE_LIST_FAIL, null);
                }
            }
            catch (Exception ex)
            {
                LogFile.Write("FTPDownload.GetListFile, ex: " + ex.ToString());
                if (eventFTPDownloadFinshed != null)
                    eventFTPDownloadFinshed(UODownloadKind.FILE_LIST_FAIL, null);
            }
        }

        private void DownloadFile(string url, string fnm)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url));
                request.Proxy = null;
                request.EnableSsl = Constants.FTP_ENABLE_SSL;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(Constants.FTP_USERNAME, Constants.FTP_PASSWORD);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                if (Constants.FTP_ENABLE_SSL == true)
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptAllCertifications);

                using (Stream reader = request.GetResponse().GetResponseStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(Constants.APP_FOLDER + fnm + ".tmp", FileMode.Create)))
                    {
                        int bytesRead = 0;
                        byte[] buffer = new byte[1024];
                        while (true)
                        {
                            bytesRead = reader.Read(buffer, 0, buffer.Length);
                            if (bytesRead == 0)
                                break;
                            writer.Write(buffer, 0, bytesRead);
                        }
                        writer.Close();
                    }
                    reader.Close();
                }
                request.Abort();

                if (eventFTPDownloadFinshed != null)
                    eventFTPDownloadFinshed(UODownloadKind.FILE_DOWNLOAD_SUCCESS, m_idx);
            }
            catch (Exception ex)
            {
                LogFile.Write("FTPDownload.DownloadFile(" + url + "), ex: " + ex.ToString());
                if (eventFTPDownloadFinshed != null)
                    eventFTPDownloadFinshed(UODownloadKind.FILE_DOWNLOAD_FAIL, m_idx);
            }
        }

        /// <summary>
        /// Xác nhận tất cả các certificate
        /// </summary>
        public bool AcceptAllCertifications(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
            //Subject = "E=anhpt@binhanh.com, OU=PDA, O=BinhAnh, L=HN, S=HN, C=84, CN=BAP"
        }
    }
}
