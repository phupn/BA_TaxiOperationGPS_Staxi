namespace Taxi.GUI 
{
    partial class frmPreviewReport
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
            this.btnExport = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.printPreviewStatus1 = new DevExpress.CodeRush.Controls.XtraPrinting.Preview.PrintPreviewStatus();
            this.previewPanel = new DevExpress.CodeRush.UserControls.PreviewPanel();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(134, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(60, 25);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Kết xuất";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(103, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 25);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(26, 4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(25, 25);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // printPreviewStatus1
            // 
            this.printPreviewStatus1.Location = new System.Drawing.Point(0, 0);
            this.printPreviewStatus1.Name = "printPreviewStatus1";
            this.printPreviewStatus1.ShowPanels = true;
            this.printPreviewStatus1.TabIndex = 0;
            // 
            // previewPanel
            // 
            this.previewPanel.AutoSize = true;
            this.previewPanel.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.previewPanel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.previewPanel.Location = new System.Drawing.Point(0, 0);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(900, 600);
            this.previewPanel.TabIndex = 3;
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(56, 6);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(41, 20);
            this.txtPage.TabIndex = 4;
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.txtPage);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Location = new System.Drawing.Point(390, 614);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 30);
            this.panel1.TabIndex = 6;
            // 
            // frmPreviewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 658);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.previewPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreviewReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hiển thị nội dung báo cáo";
            this.Load += new System.EventHandler(this.frmPreviewReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private DevExpress.CodeRush.Controls.XtraPrinting.Preview.PrintPreviewStatus printPreviewStatus1;
        private DevExpress.CodeRush.UserControls.PreviewPanel previewPanel;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Panel panel1;
    }
}