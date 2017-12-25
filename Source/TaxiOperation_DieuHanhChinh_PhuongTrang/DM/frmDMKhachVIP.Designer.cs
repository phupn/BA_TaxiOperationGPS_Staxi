namespace Taxi.GUI
{
    partial class frmDMKhachVIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMKhachVIP));
            this.grdKhachVIP = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdAdd = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdDelete1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdExit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExit");
            this.cmdHelp1 = new Janus.Windows.UI.CommandBars.UICommand("cmdHelp");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdExit = new Janus.Windows.UI.CommandBars.UICommand("cmdExit");
            this.cmdHelp = new Janus.Windows.UI.CommandBars.UICommand("cmdHelp");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            ((System.ComponentModel.ISupportInitialize)(this.grdKhachVIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdKhachVIP
            // 
            this.grdKhachVIP.AllowColumnDrag = false;
            this.grdKhachVIP.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdKhachVIP.AutomaticSort = false;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdKhachVIP.DesignTimeLayout = gridEXLayout1;
            this.grdKhachVIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKhachVIP.GroupByBoxVisible = false;
            this.grdKhachVIP.Location = new System.Drawing.Point(0, 28);
            this.grdKhachVIP.Name = "grdKhachVIP";
            this.grdKhachVIP.SaveSettings = false;
            this.grdKhachVIP.Size = new System.Drawing.Size(869, 461);
            this.grdKhachVIP.TabIndex = 0;
            this.grdKhachVIP.DoubleClick += new System.EventHandler(this.grdKhachVIP_DoubleClick);
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
            this.cmdHelp});
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
            this.cmdExit1,
            this.cmdHelp1});
            this.cmdAdd.Key = "cmdToolBar";
            this.cmdAdd.Location = new System.Drawing.Point(0, 0);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.RowIndex = 0;
            this.cmdAdd.Size = new System.Drawing.Size(423, 28);
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
            this.cmdHelp.Text = "Trợ &giúp";
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
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(869, 28);
            // 
            // frmDMKhachVIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 489);
            this.Controls.Add(this.grdKhachVIP);
            this.Controls.Add(this.TopRebar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMKhachVIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục khách VIP";
            this.Load += new System.EventHandler(this.frmDMKhachVIP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdKhachVIP)).EndInit();
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

        private Janus.Windows.GridEX.GridEX grdKhachVIP;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar cmdAdd;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdHelp1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExit;
        private Janus.Windows.UI.CommandBars.UICommand cmdHelp;
    }
}