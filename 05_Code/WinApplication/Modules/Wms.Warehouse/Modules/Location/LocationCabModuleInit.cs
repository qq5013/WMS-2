using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.LocationModule
{
    public class LocationCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public LocationCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            LocationWorkItem item = _rootWorkItem.WorkItems.AddNew<LocationWorkItem>("LocationWorkItem");

            item.Items.AddNew<LocationController>("LocationController");
        }

    }
}



