namespace Taxi.Controls.ThueBaoTuyen
{
    partial class frmNhapTuyenDuongDai
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
            this.groupAll = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.btnSave = new Taxi.Controls.Base.Controls.ShButton();
            this.shLabel8 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtThoiGian = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel7 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtKm = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel6 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtGia = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblPhuTroi = new Taxi.Controls.Base.Controls.ShLabel();
            this.cboLoaiXe = new Taxi.Controls.Base.Common.InputLookUps.InputLookUp_LoaiXe();
            this.cboChieu = new DevExpress.XtraEditors.LookUpEdit();
            this.cboChayTuyen = new DevExpress.XtraEditors.LookUpEdit();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAll)).BeginInit();
            this.groupAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChayTuyen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Size = new System.Drawing.Size(415, 27);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // groupAll
            // 
            this.groupAll.Controls.Add(this.btnSave);
            this.groupAll.Controls.Add(this.shLabel8);
            this.groupAll.Controls.Add(this.txtThoiGian);
            this.groupAll.Controls.Add(this.shLabel7);
            this.groupAll.Controls.Add(this.txtKm);
            this.groupAll.Controls.Add(this.shLabel6);
            this.groupAll.Controls.Add(this.txtGia);
            this.groupAll.Controls.Add(this.shLabel5);
            this.groupAll.Controls.Add(this.lblPhuTroi);
            this.groupAll.Controls.Add(this.cboLoaiXe);
            this.groupAll.Controls.Add(this.cboChieu);
            this.groupAll.Controls.Add(this.cboChayTuyen);
            this.groupAll.Controls.Add(this.shLabel3);
            this.groupAll.Controls.Add(this.shLabel2);
            this.groupAll.Controls.Add(this.shLabel1);
            this.groupAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAll.Location = new System.Drawing.Point(0, 27);
            this.groupAll.Name = "groupAll";
            this.groupAll.Size = new System.Drawing.Size(415, 171);
            this.groupAll.TabIndex = 1;
            this.groupAll.Text = "Nhập cuốc đường dài ( ESC: Thoát )";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(166, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu (F2)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // shLabel8
            // 
            this.shLabel8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel8.Location = new System.Drawing.Point(347, 96);
            this.shLabel8.Name = "shLabel8";
            this.shLabel8.Size = new System.Drawing.Size(16, 14);
            this.shLabel8.TabIndex = 15;
            this.shLabel8.Text = "giờ";
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.IsChangeText = false;
            this.txtThoiGian.IsFocus = false;
            this.txtThoiGian.Location = new System.Drawing.Point(281, 92);
            this.txtThoiGian.MenuManager = this.ribbon;
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Properties.Mask.EditMask = "d";
            this.txtThoiGian.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtThoiGian.Properties.MaxLength = 6;
            this.txtThoiGian.Size = new System.Drawing.Size(58, 20);
            this.txtThoiGian.TabIndex = 5;
            // 
            // shLabel7
            // 
            this.shLabel7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel7.Location = new System.Drawing.Point(225, 96);
            this.shLabel7.Name = "shLabel7";
            this.shLabel7.Size = new System.Drawing.Size(50, 14);
            this.shLabel7.TabIndex = 13;
            this.shLabel7.Text = "Thời gian";
            // 
            // txtKm
            // 
            this.txtKm.IsChangeText = false;
            this.txtKm.IsFocus = false;
            this.txtKm.Location = new System.Drawing.Point(151, 92);
            this.txtKm.MenuManager = this.ribbon;
            this.txtKm.Name = "txtKm";
            this.txtKm.Properties.Mask.EditMask = "d";
            this.txtKm.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtKm.Properties.MaxLength = 9;
            this.txtKm.Size = new System.Drawing.Size(68, 20);
            this.txtKm.TabIndex = 4;
            // 
            // shLabel6
            // 
            this.shLabel6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel6.Location = new System.Drawing.Point(129, 95);
            this.shLabel6.Name = "shLabel6";
            this.shLabel6.Size = new System.Drawing.Size(17, 14);
            this.shLabel6.TabIndex = 11;
            this.shLabel6.Text = "Km";
            // 
            // txtGia
            // 
            this.txtGia.IsChangeText = false;
            this.txtGia.IsFocus = false;
            this.txtGia.Location = new System.Drawing.Point(56, 93);
            this.txtGia.MenuManager = this.ribbon;
            this.txtGia.Name = "txtGia";
            this.txtGia.Properties.Mask.EditMask = "d";
            this.txtGia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGia.Properties.MaxLength = 9;
            this.txtGia.Size = new System.Drawing.Size(67, 20);
            this.txtGia.TabIndex = 3;
            // 
            // shLabel5
            // 
            this.shLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel5.Location = new System.Drawing.Point(34, 96);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(16, 14);
            this.shLabel5.TabIndex = 9;
            this.shLabel5.Text = "Giá";
            // 
            // lblPhuTroi
            // 
            this.lblPhuTroi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuTroi.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblPhuTroi.Location = new System.Drawing.Point(225, 66);
            this.lblPhuTroi.Name = "lblPhuTroi";
            this.lblPhuTroi.Size = new System.Drawing.Size(179, 13);
            this.lblPhuTroi.TabIndex = 8;
            this.lblPhuTroi.Text = "Phụ trội 8,500 đ/Km và 10,000 đ/Giờ.";
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.DefaultSelectFirstRow = false;
            this.cboLoaiXe.IsChangeText = false;
            this.cboLoaiXe.IsFocus = false;
            this.cboLoaiXe.IsShowTextNull = true;
            this.cboLoaiXe.Location = new System.Drawing.Point(56, 63);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiXe.Properties.NullText = "Chọn loại xe";
            this.cboLoaiXe.Size = new System.Drawing.Size(163, 20);
            this.cboLoaiXe.TabIndex = 2;
            this.cboLoaiXe.EditValueChanged += new System.EventHandler(this.cboLoaiXe_EditValueChanged);
            // 
            // cboChieu
            // 
            this.cboChieu.Location = new System.Drawing.Point(261, 32);
            this.cboChieu.Name = "cboChieu";
            this.cboChieu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChieu.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cboChieu.Properties.Appearance.Options.UseFont = true;
            this.cboChieu.Properties.Appearance.Options.UseForeColor = true;
            this.cboChieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboChieu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", 40, "Chiều")});
            this.cboChieu.Properties.DisplayMember = "ChayTuyen";
            this.cboChieu.Properties.NullText = "Chọn chiều";
            this.cboChieu.Properties.PopupWidth = 330;
            this.cboChieu.Properties.ValidateOnEnterKey = true;
            this.cboChieu.Size = new System.Drawing.Size(102, 20);
            this.cboChieu.TabIndex = 1;
            this.cboChieu.EditValueChanged += new System.EventHandler(this.cboChieu_EditValueChanged);
            // 
            // cboChayTuyen
            // 
            this.cboChayTuyen.Location = new System.Drawing.Point(56, 32);
            this.cboChayTuyen.Name = "cboChayTuyen";
            this.cboChayTuyen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChayTuyen.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cboChayTuyen.Properties.Appearance.Options.UseFont = true;
            this.cboChayTuyen.Properties.Appearance.Options.UseForeColor = true;
            this.cboChayTuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboChayTuyen.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TuyenDuongID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTuyenDuong", 40, "Tên tuyến")});
            this.cboChayTuyen.Properties.DisplayMember = "ChayTuyen";
            this.cboChayTuyen.Properties.NullText = "Chọn tuyến";
            this.cboChayTuyen.Properties.PopupWidth = 330;
            this.cboChayTuyen.Properties.ValidateOnEnterKey = true;
            this.cboChayTuyen.Size = new System.Drawing.Size(163, 20);
            this.cboChayTuyen.TabIndex = 0;
            this.cboChayTuyen.EditValueChanged += new System.EventHandler(this.cboChayTuyen_EditValueChanged);
            // 
            // shLabel3
            // 
            this.shLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel3.Location = new System.Drawing.Point(225, 35);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(30, 14);
            this.shLabel3.TabIndex = 2;
            this.shLabel3.Text = "Chiều";
            // 
            // shLabel2
            // 
            this.shLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel2.Location = new System.Drawing.Point(12, 65);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(38, 14);
            this.shLabel2.TabIndex = 1;
            this.shLabel2.Text = "Loại xe";
            // 
            // shLabel1
            // 
            this.shLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel1.Location = new System.Drawing.Point(15, 35);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(35, 14);
            this.shLabel1.TabIndex = 0;
            this.shLabel1.Text = "Tuyến";
            // 
            // frmNhapTuyenDuongDai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 198);
            this.Controls.Add(this.groupAll);
            this.KeyPreview = true;
            this.Name = "frmNhapTuyenDuongDai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập tuyến đường dài";
            this.Load += new System.EventHandler(this.frmNhapTuyenDuongDai_Load);
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.groupAll, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAll)).EndInit();
            this.groupAll.ResumeLayout(false);
            this.groupAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChayTuyen.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShGroupBox groupAll;
        private Base.Controls.ShLabel shLabel3;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel1;
        private DevExpress.XtraEditors.LookUpEdit cboChieu;
        private DevExpress.XtraEditors.LookUpEdit cboChayTuyen;
        private Base.Controls.ShButton btnSave;
        private Base.Controls.ShLabel shLabel8;
        private Base.Inputs.InputText txtThoiGian;
        private Base.Controls.ShLabel shLabel7;
        private Base.Inputs.InputText txtKm;
        private Base.Controls.ShLabel shLabel6;
        private Base.Inputs.InputText txtGia;
        private Base.Controls.ShLabel shLabel5;
        private Base.Controls.ShLabel lblPhuTroi;
        private Base.Common.InputLookUps.InputLookUp_LoaiXe cboLoaiXe;
    }
}