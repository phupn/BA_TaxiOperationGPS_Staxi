using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business.CanhBaoSOS;
using Taxi.GUI;

namespace Taxi.Controls.SOS
{
    public partial class frmCanhBaoSOS : Form
    {
        public bool IsShow { get; private set; }
        public frmCanhBaoSOS(List<CanhBaoSOS> data)
        {
            IsShow = true;
            InitializeComponent();
            Icon = global::Taxi.Controls.Properties.Resources.Staxi_96_ic_launcher1;
            grcCanhBaoSOS.DataSource = data;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var dataList = (List<CanhBaoSOS>)grcCanhBaoSOS.DataSource;
            var sl = dataList.Aggregate("0", (current, val) => current + ("," + val.Id));
            new CanhBaoSOS().CheckAll(sl);
            Close();
        }

        public void ReloadData(List<CanhBaoSOS> data)
        {
            grcCanhBaoSOS.DataSource = data;            
        }

        private void frmCanhBaoSOS_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsShow = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                btnAccept_Click(null, null);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }


    public class ProcessCanhBaoSos
    {
        /// <summary>
        /// Line ngồi làm việc của nhân viên
        /// </summary>
        private string LineActive { get; set; }
        private Timer _timer;
        private frmCanhBaoSOS _frm;
        private CanhBaoSOS canhBaoSos;

        public ProcessCanhBaoSos(string line = "")
        {
            LineActive = line;
            canhBaoSos = new CanhBaoSOS();
            _timer = new Timer();
            _timer.Enabled = true;
            _timer.Interval = 2000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            if (_frm == null || !_frm.IsShow)
            {
                var data = canhBaoSos.GetList(LineActive);
                if (data != null && data.Count > 0)
                {
                    Taxi.Business.CommonBL.HavingSOS = true;
                    _frm = new frmCanhBaoSOS(data);
                    _frm.Show();
                }
                else
                    Taxi.Business.CommonBL.HavingSOS = false;
            }
            else
            {
                var data = canhBaoSos.GetList(LineActive);
                if (data != null && data.Count > 0)
                {
                    Taxi.Business.CommonBL.HavingSOS = true;
                    _frm.ReloadData(data);
                }
                else
                    Taxi.Business.CommonBL.HavingSOS = false;
            }
        }

        private static ProcessCanhBaoSos _statBaoSos;
        public static void Start(string line = "")
        {
            _statBaoSos = new ProcessCanhBaoSos(line);
        }
    }
}
