namespace Wms.Mobile.UI
{
    partial class TemplateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mmForm;

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
            this.mmForm = new System.Windows.Forms.MainMenu();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.pnlClientZone = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 225);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(318, 50);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClientZone.Location = new System.Drawing.Point(0, 0);
            this.pnlClientZone.Name = "pnlClientZone";
            this.pnlClientZone.Size = new System.Drawing.Size(318, 225);
            // 
            // TemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.ControlBox = false;
            this.Controls.Add(this.pnlClientZone);
            this.Controls.Add(this.pnlButton);
            this.MaximizeBox = false;
            this.Menu = this.mmForm;
            this.MinimizeBox = false;
            this.Name = "TemplateForm";
            this.Text = "TemplateForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlButton;
        public System.Windows.Forms.Panel pnlClientZone;
    }
}