using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.ContainerTypeModule
{
    public class ContainerTypeCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ContainerTypeCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            ContainerTypeWorkItem workItem = _rootWorkItem.WorkItems.AddNew<ContainerTypeWorkItem>("ContainerTypeWorkItem");
            workItem.Items.AddNew<ContainerTypeController>("ContainerTypeController");
        }
    }
}
