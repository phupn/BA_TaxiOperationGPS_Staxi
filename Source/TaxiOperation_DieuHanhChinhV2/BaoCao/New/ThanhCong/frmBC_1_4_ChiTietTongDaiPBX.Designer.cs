namespace Taxi.GUI.BaoCao.ThanhCong
{
    partial class frmBC_1_4_ChiTietTongDaiPBX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_1_4_ChiTietTongDaiPBX));
            this.label1 = new System.Windows.Forms.Label();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.gridBaoCaoBieuMau1 = new Janus.Windows.GridEX.GridEX();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.player1 = new Alvas.Audio.Player();
            this.btnPause = new System.Windows.Forms.Button();
            this.ilButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtLine = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPosition = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdGetRecordingFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGetRecordingFile");
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdGetRecordingFile = new Janus.Windows.UI.CommandBars.UICommand("cmdGetRecordingFile");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.radGoiDen = new System.Windows.Forms.RadioButton();
            this.radGoiDi = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRA CỨU THÔNG TIN CUỐC GỌI TỔNG ĐÀI";
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
            this.calDenNgay.Location = new System.Drawing.Point(432, 37);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(143, 20);
            this.calDenNgay.TabIndex = 4;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày";
            // 
            // gridBaoCaoBieuMau1
            // 
            this.gridBaoCaoBieuMau1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.uiCommandManager1.SetContextMenu(this.gridBaoCaoBieuMau1, this.uiContextMenu1);
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
            this.gridBaoCaoBieuMau1.Size = new System.Drawing.Size(757, 483);
            this.gridBaoCaoBieuMau1.TabIndex = 9;
            this.gridBaoCaoBieuMau1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridBaoCaoBieuMau1_FormattingRow);
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.gridBaoCaoBieuMau1;
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridBaoCaoBieuMau1;
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
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(392, 146);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // player1
            // 
            this.player1.FileName = "";
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPause.ImageIndex = 2;
            this.btnPause.ImageList = this.ilButtons;
            this.btnPause.Location = new System.Drawing.Point(62, 172);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(63, 21);
            this.btnPause.TabIndex = 15;
            this.btnPause.Text = "Pause";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
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
            // btnPlay
            // 
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.ImageIndex = 1;
            this.btnPlay.ImageList = this.ilButtons;
            this.btnPlay.Location = new System.Drawing.Point(11, 172);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(49, 21);
            this.btnPlay.TabIndex = 13;
            this.btnPlay.Text = "Play";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.ImageIndex = 3;
            this.btnStop.ImageList = this.ilButtons;
            this.btnStop.Location = new System.Drawing.Point(124, 172);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(61, 21);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Điện thoại";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(203, 89);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(143, 20);
            this.txtPhoneNumber.TabIndex = 39;
            this.txtPhoneNumber.TextChanged += new System.EventHandler(this.txtPhoneNumber_TextChanged);
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(203, 115);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(69, 20);
            this.txtLine.TabIndex = 42;
            this.txtLine.TextChanged += new System.EventHandler(this.txtLine_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Line";
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(194, 172);
            this.tbPosition.Margin = new System.Windows.Forms.Padding(2);
            this.tbPosition.Maximum = 100;
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(538, 45);
            this.tbPosition.TabIndex = 16;
            this.tbPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(151, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Từ ngày";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(373, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Đến ngày";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radGoiDi);
            this.panel2.Controls.Add(this.radGoiDen);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbPosition);
            this.panel2.Controls.Add(this.calTuNgay);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.calDenNgay);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtLine);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnExportExcel);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.txtPhoneNumber);
            this.panel2.Controls.Add(this.btnPlay);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnPause);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(757, 206);
            this.panel2.TabIndex = 47;
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
            this.calTuNgay.Location = new System.Drawing.Point(203, 39);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(143, 20);
            this.calTuNgay.TabIndex = 2;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(308, 146);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridBaoCaoBieuMau1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 483);
            this.panel1.TabIndex = 48;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdGetRecordingFile});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1});
            this.uiCommandManager1.Id = new System.Guid("300a5689-2a3f-42c4-8628-c614ca9300e3");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdGetRecordingFile1});
            this.uiContextMenu1.Key = "ContextMenu1";
            // 
            // cmdGetRecordingFile1
            // 
            this.cmdGetRecordingFile1.Key = "cmdGetRecordingFile";
            this.cmdGetRecordingFile1.Name = "cmdGetRecordingFile1";
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 689);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(757, 0);
            // 
            // cmdGetRecordingFile
            // 
            this.cmdGetRecordingFile.Key = "cmdGetRecordingFile";
            this.cmdGetRecordingFile.Name = "cmdGetRecordingFile";
            this.cmdGetRecordingFile.Text = "Lấy file ghi âm";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 689);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(757, 0);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 689);
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(757, 0);
            // 
            // radGoiDen
            // 
            this.radGoiDen.AutoSize = true;
            this.radGoiDen.Checked = true;
            this.radGoiDen.Location = new System.Drawing.Point(203, 66);
            this.radGoiDen.Name = "radGoiDen";
            this.radGoiDen.Size = new System.Drawing.Size(63, 17);
            this.radGoiDen.TabIndex = 45;
            this.radGoiDen.TabStop = true;
            this.radGoiDen.Text = "Gọi đến";
            this.radGoiDen.UseVisualStyleBackColor = true;
            this.radGoiDen.CheckedChanged += new System.EventHandler(this.radGoiDen_CheckedChanged);
            // 
            // radGoiDi
            // 
            this.radGoiDi.AutoSize = true;
            this.radGoiDi.Location = new System.Drawing.Point(294, 67);
            this.radGoiDi.Name = "radGoiDi";
            this.radGoiDi.Size = new System.Drawing.Size(53, 17);
            this.radGoiDi.TabIndex = 46;
            this.radGoiDi.Text = "Gọi đi";
            this.radGoiDi.UseVisualStyleBackColor = true;
            this.radGoiDi.CheckedChanged += new System.EventHandler(this.radGoiDi_CheckedChanged);
            // 
            // frmBC_1_4_ChiTietTongDaiPBX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LeftRebar1);
            this.Controls.Add(this.RightRebar1);
            this.Controls.Add(this.TopRebar1);
            this.Controls.Add(this.BottomRebar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_1_4_ChiTietTongDaiPBX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra cứu thông tin cuối gọi tổng đài";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.GridEX.GridEX gridBaoCaoBieuMau1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Alvas.Audio.Player player1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ImageList ilButtons;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.GridEX.EditControls.EditBox txtPhoneNumber;
        private Janus.Windows.GridEX.EditControls.EditBox txtLine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tbPosition;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGetRecordingFile;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGetRecordingFile1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.RadioButton radGoiDi;
        private System.Windows.Forms.RadioButton radGoiDen;
       
    }
}