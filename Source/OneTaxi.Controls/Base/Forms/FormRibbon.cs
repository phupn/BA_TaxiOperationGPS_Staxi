using System;
using System.Windows.Forms;

namespace OneTaxi.Controls.Base.Forms
{
    public partial class FormRibbon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormRibbon()
        {
            InitializeComponent();
        }
          private bool exitOnEscape = false;

        /// <summary>
          /// Thoát form bằng nút ESC. Mặc định = false
        /// </summary>
        public bool ExitOnEscape
        {
            get { return exitOnEscape; }
            set { exitOnEscape = value; }
        }
        /// <summary
        /// Thực hiện xử lý action bàn phím
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ExitOnEscape && keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return ShFormKeyChain.Inst.DoCheckKey(this, ref msg, keyData)|| base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
