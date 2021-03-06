using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Data;
using System.Data;
using Taxi.Entity;

namespace Taxi.Business
{
    /// <summary>
    /// author hangtm
    /// create date 8/4/2011
    /// </summary>
   public class XeOnline
    {
       /// <summary>
        /// Lấy ra bảng vị trí xe online
       /// </summary>
       /// <param name="MaCungXN"></param>
       /// <param name="tgBatdau"></param>
       /// <param name="tgKetthuc"></param>
       /// <returns></returns>
        public DataTable GetCarPosition(string MaCungXN , DateTime tgBatdau , DateTime tgKetthuc )
        {
            return new Taxi.Data.XeOnlineData().GetCarPosition( MaCungXN ,  tgBatdau ,  tgKetthuc );
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="MaCungXN"></param>
       /// <param name="tgBatdau"></param>
       /// <param name="tgKetthuc"></param>
       /// <returns></returns>
       public List<OnlineCarEntity> Async_ListXeObject_By_XNAndTime(string MaCungXN, DateTime tgBatdau, DateTime tgKetthuc)
       {
           return new Taxi.Data.XeOnlineData().Async_ListXeObject_By_XNAndTime(MaCungXN, tgBatdau, tgKetthuc);
       }

       /// <summary>
       /// tra lai bang danh muc dia danh 
       /// </summary>
       /// <returns></returns>
       public DataTable TenDiaDanh()
       {
           return new Taxi.Data.XeOnlineData().TenDiaDanh();
       }
       /// <summary>
       /// lay ra ten cac loai vung
       /// </summary>
       /// <returns></returns>
       public DataSet TenLoaiVung()
       {
           return new Taxi.Data.XeOnlineData().LoaiVung ();
       }
       /// <summary>
       /// lay thong tin kinh do, vi do, van toc, trang thai cua xe
       /// </summary>
       /// <returns></returns>
       public DataSet ThongTinXeOnline(string MaCungXn, string Sohieuxe, DateTime tgBatDau, DateTime tgKetThuc)
       {
           return new Taxi.Data.XeOnlineData().ThongTinXeOnline(MaCungXn, Sohieuxe , tgBatDau, tgKetThuc);
       }
        /// <summary>
        /// lay ra thong tin cua vung: ten vung, toa do cac dinh, tam vung
        /// </summary>
        /// <param name="MaCungXn"></param>
        /// <returns></returns>
       public DataSet ThongTinVung(string MaCungXn, int IDVung)
       {
           return new Taxi.Data.XeOnlineData().ThongTinVung(MaCungXn, IDVung);
       }
       public DataTable ThongTinToaDo(long ID)
       {
           return new Taxi.Data.XeOnlineData().ThongTinToaDo(ID);
       }
       
    }
}
