namespace Taxi.Controls.DanhSach.DMKhachAo
{
    partial class FrmUpdateKhachAo
    {
        public FrmUpdateKhachAo()
        {
            InitializeComponent();
        }
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
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtTen = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoDienThoai = new Taxi.Controls.Base.Inputs.InputText();
            this.txtDiaChi = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).BeginInit();
            this.panelInputView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDienThoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInputView
            // 
            this.panelInputView.Controls.Add(this.shLabel2);
            this.panelInputView.Controls.Add(this.shLabel4);
            this.panelInputView.Controls.Add(this.txtDiaChi);
            this.panelInputView.Controls.Add(this.txtTen);
            this.panelInputView.Controls.Add(this.shLabel1);
            this.panelInputView.Controls.Add(this.txtSoDienThoai);
            this.panelInputView.Size = new System.Drawing.Size(274, 103);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 103);
            this.panel1.Size = new System.Drawing.Size(274, 50);
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(67, 47);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(18, 13);
            this.shLabel4.TabIndex = 6;
            this.shLabel4.Text = "Tên";
            // 
            // txtTen
            // 
            this.txtTen.IsChangeText = false;
            this.txtTen.IsFocus = false;
            this.txtTen.Location = new System.Drawing.Point(93, 44);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.MaxLength = 50;
            this.txtTen.Size = new System.Drawing.Size(152, 20);
            this.txtTen.TabIndex = 2;
            this.txtTen.Tag = "Name";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(23, 21);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(62, 13);
            this.shLabel1.TabIndex = 7;
            this.shLabel1.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.IsChangeText = false;
            this.txtSoDienThoai.IsFocus = false;
            this.txtSoDienThoai.Location = new System.Drawing.Point(93, 18);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Properties.Mask.EditMask = "[0-9]+";
            this.txtSoDienThoai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSoDienThoai.Properties.MaxLength = 15;
            this.txtSoDienThoai.Size = new System.Drawing.Size(152, 20);
            this.txtSoDienThoai.TabIndex = 1;
            this.txtSoDienThoai.Tag = "PhoneNumber";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.IsChangeText = false;
            this.txtDiaChi.IsFocus = false;
            this.txtDiaChi.Location = new System.Drawing.Point(93, 70);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.MaxLength = 250;
            this.txtDiaChi.Size = new System.Drawing.Size(152, 20);
            this.txtDiaChi.TabIndex = 3;
            this.txtDiaChi.Tag = "Address";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(53, 73);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(32, 13);
            this.shLabel2.TabIndex = 6;
            this.shLabel2.Text = "Địa chỉ";
            // 
            // FrmUpdateKhachAo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 153);
            this.FieldEnable = new string[] {
        "PhoneNumber"};
            this.Name = "FrmUpdateKhachAo";
            this.Text = "Cập nhật khách ảo";
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).EndInit();
            this.panelInputView.ResumeLayout(false);
            this.panelInputView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDienThoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShLabel shLabel4;
        private Base.Inputs.InputText txtTen;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputText txtSoDienThoai;
        private Base.Controls.ShLabel shLabel2;
        private Base.Inputs.InputText txtDiaChi;
    }
}