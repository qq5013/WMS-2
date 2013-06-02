using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.ReceiveModule
{
    public class ReceiveCabModuleInit : ModuleInit
    {
        private WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ReceiveCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            this._rootWorkItem = workItem;
        }

        public override void Load()
        {
            IWorkspace contentWorkspace = _rootWorkItem.Workspaces[Wms.Common.Constants.WorkspaceNames.ContentWorkspace];

            ReceiveWorkItem item = _rootWorkItem.WorkItems.AddNew<ReceiveWorkItem>("ReceiveWorkItem");
            item.Items.AddNew<ReceiveController>("ReceiveController");
        }

    }
}



