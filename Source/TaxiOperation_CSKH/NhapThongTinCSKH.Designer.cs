namespace Taxi.GUI
{
    partial class NhapThongTinCSKH
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapThongTinCSKH));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblThoiDiemKhachDi = new System.Windows.Forms.Label();
            this.lblTuyenDuong = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số điện thoại :";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TaxiOperation_CSKH.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(154, 401);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 26);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = " &Cập nhật";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiOperation_CSKH.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(253, 401);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Hủy bỏ";
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDienThoai.Location = new System.Drawing.Point(96, 9);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(0, 17);
            this.lblSoDienThoai.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Thời điểm khách đi:";
            // 
            // lblThoiDiemKhachDi
            // 
            this.lblThoiDiemKhachDi.AutoSize = true;
            this.lblThoiDiemKhachDi.Location = new System.Drawing.Point(376, 13);
            this.lblThoiDiemKhachDi.Name = "lblThoiDiemKhachDi";
            this.lblThoiDiemKhachDi.Size = new System.Drawing.Size(0, 13);
            this.lblThoiDiemKhachDi.TabIndex = 13;
            // 
            // lblTuyenDuong
            // 
            this.lblTuyenDuong.AutoSize = true;
            this.lblTuyenDuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyenDuong.Location = new System.Drawing.Point(95, 34);
            this.lblTuyenDuong.Name = "lblTuyenDuong";
            this.lblTuyenDuong.Size = new System.Drawing.Size(0, 17);
            this.lblTuyenDuong.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tuyến đường:";
            // 
            // NhapThongTinCSKH
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(510, 433);
            this.Controls.Add(this.lblTuyenDuong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblThoiDiemKhachDi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NhapThongTinCSKH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gọi CSKH";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnSave;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.Label lblThoiDiemKhachDi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblTuyenDuong;
        private System.Windows.Forms.Label label4;
    }
}