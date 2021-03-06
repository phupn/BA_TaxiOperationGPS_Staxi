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
    public partial class ListMessageTemplate : Form
    {
        public delegate void GetMessageTemplate(string subject,string contents);
        public GetMessageTemplate MyGetMessageTemplate;

        public ListMessageTemplate()
        {
            InitializeComponent();
        }

        private void ListMessageTemplate_Load(object sender, EventArgs e)
        {
            reloadDataGrid();
        }

        private void reloadDataGrid()
        {
            DataTable dt = new DataTable();
            dt = new Chatting().SelectMessageTemplate();

            dgvListMessageTemplate.DataSource = dt;

            if (dgvListMessageTemplate.RowCount > 0)
            {
                dgvListMessageTemplate.Columns[0].Visible = false;
                dgvListMessageTemplate.Columns[1].HeaderText = "Tiêu đề";
                dgvListMessageTemplate.Columns[1].Width = 200;

                dgvListMessageTemplate.Columns[2].HeaderText = "Nội dung";
                dgvListMessageTemplate.Columns[2].Width = 340;
            }
        }

        private void dgvListMessageTemplate_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string subject = dgvListMessageTemplate.Rows[e.RowIndex].Cells[1].Value.ToString();
            string contents = dgvListMessageTemplate.Rows[e.RowIndex].Cells[2].Value.ToString();
            MyGetMessageTemplate(subject, contents);
            this.Close();
        }       
    }
}