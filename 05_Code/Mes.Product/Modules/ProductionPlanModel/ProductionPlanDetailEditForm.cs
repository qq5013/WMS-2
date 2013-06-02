using System;
using System.Collections.Generic;
using System.Data;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.ProductionPlanModel
{
    public partial class ProductionPlanDetailEditForm : DetailEditForm
    {
        private readonly List<EntitySetting<ProductionPlanDetail>> _detailSettings;
        public int CurrentGoodsId;

        public ProductionPlanDetailEditForm()
        {
            InitializeComponent();

            //产品代码	产品名称	产品类型		生产数量(可以按周下单)		 	单位	完工日期	备注
            lueProductCode.Properties.EditValueChanged += (sender, e) =>
                {
                    try
                    {
                        var dataRowView = ((DataRowView) lueProductCode.GetSelectedDataRow());
                        txtSKuName.EditValue = dataRowView["SkuName"].ToString();
                        textEdit1.EditValue = dataRowView["CategoryName"].ToString();
                    }
                    catch (Exception)
                    {
                        
                       // throw;
                    }
                   
                };
            _detailSettings = new List<EntitySetting<ProductionPlanDetail>>()
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品代码",
                        Width = 100,
                        Required = true,
                        Control = lueProductCode.BindProductCode()
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
                        Control = textEdit1
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
                        Control = lueMeasure.BindUnit(lueProductCode)
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
                var planDetail = CurrentDetailData as ProductionPlanDetail;

                if (planDetail != null)
                {
                    _detailSettings.DataFromEntity(planDetail);
                }
            }
        }

        public override void SaveLocalData()
        {
            var editForm = ReferenceParentForm as ProductionPlanEditForm;

            if (CurrentDataState == DataState.Create)
            {
                var localInfo = new ProductionPlanDetailModel();

                _detailSettings.DataToEntity(localInfo);

                localInfo.OperationName = "ADD";


                if (editForm != null)
                {
                    editForm.listLocalData.Add(localInfo);
                    editForm.DetailDataList.Add(localInfo);
                }
            }

            if (CurrentDataState == DataState.Update)
            {
                var localInfo = CurrentDetailData as ProductionPlanDetailModel;

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