namespace Taxi.GUI
{
    partial class frmNhanVienTimKiem
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
            this.radSoDienThoai = new System.Windows.Forms.RadioButton();
            this.radTheLaiXe = new System.Windows.Forms.RadioButton();
            this.radSoHieuXe = new System.Windows.Forms.RadioButton();
            this.radTenDoiTac = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtThongTinTimKiem = new Taxi.Controls.Base.Inputs.InputText();
            this.btnTimKiem = new Taxi.Controls.Base.Controls.ShButton();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThongTinTimKiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radSoDienThoai
            // 
            this.radSoDienThoai.AutoSize = true;
            this.radSoDienThoai.Location = new System.Drawing.Point(279, 19);
            this.radSoDienThoai.Name = "radSoDienThoai";
            this.radSoDienThoai.Size = new System.Drawing.Size(88, 17);
            this.radSoDienThoai.TabIndex = 3;
            this.radSoDienThoai.Text = "Số điện thoại";
            this.radSoDienThoai.UseVisualStyleBackColor = true;
            // 
            // radTheLaiXe
            // 
            this.radTheLaiXe.AutoSize = true;
            this.radTheLaiXe.Location = new System.Drawing.Point(202, 19);
            this.radTheLaiXe.Name = "radTheLaiXe";
            this.radTheLaiXe.Size = new System.Drawing.Size(71, 17);
            this.radTheLaiXe.TabIndex = 2;
            this.radTheLaiXe.Text = "Thẻ lái xe";
            this.radTheLaiXe.UseVisualStyleBackColor = true;
            // 
            // radSoHieuXe
            // 
            this.radSoHieuXe.AutoSize = true;
            this.radSoHieuXe.Location = new System.Drawing.Point(121, 19);
            this.radSoHieuXe.Name = "radSoHieuXe";
            this.radSoHieuXe.Size = new System.Drawing.Size(75, 17);
            this.radSoHieuXe.TabIndex = 1;
            this.radSoHieuXe.Text = "Số hiệu xe";
            this.radSoHieuXe.UseVisualStyleBackColor = true;
            // 
            // radTenDoiTac
            // 
            this.radTenDoiTac.AutoSize = true;
            this.radTenDoiTac.Checked = true;
            this.radTenDoiTac.Location = new System.Drawing.Point(18, 19);
            this.radTenDoiTac.Name = "radTenDoiTac";
            this.radTenDoiTac.Size = new System.Drawing.Size(97, 17);
            this.radTenDoiTac.TabIndex = 0;
            this.radTenDoiTac.TabStop = true;
            this.radTenDoiTac.Text = "Tên nhân viên ";
            this.radTenDoiTac.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thông tin tìm";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.txtThongTinTimKiem);
            this.groupBox1.Controls.Add(this.radSoDienThoai);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.radTheLaiXe);
            this.groupBox1.Controls.Add(this.radTenDoiTac);
            this.groupBox1.Controls.Add(this.radSoHieuXe);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin lái xe";
            // 
            // txtThongTinTimKiem
            // 
            this.txtThongTinTimKiem.IsChangeText = false;
            this.txtThongTinTimKiem.IsFocus = false;
            this.txtThongTinTimKiem.Location = new System.Drawing.Point(121, 54);
            this.txtThongTinTimKiem.Name = "txtThongTinTimKiem";
            this.txtThongTinTimKiem.Size = new System.Drawing.Size(246, 20);
            this.txtThongTinTimKiem.TabIndex = 7;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Image = global::TaxiApplication.Properties.Resources.Search;
            this.btnTimKiem.Location = new System.Drawing.Point(211, 80);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::TaxiApplication.Properties.Resources.Delete;
            this.btnThoat.Location = new System.Drawing.Point(292, 80);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmNhanVienTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 123);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::TaxiApplication.Properties.Resources.Telephone_01;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmNhanVienTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm lái xe";
            this.Load += new System.EventHandler(this.frmNhanVienTimKiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThongTinTimKiem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton radTenDoiTac;
        private System.Windows.Forms.RadioButton radSoHieuXe;
        private System.Windows.Forms.RadioButton radTheLaiXe;
        private System.Windows.Forms.RadioButton radSoDienThoai;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.Base.Controls.ShButton btnThoat;
        private Controls.Base.Controls.ShButton btnTimKiem;
        private Controls.Base.Inputs.InputText txtThongTinTimKiem;
    }
}