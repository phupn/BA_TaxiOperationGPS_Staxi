using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Taxi.Utils
{
    public static class DataTableExtend
    {
        /// <summary>
        /// Ép 1 bản ghi của bảng thành 1 đối tượng
        /// </summary>
        public static T ParseTo<T>(this DataRow row) where T : new()
        {
            var t = new T();
            t.GetType().GetProperties().ToList().ForEach(p =>
            {
                if (p.CanWrite)
                {
                    var type = TypeDescriptor.GetConverter(p.PropertyType);
                    try
                    {

                        if ((p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?)) && row[p.Name].ToString() != string.Empty && row[p.Name].ToString()!="")
                            p.SetValue(t, DateTime.Parse(row[p.Name].ToString()), null);
                        else
                        {
                            var obj = type.ConvertTo(row[p.Name].ToString(), p.PropertyType);
                            p.SetValue(t, obj, null);
                        }
                        
                       
                    }
                    catch
                    {
                      //  p.SetValue(t, type.ConvertTo(null, p.PropertyType), null);
                    }
                }
             
            }
           );
            return t;
        }

        public static object DefaultValue(Type maybeNullable)
        {
            var underlying = Nullable.GetUnderlyingType(maybeNullable);
            return Activator.CreateInstance(underlying ?? maybeNullable);
        }
    }

    public static class TypeExtend
    {
        public static void CopyTo(this object target, object source)
        {
            target.GetType().GetProperties().ToList().ForEach(p=>
            {
                var pi = source.GetType().GetProperty(p.Name);
                if (pi != null && p.CanWrite && pi.CanRead)
                {
                    try
                    {
                        p.SetValue(target, pi.GetValue(source, null), null);
                    }catch{}
                   
                }
            });
        }
    }
}
