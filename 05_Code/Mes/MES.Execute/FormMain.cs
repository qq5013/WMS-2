/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：FormMain.cs
// 文件功能描述：主功能界面，容器功能
//
// 
// 创建标识：2010.10月创建
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using MES.Common;
using MES.Entity;
using MES.Enum;
using MES.Execute.Controls;

namespace MES.Execute
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /////<summary>控制界面，不让推动标题栏.
        /////</summary>
        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    if (m.Msg == 0x84) //不让拖动标题栏 
        //    {
        //        if ((IntPtr) 2 == m.Result)
        //            m.Result = (IntPtr) 1;
        //    }
        //    if (m.Msg == 0x00A3) //双击标题栏无反应 
        //        m.WParam = IntPtr.Zero;
        //}

        private void FormMain_Load(object sender, EventArgs e)
        {
            Visible = false;
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CommonApi.Logger.Write(ex);
            }

            try
            {
                Visible = true;
            }
            catch
            {
            }
        }

        /// <summary>
        ///  初始化
        /// </summary>
        private void Init()
        {
            lblStationName.Text = string.Format("工作站名称：{0}", Environment.MachineName);
            var formLogon = new FormLogon();
            ucMenu1.TableControl = this.xtraTabControl1;
            ucMenu1.Init();
            if (formLogon.ShowDialog() == DialogResult.OK)
            {
                labelControl1.Text = "登录用户：" + CommonApi.CurrentUser().Name;
              
               
                Process process = CommonApi.CurrentProcess;
                ProductStation productStation = CommonApi.CurrentProductStation;

                if (process != null)
                {
                    if (process.Type == (int) ProcessType.Normal)
                    {
                        var normal = new UcProcessNormal
                                         {
                                             Process = process,
                                             ProductStation = productStation
                                         };
                        normal.Init();
                        //CommonApi.CurrentProcessControl = normal;
                        xtraTabControl1.ShowPage(normal, "工位", DefaultBoolean.False, null);
                    }
               
                }
            }
            else
            {
                Close();
            }
 
        }


        private void BtnCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // 修改密码
            new FormChangePassword().ShowDialog();
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            // 关闭page
            xtraTabControl1.TabPages.Remove(xtraTabControl1.SelectedTabPage);
        }
    }
}