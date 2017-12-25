namespace Taxi.Controls
{
    partial class TinhTienTheoKM_V2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbkHaiChieu = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cv_lblMsg2 = new System.Windows.Forms.Label();
            this.cv_lblMsg1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.lblMessage3 = new System.Windows.Forms.Label();
            this.lblMessage4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtThongTinThueBao = new System.Windows.Forms.TextBox();
            this.cboDiaDanh = new System.Windows.Forms.ComboBox();
            this.chkDiaDanh = new System.Windows.Forms.CheckBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMessage5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbLoaiXe = new Taxi.Controls.Base.Common.ctrl_LoaiXe_Combobox();
            this.editTGSuDungXe = new Taxi.Controls.Base.Inputs.InputText();
            this.editTongTien = new Taxi.Controls.Base.Inputs.InputText();
            this.editTienChieuVe = new Taxi.Controls.Base.Inputs.InputText();
            this.editTienChieuDi = new Taxi.Controls.Base.Inputs.InputText();
            this.editKm = new Taxi.Controls.Base.Inputs.InputText();
            this.btnThoai = new Taxi.Controls.Base.Controls.ShButton();
            this.btnTinhTien = new Taxi.Controls.Base.Controls.ShButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editTGSuDungXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTongTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTienChieuVe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTienChieuDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKm.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbkHaiChieu
            // 
            this.cbkHaiChieu.AutoSize = true;
            this.cbkHaiChieu.Checked = true;
            this.cbkHaiChieu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkHaiChieu.Location = new System.Drawing.Point(194, 301);
            this.cbkHaiChieu.Name = "cbkHaiChieu";
            this.cbkHaiChieu.Size = new System.Drawing.Size(71, 17);
            this.cbkHaiChieu.TabIndex = 33;
            this.cbkHaiChieu.Text = "&Hai chiều";
            this.cbkHaiChieu.UseVisualStyleBackColor = true;
            this.cbkHaiChieu.CheckedChanged += new System.EventHandler(this.cbkTongKM_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 355);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "TG sử dụng xe";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cv_lblMsg2);
            this.groupBox2.Controls.Add(this.cv_lblMsg1);
            this.groupBox2.Location = new System.Drawing.Point(268, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 131);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chiều về";
            // 
            // cv_lblMsg2
            // 
            this.cv_lblMsg2.AutoEllipsis = true;
            this.cv_lblMsg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cv_lblMsg2.Location = new System.Drawing.Point(5, 65);
            this.cv_lblMsg2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cv_lblMsg2.Name = "cv_lblMsg2";
            this.cv_lblMsg2.Size = new System.Drawing.Size(240, 37);
            this.cv_lblMsg2.TabIndex = 6;
            this.cv_lblMsg2.Text = "Chiều về ngưỡng 2 : ";
            // 
            // cv_lblMsg1
            // 
            this.cv_lblMsg1.AutoSize = true;
            this.cv_lblMsg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cv_lblMsg1.Location = new System.Drawing.Point(5, 23);
            this.cv_lblMsg1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cv_lblMsg1.Name = "cv_lblMsg1";
            this.cv_lblMsg1.Size = new System.Drawing.Size(126, 13);
            this.cv_lblMsg1.TabIndex = 6;
            this.cv_lblMsg1.Text = "Chiều về ngưỡng 1 : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMessage1);
            this.groupBox1.Controls.Add(this.lblMessage2);
            this.groupBox1.Controls.Add(this.lblMessage3);
            this.groupBox1.Controls.Add(this.lblMessage4);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 131);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chiều đi";
            // 
            // lblMessage1
            // 
            this.lblMessage1.AutoSize = true;
            this.lblMessage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage1.Location = new System.Drawing.Point(8, 23);
            this.lblMessage1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(82, 13);
            this.lblMessage1.TabIndex = 6;
            this.lblMessage1.Text = "KM ngưỡng 1";
            // 
            // lblMessage2
            // 
            this.lblMessage2.AutoSize = true;
            this.lblMessage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage2.Location = new System.Drawing.Point(8, 49);
            this.lblMessage2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(82, 13);
            this.lblMessage2.TabIndex = 7;
            this.lblMessage2.Text = "KM ngưỡng 2";
            // 
            // lblMessage3
            // 
            this.lblMessage3.AutoSize = true;
            this.lblMessage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage3.Location = new System.Drawing.Point(8, 76);
            this.lblMessage3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage3.Name = "lblMessage3";
            this.lblMessage3.Size = new System.Drawing.Size(82, 13);
            this.lblMessage3.TabIndex = 8;
            this.lblMessage3.Text = "KM ngưỡng 3";
            // 
            // lblMessage4
            // 
            this.lblMessage4.AutoSize = true;
            this.lblMessage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage4.Location = new System.Drawing.Point(8, 103);
            this.lblMessage4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage4.Name = "lblMessage4";
            this.lblMessage4.Size = new System.Drawing.Size(82, 13);
            this.lblMessage4.TabIndex = 8;
            this.lblMessage4.Text = "KM ngưỡng 4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Loại xe";
            // 
            // txtThongTinThueBao
            // 
            this.txtThongTinThueBao.BackColor = System.Drawing.SystemColors.Info;
            this.txtThongTinThueBao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtThongTinThueBao.Enabled = false;
            this.txtThongTinThueBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongTinThueBao.ForeColor = System.Drawing.Color.Black;
            this.txtThongTinThueBao.Location = new System.Drawing.Point(12, 193);
            this.txtThongTinThueBao.Multiline = true;
            this.txtThongTinThueBao.Name = "txtThongTinThueBao";
            this.txtThongTinThueBao.Size = new System.Drawing.Size(503, 70);
            this.txtThongTinThueBao.TabIndex = 25;
            // 
            // cboDiaDanh
            // 
            this.cboDiaDanh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDiaDanh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDiaDanh.FormattingEnabled = true;
            this.cboDiaDanh.Location = new System.Drawing.Point(87, 270);
            this.cboDiaDanh.Name = "cboDiaDanh";
            this.cboDiaDanh.Size = new System.Drawing.Size(201, 21);
            this.cboDiaDanh.TabIndex = 4;
            this.cboDiaDanh.SelectedValueChanged += new System.EventHandler(this.cboDiaDanh_SelectedValueChanged);
            // 
            // chkDiaDanh
            // 
            this.chkDiaDanh.AutoSize = true;
            this.chkDiaDanh.Location = new System.Drawing.Point(12, 272);
            this.chkDiaDanh.Name = "chkDiaDanh";
            this.chkDiaDanh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDiaDanh.Size = new System.Drawing.Size(69, 17);
            this.chkDiaDanh.TabIndex = 3;
            this.chkDiaDanh.Text = "Địa danh";
            this.chkDiaDanh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDiaDanh.UseVisualStyleBackColor = true;
            this.chkDiaDanh.CheckedChanged += new System.EventHandler(this.chkDiaDanh_CheckedChanged);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(289, 327);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(52, 13);
            this.lblTongTien.TabIndex = 11;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(288, 299);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Thành tiền chiều về";
            // 
            // lblMessage5
            // 
            this.lblMessage5.AutoSize = true;
            this.lblMessage5.Location = new System.Drawing.Point(12, 177);
            this.lblMessage5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage5.Name = "lblMessage5";
            this.lblMessage5.Size = new System.Drawing.Size(79, 13);
            this.lblMessage5.TabIndex = 9;
            this.lblMessage5.Text = "Thông tin khác";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 272);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thành tiền chiều đi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 302);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nhập &Km (Enter)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbLoaiXe);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.editTGSuDungXe);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.editTongTien);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.editTienChieuVe);
            this.groupBox3.Controls.Add(this.lblMessage5);
            this.groupBox3.Controls.Add(this.editTienChieuDi);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbkHaiChieu);
            this.groupBox3.Controls.Add(this.lblTongTien);
            this.groupBox3.Controls.Add(this.editKm);
            this.groupBox3.Controls.Add(this.chkDiaDanh);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cboDiaDanh);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.txtThongTinThueBao);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(3, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(522, 378);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tính tiền theo Km";
            // 
            // cbLoaiXe
            // 
            this.cbLoaiXe.EnterMoveNextControl = false;
            this.cbLoaiXe.Location = new System.Drawing.Point(67, 17);
            this.cbLoaiXe.Name = "cbLoaiXe";
            this.cbLoaiXe.NoneItemAll = false;
            this.cbLoaiXe.SelectItemFirst = true;
            this.cbLoaiXe.Size = new System.Drawing.Size(208, 20);
            this.cbLoaiXe.TabIndex = 38;
            this.cbLoaiXe.OnUserControlEditValueChanged += new Taxi.Controls.Base.Common.ctrl_LoaiXe_Combobox.EditValueChangedEventHandler(this.cbLoaiXe_SelectedIndexChanged);
            // 
            // editTGSuDungXe
            // 
            this.editTGSuDungXe.EditValue = "";
            this.editTGSuDungXe.Enabled = false;
            this.editTGSuDungXe.IsChangeText = false;
            this.editTGSuDungXe.IsFocus = false;
            this.editTGSuDungXe.Location = new System.Drawing.Point(402, 352);
            this.editTGSuDungXe.Name = "editTGSuDungXe";
            this.editTGSuDungXe.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.editTGSuDungXe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTGSuDungXe.Properties.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.editTGSuDungXe.Properties.Appearance.Options.UseBackColor = true;
            this.editTGSuDungXe.Properties.Appearance.Options.UseFont = true;
            this.editTGSuDungXe.Properties.Appearance.Options.UseForeColor = true;
            this.editTGSuDungXe.Properties.Appearance.Options.UseTextOptions = true;
            this.editTGSuDungXe.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editTGSuDungXe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editTGSuDungXe.Size = new System.Drawing.Size(111, 24);
            this.editTGSuDungXe.TabIndex = 37;
            // 
            // editTongTien
            // 
            this.editTongTien.EditValue = "";
            this.editTongTien.Enabled = false;
            this.editTongTien.IsChangeText = false;
            this.editTongTien.IsFocus = false;
            this.editTongTien.Location = new System.Drawing.Point(402, 324);
            this.editTongTien.Name = "editTongTien";
            this.editTongTien.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.editTongTien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTongTien.Properties.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.editTongTien.Properties.Appearance.Options.UseBackColor = true;
            this.editTongTien.Properties.Appearance.Options.UseFont = true;
            this.editTongTien.Properties.Appearance.Options.UseForeColor = true;
            this.editTongTien.Properties.Appearance.Options.UseTextOptions = true;
            this.editTongTien.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editTongTien.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editTongTien.Size = new System.Drawing.Size(111, 24);
            this.editTongTien.TabIndex = 36;
            // 
            // editTienChieuVe
            // 
            this.editTienChieuVe.EditValue = "";
            this.editTienChieuVe.Enabled = false;
            this.editTienChieuVe.IsChangeText = false;
            this.editTienChieuVe.IsFocus = false;
            this.editTienChieuVe.Location = new System.Drawing.Point(402, 298);
            this.editTienChieuVe.Name = "editTienChieuVe";
            this.editTienChieuVe.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.editTienChieuVe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTienChieuVe.Properties.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.editTienChieuVe.Properties.Appearance.Options.UseBackColor = true;
            this.editTienChieuVe.Properties.Appearance.Options.UseFont = true;
            this.editTienChieuVe.Properties.Appearance.Options.UseForeColor = true;
            this.editTienChieuVe.Properties.Appearance.Options.UseTextOptions = true;
            this.editTienChieuVe.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editTienChieuVe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editTienChieuVe.Size = new System.Drawing.Size(111, 24);
            this.editTienChieuVe.TabIndex = 35;
            // 
            // editTienChieuDi
            // 
            this.editTienChieuDi.EditValue = "";
            this.editTienChieuDi.Enabled = false;
            this.editTienChieuDi.IsChangeText = false;
            this.editTienChieuDi.IsFocus = false;
            this.editTienChieuDi.Location = new System.Drawing.Point(402, 269);
            this.editTienChieuDi.Name = "editTienChieuDi";
            this.editTienChieuDi.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.editTienChieuDi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTienChieuDi.Properties.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.editTienChieuDi.Properties.Appearance.Options.UseBackColor = true;
            this.editTienChieuDi.Properties.Appearance.Options.UseFont = true;
            this.editTienChieuDi.Properties.Appearance.Options.UseForeColor = true;
            this.editTienChieuDi.Properties.Appearance.Options.UseTextOptions = true;
            this.editTienChieuDi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editTienChieuDi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editTienChieuDi.Size = new System.Drawing.Size(111, 24);
            this.editTienChieuDi.TabIndex = 34;
            // 
            // editKm
            // 
            this.editKm.IsChangeText = false;
            this.editKm.IsFocus = false;
            this.editKm.Location = new System.Drawing.Point(87, 299);
            this.editKm.Name = "editKm";
            this.editKm.Properties.DisplayFormat.FormatString = "0.0";
            this.editKm.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKm.Properties.EditFormat.FormatString = "0.0";
            this.editKm.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKm.Properties.Mask.EditMask = "0.0";
            this.editKm.Size = new System.Drawing.Size(100, 20);
            this.editKm.TabIndex = 32;
            // 
            // btnThoai
            // 
            this.btnThoai.Location = new System.Drawing.Point(434, 380);
            this.btnThoai.Name = "btnThoai";
            this.btnThoai.Size = new System.Drawing.Size(75, 23);
            this.btnThoai.TabIndex = 33;
            this.btnThoai.Text = "&Thoát";
            this.btnThoai.Click += new System.EventHandler(this.btnThoai_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(353, 380);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(75, 23);
            this.btnTinhTien.TabIndex = 32;
            this.btnTinhTien.Text = "Tí&nh tiền";
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // TinhTienTheoKM_V2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnThoai);
            this.Controls.Add(this.btnTinhTien);
            this.Name = "TinhTienTheoKM_V2";
            this.Size = new System.Drawing.Size(528, 406);
            this.Load += new System.EventHandler(this.TinhTienTheoKM_V2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editTGSuDungXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTongTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTienChieuVe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTienChieuDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKm.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label cv_lblMsg1;
        private System.Windows.Forms.Label cv_lblMsg2;        
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.Label lblMessage3;
        private System.Windows.Forms.Label lblMessage4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtThongTinThueBao;
        private System.Windows.Forms.ComboBox cboDiaDanh;
        private System.Windows.Forms.CheckBox chkDiaDanh;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMessage5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Base.Inputs.InputText editKm;
        private System.Windows.Forms.CheckBox cbkHaiChieu;
        private Base.Inputs.InputText editTGSuDungXe;
        private Base.Inputs.InputText editTongTien;
        private Base.Inputs.InputText editTienChieuVe;
        private Base.Inputs.InputText editTienChieuDi;
        private Base.Common.ctrl_LoaiXe_Combobox cbLoaiXe;
        private Base.Controls.ShButton btnThoai;
        private Base.Controls.ShButton btnTinhTien;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
