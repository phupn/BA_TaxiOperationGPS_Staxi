using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Taxi.Common.Extender;

namespace Taxi.Controls.Base.Extender
{
    /// <summary>
    /// Phương phức mở rộng cho PopupControlContainer
    /// </summary>
    public static class PopupControlContainerExtender
    {
        /// <summary>
        /// Thực hiện hiển thị PopupControl trên một control nào đó
        /// </summary>
        /// <param name="popup"></param>
        /// <param name="control"></param>
        public static void ShowOnUp(this PopupControlContainer popup, Control control, Action<PopupControlContainer> extend = null)
        {
            // Thiết lập tọa độ
            popup.Location = new Point { X = control.Location.X, Y = control.Location.Y + control.Size.Height + popup.Size.Height };

            // extend
            if (!extend.IsNull()) extend(popup);

            // Tìm các IShInput
            var inputs = popup.FindIShInput();

            // Hiển thị
            popup.Show();

            // Thực hiện Focus
            if (inputs.Count != 0) inputs[0].As<Control>().Focus();
        }
    }
}
