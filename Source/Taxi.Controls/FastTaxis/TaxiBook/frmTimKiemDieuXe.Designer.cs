namespace Taxi.Controls.FastTaxis.TaxiDieuXe
{
    partial class frmTimKiemDieuXe
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new Taxi.Controls.Base.Controls.ShButton();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoXe = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoDT = new Taxi.Controls.Base.Inputs.InputText();
            this.txtTenKH = new Taxi.Controls.Base.Inputs.InputText();
            this.txtTinhDon = new Taxi.Controls.Base.Common.InputLookUp_Province();
            this.txtNgayDon = new Taxi.Controls.Base.Inputs.InputDate();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTinhDon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayDon.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayDon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNgayDon);
            this.groupBox1.Controls.Add(this.txtTinhDon);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Controls.Add(this.txtSoDT);
            this.groupBox1.Controls.Add(this.txtSoXe);
            this.groupBox1.Controls.Add(this.shLabel5);
            this.groupBox1.Controls.Add(this.shLabel4);
            this.groupBox1.Controls.Add(this.shLabel3);
            this.groupBox1.Controls.Add(this.shLabel2);
            this.groupBox1.Controls.Add(this.shLabel1);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 189);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(48, 160);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm (F4)";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(138, 160);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(19, 26);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(27, 13);
            this.shLabel1.TabIndex = 1;
            this.shLabel1.Text = "Số &xe";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(19, 52);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(29, 13);
            this.shLabel2.TabIndex = 2;
            this.shLabel2.Text = "Số &ĐT";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(19, 76);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(34, 13);
            this.shLabel3.TabIndex = 2;
            this.shLabel3.Text = "Tên &KH";
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(19, 103);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(41, 13);
            this.shLabel4.TabIndex = 2;
            this.shLabel4.Text = "Tỉnh đ&ón";
            // 
            // txtSoXe
            // 
            this.txtSoXe.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.txtSoXe.Location = new System.Drawing.Point(70, 23);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Size = new System.Drawing.Size(171, 20);
            this.txtSoXe.TabIndex = 3;
            // 
            // shLabel5
            // 
            this.shLabel5.Location = new System.Drawing.Point(19, 130);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(46, 13);
            this.shLabel5.TabIndex = 2;
            this.shLabel5.Text = "&Ngày đón";
            // 
            // txtSoDT
            // 
            this.txtSoDT.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.txtSoDT.Location = new System.Drawing.Point(70, 49);
            this.txtSoDT.Name = "txtSoDT";
            this.txtSoDT.Size = new System.Drawing.Size(171, 20);
            this.txtSoDT.TabIndex = 3;
            // 
            // txtTenKH
            // 
            this.txtTenKH.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Oemtilde)));
            this.txtTenKH.Location = new System.Drawing.Point(70, 73);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(171, 20);
            this.txtTenKH.TabIndex = 3;
            // 
            // txtTinhDon
            // 
            this.txtTinhDon.DefaultSelectFirstRow = false;
            this.txtTinhDon.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.txtTinhDon.Location = new System.Drawing.Point(70, 100);
            this.txtTinhDon.Name = "txtTinhDon";
            this.txtTinhDon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTinhDon.Properties.NullText = "Tất cả";
            this.txtTinhDon.Size = new System.Drawing.Size(171, 20);
            this.txtTinhDon.TabIndex = 4;
            // 
            // txtNgayDon
            // 
            this.txtNgayDon.DateNowWhenLoad = true;
            this.txtNgayDon.EditValue = null;
            this.txtNgayDon.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.txtNgayDon.Location = new System.Drawing.Point(70, 127);
            this.txtNgayDon.Name = "txtNgayDon";
            this.txtNgayDon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtNgayDon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgayDon.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtNgayDon.Size = new System.Drawing.Size(171, 20);
            this.txtNgayDon.TabIndex = 5;
            // 
            // frmTimKiemDieuXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 189);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimKiemDieuXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTinhDon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayDon.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayDon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Base.Inputs.InputText txtSoXe;
        private Base.Controls.ShLabel shLabel4;
        private Base.Controls.ShLabel shLabel3;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel1;
        private Base.Controls.ShButton btnThoat;
        private Base.Controls.ShButton btnTimKiem;
        private Base.Inputs.InputDate txtNgayDon;
        private Base.Common.InputLookUp_Province txtTinhDon;
        private Base.Inputs.InputText txtTenKH;
        private Base.Inputs.InputText txtSoDT;
        private Base.Controls.ShLabel shLabel5;

    }
}