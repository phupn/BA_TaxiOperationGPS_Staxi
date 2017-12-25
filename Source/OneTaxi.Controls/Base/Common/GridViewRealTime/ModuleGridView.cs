using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTaxi.Controls.Base.Controls.Grids.Extender;
using OneTaxi.Data.Systems;

namespace OneTaxi.Controls.Base.Common.GridViewRealTime
{
    public class ModuleGridView : RealTimeGridView<TAXIOPERATION,long,G5Command>
    {
        public override List<G5Command> DicCommand
        {
            get
            {
                return base.DicCommand;
            }
        }
        protected override void ExceptionError(string name, Exception ex)
        {
            
        }
        public override void IniGridView() { }
        public override bool CheckCommand(TAXIOPERATION data, G5Command command)
        {
            return true;
        }
    }
}
