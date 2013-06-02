namespace Wms.Mobile.UI.Putaway
{
    partial class PutawayForm_Step4
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
            this.tabResult = new System.Windows.Forms.TabPage();
            this.gridResult = new System.Windows.Forms.DataGrid();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnReturn);
            this.pnlButton.Controls.Add(this.btnAbort);
            this.pnlButton.Controls.Add(this.btnComplete);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.lblMessage);
            this.pnlClientZone.Controls.Add(this.tcMain);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabDetails);
            this.tcMain.Controls.Add(this.tabResult);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(318, 220);
            this.tcMain.TabIndex = 18;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.gridDetails);
            this.tabDetails.Location = new System.Drawing.Point(4, 25);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Size = new System.Drawing.Size(310, 191);
            this.tabDetails.Text = "任务明细";
            // 
            // gridDetails
            // 
            this.gridDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetails.Location = new System.Drawing.Point(0, 0);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(310, 191);
            this.gridDetails.TabIndex = 0;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.gridResult);
            this.tabResult.Location = new System.Drawing.Point(4, 25);
            this.tabResult.Name = "tabResult";
            this.tabResult.Size = new System.Drawing.Size(310, 191);
            this.tabResult.Text = "上架结果";
            // 
            // gridResult
            // 
            this.gridResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.Location = new System.Drawing.Point(0, 0);
            this.gridResult.Name = "gridResult";
            this.gridResult.Size = new System.Drawing.Size(310, 191);
            this.gridResult.TabIndex = 1;
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReturn.Location = new System.Drawing.Point(133, 8);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(70, 35);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbort.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnAbort.Location = new System.Drawing.Point(14, 8);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(70, 35);
            this.btnAbort.TabIndex = 6;
            this.btnAbort.Text = "放弃";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnComplete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnComplete.Location = new System.Drawing.Point(209, 8);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(95, 35);
            this.btnComplete.TabIndex = 4;
            this.btnComplete.Text = "上架完成";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(14, 222);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(290, 20);
            // 
            // PutawayForm_Step4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Name = "PutawayForm_Step4";
            this.Load += new System.EventHandler(this.PutawayForm_step4_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.DataGrid gridResult;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Label lblMessage;
    }
}
