using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.TagLocationModule
{
    public class TagLocationCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public TagLocationCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            TagLocationWorkItem item = _rootWorkItem.WorkItems.AddNew<TagLocationWorkItem>("TagLocationWorkItem");
            item.Items.AddNew<TagLocationController>("TagLocationController");
        }
    }
}



