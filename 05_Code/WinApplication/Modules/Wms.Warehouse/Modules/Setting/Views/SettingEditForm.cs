using System.Windows.Forms;
using Business.Common.Exception;
using Business.Domain.Warehouse;
using Framework.Core.Exception;
using Framework.UI.Template.Common;
using Wms.Common;
using System.ServiceModel;

namespace Modules.SettingModule.Views
{
    public partial class SettingEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        public SettingEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            if (CurrentData != null)
            {
                Setting setting = CurrentData as Setting;
                if (setting != null)
                    BackupData = setting.Clone() as Setting;
            }

            tcDetail.BackColor = this.BackColor;
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.WarehouseService.CreateSetting((Setting)CurrentData);
                CurrentData = ServiceHelper.WarehouseService.GetSetting(newId);
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
                return ServiceHelper.WarehouseService.UpdateSetting((Setting)CurrentData);
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
            Setting setting = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        setting = new Setting();
                        setting.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        setting.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = setting;
                    }
                    break;
                case DataState.Update:
                    {
                        setting = BackupData as Setting;
                        setting.EditUser = GlobalState.CurrentUser.UserId;
                        CurrentData = setting;
                        break;
                    }
                case DataState.Copy:
                    {
                        setting = BackupData as Setting;
                        setting.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        setting.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = setting;
                    }
                    break;
            }

            if (setting != null)
            {
                setting.SettingCode = txtSettingCode.Text.Trim();
                setting.SettingValue = txtSettingValue.Text.Trim();
                setting.ValueType = txtValueType.Text.Trim();
                setting.Remark = txtRemark.Text.Trim();
                setting.IsActive = cbIsActive.SelectedIndex == 0;
            }
        }

        public override void SetFormData()
        {
            Setting setting = CurrentData as Setting;
            if (setting != null)
            {
                txtSettingCode.Text = setting.SettingCode;
                txtSettingValue.Text = setting.SettingValue;
                txtValueType.Text = setting.ValueType;
                txtRemark.Text = setting.Remark;
                if (setting.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;

                txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(setting.CreateUser);
                txtCreateTime.Text = setting.CreateTime;
                txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(setting.EditUser);
                txtEditTime.Text = setting.EditTime;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;
            if (txtSettingCode.Text.Trim() == string.Empty)
            {
                string tip = "请填写设置代码。";
                Validator.SetError(txtSettingCode, tip);
                result = false;
            }

            if (txtSettingValue.Text.Trim() == string.Empty)
            {
                string tip = "请填写设置值。";
                Validator.SetError(txtSettingValue, tip);
                result = false;
            }

            if (cbIsActive.SelectedIndex == -1)
            {
                string tip = "请选择是否可用。";
                Validator.SetError(cbIsActive, tip);
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            txtSettingCode.Text  = string.Empty;
            txtSettingValue.Text  = string.Empty;
            txtValueType.Text = string.Empty;
            txtRemark.Text  = string.Empty;
            cbIsActive.SelectedIndex = 0;

            txtCreateTime.Text = string.Empty;
            txtCreateUser.Text = string.Empty;
            txtEditTime.Text = string.Empty;
            txtEditUser.Text = string.Empty;
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
                        break;
                    }
                default:
                    {
                        gcBase.Enabled = false;
                        gcOther.Enabled = false;
                    }
                    break;
            }
        }
    }
}

