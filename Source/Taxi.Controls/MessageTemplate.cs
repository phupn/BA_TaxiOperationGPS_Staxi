using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.Controls
{
    public partial class MessageTemplate : UserControl
    {
        private int idMessage = 0;

        public MessageTemplate()
        {
            InitializeComponent();
        }

        private void MessageTemplate_Load(object sender, EventArgs e)
        {
            reloadDataGrid();
        }

        private void reloadDataGrid()
        {
            DataTable dt = new DataTable();
            dt = new Chatting().SelectMessageTemplate();

            dgvMessageTemplate.DataSource = dt;
            
            if (dgvMessageTemplate.RowCount > 0)
            {
                dgvMessageTemplate.Columns[0].Visible = true;
                dgvMessageTemplate.Columns[0].Resizable = DataGridViewTriState.False;
                dgvMessageTemplate.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvMessageTemplate.Columns[0].Width = 0;

                dgvMessageTemplate.Columns[1].HeaderText = "Tiêu đề";
                dgvMessageTemplate.Columns[1].Width = 200;

                dgvMessageTemplate.Columns[2].HeaderText = "Nội dung";
                dgvMessageTemplate.Columns[2].Width = 315;
            }
            refreshForm();
        }

        private void refreshForm()
        {
            txtSubject.Text = "";
            txtContents.Text = "";
            idMessage = 0;
        }

        private void setDataSelected_gv(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                idMessage = Convert.ToInt32(dgvMessageTemplate.Rows[rowIndex].Cells[0].Value.ToString());
                txtSubject.Text = dgvMessageTemplate.Rows[rowIndex].Cells[1].Value.ToString();
                txtContents.Text = dgvMessageTemplate.Rows[rowIndex].Cells[2].Value.ToString();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    btnSave_Click(this, null);
                    return true;
                case Keys.Delete:
                    btnDelete_Click(this, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Subject = txtSubject.Text.Trim();
            string Contents = txtContents.Text.Trim();
            if (Contents.Equals(""))
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa nhập nội dung tin nhắn", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                txtContents.Focus();
            }
            else if (idMessage == 0)
            {
                if (new Chatting().Insert_MessageTemplate(Subject, Contents))
                {
                    new MessageBox.MessageBoxBA().Show("Thêm mới tin nhắn mẫu thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    reloadDataGrid();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Thêm mới tin nhắn mẫu thất bại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            else
            {
                if (new Chatting().Update_MessageTemplate(idMessage, Subject, Contents))
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật tin nhắn mẫu thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    reloadDataGrid();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật tin nhắn mẫu thất bại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {
           string confirm =  new MessageBox.MessageBoxBA().Show("Bạn có muốn xóa tin nhắn mẫu không ?", "Thông báo", 
                Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question);
           if (confirm.Equals("OK"))
           {
               if (new Chatting().Delete_MessageTemplate(idMessage))
               {
                   new MessageBox.MessageBoxBA().Show("Xóa tin nhắn mẫu thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                   reloadDataGrid();
               }
               else
               {
                   new MessageBox.MessageBoxBA().Show("Xóa tin nhắn mẫu thất bại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
               }
           }

        }

        private void dgvMessageTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            setDataSelected_gv(dgvMessageTemplate.CurrentRow.Index);
        }

        private void dgvMessageTemplate_KeyUp(object sender, KeyEventArgs e)
        {
            setDataSelected_gv(dgvMessageTemplate.CurrentRow.Index);
        }

        private void dgvMessageTemplate_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            setDataSelected_gv(e.RowIndex);
        }
    }
}
