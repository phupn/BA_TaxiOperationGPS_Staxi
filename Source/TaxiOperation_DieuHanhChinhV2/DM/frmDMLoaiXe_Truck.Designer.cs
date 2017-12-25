namespace TaxiOperation_BanCo.DM
{
    partial class frmDMLoaiXe_Truck
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
            this.pnDMGara = new System.Windows.Forms.Panel();
            this.btnXoa = new Taxi.Controls.Base.Controls.ShButton();
            this.btnSua = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.grcDMLoaiXe = new DevExpress.XtraGrid.GridControl();
            this.grvDMLoaiXe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ForeColor_Re = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BackColor_Re = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Font = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnDMGara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDMLoaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDMLoaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForeColor_Re)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackColor_Re)).BeginInit();
            this.SuspendLayout();
            // 
           
            // 
            // pnDMGara
            // 
            this.pnDMGara.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnDMGara.Controls.Add(this.btnXoa);
            this.pnDMGara.Controls.Add(this.btnSua);
            this.pnDMGara.Controls.Add(this.btnLuu);
            this.pnDMGara.Controls.Add(this.grcDMLoaiXe);
            this.pnDMGara.Location = new System.Drawing.Point(0, 34);
            this.pnDMGara.Name = "pnDMGara";
            this.pnDMGara.Size = new System.Drawing.Size(803, 552);
            this.pnDMGara.TabIndex = 3;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.KeyCommand = System.Windows.Forms.Keys.F9;
            this.btnXoa.Location = new System.Drawing.Point(711, 514);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(84, 34);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa (F9)";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.KeyCommand = System.Windows.Forms.Keys.F4;
            this.btnSua.Location = new System.Drawing.Point(621, 514);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(84, 34);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa (F4)";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.KeyCommand = System.Windows.Forms.Keys.F1;
            this.btnLuu.Location = new System.Drawing.Point(508, 514);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(107, 34);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Thêm mới (F1)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // grcDMLoaiXe
            // 
            this.grcDMLoaiXe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grcDMLoaiXe.Location = new System.Drawing.Point(0, 0);
            this.grcDMLoaiXe.MainView = this.grvDMLoaiXe;
            this.grcDMLoaiXe.Name = "grcDMLoaiXe";
            this.grcDMLoaiXe.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ForeColor_Re,
            this.BackColor_Re});
            this.grcDMLoaiXe.Size = new System.Drawing.Size(803, 509);
            this.grcDMLoaiXe.TabIndex = 0;
            this.grcDMLoaiXe.TabStop = false;
            this.grcDMLoaiXe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDMLoaiXe});
            this.grcDMLoaiXe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grcDMLoaiXe_KeyPress);
            // 
            // grvDMLoaiXe
            // 
            this.grvDMLoaiXe.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDMLoaiXe.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDMLoaiXe.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvDMLoaiXe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn6,
            this.gridColumn7,
            this.Font});
            this.grvDMLoaiXe.GridControl = this.grcDMLoaiXe;
            this.grvDMLoaiXe.IndicatorWidth = 40;
            this.grvDMLoaiXe.Name = "grvDMLoaiXe";
            this.grvDMLoaiXe.OptionsCustomization.AllowFilter = false;
            this.grvDMLoaiXe.OptionsView.ShowGroupPanel = false;
            this.grvDMLoaiXe.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvDMLoaiXe_CustomDrawRowIndicator);
            this.grvDMLoaiXe.DoubleClick += new System.EventHandler(this.grvDMLoaiXe_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên loại xe";
            this.gridColumn1.FieldName = "TenLoaiXe";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 78;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Hãng xe";
            this.gridColumn2.FieldName = "HangXe";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 78;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kích thước";
            this.gridColumn3.FieldName = "KichThuoc";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 65;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tải trọng quy định";
            this.gridColumn4.FieldName = "TaiTrongQuyDinh";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 105;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tải trọng cho phép";
            this.gridColumn5.FieldName = "TaiTrongChoPhep";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 104;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Màu chữ";
            this.gridColumn8.ColumnEdit = this.ForeColor_Re;
            this.gridColumn8.FieldName = "ForeColor";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 54;
            // 
            // ForeColor_Re
            // 
            this.ForeColor_Re.AutoHeight = false;
            this.ForeColor_Re.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None),new DevExpress.Utils.AppearanceObject(), "", null, null, true)});
            this.ForeColor_Re.Name = "ForeColor_Re";
            this.ForeColor_Re.ShowCustomColors = false;
            this.ForeColor_Re.ShowSystemColors = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Màu nền";
            this.gridColumn9.ColumnEdit = this.BackColor_Re;
            this.gridColumn9.FieldName = "BackColor";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 50;
            // 
            // BackColor_Re
            // 
            this.BackColor_Re.AutoHeight = false;
            this.BackColor_Re.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BackColor_Re.Name = "BackColor_Re";
            this.BackColor_Re.ShowCustomColors = false;
            this.BackColor_Re.ShowSystemColors = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Phím tắt";
            this.gridColumn6.FieldName = "PhimTat";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 72;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Viết tắt";
            this.gridColumn7.FieldName = "VietTat";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 59;
            // 
            // Font
            // 
            this.Font.Caption = "Font";
            this.Font.FieldName = "Font";
            this.Font.Name = "Font";
            this.Font.OptionsColumn.AllowEdit = false;
            this.Font.OptionsColumn.AllowFocus = false;
            this.Font.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Font.OptionsFilter.AllowAutoFilter = false;
            this.Font.OptionsFilter.AllowFilter = false;
            this.Font.Visible = true;
            this.Font.VisibleIndex = 9;
            this.Font.Width = 96;
            // 
            // frmDMLoaiXe_Truck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 586);
            this.Controls.Add(this.pnDMGara);
            this.Name = "frmDMLoaiXe_Truck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục loại xe";
            this.Controls.SetChildIndex(this.pnDMGara, 0);
            this.pnDMGara.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDMLoaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDMLoaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForeColor_Re)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackColor_Re)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnDMGara;
        private Taxi.Controls.Base.Controls.ShButton btnXoa;
        private Taxi.Controls.Base.Controls.ShButton btnSua;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private DevExpress.XtraGrid.GridControl grcDMLoaiXe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDMLoaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn Font;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit ForeColor_Re;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit BackColor_Re;
    }
}