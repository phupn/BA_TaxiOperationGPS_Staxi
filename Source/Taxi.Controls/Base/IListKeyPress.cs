using System.Collections.Generic;
using Taxi.Controls.Base.Inputs;

namespace Taxi.Controls.Base
{
    public interface IListKeyPress
    {
        List<IShKeyPress> GetList();
    }
}
