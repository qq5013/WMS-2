using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using WCPierce.Practices.CompositeUI.WinForms;
using Modules.StockModule.Views;
using Wms.Common.Constants;
using Business.Common;
using System.Windows.Forms;
using Business.Domain.Inventory;

namespace Modules.StockModule
{
    public class StockController:Controller
    {

        [CommandHandler("StockModule.ShowForm")]
        public void ShowInboundStockListFormHander(object sender, EventArgs e)
        {

            StockListForm form = WorkItem.Items.Get<StockListForm>("StockListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<StockListForm>("StockListForm");
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "实时库存查询";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(form, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

        }
    }
}



