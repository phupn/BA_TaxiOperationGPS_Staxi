using System;
using System.Collections.Generic;
using Taxi.Common.DbBase;

namespace Taxi.Controls.Base.Controls
{
    /// <summary>
    /// Cung cấp cho Repository phương thức lẫy dữ liệu
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : ModelBase, new()
    {
        Func<List<T>> Func { set; get; }
    }
}
