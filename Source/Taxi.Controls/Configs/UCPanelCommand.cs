using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Taxi.Business;
using Taxi.Common.EnumUtility;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity;
using Taxi.Utils.Enums;

namespace Taxi.Controls.Configs
{
    public partial class UCPanelCommand : XtraUserControl
    {
        #region Fields & Properties!
        public int WidthLabel = 130;
        public int HeightLabel = 15;        
        public int HeThongLayCauHinh = 1;

        public const int PaddingLabel = 3;
        public const int RowInAColumn = 5; 
        #endregion

        #region Methods
        public UCPanelCommand()
        {
            InitializeComponent();
        }

        public void DisplayCommandInPanel()
        {
            if (HeThongLayCauHinh == 2)
            {
                WidthLabel = 150;
                HeightLabel = 20;
            }
            GenLabelInPanel(HeThongLayCauHinh);
        }
        private void GenLabelInPanel(int pFuncUsing)
        {
            try
            {
                int col = 0;
                int row = 0;
                List<TaxiOperationCommand> lstCommand = CommonBL.Commands.Where(a => a.FunctionUsing == pFuncUsing && a.OrderCode < 1000).OrderBy(a => a.OrderCode).ToList();
                for (int i = 0; i < lstCommand.Count; i++)
                {
                    try
                    {
                        string phimTat = typeof(PhimTat).GetField(((PhimTat)lstCommand[i].Shortcuts).ToString()).GetAttribute<EnumItemAttribute>().Name;
                        Label lblCommand = new Label();
                        lblCommand.Text = "Phím " + phimTat + " : " + lstCommand[i].Command;
                        lblCommand.Size = new Size(WidthLabel, HeightLabel);
                        lblCommand.ForeColor = Color.DarkRed;
                        if (row % RowInAColumn == 0 && row > 0)
                        {
                            row = 0;
                            col++;
                        }
                        lblCommand.Location = new Point(col * WidthLabel + PaddingLabel, 5 + HeightLabel * row);
                        this.panelCommand.Controls.Add(lblCommand);
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("For in GenLabelInPanel", ex);
                    }
                    row++;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GenLabelInPanel: ",ex);                
            }
        }

        #endregion
    }
}
