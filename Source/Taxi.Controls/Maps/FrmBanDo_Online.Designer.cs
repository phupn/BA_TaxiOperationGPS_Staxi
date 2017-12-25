namespace Taxi.Controls.Maps
{
    partial class FrmBanDo_Online
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
            this.gMaps1 = new Taxi.Controls.Maps.GMaps();
            this.SuspendLayout();
            // 
            // gMaps1
            // 
            this.gMaps1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMaps1.Location = new System.Drawing.Point(0, 0);
            this.gMaps1.Name = "gMaps1";
            this.gMaps1.Size = new System.Drawing.Size(864, 461);
            this.gMaps1.TabIndex = 0;
            // 
            // FrmBanDo_Online
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 461);
            this.Controls.Add(this.gMaps1);
            this.Name = "FrmBanDo_Online";
            this.Text = "Bản đồ GPS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBanDo_Online_FormClosing);
            this.Load += new System.EventHandler(this.FrmBanDo_Online_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMaps gMaps1;
    }
}