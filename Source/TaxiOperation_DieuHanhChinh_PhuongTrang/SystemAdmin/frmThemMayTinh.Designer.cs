﻿namespace Taxi.GUI
{
    partial class frmThemMayTinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemMayTinh));
            this.label1 = new System.Windows.Forms.Label();
            this.lblLine_Vung = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtLine_Vung = new System.Windows.Forms.TextBox();
            this.chkChoPhep = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLineGop = new System.Windows.Forms.TextBox();
            this.num_No = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_No)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP ";
            // 
            // lblLine_Vung
            // 
            this.lblLine_Vung.AutoSize = true;
            this.lblLine_Vung.Location = new System.Drawing.Point(21, 49);
            this.lblLine_Vung.Name = "lblLine_Vung";
            this.lblLine_Vung.Size = new System.Drawing.Size(27, 13);
            this.lblLine_Vung.TabIndex = 5;
            this.lblLine_Vung.Text = "Line";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(96, 136);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(69, 20);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(184, 20);
            this.txtIP.TabIndex = 0;
            // 
            // txtLine_Vung
            // 
            this.txtLine_Vung.Location = new System.Drawing.Point(69, 46);
            this.txtLine_Vung.Name = "txtLine_Vung";
            this.txtLine_Vung.Size = new System.Drawing.Size(86, 20);
            this.txtLine_Vung.TabIndex = 1;
            // 
            // chkChoPhep
            // 
            this.chkChoPhep.AutoSize = true;
            this.chkChoPhep.Location = new System.Drawing.Point(69, 114);
            this.chkChoPhep.Name = "chkChoPhep";
            this.chkChoPhep.Size = new System.Drawing.Size(72, 17);
            this.chkChoPhep.TabIndex = 9;
            this.chkChoPhep.Text = "Cho phép";
            this.chkChoPhep.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "(phân cách bằng dấu ;)";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(159, 49);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(24, 13);
            this.lblNo.TabIndex = 7;
            this.lblNo.Text = "No.";
            this.lblNo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Line gộp";
            // 
            // txtLineGop
            // 
            this.txtLineGop.Location = new System.Drawing.Point(69, 72);
            this.txtLineGop.Name = "txtLineGop";
            this.txtLineGop.Size = new System.Drawing.Size(86, 20);
            this.txtLineGop.TabIndex = 3;
            // 
            // num_No
            // 
            this.num_No.Location = new System.Drawing.Point(185, 46);
            this.num_No.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_No.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_No.Name = "num_No";
            this.num_No.Size = new System.Drawing.Size(68, 20);
            this.num_No.TabIndex = 2;
            this.num_No.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_No.Visible = false;
            // 
            // frmThemMayTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 167);
            this.Controls.Add(this.num_No);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkChoPhep);
            this.Controls.Add(this.txtLineGop);
            this.Controls.Add(this.txtLine_Vung);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lblLine_Vung);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThemMayTinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm máy tính";
            ((System.ComponentModel.ISupportInitialize)(this.num_No)).EndInit();
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
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLineGop;
        private System.Windows.Forms.NumericUpDown num_No;
    }
}