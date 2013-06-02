namespace MES.Execute
{
    partial class FormLogon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogon));
            this.lblErrorMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnDone = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblProcess = new DevExpress.XtraEditors.LabelControl();
            this.teLoginName = new DevExpress.XtraEditors.TextEdit();
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.glueProcess = new DevExpress.XtraEditors.GridLookUpEdit();
            this.riglueProductName = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.riglueProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.teLoginName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riglueProductName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riglueProductCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(52, 253);
            this.lblErrorMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMessage.TabIndex = 5;
            // 
            // btnDone
            // 
            this.btnDone.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Appearance.Options.UseFont = true;
            this.btnDone.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnDone.Location = new System.Drawing.Point(51, 215);
            this.btnDone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(81, 35);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "登录";
            this.btnDone.Click += new System.EventHandler(this.BtnDoneClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnCancel.Location = new System.Drawing.Point(155, 215);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(24, 84);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 16);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "用户名：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(24, 130);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 16);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "登录密码：";
            // 
            // lblProcess
            // 
            this.lblProcess.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.Location = new System.Drawing.Point(24, 176);
            this.lblProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(80, 16);
            this.lblProcess.TabIndex = 8;
            this.lblProcess.Text = "生产车间：";
            // 
            // teLoginName
            // 
            this.teLoginName.EditValue = "admin";
            this.teLoginName.EnterMoveNextControl = true;
            this.teLoginName.Location = new System.Drawing.Point(107, 81);
            this.teLoginName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.teLoginName.Name = "teLoginName";
            this.teLoginName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teLoginName.Properties.Appearance.Options.UseFont = true;
            this.teLoginName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.teLoginName.Size = new System.Drawing.Size(150, 22);
            this.teLoginName.TabIndex = 0;
            // 
            // tePassword
            // 
            this.tePassword.EditValue = "123456";
            this.tePassword.EnterMoveNextControl = true;
            this.tePassword.Location = new System.Drawing.Point(107, 127);
            this.tePassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tePassword.Properties.Appearance.Options.UseFont = true;
            this.tePassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.tePassword.Properties.PasswordChar = '*';
            this.tePassword.Size = new System.Drawing.Size(150, 22);
            this.tePassword.TabIndex = 1;
            // 
            // glueProcess
            // 
            this.glueProcess.EnterMoveNextControl = true;
            this.glueProcess.Location = new System.Drawing.Point(107, 173);
            this.glueProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.glueProcess.Name = "glueProcess";
            this.glueProcess.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glueProcess.Properties.Appearance.Options.UseFont = true;
            this.glueProcess.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.glueProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueProcess.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riglueProductName,
            this.riglueProductCode});
            this.glueProcess.Properties.View = this.gridLookUpEdit1View;
            this.glueProcess.Size = new System.Drawing.Size(150, 22);
            this.glueProcess.TabIndex = 2;
            // 
            // riglueProductName
            // 
            this.riglueProductName.AutoHeight = false;
            this.riglueProductName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riglueProductName.Name = "riglueProductName";
            this.riglueProductName.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // riglueProductCode
            // 
            this.riglueProductCode.AutoHeight = false;
            this.riglueProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riglueProductCode.Name = "riglueProductCode";
            this.riglueProductCode.View = this.repositoryItemGridLookUpEdit2View;
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProductName,
            this.gcProductCode,
            this.gcName,
            this.gcCode});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gcProductName
            // 
            this.gcProductName.Caption = "产品名称";
            this.gcProductName.ColumnEdit = this.riglueProductName;
            this.gcProductName.FieldName = "ProductId";
            this.gcProductName.Name = "gcProductName";
            this.gcProductName.Visible = true;
            this.gcProductName.VisibleIndex = 0;
            // 
            // gcProductCode
            // 
            this.gcProductCode.Caption = "产品代码";
            this.gcProductCode.ColumnEdit = this.riglueProductCode;
            this.gcProductCode.FieldName = "ProductId";
            this.gcProductCode.Name = "gcProductCode";
            this.gcProductCode.Visible = true;
            this.gcProductCode.VisibleIndex = 1;
            // 
            // gcName
            // 
            this.gcName.Caption = "工序名称";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 2;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "代码";
            this.gcCode.FieldName = "Code";
            this.gcCode.Name = "gcCode";
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(30, 14);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(0, 23);
            this.labelControl3.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(38, 39);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(102, 19);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "生产执行系统";
            // 
            // FormLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 312);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.glueProcess);
            this.Controls.Add(this.tePassword);
            this.Controls.Add(this.teLoginName);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblErrorMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.Load += new System.EventHandler(this.FormLogon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teLoginName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riglueProductName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riglueProductCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblErrorMessage;
        private DevExpress.XtraEditors.SimpleButton btnDone;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblProcess;
        private DevExpress.XtraEditors.TextEdit teLoginName;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraEditors.GridLookUpEdit glueProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit riglueProductName;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit riglueProductCode;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit2View;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}