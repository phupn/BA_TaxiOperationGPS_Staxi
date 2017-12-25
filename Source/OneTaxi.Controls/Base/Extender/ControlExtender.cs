using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Staxi.Utils.Extender;

namespace OneTaxi.Controls.Base.Extender
{
    /// <summary>
    /// Các phương thức mở rộng cho Control
    /// </summary>
    public static class ControlExtender
    {
        /// <summary>
        /// Thực hiện Invoke một phương thức
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
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
        /// <param name="container"></param>
        public static void BindShControl(this Control container)
        {
            //  Tìm các control IBindControl và thực hiện Bind
            container.FindAllChildrenByType<IBindControl>().ToList().ForEach(c => c.Bind());
        }

        /// <summary>
        /// Lấy ra tất cả Controls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindAllChildrenByType<T>(this Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.OfType<T>().Concat<T>(controls.SelectMany<Control, T>(ctrl => FindAllChildrenByType<T>(ctrl)));
        }

        /// <summary>
        /// Thực hiện tìm các IShInput
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static List<IInput> FindIShInput(this Control control)
        {
            return control.FindAllChildrenByType<Control>().Where(c => c is IInput && c.Tag != null && c.Tag.ToString() != null).Cast<IInput>().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, object> GetValuesInput(this Control control)
        {
            var dic = new Dictionary<string, object>();
            control.FindIShInput().ForEach(ip => dic[(ip as Control).Tag.ToString()] = ip.GetValue());
            return dic;
        }

        /// <summary>
        /// Thực hiện lấy dữ liệu từ các ISHInput và điền vào object t
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="hasValidate"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="hasValidate"></param>
        /// <returns></returns>
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
        /// <param name="control"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Thực hiện KeyPress
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        public static bool SetEventKeypress(this Control frm, ref Message msg, Keys keyData)
        {
            // Lấy ra các control là IKeyPress
            var controls = frm.FindAllChildrenByType<IKeyPress>();

            // Lấy ra Controls cần mà có Key thỏa mãn
            var ik =
                controls.Cast<Control>()
                    .Where(c => c.Visible)
                    .Cast<IKeyPress>().FirstOrDefault(i => i.KeyCommand == keyData);

            // Nếu có thì thực hiện Event đã được thiết lập
            if (ik.IsNotNull()) { ik.DoKeyCommand(ik); }
            else
            {
                ik = frm.FindAllChildrenByType<IListKeyPress>().SelectMany(p => p.GetList()).FirstOrDefault(i => i.KeyCommand == keyData);
                if (ik.IsNotNull()) { ik.DoKeyCommand(ik); }
            }
            // return xem có thực hiện được sự kiện Key Press chưa
            return ik.IsNotNull();
        }
    }
}
