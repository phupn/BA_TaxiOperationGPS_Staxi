namespace TaxiOperation_DieuHanhChinh
{
    partial class frmXeViPham
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoXe = new Taxi.Controls.Base.Inputs.InputText();
            this.deEnd = new Taxi.Controls.Base.Inputs.InputDate();
            this.deStart = new Taxi.Controls.Base.Inputs.InputDate();
            this.btnThem = new Taxi.Controls.Base.Controls.ShButton();
            this.txtGhiChu = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lup_LoaiLoiViPham1 = new Taxi.Controls.Base.Common.InputLookup_LoaiLoiViPham();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lup_LoaiLoiViPham1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Áp dụng Từ";
            // 
            // txtSoXe
            // 
            this.txtSoXe.IsChangeText = false;
            this.txtSoXe.IsFocus = false;
            this.txtSoXe.Location = new System.Drawing.Point(73, 38);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Properties.MaxLength = 50;
            this.txtSoXe.Size = new System.Drawing.Size(110, 20);
            this.txtSoXe.TabIndex = 2;
            // 
            // deEnd
            // 
            this.deEnd.DateNowWhenLoad = true;
            this.deEnd.EditValue = new System.DateTime(2015, 8, 13, 17, 22, 17, 376);
            this.deEnd.IsChangeText = false;
            this.deEnd.IsFocus = false;
            this.deEnd.Location = new System.Drawing.Point(247, 11);
            this.deEnd.Name = "deEnd";
            this.deEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEnd.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.deEnd.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.deEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEnd.Properties.VistaTimeProperties.DisplayFormat.FormatString = "HH:mm";
            this.deEnd.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.VistaTimeProperties.EditFormat.FormatString = "HH:mm";
            this.deEnd.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.VistaTimeProperties.Mask.EditMask = "HH:mm";
            this.deEnd.Size = new System.Drawing.Size(111, 20);
            this.deEnd.TabIndex = 1;
            // 
            // deStart
            // 
            this.deStart.DateNowWhenLoad = true;
            this.deStart.EditValue = new System.DateTime(2015, 8, 13, 17, 21, 24, 67);
            this.deStart.IsChangeText = false;
            this.deStart.IsFocus = false;
            this.deStart.Location = new System.Drawing.Point(73, 11);
            this.deStart.Name = "deStart";
            this.deStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStart.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.deStart.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.deStart.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.deStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deStart.Properties.VistaTimeProperties.DisplayFormat.FormatString = "HH:mm";
            this.deStart.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.VistaTimeProperties.EditFormat.FormatString = "HH:mm";
            this.deStart.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.VistaTimeProperties.Mask.EditMask = "HH:mm";
            this.deStart.Size = new System.Drawing.Size(110, 20);
            this.deStart.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnThem.Location = new System.Drawing.Point(134, 163);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(94, 23);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "[ F2] - Cập nhật";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.IsChangeText = false;
            this.txtGhiChu.IsFocus = false;
            this.txtGhiChu.Location = new System.Drawing.Point(73, 90);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.MaxLength = 255;
            this.txtGhiChu.Size = new System.Drawing.Size(285, 67);
            this.txtGhiChu.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ghi chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Lỗi vị phạm";
            // 
            // lup_LoaiLoiViPham1
            // 
            this.lup_LoaiLoiViPham1.DefaultSelectFirstRow = false;
            this.lup_LoaiLoiViPham1.IsChangeText = false;
            this.lup_LoaiLoiViPham1.IsFocus = false;
            this.lup_LoaiLoiViPham1.IsVaildateAdd = true;
            this.lup_LoaiLoiViPham1.Location = new System.Drawing.Point(73, 64);
            this.lup_LoaiLoiViPham1.Name = "lup_LoaiLoiViPham1";
            this.lup_LoaiLoiViPham1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lup_LoaiLoiViPham1.Properties.DisplayMember = "TenLoaiLoiViPham";
            this.lup_LoaiLoiViPham1.Properties.MaxLength = 254;
            this.lup_LoaiLoiViPham1.Properties.NullText = "";
            this.lup_LoaiLoiViPham1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lup_LoaiLoiViPham1.Properties.ValueMember = "Id";
            this.lup_LoaiLoiViPham1.Size = new System.Drawing.Size(285, 20);
            this.lup_LoaiLoiViPham1.TabIndex = 3;
            // 
            // frmXeViPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 194);
            this.Controls.Add(this.lup_LoaiLoiViPham1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoXe);
            this.Controls.Add(this.deEnd);
            this.Controls.Add(this.deStart);
            this.Name = "frmXeViPham";
            this.Text = "Xe vi phạm lỗi";
            this.Load += new System.EventHandler(this.frmXeViPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lup_LoaiLoiViPham1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Taxi.Controls.Base.Inputs.InputText txtSoXe;
        private Taxi.Controls.Base.Inputs.InputDate deEnd;
        private Taxi.Controls.Base.Inputs.InputDate deStart;
        private Taxi.Controls.Base.Controls.ShButton btnThem;
        private Taxi.Controls.Base.Inputs.InputMemoEdit txtGhiChu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Taxi.Controls.Base.Common.InputLookup_LoaiLoiViPham lup_LoaiLoiViPham1;
    }
}