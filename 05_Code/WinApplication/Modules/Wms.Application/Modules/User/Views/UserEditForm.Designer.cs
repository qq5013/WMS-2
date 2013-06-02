namespace Modules.UserModule.Views
{
    partial class UserEditForm
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
            this.tabUser = new DevExpress.XtraTab.XtraTabPage();
            this.gcOther = new DevExpress.XtraEditors.GroupControl();
            this.layoutOther = new System.Windows.Forms.TableLayoutPanel();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.cbIsActive = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcBase = new DevExpress.XtraEditors.GroupControl();
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.txtLoginTime = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserCode = new DevExpress.XtraEditors.TextEdit();
            this.lblUserCode = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblPasswordAgain = new System.Windows.Forms.Label();
            this.txtPasswordAgain = new DevExpress.XtraEditors.TextEdit();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.txtCreateTime = new DevExpress.XtraEditors.TextEdit();
            this.lblLoginTime = new System.Windows.Forms.Label();
            this.tabRole = new DevExpress.XtraTab.XtraTabPage();
            this.lvRole = new System.Windows.Forms.ListView();
            this.tabFunction = new DevExpress.XtraTab.XtraTabPage();
            this.tvAuthority = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).BeginInit();
            this.gcClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOther)).BeginInit();
            this.gcOther.SuspendLayout();
            this.layoutOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordAgain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateTime.Properties)).BeginInit();
            this.tabRole.SuspendLayout();
            this.tabFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcClientZone
            // 
            this.gcClientZone.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.gcClientZone.Appearance.Options.UseBackColor = true;
            this.gcClientZone.Controls.Add(this.tcDetail);
            // 
            // tcDetail
            // 
            this.tcDetail.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetail.Location = new System.Drawing.Point(5, 5);
            this.tcDetail.Name = "tcDetail";
            this.tcDetail.PaintStyleName = "Skin";
            this.tcDetail.SelectedTabPage = this.tabUser;
            this.tcDetail.Size = new System.Drawing.Size(624, 422);
            this.tcDetail.TabIndex = 0;
            this.tcDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabUser,
            this.tabRole,
            this.tabFunction});
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.gcOther);
            this.tabUser.Controls.Add(this.gcBase);
            this.tabUser.Name = "tabUser";
            this.tabUser.Size = new System.Drawing.Size(618, 394);
            this.tabUser.Text = "用户信息";
            // 
            // gcOther
            // 
            this.gcOther.Controls.Add(this.layoutOther);
            this.gcOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOther.Location = new System.Drawing.Point(0, 133);
            this.gcOther.Name = "gcOther";
            this.gcOther.Padding = new System.Windows.Forms.Padding(10);
            this.gcOther.Size = new System.Drawing.Size(618, 261);
            this.gcOther.TabIndex = 0;
            this.gcOther.Text = "其它信息";
            // 
            // layoutOther
            // 
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutOther.Controls.Add(this.lblRemark, 0, 0);
            this.layoutOther.Controls.Add(this.txtRemark, 1, 0);
            this.layoutOther.Controls.Add(this.lblIsActive, 0, 2);
            this.layoutOther.Controls.Add(this.cbIsActive, 1, 2);
            this.layoutOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutOther.Location = new System.Drawing.Point(12, 31);
            this.layoutOther.Name = "layoutOther";
            this.layoutOther.RowCount = 3;
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutOther.Size = new System.Drawing.Size(594, 218);
            this.layoutOther.TabIndex = 0;
            // 
            // lblRemark
            // 
            this.lblRemark.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRemark.Location = new System.Drawing.Point(3, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(112, 20);
            this.lblRemark.TabIndex = 0;
            this.lblRemark.Text = "描述：";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemark
            // 
            this.layoutOther.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Location = new System.Drawing.Point(121, 3);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.MaxLength = 250;
            this.layoutOther.SetRowSpan(this.txtRemark, 2);
            this.txtRemark.Size = new System.Drawing.Size(461, 50);
            this.txtRemark.TabIndex = 2;
            // 
            // lblIsActive
            // 
            this.lblIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblIsActive.Location = new System.Drawing.Point(3, 56);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(112, 23);
            this.lblIsActive.TabIndex = 3;
            this.lblIsActive.Text = "是否可用*：";
            this.lblIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cbIsActive.TabIndex = 4;
            // 
            // gcBase
            // 
            this.gcBase.Controls.Add(this.layoutBase);
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.LookAndFeel.SkinName = "Lilian";
            this.gcBase.Name = "gcBase";
            this.gcBase.Padding = new System.Windows.Forms.Padding(10);
            this.gcBase.Size = new System.Drawing.Size(618, 133);
            this.gcBase.TabIndex = 1;
            this.gcBase.Text = "基本信息";
            // 
            // layoutBase
            // 
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.Controls.Add(this.txtLoginTime, 3, 2);
            this.layoutBase.Controls.Add(this.txtUserName, 3, 0);
            this.layoutBase.Controls.Add(this.txtUserCode, 1, 0);
            this.layoutBase.Controls.Add(this.lblUserCode, 0, 0);
            this.layoutBase.Controls.Add(this.lblUserName, 2, 0);
            this.layoutBase.Controls.Add(this.lblPassword, 0, 1);
            this.layoutBase.Controls.Add(this.txtPassword, 1, 1);
            this.layoutBase.Controls.Add(this.lblPasswordAgain, 2, 1);
            this.layoutBase.Controls.Add(this.txtPasswordAgain, 3, 1);
            this.layoutBase.Controls.Add(this.lblCreateTime, 0, 2);
            this.layoutBase.Controls.Add(this.txtCreateTime, 1, 2);
            this.layoutBase.Controls.Add(this.lblLoginTime, 2, 2);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 1;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.Size = new System.Drawing.Size(594, 87);
            this.layoutBase.TabIndex = 0;
            // 
            // txtLoginTime
            // 
            this.txtLoginTime.Enabled = false;
            this.txtLoginTime.Location = new System.Drawing.Point(417, 59);
            this.txtLoginTime.Name = "txtLoginTime";
            this.txtLoginTime.Properties.ReadOnly = true;
            this.txtLoginTime.Size = new System.Drawing.Size(165, 20);
            this.txtLoginTime.TabIndex = 32;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(417, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.MaxLength = 30;
            this.txtUserName.Size = new System.Drawing.Size(165, 20);
            this.txtUserName.TabIndex = 31;
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(121, 3);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Properties.MaxLength = 30;
            this.txtUserCode.Size = new System.Drawing.Size(165, 20);
            this.txtUserCode.TabIndex = 30;
            // 
            // lblUserCode
            // 
            this.lblUserCode.Location = new System.Drawing.Point(3, 0);
            this.lblUserCode.Name = "lblUserCode";
            this.lblUserCode.Size = new System.Drawing.Size(112, 20);
            this.lblUserCode.TabIndex = 28;
            this.lblUserCode.Text = "用户代码*：";
            this.lblUserCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(299, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(112, 20);
            this.lblUserName.TabIndex = 29;
            this.lblUserName.Text = "用户名称*：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPassword.Location = new System.Drawing.Point(3, 28);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(112, 20);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "口令*：";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(121, 31);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.MaxLength = 100;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(165, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPasswordAgain
            // 
            this.lblPasswordAgain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPasswordAgain.Location = new System.Drawing.Point(299, 28);
            this.lblPasswordAgain.Name = "lblPasswordAgain";
            this.lblPasswordAgain.Size = new System.Drawing.Size(112, 20);
            this.lblPasswordAgain.TabIndex = 5;
            this.lblPasswordAgain.Text = "校验口令*：";
            this.lblPasswordAgain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPasswordAgain
            // 
            this.txtPasswordAgain.Location = new System.Drawing.Point(417, 31);
            this.txtPasswordAgain.Name = "txtPasswordAgain";
            this.txtPasswordAgain.Properties.MaxLength = 100;
            this.txtPasswordAgain.Properties.PasswordChar = '*';
            this.txtPasswordAgain.Size = new System.Drawing.Size(165, 20);
            this.txtPasswordAgain.TabIndex = 8;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCreateTime.Location = new System.Drawing.Point(3, 56);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(112, 20);
            this.lblCreateTime.TabIndex = 27;
            this.lblCreateTime.Text = "创建时间：";
            this.lblCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Enabled = false;
            this.txtCreateTime.Location = new System.Drawing.Point(121, 59);
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.Properties.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(165, 20);
            this.txtCreateTime.TabIndex = 17;
            // 
            // lblLoginTime
            // 
            this.lblLoginTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLoginTime.Location = new System.Drawing.Point(299, 56);
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.Size = new System.Drawing.Size(112, 20);
            this.lblLoginTime.TabIndex = 23;
            this.lblLoginTime.Text = "登录时间：";
            this.lblLoginTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabRole
            // 
            this.tabRole.Controls.Add(this.lvRole);
            this.tabRole.Name = "tabRole";
            this.tabRole.PageVisible = false;
            this.tabRole.Size = new System.Drawing.Size(618, 394);
            this.tabRole.Text = "隶属角色";
            // 
            // lvRole
            // 
            this.lvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRole.FullRowSelect = true;
            this.lvRole.GridLines = true;
            this.lvRole.Location = new System.Drawing.Point(0, 0);
            this.lvRole.Name = "lvRole";
            this.lvRole.Size = new System.Drawing.Size(618, 394);
            this.lvRole.TabIndex = 0;
            this.lvRole.UseCompatibleStateImageBehavior = false;
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.tvAuthority);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.PageVisible = false;
            this.tabFunction.Size = new System.Drawing.Size(618, 394);
            this.tabFunction.Text = "访问功能";
            // 
            // tvAuthority
            // 
            this.tvAuthority.CheckBoxes = true;
            this.tvAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAuthority.Location = new System.Drawing.Point(0, 0);
            this.tvAuthority.Name = "tvAuthority";
            this.tvAuthority.Size = new System.Drawing.Size(618, 394);
            this.tvAuthority.TabIndex = 0;
            // 
            // UserEditForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "UserEditForm";
            this.Text = "用户明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).EndInit();
            this.gcClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOther)).EndInit();
            this.gcOther.ResumeLayout(false);
            this.layoutOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordAgain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateTime.Properties)).EndInit();
            this.tabRole.ResumeLayout(false);
            this.tabFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabUser;
        private DevExpress.XtraEditors.GroupControl gcOther;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblIsActive;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private DevExpress.XtraEditors.TextEdit txtCreateTime;
        private DevExpress.XtraEditors.TextEdit txtPasswordAgain;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private System.Windows.Forms.Label lblLoginTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblPasswordAgain;
        private System.Windows.Forms.Label lblPassword;
        private DevExpress.XtraTab.XtraTabPage tabFunction;
        private System.Windows.Forms.TreeView tvAuthority;
        private DevExpress.XtraTab.XtraTabPage tabRole;
        private System.Windows.Forms.ListView lvRole;
        private System.Windows.Forms.TableLayoutPanel layoutOther;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private DevExpress.XtraEditors.ComboBoxEdit cbIsActive;
        private System.Windows.Forms.Label lblUserCode;
        private System.Windows.Forms.Label lblUserName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtUserCode;
        private DevExpress.XtraEditors.TextEdit txtLoginTime;




    }
}
