using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Services.Operations.Inferfaces;

namespace Taxi.Services.Operations
{
    public class ServiceOnlineFactory
    {
        private static IServiceOnline _inst;
        public static IServiceOnline Inst
        {
            get
            {
                if (_inst == null)
                    _inst = Get();
                return _inst;
            }
        }

        public static IServiceOnline Get(string ConnectService = "")
        {
            if (string.IsNullOrEmpty(ConnectService))
                return new ServiceOnline();
            return new ServiceOnline(ConnectService);
        }
    }
}
