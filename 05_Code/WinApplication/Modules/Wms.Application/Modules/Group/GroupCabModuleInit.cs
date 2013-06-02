using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.GroupModule
{
    public class GroupCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public GroupCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            GroupWorkItem item = _rootWorkItem.WorkItems.AddNew<GroupWorkItem>("GroupWorkItem");
            item.Items.AddNew<GroupController>("GroupController");
        }
    }
}