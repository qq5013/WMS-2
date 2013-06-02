namespace Modules.CompanyModule.Views
{
    partial class CompanyListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblCompanyCode = new System.Windows.Forms.Label();
            this.txtCompanyCode = new DevExpress.XtraEditors.TextEdit();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblCompanyCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtCompanyCode, 1, 0);
            this.layoutCondition.Controls.Add(this.lblCompanyName, 2, 0);
            this.layoutCondition.Controls.Add(this.txtCompanyName, 3, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblCompanyCode
            // 
            this.lblCompanyCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblCompanyCode, "lblCompanyCode");
            this.lblCompanyCode.Name = "lblCompanyCode";
            // 
            // txtCompanyCode
            // 
            resources.ApplyResources(this.txtCompanyCode, "txtCompanyCode");
            this.txtCompanyCode.Name = "txtCompanyCode";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblCompanyName, "lblCompanyName");
            this.lblCompanyName.Name = "lblCompanyName";
            // 
            // txtCompanyName
            // 
            resources.ApplyResources(this.txtCompanyName, "txtCompanyName");
            this.txtCompanyName.Name = "txtCompanyName";
            // 
            // CompanyListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "CompanyListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblCompanyCode;
        private DevExpress.XtraEditors.TextEdit txtCompanyCode;
        private System.Windows.Forms.Label lblCompanyName;
        private DevExpress.XtraEditors.TextEdit txtCompanyName;



    }
}
