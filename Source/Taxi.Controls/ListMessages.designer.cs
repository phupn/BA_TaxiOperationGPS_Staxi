namespace Taxi.Controls
{
    partial class ListMessages
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMessage = new System.Windows.Forms.TabControl();
            this.tabNoiDung = new System.Windows.Forms.TabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnDaDoc = new System.Windows.Forms.Button();
            this.grpNoiDung = new System.Windows.Forms.GroupBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDMessage = new System.Windows.Forms.TextBox();
            this.lblNguoiNhan = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.tabDSTinNhan = new System.Windows.Forms.TabPage();
            this.chkTrangThai = new DevExpress.XtraEditors.CheckEdit();
            this.calDateSearch = new Taxi.Controls.Base.Inputs.InputDate();
            this.grdContent = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grcContent = new Taxi.Controls.Base.Controls.ShGridView();
            this.grcUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcIPAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcContents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcListToUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.txtNDTinNhan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabMessage.SuspendLayout();
            this.tabNoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.grpNoiDung.SuspendLayout();
            this.tabDSTinNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTrangThai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDateSearch.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDateSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcContent)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMessage
            // 
            this.tabMessage.Controls.Add(this.tabNoiDung);
            this.tabMessage.Controls.Add(this.tabDSTinNhan);
            this.tabMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMessage.ItemSize = new System.Drawing.Size(55, 18);
            this.tabMessage.Location = new System.Drawing.Point(0, 0);
            this.tabMessage.Name = "tabMessage";
            this.tabMessage.SelectedIndex = 0;
            this.tabMessage.Size = new System.Drawing.Size(661, 426);
            this.tabMessage.TabIndex = 2;
            this.tabMessage.SelectedIndexChanged += new System.EventHandler(this.tabMessage_SelectedIndexChanged);
            // 
            // tabNoiDung
            // 
            this.tabNoiDung.Controls.Add(this.groupControl1);
            this.tabNoiDung.Location = new System.Drawing.Point(4, 22);
            this.tabNoiDung.Name = "tabNoiDung";
            this.tabNoiDung.Padding = new System.Windows.Forms.Padding(3);
            this.tabNoiDung.Size = new System.Drawing.Size(653, 400);
            this.tabNoiDung.TabIndex = 0;
            this.tabNoiDung.Text = "Nội dung";
            this.tabNoiDung.UseVisualStyleBackColor = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblStatus);
            this.groupControl1.Controls.Add(this.btnDaDoc);
            this.groupControl1.Controls.Add(this.grpNoiDung);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtIDMessage);
            this.groupControl1.Controls.Add(this.lblNguoiNhan);
            this.groupControl1.Controls.Add(this.lblThoiGian);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.lblTieuDe);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(647, 394);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Thông tin tin nhắn";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(566, 38);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "status";
            this.lblStatus.Visible = false;
            // 
            // btnDaDoc
            // 
            this.btnDaDoc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDaDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaDoc.Location = new System.Drawing.Point(569, 65);
            this.btnDaDoc.Name = "btnDaDoc";
            this.btnDaDoc.Size = new System.Drawing.Size(75, 56);
            this.btnDaDoc.TabIndex = 20;
            this.btnDaDoc.Text = "Đã đọc\r\n(Enter)";
            this.btnDaDoc.UseVisualStyleBackColor = true;
            // 
            // grpNoiDung
            // 
            this.grpNoiDung.AutoSize = true;
            this.grpNoiDung.Controls.Add(this.lblNoiDung);
            this.grpNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNoiDung.Location = new System.Drawing.Point(5, 127);
            this.grpNoiDung.MinimumSize = new System.Drawing.Size(630, 250);
            this.grpNoiDung.Name = "grpNoiDung";
            this.grpNoiDung.Size = new System.Drawing.Size(636, 262);
            this.grpNoiDung.TabIndex = 24;
            this.grpNoiDung.TabStop = false;
            this.grpNoiDung.Text = "Tin nhắn từ : [Người gửi]";
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiDung.ForeColor = System.Drawing.Color.Green;
            this.lblNoiDung.Location = new System.Drawing.Point(6, 20);
            this.lblNoiDung.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(93, 20);
            this.lblNoiDung.TabIndex = 4;
            this.lblNoiDung.Text = "[Nội Dung]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Người nhận :";
            // 
            // txtIDMessage
            // 
            this.txtIDMessage.Location = new System.Drawing.Point(613, 38);
            this.txtIDMessage.Name = "txtIDMessage";
            this.txtIDMessage.Size = new System.Drawing.Size(28, 21);
            this.txtIDMessage.TabIndex = 23;
            this.txtIDMessage.Visible = false;
            // 
            // lblNguoiNhan
            // 
            this.lblNguoiNhan.AutoSize = true;
            this.lblNguoiNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiNhan.Location = new System.Drawing.Point(110, 38);
            this.lblNguoiNhan.Name = "lblNguoiNhan";
            this.lblNguoiNhan.Size = new System.Drawing.Size(110, 20);
            this.lblNguoiNhan.TabIndex = 17;
            this.lblNguoiNhan.Text = "[Người nhận]";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGian.Location = new System.Drawing.Point(496, 33);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(64, 20);
            this.lblThoiGian.TabIndex = 22;
            this.lblThoiGian.Text = "[00:00]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tiêu đề :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(409, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "Thời gian :";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AllowDrop = true;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(110, 67);
            this.lblTieuDe.MaximumSize = new System.Drawing.Size(500, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(78, 20);
            this.lblTieuDe.TabIndex = 19;
            this.lblTieuDe.Text = "[Tiêu đề]";
            // 
            // tabDSTinNhan
            // 
            this.tabDSTinNhan.Controls.Add(this.chkTrangThai);
            this.tabDSTinNhan.Controls.Add(this.calDateSearch);
            this.tabDSTinNhan.Controls.Add(this.grdContent);
            this.tabDSTinNhan.Controls.Add(this.btnXuatExcel);
            this.tabDSTinNhan.Controls.Add(this.txtNDTinNhan);
            this.tabDSTinNhan.Controls.Add(this.label7);
            this.tabDSTinNhan.Controls.Add(this.label6);
            this.tabDSTinNhan.Controls.Add(this.label5);
            this.tabDSTinNhan.Controls.Add(this.label3);
            this.tabDSTinNhan.Controls.Add(this.label2);
            this.tabDSTinNhan.Location = new System.Drawing.Point(4, 22);
            this.tabDSTinNhan.Name = "tabDSTinNhan";
            this.tabDSTinNhan.Padding = new System.Windows.Forms.Padding(3);
            this.tabDSTinNhan.Size = new System.Drawing.Size(653, 400);
            this.tabDSTinNhan.TabIndex = 1;
            this.tabDSTinNhan.Text = "Danh sách tin nhắn";
            this.tabDSTinNhan.UseVisualStyleBackColor = true;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.Location = new System.Drawing.Point(518, 317);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrangThai.Properties.Appearance.Options.UseFont = true;
            this.chkTrangThai.Properties.Caption = "Luôn luôn hiển thị";
            this.chkTrangThai.Size = new System.Drawing.Size(126, 20);
            this.chkTrangThai.TabIndex = 55;
            // 
            // calDateSearch
            // 
            this.calDateSearch.DateNowWhenLoad = true;
            this.calDateSearch.EditValue = null;
            this.calDateSearch.IsChangeText = false;
            this.calDateSearch.IsFocus = false;
            this.calDateSearch.Location = new System.Drawing.Point(70, 7);
            this.calDateSearch.Name = "calDateSearch";
            this.calDateSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calDateSearch.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.calDateSearch.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.calDateSearch.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.calDateSearch.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.calDateSearch.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.calDateSearch.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.calDateSearch.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.calDateSearch.Properties.MinValue = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.calDateSearch.Size = new System.Drawing.Size(121, 20);
            this.calDateSearch.TabIndex = 53;
            this.calDateSearch.Tag = "FromDate";
            this.calDateSearch.EditValueChanged += new System.EventHandler(this.calDateSearch_ValueChanged);
            // 
            // grdContent
            // 
            this.grdContent.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grdContent.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grdContent.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grdContent.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grdContent.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grdContent.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grdContent.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grdContent.Location = new System.Drawing.Point(3, 33);
            this.grdContent.MainView = this.grcContent;
            this.grdContent.Name = "grdContent";
            this.grdContent.Size = new System.Drawing.Size(650, 283);
            this.grdContent.TabIndex = 10;
            this.grdContent.UseEmbeddedNavigator = true;
            this.grdContent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grcContent});
            this.grdContent.Click += new System.EventHandler(this.grdContent_Click);
            this.grdContent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdContent_KeyUp);
            // 
            // grcContent
            // 
            this.grcContent.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grcContent.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcContent.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcUserName,
            this.grcFullName,
            this.grcIPAddress,
            this.grcContents,
            this.grcDate,
            this.grcPriority,
            this.grcSubject,
            this.grcStatus,
            this.grcListToUserName,
            this.grcId});
            this.grcContent.GridControl = this.grdContent;
            this.grcContent.IndicatorWidth = 35;
            this.grcContent.Name = "grcContent";
            this.grcContent.OptionsBehavior.Editable = false;
            this.grcContent.OptionsCustomization.AllowFilter = false;
            this.grcContent.OptionsCustomization.AllowGroup = false;
            this.grcContent.OptionsMenu.EnableColumnMenu = false;
            this.grcContent.OptionsMenu.EnableFooterMenu = false;
            this.grcContent.OptionsMenu.EnableGroupPanelMenu = false;
            this.grcContent.OptionsView.ColumnAutoWidth = false;
            this.grcContent.OptionsView.ShowGroupPanel = false;
            this.grcContent.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grcContent_RowCellStyle);
            this.grcContent.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grcContent_RowStyle);
            // 
            // grcUserName
            // 
            this.grcUserName.Caption = "Người gửi";
            this.grcUserName.FieldName = "UserName";
            this.grcUserName.Name = "grcUserName";
            this.grcUserName.Visible = true;
            this.grcUserName.VisibleIndex = 0;
            // 
            // grcFullName
            // 
            this.grcFullName.Caption = "Họ tên";
            this.grcFullName.FieldName = "FULLNAME";
            this.grcFullName.Name = "grcFullName";
            this.grcFullName.Visible = true;
            this.grcFullName.VisibleIndex = 1;
            // 
            // grcIPAddress
            // 
            this.grcIPAddress.Caption = "IP";
            this.grcIPAddress.FieldName = "IPAddress";
            this.grcIPAddress.Name = "grcIPAddress";
            this.grcIPAddress.Visible = true;
            this.grcIPAddress.VisibleIndex = 2;
            // 
            // grcContents
            // 
            this.grcContents.Caption = "Nội dung";
            this.grcContents.FieldName = "Contents";
            this.grcContents.Name = "grcContents";
            this.grcContents.Visible = true;
            this.grcContents.VisibleIndex = 3;
            // 
            // grcDate
            // 
            this.grcDate.Caption = "Ngày";
            this.grcDate.FieldName = "Date";
            this.grcDate.Name = "grcDate";
            this.grcDate.Visible = true;
            this.grcDate.VisibleIndex = 4;
            // 
            // grcPriority
            // 
            this.grcPriority.Caption = "Ưu tiên";
            this.grcPriority.FieldName = "Priority";
            this.grcPriority.Name = "grcPriority";
            this.grcPriority.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.grcPriority.Visible = true;
            this.grcPriority.VisibleIndex = 5;
            // 
            // grcSubject
            // 
            this.grcSubject.Caption = "Chủ đề";
            this.grcSubject.FieldName = "Subject";
            this.grcSubject.Name = "grcSubject";
            // 
            // grcStatus
            // 
            this.grcStatus.Caption = "Status";
            this.grcStatus.FieldName = "Status";
            this.grcStatus.Name = "grcStatus";
            this.grcStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // grcListToUserName
            // 
            this.grcListToUserName.Caption = "Người nhận";
            this.grcListToUserName.FieldName = "ListToUserName";
            this.grcListToUserName.Name = "grcListToUserName";
            this.grcListToUserName.Visible = true;
            this.grcListToUserName.VisibleIndex = 6;
            // 
            // grcId
            // 
            this.grcId.FieldName = "Id";
            this.grcId.Name = "grcId";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(208, 4);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(86, 23);
            this.btnXuatExcel.TabIndex = 9;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // txtNDTinNhan
            // 
            this.txtNDTinNhan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNDTinNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNDTinNhan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNDTinNhan.Location = new System.Drawing.Point(9, 337);
            this.txtNDTinNhan.Multiline = true;
            this.txtNDTinNhan.Name = "txtNDTinNhan";
            this.txtNDTinNhan.ReadOnly = true;
            this.txtNDTinNhan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNDTinNhan.Size = new System.Drawing.Size(635, 60);
            this.txtNDTinNhan.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nội dung tin nhắn :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(366, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Trạng thái :";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(547, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tin nhắn đã đọc";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(438, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tin nhắn chưa đọc";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thời gian";
            // 
            // ListMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMessage);
            this.Name = "ListMessages";
            this.Size = new System.Drawing.Size(661, 426);
            this.Load += new System.EventHandler(this.ListMessages_Load);
            this.tabMessage.ResumeLayout(false);
            this.tabNoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.grpNoiDung.ResumeLayout(false);
            this.grpNoiDung.PerformLayout();
            this.tabDSTinNhan.ResumeLayout(false);
            this.tabDSTinNhan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTrangThai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDateSearch.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDateSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMessage;
        private System.Windows.Forms.TabPage tabNoiDung;
        private System.Windows.Forms.TabPage tabDSTinNhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNDTinNhan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnXuatExcel;
        private DevExpress.XtraGrid.Columns.GridColumn grcUserName;
        private DevExpress.XtraGrid.Columns.GridColumn grcFullName;
        private DevExpress.XtraGrid.Columns.GridColumn grcIPAddress;
        private DevExpress.XtraGrid.Columns.GridColumn grcContents;
        private DevExpress.XtraGrid.Columns.GridColumn grcDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcPriority;
        private DevExpress.XtraGrid.Columns.GridColumn grcSubject;
        private DevExpress.XtraGrid.Columns.GridColumn grcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grcListToUserName;
        private DevExpress.XtraGrid.Columns.GridColumn grcId;
        public Base.Controls.ShGridControl grdContent;
        public Base.Controls.ShGridView grcContent;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpNoiDung;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDMessage;
        private System.Windows.Forms.Label lblNguoiNhan;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnDaDoc;
        protected Base.Inputs.InputDate calDateSearch;
        private DevExpress.XtraEditors.CheckEdit chkTrangThai;
    }
}
