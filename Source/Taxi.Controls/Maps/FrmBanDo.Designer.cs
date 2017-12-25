namespace Taxi.Controls.Maps
{
    partial class FrmBanDo
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
            this.userMap1 = new Taxi.Controls.Maps.UserMap();
            this.SuspendLayout();
            // 
            // userMap1
            // 
            this.userMap1.DiaChi = null;
            this.userMap1.DiaChiTimKiem = null;
            this.userMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userMap1.Lat = 0F;
            this.userMap1.Lng = 0F;
            this.userMap1.Location = new System.Drawing.Point(0, 0);
            this.userMap1.Name = "userMap1";
            this.userMap1.Size = new System.Drawing.Size(899, 613);
            this.userMap1.TabIndex = 0;
            this.userMap1.Zoom = 0;
            this.userMap1.AlterSearch += new Taxi.Controls.Maps.EventUserMapSearch(this.userMap1_AlterSearch);
            this.userMap1.EventOk += new System.EventHandler(this.userMap1_EventOk);
            // 
            // FrmBanDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 613);
            this.Controls.Add(this.userMap1);
            this.Name = "FrmBanDo";
            this.Text = "Bản đồ";
            this.ResumeLayout(false);

        }

        #endregion

        public UserMap userMap1;

    }
}