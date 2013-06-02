using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Mes.Product.Modules.ProductLineModel
{
    public class ProductLineCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ProductLineCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            var item = _rootWorkItem.WorkItems.AddNew<ProductLineWorkItem>("ProductLineWorkItem");
            item.Items.AddNew<ProductLineController>("ProductLineController");
        }
    }
}