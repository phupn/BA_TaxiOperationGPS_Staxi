using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Taxi.Controls.Base.Inputs
{
    public class AutoCompleteTextbox : PlaceholderTextBox
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        public static void PressKey(Keys key, bool up)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            if (up)
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            else
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            }
        }

        public string NullText{get; set; }
    

        protected virtual void OnSelectItem(DataRow row) { }
        #region Fields

        public delegate void SelectAutoComplete(DataRow row);

        public event SelectAutoComplete EventSelectAutoComplete;
        // the ListBox used for suggestions
        private ListBox listBox = new ListBox();
        // string to remember a former input
        private string oldText;

        // a Panel for displaying
        private Panel panel;

        public override Font Font
        {
            get
            {
                return listBox.Font;
            }
            set
            {
                listBox.Font = value;
            }
        }
        [DefaultValue(7)]
        public int Rowshow { get; set; }
        public bool EnterMoveNextControl { get; set; }
        #endregion Fields

        #region Constructors

        // the constructor
        public AutoCompleteTextbox()
            : base()
        {
            Rowshow = 7;
            // assigning some default values
            // minimum characters to be typed before suggestions are displayed
            this.MinTypedCharacters = 2;
            // not cases sensitive
            this.CaseSensitive = false;
            // the list for our suggestions database
            // the sample dictionary en-EN.dic is stored here when form1 is loaded (see form1.Load event)
            this.AutoCompleteList = new DataTable();

            // the listbox used for suggestions
           
            this.listBox.Name = "SuggestionListBox";
            this.listBox.Font = this.Font;
            this.listBox.Visible = true;
            this.listBox.ItemHeight = 20;
            // the panel to hold the listbox later on
            this.panel = new Panel();
            this.panel.Visible = false;
            this.panel.Font = this.Font;
            // to be able to fit to changing sizes of the parent form
            this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            // initialize with minimum size to avoid overlaping or flickering problems
            this.panel.ClientSize = new Size(1, 1);
            this.panel.Name = "SuggestionPanel";
            this.panel.Padding = new Padding(0, 0, 0, 0);
            this.panel.Margin = new Padding(0, 0, 0, 0);
            this.panel.BackColor = Color.Transparent;
            this.panel.ForeColor = Color.Transparent;
            this.panel.Text = "";
            this.panel.PerformLayout();
            // add the listbox to the panel if not already done
            if (!panel.Controls.Contains(listBox))
            {
                this.panel.Controls.Add(listBox);
            }

            // make the listbox fill the panel
            this.listBox.Dock = DockStyle.Fill;
            // only one itme can be selected from the listbox
            this.listBox.SelectionMode = SelectionMode.One;
            // the events to be fired if an item is selected
            this.listBox.KeyDown += new KeyEventHandler(listBox_KeyDown);
            this.listBox.MouseClick += new MouseEventHandler(listBox_MouseClick);
            this.listBox.MouseDoubleClick += new MouseEventHandler(listBox_MouseDoubleClick);

            #region Excursus: ArrayList vs. List<string>

            // surpringly ArrayList is a little faster than List<string>
            // to use ArrayList instead, replace every 'List<string>' with 'ArrayList'
            // i will used List<string> cause it's generic type

            #endregion Excursus: ArrayList vs. List<string>

            // the list of suggestions actually displayed in the listbox
            // a subset of AutoCompleteList according to the typed in keyphrase
            this.CurrentAutoCompleteList = new DataTable();

            #region Excursus: DataSource vs. AddRange

            // using DataSource is faster than adding items (see
            // uncommented listBox.Items.AddRange method below)

            #endregion Excursus: DataSource vs. AddRange

            // Bind the CurrentAutoCompleteList as DataSource to the listbox
            listBox.DataSource = CurrentAutoCompleteList;

            // set the input to remember, which is empty so far
            oldText = this.Text;
            this.TextChanged += AutoCompleteTextbox_TextChanged;
        }

       

        void AutoCompleteTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text) || this.Text.Equals(this.PlaceholderText))
            {
                DataRowSelect = null;
                OnSelectItem(DataRowSelect);
                if (EventSelectAutoComplete != null)
                {
                    EventSelectAutoComplete(DataRowSelect);
                }
            }
          
        }

        #endregion Constructors

        #region Properties

        // the list for our suggestions database
        public DataTable AutoCompleteList { get; set; }

        // case sensitivity
        public bool CaseSensitive { get; set; }

        // minimum characters to be typed before suggestions are displayed
        public int MinTypedCharacters { get; set; }

        // the index selected in the listbox
        // maybe of intrest for other classes
        public int SelectedIndex
        {
            get { return listBox.SelectedIndex; }
            set
            {
                // musn't be null
                if (listBox.Items.Count != 0)
                {
                    listBox.SelectedIndex = value;
                }
            }
        }

        // the actual list of currently displayed suggestions
        private DataTable CurrentAutoCompleteList { set; get; }

        // the parent Form of this control
        private Form ParentForm
        {
            get
            {
                if (this.Parent == null) return null;
                return this.Parent.FindForm();
            }
        }

        #endregion Properties

        #region Methods

        // hides the listbox
        public void HideSuggestionListBox()
        {
            if ((ParentForm != null))
            {
                // hiding the panel also hides the listbox
                panel.Hide();
                // now remove it from the ParentForm (Form1 in this example)
                if (this.ParentForm.Controls.Contains(panel))
                {
                    this.ParentForm.Controls.Remove(panel);
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs args)
        {
            // if user presses key.up
            if ((args.KeyCode == Keys.Up))
            {
                // move the selection in listbox one up
                MoveSelectionInListBox((SelectedIndex - 1));
                // work is done
                args.Handled = true;
            }
            // on key.down
            else if ((args.KeyCode == Keys.Down))
            {
                //move one down
                MoveSelectionInListBox((SelectedIndex + 1));
                args.Handled = true;
            }
            else if ((args.KeyCode == Keys.PageUp))
            {
                //move 10 up
                MoveSelectionInListBox((SelectedIndex - this.Rowshow));
                args.Handled = true;
            }
            else if ((args.KeyCode == Keys.PageDown))
            {
                //move 10 down
                MoveSelectionInListBox((SelectedIndex + this.Rowshow));
                args.Handled = true;
            }
            // on enter
            else if ((args.KeyCode == Keys.Enter))
            {
                if (EnterMoveNextControl && !panel.Visible)
                {
                    //var control = this.GetNextControl(this, true);
                    //if (control != null) this.SelectNextControl(control, true, true, true, true);
                    PressKey(Keys.Tab, false);
                    //SendKeys.Send("{TAB}");
                  //  args.Handled = true;
                }
                else
                    {
                        if (panel.Visible)
                        {// select the item in the ListBox
                            SelectItem();
                            args.Handled = true;

                        }
                        
                    }
                
            }
            else
            {
                // work is not done, maybe the base class will process the event, so call it...
                base.OnKeyDown(args);
            }
        }

        // if the user leaves the TextBox, the ListBox and the panel ist hidden
        protected override void OnLostFocus(EventArgs e)
        {
            if (!panel.ContainsFocus)
            {
                // call the baseclass event
                base.OnLostFocus(e);
                // then hide the stuff
                this.HideSuggestionListBox();
            }
        }

        // if the input changes, call ShowSuggests()
        protected override void OnTextChanged(EventArgs args)
        {
            // avoids crashing the designer
            if (!this.DesignMode)
                ShowSuggests();
            base.OnTextChanged(args);
            // remember input
            oldText = this.Text;
        }

        // event for any key pressed in the ListBox
        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            // on enter
            if (e.KeyCode == Keys.Enter)
            {
                // select the current item
                SelectItem();
                // work done
                e.Handled = true;
            }
        }

        // event for MouseClick in the ListBox
        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            // select the current item
            SelectItem();
        }

        // event for DoubleClick in the ListBox
        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // select the current item
            SelectItem();
        }

        private void MoveSelectionInListBox(int Index)
        {
            // beginning of list
            if (Index <= -1)
            {
                this.SelectedIndex = 0;
            }
            else
            // end of liste
                if (Index > (listBox.Items.Count - 1))
                {
                    SelectedIndex = (listBox.Items.Count - 1);
                }
                else
                // somewhere in the middle
                {
                    SelectedIndex = Index;
                }
        }

        // selects the current item
        private bool SelectItem()
        {
            DataRowSelect = null;// if the ListBox is not empty
            if (((this.listBox.Items.Count > 0) && (this.SelectedIndex > -1)))
            {
                // set the Text of the TextBox to the selected item of the ListBox
                DataRowSelect = (this.listBox.SelectedItem as DataRowView).Row;
                if (DataRowSelect != null)
                {
                    try
                    {
                        this.Text = DataRowSelect[this.DisplayMember].ToString();
                        this.Value = DataRowSelect[this.ValueMember];
                    }
                    catch
                    {
                    }
                }

                if (EventSelectAutoComplete != null)
                {
                    EventSelectAutoComplete(DataRowSelect);
                }
                // and hide the ListBox
                this.HideSuggestionListBox();

            }
            OnSelectItem(DataRowSelect);
            IsForceChangeText = false;
            return true;
        }

        // shows the suggestions in ListBox beneath the TextBox
        // and fitting it into the ParentForm
        private void ShowSuggests()
        {
            // show only if MinTypedCharacters have been typed
            if (this.Text.Length >= MinTypedCharacters)
            {
                if (panel == null) return;
                // prevent overlapping problems with other controls
                // while loading data there is nothing to draw, so suspend layout
                panel.SuspendLayout();
                // user is typing forward, char has been added at the end of the former input
                if ((this.Text.Length > 0) && (this.oldText == this.Text.Substring(0, this.Text.Length - 1)))
                {
                    //handle forward typing with refresh
                    UpdateCurrentAutoCompleteList();
                }
                // user is typing backward - char bas been removed
                else if ((this.oldText.Length > 0) && (this.Text == this.oldText.Substring(0, this.oldText.Length - 1)))
                {
                    //handle backward typing with refresh
                    UpdateCurrentAutoCompleteList();
                }
                // something within has changed
                else
                {
                    // handle other things like corrections in the middle of the input, clipboard pastes, etc. with refresh
                    UpdateCurrentAutoCompleteList();
                }

                if (((CurrentAutoCompleteList != null) && CurrentAutoCompleteList.Rows.Count > 0))
                {
                    // finally show Panel and ListBox
                    // (but after refresh to prevent drawing empty rectangles)
                    panel.Show();
                    panel.Top = Get(this).Y+this.Height;
                    // at the top of all controls
                    panel.BringToFront();
                    // then give the focuse back to the TextBox (this control)
                    this.Focus();
                }
                // or hide if no results
                else
                {
                    this.HideSuggestionListBox();
                }
                // prevent overlapping problems with other controls
                panel.ResumeLayout(true);
            }
            // hide if typed chars <= MinCharsTyped
            else
            {
                this.HideSuggestionListBox();
            }
        }
        private Point Get(Control control)
        {
            Point locationOnForm = control.FindForm().PointToClient(
    control.Parent.PointToScreen(control.Location));
            return locationOnForm;
        }

        // This is a timecritical part
        // Fills/ refreshed the CurrentAutoCompleteList with appropreate candidates
        private void UpdateCurrentAutoCompleteList()
        {
            // the list of suggestions has to be refreshed so clear it
            CurrentAutoCompleteList = AutoCompleteList.Copy();
            CurrentAutoCompleteList.Rows.Clear();
            // an find appropreate candidates for the new CurrentAutoCompleteList in AutoCompleteList
            foreach (DataRow row in AutoCompleteList.Rows)
            {
                if (SearchText(row, this.Text))
                {
                    CurrentAutoCompleteList.ImportRow(row);
                }
            }

            #region Excursus: Performance measuring of Linq queries

            // This is a simple example of speedmeasurement for Linq querries
            /*
            CurrentAutoCompleteList.Clear();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // using Linq query seems to be slower (twice as slow)
            var query =
                from expression in this.AutoCompleteList
                where expression.ToLower().Contains(this.Text.ToLower())
                select expression;
            foreach (string searchTerm in query)
            {
                CurrentAutoCompleteList.Add(searchTerm);
            }
            stopWatch.Stop();
            // method (see below) for printing the performance values to console
            PrintStopwatch(stopWatch, "Linq - Contains");
            */

            #endregion Excursus: Performance measuring of Linq queries

            // countinue to update the ListBox - the visual part
            UpdateListBoxItems();
        }

        // This is the most timecritical part, adding items to the ListBox
        private void UpdateListBoxItems()
        {
            #region Excursus: DataSource vs. AddRange

            /*
                    // This part is not used due to 'listBox.DataSource' approach (see constructor)
                    // left for comparison, delete for productive use
                    listBox.BeginUpdate();
                    listBox.Items.Clear();
                    //Fills the ListBox
                    listBox.Items.AddRange(this.CurrentAutoCompleteList.ToArray());
                    listBox.EndUpdate();
                    // to use this method remove the following
                    // "((CurrencyManager)listBox.BindingContext[CurrentAutoCompleteList]).Refresh();" line and
                    // "listBox.DataSource = CurrentAutoCompleteList;" line from the constructor
                    */

            #endregion Excursus: DataSource vs. AddRange

            // if there is a ParentForm
            if ((ParentForm != null))
            {
                // get its width
                panel.Width = this.Width;
                // calculate the remeining height beneath the TextBox
                panel.Height =(listBox.ItemHeight+1)*Rowshow;// (this.ParentForm.ClientSize.Height - this.Height - this.Location.Y)/2;
                // and the Location to use
                panel.Location = this.Location + new Size(0, this.Height);
                // Panel and ListBox have to be added to ParentForm.Controls before calling BingingContext
                if (!this.ParentForm.Controls.Contains(panel))
                {
                    // add the Panel and ListBox to the PartenForm
                    this.ParentForm.Controls.Add(panel);
                }
                // Update the listBox manually - List<string> dosn't support change events
                // this is the DataSource approche, this is a bit tricky and may cause conflicts,
                // so in case fall back to AddRange approache (see Excursus)
                listBox.DataSource = CurrentAutoCompleteList;
                listBox.Refresh();// ((CurrencyManager) listBox.BindingContext[CurrentAutoCompleteList]).Refresh();
            }
        }

        #endregion Methods

        #region Other

        /*
        // only needed for performance measuring - delete for productional use
        private void PrintStopwatch(Stopwatch stopWatch, string comment)
        {
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00},{3:000}s \t {4}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds, comment);
            Console.WriteLine("RunTime " + elapsedTime);
        }
        */

        #endregion Other

        #region Viêt thêm

        public string ValueMember
        {
            get { return listBox.ValueMember; }
            set { listBox.ValueMember = value; }
        }

        public string DisplayMember
        {
            get { return listBox.DisplayMember; }
            set { listBox.DisplayMember = value; }
        }
        public object Value { get; set; }
        public DataRow DataRowSelect { get; set; }

        /// <summary>
        /// thực hiện có trùng khớp không
        /// </summary>
        /// <param name="row"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public virtual bool SearchText(DataRow row, string txt)
        {
            string text = row[DisplayMember] == null ? string.Empty : row[DisplayMember].ToString();
            string val = row[ValueMember] == null ? string.Empty : row[ValueMember].ToString();
            if (text.Trim() != string.Empty)
                return SoSanhChu(text, txt) || SoSanhKyTuDau(text, txt) || SoSanhTiengVietKhongDau(text, txt);
            if (val.Trim() != string.Empty)
                return SoSanhChu(val, txt) || SoSanhKyTuDau(val, txt) || SoSanhTiengVietKhongDau(val, txt);
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="txtSearch"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public virtual bool SoSanhTiengVietKhongDau(string txtSearch, string txt)
        {
            string txtSearchKhongdau = ConvertVN(txtSearch);
            string txtKhongDau = ConvertVN(txt);
            return SoSanhChu(txtSearchKhongdau, txtKhongDau) || SoSanhKyTuDau(txtSearchKhongdau, txtKhongDau);
        }
        /// <summary>
        /// So sanh chữ không phân biệt
        /// </summary>
        /// <param name="txtSearch"></param>
        /// <param name="txt2"></param>
        /// <returns></returns>
        public virtual bool SoSanhChu(string txtSearch, string txt)
        {
            return txtSearch.IndexOf(txt, StringComparison.Ordinal)>-1 ||txtSearch.ToLower().IndexOf(txt.ToLower(), StringComparison.Ordinal)>-1;
        }
        /// <summary>
        /// Lấy ký tự đầu để so sánh
        /// </summary>
        /// <param name="txtSearch"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public virtual bool SoSanhKyTuDau(string txtSearch, string txt)
        {
            string kyTuDau =txtSearch.Split(' ',',').ToList()
                    .Select(t => t.Trim())
                    .Where(p => !string.IsNullOrEmpty(p) && p.Length > 0).Select(p => p.Substring(0, 1))
                    .Aggregate((current, next) => current + next);
           return SoSanhChu(kyTuDau, txt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chucodau"></param>
        /// <returns></returns>
        public static string ConvertVN(string chucodau)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            char[] arrChar = FindText.ToCharArray();
            while ((index = chucodau.IndexOfAny(arrChar)) != -1)
            {
                int index2 = FindText.IndexOf(chucodau[index]);
                chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
            }
            return chucodau;
        } 
    #endregion

    }
}