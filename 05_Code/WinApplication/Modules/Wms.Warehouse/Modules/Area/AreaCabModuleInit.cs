using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.AreaModule
{
    public class AreaCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public AreaCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            AreaWorkItem item = _rootWorkItem.WorkItems.AddNew<AreaWorkItem>("AreaWorkItem");

            item.Items.AddNew<AreaController>("AreaController");
        }

    }
}



