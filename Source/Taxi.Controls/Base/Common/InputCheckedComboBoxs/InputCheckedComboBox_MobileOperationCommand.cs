using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.BanCo.Entity.Config;

namespace Taxi.Controls.Base.Common.InputCheckedComboBoxs
{
    public class InputCheckedComboBox_MobileOperationCommand : InputCheckedComboBox<MobileOperationCommands>
    {
        public int StepWorkflowId { get; set; }
        protected override List<MobileOperationCommands> Data
        {
            get
            {
                if (StepWorkflowId != null & StepWorkflowId > 0)
                    return MobileOperationCommands.Inst.GetListByIdStepWorkflow(StepWorkflowId);
                else
                    return base.Data;
            }
        }
    }
}
