using System.Windows.Forms;
using Business.Common.Exception;
using Business.Domain.Warehouse;
using Framework.Core.Exception;
using Framework.UI.Template.Common;
using Wms.Common;
using System.ServiceModel;

namespace Modules.TagModule.Views
{
    public partial class TagEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        public TagEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            if (CurrentData != null)
            {
                Tag tag = CurrentData as Tag;
                if (tag != null)
                    BackupData = tag.Clone() as Tag;
            }

            tcDetail.BackColor = this.BackColor;
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.WarehouseService.CreateTag((Tag)CurrentData);
                CurrentData = ServiceHelper.WarehouseService.GetTag(newId);
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
                return ServiceHelper.WarehouseService.UpdateTag((Tag)CurrentData);
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
            Tag tag = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        tag = new Tag();
                        tag.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        tag.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = tag;
                    }
                    break;
                case DataState.Update:
                    {
                        tag = BackupData as Tag;
                        tag.EditUser = GlobalState.CurrentUser.UserId;
                        break;
                    }
                case DataState.Copy:
                    {
                        tag = BackupData as Tag;
                        tag.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        tag.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = tag;
                    }
                    break;
            }

            if (tag != null)
            {
                tag.TagNumber = txtTagNumber.Text.Trim();
                tag.Remark = txtRemark.Text.Trim();
                tag.IsActive = cbIsActive.SelectedIndex == 0;
            }
        }

        public override void SetFormData()
        {
            Tag tag = CurrentData as Tag;
            if (tag != null)
            {
                txtTagNumber.Text = tag.TagNumber;
                txtRemark.Text = tag.Remark;
                if (tag.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;

                txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(tag.CreateUser);
                txtCreateTime.Text = tag.CreateTime;
                txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(tag.EditUser);
                txtEditTime.Text = tag.EditTime;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;
            if (txtTagNumber.Text.Trim() == string.Empty)
            {
                string tip = "请填写标签名称。";
                Validator.SetError(txtTagNumber, tip);
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
            txtTagNumber.Text  = string.Empty;
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

