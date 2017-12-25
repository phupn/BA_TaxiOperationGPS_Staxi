namespace Taxi.GUI
{
    partial class DMLoaiDiaDanh
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.grbLoaiDiaDanh = new System.Windows.Forms.GroupBox();
            this.grdLoaiDiaDanh = new System.Windows.Forms.DataGridView();
            this.pnlThaoTac = new System.Windows.Forms.Panel();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pnlCapNhat = new System.Windows.Forms.Panel();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.lblTenKieuDieuChe = new System.Windows.Forms.Label();
            this.txtLoaiDiaDanh = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TenLoaiDiaDanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiDiaDanhID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbLoaiDiaDanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiDiaDanh)).BeginInit();
            this.pnlThaoTac.SuspendLayout();
            this.pnlCapNhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(539, 314);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // grbLoaiDiaDanh
            // 
            this.grbLoaiDiaDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLoaiDiaDanh.Controls.Add(this.grdLoaiDiaDanh);
            this.grbLoaiDiaDanh.Location = new System.Drawing.Point(12, 78);
            this.grbLoaiDiaDanh.Name = "grbLoaiDiaDanh";
            this.grbLoaiDiaDanh.Size = new System.Drawing.Size(605, 230);
            this.grbLoaiDiaDanh.TabIndex = 12;
            this.grbLoaiDiaDanh.TabStop = false;
            this.grbLoaiDiaDanh.Text = "Danh sách loại địa danh";
            // 
            // grdLoaiDiaDanh
            // 
            this.grdLoaiDiaDanh.AllowUserToAddRows = false;
            this.grdLoaiDiaDanh.AllowUserToDeleteRows = false;
            this.grdLoaiDiaDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLoaiDiaDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLoaiDiaDanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenLoaiDiaDanh,
            this.LoaiDiaDanhID});
            this.grdLoaiDiaDanh.Location = new System.Drawing.Point(6, 19);
            this.grdLoaiDiaDanh.MultiSelect = false;
            this.grdLoaiDiaDanh.Name = "grdLoaiDiaDanh";
            this.grdLoaiDiaDanh.ReadOnly = true;
            this.grdLoaiDiaDanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLoaiDiaDanh.Size = new System.Drawing.Size(593, 205);
            this.grdLoaiDiaDanh.TabIndex = 6;
            this.grdLoaiDiaDanh.SelectionChanged += new System.EventHandler(this.grdLoaiDiaDanh_SelectionChanged);
            this.grdLoaiDiaDanh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLoaiDiaDanh_CellContentClick);
            // 
            // pnlThaoTac
            // 
            this.pnlThaoTac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThaoTac.Controls.Add(this.btnThemMoi);
            this.pnlThaoTac.Controls.Add(this.btnSua);
            this.pnlThaoTac.Controls.Add(this.btnXoa);
            this.pnlThaoTac.Location = new System.Drawing.Point(369, 42);
            this.pnlThaoTac.Name = "pnlThaoTac";
            this.pnlThaoTac.Size = new System.Drawing.Size(248, 30);
            this.pnlThaoTac.TabIndex = 11;
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMoi.Location = new System.Drawing.Point(9, 3);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(75, 23);
            this.btnThemMoi.TabIndex = 1;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(89, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(170, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // pnlCapNhat
            // 
            this.pnlCapNhat.Controls.Add(this.btnBoQua);
            this.pnlCapNhat.Controls.Add(this.btnCapNhat);
            this.pnlCapNhat.Location = new System.Drawing.Point(15, 42);
            this.pnlCapNhat.Name = "pnlCapNhat";
            this.pnlCapNhat.Size = new System.Drawing.Size(348, 30);
            this.pnlCapNhat.TabIndex = 10;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(84, 4);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(75, 23);
            this.btnBoQua.TabIndex = 5;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(3, 4);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // lblTenKieuDieuChe
            // 
            this.lblTenKieuDieuChe.AutoSize = true;
            this.lblTenKieuDieuChe.Location = new System.Drawing.Point(12, 14);
            this.lblTenKieuDieuChe.Name = "lblTenKieuDieuChe";
            this.lblTenKieuDieuChe.Size = new System.Drawing.Size(90, 13);
            this.lblTenKieuDieuChe.TabIndex = 9;
            this.lblTenKieuDieuChe.Text = "Tên loại địa danh";
            // 
            // txtLoaiDiaDanh
            // 
            this.txtLoaiDiaDanh.Location = new System.Drawing.Point(112, 11);
            this.txtLoaiDiaDanh.MaxLength = 50;
            this.txtLoaiDiaDanh.Name = "txtLoaiDiaDanh";
            this.txtLoaiDiaDanh.Size = new System.Drawing.Size(251, 20);
            this.txtLoaiDiaDanh.TabIndex = 8;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 1;
            this.errorProvider.ContainerControl = this;
            // 
            // TenLoaiDiaDanh
            // 
            this.TenLoaiDiaDanh.DataPropertyName = "TenLoaiDiaDanh";
            this.TenLoaiDiaDanh.HeaderText = "Loại địa danh";
            this.TenLoaiDiaDanh.Name = "TenLoaiDiaDanh";
            this.TenLoaiDiaDanh.ReadOnly = true;
            this.TenLoaiDiaDanh.Width = 350;
            // 
            // LoaiDiaDanhID
            // 
            this.LoaiDiaDanhID.DataPropertyName = "PK_LoaiDiaDanh";
            this.LoaiDiaDanhID.HeaderText = "ID";
            this.LoaiDiaDanhID.Name = "LoaiDiaDanhID";
            this.LoaiDiaDanhID.ReadOnly = true;
            this.LoaiDiaDanhID.Visible = false;
            // 
            // DMLoaiDiaDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 348);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.grbLoaiDiaDanh);
            this.Controls.Add(this.pnlThaoTac);
            this.Controls.Add(this.pnlCapNhat);
            this.Controls.Add(this.lblTenKieuDieuChe);
            this.Controls.Add(this.txtLoaiDiaDanh);
            this.Name = "DMLoaiDiaDanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục loại địa danh";
            this.Load += new System.EventHandler(this.DMLoaiDiaDanh_Load);
            this.grbLoaiDiaDanh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiDiaDanh)).EndInit();
            this.pnlThaoTac.ResumeLayout(false);
            this.pnlCapNhat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox grbLoaiDiaDanh;
        private System.Windows.Forms.DataGridView grdLoaiDiaDanh;
        private System.Windows.Forms.Panel pnlThaoTac;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel pnlCapNhat;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label lblTenKieuDieuChe;
        private System.Windows.Forms.TextBox txtLoaiDiaDanh;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiDiaDanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiDiaDanhID;
    }
}