using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.TagModule
{
    public class TagCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public TagCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            TagWorkItem workItem = _rootWorkItem.WorkItems.AddNew<TagWorkItem>("TagWorkItem");
            workItem.Items.AddNew<SettingController>("TagController");
        }
    }
}
