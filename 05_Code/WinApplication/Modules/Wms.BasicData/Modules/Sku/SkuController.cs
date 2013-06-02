using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.SkuModule.Views;
using Business.Common;

namespace Modules.SkuModule
{
    public class SkuController:Controller
    {
        [CommandHandler("SkuModule.ShowForm")]
        public void ShowSkuListFormHandler(object sender, EventArgs e)
        {
            SkuListForm list = WorkItem.Items.Get<SkuListForm>("SkuListForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<SkuListForm>("SkuListForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("goods", "goods_info_maintainment_tip");
            smartPartInfo.Title = "货物信息维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



