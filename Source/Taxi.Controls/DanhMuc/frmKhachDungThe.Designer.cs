namespace Taxi.Controls.DanhMuc
{
    partial class frmKhachDungThe
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
            this.deDenNgay = new Taxi.Controls.Base.Inputs.InputDate();
            this.deTuNgay = new Taxi.Controls.Base.Inputs.InputDate();
            this.shLabel6 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtMaThe = new Taxi.Controls.Base.Inputs.InputText();
            this.txtSDT = new Taxi.Controls.Base.Inputs.InputText();
            this.txtTenKH = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtMaKH = new Taxi.Controls.Base.Inputs.InputText();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.txtDiaChi = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel7 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaThe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deDenNgay
            // 
            this.deDenNgay.DateNowWhenLoad = true;
            this.deDenNgay.EditValue = null;
            this.deDenNgay.IsChangeText = false;
            this.deDenNgay.IsFocus = false;
            this.deDenNgay.Location = new System.Drawing.Point(86, 33);
            this.deDenNgay.Name = "deDenNgay";
            this.deDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deDenNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDenNgay.Size = new System.Drawing.Size(141, 20);
            this.deDenNgay.TabIndex = 1;
            // 
            // deTuNgay
            // 
            this.deTuNgay.DateNowWhenLoad = true;
            this.deTuNgay.EditValue = null;
            this.deTuNgay.IsChangeText = false;
            this.deTuNgay.IsFocus = false;
            this.deTuNgay.Location = new System.Drawing.Point(86, 7);
            this.deTuNgay.Name = "deTuNgay";
            this.deTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deTuNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTuNgay.Size = new System.Drawing.Size(141, 20);
            this.deTuNgay.TabIndex = 0;
            // 
            // shLabel6
            // 
            this.shLabel6.Location = new System.Drawing.Point(30, 114);
            this.shLabel6.Name = "shLabel6";
            this.shLabel6.Size = new System.Drawing.Size(20, 13);
            this.shLabel6.TabIndex = 7;
            this.shLabel6.Text = "SĐT";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(30, 92);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(34, 13);
            this.shLabel2.TabIndex = 8;
            this.shLabel2.Text = "Tên KH";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(30, 63);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(30, 13);
            this.shLabel3.TabIndex = 9;
            this.shLabel3.Text = "Mã KH";
            // 
            // txtMaThe
            // 
            this.txtMaThe.IsChangeText = false;
            this.txtMaThe.IsFocus = false;
            this.txtMaThe.Location = new System.Drawing.Point(212, 208);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Properties.ReadOnly = true;
            this.txtMaThe.Size = new System.Drawing.Size(51, 20);
            this.txtMaThe.TabIndex = 0;
            this.txtMaThe.Visible = false;
            // 
            // txtSDT
            // 
            this.txtSDT.IsChangeText = false;
            this.txtSDT.IsFocus = false;
            this.txtSDT.Location = new System.Drawing.Point(86, 111);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.MaxLength = 20;
            this.txtSDT.Size = new System.Drawing.Size(141, 20);
            this.txtSDT.TabIndex = 4;
            // 
            // txtTenKH
            // 
            this.txtTenKH.IsChangeText = false;
            this.txtTenKH.IsFocus = false;
            this.txtTenKH.Location = new System.Drawing.Point(86, 85);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Properties.MaxLength = 250;
            this.txtTenKH.Size = new System.Drawing.Size(141, 20);
            this.txtTenKH.TabIndex = 3;
            // 
            // shLabel5
            // 
            this.shLabel5.Location = new System.Drawing.Point(30, 36);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(47, 13);
            this.shLabel5.TabIndex = 10;
            this.shLabel5.Text = "Đến ngày";
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(30, 10);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(40, 13);
            this.shLabel4.TabIndex = 11;
            this.shLabel4.Text = "Từ ngày";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(156, 212);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(33, 13);
            this.shLabel1.TabIndex = 12;
            this.shLabel1.Text = "Mã thẻ";
            this.shLabel1.Visible = false;
            // 
            // txtMaKH
            // 
            this.txtMaKH.IsChangeText = false;
            this.txtMaKH.IsFocus = false;
            this.txtMaKH.Location = new System.Drawing.Point(86, 59);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Properties.MaxLength = 45;
            this.txtMaKH.Size = new System.Drawing.Size(141, 20);
            this.txtMaKH.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(37, 179);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu (F2)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(131, 179);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát (Esc)";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.IsChangeText = false;
            this.txtDiaChi.IsFocus = false;
            this.txtDiaChi.Location = new System.Drawing.Point(86, 137);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.MaxLength = 20;
            this.txtDiaChi.Size = new System.Drawing.Size(141, 20);
            this.txtDiaChi.TabIndex = 5;
            // 
            // shLabel7
            // 
            this.shLabel7.Location = new System.Drawing.Point(30, 140);
            this.shLabel7.Name = "shLabel7";
            this.shLabel7.Size = new System.Drawing.Size(32, 13);
            this.shLabel7.TabIndex = 7;
            this.shLabel7.Text = "Địa chỉ";
            // 
            // frmKhachDungThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 219);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.deDenNgay);
            this.Controls.Add(this.deTuNgay);
            this.Controls.Add(this.shLabel7);
            this.Controls.Add(this.shLabel6);
            this.Controls.Add(this.shLabel2);
            this.Controls.Add(this.shLabel3);
            this.Controls.Add(this.txtMaThe);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.shLabel5);
            this.Controls.Add(this.shLabel4);
            this.Controls.Add(this.shLabel1);
            this.Controls.Add(this.txtMaKH);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(269, 257);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(269, 257);
            this.Name = "frmKhachDungThe";
            this.Text = "Khách hàng dùng thẻ";
            this.Load += new System.EventHandler(this.frmKhachDungThe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaThe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Base.Inputs.InputDate deDenNgay;
        private Base.Inputs.InputDate deTuNgay;
        private Base.Controls.ShLabel shLabel6;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel3;
        private Base.Inputs.InputText txtMaThe;
        private Base.Inputs.InputText txtSDT;
        private Base.Inputs.InputText txtTenKH;
        private Base.Controls.ShLabel shLabel5;
        private Base.Controls.ShLabel shLabel4;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputText txtMaKH;
        private Base.Controls.ShButton btnLuu;
        private Base.Controls.ShButton btnThoat;
        private Base.Inputs.InputText txtDiaChi;
        private Base.Controls.ShLabel shLabel7;
    }
}