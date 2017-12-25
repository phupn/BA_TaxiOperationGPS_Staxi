namespace Taxi.Controls.DanhSach.DMXE
{
    partial class FrmManagerXe
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
            this.shGridControl1 = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridView1 = new Taxi.Controls.Base.Controls.ShGridView();
            this.colSoHieuXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoKhung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGara = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenlaiXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpGara = new Taxi.Controls.Base.Common.InputLookUps.InputLookUp_Gara();
            this.lookUpLoaiXe = new Taxi.Controls.Base.Common.InputLookUps.InputLookUp_LoaiXe();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtBienSo = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoHieuXe = new Taxi.Controls.Base.Inputs.InputText();
            this.grBTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).BeginInit();
            this.panelInputFind.SuspendLayout();
            this.panelView.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGara.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLoaiXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBienSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieuXe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(323, 4);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(163, 4);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(83, 4);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(403, 4);
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblMessage.Location = new System.Drawing.Point(292, 38);
            this.lblMessage.Size = new System.Drawing.Size(0, 14);
            this.lblMessage.Text = "";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(243, 4);
            // 
            // grBTimKiem
            // 
            this.grBTimKiem.Size = new System.Drawing.Size(569, 100);
            // 
            // panelInputFind
            // 
            this.panelInputFind.Controls.Add(this.lookUpGara);
            this.panelInputFind.Controls.Add(this.lookUpLoaiXe);
            this.panelInputFind.Controls.Add(this.shLabel3);
            this.panelInputFind.Controls.Add(this.shLabel2);
            this.panelInputFind.Controls.Add(this.shLabel4);
            this.panelInputFind.Controls.Add(this.txtBienSo);
            this.panelInputFind.Controls.Add(this.shLabel1);
            this.panelInputFind.Controls.Add(this.txtSoHieuXe);
            this.panelInputFind.Size = new System.Drawing.Size(563, 81);
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.shGridControl1);
            this.panelView.Size = new System.Drawing.Size(569, 283);
            // 
            // panelAction
            // 
            this.panelAction.Size = new System.Drawing.Size(569, 58);
            // 
            // panelButton
            // 
            this.panelButton.Location = new System.Drawing.Point(48, 2);
            // 
            // shGridControl1
            // 
            this.shGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGridControl1.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shGridControl1.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shGridControl1.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shGridControl1.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shGridControl1.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shGridControl1.Location = new System.Drawing.Point(0, 0);
            this.shGridControl1.MainView = this.gridView1;
            this.shGridControl1.Name = "shGridControl1";
            this.shGridControl1.Size = new System.Drawing.Size(569, 283);
            this.shGridControl1.TabIndex = 0;
            this.shGridControl1.UseEmbeddedNavigator = true;
            this.shGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoHieuXe,
            this.colBienSo,
            this.colSoMay,
            this.colSoKhung,
            this.colLoaiXe,
            this.colGara,
            this.colSoCho,
            this.colLastUpdate,
            this.colSoDienThoai,
            this.colTenlaiXe});
            this.gridView1.GridControl = this.shGridControl1;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSoHieuXe
            // 
            this.colSoHieuXe.AppearanceCell.Options.UseTextOptions = true;
            this.colSoHieuXe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoHieuXe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoHieuXe.Caption = "Số hiệu xe";
            this.colSoHieuXe.FieldName = "PK_SoHieuXe";
            this.colSoHieuXe.Name = "colSoHieuXe";
            this.colSoHieuXe.OptionsColumn.AllowEdit = false;
            this.colSoHieuXe.OptionsFilter.AllowAutoFilter = false;
            this.colSoHieuXe.OptionsFilter.AllowFilter = false;
            this.colSoHieuXe.Visible = true;
            this.colSoHieuXe.VisibleIndex = 0;
            // 
            // colBienSo
            // 
            this.colBienSo.AppearanceCell.Options.UseTextOptions = true;
            this.colBienSo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBienSo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBienSo.Caption = "Biển số";
            this.colBienSo.FieldName = "BienKiemSoat";
            this.colBienSo.Name = "colBienSo";
            this.colBienSo.OptionsColumn.AllowEdit = false;
            this.colBienSo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBienSo.OptionsFilter.AllowAutoFilter = false;
            this.colBienSo.OptionsFilter.AllowFilter = false;
            this.colBienSo.Visible = true;
            this.colBienSo.VisibleIndex = 1;
            // 
            // colSoMay
            // 
            this.colSoMay.AppearanceCell.Options.UseTextOptions = true;
            this.colSoMay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoMay.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoMay.Caption = "Số máy";
            this.colSoMay.FieldName = "SoMay";
            this.colSoMay.Name = "colSoMay";
            this.colSoMay.OptionsColumn.AllowEdit = false;
            this.colSoMay.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSoMay.OptionsFilter.AllowAutoFilter = false;
            this.colSoMay.OptionsFilter.AllowFilter = false;
            // 
            // colSoKhung
            // 
            this.colSoKhung.AppearanceCell.Options.UseTextOptions = true;
            this.colSoKhung.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoKhung.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoKhung.Caption = "Số khung";
            this.colSoKhung.FieldName = "SoKhung";
            this.colSoKhung.Name = "colSoKhung";
            this.colSoKhung.OptionsColumn.AllowEdit = false;
            this.colSoKhung.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSoKhung.OptionsFilter.AllowAutoFilter = false;
            this.colSoKhung.OptionsFilter.AllowFilter = false;
            // 
            // colLoaiXe
            // 
            this.colLoaiXe.AppearanceCell.Options.UseTextOptions = true;
            this.colLoaiXe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLoaiXe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLoaiXe.Caption = "Loại xe";
            this.colLoaiXe.FieldName = "FK_LoaiXeID";
            this.colLoaiXe.Name = "colLoaiXe";
            this.colLoaiXe.OptionsColumn.AllowEdit = false;
            this.colLoaiXe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLoaiXe.OptionsFilter.AllowAutoFilter = false;
            this.colLoaiXe.OptionsFilter.AllowFilter = false;
            this.colLoaiXe.Visible = true;
            this.colLoaiXe.VisibleIndex = 2;
            // 
            // colGara
            // 
            this.colGara.AppearanceCell.Options.UseTextOptions = true;
            this.colGara.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGara.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGara.Caption = "Gara";
            this.colGara.FieldName = "FK_GaraID";
            this.colGara.Name = "colGara";
            this.colGara.OptionsColumn.AllowEdit = false;
            this.colGara.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGara.OptionsFilter.AllowAutoFilter = false;
            this.colGara.OptionsFilter.AllowFilter = false;
            this.colGara.Visible = true;
            this.colGara.VisibleIndex = 3;
            // 
            // colSoCho
            // 
            this.colSoCho.AppearanceCell.Options.UseTextOptions = true;
            this.colSoCho.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoCho.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoCho.Caption = "Số chỗ";
            this.colSoCho.FieldName = "SoCho";
            this.colSoCho.Name = "colSoCho";
            this.colSoCho.OptionsColumn.AllowEdit = false;
            this.colSoCho.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSoCho.OptionsFilter.AllowAutoFilter = false;
            this.colSoCho.OptionsFilter.AllowFilter = false;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.AppearanceCell.Options.UseTextOptions = true;
            this.colLastUpdate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastUpdate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLastUpdate.Caption = "Ngày cập nhật";
            this.colLastUpdate.FieldName = "LastUpdate";
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.OptionsColumn.AllowEdit = false;
            this.colLastUpdate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLastUpdate.OptionsFilter.AllowAutoFilter = false;
            this.colLastUpdate.OptionsFilter.AllowFilter = false;
            this.colLastUpdate.Width = 89;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.AppearanceCell.Options.UseTextOptions = true;
            this.colSoDienThoai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoDienThoai.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoDienThoai.Caption = "Số điện thoại";
            this.colSoDienThoai.FieldName = "SoDienThoai";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.OptionsColumn.AllowEdit = false;
            this.colSoDienThoai.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSoDienThoai.OptionsFilter.AllowAutoFilter = false;
            this.colSoDienThoai.OptionsFilter.AllowFilter = false;
            this.colSoDienThoai.Width = 82;
            // 
            // colTenlaiXe
            // 
            this.colTenlaiXe.Caption = "Tên lái xe";
            this.colTenlaiXe.Name = "colTenlaiXe";
            this.colTenlaiXe.OptionsColumn.AllowEdit = false;
            this.colTenlaiXe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTenlaiXe.OptionsFilter.AllowAutoFilter = false;
            this.colTenlaiXe.OptionsFilter.AllowFilter = false;
            // 
            // lookUpGara
            // 
            this.lookUpGara.DefaultSelectFirstRow = false;
            this.lookUpGara.IsChangeText = false;
            this.lookUpGara.IsFocus = false;
            this.lookUpGara.IsShowTextNull = true;
            this.lookUpGara.Location = new System.Drawing.Point(332, 43);
            this.lookUpGara.Name = "lookUpGara";
            this.lookUpGara.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpGara.Properties.NullText = "Chọn Gara";
            this.lookUpGara.Size = new System.Drawing.Size(152, 20);
            this.lookUpGara.TabIndex = 4;
            // 
            // lookUpLoaiXe
            // 
            this.lookUpLoaiXe.DefaultSelectFirstRow = false;
            this.lookUpLoaiXe.IsChangeText = false;
            this.lookUpLoaiXe.IsFocus = false;
            this.lookUpLoaiXe.IsShowTextNull = true;
            this.lookUpLoaiXe.Location = new System.Drawing.Point(134, 43);
            this.lookUpLoaiXe.Name = "lookUpLoaiXe";
            this.lookUpLoaiXe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpLoaiXe.Properties.NullText = "Chọn loại xe";
            this.lookUpLoaiXe.Size = new System.Drawing.Size(152, 20);
            this.lookUpLoaiXe.TabIndex = 3;
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(303, 46);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(23, 13);
            this.shLabel3.TabIndex = 8;
            this.shLabel3.Text = "Gara";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(94, 46);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(34, 13);
            this.shLabel2.TabIndex = 9;
            this.shLabel2.Text = "Loại xe";
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(292, 20);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(34, 13);
            this.shLabel4.TabIndex = 10;
            this.shLabel4.Text = "Biển số";
            // 
            // txtBienSo
            // 
            this.txtBienSo.IsChangeText = false;
            this.txtBienSo.IsFocus = false;
            this.txtBienSo.Location = new System.Drawing.Point(332, 17);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Properties.Mask.EditMask = "[0-9A-Za-z]+";
            this.txtBienSo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtBienSo.Properties.MaxLength = 15;
            this.txtBienSo.Size = new System.Drawing.Size(152, 20);
            this.txtBienSo.TabIndex = 2;
            this.txtBienSo.Tag = "SoHieuXe";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(78, 20);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(50, 13);
            this.shLabel1.TabIndex = 11;
            this.shLabel1.Text = "Số hiệu xe";
            // 
            // txtSoHieuXe
            // 
            this.txtSoHieuXe.IsChangeText = false;
            this.txtSoHieuXe.IsFocus = false;
            this.txtSoHieuXe.Location = new System.Drawing.Point(134, 17);
            this.txtSoHieuXe.Name = "txtSoHieuXe";
            this.txtSoHieuXe.Properties.Mask.EditMask = "[0-9A-Za-z]+";
            this.txtSoHieuXe.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSoHieuXe.Properties.MaxLength = 15;
            this.txtSoHieuXe.Size = new System.Drawing.Size(152, 20);
            this.txtSoHieuXe.TabIndex = 1;
            this.txtSoHieuXe.Tag = "SoHieuXe";
            // 
            // FrmManagerXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 441);
            this.FileExcel = "Danh_Sach_Xe";
            this.Grid = this.shGridControl1;
            this.Name = "FrmManagerXe";
            this.Text = "Danh sách xe";
            this.grBTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).EndInit();
            this.panelInputFind.ResumeLayout(false);
            this.panelInputFind.PerformLayout();
            this.panelView.ResumeLayout(false);
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGara.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLoaiXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBienSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieuXe.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShGridControl shGridControl1;
        private Base.Controls.ShGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colBienSo;
        private DevExpress.XtraGrid.Columns.GridColumn colSoMay;
        private DevExpress.XtraGrid.Columns.GridColumn colSoKhung;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn colGara;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCho;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colTenlaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHieuXe;
        private Base.Common.InputLookUps.InputLookUp_Gara lookUpGara;
        private Base.Common.InputLookUps.InputLookUp_LoaiXe lookUpLoaiXe;
        private Base.Controls.ShLabel shLabel3;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel4;
        private Base.Inputs.InputText txtBienSo;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputText txtSoHieuXe;
    }
}