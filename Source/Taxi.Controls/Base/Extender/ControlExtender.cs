using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Inputs;

namespace Taxi.Controls.Base.Extender
{
    /// <summary>
    /// Các phương thức mở rộng cho Control
    /// </summary>
    public static class ControlExtender
    {
        /// <summary>
        /// Thực hiện Invoke một phương thức
        /// </summary>
        public static void DoInvoke(this Control control, Action action)
        {
            try
            {
                control.Invoke(action);
            }
            catch { }
        }

        /// <summary>
        /// Thực hiện Bind dữ liệu trên Form hoặc User Control
        /// </summary>
        public static void BindShControl(this Control container)
        {
            //  Tìm các control IShControl và thực hiện Bind
            container.FindAllChildrenByType<IShControl>().ToList().ForEach(c => c.Bind());
        }

        /// <summary>
        /// Lấy ra tất cả Controls
        /// </summary>
        public static IEnumerable<T> FindAllChildrenByType<T>(this Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.OfType<T>().Concat<T>(controls.SelectMany<Control, T>(ctrl => FindAllChildrenByType<T>(ctrl)));
        }

        /// <summary>
        /// Thực hiện tìm các IShInput
        /// </summary>
        public static List<IShInput> FindIShInput(this Control control)
        {
            return control.FindAllChildrenByType<Control>().Where(c => c is IShInput && c.Tag!=null && c.Tag.ToString()!=null).Cast<IShInput>().ToList();
        }

        public static Dictionary<string, object> GetValuesInput(this Control control)
        {
            var dic = new Dictionary<string, object>();
            control.FindIShInput().ForEach(ip => dic[(ip as Control).Tag.ToString()] = ip.GetValue());
            return dic;
        }

        /// <summary>
        /// Thực hiện lấy dữ liệu từ các ISHInput và điền vào object t
        /// </summary>
        public static void ParseTo<T>(this Control control, T t, bool hasValidate = true)
        {
            var data = control.GetValuesInput();

           //  Nếu có thực hiện validate
            //if (hasValidate)
            //{
            //    var result = ObjectLibrary.Validate(t, data);
            //    if (!result.IsValid)
            //        throw new ValidatorException(result);
            //}

            t.Parse(data);
        }

        /// <summary>
        /// Thực hiện lấy dữ liệu từ các ISHInput và điền vào object t
        /// </summary>
        public static T ParseTo<T>(this Control control, bool hasValidate = true) where T : new()
        {
            var t = new T();
            control.ParseTo(t, hasValidate);
            return t;
        }

        /// <summary>
        /// Điền giá trị lên Form từ thông tin một Object
        /// </summary>
        public static void Fill(this Control control, object obj)
        {
            // Nếu obj null thì return không thực hiện gì
            if (obj == null) return;

            // Type của obj
            Type type = obj.GetType();

            control.FindIShInput().ForEach(c =>
            {
                // Name
                var pname = (c as Control).Tag.ToString();

                // Lấy ra Property
                var pi = type.GetProperty(pname);

                // Nếu có Property mới Fill
                if (pi != null) c.SetValue(pi.GetValue(obj, null));
            });
        }
        /// <summary>
        /// Kiểm tra dữ liệu trên form có thay đổi không
        /// </summary>
        public static bool CheckDataForm(this Control control)
        {
            return control.FindAllChildrenByType<ITextChange>().Any(p => p.IsChangeText);
        }
        public static int Add(this DataGridViewColumnCollection cols,string columnName, string headerText,string toolTipText)
        {
            var col=cols.Add(columnName,headerText);
            cols[col].ToolTipText = toolTipText;
            return col;
        }
    }
}
