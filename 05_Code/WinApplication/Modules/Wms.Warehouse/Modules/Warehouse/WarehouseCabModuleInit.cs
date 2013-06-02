using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.WarehouseModule
{
    public class WarehouseCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public WarehouseCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            WarehouseWorkItem item = _rootWorkItem.WorkItems.AddNew<WarehouseWorkItem>("WarehouseWorkItem");
            item.Items.AddNew<WarehouseController>("WarehouseController");
        }
    }
}



