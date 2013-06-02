namespace Mes.Product.Modules.ProcessModule
{
    partial class ProcessEditForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcMaster = new DevExpress.XtraTab.XtraTabControl();
            this.tabBase = new DevExpress.XtraTab.XtraTabPage();
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlanNumber = new System.Windows.Forms.Label();
            this.lblLinkBillNumber = new System.Windows.Forms.Label();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.teCode = new DevExpress.XtraEditors.TextEdit();
            this.lblPlanReceiveTimeStart = new System.Windows.Forms.Label();
            this.lblPlanReceiveTimeEnd = new System.Windows.Forms.Label();
            this.lblInboundType = new System.Windows.Forms.Label();
            this.lueProduct = new DevExpress.XtraEditors.LookUpEdit();
            this.lueProductLine = new DevExpress.XtraEditors.LookUpEdit();
            this.lblBillStatus = new System.Windows.Forms.Label();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).BeginInit();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMaster)).BeginInit();
            this.tcMaster.SuspendLayout();
            this.tabBase.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(915, 300);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tcMaster);
            this.grpMain.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpMain.Size = new System.Drawing.Size(915, 300);
            // 
            // gcDetail
            // 
            this.gcDetail.Size = new System.Drawing.Size(915, 247);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Size = new System.Drawing.Size(915, 247);
            // 
            // tcMaster
            // 
            this.tcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMaster.Location = new System.Drawing.Point(6, 7);
            this.tcMaster.Name = "tcMaster";
            this.tcMaster.SelectedTabPage = this.tabBase;
            this.tcMaster.Size = new System.Drawing.Size(903, 286);
            this.tcMaster.TabIndex = 1;
            this.tcMaster.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBase,
            this.xtraTabPage1});
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.layoutCondition);
            this.tabBase.Name = "tabBase";
            this.tabBase.Padding = new System.Windows.Forms.Padding(10);
            this.tabBase.Size = new System.Drawing.Size(897, 258);
            this.tabBase.Text = "基本信息";
            // 
            // layoutCondition
            // 
            this.layoutCondition.ColumnCount = 5;
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.7972F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.91878F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.7972F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.43082F));
            this.layoutCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.055997F));
            this.layoutCondition.Controls.Add(this.lblPlanNumber, 0, 0);
            this.layoutCondition.Controls.Add(this.lblLinkBillNumber, 2, 0);
            this.layoutCondition.Controls.Add(this.teName, 1, 0);
            this.layoutCondition.Controls.Add(this.teCode, 3, 0);
            this.layoutCondition.Controls.Add(this.lblPlanReceiveTimeStart, 0, 1);
            this.layoutCondition.Controls.Add(this.lblPlanReceiveTimeEnd, 2, 1);
            this.layoutCondition.Controls.Add(this.lblInboundType, 0, 2);
            this.layoutCondition.Controls.Add(this.lueProduct, 1, 1);
            this.layoutCondition.Controls.Add(this.lueProductLine, 3, 1);
            this.layoutCondition.Controls.Add(this.lblBillStatus, 0, 3);
            this.layoutCondition.Controls.Add(this.meRemark, 1, 3);
            this.layoutCondition.Controls.Add(this.checkedComboBoxEdit1, 1, 2);
            this.layoutCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutCondition.Location = new System.Drawing.Point(10, 10);
            this.layoutCondition.Name = "layoutCondition";
            this.layoutCondition.RowCount = 4;
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutCondition.Size = new System.Drawing.Size(877, 238);
            this.layoutCondition.TabIndex = 1;
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
            // lblLinkBillNumber
            // 
            this.lblLinkBillNumber.Location = new System.Drawing.Point(420, 0);
            this.lblLinkBillNumber.Name = "lblLinkBillNumber";
            this.lblLinkBillNumber.Size = new System.Drawing.Size(80, 23);
            this.lblLinkBillNumber.TabIndex = 8;
            this.lblLinkBillNumber.Text = "工序代码：";
            this.lblLinkBillNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(167, 3);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(126, 20);
            this.teName.TabIndex = 19;
            // 
            // teCode
            // 
            this.teCode.Location = new System.Drawing.Point(584, 3);
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
            this.lblPlanReceiveTimeEnd.Location = new System.Drawing.Point(420, 28);
            this.lblPlanReceiveTimeEnd.Name = "lblPlanReceiveTimeEnd";
            this.lblPlanReceiveTimeEnd.Size = new System.Drawing.Size(80, 23);
            this.lblPlanReceiveTimeEnd.TabIndex = 7;
            this.lblPlanReceiveTimeEnd.Text = "产线代码：";
            this.lblPlanReceiveTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lueProduct.Location = new System.Drawing.Point(167, 31);
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
            this.lueProductLine.Location = new System.Drawing.Point(584, 31);
            this.lueProductLine.Name = "lueProductLine";
            this.lueProductLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProductLine.Properties.NullText = "";
            this.lueProductLine.Size = new System.Drawing.Size(129, 20);
            this.lueProductLine.TabIndex = 131;
            // 
            // lblBillStatus
            // 
            this.lblBillStatus.Location = new System.Drawing.Point(3, 84);
            this.lblBillStatus.Name = "lblBillStatus";
            this.lblBillStatus.Size = new System.Drawing.Size(80, 23);
            this.lblBillStatus.TabIndex = 15;
            this.lblBillStatus.Text = "描述：";
            this.lblBillStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // meRemark
            // 
            this.layoutCondition.SetColumnSpan(this.meRemark, 3);
            this.meRemark.Location = new System.Drawing.Point(167, 87);
            this.meRemark.Name = "meRemark";
            this.meRemark.Size = new System.Drawing.Size(546, 114);
            this.meRemark.TabIndex = 132;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.simpleButton1);
            this.xtraTabPage1.Controls.Add(this.pictureEdit1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(897, 258);
            this.xtraTabPage1.Text = "图片";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.NullText = " ";
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(271, 258);
            this.pictureEdit1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(349, 16);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "选择图片";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(167, 59);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(126, 20);
            this.checkedComboBoxEdit1.TabIndex = 133;
            // 
            // ProcessEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 604);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ProcessEditForm";
            this.Text = "工序明细";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMaster)).EndInit();
            this.tcMaster.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMaster;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblPlanNumber;
        private System.Windows.Forms.Label lblLinkBillNumber;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.TextEdit teCode;
        private System.Windows.Forms.Label lblPlanReceiveTimeStart;
        private System.Windows.Forms.Label lblPlanReceiveTimeEnd;
        private System.Windows.Forms.Label lblInboundType;
        private System.Windows.Forms.Label lblBillStatus;
        private DevExpress.XtraEditors.LookUpEdit lueProduct;
        private DevExpress.XtraEditors.LookUpEdit lueProductLine;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
    }
}
