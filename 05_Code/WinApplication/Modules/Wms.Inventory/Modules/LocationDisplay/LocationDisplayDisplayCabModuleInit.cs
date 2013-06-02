using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.LocationDisplayModule
{
    public class LocationDisplayCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public LocationDisplayCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            LocationDisplayWorkItem item = _rootWorkItem.WorkItems.AddNew<LocationDisplayWorkItem>("LocationDisplayWorkItem");

            item.Items.AddNew<LocationDisplayController>("LocationDisplayController");
        }

    }
}



