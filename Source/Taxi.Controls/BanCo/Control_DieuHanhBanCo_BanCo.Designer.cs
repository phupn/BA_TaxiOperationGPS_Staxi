namespace Taxi.Controls.BanCo
{
    partial class Control_DieuHanhBanCo_BanCo
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
            this.HienTrangXe = new Taxi.Controls.Maps.HienTrangXe();
            this.SuspendLayout();
            // 
            // HienTrangXe
            // 
            this.HienTrangXe.Location = new System.Drawing.Point(204, 19);
            this.HienTrangXe.Name = "HienTrangXe";
            this.HienTrangXe.Size = new System.Drawing.Size(437, 330);
            this.HienTrangXe.TabIndex = 0;
            this.HienTrangXe.Visible = false;
            // 
            // Control_DieuHanhBanCo_BanCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.HienTrangXe);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Control_DieuHanhBanCo_BanCo";
            this.Size = new System.Drawing.Size(712, 442);
            this.ResumeLayout(false);

        }

        #endregion
        private Taxi.Controls.Maps.HienTrangXe HienTrangXe;

    }
}
