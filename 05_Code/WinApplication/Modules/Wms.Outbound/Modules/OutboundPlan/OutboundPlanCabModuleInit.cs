using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.OutboundPlanModule
{
    public class OutboundPlanCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public OutboundPlanCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            OutboundPlanWorkItem item = _rootWorkItem.WorkItems.AddNew<OutboundPlanWorkItem>("OutboundPlanWorkItem");
            item.Items.AddNew<OutboundPlanController>("OutboundPlanController");
        }

    }
}



