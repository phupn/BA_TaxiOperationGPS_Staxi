namespace Taxi.Controls.DanhSach.DMLoaiXe
{
    partial class FrmManagerLoaiXe
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
            this.shGridControl1 = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridView1 = new Taxi.Controls.Base.Controls.ShGridView();
            this.colTenLoaiXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenHienThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoCho = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtTenLoaiXe = new Taxi.Controls.Base.Inputs.InputText();
            this.grBTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).BeginInit();
            this.panelInputFind.SuspendLayout();
            this.panelView.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiXe.Properties)).BeginInit();
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
            this.lblMessage.Location = new System.Drawing.Point(237, 38);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(243, 4);
            // 
            // grBTimKiem
            // 
            this.grBTimKiem.Visible = false;
            // 
            // panelInputFind
            // 
            this.panelInputFind.Controls.Add(this.shLabel4);
            this.panelInputFind.Controls.Add(this.txtSoCho);
            this.panelInputFind.Controls.Add(this.shLabel1);
            this.panelInputFind.Controls.Add(this.txtTenLoaiXe);
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.shGridControl1);
            this.panelView.Location = new System.Drawing.Point(0, 58);
            this.panelView.Size = new System.Drawing.Size(519, 249);
            // 
            // panelAction
            // 
            this.panelAction.Location = new System.Drawing.Point(0, 0);
            this.panelAction.Size = new System.Drawing.Size(519, 58);
            // 
            // panelButton
            // 
            this.panelButton.Location = new System.Drawing.Point(63, 2);
            this.panelButton.Size = new System.Drawing.Size(409, 31);
            // 
            // shGridControl1
            // 
            this.shGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGridControl1.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shGridControl1.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shGridControl1.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shGridControl1.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shGridControl1.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shGridControl1.Location = new System.Drawing.Point(0, 0);
            this.shGridControl1.MainView = this.gridView1;
            this.shGridControl1.Name = "shGridControl1";
            this.shGridControl1.Size = new System.Drawing.Size(519, 249);
            this.shGridControl1.TabIndex = 2;
            this.shGridControl1.UseEmbeddedNavigator = true;
            this.shGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenLoaiXe,
            this.colSoCho,
            this.colTenHienThi});
            this.gridView1.GridControl = this.shGridControl1;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colTenLoaiXe
            // 
            this.colTenLoaiXe.AppearanceCell.Options.UseTextOptions = true;
            this.colTenLoaiXe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTenLoaiXe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenLoaiXe.Caption = "Tên loại xe";
            this.colTenLoaiXe.FieldName = "TenLoaiXe";
            this.colTenLoaiXe.Name = "colTenLoaiXe";
            this.colTenLoaiXe.OptionsColumn.AllowEdit = false;
            this.colTenLoaiXe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTenLoaiXe.OptionsFilter.AllowAutoFilter = false;
            this.colTenLoaiXe.OptionsFilter.AllowFilter = false;
            this.colTenLoaiXe.Visible = true;
            this.colTenLoaiXe.VisibleIndex = 0;
            this.colTenLoaiXe.Width = 160;
            // 
            // colSoCho
            // 
            this.colSoCho.AppearanceCell.Options.UseTextOptions = true;
            this.colSoCho.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoCho.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.colSoCho.Caption = "Số chỗ";
            this.colSoCho.FieldName = "SoCho";
            this.colSoCho.Name = "colSoCho";
            this.colSoCho.Visible = true;
            this.colSoCho.VisibleIndex = 1;
            this.colSoCho.Width = 113;
            // 
            // colTenHienThi
            // 
            this.colTenHienThi.Caption = "Tên hiển thị";
            this.colTenHienThi.FieldName = "TenHienThi";
            this.colTenHienThi.Name = "colTenHienThi";
            this.colTenHienThi.Visible = true;
            this.colTenHienThi.VisibleIndex = 2;
            this.colTenHienThi.Width = 209;
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(256, 33);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(32, 13);
            this.shLabel4.TabIndex = 18;
            this.shLabel4.Text = "Số chỗ";
            // 
            // txtSoCho
            // 
            this.txtSoCho.IsChangeText = false;
            this.txtSoCho.IsFocus = false;
            this.txtSoCho.Location = new System.Drawing.Point(294, 30);
            this.txtSoCho.Name = "txtSoCho";
            this.txtSoCho.Properties.Mask.EditMask = "[0-9A-Za-z]+";
            this.txtSoCho.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSoCho.Properties.MaxLength = 15;
            this.txtSoCho.Size = new System.Drawing.Size(150, 20);
            this.txtSoCho.TabIndex = 15;
            this.txtSoCho.Tag = "Name";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(30, 33);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(52, 13);
            this.shLabel1.TabIndex = 19;
            this.shLabel1.Text = "Tên loại xe";
            // 
            // txtTenLoaiXe
            // 
            this.txtTenLoaiXe.IsChangeText = false;
            this.txtTenLoaiXe.IsFocus = false;
            this.txtTenLoaiXe.Location = new System.Drawing.Point(100, 30);
            this.txtTenLoaiXe.Name = "txtTenLoaiXe";
            this.txtTenLoaiXe.Properties.Mask.EditMask = "[0-9]+";
            this.txtTenLoaiXe.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTenLoaiXe.Properties.MaxLength = 15;
            this.txtTenLoaiXe.Size = new System.Drawing.Size(150, 20);
            this.txtTenLoaiXe.TabIndex = 16;
            this.txtTenLoaiXe.Tag = "PhoneNumber";
            // 
            // FrmManagerLoaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 307);
            this.Grid = this.shGridControl1;
            this.IsFind = false;
            this.Name = "FrmManagerLoaiXe";
            this.Text = "Danh sách loại xe";
            this.grBTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).EndInit();
            this.panelInputFind.ResumeLayout(false);
            this.panelInputFind.PerformLayout();
            this.panelView.ResumeLayout(false);
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiXe.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShGridControl shGridControl1;
        private Base.Controls.ShGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLoaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCho;
        private DevExpress.XtraGrid.Columns.GridColumn colTenHienThi;
        private Base.Controls.ShLabel shLabel4;
        private Base.Inputs.InputText txtSoCho;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputText txtTenLoaiXe;
    }
}