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
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Execute.Properties;

namespace MES.Execute
{
    /// <summary>
    ///     登录界面
    /// </summary>
    public partial class FormLogon : Form
    {
        public FormLogon()
        {
            InitializeComponent();
        }

        private void FormLogon_Load(object sender, EventArgs e)
        {
            try
            {
             //   CommonApi.BindProduct(riglueProductName, riglueProductCode, false);
            }
            catch (Exception ex)
            {
                CommonApi.Logger.Write(ex);
                MessageBox.Show("网络无法连接，请联系系统管理员！");
                DialogResult = DialogResult.Cancel;
                return;
            }
            try
            {
                // 绑定工序
                glueProcess.BindProductLine(ControlMode.Edit);
            }
            catch (Exception ex)
            {
                CommonApi.Logger.Write(ex);
            }
        }

        private void BtnDoneClick(object sender, EventArgs e)
        {
            try
            {
               //  登录，保存登录信息
                //User user = ServiceBloker.GetService<User>().Find(c => c.LogInName == teLoginName.Text);
                //if (user == null || (string.Compare(user.Password, tePassword.Text) != 0))
                //{
                //    lblErrorMessage.Text = Resources.NameOrPasswordError;
                //    return;
                //}

                //if (CommonApi.CurrentProductStation != null)
                //{
                //    var process = (Process) glueProcess.GetSelectedDataRow();
                //    if (process == null)
                //    {
                //        lblErrorMessage.Text = Resources.PleaseSelectProcess;
                //        return;
                //    }
                //    CommonApi.CurrentProcess = process;
                //}

                CommonApi.CurrentUser(new User { UserId = 1, Name = "黄亮", ProductLineId = (int)glueProcess.EditValue });
            }
            catch (Exception ex)
            {
                CommonApi.Logger.Write(ex);
            }

            DialogResult = DialogResult.OK;
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}