using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars.Alerter;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Inputs;
using Taxi.MessageBox;
using MessageBoxButtons = Taxi.MessageBox.MessageBoxButtonsBA;
using MessageBoxIcon = Taxi.MessageBox.MessageBoxIconBA;

namespace Taxi.Controls.Base.Extender
{
    /// <summary>
    /// Phương thức mở rộng cho ContainerControl
    /// </summary>
    public static class ContainerControlExtender
    {
        /// <summary>
        /// Thực hiện Alert
        /// </summary>
        public static void AlertInfo(this ContainerControl frm, string message)
        {
            // Tạo thông báo
            AlertInfo alertInfo = new AlertInfo("Thông báo", message);
            
            // Tạo control chứa thông báo
            AlertControl control = new AlertControl
            {
                FormLocation = AlertFormLocation.BottomRight
            };
            control.Show(null, alertInfo);
        }

        public static void Alert(this ContainerControl frm, string message)
        {
            new MessageBoxBA().Show(message, "Thông báo");
        }

        /// <summary>
        /// Confirm
        /// </summary>
        public static bool Confirm(this ContainerControl frm, string message)
        {
            var rs = new MessageBoxBA().Show(message, "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            return rs.ToLower() == MessageBoxResult.Ok.ToLower();
        }

        /// <summary>
        /// Thực hiện KeyPress
        /// </summary>
        public static bool SetEventKeypress(this Control frm, ref Message msg, Keys keyData)
        {
            // Lấy ra các control là IKeyPress
            var controls = frm.FindAllChildrenByType<IShKeyPress>();

            // Lấy ra Controls cần mà có Key thỏa mãn
            var ik =
                controls.Cast<Control>()
                    .Where(c => c.Visible)
                    .Cast<IShKeyPress>().FirstOrDefault(i => i.KeyCommand == keyData);
            
            // Nếu có thì thực hiện Event đã được thiết lập
            if (ik.IsNotNull()) { ik.DoKeyCommand(ik); }
            else
            {
                 ik = frm.FindAllChildrenByType<IListKeyPress>().SelectMany(p => p.GetList()).FirstOrDefault(i => i.KeyCommand == keyData);
                 if (ik.IsNotNull()) { ik.DoKeyCommand(ik); }
            }

            return ik.IsNotNull();
        }
    }
}
