﻿namespace Taxi.Controls.BanCo
{
    partial class frmBanCo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSoXe = new System.Windows.Forms.TextBox();
            this.panel_BanCo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoXe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 28);
            this.panel1.TabIndex = 0;
            // 
            // txtSoXe
            // 
            this.txtSoXe.Location = new System.Drawing.Point(93, 4);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Size = new System.Drawing.Size(100, 20);
            this.txtSoXe.TabIndex = 0;
            this.txtSoXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoXe_KeyDown);
            // 
            // panel_BanCo
            // 
            this.panel_BanCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_BanCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_BanCo.Location = new System.Drawing.Point(0, 28);
            this.panel_BanCo.Name = "panel_BanCo";
            this.panel_BanCo.Size = new System.Drawing.Size(900, 367);
            this.panel_BanCo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm xe";
            // 
            // frmBanCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 395);
            this.Controls.Add(this.panel_BanCo);
            this.Controls.Add(this.panel1);
            this.Name = "frmBanCo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bàn cờ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBanCo_FormClosed);
            this.Load += new System.EventHandler(this.frmBanCo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_BanCo;
        private System.Windows.Forms.TextBox txtSoXe;
        private System.Windows.Forms.Label label1;
    }
}