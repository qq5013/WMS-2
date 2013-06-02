using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.StockModule
{
    public class StockCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public StockCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            StockWorkItem item = _rootWorkItem.WorkItems.AddNew<StockWorkItem>("StockWorkItem");
            item.Items.AddNew<StockController>("StockController");
        }

    }
}



