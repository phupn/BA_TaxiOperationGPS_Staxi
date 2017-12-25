namespace Taxi.Controls.Maps
{
    partial class UserMap
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
            this.gmap = new Taxi.Controls.ExtendedGMapControl();
            this.txtSearchAddress = new Taxi.Controls.Base.Inputs.InputText();
            this.shZoomMap = new Taxi.Controls.Base.Controls.ShZoomTrackBar();
            this.btnOk = new Taxi.Controls.Base.Controls.ShButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shZoomMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shZoomMap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.AllowDrawPolygon = false;
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
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(803, 432);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            // 
            // txtSearchAddress
            // 
            this.txtSearchAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchAddress.IsChangeText = false;
            this.txtSearchAddress.IsFocus = false;
            this.txtSearchAddress.KeyCommand = System.Windows.Forms.Keys.F3;
            this.txtSearchAddress.Location = new System.Drawing.Point(411, 4);
            this.txtSearchAddress.Name = "txtSearchAddress";
            this.txtSearchAddress.Properties.NullText = "Tìm kiếm địa chỉ (F3)";
            this.txtSearchAddress.Size = new System.Drawing.Size(290, 20);
            this.txtSearchAddress.TabIndex = 1;
            this.txtSearchAddress.EditValueChanged += new System.EventHandler(this.txtSearchAddress_EditValueChanged);
            this.txtSearchAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchAddress_KeyDown);
            this.txtSearchAddress.Leave += new System.EventHandler(this.txtSearchAddress_Leave);
            // 
            // shZoomMap
            // 
            this.shZoomMap.EditValue = null;
            this.shZoomMap.Location = new System.Drawing.Point(24, 59);
            this.shZoomMap.Name = "shZoomMap";
            this.shZoomMap.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.shZoomMap.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.shZoomMap.Size = new System.Drawing.Size(23, 259);
            this.shZoomMap.TabIndex = 2;
            this.shZoomMap.EditValueChanged += new System.EventHandler(this.shZoomMap_EditValueChanged);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnOk.Location = new System.Drawing.Point(703, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(55, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok (F2)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // UserMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.shZoomMap);
            this.Controls.Add(this.txtSearchAddress);
            this.Controls.Add(this.gmap);
            this.Name = "UserMap";
            this.Size = new System.Drawing.Size(803, 432);
            this.Load += new System.EventHandler(this.UserMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shZoomMap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shZoomMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendedGMapControl gmap;
        private Base.Inputs.InputText txtSearchAddress;
        private Base.Controls.ShZoomTrackBar shZoomMap;
        private Base.Controls.ShButton btnOk;
    }
}
