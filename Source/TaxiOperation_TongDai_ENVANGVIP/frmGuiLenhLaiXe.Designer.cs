namespace TaxiOperation_TongDai_ENVANGVIP
{
    partial class frmGuiLenhLaiXe
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
            this.inputVehicle = new Taxi.Controls.Base.Common.InputLookUps.InputLookUp_DanhSachXeHoatDong();
            this.lblDiemDo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDriverName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ilu_mobileOperationCommand = new Taxi.Controls.Base.Common.InputLookUps.InputLookUp_MobileOperationCommand();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new Taxi.Controls.Base.Controls.ShButton();
            this.btnOK = new Taxi.Controls.Base.Controls.ShButton();
            this.lblThongBao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputVehicle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilu_mobileOperationCommand.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // inputVehicle
            // 
            this.inputVehicle.DefaultSelectFirstRow = false;
            this.inputVehicle.EnterMoveNextControl = true;
            this.inputVehicle.IsChangeText = false;
            this.inputVehicle.IsFocus = false;
            this.inputVehicle.IsShowTextNull = false;
            this.inputVehicle.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.inputVehicle.Location = new System.Drawing.Point(87, 6);
            this.inputVehicle.Name = "inputVehicle";
            this.inputVehicle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.inputVehicle.Properties.HotTrackItems = false;
            this.inputVehicle.Properties.MaxLength = 10;
            this.inputVehicle.Properties.NullText = "Chọn xe";
            this.inputVehicle.Properties.NullValuePrompt = "Chọn xe";
            this.inputVehicle.Properties.NullValuePromptShowForEmptyValue = true;
            this.inputVehicle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.inputVehicle.Properties.ValidateOnEnterKey = true;
            this.inputVehicle.Size = new System.Drawing.Size(84, 20);
            this.inputVehicle.TabIndex = 9;
            this.inputVehicle.EditValueChanged += new System.EventHandler(this.inputVehicle_EditValueChanged);
            // 
            // lblDiemDo
            // 
            this.lblDiemDo.AutoSize = true;
            this.lblDiemDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiemDo.Location = new System.Drawing.Point(355, 9);
            this.lblDiemDo.Name = "lblDiemDo";
            this.lblDiemDo.Size = new System.Drawing.Size(54, 13);
            this.lblDiemDo.TabIndex = 13;
            this.lblDiemDo.Text = "Điểm đỗ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Điểm đỗ";
            // 
            // lblDriverName
            // 
            this.lblDriverName.AutoSize = true;
            this.lblDriverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverName.Location = new System.Drawing.Point(176, 9);
            this.lblDriverName.Name = "lblDriverName";
            this.lblDriverName.Size = new System.Drawing.Size(63, 13);
            this.lblDriverName.TabIndex = 11;
            this.lblDriverName.Text = "Tên lái xe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "[&S]ố xe";
            // 
            // ilu_mobileOperationCommand
            // 
            this.ilu_mobileOperationCommand.DefaultSelectFirstRow = false;
            this.ilu_mobileOperationCommand.EnterMoveNextControl = true;
            this.ilu_mobileOperationCommand.IdStepWorkflow = 0;
            this.ilu_mobileOperationCommand.IsChangeText = false;
            this.ilu_mobileOperationCommand.IsFocus = false;
            this.ilu_mobileOperationCommand.IsShowTextNull = true;
            this.ilu_mobileOperationCommand.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.ilu_mobileOperationCommand.Location = new System.Drawing.Point(87, 32);
            this.ilu_mobileOperationCommand.Name = "ilu_mobileOperationCommand";
            this.ilu_mobileOperationCommand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ilu_mobileOperationCommand.Properties.NullText = "";
            this.ilu_mobileOperationCommand.Size = new System.Drawing.Size(378, 20);
            this.ilu_mobileOperationCommand.TabIndex = 14;
            this.ilu_mobileOperationCommand.EditValueChanged += new System.EventHandler(this.ilu_mobileOperationCommand_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "[&L]ệnh LX";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(179, 78);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnOK.Location = new System.Drawing.Point(87, 78);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "Gửi (F2)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(84, 57);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(59, 13);
            this.lblThongBao.TabIndex = 18;
            this.lblThongBao.Text = "Thông báo";
            // 
            // frmGuiLenhLaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 110);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ilu_mobileOperationCommand);
            this.Controls.Add(this.inputVehicle);
            this.Controls.Add(this.lblDiemDo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDriverName);
            this.Controls.Add(this.label4);
            this.Name = "frmGuiLenhLaiXe";
            this.Text = "Gửi lệnh lái xe";
            this.Load += new System.EventHandler(this.frmGuiLenhLaiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputVehicle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilu_mobileOperationCommand.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Common.InputLookUps.InputLookUp_DanhSachXeHoatDong inputVehicle;
        private System.Windows.Forms.Label lblDiemDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDriverName;
        private System.Windows.Forms.Label label4;
        private Taxi.Controls.Base.Common.InputLookUps.InputLookUp_MobileOperationCommand ilu_mobileOperationCommand;
        private System.Windows.Forms.Label label1;
        private Taxi.Controls.Base.Controls.ShButton btnExit;
        private Taxi.Controls.Base.Controls.ShButton btnOK;
        private System.Windows.Forms.Label lblThongBao;

    }
}