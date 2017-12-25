namespace Taxi.GUI
{
    partial class frmCapNhatThongTinMoiGioi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatThongTinMoiGioi));
            this.listMoiGioi = new System.Windows.Forms.ListBox();
            this.listMoiGioiChon = new System.Windows.Forms.ListBox();
            this.btnTroLai1 = new System.Windows.Forms.Button();
            this.btnCapNhatThongtinMoiGioi = new System.Windows.Forms.Button();
            this.btnTroLaiHet = new System.Windows.Forms.Button();
            this.btnChon1 = new System.Windows.Forms.Button();
            this.btnnChonHet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date_FromDate = new System.Windows.Forms.DateTimePicker();
            this.date_ToDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // listMoiGioi
            // 
            this.listMoiGioi.FormattingEnabled = true;
            this.listMoiGioi.Location = new System.Drawing.Point(24, 90);
            this.listMoiGioi.Name = "listMoiGioi";
            this.listMoiGioi.ScrollAlwaysVisible = true;
            this.listMoiGioi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listMoiGioi.Size = new System.Drawing.Size(399, 446);
            this.listMoiGioi.TabIndex = 0;
            // 
            // listMoiGioiChon
            // 
            this.listMoiGioiChon.FormattingEnabled = true;
            this.listMoiGioiChon.Location = new System.Drawing.Point(482, 90);
            this.listMoiGioiChon.Name = "listMoiGioiChon";
            this.listMoiGioiChon.ScrollAlwaysVisible = true;
            this.listMoiGioiChon.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listMoiGioiChon.Size = new System.Drawing.Size(399, 446);
            this.listMoiGioiChon.TabIndex = 1;
            // 
            // btnTroLai1
            // 
            this.btnTroLai1.Location = new System.Drawing.Point(437, 319);
            this.btnTroLai1.Name = "btnTroLai1";
            this.btnTroLai1.Size = new System.Drawing.Size(31, 23);
            this.btnTroLai1.TabIndex = 2;
            this.btnTroLai1.Text = "<";
            this.btnTroLai1.UseVisualStyleBackColor = true;
            this.btnTroLai1.Click += new System.EventHandler(this.btnTroLai1_Click);
            // 
            // btnCapNhatThongtinMoiGioi
            // 
            this.btnCapNhatThongtinMoiGioi.Location = new System.Drawing.Point(753, 543);
            this.btnCapNhatThongtinMoiGioi.Name = "btnCapNhatThongtinMoiGioi";
            this.btnCapNhatThongtinMoiGioi.Size = new System.Drawing.Size(128, 23);
            this.btnCapNhatThongtinMoiGioi.TabIndex = 3;
            this.btnCapNhatThongtinMoiGioi.Text = "Cập nhật cuộc môi giới";
            this.btnCapNhatThongtinMoiGioi.UseVisualStyleBackColor = true;
            this.btnCapNhatThongtinMoiGioi.Click += new System.EventHandler(this.btnCapNhatThongtinMoiGioi_Click);
            // 
            // btnTroLaiHet
            // 
            this.btnTroLaiHet.Location = new System.Drawing.Point(437, 350);
            this.btnTroLaiHet.Name = "btnTroLaiHet";
            this.btnTroLaiHet.Size = new System.Drawing.Size(31, 23);
            this.btnTroLaiHet.TabIndex = 4;
            this.btnTroLaiHet.Text = "<<";
            this.btnTroLaiHet.UseVisualStyleBackColor = true;
            this.btnTroLaiHet.Click += new System.EventHandler(this.btnTroLaiHet_Click);
            // 
            // btnChon1
            // 
            this.btnChon1.Location = new System.Drawing.Point(437, 288);
            this.btnChon1.Name = "btnChon1";
            this.btnChon1.Size = new System.Drawing.Size(31, 23);
            this.btnChon1.TabIndex = 5;
            this.btnChon1.Text = ">";
            this.btnChon1.UseVisualStyleBackColor = true;
            this.btnChon1.Click += new System.EventHandler(this.btnChon1_Click);
            // 
            // btnnChonHet
            // 
            this.btnnChonHet.Location = new System.Drawing.Point(437, 257);
            this.btnnChonHet.Name = "btnnChonHet";
            this.btnnChonHet.Size = new System.Drawing.Size(31, 23);
            this.btnnChonHet.TabIndex = 6;
            this.btnnChonHet.Text = ">>";
            this.btnnChonHet.UseVisualStyleBackColor = true;
            this.btnnChonHet.Click += new System.EventHandler(this.btnnChonHet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Danh sách môi giới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Danh sách môi giới cập nhật lại thông tin cuộc gọi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Chọn khoảng thời gian cập nhật lại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Tomato;
            this.label4.Location = new System.Drawing.Point(205, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(525, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bạn chỉ nên chọn những môi giới mới nhập hoặc mới thay đổi số điện thoại để cập n" +
    "hật lại.";
            // 
            // date_FromDate
            // 
            this.date_FromDate.CustomFormat = "dd/MM/yyyy";
            this.date_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_FromDate.Location = new System.Drawing.Point(207, 10);
            this.date_FromDate.Name = "date_FromDate";
            this.date_FromDate.Size = new System.Drawing.Size(103, 20);
            this.date_FromDate.TabIndex = 12;
            // 
            // date_ToDate
            // 
            this.date_ToDate.CustomFormat = "dd/MM/yyyy";
            this.date_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_ToDate.Location = new System.Drawing.Point(316, 10);
            this.date_ToDate.Name = "date_ToDate";
            this.date_ToDate.Size = new System.Drawing.Size(103, 20);
            this.date_ToDate.TabIndex = 12;
            // 
            // frmCapNhatThongTinMoiGioi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 578);
            this.Controls.Add(this.date_ToDate);
            this.Controls.Add(this.date_FromDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnnChonHet);
            this.Controls.Add(this.btnChon1);
            this.Controls.Add(this.btnTroLaiHet);
            this.Controls.Add(this.btnCapNhatThongtinMoiGioi);
            this.Controls.Add(this.btnTroLai1);
            this.Controls.Add(this.listMoiGioiChon);
            this.Controls.Add(this.listMoiGioi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCapNhatThongTinMoiGioi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật lại cuộc gọi môi giới";
            this.Load += new System.EventHandler(this.frmCapNhatThongTinMoiGioi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listMoiGioi;
        private System.Windows.Forms.ListBox listMoiGioiChon;
        private System.Windows.Forms.Button btnTroLai1;
        private System.Windows.Forms.Button btnCapNhatThongtinMoiGioi;
        private System.Windows.Forms.Button btnTroLaiHet;
        private System.Windows.Forms.Button btnChon1;
        private System.Windows.Forms.Button btnnChonHet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date_FromDate;
        private System.Windows.Forms.DateTimePicker date_ToDate;
    }
}