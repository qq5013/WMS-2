using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.InboundPlanModule
{
    public class InboundPlanCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public InboundPlanCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            InboundPlanWorkItem item = _rootWorkItem.WorkItems.AddNew<InboundPlanWorkItem>("InboundPlanWorkItem");
            item.Items.AddNew<InboundPlanController>("InboundPlanController");
        }

    }
}



