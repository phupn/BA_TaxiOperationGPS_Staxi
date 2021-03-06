namespace TaxiOperation_TongDai.BaoCaoPhanAnh
{
    partial class BaoCaoGiaiQuyetPhanAnh_3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaoCaoGiaiQuyetPhanAnh_3));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdBaoCaoGiaiQuyet = new Janus.Windows.GridEX.GridEX();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaoCaoGiaiQuyet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO GIẢI QUYẾT THÔNG TIN KHÁCH HÀNG PHẢN ÁNH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "TRUNG TÂM ĐIỀU HÀNH TAXI GROUP";
            // 
            // grdBaoCaoGiaiQuyet
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdBaoCaoGiaiQuyet.DesignTimeLayout = gridEXLayout1;
            this.grdBaoCaoGiaiQuyet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdBaoCaoGiaiQuyet.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.grdBaoCaoGiaiQuyet.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdBaoCaoGiaiQuyet.GroupByBoxVisible = false;
            this.grdBaoCaoGiaiQuyet.Location = new System.Drawing.Point(0, 189);
            this.grdBaoCaoGiaiQuyet.Name = "grdBaoCaoGiaiQuyet";
            this.grdBaoCaoGiaiQuyet.SaveSettings = false;
            this.grdBaoCaoGiaiQuyet.Size = new System.Drawing.Size(1175, 351);
            this.grdBaoCaoGiaiQuyet.TabIndex = 2;
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
            this.calTuNgay.Location = new System.Drawing.Point(350, 93);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(148, 23);
            this.calTuNgay.TabIndex = 4;
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
            this.calDenNgay.Location = new System.Drawing.Point(616, 93);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(150, 23);
            this.calDenNgay.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(281, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Từ ngày ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(544, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đến ngày ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::TaxiOperation_TongDai.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(392, 132);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 26);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::TaxiOperation_TongDai.Properties.Resources.Excel_24x24;
            this.btnExportExcel.Location = new System.Drawing.Point(534, 132);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(98, 26);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdBaoCaoGiaiQuyet;
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
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.grdBaoCaoGiaiQuyet;
            // 
            // BaoCaoGiaiQuyetPhanAnh_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 540);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.grdBaoCaoGiaiQuyet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BaoCaoGiaiQuyetPhanAnh_3";
            this.Text = "BaoCaoGiaiQuyetPhanAnh_3";
            ((System.ComponentModel.ISupportInitialize)(this.grdBaoCaoGiaiQuyet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.GridEX.GridEX grdBaoCaoGiaiQuyet;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
    }
}