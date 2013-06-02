using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using WCPierce.Practices.CompositeUI.WinForms;
using Modules.InboundBillModule.Views;
using Wms.Common.Constants;
using Business.Common;
using System.Windows.Forms;
using Business.Domain.Inventory;

namespace Modules.InboundBillModule
{
    public class InboundBillController:Controller
    {

        [CommandHandler("InboundBillModule.ShowForm")]
        public void ShowInboundBillListFormHander(object sender, EventArgs e)
        {

            InboundBillListForm form = WorkItem.Items.Get<InboundBillListForm>("InboundBillListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<InboundBillListForm>("InboundBillListForm");
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "入库单维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(form, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

        }
    }
}



