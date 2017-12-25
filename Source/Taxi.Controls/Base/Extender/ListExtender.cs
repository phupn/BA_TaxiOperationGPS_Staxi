using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Controls.Base.Extender
{
    /// <summary>
    /// Phương thức mở rộng cho List
    /// </summary>
    public static class ListExtender
    {
        /// <summary>
        /// Tìm kiếm những bản tin mới từ danh sách mới so với danh sách cũ
        /// </summary>
        public static IEnumerable<T1> FindNewItems<T1, T2, T>(this IEnumerable<T1> listNews, IEnumerable<T2> listOlds, Func<T1, T> ex1, Func<T2, T> ex2)
        {
            return (from vi_new in listNews
                    join vi_old in listOlds on ex1(vi_new) equals ex2(vi_old) into vi_old_
                    from vi_old_item in vi_old_.DefaultIfEmpty()
                    select new { vi_new, vi_old_item }).Where(o => o.vi_old_item == null).Select(o => o.vi_new);
        }

        public static void SLeftJoin<T1, T2, T>(this IEnumerable<T1> listNews, IEnumerable<T2> listOlds, Func<T1, T> ex1, Func<T2, T> ex2, Action<T1, T2> map, Action<T1> notmap)
        {
            (from vi_new in listNews
             join vi_old in listOlds on ex1(vi_new) equals ex2(vi_old) into vi_old_
             from vi_old_item in vi_old_.DefaultIfEmpty()
             select new { vi_new, vi_old_item }).Where(o =>
             {
                 if (object.Equals(o.vi_old_item, default(T2))) return true;
                 else
                 {
                     map(o.vi_new, o.vi_old_item);
                     return false;
                 }
             }).ToList().Select(o =>
             {
                 notmap(o.vi_new);
                 return false;
             }).Count();
        }

        public static void ForEach<T>(this IEnumerable<T> data, Action<T> action)
        {
            foreach (var t in data) action(t);
        }

        public static int SJoin<T1, T2, TValue>(this IEnumerable<T1> t1, IEnumerable<T2> t2, Func<T1, TValue> f1, Func<T2, TValue> f2, Action<T1, T2> action)
        {
            return t1.Join(t2, f1, f2, (t1i, t2i) => { action(t1i, t2i); return false; }).Count();
        }

        public static int SGroupJoin<T1, T2, TValue>(this IEnumerable<T1> t1, IEnumerable<T2> t2, Func<T1, TValue> f1, Func<T2, TValue> f2, Action<T1, IEnumerable<T2>> action)
        {
            return t1.GroupJoin(t2, f1, f2, (t1i, t2is) => { action(t1i, t2is); return false; }).Count();
        }

        /// <summary>
        /// Join các phần tử thành một chuỗi
        /// </summary>
        public static string SJoinString<T, T1>(this IEnumerable<T> t, Func<T, T1> f, string sep = ",")
        {
            return string.Join(sep, t.Select(f).ToArray());
        }

        /// <summary>
        /// Cố gắng lấy một số lượng item ở BlockingCollection
        /// </summary>
        public static List<T> TryTake<T>(this BlockingCollection<T> data, int totalTryTake)
        {
            var list = new List<T>();
            T t; var i = 0;
            while (i < totalTryTake && data.Count > 0)
            {
                if (data.TryTake(out t))
                {
                    list.Add(t);
                    i++;
                }
            }
            return list;
        }

        /// <summary>
        /// Thực hiện xử lý với từng cum
        /// </summary>
        public static void ProcessInPage<T>(this List<T> list, int pageSize, Action<IEnumerable<T>> action)
        {
            list.ProcessInPage(pageSize).ForEach(data => action(data));
        }

        public static IEnumerable<IEnumerable<T>> ProcessInPage<T>(this List<T> list, int pageSize)
        {
            var totalPage = (int)Math.Ceiling((decimal)list.Count / pageSize);

            for (int i = 1; i <= totalPage; i++)
                yield return list.Skip((i - 1) * pageSize).Take(pageSize);
        }
    }
}
