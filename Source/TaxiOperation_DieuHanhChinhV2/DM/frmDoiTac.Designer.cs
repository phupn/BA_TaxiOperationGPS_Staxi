namespace Taxi.GUI
{
    partial class frmDoiTac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiTac));
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.grpViTri = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.trackBarMap = new System.Windows.Forms.TrackBar();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl();
            this.pnlControls = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.cbDoiTacStep = new Taxi.Controls.Base.Common.InputLookUp_DoiTacStep();
            this.txtVietTat = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkIsActive = new Janus.Windows.EditControls.UICheckBox();
            this.cboLoaiDT = new System.Windows.Forms.ComboBox();
            this.btn_ViTri = new System.Windows.Forms.Button();
            this.txtViDo = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKinhDo = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label5 = new System.Windows.Forms.Label();
            this.editTenDuong = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label18 = new System.Windows.Forms.Label();
            this.editSoNha = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label17 = new System.Windows.Forms.Label();
            this.calNgayKyKet = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label14 = new System.Windows.Forms.Label();
            this.cboNhanVien = new Janus.Windows.EditControls.UIComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.editNotes = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericHHNgoaiTinh = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numericHHNoiTinh = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label7 = new System.Windows.Forms.Label();
            this.editPhones = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label4 = new System.Windows.Forms.Label();
            this.editAddress = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editMaDoiTac = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelInput1 = new Taxi.Controls.Base.Controls.ShPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpViTri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControls)).BeginInit();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTacStep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput1)).BeginInit();
            this.panelInput1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(213, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "&Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(121, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 26);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = " &Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // grpViTri
            // 
            this.grpViTri.Controls.Add(this.txtAddress);
            this.grpViTri.Controls.Add(this.trackBarMap);
            this.grpViTri.Controls.Add(this.MainMap);
            this.grpViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpViTri.Location = new System.Drawing.Point(408, 2);
            this.grpViTri.Name = "grpViTri";
            this.grpViTri.Size = new System.Drawing.Size(524, 432);
            this.grpViTri.TabIndex = 17;
            this.grpViTri.TabStop = false;
            this.grpViTri.Text = "Vị trí tọa độ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(305, 19);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 21);
            this.txtAddress.TabIndex = 10;
            this.txtAddress.Text = "Tìm địa chỉ";
            this.txtAddress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAddress_MouseClick);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // trackBarMap
            // 
            this.trackBarMap.Location = new System.Drawing.Point(6, 19);
            this.trackBarMap.Name = "trackBarMap";
            this.trackBarMap.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMap.Size = new System.Drawing.Size(45, 328);
            this.trackBarMap.TabIndex = 8;
            // 
            // MainMap
            // 
            this.MainMap.AllowDrawPolygon = false;
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(3, 17);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(518, 412);
            this.MainMap.TabIndex = 9;
            this.MainMap.TabStop = false;
            this.MainMap.Zoom = 0D;
            this.MainMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseClick);
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.cbDoiTacStep);
            this.pnlControls.Controls.Add(this.txtVietTat);
            this.pnlControls.Controls.Add(this.label13);
            this.pnlControls.Controls.Add(this.chkIsActive);
            this.pnlControls.Controls.Add(this.cboLoaiDT);
            this.pnlControls.Controls.Add(this.btn_ViTri);
            this.pnlControls.Controls.Add(this.txtViDo);
            this.pnlControls.Controls.Add(this.label6);
            this.pnlControls.Controls.Add(this.txtKinhDo);
            this.pnlControls.Controls.Add(this.label5);
            this.pnlControls.Controls.Add(this.editTenDuong);
            this.pnlControls.Controls.Add(this.label18);
            this.pnlControls.Controls.Add(this.editSoNha);
            this.pnlControls.Controls.Add(this.label17);
            this.pnlControls.Controls.Add(this.calNgayKyKet);
            this.pnlControls.Controls.Add(this.label14);
            this.pnlControls.Controls.Add(this.cboNhanVien);
            this.pnlControls.Controls.Add(this.label11);
            this.pnlControls.Controls.Add(this.editNotes);
            this.pnlControls.Controls.Add(this.label9);
            this.pnlControls.Controls.Add(this.numericHHNgoaiTinh);
            this.pnlControls.Controls.Add(this.label16);
            this.pnlControls.Controls.Add(this.label15);
            this.pnlControls.Controls.Add(this.numericHHNoiTinh);
            this.pnlControls.Controls.Add(this.label7);
            this.pnlControls.Controls.Add(this.editPhones);
            this.pnlControls.Controls.Add(this.label4);
            this.pnlControls.Controls.Add(this.editAddress);
            this.pnlControls.Controls.Add(this.label3);
            this.pnlControls.Controls.Add(this.editName);
            this.pnlControls.Controls.Add(this.label2);
            this.pnlControls.Controls.Add(this.label8);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Controls.Add(this.editMaDoiTac);
            this.pnlControls.Controls.Add(this.label12);
            this.pnlControls.Controls.Add(this.label10);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControls.Location = new System.Drawing.Point(2, 2);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(406, 432);
            this.pnlControls.TabIndex = 19;
            this.pnlControls.Text = "Thông tin đối tác";
            // 
            // cbDoiTacStep
            // 
            this.cbDoiTacStep.DefaultSelectFirstRow = false;
            this.cbDoiTacStep.IsChangeText = false;
            this.cbDoiTacStep.IsFocus = false;
            this.cbDoiTacStep.IsShowTextNull = true;
            this.cbDoiTacStep.Location = new System.Drawing.Point(121, 394);
            this.cbDoiTacStep.Name = "cbDoiTacStep";
            this.cbDoiTacStep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDoiTacStep.Properties.NullText = "";
            this.cbDoiTacStep.Size = new System.Drawing.Size(160, 20);
            this.cbDoiTacStep.TabIndex = 75;
            // 
            // txtVietTat
            // 
            this.txtVietTat.AcceptsTab = true;
            this.txtVietTat.Location = new System.Drawing.Point(122, 81);
            this.txtVietTat.Margin = new System.Windows.Forms.Padding(2);
            this.txtVietTat.MaxLength = 255;
            this.txtVietTat.Name = "txtVietTat";
            this.txtVietTat.Size = new System.Drawing.Size(258, 21);
            this.txtVietTat.TabIndex = 74;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 88);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 73;
            this.label13.Text = "Tên viết tắt";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(275, 288);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(2);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(99, 19);
            this.chkIsActive.TabIndex = 12;
            this.chkIsActive.Text = "Đang hoạt động";
            this.chkIsActive.Visible = false;
            // 
            // cboLoaiDT
            // 
            this.cboLoaiDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiDT.FormattingEnabled = true;
            this.cboLoaiDT.Location = new System.Drawing.Point(263, 29);
            this.cboLoaiDT.Name = "cboLoaiDT";
            this.cboLoaiDT.Size = new System.Drawing.Size(89, 21);
            this.cboLoaiDT.TabIndex = 2;
            // 
            // btn_ViTri
            // 
            this.btn_ViTri.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.map;
            this.btn_ViTri.Location = new System.Drawing.Point(358, 25);
            this.btn_ViTri.Name = "btn_ViTri";
            this.btn_ViTri.Size = new System.Drawing.Size(27, 29);
            this.btn_ViTri.TabIndex = 71;
            this.btn_ViTri.TabStop = false;
            this.btn_ViTri.UseVisualStyleBackColor = true;
            this.btn_ViTri.Click += new System.EventHandler(this.btn_ViTri_Click);
            // 
            // txtViDo
            // 
            this.txtViDo.AcceptsTab = true;
            this.txtViDo.Location = new System.Drawing.Point(275, 259);
            this.txtViDo.Margin = new System.Windows.Forms.Padding(2);
            this.txtViDo.MaxLength = 255;
            this.txtViDo.Name = "txtViDo";
            this.txtViDo.Size = new System.Drawing.Size(106, 21);
            this.txtViDo.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "Vĩ độ";
            // 
            // txtKinhDo
            // 
            this.txtKinhDo.AcceptsTab = true;
            this.txtKinhDo.Location = new System.Drawing.Point(275, 234);
            this.txtKinhDo.Margin = new System.Windows.Forms.Padding(2);
            this.txtKinhDo.MaxLength = 255;
            this.txtKinhDo.Name = "txtKinhDo";
            this.txtKinhDo.Size = new System.Drawing.Size(106, 21);
            this.txtKinhDo.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 237);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Kinh độ";
            // 
            // editTenDuong
            // 
            this.editTenDuong.AcceptsTab = true;
            this.editTenDuong.Location = new System.Drawing.Point(233, 209);
            this.editTenDuong.Margin = new System.Windows.Forms.Padding(2);
            this.editTenDuong.MaxLength = 255;
            this.editTenDuong.Name = "editTenDuong";
            this.editTenDuong.Size = new System.Drawing.Size(147, 21);
            this.editTenDuong.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(174, 212);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 66;
            this.label18.Text = "Tên đường";
            // 
            // editSoNha
            // 
            this.editSoNha.AcceptsTab = true;
            this.editSoNha.Location = new System.Drawing.Point(122, 209);
            this.editSoNha.Margin = new System.Windows.Forms.Padding(2);
            this.editSoNha.MaxLength = 255;
            this.editSoNha.Name = "editSoNha";
            this.editSoNha.Size = new System.Drawing.Size(50, 21);
            this.editSoNha.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(78, 212);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 65;
            this.label17.Text = "Số nhà";
            // 
            // calNgayKyKet
            // 
            this.calNgayKyKet.CustomFormat = "dd/MM/yyyy";
            this.calNgayKyKet.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calNgayKyKet.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calNgayKyKet.DropDownCalendar.Name = "";
            this.calNgayKyKet.Location = new System.Drawing.Point(122, 290);
            this.calNgayKyKet.MinDate = new System.DateTime(1900, 2, 1, 0, 0, 0, 0);
            this.calNgayKyKet.Name = "calNgayKyKet";
            this.calNgayKyKet.Size = new System.Drawing.Size(98, 21);
            this.calNgayKyKet.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(53, 294);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 64;
            this.label14.Text = "Ngày ký kết";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboNhanVien.Location = new System.Drawing.Point(121, 370);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(259, 21);
            this.cboNhanVien.TabIndex = 11;
            this.cboNhanVien.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 370);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Nhân viên khai thác";
            // 
            // editNotes
            // 
            this.editNotes.Location = new System.Drawing.Point(121, 320);
            this.editNotes.Margin = new System.Windows.Forms.Padding(2);
            this.editNotes.MaxLength = 255;
            this.editNotes.Multiline = true;
            this.editNotes.Name = "editNotes";
            this.editNotes.Size = new System.Drawing.Size(259, 45);
            this.editNotes.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 320);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "Ghi chú";
            // 
            // numericHHNgoaiTinh
            // 
            this.numericHHNgoaiTinh.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General;
            this.numericHHNgoaiTinh.Location = new System.Drawing.Point(122, 259);
            this.numericHHNgoaiTinh.Margin = new System.Windows.Forms.Padding(2);
            this.numericHHNgoaiTinh.Name = "numericHHNgoaiTinh";
            this.numericHHNgoaiTinh.Size = new System.Drawing.Size(98, 21);
            this.numericHHNgoaiTinh.TabIndex = 8;
            this.numericHHNgoaiTinh.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(55, 400);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 57;
            this.label16.Text = "Thanh toán";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 264);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 13);
            this.label15.TabIndex = 57;
            this.label15.Text = "Hoa hồng ngoại tỉnh";
            // 
            // numericHHNoiTinh
            // 
            this.numericHHNoiTinh.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General;
            this.numericHHNoiTinh.Location = new System.Drawing.Point(122, 234);
            this.numericHHNoiTinh.Margin = new System.Windows.Forms.Padding(2);
            this.numericHHNoiTinh.Name = "numericHHNoiTinh";
            this.numericHHNoiTinh.Size = new System.Drawing.Size(98, 21);
            this.numericHHNoiTinh.TabIndex = 8;
            this.numericHHNoiTinh.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 239);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Hoa hồng nội tỉnh";
            // 
            // editPhones
            // 
            this.editPhones.AcceptsTab = true;
            this.editPhones.Location = new System.Drawing.Point(122, 138);
            this.editPhones.Margin = new System.Windows.Forms.Padding(2);
            this.editPhones.MaxLength = 255;
            this.editPhones.Multiline = true;
            this.editPhones.Name = "editPhones";
            this.editPhones.Size = new System.Drawing.Size(259, 67);
            this.editPhones.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Các số điện thoại (*)";
            // 
            // editAddress
            // 
            this.editAddress.AcceptsTab = true;
            this.editAddress.Location = new System.Drawing.Point(122, 112);
            this.editAddress.Margin = new System.Windows.Forms.Padding(2);
            this.editAddress.MaxLength = 255;
            this.editAddress.Name = "editAddress";
            this.editAddress.Size = new System.Drawing.Size(259, 21);
            this.editAddress.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Địa chỉ (*)";
            // 
            // editName
            // 
            this.editName.AcceptsTab = true;
            this.editName.Location = new System.Drawing.Point(122, 56);
            this.editName.Margin = new System.Windows.Forms.Padding(2);
            this.editName.MaxLength = 50;
            this.editName.Name = "editName";
            this.editName.Size = new System.Drawing.Size(259, 21);
            this.editName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Tên đối tác (*)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Loại ĐT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Mã đối tác";
            // 
            // editMaDoiTac
            // 
            this.editMaDoiTac.Location = new System.Drawing.Point(122, 29);
            this.editMaDoiTac.Margin = new System.Windows.Forms.Padding(2);
            this.editMaDoiTac.MaxLength = 6;
            this.editMaDoiTac.Name = "editMaDoiTac";
            this.editMaDoiTac.Size = new System.Drawing.Size(85, 21);
            this.editMaDoiTac.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(65, 153);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 12);
            this.label12.TabIndex = 62;
            this.label12.Text = "phân cách)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(82, 152);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 61;
            this.label10.Text = "(Dùng ;";
            // 
            // panelInput1
            // 
            this.panelInput1.Controls.Add(this.btnCancel);
            this.panelInput1.Controls.Add(this.btnSave);
            this.panelInput1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInput1.LabelMessage = null;
            this.panelInput1.Location = new System.Drawing.Point(2, 434);
            this.panelInput1.Name = "panelInput1";
            this.panelInput1.Size = new System.Drawing.Size(930, 43);
            this.panelInput1.TabIndex = 20;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grpViTri);
            this.panelControl1.Controls.Add(this.pnlControls);
            this.panelControl1.Controls.Add(this.panelInput1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(934, 479);
            this.panelControl1.TabIndex = 21;
            // 
            // frmDoiTac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 479);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDoiTac";
            this.Text = "Thêm/Sửa đối tác";
            this.Load += new System.EventHandler(this.frmDoiTac_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDoiTac_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpViTri.ResumeLayout(false);
            this.grpViTri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControls)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTacStep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput1)).EndInit();
            this.panelInput1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox grpViTri;
        private System.Windows.Forms.TrackBar trackBarMap;
        private Taxi.Controls.ExtendedGMapControl MainMap;
        private System.Windows.Forms.TextBox txtAddress;
        private Controls.Base.Controls.ShGroupBox pnlControls;
        private Janus.Windows.EditControls.UICheckBox chkIsActive;
        private System.Windows.Forms.ComboBox cboLoaiDT;
        private System.Windows.Forms.Button btn_ViTri;
        private Janus.Windows.GridEX.EditControls.EditBox txtViDo;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.EditControls.EditBox txtKinhDo;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.GridEX.EditControls.EditBox editTenDuong;
        private System.Windows.Forms.Label label18;
        private Janus.Windows.GridEX.EditControls.EditBox editSoNha;
        private System.Windows.Forms.Label label17;
        private Janus.Windows.CalendarCombo.CalendarCombo calNgayKyKet;
        private System.Windows.Forms.Label label14;
        private Janus.Windows.EditControls.UIComboBox cboNhanVien;
        private System.Windows.Forms.Label label11;
        private Janus.Windows.GridEX.EditControls.EditBox editNotes;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numericHHNoiTinh;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.GridEX.EditControls.EditBox editPhones;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.EditControls.EditBox editAddress;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.EditControls.EditBox editName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox editMaDoiTac;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private Controls.Base.Controls.ShPanel panelInput1;
        private Janus.Windows.GridEX.EditControls.EditBox txtVietTat;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numericHHNgoaiTinh;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private Controls.Base.Common.InputLookUp_DoiTacStep cbDoiTacStep;
    }
}