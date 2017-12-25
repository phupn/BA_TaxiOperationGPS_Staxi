namespace Taxi.GUI.CheckCoDuongDai
{
    partial class frmXeBaoDiSanBay_DuongDai_Mini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXeBaoDiSanBay_DuongDai_Mini));
            this.chkDuongDai = new Janus.Windows.EditControls.UICheckBox();
            this.chkSanBay = new Janus.Windows.EditControls.UICheckBox();
            this.editViTriBao = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblViTriBao = new System.Windows.Forms.Label();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.editSoHieuXe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editThoiDiemBao = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtViTriBao1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblTenLaiXe = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDuongDai
            // 
            this.chkDuongDai.Location = new System.Drawing.Point(149, 32);
            this.chkDuongDai.Name = "chkDuongDai";
            this.chkDuongDai.Size = new System.Drawing.Size(66, 23);
            this.chkDuongDai.TabIndex = 15;
            this.chkDuongDai.Text = "Đường &dài";
            this.chkDuongDai.CheckedChanged += new System.EventHandler(this.chkDuongDai_CheckedChanged);
            this.chkDuongDai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkDuongDai_KeyDown);
            // 
            // chkSanBay
            // 
            this.chkSanBay.Location = new System.Drawing.Point(77, 32);
            this.chkSanBay.Name = "chkSanBay";
            this.chkSanBay.Size = new System.Drawing.Size(66, 23);
            this.chkSanBay.TabIndex = 14;
            this.chkSanBay.Text = "&Sân bay";
            this.chkSanBay.CheckedChanged += new System.EventHandler(this.chkSanBay_CheckedChanged);
            this.chkSanBay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkSanBay_KeyDown);
            // 
            // editViTriBao
            // 
            this.editViTriBao.Location = new System.Drawing.Point(77, 85);
            this.editViTriBao.MaxLength = 50;
            this.editViTriBao.Name = "editViTriBao";
            this.editViTriBao.Size = new System.Drawing.Size(282, 20);
            this.editViTriBao.TabIndex = 17;
            this.editViTriBao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editViTriBao_KeyDown);
            // 
            // lblViTriBao
            // 
            this.lblViTriBao.AutoSize = true;
            this.lblViTriBao.Location = new System.Drawing.Point(11, 89);
            this.lblViTriBao.Name = "lblViTriBao";
            this.lblViTriBao.Size = new System.Drawing.Size(44, 13);
            this.lblViTriBao.TabIndex = 21;
            this.lblViTriBao.Text = "Vị trí trả";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(77, 136);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 26);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Lư&u";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(172, 136);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "&Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Số hiệu xe (*)";
            // 
            // editSoHieuXe
            // 
            this.editSoHieuXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSoHieuXe.Location = new System.Drawing.Point(77, 6);
            this.editSoHieuXe.MaxLength = 4;
            this.editSoHieuXe.Name = "editSoHieuXe";
            this.editSoHieuXe.Size = new System.Drawing.Size(78, 22);
            this.editSoHieuXe.TabIndex = 13;
            this.editSoHieuXe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.editSoHieuXe.TextChanged += new System.EventHandler(this.editSoHieuXe_TextChanged);
            this.editSoHieuXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editSoHieuXe_KeyDown);
            // 
            // editThoiDiemBao
            // 
            this.editThoiDiemBao.Enabled = false;
            this.editThoiDiemBao.Location = new System.Drawing.Point(242, 6);
            this.editThoiDiemBao.MaxLength = 3;
            this.editThoiDiemBao.Name = "editThoiDiemBao";
            this.editThoiDiemBao.Size = new System.Drawing.Size(115, 20);
            this.editThoiDiemBao.TabIndex = 23;
            this.editThoiDiemBao.Text = "12:12:12 02/10/2008";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Thời điểm báo";
            // 
            // txtViTriBao1
            // 
            this.txtViTriBao1.Location = new System.Drawing.Point(77, 59);
            this.txtViTriBao1.Name = "txtViTriBao1";
            this.txtViTriBao1.Size = new System.Drawing.Size(282, 20);
            this.txtViTriBao1.TabIndex = 16;
            this.txtViTriBao1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtViTriBao1_KeyDown);
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.AutoSize = true;
            this.lblTenLaiXe.Location = new System.Drawing.Point(8, 59);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(64, 13);
            this.lblTenLaiXe.TabIndex = 25;
            this.lblTenLaiXe.Text = "Vị trí đón (*)";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(77, 111);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 26;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmXeBaoDiSanBay_DuongDai_Mini
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(377, 171);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtViTriBao1);
            this.Controls.Add(this.lblTenLaiXe);
            this.Controls.Add(this.chkDuongDai);
            this.Controls.Add(this.chkSanBay);
            this.Controls.Add(this.editViTriBao);
            this.Controls.Add(this.lblViTriBao);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editSoHieuXe);
            this.Controls.Add(this.editThoiDiemBao);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXeBaoDiSanBay_DuongDai_Mini";
            this.Text = "Chốt cơ sân bay đường dài";
            this.Load += new System.EventHandler(this.frmXeBaoDiSanBay_DuongDai_Mini_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.EditControls.UICheckBox chkDuongDai;
        private Janus.Windows.EditControls.UICheckBox chkSanBay;
        private Janus.Windows.GridEX.EditControls.EditBox editViTriBao;
        private System.Windows.Forms.Label lblViTriBao;
        private Janus.Windows.EditControls.UIButton btnSave;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox editSoHieuXe;
        private Janus.Windows.GridEX.EditControls.EditBox editThoiDiemBao;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.EditBox txtViTriBao1;
        private System.Windows.Forms.Label lblTenLaiXe;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}