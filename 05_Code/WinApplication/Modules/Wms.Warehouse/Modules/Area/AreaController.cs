using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.AreaModule.Views;
using Business.Common;

namespace Modules.AreaModule
{
    public class AreaController:Controller
    {
        [CommandHandler("AreaModule.ShowForm")]
        public void ShowAreaListFormHandler(object sender, EventArgs e)
        {
            AreaListForm list = WorkItem.Items.Get<AreaListForm>("AreaListForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<AreaListForm>("AreaListForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("zones", "zone_info_maintainment_tip");
            smartPartInfo.Title = "库区维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



