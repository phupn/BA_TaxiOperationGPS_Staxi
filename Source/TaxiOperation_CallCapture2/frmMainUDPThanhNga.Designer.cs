using AxtxUDPOCX;
using Taxi.Business;
namespace TaxiCapture
{
    partial class frmMainUDPThanhNga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainUDPThanhNga));
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSystemTray = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLblKhoiDongLuc = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblSoCuocChoXuLy = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblGoiDen = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkGhiLogForDebug = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(162, 46);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(68, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hệ thống bắt số điện thoại. Nếu bạn tắt chương trình thì không hiện số điện thoại" +
    ".";
            // 
            // btnSystemTray
            // 
            this.btnSystemTray.Location = new System.Drawing.Point(253, 46);
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
            this.statusLblDatabase,
            this.lblError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 124);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(555, 22);
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
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            // 
            // lblGoiDen
            // 
            this.lblGoiDen.AutoSize = true;
            this.lblGoiDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoiDen.Location = new System.Drawing.Point(28, 96);
            this.lblGoiDen.Name = "lblGoiDen";
            this.lblGoiDen.Size = new System.Drawing.Size(0, 13);
            this.lblGoiDen.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 32);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Call";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(295, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "So Dien Thoai";
            this.textBox1.Visible = false;
            // 
            // chkGhiLogForDebug
            // 
            this.chkGhiLogForDebug.AutoSize = true;
            this.chkGhiLogForDebug.Location = new System.Drawing.Point(401, 46);
            this.chkGhiLogForDebug.Name = "chkGhiLogForDebug";
            this.chkGhiLogForDebug.Size = new System.Drawing.Size(94, 17);
            this.chkGhiLogForDebug.TabIndex = 12;
            this.chkGhiLogForDebug.Text = "Log for Debug";
            this.chkGhiLogForDebug.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(80, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 30);
            this.label2.TabIndex = 14;
            this.label2.Text = "MEM";
            // 
            // frmMainUDPThanhNga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 146);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkGhiLogForDebug);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblGoiDen);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSystemTray);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMainUDPThanhNga";
            this.Text = "Call Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label lblGoiDen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;  
        private System.Windows.Forms.CheckBox chkGhiLogForDebug;
        		    
        private AxtxUDP axtxUDP1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel lblError;
        
    }
}

