﻿using Taxi.Controls;

namespace Taxi.GUI
{
    partial class frmInfo
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.pnlVungDH = new System.Windows.Forms.Panel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.iluVungDH = new Taxi.Controls.Base.Common.InputLookUp_VungDieuHanh();
            this.lblPrivateCode = new System.Windows.Forms.Label();
            this.btnNo = new Taxi.Controls.Base.Controls.ShButton();
            this.btnYes = new Taxi.Controls.Base.Controls.ShButton();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.pnlDiaChi = new System.Windows.Forms.Panel();
            this.txtDiaChiDon = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.grbForm.SuspendLayout();
            this.pnlVungDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iluVungDH.Properties)).BeginInit();
            this.pnlDiaChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiDon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grbForm
            // 
            this.grbForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grbForm.Controls.Add(this.pnlVungDH);
            this.grbForm.Controls.Add(this.lblPrivateCode);
            this.grbForm.Controls.Add(this.btnNo);
            this.grbForm.Controls.Add(this.btnYes);
            this.grbForm.Controls.Add(this.shLabel5);
            this.grbForm.Controls.Add(this.pnlDiaChi);
            this.grbForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbForm.Location = new System.Drawing.Point(0, 0);
            this.grbForm.Name = "grbForm";
            this.grbForm.Size = new System.Drawing.Size(328, 122);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            this.grbForm.Text = "Tiêu đề";
            // 
            // pnlVungDH
            // 
            this.pnlVungDH.Controls.Add(this.shLabel2);
            this.pnlVungDH.Controls.Add(this.shLabel1);
            this.pnlVungDH.Controls.Add(this.iluVungDH);
            this.pnlVungDH.Location = new System.Drawing.Point(11, 35);
            this.pnlVungDH.Name = "pnlVungDH";
            this.pnlVungDH.Size = new System.Drawing.Size(302, 49);
            this.pnlVungDH.TabIndex = 7;
            this.pnlVungDH.Visible = false;
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(10, 30);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(164, 13);
            this.shLabel2.TabIndex = 8;
            this.shLabel2.Text = "Bạn sẽ cử lái xe đến điểm đỗ trên?";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(10, 6);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(42, 13);
            this.shLabel1.TabIndex = 7;
            this.shLabel1.Text = "Vùng ĐH";
            // 
            // iluVungDH
            // 
            this.iluVungDH.DefaultSelectFirstRow = false;
            this.iluVungDH.IsChangeText = false;
            this.iluVungDH.IsFocus = false;
            this.iluVungDH.Location = new System.Drawing.Point(66, 3);
            this.iluVungDH.Name = "iluVungDH";
            this.iluVungDH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iluVungDH.Properties.NullText = "";
            this.iluVungDH.Size = new System.Drawing.Size(233, 20);
            this.iluVungDH.TabIndex = 6;
            // 
            // lblPrivateCode
            // 
            this.lblPrivateCode.AutoSize = true;
            this.lblPrivateCode.Location = new System.Drawing.Point(63, 17);
            this.lblPrivateCode.Name = "lblPrivateCode";
            this.lblPrivateCode.Size = new System.Drawing.Size(75, 15);
            this.lblPrivateCode.TabIndex = 5;
            this.lblPrivateCode.Text = "Số hiệu xe";
            // 
            // btnNo
            // 
            this.btnNo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNo.Appearance.Font = new System.Drawing.Font("Arial", 9.25F);
            this.btnNo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnNo.Appearance.Options.UseBackColor = true;
            this.btnNo.Appearance.Options.UseFont = true;
            this.btnNo.Appearance.Options.UseForeColor = true;
            this.btnNo.Appearance.Options.UseTextOptions = true;
            this.btnNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnNo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnNo.Location = new System.Drawing.Point(202, 90);
            this.btnNo.LookAndFeel.SkinName = "Caramel";
            this.btnNo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(111, 26);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "Không";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.Appearance.Font = new System.Drawing.Font("Arial", 9.25F);
            this.btnYes.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnYes.Appearance.Options.UseBackColor = true;
            this.btnYes.Appearance.Options.UseFont = true;
            this.btnYes.Appearance.Options.UseForeColor = true;
            this.btnYes.Appearance.Options.UseTextOptions = true;
            this.btnYes.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnYes.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnYes.Location = new System.Drawing.Point(11, 90);
            this.btnYes.LookAndFeel.SkinName = "Caramel";
            this.btnYes.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(111, 26);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "Có";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // shLabel5
            // 
            this.shLabel5.Location = new System.Drawing.Point(11, 19);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(33, 13);
            this.shLabel5.TabIndex = 0;
            this.shLabel5.Text = "Xe đón";
            // 
            // pnlDiaChi
            // 
            this.pnlDiaChi.Controls.Add(this.txtDiaChiDon);
            this.pnlDiaChi.Controls.Add(this.shLabel3);
            this.pnlDiaChi.Location = new System.Drawing.Point(11, 35);
            this.pnlDiaChi.Name = "pnlDiaChi";
            this.pnlDiaChi.Size = new System.Drawing.Size(302, 40);
            this.pnlDiaChi.TabIndex = 8;
            // 
            // txtDiaChiDon
            // 
            this.txtDiaChiDon.IsChangeText = false;
            this.txtDiaChiDon.IsFocus = false;
            this.txtDiaChiDon.Location = new System.Drawing.Point(66, 3);
            this.txtDiaChiDon.Name = "txtDiaChiDon";
            this.txtDiaChiDon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDiaChiDon.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.txtDiaChiDon.Properties.Appearance.Options.UseBackColor = true;
            this.txtDiaChiDon.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChiDon.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDiaChiDon.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDiaChiDon.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtDiaChiDon.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtDiaChiDon.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtDiaChiDon.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtDiaChiDon.Properties.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.txtDiaChiDon.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtDiaChiDon.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtDiaChiDon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtDiaChiDon.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.txtDiaChiDon.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDiaChiDon.Properties.ReadOnly = true;
            this.txtDiaChiDon.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDiaChiDon.Size = new System.Drawing.Size(233, 29);
            this.txtDiaChiDon.TabIndex = 3;
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(10, 11);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(53, 13);
            this.shLabel3.TabIndex = 0;
            this.shLabel3.Text = "Địa chỉ đón";
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 122);
            this.ControlBox = false;
            this.Controls.Add(this.grbForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmInfo_Load);
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            this.pnlVungDH.ResumeLayout(false);
            this.pnlVungDH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iluVungDH.Properties)).EndInit();
            this.pnlDiaChi.ResumeLayout(false);
            this.pnlDiaChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiDon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbForm;
        private Taxi.Controls.Base.Controls.ShLabel shLabel5;
        private Taxi.Controls.Base.Controls.ShLabel shLabel3;
        private System.Windows.Forms.Timer timer1;
        private Taxi.Controls.Base.Inputs.InputMemoEdit txtDiaChiDon;
        private Controls.Base.Controls.ShButton btnNo;
        private Controls.Base.Controls.ShButton btnYes;
        private System.Windows.Forms.Label lblPrivateCode;
        private Controls.Base.Common.InputLookUp_VungDieuHanh iluVungDH;
        private System.Windows.Forms.Panel pnlDiaChi;
        private System.Windows.Forms.Panel pnlVungDH;
        private Controls.Base.Controls.ShLabel shLabel1;
        private Controls.Base.Controls.ShLabel shLabel2;
    }
}