/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         FormExtension.cs
// 文件功能描述：   窗体扩展方法
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

using System.Windows.Forms;

namespace MES.Execute.Common
{
    /// <summary>
    ///     窗体扩展方法
    /// </summary>
    public static class FormExtension
    {
        /// <summary>
        ///     对话框
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static DialogResult Dialog(this Form form)
        {
            Control control = form.Controls[0];
            if (control != null) control.Dock = DockStyle.Fill;
            form.MaximizeBox = false;
            form.ShowInTaskbar = false;
            form.ShowIcon = false;
            form.StartPosition = FormStartPosition.CenterScreen;

            // 按ESC退出
            form.KeyPress += (sender, e) =>
                {
                    if (e.KeyChar == (char) 27)
                    {
                        form.Close();
                    }
                };
            // 窗体可以接受按钮事件
            form.KeyPreview = true;
            return form.ShowDialog();
        }
    }
}