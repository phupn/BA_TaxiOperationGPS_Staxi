using System;
using System.Drawing;
using System.Windows.Forms;

namespace Taxi.Controls.Base.Inputs
{
    class ITextBox : TextBox
    {
        TextBox bgText = new TextBox();
        
        private string watermarkText;

        public string WatermarkText
        {
            get { return watermarkText; }
            set
            {
                watermarkText = value;
                bgText.Text = watermarkText;
                Point pt = bgText.GetPositionFromCharIndex(bgText.Text.Length - 1);
                this.bgText.Size = new Size(pt.X + 15, pt.Y);
            }
        }

        /// <summary>
        /// hàm khởi tạo đối tượng không có tham số
        /// </summary>
        public ITextBox()
        {
            Inittialize_Component(watermarkText);
        }
        /// <summary>
        /// hàm khởi tạo đối tượng có tham số
        /// </summary>
        public ITextBox(string text)
        {
            Inittialize_Component(text);
        }
        /// <summary>
        /// khởi tạo đối tượng
        /// </summary>
        private void Inittialize_Component(string text)
        {
            this.bgText.Text = text;
            this.bgText.ForeColor = Color.Gray;
            this.bgText.Font = new Font("Verdana", 9F);
            this.bgText.Location = new Point(2, 1);
            this.bgText.BorderStyle = BorderStyle.None;
            this.bgText.Enabled = false;
            this.bgText.BackColor = Color.White;
            this.Controls.Add(bgText);
            this.Font = new Font("Verdana", 9F);
            this.bgText.MouseDown += new MouseEventHandler(bgText_MouseDown);
        }

        private void bgText_MouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (Text != "") SelectAll();
            base.OnGotFocus(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            bgText.Visible = Text == "";
            base.OnTextChanged(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            bgText.Visible = (Enabled && !ReadOnly) && Text == "";
            base.OnEnabledChanged(e);
        }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            bgText.Visible = (Enabled && !ReadOnly) && Text == "";
            base.OnReadOnlyChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            bgText.Font = this.Font;
            base.OnFontChanged(e);
        }

        protected override void OnMultilineChanged(EventArgs e)
        {
            bgText.Location = new Point(5, 1);
            base.OnMultilineChanged(e);
        }
    }
}
