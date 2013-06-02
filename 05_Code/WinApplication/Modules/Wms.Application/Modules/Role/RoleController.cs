using System;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using Wms.Common.Constants;
using WCPierce.Practices.CompositeUI.WinForms;
using Business.Common;
using Modules.RoleModule.Views;

namespace Modules.RoleModule
{
    public class RoleController : Controller
    {
        [CommandHandler("RoleModule.ShowForm")]
        public void ShowRoleListFormHandler(object sender, EventArgs e)
        {
            RoleForm list = WorkItem.Items.Get<RoleForm>("RoleForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<RoleForm>("RoleForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("role", "system_role_maintainment_tip");
            smartPartInfo.Title = "½ÇÉ«Î¬»¤";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }
    }
}
