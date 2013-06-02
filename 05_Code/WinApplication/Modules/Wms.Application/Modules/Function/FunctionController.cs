using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.FunctionModule.Views;

namespace Modules.FunctionModule
{
    public class FunctionController:Controller
    {
        [CommandHandler("FunctionModule.ShowForm")]
        public void ShowAuthorityFormHandler(object sender, EventArgs e)
        {
            FunctionForm form = WorkItem.Items.Get<FunctionForm>("FunctionForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<FunctionForm>("FunctionForm");
                form.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "功能维护";
            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(form, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;
        }
    }
}



