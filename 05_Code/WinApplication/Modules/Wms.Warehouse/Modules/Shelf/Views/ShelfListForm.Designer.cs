namespace Modules.ShelfModule.Views
{
    partial class ShelfListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShelfListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblShelfCode = new System.Windows.Forms.Label();
            this.txtShelfCode = new DevExpress.XtraEditors.TextEdit();
            this.lblShelfName = new System.Windows.Forms.Label();
            this.txtShelfName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShelfCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShelfName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblShelfCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtShelfCode, 1, 0);
            this.layoutCondition.Controls.Add(this.lblShelfName, 2, 0);
            this.layoutCondition.Controls.Add(this.txtShelfName, 3, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblShelfCode
            // 
            this.lblShelfCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblShelfCode, "lblShelfCode");
            this.lblShelfCode.Name = "lblShelfCode";
            // 
            // txtShelfCode
            // 
            resources.ApplyResources(this.txtShelfCode, "txtShelfCode");
            this.txtShelfCode.Name = "txtShelfCode";
            // 
            // lblShelfName
            // 
            this.lblShelfName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblShelfName, "lblShelfName");
            this.lblShelfName.Name = "lblShelfName";
            // 
            // txtShelfName
            // 
            resources.ApplyResources(this.txtShelfName, "txtShelfName");
            this.txtShelfName.Name = "txtShelfName";
            // 
            // ShelfListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "ShelfListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtShelfCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShelfName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblShelfCode;
        private DevExpress.XtraEditors.TextEdit txtShelfCode;
        private System.Windows.Forms.Label lblShelfName;
        private DevExpress.XtraEditors.TextEdit txtShelfName;



    }
}
