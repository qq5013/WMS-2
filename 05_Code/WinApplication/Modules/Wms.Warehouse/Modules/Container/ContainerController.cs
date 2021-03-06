﻿using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.ContainerModule.Views;
using Business.Common;

namespace Modules.ContainerModule
{
    public class ContainerController:Controller
    {
        [CommandHandler("ContainerModule.ShowForm")]
        public void ShowContainerListFormHandler(object sender, EventArgs e)
        {
            ContainerListForm list = WorkItem.Items.Get<ContainerListForm>("ContainerListForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<ContainerListForm>("ContainerListForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("zones", "zone_info_maintainment_tip");
            smartPartInfo.Title = "容器维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



