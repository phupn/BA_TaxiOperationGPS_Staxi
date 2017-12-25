namespace StaxiManClient
{
    partial class MainForm
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
            this.ctrlProductLicense1 = new Taxi.Controls.ProductLicense.ctrlProductLicense();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_ServerInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusbar_Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlProductLicense1
            // 
            this.ctrlProductLicense1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProductLicense1.Location = new System.Drawing.Point(0, 0);
            this.ctrlProductLicense1.Name = "ctrlProductLicense1";
            this.ctrlProductLicense1.Size = new System.Drawing.Size(471, 366);
            this.ctrlProductLicense1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_ServerInfo,
            this.statusbar_Version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(471, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_ServerInfo
            // 
            this.status_ServerInfo.Name = "status_ServerInfo";
            this.status_ServerInfo.Size = new System.Drawing.Size(62, 17);
            this.status_ServerInfo.Text = "server info";
            // 
            // statusbar_Version
            // 
            this.statusbar_Version.Name = "statusbar_Version";
            this.statusbar_Version.Size = new System.Drawing.Size(45, 17);
            this.statusbar_Version.Text = "Version";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 366);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ctrlProductLicense1);
            this.Name = "MainForm";
            this.Text = "Xác thực phần mềm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.ProductLicense.ctrlProductLicense ctrlProductLicense1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status_ServerInfo;
        private System.Windows.Forms.ToolStripStatusLabel statusbar_Version;
    }
}

