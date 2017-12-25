namespace Taxi.Controls
{
    partial class frmNotifyAutoUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotifyAutoUpdate));
            this.btnYes = new Taxi.Controls.Base.Controls.ShButton();
            this.btnNo = new Taxi.Controls.Base.Controls.ShButton();
            this.lblMsg = new Taxi.Controls.Base.Controls.ShLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.Location = new System.Drawing.Point(96, 102);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(89, 23);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Cập nhật ngay";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.Location = new System.Drawing.Point(191, 102);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(89, 23);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "Để sau";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(37, 63);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(242, 18);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Bạn có muốn cập nhật ngay không ?";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 35);
            this.panel1.TabIndex = 3;
            // 
            // txtVer
            // 
            this.txtVer.BackColor = System.Drawing.SystemColors.Info;
            this.txtVer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVer.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVer.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtVer.Location = new System.Drawing.Point(0, 0);
            this.txtVer.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtVer.Multiline = true;
            this.txtVer.Name = "txtVer";
            this.txtVer.ReadOnly = true;
            this.txtVer.Size = new System.Drawing.Size(289, 47);
            this.txtVer.TabIndex = 4;
            this.txtVer.Text = "Phiên bản PM điện thoại mới:Phiên bản PM điện thoại mới:";
            this.txtVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmNotifyAutoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(289, 131);
            this.Controls.Add(this.txtVer);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotifyAutoUpdate";
            this.Text = "Cập nhật phần mềm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNotifyAutoUpdate_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Base.Controls.ShButton btnYes;
        private Base.Controls.ShButton btnNo;
        private Base.Controls.ShLabel lblMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtVer;
    }
}