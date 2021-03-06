namespace Taxi.Controls
{
    partial class MessageTemplate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMessageTemplate = new System.Windows.Forms.DataGridView();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMessageTemplate
            // 
            this.dgvMessageTemplate.AllowUserToAddRows = false;
            this.dgvMessageTemplate.AllowUserToDeleteRows = false;
            this.dgvMessageTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessageTemplate.Location = new System.Drawing.Point(3, 82);
            this.dgvMessageTemplate.MultiSelect = false;
            this.dgvMessageTemplate.Name = "dgvMessageTemplate";
            this.dgvMessageTemplate.ReadOnly = true;
            this.dgvMessageTemplate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessageTemplate.Size = new System.Drawing.Size(561, 220);
            this.dgvMessageTemplate.TabIndex = 4;
            this.dgvMessageTemplate.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMessageTemplate_CellMouseClick);
            this.dgvMessageTemplate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMessageTemplate_KeyDown);
            this.dgvMessageTemplate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvMessageTemplate_KeyUp);
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(59, 1);
            this.txtSubject.MaxLength = 100;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(423, 20);
            this.txtSubject.TabIndex = 0;
            // 
            // txtContents
            // 
            this.txtContents.Location = new System.Drawing.Point(59, 27);
            this.txtContents.MaxLength = 1000;
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.Size = new System.Drawing.Size(423, 49);
            this.txtContents.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(488, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu (Enter)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tiêu đề";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nội dung";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(488, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Nhập lại";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(488, 27);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa (Del)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // MessageTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtContents);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.dgvMessageTemplate);
            this.Name = "MessageTemplate";
            this.Size = new System.Drawing.Size(567, 305);
            this.Load += new System.EventHandler(this.MessageTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMessageTemplate;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtContents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;


    }
}
