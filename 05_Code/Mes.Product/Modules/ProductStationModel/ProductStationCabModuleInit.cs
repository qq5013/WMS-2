using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Mes.Product.Modules.ProductStationModel
{
    public class ProductStationCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ProductStationCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            var item = _rootWorkItem.WorkItems.AddNew<ProductStationWorkItem>("ProductStationWorkItem");
            item.Items.AddNew<ProductStationController>("ProductStationController");
        }
    }
}