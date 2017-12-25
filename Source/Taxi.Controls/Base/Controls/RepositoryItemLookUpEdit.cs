using System;
using System.Collections.Generic;
using DevExpress.XtraEditors.Repository;
using Taxi.Common.DbBase;
using Taxi.Common.Utility;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base.Inputs;

namespace Taxi.Controls.Base.Controls
{
    /// <summary>
    /// RepositoryItemLookUpEdit
    /// </summary>
    public class RepositoryItemLookUpEdit<T> : RepositoryItemLookUpEdit, IShControl, IRepository<T> where T : ModelBase, new()
    {

        /// <summary>
        /// Thực hiện Bind dữ liệu
        /// </summary>
        public void Bind()
        {
            // Tạo cột
            this.InitWithType(TypeOfT);
            // Thiết lập data
            DataSource = currentData = Data;
        }

        private Type typeOfT = null;
        /// <summary>
        /// Type Of T
        /// </summary>
        protected Type TypeOfT
        {
            get
            {
                if (typeOfT == null) typeOfT = typeof(T);
                return typeOfT;
            }
        }

        private List<T> currentData;
        /// <summary>
        /// Data đang binding
        /// </summary>
        public List<T> CurrentData
        {
            get { return currentData; }
        }

        private Func<List<T>> func = null;
        /// <summary>
        /// Function lấy dữ liệu
        /// </summary>
        public Func<List<T>> Func
        {
            get { return func; }
            set { func = value; }
        }

        /// <summary>
        /// Data
        /// </summary>
        protected virtual List<T> Data
        {
            get
            {
                // Nếu có function lấy dữ liệu từ thực hiện, không thì lấy tất
                return func == null ? BusinessCommon<T>.Inst.GetAllToList() : Func();
            }
        }
    }
}
