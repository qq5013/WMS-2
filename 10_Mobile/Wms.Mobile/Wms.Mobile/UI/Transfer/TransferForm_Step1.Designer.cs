namespace Wms.Mobile.UI.Transfer
{
    partial class TransferForm_Step1
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
            this.txtTargetLocation = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblSourceLocation = new System.Windows.Forms.Label();
            this.lblTargetLocation = new System.Windows.Forms.Label();
            this.lblTargetContainer = new System.Windows.Forms.Label();
            this.txtTargetContainer = new System.Windows.Forms.TextBox();
            this.txtTransferQty = new System.Windows.Forms.TextBox();
            this.lblTransferQty = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.txtSourceLocation = new System.Windows.Forms.TextBox();
            this.gridStock = new System.Windows.Forms.DataGrid();
            this.btnComplete = new System.Windows.Forms.Button();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnComplete);
            this.pnlButton.Controls.Add(this.btnContinue);
            this.pnlButton.Controls.Add(this.lblMessage);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.gridStock);
            this.pnlClientZone.Controls.Add(this.txtSourceLocation);
            this.pnlClientZone.Controls.Add(this.txtTransferQty);
            this.pnlClientZone.Controls.Add(this.lblTransferQty);
            this.pnlClientZone.Controls.Add(this.txtTargetContainer);
            this.pnlClientZone.Controls.Add(this.lblTargetContainer);
            this.pnlClientZone.Controls.Add(this.lblTargetLocation);
            this.pnlClientZone.Controls.Add(this.lblSourceLocation);
            this.pnlClientZone.Controls.Add(this.txtTargetLocation);
            // 
            // txtTargetLocation
            // 
            this.txtTargetLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtTargetLocation.Location = new System.Drawing.Point(99, 184);
            this.txtTargetLocation.Name = "txtTargetLocation";
            this.txtTargetLocation.Size = new System.Drawing.Size(203, 26);
            this.txtTargetLocation.TabIndex = 6;
            this.txtTargetLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetLocationBarcode_KeyPress);
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(10, 6);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(98, 35);
            // 
            // lblSourceLocation
            // 
            this.lblSourceLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblSourceLocation.Location = new System.Drawing.Point(10, 6);
            this.lblSourceLocation.Name = "lblSourceLocation";
            this.lblSourceLocation.Size = new System.Drawing.Size(79, 20);
            this.lblSourceLocation.Text = "原库位";
            // 
            // lblTargetLocation
            // 
            this.lblTargetLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTargetLocation.Location = new System.Drawing.Point(7, 184);
            this.lblTargetLocation.Name = "lblTargetLocation";
            this.lblTargetLocation.Size = new System.Drawing.Size(88, 20);
            this.lblTargetLocation.Text = "目标库位";
            // 
            // lblTargetContainer
            // 
            this.lblTargetContainer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTargetContainer.Location = new System.Drawing.Point(7, 216);
            this.lblTargetContainer.Name = "lblTargetContainer";
            this.lblTargetContainer.Size = new System.Drawing.Size(79, 20);
            this.lblTargetContainer.Text = "目标容器";
            // 
            // txtTargetContainer
            // 
            this.txtTargetContainer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtTargetContainer.Location = new System.Drawing.Point(99, 216);
            this.txtTargetContainer.Name = "txtTargetContainer";
            this.txtTargetContainer.Size = new System.Drawing.Size(203, 26);
            this.txtTargetContainer.TabIndex = 16;
            this.txtTargetContainer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetContainerBarcode_KeyPress);
            // 
            // txtTransferQty
            // 
            this.txtTransferQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtTransferQty.Location = new System.Drawing.Point(99, 152);
            this.txtTransferQty.Name = "txtTransferQty";
            this.txtTransferQty.Size = new System.Drawing.Size(203, 26);
            this.txtTransferQty.TabIndex = 19;
            this.txtTransferQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransferedQty_KeyPress);
            // 
            // lblTransferQty
            // 
            this.lblTransferQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTransferQty.Location = new System.Drawing.Point(10, 152);
            this.lblTransferQty.Name = "lblTransferQty";
            this.lblTransferQty.Size = new System.Drawing.Size(83, 20);
            this.lblTransferQty.Text = "移货数量";
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContinue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnContinue.Location = new System.Drawing.Point(212, 6);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(90, 35);
            this.btnContinue.TabIndex = 8;
            this.btnContinue.Text = "继续移货";
            this.btnContinue.Click += new System.EventHandler(this.btnContinueScan_Click);
            // 
            // txtSourceLocation
            // 
            this.txtSourceLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtSourceLocation.Location = new System.Drawing.Point(99, 6);
            this.txtSourceLocation.Name = "txtSourceLocation";
            this.txtSourceLocation.Size = new System.Drawing.Size(203, 26);
            this.txtSourceLocation.TabIndex = 27;
            this.txtSourceLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSourceLocation_KeyPress);
            // 
            // gridStock
            // 
            this.gridStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridStock.Location = new System.Drawing.Point(10, 38);
            this.gridStock.Name = "gridStock";
            this.gridStock.Size = new System.Drawing.Size(292, 107);
            this.gridStock.TabIndex = 28;
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnComplete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnComplete.Location = new System.Drawing.Point(116, 6);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(90, 35);
            this.btnComplete.TabIndex = 10;
            this.btnComplete.Text = "完成移货";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // TransferForm_Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Name = "TransferForm_Step1";
            this.Load += new System.EventHandler(this.PutawayForm_Step2_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTargetLocation;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblSourceLocation;
        private System.Windows.Forms.Label lblTargetLocation;
        private System.Windows.Forms.Label lblTargetContainer;
        private System.Windows.Forms.TextBox txtTargetContainer;
        private System.Windows.Forms.TextBox txtTransferQty;
        private System.Windows.Forms.Label lblTransferQty;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TextBox txtSourceLocation;
        private System.Windows.Forms.DataGrid gridStock;
        private System.Windows.Forms.Button btnComplete;
    }
}
