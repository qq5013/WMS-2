using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.TagSkuModule.Views;
using Business.Common;

namespace Modules.TagSkuModule
{
    public class TagSkuController:Controller
    {
        [CommandHandler("TagSkuModule.ShowForm")]
        public void ShowTagSkuListFormHandler(object sender, EventArgs e)
        {
            TagSkuListForm list = WorkItem.Items.Get<TagSkuListForm>("TagSkuListForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<TagSkuListForm>("TagSkuListForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "货物标签映射维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



