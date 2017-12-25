namespace Taxi.Controls.DanhSach.DMDuongPho
{
    partial class FrmUpdateDuongPho
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
            this.inputText1 = new Taxi.Controls.Base.Inputs.InputText();
            this.inputText2 = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.inputCheckbox1 = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).BeginInit();
            this.panelInputView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputText1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputText2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCheckbox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInputView
            // 
            this.panelInputView.Controls.Add(this.inputCheckbox1);
            this.panelInputView.Controls.Add(this.shLabel3);
            this.panelInputView.Controls.Add(this.shLabel2);
            this.panelInputView.Controls.Add(this.shLabel1);
            this.panelInputView.Controls.Add(this.inputText2);
            this.panelInputView.Controls.Add(this.inputText1);
            this.panelInputView.Size = new System.Drawing.Size(325, 134);
            this.panelInputView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 134);
            this.panel1.Size = new System.Drawing.Size(325, 50);
            this.panel1.TabIndex = 1;
            // 
            // inputText1
            // 
            this.inputText1.IsChangeText = false;
            this.inputText1.IsFocus = false;
            this.inputText1.Location = new System.Drawing.Point(100, 27);
            this.inputText1.Name = "inputText1";
            this.inputText1.Properties.MaxLength = 255;
            this.inputText1.Size = new System.Drawing.Size(213, 20);
            this.inputText1.TabIndex = 0;
            this.inputText1.Tag = "TenDuongPho";
            // 
            // inputText2
            // 
            this.inputText2.IsChangeText = false;
            this.inputText2.IsFocus = false;
            this.inputText2.Location = new System.Drawing.Point(100, 53);
            this.inputText2.Name = "inputText2";
            this.inputText2.Size = new System.Drawing.Size(213, 20);
            this.inputText2.TabIndex = 1;
            this.inputText2.Tag = "TenDuongPhoDayDu";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(35, 30);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(52, 13);
            this.shLabel1.TabIndex = 1;
            this.shLabel1.Text = "Tên đường";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(10, 56);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(77, 13);
            this.shLabel2.TabIndex = 1;
            this.shLabel2.Text = "Tên đường cxác";
            // 
            // inputCheckbox1
            // 
            this.inputCheckbox1.IsChangeText = false;
            this.inputCheckbox1.IsFocus = false;
            this.inputCheckbox1.KeyCommand = System.Windows.Forms.Keys.None;
            this.inputCheckbox1.Location = new System.Drawing.Point(97, 80);
            this.inputCheckbox1.Name = "inputCheckbox1";
            this.inputCheckbox1.Properties.Caption = "";
            this.inputCheckbox1.Size = new System.Drawing.Size(75, 19);
            this.inputCheckbox1.TabIndex = 2;
            this.inputCheckbox1.Tag = "IsBaoCao";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(49, 82);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(38, 13);
            this.shLabel3.TabIndex = 1;
            this.shLabel3.Text = "Báo cáo";
            // 
            // FrmUpdateDuongPho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 184);
            this.Name = "FrmUpdateDuongPho";
            this.Text = "Cập nhật thông tin đường phố";
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).EndInit();
            this.panelInputView.ResumeLayout(false);
            this.panelInputView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputText1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputText2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCheckbox1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Inputs.InputText inputText1;
        private Base.Inputs.InputText inputText2;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputCheckbox inputCheckbox1;
        private Base.Controls.ShLabel shLabel3;
    }
}