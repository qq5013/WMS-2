//===============================================================================
// Microsoft patterns & practices
// CompositeUI Application Block
//===============================================================================
// Copyright ?Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
//using Module.SidebarModule.Views;
//using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;

namespace Modules.SidebarModule
{
  public class SidebarController : Controller
  {
      //[CommandHandler("Modules.Sidebar.ShowSidebar")]
      //public void ShowSidebarViewHander(object sender, EventArgs e)
      //{
      //    IWorkspace contontWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
      //    IWorkspace sidebarWorkspace = WorkItem.Workspaces[WorkspaceNames.SidebarWorkspace];

      //    SidebarWorkItem sidebarWorkItem = WorkItem as SidebarWorkItem;
      //    if (sidebarWorkItem != null)
      //        sidebarWorkItem.ShowSidebar(sidebarWorkspace, contontWorkspace);
      //}

      //[CommandHandler("Modules.Sidebar.PortalView")]
      //public void ShowPortalViewHander(object sender, EventArgs e)
      //{
      //    PortalView view = WorkItem.Items.Get<PortalView>("PortalView");
      //    if (view == null)
      //    {
      //        view = WorkItem.Items.AddNew<PortalView>("PortalView");
      //    }

      //    TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
      //    //string tipa = GlobalState.LanguageHelper.GetLanguageString("message", "caption_portal");
      //    //smartPartInfo.Title = tipa;
      //    view.MyWorkItem = WorkItem;
      //    IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
      //    moduleWorkspace.Show(view, smartPartInfo);
      //    ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
      //    ((TabbedDocumentWorkspace)moduleWorkspace).O = view;
      //}
  }
}
