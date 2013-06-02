namespace Wms.Mobile.UI.Receiving
{
    partial class ReceivingForm_Step1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.cbBillNumber = new System.Windows.Forms.ComboBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.gridDetails = new System.Windows.Forms.DataGrid();
            this.tabRemark = new System.Windows.Forms.TabPage();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabRemark.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnRefresh);
            this.pnlButton.Controls.Add(this.btnReturn);
            this.pnlButton.Controls.Add(this.btnReceive);
            this.pnlButton.Location = new System.Drawing.Point(0, 215);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.tcMain);
            this.pnlClientZone.Controls.Add(this.lblTip);
            this.pnlClientZone.Controls.Add(this.cbBillNumber);
            this.pnlClientZone.Size = new System.Drawing.Size(318, 215);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReturn.Location = new System.Drawing.Point(14, 8);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(70, 35);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReceive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReceive.Location = new System.Drawing.Point(234, 8);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(70, 35);
            this.btnReceive.TabIndex = 2;
            this.btnReceive.Text = "收货";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // lblTip
            // 
            this.lblTip.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTip.Location = new System.Drawing.Point(14, 7);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(290, 20);
            this.lblTip.Text = "请选择收货任务 -";
            // 
            // cbBillNumber
            // 
            this.cbBillNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.cbBillNumber.Items.Add("入库操作");
            this.cbBillNumber.Items.Add("库内操作");
            this.cbBillNumber.Items.Add("出库操作");
            this.cbBillNumber.Items.Add("其它操作");
            this.cbBillNumber.Location = new System.Drawing.Point(14, 30);
            this.cbBillNumber.Name = "cbBillNumber";
            this.cbBillNumber.Size = new System.Drawing.Size(290, 26);
            this.cbBillNumber.TabIndex = 1;
            this.cbBillNumber.SelectedIndexChanged += new System.EventHandler(this.cbBillNumber_SelectedIndexChanged);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabDetails);
            this.tcMain.Controls.Add(this.tabRemark);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcMain.Location = new System.Drawing.Point(0, 94);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(318, 121);
            this.tcMain.TabIndex = 16;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.gridDetails);
            this.tabDetails.Location = new System.Drawing.Point(4, 25);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Size = new System.Drawing.Size(310, 92);
            this.tabDetails.Text = "任务明细";
            // 
            // gridDetails
            // 
            this.gridDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetails.Location = new System.Drawing.Point(0, 0);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(310, 92);
            this.gridDetails.TabIndex = 0;
            // 
            // tabRemark
            // 
            this.tabRemark.Controls.Add(this.txtMemo);
            this.tabRemark.Location = new System.Drawing.Point(4, 25);
            this.tabRemark.Name = "tabRemark";
            this.tabRemark.Size = new System.Drawing.Size(310, 92);
            this.tabRemark.Text = "备注信息";
            // 
            // txtMemo
            // 
            this.txtMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMemo.Location = new System.Drawing.Point(0, 0);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(310, 92);
            this.txtMemo.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnRefresh.Location = new System.Drawing.Point(90, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ReceivingForm_Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 265);
            this.Menu = this.mainMenu1;
            this.Name = "ReceivingForm_Step1";
            this.Text = "ReceivingForm_Step1";
            this.Load += new System.EventHandler(this.ReceivingForm_Step1_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabRemark.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.ComboBox cbBillNumber;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage tabRemark;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Button btnRefresh;
    }
}