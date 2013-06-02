using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.ReceiveModule.Views;

namespace Modules.ReceiveModule
{
    public class ReceiveController:Controller
    {
        //[CommandHandler("ReceiveModule.ShowReceiveForm")]
        //public void ShowReceiveFormHandler(object sender, EventArgs e)
        //{
        //    ReceiveForm list;

        //    list = WorkItem.Items.Get<ReceiveForm>("ReceiveForm");
        //    if (list == null)
        //    {
        //        list = WorkItem.Items.AddNew<ReceiveForm>("ReceiveForm");
        //        //list.WorkItemController = (Controller)this;
        //    }

        //    TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
        //    smartPartInfo.Title = "扫描收货";

        //    IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
        //    moduleWorkspace.Show(list, smartPartInfo);
        //    ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
        //    ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        //}

        [CommandHandler("ReceiveModule.ShowReceivePreparationForm")]
        public void ShowReceivePreparationFormHandler(object sender, EventArgs e)
        {
            ReceivePreparationForm list;

            list = WorkItem.Items.Get<ReceivePreparationForm>("ReceivePreparationForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<ReceivePreparationForm>("ReceivePreparationForm");
                //list.WorkItemController = (Controller)this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "收货准备";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

        [CommandHandler("ReceiveModule.ShowReceiveForm")]
        public void ShowReceiveFormHandler(object sender, EventArgs e)
        {
            ReceiveForm list;

            list = WorkItem.Items.Get<ReceiveForm>("ReceiveForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<ReceiveForm>("ReceiveForm");
                //list.WorkItemController = (Controller)this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "货物核收";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }
    }
}



