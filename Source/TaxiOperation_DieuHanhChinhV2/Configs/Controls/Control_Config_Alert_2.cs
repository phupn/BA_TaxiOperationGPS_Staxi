using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace TaxiOperation_BanCo.Controls.Config
{
    public partial class Control_Config_Alert_2 : UserControl
    {
        public Control_Config_Alert_2()
        {
            InitializeComponent();
            this.ContextMenu = mainCTMN;
           
        }
        ConfigurationStatusModel objConfigurationStatus;// = new ConfigurationStatusModel();
        private void ControlConfigAlert_Load(object sender, EventArgs e)
        {
            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            objConfigurationStatus = new ConfigurationStatusModel();           
            grcAlert.DataSource = objConfigurationStatus.GetAllData_Datatable();
        }

        private void grvAlert_RowUpdated(object sender, RowObjectEventArgs e)
        {
            //ConfigurationStatusModel objConfigurationStatus = new ConfigurationStatusModel();
            DataRow row = ((DataRowView)e.Row).Row;
            if (row != null)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    objConfigurationStatus.Id = byte.Parse(row["Id"].ToString());
                    objConfigurationStatus.Name = (row["Name"].ToString());
                    objConfigurationStatus.Value = row["Value"].ToString();
                    objConfigurationStatus.Type = (byte)1;
                    objConfigurationStatus.Notify = (bool)row["Notify"];
                    objConfigurationStatus.DateCreated = Convert.ToDateTime(row["DateCreated"].ToString());
                    objConfigurationStatus.Description = row["Description"].ToString();
                    objConfigurationStatus.Update();
                    grvAlert.RefreshData();
                }
                else if (row.RowState == DataRowState.Added)
                {
                    try
                    {
                        objConfigurationStatus.Name = (row["Name"].ToString());
                        objConfigurationStatus.Value = row["Value"].ToString();
                        objConfigurationStatus.Type = (byte)1;
                        objConfigurationStatus.Notify = row["Notify"] == null || row["Notify"].Equals(DBNull.Value) ? false : (bool)row["Notify"];
                        //objConfigurationStatus.Notify = (bool)row["Notify"];
                        objConfigurationStatus.DateCreated = row["DateCreated"] == null || row["DateCreated"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(row["DateCreated"].ToString());
                        objConfigurationStatus.Description = row["Description"].ToString();
                        objConfigurationStatus.Save();

                        // Sơn PC => fix lỗi, thêm mới xong phải lấy lại Id thì mới xóa được chứ
                        row["Id"] = objConfigurationStatus.Id;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            ((DataRowView)e.Row).Row.Table.Rows.Remove(row);
                        }
                        catch { }
                    }
                    grvAlert.RefreshData();
                }
            }
            else
            {
                grvAlert.RefreshData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xoá bản ghi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;
            int[] rows = grvAlert.GetSelectedRows();
            foreach (var i in rows)
            {
                DataRow dtr = grvAlert.GetDataRow(i);
                objConfigurationStatus.Id = byte.Parse(dtr.ItemArray[0].ToString());

                // Sơn PC rem => ai cản
                //objConfigurationStatus.Name = dtr.ItemArray[1].ToString();
                //objConfigurationStatus.Value = dtr.ItemArray[2].ToString();
                //objConfigurationStatus.Notify = (bool)dtr.ItemArray[3];
                //objConfigurationStatus.DateCreated = Convert.ToDateTime(dtr.ItemArray[5].ToString());
                //objConfigurationStatus.Description = dtr.ItemArray[6].ToString();

                int count = objConfigurationStatus.Delete();
            }
            ControlConfigAlert_Load(null, null);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            grcAlert.Size = new System.Drawing.Size(grcAlert.Size.Width, this.Size.Height - 62);
            base.OnSizeChanged(e);
        }
    }
}