namespace Taxi.GUI {
	partial class Hethong_NhatKy_QuanLy {
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hethong_NhatKy_QuanLy));
            this.gbTieuChuanLoc = new System.Windows.Forms.GroupBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.chklstNguoiDung = new System.Windows.Forms.CheckedListBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuGio = new System.Windows.Forms.DateTimePicker();
            this.dtpDenGio = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.lblTuGio = new System.Windows.Forms.Label();
            this.gbNhatKyHeThong = new System.Windows.Forms.GroupBox();
            this.grdKetQuaTimKiem = new Janus.Windows.GridEX.GridEX();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoaNhatKy = new System.Windows.Forms.Button();
            this.btnThietLap = new System.Windows.Forms.Button();
            this.gbTieuChuanLoc.SuspendLayout();
            this.gbNhatKyHeThong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKetQuaTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTieuChuanLoc
            // 
            this.gbTieuChuanLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTieuChuanLoc.Controls.Add(this.btnLoc);
            this.gbTieuChuanLoc.Controls.Add(this.chklstNguoiDung);
            this.gbTieuChuanLoc.Controls.Add(this.lblTuNgay);
            this.gbTieuChuanLoc.Controls.Add(this.label4);
            this.gbTieuChuanLoc.Controls.Add(this.lblDenNgay);
            this.gbTieuChuanLoc.Controls.Add(this.dtpTuGio);
            this.gbTieuChuanLoc.Controls.Add(this.dtpDenGio);
            this.gbTieuChuanLoc.Controls.Add(this.dtpDenNgay);
            this.gbTieuChuanLoc.Controls.Add(this.dtpTuNgay);
            this.gbTieuChuanLoc.Controls.Add(this.lblNguoiDung);
            this.gbTieuChuanLoc.Controls.Add(this.lblTuGio);
            this.gbTieuChuanLoc.Location = new System.Drawing.Point(12, 12);
            this.gbTieuChuanLoc.Name = "gbTieuChuanLoc";
            this.gbTieuChuanLoc.Size = new System.Drawing.Size(770, 151);
            this.gbTieuChuanLoc.TabIndex = 0;
            this.gbTieuChuanLoc.TabStop = false;
            this.gbTieuChuanLoc.Text = "Tiêu chuẩn lọc";
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(85, 119);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "&Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // chklstNguoiDung
            // 
            this.chklstNguoiDung.CheckOnClick = true;
            this.chklstNguoiDung.FormattingEnabled = true;
            this.chklstNguoiDung.Items.AddRange(new object[] {
            "Nguyễn Văn Thương",
            "Trịnh Công Sơn",
            "Nguyễn Văn Tý"});
            this.chklstNguoiDung.Location = new System.Drawing.Point(85, 19);
            this.chklstNguoiDung.Name = "chklstNguoiDung";
            this.chklstNguoiDung.Size = new System.Drawing.Size(248, 94);
            this.chklstNguoiDung.TabIndex = 1;
            this.chklstNguoiDung.Click += new System.EventHandler(this.chklstNguoiDung_Click);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(556, 23);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(32, 13);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đến thời điểm";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(556, 49);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(32, 13);
            this.lblDenNgay.TabIndex = 0;
            this.lblDenNgay.Text = "Ngày";
            // 
            // dtpTuGio
            // 
            this.dtpTuGio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTuGio.Location = new System.Drawing.Point(448, 19);
            this.dtpTuGio.Name = "dtpTuGio";
            this.dtpTuGio.ShowUpDown = true;
            this.dtpTuGio.Size = new System.Drawing.Size(102, 20);
            this.dtpTuGio.TabIndex = 2;
            this.dtpTuGio.Value = new System.DateTime(2008, 5, 23, 0, 0, 0, 0);
            // 
            // dtpDenGio
            // 
            this.dtpDenGio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDenGio.Location = new System.Drawing.Point(448, 45);
            this.dtpDenGio.Name = "dtpDenGio";
            this.dtpDenGio.ShowUpDown = true;
            this.dtpDenGio.Size = new System.Drawing.Size(102, 20);
            this.dtpDenGio.TabIndex = 4;
            this.dtpDenGio.Value = new System.DateTime(2008, 5, 23, 0, 0, 0, 0);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(594, 45);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(102, 20);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(594, 19);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(102, 20);
            this.dtpTuNgay.TabIndex = 3;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.AutoSize = true;
            this.lblNguoiDung.Location = new System.Drawing.Point(13, 19);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(62, 13);
            this.lblNguoiDung.TabIndex = 0;
            this.lblNguoiDung.Text = "Người dùng";
            // 
            // lblTuGio
            // 
            this.lblTuGio.AutoSize = true;
            this.lblTuGio.Location = new System.Drawing.Point(376, 23);
            this.lblTuGio.Name = "lblTuGio";
            this.lblTuGio.Size = new System.Drawing.Size(66, 13);
            this.lblTuGio.TabIndex = 0;
            this.lblTuGio.Text = "Từ thời điểm";
            // 
            // gbNhatKyHeThong
            // 
            this.gbNhatKyHeThong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNhatKyHeThong.Controls.Add(this.grdKetQuaTimKiem);
            this.gbNhatKyHeThong.Location = new System.Drawing.Point(12, 169);
            this.gbNhatKyHeThong.Name = "gbNhatKyHeThong";
            this.gbNhatKyHeThong.Size = new System.Drawing.Size(770, 354);
            this.gbNhatKyHeThong.TabIndex = 0;
            this.gbNhatKyHeThong.TabStop = false;
            this.gbNhatKyHeThong.Text = "Nhật ký hệ thống";
            // 
            // grdKetQuaTimKiem
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdKetQuaTimKiem.DesignTimeLayout = gridEXLayout1;
            this.grdKetQuaTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKetQuaTimKiem.GroupByBoxVisible = false;
            this.grdKetQuaTimKiem.Location = new System.Drawing.Point(3, 16);
            this.grdKetQuaTimKiem.Name = "grdKetQuaTimKiem";
            this.grdKetQuaTimKiem.RecordNavigator = true;
            this.grdKetQuaTimKiem.SaveSettings = false;
            this.grdKetQuaTimKiem.Size = new System.Drawing.Size(764, 335);
            this.grdKetQuaTimKiem.TabIndex = 0;
            this.grdKetQuaTimKiem.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdKetQuaTimKiem_LoadingRow);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(707, 529);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoaNhatKy
            // 
            this.btnXoaNhatKy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaNhatKy.Location = new System.Drawing.Point(626, 529);
            this.btnXoaNhatKy.Name = "btnXoaNhatKy";
            this.btnXoaNhatKy.Size = new System.Drawing.Size(75, 23);
            this.btnXoaNhatKy.TabIndex = 2;
            this.btnXoaNhatKy.Text = "&Xóa nhật ký";
            this.btnXoaNhatKy.UseVisualStyleBackColor = true;
            this.btnXoaNhatKy.Click += new System.EventHandler(this.btnXoaNhatKy_Click);
            // 
            // btnThietLap
            // 
            this.btnThietLap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThietLap.Location = new System.Drawing.Point(545, 529);
            this.btnThietLap.Name = "btnThietLap";
            this.btnThietLap.Size = new System.Drawing.Size(75, 23);
            this.btnThietLap.TabIndex = 1;
            this.btnThietLap.Text = "&Thiết lập";
            this.btnThietLap.UseVisualStyleBackColor = true;
            this.btnThietLap.Click += new System.EventHandler(this.btnThietLap_Click);
            // 
            // Hethong_NhatKy_QuanLy
            // 
            this.AcceptButton = this.btnLoc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(794, 564);
            this.Controls.Add(this.btnThietLap);
            this.Controls.Add(this.btnXoaNhatKy);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.gbNhatKyHeThong);
            this.Controls.Add(this.gbTieuChuanLoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "Hethong_NhatKy_QuanLy";
            this.Text = "Quản lý nhật ký hệ thống";
            this.Load += new System.EventHandler(this.Hethong_NhatKy_QuanLy_Load);
            this.gbTieuChuanLoc.ResumeLayout(false);
            this.gbTieuChuanLoc.PerformLayout();
            this.gbNhatKyHeThong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKetQuaTimKiem)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbTieuChuanLoc;
		private System.Windows.Forms.Label lblTuGio;
		private System.Windows.Forms.GroupBox gbNhatKyHeThong;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.DateTimePicker dtpTuNgay;
		private System.Windows.Forms.Label lblTuNgay;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblDenNgay;
		private System.Windows.Forms.DateTimePicker dtpTuGio;
		private System.Windows.Forms.DateTimePicker dtpDenGio;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
		private System.Windows.Forms.Label lblNguoiDung;
		private System.Windows.Forms.Button btnLoc;
		private System.Windows.Forms.Button btnXoaNhatKy;
        private System.Windows.Forms.Button btnThietLap;
        private System.Windows.Forms.CheckedListBox chklstNguoiDung;
        private Janus.Windows.GridEX.GridEX grdKetQuaTimKiem;
	}
}