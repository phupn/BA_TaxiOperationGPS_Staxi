namespace Taxi.Controls.DanhSach.DMLoaiXe
{
    partial class FrmUpdateLoaiXe
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
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoCho = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtTenLoaiXe = new Taxi.Controls.Base.Inputs.InputText();
            this.txtTenHienThi = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).BeginInit();
            this.panelInputView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenHienThi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInputView
            // 
            this.panelInputView.Controls.Add(this.shLabel2);
            this.panelInputView.Controls.Add(this.shLabel4);
            this.panelInputView.Controls.Add(this.txtTenHienThi);
            this.panelInputView.Controls.Add(this.txtSoCho);
            this.panelInputView.Controls.Add(this.shLabel1);
            this.panelInputView.Controls.Add(this.txtTenLoaiXe);
            this.panelInputView.Size = new System.Drawing.Size(245, 94);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 94);
            this.panel1.Size = new System.Drawing.Size(245, 50);
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(37, 42);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(32, 13);
            this.shLabel4.TabIndex = 22;
            this.shLabel4.Text = "Số chỗ";
            // 
            // txtSoCho
            // 
            this.txtSoCho.IsChangeText = false;
            this.txtSoCho.IsFocus = false;
            this.txtSoCho.Location = new System.Drawing.Point(87, 39);
            this.txtSoCho.Name = "txtSoCho";
            this.txtSoCho.Properties.Mask.EditMask = "[0-9]+";
            this.txtSoCho.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSoCho.Properties.MaxLength = 2;
            this.txtSoCho.Size = new System.Drawing.Size(150, 20);
            this.txtSoCho.TabIndex = 2;
            this.txtSoCho.Tag = "SoCho";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(17, 16);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(52, 13);
            this.shLabel1.TabIndex = 23;
            this.shLabel1.Text = "Tên loại xe";
            // 
            // txtTenLoaiXe
            // 
            this.txtTenLoaiXe.IsChangeText = false;
            this.txtTenLoaiXe.IsFocus = false;
            this.txtTenLoaiXe.Location = new System.Drawing.Point(87, 13);
            this.txtTenLoaiXe.Name = "txtTenLoaiXe";
            this.txtTenLoaiXe.Properties.MaxLength = 100;
            this.txtTenLoaiXe.Size = new System.Drawing.Size(150, 20);
            this.txtTenLoaiXe.TabIndex = 1;
            this.txtTenLoaiXe.Tag = "TenLoaiXe";
            // 
            // txtTenHienThi
            // 
            this.txtTenHienThi.IsChangeText = false;
            this.txtTenHienThi.IsFocus = false;
            this.txtTenHienThi.Location = new System.Drawing.Point(87, 65);
            this.txtTenHienThi.Name = "txtTenHienThi";
            this.txtTenHienThi.Properties.Mask.ShowPlaceHolders = false;
            this.txtTenHienThi.Properties.MaxLength = 20;
            this.txtTenHienThi.Size = new System.Drawing.Size(150, 20);
            this.txtTenHienThi.TabIndex = 3;
            this.txtTenHienThi.Tag = "TenHienThi";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(13, 68);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(56, 13);
            this.shLabel2.TabIndex = 22;
            this.shLabel2.Text = "Tên hiển thị";
            // 
            // FrmUpdateLoaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 144);
            this.MaximizeBox = false;
            this.Name = "FrmUpdateLoaiXe";
            this.Text = "Cập nhật loại xe";
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).EndInit();
            this.panelInputView.ResumeLayout(false);
            this.panelInputView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenHienThi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShLabel shLabel4;
        private Base.Inputs.InputText txtSoCho;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputText txtTenLoaiXe;
        private Base.Controls.ShLabel shLabel2;
        private Base.Inputs.InputText txtTenHienThi;
    }
}