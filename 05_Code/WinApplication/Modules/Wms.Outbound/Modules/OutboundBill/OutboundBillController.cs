using System;
using System.Windows.Forms;
using Business.Common;
using Business.Domain.Inventory;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Modules.OutboundBillModule.Views;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;

namespace Modules.OutboundBillModule
{
    public class OutboundBillController:Controller
    {

        [CommandHandler("OutboundBillModule.ShowForm")]
        public void ShowOutboundBillListFormHander(object sender, EventArgs e)
        {

            OutboundBillListForm form = WorkItem.Items.Get<OutboundBillListForm>("OutboundBillListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<OutboundBillListForm>("OutboundBillListForm");
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "出库单维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(form, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

        }
    }
}



