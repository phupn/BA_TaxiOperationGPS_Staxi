
namespace Taxi.Utils.Validators
{
    /// <summary>
    /// Validate không được để trống
    /// </summary>
    public class ValidatorRequireAttribute : ValidatorAttribute
    {
        public override bool Validate()
        {
            // null 
            if (Value == null) return false;

            // string empty
            if (string.IsNullOrEmpty(Value.ToString().Trim())) return false;

            // 
            return true;
        }

        /// <summary>
        /// Ghi ra thông báo
        /// </summary>
        /// <returns></returns>
        public override string GetMessage()
        {
            return FieldName + " không được để trống";
        }
    }
}
