namespace Taxi.GUI
{
    partial class QuanLyVung_GPS
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyVung_GPS));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridVungGPS = new Janus.Windows.GridEX.GridEX();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.numBKTimXe = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.numKenhGop = new System.Windows.Forms.NumericUpDown();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numKenhVung = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenVung = new System.Windows.Forms.TextBox();
            this.pnlBanDo = new System.Windows.Forms.Panel();
            this.CbMapType = new System.Windows.Forms.ComboBox();
            this.trackBarMap = new System.Windows.Forms.TrackBar();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl(this.components);
            this.pnlButton = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVungGPS)).BeginInit();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBKTimXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKenhGop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKenhVung)).BeginInit();
            this.pnlBanDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlGrid);
            this.splitContainer1.Panel1.Controls.Add(this.pnlForm);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlBanDo);
            this.splitContainer1.Panel2.Controls.Add(this.pnlButton);
            this.splitContainer1.Size = new System.Drawing.Size(784, 562);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridVungGPS);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 148);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(249, 414);
            this.pnlGrid.TabIndex = 1;
            // 
            // gridVungGPS
            // 
            this.gridVungGPS.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridVungGPS.DesignTimeLayout = gridEXLayout1;
            this.gridVungGPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVungGPS.GroupByBoxVisible = false;
            this.gridVungGPS.Location = new System.Drawing.Point(0, 0);
            this.gridVungGPS.Name = "gridVungGPS";
            this.gridVungGPS.SaveSettings = false;
            this.gridVungGPS.Size = new System.Drawing.Size(249, 414);
            this.gridVungGPS.TabIndex = 0;
            this.gridVungGPS.SelectionChanged += new System.EventHandler(this.gridVungGPS_SelectionChanged);
            this.gridVungGPS.Click += new System.EventHandler(this.gridVungGPS_Click);
            this.gridVungGPS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridVungGPS_MouseClick);
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.label5);
            this.pnlForm.Controls.Add(this.numBKTimXe);
            this.pnlForm.Controls.Add(this.label4);
            this.pnlForm.Controls.Add(this.btnNew);
            this.pnlForm.Controls.Add(this.numKenhGop);
            this.pnlForm.Controls.Add(this.btnXoa);
            this.pnlForm.Controls.Add(this.btnInsert);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Controls.Add(this.numKenhVung);
            this.pnlForm.Controls.Add(this.label2);
            this.pnlForm.Controls.Add(this.label1);
            this.pnlForm.Controls.Add(this.txtTenVung);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(249, 148);
            this.pnlForm.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "(m)";
            // 
            // numBKTimXe
            // 
            this.numBKTimXe.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numBKTimXe.Location = new System.Drawing.Point(63, 56);
            this.numBKTimXe.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBKTimXe.Name = "numBKTimXe";
            this.numBKTimXe.Size = new System.Drawing.Size(110, 20);
            this.numBKTimXe.TabIndex = 3;
            this.numBKTimXe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBKTimXe.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "BK tìm xe";
            // 
            // btnNew
            // 
            this.btnNew.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_bottom;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.Location = new System.Drawing.Point(171, 99);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 38);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "Làm mới";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // numKenhGop
            // 
            this.numKenhGop.Location = new System.Drawing.Point(193, 30);
            this.numKenhGop.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numKenhGop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKenhGop.Name = "numKenhGop";
            this.numKenhGop.Size = new System.Drawing.Size(52, 20);
            this.numKenhGop.TabIndex = 2;
            this.numKenhGop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numKenhGop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.cancel1;
            this.btnXoa.Location = new System.Drawing.Point(94, 99);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(60, 38);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.disk;
            this.btnInsert.Location = new System.Drawing.Point(18, 99);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(60, 38);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Lưu";
            this.btnInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kênh gộp";
            // 
            // numKenhVung
            // 
            this.numKenhVung.Location = new System.Drawing.Point(63, 30);
            this.numKenhVung.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numKenhVung.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKenhVung.Name = "numKenhVung";
            this.numKenhVung.Size = new System.Drawing.Size(52, 20);
            this.numKenhVung.TabIndex = 1;
            this.numKenhVung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numKenhVung.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kênh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên";
            // 
            // txtTenVung
            // 
            this.txtTenVung.Location = new System.Drawing.Point(63, 4);
            this.txtTenVung.MaxLength = 500;
            this.txtTenVung.Name = "txtTenVung";
            this.txtTenVung.Size = new System.Drawing.Size(183, 20);
            this.txtTenVung.TabIndex = 0;
            // 
            // pnlBanDo
            // 
            this.pnlBanDo.Controls.Add(this.CbMapType);
            this.pnlBanDo.Controls.Add(this.trackBarMap);
            this.pnlBanDo.Controls.Add(this.MainMap);
            this.pnlBanDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBanDo.Location = new System.Drawing.Point(0, 38);
            this.pnlBanDo.Name = "pnlBanDo";
            this.pnlBanDo.Size = new System.Drawing.Size(531, 524);
            this.pnlBanDo.TabIndex = 1;
            // 
            // CbMapType
            // 
            this.CbMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMapType.FormattingEnabled = true;
            this.CbMapType.Location = new System.Drawing.Point(54, 3);
            this.CbMapType.Name = "CbMapType";
            this.CbMapType.Size = new System.Drawing.Size(121, 21);
            this.CbMapType.TabIndex = 6;
            this.CbMapType.Visible = false;
            this.CbMapType.SelectedIndexChanged += new System.EventHandler(this.CbMapType_SelectedIndexChanged);
            // 
            // trackBarMap
            // 
            this.trackBarMap.Location = new System.Drawing.Point(-2, 3);
            this.trackBarMap.Name = "trackBarMap";
            this.trackBarMap.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMap.Size = new System.Drawing.Size(45, 382);
            this.trackBarMap.TabIndex = 5;
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
            this.MainMap.Location = new System.Drawing.Point(0, 0);
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
            this.MainMap.Size = new System.Drawing.Size(531, 524);
            this.MainMap.TabIndex = 7;
            this.MainMap.Zoom = 0D;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.lblInfo);
            this.pnlButton.Controls.Add(this.lblMsg);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButton.Location = new System.Drawing.Point(0, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(531, 38);
            this.pnlButton.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(293, 5);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(235, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Bấm chuột phải để chọn điểm và tạo vùng GPS";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblMsg.Location = new System.Drawing.Point(7, 11);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(68, 13);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Thong bao";
            this.lblMsg.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // QuanLyVung_GPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuanLyVung_GPS";
            this.Text = "Quản lý vùng - GPS";
            this.Load += new System.EventHandler(this.QuanLyVung_GPS_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVungGPS)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBKTimXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKenhGop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKenhVung)).EndInit();
            this.pnlBanDo.ResumeLayout(false);
            this.pnlBanDo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.pnlButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlBanDo;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnXoa;
        private Janus.Windows.GridEX.GridEX gridVungGPS;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenVung;
        private System.Windows.Forms.NumericUpDown numKenhGop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numKenhVung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox CbMapType;
        private System.Windows.Forms.TrackBar trackBarMap;
        private Taxi.Controls.ExtendedGMapControl MainMap;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.NumericUpDown numBKTimXe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

    }
}