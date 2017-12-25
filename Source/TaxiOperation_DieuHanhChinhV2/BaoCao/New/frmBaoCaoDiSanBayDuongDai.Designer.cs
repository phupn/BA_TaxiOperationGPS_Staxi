namespace Taxi.GUI.BaoCao
{
    partial class frmBaoCaoDiSanBayDuongDai
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoDiSanBayDuongDai));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter();
            this.gridBaoCaoBieuMau1 = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.ilButtons = new System.Windows.Forms.ImageList();
            this.cbDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cbTinhThanh = new System.Windows.Forms.ComboBox();
            this.cbTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new Janus.Windows.EditControls.UIButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGara = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO XE ĐI SÂN BAY ĐƯỜNG DÀI THEO NGÀY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridBaoCaoBieuMau1;
            // 
            // gridBaoCaoBieuMau1
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridBaoCaoBieuMau1.DesignTimeLayout = gridEXLayout1;
            this.gridBaoCaoBieuMau1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBaoCaoBieuMau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridBaoCaoBieuMau1.GroupByBoxVisible = false;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.Location = new System.Drawing.Point(0, 0);
            this.gridBaoCaoBieuMau1.Name = "gridBaoCaoBieuMau1";
            this.gridBaoCaoBieuMau1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridBaoCaoBieuMau1.RowHeaderFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBaoCaoBieuMau1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBaoCaoBieuMau1.SaveSettings = false;
            this.gridBaoCaoBieuMau1.Size = new System.Drawing.Size(994, 362);
            this.gridBaoCaoBieuMau1.TabIndex = 11;
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
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Printer;
            this.btnExportExcel.Location = new System.Drawing.Point(898, 12);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "In (Ctrl + P)";
            this.btnExportExcel.Visible = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(656, 64);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            // cbDenNgay
            // 
            this.cbDenNgay.CustomFormat = "HH:mm dd/MM/yyyy ";
            this.cbDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.cbDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 7, 1, 0, 0, 0, 0);
            this.cbDenNgay.DropDownCalendar.Name = "";
            this.cbDenNgay.Location = new System.Drawing.Point(503, 42);
            this.cbDenNgay.Margin = new System.Windows.Forms.Padding(4);
            this.cbDenNgay.Name = "cbDenNgay";
            this.cbDenNgay.Size = new System.Drawing.Size(136, 20);
            this.cbDenNgay.TabIndex = 12;
            this.cbDenNgay.Value = new System.DateTime(2011, 7, 26, 9, 15, 24, 0);
            // 
            // cbTinhThanh
            // 
            this.cbTinhThanh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTinhThanh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTinhThanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTinhThanh.Location = new System.Drawing.Point(296, 69);
            this.cbTinhThanh.Margin = new System.Windows.Forms.Padding(4);
            this.cbTinhThanh.Name = "cbTinhThanh";
            this.cbTinhThanh.Size = new System.Drawing.Size(135, 21);
            this.cbTinhThanh.TabIndex = 10;
            // 
            // cbTuNgay
            // 
            this.cbTuNgay.CustomFormat = "HH:mm dd/MM/yyyy ";
            this.cbTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.cbTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 7, 1, 0, 0, 0, 0);
            this.cbTuNgay.DropDownCalendar.Name = "";
            this.cbTuNgay.Location = new System.Drawing.Point(296, 42);
            this.cbTuNgay.Margin = new System.Windows.Forms.Padding(4);
            this.cbTuNgay.Name = "cbTuNgay";
            this.cbTuNgay.Size = new System.Drawing.Size(135, 20);
            this.cbTuNgay.TabIndex = 11;
            this.cbTuNgay.Value = new System.DateTime(2011, 7, 26, 9, 14, 54, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Đến";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tỉnh thành";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbGara);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnExportExcel);
            this.panel2.Controls.Add(this.cbDenNgay);
            this.panel2.Controls.Add(this.cbTuNgay);
            this.panel2.Controls.Add(this.cbTinhThanh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 100);
            this.panel2.TabIndex = 16;
            // 
            // btnExport
            // 
            this.btnExport.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnExport.Enabled = false;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExport.Location = new System.Drawing.Point(740, 64);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 26);
            this.btnExport.TabIndex = 29;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Đội xe";
            // 
            // cbGara
            // 
            this.cbGara.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGara.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGara.Location = new System.Drawing.Point(503, 69);
            this.cbGara.Margin = new System.Windows.Forms.Padding(4);
            this.cbGara.Name = "cbGara";
            this.cbGara.Size = new System.Drawing.Size(135, 21);
            this.cbGara.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridBaoCaoBieuMau1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 362);
            this.panel1.TabIndex = 17;
            // 
            // frmBaoCaoDiSanBayDuongDai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Taxi;
            this.Name = "frmBaoCaoDiSanBayDuongDai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO XE ĐI SÂN BAY ĐƯỜNG DÀI THEO NGÀY";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ImageList ilButtons;
        public Janus.Windows.CalendarCombo.CalendarCombo cbDenNgay;
        public System.Windows.Forms.ComboBox cbTinhThanh;
        public Janus.Windows.CalendarCombo.CalendarCombo cbTuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Janus.Windows.GridEX.GridEX gridBaoCaoBieuMau1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbGara;
        private Janus.Windows.EditControls.UIButton btnExport;
       
    }
}