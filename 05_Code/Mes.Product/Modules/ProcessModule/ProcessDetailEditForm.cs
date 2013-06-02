using System;
using System.Collections;
using System.Collections.Generic;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.ProcessModule
{
    public partial class ProcessDetailEditForm : DetailEditForm
    {
        public int CurrentGoodsId;
        private List<EntitySetting<ProcessStep>> _settings;

        public ProcessDetailEditForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            _settings = new List<EntitySetting<ProcessStep>>()
                .Setting(c => c.SkuId, new EntitySetting
                    {
                        Name = "物料代码",
                        Width = 100,
                        Control = lueSku.BindMaterial(ControlMode.Edit)
                    })
                .Setting(c => c.Quantity, new EntitySetting
                    {
                        Name = "数量",
                        Width = 100,
                        Control = seQuantity.BindNumber()
                    })
                .Setting(c => c.MeasureId, new EntitySetting
                    {
                        Name = "单位",
                        Width = 100,
                        Control = lueMeasure.BindUnit(lueSku,ControlMode.Edit)
                    })
                .Setting(c => c.Description, new EntitySetting
                    {
                        Name = "装配指导",
                        Width = 100,
                        Control = meDescription
                    })
                .Setting(c => c.Sequence, new EntitySetting
                    {
                        Name = "装配顺序",
                        Width = 100,
                        Control = seSequence.BindNumber()
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "描述",
                        Width = 100,
                        Control = meRemark
                    });
        }

        public override void SetFormData()
        {
            if (CurrentDetailData != null)
            {
                var planDetail = CurrentDetailData as ProcessStep;

                if (planDetail != null)
                {
                    _settings.DataFromEntity(planDetail);
                }
            }
        }

        public override void SaveLocalData()
        {
            var editForm = ReferenceParentForm as ProcessEditForm;

            if (CurrentDataState == DataState.Create)
            {
                var localInfo = new ProcessStepModel();

                _settings.DataToEntity(localInfo);

                localInfo.OperationName = "ADD";

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
                var localInfo = CurrentDetailData as ProcessStepModel;

                if (localInfo != null)
                {
                   _settings.DataToEntity(localInfo);

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
        public bool FindSameSku(ProcessStepModel newProcessStepModel)
        {
            try
            {
                IList oldInfo = ReferenceParentForm.DetailDataList;
                foreach (ProcessStepModel oldLocalDataInfo in oldInfo)
                {
                    if (oldLocalDataInfo.SkuId == newProcessStepModel.SkuId) //货物代码
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                ex.Process();
                return false;
            }
        }

        public override bool ValidateData()
        {
            return _settings.Validate(Validator);
        }

        public override void ClearControl()
        {
            _settings.ClearValue();
        }
    }
}