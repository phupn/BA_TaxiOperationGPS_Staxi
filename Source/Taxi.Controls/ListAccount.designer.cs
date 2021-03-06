namespace Taxi.Controls
{
    partial class ListAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListAccount));
            this.dgvListAccount = new System.Windows.Forms.DataGridView();
            this.txtUserNameFilter = new System.Windows.Forms.TextBox();
            this.txtFullNameFilter = new System.Windows.Forms.TextBox();
            this.txtLineVungFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnChooseAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListAccount
            // 
            this.dgvListAccount.AllowUserToAddRows = false;
            this.dgvListAccount.AllowUserToDeleteRows = false;
            this.dgvListAccount.AllowUserToOrderColumns = true;
            this.dgvListAccount.AllowUserToResizeColumns = false;
            this.dgvListAccount.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListAccount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListAccount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListAccount.Location = new System.Drawing.Point(0, 25);
            this.dgvListAccount.Name = "dgvListAccount";
            this.dgvListAccount.ReadOnly = true;
            this.dgvListAccount.RowHeadersVisible = false;
            this.dgvListAccount.RowHeadersWidth = 5;
            this.dgvListAccount.RowTemplate.Height = 25;
            this.dgvListAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListAccount.Size = new System.Drawing.Size(619, 489);
            this.dgvListAccount.TabIndex = 3;
            this.dgvListAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListAccount_CellClick);
            // 
            // txtUserNameFilter
            // 
            this.txtUserNameFilter.Location = new System.Drawing.Point(51, 5);
            this.txtUserNameFilter.Name = "txtUserNameFilter";
            this.txtUserNameFilter.Size = new System.Drawing.Size(125, 20);
            this.txtUserNameFilter.TabIndex = 4;
            this.txtUserNameFilter.TextChanged += new System.EventHandler(this.txtUserNameFilter_TextChanged);
            // 
            // txtFullNameFilter
            // 
            this.txtFullNameFilter.Location = new System.Drawing.Point(176, 5);
            this.txtFullNameFilter.Name = "txtFullNameFilter";
            this.txtFullNameFilter.Size = new System.Drawing.Size(175, 20);
            this.txtFullNameFilter.TabIndex = 5;
            this.txtFullNameFilter.TextChanged += new System.EventHandler(this.txtFullNameFilter_TextChanged);
            // 
            // txtLineVungFilter
            // 
            this.txtLineVungFilter.Location = new System.Drawing.Point(351, 5);
            this.txtLineVungFilter.Name = "txtLineVungFilter";
            this.txtLineVungFilter.Size = new System.Drawing.Size(125, 20);
            this.txtLineVungFilter.TabIndex = 6;
            this.txtLineVungFilter.TextChanged += new System.EventHandler(this.txtLineVungFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Lọc :";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(567, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(40, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "&Xong";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnChooseAll
            // 
            this.btnChooseAll.Location = new System.Drawing.Point(482, 3);
            this.btnChooseAll.Name = "btnChooseAll";
            this.btnChooseAll.Size = new System.Drawing.Size(79, 23);
            this.btnChooseAll.TabIndex = 10;
            this.btnChooseAll.Text = "&Chọn tất cả";
            this.btnChooseAll.UseVisualStyleBackColor = true;
            this.btnChooseAll.Click += new System.EventHandler(this.btnChooseAll_Click);
            // 
            // ListAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 514);
            this.Controls.Add(this.btnChooseAll);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLineVungFilter);
            this.Controls.Add(this.txtFullNameFilter);
            this.Controls.Add(this.txtUserNameFilter);
            this.Controls.Add(this.dgvListAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListAccount";
            this.Text = "Danh sách nhân viên đang sử dụng hệ thống";
            this.Load += new System.EventHandler(this.ListAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListAccount;
        private System.Windows.Forms.TextBox txtUserNameFilter;
        private System.Windows.Forms.TextBox txtFullNameFilter;
        private System.Windows.Forms.TextBox txtLineVungFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnChooseAll;

    }
}