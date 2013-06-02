
namespace Modules.InboundBillModule.Views
{
    partial class InboundBillListForm
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
            this.lblBillStatus = new System.Windows.Forms.Label();
            this.lblVendorId = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.beReceiveLocationId = new DevExpress.XtraEditors.ButtonEdit();
            this.beVendorId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblPlanId = new System.Windows.Forms.Label();
            this.bePlanId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.txtBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.deReceiveTimeStart = new DevExpress.XtraEditors.DateEdit();
            this.leBillStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.deReceiveTimeEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblReceiveTimeEnd = new System.Windows.Forms.Label();
            this.lblReceiveTimeStart = new System.Windows.Forms.Label();
            this.beMerchantId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblMerchantId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beReceiveLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beVendorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePlanId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceiveTimeStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceiveTimeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceiveTimeEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceiveTimeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(800, 150);
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            this.gcCondition.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gcCondition.Size = new System.Drawing.Size(800, 150);
            // 
            // lblBillStatus
            // 
            this.lblBillStatus.Location = new System.Drawing.Point(260, 84);
            this.lblBillStatus.Name = "lblBillStatus";
            this.lblBillStatus.Size = new System.Drawing.Size(81, 23);
            this.lblBillStatus.TabIndex = 15;
            this.lblBillStatus.Text = "单据状态：";
            this.lblBillStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVendorId
            // 
            this.lblVendorId.Location = new System.Drawing.Point(260, 0);
            this.lblVendorId.Name = "lblVendorId";
            this.lblVendorId.Size = new System.Drawing.Size(81, 23);
            this.lblVendorId.TabIndex = 8;
            this.lblVendorId.Text = "供应商：";
            this.lblVendorId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(3, 84);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(81, 23);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "收货库位：";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.layoutCondition.Controls.Add(this.lblPlanId, 0, 1);
            this.layoutCondition.Controls.Add(this.bePlanId, 1, 1);
            this.layoutCondition.Controls.Add(this.lblBillNumber, 2, 1);
            this.layoutCondition.Controls.Add(this.txtBillNumber, 3, 1);
            this.layoutCondition.Controls.Add(this.deReceiveTimeStart, 1, 2);
            this.layoutCondition.Controls.Add(this.deReceiveTimeEnd, 3, 2);
            this.layoutCondition.Controls.Add(this.lblReceiveTimeEnd, 2, 2);
            this.layoutCondition.Controls.Add(this.lblReceiveTimeStart, 0, 2);
            this.layoutCondition.Controls.Add(this.leBillStatus, 3, 3);
            this.layoutCondition.Controls.Add(this.lblBillStatus, 2, 3);
            this.layoutCondition.Controls.Add(this.lbl, 0, 3);
            this.layoutCondition.Controls.Add(this.beReceiveLocationId, 1, 3);
            this.layoutCondition.Controls.Add(this.beVendorId, 3, 0);
            this.layoutCondition.Controls.Add(this.lblVendorId, 2, 0);
            this.layoutCondition.Controls.Add(this.beMerchantId, 1, 0);
            this.layoutCondition.Controls.Add(this.lblMerchantId, 0, 0);
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
            // beReceiveLocationId
            // 
            this.beReceiveLocationId.Location = new System.Drawing.Point(104, 87);
            this.beReceiveLocationId.Name = "beReceiveLocationId";
            this.beReceiveLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.beReceiveLocationId.Size = new System.Drawing.Size(150, 20);
            this.beReceiveLocationId.TabIndex = 154;
            this.beReceiveLocationId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beReceiveLocationId_ButtonClick);
            // 
            // beVendorId
            // 
            this.beVendorId.Location = new System.Drawing.Point(361, 3);
            this.beVendorId.Name = "beVendorId";
            this.beVendorId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.beVendorId.Size = new System.Drawing.Size(150, 20);
            this.beVendorId.TabIndex = 157;
            this.beVendorId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beVendorId_ButtonClick);
            // 
            // lblPlanId
            // 
            this.lblPlanId.Location = new System.Drawing.Point(3, 28);
            this.lblPlanId.Name = "lblPlanId";
            this.lblPlanId.Size = new System.Drawing.Size(81, 23);
            this.lblPlanId.TabIndex = 7;
            this.lblPlanId.Text = "入库计划：";
            this.lblPlanId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bePlanId
            // 
            this.bePlanId.Location = new System.Drawing.Point(104, 31);
            this.bePlanId.Name = "bePlanId";
            this.bePlanId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.bePlanId.Size = new System.Drawing.Size(150, 20);
            this.bePlanId.TabIndex = 155;
            this.bePlanId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bePlanId_ButtonClick);
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
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(361, 31);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(150, 20);
            this.txtBillNumber.TabIndex = 156;
            // 
            // deReceiveTimeStart
            // 
            this.deReceiveTimeStart.EditValue = null;
            this.deReceiveTimeStart.Location = new System.Drawing.Point(104, 59);
            this.deReceiveTimeStart.MenuManager = this.bmMaster;
            this.deReceiveTimeStart.Name = "deReceiveTimeStart";
            this.deReceiveTimeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReceiveTimeStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deReceiveTimeStart.Size = new System.Drawing.Size(150, 20);
            this.deReceiveTimeStart.TabIndex = 133;
            // 
            // leBillStatus
            // 
            this.leBillStatus.Location = new System.Drawing.Point(361, 87);
            this.leBillStatus.Name = "leBillStatus";
            this.leBillStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.leBillStatus.Properties.NullText = "";
            this.leBillStatus.Size = new System.Drawing.Size(150, 20);
            this.leBillStatus.TabIndex = 132;
            this.leBillStatus.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.leBillStatus_ButtonPressed);
            // 
            // deReceiveTimeEnd
            // 
            this.deReceiveTimeEnd.EditValue = null;
            this.deReceiveTimeEnd.Location = new System.Drawing.Point(361, 59);
            this.deReceiveTimeEnd.MenuManager = this.bmMaster;
            this.deReceiveTimeEnd.Name = "deReceiveTimeEnd";
            this.deReceiveTimeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReceiveTimeEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deReceiveTimeEnd.Size = new System.Drawing.Size(150, 20);
            this.deReceiveTimeEnd.TabIndex = 158;
            // 
            // lblReceiveTimeEnd
            // 
            this.lblReceiveTimeEnd.Location = new System.Drawing.Point(260, 56);
            this.lblReceiveTimeEnd.Name = "lblReceiveTimeEnd";
            this.lblReceiveTimeEnd.Size = new System.Drawing.Size(95, 23);
            this.lblReceiveTimeEnd.TabIndex = 159;
            this.lblReceiveTimeEnd.Text = "收货时间(止)：";
            this.lblReceiveTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiveTimeStart
            // 
            this.lblReceiveTimeStart.Location = new System.Drawing.Point(3, 56);
            this.lblReceiveTimeStart.Name = "lblReceiveTimeStart";
            this.lblReceiveTimeStart.Size = new System.Drawing.Size(95, 23);
            this.lblReceiveTimeStart.TabIndex = 12;
            this.lblReceiveTimeStart.Text = "收货时间(起)：";
            this.lblReceiveTimeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // beMerchantId
            // 
            this.beMerchantId.Location = new System.Drawing.Point(104, 3);
            this.beMerchantId.Name = "beMerchantId";
            this.beMerchantId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.beMerchantId.Size = new System.Drawing.Size(150, 20);
            this.beMerchantId.TabIndex = 160;
            this.beMerchantId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beMerchantId_ButtonClick);
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.Location = new System.Drawing.Point(3, 0);
            this.lblMerchantId.Name = "lblMerchantId";
            this.lblMerchantId.Size = new System.Drawing.Size(81, 23);
            this.lblMerchantId.TabIndex = 161;
            this.lblMerchantId.Text = " 货主：";
            this.lblMerchantId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InboundBillListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "InboundBillListForm";
            this.PageNumber = 1;
            this.PageSize = 100;
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beReceiveLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beVendorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePlanId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceiveTimeStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceiveTimeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceiveTimeEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReceiveTimeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBillStatus;
        private System.Windows.Forms.Label lblVendorId;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblBillNumber;
        private DevExpress.XtraEditors.LookUpEdit leBillStatus;
        private System.Windows.Forms.Label lblReceiveTimeStart;
        private System.Windows.Forms.Label lblPlanId;
        private DevExpress.XtraEditors.DateEdit deReceiveTimeStart;
        public DevExpress.XtraEditors.ButtonEdit beReceiveLocationId;
        private DevExpress.XtraEditors.ButtonEdit bePlanId;
        private DevExpress.XtraEditors.TextEdit txtBillNumber;
        private DevExpress.XtraEditors.ButtonEdit beVendorId;
        private DevExpress.XtraEditors.DateEdit deReceiveTimeEnd;
        private System.Windows.Forms.Label lblReceiveTimeEnd;
        private DevExpress.XtraEditors.ButtonEdit beMerchantId;
        private System.Windows.Forms.Label lblMerchantId;

        

    }
}

