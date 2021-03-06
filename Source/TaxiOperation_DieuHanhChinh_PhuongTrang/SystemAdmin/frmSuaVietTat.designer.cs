namespace Taxi.GUI
{
    partial class frmSuaVietTat
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.txtVietTat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameVN = new System.Windows.Forms.TextBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkCoToaDo = new System.Windows.Forms.CheckBox();
            this.trackBarMap = new System.Windows.Forms.TrackBar();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tên đường";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.disk;
            this.btnThemMoi.Location = new System.Drawing.Point(782, 6);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(78, 30);
            this.btnThemMoi.TabIndex = 4;
            this.btnThemMoi.Text = "Lưu";
            this.btnThemMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // txtVietTat
            // 
            this.txtVietTat.Location = new System.Drawing.Point(535, 12);
            this.txtVietTat.MaxLength = 50;
            this.txtVietTat.Name = "txtVietTat";
            this.txtVietTat.Size = new System.Drawing.Size(154, 20);
            this.txtVietTat.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Viết tắt";
            // 
            // txtNameVN
            // 
            this.txtNameVN.Location = new System.Drawing.Point(70, 12);
            this.txtNameVN.MaxLength = 200;
            this.txtNameVN.Name = "txtNameVN";
            this.txtNameVN.Size = new System.Drawing.Size(381, 20);
            this.txtNameVN.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.chkCoToaDo);
            this.pnlTop.Controls.Add(this.txtNameVN);
            this.pnlTop.Controls.Add(this.label5);
            this.pnlTop.Controls.Add(this.txtVietTat);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.btnThemMoi);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(872, 42);
            this.pnlTop.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(454, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkCoToaDo
            // 
            this.chkCoToaDo.AutoSize = true;
            this.chkCoToaDo.Location = new System.Drawing.Point(701, 14);
            this.chkCoToaDo.Name = "chkCoToaDo";
            this.chkCoToaDo.Size = new System.Drawing.Size(73, 17);
            this.chkCoToaDo.TabIndex = 3;
            this.chkCoToaDo.Text = "Có tọa độ";
            this.chkCoToaDo.UseVisualStyleBackColor = true;
            // 
            // trackBarMap
            // 
            this.trackBarMap.Location = new System.Drawing.Point(8, 19);
            this.trackBarMap.Name = "trackBarMap";
            this.trackBarMap.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMap.Size = new System.Drawing.Size(45, 354);
            this.trackBarMap.TabIndex = 8;
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
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(866, 360);
            this.MainMap.TabIndex = 9;
            this.MainMap.Zoom = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBarMap);
            this.groupBox1.Controls.Add(this.MainMap);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 379);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vị trí tọa độ";
            // 
            // frmSuaVietTat
            // 
            this.AcceptButton = this.btnThemMoi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 421);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlTop);
            this.Icon = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Taxi;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuaVietTat";
            this.Text = "Cập nhật viết tắt tên đường";
            this.Load += new System.EventHandler(this.frmSuaVietTat_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.TextBox txtVietTat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameVN;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TrackBar trackBarMap;
        private Taxi.Controls.ExtendedGMapControl MainMap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCoToaDo;
        private System.Windows.Forms.Button btnSearch;
    }
}