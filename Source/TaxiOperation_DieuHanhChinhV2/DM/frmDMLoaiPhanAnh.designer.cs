namespace TaxiOperation_DieuHanhChinh.DM
{
    partial class frmDMLoaiPhanAnh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMLoaiPhanAnh));
            this.grdLoaiPhanAnh = new Janus.Windows.GridEX.GridEX();
            this.hlkThem = new System.Windows.Forms.LinkLabel();
            this.hlkSua = new System.Windows.Forms.LinkLabel();
            this.hlkXoa = new System.Windows.Forms.LinkLabel();
            this.btnLen = new System.Windows.Forms.Button();
            this.btnXuong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiPhanAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLoaiPhanAnh
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdLoaiPhanAnh.DesignTimeLayout = gridEXLayout1;
            this.grdLoaiPhanAnh.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdLoaiPhanAnh.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.grdLoaiPhanAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLoaiPhanAnh.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdLoaiPhanAnh.GroupByBoxVisible = false;
            this.grdLoaiPhanAnh.Location = new System.Drawing.Point(0, 0);
            this.grdLoaiPhanAnh.Name = "grdLoaiPhanAnh";
            this.grdLoaiPhanAnh.SaveSettings = false;
            this.grdLoaiPhanAnh.Size = new System.Drawing.Size(447, 265);
            this.grdLoaiPhanAnh.TabIndex = 0;
            this.grdLoaiPhanAnh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLoaiPhanAnh_KeyDown);
            this.grdLoaiPhanAnh.DoubleClick += new System.EventHandler(this.grdLoaiPhanAnh_DoubleClick);
            // 
            // hlkThem
            // 
            this.hlkThem.AutoSize = true;
            this.hlkThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hlkThem.Location = new System.Drawing.Point(219, 279);
            this.hlkThem.Name = "hlkThem";
            this.hlkThem.Size = new System.Drawing.Size(71, 15);
            this.hlkThem.TabIndex = 1;
            this.hlkThem.TabStop = true;
            this.hlkThem.Text = "Thêm mới";
            this.hlkThem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.hlkThem_LinkClicked);
            // 
            // hlkSua
            // 
            this.hlkSua.AutoSize = true;
            this.hlkSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hlkSua.Location = new System.Drawing.Point(317, 279);
            this.hlkSua.Name = "hlkSua";
            this.hlkSua.Size = new System.Drawing.Size(32, 15);
            this.hlkSua.TabIndex = 2;
            this.hlkSua.TabStop = true;
            this.hlkSua.Text = "Sửa";
            this.hlkSua.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.hlkSua_LinkClicked);
            // 
            // hlkXoa
            // 
            this.hlkXoa.AutoSize = true;
            this.hlkXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hlkXoa.Location = new System.Drawing.Point(378, 279);
            this.hlkXoa.Name = "hlkXoa";
            this.hlkXoa.Size = new System.Drawing.Size(32, 15);
            this.hlkXoa.TabIndex = 3;
            this.hlkXoa.TabStop = true;
            this.hlkXoa.Text = "Xóa";
            this.hlkXoa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.hlkXoa_LinkClicked);
            // 
            // btnLen
            // 
            this.btnLen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLen.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.uparrow;
            this.btnLen.Location = new System.Drawing.Point(335, 12);
            this.btnLen.Name = "btnLen";
            this.btnLen.Size = new System.Drawing.Size(39, 27);
            this.btnLen.TabIndex = 4;
            this.btnLen.UseVisualStyleBackColor = true;
            this.btnLen.Click += new System.EventHandler(this.btnLen_Click);
            this.btnLen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnLen_KeyDown);
            // 
            // btnXuong
            // 
            this.btnXuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuong.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.downarrow;
            this.btnXuong.Location = new System.Drawing.Point(335, 58);
            this.btnXuong.Name = "btnXuong";
            this.btnXuong.Size = new System.Drawing.Size(39, 27);
            this.btnXuong.TabIndex = 5;
            this.btnXuong.UseVisualStyleBackColor = true;
            this.btnXuong.Click += new System.EventHandler(this.btnXuong_Click);
            this.btnXuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnXuong_KeyDown);
            // 
            // frmDMLoaiPhanAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 303);
            this.Controls.Add(this.btnXuong);
            this.Controls.Add(this.btnLen);
            this.Controls.Add(this.hlkXoa);
            this.Controls.Add(this.hlkSua);
            this.Controls.Add(this.hlkThem);
            this.Controls.Add(this.grdLoaiPhanAnh);
            this.Name = "frmDMLoaiPhanAnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DMLoaiPhanAnh";
            this.Load += new System.EventHandler(this.frmDMLoaiPhanAnh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiPhanAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdLoaiPhanAnh;
        private System.Windows.Forms.LinkLabel hlkThem;
        private System.Windows.Forms.LinkLabel hlkSua;
        private System.Windows.Forms.LinkLabel hlkXoa;
        private System.Windows.Forms.Button btnLen;
        private System.Windows.Forms.Button btnXuong;
    }
}