namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    partial class frmBC_4_2_KetQuaDieuHanhTheoCa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_4_2_KetQuaDieuHanhTheoCa));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.grdDieuHanhTheoCa = new Janus.Windows.GridEX.GridEX();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridExport = new Janus.Windows.GridEX.GridEX();
            this.lblTuNgayDen = new System.Windows.Forms.Label();
            this.chkTongNgay = new System.Windows.Forms.CheckBox();
            this.txtVung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdDieuHanhTheoCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDieuHanhTheoCa
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdDieuHanhTheoCa.DesignTimeLayout = gridEXLayout1;
            this.grdDieuHanhTheoCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDieuHanhTheoCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdDieuHanhTheoCa.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdDieuHanhTheoCa.GroupByBoxVisible = false;
            this.grdDieuHanhTheoCa.Location = new System.Drawing.Point(0, 0);
            this.grdDieuHanhTheoCa.Name = "grdDieuHanhTheoCa";
            this.grdDieuHanhTheoCa.SaveSettings = false;
            this.grdDieuHanhTheoCa.Size = new System.Drawing.Size(1015, 425);
            this.grdDieuHanhTheoCa.TabIndex = 31;
            this.grdDieuHanhTheoCa.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdDieuHanhTheoCa_FormattingRow);
            // 
            // calDenNgay
            // 
            this.calDenNgay.CustomFormat = "dd/MM/yyyy";
            this.calDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Location = new System.Drawing.Point(552, 31);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(90, 20);
            this.calDenNgay.TabIndex = 28;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(497, 34);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(53, 13);
            this.lblDenNgay.TabIndex = 27;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(390, 30);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(90, 20);
            this.calTuNgay.TabIndex = 26;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(342, 33);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 25;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "BÁO CÁO KẾT QUẢ ĐIỀU HÀNH THEO CA";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(505, 82);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 30;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(420, 82);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 29;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.gridEXPrintDocument1;
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridExport;
            // 
            // gridExport
            // 
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridExport.DesignTimeLayout = gridEXLayout2;
            this.gridExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridExport.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridExport.GroupByBoxVisible = false;
            this.gridExport.Location = new System.Drawing.Point(705, 12);
            this.gridExport.Name = "gridExport";
            this.gridExport.SaveSettings = false;
            this.gridExport.Size = new System.Drawing.Size(1015, 425);
            this.gridExport.TabIndex = 32;
            this.gridExport.Visible = false;
            // 
            // lblTuNgayDen
            // 
            this.lblTuNgayDen.AutoSize = true;
            this.lblTuNgayDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgayDen.Location = new System.Drawing.Point(595, 91);
            this.lblTuNgayDen.Name = "lblTuNgayDen";
            this.lblTuNgayDen.Size = new System.Drawing.Size(0, 13);
            this.lblTuNgayDen.TabIndex = 33;
            // 
            // chkTongNgay
            // 
            this.chkTongNgay.AutoSize = true;
            this.chkTongNgay.Location = new System.Drawing.Point(500, 57);
            this.chkTongNgay.Name = "chkTongNgay";
            this.chkTongNgay.Size = new System.Drawing.Size(93, 17);
            this.chkTongNgay.TabIndex = 36;
            this.chkTongNgay.Text = "Lấy tổng ngày";
            this.chkTongNgay.UseVisualStyleBackColor = true;
            this.chkTongNgay.CheckedChanged += new System.EventHandler(this.chkTongNgay_CheckedChanged);
            // 
            // txtVung
            // 
            this.txtVung.Location = new System.Drawing.Point(390, 56);
            this.txtVung.Name = "txtVung";
            this.txtVung.Size = new System.Drawing.Size(38, 20);
            this.txtVung.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Vùng";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridExport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkTongNgay);
            this.panel1.Controls.Add(this.lblTuNgay);
            this.panel1.Controls.Add(this.txtVung);
            this.panel1.Controls.Add(this.calTuNgay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblDenNgay);
            this.panel1.Controls.Add(this.lblTuNgayDen);
            this.panel1.Controls.Add(this.calDenNgay);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 119);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdDieuHanhTheoCa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 425);
            this.panel2.TabIndex = 38;
            // 
            // frmBC_4_2_KetQuaDieuHanhTheoCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 544);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_4_2_KetQuaDieuHanhTheoCa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "4.2 Báo cáo kết quả điều hành theo ca";
            this.Load += new System.EventHandler(this.frmBC_4_2_KetQuaDieuHanhTheoCa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDieuHanhTheoCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdDieuHanhTheoCa;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.Label lblTuNgayDen;
        private System.Windows.Forms.CheckBox chkTongNgay;
        private System.Windows.Forms.TextBox txtVung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Janus.Windows.GridEX.GridEX gridExport;
    }
}