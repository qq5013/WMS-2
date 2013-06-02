using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.CategoryManagementModule
{
    public class CategoryManagementCabModuleInit:ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public CategoryManagementCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            CategoryManagementWorkItem item = _rootWorkItem.WorkItems.AddNew<CategoryManagementWorkItem>();

            item.Items.AddNew<CategoryManagementController>("CategoryManagementController");
        }

    }
}



