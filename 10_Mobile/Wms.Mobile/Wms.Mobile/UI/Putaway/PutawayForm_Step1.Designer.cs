namespace Wms.Mobile.UI.Putaway
{
    partial class PutawayForm_Step1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTip = new System.Windows.Forms.Label();
            this.cbBillNumber = new System.Windows.Forms.ComboBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.gridDetails = new System.Windows.Forms.DataGrid();
            this.tabRemark = new System.Windows.Forms.TabPage();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnPutaway = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabRemark.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnReturn);
            this.pnlButton.Controls.Add(this.btnRefresh);
            this.pnlButton.Controls.Add(this.btnPutaway);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.tcMain);
            this.pnlClientZone.Controls.Add(this.cbBillNumber);
            this.pnlClientZone.Controls.Add(this.lblTip);
            // 
            // lblTip
            // 
            this.lblTip.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTip.Location = new System.Drawing.Point(14, 7);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(290, 20);
            this.lblTip.Text = "请选择上架任务 -";
            // 
            // cbBillNumber
            // 
            this.cbBillNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
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
            this.tcMain.Location = new System.Drawing.Point(0, 81);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(318, 144);
            this.tcMain.TabIndex = 16;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.gridDetails);
            this.tabDetails.Location = new System.Drawing.Point(4, 25);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Size = new System.Drawing.Size(310, 115);
            this.tabDetails.Text = "任务明细";
            // 
            // gridDetails
            // 
            this.gridDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetails.Location = new System.Drawing.Point(0, 0);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(310, 115);
            this.gridDetails.TabIndex = 0;
            // 
            // tabRemark
            // 
            this.tabRemark.Controls.Add(this.txtRemark);
            this.tabRemark.Location = new System.Drawing.Point(4, 25);
            this.tabRemark.Name = "tabRemark";
            this.tabRemark.Size = new System.Drawing.Size(310, 154);
            this.tabRemark.Text = "备注信息";
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(0, 0);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(310, 154);
            this.txtRemark.TabIndex = 0;
            // 
            // btnPutaway
            // 
            this.btnPutaway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPutaway.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnPutaway.Location = new System.Drawing.Point(206, 9);
            this.btnPutaway.Name = "btnPutaway";
            this.btnPutaway.Size = new System.Drawing.Size(102, 35);
            this.btnPutaway.TabIndex = 2;
            this.btnPutaway.Text = "上架";
            this.btnPutaway.Click += new System.EventHandler(this.btnPutaway_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnRefresh.Location = new System.Drawing.Point(98, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReturn.Location = new System.Drawing.Point(14, 9);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 35);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // PutawayForm_Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.Name = "PutawayForm_Step1";
            this.Load += new System.EventHandler(this.PutawayForm_Step1_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabRemark.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.ComboBox cbBillNumber;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage tabRemark;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPutaway;
        private System.Windows.Forms.TextBox txtRemark;
    }
}
