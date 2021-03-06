namespace Taxi.GUI
{
    partial class frmHienThiBanDo_Mini
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
            this.MainMap = new Taxi.Controls.ExtendedGMapControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBanDo = new System.Windows.Forms.Panel();
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlBanDo.SuspendLayout();
            this.SuspendLayout();
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
            this.MainMap.Size = new System.Drawing.Size(477, 265);
            this.MainMap.TabIndex = 7;
            this.MainMap.Zoom = 0D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlBanDo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 302);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMsg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 37);
            this.panel2.TabIndex = 9;
            // 
            // pnlBanDo
            // 
            this.pnlBanDo.Controls.Add(this.MainMap);
            this.pnlBanDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBanDo.Location = new System.Drawing.Point(0, 0);
            this.pnlBanDo.Name = "pnlBanDo";
            this.pnlBanDo.Size = new System.Drawing.Size(477, 265);
            this.pnlBanDo.TabIndex = 10;
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(13, 11);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(107, 14);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Thông tin xe online";
            // 
            // frmHienThiBanDo_Mini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 302);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = global::TaxiOperation_TongDai_ENVANGVIP.Properties.Resources.Taxi;
            this.Name = "frmHienThiBanDo_Mini";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bản đồ GPS";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHienThiBanDo_Mini_FormClosing);
            this.Load += new System.EventHandler(this.frmHienThiBanDo_XeNhan_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBanDo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.ExtendedGMapControl MainMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlBanDo;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl lblMsg;
    }
}