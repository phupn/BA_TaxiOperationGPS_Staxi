using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Business.QuanTri
{
    [TableInfo(TableName = "T_QUANTRICAUHINH_HETHONGMAYTINH")]
    public class QuanTriCauHinhEntity:DbEntityBase<QuanTriCauHinhEntity>
    {
        [Field]
        public string IP_Address { get; set; }
        [Field]
        public string Line_Vung { get; set; }
        [Field]
        public string IsMayTinh { get; set; }
        [Field]
        public string IsHoatDong { get; set; }
        [Field]
        public int  MK { get; set; }
        [Field]
        public string LineGop { get; set; }
        [Field]
        public string G5_Type { get; set; }
        [Field]
        public string G5_PinMap { get; set; }
        [Field]
        public string O_Khoang { get; set; }

        [Field]
        public string Extension { get; set; }

        [Field]
        public int HasPopUpNewCall { get; set; }

        public List<QuanTriCauHinhEntity> GetListAll()
        {
            try
            {
                return Inst.GetAll().ToList<QuanTriCauHinhEntity>();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("QuanTriCauHinhEntity->GetListAll: ",ex);
                return new List<QuanTriCauHinhEntity>();
            }
        }

    }
}
