using DevExpress.XtraEditors.Controls;
using System.Linq;
using Taxi.Controls.Base.Inputs;
using Taxi.Utils.Enums.DieuXeChieuVe;

namespace Taxi.Controls.Base.Common
{
    public class InputEnumLookUp_Bookings_OpStatus : InputEnumLookUp<Enum_Bookings_OpStatus>
    {
        public void BindKhachDaGapXe()
        {            
            // Tạo cột
            Properties.Columns.Clear();
            Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Name", "Chọn") });

            // Valude Field
            Properties.ValueMember = "Value";
            // Field Display
            Properties.DisplayMember = "Name";

            var data = Data;

            // Điền dữ liệu lên
            Properties.DataSource = data.Where(p=>(int)p.ValueEnum!=(int)Enum_Bookings_OpStatus.MobileKetThuc).ToList();
            //
            this.SetValue((int)Enum_Bookings_OpStatus.DaDonKhach);

        }
    }
}
