namespace Taxi.GUI {
	partial class DMPhong_QuanLy {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgrPhong = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkQuyenCapPhep = new System.Windows.Forms.CheckBox();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.pnlCapNhat = new System.Windows.Forms.Panel();
            this.pnlThemSua = new System.Windows.Forms.Panel();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhongID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuyenCapPhepHoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPhong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlCapNhat.SuspendLayout();
            this.pnlThemSua.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMoi.Location = new System.Drawing.Point(0, 0);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(75, 23);
            this.btnThemMoi.TabIndex = 3;
            this.btnThemMoi.Text = "&Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(81, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "&Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(505, 377);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Th&oát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(162, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgrPhong);
            this.groupBox2.Location = new System.Drawing.Point(12, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 267);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phòng";
            // 
            // dgrPhong
            // 
            this.dgrPhong.AllowUserToAddRows = false;
            this.dgrPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.PhongID,
            this.TenPhong,
            this.QuyenCapPhepHoSo});
            this.dgrPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrPhong.Location = new System.Drawing.Point(3, 16);
            this.dgrPhong.MultiSelect = false;
            this.dgrPhong.Name = "dgrPhong";
            this.dgrPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrPhong.Size = new System.Drawing.Size(562, 248);
            this.dgrPhong.TabIndex = 0;
            this.dgrPhong.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrPhong_CellDoubleClick);
            this.dgrPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrPhong_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.chkQuyenCapPhep);
            this.groupBox1.Controls.Add(this.txtPhong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết phòng";
            // 
            // chkQuyenCapPhep
            // 
            this.chkQuyenCapPhep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkQuyenCapPhep.AutoSize = true;
            this.chkQuyenCapPhep.Location = new System.Drawing.Point(401, 21);
            this.chkQuyenCapPhep.Name = "chkQuyenCapPhep";
            this.chkQuyenCapPhep.Size = new System.Drawing.Size(161, 17);
            this.chkQuyenCapPhep.TabIndex = 2;
            this.chkQuyenCapPhep.Text = "Được quyền cấp phép hồ sơ";
            this.chkQuyenCapPhep.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkQuyenCapPhep.UseVisualStyleBackColor = true;
            this.chkQuyenCapPhep.Visible = false;
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(71, 19);
            this.txtPhong.MaxLength = 255;
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(294, 20);
            this.txtPhong.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên phòng";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(0, 0);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 1;
            this.btnCapNhat.Text = "&Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(81, 0);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(75, 23);
            this.btnBoQua.TabIndex = 2;
            this.btnBoQua.Text = "&Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // pnlCapNhat
            // 
            this.pnlCapNhat.Controls.Add(this.btnCapNhat);
            this.pnlCapNhat.Controls.Add(this.btnBoQua);
            this.pnlCapNhat.Location = new System.Drawing.Point(12, 75);
            this.pnlCapNhat.Name = "pnlCapNhat";
            this.pnlCapNhat.Size = new System.Drawing.Size(156, 23);
            this.pnlCapNhat.TabIndex = 8;
            // 
            // pnlThemSua
            // 
            this.pnlThemSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThemSua.Controls.Add(this.btnThemMoi);
            this.pnlThemSua.Controls.Add(this.btnSua);
            this.pnlThemSua.Controls.Add(this.btnXoa);
            this.pnlThemSua.Location = new System.Drawing.Point(343, 75);
            this.pnlThemSua.Name = "pnlThemSua";
            this.pnlThemSua.Size = new System.Drawing.Size(237, 23);
            this.pnlThemSua.TabIndex = 9;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "SoTT";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STT.DefaultCellStyle = dataGridViewCellStyle1;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 40;
            // 
            // PhongID
            // 
            this.PhongID.DataPropertyName = "PhongID";
            this.PhongID.HeaderText = "ID phòng";
            this.PhongID.Name = "PhongID";
            this.PhongID.Visible = false;
            // 
            // TenPhong
            // 
            this.TenPhong.DataPropertyName = "TenPhong";
            this.TenPhong.HeaderText = "Tên phòng";
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.Width = 300;
            // 
            // QuyenCapPhepHoSo
            // 
            this.QuyenCapPhepHoSo.DataPropertyName = "QuyenCapPhepHoSo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.QuyenCapPhepHoSo.DefaultCellStyle = dataGridViewCellStyle2;
            this.QuyenCapPhepHoSo.HeaderText = "Quyền cấp phép hồ sơ";
            this.QuyenCapPhepHoSo.Name = "QuyenCapPhepHoSo";
            this.QuyenCapPhepHoSo.Visible = false;
            this.QuyenCapPhepHoSo.Width = 140;
            // 
            // DMPhong_QuanLy
            // 
            this.AcceptButton = this.btnCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(592, 412);
            this.Controls.Add(this.pnlThemSua);
            this.Controls.Add(this.pnlCapNhat);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "DMPhong_QuanLy";
            this.Text = "Quản lý danh mục phòng";
            this.Load += new System.EventHandler(this.DMPhong_QuanLy_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrPhong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlCapNhat.ResumeLayout(false);
            this.pnlThemSua.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnThemMoi;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgrPhong;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtPhong;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Panel pnlCapNhat;
        private System.Windows.Forms.Panel pnlThemSua;
        private System.Windows.Forms.CheckBox chkQuyenCapPhep;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuyenCapPhepHoSo;

	}
}