using System;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
//usingWms.Business.Common;
//usingWms.Business.Entity;

namespace Module.SidebarModule.Views
{
    [SmartPart]
    public partial class PortalView : UserControl
    {
        public WorkItem MyWorkItem;

        public PortalView()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CalcIP();
            CalcIB();
            CalcOP();
            CalcOB();
            CalcPB();
            CalcCounting();
            CalcTB();
            ShowLocksGoods();
            ShowQCGoods();
        }

        private void CalcIP()
        {
            //BllResult bllResult;
            //int createdStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.IpCreated).DictionaryId;
            //int receivingStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.IpReceiving).DictionaryId;
            //int partialStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.IpPartial).DictionaryId;
            //string condition = string.Format("BillStatus in ({0}, {1}, {2}) and ReceiveWarehouse = {3}", createdStatus, receivingStatus, partialStatus, GlobalState.LoginUserWarehouse);
            //ArrayList list = GenericServiceHelper.GetListByCondition<InboundPlan>(out bllResult, condition);
            //if (list != null)
            //{
            //    string tipa = GlobalState.LanguageHelper.GetLanguageString("message", "caption_Qty");

            //    if (list.Count > 0)
            //    {
            //        tipa = "待处理入库计划：";
            //        navBarGroup1.Caption = string.Format("{0}{1}", tipa, list.Count);
            //        navBarGroup1.Appearance.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        tipa = "待处理入库计划：";
            //        navBarGroup1.Caption = string.Format("{0}{1}", tipa, list.Count);
            //    }
            //    lbIPList.Items.Clear();
            //    foreach (InboundPlan plan in list)
            //    {
            //        lbIPList.Items.Add(plan.InboundPlanCode);
            //    }
            //}
        }

        private void CalcIB()
        {
            //BllResult bllResult;
            //int receivedStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.IbReceived).DictionaryId;
            //int confirmedStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.IbConfirmed).DictionaryId;
            //string condition = string.Format("BillStatus in ({0}, {1}) and ReceiveWarehouse = {2}", receivedStatus, confirmedStatus, GlobalState.LoginUserWarehouse);
            //ArrayList list = GenericServiceHelper.GetListByCondition<InboundBill>(out bllResult, condition);
            //if (list != null)
            //{
            //    string tipa = GlobalState.LanguageHelper.GetLanguageString("message", "caption_Qty");
            //    if (list.Count > 0)
            //    {
            //        tipa = "待处理入库单：";
            //        navBarGroup2.Caption = string.Format("{0}{1}", tipa, list.Count);
            //        navBarGroup2.Appearance.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        tipa = "待处理入库单：";
            //        navBarGroup2.Caption = string.Format("{0}{1}", tipa, list.Count);
            //    }
            //    lbIBList.Items.Clear();
            //    foreach (InboundBill inboundBill in list)
            //    {
            //        lbIBList.Items.Add(inboundBill.InboundBillCode);
            //    }
            //}
        }

        private void CalcOP()
        {
            //BllResult bllResult;
            //int createdStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.OpCreated).DictionaryId;
            //int pickingStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.OpPicking).DictionaryId;
            //int pickedStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.OpPicked).DictionaryId;
            //string condition = string.Format("BillStatus in ({0}, {1}, {2}) and IssueWarehouse = {3}", createdStatus, pickingStatus, pickedStatus, GlobalState.LoginUserWarehouse);
            //ArrayList list = GenericServiceHelper.GetListByCondition<OutboundPlan>(out bllResult, condition);
            //if (list != null)
            //{
            //    string tipa = GlobalState.LanguageHelper.GetLanguageString("message", "caption_Qty");
            //    if (list.Count > 0)
            //    {
            //        tipa = "待处理出库计划：";
            //        navBarGroup3.Caption = string.Format("{0}{1}", tipa, list.Count);
            //        navBarGroup3.Appearance.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        tipa = "待处理出库计划：";
            //        navBarGroup3.Caption = string.Format("{0}{1}", tipa, list.Count);
            //    }
            //    lbOPList.Items.Clear();
            //    foreach (OutboundPlan outboundPlan in list)
            //    {
            //        lbOPList.Items.Add(outboundPlan.OutboundPlanCode);
            //    }
            //}
        }

        private void CalcPB()
        {
            //BllResult bllResult;
            //int createdStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.PbCreated).DictionaryId;
            //string condition = string.Format("BillStatus in ({0}) and PickWarehouse = {1}", createdStatus, GlobalState.LoginUserWarehouse);
            //ArrayList list = GenericServiceHelper.GetListByCondition<PickBill>(out bllResult, condition);
            //if (list != null)
            //{
            //    string tipa = GlobalState.LanguageHelper.GetLanguageString("message", "caption_Qty");
            //    if (list.Count > 0)
            //    {
            //        tipa = "待处理拣货单：";
            //        navBarGroup5.Caption = string.Format("{0}{1}", tipa, list.Count);
            //        navBarGroup5.Appearance.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        tipa = "待处理拣货单：";
            //        navBarGroup5.Caption = string.Format("{0}{1}", tipa, list.Count);
            //    }
            //    lbPLList.Items.Clear();
            //    foreach (PickBill pickBill in list)
            //    {
            //        if (pickBill != null)
            //            lbPLList.Items.Add(pickBill.PickBillCode);
            //    }
            //}
        }

        private void CalcOB()
        {
            //BllResult bllResult;
            //int createdStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.ObCreated).DictionaryId;
            //string condition = string.Format("BillStatus in ({0}) and IssueWarehouse = {1}", createdStatus, GlobalState.LoginUserWarehouse);
            //ArrayList list = GenericServiceHelper.GetListByCondition<OutboundBill>(out bllResult, condition);
            //if (list != null)
            //{
            //    string tipa = GlobalState.LanguageHelper.GetLanguageString("message", "caption_Qty");
            //    if (list.Count > 0)
            //    {
            //        tipa = "待处理出库单：";
            //        navBarGroup4.Caption = string.Format("{0}{1}", tipa, list.Count);
            //        navBarGroup4.Appearance.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        tipa = "待处理出库单：";
            //        navBarGroup4.Caption = string.Format("{0}{1}", tipa, list.Count);
            //    }
            //    lbOBList.Items.Clear();
            //    foreach (OutboundBill outboundBill in list)
            //    {
            //        lbOBList.Items.Add(outboundBill.OutboundBillCode);
            //    }
            //}
        }

        private void CalcCounting()
        {
            //BllResult bllResult;
            //int planedStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.CbCreated).DictionaryId;
            //string condition = string.Format("BillStatus in ({0}) and WarehouseID = {1}", planedStatus, GlobalState.LoginUserWarehouse);
            //ArrayList list = GenericServiceHelper.GetListByCondition<CountBill>(out bllResult, condition);
            //if (list != null)
            //{
            //    string tipa = GlobalState.LanguageHelper.GetLanguageString("message", "caption_Qty");
            //    if (list.Count > 0)
            //    {
            //        tipa = "待处理盘点单：";
            //        navBarGroup6.Caption = string.Format("{0}{1}", tipa, list.Count);
            //        navBarGroup6.Appearance.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        tipa = "待处理盘点单：";
            //        navBarGroup6.Caption = string.Format("{0}{1}", tipa, list.Count);
            //    }
            //    lbCounting.Items.Clear();
            //    foreach (CountBill countingBill in list)
            //    {
            //        lbCounting.Items.Add(countingBill.CountBillCode);
            //    }
            //}
        }

        private void CalcTB()
        {
            //BllResult bllResult;
            //int planedStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.TbCreated).DictionaryId;
            //int transferedStatus = ServiceHelper.FacadeService.GetDictionaryByCode(BillStatusHelper.TbTransfered).DictionaryId;
            //string condition = string.Format("BillStatus in ({0}, {1}) and WarehouseID = {2}", planedStatus, transferedStatus, GlobalState.LoginUserWarehouse);
            //ArrayList list = GenericServiceHelper.GetListByCondition<TransferBill>(out bllResult, condition);
            //if (list != null)
            //{
            //    string tipa = GlobalState.LanguageHelper.GetLanguageString("message", "caption_Qty");
            //    if (list.Count > 0)
            //    {
            //        tipa = "待处理移货单：";
            //        navBarGroup7.Caption = string.Format("{0}{1}", tipa, list.Count);
            //        navBarGroup7.Appearance.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        tipa = "待处理移货单：";
            //        navBarGroup7.Caption = string.Format("{0}{1}", tipa, list.Count);
            //    }
            //    lbTBList.Items.Clear();
            //    foreach (TransferBill transferBill in list)
            //    {
            //        lbTBList.Items.Add(transferBill.TransferBillCode);
            //    }
            //}
        }

        private void ShowQCGoods()
        {
            //BllResult bllResult;
            //int locksType = ServiceHelper.FacadeService.GetDictionaryByCode("6503").DictionaryId;
            //int lockReasonQC = ServiceHelper.FacadeService.GetDictionaryByCode("6802").DictionaryId;
            //string condtion = string.Format("LockType = {0} and LockReason = {1}", locksType, lockReasonQC);
            //ArrayList list = GenericServiceHelper.GetListByCondition<Lock>(out bllResult, condtion);
            //if (list != null && list.Count > 0)
            //{
            //    gridQC.DataSource = list;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit AuditorLookup =
            //        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    AuditorLookup.DataSource = BusinessKit.GetAllUser();
            //    AuditorLookup.DisplayMember = "UserName";
            //    AuditorLookup.ValueMember = "UserID";
            //    gridViewQC.Columns["Operator"].ColumnEdit = AuditorLookup;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LocationIDLookup =
            //        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    LocationIDLookup.DataSource = ClientCacheHelper.LoadCache(CacheType.Location);
            //    LocationIDLookup.DisplayMember = "LocationName";
            //    LocationIDLookup.ValueMember = "LocationId";
            //    gridViewQC.Columns["LocationID"].ColumnEdit = LocationIDLookup;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ContainerIDLookup =
            //        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    ContainerIDLookup.DataSource = ClientCacheHelper.LoadCache(CacheType.StorageUnit);
            //    ContainerIDLookup.DisplayMember = "ContainerName";
            //    ContainerIDLookup.ValueMember = "ContainerID";
            //    gridViewQC.Columns["ContainerID"].ColumnEdit = ContainerIDLookup;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Lookup1 =
            //        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    Lookup1.DataSource = ClientCacheHelper.LoadCache(CacheType.DataDictionary);
            //    Lookup1.DisplayMember = "DictionaryValue";
            //    Lookup1.ValueMember = "DictionaryID";
            //    gridViewQC.Columns["LockType"].ColumnEdit = Lookup1;
            //    gridViewQC.Columns["LockReason"].ColumnEdit = Lookup1;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit GoodsPacketLookup =
            //  new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    GoodsPacketLookup.DataSource = BusinessKit.GetAllPacket();
            //    GoodsPacketLookup.DisplayMember = "MeasureName";
            //    GoodsPacketLookup.ValueMember = "MeasureID";

            //    string tipa = GlobalState.LanguageHelper.GetLanguageString("user", "last_lockout_date_tip");
            //    gridViewQC.Columns["LockDate"].Caption = tipa;
            //    gridViewQC.Columns["LockDate"].Width = 80;
            //    gridViewQC.Columns["LockDate"].VisibleIndex = 0;
            //    gridViewQC.Columns["LockDate"].Visible = true;
            //    gridViewQC.Columns["LockDate"].DisplayFormat.FormatType = FormatType.DateTime;
            //    gridViewQC.Columns["LockDate"].DisplayFormat.FormatString = "yyyy-MM-dd";

            //    tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanDetailForm", "caption_GoodsCode");
            //    gridViewQC.Columns["GoodsCode"].Caption = tipa;
            //    gridViewQC.Columns["GoodsCode"].Width = 80;
            //    gridViewQC.Columns["GoodsCode"].VisibleIndex = 1;
            //    gridViewQC.Columns["GoodsCode"].Visible = true;

            //    tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanDetailForm", "caption_GoodsName");
            //    gridViewQC.Columns["GoodsName"].Caption = tipa;
            //    gridViewQC.Columns["GoodsName"].Width = 80;
            //    gridViewQC.Columns["GoodsName"].VisibleIndex = 2;
            //    gridViewQC.Columns["GoodsName"].Visible = true;

            //    tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanDetailForm", "caption_GoodsPacket");
            //    gridViewQC.Columns["GoodsPacket"].Caption = tipa;
            //    gridViewQC.Columns["GoodsPacket"].Width = 80;
            //    gridViewQC.Columns["GoodsPacket"].VisibleIndex = 3;
            //    gridViewQC.Columns["GoodsPacket"].Visible = true;
            //    gridViewQC.Columns["GoodsPacket"].ColumnEdit = GoodsPacketLookup;

            //    tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanDetailForm", "caption_Quantity");
            //    gridViewQC.Columns["Quantity"].Caption = tipa;
            //    gridViewQC.Columns["Quantity"].Width = 80;
            //    gridViewQC.Columns["Quantity"].VisibleIndex = 4;
            //    gridViewQC.Columns["Quantity"].Visible = true;

            //    gridViewQC.Columns["BillType"].Visible = false;
            //    gridViewQC.Columns["BillID"].Visible = false;
            //    gridViewQC.Columns["JobID"].Visible = false;
            //    gridViewQC.Columns["InstrunctionID"].Visible = false;
            //    gridViewQC.Columns["LockMode"].Visible = false;
            //    gridViewQC.Columns["LockReason"].Visible = false;
            //    gridViewQC.Columns["PermitReceivingGoods"].Visible = false;
            //    gridViewQC.Columns["PermitTransferingGoods"].Visible = false;
            //    gridViewQC.Columns["PermitPutaway"].Visible = false;
            //    gridViewQC.Columns["PermitPickingGoods"].Visible = false;
            //    gridViewQC.Columns["PermitingCountingGoods"].Visible = false;
            //    gridViewQC.Columns["PermitingDeliveringGoods"].Visible = false;
            //    gridViewQC.Columns["Description"].Visible = false;
            //    gridViewQC.Columns["LockID"].Visible = false;
            //    gridViewQC.Columns["LockType"].Visible = false;
            //    gridViewQC.Columns["LockObject"].Visible = false;
            //    gridViewQC.Columns["LocationID"].Visible = false;
            //    gridViewQC.Columns["ContainerID"].Visible = false;
            //    gridViewQC.Columns["Operator"].Visible = false;
            //    gridViewQC.Columns["GoodsID"].Visible = false;
            //}
        }

        private void ShowLocksGoods()
        {
            //BLLResult bllResult;
            //int locksType = BLLHelper.facadeBL.GetDictionaryByCode("6503").DictionaryID;
            //int lockReasonQC = BLLHelper.facadeBL.GetDictionaryByCode("6802").DictionaryID;
            //string condtion = string.Format("LockType = {0} and LockReason <> {1}", locksType, lockReasonQC);
            //ArrayList list = GenericBLHelper.GetByCondition<Lock>(out bllResult, condtion);
            //if (list != null && list.Count > 0)
            //{
            //    gridLocks.DataSource = list;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit AuditorLookup =
            //        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    AuditorLookup.DataSource = BusinessKit.GetAllUsers();
            //    AuditorLookup.DisplayMember = "UserName";
            //    AuditorLookup.ValueMember = "UserID";
            //    gridViewLocks.Columns["Operator"].ColumnEdit = AuditorLookup;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LocationIDLookup =
            //        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    LocationIDLookup.DataSource = BusinessKit.GetAllLocations();
            //    LocationIDLookup.DisplayMember = "LocationName";
            //    LocationIDLookup.ValueMember = "LocationID";
            //    gridViewLocks.Columns["LocationID"].ColumnEdit = LocationIDLookup;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ContainerIDLookup =
            //        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    ContainerIDLookup.DataSource = BusinessKit.GetAllStorageUnits();
            //    ContainerIDLookup.DisplayMember = "ContainerName";
            //    ContainerIDLookup.ValueMember = "ContainerID";
            //    gridViewLocks.Columns["ContainerID"].ColumnEdit = ContainerIDLookup;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Lookup1 =
            //        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    Lookup1.DataSource = BusinessKit.GetAllDictionaries();
            //    Lookup1.DisplayMember = "DictionaryValue";
            //    Lookup1.ValueMember = "DictionaryID";
            //    gridViewLocks.Columns["LockType"].ColumnEdit = Lookup1;
            //    gridViewLocks.Columns["LockReason"].ColumnEdit = Lookup1;

            //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit GoodsPacketLookup = 
            //        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //    GoodsPacketLookup.DataSource = BusinessKit.GetGoodsPacketList();
            //    GoodsPacketLookup.DisplayMember = "MeasureName";
            //    GoodsPacketLookup.ValueMember = "MeasureID";

            //    string tipa = GlobalState.LanguageHelper.GetLanguageString("user", "last_lockout_date_tip");
            //    gridViewLocks.Columns["LockDate"].Caption = tipa;
            //    gridViewLocks.Columns["LockDate"].Width = 80;
            //    gridViewLocks.Columns["LockDate"].VisibleIndex = 0;
            //    gridViewLocks.Columns["LockDate"].Visible = true;
            //    gridViewLocks.Columns["LockDate"].DisplayFormat.FormatType = FormatType.DateTime;
            //    gridViewLocks.Columns["LockDate"].DisplayFormat.FormatString = "yyyy-MM-dd";

            //    tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanDetailForm", "caption_GoodsCode");
            //    gridViewLocks.Columns["GoodsCode"].Caption = tipa;
            //    gridViewLocks.Columns["GoodsCode"].Width = 80;
            //    gridViewLocks.Columns["GoodsCode"].VisibleIndex = 1;
            //    gridViewLocks.Columns["GoodsCode"].Visible = true;

            //    tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanDetailForm", "caption_GoodsName");
            //    gridViewLocks.Columns["GoodsName"].Caption = tipa;
            //    gridViewLocks.Columns["GoodsName"].Width = 80;
            //    gridViewLocks.Columns["GoodsName"].VisibleIndex = 2;
            //    gridViewLocks.Columns["GoodsName"].Visible = true;

            //    tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanDetailForm", "caption_GoodsPacket");
            //    gridViewLocks.Columns["GoodsPacket"].Caption = tipa;
            //    gridViewLocks.Columns["GoodsPacket"].Width = 80;
            //    gridViewLocks.Columns["GoodsPacket"].VisibleIndex = 3;
            //    gridViewLocks.Columns["GoodsPacket"].Visible = true;
            //    gridViewLocks.Columns["GoodsPacket"].ColumnEdit = GoodsPacketLookup;

            //    tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanDetailForm", "caption_Quantity");
            //    gridViewLocks.Columns["Quantity"].Caption = tipa;
            //    gridViewLocks.Columns["Quantity"].Width = 80;
            //    gridViewLocks.Columns["Quantity"].VisibleIndex = 4;
            //    gridViewLocks.Columns["Quantity"].Visible = true;

            //    gridViewLocks.Columns["LockID"].Visible = false;
            //    gridViewLocks.Columns["LockType"].Visible = false;
            //    gridViewLocks.Columns["Operator"].Visible = false;
            //    gridViewLocks.Columns["LockObject"].Visible = false;
            //    gridViewLocks.Columns["LocationID"].Visible = false;
            //    gridViewLocks.Columns["ContainerID"].Visible = false;
            //    gridViewLocks.Columns["GoodsID"].Visible = false;
            //    gridViewLocks.Columns["BillType"].Visible = false;
            //    gridViewLocks.Columns["BillID"].Visible = false;
            //    gridViewLocks.Columns["JobID"].Visible = false;
            //    gridViewLocks.Columns["InstrunctionID"].Visible = false;
            //    gridViewLocks.Columns["LockMode"].Visible = false;
            //    gridViewLocks.Columns["LockReason"].Visible = false;
            //    gridViewLocks.Columns["PermitReceivingGoods"].Visible = false;
            //    gridViewLocks.Columns["PermitTransferingGoods"].Visible = false;
            //    gridViewLocks.Columns["PermitPutaway"].Visible = false;
            //    gridViewLocks.Columns["PermitPickingGoods"].Visible = false;
            //    gridViewLocks.Columns["PermitingCountingGoods"].Visible = false;
            //    gridViewLocks.Columns["PermitingDeliveringGoods"].Visible = false;
            //    gridViewLocks.Columns["Description"].Visible = false;
            //}
        }

        private void PortalView_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void lbIPList_DoubleClick(object sender, EventArgs e)
        {
            //BllResult bllResult;
            //string inboundPlanCode;
            //if (lbIPList.SelectedItem != null)
            //{
            //    inboundPlanCode = (string)lbIPList.SelectedItem;
            //    string condition = string.Format("InboundPlanCode = '" + inboundPlanCode + "'");
            //    ArrayList list = GenericServiceHelper.GetListByCondition<InboundPlan>(out bllResult, condition);
            //    if (list != null && list.Count > 0)
            //        MyWorkItem.RootWorkItem.State["SO"] = list[0] as InboundPlan;
            //    else
            //        MyWorkItem.RootWorkItem.State["SO"] = null;

            //    MyWorkItem.Commands["Modules.InboundPlan.ShowFormPop"].Execute();
            //}
        }

        private void lbIBList_DoubleClick(object sender, EventArgs e)
        {
            //BllResult bllResult;
            //string inboundBillCode;
            //if (lbIBList.SelectedItem != null)
            //{
            //    inboundBillCode = (string)lbIBList.SelectedItem;
            //    string condition = string.Format("InboundBillCode = '" + inboundBillCode + "'");
            //    ArrayList list = GenericServiceHelper.GetListByCondition<InboundBill>(out bllResult, condition);
            //    if (list != null && list.Count > 0)
            //        MyWorkItem.RootWorkItem.State["IB"] = list[0] as InboundBill;
            //    else
            //        MyWorkItem.RootWorkItem.State["IB"] = null;

            //    MyWorkItem.Commands["Modules.InboundBill.ShowFormPop"].Execute();
            //}
        }

        private void lbOPList_DoubleClick(object sender, EventArgs e)
        {
            //BllResult bllResult;
            //string outboundBillPlan;
            //if (lbOPList.SelectedItem != null)
            //{
            //    outboundBillPlan = (string)lbOPList.SelectedItem;
            //    string condition = string.Format("OutboundPlanCode = '" + outboundBillPlan + "'");
            //    ArrayList list = GenericServiceHelper.GetListByCondition<OutboundPlan>(out bllResult, condition);
            //    if (list != null && list.Count > 0)
            //        MyWorkItem.RootWorkItem.State["OP"] = list[0] as OutboundPlan;
            //    else
            //        MyWorkItem.RootWorkItem.State["OP"] = null;

            //    MyWorkItem.Commands["Modules.OutboundPlan.ShowFormPop"].Execute();
            //}
        }

        private void lbPLList_DoubleClick(object sender, EventArgs e)
        {
            //BllResult bllResult;
            //string pickBillCode;
            //if (lbPLList.SelectedItem != null)
            //{
            //    pickBillCode = (string)lbPLList.SelectedItem;
            //    string condition = string.Format("PickBillCode = '" + pickBillCode + "'");
            //    ArrayList list = GenericServiceHelper.GetListByCondition<PickBill>(out bllResult, condition);
            //    if (list != null && list.Count > 0)
            //        MyWorkItem.RootWorkItem.State["PB"] = list[0] as PickBill;
            //    else
            //        MyWorkItem.RootWorkItem.State["PB"] = null;

            //    MyWorkItem.Commands["Modules.PickBill.ShowFormPop"].Execute();
            //}
        }

        private void lbOBList_DoubleClick(object sender, EventArgs e)
        {
            //BllResult bllResult;
            //string outboundBillCode;
            //if (lbOBList.SelectedItem != null)
            //{
            //    outboundBillCode = lbOBList.SelectedItem.ToString();
            //    string condition = string.Format("OutboundBillCode = '" + outboundBillCode + "'");
            //    ArrayList list = GenericServiceHelper.GetListByCondition<OutboundBill>(out bllResult, condition);
            //    if (list != null && list.Count > 0)
            //        MyWorkItem.RootWorkItem.State["OB"] = list[0] as OutboundBill;
            //    else
            //        MyWorkItem.RootWorkItem.State["OB"] = null;

            //    MyWorkItem.Commands["Modules.OutboundBill.ShowFormPop"].Execute();
            //}

        }

        private void lbCounting_DoubleClick(object sender, EventArgs e)
        {
            //BllResult bllResult;
            //string countBillCode;
            //if (lbCounting.SelectedItem != null)
            //{
            //    countBillCode = lbCounting.SelectedItem.ToString();
            //    string condition = string.Format("CountBillCode = '" + countBillCode + "'");
            //    ArrayList list = GenericServiceHelper.GetListByCondition<CountBill>(out bllResult, condition);
            //    if (list != null && list.Count > 0)
            //        MyWorkItem.RootWorkItem.State["CB"] = list[0] as CountBill;
            //    else
            //        MyWorkItem.RootWorkItem.State["CB"] = null;

            //    MyWorkItem.Commands["Modules.CountBill.ShowFormPop"].Execute();
            //}
        }

        private void lbTBList_DoubleClick(object sender, EventArgs e)
        {
            //BllResult bllResult;
            //string transferBillCode;
            //if (lbTBList.SelectedItem != null)
            //{
            //    transferBillCode = lbTBList.SelectedItem.ToString();
            //    string condition = string.Format("TransferBillCode = '" + transferBillCode + "'");
            //    ArrayList list = GenericServiceHelper.GetListByCondition<TransferBill>(out bllResult, condition);
            //    if (list != null && list.Count > 0)
            //        MyWorkItem.RootWorkItem.State["TB"] = list[0] as TransferBill;
            //    else
            //        MyWorkItem.RootWorkItem.State["TB"] = null;

            //    MyWorkItem.Commands["Modules.TransferBill.ShowFormPop"].Execute();
            //}
        }
    }
}
