namespace Taxi.GUI
{
    partial class frmHienThiBanDo
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
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel6 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHienThiBanDo));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel7 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel8 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel9 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel10 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.pnlBanDo = new Janus.Windows.EditControls.UIGroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimDuong = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTimXe = new System.Windows.Forms.TextBox();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.trackBarMap = new System.Windows.Forms.TrackBar();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBanDo)).BeginInit();
            this.pnlBanDo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBanDo
            // 
            this.pnlBanDo.Controls.Add(this.panel2);
            this.pnlBanDo.Controls.Add(this.panel1);
            this.pnlBanDo.Controls.Add(this.uiStatusBar1);
            this.pnlBanDo.Controls.Add(this.trackBarMap);
            this.pnlBanDo.Controls.Add(this.MainMap);
            this.pnlBanDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBanDo.Location = new System.Drawing.Point(0, 0);
            this.pnlBanDo.Name = "pnlBanDo";
            this.pnlBanDo.Size = new System.Drawing.Size(784, 462);
            this.pnlBanDo.TabIndex = 3;
            this.pnlBanDo.Text = "Bản đồ";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Brown;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtTimDuong);
            this.panel2.Location = new System.Drawing.Point(373, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 27);
            this.panel2.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tìm &Đường";
            // 
            // txtTimDuong
            // 
            this.txtTimDuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimDuong.Location = new System.Drawing.Point(77, 3);
            this.txtTimDuong.Name = "txtTimDuong";
            this.txtTimDuong.Size = new System.Drawing.Size(182, 20);
            this.txtTimDuong.TabIndex = 0;
            this.txtTimDuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimDuong_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtTimXe);
            this.panel1.Location = new System.Drawing.Point(641, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 27);
            this.panel1.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(3, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Tìm &Xe";
            // 
            // txtTimXe
            // 
            this.txtTimXe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimXe.Location = new System.Drawing.Point(55, 3);
            this.txtTimXe.Name = "txtTimXe";
            this.txtTimXe.Size = new System.Drawing.Size(73, 20);
            this.txtTimXe.TabIndex = 0;
            this.txtTimXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimXe_KeyDown);
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.ImageSize = new System.Drawing.Size(20, 22);
            this.uiStatusBar1.Location = new System.Drawing.Point(3, 429);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel6.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel6.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel6.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel6.Image")));
            uiStatusBarPanel6.Key = "";
            uiStatusBarPanel6.ProgressBarValue = 0;
            uiStatusBarPanel6.Text = "Địa điểm đón khách";
            uiStatusBarPanel6.Width = 156;
            uiStatusBarPanel7.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel7.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel7.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel7.Image")));
            uiStatusBarPanel7.Key = "";
            uiStatusBarPanel7.ProgressBarValue = 0;
            uiStatusBarPanel7.Text = "Xe đề cử (Đang nổ máy)";
            uiStatusBarPanel7.Width = 152;
            uiStatusBarPanel8.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel8.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel8.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel8.Image")));
            uiStatusBarPanel8.Key = "";
            uiStatusBarPanel8.ProgressBarValue = 0;
            uiStatusBarPanel8.Text = "Xe đề cử (Tắt máy)";
            uiStatusBarPanel8.Width = 152;
            uiStatusBarPanel9.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel9.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel9.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel9.Image")));
            uiStatusBarPanel9.Key = "";
            uiStatusBarPanel9.ProgressBarValue = 0;
            uiStatusBarPanel9.Text = "Xe nhận (Đang nổ máy)";
            uiStatusBarPanel9.Width = 152;
            uiStatusBarPanel10.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel10.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel10.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel10.Image")));
            uiStatusBarPanel10.Key = "";
            uiStatusBarPanel10.ProgressBarValue = 0;
            uiStatusBarPanel10.Text = "Xe nhận (Tắt máy)";
            uiStatusBarPanel10.Width = 152;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel6,
            uiStatusBarPanel7,
            uiStatusBarPanel8,
            uiStatusBarPanel9,
            uiStatusBarPanel10});
            this.uiStatusBar1.Size = new System.Drawing.Size(778, 30);
            this.uiStatusBar1.TabIndex = 6;
            // 
            // trackBarMap
            // 
            this.trackBarMap.Location = new System.Drawing.Point(6, 19);
            this.trackBarMap.Maximum = 22;
            this.trackBarMap.Minimum = 1;
            this.trackBarMap.Name = "trackBarMap";
            this.trackBarMap.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMap.Size = new System.Drawing.Size(45, 289);
            this.trackBarMap.TabIndex = 4;
            this.trackBarMap.Value = 1;
            this.trackBarMap.ValueChanged += new System.EventHandler(this.trackBarMap_ValueChanged);
            // 
            // MainMap
            // 
            this.MainMap.AllowDrawPolygon = false;
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(3, 16);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(778, 443);
            this.MainMap.TabIndex = 15;
            this.MainMap.Zoom = 0;
            // 
            // frmHienThiBanDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.pnlBanDo);
            this.Icon = global::TaxiOperation_TongDai.Properties.Resources.Taxi;
            this.Name = "frmHienThiBanDo";
            this.Text = "Bản đồ GPS";
            this.Load += new System.EventHandler(this.frmHienThiBanDo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBanDo)).EndInit();
            this.pnlBanDo.ResumeLayout(false);
            this.pnlBanDo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox pnlBanDo;
        private System.Windows.Forms.TrackBar trackBarMap;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTimXe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimDuong;
        private Taxi.Controls.ExtendedGMapControl MainMap;
    }
}