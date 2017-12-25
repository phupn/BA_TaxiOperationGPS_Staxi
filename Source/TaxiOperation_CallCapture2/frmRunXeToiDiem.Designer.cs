namespace TaxiOperation_CallCapture2
{
    partial class frmRunXeToiDiem
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLblKhoiDongLuc = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblSoCuocChoXuLy = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLayXeToiDiem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.btnXeToiDiemDonKhach = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblThoiDiemQuet = new System.Windows.Forms.Label();
            this.lblThoiDiemXeToiDiem = new System.Windows.Forms.Label();
            this.lblThoiDiemXeDon = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLblKhoiDongLuc,
            this.statusLblSoCuocChoXuLy,
            this.statusLblServer,
            this.statusLblDatabase});
            this.statusStrip1.Location = new System.Drawing.Point(0, 235);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(557, 22);
            this.statusStrip1.TabIndex = 7;
            // 
            // statusLblKhoiDongLuc
            // 
            this.statusLblKhoiDongLuc.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.statusLblKhoiDongLuc.Name = "statusLblKhoiDongLuc";
            this.statusLblKhoiDongLuc.Size = new System.Drawing.Size(68, 17);
            this.statusLblKhoiDongLuc.Text = "Khởi động: ";
            // 
            // statusLblSoCuocChoXuLy
            // 
            this.statusLblSoCuocChoXuLy.Name = "statusLblSoCuocChoXuLy";
            this.statusLblSoCuocChoXuLy.Size = new System.Drawing.Size(91, 17);
            this.statusLblSoCuocChoXuLy.Text = "Cuộc chờ xử lý :";
            // 
            // statusLblServer
            // 
            this.statusLblServer.Name = "statusLblServer";
            this.statusLblServer.Size = new System.Drawing.Size(45, 17);
            this.statusLblServer.Text = "Server :";
            // 
            // statusLblDatabase
            // 
            this.statusLblDatabase.Name = "statusLblDatabase";
            this.statusLblDatabase.Size = new System.Drawing.Size(61, 17);
            this.statusLblDatabase.Text = "Database :";
            // 
            // btnLayXeToiDiem
            // 
            this.btnLayXeToiDiem.Location = new System.Drawing.Point(12, 12);
            this.btnLayXeToiDiem.Name = "btnLayXeToiDiem";
            this.btnLayXeToiDiem.Size = new System.Drawing.Size(156, 23);
            this.btnLayXeToiDiem.TabIndex = 0;
            this.btnLayXeToiDiem.Text = "Lấy xe tới điểm";
            this.btnLayXeToiDiem.UseVisualStyleBackColor = true;
            this.btnLayXeToiDiem.Click += new System.EventHandler(this.btnLayXeToiDiem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Gọi đến";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Số ĐT";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(55, 186);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(203, 29);
            this.txtSoDienThoai.TabIndex = 10;
            // 
            // btnXeToiDiemDonKhach
            // 
            this.btnXeToiDiemDonKhach.Location = new System.Drawing.Point(14, 41);
            this.btnXeToiDiemDonKhach.Name = "btnXeToiDiemDonKhach";
            this.btnXeToiDiemDonKhach.Size = new System.Drawing.Size(156, 23);
            this.btnXeToiDiemDonKhach.TabIndex = 11;
            this.btnXeToiDiemDonKhach.Text = "Lấy xe tới điểm đón khách";
            this.btnXeToiDiemDonKhach.UseVisualStyleBackColor = true;
            this.btnXeToiDiemDonKhach.Click += new System.EventHandler(this.btnXeToiDiemDonKhach_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Thời điểm quét :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Thời có xe tới điểm :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Thời điểm xe đón:";
            // 
            // lblThoiDiemQuet
            // 
            this.lblThoiDiemQuet.AutoSize = true;
            this.lblThoiDiemQuet.Location = new System.Drawing.Point(273, 17);
            this.lblThoiDiemQuet.Name = "lblThoiDiemQuet";
            this.lblThoiDiemQuet.Size = new System.Drawing.Size(0, 13);
            this.lblThoiDiemQuet.TabIndex = 15;
            // 
            // lblThoiDiemXeToiDiem
            // 
            this.lblThoiDiemXeToiDiem.AutoSize = true;
            this.lblThoiDiemXeToiDiem.Location = new System.Drawing.Point(288, 43);
            this.lblThoiDiemXeToiDiem.Name = "lblThoiDiemXeToiDiem";
            this.lblThoiDiemXeToiDiem.Size = new System.Drawing.Size(0, 13);
            this.lblThoiDiemXeToiDiem.TabIndex = 16;
            // 
            // lblThoiDiemXeDon
            // 
            this.lblThoiDiemXeDon.AutoSize = true;
            this.lblThoiDiemXeDon.Location = new System.Drawing.Point(278, 65);
            this.lblThoiDiemXeDon.Name = "lblThoiDiemXeDon";
            this.lblThoiDiemXeDon.Size = new System.Drawing.Size(0, 13);
            this.lblThoiDiemXeDon.TabIndex = 17;
            // 
            // frmRunXeToiDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 257);
            this.Controls.Add(this.lblThoiDiemXeDon);
            this.Controls.Add(this.lblThoiDiemXeToiDiem);
            this.Controls.Add(this.lblThoiDiemQuet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXeToiDiemDonKhach);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLayXeToiDiem);
            this.Name = "frmRunXeToiDiem";
            this.Text = "Xe toi diem";
            this.Load += new System.EventHandler(this.frmRunXeToiDiem_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLblKhoiDongLuc;
        private System.Windows.Forms.ToolStripStatusLabel statusLblSoCuocChoXuLy;
        private System.Windows.Forms.ToolStripStatusLabel statusLblServer;
        private System.Windows.Forms.ToolStripStatusLabel statusLblDatabase;
        private System.Windows.Forms.Button btnLayXeToiDiem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Button btnXeToiDiemDonKhach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThoiDiemQuet;
        private System.Windows.Forms.Label lblThoiDiemXeToiDiem;
        private System.Windows.Forms.Label lblThoiDiemXeDon;
    }
}