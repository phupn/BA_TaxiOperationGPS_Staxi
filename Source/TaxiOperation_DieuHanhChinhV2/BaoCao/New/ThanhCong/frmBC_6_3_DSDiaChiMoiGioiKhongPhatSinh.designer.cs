namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    partial class frmBC_6_3_DSDiaChiMoiGioiKhongPhatSinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_6_3_DSDiaChiMoiGioiKhongPhatSinh));
            this.calBatDauTu = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label8 = new System.Windows.Forms.Label();
            this.calBatDauDen = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.grdDSDiaChiMoiGioi = new Janus.Windows.GridEX.GridEX();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSDiaChiMoiGioi)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // calBatDauTu
            // 
            this.calBatDauTu.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calBatDauTu.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calBatDauTu.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calBatDauTu.DropDownCalendar.Name = "";
            this.calBatDauTu.Location = new System.Drawing.Point(416, 12);
            this.calBatDauTu.Name = "calBatDauTu";
            this.calBatDauTu.Size = new System.Drawing.Size(152, 20);
            this.calBatDauTu.TabIndex = 4;
            this.calBatDauTu.Value = new System.DateTime(2011, 5, 26, 15, 3, 55, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(583, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Đến ngày";
            // 
            // calBatDauDen
            // 
            this.calBatDauDen.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calBatDauDen.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calBatDauDen.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calBatDauDen.DropDownCalendar.Name = "";
            this.calBatDauDen.Location = new System.Drawing.Point(642, 12);
            this.calBatDauDen.Name = "calBatDauDen";
            this.calBatDauDen.Size = new System.Drawing.Size(152, 20);
            this.calBatDauDen.TabIndex = 5;
            this.calBatDauDen.Value = new System.DateTime(2011, 5, 26, 15, 4, 7, 0);
            // 
            // grdDSDiaChiMoiGioi
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdDSDiaChiMoiGioi.DesignTimeLayout = gridEXLayout1;
            this.grdDSDiaChiMoiGioi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDSDiaChiMoiGioi.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdDSDiaChiMoiGioi.GroupByBoxVisible = false;
            this.grdDSDiaChiMoiGioi.Location = new System.Drawing.Point(0, 0);
            this.grdDSDiaChiMoiGioi.Name = "grdDSDiaChiMoiGioi";
            this.grdDSDiaChiMoiGioi.SaveSettings = false;
            this.grdDSDiaChiMoiGioi.Size = new System.Drawing.Size(1147, 512);
            this.grdDSDiaChiMoiGioi.TabIndex = 11;
            this.grdDSDiaChiMoiGioi.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdDSDiaChiMoiGioi_FormattingRow);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(490, 50);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 33);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(586, 50);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(100, 33);
            this.btnExportExcel.TabIndex = 10;
            this.btnExportExcel.Text = "&Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdDSDiaChiMoiGioi;
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.grdDSDiaChiMoiGioi;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.calBatDauDen);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.calBatDauTu);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 98);
            this.panel1.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Từ ngày";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdDSDiaChiMoiGioi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1147, 512);
            this.panel2.TabIndex = 27;
            // 
            // frmBC_6_3_DSDiaChiMoiGioiKhongPhatSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 610);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_6_3_DSDiaChiMoiGioiKhongPhatSinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo danh sách địa chỉ môi giới không phát sinh";
            this.Load += new System.EventHandler(this.frmBC_6_1_DSDiaChiMoiGioi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDSDiaChiMoiGioi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.CalendarCombo.CalendarCombo calBatDauTu;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.CalendarCombo.CalendarCombo calBatDauDen;
        private Janus.Windows.GridEX.GridEX grdDSDiaChiMoiGioi;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}