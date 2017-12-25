namespace TestAddress
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblZoom = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.shButton1 = new Taxi.Controls.Base.Controls.ShButton();
            this.btnReset = new Taxi.Controls.Base.Controls.ShButton();
            this.btnSearch = new Taxi.Controls.Base.Controls.ShButton();
            this.ckbGoogleMap = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenTinh = new Taxi.Controls.Base.Inputs.InputText();
            this.txtKetQuaToaDo = new Taxi.Controls.Base.Inputs.InputText();
            this.txtViDo = new Taxi.Controls.Base.Inputs.InputText();
            this.txtKinhDo = new Taxi.Controls.Base.Inputs.InputText();
            this.txtDiaChi = new Taxi.Controls.Base.Inputs.InputText();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBarMap = new System.Windows.Forms.TrackBar();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbGoogleMap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKetQuaToaDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKinhDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblZoom);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.shButton1);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.ckbGoogleMap);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTenTinh);
            this.panel1.Controls.Add(this.txtKetQuaToaDo);
            this.panel1.Controls.Add(this.txtViDo);
            this.panel1.Controls.Add(this.txtKinhDo);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 151);
            this.panel1.TabIndex = 10;
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZoom.Location = new System.Drawing.Point(458, 128);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(14, 13);
            this.lblZoom.TabIndex = 7;
            this.lblZoom.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Zoom:";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(19, 93);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 5;
            // 
            // shButton1
            // 
            this.shButton1.KeyCommand = System.Windows.Forms.Keys.F5;
            this.shButton1.Location = new System.Drawing.Point(432, 86);
            this.shButton1.Name = "shButton1";
            this.shButton1.Size = new System.Drawing.Size(93, 30);
            this.shButton1.TabIndex = 5;
            this.shButton1.Text = "Làm mới(F5)";
            this.shButton1.Visible = false;
            this.shButton1.Click += new System.EventHandler(this.shButton1_Click);
            // 
            // btnReset
            // 
            this.btnReset.KeyCommand = System.Windows.Forms.Keys.F5;
            this.btnReset.Location = new System.Drawing.Point(315, 86);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(93, 30);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Làm mới(F5)";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(216, 86);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm(Enter)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ckbGoogleMap
            // 
            this.ckbGoogleMap.IsChangeText = false;
            this.ckbGoogleMap.IsFocus = false;
            this.ckbGoogleMap.KeyCommand = System.Windows.Forms.Keys.None;
            this.ckbGoogleMap.Location = new System.Drawing.Point(212, 9);
            this.ckbGoogleMap.Name = "ckbGoogleMap";
            this.ckbGoogleMap.Properties.Caption = "[G]oogle map";
            this.ckbGoogleMap.Size = new System.Drawing.Size(89, 19);
            this.ckbGoogleMap.TabIndex = 3;
            this.ckbGoogleMap.CheckedChanged += new System.EventHandler(this.ckbGoogleMap_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "[T]ỉnh/TP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tọa độ theo Đ/[C]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "[V]ĩ độ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "[K]inh độ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "[Đ]ịa chỉ";
            // 
            // txtTenTinh
            // 
            this.txtTenTinh.EditValue = "Hà Nội";
            this.txtTenTinh.IsChangeText = false;
            this.txtTenTinh.IsFocus = false;
            this.txtTenTinh.Location = new System.Drawing.Point(75, 8);
            this.txtTenTinh.Name = "txtTenTinh";
            this.txtTenTinh.Size = new System.Drawing.Size(128, 20);
            this.txtTenTinh.TabIndex = 0;
            // 
            // txtKetQuaToaDo
            // 
            this.txtKetQuaToaDo.IsChangeText = false;
            this.txtKetQuaToaDo.IsFocus = false;
            this.txtKetQuaToaDo.Location = new System.Drawing.Point(120, 124);
            this.txtKetQuaToaDo.Name = "txtKetQuaToaDo";
            this.txtKetQuaToaDo.Properties.ReadOnly = true;
            this.txtKetQuaToaDo.Size = new System.Drawing.Size(288, 20);
            this.txtKetQuaToaDo.TabIndex = 6;
            // 
            // txtViDo
            // 
            this.txtViDo.IsChangeText = false;
            this.txtViDo.IsFocus = false;
            this.txtViDo.Location = new System.Drawing.Point(285, 60);
            this.txtViDo.Name = "txtViDo";
            this.txtViDo.Size = new System.Drawing.Size(123, 20);
            this.txtViDo.TabIndex = 3;
            // 
            // txtKinhDo
            // 
            this.txtKinhDo.IsChangeText = false;
            this.txtKinhDo.IsFocus = false;
            this.txtKinhDo.Location = new System.Drawing.Point(75, 60);
            this.txtKinhDo.Name = "txtKinhDo";
            this.txtKinhDo.Size = new System.Drawing.Size(139, 20);
            this.txtKinhDo.TabIndex = 2;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.IsChangeText = false;
            this.txtDiaChi.IsFocus = false;
            this.txtDiaChi.Location = new System.Drawing.Point(75, 34);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(333, 20);
            this.txtDiaChi.TabIndex = 1;
            this.txtDiaChi.EditValueChanged += new System.EventHandler(this.txtDiaChi_EditValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 457);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBarMap);
            this.groupBox1.Controls.Add(this.MainMap);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1027, 457);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bản đồ";
            // 
            // trackBarMap
            // 
            this.trackBarMap.LargeChange = 1;
            this.trackBarMap.Location = new System.Drawing.Point(19, 33);
            this.trackBarMap.Name = "trackBarMap";
            this.trackBarMap.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMap.Size = new System.Drawing.Size(45, 457);
            this.trackBarMap.TabIndex = 0;
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
            this.MainMap.Size = new System.Drawing.Size(1021, 438);
            this.MainMap.TabIndex = 5;
            this.MainMap.Zoom = 0D;
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 608);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Test Address";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbGoogleMap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKetQuaToaDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKinhDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar trackBarMap;
        private Taxi.Controls.ExtendedGMapControl MainMap;
        private Taxi.Controls.Base.Inputs.InputCheckbox ckbGoogleMap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Taxi.Controls.Base.Inputs.InputText txtViDo;
        private Taxi.Controls.Base.Inputs.InputText txtKinhDo;
        private Taxi.Controls.Base.Inputs.InputText txtDiaChi;
        private Taxi.Controls.Base.Controls.ShButton btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label4;
        private Taxi.Controls.Base.Inputs.InputText txtKetQuaToaDo;
        private System.Windows.Forms.Label label5;
        private Taxi.Controls.Base.Inputs.InputText txtTenTinh;
        private Taxi.Controls.Base.Controls.ShButton btnReset;
        private Taxi.Controls.Base.Controls.ShButton shButton1;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Label label6;
    }
}

