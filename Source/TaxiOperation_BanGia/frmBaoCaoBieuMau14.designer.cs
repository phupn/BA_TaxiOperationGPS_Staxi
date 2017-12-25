namespace Taxi.GUI 
{
    partial class frmBaoCaoBieuMau14
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoBieuMau14));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.gridBaoCaoBieuMau1 = new Janus.Windows.GridEX.GridEX();
            this.calTuThoiDiem = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.calDenThoiDiem = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO XE HOẠT ĐỘNG";
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.gridEXPrintDocument1;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.gridEXPrintDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Thời điểm :";
            // 
            // gridBaoCaoBieuMau1
            // 
            this.gridBaoCaoBieuMau1.AutomaticSort = false;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridBaoCaoBieuMau1.DesignTimeLayout = gridEXLayout1;
            this.gridBaoCaoBieuMau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridBaoCaoBieuMau1.GroupByBoxVisible = false;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.Location = new System.Drawing.Point(0, 108);
            this.gridBaoCaoBieuMau1.Name = "gridBaoCaoBieuMau1";
            this.gridBaoCaoBieuMau1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBaoCaoBieuMau1.SaveSettings = false;
            this.gridBaoCaoBieuMau1.Size = new System.Drawing.Size(758, 437);
            this.gridBaoCaoBieuMau1.TabIndex = 15;
            this.gridBaoCaoBieuMau1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBaoCaoBieuMau1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridBaoCaoBieuMau1_FormattingRow_1);
            // 
            // calTuThoiDiem
            // 
            this.calTuThoiDiem.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calTuThoiDiem.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuThoiDiem.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuThoiDiem.DropDownCalendar.Name = "";
            this.calTuThoiDiem.Location = new System.Drawing.Point(227, 29);
            this.calTuThoiDiem.Name = "calTuThoiDiem";
            this.calTuThoiDiem.Size = new System.Drawing.Size(141, 20);
            this.calTuThoiDiem.TabIndex = 17;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(349, 65);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // calDenThoiDiem
            // 
            this.calDenThoiDiem.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calDenThoiDiem.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenThoiDiem.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calDenThoiDiem.DropDownCalendar.Name = "";
            this.calDenThoiDiem.Location = new System.Drawing.Point(426, 29);
            this.calDenThoiDiem.Name = "calDenThoiDiem";
            this.calDenThoiDiem.Size = new System.Drawing.Size(141, 20);
            this.calDenThoiDiem.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Đến ngày";
            // 
            // frmBaoCaoBieuMau14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 557);
            this.Controls.Add(this.calDenThoiDiem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.calTuThoiDiem);
            this.Controls.Add(this.gridBaoCaoBieuMau1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoBieuMau14";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BC 14 - Bao cao xe hoat dong";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.GridEX gridBaoCaoBieuMau1;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuThoiDiem;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenThoiDiem;
        private System.Windows.Forms.Label label3;
       
       
    }
}