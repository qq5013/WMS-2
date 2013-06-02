
namespace Modules.OutboundBillModule.Views
{
    partial class OutboundBillListForm
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
            this.lblMerchantId = new System.Windows.Forms.Label();
            this.lblPickBillId = new System.Windows.Forms.Label();
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.leBillStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.lblReceiveTimeStart = new System.Windows.Forms.Label();
            this.deIssueTimeStart = new DevExpress.XtraEditors.DateEdit();
            this.txtPickBillId = new DevExpress.XtraEditors.TextEdit();
            this.beMerchantId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.txtBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblPlanId = new System.Windows.Forms.Label();
            this.bePlanId = new DevExpress.XtraEditors.ButtonEdit();
            this.deIssueTimeEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblReceiveTimeEnd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueTimeStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueTimeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickBillId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePlanId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueTimeEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueTimeEnd.Properties)).BeginInit();
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
            this.lblBillStatus.Location = new System.Drawing.Point(3, 84);
            this.lblBillStatus.Name = "lblBillStatus";
            this.lblBillStatus.Size = new System.Drawing.Size(81, 23);
            this.lblBillStatus.TabIndex = 15;
            this.lblBillStatus.Text = "单据状态：";
            this.lblBillStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.Location = new System.Drawing.Point(3, 0);
            this.lblMerchantId.Name = "lblMerchantId";
            this.lblMerchantId.Size = new System.Drawing.Size(81, 23);
            this.lblMerchantId.TabIndex = 8;
            this.lblMerchantId.Text = "货主：";
            this.lblMerchantId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPickBillId
            // 
            this.lblPickBillId.Location = new System.Drawing.Point(260, 0);
            this.lblPickBillId.Name = "lblPickBillId";
            this.lblPickBillId.Size = new System.Drawing.Size(81, 23);
            this.lblPickBillId.TabIndex = 0;
            this.lblPickBillId.Text = "拣选单号：";
            this.lblPickBillId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPickBillId.Visible = false;
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
            this.layoutCondition.Controls.Add(this.lblPlanId, 0, 1);
            this.layoutCondition.Controls.Add(this.bePlanId, 1, 1);
            this.layoutCondition.Controls.Add(this.lblBillNumber, 2, 1);
            this.layoutCondition.Controls.Add(this.txtBillNumber, 3, 1);
            this.layoutCondition.Controls.Add(this.lblPickBillId, 2, 0);
            this.layoutCondition.Controls.Add(this.txtPickBillId, 3, 0);
            this.layoutCondition.Controls.Add(this.lblReceiveTimeStart, 0, 2);
            this.layoutCondition.Controls.Add(this.deIssueTimeStart, 1, 2);
            this.layoutCondition.Controls.Add(this.lblReceiveTimeEnd, 2, 2);
            this.layoutCondition.Controls.Add(this.deIssueTimeEnd, 3, 2);
            this.layoutCondition.Controls.Add(this.lblBillStatus, 0, 3);
            this.layoutCondition.Controls.Add(this.leBillStatus, 1, 3);
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
            // leBillStatus
            // 
            this.leBillStatus.Location = new System.Drawing.Point(104, 87);
            this.leBillStatus.Name = "leBillStatus";
            this.leBillStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.leBillStatus.Properties.NullText = "";
            this.leBillStatus.Size = new System.Drawing.Size(150, 20);
            this.leBillStatus.TabIndex = 132;
            this.leBillStatus.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.leBillStatus_ButtonPressed);
            // 
            // lblReceiveTimeStart
            // 
            this.lblReceiveTimeStart.Location = new System.Drawing.Point(3, 56);
            this.lblReceiveTimeStart.Name = "lblReceiveTimeStart";
            this.lblReceiveTimeStart.Size = new System.Drawing.Size(95, 23);
            this.lblReceiveTimeStart.TabIndex = 12;
            this.lblReceiveTimeStart.Text = "发货时间(起)：";
            this.lblReceiveTimeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deIssueTimeStart
            // 
            this.deIssueTimeStart.EditValue = null;
            this.deIssueTimeStart.Location = new System.Drawing.Point(104, 59);
            this.deIssueTimeStart.MenuManager = this.bmMaster;
            this.deIssueTimeStart.Name = "deIssueTimeStart";
            this.deIssueTimeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deIssueTimeStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deIssueTimeStart.Size = new System.Drawing.Size(150, 20);
            this.deIssueTimeStart.TabIndex = 133;
            // 
            // txtPickBillId
            // 
            this.txtPickBillId.Location = new System.Drawing.Point(361, 3);
            this.txtPickBillId.Name = "txtPickBillId";
            this.txtPickBillId.Size = new System.Drawing.Size(150, 20);
            this.txtPickBillId.TabIndex = 158;
            this.txtPickBillId.Visible = false;
            // 
            // beMerchantId
            // 
            this.beMerchantId.Location = new System.Drawing.Point(104, 3);
            this.beMerchantId.Name = "beMerchantId";
            this.beMerchantId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.beMerchantId.Size = new System.Drawing.Size(150, 20);
            this.beMerchantId.TabIndex = 157;
            this.beMerchantId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beMerchantId_ButtonClick);
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.Location = new System.Drawing.Point(260, 28);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(81, 23);
            this.lblBillNumber.TabIndex = 18;
            this.lblBillNumber.Text = "出库单号：";
            this.lblBillNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(361, 31);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(150, 20);
            this.txtBillNumber.TabIndex = 156;
            // 
            // lblPlanId
            // 
            this.lblPlanId.Location = new System.Drawing.Point(3, 28);
            this.lblPlanId.Name = "lblPlanId";
            this.lblPlanId.Size = new System.Drawing.Size(81, 23);
            this.lblPlanId.TabIndex = 7;
            this.lblPlanId.Text = "出库计划：";
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
            // deIssueTimeEnd
            // 
            this.deIssueTimeEnd.EditValue = null;
            this.deIssueTimeEnd.Location = new System.Drawing.Point(361, 59);
            this.deIssueTimeEnd.MenuManager = this.bmMaster;
            this.deIssueTimeEnd.Name = "deIssueTimeEnd";
            this.deIssueTimeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deIssueTimeEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deIssueTimeEnd.Size = new System.Drawing.Size(150, 20);
            this.deIssueTimeEnd.TabIndex = 159;
            // 
            // lblReceiveTimeEnd
            // 
            this.lblReceiveTimeEnd.Location = new System.Drawing.Point(260, 56);
            this.lblReceiveTimeEnd.Name = "lblReceiveTimeEnd";
            this.lblReceiveTimeEnd.Size = new System.Drawing.Size(95, 23);
            this.lblReceiveTimeEnd.TabIndex = 160;
            this.lblReceiveTimeEnd.Text = "发货时间(止)：";
            this.lblReceiveTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutboundBillListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "OutboundBillListForm";
            this.PageNumber = 1;
            this.PageSize = 100;
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueTimeStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueTimeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickBillId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePlanId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueTimeEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueTimeEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBillStatus;
        private System.Windows.Forms.Label lblMerchantId;
        private System.Windows.Forms.Label lblPickBillId;
        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblBillNumber;
        private DevExpress.XtraEditors.LookUpEdit leBillStatus;
        private System.Windows.Forms.Label lblReceiveTimeStart;
        private System.Windows.Forms.Label lblPlanId;
        private DevExpress.XtraEditors.DateEdit deIssueTimeStart;
        private DevExpress.XtraEditors.ButtonEdit bePlanId;
        private DevExpress.XtraEditors.TextEdit txtBillNumber;
        private DevExpress.XtraEditors.ButtonEdit beMerchantId;
        private DevExpress.XtraEditors.TextEdit txtPickBillId;
        private System.Windows.Forms.Label lblReceiveTimeEnd;
        private DevExpress.XtraEditors.DateEdit deIssueTimeEnd;

        

    }
}

