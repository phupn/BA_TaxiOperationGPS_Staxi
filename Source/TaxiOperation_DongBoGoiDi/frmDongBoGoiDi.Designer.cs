namespace DongBoGoiDi
{
    partial class frmDongBoGoiDi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDongBoGoiDi));
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSystemTray = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLblKhoiDongLuc = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblSoCuocChoXuLy = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLanThucHienGanDay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.dateNgay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkKhoiDongCungWin = new System.Windows.Forms.CheckBox();
            this.lblRuntime = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(170, 274);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(111, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hệ thống đồng bộ cuộc gọi đi của chăm sóc khách hàng";
            // 
            // btnSystemTray
            // 
            this.btnSystemTray.Location = new System.Drawing.Point(251, 274);
            this.btnSystemTray.Name = "btnSystemTray";
            this.btnSystemTray.Size = new System.Drawing.Size(120, 23);
            this.btnSystemTray.TabIndex = 2;
            this.btnSystemTray.Text = "Thu nhỏ - Taskbar";
            this.btnSystemTray.UseVisualStyleBackColor = true;
            this.btnSystemTray.Click += new System.EventHandler(this.btnSystemTray_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CallCapture UDP";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLblKhoiDongLuc,
            this.statusLblSoCuocChoXuLy,
            this.statusLblServer,
            this.statusLblDatabase});
            this.statusStrip1.Location = new System.Drawing.Point(0, 310);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(545, 22);
            this.statusStrip1.TabIndex = 6;
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
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 32);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLine);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblLanThucHienGanDay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chạy lại liên tục";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(38, 83);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(0, 13);
            this.lblLine.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Line:";
            // 
            // lblLanThucHienGanDay
            // 
            this.lblLanThucHienGanDay.AutoSize = true;
            this.lblLanThucHienGanDay.Location = new System.Drawing.Point(129, 17);
            this.lblLanThucHienGanDay.Name = "lblLanThucHienGanDay";
            this.lblLanThucHienGanDay.Size = new System.Drawing.Size(13, 13);
            this.lblLanThucHienGanDay.TabIndex = 2;
            this.lblLanThucHienGanDay.Text = "[]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Lần thực hiện gần đây :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "3 giờ sáng chạy lại ngày trước.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThucHien);
            this.groupBox2.Controls.Add(this.dateNgay);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chạy lại ngày cũ";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(239, 17);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(75, 23);
            this.btnThucHien.TabIndex = 12;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // dateNgay
            // 
            this.dateNgay.Location = new System.Drawing.Point(118, 20);
            this.dateNgay.Name = "dateNgay";
            this.dateNgay.Size = new System.Drawing.Size(115, 20);
            this.dateNgay.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Chọn ngày chạy lại :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Congnt - 0905228313 ";
            // 
            // chkKhoiDongCungWin
            // 
            this.chkKhoiDongCungWin.AutoSize = true;
            this.chkKhoiDongCungWin.Location = new System.Drawing.Point(13, 277);
            this.chkKhoiDongCungWin.Name = "chkKhoiDongCungWin";
            this.chkKhoiDongCungWin.Size = new System.Drawing.Size(149, 17);
            this.chkKhoiDongCungWin.TabIndex = 11;
            this.chkKhoiDongCungWin.Text = "Khởi động cùng Windows";
            this.chkKhoiDongCungWin.UseVisualStyleBackColor = true;
            // 
            // lblRuntime
            // 
            this.lblRuntime.AutoSize = true;
            this.lblRuntime.Location = new System.Drawing.Point(420, 32);
            this.lblRuntime.Name = "lblRuntime";
            this.lblRuntime.Size = new System.Drawing.Size(13, 13);
            this.lblRuntime.TabIndex = 16;
            this.lblRuntime.Text = "[]";
            // 
            // frmDongBoGoiDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 332);
            this.Controls.Add(this.lblRuntime);
            this.Controls.Add(this.chkKhoiDongCungWin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSystemTray);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDongBoGoiDi";
            this.Text = "Dong bo cuoc khach CS";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSystemTray;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLblSoCuocChoXuLy;
        private System.Windows.Forms.ToolStripStatusLabel statusLblKhoiDongLuc;
        private System.Windows.Forms.ToolStripStatusLabel statusLblServer;
        private System.Windows.Forms.ToolStripStatusLabel statusLblDatabase;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLanThucHienGanDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkKhoiDongCungWin;
        private System.Windows.Forms.DateTimePicker dateNgay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRuntime;
    }
}

