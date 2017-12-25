namespace Taxi.Controls
{
    partial class ctrlTimFile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.lblThuMuc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTenThuMuc = new System.Windows.Forms.Label();
            this.lstFile = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên file";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(46, 13);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(293, 20);
            this.txtFilename.TabIndex = 1;
            this.txtFilename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilename_KeyDown);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(345, 10);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(56, 23);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // lblThuMuc
            // 
            this.lblThuMuc.AutoSize = true;
            this.lblThuMuc.Location = new System.Drawing.Point(3, 2);
            this.lblThuMuc.Name = "lblThuMuc";
            this.lblThuMuc.Size = new System.Drawing.Size(52, 13);
            this.lblThuMuc.TabIndex = 3;
            this.lblThuMuc.Text = "Thư mục:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(20, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "( dùng \'*\' đại diện tìm file, thêm ký tự A : gọi đến, B gọi đi: *A*0902909909*.wa" +
    "v)";
            // 
            // lblTenThuMuc
            // 
            this.lblTenThuMuc.AutoSize = true;
            this.lblTenThuMuc.Location = new System.Drawing.Point(52, 3);
            this.lblTenThuMuc.Name = "lblTenThuMuc";
            this.lblTenThuMuc.Size = new System.Drawing.Size(0, 13);
            this.lblTenThuMuc.TabIndex = 6;
            // 
            // lstFile
            // 
            this.lstFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFile.FormattingEnabled = true;
            this.lstFile.Location = new System.Drawing.Point(0, 0);
            this.lstFile.Name = "lstFile";
            this.lstFile.Size = new System.Drawing.Size(430, 237);
            this.lstFile.TabIndex = 7;
            this.lstFile.SelectedIndexChanged += new System.EventHandler(this.lstFile_SelectedIndexChanged);
            this.lstFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFile_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFilename);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 82);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblThuMuc);
            this.panel2.Controls.Add(this.lblTenThuMuc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 24);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstFile);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(430, 237);
            this.panel3.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "DoubleClick vào dòng chọn để chọn file.";
            // 
            // ctrlTimFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ctrlTimFile";
            this.Size = new System.Drawing.Size(430, 343);
            this.Load += new System.EventHandler(this.ctrlTimFile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label lblThuMuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenThuMuc;
        private System.Windows.Forms.ListBox lstFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
    }
}
