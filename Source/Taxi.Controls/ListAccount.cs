using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.Controls
{
    public partial class ListAccount : Form
    {
        DataTable dtListAccount;
        SendMessage frmSendMessage;
        //string a;
        private string ToAccount = "";

        public delegate void GetMessage(string mess);
        public GetMessage MyGetMessage;

        public ListAccount()
        {
            InitializeComponent();
        }

        private void ListAccount_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.Name = "choose";
            check.HeaderText = "Chọn";
            check.TrueValue = true;
            check.FalseValue = false;
            check.ThreeState = false;
            check.ReadOnly = false;
            check.Width = 50;
            dgvListAccount.Columns.Insert(0, check);

            dtListAccount = new Chatting().SelectUserCheckIn();
            dgvListAccount.DataSource = dtListAccount;

            dgvListAccount.Columns[1].Visible = false;
            dgvListAccount.Columns[2].HeaderText = "Tài khoản";
            dgvListAccount.Columns[2].Width = 125;

            dgvListAccount.Columns[3].HeaderText = "Họ tên";
            dgvListAccount.Columns[3].Width = 195;

            dgvListAccount.Columns[4].Visible = false;

            dgvListAccount.Columns[5].HeaderText = "Line/Vùng";
            dgvListAccount.Columns[5].Width = 125;

            dgvListAccount.Columns[6].HeaderText = "Máy";
            dgvListAccount.Columns[6].Width = 125;
        }

        private DataTable dtAccountCheckIn()
        {
            DataTable dtReturn = new DataTable();
            DataTable dt = new Chatting().SelectUserCheckIn();
            dtReturn = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                string vung_line = dr["Line_Vung"].ToString();
                if (vung_line.Contains(";"))
                {
                    string[] arrVung_Line = vung_line.Split(';');
                    if (arrVung_Line.Length > 0)
                    {
                        for (int i = 0; i < arrVung_Line.Length; i++)
                        {
                            dr["Line_Vung"] = arrVung_Line[i];
                            dtReturn.Rows.Add(dr.ItemArray);
                        }
                    }
                }
                else
                {
                    dtReturn.Rows.Add(dr.ItemArray);
                }
            }
            return dtReturn;
        }

        private void btnChooseAll_Click(object sender, EventArgs e)
        {
            if (btnChooseAll.Text.Equals("&Chọn tất cả"))
            {
                for (int i = 0; i < dgvListAccount.Rows.Count; i++)
                {
                    dgvListAccount.Rows[i].Cells[0].Value = true;
                }
                btnChooseAll.Text = "Bỏ &chọn";
            }
            else
            {
                for (int i = 0; i < dgvListAccount.Rows.Count; i++)
                {
                    dgvListAccount.Rows[i].Cells[0].Value = false;
                }
                btnChooseAll.Text = "&Chọn tất cả";
            }

        }

        private void txtUserNameFilter_TextChanged(object sender, EventArgs e)
        {
            filterDataGridview("Username", txtUserNameFilter.Text.Trim());
        }

        private void txtFullNameFilter_TextChanged(object sender, EventArgs e)
        {
            filterDataGridview("FULLNAME", txtFullNameFilter.Text.Trim());
        }

        private void txtLineVungFilter_TextChanged(object sender, EventArgs e)
        {
            filterDataGridview("Line_Vung", txtLineVungFilter.Text.Trim());
        }

        private void filterDataGridview(string colName, string filterValue)
        {
            DataTable dt = (DataTable)dgvListAccount.DataSource;
            DataView dv = dt.DefaultView;
            dv.RowFilter = colName + " like " + "'%" + filterValue + "%'";
            dgvListAccount.DataSource = dv.Table;
        }

        private void dgvListAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int rowIndex = e.RowIndex;
                if (dgvListAccount.Rows[rowIndex].Cells[0].Value != null)
                {
                    if ((bool)dgvListAccount.Rows[rowIndex].Cells[0].Value)
                    {
                        dgvListAccount.Rows[rowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        dgvListAccount.Rows[rowIndex].Cells[0].Value = true;
                    }
                }
                else
                {
                    dgvListAccount.Rows[rowIndex].Cells[0].Value = true;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvListAccount.Rows.Count; i++)
            {
                if (dgvListAccount.Rows[i].Cells[0].Value != null
                               && (bool)dgvListAccount.Rows[i].Cells[0].Value == true)
                {
                    string account = dgvListAccount.Rows[i].Cells[2].Value + " - "+ dgvListAccount.Rows[i].Cells[3].Value;
                    if(!ToAccount.Contains(account))
                    {
                        ToAccount += account + ";";
                    }
                }
            }
            MyGetMessage(ToAccount);           
            this.Close();
        }

    }
}