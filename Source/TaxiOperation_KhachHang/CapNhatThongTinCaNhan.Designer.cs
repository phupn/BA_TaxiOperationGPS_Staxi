namespace Taxi.GUI
{
    partial class CapNhatThongTinCaNhan
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
            this.txtDienThoai = new System.Windows.Forms.MaskedTextBox();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQueQuan = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenTruyCap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbChucVu = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPhong = new System.Windows.Forms.ComboBox();
            this.gbMatKhau = new System.Windows.Forms.GroupBox();
            this.chkDoiMatKhau = new System.Windows.Forms.CheckBox();
            this.validator = new Itboy.Components.Validator(this.components);
            this.gbMatKhau.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtDienThoai.Location = new System.Drawing.Point(85, 174);
            this.txtDienThoai.Mask = "000000000000000";
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(166, 20);
            this.txtDienThoai.TabIndex = 7;
            // 
            // txtXacNhanMatKhau
            // 
            this.validator.SetComparedControl(this.txtXacNhanMatKhau, this.txtMatKhau);
            this.validator.SetCompareMessage(this.txtXacNhanMatKhau, "Xác nhận mật khẩu không đúng");
            this.validator.SetCompareOperator(this.txtXacNhanMatKhau, Itboy.Components.ValidationCompareOperator.Equal);
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(106, 67);
            this.txtXacNhanMatKhau.MaxLength = 20;
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.PasswordChar = '*';
            this.validator.SetRequiredMessage(this.txtXacNhanMatKhau, "Bạn cần xác nhận lại mật khẩu!");
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(150, 20);
            this.txtXacNhanMatKhau.TabIndex = 2;
            this.validator.SetType(this.txtXacNhanMatKhau, ((Itboy.Components.ValidationType)((Itboy.Components.ValidationType.Required | Itboy.Components.ValidationType.Compare))));
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Xác nhận mật khẩu";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Điện thoại";
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgaySinh.Location = new System.Drawing.Point(85, 113);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(166, 20);
            this.dtNgaySinh.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Ngày sinh (*)";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(85, 83);
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.Name = "txtHoTen";
            this.validator.SetRequiredMessage(this.txtHoTen, "Cần nhập thông tin họ tên!");
            this.txtHoTen.Size = new System.Drawing.Size(166, 20);
            this.txtHoTen.TabIndex = 2;
            this.validator.SetType(this.txtHoTen, Itboy.Components.ValidationType.Required);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(328, 174);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Giới tính";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Họ tên (*)";
            // 
            // txtQueQuan
            // 
            this.txtQueQuan.Location = new System.Drawing.Point(85, 234);
            this.txtQueQuan.MaxLength = 255;
            this.txtQueQuan.Name = "txtQueQuan";
            this.txtQueQuan.Size = new System.Drawing.Size(520, 20);
            this.txtQueQuan.TabIndex = 10;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(85, 204);
            this.txtDiaChi.MaxLength = 255;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(520, 20);
            this.txtDiaChi.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Quê quán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Địa chỉ";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(106, 40);
            this.txtMatKhau.MaxLength = 20;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.validator.SetRegularExpressionMessage(this.txtMatKhau, "");
            this.validator.SetRequiredMessage(this.txtMatKhau, "Bận cần nhập mật khẩu mới");
            this.txtMatKhau.Size = new System.Drawing.Size(150, 20);
            this.txtMatKhau.TabIndex = 1;
            this.validator.SetType(this.txtMatKhau, Itboy.Components.ValidationType.Required);
            // 
            // txtTenTruyCap
            // 
            this.txtTenTruyCap.Location = new System.Drawing.Point(85, 53);
            this.txtTenTruyCap.MaxLength = 50;
            this.txtTenTruyCap.Name = "txtTenTruyCap";
            this.txtTenTruyCap.ReadOnly = true;
            this.txtTenTruyCap.Size = new System.Drawing.Size(166, 20);
            this.txtTenTruyCap.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mật khẩu";
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbGioiTinh.Location = new System.Drawing.Point(85, 143);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(51, 21);
            this.cbGioiTinh.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tên truy cập (*)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(160, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(292, 26);
            this.label13.TabIndex = 0;
            this.label13.Text = "Thay đổi thông tin cá nhân";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(439, 331);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(78, 23);
            this.btnCapNhat.TabIndex = 13;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(527, 331);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(78, 23);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Location = new System.Drawing.Point(106, 14);
            this.txtMatKhauCu.MaxLength = 20;
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.PasswordChar = '*';
            this.validator.SetRequiredMessage(this.txtMatKhauCu, "Bạn phải nhập mật khẩu cũ!");
            this.txtMatKhauCu.Size = new System.Drawing.Size(151, 20);
            this.txtMatKhauCu.TabIndex = 0;
            this.validator.SetType(this.txtMatKhauCu, Itboy.Components.ValidationType.Required);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(34, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Mật khẩu cũ";
            // 
            // cbChucVu
            // 
            this.cbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChucVu.Enabled = false;
            this.cbChucVu.FormattingEnabled = true;
            this.cbChucVu.Items.AddRange(new object[] {
            "Cấp phép công cộng",
            "Cấp phép chuyên dụng",
            "Cấp phép phát thanh truyền hình"});
            this.cbChucVu.Location = new System.Drawing.Point(328, 264);
            this.cbChucVu.Name = "cbChucVu";
            this.cbChucVu.Size = new System.Drawing.Size(174, 21);
            this.cbChucVu.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Chức vụ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Thuộc phòng";
            // 
            // cbPhong
            // 
            this.cbPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhong.Enabled = false;
            this.cbPhong.FormattingEnabled = true;
            this.cbPhong.Items.AddRange(new object[] {
            "Cấp phép công cộng",
            "Cấp phép chuyên dụng",
            "Cấp phép phát thanh truyền hình"});
            this.cbPhong.Location = new System.Drawing.Point(85, 264);
            this.cbPhong.Name = "cbPhong";
            this.cbPhong.Size = new System.Drawing.Size(166, 21);
            this.cbPhong.TabIndex = 11;
            // 
            // gbMatKhau
            // 
            this.gbMatKhau.Controls.Add(this.txtMatKhauCu);
            this.gbMatKhau.Controls.Add(this.txtXacNhanMatKhau);
            this.gbMatKhau.Controls.Add(this.label2);
            this.gbMatKhau.Controls.Add(this.label14);
            this.gbMatKhau.Controls.Add(this.label12);
            this.gbMatKhau.Controls.Add(this.txtMatKhau);
            this.gbMatKhau.Enabled = false;
            this.gbMatKhau.Location = new System.Drawing.Point(324, 66);
            this.gbMatKhau.Name = "gbMatKhau";
            this.gbMatKhau.Size = new System.Drawing.Size(281, 96);
            this.gbMatKhau.TabIndex = 6;
            this.gbMatKhau.TabStop = false;
            this.gbMatKhau.Text = "Mật khẩu";
            // 
            // chkDoiMatKhau
            // 
            this.chkDoiMatKhau.AutoSize = true;
            this.chkDoiMatKhau.Location = new System.Drawing.Point(324, 47);
            this.chkDoiMatKhau.Name = "chkDoiMatKhau";
            this.chkDoiMatKhau.Size = new System.Drawing.Size(115, 17);
            this.chkDoiMatKhau.TabIndex = 5;
            this.chkDoiMatKhau.Text = "Thay đổi mật khẩu";
            this.chkDoiMatKhau.UseVisualStyleBackColor = true;
            this.chkDoiMatKhau.CheckedChanged += new System.EventHandler(this.chkDoiMatKhau_CheckedChanged);
            // 
            // validator
            // 
            this.validator.BlinkRate = 1;
            // 
            // CapNhatThongTinCaNhan
            // 
            this.AcceptButton = this.btnCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(612, 366);
            this.Controls.Add(this.chkDoiMatKhau);
            this.Controls.Add(this.gbMatKhau);
            this.Controls.Add(this.cbChucVu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbPhong);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtNgaySinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQueQuan);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTenTruyCap);
            this.Controls.Add(this.cbGioiTinh);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CapNhatThongTinCaNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi thông tin cá nhân";
            this.gbMatKhau.ResumeLayout(false);
            this.gbMatKhau.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQueQuan;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenTruyCap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbChucVu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPhong;
        private System.Windows.Forms.GroupBox gbMatKhau;
        private System.Windows.Forms.CheckBox chkDoiMatKhau;
        private Itboy.Components.Validator validator;
    }
}