namespace Taxi.GUI
{
    partial class frmDinhNghiVietTatDuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDinhNghiVietTatDuong));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel3 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel4 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.gridVietTatTenDuong = new Janus.Windows.GridEX.GridEX();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridVietTatTenDuong)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridVietTatTenDuong
            // 
            this.gridVietTatTenDuong.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridVietTatTenDuong.ColumnAutoResize = true;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridVietTatTenDuong.DesignTimeLayout = gridEXLayout1;
            this.gridVietTatTenDuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVietTatTenDuong.DynamicFiltering = true;
            this.gridVietTatTenDuong.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridVietTatTenDuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridVietTatTenDuong.GroupByBoxVisible = false;
            this.gridVietTatTenDuong.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridVietTatTenDuong.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridVietTatTenDuong.Location = new System.Drawing.Point(0, 0);
            this.gridVietTatTenDuong.Name = "gridVietTatTenDuong";
            this.gridVietTatTenDuong.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridVietTatTenDuong.SaveSettings = false;
            this.gridVietTatTenDuong.Size = new System.Drawing.Size(762, 460);
            this.gridVietTatTenDuong.TabIndex = 17;
            this.gridVietTatTenDuong.FilterApplied += new System.EventHandler(this.gridVietTatTenDuong_FilterApplied);
            this.gridVietTatTenDuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridBaoCaoBieuMau1_KeyDown);
            this.gridVietTatTenDuong.DoubleClick += new System.EventHandler(this.gridBaoCaoBieuMau1_DoubleClick);
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 460);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel1.Image")));
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel1.Text = "Thêm mới : [Ctrl + N]";
            uiStatusBarPanel1.Width = 151;
            uiStatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel2.Image")));
            uiStatusBarPanel2.Key = "";
            uiStatusBarPanel2.ProgressBarValue = 0;
            uiStatusBarPanel2.Text = "Sửa : Bấm Enter hoặc kích đúp chuột lên dòng";
            uiStatusBarPanel2.Width = 256;
            uiStatusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            uiStatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel3.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel3.Image")));
            uiStatusBarPanel3.Key = "";
            uiStatusBarPanel3.ProgressBarValue = 0;
            uiStatusBarPanel3.Text = "Xóa : Bấm nút Delete";
            uiStatusBarPanel3.Width = 151;
            uiStatusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel4.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel4.Image")));
            uiStatusBarPanel4.Key = "";
            uiStatusBarPanel4.ProgressBarValue = 0;
            uiStatusBarPanel4.Text = "Tìm kiếm : Nhập dòng đầu tiên";
            uiStatusBarPanel4.Width = 177;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2,
            uiStatusBarPanel3,
            uiStatusBarPanel4});
            this.uiStatusBar1.Size = new System.Drawing.Size(762, 23);
            this.uiStatusBar1.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridVietTatTenDuong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 460);
            this.panel1.TabIndex = 20;
            // 
            // frmDinhNghiVietTatDuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 483);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uiStatusBar1);
            this.Icon = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Taxi;
            this.Name = "frmDinhNghiVietTatDuong";
            this.Text = "Định nghĩa viết tắt tên đường";
            this.Load += new System.EventHandler(this.frmDinhNghiVietTatDuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridVietTatTenDuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX gridVietTatTenDuong;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private System.Windows.Forms.Panel panel1;
    }
}