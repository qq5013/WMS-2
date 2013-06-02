using System.Reflection;
using WCPierce.Practices.CompositeUI.WinForms;

namespace Wms
{
    partial class ShellForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellForm));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.taskGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.notifyGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.helpGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navbarImageListLarge = new System.Windows.Forms.ImageList();
            this.navbarImageList = new System.Windows.Forms.ImageList();
            this.pnlModuleZone = new DevExpress.XtraEditors.PanelControl();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.appMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu();
            this.popupControlContainer2 = new DevExpress.XtraBars.PopupControlContainer();
            this.buttonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.iHelp = new DevExpress.XtraBars.BarButtonItem();
            this.iExit = new DevExpress.XtraBars.BarButtonItem();
            this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer();
            this.someLabelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.someLabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ribbonImageCollection = new DevExpress.Utils.ImageCollection();
            this.iNew = new DevExpress.XtraBars.BarButtonItem();
            this.iOpen = new DevExpress.XtraBars.BarButtonItem();
            this.iClose = new DevExpress.XtraBars.BarButtonItem();
            this.iFind = new DevExpress.XtraBars.BarButtonItem();
            this.iSave = new DevExpress.XtraBars.BarButtonItem();
            this.iSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.iAbout = new DevExpress.XtraBars.BarButtonItem();
            this.sbarServerName = new DevExpress.XtraBars.BarStaticItem();
            this.sbarWarehouse = new DevExpress.XtraBars.BarStaticItem();
            this.alignButtonGroup = new DevExpress.XtraBars.BarButtonGroup();
            this.iBoldFontStyle = new DevExpress.XtraBars.BarButtonItem();
            this.iItalicFontStyle = new DevExpress.XtraBars.BarButtonItem();
            this.iUnderlinedFontStyle = new DevExpress.XtraBars.BarButtonItem();
            this.fontStyleButtonGroup = new DevExpress.XtraBars.BarButtonGroup();
            this.iLeftTextAlign = new DevExpress.XtraBars.BarButtonItem();
            this.iCenterTextAlign = new DevExpress.XtraBars.BarButtonItem();
            this.iRightTextAlign = new DevExpress.XtraBars.BarButtonItem();
            this.rgbiSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.sbarUserName = new DevExpress.XtraBars.BarStaticItem();
            this.iParameter = new DevExpress.XtraBars.BarButtonItem();
            this.iDataDictionary = new DevExpress.XtraBars.BarButtonItem();
            this.iUser = new DevExpress.XtraBars.BarButtonItem();
            this.iFunction = new DevExpress.XtraBars.BarButtonItem();
            this.iGroup = new DevExpress.XtraBars.BarButtonItem();
            this.iRole = new DevExpress.XtraBars.BarButtonItem();
            this.iDistrict = new DevExpress.XtraBars.BarButtonItem();
            this.iCompany = new DevExpress.XtraBars.BarButtonItem();
            this.iCategoryManagement = new DevExpress.XtraBars.BarButtonItem();
            this.iSku = new DevExpress.XtraBars.BarButtonItem();
            this.iWarehouse = new DevExpress.XtraBars.BarButtonItem();
            this.iArea = new DevExpress.XtraBars.BarButtonItem();
            this.iSetting = new DevExpress.XtraBars.BarButtonItem();
            this.iAisle = new DevExpress.XtraBars.BarButtonItem();
            this.iShelf = new DevExpress.XtraBars.BarButtonItem();
            this.iTag = new DevExpress.XtraBars.BarButtonItem();
            this.iContainerType = new DevExpress.XtraBars.BarButtonItem();
            this.iInboundPlan = new DevExpress.XtraBars.BarButtonItem();
            this.iContainer = new DevExpress.XtraBars.BarButtonItem();
            this.iLocation = new DevExpress.XtraBars.BarButtonItem();
            this.btnProcess = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductLine = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductStation = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductionOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnMaterialRequisition = new DevExpress.XtraBars.BarButtonItem();
            this.btnWerkstattbestand = new DevExpress.XtraBars.BarButtonItem();
            this.btnPreproduction = new DevExpress.XtraBars.BarButtonItem();
            this.iTagSku = new DevExpress.XtraBars.BarButtonItem();
            this.itagLocation = new DevExpress.XtraBars.BarButtonItem();
            this.iInboundBill = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductionPlan = new DevExpress.XtraBars.BarButtonItem();
            this.iStock = new DevExpress.XtraBars.BarButtonItem();
            this.iStockLog = new DevExpress.XtraBars.BarButtonItem();
            this.iOutboundPlan = new DevExpress.XtraBars.BarButtonItem();
            this.iOutboundBill = new DevExpress.XtraBars.BarButtonItem();
            this.iCountBill = new DevExpress.XtraBars.BarButtonItem();
            this.LocationDisplay = new DevExpress.XtraBars.BarButtonItem();
            this.iReceivePreparation = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonImageCollectionLarge = new DevExpress.Utils.ImageCollection();
            this.basicDataRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.BasicDataRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.SkuRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.MesPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.warehouseRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.warehouseRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.SettingRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.inboundRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.inboundRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.inventoryRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.stockRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.outboundRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.outboundRibbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.distributionRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.reportRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.homeRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.parameterRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.UserRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.skinsRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exitRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.helpRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.helpRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.sandDockManager = new TD.SandDock.SandDockManager();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.iReceive = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlModuleZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer2)).BeginInit();
            this.popupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).BeginInit();
            this.popupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 144);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainerControl.Panel1.Controls.Add(this.navBarControl);
            this.splitContainerControl.Panel1.MinSize = 250;
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.pnlModuleZone);
            this.splitContainerControl.Panel2.MinSize = 800;
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(879, 545);
            this.splitContainerControl.SplitterPosition = 2;
            this.splitContainerControl.TabIndex = 0;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.taskGroup;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.notifyGroup,
            this.taskGroup,
            this.helpGroup});
            this.navBarControl.LargeImages = this.navbarImageListLarge;
            this.navBarControl.Location = new System.Drawing.Point(0, 0);
            this.navBarControl.Margin = new System.Windows.Forms.Padding(2);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 250;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new System.Drawing.Size(250, 541);
            this.navBarControl.SmallImages = this.navbarImageList;
            this.navBarControl.StoreDefaultPaintStyleName = true;
            this.navBarControl.TabIndex = 1;
            this.navBarControl.Text = "navBarControl1";
            // 
            // taskGroup
            // 
            this.taskGroup.Caption = "我的任务";
            this.taskGroup.Expanded = true;
            this.taskGroup.LargeImageIndex = 2;
            this.taskGroup.Name = "taskGroup";
            // 
            // notifyGroup
            // 
            this.notifyGroup.Caption = "系统通告";
            this.notifyGroup.LargeImageIndex = 0;
            this.notifyGroup.Name = "notifyGroup";
            // 
            // helpGroup
            // 
            this.helpGroup.Caption = "操作说明";
            this.helpGroup.LargeImageIndex = 1;
            this.helpGroup.Name = "helpGroup";
            // 
            // navbarImageListLarge
            // 
            this.navbarImageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("navbarImageListLarge.ImageStream")));
            this.navbarImageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.navbarImageListLarge.Images.SetKeyName(0, "Mail_32x32.png");
            this.navbarImageListLarge.Images.SetKeyName(1, "Organizer_32x32.png");
            this.navbarImageListLarge.Images.SetKeyName(2, "control_101.ico");
            // 
            // navbarImageList
            // 
            this.navbarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("navbarImageList.ImageStream")));
            this.navbarImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.navbarImageList.Images.SetKeyName(0, "Inbox_16x16.png");
            this.navbarImageList.Images.SetKeyName(1, "Outbox_16x16.png");
            this.navbarImageList.Images.SetKeyName(2, "Drafts_16x16.png");
            this.navbarImageList.Images.SetKeyName(3, "Trash_16x16.png");
            this.navbarImageList.Images.SetKeyName(4, "Calendar_16x16.png");
            this.navbarImageList.Images.SetKeyName(5, "Tasks_16x16.png");
            // 
            // pnlModuleZone
            // 
            this.pnlModuleZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModuleZone.Location = new System.Drawing.Point(0, 0);
            this.pnlModuleZone.Name = "pnlModuleZone";
            this.pnlModuleZone.Size = new System.Drawing.Size(620, 541);
            this.pnlModuleZone.TabIndex = 0;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.appMenu;
            this.ribbonControl.ApplicationButtonText = null;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.ExpandCollapseItem.Name = "";
            this.ribbonControl.Images = this.ribbonImageCollection;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.iNew,
            this.iOpen,
            this.iClose,
            this.iFind,
            this.iSave,
            this.iSaveAs,
            this.iExit,
            this.iHelp,
            this.iAbout,
            this.sbarServerName,
            this.sbarWarehouse,
            this.alignButtonGroup,
            this.iBoldFontStyle,
            this.iItalicFontStyle,
            this.iUnderlinedFontStyle,
            this.fontStyleButtonGroup,
            this.iLeftTextAlign,
            this.iCenterTextAlign,
            this.iRightTextAlign,
            this.rgbiSkins,
            this.sbarUserName,
            this.iParameter,
            this.iDataDictionary,
            this.iUser,
            this.iFunction,
            this.iGroup,
            this.iRole,
            this.iDistrict,
            this.iCompany,
            this.iCategoryManagement,
            this.iSku,
            this.iWarehouse,
            this.iArea,
            this.iSetting,
            this.iAisle,
            this.iShelf,
            this.iTag,
            this.iContainerType,
            this.iInboundPlan,
            this.iContainer,
            this.iLocation,
            this.btnProcess,
            this.btnProductLine,
            this.btnProductStation,
            this.btnProductionOrder,
            this.btnMaterialRequisition,
            this.btnWerkstattbestand,
            this.btnPreproduction,
            this.iTagSku,
            this.itagLocation,
            this.iInboundBill,
            this.btnProductionPlan,
            this.iStock,
            this.iStockLog,
            this.iOutboundPlan,
            this.iOutboundBill,
            this.iCountBill,
            this.LocationDisplay,
            this.iReceivePreparation,
            this.iReceive});
            this.ribbonControl.LargeImages = this.ribbonImageCollectionLarge;
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(0);
            this.ribbonControl.MaxItemId = 101;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.PageHeaderItemLinks.Add(this.iAbout);
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.basicDataRibbonPage,
            this.warehouseRibbonPage,
            this.inboundRibbonPage,
            this.inventoryRibbonPage,
            this.ribbonPage1,
            this.outboundRibbonPage,
            this.distributionRibbonPage,
            this.reportRibbonPage,
            this.homeRibbonPage,
            this.helpRibbonPage});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(879, 144);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.Toolbar.ItemLinks.Add(this.iHelp);
            this.ribbonControl.Toolbar.ItemLinks.Add(this.iExit);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // appMenu
            // 
            this.appMenu.BottomPaneControlContainer = this.popupControlContainer2;
            this.appMenu.ItemLinks.Add(this.iHelp);
            this.appMenu.ItemLinks.Add(this.iExit);
            this.appMenu.Name = "appMenu";
            this.appMenu.Ribbon = this.ribbonControl;
            this.appMenu.RightPaneControlContainer = this.popupControlContainer1;
            this.appMenu.ShowRightPane = true;
            // 
            // popupControlContainer2
            // 
            this.popupControlContainer2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.popupControlContainer2.Appearance.Options.UseBackColor = true;
            this.popupControlContainer2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer2.Controls.Add(this.buttonEdit);
            this.popupControlContainer2.Location = new System.Drawing.Point(316, 258);
            this.popupControlContainer2.Name = "popupControlContainer2";
            this.popupControlContainer2.Ribbon = this.ribbonControl;
            this.popupControlContainer2.Size = new System.Drawing.Size(118, 28);
            this.popupControlContainer2.TabIndex = 5;
            this.popupControlContainer2.Visible = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.EditValue = "";
            this.buttonEdit.Location = new System.Drawing.Point(3, 3);
            this.buttonEdit.MenuManager = this.ribbonControl;
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit.Size = new System.Drawing.Size(100, 20);
            this.buttonEdit.TabIndex = 0;
            // 
            // iHelp
            // 
            this.iHelp.Caption = "帮助";
            this.iHelp.Description = "运行系统帮助文档";
            this.iHelp.Hint = "运行系统帮助文档";
            this.iHelp.Id = 22;
            this.iHelp.ImageIndex = 7;
            this.iHelp.LargeImageIndex = 7;
            this.iHelp.Name = "iHelp";
            // 
            // iExit
            // 
            this.iExit.Caption = "退出系统";
            this.iExit.Description = "退出应用系统";
            this.iExit.Hint = "退出应用系统";
            this.iExit.Id = 20;
            this.iExit.ImageIndex = 6;
            this.iExit.LargeImageIndex = 6;
            this.iExit.Name = "iExit";
            this.iExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iExit_ItemClick);
            // 
            // popupControlContainer1
            // 
            this.popupControlContainer1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.popupControlContainer1.Appearance.Options.UseBackColor = true;
            this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer1.Controls.Add(this.someLabelControl2);
            this.popupControlContainer1.Controls.Add(this.someLabelControl1);
            this.popupControlContainer1.Location = new System.Drawing.Point(208, 168);
            this.popupControlContainer1.Name = "popupControlContainer1";
            this.popupControlContainer1.Ribbon = this.ribbonControl;
            this.popupControlContainer1.Size = new System.Drawing.Size(76, 70);
            this.popupControlContainer1.TabIndex = 4;
            this.popupControlContainer1.Visible = false;
            // 
            // someLabelControl2
            // 
            this.someLabelControl2.Location = new System.Drawing.Point(3, 57);
            this.someLabelControl2.Name = "someLabelControl2";
            this.someLabelControl2.Size = new System.Drawing.Size(0, 13);
            this.someLabelControl2.TabIndex = 0;
            // 
            // someLabelControl1
            // 
            this.someLabelControl1.Location = new System.Drawing.Point(3, 3);
            this.someLabelControl1.Name = "someLabelControl1";
            this.someLabelControl1.Size = new System.Drawing.Size(0, 13);
            this.someLabelControl1.TabIndex = 0;
            // 
            // ribbonImageCollection
            // 
            this.ribbonImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollection.ImageStream")));
            this.ribbonImageCollection.Images.SetKeyName(0, "Ribbon_New_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(1, "Ribbon_Open_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(2, "Ribbon_Close_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(3, "Ribbon_Find_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(4, "Ribbon_Save_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(6, "Ribbon_Exit_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(7, "Ribbon_Content_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(8, "Ribbon_Info_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(9, "Ribbon_Bold_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(10, "Ribbon_Italic_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(11, "Ribbon_Underline_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(12, "Ribbon_AlignLeft_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(13, "Ribbon_AlignCenter_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(14, "Ribbon_AlignRight_16x16.png");
            // 
            // iNew
            // 
            this.iNew.Caption = "New";
            this.iNew.Description = "Creates a new, blank file.";
            this.iNew.Hint = "Creates a new, blank file";
            this.iNew.Id = 1;
            this.iNew.ImageIndex = 0;
            this.iNew.LargeImageIndex = 0;
            this.iNew.Name = "iNew";
            // 
            // iOpen
            // 
            this.iOpen.Caption = "&Open";
            this.iOpen.Description = "Opens a file.";
            this.iOpen.Hint = "Opens a file";
            this.iOpen.Id = 2;
            this.iOpen.ImageIndex = 1;
            this.iOpen.LargeImageIndex = 1;
            this.iOpen.Name = "iOpen";
            this.iOpen.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.iOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // iClose
            // 
            this.iClose.Caption = "&Close";
            this.iClose.Description = "Closes the active document.";
            this.iClose.Hint = "Closes the active document";
            this.iClose.Id = 3;
            this.iClose.ImageIndex = 2;
            this.iClose.LargeImageIndex = 2;
            this.iClose.Name = "iClose";
            this.iClose.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // iFind
            // 
            this.iFind.Caption = "Find";
            this.iFind.Description = "Searches for the specified info.";
            this.iFind.Hint = "Searches for the specified info";
            this.iFind.Id = 15;
            this.iFind.ImageIndex = 3;
            this.iFind.LargeImageIndex = 3;
            this.iFind.Name = "iFind";
            this.iFind.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // iSave
            // 
            this.iSave.Caption = "&Save";
            this.iSave.Description = "Saves the active document.";
            this.iSave.Hint = "Saves the active document";
            this.iSave.Id = 16;
            this.iSave.ImageIndex = 4;
            this.iSave.LargeImageIndex = 4;
            this.iSave.Name = "iSave";
            // 
            // iSaveAs
            // 
            this.iSaveAs.Caption = "Save As";
            this.iSaveAs.Description = "Saves the active document in a different location.";
            this.iSaveAs.Hint = "Saves the active document in a different location";
            this.iSaveAs.Id = 17;
            this.iSaveAs.ImageIndex = 5;
            this.iSaveAs.LargeImageIndex = 5;
            this.iSaveAs.Name = "iSaveAs";
            // 
            // iAbout
            // 
            this.iAbout.Caption = "版本号";
            this.iAbout.Description = "WMS V1.0.0.0";
            this.iAbout.Hint = "WMS V1.0.0.0";
            this.iAbout.Id = 24;
            this.iAbout.ImageIndex = 8;
            this.iAbout.LargeImageIndex = 8;
            this.iAbout.Name = "iAbout";
            // 
            // sbarServerName
            // 
            this.sbarServerName.Caption = "应用服务器名：WMSAPP01";
            this.sbarServerName.Id = 31;
            this.sbarServerName.Name = "sbarServerName";
            this.sbarServerName.TextAlignment = System.Drawing.StringAlignment.Near;
            this.sbarServerName.Width = 250;
            // 
            // sbarWarehouse
            // 
            this.sbarWarehouse.Caption = "登录仓库：上海仓";
            this.sbarWarehouse.Id = 32;
            this.sbarWarehouse.Name = "sbarWarehouse";
            this.sbarWarehouse.TextAlignment = System.Drawing.StringAlignment.Near;
            this.sbarWarehouse.Width = 150;
            // 
            // alignButtonGroup
            // 
            this.alignButtonGroup.Caption = "Align Commands";
            this.alignButtonGroup.Id = 52;
            this.alignButtonGroup.ItemLinks.Add(this.iBoldFontStyle);
            this.alignButtonGroup.ItemLinks.Add(this.iItalicFontStyle);
            this.alignButtonGroup.ItemLinks.Add(this.iUnderlinedFontStyle);
            this.alignButtonGroup.Name = "alignButtonGroup";
            // 
            // iBoldFontStyle
            // 
            this.iBoldFontStyle.Caption = "Bold";
            this.iBoldFontStyle.Id = 53;
            this.iBoldFontStyle.ImageIndex = 9;
            this.iBoldFontStyle.Name = "iBoldFontStyle";
            // 
            // iItalicFontStyle
            // 
            this.iItalicFontStyle.Caption = "Italic";
            this.iItalicFontStyle.Id = 54;
            this.iItalicFontStyle.ImageIndex = 10;
            this.iItalicFontStyle.Name = "iItalicFontStyle";
            // 
            // iUnderlinedFontStyle
            // 
            this.iUnderlinedFontStyle.Caption = "Underlined";
            this.iUnderlinedFontStyle.Id = 55;
            this.iUnderlinedFontStyle.ImageIndex = 11;
            this.iUnderlinedFontStyle.Name = "iUnderlinedFontStyle";
            // 
            // fontStyleButtonGroup
            // 
            this.fontStyleButtonGroup.Caption = "Font Style";
            this.fontStyleButtonGroup.Id = 56;
            this.fontStyleButtonGroup.ItemLinks.Add(this.iLeftTextAlign);
            this.fontStyleButtonGroup.ItemLinks.Add(this.iCenterTextAlign);
            this.fontStyleButtonGroup.ItemLinks.Add(this.iRightTextAlign);
            this.fontStyleButtonGroup.Name = "fontStyleButtonGroup";
            // 
            // iLeftTextAlign
            // 
            this.iLeftTextAlign.Caption = "Left";
            this.iLeftTextAlign.Id = 57;
            this.iLeftTextAlign.ImageIndex = 12;
            this.iLeftTextAlign.Name = "iLeftTextAlign";
            // 
            // iCenterTextAlign
            // 
            this.iCenterTextAlign.Caption = "Center";
            this.iCenterTextAlign.Id = 58;
            this.iCenterTextAlign.ImageIndex = 13;
            this.iCenterTextAlign.Name = "iCenterTextAlign";
            // 
            // iRightTextAlign
            // 
            this.iRightTextAlign.Caption = "Right";
            this.iRightTextAlign.Id = 59;
            this.iRightTextAlign.ImageIndex = 14;
            this.iRightTextAlign.Name = "iRightTextAlign";
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Caption = "切换皮肤";
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Gallery.AllowHoverImages = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgbiSkins.Gallery.ColumnCount = 4;
            this.rgbiSkins.Gallery.FixedHoverImageSize = false;
            this.rgbiSkins.Gallery.ImageSize = new System.Drawing.Size(32, 17);
            this.rgbiSkins.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top;
            this.rgbiSkins.Gallery.RowCount = 4;
            this.rgbiSkins.Id = 60;
            this.rgbiSkins.Name = "rgbiSkins";
            // 
            // sbarUserName
            // 
            this.sbarUserName.Caption = "登录用户：李易峰";
            this.sbarUserName.Id = 62;
            this.sbarUserName.Name = "sbarUserName";
            this.sbarUserName.TextAlignment = System.Drawing.StringAlignment.Near;
            this.sbarUserName.Width = 150;
            // 
            // iParameter
            // 
            this.iParameter.Caption = "参数维护";
            this.iParameter.Id = 63;
            this.iParameter.ImageIndex = 0;
            this.iParameter.LargeImageIndex = 0;
            this.iParameter.Name = "iParameter";
            this.iParameter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iParameter_ItemClick);
            // 
            // iDataDictionary
            // 
            this.iDataDictionary.Caption = "数据字典维护";
            this.iDataDictionary.Id = 64;
            this.iDataDictionary.ImageIndex = 0;
            this.iDataDictionary.LargeImageIndex = 0;
            this.iDataDictionary.Name = "iDataDictionary";
            this.iDataDictionary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iDataDictionary_ItemClick);
            // 
            // iUser
            // 
            this.iUser.Caption = "用户维护";
            this.iUser.Id = 66;
            this.iUser.ImageIndex = 0;
            this.iUser.LargeImageIndex = 0;
            this.iUser.Name = "iUser";
            this.iUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iUser_ItemClick);
            // 
            // iFunction
            // 
            this.iFunction.Caption = "功能维护";
            this.iFunction.Id = 67;
            this.iFunction.ImageIndex = 0;
            this.iFunction.LargeImageIndex = 0;
            this.iFunction.Name = "iFunction";
            this.iFunction.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iFunction_ItemClick);
            // 
            // iGroup
            // 
            this.iGroup.Caption = "用户组维护";
            this.iGroup.Id = 68;
            this.iGroup.ImageIndex = 0;
            this.iGroup.LargeImageIndex = 0;
            this.iGroup.Name = "iGroup";
            this.iGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iGroup_ItemClick);
            // 
            // iRole
            // 
            this.iRole.Caption = "角色维护";
            this.iRole.Id = 69;
            this.iRole.ImageIndex = 0;
            this.iRole.LargeImageIndex = 0;
            this.iRole.Name = "iRole";
            this.iRole.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iRole_ItemClick);
            // 
            // iDistrict
            // 
            this.iDistrict.Caption = "地区维护";
            this.iDistrict.Id = 70;
            this.iDistrict.ImageIndex = 0;
            this.iDistrict.LargeImageIndex = 0;
            this.iDistrict.Name = "iDistrict";
            this.iDistrict.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iDistrict_ItemClick);
            // 
            // iCompany
            // 
            this.iCompany.Caption = "公司维护";
            this.iCompany.Id = 71;
            this.iCompany.ImageIndex = 0;
            this.iCompany.LargeImageIndex = 0;
            this.iCompany.Name = "iCompany";
            this.iCompany.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCompany_ItemClick);
            // 
            // iCategoryManagement
            // 
            this.iCategoryManagement.Caption = "货物类型维护";
            this.iCategoryManagement.Id = 72;
            this.iCategoryManagement.ImageIndex = 0;
            this.iCategoryManagement.LargeImageIndex = 0;
            this.iCategoryManagement.Name = "iCategoryManagement";
            this.iCategoryManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCategoryManagement_ItemClick);
            // 
            // iSku
            // 
            this.iSku.Caption = "货物维护";
            this.iSku.Id = 73;
            this.iSku.ImageIndex = 0;
            this.iSku.LargeImageIndex = 0;
            this.iSku.Name = "iSku";
            this.iSku.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSku_ItemClick);
            // 
            // iWarehouse
            // 
            this.iWarehouse.Caption = "仓库维护";
            this.iWarehouse.Id = 74;
            this.iWarehouse.ImageIndex = 0;
            this.iWarehouse.LargeImageIndex = 0;
            this.iWarehouse.Name = "iWarehouse";
            this.iWarehouse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iWarehouse_ItemClick);
            // 
            // iArea
            // 
            this.iArea.Caption = "库区维护";
            this.iArea.Id = 75;
            this.iArea.ImageIndex = 0;
            this.iArea.LargeImageIndex = 0;
            this.iArea.Name = "iArea";
            this.iArea.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iArea_ItemClick);
            // 
            // iSetting
            // 
            this.iSetting.Caption = "设置维护";
            this.iSetting.Id = 76;
            this.iSetting.ImageIndex = 0;
            this.iSetting.LargeImageIndex = 0;
            this.iSetting.Name = "iSetting";
            this.iSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSetting_ItemClick);
            // 
            // iAisle
            // 
            this.iAisle.Caption = "通道维护";
            this.iAisle.Id = 77;
            this.iAisle.ImageIndex = 0;
            this.iAisle.LargeImageIndex = 0;
            this.iAisle.Name = "iAisle";
            this.iAisle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iAisle_ItemClick);
            // 
            // iShelf
            // 
            this.iShelf.Caption = "货架维护";
            this.iShelf.Id = 78;
            this.iShelf.ImageIndex = 0;
            this.iShelf.LargeImageIndex = 0;
            this.iShelf.Name = "iShelf";
            this.iShelf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iShelf_ItemClick);
            // 
            // iTag
            // 
            this.iTag.Caption = "标签维护";
            this.iTag.Id = 80;
            this.iTag.ImageIndex = 0;
            this.iTag.LargeImageIndex = 0;
            this.iTag.Name = "iTag";
            this.iTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iTag_ItemClick);
            // 
            // iContainerType
            // 
            this.iContainerType.Caption = "容器类型维护";
            this.iContainerType.Id = 81;
            this.iContainerType.ImageIndex = 0;
            this.iContainerType.LargeImageIndex = 0;
            this.iContainerType.Name = "iContainerType";
            this.iContainerType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iContainerType_ItemClick);
            // 
            // iInboundPlan
            // 
            this.iInboundPlan.Caption = "入库计划维护";
            this.iInboundPlan.Id = 82;
            this.iInboundPlan.ImageIndex = 0;
            this.iInboundPlan.LargeImageIndex = 0;
            this.iInboundPlan.Name = "iInboundPlan";
            this.iInboundPlan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iInboundPlan_ItemClick);
            // 
            // iContainer
            // 
            this.iContainer.Caption = "容器维护";
            this.iContainer.Id = 83;
            this.iContainer.ImageIndex = 0;
            this.iContainer.LargeImageIndex = 0;
            this.iContainer.Name = "iContainer";
            this.iContainer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iContainer_ItemClick);
            // 
            // iLocation
            // 
            this.iLocation.Caption = "库位维护";
            this.iLocation.Id = 84;
            this.iLocation.ImageIndex = 0;
            this.iLocation.LargeImageIndex = 0;
            this.iLocation.Name = "iLocation";
            this.iLocation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iLocation_ItemClick);
            // 
            // btnProcess
            // 
            this.btnProcess.Caption = "工序";
            this.btnProcess.Id = 86;
            this.btnProcess.ImageIndex = 0;
            this.btnProcess.LargeImageIndex = 0;
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProcess_ItemClick);
            // 
            // btnProductLine
            // 
            this.btnProductLine.Caption = "产线信息";
            this.btnProductLine.Id = 87;
            this.btnProductLine.ImageIndex = 0;
            this.btnProductLine.LargeImageIndex = 0;
            this.btnProductLine.Name = "btnProductLine";
            this.btnProductLine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductLine_ItemClick);
            // 
            // btnProductStation
            // 
            this.btnProductStation.Caption = "工位";
            this.btnProductStation.Id = 88;
            this.btnProductStation.ImageIndex = 0;
            this.btnProductStation.LargeImageIndex = 0;
            this.btnProductStation.Name = "btnProductStation";
            this.btnProductStation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductStation_ItemClick);
            // 
            // btnProductionOrder
            // 
            this.btnProductionOrder.Caption = "总工单";
            this.btnProductionOrder.Id = 89;
            this.btnProductionOrder.ImageIndex = 0;
            this.btnProductionOrder.LargeImageIndex = 0;
            this.btnProductionOrder.Name = "btnProductionOrder";
            this.btnProductionOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductionOrder_ItemClick);
            // 
            // btnMaterialRequisition
            // 
            this.btnMaterialRequisition.Caption = "领料单";
            this.btnMaterialRequisition.Id = 90;
            this.btnMaterialRequisition.ImageIndex = 0;
            this.btnMaterialRequisition.LargeImageIndex = 0;
            this.btnMaterialRequisition.Name = "btnMaterialRequisition";
            this.btnMaterialRequisition.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMaterialRequisition_ItemClick);
            // 
            // btnWerkstattbestand
            // 
            this.btnWerkstattbestand.Caption = "车间库存管理";
            this.btnWerkstattbestand.Id = 91;
            this.btnWerkstattbestand.ImageIndex = 0;
            this.btnWerkstattbestand.LargeImageIndex = 0;
            this.btnWerkstattbestand.Name = "btnWerkstattbestand";
            this.btnWerkstattbestand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWerkstattbestand_ItemClick);
            // 
            // btnPreproduction
            // 
            this.btnPreproduction.Caption = "样品试制";
            this.btnPreproduction.Id = 92;
            this.btnPreproduction.ImageIndex = 0;
            this.btnPreproduction.LargeImageIndex = 0;
            this.btnPreproduction.Name = "btnPreproduction";
            this.btnPreproduction.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPreproduction_ItemClick);
            // 
            // iTagSku
            // 
            this.iTagSku.Caption = "货物和标签映射";
            this.iTagSku.Id = 88;
            this.iTagSku.ImageIndex = 0;
            this.iTagSku.LargeImageIndex = 0;
            this.iTagSku.Name = "iTagSku";
            this.iTagSku.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iTagSku_ItemClick);
            // 
            // itagLocation
            // 
            this.itagLocation.Caption = "库位和标签映射";
            this.itagLocation.Id = 89;
            this.itagLocation.ImageIndex = 0;
            this.itagLocation.LargeImageIndex = 0;
            this.itagLocation.Name = "itagLocation";
            this.itagLocation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iTagLocation_ItemClick);
            // 
            // iInboundBill
            // 
            this.iInboundBill.Caption = "入库单维护";
            this.iInboundBill.Id = 90;
            this.iInboundBill.ImageIndex = 0;
            this.iInboundBill.LargeImageIndex = 0;
            this.iInboundBill.Name = "iInboundBill";
            this.iInboundBill.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iInboundBill_ItemClick);
            // 
            // btnProductionPlan
            // 
            this.btnProductionPlan.Caption = "生产计划";
            this.btnProductionPlan.Id = 91;
            this.btnProductionPlan.ImageIndex = 0;
            this.btnProductionPlan.LargeImageIndex = 0;
            this.btnProductionPlan.Name = "btnProductionPlan";
            this.btnProductionPlan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductionPlan_ItemClick);
            // 
            // iStock
            // 
            this.iStock.Caption = "实时库存查询";
            this.iStock.Id = 91;
            this.iStock.ImageIndex = 0;
            this.iStock.LargeImageIndex = 0;
            this.iStock.Name = "iStock";
            this.iStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iStock_ItemClick);
            // 
            // iStockLog
            // 
            this.iStockLog.Caption = "库存日志查询";
            this.iStockLog.Id = 92;
            this.iStockLog.ImageIndex = 0;
            this.iStockLog.LargeImageIndex = 0;
            this.iStockLog.Name = "iStockLog";
            this.iStockLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iStockLog_ItemClick);
            // 
            // iOutboundPlan
            // 
            this.iOutboundPlan.Caption = "出库计划维护";
            this.iOutboundPlan.Id = 95;
            this.iOutboundPlan.ImageIndex = 0;
            this.iOutboundPlan.LargeImageIndex = 0;
            this.iOutboundPlan.Name = "iOutboundPlan";
            this.iOutboundPlan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iOutboundPlan_ItemClick);
            // 
            // iOutboundBill
            // 
            this.iOutboundBill.Caption = "出库单维护";
            this.iOutboundBill.Id = 96;
            this.iOutboundBill.ImageIndex = 0;
            this.iOutboundBill.LargeImageIndex = 0;
            this.iOutboundBill.Name = "iOutboundBill";
            this.iOutboundBill.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iOutboundBill_ItemClick);
            // 
            // iCountBill
            // 
            this.iCountBill.Caption = "盘点单维护";
            this.iCountBill.Id = 97;
            this.iCountBill.ImageIndex = 0;
            this.iCountBill.LargeImageIndex = 0;
            this.iCountBill.Name = "iCountBill";
            this.iCountBill.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCountBill_ItemClick);
            // 
            // LocationDisplay
            // 
            this.LocationDisplay.Caption = "区域图形化库位管理";
            this.LocationDisplay.Id = 98;
            this.LocationDisplay.ImageIndex = 0;
            this.LocationDisplay.LargeImageIndex = 0;
            this.LocationDisplay.Name = "LocationDisplay";
            this.LocationDisplay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LocationDisplay_ItemClick);
            // 
            // iReceivePreparation
            // 
            this.iReceivePreparation.Caption = "收货准备";
            this.iReceivePreparation.Id = 99;
            this.iReceivePreparation.ImageIndex = 0;
            this.iReceivePreparation.LargeImageIndex = 0;
            this.iReceivePreparation.Name = "iReceivePreparation";
            this.iReceivePreparation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iReceivePreparation_ItemClick);
            // 
            // ribbonImageCollectionLarge
            // 
            this.ribbonImageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbonImageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollectionLarge.ImageStream")));
            this.ribbonImageCollectionLarge.Images.SetKeyName(0, "Ribbon_New_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(1, "Ribbon_Open_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(2, "Ribbon_Close_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(3, "Ribbon_Find_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(4, "Ribbon_Save_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(6, "Ribbon_Exit_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(7, "Ribbon_Content_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(8, "Ribbon_Info_32x32.png");
            // 
            // basicDataRibbonPage
            // 
            this.basicDataRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.BasicDataRibbonPageGroup,
            this.SkuRibbonPageGroup,
            this.MesPageGroup});
            this.basicDataRibbonPage.Name = "basicDataRibbonPage";
            this.basicDataRibbonPage.Text = "基础资料";
            // 
            // BasicDataRibbonPageGroup
            // 
            this.BasicDataRibbonPageGroup.ItemLinks.Add(this.iDistrict);
            this.BasicDataRibbonPageGroup.ItemLinks.Add(this.iCompany);
            this.BasicDataRibbonPageGroup.Name = "BasicDataRibbonPageGroup";
            this.BasicDataRibbonPageGroup.Text = "基础信息";
            // 
            // SkuRibbonPageGroup
            // 
            this.SkuRibbonPageGroup.ItemLinks.Add(this.iCategoryManagement);
            this.SkuRibbonPageGroup.ItemLinks.Add(this.iSku);
            this.SkuRibbonPageGroup.Name = "SkuRibbonPageGroup";
            this.SkuRibbonPageGroup.Text = "货物信息";
            // 
            // MesPageGroup
            // 
            this.MesPageGroup.ItemLinks.Add(this.btnProductLine);
            this.MesPageGroup.ItemLinks.Add(this.btnProductStation);
            this.MesPageGroup.ItemLinks.Add(this.btnProcess);
            this.MesPageGroup.Name = "MesPageGroup";
            this.MesPageGroup.Text = "产线信息";
            // 
            // warehouseRibbonPage
            // 
            this.warehouseRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.warehouseRibbonPageGroup,
            this.SettingRibbonPageGroup});
            this.warehouseRibbonPage.Name = "warehouseRibbonPage";
            this.warehouseRibbonPage.Text = "仓库资料";
            // 
            // warehouseRibbonPageGroup
            // 
            this.warehouseRibbonPageGroup.ItemLinks.Add(this.iWarehouse);
            this.warehouseRibbonPageGroup.ItemLinks.Add(this.iAisle);
            this.warehouseRibbonPageGroup.ItemLinks.Add(this.iArea);
            this.warehouseRibbonPageGroup.ItemLinks.Add(this.iShelf);
            this.warehouseRibbonPageGroup.ItemLinks.Add(this.iContainer);
            this.warehouseRibbonPageGroup.ItemLinks.Add(this.iContainerType);
            this.warehouseRibbonPageGroup.ItemLinks.Add(this.iLocation);
            this.warehouseRibbonPageGroup.Name = "warehouseRibbonPageGroup";
            this.warehouseRibbonPageGroup.Text = "仓库信息";
            // 
            // SettingRibbonPageGroup
            // 
            this.SettingRibbonPageGroup.ItemLinks.Add(this.iSetting);
            this.SettingRibbonPageGroup.ItemLinks.Add(this.iTag);
            this.SettingRibbonPageGroup.ItemLinks.Add(this.iTagSku);
            this.SettingRibbonPageGroup.ItemLinks.Add(this.itagLocation);
            this.SettingRibbonPageGroup.Name = "SettingRibbonPageGroup";
            this.SettingRibbonPageGroup.Text = "仓库设置";
            // 
            // inboundRibbonPage
            // 
            this.inboundRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.inboundRibbonPageGroup});
            this.inboundRibbonPage.Name = "inboundRibbonPage";
            this.inboundRibbonPage.Text = "入库作业";
            // 
            // inboundRibbonPageGroup
            // 
            this.inboundRibbonPageGroup.ItemLinks.Add(this.iInboundPlan);
            this.inboundRibbonPageGroup.ItemLinks.Add(this.iReceivePreparation);
            this.inboundRibbonPageGroup.ItemLinks.Add(this.iReceive);
            this.inboundRibbonPageGroup.ItemLinks.Add(this.iInboundBill);
            this.inboundRibbonPageGroup.Name = "inboundRibbonPageGroup";
            this.inboundRibbonPageGroup.Text = "入库管理";
            // 
            // inventoryRibbonPage
            // 
            this.inventoryRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.stockRibbonPageGroup});
            this.inventoryRibbonPage.Name = "inventoryRibbonPage";
            this.inventoryRibbonPage.Text = "库内作业";
            // 
            // stockRibbonPageGroup
            // 
            this.stockRibbonPageGroup.ItemLinks.Add(this.iStock);
            this.stockRibbonPageGroup.ItemLinks.Add(this.iStockLog);
            this.stockRibbonPageGroup.ItemLinks.Add(this.iCountBill);
            this.stockRibbonPageGroup.ItemLinks.Add(this.LocationDisplay);
            this.stockRibbonPageGroup.Name = "stockRibbonPageGroup";
            this.stockRibbonPageGroup.Text = "库存及日志";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "生产作业";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnProductionPlan);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnProductionOrder);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnMaterialRequisition);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "工单";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnWerkstattbestand);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "车间库存管理";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnPreproduction);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "样品试制";
            // 
            // outboundRibbonPage
            // 
            this.outboundRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.outboundRibbonPageGroup1});
            this.outboundRibbonPage.Name = "outboundRibbonPage";
            this.outboundRibbonPage.Text = "出库作业";
            // 
            // outboundRibbonPageGroup1
            // 
            this.outboundRibbonPageGroup1.ItemLinks.Add(this.iOutboundPlan);
            this.outboundRibbonPageGroup1.ItemLinks.Add(this.iOutboundBill);
            this.outboundRibbonPageGroup1.Name = "outboundRibbonPageGroup1";
            this.outboundRibbonPageGroup1.Text = "出库管理";
            // 
            // distributionRibbonPage
            // 
            this.distributionRibbonPage.Name = "distributionRibbonPage";
            this.distributionRibbonPage.Text = "运输配送";
            // 
            // reportRibbonPage
            // 
            this.reportRibbonPage.Name = "reportRibbonPage";
            this.reportRibbonPage.Text = "查询报表";
            // 
            // homeRibbonPage
            // 
            this.homeRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.parameterRibbonPageGroup,
            this.UserRibbonPageGroup,
            this.skinsRibbonPageGroup,
            this.exitRibbonPageGroup});
            this.homeRibbonPage.Name = "homeRibbonPage";
            this.homeRibbonPage.Text = "系统";
            // 
            // parameterRibbonPageGroup
            // 
            this.parameterRibbonPageGroup.ItemLinks.Add(this.iParameter);
            this.parameterRibbonPageGroup.ItemLinks.Add(this.iDataDictionary);
            this.parameterRibbonPageGroup.Name = "parameterRibbonPageGroup";
            this.parameterRibbonPageGroup.Text = "参数及字典";
            // 
            // UserRibbonPageGroup
            // 
            this.UserRibbonPageGroup.ItemLinks.Add(this.iUser);
            this.UserRibbonPageGroup.ItemLinks.Add(this.iGroup);
            this.UserRibbonPageGroup.ItemLinks.Add(this.iFunction);
            this.UserRibbonPageGroup.ItemLinks.Add(this.iRole);
            this.UserRibbonPageGroup.Name = "UserRibbonPageGroup";
            this.UserRibbonPageGroup.Text = "用户及权限";
            // 
            // skinsRibbonPageGroup
            // 
            this.skinsRibbonPageGroup.ItemLinks.Add(this.rgbiSkins);
            this.skinsRibbonPageGroup.Name = "skinsRibbonPageGroup";
            this.skinsRibbonPageGroup.ShowCaptionButton = false;
            this.skinsRibbonPageGroup.Text = "皮肤";
            // 
            // exitRibbonPageGroup
            // 
            this.exitRibbonPageGroup.ItemLinks.Add(this.iExit);
            this.exitRibbonPageGroup.Name = "exitRibbonPageGroup";
            this.exitRibbonPageGroup.Text = "退出";
            // 
            // helpRibbonPage
            // 
            this.helpRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.helpRibbonPageGroup});
            this.helpRibbonPage.Name = "helpRibbonPage";
            this.helpRibbonPage.Text = "帮助";
            // 
            // helpRibbonPageGroup
            // 
            this.helpRibbonPageGroup.ItemLinks.Add(this.iHelp);
            this.helpRibbonPageGroup.ItemLinks.Add(this.iAbout);
            this.helpRibbonPageGroup.Name = "helpRibbonPageGroup";
            this.helpRibbonPageGroup.Text = "帮助";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.sbarServerName);
            this.ribbonStatusBar.ItemLinks.Add(this.sbarWarehouse);
            this.ribbonStatusBar.ItemLinks.Add(this.sbarUserName);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 689);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(879, 31);
            // 
            // sandDockManager
            // 
            this.sandDockManager.BorderStyle = TD.SandDock.Rendering.BorderStyle.RaisedThin;
            this.sandDockManager.DockSystemContainer = this.pnlModuleZone;
            this.sandDockManager.OwnerForm = this;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.iCategoryManagement);
            this.ribbonPageGroup1.ItemLinks.Add(this.iSku);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "货物信息";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.iCategoryManagement);
            this.ribbonPageGroup2.ItemLinks.Add(this.iSku);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "货物信息";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Inbox_16x16.png");
            this.imageList1.Images.SetKeyName(1, "Outbox_16x16.png");
            this.imageList1.Images.SetKeyName(2, "Drafts_16x16.png");
            this.imageList1.Images.SetKeyName(3, "Trash_16x16.png");
            this.imageList1.Images.SetKeyName(4, "Calendar_16x16.png");
            this.imageList1.Images.SetKeyName(5, "Tasks_16x16.png");
            // 
            // iReceive
            // 
            this.iReceive.Caption = "货物核收";
            this.iReceive.Id = 100;
            this.iReceive.ImageIndex = 0;
            this.iReceive.LargeImageIndex = 0;
            this.iReceive.Name = "iReceive";
            this.iReceive.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iReceive_ItemClick);
            // 
            // ShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 720);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.popupControlContainer1);
            this.Controls.Add(this.popupControlContainer2);
            this.Controls.Add(this.ribbonStatusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShellForm";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Warehouse Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShellForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlModuleZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer2)).EndInit();
            this.popupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).EndInit();
            this.popupControlContainer1.ResumeLayout(false);
            this.popupControlContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem iNew;
        private DevExpress.XtraBars.BarButtonItem iOpen;
        private DevExpress.XtraBars.BarButtonItem iClose;
        private DevExpress.XtraBars.BarButtonItem iFind;
        private DevExpress.XtraBars.BarButtonItem iSave;
        private DevExpress.XtraBars.BarButtonItem iSaveAs;
        private DevExpress.XtraBars.BarButtonItem iExit;
        private DevExpress.XtraBars.BarButtonItem iHelp;
        private DevExpress.XtraBars.BarButtonItem iAbout;
        private DevExpress.XtraBars.BarStaticItem sbarServerName;
        private DevExpress.XtraBars.BarStaticItem sbarWarehouse;
        private DevExpress.XtraBars.BarButtonGroup alignButtonGroup;
        private DevExpress.XtraBars.BarButtonItem iBoldFontStyle;
        private DevExpress.XtraBars.BarButtonItem iItalicFontStyle;
        private DevExpress.XtraBars.BarButtonItem iUnderlinedFontStyle;
        private DevExpress.XtraBars.BarButtonGroup fontStyleButtonGroup;
        private DevExpress.XtraBars.BarButtonItem iLeftTextAlign;
        private DevExpress.XtraBars.BarButtonItem iCenterTextAlign;
        private DevExpress.XtraBars.BarButtonItem iRightTextAlign;
        private DevExpress.XtraBars.RibbonGalleryBarItem rgbiSkins;
        private DevExpress.XtraBars.Ribbon.RibbonPage homeRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup skinsRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup exitRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPage helpRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup helpRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu appMenu;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private DevExpress.XtraEditors.LabelControl someLabelControl2;
        private DevExpress.XtraEditors.LabelControl someLabelControl1;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.Utils.ImageCollection ribbonImageCollection;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup taskGroup;
        private System.Windows.Forms.ImageList navbarImageList;
        private System.Windows.Forms.ImageList navbarImageListLarge;
        private DevExpress.XtraEditors.PanelControl pnlModuleZone;
        private TD.SandDock.SandDockManager sandDockManager;
        internal DockableWindowWorkspace sideBarWorkspace;
        internal TabbedDocumentWorkspace contentWorkspace;
        private DevExpress.XtraBars.BarStaticItem sbarUserName;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.Ribbon.RibbonPage basicDataRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPage warehouseRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPage inboundRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPage inventoryRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPage outboundRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPage distributionRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPage reportRibbonPage;
        private DevExpress.XtraBars.BarButtonItem iParameter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup parameterRibbonPageGroup;
        private DevExpress.XtraNavBar.NavBarGroup helpGroup;
        private DevExpress.XtraNavBar.NavBarGroup notifyGroup;
        private DevExpress.XtraBars.BarButtonItem iDataDictionary;
        private DevExpress.XtraBars.BarButtonItem iUser;
        private DevExpress.XtraBars.BarButtonItem iFunction;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup UserRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem iGroup;
        private DevExpress.XtraBars.BarButtonItem iRole;
        private DevExpress.XtraBars.BarButtonItem iDistrict;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup BasicDataRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem iCompany;
        private DevExpress.XtraBars.BarButtonItem iCategoryManagement;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup SkuRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem iSku;
        private DevExpress.XtraBars.BarButtonItem iWarehouse;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup warehouseRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem iArea;
        private DevExpress.XtraBars.BarButtonItem iSetting;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup SettingRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem iAisle;
        private DevExpress.XtraBars.BarButtonItem iShelf;
        private DevExpress.XtraBars.BarButtonItem iTag;
        private DevExpress.XtraBars.BarButtonItem iContainerType;
        private DevExpress.XtraBars.BarButtonItem iInboundPlan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup inboundRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem iContainer;
        private DevExpress.XtraBars.BarButtonItem iLocation;
        private DevExpress.XtraBars.BarButtonItem btnProcess;
        private DevExpress.XtraBars.BarButtonItem btnProductLine;
        private DevExpress.XtraBars.BarButtonItem btnProductStation;
        private DevExpress.XtraBars.BarButtonItem btnProductionOrder;
        private DevExpress.XtraBars.BarButtonItem btnMaterialRequisition;
        private DevExpress.XtraBars.BarButtonItem btnWerkstattbestand;
        private DevExpress.XtraBars.BarButtonItem btnPreproduction;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup MesPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem iTagSku;
        private DevExpress.XtraBars.BarButtonItem itagLocation;
        private DevExpress.XtraBars.BarButtonItem iInboundBill;
        private DevExpress.XtraBars.BarButtonItem btnProductionPlan;
        private DevExpress.XtraBars.BarButtonItem iStock;
        private DevExpress.XtraBars.BarButtonItem iStockLog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup stockRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup outboundRibbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem iOutboundPlan;
        private DevExpress.XtraBars.BarButtonItem iOutboundBill;
        private DevExpress.XtraBars.BarButtonItem iCountBill;
        private DevExpress.XtraBars.BarButtonItem LocationDisplay;
        private DevExpress.XtraBars.BarButtonItem iReceivePreparation;
        private DevExpress.XtraBars.BarButtonItem iReceive;

    }
}
