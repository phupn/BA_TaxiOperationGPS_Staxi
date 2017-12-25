namespace Taxi.Controls.KhieuNai_PhanAnh
{
    partial class ctrlDSKhieuNai
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlDSKhieuNai));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.grdGiaiQuyetPA = new Janus.Windows.GridEX.GridEX();
            this.tabControl_DSKhieuNai = new System.Windows.Forms.TabControl();
            this.tabPage_ChoGiaiQuyet = new System.Windows.Forms.TabPage();
            this.tabPage_DaGiaiQuyet = new System.Windows.Forms.TabPage();
            this.grdDaGiaiQuyetPA = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaiQuyetPA)).BeginInit();
            this.tabControl_DSKhieuNai.SuspendLayout();
            this.tabPage_ChoGiaiQuyet.SuspendLayout();
            this.tabPage_DaGiaiQuyet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDaGiaiQuyetPA)).BeginInit();
            this.SuspendLayout();
            // 
            // grdGiaiQuyetPA
            // 
            this.grdGiaiQuyetPA.AllowDrop = true;
            this.grdGiaiQuyetPA.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdGiaiQuyetPA.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdGiaiQuyetPA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGiaiQuyetPA.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.grdGiaiQuyetPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdGiaiQuyetPA.GroupByBoxVisible = false;
            gridEXLayout1.IsCurrentLayout = true;
            gridEXLayout1.Key = "1";
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdGiaiQuyetPA.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout1});
            this.grdGiaiQuyetPA.Location = new System.Drawing.Point(3, 3);
            this.grdGiaiQuyetPA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdGiaiQuyetPA.Name = "grdGiaiQuyetPA";
            this.grdGiaiQuyetPA.SaveSettings = false;
            this.grdGiaiQuyetPA.Size = new System.Drawing.Size(786, 468);
            this.grdGiaiQuyetPA.TabIndex = 1;
            this.grdGiaiQuyetPA.DoubleClick += new System.EventHandler(this.grdGiaiQuyetPA_DoubleClick);
            this.grdGiaiQuyetPA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdGiaiQuyetPA_KeyDown);
            // 
            // tabControl_DSKhieuNai
            // 
            this.tabControl_DSKhieuNai.Controls.Add(this.tabPage_ChoGiaiQuyet);
            this.tabControl_DSKhieuNai.Controls.Add(this.tabPage_DaGiaiQuyet);
            this.tabControl_DSKhieuNai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_DSKhieuNai.Location = new System.Drawing.Point(0, 0);
            this.tabControl_DSKhieuNai.Name = "tabControl_DSKhieuNai";
            this.tabControl_DSKhieuNai.SelectedIndex = 0;
            this.tabControl_DSKhieuNai.Size = new System.Drawing.Size(800, 500);
            this.tabControl_DSKhieuNai.TabIndex = 2;
            this.tabControl_DSKhieuNai.SelectedIndexChanged += new System.EventHandler(this.tabControl_DSKhieuNai_SelectedIndexChanged);
            // 
            // tabPage_ChoGiaiQuyet
            // 
            this.tabPage_ChoGiaiQuyet.Controls.Add(this.grdGiaiQuyetPA);
            this.tabPage_ChoGiaiQuyet.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ChoGiaiQuyet.Name = "tabPage_ChoGiaiQuyet";
            this.tabPage_ChoGiaiQuyet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ChoGiaiQuyet.Size = new System.Drawing.Size(792, 474);
            this.tabPage_ChoGiaiQuyet.TabIndex = 0;
            this.tabPage_ChoGiaiQuyet.Text = "Chờ giải quyết";
            this.tabPage_ChoGiaiQuyet.UseVisualStyleBackColor = true;
            // 
            // tabPage_DaGiaiQuyet
            // 
            this.tabPage_DaGiaiQuyet.Controls.Add(this.grdDaGiaiQuyetPA);
            this.tabPage_DaGiaiQuyet.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DaGiaiQuyet.Name = "tabPage_DaGiaiQuyet";
            this.tabPage_DaGiaiQuyet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DaGiaiQuyet.Size = new System.Drawing.Size(792, 474);
            this.tabPage_DaGiaiQuyet.TabIndex = 1;
            this.tabPage_DaGiaiQuyet.Text = "Đã giải quyết";
            this.tabPage_DaGiaiQuyet.UseVisualStyleBackColor = true;
            // 
            // grdDaGiaiQuyetPA
            // 
            this.grdDaGiaiQuyetPA.AllowDrop = true;
            this.grdDaGiaiQuyetPA.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdDaGiaiQuyetPA.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdDaGiaiQuyetPA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDaGiaiQuyetPA.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.grdDaGiaiQuyetPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdDaGiaiQuyetPA.GroupByBoxVisible = false;
            gridEXLayout2.IsCurrentLayout = true;
            gridEXLayout2.Key = "1";
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.grdDaGiaiQuyetPA.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout2});
            this.grdDaGiaiQuyetPA.Location = new System.Drawing.Point(3, 3);
            this.grdDaGiaiQuyetPA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdDaGiaiQuyetPA.Name = "grdDaGiaiQuyetPA";
            this.grdDaGiaiQuyetPA.SaveSettings = false;
            this.grdDaGiaiQuyetPA.Size = new System.Drawing.Size(786, 468);
            this.grdDaGiaiQuyetPA.TabIndex = 2;
            this.grdDaGiaiQuyetPA.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdGiaiQuyetPA_FormattingRow);
            this.grdDaGiaiQuyetPA.DoubleClick += new System.EventHandler(this.grdDaGiaiQuyetPA_DoubleClick);
            this.grdDaGiaiQuyetPA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDaGiaiQuyetPA_KeyDown);
            // 
            // ctrlDSKhieuNai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl_DSKhieuNai);
            this.Name = "ctrlDSKhieuNai";
            this.Size = new System.Drawing.Size(800, 500);
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaiQuyetPA)).EndInit();
            this.tabControl_DSKhieuNai.ResumeLayout(false);
            this.tabPage_ChoGiaiQuyet.ResumeLayout(false);
            this.tabPage_DaGiaiQuyet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDaGiaiQuyetPA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdGiaiQuyetPA;
        private System.Windows.Forms.TabControl tabControl_DSKhieuNai;
        private System.Windows.Forms.TabPage tabPage_ChoGiaiQuyet;
        private System.Windows.Forms.TabPage tabPage_DaGiaiQuyet;
        private Janus.Windows.GridEX.GridEX grdDaGiaiQuyetPA;
    }
}
