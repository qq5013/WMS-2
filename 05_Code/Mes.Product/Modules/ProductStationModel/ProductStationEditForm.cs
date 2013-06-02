using System.Collections.Generic;
using System.ServiceModel;
using Business.Common.Exception;
using Frame.Utils.Service;
using Framework.UI.Template.Common;
using Framework.UI.Template.Single;
using MES.BllService;
using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.ProductStationModel
{
    public partial class ProductStationEditForm : SingleEditForm
    {
        private List<EntitySetting<ProductStation>> _settings;


        public ProductStationEditForm()
        {
            InitializeComponent();
        }

        public IEntityService<ProductStation> Service
        {
            get { return ServiceBloker.GetService<ProductStation>(); }
        }

        public override void InitForm()
        {
            _settings =
                new List<EntitySetting<ProductStation>>()
                    .Setting(c => c.Code, new EntitySetting
                        {
                            Name = "工位代码",
                            Control = teEdit,
                            Required = true,
                        })
                    .Setting(c => c.Name, new EntitySetting
                        {
                            Name = "工位名称",
                            Required = true,
                            Control = teName
                        })
                    .Setting(c => c.ProductLineId, new EntitySetting
                        {
                            Name = "产线代码",
                            Required = true,
                            Control = lueProductLine.BindProductLine(ControlMode.Edit),
                        })
                    .Setting(c => c.Remark, new EntitySetting
                        {
                            Name = "描述",
                            Control = meRemark
                        });

            if (CurrentData != null)
            {
                var productStation = CurrentData as ProductStation;
                if (productStation != null)
                    BackupData = productStation.Clone() as ProductStation;
            }

            tcDetail.BackColor = BackColor;
        }


        public override bool CreateData()
        {
            try
            {
                int newId = Service
                    .Save((ProductStation) CurrentData);
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

            return true;
        }

        public override bool UpdateData()
        {
            try
            {
                bool updateResult =
                    Service.Save((ProductStation) CurrentData) > 0;
                return updateResult;
            }
            catch (FaultException<ServiceError> sex)
            {
                sex.Process();
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

                return false;
            }
        }

        public override void SaveFormData()
        {
            ProductStation productStation = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        productStation = new ProductStation();
                        CurrentData = productStation;
                    }
                    break;
                case DataState.Update:
                    {
                        productStation = BackupData as ProductStation;
                        CurrentData = productStation;
                    }
                    break;
                case DataState.Copy:
                    {
                        productStation = new ProductStation {ProductLineId = 0};
                        CurrentData = productStation;
                    }
                    break;
            }

            if (productStation != null)
            {
                _settings.DataToEntity(productStation);
            }
        }

        public override void SetFormData()
        {
            var productStation = CurrentData as ProductStation;
            if (productStation != null)
            {
                _settings.DataFromEntity(productStation);
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