using StaxiMan_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Taxi.Logger;
using Taxi.MessageBox;
using Taxi.Common.Extender;

namespace StaxiMan
{
    public partial class Company_Form : StaxiMan_FormBase
    {
        private Company _objCompany;
        private DataTable lstCompany;
        public Company_Form()
        {
            InitializeComponent();
        }

        private void Company_Form_Load(object sender, EventArgs e)
        {
            LoadData();
            _objCompany = new Company();
        }

        private void LoadData()
        {                
            lstCompany = Company.Inst.GetListAll_NotParentCompany();
            gridControl_Origin.DataSource = lstCompany; 
        }

        private void gridView_Origin_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                if (e.Row == null) return;

                DataRow row = ((DataRowView)e.Row).Row;
                if (row != null)
                {
                    if (!CheckValid(row))
                    {
                        ((DataRowView)e.Row).Row.Table.Rows.Remove(row);
                        return;
                    }

                    if (row.RowState == DataRowState.Modified)
                    {
                        _objCompany.Id = (int)row["Id"];
                        _objCompany.UpdatedDate = DateTime.Now;
                        _objCompany.CreatedDate = (DateTime)row["CreatedDate"];
                        _objCompany.DeployDate = (DateTime)row["DeployDate"];
                        _objCompany.Hotline = row["Hotline"].ToString();
                        _objCompany.Name = row["Name"].ToString();
                        _objCompany.XNCode = (int)row["XNCode"];
                        _objCompany.CompanyId = _objCompany.XNCode;
                        _objCompany.Update();
                        row["UpdatedDate"] = _objCompany.UpdatedDate;
                        gridView_Origin.RefreshData();
                    }
                    else if (row.RowState == DataRowState.Added)
                    {
                        try
                        {
                            _objCompany.CreatedDate = DateTime.Now;
                            _objCompany.UpdatedDate = null;
                            _objCompany.DeployDate = (DateTime)row["DeployDate"];
                            _objCompany.Hotline = row["Hotline"].ToString();
                            _objCompany.Name = row["Name"].ToString();
                            _objCompany.XNCode = (int)row["XNCode"];
                            _objCompany.CompanyId = _objCompany.XNCode;
                            _objCompany.Save();

                            row["Id"] = _objCompany.Id;
                            row["CreatedDate"] = _objCompany.CreatedDate;
                            gridView_Origin.RefreshData();
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                ((DataRowView)e.Row).Row.Table.Rows.Remove(row);
                            }
                            catch 
                            { }
                            LogError.WriteLogError("Company_Form gridView_Origin_RowUpdated", ex);
                        }
                    }
                }
                else
                {
                    gridView_Origin.RefreshData();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridView_Origin_RowUpdated: ", ex);                
            }
        }

        private bool CheckValid(DataRow pRow)
        {
            try
            {
                if (string.IsNullOrEmpty(pRow["XNCode"].ToString()))
                {
                    new MessageBoxBA().Show("Mã XNCode không được để trống!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                    return false;
                }
                string xnCode = pRow["XNCode"].ToString();
                if (ExistXNCode(xnCode))
                {
                    new MessageBoxBA().Show("XNCode không được trùng với các XNCode đã có!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                    return false;
                }
                else if (xnCode == "0")
                {
                    new MessageBoxBA().Show("Nếu hãng chưa có XNCode thì vui lòng nhập -1","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                    
                    return false;                    
                }

                if (string.IsNullOrEmpty(pRow["Hotline"].ToString()))
                {
                    new MessageBoxBA().Show("Số điện thoại hotline không được để trống!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                    return false;
                }
                if (string.IsNullOrEmpty(pRow["Name"].ToString()))
                {
                    new MessageBoxBA().Show("Tên công ty không được để trống!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    return false;
                }
                if (string.IsNullOrEmpty(pRow["DeployDate"].ToString()))
                {
                    new MessageBoxBA().Show("Ngày triển khai không được để trống!","Thông báo",MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    return false; 
                }
            }
            catch(Exception ex)
            {
                new MessageBoxBA().Show("Lỗi khi thao tác dữ liệu! " + ex.Message,"Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                return false;
            }

            return true;
        }

        private bool ExistXNCode(string xnCode)
        {
            if (Company.Inst.GetListAll().Exists(a => a.XNCode.ToString() == xnCode))
                return true;
            return false;
        }

        private void gridView_Origin_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (MessageBox.Show("Are you delete ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }

            try
            {
                DataRow row =((DataRowView)e.Row).Row;                
                if (row != null)
                {
                    _objCompany.Id = (int)row["Id"];
                    _objCompany.UpdatedDate = DateTime.Now;
                    _objCompany.Delete();                    
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridView_Origin_RowDeleted: ", ex);
            }
        }

        private void gridView_Origin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView_Origin.DeleteRow(gridView_Origin.FocusedRowHandle);
                LoadData();
            }
        }
    }
}
