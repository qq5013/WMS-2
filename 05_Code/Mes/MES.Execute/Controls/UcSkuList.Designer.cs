namespace MES.Execute.Controls
{
    partial class UcSkuList
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.glueProduct = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.teCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.teSpec = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.teModel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.teColor = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSpec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teColor.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.btnCancel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            this.barManager1.MdiMenuMergeStyle = DevExpress.XtraBars.BarMdiMenuMergeStyle.Always;
            // 
            // bar2
            // 
            this.bar2.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.bar2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.bar2.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.bar2.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.bar2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.bar2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = ((DevExpress.XtraBars.BarCanDockStyle)((((((DevExpress.XtraBars.BarCanDockStyle.Floating | DevExpress.XtraBars.BarCanDockStyle.Left)
                        | DevExpress.XtraBars.BarCanDockStyle.Top)
                        | DevExpress.XtraBars.BarCanDockStyle.Right)
                        | DevExpress.XtraBars.BarCanDockStyle.Bottom)
                        | DevExpress.XtraBars.BarCanDockStyle.Standalone)));
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.BarState = DevExpress.XtraBars.BarState.Expanded;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnSave
            // 
            this.btnSave.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Default;
            this.btnSave.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.btnSave.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.btnSave.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            this.btnSave.Caption = "保存";
            this.btnSave.Glyph = global::MES.Execute.Properties.Resources.Save;
            this.btnSave.Id = 0;
            this.btnSave.ItemClickFireMode = DevExpress.XtraBars.BarItemEventFireMode.Default;
            this.btnSave.MergeType = DevExpress.XtraBars.BarMenuMerge.Add;
            this.btnSave.Name = "btnSave";
            this.btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSaveItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Default;
            this.btnCancel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.btnCancel.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.btnCancel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            this.btnCancel.Caption = "取消";
            this.btnCancel.Glyph = global::MES.Execute.Properties.Resources.Cancel;
            this.btnCancel.Id = 1;
            this.btnCancel.ItemClickFireMode = DevExpress.XtraBars.BarItemEventFireMode.Default;
            this.btnCancel.MergeType = DevExpress.XtraBars.BarMenuMerge.Add;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnCancelItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.barDockControlTop.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.barDockControlTop.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.barDockControlTop.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.barDockControlTop.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.barDockControlTop.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(245, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.barDockControlBottom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.barDockControlBottom.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.barDockControlBottom.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.barDockControlBottom.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.barDockControlBottom.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 203);
            this.barDockControlBottom.Size = new System.Drawing.Size(245, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.barDockControlLeft.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.barDockControlLeft.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.barDockControlLeft.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.barDockControlLeft.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.barDockControlLeft.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 177);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.barDockControlRight.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.barDockControlRight.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.barDockControlRight.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.barDockControlRight.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.barDockControlRight.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(245, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 177);
            // 
            // glueProduct
            // 
            this.glueProduct.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.glueProduct.Location = new System.Drawing.Point(83, 42);
            this.glueProduct.MenuManager = this.barManager1;
            this.glueProduct.Name = "glueProduct";
            this.glueProduct.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Default;
            this.glueProduct.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.Default;
            this.glueProduct.Properties.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.glueProduct.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.glueProduct.Properties.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.glueProduct.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.glueProduct.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.glueProduct.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.glueProduct.Properties.AppearanceDisabled.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.glueProduct.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.glueProduct.Properties.AppearanceDisabled.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.glueProduct.Properties.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.glueProduct.Properties.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.glueProduct.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.glueProduct.Properties.AppearanceDropDown.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.glueProduct.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.glueProduct.Properties.AppearanceDropDown.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.glueProduct.Properties.AppearanceDropDown.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.glueProduct.Properties.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.glueProduct.Properties.AppearanceDropDown.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.glueProduct.Properties.AppearanceFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.glueProduct.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.glueProduct.Properties.AppearanceFocused.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.glueProduct.Properties.AppearanceFocused.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.glueProduct.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.glueProduct.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.glueProduct.Properties.AppearanceReadOnly.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.glueProduct.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.glueProduct.Properties.AppearanceReadOnly.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.glueProduct.Properties.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.glueProduct.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.glueProduct.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.glueProduct.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.None;
            this.glueProduct.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            serializableAppearanceObject1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            serializableAppearanceObject1.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            serializableAppearanceObject1.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            serializableAppearanceObject1.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            serializableAppearanceObject1.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.glueProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.glueProduct.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.glueProduct.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.glueProduct.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Default;
            this.glueProduct.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.glueProduct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Default;
            this.glueProduct.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.Default;
            this.glueProduct.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
            this.glueProduct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.glueProduct.Properties.View = this.gridLookUpEdit1View;
            this.glueProduct.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.Default;
            this.glueProduct.Size = new System.Drawing.Size(134, 20);
            this.glueProduct.TabIndex = 0;
            this.glueProduct.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButton.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButtonActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButtonActive.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButtonActive.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButtonActive.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButtonActive.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.CustomizationFormHint.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.CustomizationFormHint.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.CustomizationFormHint.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.CustomizationFormHint.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.CustomizationFormHint.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.CustomizationFormHint.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.DetailTip.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.DetailTip.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.DetailTip.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.DetailTip.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.DetailTip.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.DetailTip.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.Empty.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.Empty.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.Empty.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.Empty.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.Empty.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.EvenRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.EvenRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.EvenRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.EvenRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.EvenRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.FilterCloseButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.FilterCloseButton.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.FilterCloseButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FilterCloseButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.FilterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FilterPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.FilterPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.FilterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FilterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.FixedLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.FixedLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FixedLine.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.FixedLine.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.FixedLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FixedLine.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.FocusedCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FocusedCell.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.FocusedCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.FocusedCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FocusedCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FocusedRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.FocusedRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FocusedRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FooterPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.FooterPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.FooterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.GroupButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.GroupButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.GroupButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.GroupButton.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.GroupButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.GroupButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.GroupFooter.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.GroupFooter.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.GroupFooter.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.GroupFooter.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.GroupPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.GroupPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.GroupPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.GroupPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.GroupPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.GroupRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.GroupRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.GroupRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.GroupRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.GroupRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.HeaderPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.HideSelectionRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.HideSelectionRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.HideSelectionRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.HideSelectionRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.HideSelectionRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.HideSelectionRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.HorzLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.HorzLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.HorzLine.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.HorzLine.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.HorzLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.HorzLine.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.OddRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.OddRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.OddRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.OddRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.OddRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.Preview.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.Preview.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.Preview.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.Preview.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.Row.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.RowSeparator.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.RowSeparator.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.RowSeparator.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.RowSeparator.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.RowSeparator.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.RowSeparator.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.SelectedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.SelectedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.SelectedRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.SelectedRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.SelectedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.SelectedRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.TopNewRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.TopNewRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.TopNewRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.TopNewRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.VertLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.VertLine.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.VertLine.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.VertLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.VertLine.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.Appearance.ViewCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.Appearance.ViewCaption.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.Appearance.ViewCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.EvenRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.EvenRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.EvenRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.EvenRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.EvenRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.FilterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.FilterPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.FilterPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.FilterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.FilterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.FooterPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.FooterPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.FooterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupFooter.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupFooter.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupFooter.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupFooter.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.GroupRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.HeaderPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.Lines.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.Lines.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.Lines.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.Lines.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.Lines.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.Lines.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.OddRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.OddRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.OddRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.OddRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.OddRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.Preview.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.Preview.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.Preview.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.Preview.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.AppearancePrint.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gridLookUpEdit1View.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.Row.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gridLookUpEdit1View.AppearancePrint.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gridLookUpEdit1View.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gridLookUpEdit1View.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gridLookUpEdit1View.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.gridLookUpEdit1View.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Top;
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded;
            this.gridLookUpEdit1View.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.Default;
            this.gridLookUpEdit1View.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.Default;
            this.gridLookUpEdit1View.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.CacheAll;
            this.gridLookUpEdit1View.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Default;
            this.gridLookUpEdit1View.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.Default;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            this.gridLookUpEdit1View.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.Default;
            this.gridLookUpEdit1View.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Default;
            this.gridLookUpEdit1View.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Default;
            this.gridLookUpEdit1View.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.gridLookUpEdit1View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedCell;
            this.gridLookUpEdit1View.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.labelControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.labelControl1.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.labelControl1.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.None;
            this.labelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Default;
            this.labelControl1.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Default;
            this.labelControl1.Location = new System.Drawing.Point(15, 45);
            this.labelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "选择物料";
            this.labelControl1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // labelControl2
            // 
            this.labelControl2.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.labelControl2.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelControl2.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.labelControl2.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.labelControl2.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.labelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.None;
            this.labelControl2.LineLocation = DevExpress.XtraEditors.LineLocation.Default;
            this.labelControl2.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Default;
            this.labelControl2.Location = new System.Drawing.Point(15, 71);
            this.labelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "代码";
            this.labelControl2.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // teCode
            // 
            this.teCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.teCode.Location = new System.Drawing.Point(83, 68);
            this.teCode.MenuManager = this.barManager1;
            this.teCode.Name = "teCode";
            this.teCode.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Default;
            this.teCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.Default;
            this.teCode.Properties.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teCode.Properties.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teCode.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teCode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teCode.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teCode.Properties.AppearanceDisabled.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teCode.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teCode.Properties.AppearanceDisabled.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teCode.Properties.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teCode.Properties.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teCode.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teCode.Properties.AppearanceFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teCode.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teCode.Properties.AppearanceFocused.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teCode.Properties.AppearanceFocused.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teCode.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teCode.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teCode.Properties.AppearanceReadOnly.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teCode.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teCode.Properties.AppearanceReadOnly.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teCode.Properties.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teCode.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teCode.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.teCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.teCode.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.teCode.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Default;
            this.teCode.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.teCode.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Default;
            this.teCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.teCode.Properties.MaxLength = 5;
            this.teCode.Size = new System.Drawing.Size(134, 20);
            this.teCode.TabIndex = 1;
            this.teCode.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // labelControl3
            // 
            this.labelControl3.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.labelControl3.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelControl3.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.labelControl3.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.labelControl3.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.labelControl3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.None;
            this.labelControl3.LineLocation = DevExpress.XtraEditors.LineLocation.Default;
            this.labelControl3.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Default;
            this.labelControl3.Location = new System.Drawing.Point(15, 97);
            this.labelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "规格";
            this.labelControl3.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // teSpec
            // 
            this.teSpec.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.teSpec.Location = new System.Drawing.Point(83, 94);
            this.teSpec.Name = "teSpec";
            this.teSpec.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Default;
            this.teSpec.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.Default;
            this.teSpec.Properties.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teSpec.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teSpec.Properties.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teSpec.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teSpec.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teSpec.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teSpec.Properties.AppearanceDisabled.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teSpec.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teSpec.Properties.AppearanceDisabled.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teSpec.Properties.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teSpec.Properties.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teSpec.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teSpec.Properties.AppearanceFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teSpec.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teSpec.Properties.AppearanceFocused.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teSpec.Properties.AppearanceFocused.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teSpec.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teSpec.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teSpec.Properties.AppearanceReadOnly.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teSpec.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teSpec.Properties.AppearanceReadOnly.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teSpec.Properties.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teSpec.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teSpec.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teSpec.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.teSpec.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.teSpec.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.teSpec.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Default;
            this.teSpec.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.teSpec.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Default;
            this.teSpec.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.teSpec.Properties.MaxLength = 50;
            this.teSpec.Size = new System.Drawing.Size(134, 20);
            this.teSpec.TabIndex = 2;
            this.teSpec.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // labelControl4
            // 
            this.labelControl4.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.labelControl4.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelControl4.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.labelControl4.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.labelControl4.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.labelControl4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default;
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.None;
            this.labelControl4.LineLocation = DevExpress.XtraEditors.LineLocation.Default;
            this.labelControl4.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Default;
            this.labelControl4.Location = new System.Drawing.Point(15, 123);
            this.labelControl4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "型号";
            this.labelControl4.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // teModel
            // 
            this.teModel.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.teModel.Location = new System.Drawing.Point(83, 120);
            this.teModel.Name = "teModel";
            this.teModel.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Default;
            this.teModel.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.Default;
            this.teModel.Properties.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teModel.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teModel.Properties.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teModel.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teModel.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teModel.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teModel.Properties.AppearanceDisabled.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teModel.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teModel.Properties.AppearanceDisabled.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teModel.Properties.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teModel.Properties.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teModel.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teModel.Properties.AppearanceFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teModel.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teModel.Properties.AppearanceFocused.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teModel.Properties.AppearanceFocused.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teModel.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teModel.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teModel.Properties.AppearanceReadOnly.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teModel.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teModel.Properties.AppearanceReadOnly.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teModel.Properties.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teModel.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teModel.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teModel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.teModel.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.teModel.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.teModel.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Default;
            this.teModel.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.teModel.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Default;
            this.teModel.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.teModel.Properties.MaxLength = 50;
            this.teModel.Size = new System.Drawing.Size(134, 20);
            this.teModel.TabIndex = 3;
            this.teModel.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // labelControl5
            // 
            this.labelControl5.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.labelControl5.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelControl5.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.labelControl5.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.labelControl5.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.labelControl5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default;
            this.labelControl5.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.None;
            this.labelControl5.LineLocation = DevExpress.XtraEditors.LineLocation.Default;
            this.labelControl5.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Default;
            this.labelControl5.Location = new System.Drawing.Point(15, 149);
            this.labelControl5.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "颜色";
            this.labelControl5.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // teColor
            // 
            this.teColor.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.Default;
            this.teColor.Location = new System.Drawing.Point(83, 146);
            this.teColor.Name = "teColor";
            this.teColor.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Default;
            this.teColor.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.Default;
            this.teColor.Properties.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teColor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teColor.Properties.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teColor.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teColor.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teColor.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teColor.Properties.AppearanceDisabled.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teColor.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teColor.Properties.AppearanceDisabled.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teColor.Properties.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teColor.Properties.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teColor.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teColor.Properties.AppearanceFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teColor.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teColor.Properties.AppearanceFocused.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teColor.Properties.AppearanceFocused.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teColor.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teColor.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teColor.Properties.AppearanceReadOnly.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.teColor.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.teColor.Properties.AppearanceReadOnly.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.teColor.Properties.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.teColor.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.teColor.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.teColor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.teColor.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.teColor.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.teColor.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Default;
            this.teColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.teColor.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Default;
            this.teColor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.teColor.Properties.MaxLength = 50;
            this.teColor.Size = new System.Drawing.Size(134, 20);
            this.teColor.TabIndex = 4;
            this.teColor.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            // 
            // UcSkuList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.teColor);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.teModel);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.teSpec);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.teCode);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.glueProduct);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UcSkuList";
            this.Size = new System.Drawing.Size(245, 203);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSpec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teColor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit glueProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit teColor;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit teModel;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit teSpec;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit teCode;
    }
}
