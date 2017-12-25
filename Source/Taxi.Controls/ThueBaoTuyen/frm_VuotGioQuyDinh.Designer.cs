namespace Taxi.Controls.ThueBaoTuyen
{
    partial class frm_VuotGioQuyDinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_VuotGioQuyDinh));
            this.grcDinhMuc = new DevExpress.XtraGrid.GridControl();
            this.grvDinhMuc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueXe = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboLoaiXe = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ctmtXoa = new System.Windows.Forms.ContextMenuStrip();
            this.Xoa = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDinhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDinhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiXe)).BeginInit();
            this.ctmtXoa.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Size = new System.Drawing.Size(1174, 27);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // grcDinhMuc
            // 
            this.grcDinhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grcDinhMuc.Location = new System.Drawing.Point(12, 3);
            this.grcDinhMuc.MainView = this.grvDinhMuc;
            this.grcDinhMuc.Name = "grcDinhMuc";
            this.grcDinhMuc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboLoaiXe,
            this.lueXe});
            this.grcDinhMuc.Size = new System.Drawing.Size(1153, 298);
            this.grcDinhMuc.TabIndex = 0;
            this.grcDinhMuc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDinhMuc});
            this.grcDinhMuc.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grcDinhMuc_ProcessGridKey);
            // 
            // grvDinhMuc
            // 
            this.grvDinhMuc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.STT,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.grvDinhMuc.GridControl = this.grcDinhMuc;
            this.grvDinhMuc.IndicatorWidth = 20;
            this.grvDinhMuc.Name = "grvDinhMuc";
            this.grvDinhMuc.NewItemRowText = "Thêm dữ liệu";
            this.grvDinhMuc.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvDinhMuc.OptionsView.ShowGroupPanel = false;
            this.grvDinhMuc.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvDinhMuc_RowClick);
            this.grvDinhMuc.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvDinhMuc_CustomDrawRowIndicator);
            this.grvDinhMuc.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvDinhMuc_InvalidRowException);
            this.grvDinhMuc.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvDinhMuc_ValidateRow);
            this.grvDinhMuc.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.grvDinhMuc_InvalidValueException);
            // 
            // STT
            // 
            this.STT.Caption = "STT";
            this.STT.FieldName = "STT";
            this.STT.Name = "STT";
            this.STT.OptionsColumn.AllowFocus = false;
            this.STT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.STT.OptionsFilter.AllowFilter = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Loại xe";
            this.gridColumn2.ColumnEdit = this.lueXe;
            this.gridColumn2.FieldName = "FK_LoaiXeID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 115;
            // 
            // lueXe
            // 
            this.lueXe.AutoHeight = false;
            this.lueXe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueXe.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoaiXe", "Loại xe")});
            this.lueXe.Name = "lueXe";
            this.lueXe.NullText = "Chọn xe";
            this.lueXe.EditValueChanged += new System.EventHandler(this.lueXe_EditValueChanged);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Vượt 1 giờ 1 chiều";
            this.gridColumn3.FieldName = "GiaDinhMucVuot1GioMotChieu";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Width = 115;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Vượt 1 km 1 chiều";
            this.gridColumn4.FieldName = "GiaDinhMucVuot1KmMotChieu";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 115;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Vượt 1 giờ 2 chiều";
            this.gridColumn5.FieldName = "GiaDinhMucVuot1GioHaiChieu";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 115;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Vượt 1 km 2 chiều";
            this.gridColumn6.FieldName = "GiaDinhMucVuot1KmHaiChieu";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 115;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tiền lưu ngày";
            this.gridColumn1.DisplayFormat.FormatString = "###,##0.##";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn1.FieldName = "TienLuuNgay";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tiền lưu đêm";
            this.gridColumn7.DisplayFormat.FormatString = "###,##0.##";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "TienLuuDem";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tiền bù xăng di chuyển xa";
            this.gridColumn8.DisplayFormat.FormatString = "###,##0.##";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn8.FieldName = "TienBuXangDiChuyenXa";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsFilter.AllowFilter = false;
            this.gridColumn8.Width = 139;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tiền bù xăng vượt Km";
            this.gridColumn9.DisplayFormat.FormatString = "###,##0.##";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn9.FieldName = "TienBuXangVuotKm";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsFilter.AllowFilter = false;
            this.gridColumn9.Width = 139;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tiền bù xăng trượt hàng";
            this.gridColumn10.DisplayFormat.FormatString = "###,##0.##";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn10.FieldName = "TienBuXangTruotHang";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsFilter.AllowFilter = false;
            this.gridColumn10.Width = 149;
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.AutoHeight = false;
            this.cboLoaiXe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiXe.Name = "cboLoaiXe";
            // 
            // ctmtXoa
            // 
            this.ctmtXoa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Xoa});
            this.ctmtXoa.Name = "ctmtXoa";
            this.ctmtXoa.Size = new System.Drawing.Size(95, 26);
            // 
            // Xoa
            // 
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(94, 22);
            this.Xoa.Text = "Xóa";
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(975, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phím Delete: xóa (Đơn vị: nghìn đồng)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grcDinhMuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 326);
            this.panel1.TabIndex = 2;
            // 
            // frm_VuotGioQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 353);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_VuotGioQuyDinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Định mức vượt giờ-km";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_VuotGioQuyDinh_FormClosing);
            this.Load += new System.EventHandler(this.frm_VuotGioQuyDinh_Load);
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDinhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDinhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiXe)).EndInit();
            this.ctmtXoa.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcDinhMuc;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDinhMuc;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboLoaiXe;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueXe;
        private System.Windows.Forms.ContextMenuStrip ctmtXoa;
        private System.Windows.Forms.ToolStripMenuItem Xoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}