using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using Business.Common.Exception;
using Business.Common.Toolkit;
using Business.Domain.Application;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using Frame.Utils.Service;
using Framework.Core.Collections;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;
using Wms.Common;

namespace Mes.Product.Modules.ProductionPlanModel
{
    public partial class ProductionPlanEditForm : MasterEditForm
    {
        private List<EntitySetting<ProductionPlanDetail>> _detailSettings;

        private List<EntitySetting<ProductionPlan>> _settings;

        public IList<ProductionPlanDetailModel> listLocalData = new List<ProductionPlanDetailModel>();

        public ProductionPlanEditForm()
        {
            InitializeComponent();
        }

        private IEntityService<ProductionPlan> Service
        {
            get { return ServiceBloker.GetService<ProductionPlan>(); }
        }

        private IEntityService<ProductionPlanDetail> DeatilService
        {
            get { return ServiceBloker.GetService<ProductionPlanDetail>(); }
        }

        public override void FormInitialize()
        {
            RegisterDetailForm(typeof (ProductionPlanDetailEditForm).FullName);

            _settings = new List<EntitySetting<ProductionPlan>>()
                .Setting(c => c.CustomerName, new EntitySetting
                    {
                        Name = "客户",
                        Control = beCustomer.BindCustomer(ControlMode.Edit)
                    })
                .Setting(c => c.ContractWith, new EntitySetting
                    {
                        Name = "联系人",
                        Control = teContractWith
                    })
                .Setting(c => c.OrderDate, new EntitySetting
                    {
                        Name = "订购日期",
                        Control = deOrderDate
                    })
                .Setting(c => c.DeliveryDate, new EntitySetting
                    {
                        Name = "交货日期",
                        Control = deDeliveryDate
                    })
                .Setting(c => c.DeliveryAddress, new EntitySetting
                    {
                        Name = "交货地址",
                        Control = teDeliveryAddress
                    })
                .Setting(c => c.OrderCreaterId, new EntitySetting
                    {
                        Name = "下单员",
                        Control = lueOrderCreater.BindUser(ControlMode.Edit)
                    })
                .Setting(c => c.CreaterId, new EntitySetting
                    {
                        Name = "制单人",
                        Readonly = true,
                        Control = lueCreater.BindUser(ControlMode.Edit)
                    })
                .Setting(c => c.CreateTime, new EntitySetting
                    {
                        Name = "制单日期",
                        Control = deOrderDate
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Control = meRemark
                    });


            _detailSettings = new List<EntitySetting<ProductionPlanDetail>>()
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品代码",
                        Width = 100,
                        ColumnEdit = new RepositoryItemComboBox()
                    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品名称",
                        Width = 100,
                        ColumnEdit = new RepositoryItemComboBox()
                    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品类型",
                        Width = 100,
                        ColumnEdit = new RepositoryItemComboBox()
                    })
                .Setting(c => c.Quantity, new EntitySetting
                    {
                        Name = "生产数量",
                        Width = 100,
                    })
                .Setting(c => c.MeasureId, new EntitySetting
                    {
                        Name = "单位",
                        Width = 100,
                    })
                .Setting(c => c.FinishDate, new EntitySetting
                    {
                        Name = "完工日期",
                        Width = 100,
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Width = 100,
                    });


            base.FormInitialize();
        }

        public override void InitInputControlData()
        {
        }

        public override void InitToolButtons()
        {
            //btnCancelBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnAdditionButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnAdditionButton.Caption = @"导出入库计划";

            //btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnImport.Caption = @"打印货物条码";

            btnConfirm.Visibility = BarItemVisibility.Always;
            btnConfirm.Caption = @"审核";

            btnRevoke.Visibility = BarItemVisibility.Always;
            btnPrint.Visibility = BarItemVisibility.Always;

            btnAdditionButton.Visibility = BarItemVisibility.Always;
            btnAdditionButton.Caption = "打印条码标签";
        }


        public override void SetToolButtons()
        {
            base.SetToolButtons();

            // 判读当前单据状态是否可以审核
            var plan = CurrentMasterData as ProductionPlan;
            if (plan != null)
            {
                //DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(plan.BillStatus);
                //if (dictionary != null)
                //{
                //    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProductionPlanStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProductionPlanStatus.Modified))
                //    {
                //        btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //        btnUpdateMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    }

                //    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProductionPlanStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProductionPlanStatus.Modified)
                //        && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProductionPlanStatus.Confirmed))
                //    {
                //        btnRevoke.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    }
                //}
            }
        }

        public override bool ConfirmData()
        {
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as ProductionPlan;

                if (plan != null)
                {
                    try
                    {
                        //bool comfirmResult = Service.ConfirmProductionPlan(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

                        //if (comfirmResult)
                        //{
                        //    CurrentMasterData = Service.GetProductionPlan(plan.PlanId);
                        //    SetMainData();
                        //    btnConfirm.Enabled = false;
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
            return true;
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
            //btnInsertMaster.Tag = "ProductionPlan_INSERT";
            //btnUpdateMaster.Tag = "ProductionPlan_EDIT";
            //btnQueryMaster.Tag = "ProductionPlan_QUERY";
        }

        public override void RevokeData()
        {
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as ProductionPlan;

                if (plan != null)
                {
                    try
                    {
                        //bool revokeResult = Service.RevokeProductionPlan(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

                        //if (revokeResult)
                        //{
                        //    CurrentMasterData = Service.GetProductionPlan(plan.PlanId);
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

            var plan = CurrentMasterData as ProductionPlan;
            if (plan != null)
            {
                List<ProductionPlanDetail> details =
                    DeatilService.FindAll(c => c.ProductionPlanId == plan.ProductionPlanId);

                listLocalData = ObjCopyToLocal(details);
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
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as ProductionPlan;
                if (plan != null) CurrentMasterData = Service.GetById(plan.ProductionPlanId);

                LoadDetailData();
            }
        }

        public override void SetMainData()
        {
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as ProductionPlan;

                if (plan != null)
                {
                    Text = string.Format(" 生产计划 - {0}", plan.Code);


                    _settings.DataFromEntity(plan);
                }
            }
        }


        public override void SaveData()
        {
            ProductionPlan plan = null;
            if (MasterDataState == DataState.Create)
            {
                plan = new ProductionPlan
                    {
                        Status = ProductionPlanStatus.Created,
                        CreaterId = GlobalState.CurrentUser.UserId,
                        CreateTime = DateTime.Now,DeliveryDate = DateTimeHelper.Min
                    };
            }
            if (MasterDataState == DataState.Update)
            {
                plan = CurrentMasterData as ProductionPlan;
                if (plan != null)
                {
                }
            }

            if (plan != null)
            {
                _settings.DataToEntity(plan);

                if (MasterDataState == DataState.Create)
                {
                    if (Service.Save(plan) <= 0)
                    {
                        FormHelper.ShowErrorDialog("创建入库计划失败。");
                        return;
                    }
                }
                if (MasterDataState == DataState.Update)
                {
                    bool updateResult = Service.Save(plan) > 0;
                    if (!updateResult)
                    {
                        FormHelper.ShowErrorDialog("更新入库计划失败。");
                        return;
                    }
                }

                CurrentMasterData = plan;
                SetMainData();
            }

            if (plan != null)
            {
                foreach (ProductionPlanDetailModel localInfo in listLocalData)
                {
                    switch (localInfo.OperationName)
                    {
                        case "ADD":
                            {
                                localInfo.ProductionPlanId = plan.ProductionPlanId; //改成主键
                                int newID = DeatilService.Save(
                                    localInfo);
                                if (newID <= 0)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                localInfo.ProductionPlanDetailId = newID;
                                break;
                            }
                        case "EDIT":
                            {
                                bool updateResult =
                                    DeatilService.Save(localInfo) > 0;
                                if (!updateResult)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                break;
                            }
                        case "DELETE":
                            {
                                bool deleteResult =
                                    Service.Delete(localInfo.GetEntityId()) > 0;
                                if (!deleteResult)
                                {
                                    throw new Exception();
                                }
                                break;
                            }

                            //case "NONE":
                            //    {
                            //        bool updateResult = GenericServiceHelper.Update<ProductionPlanDetail>(out bllResult, ObjCopyToParent(localInfo));
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

            CountData();
        }

        public override void DeleteLocalData()
        {
            if (CurrentDetailData == null) return;

            var localInfo = CurrentDetailData as ProductionPlanDetailModel;

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
            var plan = CurrentMasterData as ProductionPlan;
            if (plan != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary((int) plan.Status);
                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode !=
                        DictionaryHelper.ConvertToDictionaryCode((int) ProductionPlanStatus.Created) &&
                        dictionary.DictionaryCode !=
                        DictionaryHelper.ConvertToDictionaryCode((int) ProductionPlanStatus.Finished))
                    {
                        FormHelper.ShowWarningDialog("此入库计划当前状态不允许被编辑。");
                        return false;
                    }
                }
            }

            return true;
        }

        public override bool ValidateMainData()
        {
            return _settings.Validate(Validator);
        }

        public override void CustomizeDetailGrid()
        {
            _detailSettings.SetGridColumn(DetailGridView);
        }

        private IList<ProductionPlanDetailModel> ObjCopyToLocal(IList<ProductionPlanDetail> entyInfoList)
        {
            IList<ProductionPlanDetailModel> list = new List<ProductionPlanDetailModel>();

            Type ts = typeof (ProductionPlanDetail);
            PropertyInfo[] pis = ts.GetProperties();

            Type t = typeof (ProductionPlanDetailModel);

            for (int c = 0, count = entyInfoList.Count; c < count; c++)
            {
                var info = new ProductionPlanDetailModel();

                for (int i = 0, j = pis.Length; i < j; i++)
                {
                    PropertyInfo pi = t.GetProperty(pis[i].Name);
                    try
                    {
                        pi.SetValue(info, pis[i].GetValue(entyInfoList[c], null), null);
                    }
                    catch (Exception ex)
                    {
                        ex.Process();
                    }
                }
                info.TempId = c;
                info.OperationName = "NONE";
                list.Add(info);
            }

            return list;
        }
    }
}