using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.ParameterModule
{
    public class ParameterCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ParameterCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            var workItem = _rootWorkItem.WorkItems.AddNew<ParameterWorkItem>("ParameterWorkItem");
            workItem.Items.AddNew<ParameterController>("ParameterController");
        }
    }
}
