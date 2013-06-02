namespace Modules.ContainerModule.Views
{
    partial class ContainerListForm
    {
        /// <summary>layoutCondition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblContainerCode = new System.Windows.Forms.Label();
            this.txtContaineCode = new DevExpress.XtraEditors.TextEdit();
            this.lblContaineName = new System.Windows.Forms.Label();
            this.txtContaineName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtContaineCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContaineName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblContainerCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtContaineCode, 1, 0);
            this.layoutCondition.Controls.Add(this.lblContaineName, 2, 0);
            this.layoutCondition.Controls.Add(this.txtContaineName, 3, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblContainerCode
            // 
            this.lblContainerCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblContainerCode, "lblContainerCode");
            this.lblContainerCode.Name = "lblContainerCode";
            // 
            // txtContaineCode
            // 
            resources.ApplyResources(this.txtContaineCode, "txtContaineCode");
            this.txtContaineCode.Name = "txtContaineCode";
            // 
            // lblContaineName
            // 
            this.lblContaineName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblContaineName, "lblContaineName");
            this.lblContaineName.Name = "lblContaineName";
            // 
            // txtContaineName
            // 
            resources.ApplyResources(this.txtContaineName, "txtContaineName");
            this.txtContaineName.Name = "txtContaineName";
            // 
            // ContainerListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "ContainerListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtContaineCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContaineName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblContainerCode;
        private DevExpress.XtraEditors.TextEdit txtContaineCode;
        private System.Windows.Forms.Label lblContaineName;
        private DevExpress.XtraEditors.TextEdit txtContaineName;



    }
}
