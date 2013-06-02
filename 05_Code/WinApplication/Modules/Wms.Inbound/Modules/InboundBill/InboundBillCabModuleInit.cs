using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.InboundBillModule
{
    public class InboundBillCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public InboundBillCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            InboundBillWorkItem item = _rootWorkItem.WorkItems.AddNew<InboundBillWorkItem>("InboundBillWorkItem");
            item.Items.AddNew<InboundBillController>("InboundBillController");
        }

    }
}



