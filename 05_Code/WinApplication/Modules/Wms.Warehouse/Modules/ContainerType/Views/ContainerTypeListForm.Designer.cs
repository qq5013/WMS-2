namespace Modules.ContainerTypeModule.Views
{
    partial class ContainerTypeListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerTypeListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblTypeCode = new System.Windows.Forms.Label();
            this.txtTypeCode = new DevExpress.XtraEditors.TextEdit();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.txtTypeName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblTypeCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtTypeCode, 1, 0);
            this.layoutCondition.Controls.Add(this.lblTypeName, 2, 0);
            this.layoutCondition.Controls.Add(this.txtTypeName, 3, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblTypeCode
            // 
            resources.ApplyResources(this.lblTypeCode, "lblTypeCode");
            this.lblTypeCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTypeCode.Name = "lblTypeCode";
            // 
            // txtTypeCode
            // 
            resources.ApplyResources(this.txtTypeCode, "txtTypeCode");
            this.txtTypeCode.Name = "txtTypeCode";
            // 
            // lblTypeName
            // 
            this.lblTypeName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblTypeName, "lblTypeName");
            this.lblTypeName.Name = "lblTypeName";
            // 
            // txtTypeName
            // 
            resources.ApplyResources(this.txtTypeName, "txtTypeName");
            this.txtTypeName.Name = "txtTypeName";
            // 
            // ContainerTypeListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "ContainerTypeListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblTypeCode;
        private DevExpress.XtraEditors.TextEdit txtTypeCode;
        private System.Windows.Forms.Label lblTypeName;
        private DevExpress.XtraEditors.TextEdit txtTypeName;



    }
}
