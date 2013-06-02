using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.DistrictModule.Views;
using Business.Common;

namespace Modules.DistrictModule
{
    public class DistrictController:Controller
    {
        [CommandHandler("DistrictModule.ShowForm")]
        public void ShowDistrictFormHandler(object sender, EventArgs e)
        {
            DistrictForm list = WorkItem.Items.Get<DistrictForm>("DistrictForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<DistrictForm>("DistrictForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "地区维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }
    }
}



