namespace Taxi.GUI
{
    partial class frmDriversChat
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
            this.shgXe = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridXe = new Taxi.Controls.Base.Controls.ShGridView();
            this.SoHieuXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtChatBox = new System.Windows.Forms.TextBox();
            this.txtChatInput = new System.Windows.Forms.TextBox();
            this.timerLoadChat = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.shgXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // shgXe
            // 
            this.shgXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shgXe.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shgXe.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shgXe.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shgXe.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shgXe.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shgXe.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shgXe.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shgXe.Location = new System.Drawing.Point(0, 0);
            this.shgXe.MainView = this.gridXe;
            this.shgXe.Name = "shgXe";
            this.shgXe.Size = new System.Drawing.Size(81, 321);
            this.shgXe.TabIndex = 1;
            this.shgXe.UseEmbeddedNavigator = true;
            this.shgXe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridXe});
            // 
            // gridXe
            // 
            this.gridXe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SoHieuXe});
            this.gridXe.GridControl = this.shgXe;
            this.gridXe.IndicatorWidth = 35;
            this.gridXe.Name = "gridXe";
            this.gridXe.OptionsFind.AllowFindPanel = false;
            this.gridXe.OptionsNavigation.UseOfficePageNavigation = false;
            this.gridXe.OptionsView.ShowGroupPanel = false;
            this.gridXe.OptionsView.ShowIndicator = false;
            this.gridXe.DoubleClick += new System.EventHandler(this.gridXe_DoubleClick);
            // 
            // SoHieuXe
            // 
            this.SoHieuXe.Caption = "Xe";
            this.SoHieuXe.FieldName = "SoHieuXe";
            this.SoHieuXe.Name = "SoHieuXe";
            this.SoHieuXe.OptionsColumn.AllowEdit = false;
            this.SoHieuXe.Visible = true;
            this.SoHieuXe.VisibleIndex = 0;
            // 
            // txtChatBox
            // 
            this.txtChatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChatBox.Location = new System.Drawing.Point(0, 0);
            this.txtChatBox.Multiline = true;
            this.txtChatBox.Name = "txtChatBox";
            this.txtChatBox.ReadOnly = true;
            this.txtChatBox.Size = new System.Drawing.Size(315, 292);
            this.txtChatBox.TabIndex = 2;
            // 
            // txtChatInput
            // 
            this.txtChatInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChatInput.Location = new System.Drawing.Point(0, 0);
            this.txtChatInput.Name = "txtChatInput";
            this.txtChatInput.Size = new System.Drawing.Size(315, 20);
            this.txtChatInput.TabIndex = 3;
            this.txtChatInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChatInput_KeyDown);
            // 
            // timerLoadChat
            // 
            this.timerLoadChat.Tick += new System.EventHandler(this.timerLoadChat_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.shgXe);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(400, 321);
            this.splitContainer1.SplitterDistance = 81;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtChatBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtChatInput);
            this.splitContainer2.Size = new System.Drawing.Size(315, 321);
            this.splitContainer2.SplitterDistance = 292;
            this.splitContainer2.TabIndex = 0;
            // 
            // frmDriversChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 321);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDriversChat";
            this.Text = "Driver Messenger";
            this.Load += new System.EventHandler(this.frmDriversChat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shgXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridXe)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl shgXe;
        private Taxi.Controls.Base.Controls.ShGridView gridXe;
        private DevExpress.XtraGrid.Columns.GridColumn SoHieuXe;
        private System.Windows.Forms.TextBox txtChatBox;
        private System.Windows.Forms.TextBox txtChatInput;
        private System.Windows.Forms.Timer timerLoadChat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}