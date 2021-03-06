namespace TaxiOperation_DieuHanhChinh.SystemAdmin
{
    partial class HeThong_PhanQuyenKhaiThacMoiGioi
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbCongTy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstNVKhaiThac = new System.Windows.Forms.ListBox();
            this.lstNVChuaDuocPhan = new System.Windows.Forms.ListBox();
            this.btnFoward = new System.Windows.Forms.Button();
            this.btnBackward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên công ty";
            // 
            // cbCongTy
            // 
            this.cbCongTy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCongTy.FormattingEnabled = true;
            this.cbCongTy.Location = new System.Drawing.Point(97, 25);
            this.cbCongTy.Name = "cbCongTy";
            this.cbCongTy.Size = new System.Drawing.Size(136, 21);
            this.cbCongTy.TabIndex = 1;
            this.cbCongTy.SelectedValueChanged += new System.EventHandler(this.cbCongTy_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Danh sách nhân viên được khai thác";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Danh sách nhân viên chưa được phân";
            // 
            // lstNVKhaiThac
            // 
            this.lstNVKhaiThac.FormattingEnabled = true;
            this.lstNVKhaiThac.Location = new System.Drawing.Point(12, 82);
            this.lstNVKhaiThac.Name = "lstNVKhaiThac";
            this.lstNVKhaiThac.Size = new System.Drawing.Size(199, 225);
            this.lstNVKhaiThac.TabIndex = 4;
            // 
            // lstNVChuaDuocPhan
            // 
            this.lstNVChuaDuocPhan.FormattingEnabled = true;
            this.lstNVChuaDuocPhan.Location = new System.Drawing.Point(291, 82);
            this.lstNVChuaDuocPhan.Name = "lstNVChuaDuocPhan";
            this.lstNVChuaDuocPhan.Size = new System.Drawing.Size(208, 225);
            this.lstNVChuaDuocPhan.TabIndex = 5;
            // 
            // btnFoward
            // 
            this.btnFoward.Location = new System.Drawing.Point(228, 130);
            this.btnFoward.Name = "btnFoward";
            this.btnFoward.Size = new System.Drawing.Size(44, 23);
            this.btnFoward.TabIndex = 6;
            this.btnFoward.Text = ">";
            this.btnFoward.UseVisualStyleBackColor = true;
            this.btnFoward.Click += new System.EventHandler(this.btnFoward_Click);
            // 
            // btnBackward
            // 
            this.btnBackward.Location = new System.Drawing.Point(228, 186);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(44, 23);
            this.btnBackward.TabIndex = 7;
            this.btnBackward.Text = "<";
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // HeThong_PhanQuyenKhaiThacMoiGioi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 318);
            this.Controls.Add(this.btnBackward);
            this.Controls.Add(this.btnFoward);
            this.Controls.Add(this.lstNVChuaDuocPhan);
            this.Controls.Add(this.lstNVKhaiThac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCongTy);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeThong_PhanQuyenKhaiThacMoiGioi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phân quyền khai thác môi giới";
            this.Load += new System.EventHandler(this.HeThong_PhanQuyenKhaiThacMoiGioi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCongTy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstNVKhaiThac;
        private System.Windows.Forms.ListBox lstNVChuaDuocPhan;
        private System.Windows.Forms.Button btnFoward;
        private System.Windows.Forms.Button btnBackward;
    }
}