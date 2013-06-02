using System;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using Wms.Common.Constants;
using WCPierce.Practices.CompositeUI.WinForms;
using Business.Common;
using Modules.GroupModule.Views;

namespace Modules.GroupModule
{
    public class GroupController : Controller
    {
        [CommandHandler("GroupModule.ShowForm")]
        public void ShowUserGroupListFormHandler(object sender, EventArgs e)
        {
            var list = WorkItem.Items.Get<GroupForm>("GroupForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<GroupForm>("GroupForm");
                list.WorkItemController = this;
            }

            var smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "用户组维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }
    }
}
