namespace Modules.AreaModule.Views
{
    partial class AreaListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.txtAreaCode = new DevExpress.XtraEditors.TextEdit();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.txtAreaName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblAreaCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtAreaCode, 1, 0);
            this.layoutCondition.Controls.Add(this.lblAreaName, 2, 0);
            this.layoutCondition.Controls.Add(this.txtAreaName, 3, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblAreaCode, "lblAreaCode");
            this.lblAreaCode.Name = "lblAreaCode";
            // 
            // txtAreaCode
            // 
            resources.ApplyResources(this.txtAreaCode, "txtAreaCode");
            this.txtAreaCode.Name = "txtAreaCode";
            // 
            // lblAreaName
            // 
            this.lblAreaName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblAreaName, "lblAreaName");
            this.lblAreaName.Name = "lblAreaName";
            // 
            // txtAreaName
            // 
            resources.ApplyResources(this.txtAreaName, "txtAreaName");
            this.txtAreaName.Name = "txtAreaName";
            // 
            // AreaListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "AreaListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblAreaCode;
        private DevExpress.XtraEditors.TextEdit txtAreaCode;
        private System.Windows.Forms.Label lblAreaName;
        private DevExpress.XtraEditors.TextEdit txtAreaName;



    }
}
