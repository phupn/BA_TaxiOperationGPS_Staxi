namespace Taxi.GUI
{
    partial class frmHienThiBanDo_XeNhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHienThiBanDo_XeNhan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchType = new Taxi.Controls.Base.Inputs.InputRadioGroup();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTimXe = new System.Windows.Forms.TextBox();
            this.trackBarMap = new System.Windows.Forms.TrackBar();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLenhDTV = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLenhMK = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoDT = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDCDon = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.grcXeDonDeCu = new Taxi.Controls.Base.Controls.ShGridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.shBarManager = new Taxi.Controls.Base.Controls.ShBarManager();
            this.bar = new DevExpress.XtraBars.Bar();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.shImageCollection = new Taxi.Controls.Base.Controls.ShImageCollection();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcXeDonDeCu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.SearchType);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtTimXe);
            this.panel1.Location = new System.Drawing.Point(499, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 27);
            this.panel1.TabIndex = 13;
            // 
            // SearchType
            // 
            this.SearchType.EditValue = 1;
            this.SearchType.IsChangeText = false;
            this.SearchType.IsFocus = false;
            this.SearchType.Location = new System.Drawing.Point(45, 1);
            this.SearchType.Name = "SearchType";
            this.SearchType.Properties.Appearance.BackColor = System.Drawing.Color.Brown;
            this.SearchType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.SearchType.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SearchType.Properties.Appearance.Options.UseBackColor = true;
            this.SearchType.Properties.Appearance.Options.UseFont = true;
            this.SearchType.Properties.Appearance.Options.UseForeColor = true;
            this.SearchType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SearchType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "&GPS"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "&App LX")});
            this.SearchType.Size = new System.Drawing.Size(133, 25);
            this.SearchType.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(3, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Tìm &Xe";
            // 
            // txtTimXe
            // 
            this.txtTimXe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimXe.Location = new System.Drawing.Point(184, 3);
            this.txtTimXe.Name = "txtTimXe";
            this.txtTimXe.Size = new System.Drawing.Size(86, 20);
            this.txtTimXe.TabIndex = 0;
            this.txtTimXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimXe_KeyDown);
            // 
            // trackBarMap
            // 
            this.trackBarMap.Location = new System.Drawing.Point(9, 16);
            this.trackBarMap.Maximum = 22;
            this.trackBarMap.Minimum = 1;
            this.trackBarMap.Name = "trackBarMap";
            this.trackBarMap.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMap.Size = new System.Drawing.Size(45, 447);
            this.trackBarMap.TabIndex = 4;
            this.trackBarMap.Value = 1;
            this.trackBarMap.ValueChanged += new System.EventHandler(this.trackBarMap_ValueChanged);
            // 
            // MainMap
            // 
            this.MainMap.AllowDrawPolygon = false;
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(3, 16);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(778, 450);
            this.MainMap.TabIndex = 7;
            this.MainMap.Zoom = 0D;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.splitContainer.Panel1.Controls.Add(this.lblThoiGian);
            this.splitContainer.Panel1.Controls.Add(this.label7);
            this.splitContainer.Panel1.Controls.Add(this.lblGhiChu);
            this.splitContainer.Panel1.Controls.Add(this.label6);
            this.splitContainer.Panel1.Controls.Add(this.lblLenhDTV);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.lblLenhMK);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.lblSoDT);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.lblDCDon);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBox);
            this.splitContainer.Size = new System.Drawing.Size(784, 568);
            this.splitContainer.SplitterDistance = 95;
            this.splitContainer.TabIndex = 4;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGian.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblThoiGian.Location = new System.Drawing.Point(85, 9);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(18, 13);
            this.lblThoiGian.TabIndex = 11;
            this.lblThoiGian.Text = "tg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Thời gian : ";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblGhiChu.Location = new System.Drawing.Point(76, 49);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(52, 13);
            this.lblGhiChu.TabIndex = 9;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(12, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ghi chú : ";
            // 
            // lblLenhDTV
            // 
            this.lblLenhDTV.AutoSize = true;
            this.lblLenhDTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLenhDTV.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLenhDTV.Location = new System.Drawing.Point(573, 9);
            this.lblLenhDTV.Name = "lblLenhDTV";
            this.lblLenhDTV.Size = new System.Drawing.Size(57, 13);
            this.lblLenhDTV.TabIndex = 7;
            this.lblLenhDTV.Text = "Lệnh dtv";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(496, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Lệnh ĐTV : ";
            // 
            // lblLenhMK
            // 
            this.lblLenhMK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLenhMK.AutoSize = true;
            this.lblLenhMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLenhMK.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLenhMK.Location = new System.Drawing.Point(573, 29);
            this.lblLenhMK.Name = "lblLenhMK";
            this.lblLenhMK.Size = new System.Drawing.Size(51, 13);
            this.lblLenhMK.TabIndex = 5;
            this.lblLenhMK.Text = "lệnh mk";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(500, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lệnh MK :";
            // 
            // lblSoDT
            // 
            this.lblSoDT.AutoSize = true;
            this.lblSoDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSoDT.Location = new System.Drawing.Point(275, 9);
            this.lblSoDT.Name = "lblSoDT";
            this.lblSoDT.Size = new System.Drawing.Size(38, 13);
            this.lblSoDT.TabIndex = 3;
            this.lblSoDT.Text = "Số đt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(229, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số dt: ";
            // 
            // lblDCDon
            // 
            this.lblDCDon.AutoSize = true;
            this.lblDCDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCDon.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDCDon.Location = new System.Drawing.Point(97, 29);
            this.lblDCDon.Name = "lblDCDon";
            this.lblDCDon.Size = new System.Drawing.Size(73, 13);
            this.lblDCDon.TabIndex = 1;
            this.lblDCDon.Text = "Địa chỉ đón";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ đón : ";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.grcXeDonDeCu);
            this.groupBox.Controls.Add(this.panel1);
            this.groupBox.Controls.Add(this.trackBarMap);
            this.groupBox.Controls.Add(this.MainMap);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(784, 469);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Bản đồ";
            // 
            // grcXeDonDeCu
            // 
            this.grcXeDonDeCu.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcXeDonDeCu.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcXeDonDeCu.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcXeDonDeCu.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcXeDonDeCu.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcXeDonDeCu.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcXeDonDeCu.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grcXeDonDeCu.Location = new System.Drawing.Point(70, 23);
            this.grcXeDonDeCu.MainView = this.bandedGridView1;
            this.grcXeDonDeCu.Name = "grcXeDonDeCu";
            this.grcXeDonDeCu.Size = new System.Drawing.Size(216, 125);
            this.grcXeDonDeCu.TabIndex = 14;
            this.grcXeDonDeCu.UseEmbeddedNavigator = true;
            this.grcXeDonDeCu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            this.grcXeDonDeCu.Visible = false;
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bandedGridView1.Appearance.Row.Options.UseTextOptions = true;
            this.bandedGridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.ColumnPanelRowHeight = 39;
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2});
            this.bandedGridView1.GridControl = this.grcXeDonDeCu;
            this.bandedGridView1.GroupPanelText = "Kéo cột muốn nhóm vào đây";
            this.bandedGridView1.IndicatorWidth = 35;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand1.Caption = "Xe đón đề cử";
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.Columns.Add(this.bandedGridColumn2);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 220;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumn1.Caption = "Số xe";
            this.bandedGridColumn1.FieldName = "SoHieuXe";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 78;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumn2.Caption = "Giờ đón";
            this.bandedGridColumn2.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.bandedGridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.bandedGridColumn2.FieldName = "ThoiGian";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 142;
            // 
            // shBarManager
            // 
            this.shBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar});
            this.shBarManager.DockControls.Add(this.barDockControlTop);
            this.shBarManager.DockControls.Add(this.barDockControlBottom);
            this.shBarManager.DockControls.Add(this.barDockControlLeft);
            this.shBarManager.DockControls.Add(this.barDockControlRight);
            this.shBarManager.Form = this;
            this.shBarManager.Images = this.shImageCollection;
            this.shBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barSubItem2,
            this.barEditItem1,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barStaticItem1,
            this.barEditItem2,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8});
            this.shBarManager.MaxItemId = 13;
            this.shBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemTextEdit1});
            this.shBarManager.StatusBar = this.bar;
            // 
            // bar
            // 
            this.bar.BarName = "Status bar";
            this.bar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barStaticItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem6, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem7, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem8, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar.OptionsBar.AllowQuickCustomization = false;
            this.bar.OptionsBar.DrawDragBorder = false;
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "Status bar";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Địa điểm đón khách";
            this.barButtonItem3.Id = 5;
            this.barButtonItem3.ImageOptions.ImageIndex = 0;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Xe nhận(nổ máy) ";
            this.barStaticItem1.Id = 8;
            this.barStaticItem1.ImageOptions.ImageIndex = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Xe đang tắt máy";
            this.barButtonItem6.Id = 10;
            this.barButtonItem6.ImageOptions.ImageIndex = 2;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Xe nhận(nổ máy)";
            this.barButtonItem7.Id = 11;
            this.barButtonItem7.ImageOptions.ImageIndex = 3;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Xe nhận(tắt máy)";
            this.barButtonItem8.Id = 12;
            this.barButtonItem8.ImageOptions.ImageIndex = 4;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.shBarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(784, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 568);
            this.barDockControlBottom.Manager = this.shBarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(784, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.shBarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 568);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(784, 0);
            this.barDockControlRight.Manager = this.shBarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 568);
            // 
            // shImageCollection
            // 
            this.shImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("shImageCollection.ImageStream")));
            this.shImageCollection.Images.SetKeyName(0, "marker2.png");
            this.shImageCollection.Images.SetKeyName(1, "RentalCar.png");
            this.shImageCollection.Images.SetKeyName(2, "RentalCar2.png");
            this.shImageCollection.Images.SetKeyName(3, "Xe.PNG");
            this.shImageCollection.Images.SetKeyName(4, "XeTM.png");
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Địa điểm đón khách";
            this.barSubItem1.Id = 0;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Xe đang nổ máy";
            this.barSubItem2.Id = 1;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Edit = this.repositoryItemPictureEdit1;
            this.barEditItem1.EditWidth = 144;
            this.barEditItem1.Id = 2;
            this.barEditItem1.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.Actions_arrow_down_icon;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.ZoomAccelerationFactor = 1D;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Địa điểm đón khách |";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.Image = global::TaxiApplication.Properties.Resources.marker2;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Xe đang nổ máy |";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.ImageOptions.Image = global::TaxiApplication.Properties.Resources.RentalCar;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Xe nhận(nổ máy) |";
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.ImageOptions.Image = global::TaxiApplication.Properties.Resources.RentalCar2;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Xe nhận(tắt máy) |";
            this.barButtonItem5.Id = 7;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Edit = this.repositoryItemTextEdit1;
            this.barEditItem2.Id = 9;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // frmHienThiBanDo_XeNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 595);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = global::TaxiApplication.Properties.Resources.Taxi;
            this.Name = "frmHienThiBanDo_XeNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bản đồ GPS - Kiểm tra xe nhận";
            this.Load += new System.EventHandler(this.frmHienThiBanDo_XeNhan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcXeDonDeCu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarMap;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDCDon;
        private System.Windows.Forms.Label lblSoDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLenhMK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLenhDTV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label label7;
        private Taxi.Controls.ExtendedGMapControl MainMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTimXe;
        private Controls.Base.Inputs.InputRadioGroup SearchType;
        private System.Windows.Forms.GroupBox groupBox;
        private Controls.Base.Controls.ShGridControl grcXeDonDeCu;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private Controls.Base.Controls.ShBarManager shBarManager;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private Controls.Base.Controls.ShImageCollection shImageCollection;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
    }
}