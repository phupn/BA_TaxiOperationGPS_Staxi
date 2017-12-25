namespace TaxiOperation_BanCo.GiamSatXe
{
    partial class frmGiamSatXe_BaoRoiXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiamSatXe_BaoRoiXe));
            this.txtSoHieu = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.lblmsg = new Taxi.Controls.Base.Controls.ShLabel();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.label5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label6 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblTenLaiXe = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblThoiGianBao = new Taxi.Controls.Base.Controls.ShLabel();
            this.label1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtGhiChu = new Taxi.Controls.Base.Inputs.InputText();
            this.lblViTri = new Taxi.Controls.Base.Controls.ShLabel();
            this.spin_SoPhutNghi = new Taxi.Controls.Base.Inputs.InputSpin();
            this.chkAnDiemDo = new Taxi.Controls.Base.Inputs.InputCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_SoPhutNghi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnDiemDo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoHieu
            // 
            this.txtSoHieu.IsChangeText = false;
            this.txtSoHieu.IsFocus = false;
            this.txtSoHieu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.txtSoHieu.Location = new System.Drawing.Point(115, 35);
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
            this.lblmsg.Location = new System.Drawing.Point(115, 150);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 19);
            this.lblmsg.TabIndex = 28;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.Close;
            this.btnThoat.Location = new System.Drawing.Point(191, 174);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(105, 30);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát (Esc)";
            this.btnThoat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnThoat_KeyDown);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Image = global::Taxi.Controls.Properties.Resources.disk;
            this.btnLuu.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnLuu.Location = new System.Drawing.Point(85, 174);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 30);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu (F2)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnLuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnLuu_KeyDown);
            // 
            // label5
            // 
            this.label5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "Ghi &chú";
            // 
            // label6
            // 
            this.label6.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(208, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "(Phút)";
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "Số phút &nghỉ *";
            // 
            // label4
            // 
            this.label4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 27;
            this.label4.Text = "Vị trí  *";
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "Số &xe *";
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLaiXe.Location = new System.Drawing.Point(208, 37);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(0, 19);
            this.lblTenLaiXe.TabIndex = 20;
            // 
            // lblThoiGianBao
            // 
            this.lblThoiGianBao.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianBao.Location = new System.Drawing.Point(116, 10);
            this.lblThoiGianBao.Name = "lblThoiGianBao";
            this.lblThoiGianBao.Size = new System.Drawing.Size(0, 19);
            this.lblThoiGianBao.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Thời gian báo";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.IsChangeText = false;
            this.txtGhiChu.IsFocus = false;
            this.txtGhiChu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.txtGhiChu.Location = new System.Drawing.Point(115, 93);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu.Properties.MaxLength = 255;
            this.txtGhiChu.Size = new System.Drawing.Size(237, 22);
            this.txtGhiChu.TabIndex = 2;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhiChu_KeyDown);
            // 
            // lblViTri
            // 
            this.lblViTri.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViTri.Location = new System.Drawing.Point(116, 67);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(0, 19);
            this.lblViTri.TabIndex = 29;
            // 
            // spin_SoPhutNghi
            // 
            this.spin_SoPhutNghi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spin_SoPhutNghi.KeyCommand = System.Windows.Forms.Keys.None;
            this.spin_SoPhutNghi.Location = new System.Drawing.Point(115, 121);
            this.spin_SoPhutNghi.Name = "spin_SoPhutNghi";
            this.spin_SoPhutNghi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spin_SoPhutNghi.Properties.Appearance.Options.UseFont = true;
            this.spin_SoPhutNghi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spin_SoPhutNghi.Properties.IsFloatValue = false;
            this.spin_SoPhutNghi.Properties.Mask.EditMask = "N00";
            this.spin_SoPhutNghi.Properties.MaxLength = 4;
            this.spin_SoPhutNghi.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spin_SoPhutNghi.Size = new System.Drawing.Size(88, 22);
            this.spin_SoPhutNghi.TabIndex = 3;
            this.spin_SoPhutNghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoPhutNghi_KeyDown);
            // 
            // chkAnDiemDo
            // 
            this.chkAnDiemDo.IsChangeText = false;
            this.chkAnDiemDo.IsFocus = false;
            this.chkAnDiemDo.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.chkAnDiemDo.Location = new System.Drawing.Point(277, 122);
            this.chkAnDiemDo.Name = "chkAnDiemDo";
            this.chkAnDiemDo.Properties.Caption = "&Ẩn điểm đỗ";
            this.chkAnDiemDo.Size = new System.Drawing.Size(75, 19);
            this.chkAnDiemDo.TabIndex = 30;
            this.chkAnDiemDo.ToolTip = "Xe xin ra ngoài lâu, ẩn luôn ở cột giám sát xe (cột 3)";
            this.chkAnDiemDo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAnDiemDo_KeyDown);
            // 
            // frmGiamSatXe_BaoRoiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(367, 208);
            this.Controls.Add(this.chkAnDiemDo);
            this.Controls.Add(this.spin_SoPhutNghi);
            this.Controls.Add(this.lblViTri);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtSoHieu);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTenLaiXe);
            this.Controls.Add(this.lblThoiGianBao);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(369, 213);
            this.Name = "frmGiamSatXe_BaoRoiXe";
            this.Text = "Xe báo rời xe";
            this.Load += new System.EventHandler(this.frmGiamSatXe_BaoRoiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_SoPhutNghi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnDiemDo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Inputs.InputLookUp txtSoHieu;
        private Taxi.Controls.Base.Controls.ShLabel lblmsg;
        private Taxi.Controls.Base.Controls.ShButton btnThoat;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private Taxi.Controls.Base.Controls.ShLabel label5;
        private Taxi.Controls.Base.Controls.ShLabel label6;
        private Taxi.Controls.Base.Controls.ShLabel label2;
        private Taxi.Controls.Base.Controls.ShLabel label4;
        private Taxi.Controls.Base.Controls.ShLabel label3;
        private Taxi.Controls.Base.Controls.ShLabel lblTenLaiXe;
        private Taxi.Controls.Base.Controls.ShLabel lblThoiGianBao;
        private Taxi.Controls.Base.Controls.ShLabel label1;
        private Taxi.Controls.Base.Inputs.InputText txtGhiChu;
        private Taxi.Controls.Base.Controls.ShLabel lblViTri;
        private Taxi.Controls.Base.Inputs.InputSpin spin_SoPhutNghi;
        private Taxi.Controls.Base.Inputs.InputCheckbox chkAnDiemDo;
    }
}