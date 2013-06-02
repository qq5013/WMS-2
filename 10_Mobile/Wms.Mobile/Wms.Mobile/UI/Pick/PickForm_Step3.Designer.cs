namespace Wms.Mobile.UI.Pick
{
    partial class PickForm_Step3
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
            this.gridPickTask = new System.Windows.Forms.DataGrid();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tebPick.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnAbort);
            this.pnlButton.Controls.Add(this.btnComplete);
            this.pnlButton.Location = new System.Drawing.Point(0, 245);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.tcMain);
            this.pnlClientZone.Size = new System.Drawing.Size(318, 245);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabDetails);
            this.tcMain.Controls.Add(this.tebPick);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcMain.Location = new System.Drawing.Point(0, 3);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(318, 242);
            this.tcMain.TabIndex = 22;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.gridDetails);
            this.tabDetails.Location = new System.Drawing.Point(4, 25);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Size = new System.Drawing.Size(310, 213);
            this.tabDetails.Text = "任务明细";
            // 
            // gridDetails
            // 
            this.gridDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetails.Location = new System.Drawing.Point(0, 0);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(310, 213);
            this.gridDetails.TabIndex = 0;
            // 
            // tebPick
            // 
            this.tebPick.Controls.Add(this.gridPickTask);
            this.tebPick.Location = new System.Drawing.Point(4, 25);
            this.tebPick.Name = "tebPick";
            this.tebPick.Size = new System.Drawing.Size(310, 213);
            this.tebPick.Text = "拣选任务";
            // 
            // gridPickTask
            // 
            this.gridPickTask.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridPickTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPickTask.Location = new System.Drawing.Point(0, 0);
            this.gridPickTask.Name = "gridPickTask";
            this.gridPickTask.Size = new System.Drawing.Size(310, 213);
            this.gridPickTask.TabIndex = 1;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbort.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnAbort.Location = new System.Drawing.Point(14, 8);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(70, 35);
            this.btnAbort.TabIndex = 8;
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
            this.btnComplete.TabIndex = 7;
            this.btnComplete.Text = "出货完成";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // PickForm_Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Name = "PickForm_Step3";
            this.Load += new System.EventHandler(this.PickForm_Step3_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tebPick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.TabPage tebPick;
        private System.Windows.Forms.DataGrid gridPickTask;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnComplete;
    }
}
