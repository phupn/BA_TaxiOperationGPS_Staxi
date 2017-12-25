using System.Data;
namespace Taxi.Controls.Maps
{
    partial class TimLoaiXe
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
        /// 
        private void InitializeComponent()
        {
            this.ctrlSearchXe1 = new Taxi.Controls.Common.ctrlLoaiXe_CheckListBox();
            this.SuspendLayout();
            // 
            // ctrlSearchXe1
            // 
            this.ctrlSearchXe1.Location = new System.Drawing.Point(31, 21);
            this.ctrlSearchXe1.Name = "ctrlSearchXe1";
            this.ctrlSearchXe1.Size = new System.Drawing.Size(203, 101);
            this.ctrlSearchXe1.TabIndex = 0;
            // 
            // TimLoaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ctrlSearchXe1);
            this.Name = "TimLoaiXe";
            this.Text = "TimLoaiXe";
            this.Load += new System.EventHandler(this.TimLoaiXe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Common.ctrlLoaiXe_CheckListBox ctrlSearchXe1;
    }
}