using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.RoleModule
{
    public class RoleCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public RoleCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            RoleWorkItem item = _rootWorkItem.WorkItems.AddNew<RoleWorkItem>();

            item.Items.AddNew<RoleController>("RoleController");
        }
    }
}
