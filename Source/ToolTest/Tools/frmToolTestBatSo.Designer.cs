namespace ToolTest
{
    partial class frmToolTestBatSo
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
            this.label2 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCall = new Taxi.Controls.Base.Controls.ShButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSLCuoc = new Taxi.Controls.Base.Inputs.InputText();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSDT = new Taxi.Controls.Base.Inputs.InputText();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbkGoiLai = new Taxi.Controls.Base.Inputs.InputCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLCuoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbkGoiLai.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Số điện thoại:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCall);
            this.panelControl1.Location = new System.Drawing.Point(12, 117);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(358, 35);
            this.panelControl1.TabIndex = 9;
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(126, 7);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(75, 23);
            this.btnCall.TabIndex = 0;
            this.btnCall.Text = "Gọi điện";
            this.btnCall.Click += new System.EventHandler(this.btnGoiDien_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSLCuoc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 99);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cuộc gọi";
            // 
            // txtSLCuoc
            // 
            this.txtSLCuoc.IsChangeText = false;
            this.txtSLCuoc.IsFocus = false;
            this.txtSLCuoc.Location = new System.Drawing.Point(120, 59);
            this.txtSLCuoc.Name = "txtSLCuoc";
            this.txtSLCuoc.Properties.Mask.EditMask = "\\d+";
            this.txtSLCuoc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSLCuoc.Properties.MaxLength = 15;
            this.txtSLCuoc.Size = new System.Drawing.Size(196, 20);
            this.txtSLCuoc.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Số lượng cuốc:";
            // 
            // txtSDT
            // 
            this.txtSDT.IsChangeText = false;
            this.txtSDT.IsFocus = false;
            this.txtSDT.Location = new System.Drawing.Point(120, 19);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Mask.EditMask = "\\d+";
            this.txtSDT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSDT.Properties.MaxLength = 15;
            this.txtSDT.Size = new System.Drawing.Size(196, 20);
            this.txtSDT.TabIndex = 7;
            // 
            // cbkGoiLai
            // 
            this.cbkGoiLai.IsChangeText = false;
            this.cbkGoiLai.IsFocus = false;
            this.cbkGoiLai.KeyCommand = System.Windows.Forms.Keys.None;
            this.cbkGoiLai.Location = new System.Drawing.Point(376, 22);
            this.cbkGoiLai.Name = "cbkGoiLai";
            this.cbkGoiLai.Properties.Caption = "Cuốc gọi lại";
            this.cbkGoiLai.Size = new System.Drawing.Size(87, 19);
            this.cbkGoiLai.TabIndex = 10;
            // 
            // frmToolTestBatSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 162);
            this.Controls.Add(this.cbkGoiLai);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmToolTestBatSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Bắt Số Cuộc Gọi";
            this.Load += new System.EventHandler(this.frmToolTestBatSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLCuoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbkGoiLai.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Inputs.InputText txtSDT;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Taxi.Controls.Base.Controls.ShButton btnCall;
        private System.Windows.Forms.GroupBox groupBox1;
        private Taxi.Controls.Base.Inputs.InputText txtSLCuoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Taxi.Controls.Base.Inputs.InputCheckbox cbkGoiLai;


    }
}

