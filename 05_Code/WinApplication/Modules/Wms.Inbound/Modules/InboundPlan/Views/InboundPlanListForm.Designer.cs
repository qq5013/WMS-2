
namespace Modules.InboundPlanModule.Views
{
    partial class InboundPlanListForm
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
            this.lblLinkBillNumber = new System.Windows.Forms.Label();
            this.lblPlanNumber = new System.Windows.Forms.Label();
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.txtPlanNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtLinkBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblPlanReceiveTimeStart = new System.Windows.Forms.Label();
            this.lblPlanReceiveTimeEnd = new System.Windows.Forms.Label();
            this.leInboundType = new DevExpress.XtraEditors.LookUpEdit();
            this.lblInboundType = new System.Windows.Forms.Label();
            this.leBillStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.dePlanReceiveTimeStart = new DevExpress.XtraEditors.DateEdit();
            this.dePlanReceiveTimeEnd = new DevExpress.XtraEditors.DateEdit();
            this.beMerchantId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblMerchantId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leInboundType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanReceiveTimeStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanReceiveTimeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanReceiveTimeEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanReceiveTimeEnd.Properties)).BeginInit();
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
            // lblLinkBillNumber
            // 
            this.lblLinkBillNumber.Location = new System.Drawing.Point(260, 28);
            this.lblLinkBillNumber.Name = "lblLinkBillNumber";
            this.lblLinkBillNumber.Size = new System.Drawing.Size(81, 23);
            this.lblLinkBillNumber.TabIndex = 8;
            this.lblLinkBillNumber.Text = "关联单据号：";
            this.lblLinkBillNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlanNumber
            // 
            this.lblPlanNumber.Location = new System.Drawing.Point(3, 28);
            this.lblPlanNumber.Name = "lblPlanNumber";
            this.lblPlanNumber.Size = new System.Drawing.Size(95, 23);
            this.lblPlanNumber.TabIndex = 0;
            this.lblPlanNumber.Text = "入库计划单号：";
            this.lblPlanNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.layoutCondition.Controls.Add(this.lblInboundType, 0, 3);
            this.layoutCondition.Controls.Add(this.leInboundType, 1, 3);
            this.layoutCondition.Controls.Add(this.lblBillStatus, 2, 3);
            this.layoutCondition.Controls.Add(this.leBillStatus, 3, 3);
            this.layoutCondition.Controls.Add(this.dePlanReceiveTimeEnd, 3, 2);
            this.layoutCondition.Controls.Add(this.lblPlanReceiveTimeEnd, 2, 2);
            this.layoutCondition.Controls.Add(this.dePlanReceiveTimeStart, 1, 2);
            this.layoutCondition.Controls.Add(this.lblPlanReceiveTimeStart, 0, 2);
            this.layoutCondition.Controls.Add(this.lblPlanNumber, 0, 1);
            this.layoutCondition.Controls.Add(this.txtPlanNumber, 1, 1);
            this.layoutCondition.Controls.Add(this.lblLinkBillNumber, 2, 1);
            this.layoutCondition.Controls.Add(this.txtLinkBillNumber, 3, 1);
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
            // txtPlanNumber
            // 
            this.txtPlanNumber.Location = new System.Drawing.Point(104, 31);
            this.txtPlanNumber.Name = "txtPlanNumber";
            this.txtPlanNumber.Size = new System.Drawing.Size(150, 20);
            this.txtPlanNumber.TabIndex = 19;
            // 
            // txtLinkBillNumber
            // 
            this.txtLinkBillNumber.Location = new System.Drawing.Point(361, 31);
            this.txtLinkBillNumber.Name = "txtLinkBillNumber";
            this.txtLinkBillNumber.Size = new System.Drawing.Size(150, 20);
            this.txtLinkBillNumber.TabIndex = 20;
            // 
            // lblPlanReceiveTimeStart
            // 
            this.lblPlanReceiveTimeStart.Location = new System.Drawing.Point(3, 56);
            this.lblPlanReceiveTimeStart.Name = "lblPlanReceiveTimeStart";
            this.lblPlanReceiveTimeStart.Size = new System.Drawing.Size(95, 23);
            this.lblPlanReceiveTimeStart.TabIndex = 12;
            this.lblPlanReceiveTimeStart.Text = "计划时间(起)：";
            this.lblPlanReceiveTimeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlanReceiveTimeEnd
            // 
            this.lblPlanReceiveTimeEnd.Location = new System.Drawing.Point(260, 56);
            this.lblPlanReceiveTimeEnd.Name = "lblPlanReceiveTimeEnd";
            this.lblPlanReceiveTimeEnd.Size = new System.Drawing.Size(95, 23);
            this.lblPlanReceiveTimeEnd.TabIndex = 7;
            this.lblPlanReceiveTimeEnd.Text = "计划时间(止)：";
            this.lblPlanReceiveTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leInboundType
            // 
            this.leInboundType.Location = new System.Drawing.Point(104, 87);
            this.leInboundType.Name = "leInboundType";
            this.leInboundType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.leInboundType.Properties.NullText = "";
            this.leInboundType.Size = new System.Drawing.Size(150, 20);
            this.leInboundType.TabIndex = 131;
            this.leInboundType.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.leInboundType_ButtonPressed);
            // 
            // lblInboundType
            // 
            this.lblInboundType.Location = new System.Drawing.Point(3, 84);
            this.lblInboundType.Name = "lblInboundType";
            this.lblInboundType.Size = new System.Drawing.Size(81, 23);
            this.lblInboundType.TabIndex = 18;
            this.lblInboundType.Text = "入库类型：";
            this.lblInboundType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // dePlanReceiveTimeStart
            // 
            this.dePlanReceiveTimeStart.EditValue = null;
            this.dePlanReceiveTimeStart.Location = new System.Drawing.Point(104, 59);
            this.dePlanReceiveTimeStart.MenuManager = this.bmMaster;
            this.dePlanReceiveTimeStart.Name = "dePlanReceiveTimeStart";
            this.dePlanReceiveTimeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePlanReceiveTimeStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dePlanReceiveTimeStart.Size = new System.Drawing.Size(150, 20);
            this.dePlanReceiveTimeStart.TabIndex = 133;
            // 
            // dePlanReceiveTimeEnd
            // 
            this.dePlanReceiveTimeEnd.EditValue = null;
            this.dePlanReceiveTimeEnd.Location = new System.Drawing.Point(361, 59);
            this.dePlanReceiveTimeEnd.MenuManager = this.bmMaster;
            this.dePlanReceiveTimeEnd.Name = "dePlanReceiveTimeEnd";
            this.dePlanReceiveTimeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePlanReceiveTimeEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dePlanReceiveTimeEnd.Size = new System.Drawing.Size(150, 20);
            this.dePlanReceiveTimeEnd.TabIndex = 134;
            // 
            // beMerchantId
            // 
            this.beMerchantId.Location = new System.Drawing.Point(104, 3);
            this.beMerchantId.Name = "beMerchantId";
            this.beMerchantId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.beMerchantId.Size = new System.Drawing.Size(150, 20);
            this.beMerchantId.TabIndex = 161;
            this.beMerchantId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beMerchantId_ButtonClick);
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.Location = new System.Drawing.Point(3, 0);
            this.lblMerchantId.Name = "lblMerchantId";
            this.lblMerchantId.Size = new System.Drawing.Size(81, 23);
            this.lblMerchantId.TabIndex = 162;
            this.lblMerchantId.Text = " 货主：";
            this.lblMerchantId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InboundPlanListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "InboundPlanListForm";
            this.PageNumber = 1;
            this.PageSize = 100;
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leInboundType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanReceiveTimeStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanReceiveTimeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanReceiveTimeEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanReceiveTimeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBillStatus;
        private System.Windows.Forms.Label lblLinkBillNumber;
        private System.Windows.Forms.Label lblPlanNumber;
        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblInboundType;
        private DevExpress.XtraEditors.TextEdit txtPlanNumber;
        private DevExpress.XtraEditors.TextEdit txtLinkBillNumber;
        private DevExpress.XtraEditors.LookUpEdit leInboundType;
        private DevExpress.XtraEditors.LookUpEdit leBillStatus;
        private System.Windows.Forms.Label lblPlanReceiveTimeStart;
        private System.Windows.Forms.Label lblPlanReceiveTimeEnd;
        private DevExpress.XtraEditors.DateEdit dePlanReceiveTimeStart;
        private DevExpress.XtraEditors.DateEdit dePlanReceiveTimeEnd;
        private DevExpress.XtraEditors.ButtonEdit beMerchantId;
        private System.Windows.Forms.Label lblMerchantId;

        

    }
}

