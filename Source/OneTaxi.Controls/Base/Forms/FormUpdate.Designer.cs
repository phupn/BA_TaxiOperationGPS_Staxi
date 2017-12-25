namespace OneTaxi.Controls.Base.Forms
{
    partial class FormUpdate
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
            this.panelView = new OneTaxi.Controls.Base.Controls.PanelInput();
            this.panelControl1 = new OneTaxi.Controls.Base.Controls.PanelControl();
            this.btnClose = new OneTaxi.Controls.Base.Controls.Button();
            this.btnSave = new OneTaxi.Controls.Base.Controls.Button();
            this.lblMsg = new OneTaxi.Controls.Base.Controls.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelView
            // 
            this.panelView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.LabelMessage = null;
            this.panelView.Location = new System.Drawing.Point(0, 27);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(513, 338);
            this.panelView.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.lblMsg);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 365);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(513, 57);
            this.panelControl1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnClose.Location = new System.Drawing.Point(247, 26);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.TagLanguage = null;
            this.btnClose.Text = "(Esc) - Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnSave.Location = new System.Drawing.Point(148, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.TagLanguage = null;
            this.btnSave.Text = "(F2) - Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(148, 7);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(64, 13);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.TagLanguage = null;
            this.lblMsg.Text = "Thông báo lỗi";
            // 
            // FormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 422);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormUpdate";
            this.Text = "FormUpdate";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PanelInput panelView;
        private Controls.PanelControl panelControl1;
        private Controls.Label lblMsg;
        private Controls.Button btnSave;
        private Controls.Button btnClose;
    }
}