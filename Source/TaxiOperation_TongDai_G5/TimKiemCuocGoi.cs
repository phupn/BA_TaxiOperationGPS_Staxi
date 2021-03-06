using System;
using System.Windows.Forms;

namespace Taxi.GUI
{
    public partial class TimKiemCuocGoi : Form
    {
        private DateTime g_TimeServer;
        private int gTrangThaiCuocGoi;
        private string gLoaiXe;
        private string gKenhVung;        
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
        }

        private void TimKiemCuocGoi_Load(object sender, EventArgs e)
        {            
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
    }
}