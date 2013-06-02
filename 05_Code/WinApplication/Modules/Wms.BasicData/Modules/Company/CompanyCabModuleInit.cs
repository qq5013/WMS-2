using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.CompanyModule
{
    public class CompanyCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public CompanyCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            CompanyWorkItem item = _rootWorkItem.WorkItems.AddNew<CompanyWorkItem>("CompanyWorkItem");
            item.Items.AddNew<CompanyController>("CompanyController");
        }
    }
}



