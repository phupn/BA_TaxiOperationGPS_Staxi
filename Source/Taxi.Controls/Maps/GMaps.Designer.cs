namespace Taxi.Controls.Maps
{
    partial class GMaps
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTimXe = new System.Windows.Forms.TextBox();
            this.pnSearchDiaChi = new System.Windows.Forms.Panel();
            this.txtSearchDiaChi = new System.Windows.Forms.TextBox();
            this.ptbDiaChi = new System.Windows.Forms.PictureBox();
            this.ztbMap = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.grbSearch = new System.Windows.Forms.GroupBox();
            this.txtTinhThanh = new System.Windows.Forms.TextBox();
            this.ccbeVDH = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.timerVDH = new System.Windows.Forms.Timer(this.components);
            this.cboMapType = new System.Windows.Forms.ComboBox();
            this.hienTrangXe1 = new Taxi.Controls.Maps.HienTrangXe();
            this.pnSearchDiaChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDiaChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMap.Properties)).BeginInit();
            this.grbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccbeVDH.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 0);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1083, 579);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.gmap.OnMapDrag += new GMap.NET.MapDrag(this.gmap_OnMapDrag);
            this.gmap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gmap_OnMapZoomChanged);
            this.gmap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gmap_Scroll);
            this.gmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseClick);
            this.gmap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseDoubleClick);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Location = new System.Drawing.Point(241, 19);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(190, 20);
            this.txtDiaChi.TabIndex = 2;
            this.txtDiaChi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDiaChi_MouseClick);
            this.txtDiaChi.TextChanged += new System.EventHandler(this.txtDiaChi_TextChanged);
            this.txtDiaChi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaChi_KeyDown);
            // 
            // txtTimXe
            // 
            this.txtTimXe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimXe.Location = new System.Drawing.Point(437, 19);
            this.txtTimXe.Name = "txtTimXe";
            this.txtTimXe.Size = new System.Drawing.Size(190, 20);
            this.txtTimXe.TabIndex = 3;
            this.txtTimXe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTimXe_MouseClick);
            this.txtTimXe.TextChanged += new System.EventHandler(this.txtTimXe_TextChanged);
            this.txtTimXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimXe_KeyDown);
            // 
            // pnSearchDiaChi
            // 
            this.pnSearchDiaChi.BackColor = System.Drawing.Color.White;
            this.pnSearchDiaChi.Controls.Add(this.txtSearchDiaChi);
            this.pnSearchDiaChi.Controls.Add(this.ptbDiaChi);
            this.pnSearchDiaChi.Location = new System.Drawing.Point(92, 506);
            this.pnSearchDiaChi.Name = "pnSearchDiaChi";
            this.pnSearchDiaChi.Size = new System.Drawing.Size(222, 60);
            this.pnSearchDiaChi.TabIndex = 5;
            this.pnSearchDiaChi.Visible = false;
            // 
            // txtSearchDiaChi
            // 
            this.txtSearchDiaChi.BackColor = System.Drawing.Color.White;
            this.txtSearchDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchDiaChi.Enabled = false;
            this.txtSearchDiaChi.Location = new System.Drawing.Point(4, 27);
            this.txtSearchDiaChi.Multiline = true;
            this.txtSearchDiaChi.Name = "txtSearchDiaChi";
            this.txtSearchDiaChi.ReadOnly = true;
            this.txtSearchDiaChi.Size = new System.Drawing.Size(215, 30);
            this.txtSearchDiaChi.TabIndex = 1;
            // 
            // ptbDiaChi
            // 
            this.ptbDiaChi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbDiaChi.InitialImage = null;
            this.ptbDiaChi.Location = new System.Drawing.Point(194, 3);
            this.ptbDiaChi.Name = "ptbDiaChi";
            this.ptbDiaChi.Size = new System.Drawing.Size(16, 16);
            this.ptbDiaChi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbDiaChi.TabIndex = 0;
            this.ptbDiaChi.TabStop = false;
            this.ptbDiaChi.Click += new System.EventHandler(this.ptbDiaChi_Click);
            // 
            // ztbMap
            // 
            this.ztbMap.EditValue = 14;
            this.ztbMap.Location = new System.Drawing.Point(3, 3);
            this.ztbMap.Name = "ztbMap";
            this.ztbMap.Properties.Maximum = 18;
            this.ztbMap.Properties.Minimum = 5;
            this.ztbMap.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ztbMap.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbMap.Size = new System.Drawing.Size(23, 182);
            this.ztbMap.TabIndex = 7;
            this.ztbMap.Value = 14;
            this.ztbMap.EditValueChanged += new System.EventHandler(this.ztbMap_EditValueChanged);
            // 
            // grbSearch
            // 
            this.grbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSearch.Controls.Add(this.txtTinhThanh);
            this.grbSearch.Controls.Add(this.ccbeVDH);
            this.grbSearch.Controls.Add(this.txtDiaChi);
            this.grbSearch.Controls.Add(this.txtTimXe);
            this.grbSearch.Location = new System.Drawing.Point(418, -1);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(648, 51);
            this.grbSearch.TabIndex = 0;
            this.grbSearch.TabStop = false;
            this.grbSearch.Text = "Tìm kiếm";
            // 
            // txtTinhThanh
            // 
            this.txtTinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTinhThanh.Location = new System.Drawing.Point(143, 19);
            this.txtTinhThanh.Name = "txtTinhThanh";
            this.txtTinhThanh.Size = new System.Drawing.Size(92, 21);
            this.txtTinhThanh.TabIndex = 1;
            // 
            // ccbeVDH
            // 
            this.ccbeVDH.EditValue = "";
            this.ccbeVDH.Location = new System.Drawing.Point(7, 20);
            this.ccbeVDH.Name = "ccbeVDH";
            this.ccbeVDH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccbeVDH.Properties.NullText = "Chọn vùng";
            this.ccbeVDH.Size = new System.Drawing.Size(130, 20);
            this.ccbeVDH.TabIndex = 0;
            this.ccbeVDH.EditValueChanged += new System.EventHandler(this.ccbeVDH_EditValueChanged);
            // 
            // timerVDH
            // 
            this.timerVDH.Interval = 5000;
            this.timerVDH.Tick += new System.EventHandler(this.timerVDH_Tick);
            // 
            // cboMapType
            // 
            this.cboMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMapType.FormattingEnabled = true;
            this.cboMapType.Location = new System.Drawing.Point(33, 4);
            this.cboMapType.Name = "cboMapType";
            this.cboMapType.Size = new System.Drawing.Size(121, 21);
            this.cboMapType.TabIndex = 9;
            this.cboMapType.SelectedIndexChanged += new System.EventHandler(this.cboMapType_SelectedIndexChanged);
            // 
            // hienTrangXe1
            // 
            this.hienTrangXe1.Location = new System.Drawing.Point(19, 84);
            this.hienTrangXe1.Name = "hienTrangXe1";
            this.hienTrangXe1.Size = new System.Drawing.Size(437, 330);
            this.hienTrangXe1.TabIndex = 6;
            // 
            // GMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbSearch);
            this.Controls.Add(this.cboMapType);
            this.Controls.Add(this.ztbMap);
            this.Controls.Add(this.hienTrangXe1);
            this.Controls.Add(this.pnSearchDiaChi);
            this.Controls.Add(this.gmap);
            this.Name = "GMaps";
            this.Size = new System.Drawing.Size(1083, 579);
            this.VisibleChanged += new System.EventHandler(this.GMaps_VisibleChanged);
            this.Resize += new System.EventHandler(this.GMaps_Resize);
            this.pnSearchDiaChi.ResumeLayout(false);
            this.pnSearchDiaChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDiaChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMap)).EndInit();
            this.grbSearch.ResumeLayout(false);
            this.grbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccbeVDH.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTimXe;
        private System.Windows.Forms.Panel pnSearchDiaChi;
        private System.Windows.Forms.PictureBox ptbDiaChi;
        private System.Windows.Forms.TextBox txtSearchDiaChi;
        private HienTrangXe hienTrangXe1;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbMap;
        private System.Windows.Forms.GroupBox grbSearch;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ccbeVDH;
        private System.Windows.Forms.Timer timerVDH;
        private System.Windows.Forms.ComboBox cboMapType;
        private System.Windows.Forms.TextBox txtTinhThanh;

    }
}
