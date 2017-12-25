using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Data.BanCo.DbConnections;
using System.Data;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.TuyenThueBao
{
    [TableInfo(TableName = "THUEBAO.T_DMDIEMXUATPHAT")]
    public class DiemXuatPhat : TaxiOperationDbEntityBase<DiemXuatPhat>
    {
        [Field(IsKey = true, IsIdentity = true)]
        public int ID { get; set; }

        [Field]
        public string TenDiemXuatPhat { get; set; }

        [Field]
        public String ShortName { set; get; }

        public String NewName { set; get; }

        public List<DiemXuatPhat> getListDiemXP() 
        {
            List<DiemXuatPhat> listRet =  getDMDiemXuatPhat().ToList<DiemXuatPhat>();

            foreach (DiemXuatPhat obj in listRet)
            {
                if (String.IsNullOrEmpty(obj.ShortName))
                    obj.NewName = obj.TenDiemXuatPhat;
                else
                    obj.NewName = String.Format("{0}_{1}", obj.ShortName, obj.TenDiemXuatPhat);
            }

            return listRet;
        }

        #region form diem xuat phat
        public DataTable getDMDiemXuatPhat()
        {
            return ExeStore("sp_THUEBAO_T_DMDIEMXUATPHAT_SELECT_ALL");
        }

        public int UpdateDMDiemXuatPhat(int id, string TenDiemXuatPhat, string VietTat)
        {
            return ExeStoreNoneQuery("sp_THUEBAO_T_DMDIEMXUATPHAT_Update", id, TenDiemXuatPhat,VietTat);
        }

        public int InsertDMDiemXuatPhat(string TenDiemXuatPhat,string VietTat)
        {
            return ExeStoreNoneQuery("sp_THUEBAO_T_DMDIEMXUATPHAT_INSERT", TenDiemXuatPhat,VietTat);
        }

        public int DeleteDMDiemXuatPhat(int id)
        {
            return ExeStoreNoneQuery("sp_THUEBAO_T_DMDIEMXUATPHAT_DELETE", id);
        }

        public int GetDefault()
        {
            return int.Parse(ExeStore("sp_THUEBAO_T_DMDIEMXUATPHAT_GetDefault").Rows[0][0].ToString());
        }
        #endregion
    }
   
}
