namespace Taxi.GUI {
	partial class HeThong_NguoiDung_TaoMoi {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.cbPhong = new System.Windows.Forms.ComboBox();
            this.txtTenTruyCap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkNgungSuDung = new System.Windows.Forms.CheckBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQueQuan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cbChucVu = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbTrungTam = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEXT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên truy cập (*)";
            // 
            // cbPhong
            // 
            this.cbPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhong.FormattingEnabled = true;
            this.cbPhong.Items.AddRange(new object[] {
            "Cấp phép công cộng",
            "Cấp phép chuyên dụng",
            "Cấp phép phát thanh truyền hình"});
            this.cbPhong.Location = new System.Drawing.Point(91, 192);
            this.cbPhong.Name = "cbPhong";
            this.cbPhong.Size = new System.Drawing.Size(151, 21);
            this.cbPhong.TabIndex = 10;
            this.cbPhong.SelectedValueChanged += new System.EventHandler(this.cbPhong_SelectedValueChanged);
            // 
            // txtTenTruyCap
            // 
            this.txtTenTruyCap.Location = new System.Drawing.Point(91, 12);
            this.txtTenTruyCap.MaxLength = 50;
            this.txtTenTruyCap.Name = "txtTenTruyCap";
            this.txtTenTruyCap.Size = new System.Drawing.Size(151, 20);
            this.txtTenTruyCap.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(91, 42);
            this.txtMatKhau.MaxLength = 255;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(150, 20);
            this.txtMatKhau.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(366, 72);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(245, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thuộc phòng (*)";
            // 
            // chkNgungSuDung
            // 
            this.chkNgungSuDung.AutoSize = true;
            this.chkNgungSuDung.Location = new System.Drawing.Point(91, 254);
            this.chkNgungSuDung.Name = "chkNgungSuDung";
            this.chkNgungSuDung.Size = new System.Drawing.Size(99, 17);
            this.chkNgungSuDung.TabIndex = 12;
            this.chkNgungSuDung.Text = "Ngừng sử dụng";
            this.chkNgungSuDung.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(533, 293);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(78, 23);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Th&oát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Location = new System.Drawing.Point(452, 293);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(78, 23);
            this.btnTaoMoi.TabIndex = 13;
            this.btnTaoMoi.Text = "&Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tên (*)";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(365, 12);
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(151, 20);
            this.txtHoTen.TabIndex = 1;
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbGioiTinh.Location = new System.Drawing.Point(366, 102);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(51, 21);
            this.cbGioiTinh.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Giới tính (*)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(91, 132);
            this.txtDiaChi.MaxLength = 255;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(520, 20);
            this.txtDiaChi.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Quê quán";
            // 
            // txtQueQuan
            // 
            this.txtQueQuan.Location = new System.Drawing.Point(91, 162);
            this.txtQueQuan.MaxLength = 255;
            this.txtQueQuan.Name = "txtQueQuan";
            this.txtQueQuan.Size = new System.Drawing.Size(520, 20);
            this.txtQueQuan.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngày sinh (*)";
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgaySinh.Location = new System.Drawing.Point(91, 72);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(151, 20);
            this.dtNgaySinh.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(300, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Chức vụ (*)";
            // 
            // cbChucVu
            // 
            this.cbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChucVu.FormattingEnabled = true;
            this.cbChucVu.Items.AddRange(new object[] {
            "Cấp phép công cộng",
            "Cấp phép chuyên dụng",
            "Cấp phép phát thanh truyền hình"});
            this.cbChucVu.Location = new System.Drawing.Point(366, 192);
            this.cbChucVu.Name = "cbChucVu";
            this.cbChucVu.Size = new System.Drawing.Size(151, 21);
            this.cbChucVu.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Điện thoại";
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(366, 42);
            this.txtXacNhanMatKhau.MaxLength = 255;
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.PasswordChar = '*';
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(150, 20);
            this.txtXacNhanMatKhau.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(260, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Xác nhận mật khẩu";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtDienThoai.Location = new System.Drawing.Point(91, 102);
            this.txtDienThoai.Mask = "00000000000";
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(151, 20);
            this.txtDienThoai.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 226);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Trung tâm";
            // 
            // cbTrungTam
            // 
            this.cbTrungTam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrungTam.FormattingEnabled = true;
            this.cbTrungTam.Items.AddRange(new object[] {
            "Cấp phép công cộng",
            "Cấp phép chuyên dụng",
            "Cấp phép phát thanh truyền hình"});
            this.cbTrungTam.Location = new System.Drawing.Point(91, 223);
            this.cbTrungTam.Name = "cbTrungTam";
            this.cbTrungTam.Size = new System.Drawing.Size(151, 21);
            this.cbTrungTam.TabIndex = 17;
            this.cbTrungTam.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(300, 222);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Extension";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // txtEXT
            // 
            this.txtEXT.Location = new System.Drawing.Point(365, 219);
            this.txtEXT.MaxLength = 255;
            this.txtEXT.Name = "txtEXT";
            this.txtEXT.Size = new System.Drawing.Size(100, 20);
            this.txtEXT.TabIndex = 9;
            // 
            // HeThong_NguoiDung_TaoMoi
            // 
            this.AcceptButton = this.btnTaoMoi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(616, 340);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbTrungTam);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.txtXacNhanMatKhau);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbChucVu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtNgaySinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTaoMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.chkNgungSuDung);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEXT);
            this.Controls.Add(this.txtQueQuan);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenTruyCap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbGioiTinh);
            this.Controls.Add(this.cbPhong);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeThong_NguoiDung_TaoMoi";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo mới người dùng";
            this.Load += new System.EventHandler(this.HeThong_NguoiDung_TaoMoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbPhong;
		private System.Windows.Forms.TextBox txtTenTruyCap;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatKhau;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkNgungSuDung;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnTaoMoi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtHoTen;
		private System.Windows.Forms.ComboBox cbGioiTinh;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtQueQuan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbChucVu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtDienThoai;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbTrungTam;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEXT;
	}
}