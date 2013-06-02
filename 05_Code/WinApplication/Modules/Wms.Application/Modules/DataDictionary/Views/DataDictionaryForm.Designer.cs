namespace Modules.DataDictionaryModule.Views
{
    partial class DataDictionaryForm
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
            this.grcBase = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDataDictionaryLevel = new System.Windows.Forms.Label();
            this.txtDataDictionaryLevel = new DevExpress.XtraEditors.TextEdit();
            this.lblParentID = new System.Windows.Forms.Label();
            this.txtParentID = new DevExpress.XtraEditors.TextEdit();
            this.txtCategory = new DevExpress.XtraEditors.TextEdit();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDataDictionaryCode = new System.Windows.Forms.Label();
            this.lblDictionaryValue = new System.Windows.Forms.Label();
            this.txtDataDictionaryCode = new DevExpress.XtraEditors.TextEdit();
            this.txtDictionaryValue = new DevExpress.XtraEditors.TextEdit();
            this.grcOther = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRemark = new System.Windows.Forms.Label();
            this.cbIsActive = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.gcData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBase)).BeginInit();
            this.grcBase.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataDictionaryLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataDictionaryCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDictionaryValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOther)).BeginInit();
            this.grcOther.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // gcTree
            // 
            this.gcTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // gcData
            // 
            this.gcData.Controls.Add(this.grcOther);
            this.gcData.Controls.Add(this.grcBase);
            this.gcData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcData.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // grcBase
            // 
            this.grcBase.Controls.Add(this.tableLayoutPanel1);
            this.grcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.grcBase.Location = new System.Drawing.Point(6, 25);
            this.grcBase.LookAndFeel.SkinName = "Lilian";
            this.grcBase.Name = "grcBase";
            this.grcBase.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grcBase.Size = new System.Drawing.Size(533, 181);
            this.grcBase.TabIndex = 68;
            this.grcBase.Text = "基本信息";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lblDataDictionaryLevel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDataDictionaryLevel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblParentID, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtParentID, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCategory, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCategory, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDataDictionaryCode, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDictionaryValue, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDataDictionaryCode, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDictionaryValue, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 168);
            this.tableLayoutPanel1.TabIndex = 128;
            // 
            // lblDataDictionaryLevel
            // 
            this.lblDataDictionaryLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataDictionaryLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDataDictionaryLevel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataDictionaryLevel.Location = new System.Drawing.Point(3, 0);
            this.lblDataDictionaryLevel.Name = "lblDataDictionaryLevel";
            this.lblDataDictionaryLevel.Size = new System.Drawing.Size(95, 23);
            this.lblDataDictionaryLevel.TabIndex = 69;
            this.lblDataDictionaryLevel.Text = "字典级别*：";
            this.lblDataDictionaryLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataDictionaryLevel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDataDictionaryLevel, 2);
            this.txtDataDictionaryLevel.Enabled = false;
            this.txtDataDictionaryLevel.Location = new System.Drawing.Point(104, 3);
            this.txtDataDictionaryLevel.Name = "txtDataDictionaryLevel";
            this.txtDataDictionaryLevel.Properties.ReadOnly = true;
            this.txtDataDictionaryLevel.Size = new System.Drawing.Size(200, 20);
            this.txtDataDictionaryLevel.TabIndex = 0;
            // 
            // lblParentID
            // 
            this.lblParentID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblParentID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParentID.Location = new System.Drawing.Point(3, 28);
            this.lblParentID.Name = "lblParentID";
            this.lblParentID.Size = new System.Drawing.Size(81, 23);
            this.lblParentID.TabIndex = 74;
            this.lblParentID.Text = "父级字典*：";
            this.lblParentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParentID
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtParentID, 2);
            this.txtParentID.Enabled = false;
            this.txtParentID.Location = new System.Drawing.Point(104, 31);
            this.txtParentID.Name = "txtParentID";
            this.txtParentID.Properties.ReadOnly = true;
            this.txtParentID.Size = new System.Drawing.Size(200, 20);
            this.txtParentID.TabIndex = 1;
            // 
            // txtCategory
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtCategory, 2);
            this.txtCategory.Location = new System.Drawing.Point(104, 59);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Properties.MaxLength = 30;
            this.txtCategory.Size = new System.Drawing.Size(200, 20);
            this.txtCategory.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCategory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCategory.Location = new System.Drawing.Point(3, 56);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(81, 23);
            this.lblCategory.TabIndex = 73;
            this.lblCategory.Text = "字典分类*：";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDataDictionaryCode
            // 
            this.lblDataDictionaryCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDataDictionaryCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataDictionaryCode.Location = new System.Drawing.Point(3, 84);
            this.lblDataDictionaryCode.Name = "lblDataDictionaryCode";
            this.lblDataDictionaryCode.Size = new System.Drawing.Size(81, 23);
            this.lblDataDictionaryCode.TabIndex = 76;
            this.lblDataDictionaryCode.Text = "字典代码*：";
            this.lblDataDictionaryCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDictionaryValue
            // 
            this.lblDictionaryValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDictionaryValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDictionaryValue.Location = new System.Drawing.Point(3, 112);
            this.lblDictionaryValue.Name = "lblDictionaryValue";
            this.lblDictionaryValue.Size = new System.Drawing.Size(81, 23);
            this.lblDictionaryValue.TabIndex = 77;
            this.lblDictionaryValue.Text = "字典值*：";
            this.lblDictionaryValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataDictionaryCode
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDataDictionaryCode, 2);
            this.txtDataDictionaryCode.Location = new System.Drawing.Point(104, 87);
            this.txtDataDictionaryCode.Name = "txtDataDictionaryCode";
            this.txtDataDictionaryCode.Properties.MaxLength = 30;
            this.txtDataDictionaryCode.Size = new System.Drawing.Size(200, 20);
            this.txtDataDictionaryCode.TabIndex = 3;
            // 
            // txtDictionaryValue
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDictionaryValue, 2);
            this.txtDictionaryValue.Location = new System.Drawing.Point(104, 115);
            this.txtDictionaryValue.Name = "txtDictionaryValue";
            this.txtDictionaryValue.Properties.MaxLength = 30;
            this.txtDictionaryValue.Size = new System.Drawing.Size(200, 20);
            this.txtDictionaryValue.TabIndex = 4;
            // 
            // grcOther
            // 
            this.grcOther.Controls.Add(this.tableLayoutPanel2);
            this.grcOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcOther.Location = new System.Drawing.Point(6, 206);
            this.grcOther.LookAndFeel.SkinName = "Lilian";
            this.grcOther.Name = "grcOther";
            this.grcOther.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grcOther.Size = new System.Drawing.Size(533, 355);
            this.grcOther.TabIndex = 70;
            this.grcOther.Text = "其它信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.lblRemark, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbIsActive, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblIsActive, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 31);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(509, 100);
            this.tableLayoutPanel2.TabIndex = 129;
            // 
            // lblRemark
            // 
            this.lblRemark.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRemark.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRemark.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRemark.Location = new System.Drawing.Point(3, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(95, 23);
            this.lblRemark.TabIndex = 126;
            this.lblRemark.Text = "描述：";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIsActive
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cbIsActive, 2);
            this.cbIsActive.Location = new System.Drawing.Point(104, 59);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbIsActive.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbIsActive.Size = new System.Drawing.Size(200, 20);
            this.cbIsActive.TabIndex = 6;
            // 
            // lblIsActive
            // 
            this.lblIsActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblIsActive.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIsActive.Location = new System.Drawing.Point(3, 56);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(95, 23);
            this.lblIsActive.TabIndex = 75;
            this.lblIsActive.Text = "是否可用*：";
            this.lblIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemark
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Location = new System.Drawing.Point(104, 3);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.MaxLength = 250;
            this.txtRemark.Size = new System.Drawing.Size(200, 50);
            this.txtRemark.TabIndex = 5;
            // 
            // DataDictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CurrentDataState = Framework.UI.Template.Common.DataState.Read;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataDictionaryForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.gcData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcBase)).EndInit();
            this.grcBase.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataDictionaryLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataDictionaryCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDictionaryValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOther)).EndInit();
            this.grcOther.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcBase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.TextEdit txtCategory;
        private System.Windows.Forms.Label lblDataDictionaryLevel;
        private System.Windows.Forms.Label lblCategory;
        private DevExpress.XtraEditors.TextEdit txtDataDictionaryLevel;
        private System.Windows.Forms.Label lblParentID;
        private DevExpress.XtraEditors.TextEdit txtParentID;
        private DevExpress.XtraEditors.GroupControl grcOther;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblRemark;
        private DevExpress.XtraEditors.ComboBoxEdit cbIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private System.Windows.Forms.Label lblDataDictionaryCode;
        private System.Windows.Forms.Label lblDictionaryValue;
        private DevExpress.XtraEditors.TextEdit txtDataDictionaryCode;
        private DevExpress.XtraEditors.TextEdit txtDictionaryValue;

    }
}
