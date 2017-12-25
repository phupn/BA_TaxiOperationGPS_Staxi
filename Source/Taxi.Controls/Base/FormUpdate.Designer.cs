using Taxi.Common.DbBase;

namespace Taxi.Controls.Base
{
    partial class FormUpdate
    {
        public FormUpdate()
        {
            InitializeComponent();
        }
        public FormUpdate(ModelBase model)
        {
            InitializeComponent();
            this._model = model;
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnUpdate = new Taxi.Controls.Base.Controls.ShButton();
            this.lblMessage = new Taxi.Controls.Base.Controls.ShLabel();
            this.panelInputView = new Taxi.Controls.Base.Controls.ShPanel();
            this.panel1.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelButton);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 50);
            this.panel1.TabIndex = 0;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnThoat);
            this.panelButton.Controls.Add(this.btnUpdate);
            this.panelButton.Location = new System.Drawing.Point(123, 19);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(197, 25);
            this.panelButton.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(111, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(83, 23);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Esc - Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnUpdate.Location = new System.Drawing.Point(3, 1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "F2 - Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(191, 3);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(60, 14);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Thông báo";
            // 
            // panelInputView
            // 
            this.panelInputView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelInputView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInputView.LabelMessage = null;
            this.panelInputView.Location = new System.Drawing.Point(0, 0);
            this.panelInputView.Name = "panelInputView";
            this.panelInputView.Size = new System.Drawing.Size(442, 323);
            this.panelInputView.TabIndex = 1;
            // 
            // FormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 373);
            this.Controls.Add(this.panelInputView);
            this.Controls.Add(this.panel1);
            this.Name = "FormUpdate";
            this.Text = "FormUpdate";
            this.Load += new System.EventHandler(this.FormUpdate_Load);
            this.Resize += new System.EventHandler(this.FormUpdate_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.ShButton btnThoat;
        protected Controls.ShButton btnUpdate;
        private Controls.ShLabel lblMessage;
        public Controls.ShPanel panelInputView;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelButton;
    }
}