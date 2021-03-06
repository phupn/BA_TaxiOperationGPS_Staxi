using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Common.Extender;

namespace Taxi.Controls
{
    public partial class ListMessages : UserControl
    {
        private DataTable g_DataListMessage;
        private bool g_IsRead = false;
        private string g_Status = "0";        
        private string g_FullName = "";        
        private string g_ToUserName = "";
        private string g_Contents = "";
        private string g_Subject = "";
        private string g_Date = "";
        private int g_IDMessage = 0;
        private int g_Priority = 1;
        private int g_IsAdmin = 0;
        public int IDMessage_GV = 0;//ID selected gridview
        public  delegate void CloseFormMessage() ;

        public event CloseFormMessage CloseFormMessageEvent;
        public ListMessages()
        {
            InitializeComponent();
            btnDaDoc.Click += btnDaDoc_Click;
        }

        private void ListMessages_Load(object sender, EventArgs e)
        {
            try
            {
                calDateSearch.EditValue = CommonBL.GetTimeServer();
                if (g_IsAdmin == 0)
                {
                    setValueDetail();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ListMessages_Load: ", ex);                
            }            
        }

        private void setDataToGrid(DateTime date)
        {
            try
            {
                g_IsAdmin = 0;
                //*sign
                //ArrayList DanhSachQuyen = ThongTinDangNhap.Permissions;                
                //if ((DanhSachQuyen != null && DanhSachQuyen.Contains(CucTanSo.Common.DanhSachQuyen.QuanLyTinNhan)) || ThongTinDangNhap.USER_ID == "admin" || (Global.Module == EnumModule.DieuHanhChinh && DanhSachQuyen.Contains(CucTanSo.Common.DanhSachQuyen.QuanLyTinNhan_XemGhiChu)))
                //{
                //    isAdmin = 1;
                //    if (tabMessage.TabPages["tabNoiDung"] != null)
                //        tabMessage.TabPages.Remove(tabMessage.TabPages["tabNoiDung"]);
                //}
                g_DataListMessage = new DataTable();
                g_DataListMessage = new Chatting().SelectByUserName(ThongTinDangNhap.USER_ID, date, g_IsAdmin);
                grdContent.DataSource = g_DataListMessage;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("setDataToGrid: ", ex);                
            }
        }

        private void setValueDetail()
        {
            try
            {
                using (DataTable dt = new Chatting().SelectByUserName_Top_Detail(ThongTinDangNhap.USER_ID, g_IsAdmin))
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            g_IsRead = Convert.ToBoolean(dt.Rows[0]["isRead"].ToString());
                            //-----Đối với tài khoản có quyền admin thì ko cần ẩn nút Đã Đọc.
                            //-----Thay vào đó sẽ có thể cho admin gửi lại
                            if (g_IsRead && g_IsAdmin == 0)
                            {
                                btnDaDoc.Enabled = false;
                            }
                            else
                            {
                                btnDaDoc.Enabled = true;
                            }
                            g_Status = dt.Rows[0]["Status"].ToString().Trim();
                            //UserName = dt.Rows[0]["UserName"].ToString();
                            g_FullName = dt.Rows[0]["FULLNAME"].ToString();
                            //IPAddress = dt.Rows[0]["IPAddress"].ToString();
                            g_ToUserName = dt.Rows[0]["ToUserName"].ToString();
                            g_Contents = dt.Rows[0]["Contents"].ToString();
                            g_Subject = dt.Rows[0]["Subject"].ToString();
                            g_Date = dt.Rows[0]["Date"].ToString();
                            g_IDMessage = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                            g_Priority = Convert.ToInt16(dt.Rows[0]["Priority"].ToString());
                            switch (g_Priority)
                            {
                                case 0:
                                    lblNoiDung.ForeColor = Color.SteelBlue;
                                    break;
                                case 1:
                                    lblNoiDung.ForeColor = Color.Green;
                                    break;
                                default:
                                    lblNoiDung.ForeColor = Color.Red;
                                    break;
                            }
                            DataTable dtToUser = new Users().GetUserInfo(g_ToUserName);
                            lblNguoiNhan.Text = dtToUser.Rows[0]["FULLNAME"].ToString();
                            grpNoiDung.Text = "Tin nhắn từ : " + g_FullName;
                            lblNoiDung.Text = g_Contents;
                            lblThoiGian.Text = Convert.ToDateTime(g_Date).ToString("HH:mm dd/MM/yyyy");
                            lblTieuDe.Text = g_Subject;
                            txtIDMessage.Text = g_IDMessage.ToString();
                            lblStatus.Text = g_Status;
                        }
                    }
                    else
                    {
                        btnDaDoc.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("setValueDetail: ",ex);                
            }

        }

        private void btnDaDoc_Click(object sender, EventArgs e)
        {
            try
            {
                string IP = Business.QuanTri.QuanTriCauHinh.getAddress();
                if (g_IsAdmin == 0)
                {
                    new Chatting().Update(g_IDMessage, ThongTinDangNhap.USER_ID, IP);
                    btnDaDoc.Enabled = false;
                    if (CloseFormMessageEvent != null)
                        CloseFormMessageEvent();
                }
                else
                {
                    if (txtIDMessage.Text != "")
                        resendMessage(Convert.ToInt32(txtIDMessage.Text.Trim()));
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnDaDoc_click: " , ex);                
            }
        }

        private void resendMessage(int Id)
        {
            try
            {
                if (new Chatting().Insert_Resend(Id))
                {
                    new MessageBox.MessageBoxBA().Show("Gửi tin nhắn thành công", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Gửi tin nhắn thất bại", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("resendMessage: ", ex);                
            }
        }

        private void Update_Status()
        {
            try
            {
                if (new Chatting().Update_Status(IDMessage_GV, !chkTrangThai.Checked))
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật thành công", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                    setDataToGrid(DateTime.Now);
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật thất bại", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Update_Status: ", ex);                
            }
        }

        /// <summary>
        /// set nội dung cho các control khi chọn dòng
        /// </summary>        
        private void setDataSelected_gv(int rowIndex)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    var dr = grcContent.GetDataRow(rowIndex);
                    IDMessage_GV = dr["Id"].To<int>();
                    txtNDTinNhan.Text = dr["Contents"].To<string>();
                    string status = dr["Status"].To<string>();
                    if (status == "True")
                    {
                        chkTrangThai.Checked = true;
                    }
                    else
                    {
                        chkTrangThai.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("setDataSelected_gv: ", ex);                
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if ( !g_IsRead && tabMessage.TabPages.Count > 1 && tabMessage.SelectedIndex==0 )
                    {
                        btnDaDoc_Click(this, null);
                    }
                    return true;
                case Keys.F5:
                    setDataToGrid(calDateSearch.DateTime);
                    return true;
                case Keys.F6:
                    if (g_IsAdmin == 1)
                    {
                        resendMessage(IDMessage_GV);
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Bạn không có quyền gửi tin nhắn !", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                    }
                    return true;
                case Keys.F7:
                    if (g_IsAdmin == 1)
                    {
                        Update_Status();
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Bạn không có quyền thay đổi trạng thái !", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void calDateSearch_ValueChanged(object sender, EventArgs e)
        {
            setDataToGrid(calDateSearch.DateTime);
        }

        private void tabMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMessage.SelectedIndex == 1)
            {
                if (g_DataListMessage.Rows.Count > 0)
                {
                    grcContent.Focus();
                }
            }
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Execel 2003 (*.xls)|*.xls|Execel 2007-2010 (*.xlsx)|*.xlsx";

                    saveFileDialog.FilterIndex = 0;

                    saveFileDialog.RestoreDirectory = true;

                    saveFileDialog.CreatePrompt = true;

                    saveFileDialog.Title = "Xuất excel";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (saveFileDialog.FileName.EndsWith("xlsx"))
                        {
                            grdContent.ExportToXlsx(saveFileDialog.FileName);
                        }
                        else
                        {
                            grdContent.ExportToXls(saveFileDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnXuatExcel_Click: ", ex);                
            }
        }

        private void grdContent_Click(object sender, EventArgs e)
        {
            if (grcContent.FocusedRowHandle>=0)
            setDataSelected_gv(grcContent.FocusedRowHandle);
        }

        private void grcContent_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "ListToUserName")
            {
                if (e.CellValue == DBNull.Value || (string) e.CellValue == "")
                {
                   
                }
            }
        }

        private void grcContent_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle>=0)
            {
                var dr=grcContent.GetDataRow(e.RowHandle);
                if(dr["ListToUserName"]==DBNull.Value||(string) dr["ListToUserName"]=="")
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }

        private void grdContent_KeyUp(object sender, KeyEventArgs e)
        {
            if (grcContent.FocusedRowHandle >= 0)
                setDataSelected_gv(grcContent.FocusedRowHandle);
        }

    }
}
