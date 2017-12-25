namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    partial class FrmBC_1_10_BaoCaoThongKeTheoTenDuong
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
            this.gridColumn1 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn2 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn3 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn4 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInputs
            // 
            this.pnInputs.Size = new System.Drawing.Size(817, 44);
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = null;
            this.ipToDate.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipToDate.Size = new System.Drawing.Size(152, 20);
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = null;
            this.ipFromDate.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipFromDate.Size = new System.Drawing.Size(152, 20);
            // 
            // pnButtons
            // 
            this.pnButtons.Location = new System.Drawing.Point(0, 78);
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnExportExcel.Appearance.Options.UseFont = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnThoat.Appearance.Options.UseFont = true;
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnTim.Appearance.Options.UseFont = true;
            // 
            // pnOutput
            // 
            this.pnOutput.Controls.Add(this.gridControl1);
            this.pnOutput.Location = new System.Drawing.Point(0, 130);
            this.pnOutput.Size = new System.Drawing.Size(817, 451);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
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
            this.gridControl1.Size = new System.Drawing.Size(817, 451);
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
            this.gridColumn1,
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên đường";
            this.gridColumn1.FieldName = "TenDuongPho";
            this.gridColumn1.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.TagLanguage = null;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Số cuốc";
            this.gridColumn2.DisplayFormat.FormatString = "#,##0";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn2.FieldName = "CuocKhach";
            this.gridColumn2.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.TagLanguage = null;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Cuốc taxi";
            this.gridColumn3.DisplayFormat.FormatString = "#,##0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "CuocTaxi";
            this.gridColumn3.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.TagLanguage = null;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Đón được";
            this.gridColumn4.DisplayFormat.FormatString = "#,##0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "CuocDonDuoc";
            this.gridColumn4.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.TagLanguage = null;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // FrmBC_1_10_BaoCaoThongKeTheoTenDuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 581);
            this.Name = "FrmBC_1_10_BaoCaoThongKeTheoTenDuong";
            this.Text = "Báo cáo thông kê theo tên đường";
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.Grids.GridControl gridControl1;
        private Taxi.Controls.Base.Controls.Grids.GridView gridView1;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn1;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn2;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn3;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn4;
    }
}