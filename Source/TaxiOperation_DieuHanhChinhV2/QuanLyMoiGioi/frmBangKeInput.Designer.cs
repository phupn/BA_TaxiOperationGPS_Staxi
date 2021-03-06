namespace Taxi.GUI
{
    partial class frmBangKeInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangKeInput));
            this.calNgayDon = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cbMoiGioi = new Janus.Windows.EditControls.UIComboBox();
            this.cbCongTy = new Janus.Windows.EditControls.UIComboBox();
            this.txtDSXeDon = new Janus.Windows.GridEX.EditControls.EditBox();
            this.btnCapNhat = new Janus.Windows.EditControls.UIButton();
            this.btnHuyBo = new Janus.Windows.EditControls.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMoiGioi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calNgayDon
            // 
            // 
            // 
            // 
            this.calNgayDon.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calNgayDon.DropDownCalendar.Name = "";
            this.calNgayDon.Location = new System.Drawing.Point(82, 12);
            this.calNgayDon.Name = "calNgayDon";
            this.calNgayDon.Size = new System.Drawing.Size(200, 20);
            this.calNgayDon.TabIndex = 1;
            // 
            // cbMoiGioi
            // 
            this.cbMoiGioi.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbMoiGioi.Location = new System.Drawing.Point(82, 38);
            this.cbMoiGioi.Name = "cbMoiGioi";
            this.cbMoiGioi.Size = new System.Drawing.Size(200, 20);
            this.cbMoiGioi.TabIndex = 2;
            // 
            // cbCongTy
            // 
            this.cbCongTy.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbCongTy.Location = new System.Drawing.Point(82, 64);
            this.cbCongTy.Name = "cbCongTy";
            this.cbCongTy.Size = new System.Drawing.Size(200, 20);
            this.cbCongTy.TabIndex = 3;
            // 
            // txtDSXeDon
            // 
            this.txtDSXeDon.Location = new System.Drawing.Point(82, 91);
            this.txtDSXeDon.Multiline = true;
            this.txtDSXeDon.Name = "txtDSXeDon";
            this.txtDSXeDon.Size = new System.Drawing.Size(300, 54);
            this.txtDSXeDon.TabIndex = 4;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(82, 167);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 5;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(163, 167);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 23);
            this.btnHuyBo.TabIndex = 6;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ngày đón";
            // 
            // lblMoiGioi
            // 
            this.lblMoiGioi.AutoSize = true;
            this.lblMoiGioi.Location = new System.Drawing.Point(27, 38);
            this.lblMoiGioi.Name = "lblMoiGioi";
            this.lblMoiGioi.Size = new System.Drawing.Size(43, 13);
            this.lblMoiGioi.TabIndex = 8;
            this.lblMoiGioi.Text = "Môi giới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Công ty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "DS xe đón";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "(dấu phẩy \',\' phân cách các xe)";
            // 
            // frmBangKeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 201);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMoiGioi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.txtDSXeDon);
            this.Controls.Add(this.cbCongTy);
            this.Controls.Add(this.cbMoiGioi);
            this.Controls.Add(this.calNgayDon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBangKeInput";
            this.Text = "Thêm/Sửa bảng kê";
            this.Load += new System.EventHandler(this.frmBangKeInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.CalendarCombo.CalendarCombo calNgayDon;
        private Janus.Windows.EditControls.UIComboBox cbMoiGioi;
        private Janus.Windows.EditControls.UIComboBox cbCongTy;
        private Janus.Windows.GridEX.EditControls.EditBox txtDSXeDon;
        private Janus.Windows.EditControls.UIButton btnCapNhat;
        private Janus.Windows.EditControls.UIButton btnHuyBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMoiGioi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;

    }
}