using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.SkuModule
{
    public class SkuCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public SkuCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            SkuWorkItem item = _rootWorkItem.WorkItems.AddNew<SkuWorkItem>("SkuWorkItem");

            item.Items.AddNew<SkuController>("SkuController");
        }

    }
}



