using Taxi.Controls.Base.Controls;
namespace Taxi.Controls.ThueBaoTuyen
{
    partial class frm_BangGiaCuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BangGiaCuoc));
            this.label1 = new System.Windows.Forms.Label();
            this.lueDiemXuatPhat = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDsTuyen = new System.Windows.Forms.Label();
            this.lbDsTuyen = new System.Windows.Forms.ListBox();
            this.lblTuyen1 = new System.Windows.Forms.Label();
            this.lblTuyen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lueChayTuyen = new DevExpress.XtraEditors.LookUpEdit();
            this.pnTuyen2 = new System.Windows.Forms.Panel();
            this.grcBangGia = new DevExpress.XtraGrid.GridControl();
            this.grvBangGia = new Taxi.Controls.Base.Controls.ShGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueLoaiXe = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnTuyen3 = new System.Windows.Forms.Panel();
            this.pnTuyen1 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.lblHelp_Xoa = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDiemXuatPhat.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChayTuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBangGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBangGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiXe)).BeginInit();
            this.pnTuyen1.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Size = new System.Drawing.Size(1005, 27);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Điểm xuất phát";
            // 
            // lueDiemXuatPhat
            // 
            this.lueDiemXuatPhat.Location = new System.Drawing.Point(6, 22);
            this.lueDiemXuatPhat.Name = "lueDiemXuatPhat";
            this.lueDiemXuatPhat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lueDiemXuatPhat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDiemXuatPhat.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDiemXuatPhat", "Điểm xuất phát")});
            this.lueDiemXuatPhat.Properties.NullText = "Điểm xuất phát";
            this.lueDiemXuatPhat.Size = new System.Drawing.Size(141, 20);
            this.lueDiemXuatPhat.TabIndex = 0;
            this.lueDiemXuatPhat.EditValueChanged += new System.EventHandler(this.lueDiemXuatPhat_EditValueChanged);
            // 
            // lblDsTuyen
            // 
            this.lblDsTuyen.AutoSize = true;
            this.lblDsTuyen.Location = new System.Drawing.Point(3, 96);
            this.lblDsTuyen.Name = "lblDsTuyen";
            this.lblDsTuyen.Size = new System.Drawing.Size(88, 13);
            this.lblDsTuyen.TabIndex = 4;
            this.lblDsTuyen.Text = "Danh sách tuyến";
            // 
            // lbDsTuyen
            // 
            this.lbDsTuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbDsTuyen.FormattingEnabled = true;
            this.lbDsTuyen.Location = new System.Drawing.Point(6, 121);
            this.lbDsTuyen.Name = "lbDsTuyen";
            this.lbDsTuyen.Size = new System.Drawing.Size(141, 485);
            this.lbDsTuyen.TabIndex = 3;
            this.lbDsTuyen.SelectedIndexChanged += new System.EventHandler(this.lbDsTuyen_SelectedIndexChanged);
            // 
            // lblTuyen1
            // 
            this.lblTuyen1.AutoSize = true;
            this.lblTuyen1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyen1.Location = new System.Drawing.Point(14, 9);
            this.lblTuyen1.Name = "lblTuyen1";
            this.lblTuyen1.Size = new System.Drawing.Size(46, 13);
            this.lblTuyen1.TabIndex = 7;
            this.lblTuyen1.Text = "Tuyến:";
            // 
            // lblTuyen
            // 
            this.lblTuyen.AutoSize = true;
            this.lblTuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyen.Location = new System.Drawing.Point(75, 9);
            this.lblTuyen.Name = "lblTuyen";
            this.lblTuyen.Size = new System.Drawing.Size(0, 13);
            this.lblTuyen.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(807, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lueChayTuyen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lueDiemXuatPhat);
            this.panel1.Controls.Add(this.lblDsTuyen);
            this.panel1.Controls.Add(this.lbDsTuyen);
            this.panel1.Location = new System.Drawing.Point(3, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 625);
            this.panel1.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Chạy tuyến";
            // 
            // lueChayTuyen
            // 
            this.lueChayTuyen.Location = new System.Drawing.Point(6, 67);
            this.lueChayTuyen.Name = "lueChayTuyen";
            this.lueChayTuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChayTuyen.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ChayTuyen", "Chạy tuyến")});
            this.lueChayTuyen.Properties.NullText = "Chạy tuyến";
            this.lueChayTuyen.Size = new System.Drawing.Size(141, 20);
            this.lueChayTuyen.TabIndex = 1;
            this.lueChayTuyen.EditValueChanged += new System.EventHandler(this.lueChayTuyen_EditValueChanged);
            // 
            // pnTuyen2
            // 
            this.pnTuyen2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnTuyen2.Location = new System.Drawing.Point(0, 0);
            this.pnTuyen2.Name = "pnTuyen2";
            this.pnTuyen2.Size = new System.Drawing.Size(832, 606);
            this.pnTuyen2.TabIndex = 7;
            // 
            // grcBangGia
            // 
            this.grcBangGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grcBangGia.Location = new System.Drawing.Point(0, 35);
            this.grcBangGia.MainView = this.grvBangGia;
            this.grcBangGia.Name = "grcBangGia";
            this.grcBangGia.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueLoaiXe});
            this.grcBangGia.Size = new System.Drawing.Size(832, 571);
            this.grcBangGia.TabIndex = 6;
            this.grcBangGia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBangGia});
            this.grcBangGia.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grcBangGia_ProcessGridKey);
            // 
            // grvBangGia
            // 
            this.grvBangGia.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvBangGia.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBangGia.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvBangGia.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvBangGia.ColumnPanelRowHeight = 80;
            this.grvBangGia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn4});
            this.grvBangGia.GridControl = this.grcBangGia;
            this.grvBangGia.IndicatorWidth = 30;
            this.grvBangGia.Name = "grvBangGia";
            this.grvBangGia.NewItemRowText = "Thêm dữ liệu";
            this.grvBangGia.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvBangGia.OptionsView.ShowGroupedColumns = true;
            this.grvBangGia.OptionsView.ShowGroupPanel = false;
            this.grvBangGia.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvBangGia_InvalidRowException);
            this.grvBangGia.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvBangGia_ValidateRow);
            this.grvBangGia.Click += new System.EventHandler(this.grvBangGia_Click);
            this.grvBangGia.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.grvBangGia_InvalidValueException);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Loại xe";
            this.gridColumn1.ColumnEdit = this.lueLoaiXe;
            this.gridColumn1.FieldName = "FK_LoaiXeID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // lueLoaiXe
            // 
            this.lueLoaiXe.AutoHeight = false;
            this.lueLoaiXe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLoaiXe.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoaiXe", "Loại xe")});
            this.lueLoaiXe.Name = "lueLoaiXe";
            this.lueLoaiXe.NullText = "Loại xe";
            this.lueLoaiXe.EditValueChanged += new System.EventHandler(this.lueLoaiXe_EditValueChanged);
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Km 1 chiều";
            this.gridColumn2.FieldName = "KmQuyDinh1Chieu";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 61;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "TG 1 chiều (Giờ)";
            this.gridColumn3.FieldName = "ThoiGianQuyDinh1Chieu";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 61;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn5.Caption = "Km 2 chiều";
            this.gridColumn5.FieldName = "KmQuyDinh2Chieu";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 61;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn6.Caption = "TG 2 chiều (Giờ)";
            this.gridColumn6.FieldName = "ThoiGianQuyDinh2Chieu";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 61;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn7.Caption = "Giá tiền 2 chiều";
            this.gridColumn7.FieldName = "GiaTien2Chieu";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 61;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn8.Caption = "Vượt 1 giờ 1 chiều ";
            this.gridColumn8.FieldName = "GiaDinhMucVuot1GioMotChieu";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsFilter.AllowFilter = false;
            this.gridColumn8.Width = 61;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn9.Caption = "Vượt 1 km 1 chiều ";
            this.gridColumn9.FieldName = "GiaDinhMucVuot1KmMotChieu";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsFilter.AllowFilter = false;
            this.gridColumn9.Width = 61;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn10.Caption = "Vượt 1 giờ 2 chiều ";
            this.gridColumn10.FieldName = "GiaDinhMucVuot1GioHaiChieu";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsFilter.AllowFilter = false;
            this.gridColumn10.Width = 61;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn11.Caption = "Vượt 1 km 2 chiều";
            this.gridColumn11.FieldName = "GiaDinhMucVuot1KmHaiChieu";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsFilter.AllowFilter = false;
            this.gridColumn11.Width = 61;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn12.Caption = "Vé trạm";
            this.gridColumn12.FieldName = "VeTram";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsFilter.AllowFilter = false;
            this.gridColumn12.Width = 97;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.Caption = "Giá tiền 1 chiều";
            this.gridColumn4.FieldName = "GiaTien1Chieu";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 61;
            // 
            // pnTuyen3
            // 
            this.pnTuyen3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnTuyen3.Location = new System.Drawing.Point(0, 0);
            this.pnTuyen3.Name = "pnTuyen3";
            this.pnTuyen3.Size = new System.Drawing.Size(832, 606);
            this.pnTuyen3.TabIndex = 1;
            // 
            // pnTuyen1
            // 
            this.pnTuyen1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnTuyen1.Controls.Add(this.labelControl1);
            this.pnTuyen1.Controls.Add(this.lblTuyen);
            this.pnTuyen1.Controls.Add(this.lblTuyen1);
            this.pnTuyen1.Controls.Add(this.grcBangGia);
            this.pnTuyen1.Location = new System.Drawing.Point(158, 45);
            this.pnTuyen1.Name = "pnTuyen1";
            this.pnTuyen1.Size = new System.Drawing.Size(832, 606);
            this.pnTuyen1.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(734, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Đơn vị : Nghìn đồng";
            // 
            // pnLeft
            // 
            this.pnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLeft.Controls.Add(this.pnTuyen2);
            this.pnLeft.Controls.Add(this.pnTuyen3);
            this.pnLeft.Location = new System.Drawing.Point(160, 44);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(834, 614);
            this.pnLeft.TabIndex = 13;
            // 
            // lblHelp_Xoa
            // 
            this.lblHelp_Xoa.Location = new System.Drawing.Point(872, 30);
            this.lblHelp_Xoa.Name = "lblHelp_Xoa";
            this.lblHelp_Xoa.Size = new System.Drawing.Size(115, 13);
            this.lblHelp_Xoa.TabIndex = 10;
            this.lblHelp_Xoa.Text = "Bấm phím Delete để xóa";
            // 
            // frm_BangGiaCuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 662);
            this.Controls.Add(this.pnTuyen1);
            this.Controls.Add(this.lblHelp_Xoa);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_BangGiaCuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng giá cước";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_BangGiaCuoc_FormClosing);
            this.Load += new System.EventHandler(this.frm_BangGiaCuoc_Load);
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnLeft, 0);
            this.Controls.SetChildIndex(this.lblHelp_Xoa, 0);
            this.Controls.SetChildIndex(this.pnTuyen1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDiemXuatPhat.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChayTuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBangGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBangGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiXe)).EndInit();
            this.pnTuyen1.ResumeLayout(false);
            this.pnTuyen1.PerformLayout();
            this.pnLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lueDiemXuatPhat;
        private System.Windows.Forms.Label lblDsTuyen;
        private System.Windows.Forms.ListBox lbDsTuyen;
        private System.Windows.Forms.Label lblTuyen1;
        private System.Windows.Forms.Label lblTuyen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lueChayTuyen;
        private System.Windows.Forms.Panel pnTuyen2;
        //private Taxi.Controls.Ctrl_TinhTienKm_CA ctrl_TinhTienKm_CA1;
        private System.Windows.Forms.Panel pnTuyen3;
        //private Taxi.Controls.Ctrl_TinhTienKm_METER ctrl_TinhTienKm_METER1;
        private DevExpress.XtraGrid.GridControl grcBangGia;
        private ShGridView grvBangGia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueLoaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Panel pnTuyen1;
        private System.Windows.Forms.Panel pnLeft;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblHelp_Xoa;
    }
}