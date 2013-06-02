using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Wms.Common;
using Framework.Core.Encryption;
using Business.Domain.Application;
using Business.Domain.Wms;
using System.ServiceModel;
using Business.Common.Exception;
using Framework.UI.Template.Common;

namespace Wms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User loginUser = null;

            if (ValidateLogin() == true)
            {
                try
                {
                    int warehouseId = (int)leWarehouse.EditValue;
                    loginUser = ServiceHelper.ApplicationService.ValidateUser(GlobalState.ApplicationCode, txtUserCode.Text, EncryptHelper.Encrypt(txtPassword.Text.Trim()), warehouseId);
                }
                catch (FaultException<ServiceError> sex)
                {
                    if (sex.Detail != null)
                        FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                }

                if (loginUser != null)
                {
                    GlobalState.CurrentUser = loginUser;
                    GlobalState.CurrentWarehouse = ServiceHelper.WarehouseService.GetWarehouse((int)leWarehouse.EditValue);
                    //GlobalState.LoginWarehouseId = (int)leWarehouse.EditValue;
                    //GlobalState.LoginWarehouseName = leWarehouse.Text;
                    GlobalState.CurrentAuthority = ServiceHelper.ApplicationService.GetUserFunctions(GlobalState.ApplicationCode, loginUser.UserCode);
                    TemplateCommon.AuthorityList = GlobalState.CurrentAuthority;
                    this.Close();
                }
                else
                {
                    txtUserCode.Focus();
                    FormHelper.ShowWarningDialog("仓库用户不存在或口令不正确，请重新登录。");
                }
            }
        }

        private bool ValidateLogin()
        {
            string userCode = txtUserCode.Text.Trim();
            string password = txtPassword.Text.Trim();

            bool result = true;
            if (userCode == string.Empty)
            {
                errorProvider.SetError(txtUserCode, "请输入用户代码。");
                txtUserCode.Focus();
                result = false;
            }
            if (password == string.Empty)
            {
                errorProvider.SetError(txtPassword, "请输入登录口令。");
                txtPassword.Focus();
                result = false;
            }

            if (leWarehouse.EditValue == null)
            {
                errorProvider.SetError(leWarehouse, "请选择登录仓库。");
                leWarehouse.Focus();
                result = false;
            }

            return result;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            InitAllWarehouse();
            

            this.txtUserCode.Text = "Admin";
            this.txtPassword.Text = "123456";
            leWarehouse.EditValue = 101;
        }

        private void InitAllWarehouse()
        {
            try
            {
                List<Warehouse> warehouses = ServiceHelper.WarehouseService.GetAllWarehouse();
                leWarehouse.Properties.DataSource = warehouses;
                leWarehouse.Properties.DisplayMember = "WarehouseName";
                leWarehouse.Properties.ValueMember = "WarehouseId";
                //leWarehouse.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseCode", "代码"));
                leWarehouse.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseName", "仓库名称"));
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                btnLogin.Enabled = false;
            }
            catch (Exception ex)
            {
               System.Console.Write(ex.Message);
            }
        }
    }
}
