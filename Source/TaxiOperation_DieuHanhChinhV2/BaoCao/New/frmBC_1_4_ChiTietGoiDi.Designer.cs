namespace Taxi.GUI.BaoCao
{
    partial class frmBC_1_4_BCChiTietGoiDi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_1_4_BCChiTietGoiDi));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.player = new Alvas.Audio.Player();
            this.tbPosition = new System.Windows.Forms.TrackBar();
            this.btnPause = new System.Windows.Forms.Button();
            this.ilButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.timeThoiGianDamThoai = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLine = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNVID = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPhanLoaiMay = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.panelBody = new DevExpress.XtraEditors.PanelControl();
            this.gridChiTietGoiDi = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.gridViewChiTietGoiDi = new Taxi.Controls.Base.Controls.Grids.GridView();
            this.gridColumn1 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn2 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn3 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn4 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn5 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn6 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn7 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBody)).BeginInit();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTietGoiDi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTietGoiDi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO CUỘC GỌI ĐI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(155, 37);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(143, 21);
            this.calTuNgay.TabIndex = 2;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // calDenNgay
            // 
            this.calDenNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Location = new System.Drawing.Point(385, 36);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(143, 21);
            this.calDenNgay.TabIndex = 4;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(294, 128);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(210, 128);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // player
            // 
            this.player.FileName = "";
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(192, 159);
            this.tbPosition.Margin = new System.Windows.Forms.Padding(2);
            this.tbPosition.Maximum = 100;
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(492, 45);
            this.tbPosition.TabIndex = 16;
            this.tbPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPause.ImageIndex = 2;
            this.btnPause.ImageList = this.ilButtons;
            this.btnPause.Location = new System.Drawing.Point(60, 159);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(63, 21);
            this.btnPause.TabIndex = 15;
            this.btnPause.Text = "Pause";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // ilButtons
            // 
            this.ilButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilButtons.ImageStream")));
            this.ilButtons.TransparentColor = System.Drawing.Color.Silver;
            this.ilButtons.Images.SetKeyName(0, "");
            this.ilButtons.Images.SetKeyName(1, "");
            this.ilButtons.Images.SetKeyName(2, "");
            this.ilButtons.Images.SetKeyName(3, "");
            this.ilButtons.Images.SetKeyName(4, "");
            // 
            // btnPlay
            // 
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.ImageIndex = 1;
            this.btnPlay.ImageList = this.ilButtons;
            this.btnPlay.Location = new System.Drawing.Point(11, 159);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(49, 21);
            this.btnPlay.TabIndex = 13;
            this.btnPlay.Text = "Play";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.ImageIndex = 3;
            this.btnStop.ImageList = this.ilButtons;
            this.btnStop.Location = new System.Drawing.Point(127, 159);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(61, 21);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Thời gian gọi trên:";
            // 
            // timeThoiGianDamThoai
            // 
            this.timeThoiGianDamThoai.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.timeThoiGianDamThoai.CustomFormat = "HH:mm:ss";
            this.timeThoiGianDamThoai.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.timeThoiGianDamThoai.DropDownCalendar.FirstMonth = new System.DateTime(2008, 11, 1, 0, 0, 0, 0);
            this.timeThoiGianDamThoai.DropDownCalendar.Name = "";
            this.timeThoiGianDamThoai.Location = new System.Drawing.Point(155, 68);
            this.timeThoiGianDamThoai.MinuteIncrement = 1;
            this.timeThoiGianDamThoai.Name = "timeThoiGianDamThoai";
            this.timeThoiGianDamThoai.SecondIncrement = 1;
            this.timeThoiGianDamThoai.ShowDropDown = false;
            this.timeThoiGianDamThoai.ShowUpDown = true;
            this.timeThoiGianDamThoai.Size = new System.Drawing.Size(80, 21);
            this.timeThoiGianDamThoai.TabIndex = 37;
            this.timeThoiGianDamThoai.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.timeThoiGianDamThoai.ValueChanged += new System.EventHandler(this.timeThoiGianDamThoai_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Điện thoại";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(327, 68);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(90, 21);
            this.txtPhoneNumber.TabIndex = 39;
            this.txtPhoneNumber.TextChanged += new System.EventHandler(this.txtPhoneNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "(Tìm tương đối : 4568 ,có chuỗi số 4568)";
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(155, 94);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(80, 21);
            this.txtLine.TabIndex = 42;
            this.txtLine.TextChanged += new System.EventHandler(this.txtLine_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Line";
            // 
            // txtNVID
            // 
            this.txtNVID.Location = new System.Drawing.Point(328, 94);
            this.txtNVID.Name = "txtNVID";
            this.txtNVID.Size = new System.Drawing.Size(89, 21);
            this.txtNVID.TabIndex = 44;
            this.txtNVID.TextChanged += new System.EventHandler(this.txtNVID_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(283, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "NVID";
            // 
            // cboPhanLoaiMay
            // 
            this.cboPhanLoaiMay.DisplayMember = "Text";
            this.cboPhanLoaiMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhanLoaiMay.Items.AddRange(new object[] {
            "Tất cả"});
            this.cboPhanLoaiMay.Location = new System.Drawing.Point(523, 92);
            this.cboPhanLoaiMay.Name = "cboPhanLoaiMay";
            this.cboPhanLoaiMay.Size = new System.Drawing.Size(161, 21);
            this.cboPhanLoaiMay.TabIndex = 46;
            this.cboPhanLoaiMay.ValueMember = "id";
            this.cboPhanLoaiMay.SelectedIndexChanged += new System.EventHandler(this.cboPhanLoaiMay_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(457, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Phân loại";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.cboPhanLoaiMay);
            this.panelTop.Controls.Add(this.tbPosition);
            this.panelTop.Controls.Add(this.label9);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.txtNVID);
            this.panelTop.Controls.Add(this.calTuNgay);
            this.panelTop.Controls.Add(this.label8);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.txtLine);
            this.panelTop.Controls.Add(this.calDenNgay);
            this.panelTop.Controls.Add(this.label7);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.label6);
            this.panelTop.Controls.Add(this.btnExportExcel);
            this.panelTop.Controls.Add(this.txtPhoneNumber);
            this.panelTop.Controls.Add(this.btnStop);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.btnPlay);
            this.panelTop.Controls.Add(this.timeThoiGianDamThoai);
            this.panelTop.Controls.Add(this.btnPause);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(753, 218);
            this.panelTop.TabIndex = 47;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.gridChiTietGoiDi);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 218);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(753, 332);
            this.panelBody.TabIndex = 48;
            // 
            // gridChiTietGoiDi
            // 
            this.gridChiTietGoiDi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChiTietGoiDi.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridChiTietGoiDi.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridChiTietGoiDi.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridChiTietGoiDi.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridChiTietGoiDi.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridChiTietGoiDi.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridChiTietGoiDi.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridChiTietGoiDi.Location = new System.Drawing.Point(2, 2);
            this.gridChiTietGoiDi.MainView = this.gridViewChiTietGoiDi;
            this.gridChiTietGoiDi.Name = "gridChiTietGoiDi";
            this.gridChiTietGoiDi.Size = new System.Drawing.Size(749, 328);
            this.gridChiTietGoiDi.TabIndex = 10;
            this.gridChiTietGoiDi.UseEmbeddedNavigator = true;
            this.gridChiTietGoiDi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewChiTietGoiDi});
            // 
            // gridViewChiTietGoiDi
            // 
            this.gridViewChiTietGoiDi.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridViewChiTietGoiDi.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewChiTietGoiDi.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewChiTietGoiDi.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewChiTietGoiDi.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewChiTietGoiDi.Appearance.Row.Options.UseTextOptions = true;
            this.gridViewChiTietGoiDi.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewChiTietGoiDi.ColumnPanelRowHeight = 30;
            this.gridViewChiTietGoiDi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridViewChiTietGoiDi.GridControl = this.gridChiTietGoiDi;
            this.gridViewChiTietGoiDi.GroupPanelText = "Kéo cột muốn nhóm vào đây";
            this.gridViewChiTietGoiDi.IndicatorWidth = 35;
            this.gridViewChiTietGoiDi.Name = "gridViewChiTietGoiDi";
            this.gridViewChiTietGoiDi.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewChiTietGoiDi.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gridViewChiTietGoiDi.OptionsBehavior.Editable = false;
            this.gridViewChiTietGoiDi.OptionsCustomization.AllowFilter = false;
            this.gridViewChiTietGoiDi.OptionsCustomization.AllowGroup = false;
            this.gridViewChiTietGoiDi.OptionsMenu.EnableColumnMenu = false;
            this.gridViewChiTietGoiDi.OptionsMenu.EnableFooterMenu = false;
            this.gridViewChiTietGoiDi.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewChiTietGoiDi.OptionsSelection.MultiSelect = true;
            this.gridViewChiTietGoiDi.OptionsView.ColumnAutoWidth = false;
            this.gridViewChiTietGoiDi.OptionsView.ShowGroupPanel = false;
            this.gridViewChiTietGoiDi.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewChiTietGoiDi_CustomColumnDisplayText);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Line";
            this.gridColumn1.FieldName = "Line";
            this.gridColumn1.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.TagLanguage = null;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 82;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Thời điểm gọi";
            this.gridColumn2.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn2.FieldName = "ThoiDiemGoi";
            this.gridColumn2.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.TagLanguage = null;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 135;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Điện thoại";
            this.gridColumn3.FieldName = "PhoneNumber";
            this.gridColumn3.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.TagLanguage = null;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 140;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Độ dài cuộc gọi";
            this.gridColumn4.FieldName = "DoDaiCuocGoi";
            this.gridColumn4.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.TagLanguage = null;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 102;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tên nhân viên";
            this.gridColumn5.FieldName = "FULLNAME";
            this.gridColumn5.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.TagLanguage = null;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 140;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Phân loại";
            this.gridColumn6.FieldName = "ThuocViTriGoi";
            this.gridColumn6.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.TagLanguage = null;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 110;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Đường dẫn file ghi âm";
            this.gridColumn7.FieldName = "VoiceFilePath";
            this.gridColumn7.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.TagLanguage = null;
            // 
            // frmBC_1_4_BCChiTietGoiDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 550);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_1_4_BCChiTietGoiDi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1.4- Bao cao cuoc goi di";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBody)).EndInit();
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTietGoiDi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTietGoiDi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Alvas.Audio.Player player;
        private System.Windows.Forms.TrackBar tbPosition;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ImageList ilButtons;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo timeThoiGianDamThoai;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.GridEX.EditControls.EditBox txtPhoneNumber;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.EditControls.EditBox txtLine;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.GridEX.EditControls.EditBox txtNVID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboPhanLoaiMay;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.PanelControl panelBody;
        private Controls.Base.Controls.Grids.GridControl gridChiTietGoiDi;
        private Controls.Base.Controls.Grids.GridView gridViewChiTietGoiDi;
        private Controls.Base.Controls.Grids.GridColumn gridColumn1;
        private Controls.Base.Controls.Grids.GridColumn gridColumn2;
        private Controls.Base.Controls.Grids.GridColumn gridColumn3;
        private Controls.Base.Controls.Grids.GridColumn gridColumn4;
        private Controls.Base.Controls.Grids.GridColumn gridColumn5;
        private Controls.Base.Controls.Grids.GridColumn gridColumn6;
        private Controls.Base.Controls.Grids.GridColumn gridColumn7;
       
    }
}