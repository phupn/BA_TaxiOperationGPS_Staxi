using System;
using System.Collections.Generic;

namespace Taxi.Entity
{
    public class XeDeCuEntity
    {
        #region Properties
        public float KinhDo { get; set; }
        public float ViDo { get; set; }
        public float KhoangCach { get; set; }
        public string PK_SoHieuXe { get; set; }
        public string FK_BienSoXe { get; set; }
        public string MaCungXN { get; set; }
        public int TrangThai { get; set; }
        public int TrangThaiKhac { get; set; }
        public int FK_LoaiXeID { get; set; }

        public XeDeCuEntity(float _KinhDo, float _ViDo, float _KhoangCach, string _PK_SoHieuXe, string _FK_BienSoXe,
            string _MaCungXN, int _TrangThai, int _TrangThaiKhac, int _FK_LoaiXeID)
        {
            KinhDo = _KinhDo;
            ViDo = _ViDo;
            KhoangCach = _KhoangCach;
            PK_SoHieuXe = _PK_SoHieuXe;
            FK_BienSoXe = _FK_BienSoXe;
            MaCungXN = _MaCungXN;
            TrangThai = _TrangThai;
            TrangThaiKhac = _TrangThaiKhac;
            FK_LoaiXeID = _FK_LoaiXeID;
        }
        public XeDeCuEntity()
         {
             
         }
         
#endregion Properties
    }

    public class XeDonDeCuEntity
    {
        public string SoHieuXe { get; set; }
        public double KinhDo { get; set; }
        public double ViDo { get; set; }
        public DateTime ThoiGian { get; set; }

        public XeDonDeCuEntity(){}
        public XeDonDeCuEntity(string _SoHieuXe, double _KinhDo, double _ViDo, DateTime _ThoiGian)
        {
            SoHieuXe = _SoHieuXe;
            KinhDo = _KinhDo;
            ViDo = _ViDo;
            ThoiGian = _ThoiGian;
        }
    }
}