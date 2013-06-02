using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Business.Common.DataDictionary;
using Business.Common.QueryModel;
using Business.Common.Exception;
using Business.Domain.Application;
using Business.Domain.Warehouse;
using Framework.Core.Exception;
using Framework.UI.Template.Common;
using Wms.Common;
using System.ServiceModel;

namespace Modules.ContainerTypeModule.Views
{
    public partial class ContainerTypeEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        public ContainerTypeEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {

            InitComboBox(); 
            if (CurrentData != null)
            {
                ContainerType containerType = CurrentData as ContainerType;
                if (containerType != null)
                    BackupData = containerType.Clone() as ContainerType;
            }

            tcDetail.BackColor = this.BackColor;
        }

        private void InitComboBox()
        {
            // abc type
            Query query = new Query();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.PURPOSE_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> types = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            lePurposeType.Properties.DataSource = types;
            lePurposeType.Properties.DisplayMember = "DictionaryValue";
            lePurposeType.Properties.ValueMember = "DictionaryId";
            lePurposeType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            lePurposeType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.WarehouseService.CreateContainerType((ContainerType)CurrentData);
                CurrentData = ServiceHelper.WarehouseService.GetContainerType(newId);
                DataList.Add(CurrentData);
                return true;
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            return false;
        }

        public override bool UpdateData()
        {
            try
            {
                return ServiceHelper.WarehouseService.UpdateContainerType((ContainerType)CurrentData);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

            }

            return false;
        }

        public override void SaveFormData()
        {
            ContainerType type = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        type = new ContainerType();
                        type.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = type;
                    }
                    break;
                case DataState.Update:
                    {
                        type = BackupData as ContainerType;
                        CurrentData = type;
                        break;
                    }
                case DataState.Copy:
                    {
                        type = BackupData as ContainerType;
                        type.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = type;
                    }
                    break;
            }

            if (type != null)
            {
                type.TypeCode = txtTypeCode.Text.Trim();
                type.TypeName = txtTypeName.Text.Trim();

                type.Length = seLength.Value;
                type.Width = seWidth.Value;
                type.Height = seHeight.Value;

                type.Weight = seWeight.Value;
                type.BearingWeight = seBearingWeight.Value;

                if (lePurposeType.EditValue != null)
                    type.PurposeType = (int)lePurposeType.EditValue;
            }
        }

        public override void SetFormData()
        {
            ContainerType type = CurrentData as ContainerType;
            if (type != null)
            {
                txtTypeCode.Text = type.TypeCode;
                txtTypeName.Text = type.TypeName;

                seLength.Value = type.Length;
                seWidth.Value = type.Width;
                seHeight.Value = type.Height;
                seWeight.Value = type.Weight;
                seBearingWeight.Value = type.BearingWeight;
                lePurposeType.EditValue = type.PurposeType;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;
            if (txtTypeCode.Text.Trim() == string.Empty)
            {
                string tip = "请填写容器类型代码。";
                Validator.SetError(txtTypeCode, tip);
                result = false;
            }

            if (txtTypeName.Text.Trim() == string.Empty)
            {
                string tip = "请填写容器类型名称。";
                Validator.SetError(txtTypeName, tip);
                result = false;
            }

            if (lePurposeType.EditValue == null)
            {
                string tip = "请选择用途类型。";
                Validator.SetError(lePurposeType, tip);
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            txtTypeCode.Text  = string.Empty;
            txtTypeName.Text  = string.Empty;

            seWeight.Value = 0.0m;
            seBearingWeight.Value = 0.0m;
            seLength.Value = 0.0m;
            seWidth.Value = 0.0m;
            seHeight.Value = 0.0m;
            lePurposeType.EditValue = null;
        }

        public override void SetInputStatus()
        {
            switch (CurrentDataState)
            {
                case DataState.Create:
                case DataState.Copy:
                case DataState.Update:
                    {
                        gcBase.Enabled = true;
                        gcSpec.Enabled = true;
                        break;
                    }
                default:
                    {
                        gcBase.Enabled = false;
                        gcSpec.Enabled = false;
                    }
                    break;
            }
        }
    }
}

