namespace Taxi.GUI.BaoCao
{
    partial class frmBaoCaoBieuMau6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoBieuMau6));
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnPrint = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridDienThoai = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.editVung = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label5 = new System.Windows.Forms.Label();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTruot = new System.Windows.Forms.CheckBox();
            this.chkKhachHoan = new System.Windows.Forms.CheckBox();
            this.chkKhongXe = new System.Windows.Forms.CheckBox();
            this.timeThoiGianDieuXe = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ilButtons = new System.Windows.Forms.ImageList(this.components);
            this.player1 = new Alvas.Audio.Player();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbPosition = new System.Windows.Forms.TrackBar();
            this.timeChuyenTongDai = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO CUỘC GỌI KHÔNG ĐÓN ĐƯỢC KHÁCH";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(509, 145);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Printer;
            this.btnPrint.Location = new System.Drawing.Point(445, 145);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(62, 26);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "&In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(364, 145);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 7;
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
            this.gridDienThoai.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.gridDienThoai.GroupByBoxVisible = false;
            this.gridDienThoai.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gridEXLayout1.IsCurrentLayout = true;
            gridEXLayout1.Key = "1";
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridDienThoai.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout1});
            this.gridDienThoai.Location = new System.Drawing.Point(8, 207);
            this.gridDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.gridDienThoai.Name = "gridDienThoai";
            this.gridDienThoai.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridDienThoai.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.FontSize = 9F;
            this.gridDienThoai.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Empty;
            this.gridDienThoai.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridDienThoai.RowHeaderFormatStyle.Font = new System.Drawing.Font("Tahoma", 6F);
            this.gridDienThoai.RowHeaderFormatStyle.FontSize = 10F;
            this.gridDienThoai.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridDienThoai.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridDienThoai.SaveSettings = false;
            this.gridDienThoai.SettingsKey = "gridDienThoai";
            this.gridDienThoai.Size = new System.Drawing.Size(1023, 519);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(471, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "(1;3;4 - dấu chấm phẩu phân cách)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(474, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Thời gian điều xe trên";
            // 
            // editVung
            // 
            this.editVung.Location = new System.Drawing.Point(364, 69);
            this.editVung.MaxLength = 10;
            this.editVung.Name = "editVung";
            this.editVung.Size = new System.Drawing.Size(101, 20);
            this.editVung.TabIndex = 2;
            this.editVung.TextChanged += new System.EventHandler(this.editVung_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Cuộc gọi vùng";
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
            this.calDenNgay.Location = new System.Drawing.Point(526, 42);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(141, 20);
            this.calDenNgay.TabIndex = 1;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 46);
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
            this.calTuNgay.Location = new System.Drawing.Point(324, 42);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(141, 20);
            this.calTuNgay.TabIndex = 0;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Từ ngày";
            // 
            // chkTruot
            // 
            this.chkTruot.AutoSize = true;
            this.chkTruot.Location = new System.Drawing.Point(364, 122);
            this.chkTruot.Name = "chkTruot";
            this.chkTruot.Size = new System.Drawing.Size(84, 17);
            this.chkTruot.TabIndex = 4;
            this.chkTruot.Text = "Trượt khách";
            this.chkTruot.UseVisualStyleBackColor = true;
            this.chkTruot.CheckedChanged += new System.EventHandler(this.chkTruot_CheckedChanged);
            // 
            // chkKhachHoan
            // 
            this.chkKhachHoan.AutoSize = true;
            this.chkKhachHoan.Location = new System.Drawing.Point(446, 122);
            this.chkKhachHoan.Name = "chkKhachHoan";
            this.chkKhachHoan.Size = new System.Drawing.Size(84, 17);
            this.chkKhachHoan.TabIndex = 5;
            this.chkKhachHoan.Text = "Khách hoãn";
            this.chkKhachHoan.UseVisualStyleBackColor = true;
            this.chkKhachHoan.CheckedChanged += new System.EventHandler(this.chkKhachHoan_CheckedChanged);
            // 
            // chkKhongXe
            // 
            this.chkKhongXe.AutoSize = true;
            this.chkKhongXe.Location = new System.Drawing.Point(531, 122);
            this.chkKhongXe.Name = "chkKhongXe";
            this.chkKhongXe.Size = new System.Drawing.Size(71, 17);
            this.chkKhongXe.TabIndex = 6;
            this.chkKhongXe.Text = "Không xe";
            this.chkKhongXe.UseVisualStyleBackColor = true;
            this.chkKhongXe.CheckedChanged += new System.EventHandler(this.chkKhongXe_CheckedChanged);
            // 
            // timeThoiGianDieuXe
            // 
            this.timeThoiGianDieuXe.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.timeThoiGianDieuXe.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Time;
            // 
            // 
            // 
            this.timeThoiGianDieuXe.DropDownCalendar.FirstMonth = new System.DateTime(2008, 11, 1, 0, 0, 0, 0);
            this.timeThoiGianDieuXe.DropDownCalendar.Name = "";
            this.timeThoiGianDieuXe.Location = new System.Drawing.Point(590, 93);
            this.timeThoiGianDieuXe.MinuteIncrement = 1;
            this.timeThoiGianDieuXe.Name = "timeThoiGianDieuXe";
            this.timeThoiGianDieuXe.SecondIncrement = 1;
            this.timeThoiGianDieuXe.ShowDropDown = false;
            this.timeThoiGianDieuXe.ShowUpDown = true;
            this.timeThoiGianDieuXe.Size = new System.Drawing.Size(69, 20);
            this.timeThoiGianDieuXe.TabIndex = 3;
            this.timeThoiGianDieuXe.TextChanged += new System.EventHandler(this.timeThoiGianDieuXe_TextChanged);
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
            // player1
            // 
            this.player1.FileName = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPause.ImageIndex = 2;
            this.btnPause.ImageList = this.ilButtons;
            this.btnPause.Location = new System.Drawing.Point(61, 177);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(63, 21);
            this.btnPause.TabIndex = 43;
            this.btnPause.Text = "Pause";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.ImageIndex = 1;
            this.btnPlay.ImageList = this.ilButtons;
            this.btnPlay.Location = new System.Drawing.Point(8, 177);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(49, 21);
            this.btnPlay.TabIndex = 41;
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
            this.btnStop.Location = new System.Drawing.Point(128, 177);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(61, 21);
            this.btnStop.TabIndex = 42;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(193, 176);
            this.tbPosition.Margin = new System.Windows.Forms.Padding(2);
            this.tbPosition.Maximum = 100;
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(828, 45);
            this.tbPosition.TabIndex = 44;
            this.tbPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // timeChuyenTongDai
            // 
            this.timeChuyenTongDai.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.timeChuyenTongDai.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Time;
            // 
            // 
            // 
            this.timeChuyenTongDai.DropDownCalendar.FirstMonth = new System.DateTime(2008, 11, 1, 0, 0, 0, 0);
            this.timeChuyenTongDai.DropDownCalendar.Name = "";
            this.timeChuyenTongDai.Location = new System.Drawing.Point(364, 93);
            this.timeChuyenTongDai.MinuteIncrement = 1;
            this.timeChuyenTongDai.Name = "timeChuyenTongDai";
            this.timeChuyenTongDai.SecondIncrement = 1;
            this.timeChuyenTongDai.ShowDropDown = false;
            this.timeChuyenTongDai.ShowUpDown = true;
            this.timeChuyenTongDai.Size = new System.Drawing.Size(69, 20);
            this.timeChuyenTongDai.TabIndex = 45;
            this.timeChuyenTongDai.ValueChanged += new System.EventHandler(this.timeChuyenTongDai_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Thời gian chuyển tổng đài";
            // 
            // frmBaoCaoBieuMau6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 725);
            this.Controls.Add(this.timeChuyenTongDai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.timeThoiGianDieuXe);
            this.Controls.Add(this.chkKhongXe);
            this.Controls.Add(this.chkKhachHoan);
            this.Controls.Add(this.chkTruot);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.editVung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridDienThoai);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPosition);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoBieuMau6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BC 6 - Bao cao cuoc goi khong don duoc khach";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnPrint;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.GridEX.GridEX gridDienThoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.GridEX.EditControls.EditBox editVung;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTruot;
        private System.Windows.Forms.CheckBox chkKhachHoan;
        private System.Windows.Forms.CheckBox chkKhongXe;
        private Janus.Windows.CalendarCombo.CalendarCombo timeThoiGianDieuXe;
        private System.Windows.Forms.ImageList ilButtons;
        private Alvas.Audio.Player player1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar tbPosition;
        private Janus.Windows.CalendarCombo.CalendarCombo timeChuyenTongDai;
        private System.Windows.Forms.Label label4;
       
    }
}