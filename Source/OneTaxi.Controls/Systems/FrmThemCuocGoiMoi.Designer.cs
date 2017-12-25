namespace OneTaxi.Controls.Systems
{
    partial class FrmThemCuocGoiMoi
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
            this.groupBox1 = new OneTaxi.Controls.Base.Controls.GroupBox();
            this.label2 = new OneTaxi.Controls.Base.Controls.Label();
            this.label1 = new OneTaxi.Controls.Base.Controls.Label();
            this.inputText2 = new OneTaxi.Controls.Base.Inputs.InputText();
            this.inputText1 = new OneTaxi.Controls.Base.Inputs.InputText();
            this.panelControl1 = new OneTaxi.Controls.Base.Controls.PanelControl();
            this.btnHuyBo = new OneTaxi.Controls.Base.Controls.Button();
            this.bttnCapNhat = new OneTaxi.Controls.Base.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputText2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputText1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inputText2);
            this.groupBox1.Controls.Add(this.inputText1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 137);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.Text = "Chèn mới một cuộc điện thoại";
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 1;
            this.label2.TagLanguage = null;
            this.label2.Text = "Địa chỉ đón";
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 1;
            this.label1.TagLanguage = null;
            this.label1.Text = "Số điện thoại";
            // 
            // inputText2
            // 
            this.inputText2.IsChangeText = false;
            this.inputText2.IsFocus = false;
            this.inputText2.Location = new System.Drawing.Point(147, 87);
            this.inputText2.Name = "inputText2";
            this.inputText2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputText2.Properties.Appearance.Options.UseFont = true;
            this.inputText2.Size = new System.Drawing.Size(255, 29);
            this.inputText2.TabIndex = 0;
            // 
            // inputText1
            // 
            this.inputText1.IsChangeText = false;
            this.inputText1.IsFocus = false;
            this.inputText1.Location = new System.Drawing.Point(147, 52);
            this.inputText1.Name = "inputText1";
            this.inputText1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputText1.Properties.Appearance.Options.UseFont = true;
            this.inputText1.Size = new System.Drawing.Size(255, 29);
            this.inputText1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnHuyBo);
            this.panelControl1.Controls.Add(this.bttnCapNhat);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 164);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(451, 45);
            this.panelControl1.TabIndex = 2;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnHuyBo.Location = new System.Drawing.Point(228, 10);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 23);
            this.btnHuyBo.TabIndex = 0;
            this.btnHuyBo.TagLanguage = null;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // bttnCapNhat
            // 
            this.bttnCapNhat.KeyCommand = System.Windows.Forms.Keys.None;
            this.bttnCapNhat.Location = new System.Drawing.Point(147, 10);
            this.bttnCapNhat.Name = "bttnCapNhat";
            this.bttnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.bttnCapNhat.TabIndex = 0;
            this.bttnCapNhat.TagLanguage = null;
            this.bttnCapNhat.Text = "Cập nhật";
            this.bttnCapNhat.Click += new System.EventHandler(this.bttnCapNhat_Click);
            // 
            // FrmThemCuocGoiMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 209);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmThemCuocGoiMoi";
            this.Text = "Điều hành điện thoại";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputText2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputText1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.GroupBox groupBox1;
        private Base.Controls.PanelControl panelControl1;
        private Base.Controls.Button bttnCapNhat;
        private Base.Controls.Button btnHuyBo;
        private Base.Inputs.InputText inputText1;
        private Base.Controls.Label label1;
        private Base.Controls.Label label2;
        private Base.Inputs.InputText inputText2;
    }
}