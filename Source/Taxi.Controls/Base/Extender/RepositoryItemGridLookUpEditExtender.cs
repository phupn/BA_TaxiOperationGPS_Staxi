using System;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Common.ShReflector;

namespace Taxi.Controls.Base.Extender
{
    /// <summary>
    /// Mở rộng phương thức cho RepositoryItemGridLookUpEdit
    /// </summary>
    public static class RepositoryItemGridLookUpEditExtender
    {
        /// <summary>
        /// Khởi tạo RepositoryItemGridLookUpEdit với Type
        /// </summary>
        /// <param name="type"></param>
        public static void InitWithType(this RepositoryItemGridLookUpEdit ri, Type type, string[] fieldShows = null)
        {
            // Khởi tạo GridView
            GridView gv = new GridView();

            // Tạo action xử lý một ColumnFieldAttribute
            Action<ColumnFieldAttribute> action = (f) =>
                {
                    // Tạo cột
                    var gc = gv.CreateNewGridColumn(f.ColumnName);

                    // FieldName
                    gc.FieldName = f.Name;

                    // 
                    gc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;

                    // Cho Phép filter
                    gc.OptionsFilter.AllowAutoFilter = true;                    
                };

            // Tạo cột // Nếu không có thiết lập fieldShow thì tạo tất cả các cột, còn không thì có thiết lập thì mới tạo
            if (fieldShows.IsNull() || fieldShows.Length == 0)                
                TypeListFieldNameAttributes<ColumnFieldAttribute>.Inst[type].ForEach(f => action(f));
            else                
                TypeListFieldNameAttributes<ColumnFieldAttribute>.Inst[type].ForEach(f => { if (fieldShows.Contains(f.Name)) action(f); });

            // Không thực hiện ShowGroup
            gv.OptionsView.ShowGroupPanel = false;

            // Hiển thị Box tìm kiếm
            gv.OptionsView.ShowAutoFilterRow = true;

            // Khởi tạo View
            ri.View = gv;

            // Tiêu đề hiển thị
            ri.DisplayMember = ri.DisplayMember.IsNull() ? TypeListFieldNameAttributes<DisplayFieldAttribute>.Inst[type].FirstOrDefault().Name : ri.DisplayMember;

            // Giá trị cần lấy
            ri.ValueMember = TypeListFieldNameAttributes<ValueFieldAttribute>.Inst[type].FirstOrDefault().Name;

            // Null Text
            ri.NullText = string.Empty;
        }
    }
}
