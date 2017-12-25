namespace Taxi.GUI
{
    partial class frmThemThoatCuoc999
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
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtVung = new System.Windows.Forms.TextBox();
            this.txtGioiHanSoCuocDuocBat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoPhutGioiHan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vùng (*)";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(180, 92);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(58, 23);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtVung
            // 
            this.txtVung.Location = new System.Drawing.Point(180, 3);
            this.txtVung.Name = "txtVung";
            this.txtVung.Size = new System.Drawing.Size(57, 20);
            this.txtVung.TabIndex = 3;
            // 
            // txtGioiHanSoCuocDuocBat
            // 
            this.txtGioiHanSoCuocDuocBat.Location = new System.Drawing.Point(180, 27);
            this.txtGioiHanSoCuocDuocBat.Name = "txtGioiHanSoCuocDuocBat";
            this.txtGioiHanSoCuocDuocBat.Size = new System.Drawing.Size(57, 20);
            this.txtGioiHanSoCuocDuocBat.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Giới hạn số cuốc được bất (*)";
            // 
            // txtSoPhutGioiHan
            // 
            this.txtSoPhutGioiHan.Location = new System.Drawing.Point(180, 53);
            this.txtSoPhutGioiHan.Name = "txtSoPhutGioiHan";
            this.txtSoPhutGioiHan.Size = new System.Drawing.Size(56, 20);
            this.txtSoPhutGioiHan.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Giới hạn số phút được sử dụng (*)";
            // 
            // frmThemThoatCuoc999
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 127);
            this.Controls.Add(this.txtSoPhutGioiHan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGioiHanSoCuocDuocBat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVung);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemThoatCuoc999";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm mới thoát cuốc 999 vùng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtVung;
        private System.Windows.Forms.TextBox txtGioiHanSoCuocDuocBat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoPhutGioiHan;
        private System.Windows.Forms.Label label3;
    }
}