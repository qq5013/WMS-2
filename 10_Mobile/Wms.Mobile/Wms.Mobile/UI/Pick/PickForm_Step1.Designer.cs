namespace Wms.Mobile.UI.Pick
{
    partial class PickForm_Step1
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.gridDetails = new System.Windows.Forms.DataGrid();
            this.tebPick = new System.Windows.Forms.TabPage();
            this.gridPick = new System.Windows.Forms.DataGrid();
            this.tabRemark = new System.Windows.Forms.TabPage();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.cbPlanNumber = new System.Windows.Forms.ComboBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.btnPick = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tebPick.SuspendLayout();
            this.tabRemark.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnReturn);
            this.pnlButton.Controls.Add(this.btnRefresh);
            this.pnlButton.Controls.Add(this.btnPick);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.tcMain);
            this.pnlClientZone.Controls.Add(this.cbPlanNumber);
            this.pnlClientZone.Controls.Add(this.lblTip);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabDetails);
            this.tcMain.Controls.Add(this.tebPick);
            this.tcMain.Controls.Add(this.tabRemark);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcMain.Location = new System.Drawing.Point(0, 79);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(318, 146);
            this.tcMain.TabIndex = 19;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.gridDetails);
            this.tabDetails.Location = new System.Drawing.Point(4, 25);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Size = new System.Drawing.Size(310, 117);
            this.tabDetails.Text = "任务明细";
            // 
            // gridDetails
            // 
            this.gridDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetails.Location = new System.Drawing.Point(0, 0);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(310, 117);
            this.gridDetails.TabIndex = 0;
            // 
            // tebPick
            // 
            this.tebPick.Controls.Add(this.gridPick);
            this.tebPick.Location = new System.Drawing.Point(4, 25);
            this.tebPick.Name = "tebPick";
            this.tebPick.Size = new System.Drawing.Size(310, 154);
            this.tebPick.Text = "拣选任务";
            // 
            // gridPick
            // 
            this.gridPick.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridPick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPick.Location = new System.Drawing.Point(0, 0);
            this.gridPick.Name = "gridPick";
            this.gridPick.Size = new System.Drawing.Size(310, 154);
            this.gridPick.TabIndex = 1;
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
            // cbPlanNumber
            // 
            this.cbPlanNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.cbPlanNumber.Location = new System.Drawing.Point(14, 26);
            this.cbPlanNumber.Name = "cbPlanNumber";
            this.cbPlanNumber.Size = new System.Drawing.Size(290, 26);
            this.cbPlanNumber.TabIndex = 18;
            this.cbPlanNumber.SelectedIndexChanged += new System.EventHandler(this.cbPlanNumber_SelectedIndexChanged);
            // 
            // lblTip
            // 
            this.lblTip.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTip.Location = new System.Drawing.Point(14, 3);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(290, 20);
            this.lblTip.Text = "出库计划 -";
            // 
            // btnPick
            // 
            this.btnPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPick.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnPick.Location = new System.Drawing.Point(208, 8);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(102, 35);
            this.btnPick.TabIndex = 3;
            this.btnPick.Text = "开始拣货";
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReturn.Location = new System.Drawing.Point(14, 8);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 35);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnRefresh.Location = new System.Drawing.Point(98, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 35);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PickForm_Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.Name = "PickForm_Step1";
            this.Load += new System.EventHandler(this.PickForm_Step1_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tebPick.ResumeLayout(false);
            this.tabRemark.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.TabPage tabRemark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.ComboBox cbPlanNumber;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.TabPage tebPick;
        private System.Windows.Forms.DataGrid gridPick;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnRefresh;
    }
}
