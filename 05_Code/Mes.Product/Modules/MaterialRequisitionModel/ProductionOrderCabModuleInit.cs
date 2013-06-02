using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Mes.Product.Modules.ProductionOrderModel
{
    public class ProductionOrderCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ProductionOrderCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            var item = _rootWorkItem.WorkItems.AddNew<ProductionOrderWorkItem>("ProductionOrderWorkItem");
            item.Items.AddNew<ProductionOrderController>("ProductionOrderController");
        }
    }
}