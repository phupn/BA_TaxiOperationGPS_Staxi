namespace TaxiOperation_BanCo.GiamSatXe
{
    partial class frmGiamSatXe_BaoRaKinhDoanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiamSatXe_BaoRaKinhDoanh));
            this.lblb = new System.Windows.Forms.Label();
            this.lVungDieuHanh = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.lookUp_SoHieu = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.lblmsg = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.txtGhiChu = new Taxi.Controls.Base.Inputs.InputText();
            this.deGioDi = new Taxi.Controls.Base.Inputs.InputDate();
            this.lookUp_LaiXe = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.chk2Lai = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.chkTrucDem = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.spin_ChiSoDi = new Taxi.Controls.Base.Inputs.InputSpin();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCa3 = new Taxi.Controls.Base.Inputs.InputCheckbox {Properties = {AllowHtmlString = true}};
            this.label6 = new System.Windows.Forms.Label();
            this.txtNode = new Taxi.Controls.Base.Inputs.InputText();
            ((System.ComponentModel.ISupportInitialize) (this.lVungDieuHanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.lookUp_SoHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.deGioDi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.deGioDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.lookUp_LaiXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.chk2Lai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.chkTrucDem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.spin_ChiSoDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.chkCa3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.txtNode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblb
            // 
            this.lblb.AutoSize = true;
            this.lblb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblb.Location = new System.Drawing.Point(12, 136);
            this.lblb.Name = "lblb";
            this.lblb.Size = new System.Drawing.Size(58, 19);
            this.lblb.TabIndex = 13;
            this.lblb.Text = "&Giờ đi *";
            // 
            // lVungDieuHanh
            // 
            this.lVungDieuHanh.IsChangeText = false;
            this.lVungDieuHanh.IsFocus = false;
            this.lVungDieuHanh.KeyCommand =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.lVungDieuHanh.Location = new System.Drawing.Point(95, 74);
            this.lVungDieuHanh.Name = "lVungDieuHanh";
            this.lVungDieuHanh.Properties.AllowFocused = false;
            this.lVungDieuHanh.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lVungDieuHanh.Properties.Appearance.Options.UseFont = true;
            this.lVungDieuHanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.lVungDieuHanh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenVung", "vùng điều hành"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "", 20, DevExpress.Utils.FormatType.None, "",
                    false, DevExpress.Utils.HorzAlignment.Default)
            });
            this.lVungDieuHanh.Properties.DisplayMember = "NameVungDH";
            this.lVungDieuHanh.Properties.MaxLength = 255;
            this.lVungDieuHanh.Properties.NullText = "Chọn vùng";
            this.lVungDieuHanh.Properties.PopupWidth = 330;
            this.lVungDieuHanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lVungDieuHanh.Properties.ValidateOnEnterKey = true;
            this.lVungDieuHanh.Size = new System.Drawing.Size(165, 25);
            this.lVungDieuHanh.TabIndex = 3;
            this.lVungDieuHanh.ToolTip = "Số xe";
            this.lVungDieuHanh.Closed +=
                new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.lVungDieuHanh_Closed);
            this.lVungDieuHanh.TextChanged += new System.EventHandler(this.lVungDieuHanh_TextChanged);
            this.lVungDieuHanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lVungDieuHanh_KeyDown);
            // 
            // lookUp_SoHieu
            // 
            this.lookUp_SoHieu.IsChangeText = false;
            this.lookUp_SoHieu.IsFocus = false;
            this.lookUp_SoHieu.KeyCommand =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.lookUp_SoHieu.Location = new System.Drawing.Point(95, 12);
            this.lookUp_SoHieu.Name = "lookUp_SoHieu";
            this.lookUp_SoHieu.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lookUp_SoHieu.Properties.Appearance.Options.UseFont = true;
            this.lookUp_SoHieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.lookUp_SoHieu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoHieuXe", "Số hiệu xe"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhanVien", 50, "Tên lái xe")
            });
            this.lookUp_SoHieu.Properties.MaxLength = 10;
            this.lookUp_SoHieu.Properties.NullText = "Chọn xe";
            this.lookUp_SoHieu.Properties.PopupWidth = 50;
            this.lookUp_SoHieu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUp_SoHieu.Properties.ValidateOnEnterKey = true;
            this.lookUp_SoHieu.Size = new System.Drawing.Size(80, 25);
            this.lookUp_SoHieu.TabIndex = 0;
            this.lookUp_SoHieu.ToolTip = "Số xe";
            this.lookUp_SoHieu.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.txtSoHieu_Closed);
            this.lookUp_SoHieu.EditValueChanged += new System.EventHandler(this.lookUp_SoHieu_EditValueChanged);
            this.lookUp_SoHieu.TextChanged += new System.EventHandler(this.lookUp_SoHieu_TextChanged);
            this.lookUp_SoHieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoHieu_KeyDown);
            this.lookUp_SoHieu.Leave += new System.EventHandler(this.lookUp_SoHieu_Leave);
            // 
            // lblmsg
            // 
            this.lblmsg.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblmsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblmsg.Location = new System.Drawing.Point(16, 184);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(332, 0);
            this.lblmsg.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "&Điểm đỗ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(12, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ghi &chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(185, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Ch&ỉ số đi *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Số &xe *";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.Close;
            this.btnThoat.Location = new System.Drawing.Point(182, 214);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(109, 30);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát (Esc)";
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Image = global::Taxi.Controls.Properties.Resources.disk;
            this.btnLuu.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnLuu.Location = new System.Drawing.Point(70, 214);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(103, 30);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu (F2)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.IsChangeText = false;
            this.txtGhiChu.IsFocus = false;
            this.txtGhiChu.KeyCommand =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.txtGhiChu.Location = new System.Drawing.Point(95, 106);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtGhiChu.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu.Properties.MaxLength = 255;
            this.txtGhiChu.Size = new System.Drawing.Size(254, 22);
            this.txtGhiChu.TabIndex = 5;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhiChu_KeyDown);
            // 
            // deGioDi
            // 
            this.deGioDi.DateNowWhenLoad = true;
            this.deGioDi.EditValue = new System.DateTime(2014, 6, 4, 14, 31, 22, 333);
            this.deGioDi.IsChangeText = false;
            this.deGioDi.IsFocus = false;
            this.deGioDi.Location = new System.Drawing.Point(95, 135);
            this.deGioDi.Name = "deGioDi";
            this.deGioDi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.deGioDi.Properties.Appearance.Options.UseFont = true;
            this.deGioDi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.deGioDi.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deGioDi.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deGioDi.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.deGioDi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deGioDi.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.deGioDi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deGioDi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.
                EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            this.deGioDi.Size = new System.Drawing.Size(254, 23);
            this.deGioDi.TabIndex = 6;
            this.deGioDi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deGioDi_KeyDown);
            // 
            // lookUp_LaiXe
            // 
            this.lookUp_LaiXe.IsChangeText = false;
            this.lookUp_LaiXe.IsFocus = false;
            this.lookUp_LaiXe.KeyCommand =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.lookUp_LaiXe.Location = new System.Drawing.Point(95, 43);
            this.lookUp_LaiXe.Name = "lookUp_LaiXe";
            this.lookUp_LaiXe.Properties.AllowFocused = false;
            this.lookUp_LaiXe.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lookUp_LaiXe.Properties.Appearance.Options.UseFont = true;
            this.lookUp_LaiXe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.lookUp_LaiXe.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenVietTat", 150, "Tên nhân viên")
            });
            this.lookUp_LaiXe.Properties.MaxLength = 255;
            this.lookUp_LaiXe.Properties.NullText = "Lái xe";
            this.lookUp_LaiXe.Properties.PopupWidth = 150;
            this.lookUp_LaiXe.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUp_LaiXe.Properties.ValidateOnEnterKey = true;
            this.lookUp_LaiXe.Size = new System.Drawing.Size(254, 25);
            this.lookUp_LaiXe.TabIndex = 2;
            this.lookUp_LaiXe.ToolTip = "Số xe";
            this.lookUp_LaiXe.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.lueLaiXe_Closed);
            this.lookUp_LaiXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lueLaiXe_KeyDown);
            // 
            // chk2Lai
            // 
            this.chk2Lai.IsChangeText = false;
            this.chk2Lai.IsFocus = false;
            this.chk2Lai.KeyCommand = System.Windows.Forms.Keys.None;
            this.chk2Lai.Location = new System.Drawing.Point(179, 164);
            this.chk2Lai.Name = "chk2Lai";
            this.chk2Lai.Properties.AllowHtmlString = true;
            this.chk2Lai.Properties.Caption = "<color=blue><b>&H</b></color>ai lái";
            this.chk2Lai.Size = new System.Drawing.Size(61, 19);
            this.chk2Lai.TabIndex = 8;
            this.chk2Lai.Tag = "IsHaiLai";
            this.chk2Lai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chk2Lai_KeyDown);
            // 
            // chkTrucDem
            // 
            this.chkTrucDem.IsChangeText = false;
            this.chkTrucDem.IsFocus = false;
            this.chkTrucDem.KeyCommand = System.Windows.Forms.Keys.None;
            this.chkTrucDem.Location = new System.Drawing.Point(98, 164);
            this.chkTrucDem.Name = "chkTrucDem";
            this.chkTrucDem.Properties.AllowHtmlString = true;
            this.chkTrucDem.Properties.Caption = "<color=blue><b>&T</b></color>rực đêm";
            this.chkTrucDem.Size = new System.Drawing.Size(75, 19);
            this.chkTrucDem.TabIndex = 7;
            this.chkTrucDem.Tag = "IsTrucDem";
            this.chkTrucDem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkTrucDem_KeyDown);
            // 
            // spin_ChiSoDi
            // 
            this.spin_ChiSoDi.EditValue = new decimal(new int[]
            {
                1,
                0,
                0,
                0
            });
            this.spin_ChiSoDi.KeyCommand =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.spin_ChiSoDi.Location = new System.Drawing.Point(264, 14);
            this.spin_ChiSoDi.Name = "spin_ChiSoDi";
            this.spin_ChiSoDi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F,
                System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.spin_ChiSoDi.Properties.Appearance.Options.UseFont = true;
            this.spin_ChiSoDi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            this.spin_ChiSoDi.Properties.IsFloatValue = false;
            this.spin_ChiSoDi.Properties.Mask.EditMask = "d";
            this.spin_ChiSoDi.Properties.MaxLength = 10;
            this.spin_ChiSoDi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.spin_ChiSoDi.Size = new System.Drawing.Size(85, 22);
            this.spin_ChiSoDi.TabIndex = 1;
            this.spin_ChiSoDi.TextChanged += new System.EventHandler(this.txtChiSoDi_TextChanged);
            this.spin_ChiSoDi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChiSoDi_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "T&ên lái xe *";
            // 
            // chkCa3
            // 
            this.chkCa3.IsChangeText = false;
            this.chkCa3.IsFocus = false;
            this.chkCa3.KeyCommand = System.Windows.Forms.Keys.None;
            this.chkCa3.Location = new System.Drawing.Point(246, 164);
            this.chkCa3.Name = "chkCa3";
            this.chkCa3.Properties.Caption = "Ca <color=blue><b>&3</b></color>";
            this.chkCa3.Size = new System.Drawing.Size(56, 19);
            this.chkCa3.TabIndex = 9;
            this.chkCa3.Tag = "IsCa3";
            this.chkCa3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chk2Lai_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label6.Location = new System.Drawing.Point(266, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "&Số";
            // 
            // txtNode
            // 
            this.txtNode.EnterMoveNextControl = true;
            this.txtNode.IsChangeText = false;
            this.txtNode.IsFocus = false;
            this.txtNode.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.txtNode.Location = new System.Drawing.Point(295, 76);
            this.txtNode.Name = "txtNode";
            this.txtNode.Properties.Mask.EditMask = "d";
            this.txtNode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNode.Properties.Mask.ShowPlaceHolders = false;
            this.txtNode.Properties.MaxLength = 3;
            this.txtNode.Size = new System.Drawing.Size(49, 20);
            this.txtNode.TabIndex = 4;
            // 
            // frmGiamSatXe_BaoRaKinhDoanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(360, 251);
            this.Controls.Add(this.txtNode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.spin_ChiSoDi);
            this.Controls.Add(this.chkCa3);
            this.Controls.Add(this.chk2Lai);
            this.Controls.Add(this.chkTrucDem);
            this.Controls.Add(this.lookUp_LaiXe);
            this.Controls.Add(this.deGioDi);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblb);
            this.Controls.Add(this.lVungDieuHanh);
            this.Controls.Add(this.lookUp_SoHieu);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(356, 252);
            this.Name = "frmGiamSatXe_BaoRaKinhDoanh";
            this.Text = "Báo ra kinh doanh";
            this.Load += new System.EventHandler(this.frmGiamSatXe_BaoRaKinhDoanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lVungDieuHanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_SoHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGioDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_LaiXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk2Lai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTrucDem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_ChiSoDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCa3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblb;
        private Taxi.Controls.Base.Inputs.InputLookUp lVungDieuHanh;
        private Taxi.Controls.Base.Inputs.InputLookUp lookUp_SoHieu;
        private DevExpress.XtraEditors.LabelControl lblmsg;
        private Taxi.Controls.Base.Controls.ShButton btnThoat;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Taxi.Controls.Base.Inputs.InputText txtGhiChu;
        private Taxi.Controls.Base.Inputs.InputDate deGioDi;
        private Taxi.Controls.Base.Inputs.InputLookUp lookUp_LaiXe;
        private Taxi.Controls.Base.Inputs.InputCheckbox chk2Lai;
        private Taxi.Controls.Base.Inputs.InputCheckbox chkTrucDem;
        private Taxi.Controls.Base.Inputs.InputSpin spin_ChiSoDi;
        private System.Windows.Forms.Label label1;
        private Taxi.Controls.Base.Inputs.InputCheckbox chkCa3;
        private System.Windows.Forms.Label label6;
        private Taxi.Controls.Base.Inputs.InputText txtNode;
    }
}