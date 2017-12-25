using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Common.Attributes;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.FastTaxis.TaxiBook;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Data.FastTaxi;
using System.Linq;
using TaxiApplication.ServiceEnVang;
using Taxi.Data.EnVang;
using TaxiApplication;
using EnVangVIP.Utils.PhatAmThanh;
using System.ComponentModel;

namespace Taxi.GUI
{
    public partial class frmInfo : FormBase
    {
        public frmInfo()
        {
            InitializeComponent();
        }
        BackgroundWorker bwBanCo = new BackgroundWorker();
        private static List<int> _postionInfo = new List<int>();
        public static List<int> PostionInfo
        {
            get {
                if (_postionInfo == null || _postionInfo.Count == 0)
                {
                    int n = (Screen.PrimaryScreen.Bounds.Height / (new frmInfo().Height))-1;
                    for (int i = 0; i < n; i++)
                    {
                        _postionInfo.Add(0);
                    }
                }
                return _postionInfo;
            }
        }
        /// <summary>
        /// Vị trí hiện tại
        /// </summary>
        public int PostionCurrent=-1;
        public int Zindex = 0;
        public MessageConfirm Model;
        private frmDieuHanhBoDamNEW_V4 Parent;
        private int _time = 1 * 30;
        // Kiểm tra trường hợp đóng mà không chọn Y/N
        private bool CloseWithoutChoose = true;
        private string MaLaiXe = string.Empty;
        private bool HaveToConfirm = false;
        private short PKCommandID = 0;

        /// <summary>
        /// Set giao diện cho form trước khi hiển thị lên màn hình
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="lenhLaiXe">The lenh lai xe.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="isButtonVisible">if set to <c>true</c> [is button visible].</param>
        /// <param name="doUseTimer">if set to <c>true</c> [do use timer].</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/11/2015   created
        /// </Modified>
        public void SetModel(MessageConfirm model, string lenhLaiXe, frmDieuHanhBoDamNEW_V4 parent, bool isButtonVisible, bool doUseTimer)
        {
            if (model == null) {
                this.Close();
                return;
            }
            Parent = parent;
            txtDiaChiDon.Text = model.DiaChiDonKhach;
            lblPrivateCode.Text = model.XeDon;

            lblMsg.Text = "";
            lblMsg.Visible = false;
            Model = model;
            if (doUseTimer)
            {
                if (model.MaMessage == EnVangManagement.MA_LENH_DADON) _time = 1 * 15;
                else _time = 1 * model.Timeout;
                timer1.Start();
            }

            if (model.MaMessage == EnVangManagement.MA_LENH_XINDIEMDO)
            {
                iluVungDH.Bind();
                pnlVungDH.Visible = true;
                pnlDiaChi.Visible = false;
                iluVungDH.EditValue = Convert.ToInt64(model.MessageContent.Split("-".ToCharArray())[0]);
            }
            if (model.MaMessage == EnVangManagement.MA_LENH_BAOKHAITHAC)
            {
                pnlVungDH.Visible = false;
                pnlDiaChi.Visible = false;
            }
            if(model.MaMessage == EnVangManagement.MA_LENH_DRIVERCMD) //Trường hợp dùng driver command
            {
                if (string.IsNullOrEmpty(model.MessageContent))
                {
                    CloseWithoutChoose = false;
                    XuLyLenhLaiXe(0, false);
                    this.Close();
                }

                //Message Content hiện giờ đang ở định dạng:
                //Có confirm hay không (0,1) - Mã số lái xe - ID TrangThaiXeBao - Số phút FromMinute - PK Của MessageXeBao ; Text của command
                var messageParts = model.MessageContent.Split(";".ToCharArray());
                
                lenhLaiXe = messageParts[1];
                var cmdInfo = messageParts[0].Split("-".ToCharArray());
                isButtonVisible = cmdInfo[0].Equals("1");
                HaveToConfirm = isButtonVisible;
                MaLaiXe = cmdInfo[1];
                PKCommandID = Convert.ToInt16(cmdInfo[4]);

                pnlVungDH.Visible = false;
                pnlDiaChi.Visible = false;

                lblMsg.Text = lenhLaiXe;
                lblMsg.Visible = true;
            }

            if (!isButtonVisible)
            {                
                btnYes.Text = "[&O]K";
                btnNo.Visible = false;
            }
            grbForm.Text = lenhLaiXe;

            bwBanCo.WorkerSupportsCancellation = true;
            bwBanCo.DoWork += bwBanCo_DoWork;

        }

        private void bwBanCo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SpeechHelper.Do(string.Format(EnVangManagement.audioMessages[grbForm.Text], lblPrivateCode.Text));
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmInfo_Shown Audio : ", ex);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (CloseWithoutChoose)
            {
                XuLyLenhLaiXe(0, false);
            }
            timer1.Stop();
            base.OnClosed(e);
            if(PostionCurrent>=0&&PostionCurrent<PostionInfo.Count)
                PostionInfo[PostionCurrent] = 0;
        }

        private void frmInfo_Load(object sender, System.EventArgs e)
        {
            for (int i = 0; i < PostionInfo.Count; i++)
            {
                if (PostionInfo[i] == 0)
                {
                    PostionCurrent = i;
                    PostionInfo[i] = 1;
                    break;
                }
            }
            if (PostionCurrent >= 0)
            {
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 2, Screen.PrimaryScreen.Bounds.Height - (Height * (PostionCurrent + 2)));
            }
            else
            {
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 2, Screen.PrimaryScreen.Bounds.Height - (Height*2));
            }

            
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            XuLyLenhLaiXe(1);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            XuLyLenhLaiXe(0);
        }

        /// <summary>
        /// Xử lý lệnh lái xe
        /// </summary>
        /// <param name="doAccept">The do accept.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/11/2015   created
        /// </Modified>
        public void XuLyLenhLaiXe(byte doAccept, bool clickButton = true)
        {
            CloseWithoutChoose = false;
            try
            { 
                 string driverMessage = string.Empty;
                if (Model.MaMessage == EnVangManagement.MA_LENH_DAKETTHUC)
                {
                    if (clickButton) EnVangProcess.SendConfirmDone(Model, doAccept);
                    driverMessage = "Đã kết thúc";
                }
                else if (Model.MaMessage == EnVangManagement.MA_LENH_XINDIEMDO)
                {
                    if (clickButton)
                    {
                        int landMarkGPSID = Convert.ToInt32(iluVungDH.EditValue);
                        int landMarkID = 0;
                        landMarkID = Parent._controlDieuHanhBanCoBanCo.GetIDVung(landMarkGPSID);
                        int node = 0;
                        if (!string.IsNullOrEmpty(txtNode.Text))
                        {
                            node = Convert.ToInt32(txtNode.Text);
                        }
                        //else
                        //{
                        //    node = Parent._controlDieuHanhBanCoBanCo.GetNodeNum(landMarkID, Model.XeDon);
                        //}

                        var value = EnVangProcess.SendConfirmLandmark(Model, doAccept, landMarkGPSID, node, landMarkID);
                    }
                }
                else if (Model.MaMessage == EnVangManagement.MA_LENH_DRIVERCMD && HaveToConfirm)
                {
                    if (clickButton)
                    {
                        var value = EnVangProcess.SendACKActiveChange(Model, doAccept, MaLaiXe, PKCommandID);
                    }
                }
                //if (Model.IDCuocGoi > 0)
                {
                    CuocGoi.DIENTHOAI_SuaMessageConfirm_EnVangVip(Model.IDCuocGoi, driverMessage, Model.MaMessage, !clickButton, Model.SoHieuXe);    
                }                
                Close();
                Parent.XuLyMessageKhongCanConfirm(Model, doAccept);
            }
            catch (System.Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "btnHienThi_Click", DateTime.Now, ex.Message);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            _time--;

            if(_time <= 0 )
            {
                timer1.Stop();
                CloseWithoutChoose = false;
                XuLyLenhLaiXe(0, false);
                this.Close();
            }

            Thread.Sleep(100);
            if (Model == null) return;
        }

        private void txtNode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmInfo_Shown(object sender, EventArgs e)
        {
            if (EnVangManagement.audioMessages.ContainsKey(grbForm.Text))
            {
                bwBanCo.RunWorkerAsync();
                
            }
        }
    }
}
