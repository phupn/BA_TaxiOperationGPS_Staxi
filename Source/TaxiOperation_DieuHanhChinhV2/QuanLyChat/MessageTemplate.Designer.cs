namespace TaxiOperation_DieuHanhChinh.QuanLyChat
{
    partial class MessageTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageTemplate));
            this.messageTemplate1 = new Taxi.Controls.MessageTemplate();
            this.SuspendLayout();
            // 
            // messageTemplate1
            // 
            this.messageTemplate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTemplate1.Location = new System.Drawing.Point(0, 0);
            this.messageTemplate1.Name = "messageTemplate1";
            this.messageTemplate1.Size = new System.Drawing.Size(567, 307);
            this.messageTemplate1.TabIndex = 0;
            // 
            // MessageTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 307);
            this.Controls.Add(this.messageTemplate1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessageTemplate";
            this.Text = "Tin nhắn mẫu";
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.MessageTemplate messageTemplate1;
    }
}