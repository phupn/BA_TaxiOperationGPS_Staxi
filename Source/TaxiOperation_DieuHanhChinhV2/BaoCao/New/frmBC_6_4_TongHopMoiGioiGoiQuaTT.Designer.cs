namespace Taxi.GUI.BaoCao
{
    partial class frmBC_6_4_TongHopMoiGioiGoiQuaTT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_6_4_TongHopMoiGioiGoiQuaTT));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridDienThoai = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter2 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.lblTuNgayDen = new System.Windows.Forms.Label();
            this.btnPrint = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = " BÁO CÁO TỔNG HỢP MÔI GIỚI GỌI QUA TRUNG TÂM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
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
            this.calTuNgay.Location = new System.Drawing.Point(243, 30);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(93, 20);
            this.calTuNgay.TabIndex = 2;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
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
            this.calDenNgay.Location = new System.Drawing.Point(398, 30);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(89, 20);
            this.calDenNgay.TabIndex = 4;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(315, 67);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(231, 67);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.gridDienThoai;
            // 
            // gridDienThoai
            // 
            this.gridDienThoai.AllowColumnDrag = false;
            this.gridDienThoai.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridDienThoai.AutomaticSort = false;
            this.gridDienThoai.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.gridDienThoai.GroupByBoxVisible = false;
            this.gridDienThoai.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gridEXLayout1.IsCurrentLayout = true;
            gridEXLayout1.Key = "1";
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridDienThoai.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout1});
            this.gridDienThoai.Location = new System.Drawing.Point(0, 109);
            this.gridDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.gridDienThoai.Name = "gridDienThoai";
            this.gridDienThoai.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridDienThoai.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.FontSize = 9F;
            this.gridDienThoai.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Empty;
            this.gridDienThoai.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridDienThoai.RowHeaderFormatStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridDienThoai.RowHeaderFormatStyle.FontSize = 10F;
            this.gridDienThoai.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridDienThoai.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridDienThoai.SaveSettings = false;
            this.gridDienThoai.SettingsKey = "gridDienThoai";
            this.gridDienThoai.Size = new System.Drawing.Size(712, 162);
            this.gridDienThoai.TabIndex = 21;
            this.gridDienThoai.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gridDienThoai.TableSpacing = 8;
            this.gridDienThoai.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridDienThoai;
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
            // gridEX1
            // 
            this.gridEX1.AllowColumnDrag = false;
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.AutomaticSort = false;
            this.gridEX1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridEX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gridEXLayout2.IsCurrentLayout = true;
            gridEXLayout2.Key = "1";
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridEX1.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout2});
            this.gridEX1.Location = new System.Drawing.Point(0, 275);
            this.gridEX1.Margin = new System.Windows.Forms.Padding(2);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridEX1.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridEX1.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridEX1.RowFormatStyle.FontSize = 9F;
            this.gridEX1.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Empty;
            this.gridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridEX1.RowHeaderFormatStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridEX1.RowHeaderFormatStyle.FontSize = 10F;
            this.gridEX1.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.SaveSettings = false;
            this.gridEX1.SettingsKey = "gridDienThoai";
            this.gridEX1.Size = new System.Drawing.Size(712, 162);
            this.gridEX1.TabIndex = 22;
            this.gridEX1.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gridEX1.TableSpacing = 8;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // gridEXExporter2
            // 
            this.gridEXExporter2.GridEX = this.gridEX1;
            // 
            // lblTuNgayDen
            // 
            this.lblTuNgayDen.AutoSize = true;
            this.lblTuNgayDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgayDen.Location = new System.Drawing.Point(243, 57);
            this.lblTuNgayDen.Name = "lblTuNgayDen";
            this.lblTuNgayDen.Size = new System.Drawing.Size(0, 13);
            this.lblTuNgayDen.TabIndex = 23;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPrint.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Printer;
            this.btnPrint.Location = new System.Drawing.Point(405, 67);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 26);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmBC_6_4_TongHopMoiGioiGoiQuaTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 463);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTuNgayDen);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.gridDienThoai);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_6_4_TongHopMoiGioiGoiQuaTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5.7 Báo cáo tổng hợp môi giới gọi qua trung tâm";
            this.Load += new System.EventHandler(this.frm_5_7_BCTongHopMoiGioiGoiQuaTT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.GridEX.GridEX gridDienThoai;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter2;
        private System.Windows.Forms.Label lblTuNgayDen;
        private Janus.Windows.EditControls.UIButton btnPrint;
       
    }
}