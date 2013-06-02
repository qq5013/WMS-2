using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using Frame.Utils.Service;
using MES.BllService;
using MES.Entity;
using MES.Execute.Common;
using MES.Execute.Properties;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 入库单编辑
    /// </summary>
    public partial class UcInbound : UserControl, IInitControl, ICheckClosing
    {
        /// <summary>
        /// 是否物料
        /// </summary>
        private bool _isMateriel;

        public UcInbound()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 入库类型
        /// </summary>
        public InboundType InboundType { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public Inbound Data { get; set; }

        /// <summary>
        /// 当前Sku信息
        /// </summary>
        public SkuInfo CurrentSkuInfo { get; set; }

        /// <summary>
        /// 允许修改
        /// </summary>
        public bool AllowEdit { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 是否检查出库单是否存在
        /// </summary>
        private bool CheckOutbound { get; set; }

        /// <summary>
        /// 入库单明细Service
        /// </summary>
        public IEntityService<InboundDetail> InboundDetailService
        {
            get { return ServiceHelper.GetService<InboundDetail>(); }
        }

        /// <summary>
        /// 入库单明细追踪Service
        /// </summary>
        public IEntityService<InboundDetailTrace> InboundDetailTraceService
        {
            get { return ServiceHelper.GetService<InboundDetailTrace>(); }
        }

        /// <summary>
        /// 入库单Service
        /// </summary>
        private IEntityService<Inbound> InboundService
        {
            get { return ServiceHelper.GetService<Inbound>(); }
        }

        /// <summary>
        /// 出库单明细追踪服务
        /// </summary>
        private IEntityService<OutboundDetailTrace> OutboundDetailTraceService
        {
            get { return ServiceHelper.GetService<OutboundDetailTrace>(); }
        }

        /// <summary>
        /// 出库单明细服务
        /// </summary>
        private IEntityService<OutboundDetail> OutboundDetailService
        {
            get { return ServiceHelper.GetService<OutboundDetail>(); }
        }

        /// <summary>
        /// 出库单服务
        /// </summary>
        private IEntityService<Outbound> OutboundService
        {
            get { return ServiceHelper.GetService<Outbound>(); }
        }

        /// <summary>
        /// 库存Service
        /// </summary>
        private IEntityService<Storage> StorageService
        {
            get { return ServiceHelper.GetService<Storage>(); }
        }

        /// <summary>
        /// 库位Service
        /// </summary>
        private IEntityService<Location> LocationService
        {
            get { return ServiceHelper.GetService<Location>(); }
        }

        /// <summary>
        /// 销售订单Service
        /// </summary>
        private IEntityService<SalesOrder> SalesOrderService
        {
            get { return ServiceHelper.GetService<SalesOrder>(); }
        }

        /// <summary>
        /// 生产工单Service
        /// </summary>
        private IEntityService<ProductionOrder> ProductionOrderService
        {
            get { return ServiceHelper.GetService<ProductionOrder>(); }
        }

        /// <summary>
        /// 生产计划Service
        /// </summary>
        private IEntityService<ProductionPlan> ProductionPlanService
        {
            get { return ServiceHelper.GetService<ProductionPlan>(); }
        }

        /// <summary>
        /// 采购订单Service
        /// </summary>
        private IEntityService<PurchaseOrder> PurchaseOrderService
        {
            get { return ServiceHelper.GetService<PurchaseOrder>(); }
        }

        #region ICheckClosing Members

        /// <summary>
        /// 数据变更
        /// </summary>
        public bool DataChanged { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // 将控件中的数据存到Datasource
            gridControl1.MainView.PostEditor();

            // 如果数据不存在则不能保存
            if (Data == null)
            {
                return false;
            }

            // 从控件中加载数据
            Data.LoadData(Controls);
            // 设置入库类型
            Data.Type = InboundType;
            // 保存
            int inboundId = InboundService.Save(Data);
            if (Data.InboundId == 0)
            {
                // 设置入库单号
                Data.InboundId = inboundId;
            }
            // 清楚被删除的明细
            foreach (InboundDetail detail in Data.RemoveList)
            {
                // 根据Id删除不要的入库单明细
                if (detail.GetEntityId() > 0)
                    detail.Remove();
            }
            // 清空临时Remove列表
            Data.RemoveList.Clear();
            // 保存明细
            foreach (InboundDetail detail in Data.Details)
            {
                // 设置明细中的主表Id
                detail.InboundId = Data.InboundId;
                int inboundDetailId = InboundDetailService.Save(detail);
                if (detail.InboundDetailId == 0)
                {
                    // 设置主键
                    detail.InboundDetailId = inboundDetailId;
                }
                // 保存明细追踪
                foreach (InboundDetailTrace detailTrace in detail.Details)
                {
                    // 设置追踪表中的明细表Id
                    detailTrace.InboundDetaiId = detail.InboundDetailId;
                    // 保存追踪表
                    int inboundDetailTraceId = InboundDetailTraceService.Save(detailTrace);

                    if (detailTrace.InboundDetailTraceId == 0) // 保存追踪表主键
                        detailTrace.InboundDetailTraceId = inboundDetailTraceId;
                }
            }
            // 保存完成后将复位到数据未更改状态
            DataChanged = false;
            // 返回保存成功
            return true;
        }

        #endregion

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            barManager2.Form = groupControl1;

            //验收员
            glueInspector.BindUser(ControlMode.Edit,
                                   new List<string>
                                       {
                                           "purchase",
                                           // 采购员
                                           "centerWarehosue",
                                           // 中心仓库
                                           "workshopWarehouse",
                                           // 车间仓库
                                           "productWarehouse",
                                           // 成品仓库
                                           "purchase",
                                           // 采购员，duplicate
                                           "qualityManagement",
                                           // 质检
                                           "administrators" //管理员
                                       });
            // 设置验收员为当前用户
            glueInspector.EditValue = CommonApi.CurrentUser().UserId;

            //入库类型
            glueType.Bind<InboundType>(ControlMode.Edit);
            // 设置入库类型为传入类型
            glueType.EditValue = InboundType;
            // 不可更改
            glueType.Properties.ReadOnly = true;
            //仓库
            glueWarehouse.BindWarehouse(ControlMode.Edit);
            // 设置仓库为当前仓库
            glueWarehouse.EditValue = WarehouseId;
            // 只读
            glueWarehouse.Properties.ReadOnly = true;

            //打印条码按钮
            btnPrintBarcode.Visibility = BarItemVisibility.Never;
            bandedGridColumn12.Visible = false;

            deReceiveTime.EditValue = DateTimeHelper.Now;

            riglueLocation.BindLocation(WarehouseId);

            // 根据不同的参数绑定不同的控件和反映效果
            switch (InboundType)
            {
                case InboundType.Purchase:
                    lblPreOrderType.Text = Resources.RelaPurchaseOrder;
                    beRelationCode.BindOrder<UcPurchaseOrderManage>("选择采购申请单", code =>
                                                                                   {
                                                                                       beRelationCode.Text = code;
                                                                                       List<int> skus = null;
                                                                                       List<PurchaseOrderDetail> details
                                                                                           = null;
                                                                                       if (!string.IsNullOrEmpty(code))
                                                                                       {
                                                                                           PurchaseOrder purchaseOrder =
                                                                                               ServiceHelper.GetService
                                                                                                   <PurchaseOrder>().
                                                                                                   Find(
                                                                                                       c =>
                                                                                                       c.
                                                                                                           PurchasePlanCode ==
                                                                                                       code);


                                                                                           if (purchaseOrder != null)
                                                                                           {
                                                                                               glueSourceUnit.EditValue
                                                                                                   =
                                                                                                   purchaseOrder.
                                                                                                       VendorId;
                                                                                               details =
                                                                                                   ServiceHelper.
                                                                                                       GetService
                                                                                                       <
                                                                                                           PurchaseOrderDetail
                                                                                                           >().FindAll(
                                                                                                               c =>
                                                                                                               c.
                                                                                                                   PurchaseOrderId ==
                                                                                                               purchaseOrder
                                                                                                                   .
                                                                                                                   PurchaseOrderId,
                                                                                                               null);
                                                                                               skus =
                                                                                                   details.Select(
                                                                                                       c => c.SkuId).
                                                                                                       ToList();
                                                                                           }
                                                                                       }

                                                                                       if (skus != null &&
                                                                                           skus.Count > 0)
                                                                                       {
                                                                                           List<SkuInfo> skuInfos = ServiceHelper
                                                                                               .GetQuery<SkuInfo>().
                                                                                               FindAll(t =>
                                                                                                       skus.Contains(
                                                                                                           t.SkuId) &&
                                                                                                       t.TraceType ==
                                                                                                       TraceType.None,
                                                                                                       null);

                                                                                           List<int> list =
                                                                                               ServiceHelper.GetService
                                                                                                   <Inbound>().FindAll(
                                                                                                       c =>
                                                                                                       c.RelationCode ==
                                                                                                       code &&
                                                                                                       c.Status ==
                                                                                                       InboundStatus.
                                                                                                           Finished &&
                                                                                                       c.InboundId !=
                                                                                                       Data.InboundId,
                                                                                                       null).Select(
                                                                                                           c =>
                                                                                                           c.InboundId).
                                                                                                   ToList();

                                                                                           if (list.Count > 0)
                                                                                           {
                                                                                               foreach (
                                                                                                   InboundDetail
                                                                                                       inboundDetail in
                                                                                                       ServiceHelper.
                                                                                                           GetService
                                                                                                           <
                                                                                                               InboundDetail
                                                                                                               >().
                                                                                                           FindAll(
                                                                                                               c =>
                                                                                                               list.
                                                                                                                   Contains
                                                                                                                   (c.
                                                                                                                        InboundId),
                                                                                                               null))
                                                                                               {
                                                                                                   InboundDetail detail
                                                                                                       = inboundDetail;
                                                                                                   PurchaseOrderDetail
                                                                                                       purchaseOrderDetail
                                                                                                           =
                                                                                                           details.Find(
                                                                                                               c =>
                                                                                                               c.SkuId ==
                                                                                                               detail.
                                                                                                                   SkuId);
                                                                                                   if (
                                                                                                       purchaseOrderDetail !=
                                                                                                       null)
                                                                                                   {
                                                                                                       purchaseOrderDetail
                                                                                                           .Quantity -=
                                                                                                           inboundDetail
                                                                                                               .Quantity;
                                                                                                   }
                                                                                               }
                                                                                           }
                                                                                           // 如果选择了采购订单，将采购订单中的物流导入入库单
                                                                                           foreach (
                                                                                               SkuInfo skuInfo in
                                                                                                   skuInfos)
                                                                                           {
                                                                                               SkuInfo info = skuInfo;
                                                                                               PurchaseOrderDetail
                                                                                                   purchaseOrderDetail =
                                                                                                       details.Find(
                                                                                                           c =>
                                                                                                           c.SkuId ==
                                                                                                           info.SkuId);
                                                                                               if (
                                                                                                   purchaseOrderDetail !=
                                                                                                   null &&
                                                                                                   purchaseOrderDetail.
                                                                                                       Quantity > 0)
                                                                                                   ImportCode(skuInfo,
                                                                                                              skuInfo.
                                                                                                                  Code,
                                                                                                              "00000", 1,
                                                                                                              purchaseOrderDetail
                                                                                                                  .
                                                                                                                  Quantity,
                                                                                                              error => { });
                                                                                           }
                                                                                       }
                                                                                   }, null, null);

                    lblSourceUnit.Text = Resources.Vendor;
                    glueSourceUnit.BindVendor(ControlMode.Query);

                    lblDeliverDep.Text = "提交部门";
                    glueDeliverDep.BindDepartment(ControlMode.Query);

                    lblSender.Text = "零部件提交人";
                    glueDeliverMan.BindUser(ControlMode.Query, null);


                    dxValidationProvider1.SetValidationRule(beRelationCode, null);
                    markRelationCode.Visible = false;

                    //打印条码按钮
                    btnPrintBarcode.Visibility = BarItemVisibility.Always;
                    bandedGridColumn12.Visible = true;
                    _isMateriel = true;
                    bandedGridColumn14.Visible = true;
                    break;
                case InboundType.Material:
                    lblPreOrderType.Text = Resources.RelaOutbound;
                    beRelationCode.BindOrder<UcOutboundManage>("选择出库单号",
                                                               code =>
                                                                   {
                                                                       beRelationCode.Text = code;
                                                                       BindOutbind(code);
                                                                   }, new[] {(int) OutboundType.Material},
                                                               new[] {(int) OutboundStatus.Finished});

                    CheckOutbound = true;

                    lblSourceUnit.Text = "发货仓库";
                    glueSourceUnit.BindWarehouse(ControlMode.Edit);
                    glueSourceUnit.EditValue = 1;
                    glueSourceUnit.Properties.ReadOnly = true;


                    lblDeliverDep.Visible = false;
                    glueDeliverDep.Visible = false;

                    lblSender.Text = "发料人";
                    glueDeliverMan.BindUser(ControlMode.Query, null);

                    dxValidationProvider1.SetValidationRule(beRelationCode, null);
                    markRelationCode.Visible = true;
                    //添加物料按钮不显示
                    bar3.Visible = false;
                    _isMateriel = true;
                    break;
                case InboundType.ReturnMaterial:

                    lblPreOrderType.Text = Resources.RelaProductionPlan;
                    beRelationCode.BindOrder<UcProductionPlanManage>("选择生产计划单号");

                    lblSourceUnit.Text = "退货产线";
                    glueSourceUnit.BindWorkShop(ControlMode.Edit);
                    glueSourceUnit.EditValue = 1;
                    glueSourceUnit.Properties.ReadOnly = true;

                    lblDeliverDep.Visible = false;
                    glueDeliverDep.Visible = false;

                    lblSender.Text = "退料人";
                    glueDeliverMan.BindUser(ControlMode.Query, null);
                    dxValidationProvider1.SetValidationRule(beRelationCode, null);
                    markRelationCode.Visible = false;
                    _isMateriel = true;
                    break;
                case InboundType.Product:

                    lblPreOrderType.Text = Resources.RelaProductionOrder;
                    beRelationCode.BindOrder<UcProductionOrderManage>("选择生产工单号");

                    lblSourceUnit.Text = Resources.ProductLine;
                    glueSourceUnit.BindWorkShop(ControlMode.Edit);
                    glueSourceUnit.EditValue = 1;
                    glueSourceUnit.Properties.ReadOnly = true;

                    lblDeliverDep.Visible = false;
                    glueDeliverDep.Visible = false;

                    lblSender.Text = "提交人";
                    glueDeliverMan.BindUser(ControlMode.Query, null);
                    dxValidationProvider1.SetValidationRule(beRelationCode, null);
                    markRelationCode.Visible = false;

                    _isMateriel = false;
                    break;
                case InboundType.ReturnProduct:
                    lblPreOrderType.Text = Resources.RelaSalesOrder;
                    beRelationCode.BindOrder<UcSalesOrderManage>("选择销售订单号");

                    lblSourceUnit.Text = "退货单位";
                    glueSourceUnit.BindCustomer(ControlMode.Edit);

                    lblDeliverDep.Visible = false;
                    glueDeliverDep.Visible = false;

                    lblSender.Visible = false;
                    glueDeliverMan.Visible = false;

                    dxValidationProvider1.SetValidationRule(beRelationCode, null);
                    markRelationCode.Visible = false;

                    _isMateriel = false;
                    break;
                case InboundType.ReturnMaterialToCenter:

                    lblPreOrderType.Text = Resources.RelaOutbound;
                    beRelationCode.BindOrder<UcOutboundManage>("选择出库单号",
                                                               code =>
                                                                   {
                                                                       beRelationCode.Text = code;
                                                                       BindOutbind(code);
                                                                   }, new[] {(int) OutboundType.BackCenter},
                                                               new[] {(int) OutboundStatus.Finished});

                    //CheckOutbound = true;
                    lblSourceUnit.Text = "退货部门";
                    glueSourceUnit.BindDepartment(ControlMode.Edit);

                    // 针对 中心仓库的 退料入库 （车间仓库=〉中心仓库）
                    //julio: 1.必须输入项目检查，[关联出库单号] 如果选择[控制器车间仓库]时，要求[关联出库单号]为必填项目，如果选择其他部门，则要求[关联出库单号]为空。
                    //julio: 2.[关联出库单号],可以输入，也可以通过弹出选择框来选择。如果选择了关联出库单号，退料成功入库后，该关联出库单号的状态由[出库]变为[完成]
                    //julio: 3.[扫描入库]按钮，如果选择[控制器车间仓库]时，此按钮不可用，物料只能通过关联入库单号取得。
                    //julio: 4.[入库数量] 如果选择[控制器车间仓库]时，不可输入，通过关联单号取得。
                    beRelationCode.Properties.ReadOnly = true;
                    beRelationCode.Properties.Buttons[0].Enabled = false;
                    glueSourceUnit.EditValueChanged += (sender, e) =>
                                                           {
                                                               var department =
                                                                   glueSourceUnit.GetSelectedDataRow() as Department;
                                                               bool isWorkShop = department != null &&
                                                                                 string.Compare(
                                                                                     department.Code,
                                                                                     "1000C",
                                                                                     StringComparison.
                                                                                         CurrentCultureIgnoreCase) ==
                                                                                 0;
                                                               beRelationCode.Properties.Buttons[0].Enabled = isWorkShop;
                                                               btnAdd.Enabled = !isWorkShop;
                                                               btnRemove.Enabled = !isWorkShop;
                                                               barButtonItem5.Enabled = !isWorkShop;
                                                               btnChangeQuantity.Enabled = !isWorkShop;
                                                               markRelationCode.Visible = isWorkShop;
                                                               CheckOutbound = isWorkShop;
                                                           };


                    lblDeliverDep.Visible = false;
                    glueDeliverDep.Visible = false;

                    lblSender.Text = "退料人";
                    glueDeliverMan.BindUser(ControlMode.Query, null);
                    dxValidationProvider1.SetValidationRule(beRelationCode, null);
                    markRelationCode.Visible = true;

                    _isMateriel = true;

                    break;
                case InboundType.CenterAdjust:
                case InboundType.PlantAdjust:

                    lblPreOrderType.Visible = false;
                    beRelationCode.Visible = false;


                    lblSourceUnit.Visible = false;
                    glueSourceUnit.Visible = false;

                    lblDeliverDep.Visible = false;
                    glueDeliverDep.Visible = false;

                    lblSender.Text = "盘点人";
                    glueDeliverMan.BindUser(ControlMode.Query, null);
                    dxValidationProvider1.SetValidationRule(beRelationCode, null);

                    dxValidationProvider1.SetValidationRule(beRelationCode, null);
                    markRelationCode.Visible = false;
                    dxValidationProvider1.SetValidationRule(glueSourceUnit, null);
                    markVendor.Visible = false;

                    _isMateriel = true;

                    break;
                case InboundType.ProductAdjust:
                    lblPreOrderType.Visible = false;
                    beRelationCode.Visible = false;

                    lblSourceUnit.Visible = false;
                    glueSourceUnit.Visible = false;

                    lblDeliverDep.Visible = false;
                    glueDeliverDep.Visible = false;

                    lblSender.Text = "盘点人";
                    glueDeliverMan.BindUser(ControlMode.Query, null);
                    dxValidationProvider1.SetValidationRule(beRelationCode, null);
                    markRelationCode.Visible = false;
                    dxValidationProvider1.SetValidationRule(glueSourceUnit, null);
                    markVendor.Visible = false;
                    _isMateriel = false;
                    break;
                case InboundType.BackProduct:
                    lblPreOrderType.Text = Resources.RelaOutbound;
                    beRelationCode.BindOrder<UcOutboundManage>("选择出库单号",
                                                               code =>
                                                                   {
                                                                       beRelationCode.Text = code;
                                                                       BindOutbind(code);
                                                                   },
                                                               new[]
                                                                   {
                                                                       (int) OutboundType.Product,
                                                                       (int) OutboundType.Inspect
                                                                   },
                                                               new[] {(int) OutboundStatus.Finished});

                    CheckOutbound = true;
                    lblSourceUnit.Text = "归还部门";
                    glueSourceUnit.BindWorkShop(ControlMode.Edit);

                    lblDeliverDep.Visible = false;
                    glueDeliverDep.Visible = false;

                    lblSender.Text = "归还人";
                    glueDeliverMan.BindUser(ControlMode.Query, null);
                    dxValidationProvider1.SetValidationRule(beRelationCode, null);
                    markRelationCode.Visible = true;
                    //添加物料按钮不显示
                    bar3.Visible = false;
                    _isMateriel = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (!_isMateriel)
            {
                // 产品不能直接添加和修改数量
                btnAdd.Visibility = BarItemVisibility.Never;
                btnChangeQuantity.Visibility = BarItemVisibility.Never;
            }

            // 绑定Sku
            CommonApi.BindSku(riglueSkuCategoryName, riglueSkuName, riglueSkuCode, riglueSkuSpec, riglueSkuModel,
                              riglueSkuColor, _isMateriel);

            if (Data != null) // 编辑
            {
                teCode.Properties.ReadOnly = true;
                if (Data.Status != InboundStatus.Created)
                {
                    foreach (object control in Controls)
                    {
                        if (control is GridLookUpEdit)
                        {
                            ((GridLookUpEdit) control).Properties.ReadOnly = true;
                        }
                        else if (control is TextEdit)
                        {
                            ((TextEdit) control).Properties.ReadOnly = true;
                        }
                        else if (control is CheckEdit)
                        {
                            ((CheckEdit) control).Properties.ReadOnly = true;
                        }
                    }
                    bandedGridView1.OptionsBehavior.ReadOnly = true;
                    btnSave.Enabled = false;
                    btnPrintBarcode.Enabled = false;
                    barButtonItem1.Enabled = false;
                    bar3.Visible = false;
                }
                else //新建
                {
                    AllowEdit = true;
                }
                Data.FillData(Controls);

                if (InboundType == InboundType.Purchase && Convert.ToInt32(glueSourceUnit.EditValue) > 0)
                {
                    glueSourceUnit.Properties.ReadOnly = true;
                }

                if (Data.InboundId > 0)
                {
                    // 绑定明细
                    List<InboundDetail> details =
                        InboundDetailService.FindAll(c => c.InboundId == Data.InboundId, null);
                    List<int> ids = details.Select(c => c.InboundDetailId).ToList();

                    details.ForEach(c => SetStorage(c, c.TraceType, c.SkuId));

                    if (ids.Count > 0)
                    {
                        List<InboundDetailTrace> inboundDetailTraces =
                            InboundDetailTraceService.FindAll(c => ids.Contains(c.InboundDetaiId), null);
                        foreach (InboundDetailTrace detailTrace in inboundDetailTraces)
                        {
                            InboundDetailTrace trace = detailTrace;
                            InboundDetail inboundDetail = details.Find(c => c.InboundDetailId == trace.InboundDetaiId);
                            if (inboundDetail != null) inboundDetail.Details.Add(detailTrace);
                        }
                    }
                    Data.Details.Clear();
                    Data.Details.AddRange(details);
                }

                BindDetails();
            }
            else
            {
                Reset();
            }

            // 允许编辑
            if (AllowEdit)
            {
                foreach (object control in Controls)
                {
                    if (control is BaseEdit)
                    {
                        ((BaseEdit) control).EditValueChanged += (sender, e) => { DataChanged = true; };
                    }
                }
                // 数据更改时
                risePurchseQuantity.EditValueChanged += (sender, e) => { DataChanged = true; };
                rimeStorageLocation.EditValueChanged += (sender, e) => { DataChanged = true; };
                riteUseWay.EditValueChanged += (sender, e) => { DataChanged = true; };
                rimeRemark.EditValueChanged += (sender, e) => { DataChanged = true; };
            }
        }

        #endregion

        /// <summary>
        /// 绑定明细
        /// </summary>
        private void BindDetails()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = Data.Details;
        }

        /// <summary>
        /// 绑定出库单
        /// </summary>
        /// <param name="code"></param>
        private void BindOutbind(string code)
        {
            Outbound outbound = OutboundService.Find(c => c.Code == code);
            List<OutboundDetail> details =
                OutboundDetailService.FindAll(c => c.OutboundId == outbound.OutboundId, null);
            outbound.Details.AddRange(details);
            List<int> ids = outbound.Details.Select(c => c.OutboundDetailId).ToList();
            // 将出库单的信息导入入库单明细。
            if (ids.Count > 0)
            {
                List<OutboundDetailTrace> outboundDetailTraces =
                    OutboundDetailTraceService.FindAll(c => ids.Contains(c.OutboundDetaiId), null);
                foreach (OutboundDetailTrace detailTrace in outboundDetailTraces)
                {
                    OutboundDetailTrace trace = detailTrace;
                    OutboundDetail outboundDetail = details.Find(c => c.OutboundDetailId == trace.OutboundDetaiId);
                    if (outboundDetail != null) outboundDetail.Details.Add(detailTrace);
                }
            }

            Data.Details.Clear();
            foreach (OutboundDetail outboundDetail in outbound.Details)
            {
                var inboundDetail = new InboundDetail
                                        {
                                            Quantity = outboundDetail.Quantity,
                                            LotNo = outboundDetail.LotNo,
                                            MeasureId = outboundDetail.MeasureId,
                                            TraceType = outboundDetail.TraceType,
                                            SkuId = outboundDetail.SkuId
                                        };
                foreach (OutboundDetailTrace outboundDetailTrace in outboundDetail.Details)
                {
                    inboundDetail.Details.Add(new InboundDetailTrace {Code = outboundDetailTrace.Code});
                }
                SetStorage(inboundDetail, inboundDetail.TraceType, inboundDetail.SkuId);
                Data.Details.Add(inboundDetail);
            }
            BindDetails();
        }

        /// <summary>
        /// 数据清空
        /// </summary>
        private void Reset()
        {
            teCode.Text = CommonApi.GetCode<Inbound>();
            teCode.Properties.ReadOnly = true;
            AllowEdit = true;
            DataChanged = true;
            Data = new Inbound
                       {
                           CreaterId = CommonApi.CurrentUser().UserId,
                           CreateTime = DateTimeHelper.Now,
                           ReceiveTime = DateTimeHelper.Now,
                           Status = InboundStatus.Created
                       };
            Data.FillData(Controls);
            BindDetails();
        }

        private void UcInbound_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelItemClick(object sender, ItemClickEventArgs e)
        {
            DoClose();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Save())
            {
                return;
            }
            // 保存成功关闭
            if (MessageBox.Show(Resources.IsCloseAfterSaveSuccess, Resources.Notice, MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                DoClose();
            }
            else
            {
                //delete by kenny 2010/11/10
                //Reset();
            }
        }


        /// <summary>
        /// Close Form
        /// </summary>
        private void DoClose()
        {
            if (ParentForm != null) ParentForm.Close();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddItemClick(object sender, ItemClickEventArgs e)
        {
            var ucSelectSku = new UcSelectSku {CallBack = ImportCode, IsMateriel = _isMateriel};
            ucSelectSku.Init();
            // 选择不追踪的物料或者产品
            new Form
                {
                    Controls = {ucSelectSku},
                    Size = new Size(700, 280),
                    Text = _isMateriel ? Resources.AddMateriel : Resources.AddProduct
                }.Dialog();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveItemClick(object sender, ItemClickEventArgs e)
        {
            int[] selectedRows = bandedGridView1.GetSelectedRows();
            if (selectedRows != null && selectedRows.Length > 0)
            {
                List<InboundDetail> list =
                    selectedRows.Select(selectedRow => bandedGridView1.GetRow(selectedRow) as InboundDetail).ToList();

                // 删除明细
                foreach (InboundDetail detail in list)
                {
                    Data.RemoveList.Add(detail);
                    Data.Details.Remove(detail);
                }

                DataChanged = true;
                BindDetails();
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            if (Data == null)
            {
                return;
            }
            gridControl1.MainView.PostEditor();
            Data.LoadData(Controls);

            Data.GetReport(InboundType).ShowPrint();
        }

        /// <summary>
        /// 打印条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintBarcodeItemClick(object sender, ItemClickEventArgs e)
        {
            // Check Print Condition
            dxErrorProvider1.ClearErrors();
            if (null == glueSourceUnit.EditValue)
            {
                string errorText = "请先选择入库物料供应商";
                dxErrorProvider1.SetError(glueSourceUnit, errorText);
                ShowError(errorText);
                return;
            }
            List<int> skus = null;

            // 如果输入的采购订单不为空，根据采购订单获取Sku列表
            if (!string.IsNullOrEmpty(beRelationCode.Text))
            {
                PurchaseOrder purchaseOrder =
                    ServiceHelper.GetService<PurchaseOrder>().Find(c => c.PurchasePlanCode == beRelationCode.Text);
                if (purchaseOrder != null)
                {
                    skus =
                        ServiceHelper.GetService<PurchaseOrderDetail>().FindAll(
                            c => c.PurchaseOrderId == purchaseOrder.PurchaseOrderId, null).Select(c => c.SkuId).ToList();
                }
            }

            // 将采购订单中的Sku赋值给打印控件
            var ucPrintBarcode = new UcPrintBarcode
                                     {VendorId = Convert.ToInt32(glueSourceUnit.EditValue), SkuIds = skus};
            ucPrintBarcode.Init();

            new Form
                {
                    Controls = {ucPrintBarcode},
                    Size = new Size(625, 283),
                    Text = Resources.PrintMateriel
                }.Dialog();
        }

        /// <summary>
        /// 显示错误
        /// </summary>
        /// <param name="error"></param>
        private void ShowError(string error)
        {
            MessageBox.Show(error, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 输入条码
        /// </summary>
        /// <param name="skuInfo"></param>
        /// <param name="code"></param>
        /// <param name="lotNo"></param>
        /// <param name="measureId"></param>
        /// <param name="quantity"></param>
        /// <param name="showError"></param>
        private void ImportCode(SkuInfo skuInfo, string code, string lotNo, int measureId, int quantity,
                                ShowError showError)
        {
            // 解析物料
            if (_isMateriel)
            {
                InboundDetail detail = Data.Details.Find(c => c.SkuId == skuInfo.SkuId);

                if (detail == null)
                {
                    detail = new InboundDetail {SkuId = skuInfo.SkuId, TraceType = skuInfo.TraceType, LotNo = lotNo};

                    SetStorage(detail, skuInfo.TraceType, skuInfo.SkuId);

                    Data.Details.Insert(0, detail);
                }
                if (skuInfo.TraceType == TraceType.Single) //单品追踪
                {
                    if (detail.Details.Exists(c => c.Code == code))
                    {
                        showError("单品条码重复！");
                        return;
                    }
                    if (StorageService.Exists(c => c.Code == code))
                    {
                        showError("物料已在库存中！");
                        return;
                    }

                    var detailTrace = new InboundDetailTrace {Code = code, InboundDetaiId = detail.InboundDetailId};
                    detail.Details.Add(detailTrace);
                    detail.Quantity += 1;
                }
                else if (skuInfo.TraceType == TraceType.Sku) //Sku追踪
                {
                    if (detail.Details.Count == 0)
                        detail.Details.Add(new InboundDetailTrace {Code = code});
                    detail.Quantity += 1;
                }
                else // 不追踪
                {
                    if (detail.Details.Count == 0)
                        detail.Details.Add(new InboundDetailTrace {Code = code});
                    detail.Quantity += quantity;
                }

                BindDetails();
            }
            else
            {
                // 解析产品
                InboundDetail detail = Data.Details.Find(c => c.SkuId == skuInfo.SkuId);

                if (detail == null)
                {
                    detail = new InboundDetail {SkuId = skuInfo.SkuId, TraceType = skuInfo.TraceType, LotNo = lotNo};

                    SetStorage(detail, skuInfo.TraceType, skuInfo.SkuId);

                    Data.Details.Insert(0, detail);
                }
                if (detail.Details.Exists(c => c.Code == code))
                {
                    showError("单品条码重复！");
                    return;
                }
                if (StorageService.Exists(c => c.Code == code))
                {
                    showError("物料已在库存中！");
                    return;
                }


                var detailTrace = new InboundDetailTrace {Code = code, InboundDetaiId = detail.InboundDetailId};
                detail.Details.Add(detailTrace);
                detail.Quantity += 1;
                BindDetails();
            }
            DataChanged = true;
        }

        /// <summary>
        /// 设置库存
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="traceType"></param>
        /// <param name="skuId"></param>
        private void SetStorage(InboundDetail detail, TraceType traceType, int skuId)
        {
            Location location = LocationService.Find(c => c.WarehouseId == WarehouseId);
            if (location != null)
                detail.LocationId = location.LocationId;

            // 如果根据入库类型找到相应库位
            if (location != null)
            {
                switch (traceType)
                {
                    case TraceType.Single:
                        detail.SetCurrentQuantity(
                            StorageService.Count(
                                c => c.LocationId == location.LocationId && c.SkuId == skuId));
                        break;
                    case TraceType.Sku:
                        detail.SetCurrentQuantity(
                            StorageService.FindAll(
                                c => c.LocationId == location.LocationId && c.SkuId == skuId, null).Sum(c => c.Quantity));
                        break;
                    case TraceType.None:
                        detail.SetCurrentQuantity(
                            StorageService.FindAll(
                                c => c.LocationId == location.LocationId && c.SkuId == skuId, null).Sum(c => c.Quantity));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        /// <summary>
        /// 入库操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInboundItemClick(object sender, ItemClickEventArgs e)
        {
            Outbound outbound = null;
            string relationCode = beRelationCode.Text.Trim();
            // 检查关联出库单
            if (CheckOutbound)
            {
                outbound = OutboundService.Find(c => c.Code == relationCode);
                if (outbound != null)
                    switch (outbound.Status)
                    {
                        case OutboundStatus.Created:
                            ShowError("出库单" + outbound.Code + "尚未做出库");
                            return;
                        case OutboundStatus.Used:
                            ShowError("出库单" + outbound.Code + "已对应单据入库操作");
                            return;
                        case OutboundStatus.Finished:
                            break;
                        case OutboundStatus.Invalid:
                            ShowError("出库单" + outbound.Code + "已作废");
                            return;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                else
                {
                    ShowError("出库单" + relationCode + "未找到");
                    return;
                }
            }

            // 检查其他关联单据。保证选择的单据未被选择过
            if (!string.IsNullOrEmpty(relationCode))
                switch (InboundType)
                {
                    case InboundType.Purchase:
                        PurchaseOrder purchaseOrder =
                            PurchaseOrderService.Find(c => c.PurchasePlanCode == relationCode);
                        if (purchaseOrder != null)
                            switch (purchaseOrder.Status)
                            {
                                case PurchaseOrderStatus.Invalid:
                                    ShowError("采购申请" + purchaseOrder.Code + "已作废");
                                    return;
                                default:
                                    break;
                            }
                        else
                        {
                            ShowError("采购申请" + relationCode + "未找到");
                            return;
                        }
                        break;
                    case InboundType.ReturnMaterial:
                        ProductionPlan productionPlan =
                            ProductionPlanService.Find(c => c.Code == relationCode);
                        if (productionPlan != null)
                            switch (productionPlan.Status)
                            {
                                case ProductionPlanStatus.Invalid:
                                    ShowError("生产计划单" + productionPlan.Code + "已作废");
                                    return;
                                default:
                                    break;
                            }
                        else
                        {
                            ShowError("生产计划单" + relationCode + "未找到");
                            return;
                        }
                        break;
                    case InboundType.Product:
                        ProductionOrder productionOrder =
                            ProductionOrderService.Find(c => c.Code == relationCode);
                        if (productionOrder != null)
                            switch (productionOrder.Status)
                            {
                                case ProductionOrderStatus.Invalid:
                                    ShowError("生产工单" + productionOrder.Code + "已作废");
                                    return;
                                default:
                                    break;
                            }
                        else
                        {
                            ShowError("生产工单" + relationCode + "未找到");
                            return;
                        }
                        break;
                    case InboundType.ReturnProduct:
                        SalesOrder salesOrder = SalesOrderService.Find(c => c.Code == relationCode);
                        if (salesOrder != null)
                            switch (salesOrder.Status)
                            {
                                case SalesOrderStatus.Invalid:
                                    ShowError("销售订单" + salesOrder.Code + "已作废");
                                    return;
                                default:
                                    break;
                            }
                        else
                        {
                            ShowError("销售订单" + relationCode + "未找到");
                            return;
                        }
                        break;
                    default:
                        break;
                }

            gridControl1.MainView.PostEditor();

            if (InboundType == InboundType.Purchase && beRelationCode.Text.Trim() != string.Empty)
            {
                List<int> list =
                    ServiceHelper.GetService<Inbound>().FindAll(
                        c =>
                        c.RelationCode == beRelationCode.Text.Trim() && c.Status == InboundStatus.Finished &&
                        c.InboundId != Data.InboundId, null).Select(c => c.InboundId).ToList();
                int purchaseOrderId =
                    ServiceHelper.GetService<PurchaseOrder>().Find(c => c.PurchasePlanCode == beRelationCode.Text.Trim())
                        .PurchaseOrderId;
                List<PurchaseOrderDetail> purchaseOrderDetails =
                    ServiceHelper.GetService<PurchaseOrderDetail>().FindAll(c => c.PurchaseOrderId == purchaseOrderId,
                                                                            null);
                if (list.Count > 0)
                {
                    List<InboundDetail> details =
                        ServiceHelper.GetService<InboundDetail>().FindAll(c => list.Contains(c.InboundId), null);
                    foreach (InboundDetail inboundDetail in details)
                    {
                        InboundDetail detail = inboundDetail;
                        PurchaseOrderDetail purchaseOrderDetail = purchaseOrderDetails.Find(c => c.SkuId == detail.SkuId);
                        if (purchaseOrderDetail != null)
                        {
                            purchaseOrderDetail.Quantity -= inboundDetail.Quantity;
                        }
                    }
                }

                foreach (InboundDetail inboundDetail in Data.Details)
                {
                    InboundDetail detail = inboundDetail;
                    PurchaseOrderDetail purchaseOrderDetail = purchaseOrderDetails.Find(c => c.SkuId == detail.SkuId);
                    if (purchaseOrderDetail != null)
                    {
                        if (purchaseOrderDetail.Quantity < inboundDetail.Quantity)
                        {
                            if (
                                MessageBox.Show("入库数量大于采购数量，是否入库", "提示", MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                                DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }


            if (!dxValidationProvider1.Validate())
            {
                return;
            }
            if (Data.Details.Count <= 0)
            {
                if (_isMateriel)
                    MessageBox.Show("至少需要录入1条记录物料信息！");
                else
                    MessageBox.Show("至少需要录入1条记录产品信息！");
                return;
            }
            //delete by kenny 2010/11/10
            //deReceiveTime.EditValue = DateTimeHelper.Now;
            Data.Status = InboundStatus.Finished;
            if (!Save())
            {
                Data.Status = InboundStatus.Created;
                return;
            }

            var storageTraces = new List<StorageTrace>();
            foreach (InboundDetail detail in Data.Details)
            {
                if (detail.TraceType == TraceType.Single)
                {
                    InboundDetail inboundDetail = detail;
                    storageTraces.AddRange(detail.Details.Select(trace => new StorageTrace
                                                                              {
                                                                                  SkuId = inboundDetail.SkuId,
                                                                                  Code = trace.Code,
                                                                                  LotNo = inboundDetail.LotNo,
                                                                                  Quantity = 1,
                                                                                  LocationId = inboundDetail.LocationId,
                                                                                  TraceType = inboundDetail.TraceType
                                                                              }));
                }
                else
                {
                    InboundDetailTrace inboundDetailTrace = detail.Details[0];
                    var storageTrace = new StorageTrace
                                           {
                                               SkuId = detail.SkuId,
                                               Code = inboundDetailTrace.Code,
                                               LotNo = detail.LotNo,
                                               Quantity = detail.Quantity,
                                               LocationId = detail.LocationId,
                                               TraceType = detail.TraceType
                                           };
                    storageTraces.Add(storageTrace);
                }
            }
            CommonApi.ChangeStorage(storageTraces);
            // 退料入库，扣除临时库存
            if (InboundType == InboundType.ReturnMaterial)
            {
                CommonApi.MaterialTrace(storageTraces);
            }
            // 保存出库单信息
            if (outbound != null)
            {
                outbound.RelaOrderCode = Data.Code;
                outbound.Status = OutboundStatus.Used;
                outbound.Save();
            }

            MessageBox.Show(Resources.FinishInbound);
            if (ParentForm != null) ParentForm.Close();
        }


        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExportItemClick(object sender, ItemClickEventArgs e)
        {
            if (Data == null)
            {
                return;
            }
            gridControl1.MainView.PostEditor();
            Data.LoadData(Controls);
            XtraReport report = Data.GetReport(InboundType);
            report.Export(Title + Data.Code);
        }

        /// <summary>
        /// 扫描条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnScanBarcodeItemClick(object sender, ItemClickEventArgs e)
        {
            new Form
                {
                    Controls = {new UcBarcodeScan {CallBack = ImportCode}},
                    Size = new Size(420, 170),
                    Text = Resources.ScanMateriel,
                }.Dialog();
        }

        /// <summary>
        /// 修改数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChangeQuantityItemClick(object sender, ItemClickEventArgs e)
        {
            var detail = bandedGridView1.Current<InboundDetail>();
            if (detail == null) return;
            if (detail.TraceType == TraceType.Single) return;

            var ucBarcodeScan = new UcChangeQuantity
                                    {
                                        Adjust = quantity =>
                                                     {
                                                         // 如果是采购入库需要校验是否采购采购单数量
                                                         if (InboundType == InboundType.Purchase &&
                                                             beRelationCode.Text.Trim() != string.Empty)
                                                         {
                                                             List<int> list =
                                                                 ServiceHelper.GetService<Inbound>().FindAll(
                                                                     c =>
                                                                     c.RelationCode == beRelationCode.Text.Trim() &&
                                                                     c.Status == InboundStatus.Finished &&
                                                                     c.InboundId != Data.InboundId, null).Select(
                                                                         c => c.InboundId).ToList();
                                                             int purchaseOrderId =
                                                                 ServiceHelper.GetService<PurchaseOrder>().Find(
                                                                     c =>
                                                                     c.PurchasePlanCode == beRelationCode.Text.Trim()).
                                                                     PurchaseOrderId;
                                                             List<PurchaseOrderDetail> purchaseOrderDetails =
                                                                 ServiceHelper.GetService<PurchaseOrderDetail>().FindAll
                                                                     (c =>
                                                                      c.PurchaseOrderId == purchaseOrderId &&
                                                                      c.SkuId == detail.SkuId, null);
                                                             PurchaseOrderDetail purchaseOrderDetail =
                                                                 purchaseOrderDetails.Find(c => c.SkuId == detail.SkuId);
                                                             if (list.Count > 0)
                                                             {
                                                                 List<InboundDetail> details =
                                                                     ServiceHelper.GetService<InboundDetail>().FindAll(
                                                                         c =>
                                                                         list.Contains(c.InboundId) &&
                                                                         c.SkuId == detail.SkuId, null);
                                                                 foreach (InboundDetail inboundDetail in details)
                                                                 {
                                                                     if (purchaseOrderDetail != null)
                                                                     {
                                                                         purchaseOrderDetail.Quantity -=
                                                                             inboundDetail.Quantity;
                                                                     }
                                                                 }
                                                             }


                                                             if (purchaseOrderDetail != null)
                                                             {
                                                                 if (purchaseOrderDetail.Quantity < quantity)
                                                                 {
                                                                     if (
                                                                         MessageBox.Show("入库数量大于采购数量，是否入库", "提示",
                                                                                         MessageBoxButtons.YesNo,
                                                                                         MessageBoxIcon.Question,
                                                                                         MessageBoxDefaultButton.Button2) ==
                                                                         DialogResult.No)
                                                                     {
                                                                         return false;
                                                                     }
                                                                 }
                                                             }
                                                         }

                                                         detail.Quantity = quantity;
                                                         BindDetails();
                                                         return true;
                                                     },
                                        Data = detail.Quantity
                                    };

            new Form
                {
                    Controls = {ucBarcodeScan},
                    Size = new Size(433, 170),
                    Text = Resources.ChangeQuantity
                }.Dialog();
        }

        /// <summary>
        /// TODO：Remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BandedGridView1FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }

        /// <summary>
        /// 选择的数据改变后调整按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bandedGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var detail = bandedGridView1.Current<InboundDetail>();

            btnChangeQuantity.Enabled = bandedGridView1.SelectedRowsCount == 1 && detail != null &&
                                        detail.TraceType != TraceType.Single && detail.Details.Count > 0;
        }
    }
}