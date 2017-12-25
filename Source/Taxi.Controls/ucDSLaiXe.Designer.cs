namespace Taxi.Controls
{
    partial class ucDSLaiXe
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
            this.panelInput1 = new Taxi.Controls.Base.Controls.ShPanel();
            this.lblMsg = new Taxi.Controls.Base.Controls.ShLabel();
            this.btnTimKiem = new Taxi.Controls.Base.Controls.ShButton();
            this.txtDiDong = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtTheLaiXe = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoHieuXe = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.panelInput2 = new Taxi.Controls.Base.Controls.ShPanel();
            this.grcDanhSachLaiXe = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvDanhSachLaiXe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoHieuXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTheLaiXe = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput1)).BeginInit();
            this.panelInput1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiDong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTheLaiXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieuXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput2)).BeginInit();
            this.panelInput2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSachLaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachLaiXe)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInput1
            // 
            this.panelInput1.Controls.Add(this.lblMsg);
            this.panelInput1.Controls.Add(this.btnTimKiem);
            this.panelInput1.Controls.Add(this.txtDiDong);
            this.panelInput1.Controls.Add(this.shLabel3);
            this.panelInput1.Controls.Add(this.txtTheLaiXe);
            this.panelInput1.Controls.Add(this.shLabel2);
            this.panelInput1.Controls.Add(this.txtSoHieuXe);
            this.panelInput1.Controls.Add(this.shLabel1);
            this.panelInput1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput1.LabelMessage = null;
            this.panelInput1.Location = new System.Drawing.Point(0, 0);
            this.panelInput1.Name = "panelInput1";
            this.panelInput1.Size = new System.Drawing.Size(624, 51);
            this.panelInput1.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(69, 32);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(29, 13);
            this.lblMsg.TabIndex = 4;
            this.lblMsg.Text = "lblMsg";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(408, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(86, 23);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm (Enter)";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtDiDong
            // 
            this.txtDiDong.IsChangeText = false;
            this.txtDiDong.IsFocus = false;
            this.txtDiDong.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.txtDiDong.Location = new System.Drawing.Point(317, 10);
            this.txtDiDong.Name = "txtDiDong";
            this.txtDiDong.Properties.MaxLength = 20;
            this.txtDiDong.Size = new System.Drawing.Size(86, 20);
            this.txtDiDong.TabIndex = 2;
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(253, 13);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(58, 13);
            this.shLabel3.TabIndex = 0;
            this.shLabel3.Text = "[S]ố di động";
            // 
            // txtTheLaiXe
            // 
            this.txtTheLaiXe.IsChangeText = false;
            this.txtTheLaiXe.IsFocus = false;
            this.txtTheLaiXe.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.txtTheLaiXe.Location = new System.Drawing.Point(188, 9);
            this.txtTheLaiXe.Name = "txtTheLaiXe";
            this.txtTheLaiXe.Properties.MaxLength = 255;
            this.txtTheLaiXe.Size = new System.Drawing.Size(59, 20);
            this.txtTheLaiXe.TabIndex = 1;
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(130, 13);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(54, 13);
            this.shLabel2.TabIndex = 0;
            this.shLabel2.Text = "[T]hẻ lái xe";
            // 
            // txtSoHieuXe
            // 
            this.txtSoHieuXe.IsChangeText = false;
            this.txtSoHieuXe.IsFocus = false;
            this.txtSoHieuXe.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.txtSoHieuXe.Location = new System.Drawing.Point(68, 9);
            this.txtSoHieuXe.Name = "txtSoHieuXe";
            this.txtSoHieuXe.Properties.MaxLength = 255;
            this.txtSoHieuXe.Size = new System.Drawing.Size(56, 20);
            this.txtSoHieuXe.TabIndex = 0;
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(6, 13);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(58, 13);
            this.shLabel1.TabIndex = 0;
            this.shLabel1.Text = "Số hiệu [x]e";
            // 
            // panelInput2
            // 
            this.panelInput2.Controls.Add(this.grcDanhSachLaiXe);
            this.panelInput2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput2.LabelMessage = null;
            this.panelInput2.Location = new System.Drawing.Point(0, 51);
            this.panelInput2.Name = "panelInput2";
            this.panelInput2.Size = new System.Drawing.Size(624, 314);
            this.panelInput2.TabIndex = 1;
            // 
            // grcDanhSachLaiXe
            // 
            this.grcDanhSachLaiXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcDanhSachLaiXe.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcDanhSachLaiXe.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcDanhSachLaiXe.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcDanhSachLaiXe.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcDanhSachLaiXe.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcDanhSachLaiXe.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcDanhSachLaiXe.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grcDanhSachLaiXe.Location = new System.Drawing.Point(2, 2);
            this.grcDanhSachLaiXe.MainView = this.grvDanhSachLaiXe;
            this.grcDanhSachLaiXe.Name = "grcDanhSachLaiXe";
            this.grcDanhSachLaiXe.Size = new System.Drawing.Size(620, 310);
            this.grcDanhSachLaiXe.TabIndex = 6;
            this.grcDanhSachLaiXe.UseEmbeddedNavigator = true;
            this.grcDanhSachLaiXe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSachLaiXe});
            // 
            // grvDanhSachLaiXe
            // 
            this.grvDanhSachLaiXe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvDanhSachLaiXe.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDanhSachLaiXe.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDanhSachLaiXe.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDanhSachLaiXe.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvDanhSachLaiXe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoHieuXe,
            this.colHoTen,
            this.colDienThoai,
            this.colDiDong,
            this.colTheLaiXe});
            this.grvDanhSachLaiXe.GridControl = this.grcDanhSachLaiXe;
            this.grvDanhSachLaiXe.Name = "grvDanhSachLaiXe";
            this.grvDanhSachLaiXe.OptionsBehavior.Editable = false;
            this.grvDanhSachLaiXe.OptionsBehavior.ReadOnly = true;
            this.grvDanhSachLaiXe.OptionsView.ShowGroupPanel = false;
            // 
            // colSoHieuXe
            // 
            this.colSoHieuXe.AppearanceCell.Options.UseTextOptions = true;
            this.colSoHieuXe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoHieuXe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoHieuXe.Caption = "Số hiệu xe";
            this.colSoHieuXe.FieldName = "FK_SoHieuXeLai";
            this.colSoHieuXe.Name = "colSoHieuXe";
            this.colSoHieuXe.Visible = true;
            this.colSoHieuXe.VisibleIndex = 0;
            this.colSoHieuXe.Width = 91;
            // 
            // colHoTen
            // 
            this.colHoTen.Caption = "Họ tên";
            this.colHoTen.FieldName = "TenNhanVien";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.Visible = true;
            this.colHoTen.VisibleIndex = 1;
            this.colHoTen.Width = 127;
            // 
            // colDienThoai
            // 
            this.colDienThoai.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDienThoai.AppearanceCell.Options.UseFont = true;
            this.colDienThoai.AppearanceCell.Options.UseTextOptions = true;
            this.colDienThoai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDienThoai.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDienThoai.Caption = "Điện thoại";
            this.colDienThoai.FieldName = "DienThoai";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.Visible = true;
            this.colDienThoai.VisibleIndex = 4;
            this.colDienThoai.Width = 137;
            // 
            // colDiDong
            // 
            this.colDiDong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDiDong.AppearanceCell.Options.UseFont = true;
            this.colDiDong.AppearanceCell.Options.UseTextOptions = true;
            this.colDiDong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiDong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDiDong.Caption = "Di động";
            this.colDiDong.FieldName = "DiDong";
            this.colDiDong.Name = "colDiDong";
            this.colDiDong.Visible = true;
            this.colDiDong.VisibleIndex = 2;
            this.colDiDong.Width = 134;
            // 
            // colTheLaiXe
            // 
            this.colTheLaiXe.AppearanceCell.Options.UseTextOptions = true;
            this.colTheLaiXe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTheLaiXe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTheLaiXe.Caption = "Thẻ lái xe";
            this.colTheLaiXe.FieldName = "SoTheLaiXe";
            this.colTheLaiXe.Name = "colTheLaiXe";
            this.colTheLaiXe.Visible = true;
            this.colTheLaiXe.VisibleIndex = 3;
            this.colTheLaiXe.Width = 113;
            // 
            // ucDSLaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInput2);
            this.Controls.Add(this.panelInput1);
            this.Name = "ucDSLaiXe";
            this.Size = new System.Drawing.Size(624, 365);
            this.Load += new System.EventHandler(this.ucDSLaiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelInput1)).EndInit();
            this.panelInput1.ResumeLayout(false);
            this.panelInput1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiDong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTheLaiXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieuXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput2)).EndInit();
            this.panelInput2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSachLaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachLaiXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShPanel panelInput1;
        private Base.Controls.ShPanel panelInput2;
        private Base.Controls.ShGridControl grcDanhSachLaiXe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSachLaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHieuXe;
        private DevExpress.XtraGrid.Columns.GridColumn colHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colDiDong;
        private DevExpress.XtraGrid.Columns.GridColumn colTheLaiXe;
        private Base.Controls.ShButton btnTimKiem;
        private Base.Inputs.InputText txtSoHieuXe;
        private Base.Controls.ShLabel shLabel1;
        private Base.Controls.ShLabel lblMsg;
        private Base.Inputs.InputText txtDiDong;
        private Base.Controls.ShLabel shLabel3;
        private Base.Inputs.InputText txtTheLaiXe;
        private Base.Controls.ShLabel shLabel2;
    }
}
