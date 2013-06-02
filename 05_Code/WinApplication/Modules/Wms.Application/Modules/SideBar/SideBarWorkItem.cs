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

using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
//using Module.SidebarModule.Views;
//using Modules.SidebarModule.Views;
//using WCPierce.Practices.CompositeUI.WinForms;

namespace Modules.SidebarModule
{
    // The BankTellerWorkItem is the core work item of the module. Rather than
    // representing a single use case, it is the container of all the other
    // smaller work items in the system.
    public class SidebarWorkItem : WorkItem
    {
        // private ToolStripMenuItem queueItem;

        private IWorkspace _contentWorkspace;

        //public void ShowSidebar(IWorkspace sideBar, IWorkspace content)
        //{
        //    _contentWorkspace = content;

        //    //Needs to be named because it will be used in a placeholder
        //    SideBarView sideBarView = Items.AddNew<SideBarView>();
        //    sideBarView.MyWorkItem = this;
        //    sideBarView.Width = 155;
        //    sideBarView.MyWorkItem.RootWorkItem.State["SIDEBAR"] = sideBarView;
        //    /// ADDED
        //    DockableWindowSmartPartInfo smartPartInfo = new DockableWindowSmartPartInfo();
        //    smartPartInfo.DockLocation = ContainerDockLocation.Left;
        //    //string tipa = GlobalState.LanguageHelper.GetLanguageString("menus", "navigation");
        //    //smartPartInfo.Title = tipa;
           
        //    smartPartInfo.AllowClose = false;
        //    smartPartInfo.ShowOptions = false;
        //    ///
            
        //    sideBar.Show(sideBarView, smartPartInfo);
            
        //    Activate();
        //}

        //public void ShowPortal(IWorkspace viewBar, IWorkspace content)
        //{
        //    _contentWorkspace = content;

        //    //Needs to be named because it will be used in a placeholder
        //    PortalView view = Items.AddNew<PortalView>();
        //    view.MyWorkItem = this;

        //    /// ADDED
        //    DockableWindowSmartPartInfo smartPartInfo = new DockableWindowSmartPartInfo();
        //    smartPartInfo.DockLocation = ContainerDockLocation.Left;
        //    smartPartInfo.Title = "¹¤×÷Ãæ°å";
        //    smartPartInfo.AllowClose = false;
        //    smartPartInfo.ShowOptions = false;
        //    ///

        //    viewBar.Show(view, smartPartInfo);
        //    Activate();
        //}
    }
}
