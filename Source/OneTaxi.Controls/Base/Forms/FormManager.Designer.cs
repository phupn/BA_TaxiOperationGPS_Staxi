namespace OneTaxi.Controls.Base.Forms
{
    partial class FormManager
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
            this.panelControl2 = new OneTaxi.Controls.Base.Controls.PanelControl();
            this.btnExportExcel = new OneTaxi.Controls.Base.Controls.Button();
            this.btnRefresh = new OneTaxi.Controls.Base.Controls.Button();
            this.btnFind = new OneTaxi.Controls.Base.Controls.Button();
            this.btnRemove = new OneTaxi.Controls.Base.Controls.Button();
            this.btnEdit = new OneTaxi.Controls.Base.Controls.Button();
            this.btnAdd = new OneTaxi.Controls.Base.Controls.Button();
            this.lblMsg = new OneTaxi.Controls.Base.Controls.Label();
            this.panelView = new OneTaxi.Controls.Base.Controls.PanelControl();
            this.panelFind = new OneTaxi.Controls.Base.Controls.PanelInput();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFind)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnExportExcel);
            this.panelControl2.Controls.Add(this.btnRefresh);
            this.panelControl2.Controls.Add(this.btnFind);
            this.panelControl2.Controls.Add(this.btnRemove);
            this.panelControl2.Controls.Add(this.btnEdit);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Controls.Add(this.lblMsg);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 127);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(736, 66);
            this.panelControl2.TabIndex = 2;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnExportExcel.Location = new System.Drawing.Point(533, 7);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.TagLanguage = null;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnRefresh.Location = new System.Drawing.Point(452, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.TagLanguage = null;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnFind
            // 
            this.btnFind.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnFind.Location = new System.Drawing.Point(371, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.TagLanguage = null;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnRemove.Location = new System.Drawing.Point(290, 7);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.TagLanguage = null;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnEdit.Location = new System.Drawing.Point(209, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.TagLanguage = null;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnAdd.Location = new System.Drawing.Point(128, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TagLanguage = null;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(243, 46);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(64, 13);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.TagLanguage = null;
            this.lblMsg.Text = "Thông báo lỗi";
            // 
            // panelView
            // 
            this.panelView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 193);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(736, 367);
            this.panelView.TabIndex = 3;
            // 
            // panelFind
            // 
            this.panelFind.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFind.LabelMessage = null;
            this.panelFind.Location = new System.Drawing.Point(0, 27);
            this.panelFind.Name = "panelFind";
            this.panelFind.Size = new System.Drawing.Size(736, 100);
            this.panelFind.TabIndex = 4;
            // 
            // FormManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 560);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelFind);
            this.Name = "FormManager";
            this.Text = "FormManager";
            this.Controls.SetChildIndex(this.panelFind, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.panelView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PanelControl panelControl2;
        private Controls.PanelControl panelView;
        private Controls.Label lblMsg;
        private Controls.Button btnAdd;
        private Controls.Button btnEdit;
        private Controls.Button btnFind;
        private Controls.Button btnRemove;
        private Controls.Button btnRefresh;
        private Controls.Button btnExportExcel;
        public Controls.PanelInput panelFind;
    }
}