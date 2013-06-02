using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.OutboundBillModule
{
    public class OutboundBillCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public OutboundBillCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            OutboundBillWorkItem item = _rootWorkItem.WorkItems.AddNew<OutboundBillWorkItem>("OutboundBillWorkItem");
            item.Items.AddNew<OutboundBillController>("OutboundBillController");
        }

    }
}



