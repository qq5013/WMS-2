using System;
using System.Collections.Generic;
using System.ServiceModel;
using Business.Common.Exception;
using Frame.Utils.Service;
using Framework.UI.Template.Common;
using Framework.UI.Template.Single;
using MES.BllService;
using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.ProductLineModel
{
    public partial class ProductLineEditForm : SingleEditForm
    {
        private List<EntitySetting<ProductLine>> _settings;

        public ProductLineEditForm()
        {
            InitializeComponent();
        }

        public IEntityService<ProductLine> Service
        {
            get { return ServiceBloker.GetService<ProductLine>(); }
        }

        public override void InitForm()
        {
            _settings =
                new List<EntitySetting<ProductLine>>()
                    .Setting(c => c.Name, new EntitySetting
                        {
                            Name = "产线名称",
                            Control = teName,
                            Required = true
                        })
                    .Setting(c => c.Code, new EntitySetting
                        {
                            Name = "产线代码",
                            Required = true,
                            Control = teCode
                        })
                    .Setting(c => c.ProductLineType, new EntitySetting
                        {
                            Name = "产线类别",
                            Control = lueProductLineType.BindProductLineType(ControlMode.Edit),
                            Required = true
                        })
                    .Setting(c => c.Description, new EntitySetting
                        {
                            Name = "描述",
                            Control = meRemark
                        });

            if (CurrentData != null)
            {
                var productLine = CurrentData as ProductLine;
                if (productLine != null)
                    BackupData = productLine.Clone() as ProductLine;
            }
            tcDetail.BackColor = BackColor;
        }


        public override bool CreateData()
        {
            try
            {
                int newId = Service
                    .Save((ProductLine) CurrentData);
                CurrentData = Service.GetById(newId);
                DataList.Add(CurrentData);
            }
            catch (FaultException<ServiceError> sex)
            {
                sex.Process();
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

                return false;
            }
            catch (Exception ex)
            {
                ex.Process();
                return false;
            }
            return true;
        }

        public override bool UpdateData()
        {
            try
            {
                bool updateResult =
                    Service.Save((ProductLine) CurrentData) > 0;
                return updateResult;
            }
            catch (FaultException<ServiceError> sex)
            {
                sex.Process();
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

                return false;
            }
            catch (Exception ex)
            {
                ex.Process();
                return false;
            }
        }

        public override void SaveFormData()
        {
            ProductLine productLine = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        productLine = new ProductLine();
                        CurrentData = productLine;
                    }
                    break;
                case DataState.Update:
                    {
                        productLine = BackupData as ProductLine;
                        CurrentData = productLine;
                    }
                    break;
                case DataState.Copy:
                    {
                        productLine = BackupData as ProductLine;
                        productLine.ProductLineId = 0;
                        CurrentData = productLine;
                    }
                    break;
            }

            if (productLine != null)
            {
                _settings.DataToEntity(productLine);
            }
        }

        public override void SetFormData()
        {
            var productLine = CurrentData as ProductLine;
            if (productLine != null)
            {
                _settings.DataFromEntity(productLine);
            }
        }

        public override bool ValidateData()
        {
            return _settings.Validate(Validator);
        }

        public override void ClearFormData()
        {
            _settings.ClearValue();
        }

        public override void SetInputStatus()
        {
            switch (CurrentDataState)
            {
                case DataState.Create:
                case DataState.Update:
                    {
                        gcBase.Enabled = true;

                        break;
                    }
            }
        }
    }
}