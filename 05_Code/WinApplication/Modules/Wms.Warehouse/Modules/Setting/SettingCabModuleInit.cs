using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.SettingModule
{
    public class SettingCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public SettingCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            SettingWorkItem workItem = _rootWorkItem.WorkItems.AddNew<SettingWorkItem>("SettingWorkItem");
            workItem.Items.AddNew<SettingController>("SettingController");
        }
    }
}
