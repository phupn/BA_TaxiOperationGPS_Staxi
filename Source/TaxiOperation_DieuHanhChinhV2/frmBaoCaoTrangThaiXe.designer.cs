namespace Taxi.GUI
{
    partial class frmBaoCaoTrangThaiXe
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoTrangThaiXe));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridBaoCaoBieuMau1 = new Janus.Windows.GridEX.GridEX();
            this.lblThoiDiem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO XE HOẠT ĐỘNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Thời điểm :";
            // 
            // gridBaoCaoBieuMau1
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridBaoCaoBieuMau1.DesignTimeLayout = gridEXLayout1;
            this.gridBaoCaoBieuMau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridBaoCaoBieuMau1.GroupByBoxVisible = false;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.Location = new System.Drawing.Point(-4, 57);
            this.gridBaoCaoBieuMau1.Name = "gridBaoCaoBieuMau1";
            this.gridBaoCaoBieuMau1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBaoCaoBieuMau1.SaveSettings = false;
            this.gridBaoCaoBieuMau1.Size = new System.Drawing.Size(758, 488);
            this.gridBaoCaoBieuMau1.TabIndex = 15;
            this.gridBaoCaoBieuMau1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBaoCaoBieuMau1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridBaoCaoBieuMau1_FormattingRow_1);
            // 
            // lblThoiDiem
            // 
            this.lblThoiDiem.AutoSize = true;
            this.lblThoiDiem.Location = new System.Drawing.Point(333, 34);
            this.lblThoiDiem.Name = "lblThoiDiem";
            this.lblThoiDiem.Size = new System.Drawing.Size(10, 13);
            this.lblThoiDiem.TabIndex = 16;
            this.lblThoiDiem.Text = " ";
            // 
            // frmBaoCaoTrangThaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 557);
            this.Controls.Add(this.lblThoiDiem);
            this.Controls.Add(this.gridBaoCaoBieuMau1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoTrangThaiXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "  Bao cao xe hoat dong";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
   
     
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.GridEX gridBaoCaoBieuMau1;
        private System.Windows.Forms.Label lblThoiDiem;
       
       
    }
}