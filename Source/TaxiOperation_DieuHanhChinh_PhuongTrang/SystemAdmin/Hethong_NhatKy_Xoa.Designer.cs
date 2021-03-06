namespace Taxi.GUI {
	partial class Hethong_NhatKy_Xoa {
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
            this.btnXoa = new System.Windows.Forms.Button();
            this.gbTieuChuanLoc = new System.Windows.Forms.GroupBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenGio = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuGio = new System.Windows.Forms.DateTimePicker();
            this.dtpDenGio = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuGio = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbTieuChuanLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(426, 379);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // gbTieuChuanLoc
            // 
            this.gbTieuChuanLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTieuChuanLoc.Controls.Add(this.lblTuNgay);
            this.gbTieuChuanLoc.Controls.Add(this.lblDenGio);
            this.gbTieuChuanLoc.Controls.Add(this.lblDenNgay);
            this.gbTieuChuanLoc.Controls.Add(this.dtpTuGio);
            this.gbTieuChuanLoc.Controls.Add(this.dtpDenGio);
            this.gbTieuChuanLoc.Controls.Add(this.dtpDenNgay);
            this.gbTieuChuanLoc.Controls.Add(this.dtpTuNgay);
            this.gbTieuChuanLoc.Controls.Add(this.lblTuGio);
            this.gbTieuChuanLoc.Location = new System.Drawing.Point(12, 12);
            this.gbTieuChuanLoc.Name = "gbTieuChuanLoc";
            this.gbTieuChuanLoc.Size = new System.Drawing.Size(570, 79);
            this.gbTieuChuanLoc.TabIndex = 1;
            this.gbTieuChuanLoc.TabStop = false;
            this.gbTieuChuanLoc.Text = "Thời điểm xóa";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(193, 24);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(32, 13);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Ngày";
            // 
            // lblDenGio
            // 
            this.lblDenGio.AutoSize = true;
            this.lblDenGio.Location = new System.Drawing.Point(52, 50);
            this.lblDenGio.Name = "lblDenGio";
            this.lblDenGio.Size = new System.Drawing.Size(27, 13);
            this.lblDenGio.TabIndex = 0;
            this.lblDenGio.Text = "Đến";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(193, 50);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(32, 13);
            this.lblDenNgay.TabIndex = 0;
            this.lblDenNgay.Text = "Ngày";
            // 
            // dtpTuGio
            // 
            this.dtpTuGio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTuGio.Location = new System.Drawing.Point(85, 20);
            this.dtpTuGio.Name = "dtpTuGio";
            this.dtpTuGio.ShowUpDown = true;
            this.dtpTuGio.Size = new System.Drawing.Size(102, 20);
            this.dtpTuGio.TabIndex = 1;
            this.dtpTuGio.Value = new System.DateTime(2008, 5, 23, 0, 0, 0, 0);
            // 
            // dtpDenGio
            // 
            this.dtpDenGio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDenGio.Location = new System.Drawing.Point(85, 46);
            this.dtpDenGio.Name = "dtpDenGio";
            this.dtpDenGio.ShowUpDown = true;
            this.dtpDenGio.Size = new System.Drawing.Size(102, 20);
            this.dtpDenGio.TabIndex = 3;
            this.dtpDenGio.Value = new System.DateTime(2008, 5, 23, 0, 0, 0, 0);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(231, 46);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(102, 20);
            this.dtpDenNgay.TabIndex = 4;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(231, 20);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(102, 20);
            this.dtpTuNgay.TabIndex = 2;
            // 
            // lblTuGio
            // 
            this.lblTuGio.AutoSize = true;
            this.lblTuGio.Location = new System.Drawing.Point(59, 24);
            this.lblTuGio.Name = "lblTuGio";
            this.lblTuGio.Size = new System.Drawing.Size(20, 13);
            this.lblTuGio.TabIndex = 0;
            this.lblTuGio.Text = "Từ";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(507, 379);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Hethong_NhatKy_Xoa
            // 
            this.AcceptButton = this.btnXoa;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(594, 414);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.gbTieuChuanLoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Hethong_NhatKy_Xoa";
            this.Text = "Xóa nhật ký hệ thống";
            this.gbTieuChuanLoc.ResumeLayout(false);
            this.gbTieuChuanLoc.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.GroupBox gbTieuChuanLoc;
		private System.Windows.Forms.Label lblTuNgay;
		private System.Windows.Forms.Label lblDenGio;
		private System.Windows.Forms.Label lblDenNgay;
		private System.Windows.Forms.DateTimePicker dtpTuGio;
		private System.Windows.Forms.DateTimePicker dtpDenGio;
		private System.Windows.Forms.DateTimePicker dtpDenNgay;
		private System.Windows.Forms.DateTimePicker dtpTuNgay;
		private System.Windows.Forms.Label lblTuGio;
        private System.Windows.Forms.Button btnThoat;
	}
}