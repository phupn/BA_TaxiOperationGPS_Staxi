using System;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Controls.Base.Inputs;

namespace TaxiOperation_BanCo.UI
{
    /// <summary>
    /// TextBoxUI tăng khả năng xử lý cho textBox
    /// </summary>
    public class TextBoxUI: InputText
    {
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit Properties;
    
        public char decimalSeparator { get; set; }
        public bool IsDecimalSeparator { get; set; }
        public object ValueDefault { get; set; }
        /// <summary>
        /// Số chữ số sau phần thập phân
        /// </summary>
        public int NumberOfDigitAfterSeparator { get; set; }
        public TextBoxUI()
        {
            this.MinValue = decimal.MinValue;
            this.MaxValue = decimal.MaxValue;
            this.decimalSeparator = '.';
            NumberOfDigitAfterSeparator = 2;
            ValueDefault =0;

        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (this.Text == "" && InputOnlyNumber)
            {
                this.EditValue = ValueDefault;
                this.SelectionStart = 1;
            }
               
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (this.Enabled == false)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '\b')
            {
                // Allows Backspace key.
            }

            else if (e.KeyChar == '\r')
            {
               // UpdateText(e.KeyChar);
                // Validate input when Enter key is pressed. 
                // Take other action.
            }
            else
            {
                //if(this.Properties.ReadOnly==true)
                //    return;
                
                UpdateText(e.KeyChar);
                e.Handled = true;
            }

        }
   
        private void UpdateText(char key)
        {
            string input = "";
            int index = this.SelectionStart;
           
            if (this.SelectedText != "")
            {
                input = this.Text.Remove(index, this.SelectedText.Length);
                input = input.Insert(index, key.ToString());
            }
            else
            {
                input = this.Text.Insert(index, key.ToString());
            }
            //else
            //{
            //    input = this.Text + key.ToString();
            //}
            if (InputOnlyNumber && !key.Equals(decimalSeparator))
            {
                if (!char.IsDigit(key))
                   return;
                decimal de = 0;
                if (!decimal.TryParse(input,out de))
                {
                    return;
                }
                if(de<this.MinValue||de>this.MaxValue)
                    return;
                input = de.ToString();

            }
            if (TrimStartUI == true)
            {
                input = input.TrimStart();
            }
            if (InputOnlyNumber && key.Equals(decimalSeparator) )
            {
                if (this.Text.IndexOf(decimalSeparator) > 0 || input.StartsWith(decimalSeparator.ToString())||IsDecimalSeparator)
                    return;
            }
            if (IsDecimalSeparator && key.Equals(decimalSeparator))
                return;

            if (InputOnlyNumber && !IsDecimalSeparator && (NumberOfDigitAfterSeparator > 0))
            {
                int i = input.IndexOf('.');
                if ((input.IndexOf('.') > 0) && (input.Length - 1 - input.IndexOf('.')) >= (NumberOfDigitAfterSeparator + 1))
                {
                    return;
                }
            }
           
            this.Text = input;
            this.SelectionStart = index+1;
        }

        public decimal ValueDecimal
        {
            get
            {
                try
                {
                    return decimal.Parse(this.EditValue.ToString().Trim());
                }
                catch
                {
                    return 0;
                }
                
            }
        }
        public int ValueInt
        {
            get
            {
                try
                {
                    return int.Parse(this.EditValue.ToString().Trim());
                }
                catch
                {
                    return 0;
                }

            }
        }
        public Int16 ValueInt16
        {
            get
            {
                try
                {
                    return Int16.Parse(this.EditValue.ToString().Trim());
                }
                catch
                {
                    return 0;
                }

            }
        }
        public float ValueNumber
        {
            get
            {
                try
                {
                    return (float)Convert.ToDouble(this.EditValue.ToString().Trim(), Taxi.Utils.Global.CultureSystem);
                }
                catch
                {
                    return 0;
                }

            }
        }

        public float ValueDouble
        {
            get
            {
                try
                {
                    return (float) Convert.ToDouble(this.EditValue.ToString().Trim(), Taxi.Utils.Global.CultureSystem);
                }
                catch
                {
                    return 0;
                }

            }
        }

        public bool TrimStartUI{get;set;}
        public bool InputOnlyNumber { get; set; }

        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }

        public void Bind()
        { }

        private void InitializeComponent()
        {
            this.Properties = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Properties
            // 
            this.Properties.Name = "Properties";
            ((System.ComponentModel.ISupportInitialize)(this.Properties)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
