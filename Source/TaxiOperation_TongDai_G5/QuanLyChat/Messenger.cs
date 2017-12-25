using System.Windows.Forms;

namespace Taxi.GUI
{
    public partial class Messenger : Form
    {
        public Messenger()
        {
            InitializeComponent();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Messenger_Load(object sender, System.EventArgs e)
        {
            listMessages1.CloseFormMessageEvent += Execute_CloseFormMessageEvent;
        }

        private void Execute_CloseFormMessageEvent()
        {
            this.Close();
        }
    }
}