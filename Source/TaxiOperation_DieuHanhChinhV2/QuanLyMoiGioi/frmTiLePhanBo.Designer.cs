namespace Taxi.GUI
{
    partial class frmTiLePhanBo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiLePhanBo));
            this.btnCapNhat = new Janus.Windows.EditControls.UIButton();
            this.btnHuyBo = new Janus.Windows.EditControls.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMoiGioi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHN = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtCP = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtTOU = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txt3A = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtJAC = new Janus.Windows.GridEX.EditControls.EditBox();
            this.SuspendLayout();
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(48, 140);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 5;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(129, 140);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 23);
            this.btnHuyBo.TabIndex = 6;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hà Nội Taxi";
            // 
            // lblMoiGioi
            // 
            this.lblMoiGioi.AutoSize = true;
            this.lblMoiGioi.Location = new System.Drawing.Point(65, 40);
            this.lblMoiGioi.Name = "lblMoiGioi";
            this.lblMoiGioi.Size = new System.Drawing.Size(44, 13);
            this.lblMoiGioi.TabIndex = 8;
            this.lblMoiGioi.Text = "Taxi CP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Taxi Tourist";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Taxi 3A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Taxi JAC";
            // 
            // txtHN
            // 
            this.txtHN.Location = new System.Drawing.Point(115, 10);
            this.txtHN.Name = "txtHN";
            this.txtHN.Size = new System.Drawing.Size(80, 20);
            this.txtHN.TabIndex = 11;
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(115, 36);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(80, 20);
            this.txtCP.TabIndex = 12;
            // 
            // txtTOU
            // 
            this.txtTOU.Location = new System.Drawing.Point(115, 62);
            this.txtTOU.Name = "txtTOU";
            this.txtTOU.Size = new System.Drawing.Size(80, 20);
            this.txtTOU.TabIndex = 13;
            // 
            // txt3A
            // 
            this.txt3A.Location = new System.Drawing.Point(115, 88);
            this.txt3A.Name = "txt3A";
            this.txt3A.Size = new System.Drawing.Size(80, 20);
            this.txt3A.TabIndex = 14;
            // 
            // txtJAC
            // 
            this.txtJAC.Location = new System.Drawing.Point(115, 114);
            this.txtJAC.Name = "txtJAC";
            this.txtJAC.Size = new System.Drawing.Size(80, 20);
            this.txtJAC.TabIndex = 15;
            // 
            // frmTiLePhanBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 177);
            this.Controls.Add(this.txtJAC);
            this.Controls.Add(this.txt3A);
            this.Controls.Add(this.txtTOU);
            this.Controls.Add(this.txtCP);
            this.Controls.Add(this.txtHN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMoiGioi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnCapNhat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTiLePhanBo";
            this.Text = "Tỉ lệ phân bổ";
            this.Load += new System.EventHandler(this.frmTiLePhanBo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btnCapNhat;
        private Janus.Windows.EditControls.UIButton btnHuyBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMoiGioi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.EditBox txtHN;
        private Janus.Windows.GridEX.EditControls.EditBox txtCP;
        private Janus.Windows.GridEX.EditControls.EditBox txtTOU;
        private Janus.Windows.GridEX.EditControls.EditBox txt3A;
        private Janus.Windows.GridEX.EditControls.EditBox txtJAC;

    }
}