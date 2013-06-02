namespace Modules.OutboundPlanModule.Views
{
    partial class OutboundPlanDetailEditForm
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
            this.seIssuedQty = new DevExpress.XtraEditors.SpinEdit();
            this.seQty = new DevExpress.XtraEditors.SpinEdit();
            this.lePackId = new DevExpress.XtraEditors.LookUpEdit();
            this.beSkuId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblIssuedQty = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblSkuId = new System.Windows.Forms.Label();
            this.lblSkuName = new System.Windows.Forms.Label();
            this.txtSKuName = new DevExpress.XtraEditors.TextEdit();
            this.lblPackId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            this.gcDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seIssuedQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lePackId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSkuId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKuName.Properties)).BeginInit();
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
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.Controls.Add(this.seIssuedQty, 3, 2);
            this.layoutBase.Controls.Add(this.seQty, 1, 2);
            this.layoutBase.Controls.Add(this.lePackId, 3, 0);
            this.layoutBase.Controls.Add(this.beSkuId, 1, 0);
            this.layoutBase.Controls.Add(this.lblIssuedQty, 2, 2);
            this.layoutBase.Controls.Add(this.lblQty, 0, 2);
            this.layoutBase.Controls.Add(this.lblSkuId, 0, 0);
            this.layoutBase.Controls.Add(this.lblSkuName, 0, 1);
            this.layoutBase.Controls.Add(this.txtSKuName, 1, 1);
            this.layoutBase.Controls.Add(this.lblPackId, 2, 0);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 3;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBase.Size = new System.Drawing.Size(590, 88);
            this.layoutBase.TabIndex = 128;
            // 
            // seIssuedQty
            // 
            this.seIssuedQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seIssuedQty.Enabled = false;
            this.seIssuedQty.Location = new System.Drawing.Point(416, 59);
            this.seIssuedQty.Name = "seIssuedQty";
            this.seIssuedQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seIssuedQty.Properties.IsFloatValue = false;
            this.seIssuedQty.Properties.Mask.BeepOnError = true;
            this.seIssuedQty.Properties.Mask.EditMask = "N00";
            this.seIssuedQty.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seIssuedQty.Properties.ReadOnly = true;
            this.seIssuedQty.Size = new System.Drawing.Size(165, 20);
            this.seIssuedQty.TabIndex = 137;
            // 
            // seQty
            // 
            this.seQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seQty.Location = new System.Drawing.Point(121, 59);
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
            this.seQty.TabIndex = 136;
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
            // beSkuId
            // 
            this.beSkuId.Location = new System.Drawing.Point(121, 3);
            this.beSkuId.Name = "beSkuId";
            this.beSkuId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beSkuId.Size = new System.Drawing.Size(165, 20);
            this.beSkuId.TabIndex = 135;
            this.beSkuId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beSkuId_ButtonClick);
            // 
            // lblIssuedQty
            // 
            this.lblIssuedQty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblIssuedQty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIssuedQty.Location = new System.Drawing.Point(298, 56);
            this.lblIssuedQty.Name = "lblIssuedQty";
            this.lblIssuedQty.Size = new System.Drawing.Size(81, 23);
            this.lblIssuedQty.TabIndex = 132;
            this.lblIssuedQty.Text = "已出货数量：";
            this.lblIssuedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty
            // 
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblQty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQty.Location = new System.Drawing.Point(3, 56);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(81, 23);
            this.lblQty.TabIndex = 131;
            this.lblQty.Text = "计划数量*：";
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
            // OutboundPlanDetailEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "OutboundPlanDetailEditForm";
            this.Text = "出库计划明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            this.gcDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seIssuedQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lePackId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSkuId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKuName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblIssuedQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblSkuId;
        private System.Windows.Forms.Label lblSkuName;
        private DevExpress.XtraEditors.TextEdit txtSKuName;
        private System.Windows.Forms.Label lblPackId;
        private DevExpress.XtraEditors.ButtonEdit beSkuId;
        private DevExpress.XtraEditors.LookUpEdit lePackId;
        private DevExpress.XtraEditors.SpinEdit seIssuedQty;
        private DevExpress.XtraEditors.SpinEdit seQty;
    }
}