using Staxi.Utils.DbBase;
using System;
using System.Collections.Generic;

namespace OneTaxi.Controls.Base
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
