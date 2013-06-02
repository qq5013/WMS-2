using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.FunctionModule
{
    public class FunctionCabModuleInit : ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public FunctionCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            FunctionWorkItem workItem = _rootWorkItem.WorkItems.AddNew<FunctionWorkItem>();
            workItem.Items.AddNew<FunctionController>("FunctionController");
        }
    }
}



