namespace Modules.WarehouseModule.Views
{
    partial class WarehouseEditForm
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
            this.tabWarehouse = new DevExpress.XtraTab.XtraTabPage();
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
            this.cbIsBonded = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblAcreage = new System.Windows.Forms.Label();
            this.lblIsbonded = new System.Windows.Forms.Label();
            this.txtWarehouseCode = new DevExpress.XtraEditors.TextEdit();
            this.lblWarehouseCode = new System.Windows.Forms.Label();
            this.txtWarehouseName = new DevExpress.XtraEditors.TextEdit();
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.seAcreage = new DevExpress.XtraEditors.SpinEdit();
            this.tabContact = new DevExpress.XtraTab.XtraTabPage();
            this.gcContact = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCountyId = new System.Windows.Forms.Label();
            this.beCountryId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtPostalCode = new DevExpress.XtraEditors.TextEdit();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.lblFaxNumber = new System.Windows.Forms.Label();
            this.txtFaxNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblContactor = new System.Windows.Forms.Label();
            this.txtContactor = new DevExpress.XtraEditors.TextEdit();
            this.tabWarehouseUser = new DevExpress.XtraTab.XtraTabPage();
            this.btnRemoveUser = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsertUser = new DevExpress.XtraEditors.SimpleButton();
            this.lbUsers = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).BeginInit();
            this.gcClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabWarehouse.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.cbIsBonded.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAcreage.Properties)).BeginInit();
            this.tabContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcContact)).BeginInit();
            this.gcContact.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beCountryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaxNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactor.Properties)).BeginInit();
            this.tabWarehouseUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbUsers)).BeginInit();
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
            this.tcDetail.SelectedTabPage = this.tabWarehouse;
            this.tcDetail.Size = new System.Drawing.Size(624, 422);
            this.tcDetail.TabIndex = 70;
            this.tcDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabWarehouse,
            this.tabContact,
            this.tabWarehouseUser});
            // 
            // tabWarehouse
            // 
            this.tabWarehouse.Controls.Add(this.gcOther);
            this.tabWarehouse.Controls.Add(this.gcBase);
            this.tabWarehouse.Name = "tabWarehouse";
            this.tabWarehouse.Size = new System.Drawing.Size(618, 394);
            this.tabWarehouse.Text = "仓库信息";
            // 
            // gcOther
            // 
            this.gcOther.Controls.Add(this.layoutOther);
            this.gcOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOther.Location = new System.Drawing.Point(0, 97);
            this.gcOther.LookAndFeel.SkinName = "Lilian";
            this.gcOther.Name = "gcOther";
            this.gcOther.Padding = new System.Windows.Forms.Padding(10);
            this.gcOther.Size = new System.Drawing.Size(618, 297);
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
            this.gcBase.Size = new System.Drawing.Size(618, 97);
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
            this.layoutBase.Controls.Add(this.cbIsBonded, 1, 1);
            this.layoutBase.Controls.Add(this.lblAcreage, 2, 1);
            this.layoutBase.Controls.Add(this.lblIsbonded, 0, 1);
            this.layoutBase.Controls.Add(this.txtWarehouseCode, 1, 0);
            this.layoutBase.Controls.Add(this.lblWarehouseCode, 0, 0);
            this.layoutBase.Controls.Add(this.txtWarehouseName, 3, 0);
            this.layoutBase.Controls.Add(this.lblWarehouseName, 2, 0);
            this.layoutBase.Controls.Add(this.seAcreage, 3, 1);
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
            // cbIsBonded
            // 
            this.cbIsBonded.Location = new System.Drawing.Point(121, 31);
            this.cbIsBonded.Name = "cbIsBonded";
            this.cbIsBonded.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbIsBonded.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbIsBonded.Size = new System.Drawing.Size(165, 20);
            this.cbIsBonded.TabIndex = 135;
            // 
            // lblAcreage
            // 
            this.lblAcreage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAcreage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAcreage.Location = new System.Drawing.Point(299, 28);
            this.lblAcreage.Name = "lblAcreage";
            this.lblAcreage.Size = new System.Drawing.Size(101, 23);
            this.lblAcreage.TabIndex = 73;
            this.lblAcreage.Text = "面积(平方米)：";
            this.lblAcreage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIsbonded
            // 
            this.lblIsbonded.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblIsbonded.Location = new System.Drawing.Point(3, 28);
            this.lblIsbonded.Name = "lblIsbonded";
            this.lblIsbonded.Size = new System.Drawing.Size(90, 23);
            this.lblIsbonded.TabIndex = 130;
            this.lblIsbonded.Text = "是否保税：";
            this.lblIsbonded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWarehouseCode
            // 
            this.txtWarehouseCode.Location = new System.Drawing.Point(121, 3);
            this.txtWarehouseCode.Name = "txtWarehouseCode";
            this.txtWarehouseCode.Properties.MaxLength = 2;
            this.txtWarehouseCode.Size = new System.Drawing.Size(165, 20);
            this.txtWarehouseCode.TabIndex = 0;
            // 
            // lblWarehouseCode
            // 
            this.lblWarehouseCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWarehouseCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWarehouseCode.Location = new System.Drawing.Point(3, 0);
            this.lblWarehouseCode.Name = "lblWarehouseCode";
            this.lblWarehouseCode.Size = new System.Drawing.Size(81, 23);
            this.lblWarehouseCode.TabIndex = 129;
            this.lblWarehouseCode.Text = "仓库代码*：";
            this.lblWarehouseCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.Location = new System.Drawing.Point(417, 3);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Properties.MaxLength = 100;
            this.txtWarehouseName.Size = new System.Drawing.Size(165, 20);
            this.txtWarehouseName.TabIndex = 1;
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWarehouseName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWarehouseName.Location = new System.Drawing.Point(299, 0);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new System.Drawing.Size(81, 23);
            this.lblWarehouseName.TabIndex = 69;
            this.lblWarehouseName.Text = "仓库名称*：";
            this.lblWarehouseName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seAcreage
            // 
            this.seAcreage.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAcreage.Location = new System.Drawing.Point(417, 31);
            this.seAcreage.Name = "seAcreage";
            this.seAcreage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seAcreage.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.seAcreage.Size = new System.Drawing.Size(165, 20);
            this.seAcreage.TabIndex = 136;
            // 
            // tabContact
            // 
            this.tabContact.Controls.Add(this.gcContact);
            this.tabContact.Name = "tabContact";
            this.tabContact.Size = new System.Drawing.Size(618, 394);
            this.tabContact.Text = "联系信息";
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
            this.tableLayoutPanel1.Controls.Add(this.lblCountyId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.beCountryId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPostalCode, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPostalCode, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAddress, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPhone, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPhone, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFaxNumber, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtFaxNumber, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblContactor, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtContactor, 1, 3);
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
            // lblCountyId
            // 
            this.lblCountyId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCountyId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCountyId.Location = new System.Drawing.Point(3, 0);
            this.lblCountyId.Name = "lblCountyId";
            this.lblCountyId.Size = new System.Drawing.Size(81, 23);
            this.lblCountyId.TabIndex = 137;
            this.lblCountyId.Text = "地区：";
            this.lblCountyId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // beCountryId
            // 
            this.beCountryId.Location = new System.Drawing.Point(121, 3);
            this.beCountryId.Name = "beCountryId";
            this.beCountryId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beCountryId.Size = new System.Drawing.Size(165, 20);
            this.beCountryId.TabIndex = 138;
            this.beCountryId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beCountryId_ButtonClick);
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPostalCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPostalCode.Location = new System.Drawing.Point(299, 0);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(81, 23);
            this.lblPostalCode.TabIndex = 73;
            this.lblPostalCode.Text = "邮编：";
            this.lblPostalCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(417, 3);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Properties.MaxLength = 20;
            this.txtPostalCode.Size = new System.Drawing.Size(165, 20);
            this.txtPostalCode.TabIndex = 16;
            // 
            // lblAddress
            // 
            this.lblAddress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAddress.Location = new System.Drawing.Point(3, 28);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(81, 23);
            this.lblAddress.TabIndex = 133;
            this.lblAddress.Text = "公司地址：";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtAddress, 3);
            this.txtAddress.Location = new System.Drawing.Point(121, 31);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.MaxLength = 250;
            this.txtAddress.Size = new System.Drawing.Size(461, 20);
            this.txtAddress.TabIndex = 17;
            // 
            // lblPhone
            // 
            this.lblPhone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPhone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPhone.Location = new System.Drawing.Point(3, 56);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(81, 23);
            this.lblPhone.TabIndex = 134;
            this.lblPhone.Text = "电话号码：";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(121, 59);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.MaxLength = 20;
            this.txtPhone.Size = new System.Drawing.Size(165, 20);
            this.txtPhone.TabIndex = 18;
            // 
            // lblFaxNumber
            // 
            this.lblFaxNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblFaxNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFaxNumber.Location = new System.Drawing.Point(299, 56);
            this.lblFaxNumber.Name = "lblFaxNumber";
            this.lblFaxNumber.Size = new System.Drawing.Size(81, 23);
            this.lblFaxNumber.TabIndex = 134;
            this.lblFaxNumber.Text = "传真号码：";
            this.lblFaxNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFaxNumber
            // 
            this.txtFaxNumber.Location = new System.Drawing.Point(417, 59);
            this.txtFaxNumber.Name = "txtFaxNumber";
            this.txtFaxNumber.Properties.MaxLength = 20;
            this.txtFaxNumber.Size = new System.Drawing.Size(165, 20);
            this.txtFaxNumber.TabIndex = 19;
            // 
            // lblContactor
            // 
            this.lblContactor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblContactor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblContactor.Location = new System.Drawing.Point(3, 84);
            this.lblContactor.Name = "lblContactor";
            this.lblContactor.Size = new System.Drawing.Size(81, 23);
            this.lblContactor.TabIndex = 134;
            this.lblContactor.Text = "联系人：";
            this.lblContactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContactor
            // 
            this.txtContactor.Location = new System.Drawing.Point(121, 87);
            this.txtContactor.Name = "txtContactor";
            this.txtContactor.Properties.MaxLength = 20;
            this.txtContactor.Size = new System.Drawing.Size(165, 20);
            this.txtContactor.TabIndex = 20;
            // 
            // tabWarehouseUser
            // 
            this.tabWarehouseUser.Controls.Add(this.btnRemoveUser);
            this.tabWarehouseUser.Controls.Add(this.btnInsertUser);
            this.tabWarehouseUser.Controls.Add(this.lbUsers);
            this.tabWarehouseUser.Name = "tabWarehouseUser";
            this.tabWarehouseUser.Padding = new System.Windows.Forms.Padding(10);
            this.tabWarehouseUser.Size = new System.Drawing.Size(618, 394);
            this.tabWarehouseUser.Text = "仓库用户";
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(530, 351);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveUser.TabIndex = 2;
            this.btnRemoveUser.Text = "移除";
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnInsertUser
            // 
            this.btnInsertUser.Location = new System.Drawing.Point(530, 322);
            this.btnInsertUser.Name = "btnInsertUser";
            this.btnInsertUser.Size = new System.Drawing.Size(75, 23);
            this.btnInsertUser.TabIndex = 1;
            this.btnInsertUser.Text = "加入";
            this.btnInsertUser.Click += new System.EventHandler(this.btnInsertUser_Click);
            // 
            // lbUsers
            // 
            this.lbUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbUsers.Location = new System.Drawing.Point(10, 10);
            this.lbUsers.MultiColumn = true;
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(509, 374);
            this.lbUsers.TabIndex = 0;
            // 
            // WarehouseEditForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "WarehouseEditForm";
            this.Text = "仓库明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).EndInit();
            this.gcClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabWarehouse.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.cbIsBonded.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAcreage.Properties)).EndInit();
            this.tabContact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcContact)).EndInit();
            this.gcContact.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beCountryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaxNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactor.Properties)).EndInit();
            this.tabWarehouseUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabWarehouse;
        private DevExpress.XtraEditors.GroupControl gcOther;
        private System.Windows.Forms.TableLayoutPanel layoutOther;
        private System.Windows.Forms.Label lblRemark;
        private DevExpress.XtraEditors.ComboBoxEdit cbIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblAcreage;
        private DevExpress.XtraEditors.TextEdit txtWarehouseName;
        private System.Windows.Forms.Label lblWarehouseName;
        private DevExpress.XtraTab.XtraTabPage tabContact;
        private DevExpress.XtraEditors.TextEdit txtWarehouseCode;
        private System.Windows.Forms.Label lblWarehouseCode;
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
        private DevExpress.XtraEditors.TextEdit txtPostalCode;
        private System.Windows.Forms.Label lblPostalCode;
        private DevExpress.XtraEditors.TextEdit txtFaxNumber;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private System.Windows.Forms.Label lblContactor;
        private System.Windows.Forms.Label lblFaxNumber;
        private System.Windows.Forms.Label lblPhone;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private DevExpress.XtraEditors.TextEdit txtContactor;
        private DevExpress.XtraEditors.ComboBoxEdit cbIsBonded;
        private System.Windows.Forms.Label lblIsbonded;
        private System.Windows.Forms.Label lblCountyId;
        private DevExpress.XtraEditors.ButtonEdit beCountryId;
        private DevExpress.XtraTab.XtraTabPage tabWarehouseUser;
        private DevExpress.XtraEditors.SpinEdit seAcreage;
        private DevExpress.XtraEditors.SimpleButton btnRemoveUser;
        private DevExpress.XtraEditors.SimpleButton btnInsertUser;
        private DevExpress.XtraEditors.ListBoxControl lbUsers;




    }
}
