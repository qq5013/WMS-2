namespace Wms.Mobile.UI.StockQuery
{
    partial class StockQueryForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.gridStock = new System.Windows.Forms.DataGrid();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.lblMessage);
            this.pnlButton.Controls.Add(this.btnClose);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.txtBarcode);
            this.pnlClientZone.Controls.Add(this.lblBarcode);
            this.pnlClientZone.Controls.Add(this.gridStock);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(235, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridStock
            // 
            this.gridStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridStock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridStock.Location = new System.Drawing.Point(0, 51);
            this.gridStock.Name = "gridStock";
            this.gridStock.Size = new System.Drawing.Size(318, 174);
            this.gridStock.TabIndex = 0;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtBarcode.Location = new System.Drawing.Point(15, 19);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(290, 26);
            this.txtBarcode.TabIndex = 4;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblBarcode.Location = new System.Drawing.Point(15, -4);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(290, 20);
            this.lblBarcode.Text = "可扫描库位/容器/货物条码：";
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(15, 6);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(202, 20);
            // 
            // StockQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.Menu = this.mainMenu1;
            this.Name = "StockQueryForm";
            this.Text = "StockQueryForm";
            this.Load += new System.EventHandler(this.StockQueryForm_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGrid gridStock;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblMessage;
    }
}