namespace Taxi.Controls.Configs
{
    partial class UCPanelCommand
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
            this.panelCommand = new Taxi.Controls.BanCo.MyPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelCommand)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.panelCommand.Appearance.Options.UseBackColor = true;
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommand.Location = new System.Drawing.Point(0, 0);
            this.panelCommand.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelCommand.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(757, 85);
            this.panelCommand.TabIndex = 0;
            // 
            // UCPanelCommand
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCommand);
            this.Name = "UCPanelCommand";
            this.Size = new System.Drawing.Size(757, 85);
            ((System.ComponentModel.ISupportInitialize)(this.panelCommand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BanCo.MyPanelControl panelCommand;

    }
}
