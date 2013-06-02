/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcMenu.cs
// 文件功能描述：   菜单控件
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
using DevExpress.Utils.Menu;
using DevExpress.XtraTab;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Execute.Controls;

namespace MES.Execute
{
    /// <summary>
    ///     菜单控件
    /// </summary>
    public sealed partial class UcMenu : UserControl
    {
        /// <summary>
        ///     菜单
        /// </summary>
        public UcMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     内容Tab
        /// </summary>
        public XtraTabControl TableControl { get; set; }

        private void UcMenu_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            // 暂停控件实时显示
            SuspendLayout();
            try
            {
                // 加载生产管理
                // 生产
                dropDownButton1.DropDownControl = new DXPopupMenu
                    {
                        Items =
                            {
                                new DXMenuItem("生产工单开停线管理", (sender, e) =>
                                    {
                                        var manage = new UcProductionOrder();
                                        manage.Init();
                                        TableControl.ShowPage(manage, "开停线管理", sender);
                                    })
                                    {Visible = true},
                                new DXMenuItem("生产", (sender2, e2) =>
                                    {
                                        Process process =
                                            ServiceBloker.GetService<Process>()
                                                         .Find(
                                                             c =>
                                                             c.ProductLineId == CommonApi.CurrentUser().ProductLineId);
                                        if (process == null) return;
                                        var manage = new UcProcessNormal {Process = process};
                                        manage.Init();
                                        TableControl.ShowPage(manage, "生产", sender2);
                                    })
                                    {Visible = true},
                                new DXMenuItem("下线统计", (sender2, e2) =>
                                    {
                                        var manage = new UcProductStatistics();
                                        manage.Init();
                                        TableControl.ShowPage(manage, "下线统计", sender2);
                                    })
                                    {Visible = true},
                                new DXMenuItem("检验", (sender1, e1) =>
                                    {
                                        var manage = new UcProductInspect();
                                        manage.Init();
                                        TableControl.ShowPage(manage, "检验", sender1);
                                    })
                                    {Visible = true}
                            }
                    };
            }
            catch (Exception ex)
            {
                MessageBox.Show("菜单加载错误");
                CommonApi.Logger.Write(ex);
            }
            // 继续控件实时显示
            ResumeLayout();
        }


        /// <summary>
        ///     检测控件，判断子菜单是否可用
        /// </summary>
        /// <param name="dxSubMenuItem"></param>
        /// <returns></returns>
        private bool Check(DXSubMenuItem dxSubMenuItem)
        {
            bool result = false;
            foreach (object item in dxSubMenuItem.Items)
            {
                if (item is DXSubMenuItem)
                {
                    if (Check(item as DXSubMenuItem))
                        result = true;
                }
                else if (item is DXMenuItem)
                {
                    if ((item as DXMenuItem).Visible)
                        result = true;
                }
            }
            dxSubMenuItem.Visible = result;
            return result;
        }

        /// <summary>
        ///     检测控件，判断弹出菜单是否可用
        /// </summary>
        /// <param name="dxSubMenuItem"></param>
        /// <returns></returns>
        private bool Check(DXPopupMenu dxSubMenuItem)
        {
            bool result = false;
            foreach (object item in dxSubMenuItem.Items)
            {
                if (item is DXSubMenuItem)
                {
                    if (Check(item as DXSubMenuItem))
                        result = true;
                }
                else if (item is DXMenuItem)
                {
                    if ((item as DXMenuItem).Visible)
                        result = true;
                }
            }
            dxSubMenuItem.Visible = result;
            return result;
        }
    }
}