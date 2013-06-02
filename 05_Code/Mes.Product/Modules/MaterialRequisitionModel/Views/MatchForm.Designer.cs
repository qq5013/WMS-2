namespace Modules.InboundBillModule.Views
{
    partial class MatchForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gSO = new DevExpress.XtraEditors.GroupControl();
            this.MainGrid = new DevExpress.XtraGrid.GridControl();
            this.MainGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.StyleController = new DevExpress.XtraEditors.StyleController(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gSO)).BeginInit();
            this.gSO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StyleController)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupControl1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.groupControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.groupControl1.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.groupControl1.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.groupControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.groupControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.groupControl1.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.groupControl1.AppearanceCaption.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.groupControl1.AppearanceCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.groupControl1.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.groupControl1.AppearanceCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.groupControl1.CaptionImageLocation = DevExpress.Utils.GroupElementLocation.Default;
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Default;
            this.groupControl1.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Controls.Add(this.btnConfirm);
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnCancel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.btnCancel.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.btnCancel.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.btnCancel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.btnCancel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.Default;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.StyleController = this.StyleController;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnConfirm.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.btnConfirm.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.btnConfirm.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.btnConfirm.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.btnConfirm.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.btnConfirm.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConfirm.ImageLocation = DevExpress.XtraEditors.ImageLocation.Default;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.StyleController = this.StyleController;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gSO);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // gSO
            // 
            this.gSO.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gSO.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gSO.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gSO.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gSO.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gSO.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gSO.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gSO.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.gSO.AppearanceCaption.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.gSO.AppearanceCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.gSO.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.gSO.AppearanceCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.gSO.CaptionImageLocation = DevExpress.Utils.GroupElementLocation.Default;
            this.gSO.CaptionLocation = DevExpress.Utils.Locations.Default;
            this.gSO.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gSO.Controls.Add(this.MainGrid);
            resources.ApplyResources(this.gSO, "gSO");
            this.gSO.LookAndFeel.SkinName = "Lilian";
            this.gSO.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.gSO.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gSO.Name = "gSO";
            // 
            // MainGrid
            // 
            this.MainGrid.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.Default;
            resources.ApplyResources(this.MainGrid, "MainGrid");
            this.MainGrid.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("MainGrid.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.MainGrid.EmbeddedNavigator.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGrid.EmbeddedNavigator.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGrid.EmbeddedNavigator.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGrid.EmbeddedNavigator.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGrid.EmbeddedNavigator.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGrid.EmbeddedNavigator.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.MainGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.MainGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.MainGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.MainGrid.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.MainGrid.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.MainGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.MainGrid.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.MainGrid.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("MainGrid.EmbeddedNavigator.TextLocation")));
            this.MainGrid.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("MainGrid.EmbeddedNavigator.ToolTipIconType")));
            this.MainGrid.LookAndFeel.SkinName = "Lilian";
            this.MainGrid.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.MainGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MainGrid.MainView = this.MainGridView;
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.MainGrid.UseEmbeddedNavigator = true;
            this.MainGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MainGridView});
            // 
            // MainGridView
            // 
            this.MainGridView.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(146)))));
            this.MainGridView.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.MainGridView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.MainGridView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.MainGridView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.MainGridView.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.ColumnFilterButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.ColumnFilterButton.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.ColumnFilterButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.ColumnFilterButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(244)))));
            this.MainGridView.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(222)))), ((int)(((byte)(183)))));
            this.MainGridView.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(244)))));
            this.MainGridView.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.MainGridView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.MainGridView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.MainGridView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.MainGridView.Appearance.ColumnFilterButtonActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.ColumnFilterButtonActive.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.ColumnFilterButtonActive.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.ColumnFilterButtonActive.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.ColumnFilterButtonActive.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.CustomizationFormHint.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.CustomizationFormHint.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.CustomizationFormHint.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.CustomizationFormHint.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.CustomizationFormHint.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.CustomizationFormHint.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.DetailTip.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.DetailTip.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.DetailTip.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.DetailTip.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.DetailTip.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.DetailTip.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.MainGridView.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.Empty.Options.UseBackColor = true;
            this.MainGridView.Appearance.Empty.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.Empty.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.Empty.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.Empty.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.Empty.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.MainGridView.Appearance.EvenRow.Options.UseForeColor = true;
            this.MainGridView.Appearance.EvenRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.EvenRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.EvenRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.EvenRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.EvenRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(146)))));
            this.MainGridView.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.MainGridView.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.MainGridView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.MainGridView.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.MainGridView.Appearance.FilterCloseButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.FilterCloseButton.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.FilterCloseButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.FilterCloseButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(126)))));
            this.MainGridView.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.MainGridView.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.FilterPanel.Options.UseBackColor = true;
            this.MainGridView.Appearance.FilterPanel.Options.UseForeColor = true;
            this.MainGridView.Appearance.FilterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.FilterPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.FilterPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.FilterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.FilterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(128)))), ((int)(((byte)(88)))));
            this.MainGridView.Appearance.FixedLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.FixedLine.Options.UseBackColor = true;
            this.MainGridView.Appearance.FixedLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.FixedLine.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.FixedLine.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.FixedLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.FixedLine.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.MainGridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.MainGridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.MainGridView.Appearance.FocusedCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.FocusedCell.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.FocusedCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.FocusedCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.FocusedCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(160)))), ((int)(((byte)(112)))));
            this.MainGridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.MainGridView.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.MainGridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.MainGridView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.FocusedRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.FocusedRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.FocusedRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(146)))));
            this.MainGridView.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.MainGridView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.MainGridView.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.MainGridView.Appearance.FooterPanel.Options.UseForeColor = true;
            this.MainGridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.FooterPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.FooterPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.FooterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.MainGridView.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.MainGridView.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.GroupButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.GroupButton.Options.UseBackColor = true;
            this.MainGridView.Appearance.GroupButton.Options.UseBorderColor = true;
            this.MainGridView.Appearance.GroupButton.Options.UseForeColor = true;
            this.MainGridView.Appearance.GroupButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.GroupButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.GroupButton.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.GroupButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.GroupButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.MainGridView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.MainGridView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.MainGridView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.GroupFooter.Options.UseBackColor = true;
            this.MainGridView.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.MainGridView.Appearance.GroupFooter.Options.UseFont = true;
            this.MainGridView.Appearance.GroupFooter.Options.UseForeColor = true;
            this.MainGridView.Appearance.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.GroupFooter.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.GroupFooter.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.GroupFooter.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.GroupFooter.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(126)))));
            this.MainGridView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.GroupPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.MainGridView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.MainGridView.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.GroupPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.GroupPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.GroupPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.GroupPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.MainGridView.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.MainGridView.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.MainGridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.GroupRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.GroupRow.Options.UseBackColor = true;
            this.MainGridView.Appearance.GroupRow.Options.UseBorderColor = true;
            this.MainGridView.Appearance.GroupRow.Options.UseFont = true;
            this.MainGridView.Appearance.GroupRow.Options.UseForeColor = true;
            this.MainGridView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.GroupRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.GroupRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.GroupRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.GroupRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(146)))));
            this.MainGridView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            this.MainGridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.MainGridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.MainGridView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.MainGridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.MainGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.HeaderPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(207)))), ((int)(((byte)(170)))));
            this.MainGridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(160)))), ((int)(((byte)(112)))));
            this.MainGridView.Appearance.HideSelectionRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.MainGridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.MainGridView.Appearance.HideSelectionRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.HideSelectionRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.HideSelectionRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.HideSelectionRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.HideSelectionRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(168)))), ((int)(((byte)(128)))));
            this.MainGridView.Appearance.HorzLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.HorzLine.Options.UseBackColor = true;
            this.MainGridView.Appearance.HorzLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.HorzLine.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.HorzLine.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.HorzLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.HorzLine.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.OddRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.OddRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.OddRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.OddRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.OddRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(247)))));
            this.MainGridView.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(160)))), ((int)(((byte)(112)))));
            this.MainGridView.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.Preview.Options.UseBackColor = true;
            this.MainGridView.Appearance.Preview.Options.UseForeColor = true;
            this.MainGridView.Appearance.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.Preview.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.Preview.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.Preview.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.Preview.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.MainGridView.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.MainGridView.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.Row.Options.UseBackColor = true;
            this.MainGridView.Appearance.Row.Options.UseForeColor = true;
            this.MainGridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.Row.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.MainGridView.Appearance.RowSeparator.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.RowSeparator.Options.UseBackColor = true;
            this.MainGridView.Appearance.RowSeparator.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.RowSeparator.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.RowSeparator.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.RowSeparator.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.RowSeparator.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(133)))));
            this.MainGridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.MainGridView.Appearance.SelectedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.MainGridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.MainGridView.Appearance.SelectedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.SelectedRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.SelectedRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.SelectedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.SelectedRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.MainGridView.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.MainGridView.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.TopNewRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.TopNewRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.TopNewRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.TopNewRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(160)))), ((int)(((byte)(188)))));
            this.MainGridView.Appearance.VertLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.VertLine.Options.UseBackColor = true;
            this.MainGridView.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.VertLine.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.VertLine.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.VertLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.VertLine.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.Appearance.ViewCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.Appearance.ViewCaption.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.Appearance.ViewCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.EvenRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.EvenRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.EvenRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.EvenRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.EvenRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.FilterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.FilterPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.FilterPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.FilterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.FilterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.FooterPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.FooterPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.FooterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.GroupFooter.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.GroupFooter.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.GroupFooter.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.GroupFooter.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.GroupRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.GroupRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.GroupRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.GroupRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.GroupRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.HeaderPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.Lines.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.Lines.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.Lines.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.Lines.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.Lines.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.Lines.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.OddRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.OddRow.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.OddRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.OddRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.OddRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.Preview.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.Preview.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.Preview.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.Preview.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.AppearancePrint.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.MainGridView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.MainGridView.AppearancePrint.Row.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.MainGridView.AppearancePrint.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.MainGridView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.MainGridView.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.MainGridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.MainGridView.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Top;
            this.MainGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            this.MainGridView.GridControl = this.MainGrid;
            this.MainGridView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded;
            this.MainGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.MainGridView.Name = "MainGridView";
            this.MainGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.Default;
            this.MainGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.Default;
            this.MainGridView.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.CacheAll;
            this.MainGridView.OptionsBehavior.Editable = false;
            this.MainGridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Default;
            this.MainGridView.OptionsCustomization.AllowFilter = false;
            this.MainGridView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.Default;
            this.MainGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            this.MainGridView.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.Default;
            this.MainGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.MainGridView.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Default;
            this.MainGridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Default;
            this.MainGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.MainGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;
            this.MainGridView.OptionsView.ShowGroupPanel = false;
            this.MainGridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedCell;
            this.MainGridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AccessibleRole = System.Windows.Forms.AccessibleRole.Default;
            this.repositoryItemLookUpEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.Default;
            this.repositoryItemLookUpEdit1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.repositoryItemLookUpEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.repositoryItemLookUpEdit1.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.repositoryItemLookUpEdit1.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.repositoryItemLookUpEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.repositoryItemLookUpEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.repositoryItemLookUpEdit1.AppearanceDisabled.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.repositoryItemLookUpEdit1.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceDisabled.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.repositoryItemLookUpEdit1.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.repositoryItemLookUpEdit1.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDownHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.repositoryItemLookUpEdit1.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDownHeader.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDownHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceDropDownHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.repositoryItemLookUpEdit1.AppearanceFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.repositoryItemLookUpEdit1.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceFocused.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.repositoryItemLookUpEdit1.AppearanceFocused.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.repositoryItemLookUpEdit1.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.repositoryItemLookUpEdit1.AppearanceReadOnly.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.repositoryItemLookUpEdit1.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceReadOnly.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.repositoryItemLookUpEdit1.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.repositoryItemLookUpEdit1.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.repositoryItemLookUpEdit1.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            resources.ApplyResources(this.repositoryItemLookUpEdit1, "repositoryItemLookUpEdit1");
            this.repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.None;
            this.repositoryItemLookUpEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            serializableAppearanceObject1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemLookUpEdit1.Buttons"))), resources.GetString("repositoryItemLookUpEdit1.Buttons1"), ((int)(resources.GetObject("repositoryItemLookUpEdit1.Buttons2"))), ((bool)(resources.GetObject("repositoryItemLookUpEdit1.Buttons3"))), ((bool)(resources.GetObject("repositoryItemLookUpEdit1.Buttons4"))), ((bool)(resources.GetObject("repositoryItemLookUpEdit1.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("repositoryItemLookUpEdit1.Buttons6"))), null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("repositoryItemLookUpEdit1.Buttons7"), null, null, ((bool)(resources.GetObject("repositoryItemLookUpEdit1.Buttons8"))))});
            this.repositoryItemLookUpEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.repositoryItemLookUpEdit1.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.repositoryItemLookUpEdit1.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Default;
            this.repositoryItemLookUpEdit1.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.Sorting;
            this.repositoryItemLookUpEdit1.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Default;
            this.repositoryItemLookUpEdit1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.Default;
            this.repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.repositoryItemLookUpEdit1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
            this.repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // StyleController
            // 
            this.StyleController.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.StyleController.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.StyleController.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.StyleController.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.StyleController.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.StyleController.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.StyleController.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.StyleController.AppearanceDisabled.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.StyleController.AppearanceDisabled.Options.UseForeColor = true;
            this.StyleController.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.StyleController.AppearanceDisabled.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.StyleController.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.StyleController.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.StyleController.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.StyleController.AppearanceDropDown.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.StyleController.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.StyleController.AppearanceDropDown.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.StyleController.AppearanceDropDown.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.StyleController.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.StyleController.AppearanceDropDown.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.StyleController.AppearanceDropDownHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.StyleController.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.StyleController.AppearanceDropDownHeader.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.StyleController.AppearanceDropDownHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.StyleController.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.StyleController.AppearanceDropDownHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.StyleController.AppearanceFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.StyleController.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.StyleController.AppearanceFocused.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.StyleController.AppearanceFocused.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.StyleController.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.StyleController.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.StyleController.AppearanceReadOnly.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.StyleController.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.StyleController.AppearanceReadOnly.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.StyleController.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.StyleController.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.StyleController.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.StyleController.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.StyleController.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.StyleController.LookAndFeel.SkinName = "Lilian";
            this.StyleController.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.StyleController.LookAndFeel.UseDefaultLookAndFeel = false;
            this.StyleController.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            // 
            // MatchSOForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MatchForm";
            this.Load += new System.EventHandler(this.MatchForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gSO)).EndInit();
            this.gSO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StyleController)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.GroupControl gSO;
        protected DevExpress.XtraGrid.GridControl MainGrid;
        protected DevExpress.XtraGrid.Views.Grid.GridView MainGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        public DevExpress.XtraEditors.StyleController StyleController;
    }
}