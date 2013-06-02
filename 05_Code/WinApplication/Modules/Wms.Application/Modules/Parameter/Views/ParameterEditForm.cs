using Business.Common.Exception;
using Business.Domain.Application;
using Framework.UI.Template.Common;
using Framework.UI.Template.Single;
using Wms.Common;
using System.ServiceModel;

namespace Modules.ParameterModule.Views
{
    public partial class ParameterEditForm : SingleEditForm
    {
        public ParameterEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            if (CurrentData != null)
            {
                var parameter = CurrentData as Parameter;
                if (parameter != null)
                    BackupData = parameter.Clone() as Parameter;
            }

            tcDetail.BackColor = BackColor;
        }

        public override bool CreateData()
        {
            try
            {
                var newParameter = ServiceHelper.ApplicationService.CreateParameter((Parameter)CurrentData);
                if (newParameter != null)
                {
                    CurrentData = newParameter;
                    DataList.Add(CurrentData);

                    return true;
                }
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
                return ServiceHelper.ApplicationService.UpdateParameter((Parameter)CurrentData);
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
            Parameter parameter = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        parameter = new Parameter();
                        parameter.ApplicationId = GlobalState.CurrentApplication.ApplicationId;
                        CurrentData = parameter;
                    }
                    break;
                case DataState.Update:
                case DataState.Copy:
                    {
                        parameter = BackupData as Parameter;
                        CurrentData = parameter;
                    }
                    break;
            }

            if (parameter != null)
            {
                parameter.ParameterCode = txtParameterName.Text.Trim();
                parameter.ParameterValue = txtParameterValue.Text.Trim();
                parameter.ValueType = txtValueType.Text.Trim();
                parameter.Remark = txtRemark.Text.Trim();
                parameter.IsActive = cbIsActive.SelectedIndex == 0;
            }
        }

        public override void SetFormData()
        {
            var parameter = CurrentData as Parameter;
            if (parameter != null)
            {
                txtParameterName.Text = parameter.ParameterCode;
                txtParameterValue.Text = parameter.ParameterValue;
                txtValueType.Text = parameter.ValueType;
                txtRemark.Text = parameter.Remark;

                cbIsActive.SelectedIndex = parameter.IsActive ? 0 : 1;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;
            if (txtParameterName.Text.Trim() == string.Empty)
            {
                const string tip = "请填写参数代码。";
                Validator.SetError(txtParameterName, tip);
                txtParameterName.Focus();
                result = false;
            }

            if (txtParameterValue.Text.Trim() == string.Empty)
            {
                const string tip = "请填写参数值。";
                Validator.SetError(txtParameterValue, tip);
                txtParameterValue.Focus();
                result = false;
            }

            if (cbIsActive.SelectedIndex == -1)
            {
                const string tip = "请选择是否可用。";
                Validator.SetError(cbIsActive, tip);
                cbIsActive.Focus();
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            txtParameterName.Text  = string.Empty;
            txtParameterValue.Text  = string.Empty;
            txtValueType.Text = string.Empty;
            txtRemark.Text  = string.Empty;
            cbIsActive.SelectedIndex = 0;
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
                        gcOther.Enabled = true;
                    }
                    break;
                default :
                    {
                        gcBase.Enabled = false;
                        gcOther.Enabled = false;
                    }
                    break;
            }
        }
    }
}

