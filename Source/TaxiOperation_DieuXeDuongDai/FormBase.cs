using System.Windows.Forms;
using TaxiOperation_DieuXeDuongDai.Base.Extender;

namespace TaxiOperation_DieuXeDuongDai
{
    public partial class FormBase : Form
    {
        public bool CloseByKeyEsc { get; set; }
        public FormBase()
        {
            InitializeComponent();
        }
        

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (CloseByKeyEsc && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            var rs = this.WithKey(keyData);
            return rs || base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
