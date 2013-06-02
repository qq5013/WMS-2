namespace Modules.GroupModule.Views
{
    partial class GroupForm
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
            this.lblGroupLevel = new System.Windows.Forms.Label();
            this.txtGroupLevel = new DevExpress.XtraEditors.TextEdit();
            this.lblParentID = new System.Windows.Forms.Label();
            this.txtParentID = new DevExpress.XtraEditors.TextEdit();
            this.txtGroupCode = new DevExpress.XtraEditors.TextEdit();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new DevExpress.XtraEditors.TextEdit();
            this.grcOther = new DevExpress.XtraEditors.GroupControl();
            this.layoutOther = new System.Windows.Forms.TableLayoutPanel();
            this.lblRemark = new System.Windows.Forms.Label();
            this.cbIsActive = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.grcGroupUser = new DevExpress.XtraEditors.GroupControl();
            this.layoutGroupUser = new System.Windows.Forms.TableLayoutPanel();
            this.lbGroupUser = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.gcData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBase)).BeginInit();
            this.grcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOther)).BeginInit();
            this.grcOther.SuspendLayout();
            this.layoutOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcGroupUser)).BeginInit();
            this.grcGroupUser.SuspendLayout();
            this.layoutGroupUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbGroupUser)).BeginInit();
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
            this.grcBase.Size = new System.Drawing.Size(533, 155);
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
            this.layoutBase.Controls.Add(this.lblGroupLevel, 0, 0);
            this.layoutBase.Controls.Add(this.txtGroupLevel, 1, 0);
            this.layoutBase.Controls.Add(this.lblParentID, 0, 1);
            this.layoutBase.Controls.Add(this.txtParentID, 1, 1);
            this.layoutBase.Controls.Add(this.txtGroupCode, 1, 2);
            this.layoutBase.Controls.Add(this.lblGroupCode, 0, 2);
            this.layoutBase.Controls.Add(this.lblGroupName, 0, 3);
            this.layoutBase.Controls.Add(this.txtGroupName, 1, 3);
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
            this.layoutBase.Size = new System.Drawing.Size(509, 122);
            this.layoutBase.TabIndex = 128;
            // 
            // lblGroupLevel
            // 
            this.lblGroupLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblGroupLevel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGroupLevel.Location = new System.Drawing.Point(3, 0);
            this.lblGroupLevel.Name = "lblGroupLevel";
            this.lblGroupLevel.Size = new System.Drawing.Size(95, 23);
            this.lblGroupLevel.TabIndex = 69;
            this.lblGroupLevel.Text = "功能级别*：";
            this.lblGroupLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGroupLevel
            // 
            this.layoutBase.SetColumnSpan(this.txtGroupLevel, 2);
            this.txtGroupLevel.Enabled = false;
            this.txtGroupLevel.Location = new System.Drawing.Point(104, 3);
            this.txtGroupLevel.Name = "txtGroupLevel";
            this.txtGroupLevel.Properties.ReadOnly = true;
            this.txtGroupLevel.Size = new System.Drawing.Size(200, 20);
            this.txtGroupLevel.TabIndex = 0;
            // 
            // lblParentID
            // 
            this.lblParentID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblParentID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParentID.Location = new System.Drawing.Point(3, 28);
            this.lblParentID.Name = "lblParentID";
            this.lblParentID.Size = new System.Drawing.Size(81, 23);
            this.lblParentID.TabIndex = 74;
            this.lblParentID.Text = "父级功能*：";
            this.lblParentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParentID
            // 
            this.layoutBase.SetColumnSpan(this.txtParentID, 2);
            this.txtParentID.Enabled = false;
            this.txtParentID.Location = new System.Drawing.Point(104, 31);
            this.txtParentID.Name = "txtParentID";
            this.txtParentID.Properties.ReadOnly = true;
            this.txtParentID.Size = new System.Drawing.Size(200, 20);
            this.txtParentID.TabIndex = 1;
            // 
            // txtGroupCode
            // 
            this.layoutBase.SetColumnSpan(this.txtGroupCode, 2);
            this.txtGroupCode.Location = new System.Drawing.Point(104, 59);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Properties.MaxLength = 30;
            this.txtGroupCode.Size = new System.Drawing.Size(200, 20);
            this.txtGroupCode.TabIndex = 2;
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblGroupCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGroupCode.Location = new System.Drawing.Point(3, 56);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(81, 23);
            this.lblGroupCode.TabIndex = 73;
            this.lblGroupCode.Text = "用户组代码*：";
            this.lblGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroupName
            // 
            this.lblGroupName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblGroupName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGroupName.Location = new System.Drawing.Point(3, 84);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(81, 23);
            this.lblGroupName.TabIndex = 76;
            this.lblGroupName.Text = "用户组名称*：";
            this.lblGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGroupName
            // 
            this.layoutBase.SetColumnSpan(this.txtGroupName, 2);
            this.txtGroupName.Location = new System.Drawing.Point(104, 87);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Properties.MaxLength = 30;
            this.txtGroupName.Size = new System.Drawing.Size(200, 20);
            this.txtGroupName.TabIndex = 3;
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
            this.grcGroupUser.Controls.Add(this.layoutGroupUser);
            this.grcGroupUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcGroupUser.Location = new System.Drawing.Point(6, 180);
            this.grcGroupUser.LookAndFeel.SkinName = "Lilian";
            this.grcGroupUser.Name = "grcGroupUser";
            this.grcGroupUser.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grcGroupUser.Size = new System.Drawing.Size(533, 251);
            this.grcGroupUser.TabIndex = 71;
            this.grcGroupUser.Text = "成员信息";
            // 
            // layoutGroupUser
            // 
            this.layoutGroupUser.ColumnCount = 1;
            this.layoutGroupUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutGroupUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutGroupUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutGroupUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutGroupUser.Controls.Add(this.lbGroupUser, 0, 0);
            this.layoutGroupUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutGroupUser.Location = new System.Drawing.Point(12, 31);
            this.layoutGroupUser.Name = "layoutGroupUser";
            this.layoutGroupUser.RowCount = 1;
            this.layoutGroupUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutGroupUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutGroupUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutGroupUser.Size = new System.Drawing.Size(509, 208);
            this.layoutGroupUser.TabIndex = 129;
            // 
            // lbGroupUser
            // 
            this.lbGroupUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGroupUser.Location = new System.Drawing.Point(3, 3);
            this.lbGroupUser.MultiColumn = true;
            this.lbGroupUser.Name = "lbGroupUser";
            this.lbGroupUser.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbGroupUser.Size = new System.Drawing.Size(503, 202);
            this.lbGroupUser.TabIndex = 0;
            this.lbGroupUser.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lbGroupUser_ItemCheck);
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CurrentDataState = Framework.UI.Template.Common.DataState.Read;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GroupForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.gcData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcBase)).EndInit();
            this.grcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOther)).EndInit();
            this.grcOther.ResumeLayout(false);
            this.layoutOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcGroupUser)).EndInit();
            this.grcGroupUser.ResumeLayout(false);
            this.layoutGroupUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbGroupUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private DevExpress.XtraEditors.TextEdit txtGroupCode;
        private System.Windows.Forms.Label lblGroupLevel;
        private System.Windows.Forms.Label lblGroupCode;
        private DevExpress.XtraEditors.TextEdit txtGroupLevel;
        private System.Windows.Forms.Label lblParentID;
        private DevExpress.XtraEditors.TextEdit txtParentID;
        private DevExpress.XtraEditors.GroupControl grcOther;
        private System.Windows.Forms.TableLayoutPanel layoutOther;
        private System.Windows.Forms.Label lblRemark;
        private DevExpress.XtraEditors.ComboBoxEdit cbIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private System.Windows.Forms.Label lblGroupName;
        private DevExpress.XtraEditors.TextEdit txtGroupName;
        private DevExpress.XtraEditors.GroupControl grcGroupUser;
        private System.Windows.Forms.TableLayoutPanel layoutGroupUser;
        private DevExpress.XtraEditors.CheckedListBoxControl lbGroupUser;

    }
}
