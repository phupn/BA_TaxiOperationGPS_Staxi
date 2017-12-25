namespace Taxi.Utils.Validators
{
    /// <summary>
    /// Validate có phải kiểm số hay không
    /// </summary>
    public class ValidatorIsNumeric : ValidatorAttribute
    {
        public override bool Validate()
        {
            if (Value == null || string.IsNullOrEmpty(Value.ToString().Trim())) return true;

            decimal d;

            return decimal.TryParse(Value.ToString(), out d);
        }

        public override string GetMessage()
        {
            return FieldName + " không đúng định dạng số";
        }
    }
}
