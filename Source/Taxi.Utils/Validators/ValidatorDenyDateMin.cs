using System;
namespace Taxi.Utils.Validators
{
    public class ValidatorDenyDateMin : ValidatorAttribute
    {
        public override bool Validate()
        {
            if (Value == null || string.IsNullOrEmpty(Value.ToString().Trim())) return true;

            try
            {
                return Convert.ToDateTime(Value) != DateTime.MinValue;
            }
            catch
            {
                return false;
            }
        }

        public override string GetMessage()
        {
            return "Yêu cầu nhập " + FieldName;
        }
    }
}
