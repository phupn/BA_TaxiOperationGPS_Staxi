namespace Taxi.GUI
{
    partial class frmDMLoaiXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMLoaiXe));
            this.gridLoaiXe = new Janus.Windows.GridEX.GridEX();
            this.lnkThemMoi = new System.Windows.Forms.LinkLabel();
            this.lnkSua = new System.Windows.Forms.LinkLabel();
            this.lnkXoa = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoaiXe)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLoaiXe
            // 
            this.gridLoaiXe.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridLoaiXe.DesignTimeLayout = gridEXLayout1;
            this.gridLoaiXe.GroupByBoxVisible = false;
            this.gridLoaiXe.Location = new System.Drawing.Point(2, 12);
            this.gridLoaiXe.Name = "gridLoaiXe";
            this.gridLoaiXe.SaveSettings = false;
            this.gridLoaiXe.Size = new System.Drawing.Size(356, 512);
            this.gridLoaiXe.TabIndex = 0;
            this.gridLoaiXe.DoubleClick += new System.EventHandler(this.gridLoaiXe_DoubleClick);
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
            // frmDMLoaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 553);
            this.Controls.Add(this.lnkXoa);
            this.Controls.Add(this.lnkSua);
            this.Controls.Add(this.lnkThemMoi);
            this.Controls.Add(this.gridLoaiXe);
            this.Icon = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Taxi;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDMLoaiXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Địa danh - Km";
            ((System.ComponentModel.ISupportInitialize)(this.gridLoaiXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX gridLoaiXe;
        private System.Windows.Forms.LinkLabel lnkThemMoi;
        private System.Windows.Forms.LinkLabel lnkSua;
        private System.Windows.Forms.LinkLabel lnkXoa;
    }
}