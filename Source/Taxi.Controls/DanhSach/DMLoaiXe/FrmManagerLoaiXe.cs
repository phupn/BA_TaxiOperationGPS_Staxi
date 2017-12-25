using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;

namespace Taxi.Controls.DanhSach.DMLoaiXe
{
    public partial class FrmManagerLoaiXe : FormManager
    {
        public FrmManagerLoaiXe()
        {
            InitializeComponent();
        }

        public override object GetData()
        {
            return LoaiXe.GetAllToList();
        }

        public override Taxi.Controls.Base.FormUpdate FormUpdate
        {
            get
            {
                return new FrmUpdateLoaiXe();
            }
        }
    }
}
