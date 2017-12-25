namespace TaxiOperation_TongDai
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.autoCompleteAddress1 = new Taxi.Controls.Base.Common.AutoCompleteAddress();
            this.extendedGMapControl1 = new Taxi.Controls.ExtendedGMapControl(this.components);
            this.SuspendLayout();
            // 
            // autoCompleteAddress1
            // 
            this.autoCompleteAddress1.CaseSensitive = false;
            this.autoCompleteAddress1.DataRowSelect = null;
            this.autoCompleteAddress1.DisplayMember = "";
            this.autoCompleteAddress1.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoCompleteAddress1.Location = new System.Drawing.Point(0, 0);
            this.autoCompleteAddress1.MinTypedCharacters = 2;
            this.autoCompleteAddress1.Name = "autoCompleteAddress1";
            this.autoCompleteAddress1.Rowshow = 10;
            this.autoCompleteAddress1.SelectedIndex = -1;
            this.autoCompleteAddress1.Size = new System.Drawing.Size(688, 20);
            this.autoCompleteAddress1.TabIndex = 5;
            this.autoCompleteAddress1.Value = null;
            this.autoCompleteAddress1.ValueMember = "";
            this.autoCompleteAddress1.EventSelectAutoComplete += new Taxi.Controls.Base.Inputs.AutoCompleteTextbox.SelectAutoComplete(this.autoCompleteAddress1_EventSelectAutoComplete);
            // 
            // extendedGMapControl1
            // 
            this.extendedGMapControl1.AllowDrawPolygon = false;
            this.extendedGMapControl1.Bearing = 0F;
            this.extendedGMapControl1.CanDragMap = true;
            this.extendedGMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedGMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.extendedGMapControl1.GrayScaleMode = false;
            this.extendedGMapControl1.LevelsKeepInMemmory = 5;
            this.extendedGMapControl1.Location = new System.Drawing.Point(0, 20);
            this.extendedGMapControl1.MarkersEnabled = true;
            this.extendedGMapControl1.MaxZoom = 2;
            this.extendedGMapControl1.MinZoom = 2;
            this.extendedGMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.extendedGMapControl1.Name = "extendedGMapControl1";
            this.extendedGMapControl1.NegativeMode = false;
            this.extendedGMapControl1.PolygonsEnabled = true;
            this.extendedGMapControl1.RetryLoadTile = 0;
            this.extendedGMapControl1.RoutesEnabled = true;
            this.extendedGMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.extendedGMapControl1.ShowTileGridLines = false;
            this.extendedGMapControl1.Size = new System.Drawing.Size(688, 638);
            this.extendedGMapControl1.TabIndex = 6;
            this.extendedGMapControl1.Zoom = 0D;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 658);
            this.Controls.Add(this.extendedGMapControl1);
            this.Controls.Add(this.autoCompleteAddress1);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Common.AutoCompleteAddress autoCompleteAddress1;
        private Taxi.Controls.ExtendedGMapControl extendedGMapControl1;
    }
}