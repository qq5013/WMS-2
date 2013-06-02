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
using Microsoft.Practices.ObjectBuilder;

namespace Modules.SidebarModule
{
  public class SideBarCabModuleInit : ModuleInit
  {
      private readonly WorkItem _rootWorkItem;

      [InjectionConstructor]
      public SideBarCabModuleInit([ServiceDependency] WorkItem workItem)
      {
          _rootWorkItem = workItem;
      }

      public override void Load()
      {
          SidebarWorkItem item = _rootWorkItem.WorkItems.AddNew<SidebarWorkItem>("sidebarWorkItem");
          item.Items.AddNew<SidebarController>("sidebarController");
      }
  }
}
