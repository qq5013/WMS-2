using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.ContainerModule
{
    public class ContainerCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public ContainerCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            ContainerWorkItem item = _rootWorkItem.WorkItems.AddNew<ContainerWorkItem>("ContainerWorkItem");

            item.Items.AddNew<ContainerController>("ContainerController");
        }

    }
}



