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
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel11 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHienThiBanDo));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel12 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel13 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel14 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel15 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.pnlBanDo = new Janus.Windows.EditControls.UIGroupBox();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.trackBarMap = new System.Windows.Forms.TrackBar();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLenhDTV = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblKenh = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoDT = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDCDon = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTimXe = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBanDo)).BeginInit();
            this.pnlBanDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBanDo
            // 
            this.pnlBanDo.Controls.Add(this.panel1);
            this.pnlBanDo.Controls.Add(this.uiStatusBar1);
            this.pnlBanDo.Controls.Add(this.trackBarMap);
            this.pnlBanDo.Controls.Add(this.MainMap);
            this.pnlBanDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBanDo.Location = new System.Drawing.Point(0, 0);
            this.pnlBanDo.Name = "pnlBanDo";
            this.pnlBanDo.Size = new System.Drawing.Size(784, 381);
            this.pnlBanDo.TabIndex = 3;
            this.pnlBanDo.Text = "Bản đồ";
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.ImageSize = new System.Drawing.Size(20, 22);
            this.uiStatusBar1.Location = new System.Drawing.Point(3, 348);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel11.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel11.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel11.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel11.Image")));
            uiStatusBarPanel11.Key = "";
            uiStatusBarPanel11.ProgressBarValue = 0;
            uiStatusBarPanel11.Text = "Địa điểm đón khách";
            uiStatusBarPanel11.Width = 156;
            uiStatusBarPanel12.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel12.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel12.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel12.Image")));
            uiStatusBarPanel12.Key = "";
            uiStatusBarPanel12.ProgressBarValue = 0;
            uiStatusBarPanel12.Text = "Xe đề cử (Đang nổ máy)";
            uiStatusBarPanel12.Width = 152;
            uiStatusBarPanel13.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel13.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel13.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel13.Image")));
            uiStatusBarPanel13.Key = "";
            uiStatusBarPanel13.ProgressBarValue = 0;
            uiStatusBarPanel13.Text = "Xe đề cử (Tắt máy)";
            uiStatusBarPanel13.Width = 152;
            uiStatusBarPanel14.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel14.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel14.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel14.Image")));
            uiStatusBarPanel14.Key = "";
            uiStatusBarPanel14.ProgressBarValue = 0;
            uiStatusBarPanel14.Text = "Xe nhận (Đang nổ máy)";
            uiStatusBarPanel14.Width = 152;
            uiStatusBarPanel15.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel15.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel15.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel15.Image")));
            uiStatusBarPanel15.Key = "";
            uiStatusBarPanel15.ProgressBarValue = 0;
            uiStatusBarPanel15.Text = "Xe nhận (Tắt máy)";
            uiStatusBarPanel15.Width = 152;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel11,
            uiStatusBarPanel12,
            uiStatusBarPanel13,
            uiStatusBarPanel14,
            uiStatusBarPanel15});
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
            this.MainMap.Size = new System.Drawing.Size(778, 362);
            this.MainMap.TabIndex = 7;
            this.MainMap.Zoom = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.splitContainer1.Panel1.Controls.Add(this.lblThoiGian);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.lblGhiChu);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.lblLenhDTV);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.lblKenh);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lblSoDT);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lblDCDon);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlBanDo);
            this.splitContainer1.Size = new System.Drawing.Size(784, 462);
            this.splitContainer1.SplitterDistance = 77;
            this.splitContainer1.TabIndex = 4;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGian.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblThoiGian.Location = new System.Drawing.Point(85, 9);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(18, 13);
            this.lblThoiGian.TabIndex = 11;
            this.lblThoiGian.Text = "tg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Thời gian : ";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblGhiChu.Location = new System.Drawing.Point(76, 49);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(52, 13);
            this.lblGhiChu.TabIndex = 9;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(12, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ghi chú : ";
            // 
            // lblLenhDTV
            // 
            this.lblLenhDTV.AutoSize = true;
            this.lblLenhDTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLenhDTV.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLenhDTV.Location = new System.Drawing.Point(573, 9);
            this.lblLenhDTV.Name = "lblLenhDTV";
            this.lblLenhDTV.Size = new System.Drawing.Size(57, 13);
            this.lblLenhDTV.TabIndex = 7;
            this.lblLenhDTV.Text = "Lệnh dtv";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(496, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Lệnh ĐTV : ";
            // 
            // lblKenh
            // 
            this.lblKenh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKenh.AutoSize = true;
            this.lblKenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKenh.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblKenh.Location = new System.Drawing.Point(445, 9);
            this.lblKenh.Name = "lblKenh";
            this.lblKenh.Size = new System.Drawing.Size(36, 13);
            this.lblKenh.TabIndex = 5;
            this.lblKenh.Text = "Kênh";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(409, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kênh";
            // 
            // lblSoDT
            // 
            this.lblSoDT.AutoSize = true;
            this.lblSoDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSoDT.Location = new System.Drawing.Point(275, 9);
            this.lblSoDT.Name = "lblSoDT";
            this.lblSoDT.Size = new System.Drawing.Size(38, 13);
            this.lblSoDT.TabIndex = 3;
            this.lblSoDT.Text = "Số đt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(229, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số dt: ";
            // 
            // lblDCDon
            // 
            this.lblDCDon.AutoSize = true;
            this.lblDCDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCDon.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDCDon.Location = new System.Drawing.Point(97, 29);
            this.lblDCDon.Name = "lblDCDon";
            this.lblDCDon.Size = new System.Drawing.Size(73, 13);
            this.lblDCDon.TabIndex = 1;
            this.lblDCDon.Text = "Địa chỉ đón";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ đón : ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtTimXe);
            this.panel1.Location = new System.Drawing.Point(647, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 27);
            this.panel1.TabIndex = 15;
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
            // frmHienThiBanDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.splitContainer1);
            this.Icon = global::TaxiOperation_MoiKhach.Properties.Resources.Taxi;
            this.Name = "frmHienThiBanDo";
            this.Text = "Bản đồ GPS";
            this.Load += new System.EventHandler(this.frmHienThiBanDo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBanDo)).EndInit();
            this.pnlBanDo.ResumeLayout(false);
            this.pnlBanDo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox pnlBanDo;
        private System.Windows.Forms.TrackBar trackBarMap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDCDon;
        private System.Windows.Forms.Label lblSoDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKenh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLenhDTV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label label7;
        private Taxi.Controls.ExtendedGMapControl MainMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTimXe;
    }
}