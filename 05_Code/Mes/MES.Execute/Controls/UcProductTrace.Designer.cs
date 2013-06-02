namespace MES.Execute.Controls
{
    partial class UcProductTrace
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
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.listBoxControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.listBoxControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.listBoxControl1.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.listBoxControl1.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.listBoxControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.listBoxControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControl1.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Default;
            this.listBoxControl1.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnHotTrack;
            this.listBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.listBoxControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.listBoxControl1.Size = new System.Drawing.Size(314, 146);
            this.listBoxControl1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.listBoxControl1.TabIndex = 0;
            this.listBoxControl1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // UcProductTrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxControl1);
            this.Name = "UcProductTrace";
            this.Size = new System.Drawing.Size(314, 146);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
    }
}
