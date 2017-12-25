namespace Taxi.GUI.BaoCao
{
    partial class frmBaoCaoCSKHChiTiet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoCSKHChiTiet));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.player1 = new Alvas.Audio.Player();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.myPanelControl2 = new Taxi.Controls.BanCo.MyPanelControl();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.myPanelControl1 = new Taxi.Controls.BanCo.MyPanelControl();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkGoiLai = new System.Windows.Forms.CheckBox();
            this.chkGoiTaxi = new System.Windows.Forms.CheckBox();
            this.txtIDDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDonDuocXe888 = new System.Windows.Forms.CheckBox();
            this.chkXe999 = new System.Windows.Forms.CheckBox();
            this.txtIDCS = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIDTD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkKhongXe = new System.Windows.Forms.CheckBox();
            this.chkTruotHoan = new System.Windows.Forms.CheckBox();
            this.chkDonDuoc = new System.Windows.Forms.CheckBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.gridEX2 = new Janus.Windows.GridEX.GridEX();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoLanGoiLai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVung = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPosition = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radGoiCSLan2 = new System.Windows.Forms.RadioButton();
            this.radGoiDenLan3 = new System.Windows.Forms.RadioButton();
            this.radGoiCSLan1 = new System.Windows.Forms.RadioButton();
            this.radGoiDenLan1 = new System.Windows.Forms.RadioButton();
            this.radGoiCSLan4 = new System.Windows.Forms.RadioButton();
            this.radGoiDenLan4 = new System.Windows.Forms.RadioButton();
            this.radGoiCSLan3 = new System.Windows.Forms.RadioButton();
            this.radGoiDenLan2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl2)).BeginInit();
            this.myPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl1)).BeginInit();
            this.myPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridEXExporter1
            // 
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
            // player1
            // 
            this.player1.FileName = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myPanelControl2
            // 
            this.myPanelControl2.Controls.Add(this.gridEX1);
            this.myPanelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPanelControl2.Location = new System.Drawing.Point(0, 265);
            this.myPanelControl2.Name = "myPanelControl2";
            this.myPanelControl2.Size = new System.Drawing.Size(1063, 460);
            this.myPanelControl2.TabIndex = 76;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEXLayout1;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridEX1.Location = new System.Drawing.Point(2, 2);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.gridEX1.SaveSettings = false;
            this.gridEX1.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.gridEX1.Size = new System.Drawing.Size(1059, 456);
            this.gridEX1.TabIndex = 44;
            this.gridEX1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridEX1_FormattingRow);
            this.gridEX1.SelectionChanged += new System.EventHandler(this.gridEX1_SelectionChanged);
            // 
            // myPanelControl1
            // 
            this.myPanelControl1.Controls.Add(this.txtSoDienThoai);
            this.myPanelControl1.Controls.Add(this.label13);
            this.myPanelControl1.Controls.Add(this.chkGoiLai);
            this.myPanelControl1.Controls.Add(this.chkGoiTaxi);
            this.myPanelControl1.Controls.Add(this.txtIDDT);
            this.myPanelControl1.Controls.Add(this.label4);
            this.myPanelControl1.Controls.Add(this.chkDonDuocXe888);
            this.myPanelControl1.Controls.Add(this.chkXe999);
            this.myPanelControl1.Controls.Add(this.txtIDCS);
            this.myPanelControl1.Controls.Add(this.label12);
            this.myPanelControl1.Controls.Add(this.txtIDTD);
            this.myPanelControl1.Controls.Add(this.label11);
            this.myPanelControl1.Controls.Add(this.chkKhongXe);
            this.myPanelControl1.Controls.Add(this.chkTruotHoan);
            this.myPanelControl1.Controls.Add(this.chkDonDuoc);
            this.myPanelControl1.Controls.Add(this.lblFilename);
            this.myPanelControl1.Controls.Add(this.gridEX2);
            this.myPanelControl1.Controls.Add(this.label10);
            this.myPanelControl1.Controls.Add(this.label9);
            this.myPanelControl1.Controls.Add(this.label8);
            this.myPanelControl1.Controls.Add(this.btnPause);
            this.myPanelControl1.Controls.Add(this.btnPlay);
            this.myPanelControl1.Controls.Add(this.btnStop);
            this.myPanelControl1.Controls.Add(this.label7);
            this.myPanelControl1.Controls.Add(this.txtSoLanGoiLai);
            this.myPanelControl1.Controls.Add(this.label5);
            this.myPanelControl1.Controls.Add(this.txtVung);
            this.myPanelControl1.Controls.Add(this.label6);
            this.myPanelControl1.Controls.Add(this.calDenNgay);
            this.myPanelControl1.Controls.Add(this.label3);
            this.myPanelControl1.Controls.Add(this.calTuNgay);
            this.myPanelControl1.Controls.Add(this.label2);
            this.myPanelControl1.Controls.Add(this.btnExportExcel);
            this.myPanelControl1.Controls.Add(this.btnRefresh);
            this.myPanelControl1.Controls.Add(this.label1);
            this.myPanelControl1.Controls.Add(this.tbPosition);
            this.myPanelControl1.Controls.Add(this.panel1);
            this.myPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.myPanelControl1.Name = "myPanelControl1";
            this.myPanelControl1.Size = new System.Drawing.Size(1063, 265);
            this.myPanelControl1.TabIndex = 75;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(327, 57);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(141, 20);
            this.txtSoDienThoai.TabIndex = 110;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(251, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 111;
            this.label13.Text = "Số điện thoại";
            // 
            // chkGoiLai
            // 
            this.chkGoiLai.AutoSize = true;
            this.chkGoiLai.Location = new System.Drawing.Point(399, 107);
            this.chkGoiLai.Name = "chkGoiLai";
            this.chkGoiLai.Size = new System.Drawing.Size(55, 17);
            this.chkGoiLai.TabIndex = 81;
            this.chkGoiLai.Text = "Gọi lại";
            this.chkGoiLai.UseVisualStyleBackColor = true;
            this.chkGoiLai.CheckedChanged += new System.EventHandler(this.chkGoiLai_CheckedChanged);
            // 
            // chkGoiTaxi
            // 
            this.chkGoiTaxi.AutoSize = true;
            this.chkGoiTaxi.Location = new System.Drawing.Point(327, 107);
            this.chkGoiTaxi.Name = "chkGoiTaxi";
            this.chkGoiTaxi.Size = new System.Drawing.Size(61, 17);
            this.chkGoiTaxi.TabIndex = 80;
            this.chkGoiTaxi.Text = "Gọi taxi";
            this.chkGoiTaxi.UseVisualStyleBackColor = true;
            this.chkGoiTaxi.CheckedChanged += new System.EventHandler(this.chkGoiTaxi_CheckedChanged);
            // 
            // txtIDDT
            // 
            this.txtIDDT.Location = new System.Drawing.Point(327, 147);
            this.txtIDDT.Name = "txtIDDT";
            this.txtIDDT.Size = new System.Drawing.Size(71, 20);
            this.txtIDDT.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 109;
            this.label4.Text = "IDĐT";
            // 
            // chkDonDuocXe888
            // 
            this.chkDonDuocXe888.AutoSize = true;
            this.chkDonDuocXe888.Location = new System.Drawing.Point(544, 130);
            this.chkDonDuocXe888.Name = "chkDonDuocXe888";
            this.chkDonDuocXe888.Size = new System.Drawing.Size(99, 17);
            this.chkDonDuocXe888.TabIndex = 85;
            this.chkDonDuocXe888.Text = "Đ/được xe 888";
            this.chkDonDuocXe888.UseVisualStyleBackColor = true;
            this.chkDonDuocXe888.CheckedChanged += new System.EventHandler(this.chkDonDuocXe888_CheckedChanged);
            // 
            // chkXe999
            // 
            this.chkXe999.AutoSize = true;
            this.chkXe999.Location = new System.Drawing.Point(649, 130);
            this.chkXe999.Name = "chkXe999";
            this.chkXe999.Size = new System.Drawing.Size(86, 17);
            this.chkXe999.TabIndex = 86;
            this.chkXe999.Text = "Khác xe 999";
            this.chkXe999.UseVisualStyleBackColor = true;
            this.chkXe999.CheckedChanged += new System.EventHandler(this.chkXe999_CheckedChanged);
            // 
            // txtIDCS
            // 
            this.txtIDCS.Location = new System.Drawing.Point(599, 149);
            this.txtIDCS.Name = "txtIDCS";
            this.txtIDCS.Size = new System.Drawing.Size(71, 20);
            this.txtIDCS.TabIndex = 89;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(561, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 108;
            this.label12.Text = "IDCS";
            // 
            // txtIDTD
            // 
            this.txtIDTD.Location = new System.Drawing.Point(476, 149);
            this.txtIDTD.Name = "txtIDTD";
            this.txtIDTD.Size = new System.Drawing.Size(71, 20);
            this.txtIDTD.TabIndex = 88;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(437, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 107;
            this.label11.Text = "IDTĐ";
            // 
            // chkKhongXe
            // 
            this.chkKhongXe.AutoSize = true;
            this.chkKhongXe.Location = new System.Drawing.Point(474, 128);
            this.chkKhongXe.Name = "chkKhongXe";
            this.chkKhongXe.Size = new System.Drawing.Size(71, 17);
            this.chkKhongXe.TabIndex = 84;
            this.chkKhongXe.Text = "Không xe";
            this.chkKhongXe.UseVisualStyleBackColor = true;
            this.chkKhongXe.CheckedChanged += new System.EventHandler(this.chkKhongXe_CheckedChanged);
            // 
            // chkTruotHoan
            // 
            this.chkTruotHoan.AutoSize = true;
            this.chkTruotHoan.Location = new System.Drawing.Point(399, 128);
            this.chkTruotHoan.Name = "chkTruotHoan";
            this.chkTruotHoan.Size = new System.Drawing.Size(78, 17);
            this.chkTruotHoan.TabIndex = 83;
            this.chkTruotHoan.Text = "Trượt hoãn";
            this.chkTruotHoan.UseVisualStyleBackColor = true;
            this.chkTruotHoan.CheckedChanged += new System.EventHandler(this.chkTruotHoan_CheckedChanged);
            // 
            // chkDonDuoc
            // 
            this.chkDonDuoc.AutoSize = true;
            this.chkDonDuoc.Location = new System.Drawing.Point(327, 128);
            this.chkDonDuoc.Name = "chkDonDuoc";
            this.chkDonDuoc.Size = new System.Drawing.Size(74, 17);
            this.chkDonDuoc.TabIndex = 82;
            this.chkDonDuoc.Text = "Đón được";
            this.chkDonDuoc.UseVisualStyleBackColor = true;
            this.chkDonDuoc.CheckedChanged += new System.EventHandler(this.chkDonDuoc_CheckedChanged);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.Location = new System.Drawing.Point(351, 194);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(0, 13);
            this.lblFilename.TabIndex = 106;
            // 
            // gridEX2
            // 
            this.gridEX2.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridEX2.DesignTimeLayout = gridEXLayout2;
            this.gridEX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX2.GroupByBoxVisible = false;
            this.gridEX2.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridEX2.Location = new System.Drawing.Point(851, 85);
            this.gridEX2.Name = "gridEX2";
            this.gridEX2.SaveSettings = false;
            this.gridEX2.Size = new System.Drawing.Size(200, 98);
            this.gridEX2.TabIndex = 105;
            this.gridEX2.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 103;
            this.label10.Text = "Gọi CS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 102;
            this.label9.Text = "NGHE  LẠI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "Cuốc gọi đến :";
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPause.ImageIndex = 2;
            this.btnPause.Location = new System.Drawing.Point(405, 216);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(63, 21);
            this.btnPause.TabIndex = 92;
            this.btnPause.Text = "Pause";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.ImageIndex = 1;
            this.btnPlay.Location = new System.Drawing.Point(352, 216);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(49, 21);
            this.btnPlay.TabIndex = 90;
            this.btnPlay.Text = "Play";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.ImageIndex = 3;
            this.btnStop.Location = new System.Drawing.Point(472, 216);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(61, 21);
            this.btnStop.TabIndex = 94;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(676, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "(Khoảng dữ liệu nên trong trong vòng 24h)";
            // 
            // txtSoLanGoiLai
            // 
            this.txtSoLanGoiLai.Location = new System.Drawing.Point(595, 78);
            this.txtSoLanGoiLai.Name = "txtSoLanGoiLai";
            this.txtSoLanGoiLai.Size = new System.Drawing.Size(75, 20);
            this.txtSoLanGoiLai.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(477, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "Số lần khách gọi lại >:";
            // 
            // txtVung
            // 
            this.txtVung.Location = new System.Drawing.Point(327, 81);
            this.txtVung.Name = "txtVung";
            this.txtVung.Size = new System.Drawing.Size(66, 20);
            this.txtVung.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 97;
            this.label6.Text = "Vùng";
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
            this.calDenNgay.Location = new System.Drawing.Point(529, 33);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(141, 20);
            this.calDenNgay.TabIndex = 77;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Đến ngày";
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 2, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(327, 33);
            this.calTuNgay.MinDate = new System.DateTime(2011, 2, 26, 0, 0, 0, 0);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(141, 20);
            this.calTuNgay.TabIndex = 76;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Từ ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(586, 175);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 93;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(502, 175);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 91;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 24);
            this.label1.TabIndex = 75;
            this.label1.Text = "BÁO CÁO CHI TIẾT CSKH";
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(537, 212);
            this.tbPosition.Margin = new System.Windows.Forms.Padding(2);
            this.tbPosition.Maximum = 100;
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(495, 45);
            this.tbPosition.TabIndex = 100;
            this.tbPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radGoiCSLan2);
            this.panel1.Controls.Add(this.radGoiDenLan3);
            this.panel1.Controls.Add(this.radGoiCSLan1);
            this.panel1.Controls.Add(this.radGoiDenLan1);
            this.panel1.Controls.Add(this.radGoiCSLan4);
            this.panel1.Controls.Add(this.radGoiDenLan4);
            this.panel1.Controls.Add(this.radGoiCSLan3);
            this.panel1.Controls.Add(this.radGoiDenLan2);
            this.panel1.Location = new System.Drawing.Point(93, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 49);
            this.panel1.TabIndex = 104;
            // 
            // radGoiCSLan2
            // 
            this.radGoiCSLan2.AutoSize = true;
            this.radGoiCSLan2.Location = new System.Drawing.Point(83, 25);
            this.radGoiCSLan2.Name = "radGoiCSLan2";
            this.radGoiCSLan2.Size = new System.Drawing.Size(52, 17);
            this.radGoiCSLan2.TabIndex = 57;
            this.radGoiCSLan2.Text = "Lần 2";
            this.radGoiCSLan2.UseVisualStyleBackColor = true;
            // 
            // radGoiDenLan3
            // 
            this.radGoiDenLan3.AutoSize = true;
            this.radGoiDenLan3.Location = new System.Drawing.Point(141, 5);
            this.radGoiDenLan3.Name = "radGoiDenLan3";
            this.radGoiDenLan3.Size = new System.Drawing.Size(52, 17);
            this.radGoiDenLan3.TabIndex = 52;
            this.radGoiDenLan3.Text = "Lần 3";
            this.radGoiDenLan3.UseVisualStyleBackColor = true;
            // 
            // radGoiCSLan1
            // 
            this.radGoiCSLan1.AutoSize = true;
            this.radGoiCSLan1.Location = new System.Drawing.Point(25, 24);
            this.radGoiCSLan1.Name = "radGoiCSLan1";
            this.radGoiCSLan1.Size = new System.Drawing.Size(52, 17);
            this.radGoiCSLan1.TabIndex = 56;
            this.radGoiCSLan1.Text = "Lần 1";
            this.radGoiCSLan1.UseVisualStyleBackColor = true;
            // 
            // radGoiDenLan1
            // 
            this.radGoiDenLan1.AutoSize = true;
            this.radGoiDenLan1.Checked = true;
            this.radGoiDenLan1.Location = new System.Drawing.Point(25, 4);
            this.radGoiDenLan1.Name = "radGoiDenLan1";
            this.radGoiDenLan1.Size = new System.Drawing.Size(52, 17);
            this.radGoiDenLan1.TabIndex = 50;
            this.radGoiDenLan1.TabStop = true;
            this.radGoiDenLan1.Text = "Lần 1";
            this.radGoiDenLan1.UseVisualStyleBackColor = true;
            // 
            // radGoiCSLan4
            // 
            this.radGoiCSLan4.AutoSize = true;
            this.radGoiCSLan4.Location = new System.Drawing.Point(199, 26);
            this.radGoiCSLan4.Name = "radGoiCSLan4";
            this.radGoiCSLan4.Size = new System.Drawing.Size(52, 17);
            this.radGoiCSLan4.TabIndex = 59;
            this.radGoiCSLan4.Text = "Lần 4";
            this.radGoiCSLan4.UseVisualStyleBackColor = true;
            // 
            // radGoiDenLan4
            // 
            this.radGoiDenLan4.AutoSize = true;
            this.radGoiDenLan4.Location = new System.Drawing.Point(199, 6);
            this.radGoiDenLan4.Name = "radGoiDenLan4";
            this.radGoiDenLan4.Size = new System.Drawing.Size(52, 17);
            this.radGoiDenLan4.TabIndex = 53;
            this.radGoiDenLan4.Text = "Lần 4";
            this.radGoiDenLan4.UseVisualStyleBackColor = true;
            // 
            // radGoiCSLan3
            // 
            this.radGoiCSLan3.AutoSize = true;
            this.radGoiCSLan3.Location = new System.Drawing.Point(141, 25);
            this.radGoiCSLan3.Name = "radGoiCSLan3";
            this.radGoiCSLan3.Size = new System.Drawing.Size(52, 17);
            this.radGoiCSLan3.TabIndex = 58;
            this.radGoiCSLan3.Text = "Lần 3";
            this.radGoiCSLan3.UseVisualStyleBackColor = true;
            // 
            // radGoiDenLan2
            // 
            this.radGoiDenLan2.AutoSize = true;
            this.radGoiDenLan2.Location = new System.Drawing.Point(83, 5);
            this.radGoiDenLan2.Name = "radGoiDenLan2";
            this.radGoiDenLan2.Size = new System.Drawing.Size(52, 17);
            this.radGoiDenLan2.TabIndex = 51;
            this.radGoiDenLan2.Text = "Lần 2";
            this.radGoiDenLan2.UseVisualStyleBackColor = true;
            // 
            // frmBaoCaoCSKHChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 725);
            this.Controls.Add(this.myPanelControl2);
            this.Controls.Add(this.myPanelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoCSKHChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2.2 Bao cao chi tiet CSKH - TaxiGroup";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl2)).EndInit();
            this.myPanelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl1)).EndInit();
            this.myPanelControl1.ResumeLayout(false);
            this.myPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Alvas.Audio.Player player1;
        private System.Windows.Forms.Timer timer1;
        private Controls.BanCo.MyPanelControl myPanelControl1;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkGoiLai;
        private System.Windows.Forms.CheckBox chkGoiTaxi;
        private System.Windows.Forms.TextBox txtIDDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDonDuocXe888;
        private System.Windows.Forms.CheckBox chkXe999;
        private System.Windows.Forms.TextBox txtIDCS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIDTD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkKhongXe;
        private System.Windows.Forms.CheckBox chkTruotHoan;
        private System.Windows.Forms.CheckBox chkDonDuoc;
        private System.Windows.Forms.Label lblFilename;
        private Janus.Windows.GridEX.GridEX gridEX2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoLanGoiLai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVung;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbPosition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radGoiCSLan2;
        private System.Windows.Forms.RadioButton radGoiDenLan3;
        private System.Windows.Forms.RadioButton radGoiCSLan1;
        private System.Windows.Forms.RadioButton radGoiDenLan1;
        private System.Windows.Forms.RadioButton radGoiCSLan4;
        private System.Windows.Forms.RadioButton radGoiDenLan4;
        private System.Windows.Forms.RadioButton radGoiCSLan3;
        private System.Windows.Forms.RadioButton radGoiDenLan2;
        private Controls.BanCo.MyPanelControl myPanelControl2;
        private Janus.Windows.GridEX.GridEX gridEX1;
       
    }
}