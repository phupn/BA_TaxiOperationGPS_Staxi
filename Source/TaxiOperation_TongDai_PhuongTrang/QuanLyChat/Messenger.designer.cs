namespace Taxi.GUI
{
    partial class Messenger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messenger));
            this.listMessages1 = new Taxi.Controls.ListMessages();
            this.SuspendLayout();
            // 
            // listMessages1
            // 
            this.listMessages1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMessages1.Location = new System.Drawing.Point(0, 0);
            this.listMessages1.Name = "listMessages1";
            this.listMessages1.Size = new System.Drawing.Size(664, 407);
            this.listMessages1.TabIndex = 0;
            // 
            // Messenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(664, 407);
            this.Controls.Add(this.listMessages1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Messenger";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tin nhắn";
            this.Load += new System.EventHandler(this.Messenger_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.ListMessages listMessages1;

    }
}