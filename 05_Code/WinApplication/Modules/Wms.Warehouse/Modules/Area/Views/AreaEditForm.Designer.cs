namespace Modules.AreaModule.Views
{
    partial class AreaEditForm
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
            this.txtAreaCode = new DevExpress.XtraEditors.TextEdit();
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.lblAreaType = new System.Windows.Forms.Label();
            this.txtAreaName = new DevExpress.XtraEditors.TextEdit();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.leAreaType = new DevExpress.XtraEditors.LookUpEdit();
            this.tabPosition = new DevExpress.XtraTab.XtraTabPage();
            this.gcContact = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.seCoordY = new DevExpress.XtraEditors.SpinEdit();
            this.seCoordZ = new DevExpress.XtraEditors.SpinEdit();
            this.seCoordX = new DevExpress.XtraEditors.SpinEdit();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblCoordY = new System.Windows.Forms.Label();
            this.lblCoordX = new System.Windows.Forms.Label();
            this.lblCoordZ = new System.Windows.Forms.Label();
            this.seLength = new DevExpress.XtraEditors.SpinEdit();
            this.seWidth = new DevExpress.XtraEditors.SpinEdit();
            this.seHeight = new DevExpress.XtraEditors.SpinEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leAreaType.Properties)).BeginInit();
            this.tabPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcContact)).BeginInit();
            this.gcContact.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seCoordY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCoordZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCoordX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seHeight.Properties)).BeginInit();
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
            this.tabBase,
            this.tabPosition});
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.gcOther);
            this.tabBase.Controls.Add(this.gcBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Size = new System.Drawing.Size(618, 394);
            this.tabBase.Text = "库区信息";
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
            this.layoutBase.Controls.Add(this.txtAreaCode, 1, 0);
            this.layoutBase.Controls.Add(this.lblAreaCode, 0, 0);
            this.layoutBase.Controls.Add(this.lblAreaType, 0, 1);
            this.layoutBase.Controls.Add(this.txtAreaName, 3, 0);
            this.layoutBase.Controls.Add(this.lblAreaName, 2, 0);
            this.layoutBase.Controls.Add(this.leAreaType, 1, 1);
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
            // txtAreaCode
            // 
            this.txtAreaCode.Location = new System.Drawing.Point(121, 3);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Properties.MaxLength = 30;
            this.txtAreaCode.Size = new System.Drawing.Size(165, 20);
            this.txtAreaCode.TabIndex = 0;
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAreaCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAreaCode.Location = new System.Drawing.Point(3, 0);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(81, 23);
            this.lblAreaCode.TabIndex = 129;
            this.lblAreaCode.Text = "库区代码*：";
            this.lblAreaCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAreaType
            // 
            this.lblAreaType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAreaType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAreaType.Location = new System.Drawing.Point(3, 28);
            this.lblAreaType.Name = "lblAreaType";
            this.lblAreaType.Size = new System.Drawing.Size(81, 23);
            this.lblAreaType.TabIndex = 74;
            this.lblAreaType.Text = "库区类型*：";
            this.lblAreaType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAreaName
            // 
            this.txtAreaName.Location = new System.Drawing.Point(417, 3);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Properties.MaxLength = 30;
            this.txtAreaName.Size = new System.Drawing.Size(165, 20);
            this.txtAreaName.TabIndex = 1;
            // 
            // lblAreaName
            // 
            this.lblAreaName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAreaName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAreaName.Location = new System.Drawing.Point(299, 0);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(81, 23);
            this.lblAreaName.TabIndex = 69;
            this.lblAreaName.Text = "库区名称*：";
            this.lblAreaName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leAreaType
            // 
            this.leAreaType.Location = new System.Drawing.Point(121, 31);
            this.leAreaType.Name = "leAreaType";
            this.leAreaType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leAreaType.Properties.NullText = "";
            this.leAreaType.Size = new System.Drawing.Size(165, 20);
            this.leAreaType.TabIndex = 130;
            // 
            // tabPosition
            // 
            this.tabPosition.Controls.Add(this.gcContact);
            this.tabPosition.Name = "tabPosition";
            this.tabPosition.Size = new System.Drawing.Size(618, 394);
            this.tabPosition.Text = "位置信息";
            // 
            // gcContact
            // 
            this.gcContact.Controls.Add(this.tableLayoutPanel1);
            this.gcContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcContact.Location = new System.Drawing.Point(0, 0);
            this.gcContact.LookAndFeel.SkinName = "Lilian";
            this.gcContact.Name = "gcContact";
            this.gcContact.Padding = new System.Windows.Forms.Padding(10);
            this.gcContact.Size = new System.Drawing.Size(618, 394);
            this.gcContact.TabIndex = 69;
            this.gcContact.Text = "基本信息";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.seCoordY, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.seCoordZ, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.seCoordX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLength, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHeight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWidth, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCoordY, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCoordX, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCoordZ, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.seLength, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.seWidth, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.seHeight, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 245);
            this.tableLayoutPanel1.TabIndex = 128;
            // 
            // seCoordY
            // 
            this.seCoordY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCoordY.Location = new System.Drawing.Point(417, 59);
            this.seCoordY.Name = "seCoordY";
            this.seCoordY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seCoordY.Properties.Mask.EditMask = "n2";
            this.seCoordY.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seCoordY.Size = new System.Drawing.Size(160, 20);
            this.seCoordY.TabIndex = 135;
            // 
            // seCoordZ
            // 
            this.seCoordZ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCoordZ.Location = new System.Drawing.Point(121, 87);
            this.seCoordZ.MenuManager = this.bmMain;
            this.seCoordZ.Name = "seCoordZ";
            this.seCoordZ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seCoordZ.Properties.Mask.EditMask = "n2";
            this.seCoordZ.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seCoordZ.Size = new System.Drawing.Size(160, 20);
            this.seCoordZ.TabIndex = 135;
            // 
            // seCoordX
            // 
            this.seCoordX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCoordX.Location = new System.Drawing.Point(121, 59);
            this.seCoordX.MenuManager = this.bmMain;
            this.seCoordX.Name = "seCoordX";
            this.seCoordX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seCoordX.Properties.Mask.EditMask = "n2";
            this.seCoordX.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seCoordX.Size = new System.Drawing.Size(160, 20);
            this.seCoordX.TabIndex = 135;
            // 
            // lblLength
            // 
            this.lblLength.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLength.Location = new System.Drawing.Point(3, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(81, 23);
            this.lblLength.TabIndex = 129;
            this.lblLength.Text = "长度(米)：";
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeight
            // 
            this.lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblHeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHeight.Location = new System.Drawing.Point(3, 28);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(81, 23);
            this.lblHeight.TabIndex = 74;
            this.lblHeight.Text = "高度(米)：";
            this.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWidth
            // 
            this.lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWidth.Location = new System.Drawing.Point(299, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(81, 23);
            this.lblWidth.TabIndex = 69;
            this.lblWidth.Text = "宽度(米)：";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCoordY
            // 
            this.lblCoordY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCoordY.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCoordY.Location = new System.Drawing.Point(299, 56);
            this.lblCoordY.Name = "lblCoordY";
            this.lblCoordY.Size = new System.Drawing.Size(81, 23);
            this.lblCoordY.TabIndex = 73;
            this.lblCoordY.Text = "Y坐标：";
            this.lblCoordY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCoordX
            // 
            this.lblCoordX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCoordX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCoordX.Location = new System.Drawing.Point(3, 56);
            this.lblCoordX.Name = "lblCoordX";
            this.lblCoordX.Size = new System.Drawing.Size(81, 23);
            this.lblCoordX.TabIndex = 131;
            this.lblCoordX.Text = "X坐标：";
            this.lblCoordX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCoordZ
            // 
            this.lblCoordZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCoordZ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCoordZ.Location = new System.Drawing.Point(3, 84);
            this.lblCoordZ.Name = "lblCoordZ";
            this.lblCoordZ.Size = new System.Drawing.Size(81, 23);
            this.lblCoordZ.TabIndex = 133;
            this.lblCoordZ.Text = "Z坐标：";
            this.lblCoordZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seLength
            // 
            this.seLength.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seLength.Location = new System.Drawing.Point(121, 3);
            this.seLength.MenuManager = this.bmMain;
            this.seLength.Name = "seLength";
            this.seLength.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seLength.Properties.Mask.EditMask = "n2";
            this.seLength.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seLength.Size = new System.Drawing.Size(160, 20);
            this.seLength.TabIndex = 134;
            // 
            // seWidth
            // 
            this.seWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seWidth.Location = new System.Drawing.Point(417, 3);
            this.seWidth.MenuManager = this.bmMain;
            this.seWidth.Name = "seWidth";
            this.seWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seWidth.Properties.Mask.EditMask = "n2";
            this.seWidth.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seWidth.Size = new System.Drawing.Size(160, 20);
            this.seWidth.TabIndex = 135;
            // 
            // seHeight
            // 
            this.seHeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seHeight.Location = new System.Drawing.Point(121, 31);
            this.seHeight.MenuManager = this.bmMain;
            this.seHeight.Name = "seHeight";
            this.seHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seHeight.Properties.Mask.EditMask = "n2";
            this.seHeight.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seHeight.Size = new System.Drawing.Size(160, 20);
            this.seHeight.TabIndex = 136;
            // 
            // AreaEditForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "AreaEditForm";
            this.Text = "库区明细";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leAreaType.Properties)).EndInit();
            this.tabPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcContact)).EndInit();
            this.gcContact.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seCoordY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCoordZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCoordX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seHeight.Properties)).EndInit();
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
        private System.Windows.Forms.Label lblAreaType;
        private DevExpress.XtraEditors.TextEdit txtAreaName;
        private System.Windows.Forms.Label lblAreaName;
        private DevExpress.XtraTab.XtraTabPage tabPosition;
        private DevExpress.XtraEditors.TextEdit txtAreaCode;
        private System.Windows.Forms.Label lblAreaCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtEditTime;
        private DevExpress.XtraEditors.TextEdit txtEditUser;
        private DevExpress.XtraEditors.TextEdit txtCreateTime;
        private DevExpress.XtraEditors.TextEdit txtCreateUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl gcContact;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCoordX;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblCoordY;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblCoordZ;
        private DevExpress.XtraEditors.SpinEdit seLength;
        private DevExpress.XtraEditors.SpinEdit seCoordY;
        private DevExpress.XtraEditors.SpinEdit seCoordZ;
        private DevExpress.XtraEditors.SpinEdit seCoordX;
        private DevExpress.XtraEditors.SpinEdit seWidth;
        private DevExpress.XtraEditors.SpinEdit seHeight;
        private DevExpress.XtraEditors.LookUpEdit leAreaType;




    }
}
