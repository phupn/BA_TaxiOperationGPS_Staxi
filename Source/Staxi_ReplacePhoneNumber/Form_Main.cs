using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staxi_ReplacePhoneNumber
{
    public partial class Form_Main : Form
    {
        private string TableName { get; set; }
        private string ColumnName { get; set; }

        public Form_Main()
        {
            InitializeComponent();
            Icon = Staxi_ReplacePhoneNumber.Properties.Resources.Staxi_96_ic_launcher;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            LoadTableName();
        }

        private void LoadTableName()
        {
            try
            {
                DataTable lstTableName = DBServices.Inst.GetAllTableName();
                if (lstTableName != null)
                {
                    lookUpEdit_Table.Properties.DataSource = lstTableName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load table rồi : " + ex.Message);
            }
        }

        private void LoadColumnName()
        {
            try
            {
                if (lookUpEdit_Table.EditValue != null)
                {
                    TableName = lookUpEdit_Table.EditValue.ToString();
                    DataTable lstTableName = DBServices.Inst.GetAllColumnByTableName(TableName);
                    if (lstTableName != null)
                    {
                        lookUpEdit_Column.Properties.DataSource = lstTableName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load column rồi : " + ex.Message);
            }
        }

        private void LoadDataOrigin()
        {
            try
            {
                if (TableName != null && TableName != "")
                {
                    gridControl_Origin.DataSource = null;
                    gridControl_Origin.Refresh();
                    gridView_Origin.Columns.Clear();
                    gridControl_Origin.RefreshDataSource();
                    gridControl_Origin.DataSource = DBServices.Inst.GetData_Table(TableName);
                }
                else
                {
                    gridControl_Origin.RefreshDataSource();
                    gridControl_Origin.DataSource = null;
                    gridControl_Origin.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load data rồi : " + ex.Message);
            }
        }

        private void LoadDataOrigin_Review(string value, string replace)
        {
            try
            {
                if (TableName != null && TableName != "" && ColumnName != null && ColumnName != "")
                {
                    gridControl_Origin.DataSource = null;
                    gridControl_Origin.Refresh();
                    gridView_Origin.Columns.Clear();
                    gridControl_Origin.RefreshDataSource();
                    gridControl_Origin.DataSource = DBServices.Inst.GetData_Table(TableName, ColumnName, value, replace);
                }
                else
                {
                    gridControl_Origin.RefreshDataSource();
                    gridControl_Origin.DataSource = null;
                    gridControl_Origin.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load data rồi : " + ex.Message);
            }
        }
        private void LoadDataReplace(string value, string replace)
        {
            try
            {
                lblMsg.Text = "";
                if (TableName != null && TableName != "" && ColumnName != null && ColumnName != "")
                {
                    gridControl_Replace.DataSource = null;
                    gridControl_Replace.Refresh();
                    gridView_Replace.Columns.Clear();
                    gridControl_Replace.RefreshDataSource();
                    gridControl_Replace.DataSource = DBServices.Inst.GetData_Table_Column(TableName, ColumnName, value, replace);
                }
                else
                {
                    gridControl_Replace.RefreshDataSource();
                    gridControl_Replace.DataSource = null;
                    gridControl_Replace.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load data rồi : " + ex.Message);
            }
        }

        //protected override void RaiseCustomDrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        //{
        //    //// Sự kiện lớp base
        //    //base.RaiseCustomDrawRowIndicator(e);
        //    //e.Info.Appearance.Font = new Font(e.Info.Appearance.Font.FontFamily, e.Info.Appearance.Font.Size);
        //    //e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
        //    //e.Info.Appearance.TextOptions.VAlignment = VertAlignment.Center;
        //    //// Hiển thị số thứ tự

        //    //if (e.Info.IsRowIndicator && e.RowHandle >= 0)
        //    //{
        //    //    e.Info.DisplayText = (e.RowHandle + 1).ToString();
        //    //}
        //    //else if (!e.Info.IsRowIndicator && e.RowHandle < 0 && e.Info.IsTopMost)
        //    //{
        //    //    e.Info.DisplayText = "STT";
        //    //}
        //}
        private void lookUpEdit_Table_EditValueChanged(object sender, EventArgs e)
        {
            LoadColumnName();
            LoadDataOrigin();
            lblMsg.Text = "";
            btnReplace.Enabled = false;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (ColumnName != null && ColumnName != "" && TableName != null && TableName != "" && txtReplace.Text != "" && txtValue.Text != "")
                {
                    btnReplace.Enabled = false;
                    string value = txtValue.Text.Trim();
                    string replace = txtReplace.Text.Trim();
                    
                    if (MessageBox.Show("Bạn có chắc chắc thay thế giá trị [" + value + "] bằng giá trị [" + replace + "] không ?", "Hỏi xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if(DBServices.Inst.ReplaceData(TableName, ColumnName, value, replace))
                        {
                            MessageBox.Show("Replace thành công rồi nhé");
                        }
                        else
                        {
                            MessageBox.Show("Không replace data được rồi");
                            gridControl_Replace.RefreshDataSource();
                            gridControl_Replace.DataSource = null;
                            gridControl_Replace.Refresh();
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Vui lòng điền đầy đủ thông tin trước khi Replace";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Update data rồi : " + ex.Message);
            }
        }

        private void lookUpEdit_Column_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_Table.EditValue != null)
            {
                ColumnName = lookUpEdit_Column.EditValue.ToString();
                lblMsg.Text = "";
            }
            btnReplace.Enabled = false;
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (ColumnName != null && ColumnName != "" && TableName != null && TableName != "" && txtReplace.Text != "" && txtValue.Text != "")
            {
                string value = txtValue.Text.Trim();
                string replace = txtReplace.Text.Trim();
                LoadDataReplace(value, replace);
                LoadDataOrigin_Review(value, replace);
                btnReplace.Enabled = true;
            }
            else
            {
                lblMsg.Text = "Vui lòng nhập đủ thông tin trước khi review!";
            }
        }

        private void gridView_Origin_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            e.Info.Appearance.Font = new Font(e.Info.Appearance.Font.FontFamily, e.Info.Appearance.Font.Size);
            e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            e.Info.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            // Hiển thị số thứ tự

            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
            else if (!e.Info.IsRowIndicator && e.RowHandle < 0 && e.Info.IsTopMost)
            {
                e.Info.DisplayText = "STT";
            }
        }

        private void gridView_Replace_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            e.Info.Appearance.Font = new Font(e.Info.Appearance.Font.FontFamily, e.Info.Appearance.Font.Size);
            e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            e.Info.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            // Hiển thị số thứ tự

            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
            else if (!e.Info.IsRowIndicator && e.RowHandle < 0 && e.Info.IsTopMost)
            {
                e.Info.DisplayText = "STT";
            }
        }
    }
}
