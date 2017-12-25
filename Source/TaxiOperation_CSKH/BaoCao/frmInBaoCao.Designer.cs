namespace Taxi.GUI
{
    partial class frmInBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInBaoCao));
            this.crGiayPhepViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crGiayPhepViewer
            // 
            this.crGiayPhepViewer.ActiveViewIndex = -1;
            this.crGiayPhepViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crGiayPhepViewer.DisplayBackgroundEdge = false;
            this.crGiayPhepViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crGiayPhepViewer.Location = new System.Drawing.Point(0, 0);
            this.crGiayPhepViewer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.crGiayPhepViewer.Name = "crGiayPhepViewer";
            this.crGiayPhepViewer.SelectionFormula = "";
            this.crGiayPhepViewer.ShowCloseButton = false;
            this.crGiayPhepViewer.ShowGroupTreeButton = false;
            this.crGiayPhepViewer.ShowTextSearchButton = false;
            this.crGiayPhepViewer.Size = new System.Drawing.Size(802, 500);
            this.crGiayPhepViewer.TabIndex = 0;
            this.crGiayPhepViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crGiayPhepViewer.ToolPanelWidth = 150;
            this.crGiayPhepViewer.ViewTimeSelectionFormula = "";
            // 
            // frmInBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 500);
            this.Controls.Add(this.crGiayPhepViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmInBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Báo cáo";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crGiayPhepViewer;
    }
}