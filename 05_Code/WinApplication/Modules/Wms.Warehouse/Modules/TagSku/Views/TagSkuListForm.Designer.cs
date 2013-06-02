namespace Modules.TagSkuModule.Views
{
    partial class TagSkuListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagSkuListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblSkuId = new System.Windows.Forms.Label();
            this.lblTagId = new System.Windows.Forms.Label();
            this.beTagId = new DevExpress.XtraEditors.ButtonEdit();
            this.beSkuId = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beTagId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSkuId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblSkuId, 0, 0);
            this.layoutCondition.Controls.Add(this.lblTagId, 2, 0);
            this.layoutCondition.Controls.Add(this.beTagId, 3, 0);
            this.layoutCondition.Controls.Add(this.beSkuId, 1, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblSkuId
            // 
            this.lblSkuId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblSkuId, "lblSkuId");
            this.lblSkuId.Name = "lblSkuId";
            // 
            // lblTagId
            // 
            this.lblTagId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblTagId, "lblTagId");
            this.lblTagId.Name = "lblTagId";
            // 
            // beTagId
            // 
            resources.ApplyResources(this.beTagId, "beTagId");
            this.beTagId.Name = "beTagId";
            this.beTagId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("beTagId.Properties.Buttons"))))});
            this.beTagId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beTagId_ButtonClick);
            // 
            // beSkuId
            // 
            resources.ApplyResources(this.beSkuId, "beSkuId");
            this.beSkuId.Name = "beSkuId";
            this.beSkuId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("beSkuId.Properties.Buttons"))))});
            this.beSkuId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beSkuId_ButtonClick);
            // 
            // TagSkuListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TagSkuListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.beTagId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSkuId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblSkuId;
        private System.Windows.Forms.Label lblTagId;
        private DevExpress.XtraEditors.ButtonEdit beTagId;
        private DevExpress.XtraEditors.ButtonEdit beSkuId;



    }
}
