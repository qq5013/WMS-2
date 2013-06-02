namespace Mes.Product.Modules.ProductStationModel
{
    partial class ProductStationEditForm
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
            this.teEdit = new DevExpress.XtraEditors.TextEdit();
            this.lblProductStationCode = new System.Windows.Forms.Label();
            this.lblShortName = new System.Windows.Forms.Label();
            this.lblParentId = new System.Windows.Forms.Label();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.lblProductStationName = new System.Windows.Forms.Label();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lueProductLine = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).BeginInit();
            this.gcClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).BeginInit();
            this.tcDetail.SuspendLayout();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            this.gcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductLine.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcClientZone
            // 
            this.gcClientZone.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.gcClientZone.Appearance.Options.UseBackColor = true;
            this.gcClientZone.Controls.Add(this.tcDetail);
            this.gcClientZone.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcClientZone.Size = new System.Drawing.Size(634, 256);
            // 
            // tcDetail
            // 
            this.tcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetail.Location = new System.Drawing.Point(5, 5);
            this.tcDetail.Name = "tcDetail";
            this.tcDetail.SelectedTabPage = this.tabBase;
            this.tcDetail.Size = new System.Drawing.Size(624, 246);
            this.tcDetail.TabIndex = 70;
            this.tcDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBase});
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.gcBase);
            this.tabBase.Name = "tabBase";
            this.tabBase.Size = new System.Drawing.Size(618, 218);
            this.tabBase.Text = "工位信息";
            // 
            // gcBase
            // 
            this.gcBase.Controls.Add(this.layoutBase);
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.LookAndFeel.SkinName = "Lilian";
            this.gcBase.Name = "gcBase";
            this.gcBase.Padding = new System.Windows.Forms.Padding(10);
            this.gcBase.Size = new System.Drawing.Size(618, 223);
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
            this.layoutBase.Controls.Add(this.teEdit, 1, 0);
            this.layoutBase.Controls.Add(this.lblProductStationCode, 0, 0);
            this.layoutBase.Controls.Add(this.lblShortName, 0, 1);
            this.layoutBase.Controls.Add(this.teName, 3, 0);
            this.layoutBase.Controls.Add(this.lblProductStationName, 2, 0);
            this.layoutBase.Controls.Add(this.lueProductLine, 1, 1);
            this.layoutBase.Controls.Add(this.lblParentId, 0, 2);
            this.layoutBase.Controls.Add(this.meRemark, 1, 2);
            this.layoutBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBase.Location = new System.Drawing.Point(12, 31);
            this.layoutBase.Name = "layoutBase";
            this.layoutBase.RowCount = 3;
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBase.Size = new System.Drawing.Size(594, 177);
            this.layoutBase.TabIndex = 128;
            // 
            // teEdit
            // 
            this.teEdit.Location = new System.Drawing.Point(121, 3);
            this.teEdit.Name = "teEdit";
            this.teEdit.Size = new System.Drawing.Size(165, 20);
            this.teEdit.TabIndex = 0;
            // 
            // lblProductStationCode
            // 
            this.lblProductStationCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblProductStationCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProductStationCode.Location = new System.Drawing.Point(3, 0);
            this.lblProductStationCode.Name = "lblProductStationCode";
            this.lblProductStationCode.Size = new System.Drawing.Size(81, 23);
            this.lblProductStationCode.TabIndex = 129;
            this.lblProductStationCode.Text = "工位名称*：";
            this.lblProductStationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShortName
            // 
            this.lblShortName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblShortName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblShortName.Location = new System.Drawing.Point(3, 28);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(81, 23);
            this.lblShortName.TabIndex = 74;
            this.lblShortName.Text = "产线代码*：";
            this.lblShortName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblParentId
            // 
            this.lblParentId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblParentId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParentId.Location = new System.Drawing.Point(3, 56);
            this.lblParentId.Name = "lblParentId";
            this.lblParentId.Size = new System.Drawing.Size(81, 23);
            this.lblParentId.TabIndex = 73;
            this.lblParentId.Text = "描述：";
            this.lblParentId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(417, 3);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(165, 20);
            this.teName.TabIndex = 1;
            // 
            // lblProductStationName
            // 
            this.lblProductStationName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblProductStationName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProductStationName.Location = new System.Drawing.Point(299, 0);
            this.lblProductStationName.Name = "lblProductStationName";
            this.lblProductStationName.Size = new System.Drawing.Size(81, 23);
            this.lblProductStationName.TabIndex = 69;
            this.lblProductStationName.Text = "工位代码*：";
            this.lblProductStationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // meRemark
            // 
            this.layoutBase.SetColumnSpan(this.meRemark, 3);
            this.meRemark.Location = new System.Drawing.Point(121, 59);
            this.meRemark.MenuManager = this.bmMain;
            this.meRemark.Name = "meRemark";
            this.meRemark.Size = new System.Drawing.Size(461, 115);
            this.meRemark.TabIndex = 134;
            // 
            // lueProductLine
            // 
            this.lueProductLine.Location = new System.Drawing.Point(121, 31);
            this.lueProductLine.MenuManager = this.bmMain;
            this.lueProductLine.Name = "lueProductLine";
            this.lueProductLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProductLine.Size = new System.Drawing.Size(165, 20);
            this.lueProductLine.TabIndex = 135;
            // 
            // ProductStationEditForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 280);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ProductStationEditForm";
            this.Text = "工位明细";
            ((System.ComponentModel.ISupportInitialize)(this.gcClientZone)).EndInit();
            this.gcClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcDetail)).EndInit();
            this.tcDetail.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            this.gcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductLine.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcDetail;
        private DevExpress.XtraTab.XtraTabPage tabBase;
        private DevExpress.XtraEditors.GroupControl gcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.Label lblShortName;
        private System.Windows.Forms.Label lblParentId;
        private DevExpress.XtraEditors.TextEdit teName;
        private System.Windows.Forms.Label lblProductStationName;
        private DevExpress.XtraEditors.TextEdit teEdit;
        private System.Windows.Forms.Label lblProductStationCode;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private DevExpress.XtraEditors.LookUpEdit lueProductLine;




    }
}
