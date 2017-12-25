namespace Taxi.GUI
{
    partial class frmTuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTuyen));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenTuyen = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.radNgoaiThanh = new System.Windows.Forms.RadioButton();
            this.radNgoaiTinh = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tuyến";
            // 
            // txtTenTuyen
            // 
            this.txtTenTuyen.Location = new System.Drawing.Point(80, 22);
            this.txtTenTuyen.Name = "txtTenTuyen";
            this.txtTenTuyen.Size = new System.Drawing.Size(290, 20);
            this.txtTenTuyen.TabIndex = 1;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(214, 72);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(295, 72);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 23);
            this.btnHuyBo.TabIndex = 3;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // radNgoaiThanh
            // 
            this.radNgoaiThanh.AutoSize = true;
            this.radNgoaiThanh.Location = new System.Drawing.Point(80, 48);
            this.radNgoaiThanh.Name = "radNgoaiThanh";
            this.radNgoaiThanh.Size = new System.Drawing.Size(83, 17);
            this.radNgoaiThanh.TabIndex = 4;
            this.radNgoaiThanh.Text = "Ngoại thành";
            this.radNgoaiThanh.UseVisualStyleBackColor = true;
            // 
            // radNgoaiTinh
            // 
            this.radNgoaiTinh.AutoSize = true;
            this.radNgoaiTinh.Checked = true;
            this.radNgoaiTinh.Location = new System.Drawing.Point(169, 48);
            this.radNgoaiTinh.Name = "radNgoaiTinh";
            this.radNgoaiTinh.Size = new System.Drawing.Size(73, 17);
            this.radNgoaiTinh.TabIndex = 5;
            this.radNgoaiTinh.TabStop = true;
            this.radNgoaiTinh.Text = "Ngoại tỉnh";
            this.radNgoaiTinh.UseVisualStyleBackColor = true;
            // 
            // frmTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 102);
            this.Controls.Add(this.radNgoaiTinh);
            this.Controls.Add(this.radNgoaiThanh);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTenTuyen);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tuyến đường";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenTuyen;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.RadioButton radNgoaiThanh;
        private System.Windows.Forms.RadioButton radNgoaiTinh;
    }
}