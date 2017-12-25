using System.Windows.Forms;
using Taxi.Controls.Base.Forms;
using System.Linq;
using System.ComponentModel;

namespace Taxi.Controls.Base
{
    public partial class FormBase : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        private bool _exitOnEscape = true;
        private bool _isHideButtonClose = false;

        public bool IsDesign { get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; } }
        public FormBase()
        {
            InitializeComponent();
            this.Icon = Taxi.Controls.Properties.Resources.Staxi_96_ic_launcher1;
        }
        
        /// <summary>
        /// Thoát form bằng nút ESC. Mặc định = true
        /// </summary>
        public bool ExitOnEscape
        {
            get { return _exitOnEscape; }
            set { _exitOnEscape = value; }
        }
        
        public bool IsHideButtonClose { get { return _isHideButtonClose; } set { _isHideButtonClose = value; this.Refresh(); } }

        protected override CreateParams CreateParams
        {
            get
            {
                if (!_isHideButtonClose)
                    return base.CreateParams;
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ExitOnEscape && keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            return ShFormKeyChain.Inst.DoCheckKey(this, ref msg, keyData) || base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
