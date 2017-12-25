using System.Windows.Forms;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using Taxi.Business;
using Taxi.Common.DbBase;
using Taxi.Common.Utility;
using Taxi.Controls.Base.Extender;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
namespace Taxi.Controls.Base.Inputs
{
    /// <summary>
    /// Input chọn nhiều
    /// </summary>
    public class InputCheckedComboBox : CheckedComboBoxEdit, IShInput, IShKeyPress, ITextChange
    {
        public bool IsChangeText { get; set; }
        public bool IsForceChangeText { get; private set; }
        public bool IsFocus { get; set; }
        private bool isCheckItemOne;
        public int RowCount{ get; set; }
        public bool IsCheckItemOne { get { return isCheckItemOne; } set { isCheckItemOne = value; if (isCheckItemOne) { Popup_ItemChecking += _Popup_ItemChecking; } else { Popup_ItemChecking -= _Popup_ItemChecking; } } }
        /// <summary>
        /// Sự kiện click vào item của phần popup
        /// </summary>
        public event DevExpress.XtraEditors.Controls.ItemCheckingEventHandler Popup_ItemChecking;
        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);
            IsForceChangeText = false;
            IsFocus = true;
        }
        public InputCheckedComboBox()
        {
            this.Popup+=InputCheckedComboBox_Popup;
        }

        private void InputCheckedComboBox_Popup(object sender, EventArgs e)
        {           
            try
            {
                if (Popup_ItemChecking != null)
                {
                    PopupContainerForm form = (sender as IPopupControl).PopupWindow as PopupContainerForm;
                    (form.Controls[3].Controls[0] as CheckedListBoxControl).ItemChecking += Popup_ItemChecking;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("InputCheckedComboBox_Popup: ", ex);                
            }
        }
        private void _Popup_ItemChecking(object sender, DevExpress.XtraEditors.Controls.ItemCheckingEventArgs e)
        {
            if (!IsPopupOpen) return;
            if (IsCheckItemOne)
            {
                var op = sender as CheckedListBoxControl;
                if (op != null)
                {
                    for (int index = 0; index < op.Items.Count; index++)
                    {
                        if (index != e.Index && op.Items[index].CheckState != CheckState.Unchecked)
                        {
                            op.Items[index].CheckState = CheckState.Unchecked;
                        }
                    }
                }
            }
        }
            
        protected override void OnEditValueChanged()
        {
            if (this.IsFocus)
            {
                IsForceChangeText = true;
                IsChangeText = true;
            }
            base.OnEditValueChanged();
        }

        protected override void OnTextChanged(System.EventArgs e)
        {

            if (this.IsFocus)
            {
                IsForceChangeText = true;
                IsChangeText = true;
            }
            base.OnTextChanged(e);
        }

        protected override void OnLeave(System.EventArgs e)
        {
            IsFocus = false;
            base.OnLeave(e);
        }

        public virtual void Clear()
        {
            this.Reset();
            SetValue(null);
        }

        /// <summary>
        /// Thiết lập giá trị
        /// </summary>        
        public void SetValue(object value)
        {
            SetEditValue(value);
        }

        /// <summary>
        /// Lấy ra giá trị
        /// </summary>        
        public virtual object GetValue()
        {
            return this.EditValue.ToString();
        }

        public Keys KeyCommand { get; set; }

        public void DoKeyCommand(object sender)
        {
            this.Focus();
        }
    }
    public class InputCheckedComboBox<T> : InputCheckedComboBox, IShInput, IShControl where T : ModelBase, new()
    {
        /// <summary>
        /// Trước khi thực hiện Bind dữ liệu
        /// </summary>
        protected virtual void BeforeBind()
        {
        }

        /// <summary>
        /// Sự kiện lựa chọn một Item
        /// </summary>
        public event Action<T> SelectItem;

        /// <summary>
        /// Sự kiện sau khi thực hiện Bind dữ liệu
        /// </summary>
        public event Action<InputCheckedComboBox> AfterBind;

        /// <summary>
        /// Mở rộng thêm hành động khi thay đổi giá trị lựa chọn
        /// </summary>
        protected override void OnEditValueChanged()
        {
            // Base
            base.OnEditValueChanged();

            // Nếu có Custom lại sự kiện chọn Item T thì thực hiện
          //  if (SelectItem != null) SelectItem(this.GetSelectedDataRow().As<T>());
        }

        /// <summary>
        /// Thực hiện Bind data
        /// </summary>
        public void Bind()
        {
            // Trước khi thực hiện Bind dữ liệu
            this.BeforeBind();

            // Khởi tạo
            this.Properties.InitWithType(TypeOfT);

            // Điền dữ liệu lên
            var data = Data;

            // Đưa vào source
            ProcessData(data);
            Properties.DataSource = data;

            //// Nếu không có sự sau khi Bind thì mặc định chọn giá trị đầu tiên 
            //if (data.Count > 0 && DefaultSelectFirstRow)
            //    this.SetValue(data[0].GetPropertyValue(Properties.ValueMember));

            if (AfterBind != null) this.AfterBind(this);
        }

        /// <summary>
        /// Xử lý dữ liệu trước khi bind
        /// </summary>
        /// <param name="data"></param>
        protected virtual void ProcessData(List<T> data)
        {
            //if (string.IsNullOrEmpty(Properties.NullText)) return;
            //DefaultSelectFirstRow = true;

            //var t = new T();
            //t.SetPropertyValue(this.Properties.DisplayMember, Properties.NullText);
            //if (TypeOfT.GetProperty(this.Properties.ValueMember).PropertyType == typeof(string))
            //    t.SetPropertyValue(this.Properties.ValueMember, Properties.NullText);
            //data.Insert(0, t);
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

        private Func<List<T>> func = null;

        /// <summary>
        /// Phương thức thể lấy dữ liệu
        /// </summary>
        public void SetFunc(Func<List<T>> func)
        {
            this.func = func;
        }

        /// <summary>
        /// Data
        /// </summary>
        protected virtual List<T> Data
        {
            get
            {
                // Nếu có phương thức lấy dữ liệu thì thực hiện, không thì lấy tất cả
                return this.func == null ? BusinessCommon<T>.Inst.GetAllToList() : func();
            }
        }

        /// <summary>
        /// Get data của lookup input
        /// </summary>
        public List<T> GetData
        {
            get { return this.func == null ? BusinessCommon<T>.Inst.GetAllToList() : func(); }
        }

        public override object GetValue()
        {
            return base.GetValue();
        }
    }
}