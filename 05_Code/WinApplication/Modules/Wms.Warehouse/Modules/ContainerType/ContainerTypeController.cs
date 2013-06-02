using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Modules.ContainerTypeModule.Views;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;

namespace Modules.ContainerTypeModule
{
    public class ContainerTypeController : Controller
    {
        [CommandHandler("ContainerTypeModule.ShowForm")]
        public void ShowContainerTypeListFormHandler(object sender, EventArgs e)
        {
            ContainerTypeListForm form = WorkItem.Items.Get<ContainerTypeListForm>("ContainerTypeListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<ContainerTypeListForm>("ContainerTypeListForm");
                form.WorkItemController = this;
            }

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "容器类型维护";
            moduleWorkspace.Show(form, smartPartInfo);

        }
    }
}
