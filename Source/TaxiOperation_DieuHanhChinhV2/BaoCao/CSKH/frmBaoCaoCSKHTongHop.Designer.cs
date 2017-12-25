namespace Taxi.GUI.BaoCao
{
    partial class frmBaoCaoCSKHTongHop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoCSKHTongHop));
            this.label1 = new System.Windows.Forms.Label();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.txtVung = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoLanGoi = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radTatCa = new System.Windows.Forms.RadioButton();
            this.radVLCD = new System.Windows.Forms.RadioButton();
            this.radVangLaiDiDong = new System.Windows.Forms.RadioButton();
            this.radMoiGioi = new System.Windows.Forms.RadioButton();
            this.txtIDCS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO TỔNG HỢP CSKH";
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridEX1;
            this.gridEXExporter1.IncludeChildTables = true;
            // 
            // gridEX1
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEXLayout1;
            this.gridEX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX1.Location = new System.Drawing.Point(3, 170);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(1165, 543);
            this.gridEX1.TabIndex = 43;
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
            // calDenNgay
            // 
            this.calDenNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Location = new System.Drawing.Point(524, 47);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(141, 20);
            this.calDenNgay.TabIndex = 1;
            this.calDenNgay.Value = new System.DateTime(2011, 12, 29, 0, 0, 0, 0);
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Đến ngày";
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
            this.calTuNgay.Location = new System.Drawing.Point(322, 47);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(141, 20);
            this.calTuNgay.TabIndex = 0;
            this.calTuNgay.Value = new System.DateTime(2011, 12, 29, 0, 0, 0, 0);
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Từ ngày";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Vùng";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(495, 130);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 7;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(411, 130);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtVung
            // 
            this.txtVung.Location = new System.Drawing.Point(322, 74);
            this.txtVung.Name = "txtVung";
            this.txtVung.Size = new System.Drawing.Size(141, 20);
            this.txtVung.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Số lần khách gọi lại >:";
            // 
            // txtSoLanGoi
            // 
            this.txtSoLanGoi.Location = new System.Drawing.Point(392, 101);
            this.txtSoLanGoi.Name = "txtSoLanGoi";
            this.txtSoLanGoi.Size = new System.Drawing.Size(71, 20);
            this.txtSoLanGoi.TabIndex = 4;
            this.txtSoLanGoi.TextChanged += new System.EventHandler(this.txtSoLanGoi_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radTatCa);
            this.panel1.Controls.Add(this.radVLCD);
            this.panel1.Controls.Add(this.radVangLaiDiDong);
            this.panel1.Controls.Add(this.radMoiGioi);
            this.panel1.Location = new System.Drawing.Point(523, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 30);
            this.panel1.TabIndex = 5;
            // 
            // radTatCa
            // 
            this.radTatCa.AutoSize = true;
            this.radTatCa.Checked = true;
            this.radTatCa.Location = new System.Drawing.Point(197, 6);
            this.radTatCa.Name = "radTatCa";
            this.radTatCa.Size = new System.Drawing.Size(56, 17);
            this.radTatCa.TabIndex = 3;
            this.radTatCa.TabStop = true;
            this.radTatCa.Text = "Tất cả";
            this.radTatCa.UseVisualStyleBackColor = true;
            this.radTatCa.CheckedChanged += new System.EventHandler(this.radTatCa_CheckedChanged);
            // 
            // radVLCD
            // 
            this.radVLCD.AutoSize = true;
            this.radVLCD.Location = new System.Drawing.Point(113, 7);
            this.radVLCD.Name = "radVLCD";
            this.radVLCD.Size = new System.Drawing.Size(78, 17);
            this.radVLCD.TabIndex = 2;
            this.radVLCD.Text = "VL Cố định";
            this.radVLCD.UseVisualStyleBackColor = true;
            this.radVLCD.CheckedChanged += new System.EventHandler(this.radVLCD_CheckedChanged);
            // 
            // radVangLaiDiDong
            // 
            this.radVangLaiDiDong.AutoSize = true;
            this.radVangLaiDiDong.Location = new System.Drawing.Point(52, 7);
            this.radVangLaiDiDong.Name = "radVangLaiDiDong";
            this.radVangLaiDiDong.Size = new System.Drawing.Size(57, 17);
            this.radVangLaiDiDong.TabIndex = 1;
            this.radVangLaiDiDong.Text = "VL DĐ";
            this.radVangLaiDiDong.UseVisualStyleBackColor = true;
            this.radVangLaiDiDong.CheckedChanged += new System.EventHandler(this.radVangLaiDiDong_CheckedChanged);
            // 
            // radMoiGioi
            // 
            this.radMoiGioi.AutoSize = true;
            this.radMoiGioi.Location = new System.Drawing.Point(4, 7);
            this.radMoiGioi.Name = "radMoiGioi";
            this.radMoiGioi.Size = new System.Drawing.Size(42, 17);
            this.radMoiGioi.TabIndex = 0;
            this.radMoiGioi.Text = "MG";
            this.radMoiGioi.UseVisualStyleBackColor = true;
            this.radMoiGioi.CheckedChanged += new System.EventHandler(this.radMoiGioi_CheckedChanged);
            // 
            // txtIDCS
            // 
            this.txtIDCS.Location = new System.Drawing.Point(524, 70);
            this.txtIDCS.Name = "txtIDCS";
            this.txtIDCS.Size = new System.Drawing.Size(141, 20);
            this.txtIDCS.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(484, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "ID CS";
            // 
            // frmBaoCaoCSKHTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 725);
            this.Controls.Add(this.txtIDCS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSoLanGoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtVung);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoCSKHTongHop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2.1 Bao cao moi gioi - TaxiGroup";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoLanGoi;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radVangLaiDiDong;
        private System.Windows.Forms.RadioButton radMoiGioi;
        private System.Windows.Forms.RadioButton radTatCa;
        private System.Windows.Forms.RadioButton radVLCD;
        private System.Windows.Forms.TextBox txtIDCS;
        private System.Windows.Forms.Label label7;
       
    }
}