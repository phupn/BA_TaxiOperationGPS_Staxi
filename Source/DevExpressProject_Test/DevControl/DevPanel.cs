using System.ComponentModel;

namespace DevExpressProject_Test
{
    public partial class DevPanel : DevExpress.XtraEditors.PanelControl
    {
        public DevPanel()
        {
            InitializeComponent();
        }

        public DevPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
