using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Business.Common.DataDictionary;
using Business.Common.Exception;
using Business.Common.Toolkit;
using Business.Domain.Application;
using Business.Domain.Inventory;
using Frame.Utils.Service;
using Framework.Core.Collections;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Common;
using MES.Entity;
using Wms.Common;

namespace Mes.Product.Modules.MaterialRequisitionModel
{
    /// <summary>
    ///     编辑领料单
    /// </summary>
    public partial class MaterialRequisitionEditForm : MasterEditForm
    {
        public int NClientId;
        public int NMerchantId;
        private List<EntitySetting<MaterialRequisitionDetail>> _detailSettings;
        private IEntityService<MaterialRequisitionDetail> _detialService;
        private IEntityService<MaterialRequisition> _service;
        private List<EntitySetting<MaterialRequisition>> _settings;
        internal IList<MaterialRequisitionDetailModel> listLocalData = new List<MaterialRequisitionDetailModel>();


        public MaterialRequisitionEditForm()
        {
            InitializeComponent();
        }

        protected IEntityService<MaterialRequisition> Service
        {
            get { return _service ?? (_service = ServiceBloker.GetService<MaterialRequisition>()); }
        }

        protected IEntityService<MaterialRequisitionDetail> DetialService
        {
            get { return _detialService ?? (_detialService = ServiceBloker.GetService<MaterialRequisitionDetail>()); }
        }


        public override void PrintData()
        {
            //打印领料单
        }


        public override void FormInitialize()
        {
            RegisterDetailForm(typeof (MaterialRequisitionDetailEditForm).FullName);


            _settings = new List<EntitySetting<MaterialRequisition>>()
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
                        Control = deCreateTime.BindDate()
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Control = meRemark
                    });

            _detailSettings = new List<EntitySetting<MaterialRequisitionDetail>>();


            _detailSettings
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品代码",
                        Width = 100,
                        Control = null
                    })
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
            //btnConfirm.Visibility = BarItemVisibility.Always;
            //btnConfirm.Caption = @"审核";

            //btnRevoke.Visibility = BarItemVisibility.Always;
            //btnPrint.Visibility = BarItemVisibility.Always;

            //btnAdditionButton.Visibility = BarItemVisibility.Always;
            //btnAdditionButton.Caption = "打印条码标签";
        }


        public override void SetToolButtons()
        {
            base.SetToolButtons();

            // 判读当前单据状态是否可以审核
            var bill = CurrentMasterData as MaterialRequisition;
            if (bill != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(bill.Status);
                if (dictionary != null)
                {
                    //if (dictionary.DictionaryCode !=
                    //    DictionaryHelper.ConvertToDictionaryCode((int) InboundPlanStatus.Created) &&
                    //    dictionary.DictionaryCode !=
                    //    DictionaryHelper.ConvertToDictionaryCode((int) InboundPlanStatus.Modified))
                    //{
                    //    btnConfirm.Visibility = BarItemVisibility.Never;
                    //    btnUpdateMaster.Visibility = BarItemVisibility.Never;
                    //}

                    //if (dictionary.DictionaryCode !=
                    //    DictionaryHelper.ConvertToDictionaryCode((int) InboundPlanStatus.Created) &&
                    //    dictionary.DictionaryCode !=
                    //    DictionaryHelper.ConvertToDictionaryCode((int) InboundPlanStatus.Modified)
                    //    &&
                    //    dictionary.DictionaryCode !=
                    //    DictionaryHelper.ConvertToDictionaryCode((int) InboundPlanStatus.Confirmed))
                    //{
                    //    btnRevoke.Visibility = BarItemVisibility.Never;
                    //}
                }
            }
        }

        public override bool ConfirmData()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as MaterialRequisition;

                if (bill != null)
                {
                    try
                    {
                        //bool comfirmResult = Service.ConfirmMaterialRequisition(GlobalState.CurrentWarehouse.WarehouseId, bill.BillId, GlobalState.CurrentUser.UserId);

                        //if (comfirmResult)
                        //{
                        //    CurrentMasterData = Service.GetInboundPlan(bill.BillId);
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
            //btnInsertMaster.Tag = "INBOUNDPLAN_INSERT";
            //btnUpdateMaster.Tag = "INBOUNDPLAN_EDIT";
            //btnQueryMaster.Tag = "INBOUNDPLAN_QUERY";
        }

        public override void RevokeData()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as MaterialRequisition;

                if (bill != null)
                {
                    try
                    {
                        //bool revokeResult = Service.RevokeMaterialRequisition(GlobalState.CurrentWarehouse.WarehouseId, bill.BillId, GlobalState.CurrentUser.UserId);

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

            var bill = CurrentMasterData as MaterialRequisition;
            if (bill != null)
            {
                List<MaterialRequisitionDetail> details =
                    DetialService.FindAll(c => c.MaterialRequisitionId == bill.MaterialRequisitionId);

                IList<MaterialRequisitionDetailModel> materialRequisitionDetailModels =
                    new List<MaterialRequisitionDetailModel>();

                details.CopyTo(materialRequisitionDetailModels);

                listLocalData = materialRequisitionDetailModels;
                DetailDataList = listLocalData.ToArray();
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
                var order = CurrentMasterData as MaterialRequisition;
                CurrentMasterData = Service.GetById(order.GetEntityId());

                LoadDetailData();
            }
        }

        public override void SetMainData()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as MaterialRequisition;

                if (bill != null)
                {
                    Text = string.Format(" 入库单计划 - {0}", bill.Code);

                    MaterialRequisition plan = Service.GetById(bill.GetEntityId());
                    _settings.DataFromEntity(plan);
                }
            }
        }


        public override void SaveData()
        {
            MaterialRequisition bill = null;
            if (MasterDataState == DataState.Create)
            {
                bill = new MaterialRequisition {Status = 1};

                _settings.DataFromEntity(bill);
                bill.CreaterId = GlobalState.CurrentUser.UserId;
                bill.CreateTime = DateTime.Now;
            }
            if (MasterDataState == DataState.Update)
            {
                bill = CurrentMasterData as MaterialRequisition;
                if (bill != null)
                {
                    _settings.DataFromEntity(bill);
                }
            }

            if (bill != null)
            {
                _settings.DataToEntity(bill);


                if (MasterDataState == DataState.Create)
                {
                    bool bill1 = Service.Save(bill) > 0;
                    if (bill1)
                    {
                        FormHelper.ShowErrorDialog("创建领料单失败。");
                        return;
                    }
                }
                if (MasterDataState == DataState.Update)
                {
                    bool updateResult = Service.Save(bill) > 0;
                    if (!updateResult)
                    {
                        FormHelper.ShowErrorDialog("更新领料单失败。");
                        return;
                    }
                }

                CurrentMasterData = bill;
                SetMainData();
            }

            if (bill != null)
            {
                foreach (MaterialRequisitionDetailModel localInfo in listLocalData)
                {
                    switch (localInfo.OperationName)
                    {
                        case "ADD":
                            {
                                localInfo.MaterialRequisitionId = bill.MaterialRequisitionId; //改成主键
                                int newID = _detialService.Save(localInfo);
                                if (newID <= 0)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                localInfo.MaterialRequisitionDetailId = newID;
                                break;
                            }
                        case "EDIT":
                            {
                                bool updateResult = _detialService.Save(localInfo) > 0;
                                if (!updateResult)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                break;
                            }
                        case "DELETE":
                            {
                                bool deleteResult = _detialService.Delete(localInfo.GetEntityId()) > 0;
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

            var localInfo = CurrentDetailData as MaterialRequisitionDetailModel;

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
                        FormHelper.ShowWarningDialog("此领料单当前状态不允许被编辑。");
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
        }
    }
}