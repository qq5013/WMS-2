
namespace Modules.CountBillModule.Views
{
    partial class CountBillListForm
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
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.txtBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblPlanCountDateStart = new System.Windows.Forms.Label();
            this.dePlanCountDateStart = new DevExpress.XtraEditors.DateEdit();
            this.leBillStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPlanCountDateEnd = new System.Windows.Forms.Label();
            this.dePlanCountDateEnd = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanCountDateStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanCountDateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanCountDateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanCountDateEnd.Properties)).BeginInit();
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
            this.lblBillStatus.Location = new System.Drawing.Point(3, 56);
            this.lblBillStatus.Name = "lblBillStatus";
            this.lblBillStatus.Size = new System.Drawing.Size(81, 23);
            this.lblBillStatus.TabIndex = 15;
            this.lblBillStatus.Text = "单据状态：";
            this.lblBillStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.Location = new System.Drawing.Point(3, 0);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(81, 23);
            this.lblBillNumber.TabIndex = 8;
            this.lblBillNumber.Text = "盘点单号：";
            this.lblBillNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layoutCondition
            // 
            this.layoutCondition.ColumnCount = 6;
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutCondition.Controls.Add(this.lblBillNumber, 0, 0);
            this.layoutCondition.Controls.Add(this.txtBillNumber, 1, 0);
            this.layoutCondition.Controls.Add(this.lblPlanCountDateStart, 0, 1);
            this.layoutCondition.Controls.Add(this.dePlanCountDateStart, 1, 1);
            this.layoutCondition.Controls.Add(this.lblBillStatus, 0, 2);
            this.layoutCondition.Controls.Add(this.leBillStatus, 1, 2);
            this.layoutCondition.Controls.Add(this.lblPlanCountDateEnd, 2, 1);
            this.layoutCondition.Controls.Add(this.dePlanCountDateEnd, 3, 1);
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
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(120, 3);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(150, 20);
            this.txtBillNumber.TabIndex = 20;
            // 
            // lblPlanCountDateStart
            // 
            this.lblPlanCountDateStart.Location = new System.Drawing.Point(3, 28);
            this.lblPlanCountDateStart.Name = "lblPlanCountDateStart";
            this.lblPlanCountDateStart.Size = new System.Drawing.Size(111, 23);
            this.lblPlanCountDateStart.TabIndex = 12;
            this.lblPlanCountDateStart.Text = "计划盘点日期(起)：";
            this.lblPlanCountDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dePlanCountDateStart
            // 
            this.dePlanCountDateStart.EditValue = null;
            this.dePlanCountDateStart.Location = new System.Drawing.Point(120, 31);
            this.dePlanCountDateStart.MenuManager = this.bmMaster;
            this.dePlanCountDateStart.Name = "dePlanCountDateStart";
            this.dePlanCountDateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePlanCountDateStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dePlanCountDateStart.Size = new System.Drawing.Size(150, 20);
            this.dePlanCountDateStart.TabIndex = 133;
            // 
            // leBillStatus
            // 
            this.leBillStatus.Location = new System.Drawing.Point(120, 59);
            this.leBillStatus.Name = "leBillStatus";
            this.leBillStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.leBillStatus.Properties.NullText = "";
            this.leBillStatus.Size = new System.Drawing.Size(150, 20);
            this.leBillStatus.TabIndex = 132;
            this.leBillStatus.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.leBillStatus_ButtonPressed);
            // 
            // lblPlanCountDateEnd
            // 
            this.lblPlanCountDateEnd.Location = new System.Drawing.Point(276, 28);
            this.lblPlanCountDateEnd.Name = "lblPlanCountDateEnd";
            this.lblPlanCountDateEnd.Size = new System.Drawing.Size(111, 23);
            this.lblPlanCountDateEnd.TabIndex = 160;
            this.lblPlanCountDateEnd.Text = "计划盘点日期(止)：";
            this.lblPlanCountDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dePlanCountDateEnd
            // 
            this.dePlanCountDateEnd.EditValue = null;
            this.dePlanCountDateEnd.Location = new System.Drawing.Point(393, 31);
            this.dePlanCountDateEnd.MenuManager = this.bmMaster;
            this.dePlanCountDateEnd.Name = "dePlanCountDateEnd";
            this.dePlanCountDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePlanCountDateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dePlanCountDateEnd.Size = new System.Drawing.Size(150, 20);
            this.dePlanCountDateEnd.TabIndex = 159;
            // 
            // CountBillListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "CountBillListForm";
            this.PageNumber = 1;
            this.PageSize = 100;
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanCountDateStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanCountDateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBillStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanCountDateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePlanCountDateEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBillStatus;
        private System.Windows.Forms.Label lblBillNumber;
        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private DevExpress.XtraEditors.TextEdit txtBillNumber;
        private DevExpress.XtraEditors.LookUpEdit leBillStatus;
        private System.Windows.Forms.Label lblPlanCountDateStart;
        private DevExpress.XtraEditors.DateEdit dePlanCountDateStart;
        private DevExpress.XtraEditors.DateEdit dePlanCountDateEnd;
        private System.Windows.Forms.Label lblPlanCountDateEnd;

        

    }
}

