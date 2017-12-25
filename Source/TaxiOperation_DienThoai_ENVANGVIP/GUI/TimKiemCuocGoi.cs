using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Femiani.Forms.UI.Input;

namespace Taxi.GUI
{
    public partial class TimKiemCuocGoi : Form
    {
        private DateTime g_TimeServer;
        private int gTrangThaiCuocGoi;
        private string gLoaiXe;
        private string gKenhVung;
        //private AutoCompleteEntryCollection gListDataAutoComplete;
        public TimKiemCuocGoi()
        {
            InitializeComponent();
        }

        public TimKiemCuocGoi(DateTime CurrTimeServer, string KenhVung, int TrangThaiCuocGoi, string LoaiXe)
        {
            InitializeComponent();
            g_TimeServer = CurrTimeServer;
            gTrangThaiCuocGoi = TrangThaiCuocGoi;
            gLoaiXe = LoaiXe;
            gKenhVung = KenhVung;
            //gListDataAutoComplete = listDataAutoComplete;
        }

        private void TimKiemCuocGoi_Load(object sender, EventArgs e)
        {
            //ctrlSearchCuocGoi.txtDiaChi.Items = gListDataAutoComplete;
            //ctrlSearchCuocGoi.txtLine.Text = gKenhVung;
            if (gTrangThaiCuocGoi == 1)
                ctrlSearchCuocGoi.chkChuaGiaiQuyet.Checked = true;
            else if (gTrangThaiCuocGoi == 2)
                ctrlSearchCuocGoi.chkDaGiaiQuyet.Checked = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ctrlSearchCuocGoi_Load(object sender, EventArgs e)
        {

        }
    }
}