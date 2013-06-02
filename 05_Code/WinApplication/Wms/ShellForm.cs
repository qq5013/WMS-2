using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Framework.UI.Template.Common;
using DevExpress.UserSkins;
using Wms.Common;
using System.ServiceModel; 
using Business.Common.Exception;

namespace Wms
{
    public partial class ShellForm : RibbonForm
    {
        private WorkItem _workItem;
        public Button ModuleButton = new Button();

        [ServiceDependency]
        public WorkItem WorkItem
        {
            set { _workItem = value; }
        }

        public ShellForm()
        {
            InitializeComponent();
            this.Hide();
            InitSkinGallery();
            
            this.splitContainerControl.Panel1.MinSize = 0;
        }

        private void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        public void ProcessCommandMap()
        {
            #region Application Module
            //_workItem.Commands["Modules.Sidebar.InitMenu"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.Sidebar.InitTree"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Module.Sidebar.PortalView"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Module.Sidebar.ShowSidebar"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["ParameterModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["UserModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["DataDictionaryModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.Log.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["FunctionModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.OperationLog.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["GroupModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["RoleModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            #endregion

            #region Basic Module
            _workItem.Commands["DistrictModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["CompanyModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["CategoryManagementModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["SkuModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.Packet.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.Measure.ShowForm"].AddInvoker(ModuleButton, "Click");
            #endregion

            #region Warehouse Module 
            _workItem.Commands["WarehouseModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["AisleModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["AreaModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["ShelfModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["ContainerTypeModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["ContainerModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["LocationModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.Warehouse.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["SettingModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["TagModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["TagSkuModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["TagLocationModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.OperationGroupModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.TagPolicy.ShowForm"].AddInvoker(ModuleButton, "Click");
            #endregion

            #region Order Module
            _workItem.Commands["Modules.PurchaseOrder.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["Modules.SalesOrderModule.SalesOrderForm"].AddInvoker(ModuleButton, "Click");
            #endregion

            #region Inbound Module
            _workItem.Commands["InboundPlanModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["ReceiveModule.ShowReceivePreparationForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["ReceiveModule.ShowReceiveForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.InboundPlan.ShowFormPop"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["InboundBillModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.InboundBill.ShowFormPop"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.ReceiveGoods.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.PrintLabel.ShowForm"].AddInvoker(ModuleButton, "Click");
            #endregion

            #region Inventory Module
            _workItem.Commands["StockModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["StockLogModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["CountBillModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["LocationDisplayModule.ShowForm"].AddInvoker(ModuleButton, "Click");

            //_workItem.Commands["Modules.StockModules.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.Lock.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.CountBill.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.CountBill.ShowFormPop"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.TransferBill.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.LockLog.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.StockLog.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.StockModule.StockChangeHistoryTraceCodeListForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.Stock.ShowFormPop"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.TransferBill.ShowFormPop"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.IoReport.ShowForm"].AddInvoker(ModuleButton, "Click");
            #endregion

            #region Outbound Module
            _workItem.Commands["OutboundPlanModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.PickBill.ShowForm"].AddInvoker(ModuleButton, "Click");
            _workItem.Commands["OutboundBillModule.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.IssueGoods.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.SortBill.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.OutboundBill.ShowForm"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.OutboundPlan.ShowFormPop"].AddInvoker(ModuleButton, "Click");
            //_workItem.Commands["Modules.PickBill.ShowFormPop"].AddInvoker(ModuleButton, "Click");
            #endregion

            new List<string>
                {
                    "ProductLine",
                    "Process", 
                    "ProductStation",
                    "ProductionPlan",
                    "ProductionOrder",
                    "MaterialRequisition"
                }.ForEach(c => _workItem.Commands[c + "Module.ShowForm"].AddInvoker(ModuleButton, "Click"));
            
           
        }

        private void ShellForm_Load(object sender, System.EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.ShowDialog();
            this.Show();

            string serverName = string.Empty;
            try
            {
                serverName = ServiceHelper.ApplicationService.GetServerName();
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            serverName = "应用服务器: " + ServiceHelper.ApplicationService.GetServerName();
            sbarUserName.Caption = "登录用户: " + GlobalState.CurrentUser.UserName;
            sbarServerName.Caption = serverName;
            sbarWarehouse.Caption = "登录仓库: " + GlobalState.CurrentWarehouse.WarehouseName;

            sideBarWorkspace = new DockableWindowWorkspace(sandDockManager);
            contentWorkspace = new TabbedDocumentWorkspace(sandDockManager);

            //sandDockManager.DockSystemContainer.BackColor = this.BackColor;

            _workItem.Workspaces.Add(contentWorkspace, WorkspaceNames.ContentWorkspace);
            _workItem.Workspaces.Add(sideBarWorkspace, WorkspaceNames.SidebarWorkspace);

            //_workItem.Commands["ParameterModule.ShowForm"].Execute();
        }

        private void iExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //sandDockManager.DocumentContainer.BackColor = this.BackColor;
            //pnlModuleZone.BackColor = this.BackColor;
            System.Windows.Forms.Application.Exit();
        }

        private void iParameter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _workItem.Commands["ParameterModule.ShowForm"].Execute();
        }

        private void iDataDictionary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _workItem.Commands["DataDictionaryModule.ShowForm"].Execute();
        }

        private void iUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _workItem.Commands["UserModule.ShowForm"].Execute();
        }

        private void iFunction_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["FunctionModule.ShowForm"].Execute();
        }

        private void iGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["GroupModule.ShowForm"].Execute();
        }

        private void iRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["RoleModule.ShowForm"].Execute();
        }

        private void iDistrict_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["DistrictModule.ShowForm"].Execute();
        }

        private void iCompany_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["CompanyModule.ShowForm"].Execute();
        }

        private void iCategoryManagement_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["CategoryManagementModule.ShowForm"].Execute();
        }

        private void iSku_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["SkuModule.ShowForm"].Execute();
        }

        private void iWarehouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["WarehouseModule.ShowForm"].Execute();
        }

        private void iArea_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["AreaModule.ShowForm"].Execute();
        }

        private void iSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["SettingModule.ShowForm"].Execute();
        }

        private void iAisle_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["AisleModule.ShowForm"].Execute();
        }

        private void iShelf_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ShelfModule.ShowForm"].Execute();
        }

        private void iTag_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["TagModule.ShowForm"].Execute();
        }

        private void iContainerType_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ContainerTypeModule.ShowForm"].Execute();
        }

        private void iInboundPlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["InboundPlanModule.ShowForm"].Execute();
        }

        private void iContainer_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ContainerModule.ShowForm"].Execute();
        }

        private void iLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["LocationModule.ShowForm"].Execute();
        }


        private void iTagSku_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["TagSkuModule.ShowForm"].Execute();
        }
        private void btnProductLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ProductLineModule.ShowForm"].Execute();
        }

        private void iTagLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["TagLocationModule.ShowForm"].Execute();
        }

        private void iInboundBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["InboundBillModule.ShowForm"].Execute();
        }


        private void btnProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ProcessModule.ShowForm"].Execute();
        }

        private void btnProductStation_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ProductStationModule.ShowForm"].Execute();
        }

        private void btnProductionOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ProductionOrderModule.ShowForm"].Execute();
        }

        private void btnMaterialRequisition_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["MaterialRequisitionModule.ShowForm"].Execute();
        }

        private void btnWerkstattbestand_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["WerkstattbestandModule.ShowForm"].Execute();
        }

        private void btnPreproduction_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["PreproductionModule.ShowForm"].Execute();
        }

        private void btnProductionPlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ProductionPlanModule.ShowForm"].Execute();
        }


        private void iStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["StockModule.ShowForm"].Execute();
        }

        private void iStockLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["StockLogModule.ShowForm"].Execute();
        }

        private void iOutboundPlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["OutboundPlanModule.ShowForm"].Execute();
        }

        private void iOutboundBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["OutboundBillModule.ShowForm"].Execute();
        }

        private void iCountBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["CountBillModule.ShowForm"].Execute();
        }

        private void LocationDisplay_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["LocationDisplayModule.ShowForm"].Execute();
        }

        private void iReceivePreparation_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ReceiveModule.ShowReceivePreparationForm"].Execute();
        }

        private void iReceive_ItemClick(object sender, ItemClickEventArgs e)
        {
            _workItem.Commands["ReceiveModule.ShowReceiveForm"].Execute();
        }
    }
}
