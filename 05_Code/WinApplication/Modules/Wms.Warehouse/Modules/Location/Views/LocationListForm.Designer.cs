namespace Modules.LocationModule.Views
{
    partial class LocationListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationListForm));
            this.layoutCondition = new System.Windows.Forms.TableLayoutPanel();
            this.lblAreaType = new System.Windows.Forms.Label();
            this.leAreaType = new DevExpress.XtraEditors.LookUpEdit();
            this.txtLocationName = new DevExpress.XtraEditors.TextEdit();
            this.beAreaId = new DevExpress.XtraEditors.ButtonEdit();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.lblLocationCode = new System.Windows.Forms.Label();
            this.txtLocationCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondition)).BeginInit();
            this.gcCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientZone)).BeginInit();
            this.pnlClientZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.layoutCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leAreaType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beAreaId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCondition
            // 
            this.gcCondition.Controls.Add(this.layoutCondition);
            // 
            // layoutCondition
            // 
            resources.ApplyResources(this.layoutCondition, "layoutCondition");
            this.layoutCondition.Controls.Add(this.lblAreaType, 0, 0);
            this.layoutCondition.Controls.Add(this.leAreaType, 1, 0);
            this.layoutCondition.Controls.Add(this.txtLocationName, 3, 1);
            this.layoutCondition.Controls.Add(this.beAreaId, 3, 0);
            this.layoutCondition.Controls.Add(this.lblAreaName, 2, 0);
            this.layoutCondition.Controls.Add(this.lblLocationName, 2, 1);
            this.layoutCondition.Controls.Add(this.lblLocationCode, 0, 1);
            this.layoutCondition.Controls.Add(this.txtLocationCode, 1, 1);
            this.layoutCondition.Name = "layoutCondition";
            // 
            // lblAreaType
            // 
            this.lblAreaType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblAreaType, "lblAreaType");
            this.lblAreaType.Name = "lblAreaType";
            // 
            // leAreaType
            // 
            resources.ApplyResources(this.leAreaType, "leAreaType");
            this.leAreaType.Name = "leAreaType";
            this.leAreaType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leAreaType.Properties.Buttons"))))});
            this.leAreaType.Properties.NullText = resources.GetString("leAreaType.Properties.NullText");
            // 
            // txtLocationName
            // 
            resources.ApplyResources(this.txtLocationName, "txtLocationName");
            this.txtLocationName.Name = "txtLocationName";
            // 
            // beAreaId
            // 
            resources.ApplyResources(this.beAreaId, "beAreaId");
            this.beAreaId.Name = "beAreaId";
            this.beAreaId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("beAreaId.Properties.Buttons"))))});
            this.beAreaId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beAreaId_ButtonClick);
            // 
            // lblAreaName
            // 
            this.lblAreaName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblAreaName, "lblAreaName");
            this.lblAreaName.Name = "lblAreaName";
            // 
            // lblLocationName
            // 
            this.lblLocationName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblLocationName, "lblLocationName");
            this.lblLocationName.Name = "lblLocationName";
            // 
            // lblLocationCode
            // 
            this.lblLocationCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.lblLocationCode, "lblLocationCode");
            this.lblLocationCode.Name = "lblLocationCode";
            // 
            // txtLocationCode
            // 
            resources.ApplyResources(this.txtLocationCode, "txtLocationCode");
            this.txtLocationCode.Name = "txtLocationCode";
            // 
            // LocationListForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "LocationListForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.leAreaType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beAreaId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutCondition;
        private System.Windows.Forms.Label lblLocationCode;
        private DevExpress.XtraEditors.TextEdit txtLocationCode;
        private System.Windows.Forms.Label lblLocationName;
        private DevExpress.XtraEditors.TextEdit txtLocationName;
        private System.Windows.Forms.Label lblAreaName;
        private DevExpress.XtraEditors.ButtonEdit beAreaId;
        private DevExpress.XtraEditors.LookUpEdit leAreaType;
        private System.Windows.Forms.Label lblAreaType;



    }
}
