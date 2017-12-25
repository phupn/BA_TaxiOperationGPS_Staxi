using System;
namespace Taxi.Utils.Validators
{
    /// <summary>
    /// Validator phạm vi
    /// </summary>
    public class ValidatorRange : ValidatorAttribute
    {
        /// <summary>
        /// Loại so sánh
        /// </summary>
        private readonly RangeType _range = RangeType.Between;

        /// <summary>
        /// Cận dưới
        /// </summary>
        public double Min { get; set; }

        /// <summary>
        /// Cận trên
        /// </summary>
        public double Max { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ValidatorRange(RangeType range)
        {
            Max = 0;
            Min = 0;
            _range = range;
        }

        /// <summary>
        /// Thực hiện validate
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            // 
            if (Value == null || string.IsNullOrEmpty(Value.ToString().Trim())) return true;

            // Giá trị cần so sánh
            var value = Convert.ToDouble(Value);
            // Thực hiện so sánh
            switch (_range)
            {
                case RangeType.Between: return value >= Min && value <= Max;
                case RangeType.Greater: return value > Min;
            }

            // Mặc định là luôn đúng
            return true;
        }

        /// <summary>
        /// Đưa ra thông báo
        /// </summary>
        /// <returns></returns>
        public override string GetMessage()
        {
            switch (_range)
            {
                case RangeType.Between: return FieldName + " phải nằm trong khoảng " + Min + " đến " + Max;
                case RangeType.Greater: return FieldName + " phải lớn hơn " + Min;
            }
            return FieldName + " không thỏa mãn";
        }
    }

    /// <summary>
    /// Các loại so sánh
    /// </summary>
    public enum RangeType
    {
        Between = 0,
        Greater = 1
    }
}
