using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Mes.Product
{
    public class ProcessCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ProcessCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            var item = _rootWorkItem.WorkItems.AddNew<ProcessWorkItem>("ProcessWorkItem");
            item.Items.AddNew<ProductController>("ProcessController");
        }
    }
}