namespace Taxi.GUI 
{
    partial class frm_3_1_BCKetQuaDieuHanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_3_1_BCKetQuaDieuHanh));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout3 = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.radTheoGio = new System.Windows.Forms.RadioButton();
            this.radTheoCa = new System.Windows.Forms.RadioButton();
            this.radTheoNgay = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.gridTheoNgay = new Janus.Windows.GridEX.GridEX();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVung = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridTheoCa = new Janus.Windows.GridEX.GridEX();
            this.gridTheoGio = new Janus.Windows.GridEX.GridEX();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheoNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheoCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheoGio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO KẾT QUẢ ĐIỀU HÀNH";
            // 
            // calTuNgay
            // 
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(374, 55);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(90, 20);
            this.calTuNgay.TabIndex = 2;
            this.calTuNgay.Value = new System.DateTime(2011, 3, 6, 0, 0, 0, 0);
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
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
            this.radTheoGio.Location = new System.Drawing.Point(158, 3);
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
            this.radTheoCa.Location = new System.Drawing.Point(85, 3);
            this.radTheoCa.Name = "radTheoCa";
            this.radTheoCa.Size = new System.Drawing.Size(65, 17);
            this.radTheoCa.TabIndex = 11;
            this.radTheoCa.Text = "Theo ca";
            this.radTheoCa.UseVisualStyleBackColor = true;
            this.radTheoCa.CheckedChanged += new System.EventHandler(this.radTheoCa_CheckedChanged);
            // 
            // radTheoNgay
            // 
            this.radTheoNgay.AutoSize = true;
            this.radTheoNgay.Checked = true;
            this.radTheoNgay.Location = new System.Drawing.Point(8, 3);
            this.radTheoNgay.Name = "radTheoNgay";
            this.radTheoNgay.Size = new System.Drawing.Size(76, 17);
            this.radTheoNgay.TabIndex = 12;
            this.radTheoNgay.TabStop = true;
            this.radTheoNgay.Text = "Theo ngày";
            this.radTheoNgay.UseVisualStyleBackColor = true;
            this.radTheoNgay.CheckedChanged += new System.EventHandler(this.radTheoNgay_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radTheoGio);
            this.panel1.Controls.Add(this.radTheoNgay);
            this.panel1.Controls.Add(this.radTheoCa);
            this.panel1.Location = new System.Drawing.Point(374, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 25);
            this.panel1.TabIndex = 13;
            // 
            // calDenNgay
            // 
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Location = new System.Drawing.Point(536, 56);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(90, 20);
            this.calDenNgay.TabIndex = 15;
            this.calDenNgay.Value = new System.DateTime(2011, 3, 6, 0, 0, 0, 0);
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(481, 59);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(53, 13);
            this.lblDenNgay.TabIndex = 14;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(326, 58);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // gridTheoNgay
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridTheoNgay.DesignTimeLayout = gridEXLayout1;
            this.gridTheoNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridTheoNgay.GroupByBoxVisible = false;
            this.gridTheoNgay.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.gridTheoNgay.Location = new System.Drawing.Point(-1, 139);
            this.gridTheoNgay.Name = "gridTheoNgay";
            this.gridTheoNgay.SaveSettings = false;
            this.gridTheoNgay.Size = new System.Drawing.Size(1033, 588);
            this.gridTheoNgay.TabIndex = 16;
            this.gridTheoNgay.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Vùng";
            // 
            // txtVung
            // 
            this.txtVung.Location = new System.Drawing.Point(374, 81);
            this.txtVung.Name = "txtVung";
            this.txtVung.Size = new System.Drawing.Size(160, 20);
            this.txtVung.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "(1;3;4 - rỗng chọn tất cả)";
            // 
            // gridTheoCa
            // 
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridTheoCa.DesignTimeLayout = gridEXLayout2;
            this.gridTheoCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridTheoCa.GroupByBoxVisible = false;
            this.gridTheoCa.Location = new System.Drawing.Point(-1, 139);
            this.gridTheoCa.Name = "gridTheoCa";
            this.gridTheoCa.SaveSettings = false;
            this.gridTheoCa.Size = new System.Drawing.Size(1033, 588);
            this.gridTheoCa.TabIndex = 20;
            // 
            // gridTheoGio
            // 
            gridEXLayout3.LayoutString = resources.GetString("gridEXLayout3.LayoutString");
            this.gridTheoGio.DesignTimeLayout = gridEXLayout3;
            this.gridTheoGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridTheoGio.GroupByBoxVisible = false;
            this.gridTheoGio.Location = new System.Drawing.Point(-1, 139);
            this.gridTheoGio.Name = "gridTheoGio";
            this.gridTheoGio.SaveSettings = false;
            this.gridTheoGio.Size = new System.Drawing.Size(1033, 588);
            this.gridTheoGio.TabIndex = 21;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(459, 103);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(374, 103);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frm_3_1_BCKetQuaDieuHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 725);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridTheoNgay);
            this.Controls.Add(this.gridTheoGio);
            this.Controls.Add(this.gridTheoCa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_3_1_BCKetQuaDieuHanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3.1 BC Ket qua dieu hanh theo ngay ";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheoNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheoCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheoGio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.RadioButton radTheoGio;
        private System.Windows.Forms.RadioButton radTheoCa;
        private System.Windows.Forms.RadioButton radTheoNgay;
        private System.Windows.Forms.Panel panel1;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private Janus.Windows.GridEX.GridEX gridTheoNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVung;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.GridEX gridTheoCa;
        private Janus.Windows.GridEX.GridEX gridTheoGio;
       
    }
}