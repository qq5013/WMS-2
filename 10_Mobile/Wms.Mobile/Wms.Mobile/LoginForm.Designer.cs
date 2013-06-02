namespace Wms.Mobile
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.cbWarehouse = new System.Windows.Forms.ComboBox();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserCode = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblVersion);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(318, 120);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblVersion.Location = new System.Drawing.Point(193, 85);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(107, 20);
            this.lblVersion.Text = "Mobile V1.0";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(265, 95);
            this.lblTitle.Text = "Warehouse Management System";
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.panel1);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(0, 120);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(318, 155);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblWarehouse);
            this.panel1.Controls.Add(this.cbWarehouse);
            this.panel1.Controls.Add(this.cbUser);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.lblUserCode);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, -18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 173);
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblWarehouse.Location = new System.Drawing.Point(15, 26);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(80, 20);
            this.lblWarehouse.Text = "仓库：";
            // 
            // cbWarehouse
            // 
            this.cbWarehouse.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.cbWarehouse.Location = new System.Drawing.Point(105, 23);
            this.cbWarehouse.Name = "cbWarehouse";
            this.cbWarehouse.Size = new System.Drawing.Size(200, 26);
            this.cbWarehouse.TabIndex = 2;
            this.cbWarehouse.SelectedIndexChanged += new System.EventHandler(this.cbWarehouse_SelectedIndexChanged);
            // 
            // cbUser
            // 
            this.cbUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.cbUser.Location = new System.Drawing.Point(105, 53);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(200, 26);
            this.cbUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtPassword.Location = new System.Drawing.Point(105, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 26);
            this.txtPassword.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblPassword.Location = new System.Drawing.Point(15, 88);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(101, 20);
            this.lblPassword.Text = "登录口令：";
            // 
            // lblUserCode
            // 
            this.lblUserCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblUserCode.Location = new System.Drawing.Point(15, 56);
            this.lblUserCode.Name = "lblUserCode";
            this.lblUserCode.Size = new System.Drawing.Size(101, 20);
            this.lblUserCode.Text = "登录用户：";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnExit.Location = new System.Drawing.Point(235, 125);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 35);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnLogin.Location = new System.Drawing.Point(159, 125);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 35);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.ControlBox = false;
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.Name = "LoginForm";
            this.Text = "欢迎使用";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.ComboBox cbWarehouse;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserCode;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblTitle;
    }
}