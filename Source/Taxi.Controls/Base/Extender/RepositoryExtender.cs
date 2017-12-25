using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.ShReflector;
namespace Taxi.Controls.Base.Extender
{
    /// <summary>
    /// Phương thức mở rộng cho RepositoryItemLookUpEdit
    /// </summary>
    public static class RepositoryExtender
    {
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="ri"></param>
        /// <param name="type"></param>
        public static void InitWithType(this RepositoryItemLookUpEdit ri, Type type)
        {
            // 
            ri.Columns.Clear();

            // Tạo cột
            ri.Columns.AddRange(
                TypeListFieldNameAttributes<ColumnFieldAttribute>.Inst[type].Select(
                    f => new LookUpColumnInfo(f.Name, f.ColumnName)).ToArray());

            // Null Text
            // ri.NullText = string.Empty;

            // Thiết lập ValueMember
            ri.ValueMember = TypeListFieldNameAttributes<ValueFieldAttribute>.Inst[type].FirstOrDefault().Name;

            // Thiết lập DisplayMember
            ri.DisplayMember = TypeListFieldNameAttributes<DisplayFieldAttribute>.Inst[type].FirstOrDefault().Name;
        }

        /// <summary>
        /// Khởi tạo cho RepositoryItemCheckedComboBoxEdit
        /// </summary>
        /// <param name="ri"></param>
        /// <param name="type"></param>
        public static void InitWithType(this RepositoryItemCheckedComboBoxEdit ri, Type type)
        {
            // Thiết lập Display Member
            ri.DisplayMember = TypeListFieldNameAttributes<DisplayFieldAttribute>.Inst[type].FirstOrDefault().Name;

            // Thiết lập Value Member
            ri.ValueMember = TypeListFieldNameAttributes<ValueFieldAttribute>.Inst[type].FirstOrDefault().Name;
        }
    }
}