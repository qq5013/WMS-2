using System;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;

namespace Mes.Product
{
    public static class ControllerHelper
    {
        /// <summary>
        /// 显示模块
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="controller">模块所在控件</param>
        /// <param name="title">标题</param>
        /// <param name="name">名称</param>
        public static void Show<T>(this Controller controller, string title, string name = null)
            where T : Control
        {
            if (string.IsNullOrEmpty(name))
                name = typeof (T).Name;
            var list = controller.WorkItem.Items.Get<T>(name);
            if (list == null)
            {
                list = controller.WorkItem.Items.AddNew<T>(name);
                try
                {
                    ((dynamic) list).WorkItemController = controller;
                }
                catch (Exception)
                {
                }
            }

            var smartPartInfo = new TabSmartPartInfo {Title = title};
            IWorkspace moduleWorkspace = controller.WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            var workspace = ((TabbedDocumentWorkspace) moduleWorkspace);
            workspace.WorkItem = controller.WorkItem;
            workspace.O = list;
        }
    }
}