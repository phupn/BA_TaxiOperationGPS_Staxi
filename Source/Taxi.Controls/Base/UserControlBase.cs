using System.Linq;
using System.Windows.Forms;
using Taxi.Common.Attributes;
using Taxi.Controls.Base.Forms;
using Taxi.Common.Extender;
namespace Taxi.Controls.Base
{
    public class UserControlBase : UserControl
    { 
        /// <summary>
        /// Thực hiện xử lý action bàn phím
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var rs = ShFormKeyChain.Inst.DoCheckKey(this, ref msg, keyData);
            if (rs) return true;
            var r = this.GetType().GetMethods().Where(p => p.GetAttribute<MethodWithKeyAttribute>() != null && p.GetAttribute<MethodWithKeyAttribute>().Keys==keyData).ToList();
            if (r.Any())
            {
                r.ForEach(p => p.Invoke(this,null));
                return true;
            }
            return  base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
