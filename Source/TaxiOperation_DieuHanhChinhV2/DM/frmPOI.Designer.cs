namespace Taxi.GUI
{
    partial class frmPOI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOI));
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.grpViTri = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.trackBarMap = new System.Windows.Forms.TrackBar();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl();
            this.myGroupBox1 = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.txtVietTat = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtDiaChi = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtPOIName = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtViDo = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtKinhDo = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.btn_ViTri = new System.Windows.Forms.Button();
            this.panelInput1 = new Taxi.Controls.Base.Controls.ShPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpViTri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox1)).BeginInit();
            this.myGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVietTat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOIName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKinhDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput1)).BeginInit();
            this.panelInput1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(213, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(121, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 26);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = " &Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // grpViTri
            // 
            this.grpViTri.Controls.Add(this.txtAddress);
            this.grpViTri.Controls.Add(this.trackBarMap);
            this.grpViTri.Controls.Add(this.MainMap);
            this.grpViTri.Location = new System.Drawing.Point(411, 2);
            this.grpViTri.Name = "grpViTri";
            this.grpViTri.Size = new System.Drawing.Size(511, 277);
            this.grpViTri.TabIndex = 17;
            this.grpViTri.TabStop = false;
            this.grpViTri.Text = "Vị trí tọa độ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(305, 19);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 20);
            this.txtAddress.TabIndex = 10;
            this.txtAddress.Text = "Tìm địa chỉ";
            this.txtAddress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAddress_MouseClick);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // trackBarMap
            // 
            this.trackBarMap.Location = new System.Drawing.Point(6, 19);
            this.trackBarMap.Name = "trackBarMap";
            this.trackBarMap.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMap.Size = new System.Drawing.Size(45, 252);
            this.trackBarMap.TabIndex = 8;
            // 
            // MainMap
            // 
            this.MainMap.AllowDrawPolygon = false;
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            //this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
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
            //this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(505, 258);
            this.MainMap.TabIndex = 9;
            this.MainMap.TabStop = false;
            this.MainMap.Zoom = 0D;
            this.MainMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseClick);
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Controls.Add(this.txtVietTat);
            this.myGroupBox1.Controls.Add(this.shLabel5);
            this.myGroupBox1.Controls.Add(this.txtDiaChi);
            this.myGroupBox1.Controls.Add(this.shLabel4);
            this.myGroupBox1.Controls.Add(this.txtPOIName);
            this.myGroupBox1.Controls.Add(this.shLabel3);
            this.myGroupBox1.Controls.Add(this.txtViDo);
            this.myGroupBox1.Controls.Add(this.shLabel2);
            this.myGroupBox1.Controls.Add(this.txtKinhDo);
            this.myGroupBox1.Controls.Add(this.shLabel1);
            this.myGroupBox1.Controls.Add(this.btn_ViTri);
            this.myGroupBox1.Location = new System.Drawing.Point(2, 7);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(406, 223);
            this.myGroupBox1.TabIndex = 19;
            this.myGroupBox1.Text = "Thông tin POI";
            // 
            // txtVietTat
            // 
            this.txtVietTat.IsChangeText = false;
            this.txtVietTat.IsFocus = false;
            this.txtVietTat.Location = new System.Drawing.Point(97, 100);
            this.txtVietTat.Name = "txtVietTat";
            this.txtVietTat.Size = new System.Drawing.Size(273, 20);
            this.txtVietTat.TabIndex = 3;
            // 
            // shLabel5
            // 
            this.shLabel5.Location = new System.Drawing.Point(35, 103);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(35, 13);
            this.shLabel5.TabIndex = 80;
            this.shLabel5.Text = "Viết tắt";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.IsChangeText = false;
            this.txtDiaChi.IsFocus = false;
            this.txtDiaChi.Location = new System.Drawing.Point(97, 65);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(273, 20);
            this.txtDiaChi.TabIndex = 2;
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(35, 68);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(35, 13);
            this.shLabel4.TabIndex = 78;
            this.shLabel4.Text = "Địa chỉ ";
            // 
            // txtPOIName
            // 
            this.txtPOIName.IsChangeText = false;
            this.txtPOIName.IsFocus = true;
            this.txtPOIName.Location = new System.Drawing.Point(97, 30);
            this.txtPOIName.Name = "txtPOIName";
            this.txtPOIName.Size = new System.Drawing.Size(273, 20);
            this.txtPOIName.TabIndex = 1;
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(35, 33);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(56, 13);
            this.shLabel3.TabIndex = 76;
            this.shLabel3.Text = "Tên POI (*)";
            // 
            // txtViDo
            // 
            this.txtViDo.IsChangeText = false;
            this.txtViDo.IsFocus = false;
            this.txtViDo.Location = new System.Drawing.Point(97, 171);
            this.txtViDo.Name = "txtViDo";
            this.txtViDo.Size = new System.Drawing.Size(273, 20);
            this.txtViDo.TabIndex = 5;
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(35, 174);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(23, 13);
            this.shLabel2.TabIndex = 74;
            this.shLabel2.Text = "Vĩ độ";
            // 
            // txtKinhDo
            // 
            this.txtKinhDo.IsChangeText = false;
            this.txtKinhDo.IsFocus = false;
            this.txtKinhDo.Location = new System.Drawing.Point(97, 136);
            this.txtKinhDo.Name = "txtKinhDo";
            this.txtKinhDo.Size = new System.Drawing.Size(273, 20);
            this.txtKinhDo.TabIndex = 4;
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(35, 139);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(35, 13);
            this.shLabel1.TabIndex = 72;
            this.shLabel1.Text = "Kinh độ";
            // 
            // btn_ViTri
            // 
            this.btn_ViTri.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.map;
            this.btn_ViTri.Location = new System.Drawing.Point(376, 25);
            this.btn_ViTri.Name = "btn_ViTri";
            this.btn_ViTri.Size = new System.Drawing.Size(27, 29);
            this.btn_ViTri.TabIndex = 0;
            this.btn_ViTri.TabStop = false;
            this.btn_ViTri.UseVisualStyleBackColor = true;
            this.btn_ViTri.Click += new System.EventHandler(this.btn_ViTri_Click);
            // 
            // panelInput1
            // 
            this.panelInput1.Controls.Add(this.btnCancel);
            this.panelInput1.Controls.Add(this.btnSave);
            this.panelInput1.LabelMessage = null;
            this.panelInput1.Location = new System.Drawing.Point(2, 236);
            this.panelInput1.Name = "panelInput1";
            this.panelInput1.Size = new System.Drawing.Size(406, 43);
            this.panelInput1.TabIndex = 20;
            // 
            // frmPOI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 291);
            this.Controls.Add(this.panelInput1);
            this.Controls.Add(this.myGroupBox1);
            this.Controls.Add(this.grpViTri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmPOI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý POI";
            this.Load += new System.EventHandler(this.frmPOI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDoiTac_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpViTri.ResumeLayout(false);
            this.grpViTri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox1)).EndInit();
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVietTat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOIName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKinhDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput1)).EndInit();
            this.panelInput1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox grpViTri;
        private System.Windows.Forms.TrackBar trackBarMap;
        private Taxi.Controls.ExtendedGMapControl MainMap;
        private System.Windows.Forms.TextBox txtAddress;
        private Controls.Base.Controls.ShGroupBox myGroupBox1;
        private System.Windows.Forms.Button btn_ViTri;
        private Controls.Base.Controls.ShPanel panelInput1;
        private Controls.Base.Inputs.InputText txtViDo;
        private Controls.Base.Controls.ShLabel shLabel2;
        private Controls.Base.Inputs.InputText txtKinhDo;
        private Controls.Base.Controls.ShLabel shLabel1;
        private Controls.Base.Inputs.InputText txtPOIName;
        private Controls.Base.Controls.ShLabel shLabel3;
        private Controls.Base.Inputs.InputText txtVietTat;
        private Controls.Base.Controls.ShLabel shLabel5;
        private Controls.Base.Inputs.InputText txtDiaChi;
        private Controls.Base.Controls.ShLabel shLabel4;
    }
}