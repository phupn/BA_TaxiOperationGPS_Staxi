namespace Taxi.GUI 
{
    partial class frmBCGroupTongKetGoiDen_1_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCGroupTongKetGoiDen_1_1));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.radTheoGio = new System.Windows.Forms.RadioButton();
            this.radTheoCa = new System.Windows.Forms.RadioButton();
            this.gridTheoGio = new Janus.Windows.GridEX.GridEX();
            this.ChartVungKieu1 = new ChartDirector.WinChartViewer();
            this.viewer2 = new ChartDirector.WinChartViewer();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheoGio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartVungKieu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewer2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(270, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO TỔNG HỢP CUỘC GỌI ĐẾN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày";
            // 
            // calTuNgay
            // 
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(357, 30);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(90, 20);
            this.calTuNgay.TabIndex = 2;
            this.calTuNgay.Value = new System.DateTime(2011, 3, 6, 0, 0, 0, 0);
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(472, 56);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(387, 56);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridEX1;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.AutomaticSort = false;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEXLayout1;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(-4, 105);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(1034, 174);
            this.gridEX1.TabIndex = 9;
            this.gridEX1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridEX1_FormattingRow);
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
            // radTheoGio
            // 
            this.radTheoGio.AutoSize = true;
            this.radTheoGio.Location = new System.Drawing.Point(543, 27);
            this.radTheoGio.Name = "radTheoGio";
            this.radTheoGio.Size = new System.Drawing.Size(67, 17);
            this.radTheoGio.TabIndex = 10;
            this.radTheoGio.Text = "Theo giờ";
            this.radTheoGio.UseVisualStyleBackColor = true;
            this.radTheoGio.CheckedChanged += new System.EventHandler(this.radTheoGio_CheckedChanged);
            // 
            // radTheoCa
            // 
            this.radTheoCa.AutoSize = true;
            this.radTheoCa.Checked = true;
            this.radTheoCa.Location = new System.Drawing.Point(472, 27);
            this.radTheoCa.Name = "radTheoCa";
            this.radTheoCa.Size = new System.Drawing.Size(65, 17);
            this.radTheoCa.TabIndex = 11;
            this.radTheoCa.TabStop = true;
            this.radTheoCa.Text = "Theo ca";
            this.radTheoCa.UseVisualStyleBackColor = true;
            this.radTheoCa.CheckedChanged += new System.EventHandler(this.radTheoCa_CheckedChanged);
            // 
            // gridTheoGio
            // 
            this.gridTheoGio.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridTheoGio.AutomaticSort = false;
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridTheoGio.DesignTimeLayout = gridEXLayout2;
            this.gridTheoGio.GroupByBoxVisible = false;
            this.gridTheoGio.Location = new System.Drawing.Point(-4, 105);
            this.gridTheoGio.Name = "gridTheoGio";
            this.gridTheoGio.SaveSettings = false;
            this.gridTheoGio.Size = new System.Drawing.Size(1034, 619);
            this.gridTheoGio.TabIndex = 12;
            this.gridTheoGio.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridTheoGio.Visible = false;
            this.gridTheoGio.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridTheoGio_FormattingRow);
            // 
            // ChartVungKieu1
            // 
            this.ChartVungKieu1.Location = new System.Drawing.Point(54, 296);
            this.ChartVungKieu1.Name = "ChartVungKieu1";
            this.ChartVungKieu1.Size = new System.Drawing.Size(438, 306);
            this.ChartVungKieu1.TabIndex = 14;
            this.ChartVungKieu1.TabStop = false;
            // 
            // viewer2
            // 
            this.viewer2.Location = new System.Drawing.Point(521, 301);
            this.viewer2.Name = "viewer2";
            this.viewer2.Size = new System.Drawing.Size(438, 306);
            this.viewer2.TabIndex = 13;
            this.viewer2.TabStop = false;
            // 
            // frmBCGroupTongKetGoiDen_1_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 725);
            this.Controls.Add(this.ChartVungKieu1);
            this.Controls.Add(this.viewer2);
            this.Controls.Add(this.radTheoCa);
            this.Controls.Add(this.radTheoGio);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.gridTheoGio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBCGroupTongKetGoiDen_1_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1.1 BC Tong hop cuoc goi den ";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheoGio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartVungKieu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.RadioButton radTheoGio;
        private System.Windows.Forms.RadioButton radTheoCa;
        private Janus.Windows.GridEX.GridEX gridTheoGio;
        private ChartDirector.WinChartViewer ChartVungKieu1;
        private ChartDirector.WinChartViewer viewer2;
       
    }
}