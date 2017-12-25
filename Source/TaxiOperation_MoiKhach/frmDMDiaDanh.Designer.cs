namespace Taxi.GUI
{
    partial class frmDMDiaDanh
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMDiaDanh));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkThemMoi = new System.Windows.Forms.LinkLabel();
            this.trvLoaiDiaDanh = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkSuaDiaDanh = new System.Windows.Forms.LinkLabel();
            this.lnkXoaDiaDanh = new System.Windows.Forms.LinkLabel();
            this.gridDiaDanh = new Janus.Windows.GridEX.GridEX();
            this.lnkThemDiaDanh = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.rdoDiaChi = new System.Windows.Forms.RadioButton();
            this.rdoTheoTen = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiaDanh)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkThemMoi);
            this.groupBox1.Controls.Add(this.trvLoaiDiaDanh);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 564);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Loại địa danh";
            // 
            // lnkThemMoi
            // 
            this.lnkThemMoi.AutoSize = true;
            this.lnkThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkThemMoi.Location = new System.Drawing.Point(6, 541);
            this.lnkThemMoi.Name = "lnkThemMoi";
            this.lnkThemMoi.Size = new System.Drawing.Size(61, 13);
            this.lnkThemMoi.TabIndex = 1;
            this.lnkThemMoi.TabStop = true;
            this.lnkThemMoi.Text = "Thêm mới";
            this.lnkThemMoi.Visible = false;
            this.lnkThemMoi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkThemMoi_LinkClicked);
            // 
            // trvLoaiDiaDanh
            // 
            this.trvLoaiDiaDanh.Location = new System.Drawing.Point(6, 19);
            this.trvLoaiDiaDanh.Name = "trvLoaiDiaDanh";
            this.trvLoaiDiaDanh.Size = new System.Drawing.Size(194, 515);
            this.trvLoaiDiaDanh.TabIndex = 0;
            this.trvLoaiDiaDanh.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvLoaiDiaDanh_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lnkSuaDiaDanh);
            this.groupBox2.Controls.Add(this.lnkXoaDiaDanh);
            this.groupBox2.Controls.Add(this.gridDiaDanh);
            this.groupBox2.Controls.Add(this.lnkThemDiaDanh);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(217, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 564);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin địa danh";
            // 
            // lnkSuaDiaDanh
            // 
            this.lnkSuaDiaDanh.AutoSize = true;
            this.lnkSuaDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSuaDiaDanh.Location = new System.Drawing.Point(496, 541);
            this.lnkSuaDiaDanh.Name = "lnkSuaDiaDanh";
            this.lnkSuaDiaDanh.Size = new System.Drawing.Size(33, 13);
            this.lnkSuaDiaDanh.TabIndex = 6;
            this.lnkSuaDiaDanh.TabStop = true;
            this.lnkSuaDiaDanh.Text = "Sửa ";
            this.lnkSuaDiaDanh.Visible = false;
            this.lnkSuaDiaDanh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSuaDiaDanh_LinkClicked);
            // 
            // lnkXoaDiaDanh
            // 
            this.lnkXoaDiaDanh.AutoSize = true;
            this.lnkXoaDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkXoaDiaDanh.Location = new System.Drawing.Point(529, 541);
            this.lnkXoaDiaDanh.Name = "lnkXoaDiaDanh";
            this.lnkXoaDiaDanh.Size = new System.Drawing.Size(29, 13);
            this.lnkXoaDiaDanh.TabIndex = 5;
            this.lnkXoaDiaDanh.TabStop = true;
            this.lnkXoaDiaDanh.Text = "Xóa";
            this.lnkXoaDiaDanh.Visible = false;
            this.lnkXoaDiaDanh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkXoaDiaDanh_LinkClicked);
            // 
            // gridDiaDanh
            // 
            this.gridDiaDanh.AllowColumnDrag = false;
            this.gridDiaDanh.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridDiaDanh.AutomaticSort = false;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridDiaDanh.DesignTimeLayout = gridEXLayout1;
            this.gridDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridDiaDanh.GroupByBoxVisible = false;
            this.gridDiaDanh.Location = new System.Drawing.Point(15, 96);
            this.gridDiaDanh.Name = "gridDiaDanh";
            this.gridDiaDanh.SaveSettings = false;
            this.gridDiaDanh.Size = new System.Drawing.Size(540, 438);
            this.gridDiaDanh.TabIndex = 1;
            // 
            // lnkThemDiaDanh
            // 
            this.lnkThemDiaDanh.AutoSize = true;
            this.lnkThemDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkThemDiaDanh.Location = new System.Drawing.Point(436, 541);
            this.lnkThemDiaDanh.Name = "lnkThemDiaDanh";
            this.lnkThemDiaDanh.Size = new System.Drawing.Size(61, 13);
            this.lnkThemDiaDanh.TabIndex = 4;
            this.lnkThemDiaDanh.TabStop = true;
            this.lnkThemDiaDanh.Text = "Thêm mới";
            this.lnkThemDiaDanh.Visible = false;
            this.lnkThemDiaDanh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkThemDiaDanh_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTimKiem);
            this.groupBox3.Controls.Add(this.txtTimKiem);
            this.groupBox3.Controls.Add(this.rdoDiaChi);
            this.groupBox3.Controls.Add(this.rdoTheoTen);
            this.groupBox3.Location = new System.Drawing.Point(15, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 70);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Image = global::TaxiOperation_MoiKhach.Properties.Resources.Search;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(395, 31);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(73, 23);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "&Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(57, 34);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(321, 20);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // rdoDiaChi
            // 
            this.rdoDiaChi.AutoSize = true;
            this.rdoDiaChi.Location = new System.Drawing.Point(148, 11);
            this.rdoDiaChi.Name = "rdoDiaChi";
            this.rdoDiaChi.Size = new System.Drawing.Size(97, 17);
            this.rdoDiaChi.TabIndex = 1;
            this.rdoDiaChi.Text = "&2. Theo địa chỉ";
            this.rdoDiaChi.UseVisualStyleBackColor = true;
            // 
            // rdoTheoTen
            // 
            this.rdoTheoTen.AutoSize = true;
            this.rdoTheoTen.Checked = true;
            this.rdoTheoTen.Location = new System.Drawing.Point(57, 11);
            this.rdoTheoTen.Name = "rdoTheoTen";
            this.rdoTheoTen.Size = new System.Drawing.Size(80, 17);
            this.rdoTheoTen.TabIndex = 0;
            this.rdoTheoTen.TabStop = true;
            this.rdoTheoTen.Text = "&1. Theo tên";
            this.rdoTheoTen.UseVisualStyleBackColor = true;
            // 
            // frmDMDiaDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMDiaDanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục địa danh";
            this.Load += new System.EventHandler(this.frmDMDiaDanh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiaDanh)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView trvLoaiDiaDanh;
        private System.Windows.Forms.LinkLabel lnkThemMoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoDiaChi;
        private System.Windows.Forms.RadioButton rdoTheoTen;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.LinkLabel lnkSuaDiaDanh;
        private System.Windows.Forms.LinkLabel lnkXoaDiaDanh;
        private Janus.Windows.GridEX.GridEX gridDiaDanh;
        private System.Windows.Forms.LinkLabel lnkThemDiaDanh;
    }
}