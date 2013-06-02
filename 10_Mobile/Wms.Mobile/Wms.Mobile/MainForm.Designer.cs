namespace Wms.Mobile
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mmMain;

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
            this.mmMain = new System.Windows.Forms.MainMenu();
            this.lblTip = new System.Windows.Forms.Label();
            this.cbOperationType = new System.Windows.Forms.ComboBox();
            this.lvOperation = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colOperation = new System.Windows.Forms.ColumnHeader();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTip
            // 
            this.lblTip.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTip.Location = new System.Drawing.Point(15, 8);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(290, 20);
            this.lblTip.Text = "请选择仓库操作类型 -";
            // 
            // cbOperationType
            // 
            this.cbOperationType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.cbOperationType.Items.Add("入库操作");
            this.cbOperationType.Items.Add("库内操作");
            this.cbOperationType.Items.Add("出库操作");
            this.cbOperationType.Items.Add("其它操作");
            this.cbOperationType.Location = new System.Drawing.Point(15, 31);
            this.cbOperationType.Name = "cbOperationType";
            this.cbOperationType.Size = new System.Drawing.Size(290, 26);
            this.cbOperationType.TabIndex = 13;
            this.cbOperationType.SelectedIndexChanged += new System.EventHandler(this.cbOperationType_SelectedIndexChanged);
            // 
            // lvOperation
            // 
            this.lvOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvOperation.Columns.Add(this.colID);
            this.lvOperation.Columns.Add(this.colOperation);
            this.lvOperation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lvOperation.FullRowSelect = true;
            this.lvOperation.Location = new System.Drawing.Point(15, 60);
            this.lvOperation.Name = "lvOperation";
            this.lvOperation.Size = new System.Drawing.Size(290, 160);
            this.lvOperation.TabIndex = 14;
            this.lvOperation.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "编号";
            this.colID.Width = 60;
            // 
            // colOperation
            // 
            this.colOperation.Text = "操作信息";
            this.colOperation.Width = 220;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnExit);
            this.pnlButton.Controls.Add(this.btnSelect);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 225);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(318, 50);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnExit.Location = new System.Drawing.Point(15, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 35);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnSelect.Location = new System.Drawing.Point(235, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(70, 35);
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.ControlBox = false;
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.cbOperationType);
            this.Controls.Add(this.lvOperation);
            this.MaximizeBox = false;
            this.Menu = this.mmMain;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "操作选择";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.ComboBox cbOperationType;
        private System.Windows.Forms.ListView lvOperation;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colOperation;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnExit;
    }
}

