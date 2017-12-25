namespace Taxi.GUI
{
    partial class frmBackUpDuLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackUpDuLieu));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDuongDanSaoLuu = new System.Windows.Forms.TextBox();
            this.btnBrowseSaoLuu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNgayGanDay1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaoLuu1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNgayGanDay2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaoLuu2 = new System.Windows.Forms.Button();
            this.txtBrowse2 = new System.Windows.Forms.TextBox();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn sao lưu";
            // 
            // txtDuongDanSaoLuu
            // 
            this.txtDuongDanSaoLuu.Location = new System.Drawing.Point(111, 31);
            this.txtDuongDanSaoLuu.Name = "txtDuongDanSaoLuu";
            this.txtDuongDanSaoLuu.Size = new System.Drawing.Size(472, 20);
            this.txtDuongDanSaoLuu.TabIndex = 1;
            this.txtDuongDanSaoLuu.Text = "C:\\Program Files\\Microsoft SQL Server\\MSSQL.1\\MSSQL\\Backup\\TaxiOperation20090731." +
                "bak";
            // 
            // btnBrowseSaoLuu
            // 
            this.btnBrowseSaoLuu.Location = new System.Drawing.Point(586, 28);
            this.btnBrowseSaoLuu.Name = "btnBrowseSaoLuu";
            this.btnBrowseSaoLuu.Size = new System.Drawing.Size(27, 23);
            this.btnBrowseSaoLuu.TabIndex = 2;
            this.btnBrowseSaoLuu.Text = "...";
            this.btnBrowseSaoLuu.UseVisualStyleBackColor = true;
            this.btnBrowseSaoLuu.Click += new System.EventHandler(this.btnBrowseSaoLuu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNgayGanDay1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSaoLuu1);
            this.groupBox1.Controls.Add(this.txtDuongDanSaoLuu);
            this.groupBox1.Controls.Add(this.btnBrowseSaoLuu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sao lưu toàn bộ";
            // 
            // lblNgayGanDay1
            // 
            this.lblNgayGanDay1.AutoSize = true;
            this.lblNgayGanDay1.Location = new System.Drawing.Point(260, 14);
            this.lblNgayGanDay1.Name = "lblNgayGanDay1";
            this.lblNgayGanDay1.Size = new System.Drawing.Size(0, 13);
            this.lblNgayGanDay1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày đã thực hiện gần đây:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Goldenrod;
            this.label3.Location = new System.Drawing.Point(111, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Công việc này nên thực hiện 1 tháng một lần.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(111, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sao lưu toàn bộ dữ liệu, bạn cần copy lại file này để dự phòng lỗi dữ liệu xảy ra" +
                ".";
            // 
            // btnSaoLuu1
            // 
            this.btnSaoLuu1.Location = new System.Drawing.Point(508, 57);
            this.btnSaoLuu1.Name = "btnSaoLuu1";
            this.btnSaoLuu1.Size = new System.Drawing.Size(75, 23);
            this.btnSaoLuu1.TabIndex = 3;
            this.btnSaoLuu1.Text = "Sao lưu";
            this.btnSaoLuu1.UseVisualStyleBackColor = true;
            this.btnSaoLuu1.Click += new System.EventHandler(this.btnSaoLuu1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNgayGanDay2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnSaoLuu2);
            this.groupBox2.Controls.Add(this.txtBrowse2);
            this.groupBox2.Controls.Add(this.btnBrowse2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(2, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 123);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sao lưu && xóa bỏ";
            // 
            // lblNgayGanDay2
            // 
            this.lblNgayGanDay2.AutoSize = true;
            this.lblNgayGanDay2.Location = new System.Drawing.Point(265, 15);
            this.lblNgayGanDay2.Name = "lblNgayGanDay2";
            this.lblNgayGanDay2.Size = new System.Drawing.Size(0, 13);
            this.lblNgayGanDay2.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Goldenrod;
            this.label9.Location = new System.Drawing.Point(111, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(305, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Những dữ liệu copy : cuộc đã giải quyết, thông tin kiểm soát xe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ngày đã thực hiện gần đây:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Goldenrod;
            this.label6.Location = new System.Drawing.Point(111, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(380, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Việc này bạn nên thực hiện 1 tháng một lần, nó làm tăng tốc độ xử lý hệ thống.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Goldenrod;
            this.label7.Location = new System.Drawing.Point(111, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(392, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Sao lưu một phần dữ liệu của hệ thống chỉ để lại trong hệ thống 3 tháng gần đây.";
            // 
            // btnSaoLuu2
            // 
            this.btnSaoLuu2.Location = new System.Drawing.Point(508, 57);
            this.btnSaoLuu2.Name = "btnSaoLuu2";
            this.btnSaoLuu2.Size = new System.Drawing.Size(75, 23);
            this.btnSaoLuu2.TabIndex = 3;
            this.btnSaoLuu2.Text = "Sao lưu";
            this.btnSaoLuu2.UseVisualStyleBackColor = true;
            this.btnSaoLuu2.Click += new System.EventHandler(this.btnSaoLuu2_Click);
            // 
            // txtBrowse2
            // 
            this.txtBrowse2.Location = new System.Drawing.Point(111, 31);
            this.txtBrowse2.Name = "txtBrowse2";
            this.txtBrowse2.Size = new System.Drawing.Size(472, 20);
            this.txtBrowse2.TabIndex = 1;
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(586, 28);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(27, 23);
            this.btnBrowse2.TabIndex = 2;
            this.btnBrowse2.Text = "...";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Đường dẫn sao lưu";
            // 
            // frmBackUpDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 267);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBackUpDuLieu";
            this.Text = "Sao lưu dữ liệu";
            this.Load += new System.EventHandler(this.frmBackUpDuLieu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDuongDanSaoLuu;
        private System.Windows.Forms.Button btnBrowseSaoLuu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaoLuu1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaoLuu2;
        private System.Windows.Forms.TextBox txtBrowse2;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNgayGanDay1;
        private System.Windows.Forms.Label lblNgayGanDay2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}