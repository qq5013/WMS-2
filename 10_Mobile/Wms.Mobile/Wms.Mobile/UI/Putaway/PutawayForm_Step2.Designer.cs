namespace Wms.Mobile.UI.Putaway
{
    partial class PutawayForm_Step2
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
            this.lblSkuNumber = new System.Windows.Forms.Label();
            this.lblLocationNumber = new System.Windows.Forms.Label();
            this.txtSkuBarcode = new System.Windows.Forms.TextBox();
            this.txtTargetLocationBarcode = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lbltxtZContainerNumber = new System.Windows.Forms.Label();
            this.txtSourceContainerBarcode = new System.Windows.Forms.TextBox();
            this.cbLocationNumber = new System.Windows.Forms.ComboBox();
            this.lbllblLLocationNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContainerNumber = new System.Windows.Forms.Label();
            this.txtTargetContainerBarcode = new System.Windows.Forms.TextBox();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.txtTransferedQty = new System.Windows.Forms.TextBox();
            this.lblTransferQty = new System.Windows.Forms.Label();
            this.btnContinueScan = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnReturn);
            this.pnlButton.Controls.Add(this.btnContinueScan);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.txtBatchNumber);
            this.pnlClientZone.Controls.Add(this.lblBatchNumber);
            this.pnlClientZone.Controls.Add(this.lblMessage);
            this.pnlClientZone.Controls.Add(this.txtTransferedQty);
            this.pnlClientZone.Controls.Add(this.lblTransferQty);
            this.pnlClientZone.Controls.Add(this.txtTargetContainerBarcode);
            this.pnlClientZone.Controls.Add(this.lblContainerNumber);
            this.pnlClientZone.Controls.Add(this.label3);
            this.pnlClientZone.Controls.Add(this.lbllblLLocationNumber);
            this.pnlClientZone.Controls.Add(this.cbLocationNumber);
            this.pnlClientZone.Controls.Add(this.txtSourceContainerBarcode);
            this.pnlClientZone.Controls.Add(this.lbltxtZContainerNumber);
            this.pnlClientZone.Controls.Add(this.txtTargetLocationBarcode);
            this.pnlClientZone.Controls.Add(this.txtSkuBarcode);
            this.pnlClientZone.Controls.Add(this.lblLocationNumber);
            this.pnlClientZone.Controls.Add(this.lblSkuNumber);
            // 
            // lblSkuNumber
            // 
            this.lblSkuNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblSkuNumber.Location = new System.Drawing.Point(7, 22);
            this.lblSkuNumber.Name = "lblSkuNumber";
            this.lblSkuNumber.Size = new System.Drawing.Size(79, 20);
            this.lblSkuNumber.Text = "上架货物";
            // 
            // lblLocationNumber
            // 
            this.lblLocationNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblLocationNumber.Location = new System.Drawing.Point(8, 76);
            this.lblLocationNumber.Name = "lblLocationNumber";
            this.lblLocationNumber.Size = new System.Drawing.Size(79, 20);
            this.lblLocationNumber.Text = "推荐库位";
            // 
            // txtSkuBarcode
            // 
            this.txtSkuBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtSkuBarcode.Location = new System.Drawing.Point(99, 22);
            this.txtSkuBarcode.Name = "txtSkuBarcode";
            this.txtSkuBarcode.Size = new System.Drawing.Size(201, 26);
            this.txtSkuBarcode.TabIndex = 2;
            this.txtSkuBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSkuBarcode_KeyPress);
            // 
            // txtTargetLocationBarcode
            // 
            this.txtTargetLocationBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtTargetLocationBarcode.Location = new System.Drawing.Point(99, 125);
            this.txtTargetLocationBarcode.Name = "txtTargetLocationBarcode";
            this.txtTargetLocationBarcode.Size = new System.Drawing.Size(203, 26);
            this.txtTargetLocationBarcode.TabIndex = 6;
            this.txtTargetLocationBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetLocationBarcode_KeyPress);
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(8, 205);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(196, 20);
            // 
            // lbltxtZContainerNumber
            // 
            this.lbltxtZContainerNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbltxtZContainerNumber.Location = new System.Drawing.Point(7, -3);
            this.lbltxtZContainerNumber.Name = "lbltxtZContainerNumber";
            this.lbltxtZContainerNumber.Size = new System.Drawing.Size(79, 20);
            this.lbltxtZContainerNumber.Text = "周转容器";
            // 
            // txtSourceContainerBarcode
            // 
            this.txtSourceContainerBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtSourceContainerBarcode.Location = new System.Drawing.Point(99, -5);
            this.txtSourceContainerBarcode.Name = "txtSourceContainerBarcode";
            this.txtSourceContainerBarcode.Size = new System.Drawing.Size(201, 26);
            this.txtSourceContainerBarcode.TabIndex = 1;
            this.txtSourceContainerBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSourceContainerBarcode_KeyPress);
            // 
            // cbLocationNumber
            // 
            this.cbLocationNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.cbLocationNumber.Location = new System.Drawing.Point(99, 76);
            this.cbLocationNumber.Name = "cbLocationNumber";
            this.cbLocationNumber.Size = new System.Drawing.Size(203, 26);
            this.cbLocationNumber.TabIndex = 4;
            this.cbLocationNumber.SelectedIndexChanged += new System.EventHandler(this.cblblLocationNumber_SelectedIndexChanged);
            this.cbLocationNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLocationNumber_KeyPress);
            // 
            // lbllblLLocationNumber
            // 
            this.lbllblLLocationNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbllblLLocationNumber.Location = new System.Drawing.Point(99, 105);
            this.lbllblLLocationNumber.Name = "lbllblLLocationNumber";
            this.lbllblLLocationNumber.Size = new System.Drawing.Size(203, 20);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(5, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.Text = "上架库位";
            // 
            // lblContainerNumber
            // 
            this.lblContainerNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblContainerNumber.Location = new System.Drawing.Point(7, 153);
            this.lblContainerNumber.Name = "lblContainerNumber";
            this.lblContainerNumber.Size = new System.Drawing.Size(79, 20);
            this.lblContainerNumber.Text = "上架容器";
            // 
            // txtTargetContainerBarcode
            // 
            this.txtTargetContainerBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtTargetContainerBarcode.Location = new System.Drawing.Point(99, 153);
            this.txtTargetContainerBarcode.Name = "txtTargetContainerBarcode";
            this.txtTargetContainerBarcode.Size = new System.Drawing.Size(203, 26);
            this.txtTargetContainerBarcode.TabIndex = 16;
            this.txtTargetContainerBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetContainerBarcode_KeyPress);
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtBatchNumber.Location = new System.Drawing.Point(99, 50);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(201, 26);
            this.txtBatchNumber.TabIndex = 3;
            this.txtBatchNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchNumber_KeyPress);
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblBatchNumber.Location = new System.Drawing.Point(8, 50);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(83, 20);
            this.lblBatchNumber.Text = "入库批次";
            // 
            // txtTransferedQty
            // 
            this.txtTransferedQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtTransferedQty.Location = new System.Drawing.Point(99, 180);
            this.txtTransferedQty.Name = "txtTransferedQty";
            this.txtTransferedQty.Size = new System.Drawing.Size(203, 26);
            this.txtTransferedQty.TabIndex = 19;
            this.txtTransferedQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransferedQty_KeyPress);
            // 
            // lblTransferQty
            // 
            this.lblTransferQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTransferQty.Location = new System.Drawing.Point(7, 180);
            this.lblTransferQty.Name = "lblTransferQty";
            this.lblTransferQty.Size = new System.Drawing.Size(83, 20);
            this.lblTransferQty.Text = "上架数量";
            // 
            // btnContinueScan
            // 
            this.btnContinueScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContinueScan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnContinueScan.Location = new System.Drawing.Point(212, 6);
            this.btnContinueScan.Name = "btnContinueScan";
            this.btnContinueScan.Size = new System.Drawing.Size(90, 35);
            this.btnContinueScan.TabIndex = 8;
            this.btnContinueScan.Text = "继续扫描";
            this.btnContinueScan.Click += new System.EventHandler(this.btnContinueScan_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReturn.Location = new System.Drawing.Point(17, 6);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(70, 35);
            this.btnReturn.TabIndex = 10;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // PutawayForm_Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.Name = "PutawayForm_Step2";
            this.Load += new System.EventHandler(this.PutawayForm_Step2_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLocationNumber;
        private System.Windows.Forms.Label lblSkuNumber;
        private System.Windows.Forms.TextBox txtSkuBarcode;
        private System.Windows.Forms.TextBox txtTargetLocationBarcode;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lbltxtZContainerNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbllblLLocationNumber;
        private System.Windows.Forms.ComboBox cbLocationNumber;
        private System.Windows.Forms.TextBox txtSourceContainerBarcode;
        private System.Windows.Forms.Label lblContainerNumber;
        private System.Windows.Forms.TextBox txtTargetContainerBarcode;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.TextBox txtTransferedQty;
        private System.Windows.Forms.Label lblTransferQty;
        private System.Windows.Forms.Button btnContinueScan;
        private System.Windows.Forms.Button btnReturn;
    }
}
