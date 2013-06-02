
namespace Modules.StockLogModule.Views
{
    partial class StockLogListForm
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
            this.deLogTimeStart = new DevExpress.XtraEditors.DateEdit();
            this.lblLogType = new System.Windows.Forms.Label();
            this.lblLogTimeStart = new System.Windows.Forms.Label();
            this.leLogType = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblLinkBillNumber = new System.Windows.Forms.Label();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.lblSkuNumber = new System.Windows.Forms.Label();
            this.txtLinkBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtSkuNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtBatchNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.txtLocationCode = new DevExpress.XtraEditors.TextEdit();
            this.lblLocationCode = new System.Windows.Forms.Label();
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.txtAreaCode = new DevExpress.XtraEditors.TextEdit();
            this.deLogTimeEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblLogTimeEnd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deLogTimeStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLogTimeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leLogType.Properties)).BeginInit();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLogTimeEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLogTimeEnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcGrid
            // 
            this.gcGrid.Size = new System.Drawing.Size(800, 354);
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            this.gcCondition.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gcCondition.Size = new System.Drawing.Size(800, 175);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Location = new System.Drawing.Point(0, 246);
            this.pnlClientZone.Size = new System.Drawing.Size(800, 354);
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(800, 175);
            // 
            // deLogTimeStart
            // 
            this.deLogTimeStart.EditValue = null;
            this.deLogTimeStart.Location = new System.Drawing.Point(104, 87);
            this.deLogTimeStart.Name = "deLogTimeStart";
            this.deLogTimeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deLogTimeStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deLogTimeStart.Size = new System.Drawing.Size(150, 20);
            this.deLogTimeStart.TabIndex = 166;
            // 
            // lblLogType
            // 
            this.lblLogType.Location = new System.Drawing.Point(3, 112);
            this.lblLogType.Name = "lblLogType";
            this.lblLogType.Size = new System.Drawing.Size(81, 23);
            this.lblLogType.TabIndex = 168;
            this.lblLogType.Text = "日志类型：";
            this.lblLogType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogTimeStart
            // 
            this.lblLogTimeStart.Location = new System.Drawing.Point(3, 84);
            this.lblLogTimeStart.Name = "lblLogTimeStart";
            this.lblLogTimeStart.Size = new System.Drawing.Size(95, 23);
            this.lblLogTimeStart.TabIndex = 169;
            this.lblLogTimeStart.Text = "日志时间(起)：";
            this.lblLogTimeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leLogType
            // 
            this.leLogType.Location = new System.Drawing.Point(104, 115);
            this.leLogType.Name = "leLogType";
            this.leLogType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.leLogType.Properties.NullText = "";
            this.leLogType.Size = new System.Drawing.Size(150, 20);
            this.leLogType.TabIndex = 170;
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
            this.layoutCondition.Controls.Add(this.lblLinkBillNumber, 0, 1);
            this.layoutCondition.Controls.Add(this.lblBillNumber, 2, 1);
            this.layoutCondition.Controls.Add(this.lblSkuNumber, 0, 2);
            this.layoutCondition.Controls.Add(this.txtLinkBillNumber, 1, 1);
            this.layoutCondition.Controls.Add(this.txtBillNumber, 3, 1);
            this.layoutCondition.Controls.Add(this.txtSkuNumber, 1, 2);
            this.layoutCondition.Controls.Add(this.txtBatchNumber, 3, 2);
            this.layoutCondition.Controls.Add(this.lblBatchNumber, 2, 2);
            this.layoutCondition.Controls.Add(this.txtLocationCode, 3, 0);
            this.layoutCondition.Controls.Add(this.lblLocationCode, 2, 0);
            this.layoutCondition.Controls.Add(this.lblAreaCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtAreaCode, 1, 0);
            this.layoutCondition.Controls.Add(this.lblLogType, 0, 4);
            this.layoutCondition.Controls.Add(this.leLogType, 1, 4);
            this.layoutCondition.Controls.Add(this.lblLogTimeStart, 0, 3);
            this.layoutCondition.Controls.Add(this.deLogTimeStart, 1, 3);
            this.layoutCondition.Controls.Add(this.deLogTimeEnd, 3, 3);
            this.layoutCondition.Controls.Add(this.lblLogTimeEnd, 2, 3);
            this.layoutCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutCondition.Location = new System.Drawing.Point(8, 26);
            this.layoutCondition.Name = "layoutCondition";
            this.layoutCondition.RowCount = 5;
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.Size = new System.Drawing.Size(784, 142);
            this.layoutCondition.TabIndex = 171;
            // 
            // lblLinkBillNumber
            // 
            this.lblLinkBillNumber.Location = new System.Drawing.Point(3, 28);
            this.lblLinkBillNumber.Name = "lblLinkBillNumber";
            this.lblLinkBillNumber.Size = new System.Drawing.Size(81, 23);
            this.lblLinkBillNumber.TabIndex = 7;
            this.lblLinkBillNumber.Text = "关联单据号：";
            this.lblLinkBillNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblSkuNumber.Size = new System.Drawing.Size(88, 23);
            this.lblSkuNumber.TabIndex = 12;
            this.lblSkuNumber.Text = "货物代码：";
            this.lblSkuNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLinkBillNumber
            // 
            this.txtLinkBillNumber.Location = new System.Drawing.Point(104, 31);
            this.txtLinkBillNumber.Name = "txtLinkBillNumber";
            this.txtLinkBillNumber.Size = new System.Drawing.Size(150, 20);
            this.txtLinkBillNumber.TabIndex = 167;
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
            this.lblBatchNumber.Size = new System.Drawing.Size(88, 23);
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
            // lblLocationCode
            // 
            this.lblLocationCode.Location = new System.Drawing.Point(260, 0);
            this.lblLocationCode.Name = "lblLocationCode";
            this.lblLocationCode.Size = new System.Drawing.Size(81, 23);
            this.lblLocationCode.TabIndex = 0;
            this.lblLocationCode.Text = "库位代码：";
            this.lblLocationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // txtAreaCode
            // 
            this.txtAreaCode.Location = new System.Drawing.Point(104, 3);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(150, 20);
            this.txtAreaCode.TabIndex = 166;
            // 
            // deLogTimeEnd
            // 
            this.deLogTimeEnd.EditValue = null;
            this.deLogTimeEnd.Location = new System.Drawing.Point(361, 87);
            this.deLogTimeEnd.Name = "deLogTimeEnd";
            this.deLogTimeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deLogTimeEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deLogTimeEnd.Size = new System.Drawing.Size(150, 20);
            this.deLogTimeEnd.TabIndex = 172;
            // 
            // lblLogTimeEnd
            // 
            this.lblLogTimeEnd.Location = new System.Drawing.Point(260, 84);
            this.lblLogTimeEnd.Name = "lblLogTimeEnd";
            this.lblLogTimeEnd.Size = new System.Drawing.Size(95, 23);
            this.lblLogTimeEnd.TabIndex = 173;
            this.lblLogTimeEnd.Text = "日志时间(止)：";
            this.lblLogTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StockLogListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "StockLogListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.deLogTimeStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLogTimeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leLogType.Properties)).EndInit();
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLogTimeEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLogTimeEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deLogTimeStart;
        private System.Windows.Forms.Label lblLogType;
        private System.Windows.Forms.Label lblLogTimeStart;
        private DevExpress.XtraEditors.LookUpEdit leLogType;
        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblLinkBillNumber;
        private System.Windows.Forms.Label lblBillNumber;
        private System.Windows.Forms.Label lblSkuNumber;
        private DevExpress.XtraEditors.TextEdit txtLinkBillNumber;
        private DevExpress.XtraEditors.TextEdit txtBillNumber;
        private DevExpress.XtraEditors.TextEdit txtSkuNumber;
        private DevExpress.XtraEditors.TextEdit txtBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private DevExpress.XtraEditors.TextEdit txtLocationCode;
        private System.Windows.Forms.Label lblLocationCode;
        private System.Windows.Forms.Label lblAreaCode;
        private DevExpress.XtraEditors.TextEdit txtAreaCode;
        private DevExpress.XtraEditors.DateEdit deLogTimeEnd;
        private System.Windows.Forms.Label lblLogTimeEnd;

        

    }
}

