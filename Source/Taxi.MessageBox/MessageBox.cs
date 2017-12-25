using System;
using System.Drawing;
using System.Windows.Forms;

namespace Taxi.MessageBox
{
    public class MessageBoxBA
    {
        #region Fields
        private MessageBoxForm _msgBox = new MessageBoxForm();

        private bool _useSavedResponse = true;
        private string _name = null;
        #endregion

        #region Properties
        internal string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Sets the caption of the message box
        /// </summary>
        public string Caption
        {
            set { _msgBox.Caption = value; }
        }

        /// <summary>
        /// Sets the text of the message box
        /// </summary>
        public string Text
        {
            set { _msgBox.Message = value; }
        }

        /// <summary>
        /// Sets the icon to show in the message box
        /// </summary>
        public Icon CustomIcon
        {
            set { _msgBox.CustomIcon = value; }
        }

        /// <summary>
        /// Sets the icon to show in the message box
        /// </summary>
        public MessageBoxIconBA Icon
        {
            set { _msgBox.StandardIcon = (MessageBoxIconBA)Enum.Parse(typeof(MessageBoxIconBA), value.ToString()); }
        }

        /// <summary>
        /// Sets the font for the text of the message box
        /// </summary>
        public Font Font
        {
            set { _msgBox.Font = value; }
        }

        /// <summary>
        /// Sets or Gets the ability of the  user to save his/her response
        /// </summary>
        public bool AllowSaveResponse
        {
            get { return _msgBox.AllowSaveResponse; }
            set { _msgBox.AllowSaveResponse = value; }
        }

        /// <summary>
        /// Sets the text to show to the user when saving his/her response
        /// </summary>
        public string SaveResponseText
        {
            set { _msgBox.SaveResponseText = value; }
        }

        /// <summary>
        /// Sets or Gets wether the saved response if available should be used
        /// </summary>
        public bool UseSavedResponse
        {
            get { return _useSavedResponse; }
            set { _useSavedResponse = value; }
        }

        /// <summary>
        /// Sets or Gets wether an alert sound is played while showing the message box.
        /// The sound played depends on the the Icon selected for the message box
        /// </summary>
        public bool PlayAlsertSound
        {
            get { return _msgBox.PlayAlertSound; }
            set { _msgBox.PlayAlertSound = value; }
        }

        /// <summary>
        /// Sets or Gets the time in milliseconds for which the message box is displayed.
        /// </summary>
        public int Timeout
        {
            get { return _msgBox.Timeout; }
            set { _msgBox.Timeout = value; }
        }

        /// <summary>
        /// Controls the result that will be returned when the message box times out.
        /// </summary>
        public TimeoutResult TimeoutResult
        {
            get { return _msgBox.TimeoutResult; }
            set { _msgBox.TimeoutResult = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Shows the message box
        /// </summary>        
        public string Show()
        {            
            IWin32Window owner = null;
            return this.Show(owner);
        }

        /// <summary>
        /// Shows the messsage box with the specified owner
        /// </summary>
        public string Show(IWin32Window owner)
        {
            MessageBoxManager.GetMessageButton(); 
            _msgBox = new MessageBoxForm();
            if (_useSavedResponse && this.Name != null)
            {
                string savedResponse = MessageBoxManager.GetSavedResponse(this);
                if (savedResponse != null)
                    return savedResponse;
            }
            _msgBox.ClearButtons(); 
            this.AddButton(MessageBoxButtonsBA.OK);
            this.Caption = string.Empty;
            this.Text = string.Empty;
            this.Icon = MessageBoxIconBA.Information;
            if (owner == null)
            {
                _msgBox.ShowDialog();
            }
            else
            {
                _msgBox.ShowDialog(owner);
            }

            if (this.Name != null)
            {
                if (_msgBox.AllowSaveResponse && _msgBox.SaveResponse)
                    MessageBoxManager.SetSavedResponse(this, _msgBox.Result);
                else
                    MessageBoxManager.ResetSavedResponse(this.Name);
            }
            else
            {
                Dispose();
            }

            return _msgBox.Result;
        }
        //Tuyenlv

        public string Show(string text)
        {            
            IWin32Window owner = null;
            return this.Show(owner, text);
        }


        public string Show(IWin32Window owner, string text)
        {
            MessageBoxManager.GetMessageButton(); 
            _msgBox = new MessageBoxForm();
            if (_useSavedResponse && this.Name != null)
            {
                string savedResponse = MessageBoxManager.GetSavedResponse(this);
                if (savedResponse != null)
                    return savedResponse;
            }
            _msgBox.ClearButtons(); 
            this.AddButton(MessageBoxButtonsBA.OK);
            this.Caption = string.Empty;
            this.Text = text;
            this.Icon = MessageBoxIconBA.Information;
            if (owner == null)
            {
                _msgBox.ShowDialog();
            }
            else
            {
                _msgBox.ShowDialog(owner);
            }

            if (this.Name != null)
            {
                if (_msgBox.AllowSaveResponse && _msgBox.SaveResponse)
                    MessageBoxManager.SetSavedResponse(this, _msgBox.Result);
                else
                    MessageBoxManager.ResetSavedResponse(this.Name);
            }
            else
            {
                Dispose();
            }

            return _msgBox.Result;
        }

        public string Show(string text, string caption)
        {
            return Show(null, text, caption);
        }

        public string Show(IWin32Window owner, string text, string caption)
        {
            MessageBoxManager.GetMessageButton(); 
            _msgBox = new MessageBoxForm();
            if (_useSavedResponse && this.Name != null)
            {
                string savedResponse = MessageBoxManager.GetSavedResponse(this);
                if (savedResponse != null)
                    return savedResponse;
            }
            _msgBox.ClearButtons(); 
            this.AddButton(MessageBoxButtonsBA.OK);
            this.Caption = caption;
            this.Text = text;
            this.Icon = MessageBoxIconBA.Information;
            if (owner == null)
            {
                _msgBox.ShowDialog();
            }
            else
            {
                _msgBox.ShowDialog(owner);
            }

            if (this.Name != null)
            {
                if (_msgBox.AllowSaveResponse && _msgBox.SaveResponse)
                    MessageBoxManager.SetSavedResponse(this, _msgBox.Result);
                else
                    MessageBoxManager.ResetSavedResponse(this.Name);
            }
            else
            {
                Dispose();
            }

            return _msgBox.Result;
        }

        public string Show(string text, string caption, MessageBoxButtonsBA buttons)
        {
            return Show(null, text, caption, buttons);
        }
        public string Show(IWin32Window owner, string text, string caption, MessageBoxButtonsBA buttons)
        {
            MessageBoxManager.GetMessageButton(); 
            _msgBox = new MessageBoxForm();
            if (_useSavedResponse && this.Name != null)
            {
                string savedResponse = MessageBoxManager.GetSavedResponse(this);
                if (savedResponse != null)
                    return savedResponse;
            }
            _msgBox.ClearButtons(); 
            this.AddButtons(buttons);
            this.Caption = caption;
            this.Text = text;
            this.Icon = MessageBoxIconBA.Information;
            if (owner == null)
            {
                _msgBox.ShowDialog();
            }
            else
            {
                _msgBox.ShowDialog(owner);
            }

            if (this.Name != null)
            {
                if (_msgBox.AllowSaveResponse && _msgBox.SaveResponse)
                    MessageBoxManager.SetSavedResponse(this, _msgBox.Result);
                else
                    MessageBoxManager.ResetSavedResponse(this.Name);
            }
            else
            {
                Dispose();
            }

            return _msgBox.Result;
        }

        public string Show(string text, string caption, MessageBoxButtonsBA buttons, MessageBoxIconBA icon)
        {
            return Show(null, text, caption, buttons, icon);
        }

        public string Show(IWin32Window owner, string text, string caption, MessageBoxButtonsBA buttons, MessageBoxIconBA icon)
        {
            MessageBoxManager.GetMessageButton(); 
            _msgBox = new MessageBoxForm();
            try
            {
                if (_useSavedResponse && this.Name != null)
                {
                    string savedResponse = MessageBoxManager.GetSavedResponse(this);
                    if (savedResponse != null)
                        return savedResponse;
                }
                _msgBox.ClearButtons();
                this.AddButtons(buttons);
                this.Caption = caption;
                this.Text = text;
                this.Icon = icon;
                if (owner == null)
                {
                    _msgBox.ShowDialog();
                }
                else
                {
                    _msgBox.ShowDialog(owner);
                }

                if (this.Name != null)
                {
                    if (_msgBox.AllowSaveResponse && _msgBox.SaveResponse)
                        MessageBoxManager.SetSavedResponse(this, _msgBox.Result);
                    else
                        MessageBoxManager.ResetSavedResponse(this.Name);
                }
                else
                {
                    Dispose();
                }
            }
            catch 
            {

            }

            return _msgBox.Result;
        }

        /// <summary>
        /// Add a custom button to the message box Tuyenlv
        /// </summary>

        public void AddButton(MessageBoxButton button)
        {
            if (button == null)
                throw new ArgumentNullException("button", "A null button cannot be added");

            _msgBox.Buttons.Add(button);
            
            if (button.IsCancelButton)
            {
                _msgBox.CustomCancelButton = button;
            }
        }

        /// <summary>
        /// Add a custom button to the message box
        /// </summary>
        public void AddButton(string text, string val)
        {
            MessageBoxButton button = new MessageBoxButton();
            button.Text = text;
            button.Value = val;

            AddButton(button);
        }

        /// <summary>
        /// Add a standard button to the message box
        /// </summary>
        public void AddButton(MessageBoxButtonsBA button)
        {
            string buttonText = MessageBoxManager.GetLocalizedString(button.ToString());
            if (buttonText == null)
            {
                buttonText = button.ToString();
            }

            string buttonVal = button.ToString();

            MessageBoxButton btn = new MessageBoxButton();
            btn.Text = buttonText;
            btn.Value = buttonVal;

            if (button == MessageBoxButtonsBA.Cancel)
            {
                btn.IsCancelButton = true;
            }

            AddButton(btn);
        }

        /// <summary>
        /// Add standard buttons to the message box.
        /// </summary>
        public void AddButtons(MessageBoxButtonsBA buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtonsBA.OK:
                    AddButton(MessageBoxButtonsBA.OK);
                    break;

                case MessageBoxButtonsBA.Abort:
                    AddButton(MessageBoxButtonsBA.Abort);
                    break;

                case MessageBoxButtonsBA.Cancel:
                    AddButton(MessageBoxButtonsBA.Cancel);
                    break;

                case MessageBoxButtonsBA.Ignore:
                    AddButton(MessageBoxButtonsBA.Ignore);
                    break;

                case MessageBoxButtonsBA.No:
                    AddButton(MessageBoxButtonsBA.No);
                    break;

                case MessageBoxButtonsBA.Retry:
                    AddButton(MessageBoxButtonsBA.Retry);
                    break;

                case MessageBoxButtonsBA.Yes:
                    AddButton(MessageBoxButtonsBA.Yes);
                    break;

                case MessageBoxButtonsBA.AbortRetryIgnore:
                    AddButton(MessageBoxButtonsBA.Abort);
                    AddButton(MessageBoxButtonsBA.Retry);
                    AddButton(MessageBoxButtonsBA.Ignore);
                    break;

                case MessageBoxButtonsBA.OKCancel:
                    AddButton(MessageBoxButtonsBA.OK);
                    AddButton(MessageBoxButtonsBA.Cancel);
                    break;

                case MessageBoxButtonsBA.RetryCancel:
                    AddButton(MessageBoxButtonsBA.Retry);
                    AddButton(MessageBoxButtonsBA.Cancel);
                    break;

                case MessageBoxButtonsBA.YesNo:
                    AddButton(MessageBoxButtonsBA.Yes);
                    AddButton(MessageBoxButtonsBA.No);
                    break;

                case MessageBoxButtonsBA.YesNoCancel:
                    AddButton(MessageBoxButtonsBA.Yes);
                    AddButton(MessageBoxButtonsBA.No);
                    AddButton(MessageBoxButtonsBA.Cancel);
                    break;
            }
        }
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor is internal because this can only be created by MBManager
        /// </summary>
        public MessageBoxBA()
        {
            this.Name = "EFilingMessageBox";
            _msgBox.KeyDown += _msgBox_KeyDown;
        }

        private void _msgBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                _msgBox.Close();
            }
        }

        /// <summary>
        /// Called by the manager when it is disposed
        /// </summary>
        internal void Dispose()
        {
            if (_msgBox != null)
            {
                _msgBox.Dispose();
            }
        }

        #endregion
    }
}
