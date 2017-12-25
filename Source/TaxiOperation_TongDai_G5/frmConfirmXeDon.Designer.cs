namespace Taxi.GUI
{
    partial class frmConfirmXeDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmXeDon));
            this.rbConfirmXeDon1 = new System.Windows.Forms.RadioButton();
            this.rbConfirmXeDon2 = new System.Windows.Forms.RadioButton();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbConfirmXeDon3 = new System.Windows.Forms.RadioButton();
            this.txtXeDon = new System.Windows.Forms.TextBox();
            this.lblXeDon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbConfirmXeDon1
            // 
            this.rbConfirmXeDon1.AutoSize = true;
            this.rbConfirmXeDon1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConfirmXeDon1.Location = new System.Drawing.Point(15, 49);
            this.rbConfirmXeDon1.Name = "rbConfirmXeDon1";
            this.rbConfirmXeDon1.Size = new System.Drawing.Size(155, 22);
            this.rbConfirmXeDon1.TabIndex = 0;
            this.rbConfirmXeDon1.Text = "&1.Không xác định";
            this.rbConfirmXeDon1.UseVisualStyleBackColor = false;
            this.rbConfirmXeDon1.CheckedChanged += new System.EventHandler(this.rbConfirmXeDon1_CheckedChanged);
            // 
            // rbConfirmXeDon2
            // 
            this.rbConfirmXeDon2.AutoSize = true;
            this.rbConfirmXeDon2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConfirmXeDon2.Location = new System.Drawing.Point(287, 49);
            this.rbConfirmXeDon2.Name = "rbConfirmXeDon2";
            this.rbConfirmXeDon2.Size = new System.Drawing.Size(168, 22);
            this.rbConfirmXeDon2.TabIndex = 0;
            this.rbConfirmXeDon2.Text = "&2.Lái xe không báo";
            this.rbConfirmXeDon2.UseVisualStyleBackColor = true;
            this.rbConfirmXeDon2.CheckedChanged += new System.EventHandler(this.rbConfirmXeDon2_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AllowDrop = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(5, 5);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(499, 33);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Xe đón không thuộc Xe đến điểm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "[ Bấm 1 hoặc 2 để xác nhận cảnh báo ]";
            // 
            // rbConfirmXeDon3
            // 
            this.rbConfirmXeDon3.AutoSize = true;
            this.rbConfirmXeDon3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConfirmXeDon3.Location = new System.Drawing.Point(350, 49);
            this.rbConfirmXeDon3.Name = "rbConfirmXeDon3";
            this.rbConfirmXeDon3.Size = new System.Drawing.Size(161, 22);
            this.rbConfirmXeDon3.TabIndex = 0;
            this.rbConfirmXeDon3.Text = "&3.Nhập sai xe đón";
            this.rbConfirmXeDon3.UseVisualStyleBackColor = true;
            this.rbConfirmXeDon3.Visible = false;
            this.rbConfirmXeDon3.CheckedChanged += new System.EventHandler(this.rbConfirmXeDon3_CheckedChanged);
            // 
            // txtXeDon
            // 
            this.txtXeDon.BackColor = System.Drawing.SystemColors.Control;
            this.txtXeDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXeDon.ForeColor = System.Drawing.Color.Crimson;
            this.txtXeDon.Location = new System.Drawing.Point(401, 80);
            this.txtXeDon.MaxLength = 100;
            this.txtXeDon.Name = "txtXeDon";
            this.txtXeDon.Size = new System.Drawing.Size(110, 26);
            this.txtXeDon.TabIndex = 3;
            this.txtXeDon.Visible = false;
            this.txtXeDon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtXeDon_KeyDown);
            // 
            // lblXeDon
            // 
            this.lblXeDon.AutoSize = true;
            this.lblXeDon.Location = new System.Drawing.Point(353, 88);
            this.lblXeDon.Name = "lblXeDon";
            this.lblXeDon.Size = new System.Drawing.Size(42, 13);
            this.lblXeDon.TabIndex = 2;
            this.lblXeDon.Text = "Xe đón";
            this.lblXeDon.Visible = false;
            // 
            // frmConfirmXeDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(516, 112);
            this.ControlBox = false;
            this.Controls.Add(this.txtXeDon);
            this.Controls.Add(this.rbConfirmXeDon2);
            this.Controls.Add(this.lblXeDon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.rbConfirmXeDon3);
            this.Controls.Add(this.rbConfirmXeDon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfirmXeDon";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ghi nhận cảnh báo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfirmXeDon_FormClosing);
            this.Load += new System.EventHandler(this.frmConfirmXeDon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbConfirmXeDon1;
        private System.Windows.Forms.RadioButton rbConfirmXeDon2;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbConfirmXeDon3;
        private System.Windows.Forms.TextBox txtXeDon;
        private System.Windows.Forms.Label lblXeDon;
    }
}