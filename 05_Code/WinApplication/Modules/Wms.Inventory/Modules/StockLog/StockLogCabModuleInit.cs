using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.StockLogModule
{
    public class StockLogCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public StockLogCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            StockLogWorkItem item = _rootWorkItem.WorkItems.AddNew<StockLogWorkItem>("StockLogWorkItem");
            item.Items.AddNew<StockLogController>("StockLogController");
        }

    }
}



