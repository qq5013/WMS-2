using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Mes.Product.Modules.ProductionPlanModel
{
    public class ProductionPlanCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ProductionPlanCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            var item = _rootWorkItem.WorkItems.AddNew<ProductionPlanWorkItem>("ProductionPlanWorkItem");
            item.Items.AddNew<ProductionPlanController>("ProductionPlanController");
        }
    }
}