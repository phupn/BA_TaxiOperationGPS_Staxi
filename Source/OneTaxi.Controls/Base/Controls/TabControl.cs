using OneTaxi.Controls.Base.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaxi.Controls.Base.Controls
{
    public class TabControl : DevExpress.XtraTab.XtraTabControl, IListKeyPress
    {
        [System.ComponentModel.Description("IsClosePageCurrent is close on page curent.")]
        public bool IsClosePageCurrent { get; set; }
        protected override void OnCloseButtonClick(object sender, System.EventArgs e)
        {
            if (IsClosePageCurrent && this.SelectedTabPage != null)
            {
                this.TabPages.Remove(this.SelectedTabPage);
            }
            base.OnCloseButtonClick(sender, e);
        }
        protected override DevExpress.XtraTab.XtraTabPageCollection CreateTabCollection()
        {
            return new TabPageCollection(this);
        }
        public List<IKeyPress> GetList()
        {
            return this.TabPages.Where(p => p.PageVisible).Select(p => (IKeyPress)p).Where(p => p != null).ToList();
        }
    }
    public class TabPageCollection : DevExpress.XtraTab.XtraTabPageCollection
    {
        public TabPageCollection(TabControl tabControl) : base(tabControl) { }
        protected override DevExpress.XtraTab.XtraTabPage CreatePage()
        {
            return new TabPage();
        }
    }
    public class TabPage : DevExpress.XtraTab.XtraTabPage, ILanguage, IKeyPress
    {
        [System.ComponentModel.Description("TagLanguage is the support multi Language.")]
        public string TagLanguage { get; set; }

        public void SetLanguage(string Language)
        {
            this.Text = Language;
        }

        public System.Windows.Forms.Keys KeyCommand { get; set; }

        public void DoKeyCommand(object sender)
        {
            if (TabControl != null)
            {
                this.Focus();
                TabControl.SelectedTabPage = this;
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (TabControl.SelectedTabPage == this)
            {
                return ShFormKeyChain.Inst.DoCheckKey(this, ref msg, keyData) || base.ProcessCmdKey(ref msg, keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
