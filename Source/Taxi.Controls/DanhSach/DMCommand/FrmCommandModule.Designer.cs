namespace Taxi.Controls.DanhSach.DMCommand
{
    partial class FrmCommandModule
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
            this.lstCommandNotUse = new Taxi.Controls.Base.Controls.ShListBox();
            this.lstBoxUsed = new Taxi.Controls.Base.Controls.ShListBox();
            this.btnUp = new Taxi.Controls.Base.Controls.ShButton();
            this.btnDown = new Taxi.Controls.Base.Controls.ShButton();
            this.btnToRight = new Taxi.Controls.Base.Controls.ShButton();
            this.btnToLeft = new Taxi.Controls.Base.Controls.ShButton();
            this.lookupEdit_EnumCommand_Module1 = new Taxi.Controls.Base.Common.Enums.LookUpEdits.LookupEdit_EnumCommand_Module();
            this.myGroupBox1 = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.myGroupBox2 = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lstCommandNotUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEdit_EnumCommand_Module1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox1)).BeginInit();
            this.myGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox2)).BeginInit();
            this.myGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCommandNotUse
            // 
            this.lstCommandNotUse.DisplayMember = "CommandText";
            this.lstCommandNotUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCommandNotUse.Location = new System.Drawing.Point(2, 22);
            this.lstCommandNotUse.Name = "lstCommandNotUse";
            this.lstCommandNotUse.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCommandNotUse.Size = new System.Drawing.Size(215, 402);
            this.lstCommandNotUse.TabIndex = 0;
            this.lstCommandNotUse.ValueMember = "Id";
            // 
            // lstBoxUsed
            // 
            this.lstBoxUsed.DisplayMember = "CommandText";
            this.lstBoxUsed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxUsed.Location = new System.Drawing.Point(2, 22);
            this.lstBoxUsed.Name = "lstBoxUsed";
            this.lstBoxUsed.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxUsed.Size = new System.Drawing.Size(215, 402);
            this.lstBoxUsed.TabIndex = 0;
            this.lstBoxUsed.ValueMember = "CommandId";
            // 
            // btnUp
            // 
            this.btnUp.Image = global::Taxi.Controls.Properties.Resources._1464077809_arrow_up_01;
            this.btnUp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnUp.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.btnUp.Location = new System.Drawing.Point(491, 183);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 23);
            this.btnUp.TabIndex = 3;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::Taxi.Controls.Properties.Resources._1464077806_arrow_down_01;
            this.btnDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDown.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.btnDown.Location = new System.Drawing.Point(491, 213);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 23);
            this.btnDown.TabIndex = 4;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.Image = global::Taxi.Controls.Properties.Resources._1464274347_arrow_right_01;
            this.btnToRight.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnToRight.Location = new System.Drawing.Point(237, 183);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(24, 23);
            this.btnToRight.TabIndex = 3;
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Image = global::Taxi.Controls.Properties.Resources._1464274319_arrow_left_01;
            this.btnToLeft.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnToLeft.Location = new System.Drawing.Point(237, 213);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(24, 23);
            this.btnToLeft.TabIndex = 3;
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // lookupEdit_EnumCommand_Module1
            // 
            this.lookupEdit_EnumCommand_Module1.DefaultSelectFirstRow = true;
            this.lookupEdit_EnumCommand_Module1.IsAddAll = false;
            this.lookupEdit_EnumCommand_Module1.IsChangeText = false;
            this.lookupEdit_EnumCommand_Module1.IsFocus = false;
            this.lookupEdit_EnumCommand_Module1.Location = new System.Drawing.Point(60, 8);
            this.lookupEdit_EnumCommand_Module1.Name = "lookupEdit_EnumCommand_Module1";
            this.lookupEdit_EnumCommand_Module1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEdit_EnumCommand_Module1.Properties.NullText = "";
            this.lookupEdit_EnumCommand_Module1.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookupEdit_EnumCommand_Module1.Size = new System.Drawing.Size(169, 20);
            this.lookupEdit_EnumCommand_Module1.TabIndex = 5;
            this.lookupEdit_EnumCommand_Module1.EditValueChanged += new System.EventHandler(this.lookupEdit_EnumCommand_Module1_EditValueChanged);
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Controls.Add(this.lstCommandNotUse);
            this.myGroupBox1.Location = new System.Drawing.Point(12, 34);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(219, 426);
            this.myGroupBox1.TabIndex = 6;
            this.myGroupBox1.Text = "Lệnh chưa được cấp";
            // 
            // myGroupBox2
            // 
            this.myGroupBox2.Controls.Add(this.lstBoxUsed);
            this.myGroupBox2.Location = new System.Drawing.Point(268, 34);
            this.myGroupBox2.Name = "myGroupBox2";
            this.myGroupBox2.Size = new System.Drawing.Size(219, 426);
            this.myGroupBox2.TabIndex = 6;
            this.myGroupBox2.Text = "Lệnh đang được cấp";
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::Taxi.Controls.Properties.Resources.disk;
            this.btnLuu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnLuu.Location = new System.Drawing.Point(398, 5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(87, 23);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu(Ctrl+S)";
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Module";
            // 
            // FrmCommandModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 463);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.myGroupBox2);
            this.Controls.Add(this.myGroupBox1);
            this.Controls.Add(this.lookupEdit_EnumCommand_Module1);
            this.Controls.Add(this.btnToLeft);
            this.Controls.Add(this.btnToRight);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmCommandModule";
            this.Text = "Phân quyền sử dụng lệnh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCommandModule_FormClosing);
            this.Load += new System.EventHandler(this.FrmCommandModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstCommandNotUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEdit_EnumCommand_Module1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox1)).EndInit();
            this.myGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox2)).EndInit();
            this.myGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Base.Controls.ShListBox lstCommandNotUse;
        private Base.Controls.ShListBox lstBoxUsed;
        private Base.Controls.ShButton btnUp;
        private Base.Controls.ShButton btnDown;
        private Base.Controls.ShButton btnToRight;
        private Base.Controls.ShButton btnToLeft;
        private Base.Common.Enums.LookUpEdits.LookupEdit_EnumCommand_Module lookupEdit_EnumCommand_Module1;
        private Base.Controls.ShGroupBox myGroupBox1;
        private Base.Controls.ShGroupBox myGroupBox2;
        private Base.Controls.ShButton btnLuu;
        private System.Windows.Forms.Label label1;
    }
}