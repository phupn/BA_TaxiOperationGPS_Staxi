#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Services.Operations.Inferfaces;
using Taxi.Utils;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Services.Operations
{
    public class ServiceOperationFactory
    {
        /// <summary>
        /// Khởi tạo service theo từng cơ chế
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceOperation Get(EnumServiceDieuApp service,string ConnectService="")
        {
            if (string.IsNullOrEmpty(ConnectService))
            {
                switch (service)
                {
                    //case EnumServiceDieuApp.BaSao:
                    //    return new ServiceOperationBaSao();
                    case EnumServiceDieuApp.G5:
                    case EnumServiceDieuApp.Default:
                    default:
                        return new ServiceOperationG5();
                }
            }
            else
            {
                switch (service)
                {
                    //case EnumServiceDieuApp.BaSao:
                    //    return new ServiceOperationBaSao(ConnectService);
                    case EnumServiceDieuApp.G5:
                    case EnumServiceDieuApp.Default:
                    default:
                        return new ServiceOperationG5(ConnectService);
                }
            }
        }
    }
}
