
namespace Modules.StockModule.Views
{
    partial class StockListForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
       
        private void InitializeComponent()
        {
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.lblLocationCode = new System.Windows.Forms.Label();
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlanNumber = new System.Windows.Forms.Label();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.lblSkuNumber = new System.Windows.Forms.Label();
            this.txtPlanNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtSkuNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtBatchNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.txtLocationCode = new DevExpress.XtraEditors.TextEdit();
            this.txtAreaCode = new DevExpress.XtraEditors.TextEdit();
            this.beMerchantId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblMerchantId = new System.Windows.Forms.Label();
            this.lblVendorId = new System.Windows.Forms.Label();
            this.beVendorId = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beVendorId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcGrid
            // 
            this.gcGrid.Size = new System.Drawing.Size(800, 379);
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            this.gcCondition.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gcCondition.Size = new System.Drawing.Size(800, 150);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Location = new System.Drawing.Point(0, 221);
            this.pnlClientZone.Size = new System.Drawing.Size(800, 379);
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(800, 150);
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.Location = new System.Drawing.Point(3, 0);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(81, 23);
            this.lblAreaCode.TabIndex = 15;
            this.lblAreaCode.Text = "库区代码：";
            this.lblAreaCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLocationCode
            // 
            this.lblLocationCode.Location = new System.Drawing.Point(260, 0);
            this.lblLocationCode.Name = "lblLocationCode";
            this.lblLocationCode.Size = new System.Drawing.Size(81, 23);
            this.lblLocationCode.TabIndex = 0;
            this.lblLocationCode.Text = "库位代码：";
            this.lblLocationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layoutCondition
            // 
            this.layoutCondition.ColumnCount = 6;
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutCondition.Controls.Add(this.lblMerchantId, 0, 3);
            this.layoutCondition.Controls.Add(this.lblPlanNumber, 0, 1);
            this.layoutCondition.Controls.Add(this.lblBillNumber, 2, 1);
            this.layoutCondition.Controls.Add(this.lblSkuNumber, 0, 2);
            this.layoutCondition.Controls.Add(this.txtPlanNumber, 1, 1);
            this.layoutCondition.Controls.Add(this.txtBillNumber, 3, 1);
            this.layoutCondition.Controls.Add(this.txtSkuNumber, 1, 2);
            this.layoutCondition.Controls.Add(this.txtBatchNumber, 3, 2);
            this.layoutCondition.Controls.Add(this.lblBatchNumber, 2, 2);
            this.layoutCondition.Controls.Add(this.txtLocationCode, 3, 0);
            this.layoutCondition.Controls.Add(this.lblLocationCode, 2, 0);
            this.layoutCondition.Controls.Add(this.lblAreaCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtAreaCode, 1, 0);
            this.layoutCondition.Controls.Add(this.beMerchantId, 1, 3);
            this.layoutCondition.Controls.Add(this.lblVendorId, 2, 3);
            this.layoutCondition.Controls.Add(this.beVendorId, 3, 3);
            this.layoutCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutCondition.Location = new System.Drawing.Point(8, 26);
            this.layoutCondition.Name = "layoutCondition";
            this.layoutCondition.RowCount = 4;
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.Size = new System.Drawing.Size(784, 117);
            this.layoutCondition.TabIndex = 0;
            // 
            // lblPlanNumber
            // 
            this.lblPlanNumber.Location = new System.Drawing.Point(3, 28);
            this.lblPlanNumber.Name = "lblPlanNumber";
            this.lblPlanNumber.Size = new System.Drawing.Size(81, 23);
            this.lblPlanNumber.TabIndex = 7;
            this.lblPlanNumber.Text = "入库计划号：";
            this.lblPlanNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.Location = new System.Drawing.Point(260, 28);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(81, 23);
            this.lblBillNumber.TabIndex = 18;
            this.lblBillNumber.Text = "入库单号：";
            this.lblBillNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSkuNumber
            // 
            this.lblSkuNumber.Location = new System.Drawing.Point(3, 56);
            this.lblSkuNumber.Name = "lblSkuNumber";
            this.lblSkuNumber.Size = new System.Drawing.Size(81, 23);
            this.lblSkuNumber.TabIndex = 12;
            this.lblSkuNumber.Text = "货物代码：";
            this.lblSkuNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPlanNumber
            // 
            this.txtPlanNumber.Location = new System.Drawing.Point(104, 31);
            this.txtPlanNumber.Name = "txtPlanNumber";
            this.txtPlanNumber.Size = new System.Drawing.Size(150, 20);
            this.txtPlanNumber.TabIndex = 167;
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(361, 31);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(150, 20);
            this.txtBillNumber.TabIndex = 168;
            // 
            // txtSkuNumber
            // 
            this.txtSkuNumber.Location = new System.Drawing.Point(104, 59);
            this.txtSkuNumber.Name = "txtSkuNumber";
            this.txtSkuNumber.Size = new System.Drawing.Size(150, 20);
            this.txtSkuNumber.TabIndex = 169;
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(361, 59);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(150, 20);
            this.txtBatchNumber.TabIndex = 170;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.Location = new System.Drawing.Point(260, 56);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(81, 23);
            this.lblBatchNumber.TabIndex = 171;
            this.lblBatchNumber.Text = "入库批次号：";
            this.lblBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.Location = new System.Drawing.Point(361, 3);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(150, 20);
            this.txtLocationCode.TabIndex = 165;
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Location = new System.Drawing.Point(104, 3);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(150, 20);
            this.txtAreaCode.TabIndex = 166;
            // 
            // beMerchantId
            // 
            this.beMerchantId.Location = new System.Drawing.Point(104, 87);
            this.beMerchantId.Name = "beMerchantId";
            this.beMerchantId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.beMerchantId.Size = new System.Drawing.Size(150, 20);
            this.beMerchantId.TabIndex = 172;
            this.beMerchantId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SelectCompany_ButtonClick);
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.Location = new System.Drawing.Point(3, 84);
            this.lblMerchantId.Name = "lblMerchantId";
            this.lblMerchantId.Size = new System.Drawing.Size(81, 23);
            this.lblMerchantId.TabIndex = 173;
            this.lblMerchantId.Text = " 货主：";
            this.lblMerchantId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVendorId
            // 
            this.lblVendorId.Location = new System.Drawing.Point(260, 84);
            this.lblVendorId.Name = "lblVendorId";
            this.lblVendorId.Size = new System.Drawing.Size(81, 23);
            this.lblVendorId.TabIndex = 175;
            this.lblVendorId.Text = "供应商：";
            this.lblVendorId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // beVendorId
            // 
            this.beVendorId.Location = new System.Drawing.Point(361, 87);
            this.beVendorId.Name = "beVendorId";
            this.beVendorId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.beVendorId.Size = new System.Drawing.Size(150, 20);
            this.beVendorId.TabIndex = 174;
            this.beVendorId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SelectCompany_ButtonClick);
            // 
            // StockListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "StockListForm";
            this.PageNumber = 1;
            this.PagesCount = 1;
            this.PageSize = 100;
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).EndInit();
            this.pnlClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beVendorId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAreaCode;
        private System.Windows.Forms.Label lblLocationCode;
        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblBillNumber;
        private System.Windows.Forms.Label lblSkuNumber;
        private System.Windows.Forms.Label lblPlanNumber;
        private DevExpress.XtraEditors.TextEdit txtLocationCode;
        private DevExpress.XtraEditors.TextEdit txtAreaCode;
        private DevExpress.XtraEditors.TextEdit txtPlanNumber;
        private DevExpress.XtraEditors.TextEdit txtBillNumber;
        private DevExpress.XtraEditors.TextEdit txtSkuNumber;
        private DevExpress.XtraEditors.TextEdit txtBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.Label lblMerchantId;
        private DevExpress.XtraEditors.ButtonEdit beMerchantId;
        private System.Windows.Forms.Label lblVendorId;
        private DevExpress.XtraEditors.ButtonEdit beVendorId;

        

    }
}

