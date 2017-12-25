using System;

namespace Taxi.Utils
{
    public static class UtilsExtender
    {
        private static Random _random;
        private static object _syncObj = new object();
        public  static void InitRandomNumber(int seed)
        {
            _random = new Random(seed);
        }
        public static int GenerateRandomNumber( this object o ,int max)
        {
            lock (_syncObj)
            {
                if (_random == null)
                    _random = new Random(); // Or exception...
                return _random.Next(max);
            }
        }
        public static int GenerateRandomNumber(this object o, int min, int max)
        {
            lock (_syncObj)
            {
                if (_random == null)
                    _random = new Random(); // Or exception...
                return _random.Next(min,max);
            }
        }
    }
}
