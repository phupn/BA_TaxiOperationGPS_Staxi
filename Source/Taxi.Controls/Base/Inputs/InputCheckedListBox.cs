using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taxi.Controls.Base.Inputs
{
    public class InputCheckedListBox : CheckedListBoxControl, IShInput, IShKeyPress, ITextChange
    {
        public bool IsChangeText { get; set; }
        public bool IsForceChangeText { get; private set; }
        public bool IsFocus { get; set; }
        public int RowCount { get; set; }
        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);
            IsForceChangeText = false;
            IsFocus = true;
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
            SetValue(null);
        }

        /// <summary>
        /// Thiết lập giá trị
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(object value)
        {
            //this.Items[].
            //(value);
        }

        /// <summary>
        /// Lấy ra giá trị
        /// </summary>
        /// <returns></returns>
        public virtual object GetValue()
        {
            string lsId = string.Empty;
            for (int i = 0; i < CheckedItemsCount; i++)
            {
                lsId += string.Format("{0},", CheckedItems[i]);
            }
            return lsId.TrimEnd(',');
        }

        public Keys KeyCommand { get; set; }

        public void DoKeyCommand(object sender)
        {
            this.Focus();
        }
    }
}
