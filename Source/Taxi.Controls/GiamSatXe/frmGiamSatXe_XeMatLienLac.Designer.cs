namespace TaxiOperation_BanCo.GiamSatXe
{
    partial class frmGiamSatXe_XeMatLienLac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiamSatXe_XeMatLienLac));
            this.txtSoHieu = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.lblmsg = new Taxi.Controls.Base.Controls.ShLabel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.label5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblTenLaiXe = new Taxi.Controls.Base.Controls.ShLabel();
            this.label1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.deThoiDiem = new Taxi.Controls.Base.Inputs.InputDate();
            this.txtGhiChu = new Taxi.Controls.Base.Inputs.InputText();
            this.lVungDieuHanh = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.label2 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiDiem.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lVungDieuHanh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoHieu
            // 
            this.txtSoHieu.IsChangeText = false;
            this.txtSoHieu.IsFocus = false;
            this.txtSoHieu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.txtSoHieu.Location = new System.Drawing.Point(95, 6);
            this.txtSoHieu.Name = "txtSoHieu";
            this.txtSoHieu.Properties.AllowFocused = false;
            this.txtSoHieu.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHieu.Properties.Appearance.Options.UseFont = true;
            this.txtSoHieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoHieu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoHieuXe", 50, "Số hiệu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaLaiXe", 100, "Mã nhân viên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhanVien", "Tên nhân viên", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.True)});
            this.txtSoHieu.Properties.NullText = "Chọn xe";
            this.txtSoHieu.Properties.PopupWidth = 330;
            this.txtSoHieu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtSoHieu.Properties.ValidateOnEnterKey = true;
            this.txtSoHieu.Size = new System.Drawing.Size(88, 25);
            this.txtSoHieu.TabIndex = 0;
            this.txtSoHieu.ToolTip = "Số xe";
            this.txtSoHieu.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.txtSoHieu_Closed);
            this.txtSoHieu.EditValueChanged += new System.EventHandler(this.txtSoHieu_EditValueChanged);
            this.txtSoHieu.TextChanged += new System.EventHandler(this.txtSoHieu_TextChanged);
            this.txtSoHieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoHieu_KeyDown);
            this.txtSoHieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHieu_KeyPress);
            this.txtSoHieu.Leave += new System.EventHandler(this.txtSoHieu_Leave);
            // 
            // lblmsg
            // 
            this.lblmsg.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(83, 126);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 19);
            this.lblmsg.TabIndex = 25;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.Close;
            this.btnThoat.Location = new System.Drawing.Point(172, 153);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(111, 30);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát (Esc)";
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Image = global::Taxi.Controls.Properties.Resources.disk;
            this.btnLuu.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnLuu.Location = new System.Drawing.Point(59, 153);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(104, 30);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu (F2)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label5
            // 
            this.label5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "&Ghi chú";
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "Số &xe *";
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLaiXe.Location = new System.Drawing.Point(192, 12);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(0, 19);
            this.lblTenLaiXe.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "&Thời điểm *";
            // 
            // deThoiDiem
            // 
            this.deThoiDiem.DateNowWhenLoad = true;
            this.deThoiDiem.EditValue = new System.DateTime(2014, 6, 4, 14, 31, 22, 333);
            this.deThoiDiem.IsChangeText = false;
            this.deThoiDiem.IsFocus = false;
            this.deThoiDiem.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.deThoiDiem.Location = new System.Drawing.Point(95, 97);
            this.deThoiDiem.Name = "deThoiDiem";
            this.deThoiDiem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.deThoiDiem.Properties.Appearance.Options.UseFont = true;
            this.deThoiDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deThoiDiem.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deThoiDiem.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deThoiDiem.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deThoiDiem.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deThoiDiem.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.deThoiDiem.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deThoiDiem.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deThoiDiem.Size = new System.Drawing.Size(227, 23);
            this.deThoiDiem.TabIndex = 2;
            this.deThoiDiem.TextChanged += new System.EventHandler(this.deThoiDiem_TextChanged);
            this.deThoiDiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deThoiDiem_KeyDown);
            this.deThoiDiem.Leave += new System.EventHandler(this.deThoiDiem_Leave);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.IsChangeText = false;
            this.txtGhiChu.IsFocus = false;
            this.txtGhiChu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.txtGhiChu.Location = new System.Drawing.Point(95, 67);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu.Size = new System.Drawing.Size(227, 22);
            this.txtGhiChu.TabIndex = 1;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhiChu_KeyDown);
            this.txtGhiChu.Leave += new System.EventHandler(this.txtGhiChu_Leave);
            // 
            // lVungDieuHanh
            // 
            this.lVungDieuHanh.IsChangeText = false;
            this.lVungDieuHanh.IsFocus = false;
            this.lVungDieuHanh.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.lVungDieuHanh.Location = new System.Drawing.Point(95, 37);
            this.lVungDieuHanh.Name = "lVungDieuHanh";
            this.lVungDieuHanh.Properties.AllowFocused = false;
            this.lVungDieuHanh.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVungDieuHanh.Properties.Appearance.Options.UseFont = true;
            this.lVungDieuHanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lVungDieuHanh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenVung", "vùng điều hành"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lVungDieuHanh.Properties.DisplayMember = "NameVungDH";
            this.lVungDieuHanh.Properties.NullText = "Chọn vùng";
            this.lVungDieuHanh.Properties.PopupWidth = 330;
            this.lVungDieuHanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lVungDieuHanh.Properties.ValidateOnEnterKey = true;
            this.lVungDieuHanh.Size = new System.Drawing.Size(227, 25);
            this.lVungDieuHanh.TabIndex = 34;
            this.lVungDieuHanh.ToolTip = "Số xe";
            this.lVungDieuHanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lVungDieuHanh_KeyDown);
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 35;
            this.label2.Text = "&Điểm đỗ *";
            // 
            // frmGiamSatXe_XeMatLienLac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(334, 189);
            this.Controls.Add(this.lVungDieuHanh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.deThoiDiem);
            this.Controls.Add(this.txtSoHieu);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTenLaiXe);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(343, 185);
            this.Name = "frmGiamSatXe_XeMatLienLac";
            this.Text = "Xe mất liên lạc";
            this.Load += new System.EventHandler(this.frmGiamSatXe_XeMatLienLac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiDiem.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lVungDieuHanh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Inputs.InputLookUp txtSoHieu;
        private Taxi.Controls.Base.Controls.ShLabel lblmsg;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private Taxi.Controls.Base.Controls.ShLabel label5;
        private Taxi.Controls.Base.Controls.ShLabel label3;
        private Taxi.Controls.Base.Controls.ShLabel lblTenLaiXe;
        private Taxi.Controls.Base.Controls.ShLabel label1;
        private Taxi.Controls.Base.Inputs.InputDate deThoiDiem;
        private Taxi.Controls.Base.Inputs.InputText txtGhiChu;
        private Taxi.Controls.Base.Inputs.InputLookUp lVungDieuHanh;
        private Taxi.Controls.Base.Controls.ShLabel label2;
    }
}