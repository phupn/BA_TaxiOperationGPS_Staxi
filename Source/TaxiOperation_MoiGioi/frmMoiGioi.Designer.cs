namespace TaxiOperation_MoiGioi
{
    partial class frmMoiGioi
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout3 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoiGioi));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridMoiGioi = new Janus.Windows.GridEX.GridEX();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl(this.components);
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtViDo = new System.Windows.Forms.TextBox();
            this.txtKinhDo = new System.Windows.Forms.TextBox();
            this.txtMaMG = new System.Windows.Forms.TextBox();
            this.txtTenMG = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMoiGioi)).BeginInit();
            this.pnlMap.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridMoiGioi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlMap);
            this.splitContainer1.Panel2.Controls.Add(this.pnlInfo);
            this.splitContainer1.Size = new System.Drawing.Size(800, 453);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridMoiGioi
            // 
            gridEXLayout3.LayoutString = resources.GetString("gridEXLayout3.LayoutString");
            this.gridMoiGioi.DesignTimeLayout = gridEXLayout3;
            this.gridMoiGioi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMoiGioi.DynamicFiltering = true;
            this.gridMoiGioi.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridMoiGioi.GroupByBoxVisible = false;
            this.gridMoiGioi.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.gridMoiGioi.Location = new System.Drawing.Point(0, 0);
            this.gridMoiGioi.Name = "gridMoiGioi";
            this.gridMoiGioi.SaveSettings = false;
            this.gridMoiGioi.Size = new System.Drawing.Size(208, 453);
            this.gridMoiGioi.TabIndex = 0;
            this.gridMoiGioi.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridMoiGioi.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gridMoiGioi.Click += new System.EventHandler(this.gridMoiGioi_Click);
            this.gridMoiGioi.SelectionChanged += new System.EventHandler(this.gridMoiGioi_SelectionChanged);
            // 
            // pnlMap
            // 
            this.pnlMap.Controls.Add(this.MainMap);
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(0, 82);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(588, 371);
            this.pnlMap.TabIndex = 1;
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
            this.MainMap.Size = new System.Drawing.Size(588, 371);
            this.MainMap.TabIndex = 9;
            this.MainMap.Zoom = 0;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.btnSearch);
            this.pnlInfo.Controls.Add(this.txtDiaChi);
            this.pnlInfo.Controls.Add(this.txtViDo);
            this.pnlInfo.Controls.Add(this.txtKinhDo);
            this.pnlInfo.Controls.Add(this.txtMaMG);
            this.pnlInfo.Controls.Add(this.txtTenMG);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.label3);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(588, 82);
            this.pnlInfo.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::TaxiOperation_MoiGioi.Properties.Resources.search1;
            this.btnSearch.Location = new System.Drawing.Point(552, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 31);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(53, 30);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(318, 46);
            this.txtDiaChi.TabIndex = 2;
            // 
            // txtViDo
            // 
            this.txtViDo.Location = new System.Drawing.Point(428, 30);
            this.txtViDo.Name = "txtViDo";
            this.txtViDo.Size = new System.Drawing.Size(118, 20);
            this.txtViDo.TabIndex = 2;
            // 
            // txtKinhDo
            // 
            this.txtKinhDo.Location = new System.Drawing.Point(428, 56);
            this.txtKinhDo.Name = "txtKinhDo";
            this.txtKinhDo.Size = new System.Drawing.Size(118, 20);
            this.txtKinhDo.TabIndex = 2;
            // 
            // txtMaMG
            // 
            this.txtMaMG.Location = new System.Drawing.Point(428, 4);
            this.txtMaMG.Name = "txtMaMG";
            this.txtMaMG.Size = new System.Drawing.Size(118, 20);
            this.txtMaMG.TabIndex = 2;
            // 
            // txtTenMG
            // 
            this.txtTenMG.Location = new System.Drawing.Point(53, 4);
            this.txtTenMG.Name = "txtTenMG";
            this.txtTenMG.Size = new System.Drawing.Size(318, 20);
            this.txtTenMG.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Kinh độ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Vĩ độ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã MG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Địa chỉ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xls";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Excel Documents(*xls) | *.xls|Excel Documents(*xlsx) |*.xlsx";
            // 
            // frmMoiGioi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMoiGioi";
            this.Text = "Môi giới";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMoiGioi)).EndInit();
            this.pnlMap.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlMap;
        private Janus.Windows.GridEX.GridEX gridMoiGioi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtViDo;
        private System.Windows.Forms.TextBox txtMaMG;
        private System.Windows.Forms.TextBox txtTenMG;
        private System.Windows.Forms.TextBox txtKinhDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Taxi.Controls.ExtendedGMapControl MainMap;
        private System.Windows.Forms.Button btnSearch;
    }
}