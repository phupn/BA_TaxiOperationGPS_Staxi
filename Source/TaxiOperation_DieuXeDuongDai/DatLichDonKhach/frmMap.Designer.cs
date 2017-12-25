namespace TaxiOperation_DieuXeDuongDai
{
    partial class frmMap
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
            this.ztbMap = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGPS = new Taxi.Controls.Base.Controls.ShButton();
            this.btnOK = new Taxi.Controls.Base.Controls.ShButton();
            this.txtTimKiem = new Taxi.Controls.Base.Inputs.InputText();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ztbMap)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ztbMap
            // 
            this.ztbMap.Location = new System.Drawing.Point(12, 26);
            this.ztbMap.Name = "ztbMap";
            this.ztbMap.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ztbMap.Size = new System.Drawing.Size(45, 283);
            this.ztbMap.TabIndex = 2;
            this.ztbMap.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnGPS);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Location = new System.Drawing.Point(574, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 29);
            this.panel1.TabIndex = 1;
            // 
            // btnGPS
            // 
            this.btnGPS.Location = new System.Drawing.Point(327, 3);
            this.btnGPS.Name = "btnGPS";
            this.btnGPS.Size = new System.Drawing.Size(75, 23);
            this.btnGPS.TabIndex = 1;
            this.btnGPS.Text = "GPS";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(246, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.KeyCommand = System.Windows.Forms.Keys.F3;
            this.txtTimKiem.Location = new System.Drawing.Point(4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Properties.NullText = "Tìm địa chỉ (F3)";
            this.txtTimKiem.Size = new System.Drawing.Size(236, 20);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
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
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(978, 585);
            this.MainMap.TabIndex = 0;
            this.MainMap.Zoom = 0D;
            // 
            // frmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 585);
            this.CloseByKeyEsc = true;
            this.Controls.Add(this.ztbMap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMap);
            this.Name = "frmMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bản đồ";
            this.Load += new System.EventHandler(this.frmMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ztbMap)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.ExtendedGMapControl MainMap;
        private System.Windows.Forms.Panel panel1;
        private Taxi.Controls.Base.Controls.ShButton btnGPS;
        private Taxi.Controls.Base.Controls.ShButton btnOK;
        private Taxi.Controls.Base.Inputs.InputText txtTimKiem;
        private System.Windows.Forms.TrackBar ztbMap;
    }
}