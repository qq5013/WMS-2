namespace Modules.SkuModule.Views
{
    partial class SkuListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkuListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpc = new System.Windows.Forms.Label();
            this.txtUpc = new DevExpress.XtraEditors.TextEdit();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.lblMerchantId = new System.Windows.Forms.Label();
            this.beMerchantId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblErpCode = new System.Windows.Forms.Label();
            this.txtErpCode = new DevExpress.XtraEditors.TextEdit();
            this.lblSkuNumber = new System.Windows.Forms.Label();
            this.txtSkuNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblSkuName = new System.Windows.Forms.Label();
            this.txtSkuName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtErpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuName.Properties)).BeginInit();
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
            this.layoutCondition.Controls.Add(this.lblUpc, 0, 2);
            this.layoutCondition.Controls.Add(this.txtUpc, 1, 2);
            this.layoutCondition.Controls.Add(this.lblBarcode, 2, 2);
            this.layoutCondition.Controls.Add(this.txtBarcode, 3, 2);
            this.layoutCondition.Controls.Add(this.lblMerchantId, 0, 0);
            this.layoutCondition.Controls.Add(this.beMerchantId, 1, 0);
            this.layoutCondition.Controls.Add(this.lblErpCode, 2, 0);
            this.layoutCondition.Controls.Add(this.txtErpCode, 3, 0);
            this.layoutCondition.Controls.Add(this.lblSkuNumber, 0, 1);
            this.layoutCondition.Controls.Add(this.txtSkuNumber, 1, 1);
            this.layoutCondition.Controls.Add(this.lblSkuName, 2, 1);
            this.layoutCondition.Controls.Add(this.txtSkuName, 3, 1);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblUpc
            // 
            this.lblUpc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblUpc, "lblUpc");
            this.lblUpc.Name = "lblUpc";
            // 
            // txtUpc
            // 
            resources.ApplyResources(this.txtUpc, "txtUpc");
            this.txtUpc.Name = "txtUpc";
            // 
            // lblBarcode
            // 
            this.lblBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblBarcode, "lblBarcode");
            this.lblBarcode.Name = "lblBarcode";
            // 
            // txtBarcode
            // 
            resources.ApplyResources(this.txtBarcode, "txtBarcode");
            this.txtBarcode.Name = "txtBarcode";
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblMerchantId, "lblMerchantId");
            this.lblMerchantId.Name = "lblMerchantId";
            // 
            // beMerchantId
            // 
            resources.ApplyResources(this.beMerchantId, "beMerchantId");
            this.beMerchantId.Name = "beMerchantId";
            this.beMerchantId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("beMerchantId.Properties.Buttons"))))});
            this.beMerchantId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beMerchantId_ButtonClick);
            // 
            // lblErpCode
            // 
            this.lblErpCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblErpCode, "lblErpCode");
            this.lblErpCode.Name = "lblErpCode";
            // 
            // txtErpCode
            // 
            resources.ApplyResources(this.txtErpCode, "txtErpCode");
            this.txtErpCode.Name = "txtErpCode";
            // 
            // lblSkuNumber
            // 
            this.lblSkuNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblSkuNumber, "lblSkuNumber");
            this.lblSkuNumber.Name = "lblSkuNumber";
            // 
            // txtSkuNumber
            // 
            resources.ApplyResources(this.txtSkuNumber, "txtSkuNumber");
            this.txtSkuNumber.Name = "txtSkuNumber";
            // 
            // lblSkuName
            // 
            this.lblSkuName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblSkuName, "lblSkuName");
            this.lblSkuName.Name = "lblSkuName";
            // 
            // txtSkuName
            // 
            resources.ApplyResources(this.txtSkuName, "txtSkuName");
            this.txtSkuName.Name = "txtSkuName";
            // 
            // SkuListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "SkuListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtUpc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMerchantId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtErpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblSkuNumber;
        private DevExpress.XtraEditors.TextEdit txtSkuNumber;
        private System.Windows.Forms.Label lblSkuName;
        private DevExpress.XtraEditors.TextEdit txtSkuName;
        private DevExpress.XtraEditors.TextEdit txtErpCode;
        private System.Windows.Forms.Label lblErpCode;
        private System.Windows.Forms.Label lblBarcode;
        private DevExpress.XtraEditors.TextEdit txtBarcode;
        private System.Windows.Forms.Label lblUpc;
        private DevExpress.XtraEditors.TextEdit txtUpc;
        private System.Windows.Forms.Label lblMerchantId;
        public DevExpress.XtraEditors.ButtonEdit beMerchantId;



    }
}
