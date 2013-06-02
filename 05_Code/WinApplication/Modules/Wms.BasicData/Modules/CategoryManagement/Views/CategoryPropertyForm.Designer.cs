namespace Modules.CategoryManagementModule.Views
{
    partial class CategoryPropertyForm
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
            this.pnlButton = new DevExpress.XtraEditors.PanelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblCategoryProperty = new DevExpress.XtraEditors.LabelControl();
            this.lblBatchProperty = new DevExpress.XtraEditors.LabelControl();
            this.layoutProperty = new System.Windows.Forms.TableLayoutPanel();
            this.lbBatchProperty = new DevExpress.XtraEditors.ListBoxControl();
            this.lbCategoryProperty = new DevExpress.XtraEditors.ListBoxControl();
            this.btnRight = new DevExpress.XtraEditors.SimpleButton();
            this.btnLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButton)).BeginInit();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.layoutProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbBatchProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCategoryProperty)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnOk);
            this.pnlButton.Controls.Add(this.btnCancel);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 369);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(608, 35);
            this.pnlButton.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(450, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(526, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblCategoryProperty);
            this.panelControl1.Controls.Add(this.lblBatchProperty);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(608, 25);
            this.panelControl1.TabIndex = 6;
            // 
            // lblCategoryProperty
            // 
            this.lblCategoryProperty.Location = new System.Drawing.Point(343, 6);
            this.lblCategoryProperty.Name = "lblCategoryProperty";
            this.lblCategoryProperty.Size = new System.Drawing.Size(108, 13);
            this.lblCategoryProperty.TabIndex = 1;
            this.lblCategoryProperty.Text = "管理分类批次属性：";
            // 
            // lblBatchProperty
            // 
            this.lblBatchProperty.Location = new System.Drawing.Point(12, 6);
            this.lblBatchProperty.Name = "lblBatchProperty";
            this.lblBatchProperty.Size = new System.Drawing.Size(84, 13);
            this.lblBatchProperty.TabIndex = 0;
            this.lblBatchProperty.Text = "可用批次属性：";
            // 
            // layoutProperty
            // 
            this.layoutProperty.ColumnCount = 3;
            this.layoutProperty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.layoutProperty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layoutProperty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.layoutProperty.Controls.Add(this.lbBatchProperty, 0, 0);
            this.layoutProperty.Controls.Add(this.lbCategoryProperty, 2, 0);
            this.layoutProperty.Controls.Add(this.btnRight, 1, 1);
            this.layoutProperty.Controls.Add(this.btnLeft, 1, 2);
            this.layoutProperty.Controls.Add(this.btnUp, 1, 7);
            this.layoutProperty.Controls.Add(this.btnDown, 1, 8);
            this.layoutProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutProperty.Location = new System.Drawing.Point(0, 25);
            this.layoutProperty.Name = "layoutProperty";
            this.layoutProperty.RowCount = 10;
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutProperty.Size = new System.Drawing.Size(608, 344);
            this.layoutProperty.TabIndex = 7;
            // 
            // lbBatchProperty
            // 
            this.lbBatchProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBatchProperty.Location = new System.Drawing.Point(10, 5);
            this.lbBatchProperty.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.lbBatchProperty.Name = "lbBatchProperty";
            this.layoutProperty.SetRowSpan(this.lbBatchProperty, 10);
            this.lbBatchProperty.Size = new System.Drawing.Size(253, 329);
            this.lbBatchProperty.TabIndex = 0;
            // 
            // lbCategoryProperty
            // 
            this.lbCategoryProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCategoryProperty.Location = new System.Drawing.Point(343, 5);
            this.lbCategoryProperty.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.lbCategoryProperty.Name = "lbCategoryProperty";
            this.layoutProperty.SetRowSpan(this.lbCategoryProperty, 10);
            this.lbCategoryProperty.Size = new System.Drawing.Size(255, 329);
            this.lbCategoryProperty.TabIndex = 1;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(276, 33);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(54, 23);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = "加入";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(276, 63);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(54, 23);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "移除";
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(276, 213);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(54, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "向上";
            this.btnUp.Visible = false;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(276, 243);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(54, 23);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "向下";
            this.btnDown.Visible = false;
            // 
            // CategoryPropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 404);
            this.ControlBox = false;
            this.Controls.Add(this.layoutProperty);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CategoryPropertyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批次属性设置";
            this.Load += new System.EventHandler(this.CategoryPropertyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButton)).EndInit();
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.layoutProperty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbBatchProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCategoryProperty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlButton;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblCategoryProperty;
        private DevExpress.XtraEditors.LabelControl lblBatchProperty;
        private System.Windows.Forms.TableLayoutPanel layoutProperty;
        private DevExpress.XtraEditors.ListBoxControl lbBatchProperty;
        private DevExpress.XtraEditors.ListBoxControl lbCategoryProperty;
        private DevExpress.XtraEditors.SimpleButton btnRight;
        private DevExpress.XtraEditors.SimpleButton btnLeft;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnDown;

    }
}