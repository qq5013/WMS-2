﻿namespace Modules.InboundPlanModule.Views
{
    partial class PrintSkuLabelForm
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.gcInboundPlan = new DevExpress.XtraEditors.GroupControl();
            this.layoutPanelInboundPlan = new System.Windows.Forms.TableLayoutPanel();
            this.txtBatchNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblPlanInformation = new System.Windows.Forms.Label();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.lblPlanNumber = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblSkuNumber = new System.Windows.Forms.Label();
            this.memPlanInformation = new DevExpress.XtraEditors.MemoEdit();
            this.beInboundPlan = new DevExpress.XtraEditors.ButtonEdit();
            this.lblSkuInformation = new System.Windows.Forms.Label();
            this.memSkuInformation = new DevExpress.XtraEditors.MemoEdit();
            this.seQty = new DevExpress.XtraEditors.SpinEdit();
            this.leSku = new DevExpress.XtraEditors.LookUpEdit();
            this.gcLabel = new DevExpress.XtraEditors.GroupControl();
            this.imgSlider = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.layoutImageButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnNextImage = new DevExpress.XtraEditors.SimpleButton();
            this.btnPriorImage = new DevExpress.XtraEditors.SimpleButton();
            this.lblImages = new System.Windows.Forms.Label();
            this.lblSkuPicture = new System.Windows.Forms.Label();
            this.layoutBarcode = new System.Windows.Forms.TableLayoutPanel();
            this.txtSNTo = new DevExpress.XtraEditors.TextEdit();
            this.chkIsPieceManagement = new DevExpress.XtraEditors.CheckEdit();
            this.txtSNFrom = new DevExpress.XtraEditors.TextEdit();
            this.lblEndSN = new System.Windows.Forms.Label();
            this.lblStartSN = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInboundPlan)).BeginInit();
            this.gcInboundPlan.SuspendLayout();
            this.layoutPanelInboundPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPlanInformation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beInboundPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSkuInformation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSku.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLabel)).BeginInit();
            this.gcLabel.SuspendLayout();
            this.layoutImageButton.SuspendLayout();
            this.layoutBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSNTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPieceManagement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSNFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2});
            this.barManager1.MaxItemId = 2;
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "Office2003";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 24);
            this.barDockControlTop.Size = new System.Drawing.Size(784, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 561);
            this.barDockControlBottom.Size = new System.Drawing.Size(784, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 537);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(784, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 537);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "打印";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "关闭";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager2.Controller = this.barAndDockingController1;
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPrint,
            this.btnClose});
            this.barManager2.MainMenu = this.bar2;
            this.barManager2.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "打印标签";
            this.btnPrint.Glyph = global::Wms.Inbound.Properties.Resources.Print;
            this.btnPrint.Id = 0;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnClose.Caption = "退出";
            this.btnClose.Glyph = global::Wms.Inbound.Properties.Resources.Close;
            this.btnClose.Id = 1;
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(784, 24);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 561);
            this.barDockControl2.Size = new System.Drawing.Size(784, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 24);
            this.barDockControl3.Size = new System.Drawing.Size(0, 537);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(784, 24);
            this.barDockControl4.Size = new System.Drawing.Size(0, 537);
            // 
            // gcInboundPlan
            // 
            this.gcInboundPlan.Controls.Add(this.layoutPanelInboundPlan);
            this.gcInboundPlan.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcInboundPlan.Location = new System.Drawing.Point(0, 24);
            this.gcInboundPlan.Margin = new System.Windows.Forms.Padding(0);
            this.gcInboundPlan.Name = "gcInboundPlan";
            this.gcInboundPlan.Padding = new System.Windows.Forms.Padding(10);
            this.gcInboundPlan.Size = new System.Drawing.Size(784, 174);
            this.gcInboundPlan.TabIndex = 17;
            this.gcInboundPlan.Text = "入库计划信息";
            // 
            // layoutPanelInboundPlan
            // 
            this.layoutPanelInboundPlan.ColumnCount = 6;
            this.layoutPanelInboundPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutPanelInboundPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutPanelInboundPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutPanelInboundPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutPanelInboundPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layoutPanelInboundPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutPanelInboundPlan.Controls.Add(this.txtBatchNumber, 5, 2);
            this.layoutPanelInboundPlan.Controls.Add(this.lblPlanInformation, 0, 1);
            this.layoutPanelInboundPlan.Controls.Add(this.lblBatchNumber, 4, 2);
            this.layoutPanelInboundPlan.Controls.Add(this.lblPlanNumber, 0, 0);
            this.layoutPanelInboundPlan.Controls.Add(this.lblQty, 4, 0);
            this.layoutPanelInboundPlan.Controls.Add(this.lblSkuNumber, 2, 0);
            this.layoutPanelInboundPlan.Controls.Add(this.memPlanInformation, 1, 1);
            this.layoutPanelInboundPlan.Controls.Add(this.beInboundPlan, 1, 0);
            this.layoutPanelInboundPlan.Controls.Add(this.lblSkuInformation, 0, 2);
            this.layoutPanelInboundPlan.Controls.Add(this.memSkuInformation, 1, 2);
            this.layoutPanelInboundPlan.Controls.Add(this.seQty, 5, 0);
            this.layoutPanelInboundPlan.Controls.Add(this.leSku, 3, 0);
            this.layoutPanelInboundPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanelInboundPlan.Location = new System.Drawing.Point(12, 31);
            this.layoutPanelInboundPlan.Name = "layoutPanelInboundPlan";
            this.layoutPanelInboundPlan.RowCount = 4;
            this.layoutPanelInboundPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutPanelInboundPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.layoutPanelInboundPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.layoutPanelInboundPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelInboundPlan.Size = new System.Drawing.Size(760, 131);
            this.layoutPanelInboundPlan.TabIndex = 1;
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Enabled = false;
            this.txtBatchNumber.Location = new System.Drawing.Point(611, 83);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Properties.MaxLength = 20;
            this.txtBatchNumber.Size = new System.Drawing.Size(146, 20);
            this.txtBatchNumber.TabIndex = 3;
            // 
            // lblPlanInformation
            // 
            this.lblPlanInformation.Location = new System.Drawing.Point(3, 30);
            this.lblPlanInformation.Name = "lblPlanInformation";
            this.lblPlanInformation.Size = new System.Drawing.Size(108, 25);
            this.lblPlanInformation.TabIndex = 5;
            this.lblPlanInformation.Text = "入库计划备注：";
            this.lblPlanInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.Location = new System.Drawing.Point(535, 80);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(70, 25);
            this.lblBatchNumber.TabIndex = 3;
            this.lblBatchNumber.Text = "批号：";
            this.lblBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlanNumber
            // 
            this.lblPlanNumber.Location = new System.Drawing.Point(3, 0);
            this.lblPlanNumber.Name = "lblPlanNumber";
            this.lblPlanNumber.Size = new System.Drawing.Size(108, 25);
            this.lblPlanNumber.TabIndex = 0;
            this.lblPlanNumber.Text = "入库计划号：";
            this.lblPlanNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(535, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(70, 25);
            this.lblQty.TabIndex = 1;
            this.lblQty.Text = "数量：";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSkuNumber
            // 
            this.lblSkuNumber.Location = new System.Drawing.Point(269, 0);
            this.lblSkuNumber.Name = "lblSkuNumber";
            this.lblSkuNumber.Size = new System.Drawing.Size(108, 25);
            this.lblSkuNumber.TabIndex = 2;
            this.lblSkuNumber.Text = "货物代码：";
            this.lblSkuNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memPlanInformation
            // 
            this.layoutPanelInboundPlan.SetColumnSpan(this.memPlanInformation, 5);
            this.memPlanInformation.Location = new System.Drawing.Point(117, 33);
            this.memPlanInformation.Name = "memPlanInformation";
            this.memPlanInformation.Properties.LookAndFeel.SkinName = "Lilian";
            this.memPlanInformation.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.memPlanInformation.Properties.ReadOnly = true;
            this.memPlanInformation.Size = new System.Drawing.Size(640, 44);
            this.memPlanInformation.TabIndex = 3;
            // 
            // beInboundPlan
            // 
            this.beInboundPlan.Location = new System.Drawing.Point(117, 3);
            this.beInboundPlan.Name = "beInboundPlan";
            this.beInboundPlan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beInboundPlan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beInboundPlan.Size = new System.Drawing.Size(146, 20);
            this.beInboundPlan.TabIndex = 0;
            this.beInboundPlan.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beInboundPlan_ButtonClick);
            // 
            // lblSkuInformation
            // 
            this.lblSkuInformation.Location = new System.Drawing.Point(3, 80);
            this.lblSkuInformation.Name = "lblSkuInformation";
            this.lblSkuInformation.Size = new System.Drawing.Size(108, 25);
            this.lblSkuInformation.TabIndex = 4;
            this.lblSkuInformation.Text = "货物描述：";
            this.lblSkuInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memSkuInformation
            // 
            this.layoutPanelInboundPlan.SetColumnSpan(this.memSkuInformation, 3);
            this.memSkuInformation.Location = new System.Drawing.Point(117, 83);
            this.memSkuInformation.Name = "memSkuInformation";
            this.memSkuInformation.Properties.LookAndFeel.SkinName = "Lilian";
            this.memSkuInformation.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.memSkuInformation.Properties.ReadOnly = true;
            this.memSkuInformation.Size = new System.Drawing.Size(412, 44);
            this.memSkuInformation.TabIndex = 6;
            // 
            // seQty
            // 
            this.seQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seQty.Location = new System.Drawing.Point(611, 3);
            this.seQty.Name = "seQty";
            this.seQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seQty.Properties.IsFloatValue = false;
            this.seQty.Properties.Mask.BeepOnError = true;
            this.seQty.Properties.Mask.EditMask = "N00";
            this.seQty.Properties.MaxValue = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.seQty.Size = new System.Drawing.Size(146, 20);
            this.seQty.TabIndex = 137;
            // 
            // leSku
            // 
            this.leSku.Location = new System.Drawing.Point(383, 3);
            this.leSku.Name = "leSku";
            this.leSku.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leSku.Properties.NullText = "";
            this.leSku.Size = new System.Drawing.Size(146, 20);
            this.leSku.TabIndex = 138;
            this.leSku.EditValueChanged += new System.EventHandler(this.leSku_EditValueChanged);
            // 
            // gcLabel
            // 
            this.gcLabel.Controls.Add(this.imgSlider);
            this.gcLabel.Controls.Add(this.layoutImageButton);
            this.gcLabel.Controls.Add(this.lblSkuPicture);
            this.gcLabel.Controls.Add(this.layoutBarcode);
            this.gcLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLabel.Location = new System.Drawing.Point(0, 198);
            this.gcLabel.Name = "gcLabel";
            this.gcLabel.Padding = new System.Windows.Forms.Padding(10);
            this.gcLabel.Size = new System.Drawing.Size(784, 363);
            this.gcLabel.TabIndex = 18;
            this.gcLabel.Text = "条码标签";
            // 
            // imgSlider
            // 
            this.imgSlider.Enabled = false;
            this.imgSlider.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imgSlider.Location = new System.Drawing.Point(275, 59);
            this.imgSlider.Name = "imgSlider";
            this.imgSlider.Size = new System.Drawing.Size(487, 255);
            this.imgSlider.TabIndex = 7;
            // 
            // layoutImageButton
            // 
            this.layoutImageButton.ColumnCount = 6;
            this.layoutImageButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutImageButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.layoutImageButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layoutImageButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.layoutImageButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutImageButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutImageButton.Controls.Add(this.btnNextImage, 3, 0);
            this.layoutImageButton.Controls.Add(this.btnPriorImage, 1, 0);
            this.layoutImageButton.Controls.Add(this.lblImages, 2, 0);
            this.layoutImageButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutImageButton.Location = new System.Drawing.Point(266, 320);
            this.layoutImageButton.Name = "layoutImageButton";
            this.layoutImageButton.RowCount = 1;
            this.layoutImageButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutImageButton.Size = new System.Drawing.Size(506, 31);
            this.layoutImageButton.TabIndex = 6;
            // 
            // btnNextImage
            // 
            this.btnNextImage.Location = new System.Drawing.Point(280, 3);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(19, 23);
            this.btnNextImage.TabIndex = 0;
            this.btnNextImage.Text = ">";
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // btnPriorImage
            // 
            this.btnPriorImage.Location = new System.Drawing.Point(205, 3);
            this.btnPriorImage.Name = "btnPriorImage";
            this.btnPriorImage.Size = new System.Drawing.Size(19, 23);
            this.btnPriorImage.TabIndex = 1;
            this.btnPriorImage.Text = "<";
            this.btnPriorImage.Click += new System.EventHandler(this.btnPriorImage_Click);
            // 
            // lblImages
            // 
            this.lblImages.AutoSize = true;
            this.lblImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImages.Location = new System.Drawing.Point(230, 0);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(44, 31);
            this.lblImages.TabIndex = 2;
            this.lblImages.Text = "1/3";
            this.lblImages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSkuPicture
            // 
            this.lblSkuPicture.Location = new System.Drawing.Point(272, 31);
            this.lblSkuPicture.Name = "lblSkuPicture";
            this.lblSkuPicture.Size = new System.Drawing.Size(110, 25);
            this.lblSkuPicture.TabIndex = 5;
            this.lblSkuPicture.Text = "货物图片：";
            this.lblSkuPicture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layoutBarcode
            // 
            this.layoutBarcode.ColumnCount = 2;
            this.layoutBarcode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutBarcode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layoutBarcode.Controls.Add(this.txtSNTo, 1, 2);
            this.layoutBarcode.Controls.Add(this.chkIsPieceManagement, 0, 0);
            this.layoutBarcode.Controls.Add(this.txtSNFrom, 1, 1);
            this.layoutBarcode.Controls.Add(this.lblEndSN, 0, 2);
            this.layoutBarcode.Controls.Add(this.lblStartSN, 0, 1);
            this.layoutBarcode.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutBarcode.Location = new System.Drawing.Point(12, 31);
            this.layoutBarcode.Name = "layoutBarcode";
            this.layoutBarcode.RowCount = 5;
            this.layoutBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutBarcode.Size = new System.Drawing.Size(254, 320);
            this.layoutBarcode.TabIndex = 4;
            // 
            // txtSNTo
            // 
            this.txtSNTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSNTo.Enabled = false;
            this.txtSNTo.Location = new System.Drawing.Point(104, 59);
            this.txtSNTo.Name = "txtSNTo";
            this.txtSNTo.Properties.ReadOnly = true;
            this.txtSNTo.Size = new System.Drawing.Size(147, 20);
            this.txtSNTo.TabIndex = 2;
            // 
            // chkIsPieceManagement
            // 
            this.layoutBarcode.SetColumnSpan(this.chkIsPieceManagement, 2);
            this.chkIsPieceManagement.Enabled = false;
            this.chkIsPieceManagement.Location = new System.Drawing.Point(3, 3);
            this.chkIsPieceManagement.Name = "chkIsPieceManagement";
            this.chkIsPieceManagement.Properties.Caption = "单品管理货物";
            this.chkIsPieceManagement.Size = new System.Drawing.Size(248, 19);
            this.chkIsPieceManagement.TabIndex = 0;
            // 
            // txtSNFrom
            // 
            this.txtSNFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSNFrom.Enabled = false;
            this.txtSNFrom.Location = new System.Drawing.Point(104, 31);
            this.txtSNFrom.Name = "txtSNFrom";
            this.txtSNFrom.Properties.ReadOnly = true;
            this.txtSNFrom.Size = new System.Drawing.Size(147, 20);
            this.txtSNFrom.TabIndex = 1;
            // 
            // lblEndSN
            // 
            this.lblEndSN.Location = new System.Drawing.Point(3, 56);
            this.lblEndSN.Name = "lblEndSN";
            this.lblEndSN.Size = new System.Drawing.Size(95, 25);
            this.lblEndSN.TabIndex = 2;
            this.lblEndSN.Text = "终止序列号：";
            this.lblEndSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartSN
            // 
            this.lblStartSN.Location = new System.Drawing.Point(3, 28);
            this.lblStartSN.Name = "lblStartSN";
            this.lblStartSN.Size = new System.Drawing.Size(95, 25);
            this.lblStartSN.TabIndex = 1;
            this.lblStartSN.Text = "起始序列号：";
            this.lblStartSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PrintSkuLabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.gcLabel);
            this.Controls.Add(this.gcInboundPlan);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintSkuLabelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快捷打印条码标签";
            this.Load += new System.EventHandler(this.PrintPlanItemBarCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInboundPlan)).EndInit();
            this.gcInboundPlan.ResumeLayout(false);
            this.layoutPanelInboundPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPlanInformation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beInboundPlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSkuInformation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSku.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLabel)).EndInit();
            this.gcLabel.ResumeLayout(false);
            this.layoutImageButton.ResumeLayout(false);
            this.layoutImageButton.PerformLayout();
            this.layoutBarcode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSNTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPieceManagement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSNFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraEditors.GroupControl gcInboundPlan;
        private System.Windows.Forms.TableLayoutPanel layoutPanelInboundPlan;
        private System.Windows.Forms.Label lblSkuInformation;
        private System.Windows.Forms.Label lblPlanNumber;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblSkuNumber;
        private DevExpress.XtraEditors.MemoEdit memPlanInformation;
        private DevExpress.XtraEditors.ButtonEdit beInboundPlan;
        private System.Windows.Forms.Label lblPlanInformation;
        private DevExpress.XtraEditors.MemoEdit memSkuInformation;
        private DevExpress.XtraEditors.GroupControl gcLabel;
        private System.Windows.Forms.Label lblSkuPicture;
        private System.Windows.Forms.TableLayoutPanel layoutBarcode;
        private DevExpress.XtraEditors.TextEdit txtBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private DevExpress.XtraEditors.TextEdit txtSNTo;
        private DevExpress.XtraEditors.CheckEdit chkIsPieceManagement;
        private DevExpress.XtraEditors.TextEdit txtSNFrom;
        private System.Windows.Forms.Label lblEndSN;
        private System.Windows.Forms.Label lblStartSN;
        private DevExpress.XtraEditors.SpinEdit seQty;
        private DevExpress.XtraEditors.LookUpEdit leSku;
        private System.Windows.Forms.TableLayoutPanel layoutImageButton;
        private DevExpress.XtraEditors.SimpleButton btnNextImage;
        private DevExpress.XtraEditors.SimpleButton btnPriorImage;
        private System.Windows.Forms.Label lblImages;
        private DevExpress.XtraEditors.Controls.ImageSlider imgSlider;
    }
}