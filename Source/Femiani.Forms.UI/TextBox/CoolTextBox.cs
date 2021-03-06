using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Femiani.Forms.UI.Input
{
	/// <summary>
	/// Summary description for CoolTextBox.
	/// </summary>
	public class CoolTextBox : System.Windows.Forms.UserControl
    {
        [Browsable(true)]
        public event EventHandler TextChanged;

	    //[Browsable(true)]
        //[Description("")]
        public int IntTextLengthTrigger{
            get
            {
                return this.autoCompleteTextBox1.intTextLengthTrigger;
            }
            set
            {
                this.autoCompleteTextBox1.intTextLengthTrigger = value;
            }
        }
        public int MaxLength
        {
            get { return this.autoCompleteTextBox1.MaxLength; }
            set { this.autoCompleteTextBox1.MaxLength = value; }
        }

        private string G_TextReturn = "";
        public string TextReturn
        {
            get
            {
                return this.autoCompleteTextBox1.TextReturn;
            }
            set
            {
                this.autoCompleteTextBox1.TextReturn = value;
            }
        }

        private float G_KinhDo = 0;
        public float KinhDo
        {
            get
            {
                return this.autoCompleteTextBox1.KinhDo;
            }
            set
            {
                this.autoCompleteTextBox1.KinhDo = value;
            }
        }

        private float G_ViDo = 0;
        public float ViDo
        {
            get
            {
                return this.autoCompleteTextBox1.ViDo;
            }
            set
            {
                this.autoCompleteTextBox1.ViDo = value;
            }
        }

        private bool isAuto = false;
        public bool IsAuto
        {
            get
            {
                return this.autoCompleteTextBox1.IsAuto;
            }
            set
            {
                this.autoCompleteTextBox1.IsAuto = value;
            }
        }
        public bool IsCompleted
        {
            get
            {
                return autoCompleteTextBox1.IsCompleted;
            }
        }
        public bool IsFocused
        {
            get { return autoCompleteTextBox1.Focused; }
        }
		private Color borderColor = Color.LightSteelBlue;
		public Color BorderColor
		{
			get
			{
				return this.borderColor;
			}
			set
			{
				if (this.borderColor != value)
				{
					this.borderColor = value;
					this.Invalidate();
				}
			}
		}

		public Color SelectedItemBackColor
		{
			get
			{
				return this.autoCompleteTextBox1.PopupSelectionBackColor;
			}
			set
			{
				this.autoCompleteTextBox1.PopupSelectionBackColor = value;
			}
		}

        /// <summary>
        /// Boi den 1 doan text trong textbox
        /// </summary>
        /// <param name="length"></param>
        public void SelectText_Length(int length)
        {
            this.autoCompleteTextBox1.SelectText_Length(length);
        }

		public Color SelectedItemForeColor
		{
			get
			{
				return this.autoCompleteTextBox1.PopupSelectionForeColor;
			}
			set
			{
				this.autoCompleteTextBox1.PopupSelectionForeColor = value;
			}
		}
        public bool IsPopup
        {
            get
            {
                return autoCompleteTextBox1 != null && autoCompleteTextBox1.IsPopup;
            }
        }
	  

	    [System.ComponentModel.Editor(typeof(AutoCompleteEntryCollection.AutoCompleteEntryCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AutoCompleteEntryCollection Items
		{
			get
			{
				return this.autoCompleteTextBox1.Items;
			}
			set
			{
				this.autoCompleteTextBox1.Items = value;
			}
		}

		[System.ComponentModel.Editor(typeof(AutoCompleteTriggerCollection.AutoCompleteTriggerCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AutoCompleteTriggerCollection Triggers
		{
			get
			{
				return this.autoCompleteTextBox1.Triggers;
			}
			set
			{
				this.autoCompleteTextBox1.Triggers = value;
			}
		}

		[Browsable(true)]
		public override string Text
		{
			get
			{
			    try
			    {
			        return this.autoCompleteTextBox1.Text;
			    }
			    catch 
			    {
			        return string.Empty;
			    }
				
			}
			set
			{
				this.autoCompleteTextBox1.Text = value;
			}
		}

		public override Color ForeColor
		{
			get
			{
				return this.autoCompleteTextBox1.ForeColor;
			}
			set
			{
				this.autoCompleteTextBox1.ForeColor = value;
			}
		}

		public override ContextMenu ContextMenu
		{
			get
			{
				return this.autoCompleteTextBox1.ContextMenu;
			}
			set
			{
				this.autoCompleteTextBox1.ContextMenu = value;
			}
		}

		public int PopupWidth
		{
			get
			{
				return this.autoCompleteTextBox1.PopupWidth;
			}
			set
			{
				this.autoCompleteTextBox1.PopupWidth = value;
			}
		}

        private AutoCompleteTextBox autoCompleteTextBox1;
        private ToolTip toolTip1;
        private IContainer components;

		public CoolTextBox()
		{
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            this.autoCompleteTextBox1.KeyPress += autoCompleteTextBox1_KeyPress;
            this.autoCompleteTextBox1.KeyDown += autoCompleteTextBox1_KeyDown;
            this.autoCompleteTextBox1.KeyUp += autoCompleteTextBox1_KeyUp;
            this.autoCompleteTextBox1.TextChanged += autoCompleteTextBox1_TextChanged;

		}

        void autoCompleteTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChanged(this, e);
            }
        }

        void autoCompleteTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        void autoCompleteTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        void autoCompleteTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);

			Rectangle rect = this.ClientRectangle;
			rect.Width -= 1;
			rect.Height -= 1;
			Pen p = new Pen(this.BorderColor);
			e.Graphics.DrawRectangle(p, rect);
			
			p = new Pen(Color.FromArgb(100, this.BorderColor)); 
			rect.Inflate(-1, -1);
			e.Graphics.DrawRectangle(p, rect);
			
			p = new Pen(Color.FromArgb(45, this.BorderColor)); 
			rect.Inflate(-1, -1);
			e.Graphics.DrawRectangle(p, rect);

			p = new Pen(Color.FromArgb(15, this.BorderColor)); 
			rect.Inflate(-1, -1);
			e.Graphics.DrawRectangle(p, rect);

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.autoCompleteTextBox1 = new Femiani.Forms.UI.Input.AutoCompleteTextBox();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Địa chỉ";
            // 
            // autoCompleteTextBox1
            // 
            this.autoCompleteTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.autoCompleteTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoCompleteTextBox1.intTextLengthTrigger = 0;
            this.autoCompleteTextBox1.IsAuto = false;
            this.autoCompleteTextBox1.KinhDo = 0F;
            this.autoCompleteTextBox1.Location = new System.Drawing.Point(4, 4);
            this.autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            this.autoCompleteTextBox1.PopupBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.autoCompleteTextBox1.PopupOffset = new System.Drawing.Point(12, 4);
            this.autoCompleteTextBox1.PopupSelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.autoCompleteTextBox1.PopupSelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.autoCompleteTextBox1.PopupWidth = 120;
            this.autoCompleteTextBox1.Size = new System.Drawing.Size(117, 13);
            this.autoCompleteTextBox1.TabIndex = 0;
            this.autoCompleteTextBox1.Text = "autoCompleteTextBox";
            this.autoCompleteTextBox1.TextReturn = "";
            this.toolTip1.SetToolTip(this.autoCompleteTextBox1, "(\"10 dthoang -- gần bdien HN\" = 10,Đinh Tiên Hoàng,Hoàn Kiếm)");
            this.autoCompleteTextBox1.ViDo = 0F;
            this.autoCompleteTextBox1.SizeChanged += new System.EventHandler(this.TextBox_SizeChanged);
            // 
            // CoolTextBox
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.autoCompleteTextBox1);
            this.Name = "CoolTextBox";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(125, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void TextBox_SizeChanged(object sender, System.EventArgs e)
		{
			AutoCompleteTextBox tb = sender as AutoCompleteTextBox;

			this.Height = tb.Height + 8;
		}
       
	}
}
