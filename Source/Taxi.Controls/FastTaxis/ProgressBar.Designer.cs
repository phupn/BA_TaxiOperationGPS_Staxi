namespace Taxi.Controls.FastTaxis
{
    partial class ProgressBar
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
            this.shProgressBar1 = new Taxi.Controls.Base.Controls.ShProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.shProgressBar1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // shProgressBar1
            // 
            this.shProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.shProgressBar1.Name = "shProgressBar1";
            this.shProgressBar1.Size = new System.Drawing.Size(318, 23);
            this.shProgressBar1.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 23);
            this.Controls.Add(this.shProgressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.shProgressBar1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShProgressBar shProgressBar1;
    }
}