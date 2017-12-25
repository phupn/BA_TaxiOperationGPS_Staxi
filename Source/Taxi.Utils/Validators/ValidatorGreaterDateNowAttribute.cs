using System;
namespace Taxi.Utils.Validators
{
    public class ValidatorGreaterDateNowAttribute : ValidatorAttribute
    {
        public override bool Validate()
        {
            if (Value == null || string.IsNullOrEmpty(Value.ToString().Trim())) return true;

            try
            {
                return Convert.ToDateTime(Value) != DateTime.Now;
            }
            catch
            {
                return false;
            }
        }

        public override string GetMessage()
        {
            return FieldName + " phải lớn hơn giờ hiện tại";
        }
    }
}
