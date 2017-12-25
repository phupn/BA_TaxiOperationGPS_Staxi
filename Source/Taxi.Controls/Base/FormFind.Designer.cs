namespace Taxi.Controls.Base
{
    partial class FormFind
    {
        public FormFind()
        {
            InitializeComponent();
        }
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
            this.panelInputFind = new Taxi.Controls.Base.Controls.ShPanel();
            this.panelAction = new System.Windows.Forms.Panel();
            this.lblMessage = new Taxi.Controls.Base.Controls.ShLabel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new Taxi.Controls.Base.Controls.ShButton();
            this.btnTimKiem = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLamMoi = new Taxi.Controls.Base.Controls.ShButton();
            this.panelView = new System.Windows.Forms.Panel();
            this.grBTimKiem = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).BeginInit();
            this.panelAction.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.grBTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInputFind
            // 
            this.panelInputFind.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelInputFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInputFind.LabelMessage = null;
            this.panelInputFind.Location = new System.Drawing.Point(3, 16);
            this.panelInputFind.Name = "panelInputFind";
            this.panelInputFind.Size = new System.Drawing.Size(695, 81);
            this.panelInputFind.TabIndex = 1;
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.lblMessage);
            this.panelAction.Controls.Add(this.panelButton);
            this.panelAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAction.Location = new System.Drawing.Point(0, 100);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(701, 47);
            this.panelAction.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(313, 29);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(60, 14);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Thông báo";
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnXuatExcel);
            this.panelButton.Controls.Add(this.btnTimKiem);
            this.panelButton.Controls.Add(this.btnLamMoi);
            this.panelButton.Location = new System.Drawing.Point(224, 1);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(250, 27);
            this.panelButton.TabIndex = 1;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Enabled = false;
            this.btnXuatExcel.KeyCommand = System.Windows.Forms.Keys.F7;
            this.btnXuatExcel.Location = new System.Drawing.Point(165, 2);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(81, 23);
            this.btnXuatExcel.TabIndex = 2;
            this.btnXuatExcel.Text = "Xuất Excel (F6)";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.KeyCommand = System.Windows.Forms.Keys.F3;
            this.btnTimKiem.Location = new System.Drawing.Point(3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm (F3)";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.KeyCommand = System.Windows.Forms.Keys.F5;
            this.btnLamMoi.Location = new System.Drawing.Point(84, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới (F5)";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // panelView
            // 
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 147);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(701, 331);
            this.panelView.TabIndex = 2;
            // 
            // grBTimKiem
            // 
            this.grBTimKiem.Controls.Add(this.panelInputFind);
            this.grBTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grBTimKiem.Location = new System.Drawing.Point(0, 0);
            this.grBTimKiem.Name = "grBTimKiem";
            this.grBTimKiem.Size = new System.Drawing.Size(701, 100);
            this.grBTimKiem.TabIndex = 0;
            this.grBTimKiem.TabStop = false;
            this.grBTimKiem.Text = "Tìm kiếm thông tin";
            // 
            // FormFind
            // 
            this.AcceptButton = this.btnTimKiem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 478);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.grBTimKiem);
            this.Name = "FormFind";
            this.Text = "FormFind";
            this.Load += new System.EventHandler(this.FormFind_Load);
            this.SizeChanged += new System.EventHandler(this.FormFind_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).EndInit();
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.grBTimKiem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ShLabel lblMessage;
        private Controls.ShButton btnXuatExcel;
        private Controls.ShButton btnTimKiem;
        private Controls.ShButton btnLamMoi;
        public System.Windows.Forms.Panel panelButton;
        public Controls.ShPanel panelInputFind;
        public System.Windows.Forms.Panel panelAction;
        public System.Windows.Forms.Panel panelView;
        public System.Windows.Forms.GroupBox grBTimKiem;
    }
}