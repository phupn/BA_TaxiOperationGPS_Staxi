namespace Taxi.GUI.BaoCao
{
    partial class frmBaoCaoBieuMau3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoBieuMau3));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnPrint = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridDienThoai = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.chkGoiKhac = new Janus.Windows.EditControls.UICheckBox();
            this.chkGoiTaxi = new Janus.Windows.EditControls.UICheckBox();
            this.chkGoiLai = new Janus.Windows.EditControls.UICheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.editPhoneNumber = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editSoChuong = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ilButtons = new System.Windows.Forms.ImageList(this.components);
            this.player1 = new Alvas.Audio.Player();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbPosition = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.timeThoiGianDamThoai = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calThoiGianChuyenTongDai = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label7 = new System.Windows.Forms.Label();
            this.chkGoiKhieuNai = new Janus.Windows.EditControls.UICheckBox();
            this.txtDiaChi = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.editVung = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO CUỘC GỌI ĐẾN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 34);
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
            this.calTuNgay.Location = new System.Drawing.Point(328, 32);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(141, 20);
            this.calTuNgay.TabIndex = 2;
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
            this.calDenNgay.Location = new System.Drawing.Point(530, 32);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(141, 20);
            this.calDenNgay.TabIndex = 4;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(598, 164);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Printer;
            this.btnPrint.Location = new System.Drawing.Point(534, 164);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(62, 26);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "&In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(453, 164);
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
            this.gridDienThoai.Location = new System.Drawing.Point(8, 223);
            this.gridDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.gridDienThoai.Name = "gridDienThoai";
            this.gridDienThoai.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridDienThoai.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.FontSize = 9F;
            this.gridDienThoai.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Empty;
            this.gridDienThoai.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridDienThoai.RowHeaderFormatStyle.Font = new System.Drawing.Font("Tahoma", 7F);
            this.gridDienThoai.RowHeaderFormatStyle.FontSize = 10F;
            this.gridDienThoai.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridDienThoai.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridDienThoai.SaveSettings = false;
            this.gridDienThoai.SettingsKey = "gridDienThoai";
            this.gridDienThoai.Size = new System.Drawing.Size(1023, 503);
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
            // chkGoiKhac
            // 
            this.chkGoiKhac.BackColor = System.Drawing.Color.Transparent;
            this.chkGoiKhac.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoiKhac.Location = new System.Drawing.Point(545, 58);
            this.chkGoiKhac.Margin = new System.Windows.Forms.Padding(2);
            this.chkGoiKhac.Name = "chkGoiKhac";
            this.chkGoiKhac.Size = new System.Drawing.Size(62, 19);
            this.chkGoiKhac.TabIndex = 12;
            this.chkGoiKhac.Text = "Gọi &khác";
            this.chkGoiKhac.CheckedChanged += new System.EventHandler(this.chkGoiKhac_CheckedChanged);
            // 
            // chkGoiTaxi
            // 
            this.chkGoiTaxi.BackColor = System.Drawing.Color.Transparent;
            this.chkGoiTaxi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoiTaxi.Location = new System.Drawing.Point(329, 58);
            this.chkGoiTaxi.Margin = new System.Windows.Forms.Padding(2);
            this.chkGoiTaxi.Name = "chkGoiTaxi";
            this.chkGoiTaxi.Size = new System.Drawing.Size(68, 19);
            this.chkGoiTaxi.TabIndex = 9;
            this.chkGoiTaxi.Text = "&Gọi taxi";
            this.chkGoiTaxi.CheckedChanged += new System.EventHandler(this.chkGoiTaxi_CheckedChanged);
            // 
            // chkGoiLai
            // 
            this.chkGoiLai.BackColor = System.Drawing.Color.Transparent;
            this.chkGoiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoiLai.Location = new System.Drawing.Point(400, 58);
            this.chkGoiLai.Margin = new System.Windows.Forms.Padding(2);
            this.chkGoiLai.Name = "chkGoiLai";
            this.chkGoiLai.Size = new System.Drawing.Size(50, 19);
            this.chkGoiLai.TabIndex = 10;
            this.chkGoiLai.Text = "Gọi &lại";
            this.chkGoiLai.CheckedChanged += new System.EventHandler(this.chkGoiLai_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Gọi đến từ số máy";
            // 
            // editPhoneNumber
            // 
            this.editPhoneNumber.Location = new System.Drawing.Point(329, 111);
            this.editPhoneNumber.MaxLength = 50;
            this.editPhoneNumber.Name = "editPhoneNumber";
            this.editPhoneNumber.Size = new System.Drawing.Size(342, 20);
            this.editPhoneNumber.TabIndex = 14;
            this.editPhoneNumber.TextChanged += new System.EventHandler(this.editPhoneNumber_TextChanged);
            this.editPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editPhoneNumber_KeyPress);
            // 
            // editSoChuong
            // 
            this.editSoChuong.Location = new System.Drawing.Point(329, 137);
            this.editSoChuong.MaxLength = 2;
            this.editSoChuong.Name = "editSoChuong";
            this.editSoChuong.Size = new System.Drawing.Size(31, 20);
            this.editSoChuong.TabIndex = 16;
            this.editSoChuong.TextChanged += new System.EventHandler(this.editSoChuong_TextChanged);
            this.editSoChuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoChuong_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nhấc máy sau";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "(chuông)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Thời gian đàm thoại trên";
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
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPause.ImageIndex = 2;
            this.btnPause.ImageList = this.ilButtons;
            this.btnPause.Location = new System.Drawing.Point(61, 195);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(63, 21);
            this.btnPause.TabIndex = 24;
            this.btnPause.Text = "Pause";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.ImageIndex = 1;
            this.btnPlay.ImageList = this.ilButtons;
            this.btnPlay.Location = new System.Drawing.Point(8, 195);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(49, 21);
            this.btnPlay.TabIndex = 22;
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
            this.btnStop.Location = new System.Drawing.Point(128, 195);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(61, 21);
            this.btnStop.TabIndex = 23;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(193, 194);
            this.tbPosition.Margin = new System.Windows.Forms.Padding(2);
            this.tbPosition.Maximum = 100;
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(828, 45);
            this.tbPosition.TabIndex = 25;
            this.tbPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbPosition.Scroll += new System.EventHandler(this.tbPosition_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(677, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "( Các số máy cách nhau dấu \';\' )";
            // 
            // timeThoiGianDamThoai
            // 
            this.timeThoiGianDamThoai.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.timeThoiGianDamThoai.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Time;
            // 
            // 
            // 
            this.timeThoiGianDamThoai.DropDownCalendar.FirstMonth = new System.DateTime(2008, 11, 1, 0, 0, 0, 0);
            this.timeThoiGianDamThoai.DropDownCalendar.Name = "";
            this.timeThoiGianDamThoai.Location = new System.Drawing.Point(329, 164);
            this.timeThoiGianDamThoai.MinuteIncrement = 1;
            this.timeThoiGianDamThoai.Name = "timeThoiGianDamThoai";
            this.timeThoiGianDamThoai.SecondIncrement = 1;
            this.timeThoiGianDamThoai.ShowDropDown = false;
            this.timeThoiGianDamThoai.ShowUpDown = true;
            this.timeThoiGianDamThoai.Size = new System.Drawing.Size(69, 20);
            this.timeThoiGianDamThoai.TabIndex = 36;
            this.timeThoiGianDamThoai.TextChanged += new System.EventHandler(this.timeThoiGianDamThoai_TextChanged);
            // 
            // calThoiGianChuyenTongDai
            // 
            this.calThoiGianChuyenTongDai.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.calThoiGianChuyenTongDai.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Time;
            // 
            // 
            // 
            this.calThoiGianChuyenTongDai.DropDownCalendar.FirstMonth = new System.DateTime(2008, 11, 1, 0, 0, 0, 0);
            this.calThoiGianChuyenTongDai.DropDownCalendar.Name = "";
            this.calThoiGianChuyenTongDai.Location = new System.Drawing.Point(602, 137);
            this.calThoiGianChuyenTongDai.MinuteIncrement = 1;
            this.calThoiGianChuyenTongDai.Name = "calThoiGianChuyenTongDai";
            this.calThoiGianChuyenTongDai.SecondIncrement = 1;
            this.calThoiGianChuyenTongDai.ShowDropDown = false;
            this.calThoiGianChuyenTongDai.ShowUpDown = true;
            this.calThoiGianChuyenTongDai.Size = new System.Drawing.Size(69, 20);
            this.calThoiGianChuyenTongDai.TabIndex = 38;
            this.calThoiGianChuyenTongDai.TextChanged += new System.EventHandler(this.calThoiGianChuyenTongDai_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(444, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Thời gian chuyển tổng đài trên";
            // 
            // chkGoiKhieuNai
            // 
            this.chkGoiKhieuNai.BackColor = System.Drawing.Color.Transparent;
            this.chkGoiKhieuNai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoiKhieuNai.Location = new System.Drawing.Point(454, 58);
            this.chkGoiKhieuNai.Margin = new System.Windows.Forms.Padding(2);
            this.chkGoiKhieuNai.Name = "chkGoiKhieuNai";
            this.chkGoiKhieuNai.Size = new System.Drawing.Size(87, 19);
            this.chkGoiKhieuNai.TabIndex = 39;
            this.chkGoiKhieuNai.Text = "Gọi khiếu nại";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(329, 82);
            this.txtDiaChi.MaxLength = 50;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(212, 20);
            this.txtDiaChi.TabIndex = 41;
            this.txtDiaChi.TextChanged += new System.EventHandler(this.txtDiaChi_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(276, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Địa chỉ ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(677, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "(1;3;4 - dấu chấm phẩu phân cách)";
            // 
            // editVung
            // 
            this.editVung.Location = new System.Drawing.Point(629, 80);
            this.editVung.MaxLength = 10;
            this.editVung.Name = "editVung";
            this.editVung.Size = new System.Drawing.Size(42, 20);
            this.editVung.TabIndex = 43;
            this.editVung.Text = "1";
            this.editVung.TextChanged += new System.EventHandler(this.editVung_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(547, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Cuộc gọi vùng";
            // 
            // frmBaoCaoBieuMau3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 725);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.editVung);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkGoiKhieuNai);
            this.Controls.Add(this.calThoiGianChuyenTongDai);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.timeThoiGianDamThoai);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.gridDienThoai);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.editSoChuong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.editPhoneNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkGoiKhac);
            this.Controls.Add(this.chkGoiTaxi);
            this.Controls.Add(this.chkGoiLai);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPosition);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoBieuMau3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BC 03 - Bao cao cuoc goi  den";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).EndInit();
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
        private Janus.Windows.EditControls.UIButton btnPrint;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.EditControls.UICheckBox chkGoiKhac;
        private Janus.Windows.EditControls.UICheckBox chkGoiTaxi;
        private Janus.Windows.EditControls.UICheckBox chkGoiLai;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.EditControls.EditBox editPhoneNumber;
        private Janus.Windows.GridEX.EditControls.EditBox editSoChuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.GridEX.GridEX gridDienThoai;
        private System.Windows.Forms.ImageList ilButtons;
        private Alvas.Audio.Player player1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbPosition;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.CalendarCombo.CalendarCombo timeThoiGianDamThoai;
        private Janus.Windows.CalendarCombo.CalendarCombo calThoiGianChuyenTongDai;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.EditControls.UICheckBox chkGoiKhieuNai;
        private Janus.Windows.GridEX.EditControls.EditBox txtDiaChi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Janus.Windows.GridEX.EditControls.EditBox editVung;
        private System.Windows.Forms.Label label12;
       
    }
}