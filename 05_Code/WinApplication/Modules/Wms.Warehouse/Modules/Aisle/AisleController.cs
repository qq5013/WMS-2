using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Modules.AisleModule.Views;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;

namespace Modules.AisleModule
{
    public class AisleController : Controller
    {
        [CommandHandler("AisleModule.ShowForm")]
        public void ShowAisleListFormHandler(object sender, EventArgs e)
        {
            AisleListForm form = WorkItem.Items.Get<AisleListForm>("AisleListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<AisleListForm>("AisleListForm");
                form.WorkItemController = this;
            }

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "通道维护";
            moduleWorkspace.Show(form, smartPartInfo);

        }
    }
}
