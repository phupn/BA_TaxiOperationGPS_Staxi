namespace TaxiOperation_BanCo.GiamSatXe
{
    partial class frmGiamSatXe_BaoVe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiamSatXe_BaoVe));
            this.deGioDi = new Taxi.Controls.Base.Inputs.InputDate();
            this.lblb = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoHieu = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.lblmsg = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtChiSoDi = new Taxi.Controls.Base.Inputs.InputText();
            this.label5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblTenLaiXe = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtChiSoVe = new Taxi.Controls.Base.Inputs.InputText();
            this.label1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.deGioVe = new Taxi.Controls.Base.Inputs.InputDate();
            this.label2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label6 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtGhiChu = new Taxi.Controls.Base.Inputs.InputText();
            this.lookupEdit_BanCo_GiamSatXe_Reason = new Taxi.Controls.Common.LookupEdits.LookupEdit_BanCo_GiamSatXe_Reason();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiSoDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiSoVe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioVe.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioVe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEdit_BanCo_GiamSatXe_Reason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deGioDi
            // 
            this.deGioDi.DateNowWhenLoad = false;
            this.deGioDi.EditValue = new System.DateTime(2014, 9, 15, 8, 59, 18, 0);
            this.deGioDi.IsChangeText = false;
            this.deGioDi.IsFocus = false;
            this.deGioDi.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.deGioDi.Location = new System.Drawing.Point(260, 41);
            this.deGioDi.Name = "deGioDi";
            this.deGioDi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.deGioDi.Properties.Appearance.Options.UseFont = true;
            this.deGioDi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deGioDi.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deGioDi.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deGioDi.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deGioDi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deGioDi.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.deGioDi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deGioDi.Properties.MinValue = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.deGioDi.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.deGioDi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deGioDi.Size = new System.Drawing.Size(148, 23);
            this.deGioDi.TabIndex = 2;
            this.deGioDi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deGioDi_KeyDown);
            // 
            // lblb
            // 
            this.lblb.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblb.Location = new System.Drawing.Point(195, 43);
            this.lblb.Name = "lblb";
            this.lblb.Size = new System.Drawing.Size(49, 19);
            this.lblb.TabIndex = 37;
            this.lblb.Text = "Giờ đ&i *";
            // 
            // txtSoHieu
            // 
            this.txtSoHieu.IsChangeText = false;
            this.txtSoHieu.IsFocus = false;
            this.txtSoHieu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.txtSoHieu.Location = new System.Drawing.Point(100, 9);
            this.txtSoHieu.Name = "txtSoHieu";
            this.txtSoHieu.Properties.AllowFocused = false;
            this.txtSoHieu.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHieu.Properties.Appearance.Options.UseFont = true;
            this.txtSoHieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoHieu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoHieuXe", 50, "Số hiệu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaLaiXe", 100, "Mã nhân viên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhanVien", "Tên nhân viên", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GioDi", "Thời gian báo", 100, DevExpress.Utils.FormatType.DateTime, "HH:mm dd/MM", true, DevExpress.Utils.HorzAlignment.Default)});
            this.txtSoHieu.Properties.MaxLength = 10;
            this.txtSoHieu.Properties.NullText = "Chọn xe";
            this.txtSoHieu.Properties.PopupWidth = 330;
            this.txtSoHieu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtSoHieu.Properties.ValidateOnEnterKey = true;
            this.txtSoHieu.Size = new System.Drawing.Size(80, 25);
            this.txtSoHieu.TabIndex = 0;
            this.txtSoHieu.ToolTip = "Số xe";
            this.txtSoHieu.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.txtSoHieu_Closed);
            this.txtSoHieu.EditValueChanged += new System.EventHandler(this.txtSoHieu_EditValueChanged);
            this.txtSoHieu.TextChanged += new System.EventHandler(this.txtSoHieu_TextChanged);
            this.txtSoHieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoHieu_KeyDown);
            this.txtSoHieu.Leave += new System.EventHandler(this.txtSoHieu_Leave);
            // 
            // lblmsg
            // 
            this.lblmsg.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(100, 157);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 19);
            this.lblmsg.TabIndex = 35;
            // 
            // txtChiSoDi
            // 
            this.txtChiSoDi.IsChangeText = false;
            this.txtChiSoDi.IsFocus = false;
            this.txtChiSoDi.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.txtChiSoDi.Location = new System.Drawing.Point(100, 40);
            this.txtChiSoDi.Name = "txtChiSoDi";
            this.txtChiSoDi.Properties.AllowFocused = false;
            this.txtChiSoDi.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoDi.Properties.Appearance.Options.UseFont = true;
            this.txtChiSoDi.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtChiSoDi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtChiSoDi.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtChiSoDi.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.txtChiSoDi.Properties.Mask.EditMask = "d";
            this.txtChiSoDi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtChiSoDi.Properties.MaxLength = 12;
            this.txtChiSoDi.Size = new System.Drawing.Size(80, 25);
            this.txtChiSoDi.TabIndex = 1;
            this.txtChiSoDi.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtChiSoDi_EditValueChanging);
            this.txtChiSoDi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChiSoDi_KeyDown);
            // 
            // label5
            // 
            this.label5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 33;
            this.label5.Text = "&Ghi chú";
            // 
            // label4
            // 
            this.label4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "Chỉ số &đi *";
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = "Số &xe *";
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLaiXe.Location = new System.Drawing.Point(186, 12);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(0, 19);
            this.lblTenLaiXe.TabIndex = 26;
            // 
            // txtChiSoVe
            // 
            this.txtChiSoVe.IsChangeText = false;
            this.txtChiSoVe.IsFocus = false;
            this.txtChiSoVe.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.txtChiSoVe.Location = new System.Drawing.Point(100, 71);
            this.txtChiSoVe.Name = "txtChiSoVe";
            this.txtChiSoVe.Properties.AllowFocused = false;
            this.txtChiSoVe.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoVe.Properties.Appearance.Options.UseFont = true;
            this.txtChiSoVe.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtChiSoVe.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtChiSoVe.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtChiSoVe.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.txtChiSoVe.Properties.Mask.EditMask = "d";
            this.txtChiSoVe.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtChiSoVe.Properties.MaxLength = 12;
            this.txtChiSoVe.Size = new System.Drawing.Size(80, 25);
            this.txtChiSoVe.TabIndex = 3;
            this.txtChiSoVe.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtChiSoVe_EditValueChanging);
            this.txtChiSoVe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChiSoVe_KeyDown);
            this.txtChiSoVe.Leave += new System.EventHandler(this.txtChiSoVe_Leave);
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "Chỉ số &về *";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.Close;
            this.btnThoat.Location = new System.Drawing.Point(213, 185);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 30);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát (Esc)";
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Image = global::Taxi.Controls.Properties.Resources.disk;
            this.btnLuu.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnLuu.Location = new System.Drawing.Point(100, 185);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(104, 30);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu (F2)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // deGioVe
            // 
            this.deGioVe.DateNowWhenLoad = false;
            this.deGioVe.EditValue = new System.DateTime(2014, 6, 4, 14, 31, 22, 333);
            this.deGioVe.IsChangeText = false;
            this.deGioVe.IsFocus = false;
            this.deGioVe.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.deGioVe.Location = new System.Drawing.Point(260, 72);
            this.deGioVe.Name = "deGioVe";
            this.deGioVe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.deGioVe.Properties.Appearance.Options.UseFont = true;
            this.deGioVe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deGioVe.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deGioVe.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deGioVe.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deGioVe.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deGioVe.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.deGioVe.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deGioVe.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deGioVe.Size = new System.Drawing.Size(148, 23);
            this.deGioVe.TabIndex = 4;
            this.deGioVe.TextChanged += new System.EventHandler(this.deGioVe_TextChanged);
            this.deGioVe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deGioVe_KeyDown);
            this.deGioVe.Leave += new System.EventHandler(this.deGioVe_Leave);
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(195, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 41;
            this.label2.Text = "Giờ v&ề *";
            // 
            // label6
            // 
            this.label6.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 43;
            this.label6.Text = "&Lý do về *";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.IsChangeText = false;
            this.txtGhiChu.IsFocus = false;
            this.txtGhiChu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.txtGhiChu.Location = new System.Drawing.Point(100, 128);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu.Size = new System.Drawing.Size(308, 22);
            this.txtGhiChu.TabIndex = 6;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhiChu_KeyDown);
            // 
            // lookupEdit_BanCo_GiamSatXe_Reason
            // 
            this.lookupEdit_BanCo_GiamSatXe_Reason.DefaultSelectFirstRow = true;
            this.lookupEdit_BanCo_GiamSatXe_Reason.IsChangeText = false;
            this.lookupEdit_BanCo_GiamSatXe_Reason.IsFocus = false;
            this.lookupEdit_BanCo_GiamSatXe_Reason.IsShowTextNull = true;
            this.lookupEdit_BanCo_GiamSatXe_Reason.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.lookupEdit_BanCo_GiamSatXe_Reason.Location = new System.Drawing.Point(100, 102);
            this.lookupEdit_BanCo_GiamSatXe_Reason.Name = "lookupEdit_BanCo_GiamSatXe_Reason";
            this.lookupEdit_BanCo_GiamSatXe_Reason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEdit_BanCo_GiamSatXe_Reason.Properties.MaxLength = 250;
            this.lookupEdit_BanCo_GiamSatXe_Reason.Properties.NullText = "";
            this.lookupEdit_BanCo_GiamSatXe_Reason.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupEdit_BanCo_GiamSatXe_Reason.Size = new System.Drawing.Size(308, 20);
            this.lookupEdit_BanCo_GiamSatXe_Reason.TabIndex = 44;
            this.lookupEdit_BanCo_GiamSatXe_Reason.TypeReason = Taxi.Utils.Enum_ReasonType.UnKnown;
            this.lookupEdit_BanCo_GiamSatXe_Reason.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.lookupEdit_BanCo_GiamSatXe_Reason_ProcessNewValue);
            this.lookupEdit_BanCo_GiamSatXe_Reason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lueLyDoVe_KeyDown);
            // 
            // frmGiamSatXe_BaoVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(421, 226);
            this.Controls.Add(this.lookupEdit_BanCo_GiamSatXe_Reason);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.deGioVe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChiSoVe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deGioDi);
            this.Controls.Add(this.lblb);
            this.Controls.Add(this.txtSoHieu);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.txtChiSoDi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTenLaiXe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(437, 285);
            this.MinimumSize = new System.Drawing.Size(431, 252);
            this.Name = "frmGiamSatXe_BaoVe";
            this.Text = "Xe báo về";
            this.Load += new System.EventHandler(this.frmGiamSatXe_BaoVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiSoDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiSoVe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioVe.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioVe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEdit_BanCo_GiamSatXe_Reason.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Inputs.InputDate deGioDi;
        private Taxi.Controls.Base.Controls.ShLabel lblb;
        private Taxi.Controls.Base.Inputs.InputLookUp txtSoHieu;
        private Taxi.Controls.Base.Controls.ShLabel lblmsg;
        private Taxi.Controls.Base.Inputs.InputText txtChiSoDi;
        private Taxi.Controls.Base.Controls.ShButton btnThoat;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private Taxi.Controls.Base.Controls.ShLabel label5;
        private Taxi.Controls.Base.Controls.ShLabel label4;
        private Taxi.Controls.Base.Controls.ShLabel label3;
        private Taxi.Controls.Base.Controls.ShLabel lblTenLaiXe;
        private Taxi.Controls.Base.Inputs.InputText txtChiSoVe;
        private Taxi.Controls.Base.Controls.ShLabel label1;
        private Taxi.Controls.Base.Inputs.InputDate deGioVe;
        private Taxi.Controls.Base.Controls.ShLabel label2;
        private Taxi.Controls.Base.Controls.ShLabel label6;
        private Taxi.Controls.Base.Inputs.InputText txtGhiChu;
        private Taxi.Controls.Common.LookupEdits.LookupEdit_BanCo_GiamSatXe_Reason lookupEdit_BanCo_GiamSatXe_Reason;
    }
}