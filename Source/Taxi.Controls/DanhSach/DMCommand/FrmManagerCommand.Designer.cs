namespace Taxi.Controls.DanhSach.DMCommand
{
    partial class FrmManagerCommand
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
            this.reColorEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.gridControl1 = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.grvCommand = new Taxi.Controls.Base.Controls.Grids.GridView();
            this.grcShortcuts = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcShortcuts2 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcCommandType = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcCommand = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcCommandColor = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcParentCommand = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcParentColor = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcIsColorRow = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcIsColorAll = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcRequireTaxi = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcRequireApp = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcRequireVehicle = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcRequireVehicleCancel = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcIsRequited = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcCallStatus = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcStatus = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcCallType = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcCmdServer = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcCmdId = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grcCmdMsg = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.btnUp = new Taxi.Controls.Base.Controls.ShButton();
            this.btnDown = new Taxi.Controls.Base.Controls.ShButton();
            this.panOrder = new System.Windows.Forms.Panel();
            this.panbuttonChangeOrder = new System.Windows.Forms.Panel();
            this.btnCancel = new Taxi.Controls.Base.Controls.ShButton();
            this.btnSave = new Taxi.Controls.Base.Controls.ShButton();
            this.btnOrder = new Taxi.Controls.Base.Controls.ShButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grBTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).BeginInit();
            this.panelView.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reColorEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCommand)).BeginInit();
            this.panOrder.SuspendLayout();
            this.panbuttonChangeOrder.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.lblMessage.Location = new System.Drawing.Point(576, 38);
            this.lblMessage.Size = new System.Drawing.Size(128, 16);
            this.lblMessage.Text = "Không tìm thấy dữ liệu";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(243, 4);
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.panel1);
            this.panelView.Controls.Add(this.panOrder);
            this.panelView.Location = new System.Drawing.Point(0, 58);
            this.panelView.Size = new System.Drawing.Size(1264, 623);
            // 
            // panelAction
            // 
            this.panelAction.Location = new System.Drawing.Point(0, 0);
            this.panelAction.Size = new System.Drawing.Size(1264, 58);
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnOrder);
            this.panelButton.Location = new System.Drawing.Point(435, 2);
            this.panelButton.Size = new System.Drawing.Size(409, 31);
            this.panelButton.Controls.SetChildIndex(this.btnOrder, 0);
            this.panelButton.Controls.SetChildIndex(this.btnXoa, 0);
            this.panelButton.Controls.SetChildIndex(this.btnSua, 0);
            this.panelButton.Controls.SetChildIndex(this.btnLamMoi, 0);
            this.panelButton.Controls.SetChildIndex(this.btnTimKiem, 0);
            this.panelButton.Controls.SetChildIndex(this.btnXuatExcel, 0);
            this.panelButton.Controls.SetChildIndex(this.btnThem, 0);
            // 
            // reColorEdit
            // 
            this.reColorEdit.AutoHeight = false;
            this.reColorEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reColorEdit.Name = "reColorEdit";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridControl1.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridControl1.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridControl1.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridControl1.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridControl1.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.grvCommand;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1264, 588);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCommand});
            // 
            // grvCommand
            // 
            this.grvCommand.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCommand.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCommand.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCommand.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcShortcuts,
            this.grcShortcuts2,
            this.grcCommandType,
            this.grcCommand,
            this.grcCommandColor,
            this.grcParentCommand,
            this.grcParentColor,
            this.grcIsColorRow,
            this.grcIsColorAll,
            this.grcRequireTaxi,
            this.grcRequireApp,
            this.grcRequireVehicle,
            this.grcRequireVehicleCancel,
            this.grcIsRequited,
            this.grcCallStatus,
            this.grcStatus,
            this.grcCallType,
            this.grcCmdServer,
            this.grcCmdId,
            this.grcCmdMsg});
            this.grvCommand.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCommand.GridControl = this.gridControl1;
            this.grvCommand.IndicatorWidth = 35;
            this.grvCommand.Name = "grvCommand";
            this.grvCommand.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCommand.OptionsBehavior.Editable = false;
            this.grvCommand.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.grvCommand.OptionsCustomization.AllowFilter = false;
            this.grvCommand.OptionsCustomization.AllowSort = false;
            this.grvCommand.OptionsMenu.EnableColumnMenu = false;
            this.grvCommand.OptionsPrint.AutoWidth = false;
            this.grvCommand.OptionsView.ColumnAutoWidth = false;
            this.grvCommand.OptionsView.ShowGroupPanel = false;
            // 
            // grcShortcuts
            // 
            this.grcShortcuts.Caption = "Phím tắt";
            this.grcShortcuts.FieldName = "Shortcuts";
            this.grcShortcuts.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcShortcuts.Name = "grcShortcuts";
            this.grcShortcuts.TagLanguage = null;
            this.grcShortcuts.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcShortcuts.Visible = true;
            this.grcShortcuts.VisibleIndex = 0;
            // 
            // grcShortcuts2
            // 
            this.grcShortcuts2.Caption = "Shortcuts2";
            this.grcShortcuts2.FieldName = "Shortcuts2";
            this.grcShortcuts2.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcShortcuts2.Name = "grcShortcuts2";
            this.grcShortcuts2.TagLanguage = null;
            this.grcShortcuts2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // grcCommandType
            // 
            this.grcCommandType.Caption = "CommandType";
            this.grcCommandType.FieldName = "CommandType";
            this.grcCommandType.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcCommandType.Name = "grcCommandType";
            this.grcCommandType.TagLanguage = null;
            this.grcCommandType.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // grcCommand
            // 
            this.grcCommand.Caption = "Lệnh";
            this.grcCommand.FieldName = "Command";
            this.grcCommand.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcCommand.Name = "grcCommand";
            this.grcCommand.TagLanguage = null;
            this.grcCommand.Visible = true;
            this.grcCommand.VisibleIndex = 1;
            // 
            // grcCommandColor
            // 
            this.grcCommandColor.Caption = "Màu của lệnh";
            this.grcCommandColor.ColumnEdit = this.reColorEdit;
            this.grcCommandColor.FieldName = "CommandColor";
            this.grcCommandColor.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcCommandColor.Name = "grcCommandColor";
            this.grcCommandColor.TagLanguage = null;
            this.grcCommandColor.Visible = true;
            this.grcCommandColor.VisibleIndex = 2;
            this.grcCommandColor.Width = 90;
            // 
            // grcParentCommand
            // 
            this.grcParentCommand.Caption = "Lệnh cha";
            this.grcParentCommand.FieldName = "ParentCommand";
            this.grcParentCommand.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcParentCommand.Name = "grcParentCommand";
            this.grcParentCommand.TagLanguage = null;
            this.grcParentCommand.Visible = true;
            this.grcParentCommand.VisibleIndex = 3;
            this.grcParentCommand.Width = 89;
            // 
            // grcParentColor
            // 
            this.grcParentColor.Caption = "ParentColor";
            this.grcParentColor.FieldName = "ParentColor";
            this.grcParentColor.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcParentColor.Name = "grcParentColor";
            this.grcParentColor.TagLanguage = null;
            // 
            // grcIsColorRow
            // 
            this.grcIsColorRow.Caption = "Màu cả dòng";
            this.grcIsColorRow.FieldName = "IsColorRow";
            this.grcIsColorRow.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcIsColorRow.Name = "grcIsColorRow";
            this.grcIsColorRow.TagLanguage = null;
            this.grcIsColorRow.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcIsColorRow.Visible = true;
            this.grcIsColorRow.VisibleIndex = 4;
            // 
            // grcIsColorAll
            // 
            this.grcIsColorAll.Caption = "Hiện tất cả";
            this.grcIsColorAll.FieldName = "IsColorAll";
            this.grcIsColorAll.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcIsColorAll.Name = "grcIsColorAll";
            this.grcIsColorAll.TagLanguage = null;
            this.grcIsColorAll.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcIsColorAll.Visible = true;
            this.grcIsColorAll.VisibleIndex = 5;
            // 
            // grcRequireTaxi
            // 
            this.grcRequireTaxi.Caption = "Gọi taxi";
            this.grcRequireTaxi.FieldName = "RequireTaxi";
            this.grcRequireTaxi.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcRequireTaxi.Name = "grcRequireTaxi";
            this.grcRequireTaxi.TagLanguage = null;
            this.grcRequireTaxi.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcRequireTaxi.Visible = true;
            this.grcRequireTaxi.VisibleIndex = 6;
            // 
            // grcRequireApp
            // 
            this.grcRequireApp.Caption = "Điều app";
            this.grcRequireApp.FieldName = "RequireApp";
            this.grcRequireApp.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcRequireApp.Name = "grcRequireApp";
            this.grcRequireApp.TagLanguage = null;
            this.grcRequireApp.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcRequireApp.Visible = true;
            this.grcRequireApp.VisibleIndex = 7;
            // 
            // grcRequireVehicle
            // 
            this.grcRequireVehicle.Caption = "Xe nhận";
            this.grcRequireVehicle.FieldName = "RequireVehicle";
            this.grcRequireVehicle.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcRequireVehicle.Name = "grcRequireVehicle";
            this.grcRequireVehicle.TagLanguage = null;
            this.grcRequireVehicle.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcRequireVehicle.Visible = true;
            this.grcRequireVehicle.VisibleIndex = 8;
            // 
            // grcRequireVehicleCancel
            // 
            this.grcRequireVehicleCancel.Caption = "Xe hủy";
            this.grcRequireVehicleCancel.FieldName = "RequireVehicleCancel";
            this.grcRequireVehicleCancel.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcRequireVehicleCancel.Name = "grcRequireVehicleCancel";
            this.grcRequireVehicleCancel.TagLanguage = null;
            this.grcRequireVehicleCancel.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcRequireVehicleCancel.Visible = true;
            this.grcRequireVehicleCancel.VisibleIndex = 9;
            // 
            // grcIsRequited
            // 
            this.grcIsRequited.Caption = "Hỏi thực hiện lệnh";
            this.grcIsRequited.FieldName = "IsRequited";
            this.grcIsRequited.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcIsRequited.Name = "grcIsRequited";
            this.grcIsRequited.TagLanguage = null;
            this.grcIsRequited.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcIsRequited.Visible = true;
            this.grcIsRequited.VisibleIndex = 10;
            this.grcIsRequited.Width = 102;
            // 
            // grcCallStatus
            // 
            this.grcCallStatus.Caption = "Trạng thái cuốc gọi";
            this.grcCallStatus.FieldName = "CallStatus";
            this.grcCallStatus.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcCallStatus.Name = "grcCallStatus";
            this.grcCallStatus.TagLanguage = null;
            this.grcCallStatus.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcCallStatus.Visible = true;
            this.grcCallStatus.VisibleIndex = 11;
            this.grcCallStatus.Width = 100;
            // 
            // grcStatus
            // 
            this.grcStatus.Caption = "Trạng thái lệnh";
            this.grcStatus.FieldName = "Status";
            this.grcStatus.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcStatus.Name = "grcStatus";
            this.grcStatus.TagLanguage = null;
            this.grcStatus.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcStatus.Visible = true;
            this.grcStatus.VisibleIndex = 12;
            this.grcStatus.Width = 92;
            // 
            // grcCallType
            // 
            this.grcCallType.Caption = "Kiểu cuộc gọi";
            this.grcCallType.FieldName = "CallType";
            this.grcCallType.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcCallType.Name = "grcCallType";
            this.grcCallType.TagLanguage = null;
            this.grcCallType.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcCallType.Visible = true;
            this.grcCallType.VisibleIndex = 13;
            this.grcCallType.Width = 96;
            // 
            // grcCmdServer
            // 
            this.grcCmdServer.Caption = "Gửi lệnh server";
            this.grcCmdServer.FieldName = "CmdServer";
            this.grcCmdServer.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcCmdServer.Name = "grcCmdServer";
            this.grcCmdServer.TagLanguage = null;
            this.grcCmdServer.Visible = true;
            this.grcCmdServer.VisibleIndex = 14;
            this.grcCmdServer.Width = 82;
            // 
            // grcCmdId
            // 
            this.grcCmdId.Caption = "Mã lệnh";
            this.grcCmdId.FieldName = "CmdId";
            this.grcCmdId.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcCmdId.Name = "grcCmdId";
            this.grcCmdId.TagLanguage = null;
            this.grcCmdId.Visible = true;
            this.grcCmdId.VisibleIndex = 15;
            this.grcCmdId.Width = 90;
            // 
            // grcCmdMsg
            // 
            this.grcCmdMsg.Caption = "Thông báo lệnh";
            this.grcCmdMsg.FieldName = "CmdMsg";
            this.grcCmdMsg.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.grcCmdMsg.Name = "grcCmdMsg";
            this.grcCmdMsg.TagLanguage = null;
            this.grcCmdMsg.Visible = true;
            this.grcCmdMsg.VisibleIndex = 16;
            this.grcCmdMsg.Width = 83;
            // 
            // btnUp
            // 
            this.btnUp.Image = global::Taxi.Controls.Properties.Resources._1464077809_arrow_up_01;
            this.btnUp.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.btnUp.Location = new System.Drawing.Point(7, 5);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(29, 23);
            this.btnUp.TabIndex = 2;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::Taxi.Controls.Properties.Resources._1464077806_arrow_down_01;
            this.btnDown.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.btnDown.Location = new System.Drawing.Point(42, 5);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(29, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // panOrder
            // 
            this.panOrder.Controls.Add(this.panbuttonChangeOrder);
            this.panOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panOrder.Location = new System.Drawing.Point(0, 0);
            this.panOrder.Name = "panOrder";
            this.panOrder.Size = new System.Drawing.Size(1264, 35);
            this.panOrder.TabIndex = 1;
            this.panOrder.Visible = false;
            // 
            // panbuttonChangeOrder
            // 
            this.panbuttonChangeOrder.Controls.Add(this.btnCancel);
            this.panbuttonChangeOrder.Controls.Add(this.btnUp);
            this.panbuttonChangeOrder.Controls.Add(this.btnDown);
            this.panbuttonChangeOrder.Controls.Add(this.btnSave);
            this.panbuttonChangeOrder.Location = new System.Drawing.Point(521, 2);
            this.panbuttonChangeOrder.Name = "panbuttonChangeOrder";
            this.panbuttonChangeOrder.Size = new System.Drawing.Size(223, 31);
            this.panbuttonChangeOrder.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Taxi.Controls.Properties.Resources.Close;
            this.btnCancel.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btnCancel.Location = new System.Drawing.Point(151, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi.Controls.Properties.Resources.ok;
            this.btnSave.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnSave.Location = new System.Drawing.Point(77, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.KeyCommand = System.Windows.Forms.Keys.F7;
            this.btnOrder.Location = new System.Drawing.Point(404, 4);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Sắp xếp(F7)";
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 588);
            this.panel1.TabIndex = 2;
            // 
            // FrmManagerCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.FileExcel = "Quan-Ly-Tap-Lenh";
            this.Grid = this.gridControl1;
            this.IsFind = false;
            this.Name = "FrmManagerCommand";
            this.Text = "Quản lý tập lệnh";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmManagerCommand_FormClosed);
            this.Resize += new System.EventHandler(this.FrmManagerCommand_Resize);
            this.grBTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).EndInit();
            this.panelView.ResumeLayout(false);
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reColorEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCommand)).EndInit();
            this.panOrder.ResumeLayout(false);
            this.panbuttonChangeOrder.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.Grids.GridControl gridControl1;
        private Base.Controls.Grids.GridView grvCommand;
        private Base.Controls.Grids.GridColumn grcShortcuts;
        private Base.Controls.Grids.GridColumn grcShortcuts2;
        private Base.Controls.Grids.GridColumn grcCommandType;
        private Base.Controls.Grids.GridColumn grcCommand;
        private Base.Controls.Grids.GridColumn grcCommandColor;
        private Base.Controls.Grids.GridColumn grcParentCommand;
        private Base.Controls.Grids.GridColumn grcParentColor;
        private Base.Controls.Grids.GridColumn grcIsColorRow;
        private Base.Controls.Grids.GridColumn grcIsColorAll;
        private Base.Controls.Grids.GridColumn grcRequireTaxi;
        private Base.Controls.Grids.GridColumn grcRequireApp;
        private Base.Controls.Grids.GridColumn grcRequireVehicle;
        private Base.Controls.Grids.GridColumn grcRequireVehicleCancel;
        private Base.Controls.Grids.GridColumn grcIsRequited;
        private Base.Controls.Grids.GridColumn grcCallStatus;
        private Base.Controls.Grids.GridColumn grcStatus;
        private Base.Controls.Grids.GridColumn grcCallType;
        private Base.Controls.Grids.GridColumn grcCmdServer;
        private Base.Controls.Grids.GridColumn grcCmdId;
        private Base.Controls.Grids.GridColumn grcCmdMsg;
        private Base.Controls.ShButton btnUp;
        private Base.Controls.ShButton btnDown;
        private System.Windows.Forms.Panel panOrder;
        private Base.Controls.ShButton btnCancel;
        private Base.Controls.ShButton btnOrder;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit reColorEdit;
        private Base.Controls.ShButton btnSave;
        private System.Windows.Forms.Panel panbuttonChangeOrder;
    }
}