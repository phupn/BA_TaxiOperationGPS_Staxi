namespace TaxiOperation_BanCo.GiamSatXe
{
    partial class frmGiamSatXe_BaoKhaiThac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiamSatXe_BaoKhaiThac));
            this.deGioDi = new Taxi.Controls.Base.Inputs.InputDate();
            this.lblmsg = new Taxi.Controls.Base.Controls.ShLabel();
            this.label5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoHieu = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.lblTenLaiXe = new Taxi.Controls.Base.Controls.ShLabel();
            this.label1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.label2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtDongHo = new Taxi.Controls.Base.Inputs.InputText();
            this.txtViTri = new Taxi.Controls.Base.Inputs.InputText();
            this.lVungDieuHanh = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.label4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDongHo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lVungDieuHanh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deGioDi
            // 
            this.deGioDi.DateNowWhenLoad = true;
            this.deGioDi.EditValue = new System.DateTime(2014, 6, 4, 14, 31, 22, 333);
            this.deGioDi.IsChangeText = false;
            this.deGioDi.IsFocus = false;
            this.deGioDi.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.deGioDi.Location = new System.Drawing.Point(99, 132);
            this.deGioDi.Name = "deGioDi";
            this.deGioDi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.deGioDi.Properties.Appearance.Options.UseFont = true;
            this.deGioDi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deGioDi.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deGioDi.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deGioDi.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deGioDi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deGioDi.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.deGioDi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deGioDi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deGioDi.Size = new System.Drawing.Size(227, 23);
            this.deGioDi.TabIndex = 3;
            // 
            // lblmsg
            // 
            this.lblmsg.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(99, 161);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 19);
            this.lblmsg.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 42;
            this.label5.Text = "Địa &chỉ *";
            // 
            // txtSoHieu
            // 
            this.txtSoHieu.IsChangeText = false;
            this.txtSoHieu.IsFocus = false;
            this.txtSoHieu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.txtSoHieu.Location = new System.Drawing.Point(99, 12);
            this.txtSoHieu.Name = "txtSoHieu";
            this.txtSoHieu.Properties.AllowFocused = false;
            this.txtSoHieu.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHieu.Properties.Appearance.Options.UseFont = true;
            this.txtSoHieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoHieu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoHieuXe", 50, "Số hiệu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaLaiXe", 100, "Mã nhân viên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhanVien", "Tên nhân viên", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.txtSoHieu.Properties.MaxLength = 10;
            this.txtSoHieu.Properties.NullText = "Chọn xe";
            this.txtSoHieu.Properties.PopupWidth = 330;
            this.txtSoHieu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtSoHieu.Properties.ValidateOnEnterKey = true;
            this.txtSoHieu.Size = new System.Drawing.Size(88, 25);
            this.txtSoHieu.TabIndex = 0;
            this.txtSoHieu.ToolTip = "Số xe";
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLaiXe.Location = new System.Drawing.Point(193, 14);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(0, 19);
            this.lblTenLaiXe.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "Thời &điểm *";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.Close;
            this.btnThoat.Location = new System.Drawing.Point(171, 186);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 30);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát (Esc)";
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Image = global::Taxi.Controls.Properties.Resources.disk;
            this.btnLuu.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnLuu.Location = new System.Drawing.Point(66, 186);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(99, 30);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu (F2)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 47;
            this.label2.Text = "Đồng &hồ";
            // 
            // txtDongHo
            // 
            this.txtDongHo.IsChangeText = false;
            this.txtDongHo.IsFocus = false;
            this.txtDongHo.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.txtDongHo.Location = new System.Drawing.Point(99, 43);
            this.txtDongHo.Name = "txtDongHo";
            this.txtDongHo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDongHo.Properties.Appearance.Options.UseFont = true;
            this.txtDongHo.Properties.Mask.EditMask = "d";
            this.txtDongHo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDongHo.Properties.MaxLength = 7;
            this.txtDongHo.Size = new System.Drawing.Size(226, 22);
            this.txtDongHo.TabIndex = 1;
            // 
            // txtViTri
            // 
            this.txtViTri.IsChangeText = false;
            this.txtViTri.IsFocus = false;
            this.txtViTri.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.txtViTri.Location = new System.Drawing.Point(99, 72);
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtViTri.Properties.Appearance.Options.UseFont = true;
            this.txtViTri.Properties.MaxLength = 255;
            this.txtViTri.Size = new System.Drawing.Size(226, 22);
            this.txtViTri.TabIndex = 2;
            // 
            // lVungDieuHanh
            // 
            this.lVungDieuHanh.IsChangeText = false;
            this.lVungDieuHanh.IsFocus = false;
            this.lVungDieuHanh.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.lVungDieuHanh.Location = new System.Drawing.Point(99, 101);
            this.lVungDieuHanh.Name = "lVungDieuHanh";
            this.lVungDieuHanh.Properties.AllowFocused = false;
            this.lVungDieuHanh.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lVungDieuHanh.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVungDieuHanh.Properties.Appearance.Options.UseFont = true;
            this.lVungDieuHanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lVungDieuHanh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenVung", "vùng điều hành")});
            this.lVungDieuHanh.Properties.DisplayMember = "NameVungDH";
            this.lVungDieuHanh.Properties.MaxLength = 50;
            this.lVungDieuHanh.Properties.NullText = "Chọn vùng";
            this.lVungDieuHanh.Properties.PopupWidth = 330;
            this.lVungDieuHanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lVungDieuHanh.Properties.ValidateOnEnterKey = true;
            this.lVungDieuHanh.Size = new System.Drawing.Size(227, 25);
            this.lVungDieuHanh.TabIndex = 48;
            this.lVungDieuHanh.ToolTip = "Số xe";
            // 
            // label4
            // 
            this.label4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 19);
            this.label4.TabIndex = 49;
            this.label4.Text = "&Vùng";
            // 
            // shLabel1
            // 
            this.shLabel1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel1.Location = new System.Drawing.Point(18, 14);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(47, 19);
            this.shLabel1.TabIndex = 47;
            this.shLabel1.Text = "Số &xe *";
            // 
            // frmGiamSatXe_BaoKhaiThac
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(344, 228);
            this.Controls.Add(this.lVungDieuHanh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtViTri);
            this.Controls.Add(this.txtDongHo);
            this.Controls.Add(this.shLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deGioDi);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoHieu);
            this.Controls.Add(this.lblTenLaiXe);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(356, 245);
            this.Name = "frmGiamSatXe_BaoKhaiThac";
            this.Text = "Xe báo khai thác";
            this.Load += new System.EventHandler(this.frmGiamSatXe_BaoKhaiThac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDongHo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lVungDieuHanh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Inputs.InputDate deGioDi;
        private Taxi.Controls.Base.Controls.ShLabel lblmsg;
        private Taxi.Controls.Base.Controls.ShButton btnThoat;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private Taxi.Controls.Base.Controls.ShLabel label5;
        private Taxi.Controls.Base.Inputs.InputLookUp txtSoHieu;
        private Taxi.Controls.Base.Controls.ShLabel lblTenLaiXe;
        private Taxi.Controls.Base.Controls.ShLabel label1;
        private Taxi.Controls.Base.Controls.ShLabel label2;
        private Taxi.Controls.Base.Inputs.InputText txtDongHo;
        private Taxi.Controls.Base.Inputs.InputText txtViTri;
        private Taxi.Controls.Base.Inputs.InputLookUp lVungDieuHanh;
        private Taxi.Controls.Base.Controls.ShLabel label4;
        private Taxi.Controls.Base.Controls.ShLabel shLabel1;
    }
}