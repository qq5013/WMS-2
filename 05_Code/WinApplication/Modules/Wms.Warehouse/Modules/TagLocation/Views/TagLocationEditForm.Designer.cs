namespace Modules.TagLocationModule.Views
{
    partial class TagLocationEditForm
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
            this.tcDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tabBase = new DevExpress.XtraTab.XtraTabPage();
            this.gcBase = new DevExpress.XtraEditors.GroupControl();
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.beLocationId = new DevExpress.XtraEditors.ButtonEdit();
            this.beTagId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblTagId = new System.Windows.Forms.Label();
            this.lblLocationId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).BeginInit();
            this.gcClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beTagId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcClientZone
            // 
            this.gcClientZone.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.gcClientZone.Appearance.Options.UseBackColor = true;
            this.gcClientZone.Controls.Add(this.tcDetail);
            this.gcClientZone.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // tcDetail
            // 
            this.tcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetail.Location = new System.Drawing.Point(5, 5);
            this.tcDetail.Name = "tcDetail";
            this.tcDetail.SelectedTabPage = this.tabBase;
            this.tcDetail.Size = new System.Drawing.Size(624, 422);
            this.tcDetail.TabIndex = 70;
            this.tcDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBase});
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.gcBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Size = new System.Drawing.Size(618, 393);
            this.tabBase.Text = "库位标签映射";
            // 
            // gcBase
            // 
            this.gcBase.Controls.Add(this.layoutBase);
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.LookAndFeel.SkinName = "Lilian";
            this.gcBase.Name = "gcBase";
            this.gcBase.Padding = new System.Windows.Forms.Padding(10);
            this.gcBase.Size = new System.Drawing.Size(618, 395);
            this.gcBase.TabIndex = 68;
            this.gcBase.Text = "基本信息";
            // 
            // layoutBase
            // 
            this.layoutBase.ColumnCount = 4;
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.Controls.Add(this.beLocationId, 0, 0);
            this.layoutBase.Controls.Add(this.beTagId, 3, 0);
            this.layoutBase.Controls.Add(this.lblTagId, 2, 0);
            this.layoutBase.Controls.Add(this.lblLocationId, 0, 0);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 32);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 1;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.Size = new System.Drawing.Size(594, 46);
            this.layoutBase.TabIndex = 128;
            // 
            // beLocationId
            // 
            this.beLocationId.Location = new System.Drawing.Point(121, 3);
            this.beLocationId.Name = "beLocationId";
            this.beLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beLocationId.Size = new System.Drawing.Size(165, 20);
            this.beLocationId.TabIndex = 135;
            this.beLocationId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beLocationId_ButtonClick);
            // 
            // beTagId
            // 
            this.beTagId.Location = new System.Drawing.Point(417, 3);
            this.beTagId.Name = "beTagId";
            this.beTagId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beTagId.Size = new System.Drawing.Size(165, 20);
            this.beTagId.TabIndex = 134;
            this.beTagId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beTagId_ButtonClick);
            // 
            // lblTagId
            // 
            this.lblTagId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTagId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTagId.Location = new System.Drawing.Point(299, 0);
            this.lblTagId.Name = "lblTagId";
            this.lblTagId.Size = new System.Drawing.Size(81, 23);
            this.lblTagId.TabIndex = 69;
            this.lblTagId.Text = "标签名称*：";
            this.lblTagId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLocationId
            // 
            this.lblLocationId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLocationId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLocationId.Location = new System.Drawing.Point(3, 0);
            this.lblLocationId.Name = "lblLocationId";
            this.lblLocationId.Size = new System.Drawing.Size(81, 23);
            this.lblLocationId.TabIndex = 129;
            this.lblLocationId.Text = "库位名称*：";
            this.lblLocationId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TagLocationEditForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "TagLocationEditForm";
            this.Text = "库位标签映射明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).EndInit();
            this.gcClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beTagId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblTagId;
        private System.Windows.Forms.Label lblLocationId;
        private DevExpress.XtraEditors.ButtonEdit beTagId;
        private DevExpress.XtraEditors.ButtonEdit beLocationId;




    }
}
