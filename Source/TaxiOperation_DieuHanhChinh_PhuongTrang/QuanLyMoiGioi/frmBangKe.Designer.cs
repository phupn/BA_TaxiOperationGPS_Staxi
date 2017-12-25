namespace Taxi.GUI
{
    partial class frmBangKe
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangKe));
            this.grdDoiTac = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdAdd = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdDelete1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdExcel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExcel");
            this.cmdExit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExit");
            this.cmdHelp1 = new Janus.Windows.UI.CommandBars.UICommand("cmdHelp");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdExit = new Janus.Windows.UI.CommandBars.UICommand("cmdExit");
            this.cmdHelp = new Janus.Windows.UI.CommandBars.UICommand("cmdHelp");
            this.cmdCapNhatMoiGioi = new Janus.Windows.UI.CommandBars.UICommand("cmdCapNhatMoiGioi");
            this.cmdKiemTraTrung = new Janus.Windows.UI.CommandBars.UICommand("cmdKiemTraTrung");
            this.cmdExcel = new Janus.Windows.UI.CommandBars.UICommand("cmdExcel");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoiTac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDoiTac
            // 
            this.grdDoiTac.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdDoiTac.DesignTimeLayout = gridEXLayout1;
            this.grdDoiTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDoiTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdDoiTac.GroupByBoxVisible = false;
            this.grdDoiTac.Location = new System.Drawing.Point(0, 28);
            this.grdDoiTac.Margin = new System.Windows.Forms.Padding(2);
            this.grdDoiTac.Name = "grdDoiTac";
            this.grdDoiTac.SaveSettings = false;
            this.grdDoiTac.SettingsKey = "grdDoiTac";
            this.grdDoiTac.Size = new System.Drawing.Size(784, 434);
            this.grdDoiTac.TabIndex = 0;
            this.grdDoiTac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.grdDoiTac.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdDoiTac_FormattingRow);
            this.grdDoiTac.DoubleClick += new System.EventHandler(this.grdDoiTac_DoubleClick);
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.cmdAdd});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNew,
            this.cmdEdit,
            this.cmdDelete,
            this.cmdExit,
            this.cmdHelp,
            this.cmdCapNhatMoiGioi,
            this.cmdKiemTraTrung,
            this.cmdExcel});
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
            this.BottomRebar1.Location = new System.Drawing.Point(0, 586);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(807, 0);
            // 
            // cmdAdd
            // 
            this.cmdAdd.CommandManager = this.uiCommandManager1;
            this.cmdAdd.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNew1,
            this.cmdEdit1,
            this.cmdDelete1,
            this.cmdExcel1,
            this.cmdExit1,
            this.cmdHelp1,
            this.Separator1});
            this.cmdAdd.Key = "cmdToolBar";
            this.cmdAdd.Location = new System.Drawing.Point(0, 0);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.RowIndex = 0;
            this.cmdAdd.Size = new System.Drawing.Size(456, 28);
            this.cmdAdd.Text = "cmdToolBar";
            this.cmdAdd.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.cmdAdd_CommandClick);
            // 
            // cmdNew1
            // 
            this.cmdNew1.Key = "cmdNew";
            this.cmdNew1.Name = "cmdNew1";
            // 
            // cmdEdit1
            // 
            this.cmdEdit1.Key = "cmdEdit";
            this.cmdEdit1.Name = "cmdEdit1";
            // 
            // cmdDelete1
            // 
            this.cmdDelete1.Key = "cmdDelete";
            this.cmdDelete1.Name = "cmdDelete1";
            // 
            // cmdExcel1
            // 
            this.cmdExcel1.Key = "cmdExcel";
            this.cmdExcel1.Name = "cmdExcel1";
            // 
            // cmdExit1
            // 
            this.cmdExit1.Key = "cmdExit";
            this.cmdExit1.Name = "cmdExit1";
            // 
            // cmdHelp1
            // 
            this.cmdHelp1.Key = "cmdHelp";
            this.cmdHelp1.Name = "cmdHelp1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.Name = "Separator1";
            // 
            // cmdNew
            // 
            this.cmdNew.Image = ((System.Drawing.Image)(resources.GetObject("cmdNew.Image")));
            this.cmdNew.Key = "cmdNew";
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Shortcut = System.Windows.Forms.Shortcut.AltF12;
            this.cmdNew.Text = "&Thêm mới";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.Key = "cmdEdit";
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Text = "&Sửa đổi";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.Key = "cmdDelete";
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Text = "&Xóa";
            // 
            // cmdExit
            // 
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.Key = "cmdExit";
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Text = "&Thoát";
            // 
            // cmdHelp
            // 
            this.cmdHelp.Image = ((System.Drawing.Image)(resources.GetObject("cmdHelp.Image")));
            this.cmdHelp.Key = "cmdHelp";
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Text = "Tìm &kiếm";
            // 
            // cmdCapNhatMoiGioi
            // 
            this.cmdCapNhatMoiGioi.Key = "cmdCapNhatMoiGioi";
            this.cmdCapNhatMoiGioi.Name = "cmdCapNhatMoiGioi";
            this.cmdCapNhatMoiGioi.Text = "Cập nhật cuộc gọi môi giới";
            // 
            // cmdKiemTraTrung
            // 
            this.cmdKiemTraTrung.Key = "cmdKiemTraTrung";
            this.cmdKiemTraTrung.Name = "cmdKiemTraTrung";
            this.cmdKiemTraTrung.Text = "Kiểm tra trùng số";
            // 
            // cmdExcel
            // 
            this.cmdExcel.Image = ((System.Drawing.Image)(resources.GetObject("cmdExcel.Image")));
            this.cmdExcel.Key = "cmdExcel";
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Text = "Xuất Excel";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 586);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(807, 0);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 586);
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.cmdAdd});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.cmdAdd);
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Margin = new System.Windows.Forms.Padding(2);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(784, 28);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdDoiTac;
            // 
            // frmBangKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.grdDoiTac);
            this.Controls.Add(this.TopRebar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBangKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách bảng kê";
            ((System.ComponentModel.ISupportInitialize)(this.grdDoiTac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdDoiTac;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.CommandBars.UICommand cmdExit;
        private Janus.Windows.UI.CommandBars.UICommand cmdHelp;
        private Janus.Windows.UI.CommandBars.UICommand cmdCapNhatMoiGioi;
        private Janus.Windows.UI.CommandBars.UICommand cmdKiemTraTrung;
        private Janus.Windows.UI.CommandBars.UICommand cmdExcel;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.UI.CommandBars.UICommandBar cmdAdd;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExcel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdHelp1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
    }
}