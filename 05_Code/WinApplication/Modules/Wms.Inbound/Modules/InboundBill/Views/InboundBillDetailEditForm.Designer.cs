namespace Modules.InboundBillModule.Views
{
    partial class InboundBillDetailEditForm
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
            this.gcSN = new DevExpress.XtraEditors.GroupControl();
            this.chkMode = new DevExpress.XtraEditors.CheckEdit();
            this.txtSN = new DevExpress.XtraEditors.TextEdit();
            this.lblSN = new System.Windows.Forms.Label();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.lbSerialNumbers = new DevExpress.XtraEditors.ListBoxControl();
            this.gcBase = new DevExpress.XtraEditors.GroupControl();
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.txtBatchNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.lePlanSku = new DevExpress.XtraEditors.LookUpEdit();
            this.seQty = new DevExpress.XtraEditors.SpinEdit();
            this.lePackId = new DevExpress.XtraEditors.LookUpEdit();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblContainerId = new System.Windows.Forms.Label();
            this.lblSkuId = new System.Windows.Forms.Label();
            this.lblSkuName = new System.Windows.Forms.Label();
            this.txtSKuName = new DevExpress.XtraEditors.TextEdit();
            this.lblPackId = new System.Windows.Forms.Label();
            this.beContainerId = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            this.gcDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSN)).BeginInit();
            this.gcSN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSerialNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lePlanSku.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lePackId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beContainerId.Properties)).BeginInit();
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
            this.tabBase.Controls.Add(this.gcSN);
            this.tabBase.Controls.Add(this.gcBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Size = new System.Drawing.Size(614, 390);
            this.tabBase.Text = "基础信息";
            // 
            // gcSN
            // 
            this.gcSN.Controls.Add(this.chkMode);
            this.gcSN.Controls.Add(this.txtSN);
            this.gcSN.Controls.Add(this.lblSN);
            this.gcSN.Controls.Add(this.btnAdd);
            this.gcSN.Controls.Add(this.btnRemove);
            this.gcSN.Controls.Add(this.lbSerialNumbers);
            this.gcSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSN.Location = new System.Drawing.Point(0, 160);
            this.gcSN.Name = "gcSN";
            this.gcSN.Size = new System.Drawing.Size(614, 230);
            this.gcSN.TabIndex = 70;
            this.gcSN.Text = "序列号信息";
            this.gcSN.Visible = false;
            // 
            // chkMode
            // 
            this.chkMode.EditValue = true;
            this.chkMode.Location = new System.Drawing.Point(481, 29);
            this.chkMode.Name = "chkMode";
            this.chkMode.Properties.Caption = "回车添加序列号";
            this.chkMode.Size = new System.Drawing.Size(112, 19);
            this.chkMode.TabIndex = 77;
            // 
            // txtSN
            // 
            this.txtSN.Location = new System.Drawing.Point(381, 54);
            this.txtSN.Name = "txtSN";
            this.txtSN.Properties.MaxLength = 30;
            this.txtSN.Size = new System.Drawing.Size(212, 20);
            this.txtSN.TabIndex = 76;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSN_KeyPress);
            // 
            // lblSN
            // 
            this.lblSN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSN.Location = new System.Drawing.Point(379, 28);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(132, 23);
            this.lblSN.TabIndex = 75;
            this.lblSN.Text = "请扫描序列号：";
            this.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(496, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(382, 80);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(97, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "移除";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lbSerialNumbers
            // 
            this.lbSerialNumbers.Location = new System.Drawing.Point(4, 28);
            this.lbSerialNumbers.Name = "lbSerialNumbers";
            this.lbSerialNumbers.Size = new System.Drawing.Size(351, 197);
            this.lbSerialNumbers.TabIndex = 0;
            // 
            // gcBase
            // 
            this.gcBase.Controls.Add(this.layoutBase);
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.LookAndFeel.SkinName = "Lilian";
            this.gcBase.Name = "gcBase";
            this.gcBase.Padding = new System.Windows.Forms.Padding(10);
            this.gcBase.Size = new System.Drawing.Size(614, 160);
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
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.Controls.Add(this.txtBatchNumber, 1, 3);
            this.layoutBase.Controls.Add(this.lblBatchNumber, 0, 3);
            this.layoutBase.Controls.Add(this.lePlanSku, 1, 0);
            this.layoutBase.Controls.Add(this.seQty, 3, 2);
            this.layoutBase.Controls.Add(this.lePackId, 3, 0);
            this.layoutBase.Controls.Add(this.lblQty, 2, 2);
            this.layoutBase.Controls.Add(this.lblContainerId, 0, 2);
            this.layoutBase.Controls.Add(this.lblSkuId, 0, 0);
            this.layoutBase.Controls.Add(this.lblSkuName, 0, 1);
            this.layoutBase.Controls.Add(this.txtSKuName, 1, 1);
            this.layoutBase.Controls.Add(this.lblPackId, 2, 0);
            this.layoutBase.Controls.Add(this.beContainerId, 1, 2);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 4;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.Size = new System.Drawing.Size(590, 114);
            this.layoutBase.TabIndex = 128;
            // 
            // txtBatchNumber
            // 
            this.layoutBase.SetColumnSpan(this.txtBatchNumber, 3);
            this.txtBatchNumber.Location = new System.Drawing.Point(121, 87);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Properties.MaxLength = 30;
            this.txtBatchNumber.Size = new System.Drawing.Size(165, 20);
            this.txtBatchNumber.TabIndex = 140;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblBatchNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBatchNumber.Location = new System.Drawing.Point(3, 84);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(81, 23);
            this.lblBatchNumber.TabIndex = 139;
            this.lblBatchNumber.Text = "入库批次：";
            this.lblBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lePlanSku
            // 
            this.lePlanSku.Location = new System.Drawing.Point(121, 3);
            this.lePlanSku.Name = "lePlanSku";
            this.lePlanSku.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lePlanSku.Properties.NullText = "";
            this.lePlanSku.Size = new System.Drawing.Size(165, 20);
            this.lePlanSku.TabIndex = 130;
            this.lePlanSku.EditValueChanged += new System.EventHandler(this.lePlanSku_EditValueChanged);
            // 
            // seQty
            // 
            this.seQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seQty.Location = new System.Drawing.Point(416, 59);
            this.seQty.Name = "seQty";
            this.seQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seQty.Properties.IsFloatValue = false;
            this.seQty.Properties.Mask.BeepOnError = true;
            this.seQty.Properties.Mask.EditMask = "N00";
            this.seQty.Properties.MaxValue = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.seQty.Size = new System.Drawing.Size(165, 20);
            this.seQty.TabIndex = 137;
            // 
            // lePackId
            // 
            this.lePackId.Enabled = false;
            this.lePackId.Location = new System.Drawing.Point(416, 3);
            this.lePackId.Name = "lePackId";
            this.lePackId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lePackId.Properties.NullText = "";
            this.lePackId.Properties.ReadOnly = true;
            this.lePackId.Size = new System.Drawing.Size(165, 20);
            this.lePackId.TabIndex = 129;
            // 
            // lblQty
            // 
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblQty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQty.Location = new System.Drawing.Point(298, 56);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(81, 23);
            this.lblQty.TabIndex = 132;
            this.lblQty.Text = "实收数量*：";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContainerId
            // 
            this.lblContainerId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblContainerId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblContainerId.Location = new System.Drawing.Point(3, 56);
            this.lblContainerId.Name = "lblContainerId";
            this.lblContainerId.Size = new System.Drawing.Size(112, 23);
            this.lblContainerId.TabIndex = 131;
            this.lblContainerId.Text = "周转/存储容器*：";
            this.lblContainerId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSkuId
            // 
            this.lblSkuId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSkuId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSkuId.Location = new System.Drawing.Point(3, 0);
            this.lblSkuId.Name = "lblSkuId";
            this.lblSkuId.Size = new System.Drawing.Size(81, 23);
            this.lblSkuId.TabIndex = 129;
            this.lblSkuId.Text = "货物代码*：";
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
            this.lblSkuName.Text = "货物名称：";
            this.lblSkuName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSKuName
            // 
            this.layoutBase.SetColumnSpan(this.txtSKuName, 3);
            this.txtSKuName.Enabled = false;
            this.txtSKuName.Location = new System.Drawing.Point(121, 31);
            this.txtSKuName.Name = "txtSKuName";
            this.txtSKuName.Properties.ReadOnly = true;
            this.txtSKuName.Size = new System.Drawing.Size(460, 20);
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
            this.lblPackId.Text = "货物包装*：";
            this.lblPackId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // beContainerId
            // 
            this.beContainerId.Location = new System.Drawing.Point(121, 59);
            this.beContainerId.Name = "beContainerId";
            this.beContainerId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.beContainerId.Size = new System.Drawing.Size(165, 20);
            this.beContainerId.TabIndex = 138;
            this.beContainerId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beContainerId_ButtonClick);
            // 
            // InboundBillDetailEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "InboundBillDetailEditForm";
            this.Text = "入库单明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            this.gcDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSN)).EndInit();
            this.gcSN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSerialNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lePlanSku.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lePackId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beContainerId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblContainerId;
        private System.Windows.Forms.Label lblSkuId;
        private System.Windows.Forms.Label lblSkuName;
        private DevExpress.XtraEditors.TextEdit txtSKuName;
        private System.Windows.Forms.Label lblPackId;
        private DevExpress.XtraEditors.LookUpEdit lePackId;
        private DevExpress.XtraEditors.SpinEdit seQty;
        private DevExpress.XtraEditors.ButtonEdit beContainerId;
        private DevExpress.XtraEditors.GroupControl gcSN;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.ListBoxControl lbSerialNumbers;
        private System.Windows.Forms.Label lblSN;
        private DevExpress.XtraEditors.TextEdit txtSN;
        private DevExpress.XtraEditors.LookUpEdit lePlanSku;
        private DevExpress.XtraEditors.TextEdit txtBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private DevExpress.XtraEditors.CheckEdit chkMode;
    }
}