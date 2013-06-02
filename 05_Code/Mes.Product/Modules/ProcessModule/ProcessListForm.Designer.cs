
namespace Mes.Product.Modules.ProcessModule
{
    partial class ProcessListForm
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
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.teCode = new DevExpress.XtraEditors.TextEdit();
            this.lblPlanReceiveTimeStart = new System.Windows.Forms.Label();
            this.lblPlanReceiveTimeEnd = new System.Windows.Forms.Label();
            this.lueProductStation = new DevExpress.XtraEditors.LookUpEdit();
            this.lblInboundType = new System.Windows.Forms.Label();
            this.lueProduct = new DevExpress.XtraEditors.LookUpEdit();
            this.lueProductLine = new DevExpress.XtraEditors.LookUpEdit();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductStation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(800, 130);
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            this.gcCondition.Controls.Add(this.panel1);
            this.gcCondition.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gcCondition.Size = new System.Drawing.Size(800, 130);
            // 
            // lblBillStatus
            // 
            this.lblBillStatus.Location = new System.Drawing.Point(221, 56);
            this.lblBillStatus.Name = "lblBillStatus";
            this.lblBillStatus.Size = new System.Drawing.Size(80, 23);
            this.lblBillStatus.TabIndex = 15;
            this.lblBillStatus.Text = "描述：";
            this.lblBillStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLinkBillNumber
            // 
            this.lblLinkBillNumber.Location = new System.Drawing.Point(221, 0);
            this.lblLinkBillNumber.Name = "lblLinkBillNumber";
            this.lblLinkBillNumber.Size = new System.Drawing.Size(80, 23);
            this.lblLinkBillNumber.TabIndex = 8;
            this.lblLinkBillNumber.Text = "工序代码：";
            this.lblLinkBillNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlanNumber
            // 
            this.lblPlanNumber.Location = new System.Drawing.Point(3, 0);
            this.lblPlanNumber.Name = "lblPlanNumber";
            this.lblPlanNumber.Size = new System.Drawing.Size(80, 23);
            this.lblPlanNumber.TabIndex = 0;
            this.lblPlanNumber.Text = "工序名称：";
            this.lblPlanNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layoutCondition
            // 
            this.layoutCondition.ColumnCount = 5;
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.78301F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.7431F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.78301F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.60959F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.335617F));
            this.layoutCondition.Controls.Add(this.lblPlanNumber, 0, 0);
            this.layoutCondition.Controls.Add(this.lblLinkBillNumber, 2, 0);
            this.layoutCondition.Controls.Add(this.teName, 1, 0);
            this.layoutCondition.Controls.Add(this.teCode, 3, 0);
            this.layoutCondition.Controls.Add(this.lblPlanReceiveTimeStart, 0, 1);
            this.layoutCondition.Controls.Add(this.lblPlanReceiveTimeEnd, 2, 1);
            this.layoutCondition.Controls.Add(this.lueProductStation, 1, 2);
            this.layoutCondition.Controls.Add(this.lblInboundType, 0, 2);
            this.layoutCondition.Controls.Add(this.lblBillStatus, 2, 2);
            this.layoutCondition.Controls.Add(this.lueProduct, 1, 1);
            this.layoutCondition.Controls.Add(this.lueProductLine, 3, 1);
            this.layoutCondition.Controls.Add(this.meRemark, 3, 2);
            this.layoutCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutCondition.Location = new System.Drawing.Point(8, 26);
            this.layoutCondition.Name = "layoutCondition";
            this.layoutCondition.RowCount = 3;
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutCondition.Size = new System.Drawing.Size(584, 97);
            this.layoutCondition.TabIndex = 0;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(89, 3);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(126, 20);
            this.teName.TabIndex = 19;
            // 
            // teCode
            // 
            this.teCode.Location = new System.Drawing.Point(307, 3);
            this.teCode.Name = "teCode";
            this.teCode.Size = new System.Drawing.Size(129, 20);
            this.teCode.TabIndex = 20;
            // 
            // lblPlanReceiveTimeStart
            // 
            this.lblPlanReceiveTimeStart.Location = new System.Drawing.Point(3, 28);
            this.lblPlanReceiveTimeStart.Name = "lblPlanReceiveTimeStart";
            this.lblPlanReceiveTimeStart.Size = new System.Drawing.Size(80, 23);
            this.lblPlanReceiveTimeStart.TabIndex = 12;
            this.lblPlanReceiveTimeStart.Text = "产品代码:";
            this.lblPlanReceiveTimeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlanReceiveTimeEnd
            // 
            this.lblPlanReceiveTimeEnd.Location = new System.Drawing.Point(221, 28);
            this.lblPlanReceiveTimeEnd.Name = "lblPlanReceiveTimeEnd";
            this.lblPlanReceiveTimeEnd.Size = new System.Drawing.Size(80, 23);
            this.lblPlanReceiveTimeEnd.TabIndex = 7;
            this.lblPlanReceiveTimeEnd.Text = "产线代码：";
            this.lblPlanReceiveTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lueProductStation
            // 
            this.lueProductStation.Location = new System.Drawing.Point(89, 59);
            this.lueProductStation.Name = "lueProductStation";
            this.lueProductStation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProductStation.Properties.NullText = "";
            this.lueProductStation.Size = new System.Drawing.Size(126, 20);
            this.lueProductStation.TabIndex = 131;
            // 
            // lblInboundType
            // 
            this.lblInboundType.Location = new System.Drawing.Point(3, 56);
            this.lblInboundType.Name = "lblInboundType";
            this.lblInboundType.Size = new System.Drawing.Size(80, 23);
            this.lblInboundType.TabIndex = 18;
            this.lblInboundType.Text = "对应工位：";
            this.lblInboundType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lueProduct
            // 
            this.lueProduct.Location = new System.Drawing.Point(89, 31);
            this.lueProduct.Name = "lueProduct";
            this.lueProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProduct.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "商品")});
            this.lueProduct.Properties.DisplayMember = "Key";
            this.lueProduct.Properties.NullText = "";
            this.lueProduct.Properties.ValueMember = "Value";
            this.lueProduct.Size = new System.Drawing.Size(126, 20);
            this.lueProduct.TabIndex = 131;
            // 
            // lueProductLine
            // 
            this.lueProductLine.Location = new System.Drawing.Point(307, 31);
            this.lueProductLine.Name = "lueProductLine";
            this.lueProductLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProductLine.Properties.NullText = "";
            this.lueProductLine.Size = new System.Drawing.Size(126, 20);
            this.lueProductLine.TabIndex = 131;
            // 
            // meRemark
            // 
            this.meRemark.Location = new System.Drawing.Point(307, 59);
            this.meRemark.MenuManager = this.bmMaster;
            this.meRemark.Name = "meRemark";
            this.meRemark.Size = new System.Drawing.Size(224, 35);
            this.meRemark.TabIndex = 132;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(592, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 97);
            this.panel1.TabIndex = 1;
            // 
            // ProcessListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ProcessListForm";
            this.PageNumber = 1;
            this.PageSize = 100;
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductStation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBillStatus;
        private System.Windows.Forms.Label lblLinkBillNumber;
        private System.Windows.Forms.Label lblPlanNumber;
        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblInboundType;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.TextEdit teCode;
        private DevExpress.XtraEditors.LookUpEdit lueProductStation;
        private System.Windows.Forms.Label lblPlanReceiveTimeStart;
        private System.Windows.Forms.Label lblPlanReceiveTimeEnd;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LookUpEdit lueProductLine;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private DevExpress.XtraEditors.LookUpEdit lueProduct;

        

    }
}

