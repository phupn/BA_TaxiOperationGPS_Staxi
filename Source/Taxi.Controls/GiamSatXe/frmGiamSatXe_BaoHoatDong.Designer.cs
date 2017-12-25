namespace TaxiOperation_BanCo.GiamSatXe
{
    partial class frmGiamSatXe_BaoHoatDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiamSatXe_BaoHoatDong));
            this.txtSoHieu = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTenLaiXe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblmsg = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.lVungDieuHanh = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.deGioDi = new DevExpress.XtraEditors.DateEdit();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lVungDieuHanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoHieu
            // 
            this.txtSoHieu.Location = new System.Drawing.Point(105, 11);
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
            this.txtSoHieu.EditValueChanged += new System.EventHandler(this.txtSoHieu_EditValueChanged);
            this.txtSoHieu.TextChanged += new System.EventHandler(this.txtSoHieu_TextChanged);
            this.txtSoHieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHieu_KeyPress);
            this.txtSoHieu.Leave += new System.EventHandler(this.txtSoHieu_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "Số xe *";
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.AutoSize = true;
            this.lblTenLaiXe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLaiXe.Location = new System.Drawing.Point(199, 13);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(0, 19);
            this.lblTenLaiXe.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 27;
            this.label1.Text = "Thời điểm *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 30;
            this.label5.Text = "Ghi chú";
            // 
            // lblmsg
            // 
            this.lblmsg.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(106, 130);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 19);
            this.lblmsg.TabIndex = 33;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.Close;
            this.btnThoat.Location = new System.Drawing.Point(174, 154);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(109, 30);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát (Esc)";
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Image = global::Taxi.Controls.Properties.Resources.disk;
            this.btnLuu.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnLuu.Location = new System.Drawing.Point(68, 154);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(97, 30);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu (F2)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lVungDieuHanh
            // 
            this.lVungDieuHanh.Location = new System.Drawing.Point(105, 42);
            this.lVungDieuHanh.Name = "lVungDieuHanh";
            this.lVungDieuHanh.Properties.AllowFocused = false;
            this.lVungDieuHanh.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVungDieuHanh.Properties.Appearance.Options.UseFont = true;
            this.lVungDieuHanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lVungDieuHanh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenVung", "vùng điều hành"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lVungDieuHanh.Properties.NullText = "Chọn vùng";
            this.lVungDieuHanh.Properties.PopupWidth = 330;
            this.lVungDieuHanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lVungDieuHanh.Properties.ValidateOnEnterKey = true;
            this.lVungDieuHanh.Size = new System.Drawing.Size(228, 25);
            this.lVungDieuHanh.TabIndex = 1;
            this.lVungDieuHanh.EditValueChanged += new System.EventHandler(this.lVungDieuHanh_EditValueChanged);
            this.lVungDieuHanh.TextChanged += new System.EventHandler(this.lVungDieuHanh_TextChanged);
            this.lVungDieuHanh.Leave += new System.EventHandler(this.lVungDieuHanh_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 34;
            this.label2.Text = "Điểm đỗ *";
            // 
            // deGioDi
            // 
            this.deGioDi.EditValue = new System.DateTime(2014, 6, 4, 14, 31, 22, 333);
            this.deGioDi.Location = new System.Drawing.Point(105, 102);
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
            this.deGioDi.TextChanged += new System.EventHandler(this.deGioDi_TextChanged);
            this.deGioDi.Leave += new System.EventHandler(this.deGioDi_Leave);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(105, 73);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(227, 23);
            this.txtGhiChu.TabIndex = 2;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            this.txtGhiChu.Leave += new System.EventHandler(this.txtGhiChu_Leave);
            // 
            // frmGiamSatXe_BaoHoatDong
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(350, 196);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.deGioDi);
            this.Controls.Add(this.lVungDieuHanh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoHieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTenLaiXe);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(366, 210);
            this.Name = "frmGiamSatXe_BaoHoatDong";
            this.Text = "Xe báo hoạt động";
            this.Load += new System.EventHandler(this.frmGiamSatXe_BaoHoatDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lVungDieuHanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit txtSoHieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTenLaiXe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LabelControl lblmsg;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private DevExpress.XtraEditors.LookUpEdit lVungDieuHanh;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit deGioDi;
        private System.Windows.Forms.TextBox txtGhiChu;
    }
}