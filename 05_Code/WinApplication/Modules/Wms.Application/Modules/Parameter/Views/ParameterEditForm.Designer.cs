namespace Modules.ParameterModule.Views
{
    partial class ParameterEditForm
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
            this.gcOther = new DevExpress.XtraEditors.GroupControl();
            this.layoutOther = new System.Windows.Forms.TableLayoutPanel();
            this.lblRemark = new System.Windows.Forms.Label();
            this.cbIsActive = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.gcBase = new DevExpress.XtraEditors.GroupControl();
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.txtParameterValue = new DevExpress.XtraEditors.TextEdit();
            this.lblParameterName = new System.Windows.Forms.Label();
            this.lblParameterValue = new System.Windows.Forms.Label();
            this.txtParameterName = new DevExpress.XtraEditors.TextEdit();
            this.lblValueType = new System.Windows.Forms.Label();
            this.txtValueType = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).BeginInit();
            this.gcClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOther)).BeginInit();
            this.gcOther.SuspendLayout();
            this.layoutOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtParameterValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParameterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValueType.Properties)).BeginInit();
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
            this.tabBase.Controls.Add(this.gcOther);
            this.tabBase.Controls.Add(this.gcBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Size = new System.Drawing.Size(618, 394);
            this.tabBase.Text = "参数信息";
            // 
            // gcOther
            // 
            this.gcOther.Controls.Add(this.layoutOther);
            this.gcOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOther.Location = new System.Drawing.Point(0, 104);
            this.gcOther.LookAndFeel.SkinName = "Lilian";
            this.gcOther.Name = "gcOther";
            this.gcOther.Padding = new System.Windows.Forms.Padding(10);
            this.gcOther.Size = new System.Drawing.Size(618, 290);
            this.gcOther.TabIndex = 70;
            this.gcOther.Text = "其它信息";
            // 
            // layoutOther
            // 
            this.layoutOther.ColumnCount = 4;
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutOther.Controls.Add(this.lblRemark, 0, 0);
            this.layoutOther.Controls.Add(this.cbIsActive, 1, 1);
            this.layoutOther.Controls.Add(this.lblIsActive, 0, 1);
            this.layoutOther.Controls.Add(this.txtRemark, 1, 0);
            this.layoutOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutOther.Location = new System.Drawing.Point(12, 31);
            this.layoutOther.Name = "layoutOther";
            this.layoutOther.RowCount = 3;
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.Size = new System.Drawing.Size(594, 100);
            this.layoutOther.TabIndex = 129;
            // 
            // lblRemark
            // 
            this.lblRemark.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRemark.Location = new System.Drawing.Point(3, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(78, 23);
            this.lblRemark.TabIndex = 126;
            this.lblRemark.Text = "描述：";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIsActive
            // 
            this.cbIsActive.Location = new System.Drawing.Point(121, 59);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbIsActive.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbIsActive.Size = new System.Drawing.Size(165, 20);
            this.cbIsActive.TabIndex = 1;
            // 
            // lblIsActive
            // 
            this.lblIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblIsActive.Location = new System.Drawing.Point(3, 56);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(78, 23);
            this.lblIsActive.TabIndex = 75;
            this.lblIsActive.Text = "是否可用*：";
            this.lblIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemark
            // 
            this.layoutOther.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Location = new System.Drawing.Point(121, 3);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.MaxLength = 250;
            this.txtRemark.Size = new System.Drawing.Size(461, 50);
            this.txtRemark.TabIndex = 127;
            // 
            // gcBase
            // 
            this.gcBase.Controls.Add(this.layoutBase);
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.LookAndFeel.SkinName = "Lilian";
            this.gcBase.Name = "gcBase";
            this.gcBase.Padding = new System.Windows.Forms.Padding(10);
            this.gcBase.Size = new System.Drawing.Size(618, 104);
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
            this.layoutBase.Controls.Add(this.txtParameterValue, 3, 0);
            this.layoutBase.Controls.Add(this.lblParameterName, 0, 0);
            this.layoutBase.Controls.Add(this.lblParameterValue, 2, 0);
            this.layoutBase.Controls.Add(this.txtParameterName, 1, 0);
            this.layoutBase.Controls.Add(this.lblValueType, 0, 1);
            this.layoutBase.Controls.Add(this.txtValueType, 1, 1);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 3;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.Size = new System.Drawing.Size(594, 67);
            this.layoutBase.TabIndex = 128;
            // 
            // txtParameterValue
            // 
            this.txtParameterValue.Location = new System.Drawing.Point(417, 3);
            this.txtParameterValue.Name = "txtParameterValue";
            this.txtParameterValue.Properties.MaxLength = 10;
            this.txtParameterValue.Size = new System.Drawing.Size(165, 20);
            this.txtParameterValue.TabIndex = 1;
            // 
            // lblParameterName
            // 
            this.lblParameterName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblParameterName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParameterName.Location = new System.Drawing.Point(3, 0);
            this.lblParameterName.Name = "lblParameterName";
            this.lblParameterName.Size = new System.Drawing.Size(78, 23);
            this.lblParameterName.TabIndex = 69;
            this.lblParameterName.Text = "参数名称*：";
            this.lblParameterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblParameterValue
            // 
            this.lblParameterValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblParameterValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParameterValue.Location = new System.Drawing.Point(299, 0);
            this.lblParameterValue.Name = "lblParameterValue";
            this.lblParameterValue.Size = new System.Drawing.Size(86, 23);
            this.lblParameterValue.TabIndex = 73;
            this.lblParameterValue.Text = "参数值*：";
            this.lblParameterValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParameterName
            // 
            this.txtParameterName.Location = new System.Drawing.Point(121, 3);
            this.txtParameterName.Name = "txtParameterName";
            this.txtParameterName.Properties.MaxLength = 30;
            this.txtParameterName.Size = new System.Drawing.Size(165, 20);
            this.txtParameterName.TabIndex = 0;
            // 
            // lblValueType
            // 
            this.lblValueType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblValueType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValueType.Location = new System.Drawing.Point(3, 28);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(78, 23);
            this.lblValueType.TabIndex = 74;
            this.lblValueType.Text = "值类型：";
            this.lblValueType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValueType
            // 
            this.txtValueType.Location = new System.Drawing.Point(121, 31);
            this.txtValueType.Name = "txtValueType";
            this.txtValueType.Properties.MaxLength = 100;
            this.txtValueType.Size = new System.Drawing.Size(165, 20);
            this.txtValueType.TabIndex = 75;
            // 
            // ParameterEditForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ParameterEditForm";
            this.Text = "参数明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).EndInit();
            this.gcClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOther)).EndInit();
            this.gcOther.ResumeLayout(false);
            this.layoutOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtParameterValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParameterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValueType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcOther;
        private System.Windows.Forms.TableLayoutPanel layoutOther;
        private System.Windows.Forms.Label lblRemark;
        private DevExpress.XtraEditors.ComboBoxEdit cbIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private DevExpress.XtraEditors.TextEdit txtParameterValue;
        private System.Windows.Forms.Label lblParameterName;
        private System.Windows.Forms.Label lblParameterValue;
        private DevExpress.XtraEditors.TextEdit txtParameterName;
        private System.Windows.Forms.Label lblValueType;
        private DevExpress.XtraEditors.TextEdit txtValueType;




    }
}
