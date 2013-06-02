namespace Mes.Product.Modules.ProductionOrderModel
{
    partial class ProductionOrderDetailEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tabBase = new DevExpress.XtraTab.XtraTabPage();
            this.gcBase = new DevExpress.XtraEditors.GroupControl();
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.seQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.lblReceivedQty = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblSkuId = new System.Windows.Forms.Label();
            this.lblSkuName = new System.Windows.Forms.Label();
            this.txtSKuName = new DevExpress.XtraEditors.TextEdit();
            this.lblPackId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deFinishDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lueUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.lueProduct = new DevExpress.XtraEditors.LookUpEdit();
            this.teProduct = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            this.gcDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teProduct.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDetail
            // 
            this.gcDetail.Controls.Add(this.tcDetail);
            // 
            // tcDetail
            // 
            this.tcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetail.Location = new System.Drawing.Point(7, 7);
            this.tcDetail.Name = "tcDetail";
            this.tcDetail.SelectedTabPage = this.tabBase;
            this.tcDetail.Size = new System.Drawing.Size(620, 418);
            this.tcDetail.TabIndex = 71;
            this.tcDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBase});
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.gcBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Size = new System.Drawing.Size(614, 390);
            this.tabBase.Text = "基础信息";
            // 
            // gcBase
            // 
            this.gcBase.Controls.Add(this.layoutBase);
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.LookAndFeel.SkinName = "Lilian";
            this.gcBase.Name = "gcBase";
            this.gcBase.Padding = new System.Windows.Forms.Padding(10);
            this.gcBase.Size = new System.Drawing.Size(614, 390);
            this.gcBase.TabIndex = 68;
            this.gcBase.Text = "明细信息";
            // 
            // layoutBase
            // 
            this.layoutBase.ColumnCount = 4;
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.Controls.Add(this.seQuantity, 1, 2);
            this.layoutBase.Controls.Add(this.lblReceivedQty, 2, 2);
            this.layoutBase.Controls.Add(this.lblQty, 0, 2);
            this.layoutBase.Controls.Add(this.lblSkuId, 0, 0);
            this.layoutBase.Controls.Add(this.lblSkuName, 0, 1);
            this.layoutBase.Controls.Add(this.txtSKuName, 1, 1);
            this.layoutBase.Controls.Add(this.lblPackId, 2, 0);
            this.layoutBase.Controls.Add(this.label1, 0, 3);
            this.layoutBase.Controls.Add(this.deFinishDate, 1, 3);
            this.layoutBase.Controls.Add(this.label2, 0, 4);
            this.layoutBase.Controls.Add(this.meRemark, 1, 4);
            this.layoutBase.Controls.Add(this.lueUnit, 3, 2);
            this.layoutBase.Controls.Add(this.lueProduct, 1, 0);
            this.layoutBase.Controls.Add(this.teProduct, 3, 0);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 5;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.Size = new System.Drawing.Size(590, 179);
            this.layoutBase.TabIndex = 129;
            // 
            // seQty
            // 
            this.seQuantity.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seQuantity.Location = new System.Drawing.Point(121, 59);
            this.seQuantity.Name = "seQuantity";
            this.seQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seQuantity.Properties.Mask.BeepOnError = true;
            this.seQuantity.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seQuantity.Size = new System.Drawing.Size(145, 20);
            this.seQuantity.TabIndex = 136;
            // 
            // lblReceivedQty
            // 
            this.lblReceivedQty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblReceivedQty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblReceivedQty.Location = new System.Drawing.Point(298, 56);
            this.lblReceivedQty.Name = "lblReceivedQty";
            this.lblReceivedQty.Size = new System.Drawing.Size(81, 23);
            this.lblReceivedQty.TabIndex = 132;
            this.lblReceivedQty.Text = "单位：";
            this.lblReceivedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty
            // 
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblQty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQty.Location = new System.Drawing.Point(3, 56);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(81, 23);
            this.lblQty.TabIndex = 131;
            this.lblQty.Text = "生产数量*：";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSkuId
            // 
            this.lblSkuId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSkuId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSkuId.Location = new System.Drawing.Point(3, 0);
            this.lblSkuId.Name = "lblSkuId";
            this.lblSkuId.Size = new System.Drawing.Size(81, 23);
            this.lblSkuId.TabIndex = 129;
            this.lblSkuId.Text = "产品代码*：";
            this.lblSkuId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSkuName
            // 
            this.lblSkuName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSkuName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSkuName.Location = new System.Drawing.Point(3, 28);
            this.lblSkuName.Name = "lblSkuName";
            this.lblSkuName.Size = new System.Drawing.Size(81, 23);
            this.lblSkuName.TabIndex = 74;
            this.lblSkuName.Text = "产品名称：";
            this.lblSkuName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSKuName
            // 
            this.layoutBase.SetColumnSpan(this.txtSKuName, 3);
            this.txtSKuName.Location = new System.Drawing.Point(121, 31);
            this.txtSKuName.Name = "txtSKuName";
            this.txtSKuName.Size = new System.Drawing.Size(442, 20);
            this.txtSKuName.TabIndex = 2;
            // 
            // lblPackId
            // 
            this.lblPackId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPackId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPackId.Location = new System.Drawing.Point(298, 0);
            this.lblPackId.Name = "lblPackId";
            this.lblPackId.Size = new System.Drawing.Size(81, 23);
            this.lblPackId.TabIndex = 69;
            this.lblPackId.Text = "产品类型：";
            this.lblPackId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 131;
            this.label1.Text = "完工日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deFinishDate
            // 
            this.deFinishDate.EditValue = null;
            this.deFinishDate.Location = new System.Drawing.Point(121, 87);
            this.deFinishDate.Name = "deFinishDate";
            this.deFinishDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFinishDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFinishDate.Size = new System.Drawing.Size(145, 20);
            this.deFinishDate.TabIndex = 139;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 131;
            this.label2.Text = "备注：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // meRemark
            // 
            this.layoutBase.SetColumnSpan(this.meRemark, 3);
            this.meRemark.Location = new System.Drawing.Point(121, 115);
            this.meRemark.Name = "meRemark";
            this.meRemark.Size = new System.Drawing.Size(442, 61);
            this.meRemark.TabIndex = 138;
            // 
            // lueUnit
            // 
            this.lueUnit.Location = new System.Drawing.Point(416, 59);
            this.lueUnit.Name = "lueUnit";
            this.lueUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUnit.Properties.NullText = "";
            this.lueUnit.Size = new System.Drawing.Size(147, 20);
            this.lueUnit.TabIndex = 129;
            // 
            // lueProduct
            // 
            this.lueProduct.Location = new System.Drawing.Point(121, 3);
            this.lueProduct.Name = "lueProduct";
            this.lueProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProduct.Properties.NullText = "";
            this.lueProduct.Size = new System.Drawing.Size(147, 20);
            this.lueProduct.TabIndex = 129;
            // 
            // textEdit1
            // 
            this.teProduct.Location = new System.Drawing.Point(416, 3);
            this.teProduct.Name = "teProduct";
            this.teProduct.Size = new System.Drawing.Size(147, 20);
            this.teProduct.TabIndex = 2;
            // 
            // ProductionOrderDetailEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ProductionOrderDetailEditForm";
            this.Text = "生产工单明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            this.gcDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teProduct.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private DevExpress.XtraEditors.SpinEdit seQuantity;
        private System.Windows.Forms.Label lblReceivedQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblSkuId;
        private System.Windows.Forms.Label lblSkuName;
        private DevExpress.XtraEditors.TextEdit txtSKuName;
        private System.Windows.Forms.Label lblPackId;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit deFinishDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private DevExpress.XtraEditors.LookUpEdit lueUnit;
        private DevExpress.XtraEditors.LookUpEdit lueProduct;
        private DevExpress.XtraEditors.TextEdit teProduct;
    }
}