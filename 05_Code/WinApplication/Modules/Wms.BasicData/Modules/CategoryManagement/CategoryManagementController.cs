using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using Modules.CategoryManagementModule.Views;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;

namespace Modules.CategoryManagementModule
{
    public class CategoryManagementController : Controller
    {
        [CommandHandler("CategoryManagementModule.ShowForm")]
        public void ShowCategoryManagementFormHandler(object sender, EventArgs e)
        {
            CategoryManagementForm list = WorkItem.Items.Get<CategoryManagementForm>("CategoryManagementForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<CategoryManagementForm>("CategoryManagementForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();          
            smartPartInfo.Title = @"管理分类维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



