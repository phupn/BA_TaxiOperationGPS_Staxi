using System;
using System.Collections.Generic;
namespace Taxi.Utils.Validators
{
    /// <summary>
    /// ValidatorAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ValidatorAttribute : Attribute
    {
        /// <summary>
        /// Thứ tự validate
        /// </summary>
        public int Stt { set; get; }

        public string MessageCustom { set; get; }

        /// <summary>
        /// Giá trị cần validate
        /// </summary>
        protected object Value { get; private set; }

        public Type ObjectType { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> Data { set; get; }

        protected ValidatorAttribute()
        {
            FieldName = string.Empty;
        }

        /// <summary>
        /// Tên thật của một Field
        /// </summary>
        protected string FieldName { get; private set; }

        /// <summary>
        /// Thiết lập Data
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        public void SetData(object value, string fieldName)
        {
            // Value cần validate
            Value = value;

            // Field Name
            FieldName = fieldName;
        }

        /// <summary>
        /// Thực hiện validate
        /// </summary>
        /// <returns></returns>
        public abstract bool Validate();

        /// <summary>
        /// Câu thông báo
        /// </summary>
        /// <returns></returns>
        public abstract string GetMessage();
    }

    /// <summary>
    /// Các kiểu trạng thái sau khi validate
    /// </summary>
    public enum ValidatorStatus
    {
        /// <summary>
        /// Dữ liệu được validate thành công
        /// </summary>
        /// 
        Valid = 0,

        /// <summary>
        /// Dữ liệu không hợp lệ với validate
        /// </summary>
        InValid = 1
    }

    /// <summary>
    /// Đối tượng đóng gói thông báo sau khi validate
    /// </summary>
    public class ValidatorMessage
    {
        /// <summary>
        /// Trạng thái sau khi vaidate
        /// </summary>
        public ValidatorStatus Status { set; get; }

        /// <summary>
        /// Message thông báo
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// Trường validate
        /// </summary>
        public string FieldName { set; get; }

        /// <summary>
        /// Có Valid hay không
        /// </summary>
        /// <returns></returns>
        public bool IsValid
        {
            get
            {
                return Status == ValidatorStatus.Valid;
            }
        }

        /// <summary>
        /// Default
        /// </summary>
        /// <returns></returns>
        public static ValidatorMessage GetDefault()
        {
            return new ValidatorMessage { Status = ValidatorStatus.Valid, Message = "Validated" };
        }
    }

    /// <summary>
    /// ValidatorException
    /// </summary>
    public class ValidatorException : Exception
    {
        private readonly ValidatorMessage _validatorMessage;
        /// <summary>
        /// 
        /// </summary>
        public ValidatorMessage ValidatorMessage
        {
            get { return _validatorMessage; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm"></param>
        public ValidatorException(ValidatorMessage vm) : base(vm.Message)
        {
            _validatorMessage = vm;
        }
    }
}
