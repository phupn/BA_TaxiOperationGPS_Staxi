namespace TaxiOperation_DieuHanhChinh
{
    partial class frmDanhBaBuuDien
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
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.gridDanhBaBuuDien = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.gridView1 = new Taxi.Controls.Base.Controls.Grids.GridView();
            this.gridColumn1 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn2 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn3 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhBaBuuDien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.LookAndFeel.SkinMaskColor = System.Drawing.Color.LightSalmon;
            this.panelHeader.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Transparent;
            this.panelHeader.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(610, 67);
            this.panelHeader.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(185, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh bạ bưu điện";
            // 
            // gridDanhBaBuuDien
            // 
            this.gridDanhBaBuuDien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDanhBaBuuDien.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridDanhBaBuuDien.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridDanhBaBuuDien.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridDanhBaBuuDien.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridDanhBaBuuDien.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridDanhBaBuuDien.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridDanhBaBuuDien.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridDanhBaBuuDien.Location = new System.Drawing.Point(0, 67);
            this.gridDanhBaBuuDien.MainView = this.gridView1;
            this.gridDanhBaBuuDien.Name = "gridDanhBaBuuDien";
            this.gridDanhBaBuuDien.Size = new System.Drawing.Size(610, 361);
            this.gridDanhBaBuuDien.TabIndex = 2;
            this.gridDanhBaBuuDien.UseEmbeddedNavigator = true;
            this.gridDanhBaBuuDien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridDanhBaBuuDien;
            this.gridView1.GroupPanelText = "Kéo cột muốn nhóm vào đây";
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số điện thoại";
            this.gridColumn1.FieldName = "PhoneNumber";
            this.gridColumn1.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.TagLanguage = null;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên bưu điện";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.TagLanguage = null;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 150;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Địa chỉ";
            this.gridColumn3.FieldName = "Address";
            this.gridColumn3.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.TagLanguage = null;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 323;
            // 
            // frmDanhBaBuuDien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 428);
            this.Controls.Add(this.gridDanhBaBuuDien);
            this.Controls.Add(this.panelHeader);
            this.Name = "frmDanhBaBuuDien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh bạ bưu điện";
            this.Load += new System.EventHandler(this.frmDanhBaBuuDien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhBaBuuDien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private Taxi.Controls.Base.Controls.Grids.GridControl gridDanhBaBuuDien;
        private Taxi.Controls.Base.Controls.Grids.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn1;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn2;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn3;
    }
}