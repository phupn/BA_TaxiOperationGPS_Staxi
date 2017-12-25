namespace Taxi.GUI
{
    partial class frmThongTinNhatKyThueBao
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinNhatKyThueBao));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            this.cmdAdd = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdThemMoi = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdXoa = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdThoat = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdXeChuaNhapDuDuLieu = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdXeNhapDu = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdTimKiem = new Janus.Windows.UI.CommandBars.UICommand();
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdThemMoi1 = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdXoa1 = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdThoat1 = new Janus.Windows.UI.CommandBars.UICommand();
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdXeChuaNhapDuDuLieu1 = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdXeNhapDu1 = new Janus.Windows.UI.CommandBars.UICommand();
            this.cmdTimKiem1 = new Janus.Windows.UI.CommandBars.UICommand();
            this.grdNhanVien = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAdd
            // 
            this.cmdAdd.CommandManager = this.uiCommandManager1;
            this.cmdAdd.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdThemMoi1,
            this.cmdXoa1,
            this.cmdThoat1,
            this.Separator1,
            this.cmdXeChuaNhapDuDuLieu1,
            this.cmdXeNhapDu1,
            this.cmdTimKiem1});
            this.cmdAdd.Key = "cmdToolBar";
            this.cmdAdd.Location = new System.Drawing.Point(0, 0);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.RowIndex = 0;
            this.cmdAdd.Size = new System.Drawing.Size(491, 28);
            this.cmdAdd.Text = "cmdToolBar";
            this.cmdAdd.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.cmdAdd_CommandClick);
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.cmdAdd});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdThemMoi,
            this.cmdXoa,
            this.cmdThoat,
            this.cmdXeChuaNhapDuDuLieu,
            this.cmdXeNhapDu,
            this.cmdTimKiem});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.Id = new System.Guid("c150f580-389a-47ce-85a6-f5f387cdee9a");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 0);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // cmdThemMoi
            // 
            this.cmdThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("cmdThemMoi.Image")));
            this.cmdThemMoi.Key = "cmdThemMoi";
            this.cmdThemMoi.Name = "cmdThemMoi";
            this.cmdThemMoi.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.cmdThemMoi.Text = "Nhập mới (F1)";
            // 
            // cmdXoa
            // 
            this.cmdXoa.Key = "cmdXoa";
            this.cmdXoa.Name = "cmdXoa";
            this.cmdXoa.Text = "Xóa";
            // 
            // cmdThoat
            // 
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Key = "cmdThoat";
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Text = "Thoát";
            // 
            // cmdXeChuaNhapDuDuLieu
            // 
            this.cmdXeChuaNhapDuDuLieu.Key = "cmdXeChuaNhapDuDuLieu";
            this.cmdXeChuaNhapDuDuLieu.Name = "cmdXeChuaNhapDuDuLieu";
            this.cmdXeChuaNhapDuDuLieu.Text = "Xe chưa nhập đủ thông tin";
            // 
            // cmdXeNhapDu
            // 
            this.cmdXeNhapDu.Key = "cmdXeNhapDu";
            this.cmdXeNhapDu.Name = "cmdXeNhapDu";
            this.cmdXeNhapDu.Text = "Tất cả xe";
            // 
            // cmdTimKiem
            // 
            this.cmdTimKiem.Key = "cmdTimKiem";
            this.cmdTimKiem.Name = "cmdTimKiem";
            this.cmdTimKiem.Text = "Tìm kiếm";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(0, 0);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.cmdAdd});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.cmdAdd);
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(916, 28);
            // 
            // cmdThemMoi1
            // 
            this.cmdThemMoi1.Key = "cmdThemMoi";
            this.cmdThemMoi1.Name = "cmdThemMoi1";
            // 
            // cmdXoa1
            // 
            this.cmdXoa1.Image = ((System.Drawing.Image)(resources.GetObject("cmdXoa1.Image")));
            this.cmdXoa1.Key = "cmdXoa";
            this.cmdXoa1.Name = "cmdXoa1";
            // 
            // cmdThoat1
            // 
            this.cmdThoat1.Key = "cmdThoat";
            this.cmdThoat1.Name = "cmdThoat1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.Name = "Separator1";
            // 
            // cmdXeChuaNhapDuDuLieu1
            // 
            this.cmdXeChuaNhapDuDuLieu1.Key = "cmdXeChuaNhapDuDuLieu";
            this.cmdXeChuaNhapDuDuLieu1.Name = "cmdXeChuaNhapDuDuLieu1";
            // 
            // cmdXeNhapDu1
            // 
            this.cmdXeNhapDu1.Key = "cmdXeNhapDu";
            this.cmdXeNhapDu1.Name = "cmdXeNhapDu1";
            // 
            // cmdTimKiem1
            // 
            this.cmdTimKiem1.Key = "cmdTimKiem";
            this.cmdTimKiem1.Name = "cmdTimKiem1";
            // 
            // grdNhanVien
            // 
            this.grdNhanVien.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdNhanVien.DataMember = "ThoiDiem";
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdNhanVien.DesignTimeLayout = gridEXLayout1;
            this.grdNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdNhanVien.GroupByBoxVisible = false;
            this.grdNhanVien.Location = new System.Drawing.Point(0, 28);
            this.grdNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.grdNhanVien.Name = "grdNhanVien";
            this.grdNhanVien.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdNhanVien.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdNhanVien.SaveSettings = false;
            this.grdNhanVien.Size = new System.Drawing.Size(916, 480);
            this.grdNhanVien.TabIndex = 1;
            this.grdNhanVien.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdNhanVien_FormattingRow);
            this.grdNhanVien.DoubleClick += new System.EventHandler(this.grdNhanVien_DoubleClick);
            this.grdNhanVien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdNhanVien_KeyDown);
            // 
            // frmThongTinNhatKyThueBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 508);
            this.Controls.Add(this.grdNhanVien);
            this.Controls.Add(this.TopRebar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThongTinNhatKyThueBao";
            this.Text = "Thông tin chi tiết nhật ký thuê bao";
            this.Load += new System.EventHandler(this.frmThongTinNhatKyThueBao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.CommandBars.UICommandBar cmdAdd;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdThemMoi;
        private Janus.Windows.UI.CommandBars.UICommand cmdXoa;
        private Janus.Windows.GridEX.GridEX grdNhanVien;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdThemMoi1;
        private Janus.Windows.UI.CommandBars.UICommand cmdXoa1;
        private Janus.Windows.UI.CommandBars.UICommand cmdThoat;
        private Janus.Windows.UI.CommandBars.UICommand cmdThoat1;
        private Janus.Windows.UI.CommandBars.UICommand cmdXeChuaNhapDuDuLieu;
        private Janus.Windows.UI.CommandBars.UICommand cmdXeNhapDu;
        private Janus.Windows.UI.CommandBars.UICommand cmdTimKiem;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdXeChuaNhapDuDuLieu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdXeNhapDu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTimKiem1;
    }
}