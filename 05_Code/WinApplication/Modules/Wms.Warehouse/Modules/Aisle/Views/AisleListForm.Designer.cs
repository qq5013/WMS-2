namespace Modules.AisleModule.Views
{
    partial class AisleListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AisleListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblAisleCode = new System.Windows.Forms.Label();
            this.txtAisleCode = new DevExpress.XtraEditors.TextEdit();
            this.lblAisleName = new System.Windows.Forms.Label();
            this.txtAisleName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAisleCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAisleName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblAisleCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtAisleCode, 1, 0);
            this.layoutCondition.Controls.Add(this.lblAisleName, 2, 0);
            this.layoutCondition.Controls.Add(this.txtAisleName, 3, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblAisleCode
            // 
            resources.ApplyResources(this.lblAisleCode, "lblAisleCode");
            this.lblAisleCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAisleCode.Name = "lblAisleCode";
            // 
            // txtAisleCode
            // 
            resources.ApplyResources(this.txtAisleCode, "txtAisleCode");
            this.txtAisleCode.Name = "txtAisleCode";
            // 
            // lblAisleName
            // 
            this.lblAisleName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblAisleName, "lblAisleName");
            this.lblAisleName.Name = "lblAisleName";
            // 
            // txtAisleName
            // 
            resources.ApplyResources(this.txtAisleName, "txtAisleName");
            this.txtAisleName.Name = "txtAisleName";
            // 
            // AisleListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "AisleListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtAisleCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAisleName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblAisleCode;
        private DevExpress.XtraEditors.TextEdit txtAisleCode;
        private System.Windows.Forms.Label lblAisleName;
        private DevExpress.XtraEditors.TextEdit txtAisleName;



    }
}
