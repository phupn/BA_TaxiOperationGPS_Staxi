using DevExpress.XtraEditors.Controls;
using Taxi.Controls.Base.Inputs;
using Taxi.Utils.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Taxi.Controls.Base.Common
{
    public class InputEnumLookUp_TrangThaiXeBaodiDuongDai : InputEnumLookUp<Enum_XeBaoDiDuongDai_TrangThai>
    {
        public void BindNew()
        {
            // Tạo cột
            Properties.Columns.Clear();
            Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Name", "Chọn") });

            // Valude Field
            Properties.ValueMember = "Value";
            // Field Display
            Properties.DisplayMember = "Name";

            var data = Data.Where(p => (int)p.ValueEnum == (int)Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach).ToList();

            // Điền dữ liệu lên            
            Properties.DataSource = data;

            // Thiết lập giá trị mặc định
            if (DefaultSelectFirstRow) this.SetValue(data[0].Value);
        }
    }
}
