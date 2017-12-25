using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Taxi.Common.EnumUtility;
using Taxi.Controls.Base.Inputs;
using System.Linq;
namespace Taxi.Controls.Base.Controls
{
    /// <summary>
    /// Repository dùng cho Enum
    /// </summary>
    
    public class RepositoryItemEnumLookupEdit<T> : RepositoryItemLookUpEdit, IShControl
    {
        /// <summary>
        /// Thực hiện Bind dữ liệu
        /// </summary>
        public void Bind()
        {
            // Tạo cột
            this.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Name", "Tên") });

            // Field lấy làm giá trị
            ValueMember = "Value";

            // Field lấy để hiển thị
            DisplayMember = "Name";

            // Lấy ra các EnumItemAttribute
            var data = Data;

            // Gán DataSource
            this.DataSource = ProcessData(data);

            // Text rỗng
            this.NullText = string.Empty;
        }

        /// <summary>
        /// Xử lý
        /// </summary>
        protected virtual List<EnumItemAttribute> ProcessData(List<EnumItemAttribute> data) { return data; }

        protected virtual List<EnumItemAttribute> Data
        {
            get
            {
                return EnumHandler<T>.Inst.GetEnumItem();//.Select(p=>new EnumItemAttribute(p.Name){FieldName=p.FieldName,Value=(int)p.Value,ValueEnum=(int)p.ValueEnum}).ToList();
            }
        }
    }
}
