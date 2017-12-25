namespace Taxi.GUI
{
    partial class frmDMDiaDanhKm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMDiaDanhKm));
            this.gridDiaDanhKm = new Janus.Windows.GridEX.GridEX();
            this.lnkThemMoi = new System.Windows.Forms.LinkLabel();
            this.lnkSua = new System.Windows.Forms.LinkLabel();
            this.lnkXoa = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiaDanhKm)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDiaDanhKm
            // 
            this.gridDiaDanhKm.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridDiaDanhKm.DesignTimeLayout = gridEXLayout1;
            this.gridDiaDanhKm.GroupByBoxVisible = false;
            this.gridDiaDanhKm.Location = new System.Drawing.Point(12, 37);
            this.gridDiaDanhKm.Name = "gridDiaDanhKm";
            this.gridDiaDanhKm.SaveSettings = false;
            this.gridDiaDanhKm.Size = new System.Drawing.Size(393, 487);
            this.gridDiaDanhKm.TabIndex = 0;
            this.gridDiaDanhKm.DoubleClick += new System.EventHandler(this.gridDiaDanhKm_DoubleClick);
            // 
            // lnkThemMoi
            // 
            this.lnkThemMoi.AutoSize = true;
            this.lnkThemMoi.Location = new System.Drawing.Point(239, 532);
            this.lnkThemMoi.Name = "lnkThemMoi";
            this.lnkThemMoi.Size = new System.Drawing.Size(53, 13);
            this.lnkThemMoi.TabIndex = 1;
            this.lnkThemMoi.TabStop = true;
            this.lnkThemMoi.Text = "Thêm mới";
            this.lnkThemMoi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkThemMoi_LinkClicked);
            // 
            // lnkSua
            // 
            this.lnkSua.AutoSize = true;
            this.lnkSua.Location = new System.Drawing.Point(299, 532);
            this.lnkSua.Name = "lnkSua";
            this.lnkSua.Size = new System.Drawing.Size(26, 13);
            this.lnkSua.TabIndex = 2;
            this.lnkSua.TabStop = true;
            this.lnkSua.Text = "Sửa";
            this.lnkSua.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSua_LinkClicked);
            // 
            // lnkXoa
            // 
            this.lnkXoa.AutoSize = true;
            this.lnkXoa.Location = new System.Drawing.Point(332, 531);
            this.lnkXoa.Name = "lnkXoa";
            this.lnkXoa.Size = new System.Drawing.Size(26, 13);
            this.lnkXoa.TabIndex = 3;
            this.lnkXoa.TabStop = true;
            this.lnkXoa.Text = "Xóa";
            this.lnkXoa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkXoa_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Danh sách địa danh - Km";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(330, 3);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tìm  kiếm Tên địa danh";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(131, 3);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(193, 20);
            this.txtTimKiem.TabIndex = 7;
            // 
            // frmDMDiaDanhKm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 553);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkXoa);
            this.Controls.Add(this.lnkSua);
            this.Controls.Add(this.lnkThemMoi);
            this.Controls.Add(this.gridDiaDanhKm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMDiaDanhKm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Địa danh - Km";
            ((System.ComponentModel.ISupportInitialize)(this.gridDiaDanhKm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX gridDiaDanhKm;
        private System.Windows.Forms.LinkLabel lnkThemMoi;
        private System.Windows.Forms.LinkLabel lnkSua;
        private System.Windows.Forms.LinkLabel lnkXoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}