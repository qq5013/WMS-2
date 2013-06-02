using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.ShelfModule.Views;
using Business.Common;

namespace Modules.ShelfModule
{
    public class ShelfController : Controller
    {
        [CommandHandler("ShelfModule.ShowForm")]
        public void ShowShelfListFormHandler(object sender, EventArgs e)
        {
            ShelfListForm list = WorkItem.Items.Get<ShelfListForm>("ShelfListForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<ShelfListForm>("ShelfListForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("zones", "zone_info_maintainment_tip");
            smartPartInfo.Title = "货架维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



