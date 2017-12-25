using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Linq;


namespace Taxi.Data.BanCo.Entity.MasterData
{
    [TableInfo(TableName = "BanCo_VungDieuHanh")]
    public class VungDieuHanh : TaxiOperationDbEntityBase<VungDieuHanh>
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public string NameVungDH { get; set; }
        [ValueField]
        [Field]
        public long? FK_CodeVungGPS { get; set; }
        [Field]
        public SqlString Polygon { get; set; }
        [Field]
        public SqlString ColorOfVungDH { get; set; }
        [Field]
        public SqlString Description { get; set; }
        [Field]
        public SqlInt32 Sort { get; set; }
        [Field]
        public string ShortName { get; set; }
        /// <summary>
        /// Nếu chọn là quay đầu thì Duplicate cuốc đó lên, Xe đó quay lại điểm đón hàng để thực hiện 1 cuốc khác
        /// </summary>
        [Field]
        public bool IsQuayDau { get; set; }

        [DisplayField]
        [ColumnField(ColumnName = "Vùng")]
        public string NewName
        {
            get
            {
                if (!string.IsNullOrEmpty(ShortName))
                {
                    return ShortName + " - " + NameVungDH;
                }
                return NameVungDH;
            }
        }

        private List<KeyValuePair<float, float>> lsPolygon;
        public List<KeyValuePair<float, float>> LsPolygon
        {
            get
            {
                if (lsPolygon == null || lsPolygon.Count==0)
                {
                    lsPolygon = new List<KeyValuePair<float,float>>();
                    if (!Polygon.IsNull)
                    {
                      lsPolygon=  Polygon.ToString().Split(',').Select(p =>
                        {
                            var pi = p.Split(' ');
                            float vd = 0;
                            float kd = 0;
                            if (
                                System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat
                                    .CurrencyDecimalSeparator == ",")
                            {
                                //Thay thế '.' => ','
                                pi[0] = pi[0].Replace('.', '#');
                                pi[0] = pi[0].Replace(',', '.');
                                pi[0] = pi[0].Replace('#', ',');

                                pi[1] = pi[1].Replace('.', '#');
                                pi[1] = pi[1].Replace(',', '.');
                                pi[1] = pi[1].Replace('#', ',');
                            }
                            float.TryParse(pi[0], out vd);
                            float.TryParse(pi[1], out kd);
                            return new KeyValuePair<float, float>(vd, kd);
                        }).ToList();
                    }

                }
                return lsPolygon;
            }
        }
        #endregion
        public List<VungDieuHanh> GetAllVungDieuHanh()
        {
            return GetAll().ToList<VungDieuHanh>();
        }
        /// <summary>
        /// Lấy danh sách vùng điều hành theo
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllWithSort()
        {
            return ExeStore("sp_BanCo_VungDieuHanh_GetAllSort");//.ToList<VungDieuHanh>();
        }
        public DataTable Find(string StrGPS, string StrTenVung, string StrMauSac)
        {
            return ExeStore("sp_BanCo_VungDieuHanh_Find", StrGPS, StrTenVung, StrMauSac);
        }
        public void UpdateSort(int id, int index)
        {
            ExeStoreNoneQuery("sp_BanCo_VungDieuHanh_UpdateSort", id, index);

        }

        public DataTable VDHById(int id)
        {
            return ExeStore("sp_BanCo_VungDieuHanh_GetById", id);
        }

        public DataTable GetTenVungDieuHanh() {
            return ExeStore("sp_BanCo_VungDieuHanh_GetTenVung");
        }
    }
}
