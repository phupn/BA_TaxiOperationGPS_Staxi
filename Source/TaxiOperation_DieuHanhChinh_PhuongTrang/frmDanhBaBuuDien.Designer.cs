namespace TaxiOperation_DieuHanhChinh
{
    partial class frmDanhBaBuuDien
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
            this.dgv_DanhBaBuuDien = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhBaBuuDien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DanhBaBuuDien
            // 
            this.dgv_DanhBaBuuDien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhBaBuuDien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DanhBaBuuDien.Location = new System.Drawing.Point(0, 0);
            this.dgv_DanhBaBuuDien.Name = "dgv_DanhBaBuuDien";
            this.dgv_DanhBaBuuDien.Size = new System.Drawing.Size(407, 261);
            this.dgv_DanhBaBuuDien.TabIndex = 0;
            // 
            // frmDanhBaBuuDien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 261);
            this.Controls.Add(this.dgv_DanhBaBuuDien);
            this.Name = "frmDanhBaBuuDien";
            this.Text = "frmDanhBaBuuDien";
            this.Load += new System.EventHandler(this.frmDanhBaBuuDien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhBaBuuDien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DanhBaBuuDien;
    }
}