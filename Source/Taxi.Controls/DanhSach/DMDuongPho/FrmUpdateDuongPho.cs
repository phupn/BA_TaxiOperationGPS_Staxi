using System;
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;

namespace Taxi.Controls.DanhSach.DMDuongPho
{
    public partial class FrmUpdateDuongPho : FormUpdate
    {
        public override Taxi.Common.DbBase.ModelBase ModelNew
        {
            get
            {
                return new DuongPho();
            }
        }
        public FrmUpdateDuongPho()
        {
            InitializeComponent();
        }
    }
}
