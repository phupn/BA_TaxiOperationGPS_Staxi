using System;
using System.Data;
using Taxi.Data.BanCo.DbConnections;

namespace Taxi.Data.BanCo.Entity.Salary
{
    public class BangLuongHuong : TaxiOperationDbEntityBase<BangLuongHuong>
    {
        public DataTable GetData( DateTime Start,DateTime End,int loaiXeId=0)
        {
            return ExeStore("BangLuongHuong_getProcess", Start,End, loaiXeId);
        }

        public DataTable GetAllLaiXe()
        {
            return ExeStore("Luong_BangHuongLuong_GetAllLaiXe");
        }
        public DataTable GetAllXe()
        {
            return ExeStore("Luong_BangHuongLuong_GetAllXe");
        }
        public DataTable GetAllChotCo(DateTime start,DateTime end)
        {
            return ExeStore("Luong_BangHuongLuong_GetAllChotCo", start,end);
        }
        public DataTable GetAllCuocKhach(DateTime start, DateTime end)
        {
            return ExeStore("Luong_BangHuongLuong_GetAllCuocKhach", start, end);
        }
        public DataTable GetAllTrucDem(DateTime start, DateTime end)
        {
            return ExeStore("Luong_BangHuongLuong_GetAllTrucDem", start, end);
        }
    }
}
