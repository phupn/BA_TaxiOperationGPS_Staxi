﻿namespace TaxiOperation_BanCo.GiamSatXe
{
    partial class frmGiamSatXe_ChuyenVung_XinDiemDo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiamSatXe_ChuyenVung_XinDiemDo));
            this.lVungDieuHanh = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.txtSoHieu = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.lblmsg = new Taxi.Controls.Base.Controls.ShLabel();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.label2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.label3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblTenLaiXe = new Taxi.Controls.Base.Controls.ShLabel();
            this.label1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.deThoiDiem = new Taxi.Controls.Base.Inputs.InputDate();
            this.lblViTri = new Taxi.Controls.Base.Controls.ShLabel();
            this.TxtNode = new Taxi.Controls.Base.Inputs.InputText();
            this.label4 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lVungDieuHanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiDiem.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lVungDieuHanh
            // 
            this.lVungDieuHanh.IsChangeText = false;
            this.lVungDieuHanh.IsFocus = false;
            this.lVungDieuHanh.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.lVungDieuHanh.Location = new System.Drawing.Point(96, 62);
            this.lVungDieuHanh.Name = "lVungDieuHanh";
            this.lVungDieuHanh.Properties.AllowFocused = false;
            this.lVungDieuHanh.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVungDieuHanh.Properties.Appearance.Options.UseFont = true;
            this.lVungDieuHanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lVungDieuHanh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenVung", "vùng điều hành")});
            this.lVungDieuHanh.Properties.DisplayMember = "NameVungDH";
            this.lVungDieuHanh.Properties.MaxLength = 255;
            this.lVungDieuHanh.Properties.NullText = "Chọn vùng";
            this.lVungDieuHanh.Properties.PopupWidth = 330;
            this.lVungDieuHanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lVungDieuHanh.Properties.ValidateOnEnterKey = true;
            this.lVungDieuHanh.Size = new System.Drawing.Size(151, 25);
            this.lVungDieuHanh.TabIndex = 1;
            this.lVungDieuHanh.ToolTip = "Số xe";
            this.lVungDieuHanh.TextChanged += new System.EventHandler(this.lVungDieuHanh_TextChanged);
            this.lVungDieuHanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lVungDieuHanh_KeyDown);
            this.lVungDieuHanh.Leave += new System.EventHandler(this.lVungDieuHanh_Leave);
            // 
            // txtSoHieu
            // 
            this.txtSoHieu.IsChangeText = false;
            this.txtSoHieu.IsFocus = false;
            this.txtSoHieu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.txtSoHieu.Location = new System.Drawing.Point(96, 9);
            this.txtSoHieu.Name = "txtSoHieu";
            this.txtSoHieu.Properties.AllowFocused = false;
            this.txtSoHieu.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHieu.Properties.Appearance.Options.UseFont = true;
            this.txtSoHieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoHieu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoHieuXe", 50, "Số hiệu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaLaiXe", 100, "Mã lái xe"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLaiXe", "Tên lái xe", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.lblmsg.Location = new System.Drawing.Point(96, 122);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 19);
            this.lblmsg.TabIndex = 37;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.Close;
            this.btnThoat.Location = new System.Drawing.Point(173, 146);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 30);
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
            this.btnLuu.Location = new System.Drawing.Point(65, 146);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(103, 30);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu (F2)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnLuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnLuu_KeyDown);
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 35;
            this.label2.Text = "&Vùng *";
            // 
            // label5
            // 
            this.label5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 19);
            this.label5.TabIndex = 36;
            this.label5.Text = "Vị trí";
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "Số &xe *";
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLaiXe.Location = new System.Drawing.Point(191, 13);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(0, 19);
            this.lblTenLaiXe.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "&Thời điểm *";
            // 
            // deThoiDiem
            // 
            this.deThoiDiem.DateNowWhenLoad = true;
            this.deThoiDiem.EditValue = new System.DateTime(2014, 6, 4, 14, 31, 22, 333);
            this.deThoiDiem.IsChangeText = false;
            this.deThoiDiem.IsFocus = false;
            this.deThoiDiem.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.deThoiDiem.Location = new System.Drawing.Point(96, 93);
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
            this.deThoiDiem.Size = new System.Drawing.Size(239, 23);
            this.deThoiDiem.TabIndex = 3;
            this.deThoiDiem.TextChanged += new System.EventHandler(this.deThoiDiem_TextChanged);
            this.deThoiDiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deThoiDiem_KeyDown);
            this.deThoiDiem.Leave += new System.EventHandler(this.deThoiDiem_Leave);
            // 
            // lblViTri
            // 
            this.lblViTri.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViTri.Location = new System.Drawing.Point(99, 37);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(0, 19);
            this.lblViTri.TabIndex = 38;
            // 
            // TxtNode
            // 
            this.TxtNode.IsChangeText = false;
            this.TxtNode.IsFocus = false;
            this.TxtNode.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.TxtNode.Location = new System.Drawing.Point(280, 62);
            this.TxtNode.Name = "TxtNode";
            this.TxtNode.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.TxtNode.Properties.Appearance.Options.UseFont = true;
            this.TxtNode.Size = new System.Drawing.Size(53, 25);
            this.TxtNode.TabIndex = 2;
            this.TxtNode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNode_KeyDown);
            // 
            // label4
            // 
            this.label4.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label4.Location = new System.Drawing.Point(251, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "&Số";
            // 
            // frmGiamSatXe_ChuyenVung_XinDiemDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(345, 182);
            this.Controls.Add(this.TxtNode);
            this.Controls.Add(this.lblViTri);
            this.Controls.Add(this.deThoiDiem);
            this.Controls.Add(this.lVungDieuHanh);
            this.Controls.Add(this.txtSoHieu);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTenLaiXe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 204);
            this.Name = "frmGiamSatXe_ChuyenVung_XinDiemDo";
            this.Text = "Xe chuyển vùng / Xin điểm đỗ";
            this.Load += new System.EventHandler(this.frmGiamSatXe_ChuyenVung_XinDiemDo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lVungDieuHanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiDiem.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Inputs.InputLookUp lVungDieuHanh;
        private Taxi.Controls.Base.Inputs.InputLookUp txtSoHieu;
        private Taxi.Controls.Base.Controls.ShLabel lblmsg;
        private Taxi.Controls.Base.Controls.ShButton btnThoat;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private Taxi.Controls.Base.Controls.ShLabel label2;
        private Taxi.Controls.Base.Controls.ShLabel label5;
        private Taxi.Controls.Base.Controls.ShLabel label3;
        private Taxi.Controls.Base.Controls.ShLabel lblTenLaiXe;
        private Taxi.Controls.Base.Controls.ShLabel label1;
        private Taxi.Controls.Base.Inputs.InputDate deThoiDiem;
        private Taxi.Controls.Base.Controls.ShLabel lblViTri;
        private Taxi.Controls.Base.Inputs.InputText TxtNode;
        private Taxi.Controls.Base.Controls.ShLabel label4;
    }
}