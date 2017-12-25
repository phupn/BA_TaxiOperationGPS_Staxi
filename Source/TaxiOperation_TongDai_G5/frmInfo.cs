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

namespace Taxi.GUI
{
    public partial class frmInfo : FormBase
    {
        public frmInfo()
        {
            InitializeComponent();
        }
        public static List<frmInfo> topForm = new List<frmInfo>();
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
        public string LenhLaiXe;
        private frmDieuHanhBoDamNEW_V3 Parent = new frmDieuHanhBoDamNEW_V3();
        private int _time = 1 * 30;
        // Kiểm tra trường hợp đóng mà không chọn Y/N
        private bool CloseWithoutChoose = true;

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
        public void SetModel(MessageConfirm model, string lenhLaiXe, frmDieuHanhBoDamNEW_V3 parent, bool isButtonVisible, bool doUseTimer)
        {
            if (model == null) {
                this.Close();
                return;
            }
            Parent = parent;
            txtDiaChiDon.Text = model.DiaChiDonKhach;
            lblPrivateCode.Text = model.XeDon;
            grbForm.Text = lenhLaiXe;
            Model = model;
            if (doUseTimer)
            {
                if (model.MaMessage == EnVangManagement.MA_LENH_DADON) _time = 1 * 15;
                timer1.Start();
            }   
            if (!isButtonVisible)
            {
                btnYes.Visible = false;
                btnNo.Visible = false;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (CloseWithoutChoose)
            {
                XuLyLenhLaiXe(0);
            }
            if (topForm.Contains(this))
                topForm.Remove(this);
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
        private void XuLyLenhLaiXe(byte doAccept)
        {
            CloseWithoutChoose = false;
            try
            {
                string driverMessage = string.Empty;
                if (Model.MaMessage == EnVangManagement.MA_LENH_MOIKHACH)
                {
                    EnVangProcess.SendACKInvite(Model, doAccept);
                }
                else if (Model.MaMessage == EnVangManagement.MA_LENH_XINSODT)
                {
                    EnVangProcess.SendACKGetPhone(Model, doAccept);
                }
                else if (Model.MaMessage == EnVangManagement.MA_LENH_DAKETTHUC)
                {
                    EnVangProcess.SendConfirmDone(Model, doAccept);
                    driverMessage = "Đã kết thúc";
                }
                CuocGoi.DIENTHOAI_SuaMessageConfirm_EnVangVip(Model.IDCuocGoi, driverMessage, Model.MaMessage, false, Model.SoHieuXe);
                //Parent.openedDialogs.Remove(Model.MaMessage + "_" + Model.XeDon);
                Close();
            }
            catch (System.Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "btnHienThi_Click", DateTime.Now, ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _time--;
            if (_time <= 0)
            {
                XuLyLenhLaiXe(0);
                Thread.Sleep(100);
                this.Close();
            }
            Thread.Sleep(100);
            if (Model == null) return;
        }
    }
}
