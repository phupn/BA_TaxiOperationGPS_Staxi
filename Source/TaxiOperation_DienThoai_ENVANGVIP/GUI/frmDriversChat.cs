using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.DM;
using Taxi.Controls.Base;
using Taxi.Data.EnVang;
using TaxiApplication.ServiceEnVang;

namespace Taxi.GUI
{
    public partial class frmDriversChat : FormBase
    {
        private int _time = 1 * 5;
        private string g_LinesDuocCapPhep = string.Empty;
        /// <summary>
        /// Số hiệu xe đang chat
        /// </summary>
        private string SoHieuXeDangChat = string.Empty;
        /// <summary>
        /// Có đổi xe chat hay không
        /// </summary>
        private bool DoiXeChat = false;
        /// <summary>
        /// Số dòng đang chat
        /// </summary>
        private DateTime? ThoiDiemLoadChatCuoi = null;

        private long IDCuocGoi = 0;

        public frmDriversChat()
        {
            InitializeComponent();
            timerLoadChat.Start();
        }

        /// <summary>
        /// Gán giá trị cho các thuộc tính
        /// </summary>
        /// <param name="lineDuocCapPhep">The line duoc cap phep.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/21/2015   created
        /// </Modified>
        public void SetProperties(string lineDuocCapPhep)
        {
            g_LinesDuocCapPhep = lineDuocCapPhep;
        }

        /// <summary>
        /// Sets the vehicle to grid.
        /// </summary>
        /// <param name="vehicles">The vehicles.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/20/2015   created
        /// </Modified>
        public void SetVehiclesToGrid(List<Xe> vehicles)
        {
            shgXe.DataSource = vehicles;
        }

        private void txtChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtChatInput.Text)) return;
                EnVangProcess.SendText(SoHieuXeDangChat, IDCuocGoi, txtChatInput.Text);
                txtChatInput.Text = string.Empty;
            }
        }

        private void gridXe_DoubleClick(object sender, EventArgs e)
        {
            var xe = (Xe)gridXe.GetFocusedRow();
            SoHieuXeDangChat = xe.SoHieuXe;
            DoiXeChat = true;
            LoadNoiDungChat();
        }

        private void frmDriversChat_Load(object sender, EventArgs e)
        {

        }

        private void timerLoadChat_Tick(object sender, EventArgs e)
        {
            _time--;
            if (_time <= 0)
            {
                if (Visible)
                {
                    var cacXeDangChat = CuocGoi.EnVangVIP_DienThoai_LayCacXeDangChat(g_LinesDuocCapPhep);
                    if (cacXeDangChat != null && cacXeDangChat.Count > 0)
                    {
                        SetVehiclesToGrid(cacXeDangChat);
                        bool continueChatting = false;
                        foreach (var xe in cacXeDangChat)
                        {
                            if (xe.SoHieuXe == SoHieuXeDangChat)
                            {
                                continueChatting = true;
                            }
                        }
                        if (!continueChatting)
                        {
                            SoHieuXeDangChat = string.Empty;
                            txtChatBox.Clear();
                        }
                        LoadNoiDungChat();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }

        /// <summary>
        /// Load nội dung chat
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/21/2015   created
        /// </Modified>
        private void LoadNoiDungChat()
        {
            if (string.IsNullOrEmpty(SoHieuXeDangChat)) return;
            if (DoiXeChat)
            {
                txtChatBox.Lines = ConvertMessageToChatLines(CuocGoi.EnVangVip_DienThoai_LayNoiDungChatCuaXe(SoHieuXeDangChat));
                DoiXeChat = false;
            }
            else
            {
                var noiDungChat = CuocGoi.EnVangVip_DienThoai_LayNoiDungChatCuaXe(SoHieuXeDangChat, ThoiDiemLoadChatCuoi);
                if (noiDungChat != null && noiDungChat.Count > 0)
                {
                    var newLines = ConvertMessageToChatLines(noiDungChat);
                    foreach (var line in newLines)
                    {
                        txtChatBox.AppendText("\r\n" + line);
                    }
                }
            }
        }

        /// <summary>
        /// Đổi các đối tượng message confirm thành dòng chat và lấy về thời điểm chat cuối
        /// </summary>
        /// <param name="noiDungChat">The noi dung chat.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/21/2015   created
        /// </Modified>
        public string[] ConvertMessageToChatLines(List<MessageConfirm> noiDungChat)
        {
            if (noiDungChat != null && noiDungChat.Count > 0)
            {
                IDCuocGoi = noiDungChat[0].IDCuocGoi;
            }
            string[] chatLines = new string[noiDungChat.Count];
            int count = 0;
            foreach (var dong in noiDungChat)
            {
                var convertedLine = dong.MaMessage == 2342 ? dong.SoHieuXe + ": " : "ĐTV: ";
                convertedLine += dong.MessageContent;
                chatLines[count] = convertedLine;
                count++;
                if (count == noiDungChat.Count) ThoiDiemLoadChatCuoi = dong.ThoiDiemGoiMessage;
            }
            return chatLines;
        }
    }
}
