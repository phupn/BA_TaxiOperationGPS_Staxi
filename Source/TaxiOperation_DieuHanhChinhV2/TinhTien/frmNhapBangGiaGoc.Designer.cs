namespace Taxi.GUI
{
    partial class frmNhapBangGiaGoc_DHC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem2 = new Janus.Windows.EditControls.UIComboBoxItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapBangGiaGoc_DHC));
            this.cboKieuTuyen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstTuyenDuong = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grdLoaiXeTuyenDuong = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTuyenDuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeTram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnHuybo = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtGiaTien1Chieu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKmQD2Chieu = new System.Windows.Forms.TextBox();
            this.txtThoiGianQD2Chieu = new System.Windows.Forms.TextBox();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtVeTram = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtThoiGianQD1Chieu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKmQD1Chieu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGiaTien2Chieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cboViTri = new Janus.Windows.EditControls.UIComboBox();
            this.lnkXoaTuyen = new System.Windows.Forms.LinkLabel();
            this.lnkThemTuyen = new System.Windows.Forms.LinkLabel();
            this.lnkSuaTuyen = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiXeTuyenDuong)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboKieuTuyen
            // 
            this.cboKieuTuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKieuTuyen.FormattingEnabled = true;
            this.cboKieuTuyen.Items.AddRange(new object[] {
            "Tất cả",
            "Tuyến ngoại thành",
            "Tuyến ngoại tỉnh"});
            this.cboKieuTuyen.Location = new System.Drawing.Point(78, 20);
            this.cboKieuTuyen.Name = "cboKieuTuyen";
            this.cboKieuTuyen.Size = new System.Drawing.Size(151, 21);
            this.cboKieuTuyen.TabIndex = 0;
            this.cboKieuTuyen.SelectedIndexChanged += new System.EventHandler(this.cboKieuTuyen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kiểu tuyến";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstTuyenDuong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboKieuTuyen);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 547);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tuyến đường";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Danh sách các tuyến đường";
            // 
            // lstTuyenDuong
            // 
            this.lstTuyenDuong.FormattingEnabled = true;
            this.lstTuyenDuong.Location = new System.Drawing.Point(12, 70);
            this.lstTuyenDuong.Name = "lstTuyenDuong";
            this.lstTuyenDuong.Size = new System.Drawing.Size(217, 472);
            this.lstTuyenDuong.TabIndex = 2;
            this.lstTuyenDuong.SelectedValueChanged += new System.EventHandler(this.lstTuyenDuong_SelectedValueChanged);
            this.lstTuyenDuong.Leave += new System.EventHandler(this.lstTuyenDuong_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.grdLoaiXeTuyenDuong);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(255, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 551);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhập giá cho tuyến đường - loại xe";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Bảng giá của loại xe theo tuyến";
            // 
            // grdLoaiXeTuyenDuong
            // 
            this.grdLoaiXeTuyenDuong.AllowUserToDeleteRows = false;
            this.grdLoaiXeTuyenDuong.AllowUserToResizeColumns = false;
            this.grdLoaiXeTuyenDuong.AllowUserToResizeRows = false;
            this.grdLoaiXeTuyenDuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLoaiXeTuyenDuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TenTuyenDuong,
            this.TenLoaiXe,
            this.Column5,
            this.Column6,
            this.VeTram,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.MaLoaiXe});
            this.grdLoaiXeTuyenDuong.Location = new System.Drawing.Point(6, 263);
            this.grdLoaiXeTuyenDuong.Name = "grdLoaiXeTuyenDuong";
            this.grdLoaiXeTuyenDuong.ReadOnly = true;
            this.grdLoaiXeTuyenDuong.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLoaiXeTuyenDuong.Size = new System.Drawing.Size(693, 282);
            this.grdLoaiXeTuyenDuong.TabIndex = 8;
            this.grdLoaiXeTuyenDuong.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLoaiXeTuyenDuong_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "TuyenDuongID";
            this.ID.HeaderText = "Tuyến đường ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // TenTuyenDuong
            // 
            this.TenTuyenDuong.DataPropertyName = "TenTuyenDuong";
            this.TenTuyenDuong.HeaderText = "Tên tuyến đường";
            this.TenTuyenDuong.Name = "TenTuyenDuong";
            this.TenTuyenDuong.ReadOnly = true;
            this.TenTuyenDuong.Width = 150;
            // 
            // TenLoaiXe
            // 
            this.TenLoaiXe.DataPropertyName = "TenLoaiXe";
            this.TenLoaiXe.HeaderText = "Loại xe";
            this.TenLoaiXe.Name = "TenLoaiXe";
            this.TenLoaiXe.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GiaTien1Chieu";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Giá tiền 1 chiều";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 65;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "GiaTien2Chieu";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.HeaderText = "Giá tiền 2 chiều";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 65;
            // 
            // VeTram
            // 
            this.VeTram.DataPropertyName = "VeTram";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VeTram.DefaultCellStyle = dataGridViewCellStyle3;
            this.VeTram.HeaderText = "Vé trạm";
            this.VeTram.Name = "VeTram";
            this.VeTram.ReadOnly = true;
            this.VeTram.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "KmQuyDinh1Chieu";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.HeaderText = "QĐ Km 1 chiều";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ConvertHToNgay1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.HeaderText = "QĐ số giờ 1 chiều";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 65;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "KmQuyDinh2Chieu";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column3.HeaderText = "QĐ Km 2 chiều";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 65;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ConvertHToNgay2";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column4.HeaderText = "QĐ số giờ 2 chiều";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 65;
            // 
            // MaLoaiXe
            // 
            this.MaLoaiXe.DataPropertyName = "LoaiXeID";
            this.MaLoaiXe.HeaderText = "Mã Loại xe";
            this.MaLoaiXe.Name = "MaLoaiXe";
            this.MaLoaiXe.ReadOnly = true;
            this.MaLoaiXe.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnHuybo);
            this.groupBox5.Controls.Add(this.btnXoa);
            this.groupBox5.Controls.Add(this.txtGiaTien1Chieu);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.btnLuu);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.btnThemMoi);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.cboLoaiXe);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.txtGiaTien2Chieu);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(603, 214);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // btnHuybo
            // 
            this.btnHuybo.Location = new System.Drawing.Point(339, 179);
            this.btnHuybo.Name = "btnHuybo";
            this.btnHuybo.Size = new System.Drawing.Size(75, 23);
            this.btnHuybo.TabIndex = 3;
            this.btnHuybo.Text = "&Hủy bỏ";
            this.btnHuybo.UseVisualStyleBackColor = true;
            this.btnHuybo.Click += new System.EventHandler(this.btnHuybo_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(420, 179);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtGiaTien1Chieu
            // 
            this.txtGiaTien1Chieu.Location = new System.Drawing.Point(142, 151);
            this.txtGiaTien1Chieu.Name = "txtGiaTien1Chieu";
            this.txtGiaTien1Chieu.Size = new System.Drawing.Size(102, 20);
            this.txtGiaTien1Chieu.TabIndex = 1;
            this.txtGiaTien1Chieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGiaTien1Chieu.Leave += new System.EventHandler(this.txtGiaTien1Chieu_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Giá tiền 1 chiều";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(258, 179);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(248, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "(nghìn)";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(177, 179);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(75, 23);
            this.btnThemMoi.TabIndex = 0;
            this.btnThemMoi.Text = "&Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtKmQD2Chieu);
            this.groupBox4.Controls.Add(this.txtThoiGianQD2Chieu);
            this.groupBox4.Location = new System.Drawing.Point(300, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(288, 100);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Giá quy đinh chạy 2 chiều";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(251, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "(giờ)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(250, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "(Km)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Thời gian qui định 2 chiều ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Km qui định 2 chiều";
            // 
            // txtKmQD2Chieu
            // 
            this.txtKmQD2Chieu.Location = new System.Drawing.Point(140, 16);
            this.txtKmQD2Chieu.Name = "txtKmQD2Chieu";
            this.txtKmQD2Chieu.Size = new System.Drawing.Size(100, 20);
            this.txtKmQD2Chieu.TabIndex = 0;
            this.txtKmQD2Chieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtThoiGianQD2Chieu
            // 
            this.txtThoiGianQD2Chieu.Location = new System.Drawing.Point(140, 42);
            this.txtThoiGianQD2Chieu.Name = "txtThoiGianQD2Chieu";
            this.txtThoiGianQD2Chieu.Size = new System.Drawing.Size(100, 20);
            this.txtThoiGianQD2Chieu.TabIndex = 1;
            this.txtThoiGianQD2Chieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtThoiGianQD2Chieu.Leave += new System.EventHandler(this.txtThoiGianQD2Chieu_Leave);
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.DisplayMember = "TuyenDuongID";
            this.cboLoaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.FormattingEnabled = true;
            this.cboLoaiXe.Items.AddRange(new object[] {
            "Tất cả",
            "Tuyến ngoại thành",
            "Tuyến ngoại tỉnh"});
            this.cboLoaiXe.Location = new System.Drawing.Point(59, 115);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Size = new System.Drawing.Size(218, 21);
            this.cboLoaiXe.TabIndex = 0;
            this.cboLoaiXe.ValueMember = "TuyenDuongID";
            this.cboLoaiXe.SelectedIndexChanged += new System.EventHandler(this.cboLoaiXe_SelectedIndexChanged);
            this.cboLoaiXe.Leave += new System.EventHandler(this.cboLoaiXe_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtVeTram);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtThoiGianQD1Chieu);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtKmQD1Chieu);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(6, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 102);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Giá quy đinh chạy 1 chiều";
            // 
            // txtVeTram
            // 
            this.txtVeTram.Location = new System.Drawing.Point(136, 71);
            this.txtVeTram.Name = "txtVeTram";
            this.txtVeTram.Size = new System.Drawing.Size(102, 20);
            this.txtVeTram.TabIndex = 15;
            this.txtVeTram.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(78, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Vé trạm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(250, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "(giờ)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(249, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "(Km)";
            // 
            // txtThoiGianQD1Chieu
            // 
            this.txtThoiGianQD1Chieu.Location = new System.Drawing.Point(136, 48);
            this.txtThoiGianQD1Chieu.Name = "txtThoiGianQD1Chieu";
            this.txtThoiGianQD1Chieu.Size = new System.Drawing.Size(102, 20);
            this.txtThoiGianQD1Chieu.TabIndex = 1;
            this.txtThoiGianQD1Chieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Thời gian qui định 1 chiều ";
            // 
            // txtKmQD1Chieu
            // 
            this.txtKmQD1Chieu.Location = new System.Drawing.Point(136, 23);
            this.txtKmQD1Chieu.Name = "txtKmQD1Chieu";
            this.txtKmQD1Chieu.Size = new System.Drawing.Size(102, 20);
            this.txtKmQD1Chieu.TabIndex = 0;
            this.txtKmQD1Chieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Km qui định 1 chiều";
            // 
            // txtGiaTien2Chieu
            // 
            this.txtGiaTien2Chieu.Location = new System.Drawing.Point(440, 150);
            this.txtGiaTien2Chieu.Name = "txtGiaTien2Chieu";
            this.txtGiaTien2Chieu.Size = new System.Drawing.Size(100, 20);
            this.txtGiaTien2Chieu.TabIndex = 2;
            this.txtGiaTien2Chieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGiaTien2Chieu.Leave += new System.EventHandler(this.txtGiaTien2Chieu_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Loại xe";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Giá tiền 2 chiều";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(544, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "(nghìn)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "Áp dụng cho";
            // 
            // cboViTri
            // 
            this.cboViTri.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.Text = "Hải Dương";
            uiComboBoxItem1.Value = false;
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.Text = "Hải Phòng";
            uiComboBoxItem2.Value = true;
            this.cboViTri.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2});
            this.cboViTri.Location = new System.Drawing.Point(90, 7);
            this.cboViTri.Name = "cboViTri";
            this.cboViTri.Size = new System.Drawing.Size(151, 20);
            this.cboViTri.TabIndex = 5;
            this.cboViTri.SelectedValueChanged += new System.EventHandler(this.cboViTri_SelectedValueChanged);
            // 
            // lnkXoaTuyen
            // 
            this.lnkXoaTuyen.AutoSize = true;
            this.lnkXoaTuyen.Location = new System.Drawing.Point(194, 588);
            this.lnkXoaTuyen.Name = "lnkXoaTuyen";
            this.lnkXoaTuyen.Size = new System.Drawing.Size(55, 13);
            this.lnkXoaTuyen.TabIndex = 6;
            this.lnkXoaTuyen.TabStop = true;
            this.lnkXoaTuyen.Text = "Xóa tuyến";
            this.lnkXoaTuyen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkXoaTuyen_LinkClicked);
            // 
            // lnkThemTuyen
            // 
            this.lnkThemTuyen.AutoSize = true;
            this.lnkThemTuyen.Location = new System.Drawing.Point(71, 588);
            this.lnkThemTuyen.Name = "lnkThemTuyen";
            this.lnkThemTuyen.Size = new System.Drawing.Size(63, 13);
            this.lnkThemTuyen.TabIndex = 7;
            this.lnkThemTuyen.TabStop = true;
            this.lnkThemTuyen.Text = "Thêm tuyến";
            this.lnkThemTuyen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkThemTuyen_LinkClicked);
            // 
            // lnkSuaTuyen
            // 
            this.lnkSuaTuyen.AutoSize = true;
            this.lnkSuaTuyen.Location = new System.Drawing.Point(135, 588);
            this.lnkSuaTuyen.Name = "lnkSuaTuyen";
            this.lnkSuaTuyen.Size = new System.Drawing.Size(55, 13);
            this.lnkSuaTuyen.TabIndex = 8;
            this.lnkSuaTuyen.TabStop = true;
            this.lnkSuaTuyen.Text = "Sửa tuyến";
            this.lnkSuaTuyen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSuaTuyen_LinkClicked);
            // 
            // frmNhapBangGiaGoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 606);
            this.Controls.Add(this.lnkSuaTuyen);
            this.Controls.Add(this.lnkThemTuyen);
            this.Controls.Add(this.lnkXoaTuyen);
            this.Controls.Add(this.cboViTri);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhapBangGiaGoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập bảng giá gốc";
            this.Load += new System.EventHandler(this.frmNhapBangGiaGoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiXeTuyenDuong)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboKieuTuyen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstTuyenDuong;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGiaTien2Chieu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtThoiGianQD2Chieu;
        private System.Windows.Forms.TextBox txtKmQD2Chieu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiaTien1Chieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtThoiGianQD1Chieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKmQD1Chieu;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView grdLoaiXeTuyenDuong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnHuybo;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private Janus.Windows.EditControls.UIComboBox cboViTri;
        private System.Windows.Forms.TextBox txtVeTram;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTuyenDuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeTram;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiXe;
        private System.Windows.Forms.LinkLabel lnkXoaTuyen;
        private System.Windows.Forms.LinkLabel lnkThemTuyen;
        private System.Windows.Forms.LinkLabel lnkSuaTuyen;
    }
}