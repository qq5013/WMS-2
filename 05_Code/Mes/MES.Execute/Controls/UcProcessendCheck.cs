/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcProcessendCheck.cs
// 文件功能描述：   工序完工检查
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
using System.Text;
using System.Windows.Forms;
using Frame.Utils.Crypt;
using Frame.Utils.Service;
using MES.BllService;
using MES.Entity;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 工序完工检查
    /// </summary>
    public partial class UcProcessendCheck : UserControl
    {
        /// <summary>
        /// 工序完工检查
        /// </summary>
        public UcProcessendCheck()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 工序
        /// </summary>
        public ItemProcess ItemProcess { get; set; }

        /// <summary>
        /// 检验员
        /// </summary>
        public User Inspector { get; set; }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDone_Click(object sender, EventArgs e)
        {
            ItemProcess.InspectorId = Inspector.UserId;
            ParentForm.DialogResult = DialogResult.OK;
            // ParentForm.Close();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // ParentForm.Close();
        }
        /// <summary>
        /// 扫描检验员工号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit1_Properties_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    string s = buttonEdit1.Text.Trim();

                    var sb = new StringBuilder();
                    // 解密员工号
                    for (int index = 0; index < s.Length; index += 2)
                    {
                        var b = (char) Convert.ToByte(s.Substring(index, 2), 16);
                        sb.Append(b);
                    }
                    buttonEdit1.Text = string.Empty;
                    string decrypt = CryptHelper.Decrypt(sb.ToString());

                    Inspector = ServiceBloker.GetService<User>().Find(c => c.LogInName == decrypt);
                    if (Inspector == null)
                    {
                    }
                    else
                    {
                        lblCode.Text = decrypt;
                        btnDone.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}