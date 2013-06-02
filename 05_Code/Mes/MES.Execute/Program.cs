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
using MES.Common;

namespace MES.Execute
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                // 默认主窗体最大化
                Application.Run(new FormMain {WindowState = FormWindowState.Maximized});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CommonApi.Logger.Write(ex);
            }
        }
    }
}