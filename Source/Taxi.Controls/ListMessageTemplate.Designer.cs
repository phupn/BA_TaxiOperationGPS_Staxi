namespace Taxi.Controls
{
    partial class ListMessageTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListMessageTemplate));
            this.dgvListMessageTemplate = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMessageTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListMessageTemplate
            // 
            this.dgvListMessageTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMessageTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListMessageTemplate.Location = new System.Drawing.Point(0, 0);
            this.dgvListMessageTemplate.Name = "dgvListMessageTemplate";
            this.dgvListMessageTemplate.Size = new System.Drawing.Size(584, 262);
            this.dgvListMessageTemplate.TabIndex = 0;
            this.dgvListMessageTemplate.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListMessageTemplate_CellMouseDoubleClick);
            // 
            // ListMessageTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.dgvListMessageTemplate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListMessageTemplate";
            this.Text = "Tin nhắn mẫu";
            this.Load += new System.EventHandler(this.ListMessageTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMessageTemplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListMessageTemplate;
    }
}