namespace Mes.Product.Modules.MaterialRequisitionModel
{
    partial class MaterialRequisitionEditForm
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
            this.lueCreaterId = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMerchantId = new System.Windows.Forms.Label();
            this.deCreateTime = new DevExpress.XtraEditors.DateEdit();
            this.lueOrderType = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
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
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCreaterId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOrderType.Properties)).BeginInit();
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
            this.gcDetail.Size = new System.Drawing.Size(915, 204);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Size = new System.Drawing.Size(915, 204);
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
            this.tabBase});
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.layoutBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Padding = new System.Windows.Forms.Padding(10);
            this.tabBase.Size = new System.Drawing.Size(897, 258);
            this.tabBase.Text = "基本信息";
            // 
            // layoutBase
            // 
            this.layoutBase.ColumnCount = 4;
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.Controls.Add(this.lblLinkBillType, 0, 1);
            this.layoutBase.Controls.Add(this.lblLinkBillNumber, 2, 1);
            this.layoutBase.Controls.Add(this.lblPlanNumber, 0, 0);
            this.layoutBase.Controls.Add(this.deDeliveryDate, 3, 1);
            this.layoutBase.Controls.Add(this.deOrderDate, 1, 1);
            this.layoutBase.Controls.Add(this.beCustomer, 1, 0);
            this.layoutBase.Controls.Add(this.lblClientId, 0, 2);
            this.layoutBase.Controls.Add(this.lueCreaterId, 1, 2);
            this.layoutBase.Controls.Add(this.lblMerchantId, 2, 2);
            this.layoutBase.Controls.Add(this.deCreateTime, 3, 2);
            this.layoutBase.Controls.Add(this.lblVendorId, 0, 3);
            this.layoutBase.Controls.Add(this.meRemark, 1, 3);
            this.layoutBase.Controls.Add(this.lueOrderType, 3, 0);
            this.layoutBase.Controls.Add(this.label1, 2, 0);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(10, 10);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 4;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.Size = new System.Drawing.Size(877, 178);
            this.layoutBase.TabIndex = 132;
            // 
            // lblVendorId
            // 
            this.lblVendorId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblVendorId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVendorId.Location = new System.Drawing.Point(3, 84);
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
            this.lblLinkBillNumber.Location = new System.Drawing.Point(441, 28);
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
            this.lblPlanNumber.Text = "客户*：";
            this.lblPlanNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deDeliveryDate
            // 
            this.deDeliveryDate.EditValue = null;
            this.deDeliveryDate.Location = new System.Drawing.Point(616, 31);
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
            this.deOrderDate.Location = new System.Drawing.Point(178, 31);
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
            this.beCustomer.Location = new System.Drawing.Point(178, 3);
            this.beCustomer.Name = "beCustomer";
            this.beCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beCustomer.Size = new System.Drawing.Size(165, 20);
            this.beCustomer.TabIndex = 139;
            // 
            // meRemark
            // 
            this.layoutBase.SetColumnSpan(this.meRemark, 3);
            this.meRemark.Location = new System.Drawing.Point(178, 87);
            this.meRemark.Name = "meRemark";
            this.meRemark.Size = new System.Drawing.Size(603, 88);
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
            this.lblClientId.Text = "制单人*：";
            this.lblClientId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lueCreateId
            // 
            this.lueCreaterId.Location = new System.Drawing.Point(178, 59);
            this.lueCreaterId.Name = "lueCreaterId";
            this.lueCreaterId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCreaterId.Properties.NullText = "";
            this.lueCreaterId.Properties.ReadOnly = true;
            this.lueCreaterId.Size = new System.Drawing.Size(165, 20);
            this.lueCreaterId.TabIndex = 141;
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblMerchantId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMerchantId.Location = new System.Drawing.Point(441, 56);
            this.lblMerchantId.Name = "lblMerchantId";
            this.lblMerchantId.Size = new System.Drawing.Size(81, 23);
            this.lblMerchantId.TabIndex = 142;
            this.lblMerchantId.Text = "制单日期*：";
            this.lblMerchantId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deCreatedAt
            // 
            this.deCreateTime.EditValue = null;
            this.deCreateTime.Location = new System.Drawing.Point(616, 59);
            this.deCreateTime.Name = "deCreateTime";
            this.deCreateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreateTime.Properties.ReadOnly = true;
            this.deCreateTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deCreateTime.Size = new System.Drawing.Size(165, 20);
            this.deCreateTime.TabIndex = 144;
            // 
            // lookUpEdit1
            // 
            this.lueOrderType.Location = new System.Drawing.Point(616, 3);
            this.lueOrderType.Name = "lueOrderType";
            this.lueOrderType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOrderType.Properties.NullText = "";
            this.lueOrderType.Properties.ReadOnly = true;
            this.lueOrderType.Size = new System.Drawing.Size(165, 20);
            this.lueOrderType.TabIndex = 141;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(441, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 142;
            this.label1.Text = "工单类型：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaterialRequisitionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 561);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MaterialRequisitionEditForm";
            this.Text = "生产总工单管理";
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
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCreaterId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOrderType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMaster;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblLinkBillType;
        private System.Windows.Forms.Label lblLinkBillNumber;
        private System.Windows.Forms.Label lblPlanNumber;
        private DevExpress.XtraEditors.DateEdit deDeliveryDate;
        private DevExpress.XtraEditors.DateEdit deOrderDate;
        private DevExpress.XtraEditors.ButtonEdit beCustomer;
        private System.Windows.Forms.Label lblClientId;
        private DevExpress.XtraEditors.LookUpEdit lueCreaterId;
        private System.Windows.Forms.Label lblMerchantId;
        private DevExpress.XtraEditors.DateEdit deCreateTime;
        private System.Windows.Forms.Label lblVendorId;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private DevExpress.XtraEditors.LookUpEdit lueOrderType;
        private System.Windows.Forms.Label label1;
    }
}
