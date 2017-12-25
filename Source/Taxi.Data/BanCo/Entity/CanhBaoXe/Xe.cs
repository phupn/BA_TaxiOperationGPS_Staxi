using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Data.BanCo.Entity.CanhBaoXe
{
    public class Xe
    {
        public string SoHieu;
        public string TrangThai;
        public string MauChu;
        public string MauNen;
        public override string ToString()
        {
            return SoHieu;
        }
    }
}
