namespace Taxi.GUI.BaoCao
{
    partial class frmBaoCaoGroupMoiGioi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoGroupMoiGioi));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout3 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout4 = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridDienThoai = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCongTy = new Janus.Windows.EditControls.UIComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.lnkCuocKhach999 = new System.Windows.Forms.LinkLabel();
            this.lnkCuocXoaTuDong = new System.Windows.Forms.LinkLabel();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.lnkTongHop = new System.Windows.Forms.LinkLabel();
            this.gridCuoc999 = new Janus.Windows.GridEX.GridEX();
            this.gridCuocTuXoa = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCuoc999)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCuocTuXoa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(297, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO TỔNG HỢP CUỘC GỌI MÔI GIỚI";
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.gridDienThoai;
            // 
            // gridDienThoai
            // 
            this.gridDienThoai.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridDienThoai.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.gridDienThoai.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gridEXLayout1.IsCurrentLayout = true;
            gridEXLayout1.Key = "1";
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridDienThoai.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout1});
            this.gridDienThoai.Location = new System.Drawing.Point(-20, 151);
            this.gridDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.gridDienThoai.Name = "gridDienThoai";
            this.gridDienThoai.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridDienThoai.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.FontSize = 9F;
            this.gridDienThoai.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridDienThoai.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridDienThoai.RowHeaderFormatStyle.Font = new System.Drawing.Font("Tahoma", 6F);
            this.gridDienThoai.RowHeaderFormatStyle.FontSize = 10F;
            this.gridDienThoai.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridDienThoai.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridDienThoai.SaveSettings = false;
            this.gridDienThoai.SettingsKey = "gridDienThoai";
            this.gridDienThoai.Size = new System.Drawing.Size(1023, 562);
            this.gridDienThoai.TabIndex = 21;
            this.gridDienThoai.TableSpacing = 8;
            this.gridDienThoai.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gridDienThoai.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridDienThoai_FormattingRow);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridDienThoai;
            this.gridEXExporter1.IncludeChildTables = true;
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
            this.calDenNgay.Location = new System.Drawing.Point(562, 47);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(141, 20);
            this.calDenNgay.TabIndex = 31;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 51);
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
            this.calTuNgay.Location = new System.Drawing.Point(360, 47);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(141, 20);
            this.calTuNgay.TabIndex = 29;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Từ ngày";
            // 
            // cboCongTy
            // 
            this.cboCongTy.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboCongTy.Location = new System.Drawing.Point(360, 73);
            this.cboCongTy.Name = "cboCongTy";
            this.cboCongTy.Size = new System.Drawing.Size(203, 20);
            this.cboCongTy.TabIndex = 39;
            this.cboCongTy.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.cboCongTy.SelectedIndexChanged += new System.EventHandler(this.cboCongTy_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Công ty";
            // 
            // gridEX1
            // 
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridEX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.gridEX1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gridEXLayout2.IsCurrentLayout = true;
            gridEXLayout2.Key = "1";
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridEX1.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout2});
            this.gridEX1.Location = new System.Drawing.Point(877, 10);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridEX1.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridEX1.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridEX1.RowFormatStyle.FontSize = 9F;
            this.gridEX1.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridEX1.RowHeaderFormatStyle.Font = new System.Drawing.Font("Tahoma", 6F);
            this.gridEX1.RowHeaderFormatStyle.FontSize = 10F;
            this.gridEX1.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(143, 91);
            this.gridEX1.TabIndex = 40;
            this.gridEX1.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gridEX1.TableSpacing = 8;
            this.gridEX1.Visible = false;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // lnkCuocKhach999
            // 
            this.lnkCuocKhach999.AutoSize = true;
            this.lnkCuocKhach999.Location = new System.Drawing.Point(648, 131);
            this.lnkCuocKhach999.Name = "lnkCuocKhach999";
            this.lnkCuocKhach999.Size = new System.Drawing.Size(114, 13);
            this.lnkCuocKhach999.TabIndex = 41;
            this.lnkCuocKhach999.TabStop = true;
            this.lnkCuocKhach999.Text = "Chi tiết uốc khách 999";
            this.lnkCuocKhach999.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCuocKhach999_LinkClicked);
            // 
            // lnkCuocXoaTuDong
            // 
            this.lnkCuocXoaTuDong.AutoSize = true;
            this.lnkCuocXoaTuDong.Location = new System.Drawing.Point(765, 130);
            this.lnkCuocXoaTuDong.Name = "lnkCuocXoaTuDong";
            this.lnkCuocXoaTuDong.Size = new System.Drawing.Size(126, 13);
            this.lnkCuocXoaTuDong.TabIndex = 42;
            this.lnkCuocXoaTuDong.TabStop = true;
            this.lnkCuocXoaTuDong.Text = "Chi tiết cuốc xóa tự động";
            this.lnkCuocXoaTuDong.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCuocXoaTuDong_LinkClicked);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(500, 120);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(416, 120);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lnkTongHop
            // 
            this.lnkTongHop.AutoSize = true;
            this.lnkTongHop.Location = new System.Drawing.Point(593, 131);
            this.lnkTongHop.Name = "lnkTongHop";
            this.lnkTongHop.Size = new System.Drawing.Size(53, 13);
            this.lnkTongHop.TabIndex = 43;
            this.lnkTongHop.TabStop = true;
            this.lnkTongHop.Text = "Tổng hợp";
            this.lnkTongHop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTongHop_LinkClicked);
            // 
            // gridCuoc999
            // 
            gridEXLayout3.LayoutString = resources.GetString("gridEXLayout3.LayoutString");
            this.gridCuoc999.DesignTimeLayout = gridEXLayout3;
            this.gridCuoc999.Location = new System.Drawing.Point(1, 151);
            this.gridCuoc999.Name = "gridCuoc999";
            this.gridCuoc999.SaveSettings = false;
            this.gridCuoc999.Size = new System.Drawing.Size(1002, 562);
            this.gridCuoc999.TabIndex = 44;
            // 
            // gridCuocTuXoa
            // 
            gridEXLayout4.LayoutString = resources.GetString("gridEXLayout4.LayoutString");
            this.gridCuocTuXoa.DesignTimeLayout = gridEXLayout4;
            this.gridCuocTuXoa.Location = new System.Drawing.Point(1, 152);
            this.gridCuocTuXoa.Name = "gridCuocTuXoa";
            this.gridCuocTuXoa.SaveSettings = false;
            this.gridCuocTuXoa.Size = new System.Drawing.Size(1002, 562);
            this.gridCuocTuXoa.TabIndex = 45;
            // 
            // frmBaoCaoGroupMoiGioi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 725);
            this.Controls.Add(this.lnkTongHop);
            this.Controls.Add(this.lnkCuocXoaTuDong);
            this.Controls.Add(this.lnkCuocKhach999);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.cboCongTy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridDienThoai);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridCuocTuXoa);
            this.Controls.Add(this.gridCuoc999);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoGroupMoiGioi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bao cao moi gioi - TaxiGroup";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCuoc999)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCuocTuXoa)).EndInit();
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
        private Janus.Windows.GridEX.GridEX gridDienThoai;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIComboBox cboCongTy;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.LinkLabel lnkCuocKhach999;
        private System.Windows.Forms.LinkLabel lnkCuocXoaTuDong;
        private System.Windows.Forms.LinkLabel lnkTongHop;
        private Janus.Windows.GridEX.GridEX gridCuoc999;
        private Janus.Windows.GridEX.GridEX gridCuocTuXoa;
       
    }
}