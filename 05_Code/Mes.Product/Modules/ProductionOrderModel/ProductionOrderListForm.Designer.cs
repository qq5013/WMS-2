
namespace Mes.Product.Modules.ProductionOrderModel
{
    partial class ProductionOrderListForm
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
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.lblVendorId = new System.Windows.Forms.Label();
            this.lblLinkBillType = new System.Windows.Forms.Label();
            this.lblLinkBillNumber = new System.Windows.Forms.Label();
            this.lblPlanNumber = new System.Windows.Forms.Label();
            this.deDeliveryDate = new DevExpress.XtraEditors.DateEdit();
            this.deOrderDate = new DevExpress.XtraEditors.DateEdit();
            this.beCustomer = new DevExpress.XtraEditors.ButtonEdit();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lblClientId = new System.Windows.Forms.Label();
            this.lueCreateId = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMerchantId = new System.Windows.Forms.Label();
            this.deCreateTime = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lueOrderType = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCreateId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOrderType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(800, 130);
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutBase);
            this.gcCondition.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gcCondition.Size = new System.Drawing.Size(800, 130);
            // 
            // layoutBase
            // 
            this.layoutBase.ColumnCount = 4;
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.Controls.Add(this.lblVendorId, 0, 4);
            this.layoutBase.Controls.Add(this.lblLinkBillType, 0, 1);
            this.layoutBase.Controls.Add(this.lblLinkBillNumber, 2, 1);
            this.layoutBase.Controls.Add(this.lblPlanNumber, 0, 0);
            this.layoutBase.Controls.Add(this.deDeliveryDate, 3, 1);
            this.layoutBase.Controls.Add(this.deOrderDate, 1, 1);
            this.layoutBase.Controls.Add(this.beCustomer, 1, 0);
            this.layoutBase.Controls.Add(this.meRemark, 1, 4);
            this.layoutBase.Controls.Add(this.lblClientId, 0, 2);
            this.layoutBase.Controls.Add(this.lueCreateId, 1, 2);
            this.layoutBase.Controls.Add(this.lblMerchantId, 2, 2);
            this.layoutBase.Controls.Add(this.deCreateTime, 3, 2);
            this.layoutBase.Controls.Add(this.label1, 2, 0);
            this.layoutBase.Controls.Add(this.lueOrderType, 3, 0);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(8, 26);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 5;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.Size = new System.Drawing.Size(784, 178);
            this.layoutBase.TabIndex = 131;
            // 
            // lblVendorId
            // 
            this.lblVendorId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblVendorId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVendorId.Location = new System.Drawing.Point(3, 112);
            this.lblVendorId.Name = "lblVendorId";
            this.lblVendorId.Size = new System.Drawing.Size(81, 23);
            this.lblVendorId.TabIndex = 140;
            this.lblVendorId.Text = "备注：";
            this.lblVendorId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLinkBillType
            // 
            this.lblLinkBillType.Location = new System.Drawing.Point(3, 28);
            this.lblLinkBillType.Name = "lblLinkBillType";
            this.lblLinkBillType.Size = new System.Drawing.Size(94, 23);
            this.lblLinkBillType.TabIndex = 135;
            this.lblLinkBillType.Text = "订购日期：";
            this.lblLinkBillType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLinkBillNumber
            // 
            this.lblLinkBillNumber.Location = new System.Drawing.Point(394, 28);
            this.lblLinkBillNumber.Name = "lblLinkBillNumber";
            this.lblLinkBillNumber.Size = new System.Drawing.Size(94, 23);
            this.lblLinkBillNumber.TabIndex = 131;
            this.lblLinkBillNumber.Text = "交货日期：";
            this.lblLinkBillNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlanNumber
            // 
            this.lblPlanNumber.Location = new System.Drawing.Point(3, 0);
            this.lblPlanNumber.Name = "lblPlanNumber";
            this.lblPlanNumber.Size = new System.Drawing.Size(110, 23);
            this.lblPlanNumber.TabIndex = 130;
            this.lblPlanNumber.Text = "客户：";
            this.lblPlanNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deDeliveryDate
            // 
            this.deDeliveryDate.EditValue = null;
            this.deDeliveryDate.Location = new System.Drawing.Point(550, 31);
            this.deDeliveryDate.Name = "deDeliveryDate";
            this.deDeliveryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDeliveryDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDeliveryDate.Size = new System.Drawing.Size(165, 20);
            this.deDeliveryDate.TabIndex = 144;
            // 
            // deOrderDate
            // 
            this.deOrderDate.EditValue = null;
            this.deOrderDate.Location = new System.Drawing.Point(159, 31);
            this.deOrderDate.Name = "deOrderDate";
            this.deOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deOrderDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deOrderDate.Size = new System.Drawing.Size(165, 20);
            this.deOrderDate.TabIndex = 144;
            // 
            // beCustomer
            // 
            this.beCustomer.Location = new System.Drawing.Point(159, 3);
            this.beCustomer.Name = "beCustomer";
            this.beCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beCustomer.Size = new System.Drawing.Size(165, 20);
            this.beCustomer.TabIndex = 139;
            // 
            // meRemark
            // 
            this.meRemark.Location = new System.Drawing.Point(159, 115);
            this.meRemark.Name = "meRemark";
            this.meRemark.Size = new System.Drawing.Size(229, 60);
            this.meRemark.TabIndex = 145;
            // 
            // lblClientId
            // 
            this.lblClientId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblClientId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClientId.Location = new System.Drawing.Point(3, 56);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(81, 23);
            this.lblClientId.TabIndex = 138;
            this.lblClientId.Text = "制单人：";
            this.lblClientId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lueCreateId
            // 
            this.lueCreateId.Location = new System.Drawing.Point(159, 59);
            this.lueCreateId.Name = "lueCreateId";
            this.lueCreateId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCreateId.Properties.NullText = "";
            this.lueCreateId.Size = new System.Drawing.Size(165, 20);
            this.lueCreateId.TabIndex = 141;
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblMerchantId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMerchantId.Location = new System.Drawing.Point(394, 56);
            this.lblMerchantId.Name = "lblMerchantId";
            this.lblMerchantId.Size = new System.Drawing.Size(81, 23);
            this.lblMerchantId.TabIndex = 142;
            this.lblMerchantId.Text = "制单日期：";
            this.lblMerchantId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deCreatedAt
            // 
            this.deCreateTime.EditValue = null;
            this.deCreateTime.Location = new System.Drawing.Point(550, 59);
            this.deCreateTime.Name = "deCreateTime";
            this.deCreateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreateTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deCreateTime.Size = new System.Drawing.Size(165, 20);
            this.deCreateTime.TabIndex = 144;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(394, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 131;
            this.label1.Text = "工单类型：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lookUpEdit1
            // 
            this.lueOrderType.Location = new System.Drawing.Point(550, 3);
            this.lueOrderType.Name = "lueOrderType";
            this.lueOrderType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOrderType.Properties.NullText = "";
            this.lueOrderType.Size = new System.Drawing.Size(165, 20);
            this.lueOrderType.TabIndex = 141;
            // 
            // ProductionOrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ProductionOrderListForm";
            this.PageNumber = 1;
            this.PageSize = 100;
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCreateId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOrderType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblVendorId;
        private System.Windows.Forms.Label lblLinkBillType;
        private System.Windows.Forms.Label lblLinkBillNumber;
        private System.Windows.Forms.Label lblPlanNumber;
        private DevExpress.XtraEditors.DateEdit deDeliveryDate;
        private DevExpress.XtraEditors.DateEdit deOrderDate;
        private DevExpress.XtraEditors.ButtonEdit beCustomer;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private System.Windows.Forms.Label lblClientId;
        private DevExpress.XtraEditors.LookUpEdit lueCreateId;
        private System.Windows.Forms.Label lblMerchantId;
        private DevExpress.XtraEditors.DateEdit deCreateTime;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lueOrderType;




    }
}

