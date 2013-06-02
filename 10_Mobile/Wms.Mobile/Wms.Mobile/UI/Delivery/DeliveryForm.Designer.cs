namespace Wms.Mobile.UI.Delivery
{
    partial class DeliveryForm
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
            this.lblOutBillNumber = new System.Windows.Forms.Label();
            this.cbOutBillNumber = new System.Windows.Forms.ComboBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.gridDetails = new System.Windows.Forms.DataGrid();
            this.tabRemark = new System.Windows.Forms.TabPage();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnReceive = new System.Windows.Forms.Button();
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
            this.pnlButton.Controls.Add(this.btnReceive);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.tcMain);
            this.pnlClientZone.Controls.Add(this.cbOutBillNumber);
            this.pnlClientZone.Controls.Add(this.lblOutBillNumber);
            // 
            // lblOutBillNumber
            // 
            this.lblOutBillNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblOutBillNumber.Location = new System.Drawing.Point(4, 7);
            this.lblOutBillNumber.Name = "lblOutBillNumber";
            this.lblOutBillNumber.Size = new System.Drawing.Size(88, 20);
            this.lblOutBillNumber.Text = "出货单：";
            // 
            // cbOutBillNumber
            // 
            this.cbOutBillNumber.Location = new System.Drawing.Point(103, 4);
            this.cbOutBillNumber.Name = "cbOutBillNumber";
            this.cbOutBillNumber.Size = new System.Drawing.Size(205, 23);
            this.cbOutBillNumber.TabIndex = 1;
            this.cbOutBillNumber.SelectedIndexChanged += new System.EventHandler(this.cbOutBillNumber_SelectedIndexChanged);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabDetails);
            this.tcMain.Controls.Add(this.tabRemark);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcMain.Location = new System.Drawing.Point(0, 53);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(318, 172);
            this.tcMain.TabIndex = 17;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.gridDetails);
            this.tabDetails.Location = new System.Drawing.Point(4, 25);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Size = new System.Drawing.Size(310, 143);
            this.tabDetails.Text = "任务明细";
            // 
            // gridDetails
            // 
            this.gridDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetails.Location = new System.Drawing.Point(0, 0);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(310, 143);
            this.gridDetails.TabIndex = 0;
            // 
            // tabRemark
            // 
            this.tabRemark.Controls.Add(this.txtRemark);
            this.tabRemark.Location = new System.Drawing.Point(4, 25);
            this.tabRemark.Name = "tabRemark";
            this.tabRemark.Size = new System.Drawing.Size(310, 163);
            this.tabRemark.Text = "备注信息";
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(0, 0);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(310, 163);
            this.txtRemark.TabIndex = 0;
            // 
            // btnReceive
            // 
            this.btnReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReceive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReceive.Location = new System.Drawing.Point(215, 6);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(93, 35);
            this.btnReceive.TabIndex = 3;
            this.btnReceive.Text = "发货完成";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReturn.Location = new System.Drawing.Point(17, 6);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 35);
            this.btnReturn.TabIndex = 7;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // DeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.Name = "DeliveryForm";
            this.Text = "发货>发货>完成确认";
            this.Load += new System.EventHandler(this.DeliveryForm_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabRemark.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOutBillNumber;
        private System.Windows.Forms.ComboBox cbOutBillNumber;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.TabPage tabRemark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnReturn;
    }
}
