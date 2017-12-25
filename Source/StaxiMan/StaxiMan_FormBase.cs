using System.Windows.Forms;
using Taxi.Controls.Base.Forms;

namespace StaxiMan
{
    public partial class StaxiMan_FormBase : Form
    {
        private bool _exitOnEscape = true;
        /// <summary>
        /// Thoát form bằng nút ESC. Mặc định = true
        /// </summary>
        public bool ExitOnEscape
        {
            get { return _exitOnEscape; }
            set { _exitOnEscape = value; }
        }
        public StaxiMan_FormBase()
        {
            InitializeComponent();
            Icon = Properties.Resources.Staxi_96_ic_launcher;
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
