namespace Taxi.Controls.DanhSach.DMDuongPho
{
    partial class FrmManagerDuongPho
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
            this.gridControl1 = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.gridView1 = new Taxi.Controls.Base.Controls.Grids.GridView();
            this.gridColumn2 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn3 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn4 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grBTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).BeginInit();
            this.panelView.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(243, 4);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(163, 4);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(83, 4);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(323, 4);
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblMessage.Location = new System.Drawing.Point(371, 38);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(243, 4);
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.gridControl1);
            this.panelView.Location = new System.Drawing.Point(0, 58);
            this.panelView.Size = new System.Drawing.Size(787, 518);
            // 
            // panelAction
            // 
            this.panelAction.Location = new System.Drawing.Point(0, 0);
            this.panelAction.Size = new System.Drawing.Size(787, 58);
            // 
            // panelButton
            // 
            this.panelButton.Location = new System.Drawing.Point(197, 2);
            this.panelButton.Size = new System.Drawing.Size(409, 31);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridControl1.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridControl1.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridControl1.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridControl1.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridControl1.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridControl1.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(787, 518);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên đường phố";
            this.gridColumn2.FieldName = "TenDuongPho";
            this.gridColumn2.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.TagLanguage = null;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên đẩy đủ";
            this.gridColumn3.FieldName = "TenDuongPhoDayDu";
            this.gridColumn3.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.TagLanguage = null;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Báo cáo";
            this.gridColumn4.FieldName = "IsBaoCao";
            this.gridColumn4.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.TagLanguage = null;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // FrmManagerDuongPho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 576);
            this.Grid = this.gridControl1;
            this.IsFind = false;
            this.Name = "FrmManagerDuongPho";
            this.Text = "Quản lý đường phố";
            this.grBTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).EndInit();
            this.panelView.ResumeLayout(false);
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.Grids.GridControl gridControl1;
        private Base.Controls.Grids.GridView gridView1;
        private Base.Controls.Grids.GridColumn gridColumn2;
        private Base.Controls.Grids.GridColumn gridColumn3;
        private Base.Controls.Grids.GridColumn gridColumn4;
    }
}