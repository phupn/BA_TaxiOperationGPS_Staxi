namespace Taxi.GUI
{
    partial class frmDMDiaDanh
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkThemMoi = new System.Windows.Forms.LinkLabel();
            this.trvLoaiDiaDanh = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grcDiaDanh = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvDiaDanh = new Taxi.Controls.Base.Controls.ShGridView();
            this.colTenDiaDanh = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoTa = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.lnkSuaDiaDanh = new System.Windows.Forms.LinkLabel();
            this.lnkXoaDiaDanh = new System.Windows.Forms.LinkLabel();
            this.lnkThemDiaDanh = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.rdoDiaChi = new System.Windows.Forms.RadioButton();
            this.rdoTheoTen = new System.Windows.Forms.RadioButton();
            this.btnSearch = new Taxi.Controls.Base.Controls.ShButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDiaDanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDiaDanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkThemMoi);
            this.groupBox1.Controls.Add(this.trvLoaiDiaDanh);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 564);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Loại địa danh";
            // 
            // lnkThemMoi
            // 
            this.lnkThemMoi.AutoSize = true;
            this.lnkThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkThemMoi.Location = new System.Drawing.Point(6, 541);
            this.lnkThemMoi.Name = "lnkThemMoi";
            this.lnkThemMoi.Size = new System.Drawing.Size(61, 13);
            this.lnkThemMoi.TabIndex = 1;
            this.lnkThemMoi.TabStop = true;
            this.lnkThemMoi.Text = "Thêm mới";
            this.lnkThemMoi.Visible = false;
            this.lnkThemMoi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkThemMoi_LinkClicked);
            // 
            // trvLoaiDiaDanh
            // 
            this.trvLoaiDiaDanh.Location = new System.Drawing.Point(6, 19);
            this.trvLoaiDiaDanh.Name = "trvLoaiDiaDanh";
            this.trvLoaiDiaDanh.Size = new System.Drawing.Size(194, 515);
            this.trvLoaiDiaDanh.TabIndex = 0;
            this.trvLoaiDiaDanh.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvLoaiDiaDanh_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grcDiaDanh);
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.lnkSuaDiaDanh);
            this.groupBox2.Controls.Add(this.lnkXoaDiaDanh);
            this.groupBox2.Controls.Add(this.lnkThemDiaDanh);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(217, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 564);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin địa danh";
            // 
            // grcDiaDanh
            // 
            this.grcDiaDanh.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcDiaDanh.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcDiaDanh.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcDiaDanh.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcDiaDanh.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcDiaDanh.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcDiaDanh.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            gridLevelNode1.RelationName = "Level1";
            this.grcDiaDanh.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcDiaDanh.Location = new System.Drawing.Point(15, 96);
            this.grcDiaDanh.MainView = this.grvDiaDanh;
            this.grcDiaDanh.Name = "grcDiaDanh";
            this.grcDiaDanh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grcDiaDanh.Size = new System.Drawing.Size(540, 438);
            this.grcDiaDanh.TabIndex = 8;
            this.grcDiaDanh.UseEmbeddedNavigator = true;
            this.grcDiaDanh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDiaDanh});
            // 
            // grvDiaDanh
            // 
            this.grvDiaDanh.ActiveFilterEnabled = false;
            this.grvDiaDanh.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvDiaDanh.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDiaDanh.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDiaDanh.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDiaDanh.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grvDiaDanh.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvDiaDanh.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvDiaDanh.ColumnPanelRowHeight = 35;
            this.grvDiaDanh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenDiaDanh,
            this.gridColumn5,
            this.colMoTa,
            this.colDienThoai});
            this.grvDiaDanh.GridControl = this.grcDiaDanh;
            this.grvDiaDanh.IndicatorWidth = 35;
            this.grvDiaDanh.Name = "grvDiaDanh";
            this.grvDiaDanh.OptionsBehavior.Editable = false;
            this.grvDiaDanh.OptionsFilter.AllowColumnMRUFilterList = false;
            this.grvDiaDanh.OptionsFilter.AllowFilterEditor = false;
            this.grvDiaDanh.OptionsFind.AllowFindPanel = false;
            this.grvDiaDanh.OptionsView.ColumnAutoWidth = false;
            this.grvDiaDanh.OptionsView.ShowGroupPanel = false;
            // 
            // colTenDiaDanh
            // 
            this.colTenDiaDanh.Caption = "Tên địa danh";
            this.colTenDiaDanh.FieldName = "TenDiaDanh";
            this.colTenDiaDanh.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colTenDiaDanh.Name = "colTenDiaDanh";
            this.colTenDiaDanh.TagLanguage = null;
            this.colTenDiaDanh.Visible = true;
            this.colTenDiaDanh.VisibleIndex = 0;
            this.colTenDiaDanh.Width = 163;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.Caption = "Địa chỉ";
            this.gridColumn5.FieldName = "DiaChi";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 206;
            // 
            // colMoTa
            // 
            this.colMoTa.Caption = "Mô tả";
            this.colMoTa.FieldName = "MoTa";
            this.colMoTa.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colMoTa.Name = "colMoTa";
            this.colMoTa.TagLanguage = null;
            this.colMoTa.Visible = true;
            this.colMoTa.VisibleIndex = 2;
            this.colMoTa.Width = 188;
            // 
            // colDienThoai
            // 
            this.colDienThoai.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDienThoai.AppearanceCell.Options.UseFont = true;
            this.colDienThoai.AppearanceCell.Options.UseTextOptions = true;
            this.colDienThoai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDienThoai.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDienThoai.Caption = "Điện thoại";
            this.colDienThoai.FieldName = "DienThoai";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.OptionsColumn.AllowEdit = false;
            this.colDienThoai.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDienThoai.OptionsFilter.AllowAutoFilter = false;
            this.colDienThoai.OptionsFilter.AllowFilter = false;
            this.colDienThoai.Visible = true;
            this.colDienThoai.VisibleIndex = 3;
            this.colDienThoai.Width = 124;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemImageComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 2, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, 2)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(15, 536);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // lnkSuaDiaDanh
            // 
            this.lnkSuaDiaDanh.AutoSize = true;
            this.lnkSuaDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSuaDiaDanh.Location = new System.Drawing.Point(496, 541);
            this.lnkSuaDiaDanh.Name = "lnkSuaDiaDanh";
            this.lnkSuaDiaDanh.Size = new System.Drawing.Size(33, 13);
            this.lnkSuaDiaDanh.TabIndex = 6;
            this.lnkSuaDiaDanh.TabStop = true;
            this.lnkSuaDiaDanh.Text = "Sửa ";
            this.lnkSuaDiaDanh.Visible = false;
            this.lnkSuaDiaDanh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSuaDiaDanh_LinkClicked);
            // 
            // lnkXoaDiaDanh
            // 
            this.lnkXoaDiaDanh.AutoSize = true;
            this.lnkXoaDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkXoaDiaDanh.Location = new System.Drawing.Point(529, 541);
            this.lnkXoaDiaDanh.Name = "lnkXoaDiaDanh";
            this.lnkXoaDiaDanh.Size = new System.Drawing.Size(29, 13);
            this.lnkXoaDiaDanh.TabIndex = 5;
            this.lnkXoaDiaDanh.TabStop = true;
            this.lnkXoaDiaDanh.Text = "Xóa";
            this.lnkXoaDiaDanh.Visible = false;
            this.lnkXoaDiaDanh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkXoaDiaDanh_LinkClicked);
            // 
            // lnkThemDiaDanh
            // 
            this.lnkThemDiaDanh.AutoSize = true;
            this.lnkThemDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkThemDiaDanh.Location = new System.Drawing.Point(436, 541);
            this.lnkThemDiaDanh.Name = "lnkThemDiaDanh";
            this.lnkThemDiaDanh.Size = new System.Drawing.Size(61, 13);
            this.lnkThemDiaDanh.TabIndex = 4;
            this.lnkThemDiaDanh.TabStop = true;
            this.lnkThemDiaDanh.Text = "Thêm mới";
            this.lnkThemDiaDanh.Visible = false;
            this.lnkThemDiaDanh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkThemDiaDanh_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.txtTimKiem);
            this.groupBox3.Controls.Add(this.rdoDiaChi);
            this.groupBox3.Controls.Add(this.rdoTheoTen);
            this.groupBox3.Location = new System.Drawing.Point(15, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 70);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(57, 34);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(321, 20);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // rdoDiaChi
            // 
            this.rdoDiaChi.AutoSize = true;
            this.rdoDiaChi.Location = new System.Drawing.Point(148, 11);
            this.rdoDiaChi.Name = "rdoDiaChi";
            this.rdoDiaChi.Size = new System.Drawing.Size(97, 17);
            this.rdoDiaChi.TabIndex = 1;
            this.rdoDiaChi.Text = "&2. Theo địa chỉ";
            this.rdoDiaChi.UseVisualStyleBackColor = true;
            // 
            // rdoTheoTen
            // 
            this.rdoTheoTen.AutoSize = true;
            this.rdoTheoTen.Checked = true;
            this.rdoTheoTen.Location = new System.Drawing.Point(57, 11);
            this.rdoTheoTen.Name = "rdoTheoTen";
            this.rdoTheoTen.Size = new System.Drawing.Size(80, 17);
            this.rdoTheoTen.TabIndex = 0;
            this.rdoTheoTen.TabStop = true;
            this.rdoTheoTen.Text = "&1. Theo tên";
            this.rdoTheoTen.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(384, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmDMDiaDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = global::TaxiApplication.Properties.Resources.Telephone_01;
            this.Name = "frmDMDiaDanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục địa danh";
            this.Load += new System.EventHandler(this.frmDMDiaDanh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDiaDanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDiaDanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView trvLoaiDiaDanh;
        private System.Windows.Forms.LinkLabel lnkThemMoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoDiaChi;
        private System.Windows.Forms.RadioButton rdoTheoTen;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.LinkLabel lnkSuaDiaDanh;
        private System.Windows.Forms.LinkLabel lnkXoaDiaDanh;
        private System.Windows.Forms.LinkLabel lnkThemDiaDanh;
        private Controls.Base.Controls.ShButton btnThoat;
        private Controls.Base.Controls.ShGridControl grcDiaDanh;
        private Controls.Base.Controls.ShGridView grvDiaDanh;
        private Controls.Base.Controls.Grids.GridColumn colTenDiaDanh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private Controls.Base.Controls.Grids.GridColumn colMoTa;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private Controls.Base.Controls.ShButton btnSearch;
    }
}