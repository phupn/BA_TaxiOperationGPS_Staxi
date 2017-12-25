using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Data.G5;

namespace Taxi.Controls.Commands
{
    public partial class ctrlListCommandHistory : UserControl
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public string Info { get; set; }
        public ctrlListCommandHistory()
        {
            InitializeComponent();
            GridHistory.UseEmbeddedNavigator = false;
        }

        private void ctrlListCommandHistory_Load(object sender, EventArgs e)
        {
            lblInfo.Text = Info;
            var lst = new List<T_TaxiOperation_SendCommand>();
            GridHistory.DataSource = lst;
            GridHistory.RefreshDataSource();
            if (Id != null && Id > 0)
            {
                lst = T_TaxiOperation_SendCommand.Inst.GetAllById(Id);
                if (lst!= null)
                {
                    GridHistory.SetDataSource(lst);
                }
            }            
        }        
    }
}
