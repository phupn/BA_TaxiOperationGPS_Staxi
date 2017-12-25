using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Taxi.Utils
{
    public class MemberInfoHelper
    {
        private MemberInfoHelper() { }

        private static MemberInfoHelper inst = new MemberInfoHelper();
        public static MemberInfoHelper Inst
        {
            get { return inst; }
        }

        /// <summary>
        /// Lấy Attribute của một MemberInfo
        /// </summary>
        public TAttribute GetAttribute<TAttribute>(MemberInfo mi, bool inherit) where TAttribute : Attribute
        {
            var arr = mi.GetCustomAttributes(typeof(TAttribute), inherit);
            return arr.Length == 0 ? null : arr[0] as TAttribute;
        }

        /// <summary>
        /// Lấy ra danh sách Attribute của một MemberInfo
        /// </summary>
        public List<TAttribute> GetAttributes<TAttribute>(MemberInfo mi, bool inherit) where TAttribute : Attribute
        {
            return mi.GetCustomAttributes(typeof(TAttribute), inherit).Cast<TAttribute>().ToList();
        }

        /// <summary>
        /// Lấy ra danh sách cặp đôi property và List Attribute của một Type
        /// </summary>
        public List<Pair<PropertyInfo, List<TAttribute>>> GetListPairPropertyListAttribute<TAttribute>(Type type, bool inherit) where TAttribute : Attribute
        {
            return type.GetProperties().Select(p => new Pair<PropertyInfo, List<TAttribute>> { T1 = p, T2 = GetAttributes<TAttribute>(p, inherit) }).Where(pr => pr.T2.Count != 0).ToList();
        }
    }

    /// <summary>
    /// Cặp đôi giá trị
    /// </summary>
    public class Pair<T1Value, T2Value>
    {
        public T1Value T1 { set; get; }
        public T2Value T2 { set; get; }
    }
}
