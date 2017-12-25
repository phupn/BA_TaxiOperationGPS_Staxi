using TaxiOperation_BanCo.Config;
using TaxiOperation_BanCo.Controls.Config;

namespace TaxiOperation_BanCo.Config
{
    partial class frmConfigDHBanCo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigDHBanCo));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.TabPage_CauHinhBanCo = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl_Cauhinh = new DevExpress.XtraEditors.GroupControl();
            this.control_Config_Alert_21 = new TaxiOperation_BanCo.Controls.Config.Control_Config_Alert_2();
            this.groupControl_TrangThai = new DevExpress.XtraEditors.GroupControl();
            this.control_Config_ColorOfStatus1 = new TaxiOperation_BanCo.Controls.Config.Control_Config_ColorOfStatus();
            this.TabPage_CauHinhChung = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.TabPage_CauHinhBanCo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Cauhinh)).BeginInit();
            this.groupControl_Cauhinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TrangThai)).BeginInit();
            this.groupControl_TrangThai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.TabPage_CauHinhBanCo;
            this.xtraTabControl1.Size = new System.Drawing.Size(850, 403);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPage_CauHinhChung,
            this.TabPage_CauHinhBanCo});
            // 
            // TabPage_CauHinhBanCo
            // 
            this.TabPage_CauHinhBanCo.Controls.Add(this.groupControl_Cauhinh);
            this.TabPage_CauHinhBanCo.Controls.Add(this.groupControl_TrangThai);
            this.TabPage_CauHinhBanCo.Name = "TabPage_CauHinhBanCo";
            this.TabPage_CauHinhBanCo.Size = new System.Drawing.Size(844, 377);
            this.TabPage_CauHinhBanCo.Text = "Bàn cờ";
            // 
            // groupControl_Cauhinh
            // 
            this.groupControl_Cauhinh.Controls.Add(this.control_Config_Alert_21);
            this.groupControl_Cauhinh.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl_Cauhinh.Location = new System.Drawing.Point(394, 0);
            this.groupControl_Cauhinh.Name = "groupControl_Cauhinh";
            this.groupControl_Cauhinh.Size = new System.Drawing.Size(450, 377);
            this.groupControl_Cauhinh.TabIndex = 1;
            this.groupControl_Cauhinh.Text = "Cấu hình cảnh báo";
            // 
            // control_Config_Alert_21
            // 
            this.control_Config_Alert_21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_Config_Alert_21.Location = new System.Drawing.Point(2, 22);
            this.control_Config_Alert_21.Name = "control_Config_Alert_21";
            this.control_Config_Alert_21.Size = new System.Drawing.Size(446, 353);
            this.control_Config_Alert_21.TabIndex = 0;
            // 
            // groupControl_TrangThai
            // 
            this.groupControl_TrangThai.Controls.Add(this.control_Config_ColorOfStatus1);
            this.groupControl_TrangThai.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl_TrangThai.Location = new System.Drawing.Point(0, 0);
            this.groupControl_TrangThai.Name = "groupControl_TrangThai";
            this.groupControl_TrangThai.Size = new System.Drawing.Size(400, 377);
            this.groupControl_TrangThai.TabIndex = 0;
            this.groupControl_TrangThai.Text = "Màu sắc trạng thái xe";
            // 
            // control_Config_ColorOfStatus1
            // 
            this.control_Config_ColorOfStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_Config_ColorOfStatus1.Location = new System.Drawing.Point(2, 22);
            this.control_Config_ColorOfStatus1.Name = "control_Config_ColorOfStatus1";
            this.control_Config_ColorOfStatus1.Size = new System.Drawing.Size(396, 353);
            this.control_Config_ColorOfStatus1.TabIndex = 0;
            // 
            // TabPage_CauHinhChung
            // 
            this.TabPage_CauHinhChung.Name = "TabPage_CauHinhChung";
            this.TabPage_CauHinhChung.PageVisible = false;
            this.TabPage_CauHinhChung.Size = new System.Drawing.Size(844, 377);
            this.TabPage_CauHinhChung.Text = "Hệ thống";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.xtraTabControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 27);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(854, 407);
            this.panelControl1.TabIndex = 1;
            // 
            // frmConfigDHBanCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 434);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(864, 417);
            this.Name = "frmConfigDHBanCo";
            this.Text = "Cấu hình điều hành bàn cờ";
            this.Load += new System.EventHandler(this.frmConfigDHBanCo_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.TabPage_CauHinhBanCo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Cauhinh)).EndInit();
            this.groupControl_Cauhinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TrangThai)).EndInit();
            this.groupControl_TrangThai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage TabPage_CauHinhChung;
        private DevExpress.XtraTab.XtraTabPage TabPage_CauHinhBanCo;
        private DevExpress.XtraEditors.GroupControl groupControl_TrangThai;
        private Controls.Config.Control_Config_ColorOfStatus control_Config_ColorOfStatus1;
        private DevExpress.XtraEditors.GroupControl groupControl_Cauhinh;
        private Control_Config_Alert_2 control_Config_Alert_21;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}