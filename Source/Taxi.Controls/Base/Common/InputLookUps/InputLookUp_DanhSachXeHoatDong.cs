using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace Taxi.Controls.Base.Common.InputLookUps
{
    public  class InputLookUp_DanhSachXeHoatDong : InputLookUp<GiamSatXe_HoatDong>
    {
        protected override List<GiamSatXe_HoatDong> Data
        {
            get
            {
                return GiamSatXe_HoatDong.Inst.EnVangVip_GetXeHoatDong();
            }
        }
    }
}
