using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;

namespace Taxi.Controls.Configs
{
    public partial class frmConfigCommon : FormBase
    {
        private ConfigCommonEntity _configCommon;
        public frmConfigCommon()
        {
            InitializeComponent();
            _configCommon = new ConfigCommonEntity();
        }

        private void frmConfigCommon_Load(object sender, System.EventArgs e)
        {
            gridConfig.DataSource = _configCommon.GetAll();
        }

        private void gridViewConfig_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRow row = ((DataRowView) e.Row).Row;
            if (row != null)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    string conFirm = new MessageBox.MessageBoxBA().Show("Bạn có muốn sửa thông tin cấu hình?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo, MessageBox.MessageBoxIconBA.Question);
                    if (conFirm == "Yes")
                    {
                        _configCommon.Id = int.Parse(row["Id"].ToString());
                        _configCommon.Name = row["Name"].ToString();
                        _configCommon.HasValue = row["HasValue"].ToString();
                        _configCommon.Description = row["Description"].ToString();
                        _configCommon.LastUpdate = CommonBL.GetTimeServer();
                        _configCommon.Update();
                        gridViewConfig.RefreshData();    
                    }                                   
                }
            }
            else
            {
                gridConfig.DataSource = _configCommon.GetAll();
            }
        }

        private void gridViewConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var temp=gridViewConfig.GetSelectedRows();
            }
        }

    }
}
