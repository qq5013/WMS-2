/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         
// 文件功能描述：   
//
// 
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Execute.Properties;

namespace MES.Execute
{
    /// <summary>
    ///     修改密码,成功返回Ok，错误返回Cancel
    /// </summary>
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        ///     修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDoneClick(object sender, EventArgs e)
        {
            ClearError();

            // 检查就密码是否正确
            User currentUser = CommonApi.CurrentUser();
            if (String.CompareOrdinal(teOldPassword.Text, currentUser.Password) != 0)
            {
                ShowError(Resources.PasswordError);
                return;
            }

            // 检查是否符合新密码规则
            string newPassword = teNewPassword.Text;
            if (!FitPasswordRule(newPassword))
            {
                ShowError(Resources.NewPasswordTooShort);
                return;
            }

            // 检查2次密码匹配
            string newPasswordAgain = teNewPasswordAgain.Text;
            if (String.CompareOrdinal(newPassword, newPasswordAgain) != 0)
            {
                ShowError(Resources.NewPasswordAgain);
                return;
            }

            currentUser.Password = newPassword;
            try
            {
                ServiceBloker.GetService<User>().Save(currentUser);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CommonApi.Logger.Write(ex);
            }
        }

        /// <summary>
        ///     符合密码规则
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        private static bool FitPasswordRule(string newPassword)
        {
            return newPassword.Length >= 3;
        }

        /// <summary>
        ///     清空错误
        /// </summary>
        private void ClearError()
        {
            lblErrorMessage.Text = string.Empty;
        }

        /// <summary>
        ///     显示错误
        /// </summary>
        /// <param name="error"></param>
        private void ShowError(string error)
        {
            lblErrorMessage.Text = error;
        }
    }
}