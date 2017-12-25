namespace Taxi.GUI.BaoCao
{
    partial class frmBC_5_4_DiSanBayDuongDai
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_5_4_DiSanBayDuongDai));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.gridBaoCaoBieuMau1 = new Janus.Windows.GridEX.GridEX();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.ilButtons = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.date_DenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.chkAirPort = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO XE ĐI SÂN BAY ĐƯỜNG DÀI THEO NGÀY";
            // 
            // gridBaoCaoBieuMau1
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridBaoCaoBieuMau1.DesignTimeLayout = gridEXLayout1;
            this.gridBaoCaoBieuMau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridBaoCaoBieuMau1.GroupByBoxVisible = false;
            this.gridBaoCaoBieuMau1.GroupTotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.Location = new System.Drawing.Point(5, 98);
            this.gridBaoCaoBieuMau1.Name = "gridBaoCaoBieuMau1";
            this.gridBaoCaoBieuMau1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridBaoCaoBieuMau1.RowHeaderFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBaoCaoBieuMau1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBaoCaoBieuMau1.SaveSettings = false;
            this.gridBaoCaoBieuMau1.Size = new System.Drawing.Size(934, 577);
            this.gridBaoCaoBieuMau1.TabIndex = 9;
            this.gridBaoCaoBieuMau1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridBaoCaoBieuMau1_FormattingRow);
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.gridBaoCaoBieuMau1;
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridEX1;
            // 
            // gridEX1
            // 
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEXLayout2;
            this.gridEX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.GroupTotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridEX1.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridEX1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridEX1.Location = new System.Drawing.Point(596, 36);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridEX1.RowHeaderFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.gridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(343, 92);
            this.gridEX1.TabIndex = 10;
            this.gridEX1.Visible = false;
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
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(525, 56);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(441, 56);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ilButtons
            // 
            this.ilButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilButtons.ImageStream")));
            this.ilButtons.TransparentColor = System.Drawing.Color.Silver;
            this.ilButtons.Images.SetKeyName(0, "");
            this.ilButtons.Images.SetKeyName(1, "");
            this.ilButtons.Images.SetKeyName(2, "");
            this.ilButtons.Images.SetKeyName(3, "");
            this.ilButtons.Images.SetKeyName(4, "");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(482, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Đến ngày";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(266, 34);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 47;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // date_DenNgay
            // 
            this.date_DenNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.date_DenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.date_DenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.date_DenNgay.DropDownCalendar.Name = "";
            this.date_DenNgay.Location = new System.Drawing.Point(541, 30);
            this.date_DenNgay.Name = "date_DenNgay";
            this.date_DenNgay.Size = new System.Drawing.Size(143, 20);
            this.date_DenNgay.TabIndex = 50;
            this.date_DenNgay.Value = new System.DateTime(2012, 10, 8, 0, 0, 0, 0);
            this.date_DenNgay.VisibleChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(318, 30);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(143, 20);
            this.calTuNgay.TabIndex = 49;
            this.calTuNgay.Value = new System.DateTime(2012, 10, 8, 0, 0, 0, 0);
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // chkAirPort
            // 
            this.chkAirPort.AutoSize = true;
            this.chkAirPort.Location = new System.Drawing.Point(318, 65);
            this.chkAirPort.Name = "chkAirPort";
            this.chkAirPort.Size = new System.Drawing.Size(79, 17);
            this.chkAirPort.TabIndex = 51;
            this.chkAirPort.Text = "Xe sân bay";
            this.chkAirPort.UseVisualStyleBackColor = true;
            // 
            // frmBC_5_4_DiSanBayDuongDai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 704);
            this.Controls.Add(this.chkAirPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.date_DenNgay);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.gridBaoCaoBieuMau1);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_5_4_DiSanBayDuongDai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo các xe đi sân bay, đường dài";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEX gridBaoCaoBieuMau1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ImageList ilButtons;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo date_DenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.CheckBox chkAirPort;
       
    }
}