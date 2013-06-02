using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common;
using Wms.Common.Constants;
using Modules.UserModule.Views;
using Business.Common;

namespace Modules.UserModule
{
    public class UserController: Controller
    {
        [CommandHandler("UserModule.ShowForm")]
        public void ShowUserListFormHandler(object sender, EventArgs e)
        {
            UserListForm form = WorkItem.Items.Get<UserListForm>("UserListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<UserListForm>("UserListForm");
                form.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "ÓÃ»§Î¬»¤";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(form, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;
        }
    }
}
