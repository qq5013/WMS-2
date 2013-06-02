using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.AisleModule
{
    public class AisleCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public AisleCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            AisleWorkItem workItem = _rootWorkItem.WorkItems.AddNew<AisleWorkItem>("AisleWorkItem");
            workItem.Items.AddNew<AisleController>("AisleController");
        }
    }
}
