using System.Collections;
using System.Windows.Forms;
using Wms.Common;
using Framework.UI.Template;
using Framework.UI.Template.Common;
using Business.Domain.Application;
using Framework.Core.Exception;
using DevExpress.XtraEditors.Controls;
using Business.Common;
using Business.Common.Exception;
using Framework.Core.Encryption;
using System.ServiceModel;

namespace Modules.UserModule.Views
{
    public partial class UserEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        public UserEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            if (CurrentData != null)
            {
                User user = CurrentData as User;
                if (user != null) 
                    BackupData = user.Clone() as User;
            }

            tcDetail.BackColor = this.BackColor;
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.ApplicationService.CreateUser((User)CurrentData);
                CurrentData = ServiceHelper.ApplicationService.GetUser(newId);
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
                return ServiceHelper.ApplicationService.UpdateUser((User)CurrentData);
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
            User user = null;

            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        user = new User();
                        user.ApplicationId = GlobalState.CurrentApplication.ApplicationId;
                        CurrentData = user;
                    }
                    break;
                case DataState.Update:
                case DataState.Copy:
                    {
                        user = BackupData as User;
                        CurrentData = user;
                    }
                    break;
            }

            if (user != null)
            {
                user.UserCode = txtUserCode.Text.Trim();
                user.UserName = txtUserName.Text.Trim();
                user.Password = EncryptHelper.Encrypt(txtPassword.Text.Trim());
                user.Remark = txtRemark.Text.Trim();
                user.IsActive = cbIsActive.SelectedIndex == 0;
            }
        }

        public override void SetFormData()
        {
            User user = CurrentData as User;
            if (user != null)
            {
                txtUserCode.Text = user.UserCode;
                txtUserName.Text = user.UserName;
                txtPassword.Text = EncryptHelper.Decrypt(user.Password);
                txtPasswordAgain.Text = txtPassword.Text;
                txtCreateTime.Text = user.CreateTime;
                txtLoginTime.Text = user.LoginTime;
                txtRemark.Text = user.Remark;

                if (user.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;
            if (txtUserCode.Text.Trim() == "")
            {
                Validator.SetError(txtUserCode, "请填写用户代码。");
                result = false;
            }

            if (txtUserName.Text.Trim() == "")
            {
                Validator.SetError(txtUserName, "请填写用户姓名。");
                result = false;
            }


            if (txtPassword.Text.Trim() == "")
            {
                Validator.SetError(txtPassword, "请填写登录口令。");
                result = false;
            }

            if (txtPassword.Text.Trim() != txtPasswordAgain.Text.Trim())
            {
                Validator.SetError(txtPassword, "请填写一致的口令。");
                Validator.SetError(txtPasswordAgain, "请填写一致的口令。");
                result = false;
            }

            if (cbIsActive.SelectedIndex == -1)
            {
                Validator.SetError(cbIsActive, "请选择是否可用。");
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            txtUserCode.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPasswordAgain.Text = string.Empty;
            txtRemark.Text = string.Empty;
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

