namespace Taxi.GUI
{
    partial class frmCauHinhChuyenChamSoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauHinhChuyenChamSoc));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radTongDaiTuXuLy = new System.Windows.Forms.RadioButton();
            this.rad1CS = new System.Windows.Forms.RadioButton();
            this.rad2CS = new System.Windows.Forms.RadioButton();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();            
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radTongDaiTuXuLy);
            this.groupBox1.Controls.Add(this.rad1CS);
            this.groupBox1.Controls.Add(this.rad2CS);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnThemMoi);
            this.groupBox1.Location = new System.Drawing.Point(5, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình tổng đài chuyển chăm sóc";
            // 
            // radTongDaiTuXuLy
            // 
            this.radTongDaiTuXuLy.AutoSize = true;
            this.radTongDaiTuXuLy.Location = new System.Drawing.Point(70, 75);
            this.radTongDaiTuXuLy.Name = "radTongDaiTuXuLy";
            this.radTongDaiTuXuLy.Size = new System.Drawing.Size(104, 17);
            this.radTongDaiTuXuLy.TabIndex = 6;
            this.radTongDaiTuXuLy.Text = "Tổng đài tự xử lý";
            this.radTongDaiTuXuLy.UseVisualStyleBackColor = true;
            // 
            // rad1CS
            // 
            this.rad1CS.AutoSize = true;
            this.rad1CS.Location = new System.Drawing.Point(70, 52);
            this.rad1CS.Name = "rad1CS";
            this.rad1CS.Size = new System.Drawing.Size(231, 17);
            this.rad1CS.TabIndex = 5;
            this.rad1CS.Text = "Chuyển đều  1 CS (chỉ chuyển cho một CS)";
            this.rad1CS.UseVisualStyleBackColor = true;
            // 
            // rad2CS
            // 
            this.rad2CS.AutoSize = true;
            this.rad2CS.Checked = true;
            this.rad2CS.Location = new System.Drawing.Point(70, 29);
            this.rad2CS.Name = "rad2CS";
            this.rad2CS.Size = new System.Drawing.Size(300, 17);
            this.rad2CS.TabIndex = 4;
            this.rad2CS.TabStop = true;
            this.rad2CS.Text = "Chuyển đều  2 CS (tổng đài phân đều cuộc gọi cho 2 CS)";
            this.rad2CS.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(212, 126);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(61, 27);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.Location = new System.Drawing.Point(133, 126);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(73, 27);
            this.btnThemMoi.TabIndex = 2;
            this.btnThemMoi.Text = "Tra cứu";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // frmCauHinhChuyenChamSoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 178);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCauHinhChuyenChamSoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tong Dai chuyen Cham soc";
            this.Load += new System.EventHandler(this.frmTraCuu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnThoat;        
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton radTongDaiTuXuLy;
        private System.Windows.Forms.RadioButton rad1CS;
        private System.Windows.Forms.RadioButton rad2CS;

    }
}