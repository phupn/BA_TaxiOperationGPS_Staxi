namespace Taxi.Controls.VersionInfo
{
    partial class FrmRequired
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
            this.btnCapNhat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnDeSau = new Taxi.Controls.Base.Controls.ShButton();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblVer = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblHanCapNhat = new Taxi.Controls.Base.Controls.ShLabel();
            this.SuspendLayout();
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(58, 125);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 0;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnDeSau
            // 
            this.btnDeSau.Location = new System.Drawing.Point(139, 125);
            this.btnDeSau.Name = "btnDeSau";
            this.btnDeSau.Size = new System.Drawing.Size(75, 23);
            this.btnDeSau.TabIndex = 0;
            this.btnDeSau.Text = "Để sau";
            this.btnDeSau.Click += new System.EventHandler(this.btnDeSau_Click);
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(32, 11);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(66, 13);
            this.shLabel1.TabIndex = 1;
            this.shLabel1.Text = "Phiên bản mới";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(32, 45);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(225, 56);
            this.txtDescription.TabIndex = 2;
            // 
            // lblVer
            // 
            this.lblVer.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblVer.Location = new System.Drawing.Point(117, 11);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(91, 13);
            this.lblVer.TabIndex = 1;
            this.lblVer.Text = "V2 Build201600317";
            // 
            // shLabel2
            // 
            this.shLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.shLabel2.Location = new System.Drawing.Point(37, 105);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(208, 13);
            this.shLabel2.TabIndex = 1;
            this.shLabel2.Text = "(Lưu ý:cập nhật là khởi động lại phầm mềm)";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(32, 26);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(64, 13);
            this.shLabel3.TabIndex = 1;
            this.shLabel3.Text = "Hạn cập nhật";
            // 
            // lblHanCapNhat
            // 
            this.lblHanCapNhat.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblHanCapNhat.Location = new System.Drawing.Point(117, 26);
            this.lblHanCapNhat.Name = "lblHanCapNhat";
            this.lblHanCapNhat.Size = new System.Drawing.Size(91, 13);
            this.lblHanCapNhat.TabIndex = 1;
            this.lblHanCapNhat.Text = "V2 Build201600317";
            // 
            // FrmRequired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(289, 155);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblHanCapNhat);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.shLabel3);
            this.Controls.Add(this.shLabel2);
            this.Controls.Add(this.shLabel1);
            this.Controls.Add(this.btnDeSau);
            this.Controls.Add(this.btnCapNhat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRequired";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Thông tin cập nhật";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmRequired_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Base.Controls.ShButton btnCapNhat;
        private Base.Controls.ShButton btnDeSau;
        private Base.Controls.ShLabel shLabel1;
        private System.Windows.Forms.TextBox txtDescription;
        private Base.Controls.ShLabel lblVer;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel3;
        private Base.Controls.ShLabel lblHanCapNhat;
    }
}