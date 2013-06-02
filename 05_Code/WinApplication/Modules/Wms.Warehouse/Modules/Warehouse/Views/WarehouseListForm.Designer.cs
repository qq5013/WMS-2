namespace Modules.WarehouseModule.Views
{
    partial class WarehouseListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblWarehouseCode = new System.Windows.Forms.Label();
            this.txtWarehouseCode = new DevExpress.XtraEditors.TextEdit();
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.txtWarehouseName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblWarehouseCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtWarehouseCode, 1, 0);
            this.layoutCondition.Controls.Add(this.lblWarehouseName, 2, 0);
            this.layoutCondition.Controls.Add(this.txtWarehouseName, 3, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblWarehouseCode
            // 
            this.lblWarehouseCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblWarehouseCode, "lblWarehouseCode");
            this.lblWarehouseCode.Name = "lblWarehouseCode";
            // 
            // txtWarehouseCode
            // 
            resources.ApplyResources(this.txtWarehouseCode, "txtWarehouseCode");
            this.txtWarehouseCode.Name = "txtWarehouseCode";
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblWarehouseName, "lblWarehouseName");
            this.lblWarehouseName.Name = "lblWarehouseName";
            // 
            // txtWarehouseName
            // 
            resources.ApplyResources(this.txtWarehouseName, "txtWarehouseName");
            this.txtWarehouseName.Name = "txtWarehouseName";
            // 
            // WarehouseListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "WarehouseListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblWarehouseCode;
        private DevExpress.XtraEditors.TextEdit txtWarehouseCode;
        private System.Windows.Forms.Label lblWarehouseName;
        private DevExpress.XtraEditors.TextEdit txtWarehouseName;



    }
}
