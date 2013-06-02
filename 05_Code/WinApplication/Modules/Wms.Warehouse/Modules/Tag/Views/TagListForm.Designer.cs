namespace Modules.TagModule.Views
{
    partial class TagListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblTagNumber = new System.Windows.Forms.Label();
            this.txtTagNumber = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTagNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblTagNumber, 0, 0);
            this.layoutCondition.Controls.Add(this.txtTagNumber, 1, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblTagNumber
            // 
            resources.ApplyResources(this.lblTagNumber, "lblTagNumber");
            this.lblTagNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTagNumber.Name = "lblTagNumber";
            // 
            // txtTagNumber
            // 
            resources.ApplyResources(this.txtTagNumber, "txtTagNumber");
            this.txtTagNumber.Name = "txtTagNumber";
            // 
            // TagListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TagListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtTagNumber.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblTagNumber;
        private DevExpress.XtraEditors.TextEdit txtTagNumber;



    }
}
