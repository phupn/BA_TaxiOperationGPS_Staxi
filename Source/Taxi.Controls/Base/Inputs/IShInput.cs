namespace Taxi.Controls.Base.Inputs
{
    /// <summary>
    /// Interface của một Input
    /// </summary>
    public interface IShInput
    {   
        void Clear();
        void SetValue(object value);
        object GetValue();
    }
}
