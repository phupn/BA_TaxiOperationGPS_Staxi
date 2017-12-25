namespace Taxi.Controls
{
    partial class ctrlWelcome
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
            this.pnlWelcome = new DevExpress.XtraEditors.PanelControl();
            this.lblLoading = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.picture = new DevExpress.XtraEditors.PictureEdit();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWelcome)).BeginInit();
            this.pnlWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.Controls.Add(this.lblLoading);
            this.pnlWelcome.Controls.Add(this.lblTitle);
            this.pnlWelcome.Controls.Add(this.picture);
            this.pnlWelcome.Controls.Add(this.lblMessage);
            this.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWelcome.Location = new System.Drawing.Point(0, 0);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(473, 274);
            this.pnlWelcome.TabIndex = 25;
            this.pnlWelcome.Visible = false;
            // 
            // lblLoading
            // 
            this.lblLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoading.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblLoading.Appearance.Options.UseFont = true;
            this.lblLoading.Appearance.Options.UseForeColor = true;
            this.lblLoading.Location = new System.Drawing.Point(6, 251);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(104, 19);
            this.lblLoading.TabIndex = 3;
            this.lblLoading.Text = "Vui lòng chờ...";
            // 
            // lblTitle
            // 
            this.lblTitle.AllowDrop = true;
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblTitle.Location = new System.Drawing.Point(120, 36);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(347, 19);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Cám ơn bạn đã sử dụng phần mềm";
            this.lblTitle.UseWaitCursor = true;
            // 
            // picture
            // 
            this.picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picture.Cursor = System.Windows.Forms.Cursors.Default;
            this.picture.EditValue = global::Taxi.Controls.Properties.Resources.success_icon_151;
            this.picture.Location = new System.Drawing.Point(5, 3);
            this.picture.Name = "picture";
            this.picture.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picture.Properties.Appearance.Options.UseBackColor = true;
            this.picture.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picture.Properties.InitialImage = global::Taxi.Controls.Properties.Resources.success_icon_15;
            this.picture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picture.Properties.ZoomAccelerationFactor = 1D;
            this.picture.Size = new System.Drawing.Size(100, 96);
            this.picture.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.AllowDrop = true;
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Appearance.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMessage.Appearance.Options.UseFont = true;
            this.lblMessage.Appearance.Options.UseForeColor = true;
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblMessage.Location = new System.Drawing.Point(5, 114);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(454, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Chúc bạn một ngày làm việc vui vẻ và may mắn nhé !";
            this.lblMessage.UseWaitCursor = true;
            // 
            // ctrlWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWelcome);
            this.Name = "ctrlWelcome";
            this.Size = new System.Drawing.Size(473, 274);
            ((System.ComponentModel.ISupportInitialize)(this.pnlWelcome)).EndInit();
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlWelcome;
        private DevExpress.XtraEditors.LabelControl lblLoading;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.PictureEdit picture;
        private DevExpress.XtraEditors.LabelControl lblMessage;
    }
}
