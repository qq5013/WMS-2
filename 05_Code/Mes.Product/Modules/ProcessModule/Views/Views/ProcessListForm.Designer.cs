namespace Mes.Product.Modules.ProcessModule.Views
{
    partial class ProcessListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblProcessCode = new System.Windows.Forms.Label();
            this.txtProcessCode = new DevExpress.XtraEditors.TextEdit();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.txtProcessName = new DevExpress.XtraEditors.TextEdit();
        
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
          
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).BeginInit();
            this.SuspendLayout();
          
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            resources.ApplyResources(this.gcCondition, "gcCondition");
         
            // 
            // pnlCondition
            // 
            resources.ApplyResources(this.pnlCondition, "pnlCondition");
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblProcessCode, 0, 0);
            this.layoutCondition.Controls.Add(this.txtProcessCode, 1, 0);
            this.layoutCondition.Controls.Add(this.lblProcessName, 2, 0);
            this.layoutCondition.Controls.Add(this.txtProcessName, 3, 0);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblProcessCode
            // 
            this.lblProcessCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblProcessCode, "lblProcessCode");
            this.lblProcessCode.Name = "lblProcessCode";
            // 
            // txtProcessCode
            // 
            resources.ApplyResources(this.txtProcessCode, "txtProcessCode");
            this.txtProcessCode.Name = "txtProcessCode";
            // 
            // lblProcessName
            // 
            this.lblProcessName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblProcessName, "lblProcessName");
            this.lblProcessName.Name = "lblProcessName";
            // 
            // txtProcessName
            // 
            resources.ApplyResources(this.txtProcessName, "txtProcessName");
            this.txtProcessName.Name = "txtProcessName";
            // 
            // ProcessListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "ProcessListForm";
            this.PageNumber = 1;
            this.PagesCount = 1;
            this.PageSize = 100;
        
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).EndInit();
            this.gcCondition.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            this.layoutCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblProcessCode;
        private DevExpress.XtraEditors.TextEdit txtProcessCode;
        private System.Windows.Forms.Label lblProcessName;
        private DevExpress.XtraEditors.TextEdit txtProcessName;



    }
}
