namespace Wms.Mobile.UI.Pick
{
    partial class PickForm_Step2
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
            this.lblPickLocation = new System.Windows.Forms.Label();
            this.lblPickContainer = new System.Windows.Forms.Label();
            this.lblPickSku = new System.Windows.Forms.Label();
            this.lblPickQty = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtPickQty = new System.Windows.Forms.TextBox();
            this.txtPickLocationBarcode = new System.Windows.Forms.TextBox();
            this.txtPickContainerBarcode = new System.Windows.Forms.TextBox();
            this.txtPickSkuBarcode = new System.Windows.Forms.TextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblPickRecommend = new System.Windows.Forms.Label();
            this.cbPickRecommend = new System.Windows.Forms.ComboBox();
            this.lblPickRecommendMessage = new System.Windows.Forms.Label();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnReturn);
            this.pnlButton.Controls.Add(this.btnContinue);
            this.pnlButton.Location = new System.Drawing.Point(0, 245);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.txtBatchNumber);
            this.pnlClientZone.Controls.Add(this.lblMessage);
            this.pnlClientZone.Controls.Add(this.lblBatchNumber);
            this.pnlClientZone.Controls.Add(this.lblPickRecommendMessage);
            this.pnlClientZone.Controls.Add(this.cbPickRecommend);
            this.pnlClientZone.Controls.Add(this.lblPickRecommend);
            this.pnlClientZone.Controls.Add(this.txtPickSkuBarcode);
            this.pnlClientZone.Controls.Add(this.txtPickContainerBarcode);
            this.pnlClientZone.Controls.Add(this.txtPickLocationBarcode);
            this.pnlClientZone.Controls.Add(this.txtPickQty);
            this.pnlClientZone.Controls.Add(this.lblPickQty);
            this.pnlClientZone.Controls.Add(this.lblPickSku);
            this.pnlClientZone.Controls.Add(this.lblPickContainer);
            this.pnlClientZone.Controls.Add(this.lblPickLocation);
            this.pnlClientZone.Size = new System.Drawing.Size(318, 245);
            // 
            // lblPickLocation
            // 
            this.lblPickLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblPickLocation.Location = new System.Drawing.Point(4, 89);
            this.lblPickLocation.Name = "lblPickLocation";
            this.lblPickLocation.Size = new System.Drawing.Size(100, 20);
            this.lblPickLocation.Text = "拣选库位：";
            // 
            // lblPickContainer
            // 
            this.lblPickContainer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblPickContainer.Location = new System.Drawing.Point(4, 120);
            this.lblPickContainer.Name = "lblPickContainer";
            this.lblPickContainer.Size = new System.Drawing.Size(100, 20);
            this.lblPickContainer.Text = "拣选容器：";
            // 
            // lblPickSku
            // 
            this.lblPickSku.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblPickSku.Location = new System.Drawing.Point(4, 10);
            this.lblPickSku.Name = "lblPickSku";
            this.lblPickSku.Size = new System.Drawing.Size(100, 20);
            this.lblPickSku.Text = "货物：";
            // 
            // lblPickQty
            // 
            this.lblPickQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblPickQty.Location = new System.Drawing.Point(4, 150);
            this.lblPickQty.Name = "lblPickQty";
            this.lblPickQty.Size = new System.Drawing.Size(100, 20);
            this.lblPickQty.Text = "数量：";
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(0, 222);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(315, 20);
            // 
            // txtPickQty
            // 
            this.txtPickQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtPickQty.Location = new System.Drawing.Point(117, 147);
            this.txtPickQty.Name = "txtPickQty";
            this.txtPickQty.Size = new System.Drawing.Size(198, 26);
            this.txtPickQty.TabIndex = 5;
            this.txtPickQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPickQty_KeyPress);
            // 
            // txtPickLocationBarcode
            // 
            this.txtPickLocationBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtPickLocationBarcode.Location = new System.Drawing.Point(117, 86);
            this.txtPickLocationBarcode.Name = "txtPickLocationBarcode";
            this.txtPickLocationBarcode.Size = new System.Drawing.Size(198, 26);
            this.txtPickLocationBarcode.TabIndex = 3;
            this.txtPickLocationBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPickLocationBarcode_KeyPress);
            // 
            // txtPickContainerBarcode
            // 
            this.txtPickContainerBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtPickContainerBarcode.Location = new System.Drawing.Point(117, 117);
            this.txtPickContainerBarcode.Name = "txtPickContainerBarcode";
            this.txtPickContainerBarcode.Size = new System.Drawing.Size(198, 26);
            this.txtPickContainerBarcode.TabIndex = 4;
            this.txtPickContainerBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPickContainerBarcode_KeyPress);
            // 
            // txtPickSkuBarcode
            // 
            this.txtPickSkuBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtPickSkuBarcode.Location = new System.Drawing.Point(117, 7);
            this.txtPickSkuBarcode.Name = "txtPickSkuBarcode";
            this.txtPickSkuBarcode.Size = new System.Drawing.Size(198, 26);
            this.txtPickSkuBarcode.TabIndex = 2;
            this.txtPickSkuBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPickSkuBarcode_KeyPress);
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContinue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnContinue.Location = new System.Drawing.Point(194, 8);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(114, 35);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "下一个任务";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblPickRecommend
            // 
            this.lblPickRecommend.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblPickRecommend.Location = new System.Drawing.Point(4, 40);
            this.lblPickRecommend.Name = "lblPickRecommend";
            this.lblPickRecommend.Size = new System.Drawing.Size(100, 20);
            this.lblPickRecommend.Text = "拣货推荐";
            // 
            // cbPickRecommend
            // 
            this.cbPickRecommend.Location = new System.Drawing.Point(117, 37);
            this.cbPickRecommend.Name = "cbPickRecommend";
            this.cbPickRecommend.Size = new System.Drawing.Size(198, 23);
            this.cbPickRecommend.TabIndex = 13;
            this.cbPickRecommend.SelectedIndexChanged += new System.EventHandler(this.cbPickRecommend_SelectedIndexChanged);
            // 
            // lblPickRecommendMessage
            // 
            this.lblPickRecommendMessage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblPickRecommendMessage.ForeColor = System.Drawing.Color.Red;
            this.lblPickRecommendMessage.Location = new System.Drawing.Point(4, 64);
            this.lblPickRecommendMessage.Name = "lblPickRecommendMessage";
            this.lblPickRecommendMessage.Size = new System.Drawing.Size(311, 20);
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblBatchNumber.Location = new System.Drawing.Point(4, 174);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(100, 20);
            this.lblBatchNumber.Text = "出库批次：";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtBatchNumber.Location = new System.Drawing.Point(117, 174);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(198, 26);
            this.txtBatchNumber.TabIndex = 24;
            this.txtBatchNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchNumber_KeyPress);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReturn.Location = new System.Drawing.Point(13, 8);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(70, 35);
            this.btnReturn.TabIndex = 11;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // PickForm_Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Name = "PickForm_Step2";
            this.Load += new System.EventHandler(this.PickForm_Step2_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblPickQty;
        private System.Windows.Forms.Label lblPickSku;
        private System.Windows.Forms.Label lblPickContainer;
        private System.Windows.Forms.Label lblPickLocation;
        private System.Windows.Forms.TextBox txtPickQty;
        private System.Windows.Forms.TextBox txtPickSkuBarcode;
        private System.Windows.Forms.TextBox txtPickContainerBarcode;
        private System.Windows.Forms.TextBox txtPickLocationBarcode;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.ComboBox cbPickRecommend;
        private System.Windows.Forms.Label lblPickRecommend;
        private System.Windows.Forms.Label lblPickRecommendMessage;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Button btnReturn;
    }
}
