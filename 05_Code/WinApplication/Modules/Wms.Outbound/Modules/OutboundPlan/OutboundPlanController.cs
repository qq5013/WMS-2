using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using WCPierce.Practices.CompositeUI.WinForms;
using Modules.OutboundPlanModule.Views;
using Wms.Common.Constants;
using Business.Common;
using System.Windows.Forms;
using Business.Domain.Inventory;

namespace Modules.OutboundPlanModule
{
    public class OutboundPlanController:Controller
    {

        [CommandHandler("OutboundPlanModule.ShowForm")]
        public void ShowOutboundPlanListFormHander(object sender, EventArgs e)
        {
            OutboundPlanListForm form = WorkItem.Items.Get<OutboundPlanListForm>("OutboundPlanListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<OutboundPlanListForm>("OutboundPlanListForm");
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "出库计划维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(form, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

        }
    }
}



