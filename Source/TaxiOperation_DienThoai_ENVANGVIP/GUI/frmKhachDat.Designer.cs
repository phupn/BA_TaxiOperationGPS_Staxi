namespace Taxi.GUI 
{
    partial class frmKhachDat
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
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel4 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachDat));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel5 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel6 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.rbMotLan = new System.Windows.Forms.RadioButton();
            this.rbLapLai = new System.Windows.Forms.RadioButton();
            this.calGioDon = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.chkThu2 = new Janus.Windows.EditControls.UICheckBox();
            this.chkThu3 = new Janus.Windows.EditControls.UICheckBox();
            this.chkThu4 = new Janus.Windows.EditControls.UICheckBox();
            this.chkThu7 = new Janus.Windows.EditControls.UICheckBox();
            this.chkThu6 = new Janus.Windows.EditControls.UICheckBox();
            this.chkThu5 = new Janus.Windows.EditControls.UICheckBox();
            this.chkCN = new Janus.Windows.EditControls.UICheckBox();
            this.txtKenh = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTGTiepNhan = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.calNgayBatDau = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calNgayKetThuc = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.boxHangTuan = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cbSoPhut = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.chkXeLIMO7 = new Janus.Windows.EditControls.UICheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSoLuong = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chk7Cho = new Janus.Windows.EditControls.UICheckBox();
            this.chk4Cho = new Janus.Windows.EditControls.UICheckBox();
            this.txtDiaChi = new Femiani.Forms.UI.Input.CoolTextBox();
            this.txtLoaiXe = new System.Windows.Forms.TextBox();
            this.boxHangTuan.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(119, 35);
            this.txtTenKH.MaxLength = 50;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(347, 20);
            this.txtTenKH.TabIndex = 0;
            this.txtTenKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenKH_KeyDown);
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(119, 87);
            this.txtDienThoai.MaxLength = 15;
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(126, 20);
            this.txtDienThoai.TabIndex = 2;
            this.txtDienThoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDienThoai_KeyDown);
            // 
            // rbMotLan
            // 
            this.rbMotLan.AutoSize = true;
            this.rbMotLan.Checked = true;
            this.rbMotLan.Location = new System.Drawing.Point(300, 148);
            this.rbMotLan.Name = "rbMotLan";
            this.rbMotLan.Size = new System.Drawing.Size(82, 17);
            this.rbMotLan.TabIndex = 8;
            this.rbMotLan.TabStop = true;
            this.rbMotLan.Text = "Đón &một lần";
            this.rbMotLan.UseVisualStyleBackColor = true;
            this.rbMotLan.CheckedChanged += new System.EventHandler(this.rbMotLan_CheckedChanged);
            // 
            // rbLapLai
            // 
            this.rbLapLai.AutoSize = true;
            this.rbLapLai.Location = new System.Drawing.Point(391, 148);
            this.rbLapLai.Name = "rbLapLai";
            this.rbLapLai.Size = new System.Drawing.Size(75, 17);
            this.rbLapLai.TabIndex = 9;
            this.rbLapLai.Text = "Đón &lặp lại";
            this.rbLapLai.UseVisualStyleBackColor = true;
            this.rbLapLai.CheckedChanged += new System.EventHandler(this.rbLapLai_CheckedChanged);
            // 
            // calGioDon
            // 
            this.calGioDon.CustomFormat = "HH:mm";
            this.calGioDon.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calGioDon.DropDownCalendar.FirstMonth = new System.DateTime(2011, 9, 1, 0, 0, 0, 0);
            this.calGioDon.DropDownCalendar.Name = "";
            this.calGioDon.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard;
            this.calGioDon.HoverMode = Janus.Windows.CalendarCombo.HoverMode.Highlight;
            this.calGioDon.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.calGioDon.Location = new System.Drawing.Point(119, 171);
            this.calGioDon.Name = "calGioDon";
            this.calGioDon.SecondIncrement = 30;
            this.calGioDon.ShowDropDown = false;
            this.calGioDon.ShowTodayButton = false;
            this.calGioDon.ShowUpDown = true;
            this.calGioDon.Size = new System.Drawing.Size(90, 20);
            this.calGioDon.TabIndex = 4;
            this.calGioDon.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // chkThu2
            // 
            this.chkThu2.Checked = true;
            this.chkThu2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThu2.Location = new System.Drawing.Point(42, 17);
            this.chkThu2.Name = "chkThu2";
            this.chkThu2.Size = new System.Drawing.Size(50, 23);
            this.chkThu2.TabIndex = 10;
            this.chkThu2.Text = "Thứ &2";
            // 
            // chkThu3
            // 
            this.chkThu3.Checked = true;
            this.chkThu3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThu3.Location = new System.Drawing.Point(109, 17);
            this.chkThu3.Name = "chkThu3";
            this.chkThu3.Size = new System.Drawing.Size(50, 23);
            this.chkThu3.TabIndex = 11;
            this.chkThu3.Text = "Thứ &3";
            // 
            // chkThu4
            // 
            this.chkThu4.Checked = true;
            this.chkThu4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThu4.Location = new System.Drawing.Point(176, 17);
            this.chkThu4.Name = "chkThu4";
            this.chkThu4.Size = new System.Drawing.Size(50, 23);
            this.chkThu4.TabIndex = 12;
            this.chkThu4.Text = "Thứ &4";
            // 
            // chkThu7
            // 
            this.chkThu7.Checked = true;
            this.chkThu7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThu7.Location = new System.Drawing.Point(176, 45);
            this.chkThu7.Name = "chkThu7";
            this.chkThu7.Size = new System.Drawing.Size(50, 23);
            this.chkThu7.TabIndex = 15;
            this.chkThu7.Text = "Thứ &7";
            // 
            // chkThu6
            // 
            this.chkThu6.Checked = true;
            this.chkThu6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThu6.Location = new System.Drawing.Point(109, 45);
            this.chkThu6.Name = "chkThu6";
            this.chkThu6.Size = new System.Drawing.Size(50, 23);
            this.chkThu6.TabIndex = 14;
            this.chkThu6.Text = "Thứ &6";
            // 
            // chkThu5
            // 
            this.chkThu5.Checked = true;
            this.chkThu5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThu5.Location = new System.Drawing.Point(42, 45);
            this.chkThu5.Name = "chkThu5";
            this.chkThu5.Size = new System.Drawing.Size(50, 23);
            this.chkThu5.TabIndex = 13;
            this.chkThu5.Text = "Thứ &5";
            // 
            // chkCN
            // 
            this.chkCN.Location = new System.Drawing.Point(42, 73);
            this.chkCN.Name = "chkCN";
            this.chkCN.Size = new System.Drawing.Size(50, 23);
            this.chkCN.TabIndex = 16;
            this.chkCN.Text = "CN(&8)";
            // 
            // txtKenh
            // 
            this.txtKenh.HoverMode = Janus.Windows.GridEX.HoverMode.Highlight;
            this.txtKenh.Location = new System.Drawing.Point(119, 145);
            this.txtKenh.MaxLength = 3;
            this.txtKenh.Name = "txtKenh";
            this.txtKenh.Size = new System.Drawing.Size(48, 20);
            this.txtKenh.TabIndex = 3;
            this.txtKenh.Text = "0";
            this.txtKenh.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Thời điểm tiếp nhận";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên khách &hàng *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Địa &chỉ đón *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "&Điện thoại *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "V&ùng(Kênh) *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Thời &gian đón";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Báo &trước";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(227, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Loại đặt hẹn";
            // 
            // lblTGTiepNhan
            // 
            this.lblTGTiepNhan.AutoSize = true;
            this.lblTGTiepNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTGTiepNhan.Location = new System.Drawing.Point(119, 14);
            this.lblTGTiepNhan.Name = "lblTGTiepNhan";
            this.lblTGTiepNhan.Size = new System.Drawing.Size(119, 15);
            this.lblTGTiepNhan.TabIndex = 29;
            this.lblTGTiepNhan.Text = "20:20 10/10/2011";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Ngày &bắt đầu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Ngày &kết thúc";
            // 
            // calNgayBatDau
            // 
            this.calNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.calNgayBatDau.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calNgayBatDau.DropDownCalendar.FirstMonth = new System.DateTime(2011, 9, 1, 0, 0, 0, 0);
            this.calNgayBatDau.DropDownCalendar.Name = "";
            this.calNgayBatDau.HoverMode = Janus.Windows.CalendarCombo.HoverMode.Highlight;
            this.calNgayBatDau.Location = new System.Drawing.Point(119, 197);
            this.calNgayBatDau.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.calNgayBatDau.Name = "calNgayBatDau";
            this.calNgayBatDau.Size = new System.Drawing.Size(90, 20);
            this.calNgayBatDau.TabIndex = 5;
            this.calNgayBatDau.Value = new System.DateTime(2014, 3, 20, 0, 0, 0, 0);
            // 
            // calNgayKetThuc
            // 
            this.calNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.calNgayKetThuc.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calNgayKetThuc.DropDownCalendar.FirstMonth = new System.DateTime(2011, 9, 1, 0, 0, 0, 0);
            this.calNgayKetThuc.DropDownCalendar.Name = "";
            this.calNgayKetThuc.Enabled = false;
            this.calNgayKetThuc.HoverMode = Janus.Windows.CalendarCombo.HoverMode.Highlight;
            this.calNgayKetThuc.Location = new System.Drawing.Point(119, 223);
            this.calNgayKetThuc.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.calNgayKetThuc.Name = "calNgayKetThuc";
            this.calNgayKetThuc.Size = new System.Drawing.Size(90, 20);
            this.calNgayKetThuc.TabIndex = 6;
            this.calNgayKetThuc.Value = new System.DateTime(2014, 3, 20, 0, 0, 0, 0);
            // 
            // boxHangTuan
            // 
            this.boxHangTuan.Controls.Add(this.chkThu2);
            this.boxHangTuan.Controls.Add(this.chkCN);
            this.boxHangTuan.Controls.Add(this.chkThu7);
            this.boxHangTuan.Controls.Add(this.chkThu6);
            this.boxHangTuan.Controls.Add(this.chkThu3);
            this.boxHangTuan.Controls.Add(this.chkThu5);
            this.boxHangTuan.Controls.Add(this.chkThu4);
            this.boxHangTuan.Enabled = false;
            this.boxHangTuan.Location = new System.Drawing.Point(230, 171);
            this.boxHangTuan.Name = "boxHangTuan";
            this.boxHangTuan.Size = new System.Drawing.Size(235, 98);
            this.boxHangTuan.TabIndex = 38;
            this.boxHangTuan.TabStop = false;
            this.boxHangTuan.Text = "Hằng tuần";
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = global::TaxiApplication.Properties.Resources.Close;
            this.btnDong.Location = new System.Drawing.Point(200, 370);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 30);
            this.btnDong.TabIndex = 18;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::TaxiApplication.Properties.Resources.disk;
            this.btnLuu.Location = new System.Drawing.Point(119, 370);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 30);
            this.btnLuu.TabIndex = 17;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // cbSoPhut
            // 
            this.cbSoPhut.HoverMode = Janus.Windows.GridEX.HoverMode.Highlight;
            this.cbSoPhut.Increment = 10;
            this.cbSoPhut.Location = new System.Drawing.Point(119, 249);
            this.cbSoPhut.Maximum = 120;
            this.cbSoPhut.MaxLength = 3;
            this.cbSoPhut.Minimum = 5;
            this.cbSoPhut.Name = "cbSoPhut";
            this.cbSoPhut.Size = new System.Drawing.Size(48, 20);
            this.cbSoPhut.TabIndex = 7;
            this.cbSoPhut.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.cbSoPhut.Value = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(170, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "(phút)";
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 401);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel4.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel4.Image")));
            uiStatusBarPanel4.Key = "";
            uiStatusBarPanel4.ProgressBarValue = 0;
            uiStatusBarPanel4.Text = "Lưu : [Enter]";
            uiStatusBarPanel4.Width = 150;
            uiStatusBarPanel5.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel5.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel5.Image")));
            uiStatusBarPanel5.Key = "";
            uiStatusBarPanel5.ProgressBarValue = 0;
            uiStatusBarPanel5.Text = "Làm mới : [F5]";
            uiStatusBarPanel5.Width = 150;
            uiStatusBarPanel6.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel6.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel6.Image")));
            uiStatusBarPanel6.Key = "";
            uiStatusBarPanel6.ProgressBarValue = 0;
            uiStatusBarPanel6.Text = "Đóng : [Esc]";
            uiStatusBarPanel6.Width = 150;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel4,
            uiStatusBarPanel5,
            uiStatusBarPanel6});
            this.uiStatusBar1.Size = new System.Drawing.Size(478, 23);
            this.uiStatusBar1.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Gh&i chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(119, 297);
            this.txtGhiChu.MaxLength = 250;
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(347, 50);
            this.txtGhiChu.TabIndex = 8;
            // 
            // chkXeLIMO7
            // 
            this.chkXeLIMO7.BackColor = System.Drawing.Color.Transparent;
            this.chkXeLIMO7.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F);
            this.chkXeLIMO7.Location = new System.Drawing.Point(409, 116);
            this.chkXeLIMO7.Name = "chkXeLIMO7";
            this.chkXeLIMO7.Size = new System.Drawing.Size(56, 26);
            this.chkXeLIMO7.TabIndex = 55;
            this.chkXeLIMO7.Text = "LIM&O7 ";
            this.chkXeLIMO7.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(64, 117);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 15);
            this.label13.TabIndex = 56;
            this.label13.Tag = " ";
            this.label13.Text = "Loại xe";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(370, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "&Số lượng *";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.HoverMode = Janus.Windows.GridEX.HoverMode.Highlight;
            this.txtSoLuong.Location = new System.Drawing.Point(432, 87);
            this.txtSoLuong.MaxLength = 3;
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(33, 20);
            this.txtSoLuong.TabIndex = 57;
            this.txtSoLuong.Text = "1";
            this.txtSoLuong.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(119, 353);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 59;
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Location = new System.Drawing.Point(119, 273);
            this.txtGiaTien.MaxLength = 15;
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(126, 20);
            this.txtGiaTien.TabIndex = 2;
            this.txtGiaTien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDienThoai_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(68, 276);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Giá tiền";
            // 
            // chk7Cho
            // 
            this.chk7Cho.BackColor = System.Drawing.Color.Transparent;
            this.chk7Cho.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F);
            this.chk7Cho.Location = new System.Drawing.Point(297, 112);
            this.chk7Cho.Name = "chk7Cho";
            this.chk7Cho.Size = new System.Drawing.Size(57, 26);
            this.chk7Cho.TabIndex = 94;
            this.chk7Cho.Text = "7 chỗ";
            // 
            // chk4Cho
            // 
            this.chk4Cho.BackColor = System.Drawing.Color.Transparent;
            this.chk4Cho.Checked = true;
            this.chk4Cho.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk4Cho.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F);
            this.chk4Cho.Location = new System.Drawing.Point(230, 112);
            this.chk4Cho.Name = "chk4Cho";
            this.chk4Cho.Size = new System.Drawing.Size(61, 26);
            this.chk4Cho.TabIndex = 93;
            this.chk4Cho.Text = "4 chỗ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.SystemColors.Window;
            this.txtDiaChi.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txtDiaChi.IntTextLengthTrigger = 0;
            this.txtDiaChi.IsAuto = false;
            this.txtDiaChi.KinhDo = 0F;
            this.txtDiaChi.Location = new System.Drawing.Point(119, 61);
            this.txtDiaChi.MaxLength = 255;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Padding = new System.Windows.Forms.Padding(4);
            this.txtDiaChi.PopupWidth = 120;
            this.txtDiaChi.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.txtDiaChi.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtDiaChi.Size = new System.Drawing.Size(347, 21);
            this.txtDiaChi.TabIndex = 1;
            this.txtDiaChi.TextReturn = "";
            this.txtDiaChi.ViDo = 0F;
            this.txtDiaChi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaChi_KeyDown);
            // 
            // txtLoaiXe
            // 
            this.txtLoaiXe.Location = new System.Drawing.Point(119, 116);
            this.txtLoaiXe.MaxLength = 50;
            this.txtLoaiXe.Name = "txtLoaiXe";
            this.txtLoaiXe.Size = new System.Drawing.Size(90, 20);
            this.txtLoaiXe.TabIndex = 95;
            // 
            // frmKhachDat
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(478, 424);
            this.Controls.Add(this.txtLoaiXe);
            this.Controls.Add(this.chk7Cho);
            this.Controls.Add(this.chk4Cho);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.chkXeLIMO7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.uiStatusBar1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSoPhut);
            this.Controls.Add(this.boxHangTuan);
            this.Controls.Add(this.calNgayKetThuc);
            this.Controls.Add(this.calNgayBatDau);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lblTGTiepNhan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKenh);
            this.Controls.Add(this.calGioDon);
            this.Controls.Add(this.rbLapLai);
            this.Controls.Add(this.rbMotLan);
            this.Controls.Add(this.txtGiaTien);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTenKH);
            this.Icon = TaxiApplication.Properties.Resources.Telephone_01;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhachDat";
            this.Text = "Nhập thông tin khách đặt";
            this.Load += new System.EventHandler(this.frmKhachDat_Load);
            this.boxHangTuan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenKH;
        private Femiani.Forms.UI.Input.CoolTextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.RadioButton rbMotLan;
        private System.Windows.Forms.RadioButton rbLapLai;
        private Janus.Windows.CalendarCombo.CalendarCombo calGioDon;
        private Janus.Windows.EditControls.UICheckBox chkThu2;
        private Janus.Windows.EditControls.UICheckBox chkThu3;
        private Janus.Windows.EditControls.UICheckBox chkThu4;
        private Janus.Windows.EditControls.UICheckBox chkThu7;
        private Janus.Windows.EditControls.UICheckBox chkThu6;
        private Janus.Windows.EditControls.UICheckBox chkThu5;
        private Janus.Windows.EditControls.UICheckBox chkCN;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtKenh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTGTiepNhan;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Janus.Windows.CalendarCombo.CalendarCombo calNgayBatDau;
        private Janus.Windows.CalendarCombo.CalendarCombo calNgayKetThuc;
        private System.Windows.Forms.GroupBox boxHangTuan;
        private Janus.Windows.GridEX.EditControls.IntegerUpDown cbSoPhut;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGhiChu;
        private Janus.Windows.EditControls.UICheckBox chkXeLIMO7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private Janus.Windows.GridEX.EditControls.NumericEditBox txtSoLuong;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtGiaTien;
        private System.Windows.Forms.Label label15;
        private Janus.Windows.EditControls.UICheckBox chk7Cho;
        private Janus.Windows.EditControls.UICheckBox chk4Cho;
        private System.Windows.Forms.TextBox txtLoaiXe;
    }
}