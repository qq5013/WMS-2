using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.TagSkuModule
{
    public class TagSkuCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public TagSkuCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            TagSkuWorkItem item = _rootWorkItem.WorkItems.AddNew<TagSkuWorkItem>("TagSkuWorkItem");
            item.Items.AddNew<TagSkuController>("TagSkuController");
        }
    }
}



