namespace Taxi.GUI
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstTuyenDuong = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdLoaiXeTuyenDuong = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTuyenDuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeTram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiXeTuyenDuong)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboKieuTuyen
            // 
            this.cboKieuTuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKieuTuyen.FormattingEnabled = true;
            this.cboKieuTuyen.Location = new System.Drawing.Point(66, 3);
            this.cboKieuTuyen.Name = "cboKieuTuyen";
            this.cboKieuTuyen.Size = new System.Drawing.Size(117, 21);
            this.cboKieuTuyen.TabIndex = 0;
            this.cboKieuTuyen.SelectedIndexChanged += new System.EventHandler(this.cboKieuTuyen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kiểu tuyến";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 597);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tuyến đường";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstTuyenDuong);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(196, 549);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách tuyến đường";
            // 
            // lstTuyenDuong
            // 
            this.lstTuyenDuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTuyenDuong.FormattingEnabled = true;
            this.lstTuyenDuong.Location = new System.Drawing.Point(3, 16);
            this.lstTuyenDuong.Name = "lstTuyenDuong";
            this.lstTuyenDuong.Size = new System.Drawing.Size(190, 530);
            this.lstTuyenDuong.TabIndex = 2;
            this.lstTuyenDuong.SelectedValueChanged += new System.EventHandler(this.lstTuyenDuong_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboKieuTuyen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 29);
            this.panel1.TabIndex = 4;
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
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column6,
            this.MaLoaiXe,
            this.VeTram});
            this.grdLoaiXeTuyenDuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLoaiXeTuyenDuong.Location = new System.Drawing.Point(3, 16);
            this.grdLoaiXeTuyenDuong.Name = "grdLoaiXeTuyenDuong";
            this.grdLoaiXeTuyenDuong.ReadOnly = true;
            this.grdLoaiXeTuyenDuong.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLoaiXeTuyenDuong.Size = new System.Drawing.Size(764, 578);
            this.grdLoaiXeTuyenDuong.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdLoaiXeTuyenDuong);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(202, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 597);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảng giá cước thuê bao tuyến";
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
            // Column1
            // 
            this.Column1.DataPropertyName = "KmQuyDinh1Chieu";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "QĐ Km 1 chiều";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ConvertHToNgay1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "QĐ số giờ 1 chiều";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 65;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GiaTien1Chieu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Giá tiền 1 chiều";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 65;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "KmQuyDinh2Chieu";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "QĐ Km 2 chiều";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 65;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ConvertHToNgay2";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "QĐ số giờ 2 chiều";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 65;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "GiaTien2Chieu";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column6.HeaderText = "Giá tiền 2 chiều";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 65;
            // 
            // MaLoaiXe
            // 
            this.MaLoaiXe.DataPropertyName = "LoaiXeID";
            this.MaLoaiXe.HeaderText = "Mã Loại xe";
            this.MaLoaiXe.Name = "MaLoaiXe";
            this.MaLoaiXe.ReadOnly = true;
            this.MaLoaiXe.Visible = false;
            // 
            // VeTram
            // 
            this.VeTram.DataPropertyName = "VeTram";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VeTram.DefaultCellStyle = dataGridViewCellStyle7;
            this.VeTram.HeaderText = "Vé trạm";
            this.VeTram.Name = "VeTram";
            this.VeTram.ReadOnly = true;
            this.VeTram.Width = 50;
            // 
            // frmTraCuuBangGiaGoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 597);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = global::TaxiApplication.Properties.Resources.Telephone_01;
            this.Name = "frmTraCuuBangGiaGoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra cứu giá cước thuê bao tuyến";
            this.Load += new System.EventHandler(this.frmNhapBangGiaGoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiXeTuyenDuong)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboKieuTuyen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstTuyenDuong;
        private System.Windows.Forms.DataGridView grdLoaiXeTuyenDuong;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTuyenDuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeTram;
    }
}