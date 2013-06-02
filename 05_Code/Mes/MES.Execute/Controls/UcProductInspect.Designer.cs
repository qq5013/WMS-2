namespace MES.Execute.Controls
{
    partial class UcProductInspect
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView1;
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.teTraceCode = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnFinish = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintResult = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.teCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.teSpecModel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.teMachineNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.teUseWay = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.teStandard = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTraceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSpecModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMachineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUseWay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStandard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridView1.Appearance.Empty.Options.UseFont = true;
            gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridView1.Appearance.FocusedRow.Options.UseFont = true;
            gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridView1.Appearance.GroupPanel.Options.UseFont = true;
            gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridView1.Appearance.GroupRow.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn1,
            this.gridColumn10,
            this.gridColumn2,
            this.gridColumn7,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn11});
            gridView1.GridControl = this.gridControl1;
            gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "状态";
            this.gridColumn1.FieldName = "Status";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "产线";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "维修原因";
            this.gridColumn3.FieldName = "Content";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "班次";
            this.gridColumn7.FieldName = "Remark";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "修理件编号";
            this.gridColumn4.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn4.FieldName = "Data";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 8;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "维修方法";
            this.gridColumn5.FieldName = "NormalData";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "替换件编号";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "Result";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 9;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "管理条码";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "机种代码";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "磁控管编号";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 256);
            this.gridControl1.MainView = gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1235, 180);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            gridView1,
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(39, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 20);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "管理条码";
            // 
            // teTraceCode
            // 
            this.teTraceCode.Location = new System.Drawing.Point(138, 35);
            this.teTraceCode.Name = "teTraceCode";
            this.teTraceCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teTraceCode.Properties.Appearance.Options.UseFont = true;
            this.teTraceCode.Size = new System.Drawing.Size(138, 26);
            this.teTraceCode.TabIndex = 0;
            this.teTraceCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TeTraceCodeKeyPress);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnPrintResult,
            this.btnFinish});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFinish),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrintResult)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "保存";
            this.btnSave.Glyph = global::MES.Execute.Properties.Resources.save_16;
            this.btnSave.Id = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSaveItemClick);
            // 
            // btnFinish
            // 
            this.btnFinish.Caption = "关闭";
            this.btnFinish.Id = 3;
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnFinishItemClick);
            // 
            // btnPrintResult
            // 
            this.btnPrintResult.Caption = "打印调试结果单";
            this.btnPrintResult.Id = 2;
            this.btnPrintResult.Name = "btnPrintResult";
            this.btnPrintResult.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnPrintResultItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1235, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 439);
            this.barDockControlBottom.Size = new System.Drawing.Size(1235, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 413);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1235, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 413);
            // 
            // teCode
            // 
            this.teCode.Location = new System.Drawing.Point(391, 35);
            this.teCode.Name = "teCode";
            this.teCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teCode.Properties.Appearance.Options.UseFont = true;
            this.teCode.Size = new System.Drawing.Size(138, 26);
            this.teCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(292, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 20);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "调试单号";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(39, 117);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(80, 20);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "修理件编号";
            // 
            // teSpecModel
            // 
            this.teSpecModel.Location = new System.Drawing.Point(138, 114);
            this.teSpecModel.Name = "teSpecModel";
            this.teSpecModel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teSpecModel.Properties.Appearance.Options.UseFont = true;
            this.teSpecModel.Size = new System.Drawing.Size(138, 26);
            this.teSpecModel.TabIndex = 12;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(292, 121);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(80, 19);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "替换件编号";
            // 
            // teMachineNo
            // 
            this.teMachineNo.Location = new System.Drawing.Point(391, 117);
            this.teMachineNo.Name = "teMachineNo";
            this.teMachineNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teMachineNo.Properties.Appearance.Options.UseFont = true;
            this.teMachineNo.Size = new System.Drawing.Size(138, 26);
            this.teMachineNo.TabIndex = 6;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Location = new System.Drawing.Point(39, 77);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(64, 19);
            this.labelControl9.TabIndex = 7;
            this.labelControl9.Text = "维修原因";
            // 
            // teUseWay
            // 
            this.teUseWay.Location = new System.Drawing.Point(138, 73);
            this.teUseWay.Name = "teUseWay";
            this.teUseWay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teUseWay.Properties.Appearance.Options.UseFont = true;
            this.teUseWay.Size = new System.Drawing.Size(138, 26);
            this.teUseWay.TabIndex = 7;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Location = new System.Drawing.Point(292, 77);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(64, 20);
            this.labelControl10.TabIndex = 7;
            this.labelControl10.Text = "修理方法";
            // 
            // teStandard
            // 
            this.teStandard.Location = new System.Drawing.Point(391, 74);
            this.teStandard.Name = "teStandard";
            this.teStandard.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teStandard.Properties.Appearance.Options.UseFont = true;
            this.teStandard.Size = new System.Drawing.Size(138, 26);
            this.teStandard.TabIndex = 11;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Location = new System.Drawing.Point(39, 172);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(32, 20);
            this.labelControl16.TabIndex = 7;
            this.labelControl16.Text = "备注";
            // 
            // meRemark
            // 
            this.meRemark.Location = new System.Drawing.Point(138, 163);
            this.meRemark.MenuManager = this.barManager1;
            this.meRemark.Name = "meRemark";
            this.meRemark.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meRemark.Properties.Appearance.Options.UseFont = true;
            this.meRemark.Size = new System.Drawing.Size(392, 76);
            this.meRemark.TabIndex = 14;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "备注";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // UcProductInspect
            // 
            this.Controls.Add(this.meRemark);
            this.Controls.Add(this.teStandard);
            this.Controls.Add(this.teUseWay);
            this.Controls.Add(this.teMachineNo);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.teSpecModel);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.teCode);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.teTraceCode);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcProductInspect";
            this.Size = new System.Drawing.Size(1235, 439);
            this.Load += new System.EventHandler(this.UcInspect_Load);
            ((System.ComponentModel.ISupportInitialize)(gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTraceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSpecModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMachineNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUseWay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStandard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit teTraceCode;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.TextEdit teStandard;
        private DevExpress.XtraEditors.TextEdit teUseWay;
        private DevExpress.XtraEditors.TextEdit teMachineNo;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit teSpecModel;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit teCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraBars.BarButtonItem btnPrintResult;
        private DevExpress.XtraBars.BarButtonItem btnFinish;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}
