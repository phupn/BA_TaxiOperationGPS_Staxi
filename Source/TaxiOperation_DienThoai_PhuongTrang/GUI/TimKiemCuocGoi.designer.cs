namespace Taxi.GUI
{
    partial class TimKiemCuocGoi
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
            this.ctrlSearchCuocGoi = new Taxi.Controls.ctrlSearchCuocGoi();
            this.SuspendLayout();
            // 
            // ctrlSearchCuocGoi
            // 
            this.ctrlSearchCuocGoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSearchCuocGoi.Location = new System.Drawing.Point(0, 0);
            this.ctrlSearchCuocGoi.Name = "ctrlSearchCuocGoi";
            this.ctrlSearchCuocGoi.Size = new System.Drawing.Size(1009, 441);
            this.ctrlSearchCuocGoi.TabIndex = 0;
            this.ctrlSearchCuocGoi.Load += new System.EventHandler(this.ctrlSearchCuocGoi_Load);
            // 
            // TimKiemCuocGoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 441);
            this.Controls.Add(this.ctrlSearchCuocGoi);
            this.Icon = global::TaxiApplication.Properties.Resources.Taxi;
            this.Name = "TimKiemCuocGoi";
            this.Text = "Tìm kiếm cuộc gọi";
            this.Load += new System.EventHandler(this.TimKiemCuocGoi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.ctrlSearchCuocGoi ctrlSearchCuocGoi;
    }
}