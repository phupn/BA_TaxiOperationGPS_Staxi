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

namespace Taxi.Controls.FastTaxis.TaxiDieuXe
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
        public event Action Remove;
        public Booking Model;
        public void SetModel(Booking model)
        {
            if (model == null) {
                this.Close();
                return;
            }
            lblDiaChiDon.Text = model.FromAddress;
            lblDiaChiTra.Text = model.ToAdress;
            lblSoDT.Text = "Chờ nhận đón...";
            lblThoiDiemDon.Text = string.Format("{0:HH:mm} - {1:HH:mm dd/MM}", model.FromTime, model.ToTime);
            lblXeDon.Text = model.SuggesCars;
            Model = model;
        }

        protected override void OnClosed(EventArgs e)
        {
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
                //if (PostionCurrent == 0)
                //{
                //    topForm.Add(this);
                //    for (int i = topForm.Count - 1; i >= 0; i--)
                //    {
                //       // topForm[i].Setin(this, 0); ;
                //    }
                //}
               
            }
            else
            {
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 2, Screen.PrimaryScreen.Bounds.Height - (Height*2));
                //topForm.Add(this);
                //for (int i = topForm.Count - 1; i >= 0; i--)
                //{
                //    // topForm[i].Setin(this, 0); ;
                //}
               
            }
            var frm = Application.OpenForms.OfType<frmInfo>().Where(p => p.Name == this.Name && (p.PostionCurrent == -1 || p.PostionCurrent == 0)).ToList();
            shProgressBar_Timeout.Properties.Minimum = 0;
            shProgressBar_Timeout.Properties.Maximum = 1 * 60;
            int SoPhutCho = 0;
            if (Model != null)
            {
                var dt = Model.CreatedDate ?? Model.DateCreated;
                 SoPhutCho = (int)(DieuHanhTaxi.GetTimeServer() - dt.Value).TotalSeconds;
            }
            shProgressBar_Timeout.EditValue = 1 * 60 - SoPhutCho;
            timer1.Start();
            if (Application.OpenForms["frmKhachCanXe"] != null && Application.OpenForms["frmKhachCanXe"] is frmKhachCanXe)
            {
                (Application.OpenForms["frmKhachCanXe"] as frmKhachCanXe).CoCuocGoiMoi(this);
            }
        }
        private int _time = 1*60;
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _time--;
            shProgressBar_Timeout.EditValue = _time;
            if (_time <= 0)
            {
                this.Close();
            }
            if (Model == null) return;
            if (Model.OpReceivedTime != null || Model.FK_TaxiReturn > 0 || Model.OpCommand=="KH hủy")
            {
                
                timer1.Stop();
                this.Close();
                if (Remove != null)
                {
                    Remove();
                }
            }
            
        }
        [MethodWithKey(Keys=(Keys.Control|Keys.H))]
        public void ShowCtrlH()
        {
            this.Hide();
            timer1.Enabled = false;
            this.Close();
            Model.OpReceivedTime = TaxiReturn_Process.timerServer;
            //Model.OpAcceptedTime = Model.OpReceivedTime;
            Model.OpReceivedUser = ThongTinDangNhap.USER_ID;
            //Model.OpAcceptedUser = ThongTinDangNhap.USER_ID;
            Model.OpReceived(Model.PK_BooID,Model.OpReceivedUser);
            TaxiReturn_Process.OperationHasReceive(Model.PK_BooID, ThongTinCauHinh.GPS_MaCungXN.To<int>());
            new frmKhachCanXe(true, Model).ShowDialog();
        }

        private void btnHienThi_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Model == null)
                {
                    Close();
                    return;
                }
                if (frmKhachCanXe.IsOpenStatic){
                    Model.OpReceived(Model.PK_BooID, ThongTinDangNhap.USER_ID);
                    TaxiReturn_Process.OperationHasReceive(Model.PK_BooID, ThongTinCauHinh.GPS_MaCungXN.To<int>());
                }                    
                else
                    ShowCtrlH();
            } 
            catch (System.Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "btnHienThi_Click", DateTime.Now, ex.Message);
            }
           
        }

        private void shProgressBar_Timeout_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            int sophut = (e.Value.To<int>() / 60);
            int soGiay = e.Value.To<int>() - sophut * 60;
            e.DisplayText = string.Format("Còn lại {0}:{1}", sophut, soGiay);
        }
    }
}
