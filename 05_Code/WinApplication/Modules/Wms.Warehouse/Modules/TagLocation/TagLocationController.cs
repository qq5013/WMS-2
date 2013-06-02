using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.TagLocationModule.Views;
using Business.Common;

namespace Modules.TagLocationModule
{
    public class TagLocationController:Controller
    {
        [CommandHandler("TagLocationModule.ShowForm")]
        public void ShowTagLocationListFormHandler(object sender, EventArgs e)
        {
            TagLocationListForm list = WorkItem.Items.Get<TagLocationListForm>("TagLocationListForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<TagLocationListForm>("TagLocationListForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "库位标签映射维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



