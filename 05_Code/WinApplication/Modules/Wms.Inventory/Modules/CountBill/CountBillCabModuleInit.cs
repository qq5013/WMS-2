using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.CountBillModule
{
    public class CountBillCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public CountBillCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            CountBillWorkItem item = _rootWorkItem.WorkItems.AddNew<CountBillWorkItem>("CountBillWorkItem");
            item.Items.AddNew<CountBillController>("CountBillController");
        }

    }
}



