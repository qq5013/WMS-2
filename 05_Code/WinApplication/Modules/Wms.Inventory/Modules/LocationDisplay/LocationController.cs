using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.LocationDisplayModule.Views;
using Business.Common;

namespace Modules.LocationDisplayModule
{
    public class LocationDisplayController : Controller
    {
        [CommandHandler("LocationDisplayModule.ShowForm")]
        public void ShowLocationListFormHandler(object sender, EventArgs e)
        {
            LocationDisplayListForm list = WorkItem.Items.Get<LocationDisplayListForm>("LocationDisplayListForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<LocationDisplayListForm>("LocationDisplayListForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("zones", "zone_info_maintainment_tip");
            smartPartInfo.Title = "区域库位展示信息";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



