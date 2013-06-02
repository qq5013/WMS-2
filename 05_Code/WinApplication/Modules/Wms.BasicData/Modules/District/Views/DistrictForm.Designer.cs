namespace Modules.DistrictModule.Views
{
    partial class DistrictForm
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
            this.lblDistrictLevel = new System.Windows.Forms.Label();
            this.txtDistrictLevel = new DevExpress.XtraEditors.TextEdit();
            this.lblParentID = new System.Windows.Forms.Label();
            this.txtParentID = new DevExpress.XtraEditors.TextEdit();
            this.txtDistrictCode = new DevExpress.XtraEditors.TextEdit();
            this.lblDistrictCode = new System.Windows.Forms.Label();
            this.lblDistrictName = new System.Windows.Forms.Label();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtDistrictName = new DevExpress.XtraEditors.TextEdit();
            this.txtPostalCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.gcData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBase)).BeginInit();
            this.grcBase.SuspendLayout();
            this.layoutBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcData
            // 
            this.gcData.Controls.Add(this.grcBase);
            // 
            // grcBase
            // 
            this.grcBase.Controls.Add(this.layoutBase);
            this.grcBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.grcBase.Location = new System.Drawing.Point(7, 26);
            this.grcBase.LookAndFeel.SkinName = "Lilian";
            this.grcBase.Name = "grcBase";
            this.grcBase.Padding = new System.Windows.Forms.Padding(10);
            this.grcBase.Size = new System.Drawing.Size(531, 184);
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
            this.layoutBase.Controls.Add(this.lblDistrictLevel, 0, 0);
            this.layoutBase.Controls.Add(this.txtDistrictLevel, 1, 0);
            this.layoutBase.Controls.Add(this.lblParentID, 0, 1);
            this.layoutBase.Controls.Add(this.txtParentID, 1, 1);
            this.layoutBase.Controls.Add(this.txtDistrictCode, 1, 2);
            this.layoutBase.Controls.Add(this.lblDistrictCode, 0, 2);
            this.layoutBase.Controls.Add(this.lblDistrictName, 0, 3);
            this.layoutBase.Controls.Add(this.lblPostalCode, 0, 4);
            this.layoutBase.Controls.Add(this.txtDistrictName, 1, 3);
            this.layoutBase.Controls.Add(this.txtPostalCode, 1, 4);
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
            this.layoutBase.Size = new System.Drawing.Size(507, 144);
            this.layoutBase.TabIndex = 128;
            // 
            // lblDistrictLevel
            // 
            this.lblDistrictLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDistrictLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDistrictLevel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDistrictLevel.Location = new System.Drawing.Point(3, 0);
            this.lblDistrictLevel.Name = "lblDistrictLevel";
            this.lblDistrictLevel.Size = new System.Drawing.Size(95, 23);
            this.lblDistrictLevel.TabIndex = 69;
            this.lblDistrictLevel.Text = "地区级别*：";
            this.lblDistrictLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDistrictLevel
            // 
            this.layoutBase.SetColumnSpan(this.txtDistrictLevel, 2);
            this.txtDistrictLevel.Enabled = false;
            this.txtDistrictLevel.Location = new System.Drawing.Point(104, 3);
            this.txtDistrictLevel.Name = "txtDistrictLevel";
            this.txtDistrictLevel.Properties.ReadOnly = true;
            this.txtDistrictLevel.Size = new System.Drawing.Size(200, 20);
            this.txtDistrictLevel.TabIndex = 0;
            // 
            // lblParentID
            // 
            this.lblParentID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblParentID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParentID.Location = new System.Drawing.Point(3, 28);
            this.lblParentID.Name = "lblParentID";
            this.lblParentID.Size = new System.Drawing.Size(95, 23);
            this.lblParentID.TabIndex = 74;
            this.lblParentID.Text = "父级地区*：";
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
            // txtDistrictCode
            // 
            this.layoutBase.SetColumnSpan(this.txtDistrictCode, 2);
            this.txtDistrictCode.Location = new System.Drawing.Point(104, 59);
            this.txtDistrictCode.Name = "txtDistrictCode";
            this.txtDistrictCode.Properties.MaxLength = 20;
            this.txtDistrictCode.Size = new System.Drawing.Size(200, 20);
            this.txtDistrictCode.TabIndex = 2;
            // 
            // lblDistrictCode
            // 
            this.lblDistrictCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDistrictCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDistrictCode.Location = new System.Drawing.Point(3, 56);
            this.lblDistrictCode.Name = "lblDistrictCode";
            this.lblDistrictCode.Size = new System.Drawing.Size(95, 23);
            this.lblDistrictCode.TabIndex = 73;
            this.lblDistrictCode.Text = "地区代码*：";
            this.lblDistrictCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDistrictName
            // 
            this.lblDistrictName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDistrictName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDistrictName.Location = new System.Drawing.Point(3, 84);
            this.lblDistrictName.Name = "lblDistrictName";
            this.lblDistrictName.Size = new System.Drawing.Size(95, 23);
            this.lblDistrictName.TabIndex = 76;
            this.lblDistrictName.Text = "地区名称*：";
            this.lblDistrictName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPostalCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPostalCode.Location = new System.Drawing.Point(3, 112);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(95, 23);
            this.lblPostalCode.TabIndex = 77;
            this.lblPostalCode.Text = "邮政编码：";
            this.lblPostalCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDistrictName
            // 
            this.layoutBase.SetColumnSpan(this.txtDistrictName, 2);
            this.txtDistrictName.Location = new System.Drawing.Point(104, 87);
            this.txtDistrictName.Name = "txtDistrictName";
            this.txtDistrictName.Properties.MaxLength = 30;
            this.txtDistrictName.Size = new System.Drawing.Size(200, 20);
            this.txtDistrictName.TabIndex = 3;
            // 
            // txtPostalCode
            // 
            this.layoutBase.SetColumnSpan(this.txtPostalCode, 2);
            this.txtPostalCode.Location = new System.Drawing.Point(104, 115);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Properties.MaxLength = 20;
            this.txtPostalCode.Size = new System.Drawing.Size(200, 20);
            this.txtPostalCode.TabIndex = 4;
            // 
            // DistrictForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CurrentDataState = Framework.UI.Template.Common.DataState.Read;
            this.Name = "DistrictForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.gcData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcBase)).EndInit();
            this.grcBase.ResumeLayout(false);
            this.layoutBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private DevExpress.XtraEditors.TextEdit txtDistrictCode;
        private System.Windows.Forms.Label lblDistrictLevel;
        private System.Windows.Forms.Label lblDistrictCode;
        private DevExpress.XtraEditors.TextEdit txtDistrictLevel;
        private System.Windows.Forms.Label lblParentID;
        private DevExpress.XtraEditors.TextEdit txtParentID;
        private System.Windows.Forms.Label lblDistrictName;
        private System.Windows.Forms.Label lblPostalCode;
        private DevExpress.XtraEditors.TextEdit txtDistrictName;
        private DevExpress.XtraEditors.TextEdit txtPostalCode;

    }
}
