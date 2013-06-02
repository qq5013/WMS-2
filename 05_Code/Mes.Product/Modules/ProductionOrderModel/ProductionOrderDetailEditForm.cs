using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.ProductionOrderModel
{
    public partial class ProductionOrderDetailEditForm : DetailEditForm
    {
        private readonly List<EntitySetting<ProductionOrderDetail>> _detailSettings;
        public int CurrentGoodsId;

        public ProductionOrderDetailEditForm()
        {
            InitializeComponent();

            //产品代码	产品名称	产品类型		生产数量(可以按周下单)		 	单位	完工日期	备注
            lueProduct.Properties.EditValueChanged += (sender, e) =>
                {
                    try
                    {
                        var dataRowView = ((DataRowView) lueProduct.GetSelectedDataRow());
                        txtSKuName.EditValue = dataRowView["SkuName"].ToString();
                        teProduct.EditValue = dataRowView["CategoryName"].ToString();
                    }
                    catch (Exception)
                    {
                        // throw;
                    }
                };


            _detailSettings = new List<EntitySetting<ProductionOrderDetail>>()
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品代码",
                        Width = 100,
                        Required = true,
                        Control = lueProduct.BindProduct()
                    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品名称",
                        Width = 100,
                        Control = txtSKuName
                    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品类型",
                        Width = 100,
                        Control = teProduct
                    })
                .Setting(c => c.Quantity, new EntitySetting
                    {
                        Name = "生产数量",
                        Width = 100,
                        Required = true,
                        Control = seQuantity
                    })
                .Setting(c => c.MeasureId, new EntitySetting
                    {
                        Name = "单位",
                        Width = 100,
                        Control = lueUnit.BindUnit(lueProduct)
                    })
                .Setting(c => c.FinishDate, new EntitySetting
                    {
                        Name = "完工日期",
                        Width = 100,
                        Control = deFinishDate
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Width = 100,
                        Control = meRemark
                    });
        }

        public override void SetFormData()
        {
            if (CurrentDetailData != null)
            {
                var planDetail = CurrentDetailData as ProductionOrderDetail;

                if (planDetail != null)
                {
                    _detailSettings.DataFromEntity(planDetail);
                }
            }
        }

        public override void SaveLocalData()
        {
            var editForm = ReferenceParentForm as ProductionOrderEditForm;

            if (CurrentDataState == DataState.Create)
            {
                var localInfo = new ProductionOrderDetailModel {OperationName = "ADD"};

                _detailSettings.DataToEntity(localInfo);


                bool result = FindSameSku(localInfo);
                if (result)
                {
                    string tip = "明细中已存在相同货物。";
                    FormHelper.ShowWarningDialog(tip);
                    return;
                }

                if (editForm != null)
                {
                    editForm.listLocalData.Add(localInfo);
                    editForm.DetailDataList.Add(localInfo);
                }
            }

            if (CurrentDataState == DataState.Update)
            {
                var localInfo = CurrentDetailData as ProductionOrderDetailModel;

                if (localInfo != null)
                {
                    _detailSettings.DataToEntity(localInfo);


                    if (!localInfo.OperationName.Equals("ADD"))
                    {
                        localInfo.OperationName = "EDIT";
                    }

                    editForm.listLocalData[localInfo.TempId] = localInfo;
                    editForm.DetailDataList[localInfo.TempId] = localInfo;
                }
            }
        }

        /// <summary>
        ///     过滤明细表单,如果已有此类型的单据,则不允许新增,要求用户修改。
        ///     不允许存在相同货物的记录
        /// </summary>
        public bool FindSameSku(ProductionOrderDetailModel newProductionOrderDetailModel)
        {
            try
            {
                IList oldInfo = ReferenceParentForm.DetailDataList;
                return
                    oldInfo.Cast<ProductionOrderDetailModel>()
                           .Any(oldLocalDataInfo => oldLocalDataInfo.SkuId == newProductionOrderDetailModel.SkuId);
            }
            catch (Exception ex)
            {
                ex.Process();
                return false;
            }
        }

        public override bool ValidateData()
        {
            return _detailSettings.Validate(Validator);
        }

        public override void ClearControl()
        {
            _detailSettings.ClearValue();
        }
    }
}