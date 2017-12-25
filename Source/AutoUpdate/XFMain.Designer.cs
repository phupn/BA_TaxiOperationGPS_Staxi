namespace AutoUpdate
{
    partial class XFMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFMain));
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grcResult = new DevExpress.XtraGrid.GridControl();
            this.grvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcResultFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcResultState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rptItmLookUpEditState = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lbcMessage = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRun = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.prgBarCtr = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptItmLookUpEditState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarCtr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.panelControl1);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Padding = new System.Windows.Forms.Padding(4);
            this.panelControl5.Size = new System.Drawing.Size(596, 270);
            this.panelControl5.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grcResult);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(4);
            this.panelControl1.Size = new System.Drawing.Size(588, 262);
            this.panelControl1.TabIndex = 1;
            // 
            // grcResult
            // 
            this.grcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcResult.Location = new System.Drawing.Point(6, 58);
            this.grcResult.MainView = this.grvResult;
            this.grcResult.Name = "grcResult";
            this.grcResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rptItmLookUpEditState});
            this.grcResult.Size = new System.Drawing.Size(576, 164);
            this.grcResult.TabIndex = 3;
            this.grcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvResult});
            // 
            // grvResult
            // 
            this.grvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcResultFile,
            this.grcResultState});
            this.grvResult.GridControl = this.grcResult;
            this.grvResult.IndicatorWidth = 30;
            this.grvResult.Name = "grvResult";
            this.grvResult.OptionsMenu.EnableColumnMenu = false;
            this.grvResult.OptionsMenu.EnableFooterMenu = false;
            this.grvResult.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvResult.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.grvResult.OptionsMenu.ShowAutoFilterRowItem = false;
            this.grvResult.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.grvResult.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.grvResult.OptionsView.ShowColumnHeaders = false;
            this.grvResult.OptionsView.ShowGroupPanel = false;
            this.grvResult.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvResult_CustomDrawRowIndicator);
            // 
            // grcResultFile
            // 
            this.grcResultFile.Caption = "Tên file";
            this.grcResultFile.FieldName = "Name";
            this.grcResultFile.Name = "grcResultFile";
            this.grcResultFile.OptionsColumn.AllowEdit = false;
            this.grcResultFile.OptionsColumn.AllowFocus = false;
            this.grcResultFile.Visible = true;
            this.grcResultFile.VisibleIndex = 0;
            this.grcResultFile.Width = 261;
            // 
            // grcResultState
            // 
            this.grcResultState.Caption = "Trạng thái";
            this.grcResultState.ColumnEdit = this.rptItmLookUpEditState;
            this.grcResultState.FieldName = "State";
            this.grcResultState.Name = "grcResultState";
            this.grcResultState.OptionsColumn.AllowEdit = false;
            this.grcResultState.OptionsColumn.AllowFocus = false;
            this.grcResultState.OptionsColumn.FixedWidth = true;
            this.grcResultState.Visible = true;
            this.grcResultState.VisibleIndex = 1;
            this.grcResultState.Width = 80;
            // 
            // rptItmLookUpEditState
            // 
            this.rptItmLookUpEditState.AutoHeight = false;
            this.rptItmLookUpEditState.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rptItmLookUpEditState.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rptItmLookUpEditState.DisplayMember = "Name";
            this.rptItmLookUpEditState.DropDownItemHeight = 22;
            this.rptItmLookUpEditState.Name = "rptItmLookUpEditState";
            this.rptItmLookUpEditState.NullText = "...";
            this.rptItmLookUpEditState.ShowFooter = false;
            this.rptItmLookUpEditState.ShowHeader = false;
            this.rptItmLookUpEditState.ValueMember = "ID";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.lbcMessage);
            this.panelControl3.Controls.Add(this.panelControl4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(6, 222);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(576, 34);
            this.panelControl3.TabIndex = 2;
            // 
            // lbcMessage
            // 
            this.lbcMessage.Location = new System.Drawing.Point(7, 12);
            this.lbcMessage.Name = "lbcMessage";
            this.lbcMessage.Size = new System.Drawing.Size(163, 13);
            this.lbcMessage.TabIndex = 1;
            this.lbcMessage.Text = "Lấy danh sách file cần cập nhật...";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.btnCancel);
            this.panelControl4.Controls.Add(this.btnRun);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(445, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(131, 34);
            this.panelControl4.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(69, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRun
            // 
            this.btnRun.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Appearance.Options.UseFont = true;
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(3, 7);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(60, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Có";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.prgBarCtr);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(6, 6);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(576, 52);
            this.panelControl2.TabIndex = 0;
            // 
            // prgBarCtr
            // 
            this.prgBarCtr.Location = new System.Drawing.Point(1, 3);
            this.prgBarCtr.Name = "prgBarCtr";
            this.prgBarCtr.Size = new System.Drawing.Size(574, 18);
            this.prgBarCtr.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(145, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Kết quả tải các file cập nhật...";
            // 
            // XFMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 270);
            this.Controls.Add(this.panelControl5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = AutoUpdate.Properties.Resources.Staxi_96_ic_launcher;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XFMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật phần mềm...";
            this.Shown += new System.EventHandler(this.XFMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptItmLookUpEditState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarCtr.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grcResult;
        private DevExpress.XtraGrid.Views.Grid.GridView grvResult;
        private DevExpress.XtraGrid.Columns.GridColumn grcResultFile;
        private DevExpress.XtraGrid.Columns.GridColumn grcResultState;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rptItmLookUpEditState;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl lbcMessage;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnRun;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ProgressBarControl prgBarCtr;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}