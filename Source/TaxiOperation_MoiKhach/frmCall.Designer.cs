namespace Taxi.GUI
{
    partial class frmCall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCall));
            this.ctrlGoiSo1 = new Taxi.Controls.ctrlGoiSo();
            this.SuspendLayout();
            // 
            // ctrlGoiSo1
            // 
            this.ctrlGoiSo1.Location = new System.Drawing.Point(2, -3);
            this.ctrlGoiSo1.Name = "ctrlGoiSo1";
            this.ctrlGoiSo1.Size = new System.Drawing.Size(311, 445);
            this.ctrlGoiSo1.TabIndex = 0;
            // 
            // frmCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 432);
            this.Controls.Add(this.ctrlGoiSo1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gọi số";
            this.Load += new System.EventHandler(this.frmCall_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.ctrlGoiSo ctrlGoiSo1;
    }
}