namespace Taxi.Controls.ThueBaoTuyen
{
    partial class frmTraCuuBangGiaGoc
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
            this.cboKieuTuyen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstTuyenDuong = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
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
            this.cboViTri = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiXeTuyenDuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboViTri.Properties)).BeginInit();
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
            this.cboKieuTuyen.Size = new System.Drawing.Size(117, 21);
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
            this.groupBox1.Size = new System.Drawing.Size(208, 547);
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
            this.lstTuyenDuong.Size = new System.Drawing.Size(183, 472);
            this.lstTuyenDuong.TabIndex = 2;
            this.lstTuyenDuong.SelectedValueChanged += new System.EventHandler(this.lstTuyenDuong_SelectedValueChanged);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(264, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 13);
            this.label10.TabIndex = 11;
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
            this.grdLoaiXeTuyenDuong.Location = new System.Drawing.Point(226, 73);
            this.grdLoaiXeTuyenDuong.Name = "grdLoaiXeTuyenDuong";
            this.grdLoaiXeTuyenDuong.ReadOnly = true;
            this.grdLoaiXeTuyenDuong.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLoaiXeTuyenDuong.Size = new System.Drawing.Size(734, 507);
            this.grdLoaiXeTuyenDuong.TabIndex = 10;
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
            // cboViTri
            // 
            this.cboViTri.IsChangeText = false;
            this.cboViTri.IsFocus = false;
            this.cboViTri.Location = new System.Drawing.Point(95, 7);
            this.cboViTri.Name = "cboViTri";
            this.cboViTri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboViTri.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Display", 50, "Điểm xuất phát")});
            this.cboViTri.Properties.NullText = "";
            this.cboViTri.Size = new System.Drawing.Size(125, 20);
            this.cboViTri.TabIndex = 12;
            // 
            // frmTraCuuBangGiaGoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 597);
            this.Controls.Add(this.cboViTri);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grdLoaiXeTuyenDuong);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTraCuuBangGiaGoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra cứu giá cước thuê bao tuyến";
            this.Load += new System.EventHandler(this.frmNhapBangGiaGoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiXeTuyenDuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboViTri.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboKieuTuyen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstTuyenDuong;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView grdLoaiXeTuyenDuong;
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
        private Base.Inputs.InputLookUp cboViTri;
    }
}