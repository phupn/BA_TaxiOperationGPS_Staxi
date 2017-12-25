using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using Taxi.Controls.Base.Forms;

namespace Taxi.Controls.Base
{
    public partial class FormRibbon  : RibbonForm
    {
        public RibbonControl ribbon;
        public FormRibbon()
        {
            InitializeComponent();

            ribbon = new RibbonControl();
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { this.ribbon.ExpandCollapseItem });
            this.ribbon.Location = new Point(0, 100);
            this.ribbon.Margin = new Padding(4);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = RibbonControlStyle.Office2010;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new Size(520, 27);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = RibbonQuickAccessToolbarLocation.Hidden;
            this.Icon = Taxi.Controls.Properties.Resources.Staxi_96_ic_launcher1;
            //Icon = Properties.Resources.Taxi;
            this.Controls.Add(this.ribbon);
            this.Ribbon = this.ribbon;
        }
        private bool exitOnEscape = false;

        /// <summary>
        /// Thoát form bằng nút ESC. Mặc định = true
        /// </summary>
        public bool ExitOnEscape
        {
            get { return exitOnEscape; }
            set { exitOnEscape = value; }
        }
        private bool isHideButtonClose = false;
        public bool IsHideButtonClose { get { return isHideButtonClose; } set { isHideButtonClose = value; this.Refresh(); } }

        /// <summary>
        /// Thực hiện xử lý action bàn phím
        /// </summary>
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
