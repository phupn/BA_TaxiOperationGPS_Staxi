namespace Taxi.Controls.DanhSach.DMXE
{
    partial class FormUpdateXe
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
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoHieuXe = new Taxi.Controls.Base.Inputs.InputText();
            this.lookUpLoaiXe = new Taxi.Controls.Base.Common.InputLookUps.InputLookUp_LoaiXe();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lookUpGara = new Taxi.Controls.Base.Common.InputLookUps.InputLookUp_Gara();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtBienSo = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).BeginInit();
            this.panelInputView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieuXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLoaiXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGara.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBienSo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInputView
            // 
            this.panelInputView.Controls.Add(this.lookUpGara);
            this.panelInputView.Controls.Add(this.lookUpLoaiXe);
            this.panelInputView.Controls.Add(this.shLabel3);
            this.panelInputView.Controls.Add(this.shLabel2);
            this.panelInputView.Controls.Add(this.shLabel4);
            this.panelInputView.Controls.Add(this.txtBienSo);
            this.panelInputView.Controls.Add(this.shLabel1);
            this.panelInputView.Controls.Add(this.txtSoHieuXe);
            this.panelInputView.Size = new System.Drawing.Size(276, 131);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 131);
            this.panel1.Size = new System.Drawing.Size(276, 50);
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(14, 18);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(50, 13);
            this.shLabel1.TabIndex = 3;
            this.shLabel1.Text = "Số hiệu xe";
            // 
            // txtSoHieuXe
            // 
            this.txtSoHieuXe.IsChangeText = false;
            this.txtSoHieuXe.IsFocus = false;
            this.txtSoHieuXe.Location = new System.Drawing.Point(84, 15);
            this.txtSoHieuXe.Name = "txtSoHieuXe";
            this.txtSoHieuXe.Properties.Mask.EditMask = "[0-9A-Za-z\\-_.,]+";
            this.txtSoHieuXe.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSoHieuXe.Properties.MaxLength = 15;
            this.txtSoHieuXe.Size = new System.Drawing.Size(152, 20);
            this.txtSoHieuXe.TabIndex = 2;
            this.txtSoHieuXe.Tag = "PK_SoHieuXe";
            // 
            // lookUpLoaiXe
            // 
            this.lookUpLoaiXe.DefaultSelectFirstRow = false;
            this.lookUpLoaiXe.IsChangeText = false;
            this.lookUpLoaiXe.IsFocus = false;
            this.lookUpLoaiXe.IsShowTextNull = true;
            this.lookUpLoaiXe.Location = new System.Drawing.Point(84, 67);
            this.lookUpLoaiXe.Name = "lookUpLoaiXe";
            this.lookUpLoaiXe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpLoaiXe.Properties.NullText = "Chọn loại xe";
            this.lookUpLoaiXe.Size = new System.Drawing.Size(152, 20);
            this.lookUpLoaiXe.TabIndex = 4;
            this.lookUpLoaiXe.Tag = "FK_LoaiXeID";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(30, 70);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(34, 13);
            this.shLabel2.TabIndex = 3;
            this.shLabel2.Text = "Loại xe";
            // 
            // lookUpGara
            // 
            this.lookUpGara.DefaultSelectFirstRow = false;
            this.lookUpGara.IsChangeText = false;
            this.lookUpGara.IsFocus = false;
            this.lookUpGara.IsShowTextNull = true;
            this.lookUpGara.Location = new System.Drawing.Point(84, 93);
            this.lookUpGara.Name = "lookUpGara";
            this.lookUpGara.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpGara.Properties.NullText = "Chọn Gara";
            this.lookUpGara.Size = new System.Drawing.Size(152, 20);
            this.lookUpGara.TabIndex = 5;
            this.lookUpGara.Tag = "FK_GaraID";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(41, 96);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(23, 13);
            this.shLabel3.TabIndex = 3;
            this.shLabel3.Text = "Gara";
            // 
            // txtBienSo
            // 
            this.txtBienSo.IsChangeText = false;
            this.txtBienSo.IsFocus = false;
            this.txtBienSo.Location = new System.Drawing.Point(84, 41);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Properties.Mask.EditMask = "[0-9A-Za-z\\-_.,]+";
            this.txtBienSo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtBienSo.Properties.MaxLength = 15;
            this.txtBienSo.Size = new System.Drawing.Size(152, 20);
            this.txtBienSo.TabIndex = 2;
            this.txtBienSo.Tag = "BienKiemSoat";
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(30, 44);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(34, 13);
            this.shLabel4.TabIndex = 3;
            this.shLabel4.Text = "Biển số";
            // 
            // FormUpdateXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 181);
            this.FieldEnable = new string[] {
        "PK_SoHieuXe"};
            this.MaximizeBox = false;
            this.Name = "FormUpdateXe";
            this.Text = "Cập nhật thông tin xe";
            ((System.ComponentModel.ISupportInitialize)(this.panelInputView)).EndInit();
            this.panelInputView.ResumeLayout(false);
            this.panelInputView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieuXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLoaiXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGara.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBienSo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputText txtSoHieuXe;
        private Base.Common.InputLookUps.InputLookUp_LoaiXe lookUpLoaiXe;
        private Base.Controls.ShLabel shLabel2;
        private Base.Common.InputLookUps.InputLookUp_Gara lookUpGara;
        private Base.Controls.ShLabel shLabel3;
        private Base.Controls.ShLabel shLabel4;
        private Base.Inputs.InputText txtBienSo;
    }
}