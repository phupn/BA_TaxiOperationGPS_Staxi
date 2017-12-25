using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Taxi.Business;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Inputs;
using Taxi.MessageBox;
using Taxi.Services;
using Taxi.Utils;

namespace Taxi.Controls.MessageManagement
{
    public partial class frmSendListMessage : FormRibbon
    {
        #region Params & Constructors!

        private List<TinNhanSMS> _listData = new List<TinNhanSMS>();
        private BackgroundWorker _bwWorkerSendMessage = new  BackgroundWorker();
        private const string SHEETNAME="TemplateMessage";
        private const string PATH_TEMPLATE = "Template\\Template Message.xls";
        public frmSendListMessage()
        {
            InitializeComponent();
        }

        #endregion

        #region Events!
        private void frmSendListMessage_Load(object sender, EventArgs e)
        {
            try
            {
                cboChonNguoiNhan.Properties.DisplayMember = "Display";
                cboChonNguoiNhan.Properties.ValueMember = "Value";
                cboChonNguoiNhan.Properties.DataSource = AllCodeEntity.Inst.GetAllCodeByCode("NGUOINHAN");
                cboChonNguoiNhan.ItemIndex = 0;

                _bwWorkerSendMessage.DoWork += SendMessage_DoWork;
                _bwWorkerSendMessage.RunWorkerCompleted += SendMessage_Completed;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmSendListMessage_Load: " , ex);                
            }
        }

        private void SendMessage_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    new MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendMessage_Completed: ", ex);                
            }
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidate())
                    _bwWorkerSendMessage.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnSendMessage_Click: ", ex);
            }
        }      
        private void SendMessage_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int countSuccess = 0;                
                List<TinNhanSMS> listSended = _listData.Where(a => a.Chon).ToList();
    
                foreach (TinNhanSMS item in listSended)
                {
                    TinNhanSMS itemTemp = item;
                    if (Service_Common.FastTaxi.Try(client => client.SendSMS(GetFirstMobilePhone(itemTemp.SoDienThoai), txtNoiDung.Text)))
                    {
                        countSuccess++;
                        ShowStatus(item.TenNhanVien, true);
                    }
                    else
                    {
                        ShowStatus(item.TenNhanVien, false);
                    }
                    Thread.Sleep(500);
                }
                new MessageBoxBA().Show("Tổng số tin nhắn gửi thành công: " + countSuccess + "/" + listSended.Count() + " tin nhắn.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendMessage_DoWork: ", ex);
            }
        }

        private string GetFirstMobilePhone(string pSDT)
        {
            try
            {
                string strResult = string.Empty;
                string temp = string.Empty;
                if (pSDT.Length < 14)
                    strResult = pSDT;
                else
                {
                    string[] arrSDT = pSDT.Split(';');
                    foreach (string  item in arrSDT)
                    {
                        temp = item.Substring(0, 2);
                        if (temp == "01" || temp == "09")
                        {
                            strResult = item;
                            break;
                        }
                    }
                }

                return strResult;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetFirstPhone: ", ex);
                return string.Empty;
            }
        }
        private void chkChon_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var temp = gridViewMessage.GetFocusedRow() as TinNhanSMS;
                if (temp != null && ((CheckEdit)sender).Checked)
                {
                    temp.Chon = true;
                }
                else temp.Chon = false;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("chkChon_CheckedChanged :", ex);
            }
        }       
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _listData.ForEach(a=> a.Chon=((InputCheckbox) sender).Checked);
                gridMessage.RefreshDataSource();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("chkAll_CheckedChanged: ",ex);                
            }
        }
       
        private void btnExcelSample_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(PATH_TEMPLATE))
                {
                    var msgDialog = new MessageBoxBA();
                    msgDialog.Show(this, "File template mẫu không tồn tại trong thư mục /Template ", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);                    
                }
                else
                {
                    Process.Start(PATH_TEMPLATE);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnExcelSample_Click: ",ex);                 
            }
        }
        private void btnImportByExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlgDialog = new OpenFileDialog();
                dlgDialog.Filter = "All File |*.*;|File Excel |*.xlsx;|File Excel |*.xls;";
                dlgDialog.FilterIndex = 1;
                dlgDialog.AddExtension = true;
                dlgDialog.RestoreDirectory = true;
                
                dlgDialog.InitialDirectory =Application.StartupPath+ "\\Template";
                if (dlgDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {                        
                        string sourcefile = dlgDialog.FileName;                        
                        string excelquery = string.Format("Select * from [{0}$]", SHEETNAME);
                        ExcelDataAccess.SourceFile = sourcefile;
                        ExcelDataAccess.OpenConnectionExcel();
                        DataSet ds = ExcelDataAccess.GetDataSet(excelquery);
                        TinNhanSMS temp;
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                if (row[0].ToString().Length > 3)
                                {
                                    temp = new TinNhanSMS();
                                    temp.SoDienThoai = row[0].ToString();
                                    temp.TenNhanVien = row[1].ToString();
                                    temp.ThongTinThem = row[2].ToString();
                                    _listData.Add(temp);
                                }                                
                            }
                        }                                              
                        ExcelDataAccess.CloseConnectionExcel();
                        gridMessage.DataSource = _listData;  
                        gridViewMessage.RefreshData();                        
                    }
                    catch (Exception ex)
                    {
                        new MessageBoxBA().Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnImportByExcel_Click: ", ex);               
            }
        }
        private void cboChonNguoiNhan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                HienThiDanhSachNguoiNhan(cboChonNguoiNhan.EditValue.To<int>());
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("cboChonNguoiNhan_EditValueChanged: ", ex);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods
        private void ShowStatus(string pTenNhanVien, bool pSuccess)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    if (pSuccess)
                    {
                        barStatusSendMsg.Caption = "Gửi tin cho " + pTenNhanVien + " ... thành công!";
                        barStatusSendMsg.Glyph = Taxi.Controls.Properties.Resources.icon_dot_green;
                    }
                    else
                    {
                        barStatusSendMsg.Caption = "Gửi tin nhắn cho " + pTenNhanVien + " ... thất bại!";
                        barStatusSendMsg.Glyph = Taxi.Controls.Properties.Resources.legendIcon;
                    }
                }));
            }

            if (pSuccess)
            {
                barStatusSendMsg.Caption = "Gửi tin cho " + pTenNhanVien + " ... thành công!";
                barStatusSendMsg.Glyph = Taxi.Controls.Properties.Resources.icon_dot_green;
            }
            else
            {
                barStatusSendMsg.Caption = "Gửi tin nhắn cho " + pTenNhanVien + " ... thất bại!";
                barStatusSendMsg.Glyph = Taxi.Controls.Properties.Resources.legendIcon;
            }
        }
        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtNoiDung.Text))
            {
                new MessageBoxBA().Show("Nội dung tin nhắn không được để trống!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                txtNoiDung.Focus();
                return false;
            }
            if (!_listData.Any(a => a.Chon))
            {
                new MessageBoxBA().Show("Bạn chưa tích chọn một ai để nhận tin nhắn!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                return false;
            }
            return true;
        }        
        private void HienThiDanhSachNguoiNhan(int pNguoiNhan)
        {
            try
            {
                _listData = new TinNhanSMS().LayDanhSachNguoiNhan(pNguoiNhan).ToList<TinNhanSMS>();
                gridMessage.DataSource = _listData;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LayDanhSachNguoiNhan: ", ex);
            }
        }

        #endregion
    }
}
