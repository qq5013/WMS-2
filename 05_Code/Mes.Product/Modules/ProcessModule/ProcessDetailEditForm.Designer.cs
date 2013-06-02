namespace Mes.Product.Modules.ProcessModule
{
    partial class ProcessDetailEditForm
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
            this.lblSkuId = new System.Windows.Forms.Label();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lueSku = new DevExpress.XtraEditors.LookUpEdit();
            this.lblQty = new System.Windows.Forms.Label();
            this.seQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.lblReceivedQty = new System.Windows.Forms.Label();
            this.lueMeasure = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.meDescription = new DevExpress.XtraEditors.MemoEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.seSequence = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            this.gcDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSku.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMeasure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSequence.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDetail
            // 
            this.gcDetail.Controls.Add(this.tcDetail);
            this.gcDetail.Size = new System.Drawing.Size(634, 298);
            // 
            // tcDetail
            // 
            this.tcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetail.Location = new System.Drawing.Point(7, 7);
            this.tcDetail.Name = "tcDetail";
            this.tcDetail.SelectedTabPage = this.tabBase;
            this.tcDetail.Size = new System.Drawing.Size(620, 284);
            this.tcDetail.TabIndex = 71;
            this.tcDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBase});
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.gcBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Size = new System.Drawing.Size(614, 256);
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
            this.gcBase.Size = new System.Drawing.Size(614, 256);
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
            this.layoutBase.Controls.Add(this.lblSkuId, 0, 0);
            this.layoutBase.Controls.Add(this.meRemark, 1, 4);
            this.layoutBase.Controls.Add(this.lueSku, 1, 0);
            this.layoutBase.Controls.Add(this.lblQty, 0, 1);
            this.layoutBase.Controls.Add(this.seQuantity, 1, 1);
            this.layoutBase.Controls.Add(this.lblReceivedQty, 2, 1);
            this.layoutBase.Controls.Add(this.lueMeasure, 3, 1);
            this.layoutBase.Controls.Add(this.label1, 0, 2);
            this.layoutBase.Controls.Add(this.meDescription, 1, 2);
            this.layoutBase.Controls.Add(this.label2, 0, 4);
            this.layoutBase.Controls.Add(this.label3, 0, 3);
            this.layoutBase.Controls.Add(this.seSequence, 1, 3);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 5;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.layoutBase.Size = new System.Drawing.Size(590, 213);
            this.layoutBase.TabIndex = 128;
            // 
            // lblSkuId
            // 
            this.lblSkuId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSkuId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSkuId.Location = new System.Drawing.Point(3, 0);
            this.lblSkuId.Name = "lblSkuId";
            this.lblSkuId.Size = new System.Drawing.Size(81, 23);
            this.lblSkuId.TabIndex = 129;
            this.lblSkuId.Text = "物料代码*：";
            this.lblSkuId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // meRemark
            // 
            this.layoutBase.SetColumnSpan(this.meRemark, 3);
            this.meRemark.Location = new System.Drawing.Point(121, 113);
            this.meRemark.Name = "meRemark";
            this.meRemark.Size = new System.Drawing.Size(442, 95);
            this.meRemark.TabIndex = 138;
            // 
            // lueSku
            // 
            this.lueSku.Location = new System.Drawing.Point(121, 3);
            this.lueSku.Name = "lueSku";
            this.lueSku.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSku.Properties.NullText = "";
            this.lueSku.Size = new System.Drawing.Size(147, 20);
            this.lueSku.TabIndex = 129;
            // 
            // lblQty
            // 
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblQty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQty.Location = new System.Drawing.Point(3, 28);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(81, 23);
            this.lblQty.TabIndex = 131;
            this.lblQty.Text = "数量*：";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seQuantity
            // 
            this.seQuantity.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seQuantity.Location = new System.Drawing.Point(121, 31);
            this.seQuantity.Name = "seQuantity";
            this.seQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seQuantity.Properties.Mask.BeepOnError = true;
            this.seQuantity.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seQuantity.Size = new System.Drawing.Size(147, 20);
            this.seQuantity.TabIndex = 136;
            // 
            // lblReceivedQty
            // 
            this.lblReceivedQty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblReceivedQty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblReceivedQty.Location = new System.Drawing.Point(298, 28);
            this.lblReceivedQty.Name = "lblReceivedQty";
            this.lblReceivedQty.Size = new System.Drawing.Size(81, 23);
            this.lblReceivedQty.TabIndex = 132;
            this.lblReceivedQty.Text = "单位：";
            this.lblReceivedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lueMeasure
            // 
            this.lueMeasure.Location = new System.Drawing.Point(416, 31);
            this.lueMeasure.Name = "lueMeasure";
            this.lueMeasure.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMeasure.Properties.NullText = "";
            this.lueMeasure.Size = new System.Drawing.Size(147, 20);
            this.lueMeasure.TabIndex = 129;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 131;
            this.label1.Text = "装配指导：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // meDescription
            // 
            this.layoutBase.SetColumnSpan(this.meDescription, 3);
            this.meDescription.Location = new System.Drawing.Point(121, 59);
            this.meDescription.Name = "meDescription";
            this.meDescription.Size = new System.Drawing.Size(442, 22);
            this.meDescription.TabIndex = 138;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 131;
            this.label2.Text = "备注：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 23);
            this.label3.TabIndex = 131;
            this.label3.Text = "装配顺序*：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seSequence
            // 
            this.seSequence.Location = new System.Drawing.Point(121, 87);
            this.seSequence.Name = "seSequence";
            this.seSequence.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seSequence.Properties.Mask.BeepOnError = true;
            this.seSequence.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seSequence.Size = new System.Drawing.Size(147, 20);
            this.seSequence.TabIndex = 136;
            // 
            // ProcessDetailEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 322);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ProcessDetailEditForm";
            this.Text = "工序物料明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            this.gcDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSku.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMeasure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSequence.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblReceivedQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblSkuId;
        private DevExpress.XtraEditors.LookUpEdit lueSku;
        private DevExpress.XtraEditors.SpinEdit seQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private DevExpress.XtraEditors.LookUpEdit lueMeasure;
        private DevExpress.XtraEditors.MemoEdit meDescription;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SpinEdit seSequence;
    }
}