using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils.Enums;

namespace Taxi.Data.BanCo.Entity
{
    [TableInfo(TableName = "T_TAXIOPERATION_COMMAND")]
    public class TaxiOperationCommand : TaxiOperationDbEntityBase<TaxiOperationCommand>
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = false)]
        public int Id { get; set; }
        
        /// <summary>
        /// Tên lệnh điều hành
        /// </summary>
        [Field]
        public string Command { get; set; }
        
        /// <summary>
        /// Phím tắt
        /// </summary>
        [Field]
        public int Shortcuts { get; set; }
        
        /// <summary>
        /// Trang thai cuoc goi enum TrangThaiCuocGoi
        /// </summary>
        [Field]
        public int? CallStatus { get; set; }
        
        /// <summary>
        /// Trang thai lenh (enum TrangThaiLenh)
        /// </summary>
        [Field]
        public int? Status { get; set; }
        
        /// <summary>
        /// Kieu cuoc goi (enum KieuCuocGoi)
        /// </summary>
        [Field]
        public int? CallType { get; set; }
        
        /// <summary>
        /// Mau nen
        /// </summary>
        [Field]
        public string CmdColor { get; set; }
        
        /// <summary>
        /// Lenh cha (la lenh dieu hanh khi phan hoi lai lenh con)
        /// </summary>
        [Field]
        public string ParentCommand { get; set; }

        /// <summary>
        /// Mau nen cha (mau nen khi lenh con da duoc phan hoi)
        /// </summary>
        [Field]
        public string ParentColor { get; set; }

        /// <summary>
        /// Check co ton tai xe nhan
        /// </summary>
        [Field]
        public bool RequireVehicle { get; set; }

        /// <summary>
        /// Bo phan nao su dung enum Enum_ChucNangNhiemVu
        /// </summary>
        [Field]
        public int FunctionUsing { get; set; }

        /// <summary>
        /// Neu = true thi chuyen sang moi khach ChuyenMK = true
        /// </summary>
        [Field]
        public bool? IsSend_CallCust { get; set; }
        /// <summary>
        /// Gửi hàm nào cho lái xe.
        /// </summary>
        [Field]
        public int SendDriver { get; set; }
        [Field]
        public Enum_CommandCode CommandCode { get; set; }
        [Field]
        public int OrderCode { get; set; }
        #endregion

        public List<TaxiOperationCommand> GetListAll()
        {
            return this.GetAll().ToList<TaxiOperationCommand>();
        }

        public int InsertCmd(string command, int shortCuts, int callStatus, int status, int callType, string cmdColor, string parentCommand, string parentColor, bool requireVehicle, int functionUsing, bool isSend_CallCust, int sendDriver, int commandCode)
        {
            return ExeStoreNoneQuery("sp_T_TAXIOPERATION_COMMAND_Insert", command, shortCuts, callStatus, status, callType, cmdColor, parentCommand, parentColor, requireVehicle, functionUsing, isSend_CallCust, sendDriver, commandCode);
        }

        public int UpdateCmd(int id, string command, int shortCuts, int callStatus, int status, int callType, string cmdColor, string parentCommand, string parentColor, bool requireVehicle, int functionUsing, bool isSend_CallCust, int sendDriver, int orderCode, int commandCode)
        {
            return ExeStoreNoneQuery("sp_T_TAXIOPERATION_COMMAND_Update", id, command, shortCuts, callStatus, status, callType, cmdColor, parentCommand, parentColor, requireVehicle, functionUsing, isSend_CallCust, sendDriver, orderCode, commandCode);
        }

        public int DeleteCmd(int pId)
        {
            return ExeStoreNoneQuery("sp_T_TAXIOPERATION_COMMAND_Delete", pId);
        }
        
    }
}
