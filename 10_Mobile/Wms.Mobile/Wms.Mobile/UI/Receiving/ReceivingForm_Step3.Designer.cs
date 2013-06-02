namespace Wms.Mobile.UI.Receiving
{
    partial class ReceivingForm_Step3
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
            this.btnContinueScan = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.Button();
            this.txtContainerBarcode = new System.Windows.Forms.TextBox();
            this.lblContainerBarcode = new System.Windows.Forms.Label();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnComplete);
            this.pnlButton.Controls.Add(this.btnContinueScan);
            this.pnlButton.Location = new System.Drawing.Point(0, 245);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.txtContainerBarcode);
            this.pnlClientZone.Controls.Add(this.lblContainerBarcode);
            this.pnlClientZone.Controls.Add(this.lblMessage);
            this.pnlClientZone.Controls.Add(this.txtBarcode);
            this.pnlClientZone.Controls.Add(this.txtQty);
            this.pnlClientZone.Controls.Add(this.lblQty);
            this.pnlClientZone.Controls.Add(this.txtBatchNumber);
            this.pnlClientZone.Controls.Add(this.lblBatchNumber);
            this.pnlClientZone.Controls.Add(this.lblBarcode);
            this.pnlClientZone.Size = new System.Drawing.Size(318, 245);
            // 
            // btnContinueScan
            // 
            this.btnContinueScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContinueScan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnContinueScan.Location = new System.Drawing.Point(214, 8);
            this.btnContinueScan.Name = "btnContinueScan";
            this.btnContinueScan.Size = new System.Drawing.Size(90, 35);
            this.btnContinueScan.TabIndex = 4;
            this.btnContinueScan.Text = "继续扫描";
            this.btnContinueScan.Click += new System.EventHandler(this.btnContinueScan_Click);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtQty.Location = new System.Drawing.Point(14, 141);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(290, 26);
            this.txtQty.TabIndex = 3;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblQty.Location = new System.Drawing.Point(14, 118);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(290, 20);
            this.lblQty.Text = "收货数量：";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtBatchNumber.Location = new System.Drawing.Point(14, 86);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(290, 26);
            this.txtBatchNumber.TabIndex = 2;
            this.txtBatchNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchNumber_KeyPress);
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblBatchNumber.Location = new System.Drawing.Point(14, 63);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(290, 20);
            this.lblBatchNumber.Text = "入库批次：";
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblBarcode.Location = new System.Drawing.Point(14, 6);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(290, 20);
            this.lblBarcode.Text = "货物条码/UPC：";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtBarcode.Location = new System.Drawing.Point(14, 32);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(290, 26);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(14, 222);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(290, 20);
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnComplete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnComplete.Location = new System.Drawing.Point(118, 8);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(90, 35);
            this.btnComplete.TabIndex = 5;
            this.btnComplete.Text = "终止扫描";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // txtContainerBarcode
            // 
            this.txtContainerBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtContainerBarcode.Location = new System.Drawing.Point(14, 193);
            this.txtContainerBarcode.Name = "txtContainerBarcode";
            this.txtContainerBarcode.Size = new System.Drawing.Size(290, 26);
            this.txtContainerBarcode.TabIndex = 8;
            this.txtContainerBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContainerBarcode_KeyPress);
            // 
            // lblContainerBarcode
            // 
            this.lblContainerBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblContainerBarcode.Location = new System.Drawing.Point(14, 170);
            this.lblContainerBarcode.Name = "lblContainerBarcode";
            this.lblContainerBarcode.Size = new System.Drawing.Size(290, 20);
            this.lblContainerBarcode.Text = "容器条码：";
            // 
            // ReceivingForm_Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Menu = this.mainMenu1;
            this.Name = "ReceivingForm_Step3";
            this.Text = "ReceivingForm_Step3";
            this.Load += new System.EventHandler(this.ReceivingForm_Step3_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnContinueScan;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.TextBox txtContainerBarcode;
        private System.Windows.Forms.Label lblContainerBarcode;
    }
}