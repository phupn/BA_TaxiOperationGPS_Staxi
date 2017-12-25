using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.BanCo.Entity.Config;
using Taxi.Common.Extender;
namespace Taxi.Controls.Base.Common.InputLookUps
{
    public class InputLookUp_MobileOperationCommand : InputLookUp<MobileOperationCommands>
    {
        public int IdStepWorkflow { set; get; }

        public InputLookUp_MobileOperationCommand()
        {
            this.SetFunc(() => 
            {
                if (IdStepWorkflow != 0)
                    return new MobileOperationCommands { }.GetListByIdStepWorkflow(IdStepWorkflow);
                else
                    return new MobileOperationCommands { }.GetAll().ToList<MobileOperationCommands>();
                    
            });
        }
    }
}
