using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.WarehouseModule.Views;
using Business.Common;

namespace Modules.WarehouseModule
{
    public class WarehouseController : Controller
    {
        [CommandHandler("WarehouseModule.ShowForm")]
        public void ShowWarehouseListFormHandler(object sender, EventArgs e)
        {
            WarehouseListForm list = WorkItem.Items.Get<WarehouseListForm>("WarehouseListForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<WarehouseListForm>("WarehouseListForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("company", "company_info_maintainment_tip");
            smartPartInfo.Title = "仓库维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



