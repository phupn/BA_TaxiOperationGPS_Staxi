using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Taxi.Controls.Base.Inputs
{
    public class InputTime : TimeEdit, IShInput, IShControl, IShKeyPress, ITextChange
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

        /// <summary>
        /// Clear Form
        /// </summary>
        public void Clear()
        {
            // this.DateTime = DateTime.Now;
            SetValue(null);
        }

        /// <summary>
        /// Thiết lập giá trị của InputDate
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(object value)
        {
            this.EditValue = value;
        }

        /// <summary>
        /// Lấy giá trị đang lựa chọn trên input
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            return this.EditValue;
        }

        private bool _dateNowWhenLoad = true;

        /// <summary>
        /// 
        /// </summary>
        public bool DateNowWhenLoad
        {
            get { return _dateNowWhenLoad; }
            set { _dateNowWhenLoad = value; }
        }

        /// <summary>
        /// Bind data
        /// </summary>
        public void Bind()
        {
            if (_dateNowWhenLoad)
                SetValue(DateTime.Now);
        }

        [DefaultValue(Keys.None)]
        public Keys KeyCommand { set; get; }

        public void DoKeyCommand(object sender)
        {
            this.Focus();
        }
    }
}
