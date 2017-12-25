namespace Taxi.GUI.BaoCao
{
    partial class frmBC_5_3_BaoCaoHanhTrinhXe
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_5_3_BaoCaoHanhTrinhXe));
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
            this.label4 = new System.Windows.Forms.Label();
            this.editBienSoXe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ilButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnPrint = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO HÀNH TRÌNH XE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
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
            this.calTuNgay.Location = new System.Drawing.Point(328, 39);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(141, 20);
            this.calTuNgay.TabIndex = 0;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
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
            this.calDenNgay.Location = new System.Drawing.Point(530, 39);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(141, 20);
            this.calDenNgay.TabIndex = 1;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(461, 101);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 5;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(378, 101);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 3;
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
            gridEXLayout2.IsCurrentLayout = true;
            gridEXLayout2.Key = "1";
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridDienThoai.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout2});
            this.gridDienThoai.Location = new System.Drawing.Point(8, 149);
            this.gridDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.gridDienThoai.Name = "gridDienThoai";
            this.gridDienThoai.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridDienThoai.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.FontSize = 9F;
            this.gridDienThoai.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Empty;
            this.gridDienThoai.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridDienThoai.RowHeaderFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowHeaderFormatStyle.FontSize = 8F;
            this.gridDienThoai.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridDienThoai.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridDienThoai.SaveSettings = false;
            this.gridDienThoai.SettingsKey = "gridDienThoai";
            this.gridDienThoai.Size = new System.Drawing.Size(1023, 541);
            this.gridDienThoai.TabIndex = 21;
            this.gridDienThoai.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gridDienThoai.TableSpacing = 8;
            this.gridDienThoai.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gridDienThoai.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridDienThoai_FormattingRow);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Số hiệu xe";
            // 
            // editBienSoXe
            // 
            this.editBienSoXe.Location = new System.Drawing.Point(329, 65);
            this.editBienSoXe.MaxLength = 50;
            this.editBienSoXe.Name = "editBienSoXe";
            this.editBienSoXe.Size = new System.Drawing.Size(81, 20);
            this.editBienSoXe.TabIndex = 2;
            this.editBienSoXe.TextChanged += new System.EventHandler(this.editPhoneNumber_TextChanged);
            this.editBienSoXe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editPhoneNumber_KeyPress);
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
            // btnPrint
            // 
            this.btnPrint.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPrint.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Printer;
            this.btnPrint.Location = new System.Drawing.Point(551, 101);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 26);
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmBC_5_3_BaoCaoHanhTrinhXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 725);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.gridDienThoai);
            this.Controls.Add(this.editBienSoXe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_5_3_BaoCaoHanhTrinhXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BC 5.3 - Bao cao hanh trinh xe";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.EditControls.EditBox editBienSoXe;
        private Janus.Windows.GridEX.GridEX gridDienThoai;
        private System.Windows.Forms.ImageList ilButtons;
        private Janus.Windows.EditControls.UIButton btnPrint;
       
    }
}