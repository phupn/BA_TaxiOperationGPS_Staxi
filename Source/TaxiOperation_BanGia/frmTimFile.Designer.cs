namespace Taxi.GUI
{
    partial class frmTimFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimFile));
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlTimFile1 = new Taxi.Controls.ctrlTimFile();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DoubleClick vào dòng chọn để chọn file.";
            // 
            // ctrlTimFile1
            // 
            this.ctrlTimFile1.Location = new System.Drawing.Point(0, 1);
            this.ctrlTimFile1.Name = "ctrlTimFile1";
            this.ctrlTimFile1.Size = new System.Drawing.Size(430, 343);
            this.ctrlTimFile1.TabIndex = 0;
            // 
            // frmTimFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 367);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlTimFile1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm file";
            this.Load += new System.EventHandler(this.frmTimFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.ctrlTimFile ctrlTimFile1;
        private System.Windows.Forms.Label label1;
    }
}