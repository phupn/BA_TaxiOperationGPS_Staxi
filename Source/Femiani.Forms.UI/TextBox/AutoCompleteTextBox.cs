using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;

namespace Femiani.Forms.UI.Input
{
	/// <summary>
	/// Summary description for AutoCompleteTextBox.
	/// </summary>
	[Serializable]
	public class AutoCompleteTextBox : TextBox
	{
        
		#region Classes and Structures

		public enum EntryMode
		{
			Text,
			List
		}

		/// <summary>
		/// This is the class we will use to hook mouse events.
		/// </summary>
		private class WinHook : NativeWindow
		{
			private AutoCompleteTextBox tb;

			/// <summary>
			/// Initializes a new instance of <see cref="WinHook"/>
			/// </summary>
			/// <param name="tbox">The <see cref="AutoCompleteTextBox"/> the hook is running for.</param>
			public WinHook(AutoCompleteTextBox tbox)
			{
				this.tb = tbox;
			}

			/// <summary>
			/// Look for any kind of mouse activity that is not in the
			/// text box itself, and hide the popup if it is visible.
			/// </summary>
			/// <param name="m"></param>
			protected override void WndProc(ref Message m)
			{
				switch (m.Msg)
				{
					case Win32.Messages.WM_LBUTTONDOWN:
					case Win32.Messages.WM_LBUTTONDBLCLK:
					case Win32.Messages.WM_MBUTTONDOWN:
					case Win32.Messages.WM_MBUTTONDBLCLK:
					case Win32.Messages.WM_RBUTTONDOWN:
					case Win32.Messages.WM_RBUTTONDBLCLK:
					case Win32.Messages.WM_NCLBUTTONDOWN:
					case Win32.Messages.WM_NCMBUTTONDOWN:
					case Win32.Messages.WM_NCRBUTTONDOWN:
					{
						// Lets check to see where the event took place
						Form form = tb.FindForm();
						Point p = form.PointToScreen(new Point((int)m.LParam));
						Point p2 = tb.PointToScreen(new Point(0, 0));
						Rectangle rect = new Rectangle(p2, tb.Size);
						// Hide the popup if it is not in the text box
						if (!rect.Contains(p))
						{
							tb.HideList();
						}
					} break;
					case Win32.Messages.WM_SIZE:
					case Win32.Messages.WM_MOVE:
					{
						tb.HideList();
					} break;
					// This is the message that gets sent when a childcontrol gets activity
					case Win32.Messages.WM_PARENTNOTIFY:
					{
						switch ((int)m.WParam)
						{
							case Win32.Messages.WM_LBUTTONDOWN:
							case Win32.Messages.WM_LBUTTONDBLCLK:
							case Win32.Messages.WM_MBUTTONDOWN:
							case Win32.Messages.WM_MBUTTONDBLCLK:
							case Win32.Messages.WM_RBUTTONDOWN:
							case Win32.Messages.WM_RBUTTONDBLCLK:
							case Win32.Messages.WM_NCLBUTTONDOWN:
							case Win32.Messages.WM_NCMBUTTONDOWN:
							case Win32.Messages.WM_NCRBUTTONDOWN:
							{
								// Same thing as before
								Form form = tb.FindForm();
								Point p = form.PointToScreen(new Point((int)m.LParam));
								Point p2 = tb.PointToScreen(new Point(0, 0));
								Rectangle rect = new Rectangle(p2, tb.Size);
								if (!rect.Contains(p))
								{
									tb.HideList();
								}
							} break;
						}
					} break;
				}
				
				base.WndProc (ref m);
			}
		}

		#endregion

		#region Members
        private static string strNoneAutoComplete = "";
        private static bool isNum = false;
        public static bool isComplete = false;
		private ListBox list;
		protected Form popup;
        public bool IsPopup
        {
            get
            {
                return popup != null && popup.Visible;
            }
        }
		private AutoCompleteTextBox.WinHook hook;
        //private bool G_GoGiaiThichTruoc = false;
        //private string prefix = "";
        /// <summary>
        /// SỐ NHÀ - NGÕ - NGÁCH - TÊN ĐƯỜNG - QUẬN HUYỆN - ... - GIẢI THÍCH
        /// </summary>
        private string [] G_Address = new string[2];
        private int[] arrINum = new int[4];//1[~] 2[/] 3[-] 4[ ]
        /// <summary>
        /// Định nghĩa các ký tự ktra số nhà "N", "/", "-", " ","~"
        /// </summary>
        private string[] arrRegex = new string[] { "N", "/", "-", " ","~" };
		#endregion

		#region Properties

		private AutoCompleteTextBox.EntryMode mode = EntryMode.Text;
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AutoCompleteTextBox.EntryMode Mode
		{
			get
			{
				return this.mode;
			}
			set
			{
				this.mode = value;
			}
		}

		private AutoCompleteEntryCollection items = new AutoCompleteEntryCollection();
		[System.ComponentModel.Editor(typeof(AutoCompleteEntryCollection.AutoCompleteEntryCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AutoCompleteEntryCollection Items
		{
			get
			{
				return this.items;
			}
			set
			{
				this.items = value;
			}
		}

		private AutoCompleteTriggerCollection triggers = new AutoCompleteTriggerCollection();
		[System.ComponentModel.Editor(typeof(AutoCompleteTriggerCollection.AutoCompleteTriggerCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AutoCompleteTriggerCollection Triggers
		{
			get
			{
				return this.triggers;
			}
			set
			{
				this.triggers = value;
			}
		}

		[Browsable(true)]
		[Description("The width of the popup (-1 will auto-size the popup to the width of the textbox).")]
		public int PopupWidth
		{
			get
			{
				return this.popup.Width;
			}
			set
			{
				if (value == -1)
				{
					this.popup.Width = this.Width;
				} 
				else
				{
					this.popup.Width = value;
				}
			}
		}

		public BorderStyle PopupBorderStyle
		{
			get
			{
				return this.list.BorderStyle;
			}
			set
			{
				this.list.BorderStyle = value;
			}
		}

		private Point popOffset = new Point(12, 0);
		[Description("The popup defaults to the lower left edge of the textbox.")]
		public Point PopupOffset
		{
			get
			{
				return this.popOffset;
			}
			set
			{
				this.popOffset = value;
			}
		}

		private Color popSelectBackColor = SystemColors.Highlight;
		public Color PopupSelectionBackColor
		{
			get
			{
				return this.popSelectBackColor;
			}
			set
			{
				this.popSelectBackColor = value;
			}
		}

		private Color popSelectForeColor = SystemColors.HighlightText;
		public Color PopupSelectionForeColor
		{
			get
			{
				return this.popSelectForeColor;
			}
			set
			{
				this.popSelectForeColor = value;
			}
		}

		private bool triggersEnabled = true;
		protected bool TriggersEnabled
		{
			get
			{
				return this.triggersEnabled;
			}
			set
			{
				this.triggersEnabled = value;
			}
		}

		[Browsable(true)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{                
				this.TriggersEnabled = false;
				base.Text = value;
				this.TriggersEnabled = true;
			}
		}

        private int G_intTextLengthTrigger = 0;
        //[Browsable(true)]
        //[Description("")]
        public int intTextLengthTrigger
        {
            get
            {
                return this.G_intTextLengthTrigger;
            }
            set
            {
                this.G_intTextLengthTrigger = value;
            }
        }

        private string G_TextReturn = "";
        public string TextReturn
        {
            get
            {
                return this.G_TextReturn;
            }
            set
            {
                this.G_TextReturn = value;
            }
        }

        private float G_KinhDo = 0;
        public float KinhDo
        {
            get
            {
                return this.G_KinhDo;
            }
            set
            {
                this.G_KinhDo = value;
            }
        }

        private float G_ViDo = 0;
        public float ViDo
        {
            get
            {
                return this.G_ViDo;
            }
            set
            {
                this.G_ViDo = value;
            }
        }

        private bool isAuto = false;
        public bool IsAuto
        {
            get
            {
                return this.isAuto;
            }
            set
            {
                this.isAuto = value;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return isComplete;
            }
        }

		#endregion

		public AutoCompleteTextBox()
		{
			// Create the form that will hold the list
			this.popup = new Form();
			this.popup.StartPosition = FormStartPosition.Manual;
			this.popup.ShowInTaskbar = false;
			this.popup.FormBorderStyle = FormBorderStyle.None;
			this.popup.TopMost = true;
			this.popup.Deactivate += new EventHandler(Popup_Deactivate);

			// Create the list box that will hold mathcing items
			this.list = new ListBox();
			this.list.Cursor = Cursors.Hand;
			this.list.BorderStyle = BorderStyle.None;
			this.list.SelectedIndexChanged += new EventHandler(List_SelectedIndexChanged);
			this.list.MouseDown += new MouseEventHandler(List_MouseDown);
			this.list.ItemHeight = 14;
			this.list.DrawMode = DrawMode.OwnerDrawFixed;
			this.list.DrawItem += new DrawItemEventHandler(List_DrawItem);
			this.list.Dock = DockStyle.Fill;
		
			// Add the list box to the popup form
			this.popup.Controls.Add(this.list);

			// Add default triggers.
            this.triggers.Add(new TextLengthTrigger(G_intTextLengthTrigger));
			this.triggers.Add(new ShortCutTrigger(Keys.Enter, TriggerState.SelectAndConsume));
			this.triggers.Add(new ShortCutTrigger(Keys.Tab, TriggerState.Select));
			this.triggers.Add(new ShortCutTrigger(Keys.Control | Keys.Space, TriggerState.ShowAndConsume));
			this.triggers.Add(new ShortCutTrigger(Keys.Escape, TriggerState.HideAndConsume));

            //dtNoneAutoComplete = new DiaDanh().GetData_NoneAutocomplete();

		}

        private bool isNumber(string strNumber)
        {
            if (strNumber.Length > 0)
            {
                int num;
                int num1;
                int num2;
                //num1 = strNumber.IndexOf("~");
                
                //if (num1 == 0)
                //{
                //    strNumber = strNumber.Substring(1);                    
                //}                

                if (int.TryParse(strNumber, out num))
                {
                    isNum = true;
                    return true;
                }
                else
                {                   
                    isNum = false;
                    return false;
                }
            }
            else
            {
                isNum = true;
                return true;
            }
        }

        private string getTextAutoComplete_new()
        {
            try
            {
                string returnValue = string.Empty;
                string strValue = this.Text;
                G_Address[0] = "";
                if (strValue.Length > 0)
                {
                    // Giải thích viết trước
                    arrINum[2] = strValue.IndexOf(arrRegex[2]);//Có ghi giải thích hay không
                    if (arrINum[2] > 0)
                    {
                        returnValue = strValue.Substring(0, arrINum[2]);// phần trước ghi chú
                        G_Address[1] = strValue.Substring(arrINum[2]);// phần ghi chú
                        arrINum[3] = returnValue.IndexOf(arrRegex[3]);//Có Số nhà hay ko
                        int number = 0;
                        bool isNumber = int.TryParse(strValue.Substring(0, 1), out number);
                        if (arrINum[3] > 0 && isNumber)
                        {
                            returnValue = returnValue.Substring(arrINum[3] + 1);
                            FormatBuilding(strValue.Substring(0, arrINum[3]));
                        }
                    }

                    //Giải thích viết sau
                    else
                    {
                        G_Address[1] = "";// phần ghi chú
                        returnValue = strValue;
                        arrINum[3] = strValue.IndexOf(arrRegex[3]);//Có Số nhà hay ko
                        int number = 0;
                        //isNumber : Check bỏ chữ N đầu tiên. chuyển thành Ngõ
                        bool isNumber = int.TryParse(strValue.Substring(0, 1), out number);
                        if (!isNumber)
                        {
                            if (strValue.Length > 1)
                            {
                                isNumber = int.TryParse(strValue.Substring(1, 2), out number);
                            }
                        }
                        if (arrINum[3] > 0 && isNumber)
                        {
                            returnValue = returnValue.Substring(arrINum[3] + 1);
                            FormatBuilding(strValue.Substring(0, arrINum[3]));
                        }
                    }
                }
                else
                {
                    G_Address = new string[2];
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        private void FormatBuilding(string Building)
        {
            if (Config_Common.GEOService == Taxi.Utils.EnumGEOService.Google)
            {
                G_Address[0] = Building + " ";
                return;
            }
            if (Config_Common.BoVietTatNgo)
            {
                G_Address[0] = Building + ",";
                return;
            }
            //Số nhà có ngõ[~] đầu tiên hay không
            //arrINum[0] = Building.ToUpperInvariant().IndexOf(arrRegex[0]);
            //if (arrINum[0] < 0)
            //    arrINum[0] = Building.ToUpperInvariant().IndexOf(arrRegex[4]);//Số nhà có ngõ[~] đầu tiên hay không

            //Trường hợp gõ ngõ/ngách trước
            if (    Building.ToUpperInvariant().IndexOf(arrRegex[4]) == 0
                ||  Building.ToUpperInvariant().IndexOf(arrRegex[0]) == 0)
            {
                string[] needle = Building.Split(arrRegex[1].ToCharArray());
                int needleCount = needle.Length - 1;
                if (needleCount > 0)//Có dấu / thì là ngách
                {
                    G_Address[0] = string.Format("Ngách {0} ", Building.Substring(arrINum[0] + 1));
                }
                else //ngược lại là ngõ
                {
                    G_Address[0] = string.Format("Ngõ {0} ", Building.Substring(arrINum[0] + 1));
                }
            }
            else
            {
                G_Address[0] = Building + ",";
                string[] arrBuilding = Building.Split(arrRegex[1].ToCharArray());//Số nhà có ngõ, ngách hay không
                if (arrBuilding.Length > 1)
                {
                    if (arrBuilding.Length == 2 && arrBuilding[0].Length > 0 && arrBuilding[1].Length > 0)
                    {
                        //G_Address[0] = string.Format("{0},Ngõ {1}, ", arrBuilding[0], arrBuilding[1]);
                        G_Address[0] = string.Format("{0}, Ngõ {1} ", arrBuilding[0], arrBuilding[1]);
                    }
                    else //if (arrBuilding.Length == 3 && arrBuilding[0].Length > 0 && arrBuilding[1].Length > 0 && arrBuilding[2].Length > 0)
                    {
                        G_Address[0] = string.Format("{0}, Ngách {1} ", arrBuilding[0], Building.Substring(arrBuilding[0].Length + 1, Building.Length - arrBuilding[0].Length - 1));
                    }
                }
            }
        }

		protected virtual bool DefaultCmdKey(ref Message msg, Keys keyData)
		{
			bool val = base.ProcessCmdKey (ref msg, keyData);
			if (this.TriggersEnabled && isComplete == false)
			{
				switch (this.Triggers.OnCommandKey(keyData))
				{
					case TriggerState.ShowAndConsume:
					{
						val = true;
						this.ShowList();
					} break;
					case TriggerState.Show:
					{
						this.ShowList();
					} break;
					case TriggerState.HideAndConsume:
					{
						val = true;
						this.HideList();
					} break;
					case TriggerState.Hide:
					{
						this.HideList();
					} break;
					case TriggerState.SelectAndConsume:
					{
						if (this.popup.Visible == true)
						{
							val = true;
							this.SelectCurrentItem();
						}
					} break;
					case TriggerState.Select:
					{
						if (this.popup.Visible == true)
						{
							this.SelectCurrentItem();
						}
					} break;
					default:
						break;
				}
			}

			return val;
		}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //return DefaultCmdKey(ref msg, keyData);
            switch (keyData)
            {
                case Keys.Up:
                    {
                        if (isComplete == false)
                        {
                            this.Mode = EntryMode.List;
                            if (this.list.SelectedIndex > 0)
                            {
                                this.list.SelectedIndex--;
                            }
                        }
                        return true;
                    } break;
                case Keys.Down:
                    {
                        if (isComplete == false)
                        {
                            this.Mode = EntryMode.List;
                            if (this.list.SelectedIndex < this.list.Items.Count - 1)
                            {
                                this.list.SelectedIndex++;
                            }
                            return true;
                        }
                        else
                        {
                            return DefaultCmdKey(ref msg, keyData);
                        }
                    } break;
                default:
                    {
                        return DefaultCmdKey(ref msg, keyData);
                    } break;
            }
        }

		protected override void OnTextChanged(EventArgs e)
		{            
			base.OnTextChanged (e);            
			if (this.TriggersEnabled)
			{
                string textAutoComplete = getTextAutoComplete_new();

                if (textAutoComplete != "")
                {
                    switch (this.Triggers.OnTextChanged(textAutoComplete))
                    {
                        case TriggerState.Show:
                            {
                                this.ShowList();
                            } break;
                        case TriggerState.Hide:
                            {
                                this.HideList();
                            } break;
                        default:
                            {
                                this.UpdateList();
                            } break;
                    }
                }
                else
                {
                    this.KinhDo = 0;
                    this.ViDo = 0;   
                }
			}
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus (e);

			if (!(this.Focused || this.popup.Focused || this.list.Focused))
			{
				this.HideList();
			}
		}

		protected virtual void SelectCurrentItem()
		{
			if (this.list.SelectedIndex == -1)
            {
                if (this.Text.Length == 0)
                {
                    this.KinhDo = 0;
                    this.ViDo = 0;                    
                }
				return;
			}

			this.Focus();
            IsAuto = true;// nếu gia trị được chọn từ list auto complete
            isComplete = true; // Da chon gia tri
            
            G_TextReturn = G_Address[0] + this.list.SelectedItem.ToString().Trim() + G_Address[1];

            AutoCompleteEntry ItemSelected = (AutoCompleteEntry)this.list.SelectedItem;
            
            this.Text = G_TextReturn;//string.Format("{0} {1}", strNoneAutoComplete.Trim(), this.list.SelectedItem.ToString().Trim()).Trim();
            this.KinhDo = ItemSelected.KinhDo;
            this.ViDo = ItemSelected.ViDo;
            
            if (this.Text.Length > 0)
			{
				this.SelectionStart = this.Text.Length;
			}

			this.HideList();
		}

		protected virtual void ShowList()
		{
            isComplete = false;
			if (this.popup.Visible == false)
			{
				this.list.SelectedIndex = -1;
				this.UpdateList();
				Point p = this.PointToScreen(new Point(0,0));
				p.X += this.PopupOffset.X;
				p.Y += this.Height + this.PopupOffset.Y;
				this.popup.Location = p;
				if (this.list.Items.Count > 0)
				{
					this.popup.Show(this.Parent);
                    if (this.hook == null)
                    {
                        this.hook = new WinHook(this);
                        this.hook.AssignHandle(this.FindForm().Handle);
                    }
					this.Focus();
				}
			} 
			else
			{
				this.UpdateList();
			}
		}

		protected virtual void HideList()
		{
            isComplete = true;
			this.Mode = EntryMode.Text;
			if (this.hook != null)
				this.hook.ReleaseHandle();
			this.hook = null;
			this.popup.Hide();
		}

		protected virtual void UpdateList()
		{
			object selectedItem = this.list.SelectedItem;

			this.list.Items.Clear();
			this.list.Items.AddRange(this.FilterList(this.Items).ToObjectArray());

			if (selectedItem != null &&
				this.list.Items.Contains(selectedItem))
			{
				EntryMode oldMode = this.Mode;
				this.Mode = EntryMode.List;
				this.list.SelectedItem = selectedItem;
				this.Mode = oldMode;
			}

			if (this.list.Items.Count == 0)
			{
				this.HideList();
			} 
			else
			{
				int visItems = this.list.Items.Count;
				if (visItems > 8)
					visItems = 8;

				this.popup.Height = (visItems * this.list.ItemHeight) + 2;
				switch (this.BorderStyle)
				{
					case BorderStyle.FixedSingle:
					{
						this.popup.Height += 2;
					} break;
					case BorderStyle.Fixed3D:
					{
						this.popup.Height += 4;
					} break;
					case BorderStyle.None:
					default:
					{
					} break;
				}
				
				this.popup.Width = this.PopupWidth;

				if (this.list.Items.Count > 0 &&
					this.list.SelectedIndex == -1)
				{
					EntryMode oldMode = this.Mode;
					this.Mode = EntryMode.List;
					this.list.SelectedIndex = 0;
					this.Mode = oldMode;
				}

			}
		}

		protected virtual AutoCompleteEntryCollection FilterList(AutoCompleteEntryCollection list)
		{
            string textAutoComplete = getTextAutoComplete_new();
            AutoCompleteEntryCollection newList = new AutoCompleteEntryCollection();
            if (textAutoComplete != "")
            {                
                foreach (IAutoCompleteEntry entry in list)
                {
                    foreach (string match in entry.MatchStrings)
                    {
                        if (match.ToUpper().StartsWith(textAutoComplete.ToUpper()))
                        {
                            newList.Add(entry);
                            break;
                        }
                    }
                }
            }
			return newList;
		}

		private void List_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Mode != EntryMode.List)
			{
				SelectCurrentItem();
			}
		}

		private void List_MouseDown(object sender, MouseEventArgs e)
		{
			for (int i=0; i<this.list.Items.Count; i++)
			{
				if (this.list.GetItemRectangle(i).Contains(e.X, e.Y))
				{
					this.list.SelectedIndex = i;
					//this.SelectCurrentItem();
				}
			}
			this.HideList();
		}

		private void List_DrawItem(object sender, DrawItemEventArgs e)
		{
			Color bColor = e.BackColor;
			if (e.State == DrawItemState.Selected)
			{
				e.Graphics.FillRectangle(new SolidBrush(this.PopupSelectionBackColor), e.Bounds);
				e.Graphics.DrawString(this.list.Items[e.Index].ToString(), e.Font, new SolidBrush(this.PopupSelectionForeColor), e.Bounds, StringFormat.GenericDefault);
			} 
			else
			{
				e.DrawBackground();
				e.Graphics.DrawString(this.list.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
			}
		}

		private void Popup_Deactivate(object sender, EventArgs e)
		{
			if (!(this.Focused || this.popup.Focused || this.list.Focused))
			{
				this.HideList();
			}
		}

        public void SelectText_Length(int length)
        {
            this.Select(0, length);
            this.SelectionStart = 0;
            this.SelectionLength = length;
        }
	}
}
