using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.ShelfModule
{
    public class ShelfCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ShelfCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            ShelfWorkItem item = _rootWorkItem.WorkItems.AddNew<ShelfWorkItem>("ShelfWorkItem");

            item.Items.AddNew<ShelfController>("ShelfController");
        }

    }
}



