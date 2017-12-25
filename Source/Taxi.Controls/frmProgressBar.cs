using System;
using System.Windows.Forms;

namespace Taxi.Controls
{
	public partial class frmProgressBar : Form
	{
        private bool _cancel = false;
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

		public bool Cancel
		{
			get { return _cancel; }
		}

		public frmProgressBar()
		{
			InitializeComponent();
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.MarqueeAnimationSpeed = 40;
		}

		private void fmProgress_FormClosing( object sender, FormClosingEventArgs e )
		{
			_cancel = true;
			e.Cancel = true;
		}

        private void bnCancel_Click(object sender, EventArgs e)
        {
            _cancel = true;
        }
	}
}