namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    partial class frmBC_1_11_1_BaoCaoCuocKhongDieuAppTongHopTheoNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_1_11_1_BaoCaoCuocKhongDieuAppTongHopTheoNhanVien));
            this.shGridControl2 = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridView2 = new Taxi.Controls.Base.Controls.ShGridView();
            this.colMaNVDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).BeginInit();
            this.pnInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).BeginInit();
            this.pnButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).BeginInit();
            this.pnOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInputs
            // 
            this.pnInputs.Size = new System.Drawing.Size(358, 97);
            this.pnInputs.Visible = false;
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = null;
            this.ipToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = null;
            this.ipFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // pnButtons
            // 
            this.pnButtons.Size = new System.Drawing.Size(358, 52);
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.Location = new System.Drawing.Point(82, 6);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Location = new System.Drawing.Point(207, 6);
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnTim.Appearance.Options.UseFont = true;
            this.btnTim.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnTim.Location = new System.Drawing.Point(-83, 6);
            this.btnTim.Size = new System.Drawing.Size(77, 25);
            this.btnTim.Visible = false;
            // 
            // pnOutput
            // 
            this.pnOutput.Controls.Add(this.shGridControl2);
            this.pnOutput.Size = new System.Drawing.Size(358, 253);
            // 
            // pnTitle
            // 
            this.pnTitle.Size = new System.Drawing.Size(358, 34);
            this.pnTitle.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            // 
            // shGridControl2
            // 
            this.shGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGridControl2.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shGridControl2.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shGridControl2.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shGridControl2.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shGridControl2.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shGridControl2.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shGridControl2.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shGridControl2.Location = new System.Drawing.Point(0, 0);
            this.shGridControl2.MainView = this.gridView2;
            this.shGridControl2.Name = "shGridControl2";
            this.shGridControl2.Size = new System.Drawing.Size(358, 253);
            this.shGridControl2.TabIndex = 3;
            this.shGridControl2.UseEmbeddedNavigator = true;
            this.shGridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.gridView2.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView2.ColumnPanelRowHeight = 35;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNVDT,
            this.colSoCuoc});
            this.gridView2.GridControl = this.shGridControl2;
            this.gridView2.IndicatorWidth = 35;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colMaNVDT
            // 
            this.colMaNVDT.AppearanceCell.Options.UseTextOptions = true;
            this.colMaNVDT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaNVDT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaNVDT.Caption = "Mã NVĐT";
            this.colMaNVDT.FieldName = "MaNhanVienDienThoai";
            this.colMaNVDT.Name = "colMaNVDT";
            this.colMaNVDT.Visible = true;
            this.colMaNVDT.VisibleIndex = 0;
            this.colMaNVDT.Width = 145;
            // 
            // colSoCuoc
            // 
            this.colSoCuoc.AppearanceCell.Options.UseTextOptions = true;
            this.colSoCuoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoCuoc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoCuoc.Caption = "Số cuốc";
            this.colSoCuoc.FieldName = "SoCuoc";
            this.colSoCuoc.Name = "colSoCuoc";
            this.colSoCuoc.Visible = true;
            this.colSoCuoc.VisibleIndex = 1;
            this.colSoCuoc.Width = 176;
            // 
            // frmBC_1_11_1_BaoCaoCuocKhongDieuAppTongHopTheoNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 436);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_1_11_1_BaoCaoCuocKhongDieuAppTongHopTheoNhanVien";
            this.Text = "1.12.1 Báo cáo cuốc không điều app tổng hợp theo nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).EndInit();
            this.pnInputs.ResumeLayout(false);
            this.pnInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).EndInit();
            this.pnButtons.ResumeLayout(false);
            this.pnButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).EndInit();
            this.pnOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl shGridControl2;
        private Taxi.Controls.Base.Controls.ShGridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNVDT;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCuoc;
    }
}