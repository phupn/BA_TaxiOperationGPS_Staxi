namespace Taxi.GUI {
	partial class HeThong_NhatKy_ThietLapCauHinh {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeThong_NhatKy_ThietLapCauHinh));
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblCheDoGhi = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChucNang = new System.Windows.Forms.ComboBox();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.grdSuKien = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSuKien)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(505, 377);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblCheDoGhi
            // 
            this.lblCheDoGhi.AutoSize = true;
            this.lblCheDoGhi.Location = new System.Drawing.Point(12, 36);
            this.lblCheDoGhi.Name = "lblCheDoGhi";
            this.lblCheDoGhi.Size = new System.Drawing.Size(59, 13);
            this.lblCheDoGhi.TabIndex = 2;
            this.lblCheDoGhi.Text = "Chế độ ghi";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(424, 377);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 3;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chức năng";
            // 
            // cbChucNang
            // 
            this.cbChucNang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChucNang.FormattingEnabled = true;
            this.cbChucNang.Items.AddRange(new object[] {
            "Quản lý bản khai",
            "Quản lý giấy phép",
            "Quản lý TBNP",
            "Quản lý người dùng"});
            this.cbChucNang.Location = new System.Drawing.Point(77, 6);
            this.cbChucNang.Name = "cbChucNang";
            this.cbChucNang.Size = new System.Drawing.Size(288, 21);
            this.cbChucNang.TabIndex = 1;
            this.cbChucNang.SelectedValueChanged += new System.EventHandler(this.cbChucNang_SelectedValueChanged);
            // 
            // gridEX1
            // 
            this.gridEX1.Location = new System.Drawing.Point(0, 0);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(400, 376);
            this.gridEX1.TabIndex = 0;
            // 
            // grdSuKien
            // 
            this.grdSuKien.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdSuKien.DesignTimeLayout = gridEXLayout1;
            this.grdSuKien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdSuKien.GridLines = Janus.Windows.GridEX.GridLines.Default;
            this.grdSuKien.GroupByBoxVisible = false;
            this.grdSuKien.Location = new System.Drawing.Point(12, 63);
            this.grdSuKien.Name = "grdSuKien";
            this.grdSuKien.SaveSettings = false;
            this.grdSuKien.Size = new System.Drawing.Size(568, 288);
            this.grdSuKien.TabIndex = 2;
            // 
            // HeThong_NhatKy_ThietLapCauHinh
            // 
            this.AcceptButton = this.btnCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(592, 412);
            this.Controls.Add(this.grdSuKien);
            this.Controls.Add(this.cbChucNang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCheDoGhi);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThoat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeThong_NhatKy_ThietLapCauHinh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập cấu hình ghi nhật ký";
            this.Load += new System.EventHandler(this.HeThong_NhatKy_ThietLapCauHinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSuKien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Label lblCheDoGhi;
		private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbChucNang;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private Janus.Windows.GridEX.GridEX grdSuKien;
	}
}