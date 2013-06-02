namespace Modules.ContainerTypeModule.Views
{
    partial class ContainerTypeEditForm
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
            this.gcSpec = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.seBearingWeight = new DevExpress.XtraEditors.SpinEdit();
            this.seWeight = new DevExpress.XtraEditors.SpinEdit();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblBearingWeight = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.seLength = new DevExpress.XtraEditors.SpinEdit();
            this.seWidth = new DevExpress.XtraEditors.SpinEdit();
            this.seHeight = new DevExpress.XtraEditors.SpinEdit();
            this.gcBase = new DevExpress.XtraEditors.GroupControl();
            this.layoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.txtTypeName = new DevExpress.XtraEditors.TextEdit();
            this.lblTypeCode = new System.Windows.Forms.Label();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.txtTypeCode = new DevExpress.XtraEditors.TextEdit();
            this.lePurposeType = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPurposeType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).BeginInit();
            this.gcClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSpec)).BeginInit();
            this.gcSpec.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seBearingWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lePurposeType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcClientZone
            // 
            this.gcClientZone.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.gcClientZone.Appearance.Options.UseBackColor = true;
            this.gcClientZone.Controls.Add(this.tcDetail);
            this.gcClientZone.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // tcDetail
            // 
            this.tcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetail.Location = new System.Drawing.Point(5, 5);
            this.tcDetail.Name = "tcDetail";
            this.tcDetail.SelectedTabPage = this.tabBase;
            this.tcDetail.Size = new System.Drawing.Size(624, 422);
            this.tcDetail.TabIndex = 70;
            this.tcDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBase});
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.gcSpec);
            this.tabBase.Controls.Add(this.gcBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Size = new System.Drawing.Size(618, 394);
            this.tabBase.Text = "容器类型信息";
            // 
            // gcSpec
            // 
            this.gcSpec.Controls.Add(this.tableLayoutPanel1);
            this.gcSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSpec.Location = new System.Drawing.Point(0, 95);
            this.gcSpec.LookAndFeel.SkinName = "Lilian";
            this.gcSpec.Name = "gcSpec";
            this.gcSpec.Padding = new System.Windows.Forms.Padding(10);
            this.gcSpec.Size = new System.Drawing.Size(618, 299);
            this.gcSpec.TabIndex = 71;
            this.gcSpec.Text = "规格信息";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.seBearingWeight, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.seWeight, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLength, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHeight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWidth, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBearingWeight, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblWeight, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.seLength, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.seWidth, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.seHeight, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 245);
            this.tableLayoutPanel1.TabIndex = 129;
            // 
            // seBearingWeight
            // 
            this.seBearingWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seBearingWeight.Location = new System.Drawing.Point(417, 59);
            this.seBearingWeight.Name = "seBearingWeight";
            this.seBearingWeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seBearingWeight.Properties.Mask.EditMask = "n2";
            this.seBearingWeight.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seBearingWeight.Size = new System.Drawing.Size(165, 20);
            this.seBearingWeight.TabIndex = 135;
            // 
            // seWeight
            // 
            this.seWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seWeight.Location = new System.Drawing.Point(121, 59);
            this.seWeight.Name = "seWeight";
            this.seWeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seWeight.Properties.Mask.EditMask = "n2";
            this.seWeight.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seWeight.Size = new System.Drawing.Size(165, 20);
            this.seWeight.TabIndex = 135;
            // 
            // lblLength
            // 
            this.lblLength.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLength.Location = new System.Drawing.Point(3, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(81, 23);
            this.lblLength.TabIndex = 129;
            this.lblLength.Text = "长度(米)：";
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeight
            // 
            this.lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblHeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHeight.Location = new System.Drawing.Point(3, 28);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(81, 23);
            this.lblHeight.TabIndex = 74;
            this.lblHeight.Text = "高度(米)：";
            this.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWidth
            // 
            this.lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWidth.Location = new System.Drawing.Point(299, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(81, 23);
            this.lblWidth.TabIndex = 69;
            this.lblWidth.Text = "宽度(米)：";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBearingWeight
            // 
            this.lblBearingWeight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblBearingWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBearingWeight.Location = new System.Drawing.Point(299, 56);
            this.lblBearingWeight.Name = "lblBearingWeight";
            this.lblBearingWeight.Size = new System.Drawing.Size(81, 23);
            this.lblBearingWeight.TabIndex = 73;
            this.lblBearingWeight.Text = "承重(千克)：";
            this.lblBearingWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeight
            // 
            this.lblWeight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWeight.Location = new System.Drawing.Point(3, 56);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(81, 23);
            this.lblWeight.TabIndex = 131;
            this.lblWeight.Text = "自重(千克)：";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seLength
            // 
            this.seLength.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seLength.Location = new System.Drawing.Point(121, 3);
            this.seLength.Name = "seLength";
            this.seLength.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seLength.Properties.Mask.EditMask = "n2";
            this.seLength.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seLength.Size = new System.Drawing.Size(165, 20);
            this.seLength.TabIndex = 134;
            // 
            // seWidth
            // 
            this.seWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seWidth.Location = new System.Drawing.Point(417, 3);
            this.seWidth.MenuManager = this.bmMain;
            this.seWidth.Name = "seWidth";
            this.seWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seWidth.Properties.Mask.EditMask = "n2";
            this.seWidth.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seWidth.Size = new System.Drawing.Size(165, 20);
            this.seWidth.TabIndex = 135;
            // 
            // seHeight
            // 
            this.seHeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seHeight.Location = new System.Drawing.Point(121, 31);
            this.seHeight.MenuManager = this.bmMain;
            this.seHeight.Name = "seHeight";
            this.seHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seHeight.Properties.Mask.EditMask = "n2";
            this.seHeight.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seHeight.Size = new System.Drawing.Size(165, 20);
            this.seHeight.TabIndex = 136;
            // 
            // gcBase
            // 
            this.gcBase.Controls.Add(this.layoutBase);
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.LookAndFeel.SkinName = "Lilian";
            this.gcBase.Name = "gcBase";
            this.gcBase.Padding = new System.Windows.Forms.Padding(10);
            this.gcBase.Size = new System.Drawing.Size(618, 95);
            this.gcBase.TabIndex = 68;
            this.gcBase.Text = "基本信息";
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
            this.layoutBase.Controls.Add(this.txtTypeName, 3, 0);
            this.layoutBase.Controls.Add(this.lblTypeCode, 0, 0);
            this.layoutBase.Controls.Add(this.lblTypeName, 2, 0);
            this.layoutBase.Controls.Add(this.txtTypeCode, 1, 0);
            this.layoutBase.Controls.Add(this.lePurposeType, 1, 1);
            this.layoutBase.Controls.Add(this.lblPurposeType, 0, 1);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 3;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.Size = new System.Drawing.Size(594, 67);
            this.layoutBase.TabIndex = 128;
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(417, 3);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Properties.MaxLength = 30;
            this.txtTypeName.Size = new System.Drawing.Size(165, 20);
            this.txtTypeName.TabIndex = 1;
            // 
            // lblTypeCode
            // 
            this.lblTypeCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTypeCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTypeCode.Location = new System.Drawing.Point(3, 0);
            this.lblTypeCode.Name = "lblTypeCode";
            this.lblTypeCode.Size = new System.Drawing.Size(78, 23);
            this.lblTypeCode.TabIndex = 69;
            this.lblTypeCode.Text = "类型代码*：";
            this.lblTypeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTypeName
            // 
            this.lblTypeName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTypeName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTypeName.Location = new System.Drawing.Point(299, 0);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(86, 23);
            this.lblTypeName.TabIndex = 73;
            this.lblTypeName.Text = "类型名称*：";
            this.lblTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTypeCode
            // 
            this.txtTypeCode.Location = new System.Drawing.Point(121, 3);
            this.txtTypeCode.Name = "txtTypeCode";
            this.txtTypeCode.Properties.MaxLength = 30;
            this.txtTypeCode.Size = new System.Drawing.Size(165, 20);
            this.txtTypeCode.TabIndex = 0;
            // 
            // lePurposeType
            // 
            this.lePurposeType.Location = new System.Drawing.Point(121, 31);
            this.lePurposeType.Name = "lePurposeType";
            this.lePurposeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lePurposeType.Properties.NullText = "";
            this.lePurposeType.Size = new System.Drawing.Size(165, 20);
            this.lePurposeType.TabIndex = 74;
            // 
            // lblPurposeType
            // 
            this.lblPurposeType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPurposeType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPurposeType.Location = new System.Drawing.Point(3, 28);
            this.lblPurposeType.Name = "lblPurposeType";
            this.lblPurposeType.Size = new System.Drawing.Size(78, 23);
            this.lblPurposeType.TabIndex = 75;
            this.lblPurposeType.Text = "用途类型*：";
            this.lblPurposeType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ContainerTypeEditForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ContainerTypeEditForm";
            this.Text = "容器明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).EndInit();
            this.gcClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSpec)).EndInit();
            this.gcSpec.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seBearingWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lePurposeType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private DevExpress.XtraEditors.TextEdit txtTypeName;
        private System.Windows.Forms.Label lblTypeCode;
        private System.Windows.Forms.Label lblTypeName;
        private DevExpress.XtraEditors.TextEdit txtTypeCode;
        private DevExpress.XtraEditors.GroupControl gcSpec;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SpinEdit seBearingWeight;
        private DevExpress.XtraEditors.SpinEdit seWeight;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblBearingWeight;
        private System.Windows.Forms.Label lblWeight;
        private DevExpress.XtraEditors.SpinEdit seLength;
        private DevExpress.XtraEditors.SpinEdit seWidth;
        private DevExpress.XtraEditors.SpinEdit seHeight;
        private DevExpress.XtraEditors.LookUpEdit lePurposeType;
        private System.Windows.Forms.Label lblPurposeType;




    }
}
