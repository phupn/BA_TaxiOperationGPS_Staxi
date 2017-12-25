namespace Taxi.Utils.Validators
{
    public class ValidatorDenyValue : ValidatorAttribute
    {
        public object ValueDeny { set; get; }

        public ValidatorDenyValue(object v)
        {
            ValueDeny = v;
        }

        public override bool Validate()
        {
            return Value.ToString() != ValueDeny.ToString();
        }

        public override string GetMessage()
        {
            return string.Format("{0} không hợp lệ", FieldName);
        }
    }
}
