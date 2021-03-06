using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.Controls
{
    public partial class SendMessage : UserControl
    {
        private static DataTable g_TableAccount;
        public int g_idMessage = 0;
        private DateTime G_TimeServer;
        public SendMessage()
        {
            InitializeComponent();
        }       

        private void SendMessage_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            lblThongBao.Text = "";
            //Lấy tất cả các tài khoản trong hệ thống
            g_TableAccount = new Chatting().SelectListUser_CheckIn();
            G_TimeServer = DieuHanhTaxi.GetTimeServer();
            dateTime_ThoiGianGui.SetValue(G_TimeServer);
            if (g_idMessage > 0)
            {
                SetDataDetail();// xem chi tiết tin nhắn;
            }
            else
            {
                rbTatCa.Checked = true;
                cbCapDo.SelectedIndex = 1;
            }
        }

        private void SetDataDetail()
        {
            string ToUserName = "";
            string Contents = "";
            string Subject = "";
            int Priority = 1;
            DateTime date = G_TimeServer;
            DataTable dt = new Chatting().SelectByID(g_idMessage);

            ToUserName = dt.Rows[0]["ListToUserName"].ToString();
            Contents = dt.Rows[0]["Contents"].ToString();
            Subject = dt.Rows[0]["Subject"].ToString();
            Priority = Int32.TryParse(dt.Rows[0]["Priority"].ToString(), out Priority) ? Priority : 1;
            DateTime.TryParse(dt.Rows[0]["Date"].ToString(),out date);

            txtTieuDe.Text = Subject;
            txtNoiDung1.Text = Contents;
            txtTaiKhoan1.Text = ToUserName;
            cbCapDo.SelectedValue = Priority;
            dateTime_ThoiGianGui.SetValue(date);
        }

        private string GetAccountCheckIn(string isMayTinh, bool isFullAcc)
        {
            try
            {
                string strReturn = "";
                string strFilter = "";
                g_TableAccount = new Chatting().SelectListUser_CheckIn();//Lấy danh sách user mới nhất!
                if (g_TableAccount != null)
                {
                    if (isFullAcc)
                    {//Lấy tất cả các tài khoản trong hệ thống
                        foreach (DataRow dr in g_TableAccount.Rows)
                        {
                            //string vung_line = dr["Line_Vung"].ToString();
                            string fullName = dr["FULLNAME"].ToString();
                            string username = dr["Username"].ToString();
                            //string ipAddress = dr["IPAddress"].ToString();
                            strReturn = string.Format("{0}{1}-{2};", strReturn, username, fullName);
                        }
                        if (strReturn.Length <= 0)
                            return strReturn;
                        strReturn = strReturn.Substring(0, strReturn.Length - 1);
                    }
                    else
                    {//Chỉ lấy các tài khoản đang check in
                        if (isMayTinh == "")
                        {
                            strFilter = "IPAddress is not null";
                        }
                        else
                        {
                            strFilter = String.Format("isMayTinh in ({0})", isMayTinh);
                        }
                        Array.ForEach(g_TableAccount.Select(strFilter), delegate(DataRow dr)
                        {
                            string fullName = dr["FULLNAME"].ToString();
                            string username = dr["Username"].ToString();
                            strReturn = string.Format("{0}{1}-{2};", strReturn, username, fullName);
                        });
                        if (strReturn.Length <= 0)
                            return strReturn;

                        strReturn = strReturn.Substring(0, strReturn.Length - 1);
                    }
                }

                return strReturn;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetAccountCheckIn: ", ex);
                return string.Empty;
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidate())
                {
                    string desTaiKhoan = "";
                    string ipAddress = "";
                    string taiKhoan = txtTaiKhoan1.Text.Trim();
                    string tieuDe = txtTieuDe.Text.Trim();
                    string noiDung = txtNoiDung1.Text.Trim();
                    DateTime ThoiGianGui = (DateTime)dateTime_ThoiGianGui.GetValue();
                    if (!chkChonNgay.Checked)
                        ThoiGianGui = DieuHanhTaxi.GetTimeServer();

                    int capDo = Convert.ToInt16(cbCapDo.SelectedValue);
                    bool status = false;

                    string[] arrTaiKhoan = taiKhoan.Split(';');// cắt chuỗi tài khoản "Account1-FullName1;Account2-FullName2;..."
                    int length = arrTaiKhoan.Length;
                    if (arrTaiKhoan[length - 1].Trim().Equals(""))
                    {
                        length = length - 1;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        string[] arr = arrTaiKhoan[i].Trim().Split('-');// Cắt từng tài khoản 

                        desTaiKhoan += arr[0].Trim();
                        if (g_TableAccount == null)
                            continue;

                        string sql = String.Format("Username = '{0}'", arr[0].Trim());// lay IP cua account (nếu đang check-in mới có ipAddress)
                        DataRow[] dr = g_TableAccount.Select(sql);
                        if (dr.Length > 0)
                        {
                            ipAddress += dr[0]["IpAddress"].ToString() == "" ? "NULL" : dr[0]["IpAddress"].ToString();//neu ko co IpAddress thì set = NULL
                        }
                        if (i < length - 1)
                        {
                            desTaiKhoan += ";";
                            ipAddress += ";";
                        }
                    }

                    string IP = Taxi.Business.QuanTri.QuanTriCauHinh.getAddress();

                    if (new Chatting().Insert(ThongTinDangNhap.USER_ID, IP,
                                            desTaiKhoan, ipAddress, tieuDe, noiDung, ThoiGianGui, capDo, status, taiKhoan))
                    {
                        new MessageBox.MessageBoxBA().Show("Gửi tin nhắn thành công", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                        refresh();
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Gửi tin nhắn thất bại", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnGui_Click: ",ex);                
            }
        }

        private bool IsValidate()
        {
            if (txtNoiDung1.Text.Trim().Equals(""))
            {
                lblThongBao.Text = "Bạn chưa nhập nội dung.";
                txtNoiDung1.Focus();
                return false;
            }
            else if (dateTime_ThoiGianGui.Text.Trim().Equals(""))
            {
                lblThongBao.Text = "Bạn chưa nhập nội dung.";
                txtNoiDung1.Focus();
                return false;
            }
            return true;
        }

        private void refresh()
        {
            txtTaiKhoan1.Text = "";
            txtNoiDung1.Text = "";
            txtTieuDe.Text = "";
            cbCapDo.SelectedIndex = 1;
            rbTatCa.Checked = true;
            lblThongBao.Text = "";
        }
        private void SetTextForTinMau(string tieuDe, string noiDung)
        {
            txtTieuDe.Text = tieuDe;
            txtNoiDung1.Text = noiDung;
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ListAccount lstAccount = new ListAccount();
            lstAccount.MyGetMessage = SetTextForTaiKhoan;
            lstAccount.Show();
        }

        private void SetTextForTaiKhoan(string taikhoan)
        {
            txtTaiKhoan1.Text = taikhoan;
            lblThongBao.Text = "";
        }        

        private void setValueAccount()
        {
            string MayTinh = "";
            bool isFullAcc = false;
            if (rbTatCa.Checked)
            {
                MayTinh = "";
            }
            else if (rbDHV.Checked)
            {
                MayTinh = "'TD'";
            }
            else
            {
                MayTinh = "'DT'";
            }
            if (!chkIsActiveUser.Checked)
            {
                isFullAcc = true;
            }
            string Account = GetAccountCheckIn(MayTinh, isFullAcc);
            if (!Account.Equals(""))
            {
                txtTaiKhoan1.Text = Account;
                lblThongBao.Text = "";
            }
            else
            {
                lblThongBao.Text = "Không lấy được tài khoản";
                txtTaiKhoan1.Text = "";
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    btnGui_Click(this, null);
                    return true;
                case Keys.Alt | Keys.G:
                    btnGui_Click(this, null);
                    return true;
                case Keys.Alt | Keys.D1:
                    rbTatCa.Checked = true;
                    return true;
                case Keys.Alt | Keys.D2:
                    rbDHV.Checked = true;
                    return true;
                case Keys.Alt | Keys.D3:
                    rbDTV.Checked = true;
                    return true;
                case Keys.Alt | Keys.M:
                    btnTinMau_Click_1(null,null);
                    return true;
                case Keys.Alt | Keys.T:
                    btnTaiKhoan_Click(null, null);
                    return true;
                case Keys.Alt | Keys.N:
                    txtNoiDung1.Focus();
                    return true;
                case Keys.Alt | Keys.V:
                    chkIsActiveUser.Checked = chkIsActiveUser.Checked ? false : true;

                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnTaiKhoan_Click_2(object sender, EventArgs e)
        {
            ListAccount lstAccount = new ListAccount();
            lstAccount.MyGetMessage = SetTextForTaiKhoan;
            lstAccount.Show();
        }
        private void rbDHV_CheckedChanged_1(object sender, EventArgs e)
        {
            setValueAccount();
        }

        private void rbTatCa_CheckedChanged_1(object sender, EventArgs e)
        {
            setValueAccount();
        }

        private void rbDTV_CheckedChanged_1(object sender, EventArgs e)
        {
            setValueAccount();
        }

        private void chkChonNgay_CheckedChanged_1(object sender, EventArgs e)
        {
            dateTime_ThoiGianGui.Enabled = chkChonNgay.Checked;
        }

        private void chkIsActiveUser_CheckedChanged(object sender, EventArgs e)
        {
            setValueAccount();
        }
        private void btnTinMau_Click_1(object sender, EventArgs e)
        {
            ListMessageTemplate lstMessageTemplate = new ListMessageTemplate();
            lstMessageTemplate.MyGetMessageTemplate = SetTextForTinMau;
            lstMessageTemplate.Show();
        }                
    }
}
