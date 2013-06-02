using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using WCPierce.Practices.CompositeUI.WinForms;
using Modules.CountBillModule.Views;
using Wms.Common.Constants;
using Business.Common;
using System.Windows.Forms;
using Business.Domain.Inventory;

namespace Modules.CountBillModule
{
    public class CountBillController : Controller
    {

        [CommandHandler("CountBillModule.ShowForm")]
        public void ShowCountBillListFormHander(object sender, EventArgs e)
        {
            CountBillListForm form = WorkItem.Items.Get<CountBillListForm>("CountBillListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<CountBillListForm>("CountBillListForm");
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "盘点单维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(form, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

        }
    }
}



