namespace Taxi.Controls
{
    partial class DanhSachXeLienLacControls
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
            this.panel = new System.Windows.Forms.Panel();
            this.ground = new System.Windows.Forms.GroupBox();
            this.ground.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(3, 16);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(509, 221);
            this.panel.TabIndex = 0;
            // 
            // ground
            // 
            this.ground.Controls.Add(this.panel);
            this.ground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ground.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ground.Location = new System.Drawing.Point(0, 0);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(515, 240);
            this.ground.TabIndex = 0;
            this.ground.TabStop = false;
            this.ground.Text = "Title";
            // 
            // DanhSachXeLienLacControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ground);
            this.Name = "DanhSachXeLienLacControls";
            this.Size = new System.Drawing.Size(515, 240);
            this.ground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox ground;




    }
}
