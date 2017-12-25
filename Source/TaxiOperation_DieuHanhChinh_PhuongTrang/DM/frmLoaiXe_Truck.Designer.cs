namespace TaxiOperation_BanCo.DM
{
    partial class frmLoaiXe_Truck
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
            this.txtHangXe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHuy = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.txtTenLoaiXe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKichThuoc = new System.Windows.Forms.TextBox();
            this.lblKichThuoc = new System.Windows.Forms.Label();
            this.txtTaiTrongChoPhep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaiTrongQuyDinh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.luePhimTat = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVietTat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fontEdit = new DevExpress.XtraEditors.FontEdit();
            this.lueFontStyle = new DevExpress.XtraEditors.LookUpEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.lueFontSize = new DevExpress.XtraEditors.LookUpEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.inputColorPicker_ForeColor = new Taxi.Controls.Base.Inputs.InputColorPicker();
            this.inputColorPicker_BackColor = new Taxi.Controls.Base.Inputs.InputColorPicker();
            ((System.ComponentModel.ISupportInitialize)(this.luePhimTat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFontStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFontSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputColorPicker_ForeColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputColorPicker_BackColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHangXe
            // 
            this.txtHangXe.Location = new System.Drawing.Point(118, 35);
            this.txtHangXe.Name = "txtHangXe";
            this.txtHangXe.Size = new System.Drawing.Size(308, 20);
            this.txtHangXe.TabIndex = 1;
            this.txtHangXe.TextChanged += new System.EventHandler(this.txtHangXe_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Hãng xe *";
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(216, 243);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(84, 24);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnLuu.Location = new System.Drawing.Point(130, 243);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 24);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu (F2)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtTenLoaiXe
            // 
            this.txtTenLoaiXe.Location = new System.Drawing.Point(118, 9);
            this.txtTenLoaiXe.Name = "txtTenLoaiXe";
            this.txtTenLoaiXe.Size = new System.Drawing.Size(308, 20);
            this.txtTenLoaiXe.TabIndex = 0;
            this.txtTenLoaiXe.TextChanged += new System.EventHandler(this.txtTenLoaiXe_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tên loại xe *";
            // 
            // txtKichThuoc
            // 
            this.txtKichThuoc.Location = new System.Drawing.Point(118, 61);
            this.txtKichThuoc.Name = "txtKichThuoc";
            this.txtKichThuoc.Size = new System.Drawing.Size(308, 20);
            this.txtKichThuoc.TabIndex = 2;
            this.txtKichThuoc.TextChanged += new System.EventHandler(this.txtKichThuoc_TextChanged);
            // 
            // lblKichThuoc
            // 
            this.lblKichThuoc.AutoSize = true;
            this.lblKichThuoc.Location = new System.Drawing.Point(9, 64);
            this.lblKichThuoc.Name = "lblKichThuoc";
            this.lblKichThuoc.Size = new System.Drawing.Size(67, 13);
            this.lblKichThuoc.TabIndex = 35;
            this.lblKichThuoc.Text = "Kích thước *";
            // 
            // txtTaiTrongChoPhep
            // 
            this.txtTaiTrongChoPhep.Location = new System.Drawing.Point(118, 113);
            this.txtTaiTrongChoPhep.Name = "txtTaiTrongChoPhep";
            this.txtTaiTrongChoPhep.Size = new System.Drawing.Size(308, 20);
            this.txtTaiTrongChoPhep.TabIndex = 4;
            this.txtTaiTrongChoPhep.TextChanged += new System.EventHandler(this.txtTaiTrongChoPhep_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Tải trọng cho phép *";
            // 
            // txtTaiTrongQuyDinh
            // 
            this.txtTaiTrongQuyDinh.Location = new System.Drawing.Point(118, 87);
            this.txtTaiTrongQuyDinh.Name = "txtTaiTrongQuyDinh";
            this.txtTaiTrongQuyDinh.Size = new System.Drawing.Size(308, 20);
            this.txtTaiTrongQuyDinh.TabIndex = 3;
            this.txtTaiTrongQuyDinh.TextChanged += new System.EventHandler(this.txtTaiTrongQuyDinh_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Tải trọng quy định *";
            // 
            // luePhimTat
            // 
            this.luePhimTat.Location = new System.Drawing.Point(118, 139);
            this.luePhimTat.Name = "luePhimTat";
            this.luePhimTat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePhimTat.Properties.NullText = "Phím tắt";
            this.luePhimTat.Size = new System.Drawing.Size(120, 20);
            this.luePhimTat.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Phím tắt *";
            // 
            // txtVietTat
            // 
            this.txtVietTat.Location = new System.Drawing.Point(292, 139);
            this.txtVietTat.Name = "txtVietTat";
            this.txtVietTat.Size = new System.Drawing.Size(134, 20);
            this.txtVietTat.TabIndex = 6;
            this.txtVietTat.TextChanged += new System.EventHandler(this.txtVietTat_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Viết tắt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Font hiển thị";
            // 
            // fontEdit
            // 
            this.fontEdit.Location = new System.Drawing.Point(118, 191);
            this.fontEdit.Name = "fontEdit";
            this.fontEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.fontEdit.Properties.ImmediatePopup = true;
            this.fontEdit.Size = new System.Drawing.Size(308, 20);
            this.fontEdit.TabIndex = 7;
            // 
            // lueFontStyle
            // 
            this.lueFontStyle.Location = new System.Drawing.Point(264, 217);
            this.lueFontStyle.Name = "lueFontStyle";
            this.lueFontStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFontStyle.Properties.NullText = "Chọn style";
            this.lueFontStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueFontStyle.Size = new System.Drawing.Size(162, 20);
            this.lueFontStyle.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "pt";
            // 
            // lueFontSize
            // 
            this.lueFontSize.Location = new System.Drawing.Point(118, 217);
            this.lueFontSize.Name = "lueFontSize";
            this.lueFontSize.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueFontSize.Properties.Appearance.Options.UseFont = true;
            this.lueFontSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFontSize.Properties.NullText = "8.25";
            this.lueFontSize.Properties.PopupWidth = 330;
            this.lueFontSize.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueFontSize.Properties.ValidateOnEnterKey = true;
            this.lueFontSize.Size = new System.Drawing.Size(100, 20);
            this.lueFontSize.TabIndex = 8;
            this.lueFontSize.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.lueFontSize_ProcessNewValue);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Màu chữ *";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(244, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Màu nền *";
            // 
            // inputColorPicker_ForeColor
            // 
            this.inputColorPicker_ForeColor.EditValue = System.Drawing.Color.Empty;
            this.inputColorPicker_ForeColor.IsChangeText = false;
            this.inputColorPicker_ForeColor.IsFocus = false;
            this.inputColorPicker_ForeColor.Location = new System.Drawing.Point(118, 165);
            this.inputColorPicker_ForeColor.Name = "inputColorPicker_ForeColor";
            this.inputColorPicker_ForeColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.inputColorPicker_ForeColor.Properties.ShowCustomColors = false;
            this.inputColorPicker_ForeColor.Properties.ShowSystemColors = false;
            this.inputColorPicker_ForeColor.Properties.StoreColorAsInteger = true;
            this.inputColorPicker_ForeColor.Size = new System.Drawing.Size(100, 20);
            this.inputColorPicker_ForeColor.TabIndex = 50;
            // 
            // inputColorPicker_BackColor
            // 
            this.inputColorPicker_BackColor.EditValue = System.Drawing.Color.Empty;
            this.inputColorPicker_BackColor.IsChangeText = false;
            this.inputColorPicker_BackColor.IsFocus = false;
            this.inputColorPicker_BackColor.Location = new System.Drawing.Point(326, 165);
            this.inputColorPicker_BackColor.Name = "inputColorPicker_BackColor";
            this.inputColorPicker_BackColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.inputColorPicker_BackColor.Properties.ShowCustomColors = false;
            this.inputColorPicker_BackColor.Properties.ShowSystemColors = false;
            this.inputColorPicker_BackColor.Properties.StoreColorAsInteger = true;
            this.inputColorPicker_BackColor.Size = new System.Drawing.Size(100, 20);
            this.inputColorPicker_BackColor.TabIndex = 50;
            // 
            // frmLoaiXe_Truck
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(445, 273);
            this.Controls.Add(this.inputColorPicker_BackColor);
            this.Controls.Add(this.inputColorPicker_ForeColor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lueFontSize);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lueFontStyle);
            this.Controls.Add(this.fontEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtVietTat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.luePhimTat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTaiTrongChoPhep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTaiTrongQuyDinh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKichThuoc);
            this.Controls.Add(this.lblKichThuoc);
            this.Controls.Add(this.txtHangXe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTenLoaiXe);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmLoaiXe_Truck";
            this.Text = "Loại xe";
            ((System.ComponentModel.ISupportInitialize)(this.luePhimTat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFontStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFontSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputColorPicker_ForeColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputColorPicker_BackColor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHangXe;
        private System.Windows.Forms.Label label3;
        private Taxi.Controls.Base.Controls.ShButton btnHuy;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private System.Windows.Forms.TextBox txtTenLoaiXe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKichThuoc;
        private System.Windows.Forms.Label lblKichThuoc;
        private System.Windows.Forms.TextBox txtTaiTrongChoPhep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaiTrongQuyDinh;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit luePhimTat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVietTat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.FontEdit fontEdit;
        private DevExpress.XtraEditors.LookUpEdit lueFontStyle;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.LookUpEdit lueFontSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Taxi.Controls.Base.Inputs.InputColorPicker inputColorPicker_ForeColor;
        private Taxi.Controls.Base.Inputs.InputColorPicker inputColorPicker_BackColor;
    }
}