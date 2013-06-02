using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using WCPierce.Practices.CompositeUI.WinForms;
using Modules.StockLogModule.Views;
using Wms.Common.Constants;
using Business.Common;
using System.Windows.Forms;
using Business.Domain.Inventory;

namespace Modules.StockLogModule
{
    public class StockLogController:Controller
    {

        [CommandHandler("StockLogModule.ShowForm")]
        public void ShowInboundStockLogListFormHander(object sender, EventArgs e)
        {

            StockLogListForm form = WorkItem.Items.Get<StockLogListForm>("StockLogListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<StockLogListForm>("StockLogListForm");
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "库存日志查询";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(form, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

        }
    }
}



