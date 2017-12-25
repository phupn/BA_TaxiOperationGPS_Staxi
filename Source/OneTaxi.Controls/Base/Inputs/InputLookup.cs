using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using Staxi.Utils.DbBase;
using Staxi.Utils.Attributes;
using Staxi.Utils.Extender;
using Staxi.Utils.Utility;

using OneTaxi.Controls.Base.Extender;

namespace OneTaxi.Controls.Base.Inputs
{
    /// <summary>
    /// Select Input, tương đương với Combobox
    /// </summary>
    [ToolboxItem(true)]
    public class InputLookUp : LookUpEdit, IInput, IKeyPress, ITextChange
    {
        public bool IsChangeText { get; set; }
        public bool IsForceChangeText { get; private set; }
        public bool IsFocus { get; set; }

        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);
            IsForceChangeText = false;
            IsFocus = true;
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

        public InputLookUp()
        {
            this.Properties.NullText = string.Empty;
        }

        /// <summary>
        /// Clear Form
        /// </summary>
        public virtual void Clear()
        {
            this.EditValue = null;
        }

        /// <summary>
        /// Viết lại phần xử lý text trên lookupEdit
        /// </summary>
        /// <param name="partital"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        protected override bool ProcessNewValueCore(bool partital, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                OnProcessWhenEmptyText();
                return true;
            }

            // 
            else
            {
                OnProcessWhenNotEmptyText();
            
            }

            return base.ProcessNewValueCore(partital, text);
        }

        /// <summary>
        /// Khi mà text trong LookupEdit mà rỗng thì thiết lập giá trị là null
        /// Có thể kế thừa lại để xử lý tùy chọn cho 
        /// Ví dụ như khi text rỗng thì => chọn item đầu tiên v.v...
        /// </summary>
        protected virtual void OnProcessWhenEmptyText()
        {
            this.EditValue = null;
        }

        /// <summary>
        /// Xử lý khi text trên LookupEdit không rỗng
        /// </summary>
        protected virtual void OnProcessWhenNotEmptyText()
        {
            // Nothing => nghĩ là không có gì, vì cuộc đời này vốn dĩ đã không có gì, khi sinh ra đã không có gì và khi chết đi cũng không mang theo gì
        }

        /// <summary>
        /// Thiết lập giá trị
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetValue(object value)
        {
            this.EditValue = value;
        }

        /// <summary>
        /// Lấy ra giá trị
        /// </summary>
        /// <returns></returns>
        public virtual object GetValue()
        {
            return this.EditValue;
        }

        [DefaultValue(Keys.None)]
        public Keys KeyCommand { set; get; }

        public void DoKeyCommand(object sender)
        {
            this.Focus();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && !this.IsPopupOpen)
            {
                e.Handled = true;
                this.DoShowPopup();
            }
            base.OnKeyDown(e);
        }
      
    }

    /// <summary>
    /// Lookup dành cho các danh mục
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InputLookUp<T> : InputLookUp, IBindControl where T : ModelBase, new()
    {
        private bool isShowTextNull=true;
        public bool IsShowTextNull { get{return isShowTextNull;} set{isShowTextNull=value;} }
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
        public event Action<InputLookUp> AfterBind;

        /// <summary>
        /// Mở rộng thêm hành động khi thay đổi giá trị lựa chọn
        /// </summary>
        protected override void OnEditValueChanged()
        {
            // Base
            base.OnEditValueChanged();

            // Nếu có Custom lại sự kiện chọn Item T thì thực hiện
            if (SelectItem != null) SelectItem(this.GetSelectedDataRow().As<T>());
        }

        private bool defaultSelectFirstRow = false;

        /// <summary>
        /// Mặc định là có lựa chọn bản ghi đầu tiên hay không
        /// </summary>
        public bool DefaultSelectFirstRow
        {
            get { return defaultSelectFirstRow; }
            set { defaultSelectFirstRow = value; }
        }

        /// <summary>
        /// Thực hiện Bind data
        /// </summary>
        public void Bind()
        {
            if (this.DesignMode) return;
            // Trước khi thực hiện Bind dữ liệu
            this.BeforeBind();

            // Khởi tạo
            this.Properties.InitWithType(TypeOfT);

            // Điền dữ liệu lên
            var data = Data;

            // Đưa vào source
            ProcessData(data);
            Properties.DataSource = data;

            // Nếu không có sự sau khi Bind thì mặc định chọn giá trị đầu tiên 
            if (data.Count > 0 && DefaultSelectFirstRow)
                this.SetValue(data[0].GetPropertyValue(Properties.ValueMember));

            if (AfterBind != null) this.AfterBind(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Clear()
        {
            if (DefaultSelectFirstRow && Properties.DataSource.CastToList().Count > 0)
                this.ItemIndex = 0;
            else base.Clear();
        }

        /// <summary>
        /// Xử lý dữ liệu trước khi bind
        /// </summary>
        /// <param name="data"></param>
        protected virtual void ProcessData(List<T> data)
        {
            if (!IsShowTextNull||string.IsNullOrEmpty(Properties.NullText)) return;
            DefaultSelectFirstRow = true;

            var t = new T();
            t.SetValueToProperty(this.Properties.DisplayMember, Properties.NullText);
            if (TypeOfT.GetProperty(this.Properties.ValueMember).PropertyType == typeof (string))
                t.SetValueToProperty(this.Properties.ValueMember, Properties.NullText);
            data.Insert(0, t);
        }

        private Type typeOfT = null;

        /// <summary>
        /// Type Of T
        /// </summary>
        protected Type TypeOfT
        {
            get
            {
                if (typeOfT == null) typeOfT = typeof (T);
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
            if (!string.IsNullOrEmpty(Properties.NullText) && this.ItemIndex == 0) return null;

            return base.GetValue();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnProcessWhenEmptyText()
        {
            if (!string.IsNullOrEmpty(Properties.NullText))
                this.Clear();

            else base.OnProcessWhenEmptyText();
        }
    }

    /// <summary>
    /// Lookup dùng cho Enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InputEnumLookUp<T> : InputLookUp, IBindControl
    {
        /// <summary>
        /// Thêm chọn tất cả
        /// </summary>
        public bool IsAddAll { get; set; }

        /// <summary>
        /// Sự kiện lựa chọn
        /// </summary>
        public event Action<FieldInfoAttribute> SelectItem;

        /// <summary>
        /// Sự kiện lựa chọn một item
        /// </summary>
        protected override void OnEditValueChanged()
        {
            // base
            base.OnEditValueChanged();

            // Thực hiện sự kiện
            if (SelectItem != null) SelectItem(this.GetSelectedDataRow().As<FieldInfoAttribute>());
        }

        /// <summary>
        /// Thực hiện Bind dữ liệu
        /// </summary>
        public void Bind()
        {
            // Tạo cột
            Properties.Columns.Clear();
            Properties.Columns.AddRange(new LookUpColumnInfo[] {new LookUpColumnInfo("Name", "Chọn")});

            // Valude Field
            Properties.ValueMember = "RawValue";
            // Field Display
            Properties.DisplayMember = "Name";

            var data = Data;

            // Điền dữ liệu lên            
            Properties.DataSource = data;

            // Thiết lập giá trị mặc định
            if (DefaultSelectFirstRow) this.SetValue(data[0].FieldValue);
        }

        protected virtual List<FieldInfoAttribute> Data
        {
            get
            {
                var data = EnumHelper<T>.Inst.GetAttributes<FieldInfoAttribute>();
                if (IsAddAll)
                {
                    if (data.Any(p => p.Name == "Tất cả")) return data;
                    if (!data.Any(p=>(int)p.FieldValue==0))
                    data.Insert(0, new FieldInfoAttribute() {Name="Tất cả",FieldValue = 0});
                    else
                        data.Insert(0, new FieldInfoAttribute() { Name = "Tất cả", FieldValue = -1 });
                }
                return data;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Clear()
        {
            if (DefaultSelectFirstRow && Properties.DataSource.CastToList().Count > 0)
                this.ItemIndex = 0;
            else base.Clear();
        }

        private bool defaultSelectFirstRow = false;

        /// <summary>
        /// Mặc định là có lựa chọn bản ghi đầu tiên hay không
        /// </summary>
        public bool DefaultSelectFirstRow
        {
            get { return defaultSelectFirstRow; }
            set { defaultSelectFirstRow = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnProcessWhenEmptyText()
        {
            this.Clear();
        }
        public override void SetValue(object value)
        {
            base.SetValue((int?)value);
        }
        public override object GetValue()
        {
            return (int?)base.GetValue();
        }
    }
}
