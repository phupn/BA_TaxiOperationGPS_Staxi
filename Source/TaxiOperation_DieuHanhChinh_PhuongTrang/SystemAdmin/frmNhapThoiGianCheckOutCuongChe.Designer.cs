namespace Taxi.GUI
{
    partial class frmNhapThoiGianCheckOutCuongChe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapThoiGianCheckOutCuongChe));
            this.label1 = new System.Windows.Forms.Label();
            this.lblThoiDiemDangNhap = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calThoiDiemDangXuat = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnChon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thời điểm đăng nhập  :";
            // 
            // lblThoiDiemDangNhap
            // 
            this.lblThoiDiemDangNhap.AutoSize = true;
            this.lblThoiDiemDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiDiemDangNhap.Location = new System.Drawing.Point(155, 9);
            this.lblThoiDiemDangNhap.Name = "lblThoiDiemDangNhap";
            this.lblThoiDiemDangNhap.Size = new System.Drawing.Size(126, 13);
            this.lblThoiDiemDangNhap.TabIndex = 1;
            this.lblThoiDiemDangNhap.Text = "Thoi diem dan gnhap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thời điểm đăng xuất  :";
            // 
            // calThoiDiemDangXuat
            // 
            this.calThoiDiemDangXuat.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calThoiDiemDangXuat.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calThoiDiemDangXuat.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calThoiDiemDangXuat.DropDownCalendar.Name = "";
            this.calThoiDiemDangXuat.Location = new System.Drawing.Point(158, 34);
            this.calThoiDiemDangXuat.Name = "calThoiDiemDangXuat";
            this.calThoiDiemDangXuat.Size = new System.Drawing.Size(141, 20);
            this.calThoiDiemDangXuat.TabIndex = 14;
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(92, 62);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(137, 28);
            this.btnChon.TabIndex = 15;
            this.btnChon.Text = "Chọn thời điểm đăng xuất";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // frmNhapThoiGianCheckOutCuongChe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 96);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.calThoiDiemDangXuat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblThoiDiemDangNhap);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhapThoiGianCheckOutCuongChe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblThoiDiemDangNhap;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo calThoiDiemDangXuat;
        private System.Windows.Forms.Button btnChon;
    }
}