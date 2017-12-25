using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

using Staxi.Utils.Extender;

using OneTaxi.Controls.Base.Extender;

namespace OneTaxi.Controls.Base.Controls
{
    /// <summary>
    /// Panel chứa các IInput
    /// </summary>
    public class PanelInput : PanelControl
    {
        private Label labelMessage;
        /// <summary>
        /// Label để hiển thị message
        /// </summary>
        public Label LabelMessage
        {
            get { return labelMessage; }
            set { labelMessage = value; }
        }

        /// <summary>
        /// Điền dữ liệu vào Control
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ParseTo<T>(bool hasValidate = true, Action<T> afterThrowMessageInValid = null) where T : new()
        {
            // Khởi tạo đối tượng
            T t = new T();

            // Điền dữ liệu vào t và kết quả validate
            ParseTo(t, hasValidate, afterThrowMessageInValid);

            // trả ra đối tượng
            return t;
        }

        /// <summary>
        /// Điền dữ liệu trong Panel vào đối tượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void ParseTo<T>(T t, bool hasValidate = true, Action<T> afterThrowMessageInValid = null)
        {
            if (t == null) return;

            // Type của obj
            Type type = t.GetType();

            ListInputs.ForEach(c =>
            {
                // Name
                var pname = (c as Control).Tag.ToString();

                // Lấy ra Property
                var pi = type.GetProperty(pname);

                // Nếu có Property mới Fill
                if (pi != null) pi.SetValue(t,c.GetValue());
            });
            //// Lấy ra các giá trị ở trong Panel rồi điền vào đối tượng 
            //t.Parse(GetValuesInput(),false);

            //// Nếu không thực hiện validate thì return
            //if (!hasValidate) return;

            // Thực hiện validate
            //var validator = t.Validate(ListInputs.Cast<Control>().OrderBy(c => c.TabIndex).Select(c => c.Tag.ToString()).ToArray());

            //// Nếu dữ liệu được valid nhưng t lại có mở rộng validate riêng thì thực hiện validate tiếp
            //// if (validator.IsValid && (t is IValidator)) validator = (t as IValidator).Validate();

            //// nếu validator báo có dữ liệu không hợp lệ
            //if (!validator.IsValid)
            //{
            //    // Focus Control
            //    var inputFocus = this.ListInputs.Cast<Control>().FirstOrDefault(i => i.Tag.ToString() == validator.FieldName);

            //    // Nếu tồn tại control thì focus
            //    if (inputFocus.IsNotNull()) inputFocus.Focus();

            //    // Thực hiện trước khi đưa ra thông báo lỗi
            //    if (afterThrowMessageInValid != null) afterThrowMessageInValid(t);

            //    // nếu như không có label hiển thị message thì bắn ra Exception
            //    if (this.labelMessage.IsNull()) throw new ShMessageException(validator.Message);

            //    // Hiển thị Message thông báo validate ko thành công
            //    this.ShowMessage(validator.Message, Color.Black);

            //    // Bắn ra Exception không sử lý
            //    throw new ShNoProcessException();
            //}
        }
        /// <summary>
        /// Điền dữ liệu trong Panel vào đối tượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public bool ParseToEx<T>(T t, bool hasValidate = true, Action<T> afterThrowMessageInValid = null)
        {
            // Lấy ra các giá trị ở trong Panel rồi điền vào đối tượng 
            t.Parse(GetValuesInput());

            // Nếu không thực hiện validate thì return
            if (!hasValidate) return true;

            //// Thực hiện validate
            //var validator = t.Validate(ListInputs.Cast<Control>().OrderBy(c => c.TabIndex).Select(c => c.Tag.ToString()).ToArray());

            //// Nếu dữ liệu được valid nhưng t lại có mở rộng validate riêng thì thực hiện validate tiếp
            //// if (validator.IsValid && (t is IValidator)) validator = (t as IValidator).Validate();

            //// nếu validator báo có dữ liệu không hợp lệ
            //if (!validator.IsValid)
            //{
            //    // Focus Control
            //    var inputFocus = this.ListInputs.Cast<Control>().FirstOrDefault(i => i.Tag.ToString() == validator.FieldName);
            //    // var nameFx = string.Empty;//t.GetType().GetProperty(validator.FieldName).GetAttribute<FieldAttribute>().FieldName; 
            //    // Nếu tồn tại control thì focus
            //    if (inputFocus.IsNotNull()) inputFocus.Focus();

            //    // Thực hiện trước khi đưa ra thông báo lỗi
            //    if (afterThrowMessageInValid != null) afterThrowMessageInValid(t);

            //    // nếu như không có label hiển thị message thì bắn ra Exception
            //    if (this.labelMessage.IsNull()) throw new ShMessageException(validator.Message);

            //    // Hiển thị Message thông báo validate ko thành công
            //    this.ShowMessage(validator.Message, Color.Black);
            //    return true;
            //    // Bắn ra Exception không sử lý
            //    //  throw new ShNoProcessException();
            //}
            return false;
        }
        /// <summary>
        /// Điền giá trị lên Form từ thông tin một Object
        /// </summary>
        public void Fill(object obj)
        {
            // Nếu obj null thì return không thực hiện gì
            if (obj == null) return;

            // Type của obj
            Type type = obj.GetType();

            ListInputs.ForEach(c =>
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
        /// Hiển thị Message
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message, bool ShowCenter = true)
        {
            this.ShowMessage(message, Color.Green, ShowCenter);
        }

        /// <summary>
        /// Hiển thị Message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public void ShowMessage(string message, Color color, bool ShowCenter = true)
        {
            // Thiết lập là cho phép sử dụng HtmlString
            labelMessage.AllowHtmlString = true;

            // Message cần hiển thị
            labelMessage.Text = message;

            // Màu nền
            labelMessage.ForeColor = color;

            // trường hợp có label hiển thị message thì kiểm tra xem label này có phải thuộc panel hay không
            if (ShowCenter)
                if (this.Controls.Contains(labelMessage)) labelMessage.Location = new Point((this.Width - labelMessage.Width) / 2, labelMessage.Location.Y);
        }

        /// <summary>
        /// Thực hiện Clear Form
        /// </summary>
        public void ClearForm()
        {
            ListInputs.ForEach(c => c.Clear());
        }

        /// <summary>
        /// Lấy các giá trị được nhập ở trong Panel
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetValuesInput()
        {
            // Khai báo một Dictionary để lưu giá trị trả về
            Dictionary<string, object> dic = new Dictionary<string, object>();

            // Lấy những Control mà là IInput, Tag khác rỗng
            ListInputs.ForEach(c => dic[(c as Control).Tag.ToString()] = c.GetValue());

            // Trả về kết quả
            return dic;
        }

        private List<IInput> listInputs = null;
        /// <summary>
        /// Danh sách các Inputs có trên Form
        /// </summary>
        public List<IInput> ListInputs
        {
            get
            {
                // Nếu chưa lấy ra các Inputs lần nào thì thực hiện lấy
                if (listInputs == null)
                {
                    // Lấy những Control mà là IInput, Tag khác rỗng
                    listInputs = this.FindIShInput();

                    // Thiết lập sự kiện khi control focus
                    listInputs.Cast<Control>().ToList().ForEach(c => c.GotFocus += Input_Focus);
                }
                return listInputs;
            }
        }

        /// <summary>
        /// Khi control được focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Input_Focus(object sender, EventArgs e)
        {
            //   if (labelMessage != null) labelMessage.Text = string.Empty;
        }

        /// <summary>
        /// Thiết lập enable với các control theo tag
        /// </summary>
        /// <param name="tagName"></param>
        public void SetEnabled(bool enabled, bool clearWhenEnabled, params string[] tagName)
        {
            if (tagName != null && tagName.Count() > 0)
            {
                // Tìm các control có Tag cần thực hiện enabled
                ListInputs.Cast<Control>().Join(tagName, c => c.Tag.ToString(), t => t, (c, t) =>
                {
                    // Enabled
                    c.Enabled = enabled;

                    // Clear khi mà enabled
                    if (clearWhenEnabled) (c as IInput).Clear();

                    // return false
                    return false;
                }).Count(); // Thực hiện chạy vòng lặp
            }
        }

        private Control controlFisrt;
        public void FocusInput()
        {
            this.Focus();
            if (ListInputs != null && ListInputs.Count > 0)
            {
                if (controlFisrt == null)
                    controlFisrt = ((Control)ListInputs.OrderBy(p => ((Control)p).TabIndex).First());
                if (controlFisrt != null)
                    controlFisrt.Focus();
            }
        }
        public void BindData()
        {
            this.BindShControl();
        }
    }
}
