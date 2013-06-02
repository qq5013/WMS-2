namespace Modules.FunctionModule.Views
{
    partial class FunctionForm
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
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.lblFunctionLevel = new System.Windows.Forms.Label();
            this.txtFunctionLevel = new DevExpress.XtraEditors.TextEdit();
            this.lblParentID = new System.Windows.Forms.Label();
            this.txtParentID = new DevExpress.XtraEditors.TextEdit();
            this.txtFunctionCode = new DevExpress.XtraEditors.TextEdit();
            this.lblFunctionCode = new System.Windows.Forms.Label();
            this.lblFunctionName = new System.Windows.Forms.Label();
            this.lblResourceIdentifier = new System.Windows.Forms.Label();
            this.txtFunctionName = new DevExpress.XtraEditors.TextEdit();
            this.txtResourceIdentifier = new DevExpress.XtraEditors.TextEdit();
            this.grcOther = new DevExpress.XtraEditors.GroupControl();
            this.layoutOther = new System.Windows.Forms.TableLayoutPanel();
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
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFunctionLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFunctionCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFunctionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResourceIdentifier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOther)).BeginInit();
            this.grcOther.SuspendLayout();
            this.layoutOther.SuspendLayout();
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
            this.grcBase.Controls.Add(this.layoutBase);
            this.grcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.grcBase.Location = new System.Drawing.Point(6, 25);
            this.grcBase.LookAndFeel.SkinName = "Lilian";
            this.grcBase.Name = "grcBase";
            this.grcBase.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grcBase.Size = new System.Drawing.Size(533, 181);
            this.grcBase.TabIndex = 68;
            this.grcBase.Text = "基本信息";
            // 
            // layoutBase
            // 
            this.layoutBase.ColumnCount = 4;
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBase.Controls.Add(this.lblFunctionLevel, 0, 0);
            this.layoutBase.Controls.Add(this.txtFunctionLevel, 1, 0);
            this.layoutBase.Controls.Add(this.lblParentID, 0, 1);
            this.layoutBase.Controls.Add(this.txtParentID, 1, 1);
            this.layoutBase.Controls.Add(this.txtFunctionCode, 1, 2);
            this.layoutBase.Controls.Add(this.lblFunctionCode, 0, 2);
            this.layoutBase.Controls.Add(this.lblFunctionName, 0, 3);
            this.layoutBase.Controls.Add(this.lblResourceIdentifier, 0, 4);
            this.layoutBase.Controls.Add(this.txtFunctionName, 1, 3);
            this.layoutBase.Controls.Add(this.txtResourceIdentifier, 1, 4);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 7;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.Size = new System.Drawing.Size(509, 168);
            this.layoutBase.TabIndex = 128;
            // 
            // lblFunctionLevel
            // 
            this.lblFunctionLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFunctionLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblFunctionLevel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFunctionLevel.Location = new System.Drawing.Point(3, 0);
            this.lblFunctionLevel.Name = "lblFunctionLevel";
            this.lblFunctionLevel.Size = new System.Drawing.Size(95, 23);
            this.lblFunctionLevel.TabIndex = 69;
            this.lblFunctionLevel.Text = "功能级别*：";
            this.lblFunctionLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFunctionLevel
            // 
            this.layoutBase.SetColumnSpan(this.txtFunctionLevel, 2);
            this.txtFunctionLevel.Enabled = false;
            this.txtFunctionLevel.Location = new System.Drawing.Point(104, 3);
            this.txtFunctionLevel.Name = "txtFunctionLevel";
            this.txtFunctionLevel.Properties.ReadOnly = true;
            this.txtFunctionLevel.Size = new System.Drawing.Size(200, 20);
            this.txtFunctionLevel.TabIndex = 0;
            // 
            // lblParentID
            // 
            this.lblParentID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblParentID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParentID.Location = new System.Drawing.Point(3, 28);
            this.lblParentID.Name = "lblParentID";
            this.lblParentID.Size = new System.Drawing.Size(81, 23);
            this.lblParentID.TabIndex = 74;
            this.lblParentID.Text = "父级功能*：";
            this.lblParentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParentID
            // 
            this.layoutBase.SetColumnSpan(this.txtParentID, 2);
            this.txtParentID.Enabled = false;
            this.txtParentID.Location = new System.Drawing.Point(104, 31);
            this.txtParentID.Name = "txtParentID";
            this.txtParentID.Properties.ReadOnly = true;
            this.txtParentID.Size = new System.Drawing.Size(200, 20);
            this.txtParentID.TabIndex = 1;
            // 
            // txtFunctionCode
            // 
            this.layoutBase.SetColumnSpan(this.txtFunctionCode, 2);
            this.txtFunctionCode.Location = new System.Drawing.Point(104, 59);
            this.txtFunctionCode.Name = "txtFunctionCode";
            this.txtFunctionCode.Properties.MaxLength = 30;
            this.txtFunctionCode.Size = new System.Drawing.Size(200, 20);
            this.txtFunctionCode.TabIndex = 2;
            // 
            // lblFunctionCode
            // 
            this.lblFunctionCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblFunctionCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFunctionCode.Location = new System.Drawing.Point(3, 56);
            this.lblFunctionCode.Name = "lblFunctionCode";
            this.lblFunctionCode.Size = new System.Drawing.Size(81, 23);
            this.lblFunctionCode.TabIndex = 73;
            this.lblFunctionCode.Text = "功能代码*：";
            this.lblFunctionCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFunctionName
            // 
            this.lblFunctionName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblFunctionName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFunctionName.Location = new System.Drawing.Point(3, 84);
            this.lblFunctionName.Name = "lblFunctionName";
            this.lblFunctionName.Size = new System.Drawing.Size(81, 23);
            this.lblFunctionName.TabIndex = 76;
            this.lblFunctionName.Text = "功能名称*：";
            this.lblFunctionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResourceIdentifier
            // 
            this.lblResourceIdentifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblResourceIdentifier.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblResourceIdentifier.Location = new System.Drawing.Point(3, 112);
            this.lblResourceIdentifier.Name = "lblResourceIdentifier";
            this.lblResourceIdentifier.Size = new System.Drawing.Size(81, 23);
            this.lblResourceIdentifier.TabIndex = 77;
            this.lblResourceIdentifier.Text = "资源标识符：";
            this.lblResourceIdentifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFunctionName
            // 
            this.layoutBase.SetColumnSpan(this.txtFunctionName, 2);
            this.txtFunctionName.Location = new System.Drawing.Point(104, 87);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Properties.MaxLength = 30;
            this.txtFunctionName.Size = new System.Drawing.Size(200, 20);
            this.txtFunctionName.TabIndex = 3;
            // 
            // txtResourceIdentifier
            // 
            this.layoutBase.SetColumnSpan(this.txtResourceIdentifier, 2);
            this.txtResourceIdentifier.Location = new System.Drawing.Point(104, 115);
            this.txtResourceIdentifier.Name = "txtResourceIdentifier";
            this.txtResourceIdentifier.Properties.MaxLength = 200;
            this.txtResourceIdentifier.Size = new System.Drawing.Size(200, 20);
            this.txtResourceIdentifier.TabIndex = 4;
            // 
            // grcOther
            // 
            this.grcOther.Controls.Add(this.layoutOther);
            this.grcOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcOther.Location = new System.Drawing.Point(6, 206);
            this.grcOther.LookAndFeel.SkinName = "Lilian";
            this.grcOther.Name = "grcOther";
            this.grcOther.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.grcOther.Size = new System.Drawing.Size(533, 355);
            this.grcOther.TabIndex = 70;
            this.grcOther.Text = "其它信息";
            // 
            // layoutOther
            // 
            this.layoutOther.ColumnCount = 4;
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutOther.Controls.Add(this.lblRemark, 0, 0);
            this.layoutOther.Controls.Add(this.cbIsActive, 1, 1);
            this.layoutOther.Controls.Add(this.lblIsActive, 0, 1);
            this.layoutOther.Controls.Add(this.txtRemark, 1, 0);
            this.layoutOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutOther.Location = new System.Drawing.Point(12, 31);
            this.layoutOther.Name = "layoutOther";
            this.layoutOther.RowCount = 3;
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutOther.Size = new System.Drawing.Size(509, 100);
            this.layoutOther.TabIndex = 129;
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
            this.layoutOther.SetColumnSpan(this.cbIsActive, 2);
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
            this.layoutOther.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Location = new System.Drawing.Point(104, 3);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.MaxLength = 250;
            this.txtRemark.Size = new System.Drawing.Size(200, 50);
            this.txtRemark.TabIndex = 5;
            // 
            // FunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CurrentDataState = Framework.UI.Template.Common.DataState.Read;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FunctionForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.gcData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcBase)).EndInit();
            this.grcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFunctionLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFunctionCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFunctionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResourceIdentifier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOther)).EndInit();
            this.grcOther.ResumeLayout(false);
            this.layoutOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private DevExpress.XtraEditors.TextEdit txtFunctionCode;
        private System.Windows.Forms.Label lblFunctionLevel;
        private System.Windows.Forms.Label lblFunctionCode;
        private DevExpress.XtraEditors.TextEdit txtFunctionLevel;
        private System.Windows.Forms.Label lblParentID;
        private DevExpress.XtraEditors.TextEdit txtParentID;
        private DevExpress.XtraEditors.GroupControl grcOther;
        private System.Windows.Forms.TableLayoutPanel layoutOther;
        private System.Windows.Forms.Label lblRemark;
        private DevExpress.XtraEditors.ComboBoxEdit cbIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private System.Windows.Forms.Label lblFunctionName;
        private System.Windows.Forms.Label lblResourceIdentifier;
        private DevExpress.XtraEditors.TextEdit txtFunctionName;
        private DevExpress.XtraEditors.TextEdit txtResourceIdentifier;

    }
}
