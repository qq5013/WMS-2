using System;
using System.Collections.Generic;
using System.ServiceModel;
using Business.Common.DataDictionary;
using Business.Common.Exception;
using Business.Common.Toolkit;
using Business.Domain.Application;
using Business.Domain.Inventory;
using DevExpress.XtraBars;
using Frame.Utils.Service;
using Framework.Core.Collections;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;
using Wms.Common;

namespace Mes.Product.Modules.ProductionOrderModel
{
    public partial class ProductionOrderEditForm : MasterEditForm
    {
        public int NClientId;

        public int NMerchantId;

        private List<EntitySetting<ProductionOrderDetail>> _detailSettings;

        private List<EntitySetting<ProductionOrder>> _settings;

        internal IList<ProductionOrderDetailModel> listLocalData = new List<ProductionOrderDetailModel>();


        public ProductionOrderEditForm()
        {
            InitializeComponent();
        }

        protected IEntityService<ProductionOrder> Service
        {
            get { return (ServiceBloker.GetService<ProductionOrder>()); }
        }

        protected IEntityService<ProductionOrderDetail> DetialService
        {
            get { return (ServiceBloker.GetService<ProductionOrderDetail>()); }
        }


        public override void FormInitialize()
        {
            RegisterDetailForm(typeof (ProductionOrderDetailEditForm).FullName);


            _settings = new List<EntitySetting<ProductionOrder>>()
                .Setting(c => c.ProductionPlanId, new EntitySetting
                    {
                        Name = "生产计划",
                        Control = lookUpEdit1.BindProductionPlan(ControlMode.Edit)
                    })
                .Setting(c => c.CustomerName, new EntitySetting
                    {
                        Name = "客户",
                        Control = beCustomer.BindCustomer(ControlMode.Edit)
                    })
                .Setting(c => c.OrderDate, new EntitySetting
                    {
                        Name = "订购日期",
                        Control = deOrderDate.BindDate()
                    })
                .Setting(c => c.DeliveryDate, new EntitySetting
                    {
                        Name = "交货日期",
                        Control = deDeliveryDate.BindDate()
                    })
                .Setting(c => c.CreaterId, new EntitySetting
                    {
                        Name = "制单人",
                        Control = lueCreaterId.BindUser(ControlMode.Edit)
                    })
                .Setting(c => c.CreateTime, new EntitySetting
                    {
                        Name = "制单日期",
                        Control = deCreateTime
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Control = meRemark
                    });

            _detailSettings = new List<EntitySetting<ProductionOrderDetail>>();


            _detailSettings
                //.Setting(c => c.ProductId, new EntitySetting
                //    {
                //        Name = "产品代码",
                //        Width = 100,
                //        Control = null
                //    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品名称",
                        Width = 100,
                        Control = null
                    })
                //.Setting(c => c.ProductId, new EntitySetting
                //    {
                //        Name = "产品类型",
                //        Width = 100,
                //        Control = null
                //    })
                .Setting(c => c.Quantity, new EntitySetting
                    {
                        Name = "生产数量",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.MeasureId, new EntitySetting
                    {
                        Name = "单位",
                        Width = 100,
                        Control = null,
                    })
                .Setting(c => c.FinishDate, new EntitySetting
                    {
                        Name = "完工日期",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Width = 100,
                        Control = null
                    });
            base.FormInitialize();
        }

        public override void BindGridColumnMap()
        {
            base.BindGridColumnMap();
            _detailSettings.SetGridColumn(DetailGridView);
        }

        public override void InitToolButtons()
        {
            if (CurrentMasterData == null)
                return;

            var order = (CurrentMasterData as ProductionOrder);
            if (order == null || order.Status != ProductionOrderStatus.Created) return;
            if (order.OrderType == 1)
            {
                btnGenerateBill.Visibility = BarItemVisibility.Always;
                btnGenerateBill.Caption = "生成子工单";
                btnGenerateBill.ItemClick += (sender, e) =>
                    {
                        try
                        {
                            var ints = new List<int> {2, 3, 4};
                            ints.ForEach(c =>
                                {
                                    var productionOrder = order.Clone() as ProductionOrder;
                                    productionOrder.ProductionOrderId = 0;
                                    productionOrder.Code = productionOrder.Code + c;
                                    productionOrder.OrderType = c;
                                    ServiceBloker.GetService<ProductionOrder>()
                                                 .Save(productionOrder);
                                });
                            order.Status = ProductionOrderStatus.Finished;
                            ServiceBloker.GetService<ProductionOrder>().Save(order);

                            FormHelper.ShowInformationDialog("生成子工单成功");
                        }
                        catch (Exception ex)
                        {
                            ex.Process();
                        }
                    };
            }
            else
            {
                btnGenerateBill.Visibility = BarItemVisibility.Always;
                btnGenerateBill.Caption = "生成领料单";
                btnGenerateBill.ItemClick += (sender, e) =>
                    {
                        try
                        {
                            var bill = CurrentMasterData as ProductionOrder;
                            var materialRequisition = bill.CopyTo<MaterialRequisition>();
                            materialRequisition.CreateTime = DateTime.Now;
                            if (materialRequisition.DeliveryDate < DateTimeHelper.Min)
                                materialRequisition.DeliveryDate = DateTimeHelper.Min;
                            if (materialRequisition.ProductionDate < DateTimeHelper.Min)
                                materialRequisition.ProductionDate = DateTimeHelper.Min;
                            if (materialRequisition.OrderDate < DateTimeHelper.Min)
                                materialRequisition.OrderDate = DateTimeHelper.Min;
                            if (materialRequisition.PurchaseDate < DateTimeHelper.Min)
                                materialRequisition.PurchaseDate = DateTimeHelper.Min;
                            materialRequisition.Code = "MQ" + DateTime.Now.ToString("yyMMddHHmmss");
                            ServiceBloker.GetService<MaterialRequisition>()
                                         .Save(materialRequisition);

                            order.Status = ProductionOrderStatus.Finished;
                            var materialRequisitionDetails = new List<MaterialRequisitionDetail>();
                            ServiceBloker.GetService<ProductionOrderDetail>()
                                         .FindAll(c => c.ProductionOrderId == order.ProductionOrderId)
                                         .Mapper(materialRequisitionDetails);
                            foreach (MaterialRequisitionDetail materialRequisitionDetail in materialRequisitionDetails)
                            {
                                ServiceBloker.GetService<MaterialRequisitionDetail>().Save(materialRequisitionDetail);
                            }


                            FormHelper.ShowInformationDialog("生成领料单成功");
                        }
                        catch (Exception ex)
                        {
                            ex.Process();
                        }
                    };
            }
        }


        public override void SetMainDataInputStatus()
        {
            switch (MasterDataState)
            {
                case DataState.Read:
                    {
                        layoutBase.Enabled = false;
                        btnConfirm.Enabled = true;
                        btnPrint.Enabled = true;
                        btnRevoke.Enabled = true;
                        break;
                    }
                case DataState.Create:
                    {
                        layoutBase.Enabled = true;
                        btnConfirm.Enabled = false;
                        btnPrint.Enabled = false;
                        btnRevoke.Enabled = false;
                        break;
                    }
                case DataState.Update:
                    {
                        layoutBase.Enabled = true;
                        btnConfirm.Enabled = false;
                        btnPrint.Enabled = false;
                        btnRevoke.Enabled = false;
                        break;
                    }
            }
        }

        public override void InitAuthority()
        {
            //btnInsertMaster.Tag = "INBOUNDPLAN_INSERT";
            //btnUpdateMaster.Tag = "INBOUNDPLAN_EDIT";
            //btnQueryMaster.Tag = "INBOUNDPLAN_QUERY";
        }

        public override void RevokeData()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as ProductionOrder;

                if (bill != null)
                {
                    try
                    {
                        //bool revokeResult = Service.RevokeProductionOrder(GlobalState.CurrentWarehouse.WarehouseId, bill.BillId, GlobalState.CurrentUser.UserId);

                        //if (revokeResult)
                        //{
                        //    CurrentMasterData = Service.GetInboundPlan(bill.BillId);
                        //    SetMainData();
                        //    btnRevoke.Enabled = false;
                        //    btnUpdateMaster.Enabled = false;
                        //}
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        sex.Process();
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                    }
                }
            }
        }

        public override void LoadDetailData()
        {
            if (CurrentMasterData == null) return;

            var bill = CurrentMasterData as ProductionOrder;
            if (bill != null)
            {
                List<ProductionOrderDetail> details =
                    DetialService.FindAll(c => c.ProductionOrderId == bill.ProductionOrderId);

                IList<ProductionOrderDetailModel> productionOrderDetailModels = new List<ProductionOrderDetailModel>();
                details.CopyTo(productionOrderDetailModels);
                listLocalData = productionOrderDetailModels;
                DetailDataList = CollectionHelper.ToArrayList(listLocalData);
                BindDetailGrid();
                BindGridColumnMap();
            }
        }

        public override void ClearMainDataControl()
        {
            _settings.ClearValue();
        }

        public override void ReloadData()
        {
            if (CurrentMasterData == null) return;
            var productionOrder = CurrentMasterData as ProductionOrder;
            if (productionOrder != null) CurrentMasterData = Service.GetById(productionOrder.GetEntityId());

            LoadDetailData();
        }

        public override void SetMainData()
        {
            if (CurrentMasterData == null) return;
            var bill = CurrentMasterData as ProductionOrder;

            if (bill == null) return;
            Text = string.Format(" 生产工单 - {0}", bill.Code);

            ProductionOrder productionOrder = Service.GetById(bill.GetEntityId());
            _settings.DataFromEntity(productionOrder);
        }


        public override void SaveData()
        {
            ProductionOrder bill = null;
            if (MasterDataState == DataState.Create)
            {
                bill = new ProductionOrder
                    {
                        Code = "PWO" + DateTime.Now.ToString("yyMMddHHmmss"),
                        Status =
                            ProductionOrderStatus.Created,
                        CreaterId = GlobalState.CurrentUser.UserId,
                        OrderType = 1
                    };
                _settings.DataToEntity(bill);
                bill.CreateTime = DateTime.Now;
                
            }
            if (MasterDataState == DataState.Update)
            {
                bill = CurrentMasterData as ProductionOrder;
                if (bill != null)
                {
                    _settings.DataToEntity(bill);
                }
            }

            if (bill != null)
            {
                if (MasterDataState == DataState.Create)
                {
                    int save = Service.Save(bill);
                    if (save == 0)
                    {
                        FormHelper.ShowErrorDialog("创建生产工单失败。");
                        return;
                    }
                    else
                    {
                        bill.ProductionOrderId = save;
                    }
                }
                if (MasterDataState == DataState.Update)
                {
                    bool updateResult = Service.Save(bill) > 0;
                    if (!updateResult)
                    {
                        FormHelper.ShowErrorDialog("更新生产工单失败。");
                        return;
                    }
                }

                CurrentMasterData = bill;
                SetMainData();
            }

            if (bill != null)
            {
                foreach (ProductionOrderDetailModel localInfo in listLocalData)
                {
                    switch (localInfo.OperationName)
                    {
                        case "ADD":
                            {
                                localInfo.ProductionOrderId = bill.GetEntityId(); //改成主键
                                int newID = DetialService.Save(localInfo);
                                if (newID <= 0)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                localInfo.ProductionOrderDetailId = newID;
                                break;
                            }
                        case "EDIT":
                            {
                                bool updateResult = DetialService.Save(localInfo) > 0;
                                if (!updateResult)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                break;
                            }
                        case "DELETE":
                            {
                                bool deleteResult = DetialService.Delete(localInfo.GetEntityId()) > 0;
                                if (!deleteResult)
                                {
                                    throw new Exception();
                                }
                                break;
                            }

                            //case "NONE":
                            //    {
                            //        bool updateResult = GenericServiceHelper.Update<InboundPlanDetail>(out bllResult, ObjCopyToParent(localInfo));
                            //        if (!updateResult)
                            //        {
                            //            throw new Exception();
                            //        }
                            //        break;
                            //    }
                    }
                }
            }

            if (MasterDataState == DataState.Create)
            {
                listLocalData.Clear();
            }
        }

        public override void DeleteLocalData()
        {
            if (CurrentDetailData == null) return;

            var localInfo = CurrentDetailData as ProductionOrderDetailModel;

            DetailDataList.Remove(localInfo);

            if (localInfo != null)
                if (localInfo.OperationName == "ADD")
                {
                    listLocalData.Remove(localInfo);
                }
                else
                {
                    localInfo.OperationName = "DELETE";
                    listLocalData[localInfo.TempId] = localInfo;
                }
        }

        public override bool ValidateUpdateOperation()
        {
            var plan = CurrentMasterData as InboundPlan;
            if (plan != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(plan.BillStatus);
                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode !=
                        DictionaryHelper.ConvertToDictionaryCode((int) InboundPlanStatus.Created) &&
                        dictionary.DictionaryCode !=
                        DictionaryHelper.ConvertToDictionaryCode((int) InboundPlanStatus.Modified))
                    {
                        FormHelper.ShowWarningDialog("此生产工单当前状态不允许被编辑。");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///     必选项验证
        /// </summary>
        /// <returns></returns>
        public override bool ValidateMainData()
        {
            return _settings.Validate(Validator);
        }

        /// <summary>
        ///     入库单明细容器
        /// </summary>
        public override void CustomizeDetailGrid()
        {
            _detailSettings.SetGridColumn(DetailGridView);
        }
    }
}