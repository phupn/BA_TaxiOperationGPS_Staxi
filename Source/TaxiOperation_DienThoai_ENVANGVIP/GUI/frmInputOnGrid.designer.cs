namespace Taxi.GUI
{
    partial class frmInputOnGrid
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
            this.panelInputGrid = new System.Windows.Forms.Panel();
            this.lblLabel = new System.Windows.Forms.Label();
            this.txtInputGrid = new System.Windows.Forms.TextBox();
            this.panelInputGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInputGrid
            // 
            this.panelInputGrid.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelInputGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInputGrid.Controls.Add(this.lblLabel);
            this.panelInputGrid.Controls.Add(this.txtInputGrid);
            this.panelInputGrid.Location = new System.Drawing.Point(1, 1);
            this.panelInputGrid.Name = "panelInputGrid";
            this.panelInputGrid.Size = new System.Drawing.Size(323, 31);
            this.panelInputGrid.TabIndex = 5;
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(3, 8);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(70, 13);
            this.lblLabel.TabIndex = 1;
            this.lblLabel.Text = "Chuyển kênh";
            // 
            // txtInputGrid
            // 
            this.txtInputGrid.BackColor = System.Drawing.Color.Khaki;
            this.txtInputGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputGrid.Location = new System.Drawing.Point(84, 1);
            this.txtInputGrid.Name = "txtInputGrid";
            this.txtInputGrid.Size = new System.Drawing.Size(235, 26);
            this.txtInputGrid.TabIndex = 0;
            this.txtInputGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputGrid_KeyDown);
            // 
            // frmInputOnGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 34);
            this.ControlBox = false;
            this.Controls.Add(this.panelInputGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInputOnGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Nhập lưới";
            this.Load += new System.EventHandler(this.frmInputOnGrid_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInputOnGrid_FormClosing);
            this.panelInputGrid.ResumeLayout(false);
            this.panelInputGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInputGrid;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox txtInputGrid;
    }
}