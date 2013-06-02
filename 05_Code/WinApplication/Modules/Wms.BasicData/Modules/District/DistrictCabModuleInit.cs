using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.DistrictModule
{
    public class DistrictCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public DistrictCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            DistrictWorkItem item = _rootWorkItem.WorkItems.AddNew<DistrictWorkItem>("DistrictWorkItem");
            item.Items.AddNew<DistrictController>("DistrictController");
        }
    }
}



