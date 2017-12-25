using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.BanCo.Entity;
using Taxi.Utils.Enums;

namespace Taxi.Controls.Base.Common.InputLookUps
{
    public class InputLookUp_StaxiFile : InputLookUp<StaxiFile>
    {
        public StaxiFileType FileType { get; set; }
        protected override List<StaxiFile> Data
        {
            get
            {
                return StaxiFile.Inst.GetListByFileType(FileType);
            }
        }
    }
}
