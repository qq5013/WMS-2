namespace Wms
{
    partial class LoginForm
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
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.imgWMS = new DevExpress.XtraEditors.PictureEdit();
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangePassword = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.grpInput = new DevExpress.XtraEditors.GroupControl();
            this.leWarehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserCode = new DevExpress.XtraEditors.TextEdit();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblUserCode = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgWMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpInput)).BeginInit();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.labelControl2);
            this.pnlTop.Controls.Add(this.labelControl1);
            this.pnlTop.Controls.Add(this.imgWMS);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10, 5, 5, 10);
            this.pnlTop.Size = new System.Drawing.Size(384, 65);
            this.pnlTop.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(255, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(117, 19);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Magic Stone Inc.";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(70, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 45);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "WMS";
            // 
            // imgWMS
            // 
            this.imgWMS.EditValue = global::Wms.Properties.Resources.MagicStone_Logo;
            this.imgWMS.Location = new System.Drawing.Point(12, 6);
            this.imgWMS.Name = "imgWMS";
            this.imgWMS.Size = new System.Drawing.Size(52, 52);
            this.imgWMS.TabIndex = 1;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.btnLogout);
            this.pnlFill.Controls.Add(this.btnChangePassword);
            this.pnlFill.Controls.Add(this.btnLogin);
            this.pnlFill.Controls.Add(this.grpInput);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 65);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Padding = new System.Windows.Forms.Padding(10, 5, 5, 10);
            this.pnlFill.Size = new System.Drawing.Size(384, 157);
            this.pnlFill.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(275, 99);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(97, 23);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "退出系统";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(275, 70);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(97, 23);
            this.btnChangePassword.TabIndex = 2;
            this.btnChangePassword.Text = "修改口令";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(275, 41);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(97, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "登录系统";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.leWarehouse);
            this.grpInput.Controls.Add(this.labelControl3);
            this.grpInput.Controls.Add(this.txtPassword);
            this.grpInput.Controls.Add(this.txtUserCode);
            this.grpInput.Controls.Add(this.lblPassword);
            this.grpInput.Controls.Add(this.lblUserCode);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpInput.Location = new System.Drawing.Point(12, 7);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(250, 138);
            this.grpInput.TabIndex = 0;
            this.grpInput.Text = "登录信息";
            // 
            // leWarehouse
            // 
            this.leWarehouse.Location = new System.Drawing.Point(84, 99);
            this.leWarehouse.Name = "leWarehouse";
            this.leWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leWarehouse.Properties.NullText = "";
            this.leWarehouse.Size = new System.Drawing.Size(151, 20);
            this.leWarehouse.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 102);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "登录仓库：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(84, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(151, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(84, 35);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(151, 20);
            this.txtUserCode.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(18, 69);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "登录口令：";
            // 
            // lblUserCode
            // 
            this.lblUserCode.Location = new System.Drawing.Point(18, 38);
            this.lblUserCode.Name = "lblUserCode";
            this.lblUserCode.Size = new System.Drawing.Size(60, 13);
            this.lblUserCode.TabIndex = 0;
            this.lblUserCode.Text = "用户代码：";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 222);
            this.ControlBox = false;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgWMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpInput)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.PanelControl pnlFill;
        private DevExpress.XtraEditors.GroupControl grpInput;
        private DevExpress.XtraEditors.LabelControl lblUserCode;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserCode;
        private DevExpress.XtraEditors.SimpleButton btnLogout;
        private DevExpress.XtraEditors.SimpleButton btnChangePassword;
        private DevExpress.XtraEditors.PictureEdit imgWMS;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevExpress.XtraEditors.LookUpEdit leWarehouse;
    }
}