namespace Modules.RoleModule.Views
{
    partial class RoleForm
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
            this.grcBase = new DevExpress.XtraEditors.GroupControl();
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.lblRoleCode = new System.Windows.Forms.Label();
            this.txtRoleCode = new DevExpress.XtraEditors.TextEdit();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.txtRoleName = new DevExpress.XtraEditors.TextEdit();
            this.grcOther = new DevExpress.XtraEditors.GroupControl();
            this.layoutOther = new System.Windows.Forms.TableLayoutPanel();
            this.lblRemark = new System.Windows.Forms.Label();
            this.cbIsActive = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.grcGroupUser = new DevExpress.XtraEditors.GroupControl();
            this.tabRoleDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tabUser = new DevExpress.XtraTab.XtraTabPage();
            this.layoutGroupUser = new System.Windows.Forms.TableLayoutPanel();
            this.lbRoleUser = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tabGroup = new DevExpress.XtraTab.XtraTabPage();
            this.tlGroup = new DevExpress.XtraTreeList.TreeList();
            this.colGroup = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tabFunction = new DevExpress.XtraTab.XtraTabPage();
            this.tlFunction = new DevExpress.XtraTreeList.TreeList();
            this.colFunction = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.gcData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBase)).BeginInit();
            this.grcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOther)).BeginInit();
            this.grcOther.SuspendLayout();
            this.layoutOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcGroupUser)).BeginInit();
            this.grcGroupUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabRoleDetails)).BeginInit();
            this.tabRoleDetails.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.layoutGroupUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbRoleUser)).BeginInit();
            this.tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlGroup)).BeginInit();
            this.tabFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlFunction)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // gcTree
            // 
            this.gcTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // gcData
            // 
            this.gcData.Controls.Add(this.grcGroupUser);
            this.gcData.Controls.Add(this.grcOther);
            this.gcData.Controls.Add(this.grcBase);
            this.gcData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcData.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // grcBase
            // 
            this.grcBase.Controls.Add(this.layoutBase);
            this.grcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.grcBase.Location = new System.Drawing.Point(6, 25);
            this.grcBase.LookAndFeel.SkinName = "Lilian";
            this.grcBase.Name = "grcBase";
            this.grcBase.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grcBase.Size = new System.Drawing.Size(533, 98);
            this.grcBase.TabIndex = 68;
            this.grcBase.Text = "基本信息";
            // 
            // layoutBase
            // 
            this.layoutBase.ColumnCount = 4;
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.Controls.Add(this.lblRoleCode, 0, 0);
            this.layoutBase.Controls.Add(this.txtRoleCode, 1, 0);
            this.layoutBase.Controls.Add(this.lblRoleName, 0, 1);
            this.layoutBase.Controls.Add(this.txtRoleName, 1, 1);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 7;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.Size = new System.Drawing.Size(509, 64);
            this.layoutBase.TabIndex = 128;
            // 
            // lblRoleCode
            // 
            this.lblRoleCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRoleCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRoleCode.Location = new System.Drawing.Point(3, 0);
            this.lblRoleCode.Name = "lblRoleCode";
            this.lblRoleCode.Size = new System.Drawing.Size(81, 23);
            this.lblRoleCode.TabIndex = 73;
            this.lblRoleCode.Text = "角色代码*：";
            this.lblRoleCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRoleCode
            // 
            this.layoutBase.SetColumnSpan(this.txtRoleCode, 2);
            this.txtRoleCode.Location = new System.Drawing.Point(104, 3);
            this.txtRoleCode.Name = "txtRoleCode";
            this.txtRoleCode.Properties.MaxLength = 30;
            this.txtRoleCode.Size = new System.Drawing.Size(200, 20);
            this.txtRoleCode.TabIndex = 2;
            // 
            // lblRoleName
            // 
            this.lblRoleName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRoleName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRoleName.Location = new System.Drawing.Point(3, 28);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(81, 23);
            this.lblRoleName.TabIndex = 76;
            this.lblRoleName.Text = "角色名称*：";
            this.lblRoleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRoleName
            // 
            this.layoutBase.SetColumnSpan(this.txtRoleName, 2);
            this.txtRoleName.Location = new System.Drawing.Point(104, 31);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Properties.MaxLength = 30;
            this.txtRoleName.Size = new System.Drawing.Size(200, 20);
            this.txtRoleName.TabIndex = 3;
            // 
            // grcOther
            // 
            this.grcOther.Controls.Add(this.layoutOther);
            this.grcOther.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grcOther.Location = new System.Drawing.Point(6, 431);
            this.grcOther.LookAndFeel.SkinName = "Lilian";
            this.grcOther.Name = "grcOther";
            this.grcOther.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grcOther.Size = new System.Drawing.Size(533, 130);
            this.grcOther.TabIndex = 70;
            this.grcOther.Text = "其它信息";
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
            this.layoutOther.Size = new System.Drawing.Size(509, 84);
            this.layoutOther.TabIndex = 129;
            // 
            // lblRemark
            // 
            this.lblRemark.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRemark.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRemark.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRemark.Location = new System.Drawing.Point(3, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(95, 23);
            this.lblRemark.TabIndex = 126;
            this.lblRemark.Text = "描述：";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIsActive
            // 
            this.layoutOther.SetColumnSpan(this.cbIsActive, 2);
            this.cbIsActive.Location = new System.Drawing.Point(104, 59);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbIsActive.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbIsActive.Size = new System.Drawing.Size(200, 20);
            this.cbIsActive.TabIndex = 6;
            // 
            // lblIsActive
            // 
            this.lblIsActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblIsActive.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIsActive.Location = new System.Drawing.Point(3, 56);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(95, 23);
            this.lblIsActive.TabIndex = 75;
            this.lblIsActive.Text = "是否可用*：";
            this.lblIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemark
            // 
            this.layoutOther.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Location = new System.Drawing.Point(104, 3);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.MaxLength = 250;
            this.txtRemark.Size = new System.Drawing.Size(200, 50);
            this.txtRemark.TabIndex = 5;
            // 
            // grcGroupUser
            // 
            this.grcGroupUser.Controls.Add(this.tabRoleDetails);
            this.grcGroupUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcGroupUser.Location = new System.Drawing.Point(6, 123);
            this.grcGroupUser.LookAndFeel.SkinName = "Lilian";
            this.grcGroupUser.Name = "grcGroupUser";
            this.grcGroupUser.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grcGroupUser.Size = new System.Drawing.Size(533, 308);
            this.grcGroupUser.TabIndex = 71;
            this.grcGroupUser.Text = "成员信息";
            // 
            // tabRoleDetails
            // 
            this.tabRoleDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRoleDetails.Location = new System.Drawing.Point(12, 31);
            this.tabRoleDetails.Name = "tabRoleDetails";
            this.tabRoleDetails.SelectedTabPage = this.tabUser;
            this.tabRoleDetails.Size = new System.Drawing.Size(509, 265);
            this.tabRoleDetails.TabIndex = 130;
            this.tabRoleDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabUser,
            this.tabGroup,
            this.tabFunction});
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.layoutGroupUser);
            this.tabUser.Name = "tabUser";
            this.tabUser.Size = new System.Drawing.Size(503, 237);
            this.tabUser.Text = "角色用户";
            // 
            // layoutGroupUser
            // 
            this.layoutGroupUser.ColumnCount = 1;
            this.layoutGroupUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutGroupUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutGroupUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutGroupUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutGroupUser.Controls.Add(this.lbRoleUser, 0, 0);
            this.layoutGroupUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutGroupUser.Location = new System.Drawing.Point(0, 0);
            this.layoutGroupUser.Name = "layoutGroupUser";
            this.layoutGroupUser.RowCount = 1;
            this.layoutGroupUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutGroupUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.layoutGroupUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.layoutGroupUser.Size = new System.Drawing.Size(503, 237);
            this.layoutGroupUser.TabIndex = 130;
            // 
            // lbRoleUser
            // 
            this.lbRoleUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoleUser.Location = new System.Drawing.Point(3, 3);
            this.lbRoleUser.MultiColumn = true;
            this.lbRoleUser.Name = "lbRoleUser";
            this.lbRoleUser.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbRoleUser.Size = new System.Drawing.Size(497, 231);
            this.lbRoleUser.TabIndex = 0;
            this.lbRoleUser.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lbRoleUser_ItemCheck);
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.tlGroup);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Size = new System.Drawing.Size(425, 139);
            this.tabGroup.Text = "角色用户组";
            // 
            // tlGroup
            // 
            this.tlGroup.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colGroup});
            this.tlGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlGroup.Location = new System.Drawing.Point(0, 0);
            this.tlGroup.Name = "tlGroup";
            this.tlGroup.OptionsPrint.UsePrintStyles = true;
            this.tlGroup.OptionsView.ShowCheckBoxes = true;
            this.tlGroup.Size = new System.Drawing.Size(425, 139);
            this.tlGroup.TabIndex = 0;
            this.tlGroup.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlGroup_AfterCheckNode);
            // 
            // colGroup
            // 
            this.colGroup.Caption = "用户组";
            this.colGroup.FieldName = "用户组";
            this.colGroup.MinWidth = 32;
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.tlFunction);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.Size = new System.Drawing.Size(425, 139);
            this.tabFunction.Text = "角色功能";
            // 
            // tlFunction
            // 
            this.tlFunction.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colFunction});
            this.tlFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlFunction.Location = new System.Drawing.Point(0, 0);
            this.tlFunction.Name = "tlFunction";
            this.tlFunction.OptionsPrint.UsePrintStyles = true;
            this.tlFunction.OptionsView.ShowCheckBoxes = true;
            this.tlFunction.Size = new System.Drawing.Size(425, 139);
            this.tlFunction.TabIndex = 1;
            this.tlFunction.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlFunction_AfterCheckNode);
            // 
            // colFunction
            // 
            this.colFunction.Caption = "功能";
            this.colFunction.FieldName = "功能";
            this.colFunction.MinWidth = 32;
            this.colFunction.Name = "colFunction";
            this.colFunction.Visible = true;
            this.colFunction.VisibleIndex = 0;
            // 
            // RoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CurrentDataState = Framework.UI.Template.Common.DataState.Read;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RoleForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.gcData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcBase)).EndInit();
            this.grcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOther)).EndInit();
            this.grcOther.ResumeLayout(false);
            this.layoutOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcGroupUser)).EndInit();
            this.grcGroupUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabRoleDetails)).EndInit();
            this.tabRoleDetails.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.layoutGroupUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbRoleUser)).EndInit();
            this.tabGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlGroup)).EndInit();
            this.tabFunction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlFunction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private DevExpress.XtraEditors.TextEdit txtRoleCode;
        private System.Windows.Forms.Label lblRoleCode;
        private DevExpress.XtraEditors.GroupControl grcOther;
        private System.Windows.Forms.TableLayoutPanel layoutOther;
        private System.Windows.Forms.Label lblRemark;
        private DevExpress.XtraEditors.ComboBoxEdit cbIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private System.Windows.Forms.Label lblRoleName;
        private DevExpress.XtraEditors.TextEdit txtRoleName;
        private DevExpress.XtraEditors.GroupControl grcGroupUser;
        private DevExpress.XtraTab.XtraTabControl tabRoleDetails;
        private DevExpress.XtraTab.XtraTabPage tabUser;
        private System.Windows.Forms.TableLayoutPanel layoutGroupUser;
        private DevExpress.XtraEditors.CheckedListBoxControl lbRoleUser;
        private DevExpress.XtraTab.XtraTabPage tabGroup;
        private DevExpress.XtraTab.XtraTabPage tabFunction;
        private DevExpress.XtraTreeList.TreeList tlGroup;
        private DevExpress.XtraTreeList.TreeList tlFunction;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFunction;

    }
}
