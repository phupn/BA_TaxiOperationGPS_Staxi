namespace Taxi.GUI.BaoCao
{
    partial class frmBC_3_1_TongHopPhanAnh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_3_1_TongHopPhanAnh));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.grdTongHop = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grdTongHop)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(567, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Đến ngày ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Từ ngày ";
            // 
            // calDenNgay
            // 
            this.calDenNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calDenNgay.Location = new System.Drawing.Point(639, 42);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(150, 23);
            this.calDenNgay.TabIndex = 13;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            this.calDenNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calDenNgay_KeyDown);
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calTuNgay.Location = new System.Drawing.Point(373, 42);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(148, 23);
            this.calTuNgay.TabIndex = 12;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            this.calTuNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calTuNgay_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "BÁO CÁO TỔNG HỢP THÔNG TIN KHÁCH HÀNG PHẢN ÁNH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::TaxiOperation_KhachHang.Properties.Resources.Excel_24x24;
            this.btnExportExcel.Location = new System.Drawing.Point(543, 81);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(98, 26);
            this.btnExportExcel.TabIndex = 17;
            this.btnExportExcel.Text = "&Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.btnExportExcel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnExportExcel_KeyDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::TaxiOperation_KhachHang.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(448, 81);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 26);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRefresh_KeyDown);
            // 
            // grdTongHop
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdTongHop.DesignTimeLayout = gridEXLayout1;
            this.grdTongHop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTongHop.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdTongHop.GroupByBoxVisible = false;
            this.grdTongHop.Location = new System.Drawing.Point(0, 113);
            this.grdTongHop.Name = "grdTongHop";
            this.grdTongHop.SaveSettings = false;
            this.grdTongHop.Size = new System.Drawing.Size(1080, 456);
            this.grdTongHop.TabIndex = 18;
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdTongHop;
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.grdTongHop;
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
            // frmBC_3_1_TongHopPhanAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 569);
            this.Controls.Add(this.grdTongHop);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_3_1_TongHopPhanAnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo tổng hợp thông tin khách hàng phản ánh";
            this.Load += new System.EventHandler(this.frmBC_3_1_TongHopPhanAnh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTongHop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.GridEX grdTongHop;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}