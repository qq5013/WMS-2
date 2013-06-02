namespace Mes.Product.Modules.ProcessModule.Views
{
    partial class ProcessEditForm
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
            this.lblProcessType = new System.Windows.Forms.Label();
            this.lblErpCode = new System.Windows.Forms.Label();
            this.txtErpCode = new DevExpress.XtraEditors.TextEdit();
            this.txtProcessCode = new DevExpress.XtraEditors.TextEdit();
            this.lblProcessCode = new System.Windows.Forms.Label();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtShortName = new DevExpress.XtraEditors.TextEdit();
            this.lblParentId = new System.Windows.Forms.Label();
            this.txtProcessName = new DevExpress.XtraEditors.TextEdit();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.ccbProcessType = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.beParentId = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).BeginInit();
            this.gcClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtErpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbProcessType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beParentId.Properties)).BeginInit();
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
            this.tabBase.Size = new System.Drawing.Size(618, 394);
            this.tabBase.Text = "工序信息";
            // 
            // gcBase
            // 
            this.gcBase.Controls.Add(this.layoutBase);
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.LookAndFeel.SkinName = "Lilian";
            this.gcBase.Name = "gcBase";
            this.gcBase.Padding = new System.Windows.Forms.Padding(10);
            this.gcBase.Size = new System.Drawing.Size(618, 128);
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
            this.layoutBase.Controls.Add(this.lblProcessType, 2, 2);
            this.layoutBase.Controls.Add(this.lblErpCode, 0, 2);
            this.layoutBase.Controls.Add(this.txtErpCode, 1, 2);
            this.layoutBase.Controls.Add(this.txtProcessCode, 1, 0);
            this.layoutBase.Controls.Add(this.lblProcessCode, 0, 0);
            this.layoutBase.Controls.Add(this.lblShortName, 0, 1);
            this.layoutBase.Controls.Add(this.txtShortName, 1, 1);
            this.layoutBase.Controls.Add(this.lblParentId, 2, 1);
            this.layoutBase.Controls.Add(this.txtProcessName, 3, 0);
            this.layoutBase.Controls.Add(this.lblProcessName, 2, 0);
            this.layoutBase.Controls.Add(this.ccbProcessType, 3, 2);
            this.layoutBase.Controls.Add(this.beParentId, 3, 1);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 3;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.Size = new System.Drawing.Size(594, 88);
            this.layoutBase.TabIndex = 128;
            // 
            // lblProcessType
            // 
            this.lblProcessType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblProcessType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProcessType.Location = new System.Drawing.Point(299, 56);
            this.lblProcessType.Name = "lblProcessType";
            this.lblProcessType.Size = new System.Drawing.Size(81, 23);
            this.lblProcessType.TabIndex = 132;
            this.lblProcessType.Text = "公司类型*：";
            this.lblProcessType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblErpCode
            // 
            this.lblErpCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblErpCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblErpCode.Location = new System.Drawing.Point(3, 56);
            this.lblErpCode.Name = "lblErpCode";
            this.lblErpCode.Size = new System.Drawing.Size(81, 23);
            this.lblErpCode.TabIndex = 131;
            this.lblErpCode.Text = "外部代码：";
            this.lblErpCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtErpCode
            // 
            this.txtErpCode.Location = new System.Drawing.Point(121, 59);
            this.txtErpCode.Name = "txtErpCode";
            this.txtErpCode.Size = new System.Drawing.Size(165, 20);
            this.txtErpCode.TabIndex = 4;
            // 
            // txtProcessCode
            // 
            this.txtProcessCode.Location = new System.Drawing.Point(121, 3);
            this.txtProcessCode.Name = "txtProcessCode";
            this.txtProcessCode.Size = new System.Drawing.Size(165, 20);
            this.txtProcessCode.TabIndex = 0;
            // 
            // lblProcessCode
            // 
            this.lblProcessCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblProcessCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProcessCode.Location = new System.Drawing.Point(3, 0);
            this.lblProcessCode.Name = "lblProcessCode";
            this.lblProcessCode.Size = new System.Drawing.Size(81, 23);
            this.lblProcessCode.TabIndex = 129;
            this.lblProcessCode.Text = "产线名称*：";
            this.lblProcessCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShortName
            // 
            this.lblShortName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblShortName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblShortName.Location = new System.Drawing.Point(3, 28);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(81, 23);
            this.lblShortName.TabIndex = 74;
            this.lblShortName.Text = "产线类别：";
            this.lblShortName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(121, 31);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(165, 20);
            this.txtShortName.TabIndex = 2;
            // 
            // lblParentId
            // 
            this.lblParentId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblParentId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParentId.Location = new System.Drawing.Point(299, 28);
            this.lblParentId.Name = "lblParentId";
            this.lblParentId.Size = new System.Drawing.Size(81, 23);
            this.lblParentId.TabIndex = 73;
            this.lblParentId.Text = "描述：";
            this.lblParentId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(417, 3);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(165, 20);
            this.txtProcessName.TabIndex = 1;
            // 
            // lblProcessName
            // 
            this.lblProcessName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblProcessName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProcessName.Location = new System.Drawing.Point(299, 0);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(81, 23);
            this.lblProcessName.TabIndex = 69;
            this.lblProcessName.Text = "产线代码*：";
            this.lblProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ccbProcessType
            // 
            this.ccbProcessType.Location = new System.Drawing.Point(417, 59);
            this.ccbProcessType.Name = "ccbProcessType";
            this.ccbProcessType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccbProcessType.Properties.SelectAllItemCaption = "全选";
            this.ccbProcessType.Size = new System.Drawing.Size(165, 20);
            this.ccbProcessType.TabIndex = 133;
            // 
            // beParentId
            // 
            this.beParentId.Location = new System.Drawing.Point(417, 31);
            this.beParentId.Name = "beParentId";
            this.beParentId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beParentId.Size = new System.Drawing.Size(165, 20);
            this.beParentId.TabIndex = 134;
            this.beParentId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beParentId_ButtonClick);
            // 
            // ProcessEditForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ProcessEditForm";
            this.Text = "公司明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).EndInit();
            this.gcClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtErpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbProcessType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beParentId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblShortName;
        private DevExpress.XtraEditors.TextEdit txtShortName;
        private System.Windows.Forms.Label lblParentId;
        private DevExpress.XtraEditors.TextEdit txtErpCode;
        private DevExpress.XtraEditors.TextEdit txtProcessName;
        private System.Windows.Forms.Label lblProcessName;
        private DevExpress.XtraEditors.TextEdit txtProcessCode;
        private System.Windows.Forms.Label lblProcessCode;
        private System.Windows.Forms.Label lblErpCode;
        private System.Windows.Forms.Label lblProcessType;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ccbProcessType;
        private DevExpress.XtraEditors.ButtonEdit beParentId;




    }
}
