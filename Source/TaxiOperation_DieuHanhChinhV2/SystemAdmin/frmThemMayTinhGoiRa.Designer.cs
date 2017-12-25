namespace Taxi.GUI
{
    partial class frmThemMayTinhGoiRa
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
            this.lblLine_Vung = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtLine_Vung = new System.Windows.Forms.TextBox();
            this.chkChoPhep = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPhanLoaiMay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP ";
            // 
            // lblLine_Vung
            // 
            this.lblLine_Vung.AutoSize = true;
            this.lblLine_Vung.Location = new System.Drawing.Point(30, 40);
            this.lblLine_Vung.Name = "lblLine_Vung";
            this.lblLine_Vung.Size = new System.Drawing.Size(40, 13);
            this.lblLine_Vung.TabIndex = 1;
            this.lblLine_Vung.Text = "Line (*)";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(68, 128);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(68, 64);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(161, 20);
            this.txtIP.TabIndex = 3;
            // 
            // txtLine_Vung
            // 
            this.txtLine_Vung.Location = new System.Drawing.Point(68, 37);
            this.txtLine_Vung.Name = "txtLine_Vung";
            this.txtLine_Vung.Size = new System.Drawing.Size(161, 20);
            this.txtLine_Vung.TabIndex = 4;
            // 
            // chkChoPhep
            // 
            this.chkChoPhep.AutoSize = true;
            this.chkChoPhep.Location = new System.Drawing.Point(68, 107);
            this.chkChoPhep.Name = "chkChoPhep";
            this.chkChoPhep.Size = new System.Drawing.Size(72, 17);
            this.chkChoPhep.TabIndex = 5;
            this.chkChoPhep.Text = "Cho phép";
            this.chkChoPhep.UseVisualStyleBackColor = true;
            this.chkChoPhep.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "(Mỗi line trên một dòng)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Phân loại (*)";
            // 
            // cboPhanLoaiMay
            // 
            this.cboPhanLoaiMay.DisplayMember = "Text";
            this.cboPhanLoaiMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhanLoaiMay.Location = new System.Drawing.Point(68, 10);
            this.cboPhanLoaiMay.Name = "cboPhanLoaiMay";
            this.cboPhanLoaiMay.Size = new System.Drawing.Size(161, 21);
            this.cboPhanLoaiMay.TabIndex = 8;
            this.cboPhanLoaiMay.ValueMember = "id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(153, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "(* bắt buộc nhập)";
            // 
            // frmThemMayTinhGoiRa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 168);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPhanLoaiMay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkChoPhep);
            this.Controls.Add(this.txtLine_Vung);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lblLine_Vung);
            this.Controls.Add(this.label1);
            this.Name = "frmThemMayTinhGoiRa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm máy tính";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLine_Vung;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtLine_Vung;
        private System.Windows.Forms.CheckBox chkChoPhep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPhanLoaiMay;
        private System.Windows.Forms.Label label4;
    }
}