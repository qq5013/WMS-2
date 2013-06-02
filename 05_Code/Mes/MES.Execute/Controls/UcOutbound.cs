

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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
    /// 出库
    /// </summary>
    public partial class UcOutbound : UserControl, IInitControl, ICheckClosing
    {
        /// <summary>
        /// 是否物料
        /// </summary>
        private bool _isMateriel;

        /// <summary>
        /// 库位
        /// </summary>
        private Location _location;

        public UcOutbound()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 出库单
        /// </summary>
        public Outbound Data { get; set; }

        /// <summary>
        /// 出库单状态
        /// </summary>
        public OutboundType OutboundType { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public int WarehouseId { get; set; }
        
        /// <summary>
        /// 当前SKU
        /// </summary>
        protected SkuInfo CurrentSkuInfo { get; set; }

        /// <summary>
        /// 运行编辑
        /// </summary>
        protected bool AllowEdit { get; set; }

        #region ICheckClosing Members

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
            gridControl1.MainView.PostEditor();

            if (Data == null)
                return false;

            Data.LoadData(Controls);

            int outboundId = ServiceHelper.GetService<Outbound>().Save(Data);
            if (Data.OutboundId == 0)
            {
                Data.OutboundId = outboundId;
            }

            // 清空临时列表
            foreach (OutboundDetail detail in Data.RemoveList)
            {
                if (detail.GetEntityId() > 0)
                    detail.Remove();
            }
            Data.RemoveList.Clear();
            // 保存明细
            foreach (OutboundDetail detail in Data.Details)
            {
                detail.OutboundId = Data.OutboundId;
                int outboundDetailId = ServiceHelper.GetService<OutboundDetail>().Save(detail);
                if (detail.OutboundDetailId == 0)
                    detail.OutboundDetailId = outboundDetailId;
                // 保存追踪码
                foreach (OutboundDetailTrace detailTrace in detail.Details)
                {
                    detailTrace.OutboundDetaiId = detail.OutboundDetailId;
                    int outboundDetailTraceId = ServiceHelper.GetService<OutboundDetailTrace>().Save(detailTrace);
                    if (detailTrace.OutboundDetailTraceId == 0)
                        detailTrace.OutboundDetailTraceId = outboundDetailTraceId;
                }
            }
            DataChanged = false;
            return true;
        }

        /// <summary>
        /// 数据变更
        /// </summary>
        public bool DataChanged { get; set; }

        #endregion

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            SuspendLayout();
            barManager2.Form = groupControl1;

            glueOperator.BindUser(ControlMode.Edit, new List<string> { "purchase", "centerWarehosue", "workshopWarehouse", "productWarehouse", "purchase", "qualityManagement", "administrators" });
            glueOperator.EditValue = CommonApi.CurrentUser().UserId;

            //出库时间
            deOperateTime.EditValue = DateTimeHelper.Now;

            //出库库类型
            glueType.Bind<OutboundType>(ControlMode.Edit);
            glueType.EditValue = OutboundType;
            glueType.Properties.ReadOnly = true;

            //仓库
            glueWarehouse.BindWarehouse(ControlMode.Edit);
            glueWarehouse.EditValue = WarehouseId;
            glueWarehouse.Properties.ReadOnly = true;


            switch (OutboundType)
            {
                case OutboundType.Product:
                    lblRelaOrderCode.Text = "关联销售单号";
                    beRelationCode.BindOrder<UcSalesOrderManage>("选择销售订单");

                    lblTargetUnit.Text = "客户名称";
                    glueTargetUnit.BindCustomer(ControlMode.Query);

                    lblReceiver.Visible = false;
                    glueReceiver.Visible = false;

                    //计划数量
                    bandedGridColumn8.Visible = false;
                    //浮动率
                    bandedGridColumn10.Visible = false;

                    _isMateriel = false;
                    break;
                case OutboundType.Material:
                    btnByProduct.Visibility = BarItemVisibility.Always;
                    lblRelaOrderCode.Text = "关联领料单号";
                    beRelationCode.Properties.Buttons[0].Visible = false;

                    lblTargetUnit.Text = "领料部门";
                    glueTargetUnit.BindDepartment(ControlMode.Query);

                    lblReceiver.Text = "领料人";
                    glueReceiver.BindUser(ControlMode.Query, null);

                    //计划数量
                    bandedGridColumn8.Visible = true;
                    bandedGridColumn8.OptionsColumn.AllowEdit = true;
                    //浮动率
                    bandedGridColumn10.Visible = true;

                    _isMateriel = true;
                    break;
                case OutboundType.ReturnMaterial:
                    lblRelaOrderCode.Text = "关联采购单号";
                    beRelationCode.BindOrder<UcPurchaseOrderManage>("选择采购订单");

                    lblTargetUnit.Text = "供应商";
                    glueTargetUnit.BindVendor(ControlMode.Query);

                    lblReceiver.Visible = false;
                    glueReceiver.Visible = false;

                    //计划数量
                    bandedGridColumn8.Visible = false;
                    //浮动率
                    bandedGridColumn10.Visible = false;
                    _isMateriel = true;
                    break;
                case OutboundType.WorkShopMaterial:
                    lblRelaOrderCode.Text = "关联生产工单";
                    beRelationCode.BindOrder<UcProductionOrderManage>("请选择生产工单号");

                    lblTargetUnit.Text = "领料产线";
                    glueTargetUnit.BindWorkShop(ControlMode.Query);
                    glueTargetUnit.EditValue = 1;
                    glueTargetUnit.Properties.ReadOnly = true;

                    lblReceiver.Text = "领料人";
                    glueReceiver.BindUser(ControlMode.Query, null);

                    //计划数量
                    bandedGridColumn8.Visible = true;
                    //浮动率
                    bandedGridColumn10.Visible = true;

                    _isMateriel = true;
                    break;
                case OutboundType.Inspect:
                    lblRelaOrderCode.Visible = false;
                    beRelationCode.Visible = false;

                    lblTargetUnit.Text = "借用部门";
                    glueTargetUnit.BindDepartment(ControlMode.Query);

                    lblReceiver.Text = "领用人";
                    glueReceiver.BindUser(ControlMode.Query, null);

                    //计划数量
                    bandedGridColumn8.Visible = false;
                    //浮动率
                    bandedGridColumn10.Visible = false;

                    _isMateriel = false;
                    break;
                case OutboundType.BackCenter:
                    lblRelaOrderCode.Text = "关联生产计划";
                    beRelationCode.BindOrder<UcProductionPlanManage>("选择生产计划单号");

                    lblTargetUnit.Text = "接收仓库";
                    glueTargetUnit.BindWarehouse(ControlMode.Query);

                    glueTargetUnit.EditValue = 1;
                    glueTargetUnit.Properties.ReadOnly = true;


                    lblReceiver.Visible = false;
                    glueReceiver.Visible = false;

                    //计划数量
                    bandedGridColumn8.Visible = false;
                    //浮动率
                    bandedGridColumn10.Visible = false;

                    _isMateriel = true;
                    break;
                case OutboundType.CenterAdjust:
                case OutboundType.PlantAdjust:
                    lblRelaOrderCode.Visible = false;
                    beRelationCode.Visible = false;

                    lblTargetUnit.Visible = false;
                    glueTargetUnit.Visible = false;

                    lblReceiver.Visible = false;
                    glueReceiver.Visible = false;

                    labelControl3.Text = "盘点人";
                    //计划数量
                    bandedGridColumn8.Visible = false;
                    //浮动率
                    bandedGridColumn10.Visible = false;
                    dxValidationProvider1.SetValidationRule(glueTargetUnit, null);
                    markTargetUnit.Visible = false;
                    _isMateriel = true;
                    break;
                case OutboundType.ProductAdjust:
                    lblRelaOrderCode.Visible = false;
                    beRelationCode.Visible = false;

                    lblTargetUnit.Visible = false;
                    glueTargetUnit.Visible = false;

                    lblReceiver.Visible = false;
                    glueReceiver.Visible = false;

                    labelControl3.Text = "盘点人";
                    //计划数量
                    bandedGridColumn8.Visible = false;
                    //浮动率
                    bandedGridColumn10.Visible = false;
                    dxValidationProvider1.SetValidationRule(glueTargetUnit, null);
                    markTargetUnit.Visible = false;
                    _isMateriel = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            CommonApi.BindSku(riglueSkuCategoryName, riglueSkuName, riglueSkuCode, riglueSkuSpec, riglueSkuModel,
                              riglueSkuColor, _isMateriel);

            if (!_isMateriel)
            {
                // 产品不能直接添加和修改数量
                btnAdd.Visibility = BarItemVisibility.Never;
                btnChangeQuantity.Visibility = BarItemVisibility.Never;
            }
            if (Data != null)
            {
                // 填充数据
                Data.FillData(Controls);

                if (Data.Status != OutboundStatus.Created)
                {
                    // 已经审核的出库单不能编辑
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
                    btnAdd.Enabled = false;
                    btnRemove.Enabled = false;
                    btnOutbound.Enabled = false;
                    bar3.Visible = false;
                }
                else
                {
                    AllowEdit = true;
                }

                // 绑定
                if (Data.OutboundId > 0)
                {
                    List<OutboundDetail> details =
                        ServiceHelper.GetService<OutboundDetail>().FindAll(c => c.OutboundId == Data.OutboundId, null);
                    Data.Details.Clear();
                    Data.Details.AddRange(details);
                    List<int> ids = Data.Details.Select(c => c.OutboundDetailId).ToList();
                    details.ForEach(c => SetStorage(c, c.TraceType, c.SkuId));

                    // 绑定明细
                    if (ids.Count > 0)
                    {
                        List<OutboundDetailTrace> outboundDetailTraces =
                            ServiceHelper.GetService<OutboundDetailTrace>().FindAll(
                                c => ids.Contains(c.OutboundDetaiId),
                                null);
                        foreach (OutboundDetailTrace detailTrace in outboundDetailTraces)
                        {
                            OutboundDetailTrace trace = detailTrace;
                            OutboundDetail outboundDetail =
                                details.Find(c => c.OutboundDetailId == trace.OutboundDetaiId);
                            if (outboundDetail != null) outboundDetail.Details.Add(detailTrace);
                        }
                    }
                }
                else
                {
                    // 设置出库单号
                    teCode.Text = CommonApi.GetCode<Outbound>();
                    teCode.Properties.ReadOnly = true;
                }

                BindDetail();
            }
            else
            {
                Reset();
            }
            if (AllowEdit)
            {
                foreach (object control in Controls)
                {
                    if (control is BaseEdit)
                    {
                        ((BaseEdit) control).EditValueChanged += (sender, e) => { DataChanged = true; };
                    }
                }
                rimeRemark.EditValueChanged += (sender, e) => { DataChanged = true; };
            }

            ResumeLayout();
        }

        #endregion

        private void UcOutbound_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 添加物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddItemClick(object sender, ItemClickEventArgs e)
        {
            var ucSelectSku = new UcSelectSku {CallBack = ImportCode, IsMateriel = _isMateriel};
            ucSelectSku.Init();
            new Form
                {
                    Controls = {ucSelectSku},
                    Size = new Size(700, 280),
                    Text = _isMateriel ? Resources.AddMateriel : Resources.AddProduct
                }.Dialog();
        }

        /// <summary>
        /// 删除物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveItemClick(object sender, ItemClickEventArgs e)
        {
            int[] selectedRows = bandedGridView1.GetSelectedRows();
            if (selectedRows != null && selectedRows.Length > 0)
            {
                List<OutboundDetail> list = selectedRows.Select(selectedRow => bandedGridView1.GetRow(selectedRow) as OutboundDetail).ToList();
                foreach (var detail in list)
                {
                    Data.RemoveList.Add(detail);
                    Data.Details.Remove(detail);
                }

                BindDetail();
            }
        }
        /// <summary>
        /// 绑定明细
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = Data.Details;
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
            if (MessageBox.Show("保存成功是否关闭编辑界面？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
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
        /// 重置
        /// </summary>
        private void Reset()
        {
            teCode.Text = CommonApi.GetCode<Outbound>();
            teCode.Properties.ReadOnly = true;
            glueType.EditValue = OutboundType;
            Data = new Outbound
                       {
                           CreaterId = CommonApi.CurrentUser().UserId,
                           CreateTime = DateTimeHelper.Now,
                           OperateTime = DateTimeHelper.Now,
                           DeliveryTime = DateTimeHelper.Min,
                           Status = OutboundStatus.Created,
                           Type = OutboundType
                       };
            Data.FillData(Controls);
            BindDetail();
            DataChanged = true;
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
        /// 关闭编辑界面
        /// </summary>
        private void DoClose()
        {
            if (ParentForm != null) ParentForm.Close();
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

            XtraReport report = Data.GetReport(OutboundType);
            report.ShowPrint();
        }

        /// <summary>
        /// 输入条码解析
        /// </summary>
        /// <param name="skuInfo"></param>
        /// <param name="code"></param>
        /// <param name="lotNo"></param>
        /// <param name="measureId"></param>
        /// <param name="quantity"></param>
        /// <param name="showError"></param>
        public void ImportCode(SkuInfo skuInfo, string code, string lotNo, int measureId, int quantity,
                               ShowError showError)
        {
            if (OutboundType.WorkShopMaterial == OutboundType && code.Length == 19)
            {
                if (!ServiceHelper.GetService<PcbInspect>().Exists(c => c.TraceCode == code))
                {
                    showError("物料" + code + "未完成PCB板检测");
                    if (
                        MessageBox.Show("物料" + code + "未完成PCB板检测，是否强制出库", " 警告", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }
            }

            if (OutboundType.Product == OutboundType )
            {
                Item item = ServiceHelper.GetService<Item>().Find(c=>c.Barcode==code);

                if (item != null)
                {
                    if (
                        ServiceHelper.GetService<ItemSampleInspect>().Exists(
                            c => c.ItemId == item.ItemId && c.ResultId == 2))
                    {
                        showError("成品" + code + "检验不合格");
                        MessageBox.Show("成品" + code + "检验不合格，不能出库", " 警告", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        return;
                    }
                    else
                    {
                        var items =
                            ServiceHelper.GetService<Item>().FindAll(
                                c => c.ProductionOrderId == item.ProductionOrderId, null).Select(c => c.ItemId);

                        if (
                            ServiceHelper.GetService<ItemSampleInspect>().Exists(
                                c => items.Contains(c.ItemId) && c.ResultId == 1))
                        {
                        }
                        else
                        {
                            showError("成品" + code + "检验不合格");
                            MessageBox.Show("成品" + code + "检验不合格，不能出库", " 警告", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            return;
                        }
                    }
                }
                else
                {
                    showError("成品" + code + "未找到");
                    return;
                }

            }

            if (_isMateriel)
            {
                OutboundDetail detail = Data.Details.Find(c => c.SkuId == skuInfo.SkuId);
                if (detail == null)
                {
                    detail = new OutboundDetail {SkuId = skuInfo.SkuId, TraceType = skuInfo.TraceType, LotNo = lotNo};
                    SetStorage(detail, skuInfo.TraceType, skuInfo.SkuId);
                    Data.Details.Insert(0, detail);
                }
                if (skuInfo.TraceType == TraceType.Single)
                {
                    if (detail.Details.Exists(c => c.Code == code))
                    {
                        showError("单品条码重复！");
                        return;
                    }
                    if (!ServiceHelper.GetService<Storage>().Exists(c => c.Code == code))
                    {
                        showError("物料不在库存中！");
                        return;
                    }
                    var detailTrace = new OutboundDetailTrace {Code = code, OutboundDetaiId = detail.OutboundDetailId};
                    detail.TraceType = TraceType.Single;
                    detail.LotNo = lotNo;
                    detail.Details.Add(detailTrace);
                    detail.Quantity += 1;
                }
                else if (skuInfo.TraceType == TraceType.Sku)
                {
                    if (detail.Details.Count == 0)
                        detail.Details.Add(new OutboundDetailTrace
                                               {Code = code, OutboundDetaiId = detail.OutboundDetailId});
                    detail.TraceType = TraceType.Sku;
                    detail.LotNo = lotNo;
                    detail.Quantity += 1;
                }
                else
                {
                    if (detail.Details.Count == 0)
                        detail.Details.Add(new OutboundDetailTrace
                                               {Code = code, OutboundDetaiId = detail.OutboundDetailId});
                    detail.TraceType = TraceType.None;
                    detail.LotNo = lotNo;
                    detail.Quantity += quantity;
                }
            }
            else
            {
                OutboundDetail detail = Data.Details.Find(c => c.SkuId == skuInfo.SkuId);

                if (detail == null)
                {
                    detail = new OutboundDetail {SkuId = skuInfo.SkuId, TraceType = skuInfo.TraceType, LotNo = lotNo};

                    SetStorage(detail, skuInfo.TraceType, skuInfo.SkuId);

                    Data.Details.Insert(0, detail);
                }
                if (detail.Details.Exists(c => c.Code == code))
                {
                    showError("单品条码重复！");
                    return;
                }
                if (!ServiceHelper.GetService<Storage>().Exists(c => c.Code == code))
                {
                    showError("物料不在库存中！");
                    return;
                }
                var detailTrace = new OutboundDetailTrace {Code = code, OutboundDetaiId = detail.OutboundDetailId};
                detail.TraceType = TraceType.Single;
                detail.LotNo = lotNo;
                detail.Details.Add(detailTrace);
                detail.Quantity += 1;
            }
            DataChanged = true;

            BindDetail();
        }

        /// <summary>
        /// 设置库存
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="traceType"></param>
        /// <param name="skuId"></param>
        private void SetStorage(OutboundDetail detail, TraceType traceType, int skuId)
        {
            if (_location == null)
                _location = ServiceHelper.GetService<Location>().Find(c => c.WarehouseId == WarehouseId);

            if (_location != null)
            {
                // 根据不同的库位获取库存数量
                switch (traceType)
                {
                    case TraceType.Single:
                        detail.SetCurrentQuantity(
                            ServiceHelper.GetService<Storage>().Count(
                                c => c.LocationId == _location.LocationId && c.SkuId == skuId));
                        break;
                    case TraceType.Sku:
                        detail.SetCurrentQuantity(
                            ServiceHelper.GetService<Storage>().FindAll(
                                c => c.LocationId == _location.LocationId && c.SkuId == skuId, null).Sum(c => c.Quantity));
                        break;
                    case TraceType.None:
                        detail.SetCurrentQuantity(
                            ServiceHelper.GetService<Storage>().FindAll(
                                c => c.LocationId == _location.LocationId && c.SkuId == skuId, null).Sum(c => c.Quantity));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOutboundItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.MainView.PostEditor();
            if (!dxValidationProvider1.Validate())
            {
                return;
            }

            string relationCode = beRelationCode.Text.Trim();
            if (!string.IsNullOrEmpty(relationCode))
                switch (OutboundType)
                {
                    case OutboundType.Product:
                        SalesOrder salesOrder = ServiceHelper.GetService<SalesOrder>().Find(c => c.Code == relationCode);
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
                    case OutboundType.ReturnMaterial:
                        PurchaseOrder purchaseOrder =
                            ServiceHelper.GetService<PurchaseOrder>().Find(c => c.Code == relationCode);
                        if (purchaseOrder != null)
                            switch (purchaseOrder.Status)
                            {
                                case PurchaseOrderStatus.Invalid:
                                    ShowError("采购订单" + purchaseOrder.Code + "已作废");
                                    return;
                                default:
                                    break;
                            }
                        else
                        {
                            ShowError("采购订单" + relationCode + "未找到");
                            return;
                        }
                        break;
                    case OutboundType.WorkShopMaterial:
                        ProductionOrder productionOrder =
                            ServiceHelper.GetService<ProductionOrder>().Find(c => c.Code == relationCode);
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
                    case OutboundType.BackCenter:
                        ProductionPlan productionPlan =
                            ServiceHelper.GetService<ProductionPlan>().Find(c => c.Code == relationCode);
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
                    default:
                        break;
                }


            if (Data.Details.Count <= 0)
            {
                MessageBox.Show(_isMateriel ? "至少需要录入1条记录物料信息！" : "至少需要录入1条记录产品信息！");
                return;
            }
            
            Data.Status = OutboundStatus.Finished;
            if (!Save())
            {
                deOperateTime.EditValue = null;
                Data.Status = OutboundStatus.Invalid;
                return;
            }

            var storageTraces = new List<StorageTrace>();
            foreach (OutboundDetail detail in Data.Details)
            {
                int skuId = detail.SkuId;
                if (detail.TraceType == TraceType.Single)
                {
                    foreach (OutboundDetailTrace detailTrace in detail.Details)
                    {
                        OutboundDetailTrace trace = detailTrace;
                        Storage storage = ServiceHelper.GetService<Storage>().Find(c => c.Code == trace.Code);
                        if (storage == null)
                        {
                            ShowError("库存未找到");
                            return;
                        }
                        IEntityService<Location> entityService = ServiceHelper.GetService<Location>();
                        Location location = entityService.GetById(storage.LocationId);
                        if (location.WarehouseId == WarehouseId)
                        {
                            storageTraces.Add(new StorageTrace
                                                  {
                                                      SkuId = skuId,
                                                      Code = detailTrace.Code,
                                                      LotNo = detail.LotNo,
                                                      Quantity = -1,
                                                      LocationId = storage.LocationId,
                                                      TraceType = detail.TraceType
                                                  });
                        }
                        else
                        {
                            ShowError(detailTrace.Code + "库存未找到");
                            return;
                        }
                    }
                }
                else
                {
                    if(detail.Details.Count<=0)
                        continue;
                    
                    string code = detail.Details[0].Code;
                    //string lotNo = detail.LotNo;

                    IEntityService<Location> entityService = ServiceHelper.GetService<Location>();
                    var location = entityService.Find(c=>c.WarehouseId==WarehouseId);
                    var storage =
                        ServiceHelper.GetService<Storage>().Find(c => c.Code == code && c.LocationId==location.LocationId);
                    if (storage !=null)
                    {
                        if (detail.Quantity > storage.Quantity)
                        {
                            ShowError(code+"出库库存大于实际库存");
                            return;
                        }
                        var storageTrace = new StorageTrace
                                               {
                                                   SkuId = skuId,
                                                   Code = code,
                                                   LotNo = detail.LotNo,
                                                   Quantity = -detail.Quantity,
                                                   LocationId = storage.LocationId,
                                                   TraceType = detail.TraceType
                                               };
                        storageTraces.Add(storageTrace);
                       
                    }
                    else
                    {
                        ShowError(code+"出库库存大于实际库存");
                        return;
                    }
                }
            }
            CommonApi.ChangeStorage(storageTraces);
            if (OutboundType == OutboundType.WorkShopMaterial)
            {
                CommonApi.MaterialTrace(storageTraces);
            }
            MessageBox.Show("出库完成");
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

            Data.GetReport(OutboundType).Export(Title + Data.Code);
        }

        /// <summary>
        /// 显示错误
        /// </summary>
        /// <param name="error"></param>
        private void ShowError(string error)
        {
            MessageBox.Show(error);
        }
        /// <summary>
        /// 打开扫描物料窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnScanItemClick(object sender, ItemClickEventArgs e)
        {
            var ucBarcodeScan = new UcBarcodeScan {CallBack = ImportCode};

            new Form
                {
                    Controls = {ucBarcodeScan},
                    Size = new Size(420, 170),
                    Text = "扫描物料"
                }.Dialog();
        }
        /// <summary>
        /// 打开修改数量窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChangeQuantityItemClick(object sender, ItemClickEventArgs e)
        {
            var detail = bandedGridView1.Current<OutboundDetail>();
            if (detail == null) return;
            if (detail.TraceType == TraceType.Single) return;

            var ucBarcodeScan = new UcChangeQuantity
                                    {
                                        Adjust = quantity =>
                                                     {
                                                         detail.Quantity = quantity;
                                                         BindDetail();
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
        /// Julio:Remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BandedGridView1FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
           
        }
        /// <summary>
        /// 通过产品加物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            var outboundByProduct = new UcOutboundByProduct
            {
                SetProduct=(productId, quantity) => {
                    List<int> processIds =
                        ServiceHelper.GetService<Process>()
                            .FindAll(c => c.ProductId == productId, null)
                            .Select(c => c.ProcessId).ToList();
                    if(processIds.Count>0)
                    {
                        List<int> processStepIds =
                            ServiceHelper.GetService<ProcessStep>()
                                .FindAll(c => processIds.Contains(c.ProcessId), null)
                                .Select(c => c.ProcessStepId).ToList();
                        if (processStepIds.Count > 0)
                        {
                            List<ProcessStepDetail> processStepDetails =
                                ServiceHelper.GetService<ProcessStepDetail>()
                                    .FindAll(c => processStepIds.Contains(c.ProcessStepId), null);

                            foreach (ProcessStepDetail detail in processStepDetails)
                            {
                                ProcessStepDetail stepDetail = detail;
                                var sku = ServiceHelper.GetService<Sku>().GetById(stepDetail.SkuId);
                                OutboundDetail outboundDetail = Data.Details.Find(c => c.SkuId == stepDetail.SkuId);
                                if (outboundDetail != null)
                                {
                                    outboundDetail.PlanQuantity += stepDetail.Quantity * quantity;
                                }
                                else
                                {
                                    var traceType = ServiceHelper.GetService<Product>().GetById(sku.ProductId).TraceType;
                                    var item = new OutboundDetail
                                                   {
                                                       PlanQuantity =
                                                           stepDetail.Quantity * quantity,
                                                       SkuId = stepDetail.SkuId,
                                                       TraceType = traceType,
                                                   };
                                    if (traceType == TraceType.None)
                                    {
                                        item.Details.Add(new OutboundDetailTrace { Code = sku.Code });
                                    }
                                    SetStorage(item, traceType, stepDetail.SkuId);
                                    Data.Details.Add(item);
                                }
                            }
                            DataChanged = true;

                            BindDetail();
                        }
                    }
                }
                
            };
            outboundByProduct.Init();
            new Form
            {
                Controls = { outboundByProduct },
                Size = new Size(433, 170),
                Text = "选择产品"
            }.Dialog();
        }
        /// <summary>
        /// 根据选中的行变更控制按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bandedGridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var detail = bandedGridView1.Current<OutboundDetail>();

            btnChangeQuantity.Enabled = bandedGridView1.SelectedRowsCount == 1 && detail != null && detail.TraceType != TraceType.Single && detail.Details.Count > 0;
        }
    }

       
}