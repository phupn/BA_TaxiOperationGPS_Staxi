using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taxi.Controls.Maps
{
    public partial class TimLoaiXe : FormBase
    {
        public TimLoaiXe() {
            //new Taxi.Controls.Common.ctrlSearchXe(dt);
            InitializeComponent();
            
            ctrlSearchXe1.OnUserControlEditValueChanged += new Taxi.Controls.Common.ctrlLoaiXe_CheckListBox.EditValueChangedEventHandler(ctrlSearchXe2_OnUserControlEditValueChanged);
            
        }


        private void ctrlSearchXe2_OnUserControlEditValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(Taxi.Controls.Common.ctrlLoaiXe_CheckListBox.TenLoaiXe);
        }

        private void TimLoaiXe_Load(object sender, EventArgs e)
        {
            //this.ctrlSearchXe1 = new Taxi.Controls.Common.ctrlSearchXe(dtLoaiXe);
        }
    }
}
