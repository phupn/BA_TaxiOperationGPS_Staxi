namespace Taxi.Controls.FastTaxis.FormFastTaxi
{
    partial class frmPopupSendFastTaxiFail
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
            this.txtMsg = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.shButton2 = new Taxi.Controls.Base.Controls.ShButton();
            this.shButton1 = new Taxi.Controls.Base.Controls.ShButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMsg.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(3, 3);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtMsg.Properties.AppearanceDisabled.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtMsg.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtMsg.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtMsg.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtMsg.Properties.AppearanceReadOnly.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtMsg.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMsg.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtMsg.Properties.AppearanceReadOnly.Options.UseBorderColor = true;
            this.txtMsg.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtMsg.Properties.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(336, 158);
            this.txtMsg.TabIndex = 1;
            // 
            // shButton2
            // 
            this.shButton2.Location = new System.Drawing.Point(175, 170);
            this.shButton2.Name = "shButton2";
            this.shButton2.Size = new System.Drawing.Size(75, 23);
            this.shButton2.TabIndex = 0;
            this.shButton2.Text = "Thoát";
            this.shButton2.Click += new System.EventHandler(this.shButton2_Click);
            // 
            // shButton1
            // 
            this.shButton1.Location = new System.Drawing.Point(79, 170);
            this.shButton1.Name = "shButton1";
            this.shButton1.Size = new System.Drawing.Size(75, 23);
            this.shButton1.TabIndex = 0;
            this.shButton1.Text = "Gửi lại";
            this.shButton1.Click += new System.EventHandler(this.shButton1_Click);
            // 
            // frmPopupSendFastTaxiFail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 202);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.shButton2);
            this.Controls.Add(this.shButton1);
            this.Name = "frmPopupSendFastTaxiFail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo lỗi";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPopupSendFastTaxiFail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMsg.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShButton shButton1;
        private Base.Controls.ShButton shButton2;
        private Base.Inputs.InputMemoEdit txtMsg;
    }
}