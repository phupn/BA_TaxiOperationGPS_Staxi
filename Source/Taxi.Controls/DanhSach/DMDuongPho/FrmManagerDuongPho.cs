using System;
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;

namespace Taxi.Controls.DanhSach.DMDuongPho
{
    public partial class FrmManagerDuongPho : FormManager
    {
        public FrmManagerDuongPho()
        {
            InitializeComponent();
        }
        public override FormUpdate FormUpdate
        {
            get
            {
                return new FrmUpdateDuongPho();
            }
        }
        public override object GetData()
        {
            return DuongPho.GetAllToList();
        }
    }
}
