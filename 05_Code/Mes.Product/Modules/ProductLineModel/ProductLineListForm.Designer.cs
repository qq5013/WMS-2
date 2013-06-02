namespace Mes.Product.Modules.ProductLineModel
{
    partial class ProductLineListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductLineListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblProductLineCode = new System.Windows.Forms.Label();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.lblProductLineName = new System.Windows.Forms.Label();
            this.teCode = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lueProductLineType = new DevExpress.XtraEditors.LookUpEdit();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductLineType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcGrid
            // 
            resources.ApplyResources(this.gcGrid, "gcGrid");
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            resources.ApplyResources(this.gcCondition, "gcCondition");
            // 
            // pnlClientZone
            // 
            resources.ApplyResources(this.pnlClientZone, "pnlClientZone");
            // 
            // pnlCondition
            // 
            resources.ApplyResources(this.pnlCondition, "pnlCondition");
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lueProductLineType, 0, 1);
            this.layoutCondition.Controls.Add(this.lblProductLineCode, 0, 0);
            this.layoutCondition.Controls.Add(this.teName, 1, 0);
            this.layoutCondition.Controls.Add(this.lblProductLineName, 2, 0);
            this.layoutCondition.Controls.Add(this.teCode, 3, 0);
            this.layoutCondition.Controls.Add(this.label1, 0, 1);
            this.layoutCondition.Controls.Add(this.label2, 2, 1);
            this.layoutCondition.Controls.Add(this.meRemark, 3, 1);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblProductLineCode
            // 
            this.lblProductLineCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblProductLineCode, "lblProductLineCode");
            this.lblProductLineCode.Name = "lblProductLineCode";
            // 
            // teName
            // 
            resources.ApplyResources(this.teName, "teName");
            this.teName.Name = "teName";
            // 
            // lblProductLineName
            // 
            this.lblProductLineName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblProductLineName, "lblProductLineName");
            this.lblProductLineName.Name = "lblProductLineName";
            // 
            // teCode
            // 
            resources.ApplyResources(this.teCode, "teCode");
            this.teCode.Name = "teCode";
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lueProductLineType
            // 
            resources.ApplyResources(this.lueProductLineType, "lueProductLineType");
            this.lueProductLineType.Name = "lueProductLineType";
            this.lueProductLineType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lueProductLine.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lueProductLine.Properties.Buttons1"))))});
            this.lueProductLineType.Properties.NullText = resources.GetString("lueProductLine.Properties.NullText");
            // 
            // meRemark
            // 
            resources.ApplyResources(this.meRemark, "meRemark");
            this.meRemark.Name = "meRemark";
            // 
            // ProductLineListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "ProductLineListForm";
            this.PageNumber = 1;
            this.PagesCount = 1;
            this.PageSize = 100;
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).EndInit();
            this.pnlClientZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductLineType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblProductLineCode;
        private DevExpress.XtraEditors.TextEdit teName;
        private System.Windows.Forms.Label lblProductLineName;
        private DevExpress.XtraEditors.TextEdit teCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lueProductLineType;
        private DevExpress.XtraEditors.MemoEdit meRemark;



    }
}
