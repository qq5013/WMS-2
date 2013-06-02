namespace Modules.ContainerModule.Views
{
    partial class ContainerEditForm
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
            this.tcArea = new DevExpress.XtraTab.XtraTabControl();
            this.tabBase = new DevExpress.XtraTab.XtraTabPage();
            this.gcOther = new DevExpress.XtraEditors.GroupControl();
            this.layoutOther = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEditTime = new DevExpress.XtraEditors.TextEdit();
            this.txtEditUser = new DevExpress.XtraEditors.TextEdit();
            this.txtCreateTime = new DevExpress.XtraEditors.TextEdit();
            this.txtCreateUser = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.cbIsActive = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.gcBase = new DevExpress.XtraEditors.GroupControl();
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.txtContainerCode = new DevExpress.XtraEditors.TextEdit();
            this.lblContainerCode = new System.Windows.Forms.Label();
            this.lblContainerType = new System.Windows.Forms.Label();
            this.txtContainerName = new DevExpress.XtraEditors.TextEdit();
            this.lblContainerName = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.beContainerType = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).BeginInit();
            this.gcClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcArea)).BeginInit();
            this.tcArea.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOther)).BeginInit();
            this.gcOther.SuspendLayout();
            this.layoutOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beContainerType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcClientZone
            // 
            this.gcClientZone.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.gcClientZone.Appearance.Options.UseBackColor = true;
            this.gcClientZone.Controls.Add(this.tcArea);
            this.gcClientZone.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // tcArea
            // 
            this.tcArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcArea.Location = new System.Drawing.Point(5, 5);
            this.tcArea.Name = "tcArea";
            this.tcArea.SelectedTabPage = this.tabBase;
            this.tcArea.Size = new System.Drawing.Size(624, 422);
            this.tcArea.TabIndex = 70;
            this.tcArea.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBase});
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.gcOther);
            this.tabBase.Controls.Add(this.gcBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Size = new System.Drawing.Size(618, 394);
            this.tabBase.Text = "容器信息";
            // 
            // gcOther
            // 
            this.gcOther.Controls.Add(this.layoutOther);
            this.gcOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOther.Location = new System.Drawing.Point(0, 96);
            this.gcOther.LookAndFeel.SkinName = "Lilian";
            this.gcOther.Name = "gcOther";
            this.gcOther.Padding = new System.Windows.Forms.Padding(10);
            this.gcOther.Size = new System.Drawing.Size(618, 298);
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
            this.layoutOther.Controls.Add(this.label4, 2, 2);
            this.layoutOther.Controls.Add(this.label3, 0, 2);
            this.layoutOther.Controls.Add(this.txtEditTime, 3, 2);
            this.layoutOther.Controls.Add(this.txtEditUser, 1, 2);
            this.layoutOther.Controls.Add(this.txtCreateTime, 3, 1);
            this.layoutOther.Controls.Add(this.txtCreateUser, 1, 1);
            this.layoutOther.Controls.Add(this.label1, 0, 1);
            this.layoutOther.Controls.Add(this.lblRemark, 0, 0);
            this.layoutOther.Controls.Add(this.txtRemark, 1, 0);
            this.layoutOther.Controls.Add(this.lblIsActive, 0, 3);
            this.layoutOther.Controls.Add(this.cbIsActive, 1, 3);
            this.layoutOther.Controls.Add(this.label2, 2, 1);
            this.layoutOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutOther.Location = new System.Drawing.Point(12, 31);
            this.layoutOther.Name = "layoutOther";
            this.layoutOther.RowCount = 4;
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.Size = new System.Drawing.Size(594, 149);
            this.layoutOther.TabIndex = 129;
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(299, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 132;
            this.label4.Text = "编辑时间：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 23);
            this.label3.TabIndex = 132;
            this.label3.Text = "编辑用户：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEditTime
            // 
            this.txtEditTime.Enabled = false;
            this.txtEditTime.Location = new System.Drawing.Point(417, 87);
            this.txtEditTime.Name = "txtEditTime";
            this.txtEditTime.Properties.ReadOnly = true;
            this.txtEditTime.Size = new System.Drawing.Size(165, 20);
            this.txtEditTime.TabIndex = 10;
            // 
            // txtEditUser
            // 
            this.txtEditUser.Enabled = false;
            this.txtEditUser.Location = new System.Drawing.Point(121, 87);
            this.txtEditUser.Name = "txtEditUser";
            this.txtEditUser.Properties.ReadOnly = true;
            this.txtEditUser.Size = new System.Drawing.Size(165, 20);
            this.txtEditUser.TabIndex = 9;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Enabled = false;
            this.txtCreateTime.Location = new System.Drawing.Point(417, 59);
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.Properties.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(165, 20);
            this.txtCreateTime.TabIndex = 8;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Enabled = false;
            this.txtCreateUser.Location = new System.Drawing.Point(121, 59);
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.Properties.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(165, 20);
            this.txtCreateUser.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 132;
            this.label1.Text = "创建用户：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemark
            // 
            this.lblRemark.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRemark.Location = new System.Drawing.Point(3, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(71, 23);
            this.lblRemark.TabIndex = 126;
            this.lblRemark.Text = "描述：";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemark
            // 
            this.layoutOther.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Location = new System.Drawing.Point(121, 3);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.MaxLength = 250;
            this.txtRemark.Size = new System.Drawing.Size(461, 50);
            this.txtRemark.TabIndex = 6;
            // 
            // lblIsActive
            // 
            this.lblIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblIsActive.Location = new System.Drawing.Point(3, 112);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(90, 23);
            this.lblIsActive.TabIndex = 75;
            this.lblIsActive.Text = "是否可用*：";
            this.lblIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIsActive
            // 
            this.cbIsActive.Location = new System.Drawing.Point(121, 115);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbIsActive.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbIsActive.Size = new System.Drawing.Size(165, 20);
            this.cbIsActive.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(299, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 132;
            this.label2.Text = "创建时间：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gcBase
            // 
            this.gcBase.Controls.Add(this.layoutBase);
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.LookAndFeel.SkinName = "Lilian";
            this.gcBase.Name = "gcBase";
            this.gcBase.Padding = new System.Windows.Forms.Padding(10);
            this.gcBase.Size = new System.Drawing.Size(618, 96);
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
            this.layoutBase.Controls.Add(this.txtContainerCode, 1, 0);
            this.layoutBase.Controls.Add(this.lblContainerCode, 0, 0);
            this.layoutBase.Controls.Add(this.lblContainerType, 0, 1);
            this.layoutBase.Controls.Add(this.txtContainerName, 3, 0);
            this.layoutBase.Controls.Add(this.lblContainerName, 2, 0);
            this.layoutBase.Controls.Add(this.lblBarcode, 2, 1);
            this.layoutBase.Controls.Add(this.txtBarcode, 3, 1);
            this.layoutBase.Controls.Add(this.beContainerType, 1, 1);
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
            // txtContainerCode
            // 
            this.txtContainerCode.Location = new System.Drawing.Point(121, 3);
            this.txtContainerCode.Name = "txtContainerCode";
            this.txtContainerCode.Properties.MaxLength = 30;
            this.txtContainerCode.Size = new System.Drawing.Size(165, 20);
            this.txtContainerCode.TabIndex = 0;
            // 
            // lblContainerCode
            // 
            this.lblContainerCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblContainerCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblContainerCode.Location = new System.Drawing.Point(3, 0);
            this.lblContainerCode.Name = "lblContainerCode";
            this.lblContainerCode.Size = new System.Drawing.Size(81, 23);
            this.lblContainerCode.TabIndex = 129;
            this.lblContainerCode.Text = "容器代码*：";
            this.lblContainerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContainerType
            // 
            this.lblContainerType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblContainerType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblContainerType.Location = new System.Drawing.Point(3, 28);
            this.lblContainerType.Name = "lblContainerType";
            this.lblContainerType.Size = new System.Drawing.Size(81, 23);
            this.lblContainerType.TabIndex = 74;
            this.lblContainerType.Text = "容器类型*：";
            this.lblContainerType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContainerName
            // 
            this.txtContainerName.Location = new System.Drawing.Point(417, 3);
            this.txtContainerName.Name = "txtContainerName";
            this.txtContainerName.Properties.MaxLength = 30;
            this.txtContainerName.Size = new System.Drawing.Size(165, 20);
            this.txtContainerName.TabIndex = 1;
            // 
            // lblContainerName
            // 
            this.lblContainerName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblContainerName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblContainerName.Location = new System.Drawing.Point(299, 0);
            this.lblContainerName.Name = "lblContainerName";
            this.lblContainerName.Size = new System.Drawing.Size(81, 23);
            this.lblContainerName.TabIndex = 131;
            this.lblContainerName.Text = "容器名称*：";
            this.lblContainerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBarcode
            // 
            this.lblBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblBarcode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBarcode.Location = new System.Drawing.Point(299, 28);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(81, 23);
            this.lblBarcode.TabIndex = 69;
            this.lblBarcode.Text = "容器条码*：";
            this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(417, 31);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Properties.MaxLength = 30;
            this.txtBarcode.Size = new System.Drawing.Size(165, 20);
            this.txtBarcode.TabIndex = 132;
            // 
            // beContainerType
            // 
            this.beContainerType.Location = new System.Drawing.Point(121, 31);
            this.beContainerType.Name = "beContainerType";
            this.beContainerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beContainerType.Size = new System.Drawing.Size(165, 20);
            this.beContainerType.TabIndex = 135;
            this.beContainerType.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beContainerType_ButtonClick);
            // 
            // ContainerEditForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ContainerEditForm";
            this.Text = "容器明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).EndInit();
            this.gcClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcArea)).EndInit();
            this.tcArea.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOther)).EndInit();
            this.gcOther.ResumeLayout(false);
            this.layoutOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEditTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beContainerType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcArea;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcOther;
        private System.Windows.Forms.TableLayoutPanel layoutOther;
        private System.Windows.Forms.Label lblRemark;
        private DevExpress.XtraEditors.ComboBoxEdit cbIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblContainerType;
        private DevExpress.XtraEditors.TextEdit txtContainerName;
        private System.Windows.Forms.Label lblBarcode;
        private DevExpress.XtraEditors.TextEdit txtContainerCode;
        private System.Windows.Forms.Label lblContainerCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtEditTime;
        private DevExpress.XtraEditors.TextEdit txtEditUser;
        private DevExpress.XtraEditors.TextEdit txtCreateTime;
        private DevExpress.XtraEditors.TextEdit txtCreateUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblContainerName;
        private DevExpress.XtraEditors.TextEdit txtBarcode;
        private DevExpress.XtraEditors.ButtonEdit beContainerType;




    }
}
