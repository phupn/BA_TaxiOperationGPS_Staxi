
namespace OneTaxi.Controls.Base
{
    public interface IInput
    {
        void Clear();
        void SetValue(object value);
        object GetValue();
    }
}
