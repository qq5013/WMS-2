using System.Collections.Generic;
using Business.Domain.Wms;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.MaterialRequisitionModel
{
    /// <summary>
    /// 维护领料单明细
    /// </summary>
    public partial class MaterialRequisitionDetailEditForm : DetailEditForm
    {
        private readonly List<EntitySetting<MaterialRequisitionDetail>> _detailSettings;

        public int CurrentGoodsId;

        public MaterialRequisitionDetailEditForm()
        {
            InitializeComponent();

            _detailSettings = new List<EntitySetting<MaterialRequisitionDetail>>()
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品代码",
                        Width = 100,
                        Required = true,
                        Control = beSkuId
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
                        Control = lePackId
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
                        Control = lueUnit
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
            if (CurrentDetailData == null) return;
            var detail = CurrentDetailData as MaterialRequisitionDetail;

            if (detail == null) return;
            _detailSettings.DataFromEntity(detail);
        }

        public override void SaveLocalData()
        {
            var editForm = ReferenceParentForm as MaterialRequisitionEditForm;

            if (CurrentDataState == DataState.Create)
            {
                var localInfo = new MaterialRequisitionDetailModel {OperationName = "ADD"};

                _detailSettings.DataFromEntity(localInfo);


                if (editForm != null)
                {
                    editForm.listLocalData.Add(localInfo);
                    editForm.DetailDataList.Add(localInfo);
                }
            }

            if (CurrentDataState == DataState.Update)
            {
                var localInfo = CurrentDetailData as MaterialRequisitionDetailModel;

                if (localInfo != null)
                {
                    localInfo.SkuId = (beSkuId.Tag as Sku).SkuId;
                    _detailSettings.DataFromEntity(localInfo);

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