using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Common.DbBase;
using Taxi.Data.G5.DanhMuc;

namespace Taxi.Controls.DanhSach.DMLoaiXe
{
    public partial class FrmUpdateLoaiXe : FormUpdate
    {
        public FrmUpdateLoaiXe()
        {
            InitializeComponent();
        }

        public override ModelBase ModelNew
        {
            get
            {
                return new LoaiXe();
            }
        }
    }
}
