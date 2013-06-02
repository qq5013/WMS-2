
namespace Modules.OutboundPlanModule.Views
{
    partial class OutboundPlanListForm
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
            this.lblOutboundType = new System.Windows.Forms.Label();
            this.leBillStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPlanIssueTimeStart = new System.Windows.Forms.Label();
            this.leOutboundType = new DevExpress.XtraEditors.LookUpEdit();
            this.dePlanIssueTimeStart = new DevExpress.XtraEditors.DateEdit();
            this.txtPlanNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblMerchantId = new System.Windows.Forms.Label();
            this.beMerchantId = new DevExpress.XtraEditors.ButtonEdit();
            this.txtLinkBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.dePlanIssueTimeEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblPlanIssueTimeEnd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leOutboundType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanIssueTimeStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanIssueTimeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanIssueTimeEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanIssueTimeEnd.Properties)).BeginInit();
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
            this.lblPlanNumber.Text = "出库计划号：";
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
            this.layoutCondition.Controls.Add(this.lblMerchantId, 0, 0);
            this.layoutCondition.Controls.Add(this.beMerchantId, 1, 0);
            this.layoutCondition.Controls.Add(this.txtLinkBillNumber, 3, 1);
            this.layoutCondition.Controls.Add(this.lblLinkBillNumber, 2, 1);
            this.layoutCondition.Controls.Add(this.lblPlanNumber, 0, 1);
            this.layoutCondition.Controls.Add(this.txtPlanNumber, 1, 1);
            this.layoutCondition.Controls.Add(this.lblPlanIssueTimeStart, 0, 2);
            this.layoutCondition.Controls.Add(this.dePlanIssueTimeStart, 1, 2);
            this.layoutCondition.Controls.Add(this.lblPlanIssueTimeEnd, 2, 2);
            this.layoutCondition.Controls.Add(this.dePlanIssueTimeEnd, 3, 2);
            this.layoutCondition.Controls.Add(this.lblOutboundType, 0, 3);
            this.layoutCondition.Controls.Add(this.leOutboundType, 1, 3);
            this.layoutCondition.Controls.Add(this.lblBillStatus, 2, 3);
            this.layoutCondition.Controls.Add(this.leBillStatus, 3, 3);
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
            // lblOutboundType
            // 
            this.lblOutboundType.Location = new System.Drawing.Point(3, 84);
            this.lblOutboundType.Name = "lblOutboundType";
            this.lblOutboundType.Size = new System.Drawing.Size(81, 23);
            this.lblOutboundType.TabIndex = 18;
            this.lblOutboundType.Text = "出库类型：";
            this.lblOutboundType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lblPlanIssueTimeStart
            // 
            this.lblPlanIssueTimeStart.Location = new System.Drawing.Point(3, 56);
            this.lblPlanIssueTimeStart.Name = "lblPlanIssueTimeStart";
            this.lblPlanIssueTimeStart.Size = new System.Drawing.Size(95, 23);
            this.lblPlanIssueTimeStart.TabIndex = 12;
            this.lblPlanIssueTimeStart.Text = "计划日期(起)：";
            this.lblPlanIssueTimeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leOutboundType
            // 
            this.leOutboundType.Location = new System.Drawing.Point(104, 87);
            this.leOutboundType.Name = "leOutboundType";
            this.leOutboundType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.leOutboundType.Properties.NullText = "";
            this.leOutboundType.Size = new System.Drawing.Size(150, 20);
            this.leOutboundType.TabIndex = 131;
            this.leOutboundType.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.leOutboundType_ButtonPressed);
            // 
            // dePlanIssueTimeStart
            // 
            this.dePlanIssueTimeStart.EditValue = null;
            this.dePlanIssueTimeStart.Location = new System.Drawing.Point(104, 59);
            this.dePlanIssueTimeStart.MenuManager = this.bmMaster;
            this.dePlanIssueTimeStart.Name = "dePlanIssueTimeStart";
            this.dePlanIssueTimeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePlanIssueTimeStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dePlanIssueTimeStart.Size = new System.Drawing.Size(150, 20);
            this.dePlanIssueTimeStart.TabIndex = 133;
            // 
            // txtPlanNumber
            // 
            this.txtPlanNumber.Location = new System.Drawing.Point(104, 31);
            this.txtPlanNumber.Name = "txtPlanNumber";
            this.txtPlanNumber.Size = new System.Drawing.Size(150, 20);
            this.txtPlanNumber.TabIndex = 19;
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.Location = new System.Drawing.Point(3, 0);
            this.lblMerchantId.Name = "lblMerchantId";
            this.lblMerchantId.Size = new System.Drawing.Size(81, 23);
            this.lblMerchantId.TabIndex = 134;
            this.lblMerchantId.Text = "货主：";
            this.lblMerchantId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // beMerchantId
            // 
            this.beMerchantId.Location = new System.Drawing.Point(104, 3);
            this.beMerchantId.Name = "beMerchantId";
            this.beMerchantId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.beMerchantId.Size = new System.Drawing.Size(150, 20);
            this.beMerchantId.TabIndex = 158;
            this.beMerchantId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beMerchantId_ButtonClick);
            // 
            // txtLinkBillNumber
            // 
            this.txtLinkBillNumber.Location = new System.Drawing.Point(361, 31);
            this.txtLinkBillNumber.Name = "txtLinkBillNumber";
            this.txtLinkBillNumber.Size = new System.Drawing.Size(150, 20);
            this.txtLinkBillNumber.TabIndex = 20;
            // 
            // dePlanIssueTimeEnd
            // 
            this.dePlanIssueTimeEnd.EditValue = null;
            this.dePlanIssueTimeEnd.Location = new System.Drawing.Point(361, 59);
            this.dePlanIssueTimeEnd.MenuManager = this.bmMaster;
            this.dePlanIssueTimeEnd.Name = "dePlanIssueTimeEnd";
            this.dePlanIssueTimeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePlanIssueTimeEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dePlanIssueTimeEnd.Size = new System.Drawing.Size(150, 20);
            this.dePlanIssueTimeEnd.TabIndex = 159;
            // 
            // lblPlanIssueTimeEnd
            // 
            this.lblPlanIssueTimeEnd.Location = new System.Drawing.Point(260, 56);
            this.lblPlanIssueTimeEnd.Name = "lblPlanIssueTimeEnd";
            this.lblPlanIssueTimeEnd.Size = new System.Drawing.Size(95, 23);
            this.lblPlanIssueTimeEnd.TabIndex = 160;
            this.lblPlanIssueTimeEnd.Text = "计划日期(止)：";
            this.lblPlanIssueTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutboundPlanListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "OutboundPlanListForm";
            this.PageNumber = 1;
            this.PageSize = 100;
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leOutboundType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanIssueTimeStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanIssueTimeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanIssueTimeEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanIssueTimeEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBillStatus;
        private System.Windows.Forms.Label lblLinkBillNumber;
        private System.Windows.Forms.Label lblPlanNumber;
        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblOutboundType;
        private DevExpress.XtraEditors.TextEdit txtPlanNumber;
        private DevExpress.XtraEditors.TextEdit txtLinkBillNumber;
        private DevExpress.XtraEditors.LookUpEdit leOutboundType;
        private DevExpress.XtraEditors.LookUpEdit leBillStatus;
        private System.Windows.Forms.Label lblPlanIssueTimeStart;
        private DevExpress.XtraEditors.DateEdit dePlanIssueTimeStart;
        private System.Windows.Forms.Label lblMerchantId;
        private DevExpress.XtraEditors.ButtonEdit beMerchantId;
        private DevExpress.XtraEditors.DateEdit dePlanIssueTimeEnd;
        private System.Windows.Forms.Label lblPlanIssueTimeEnd;

        

    }
}

