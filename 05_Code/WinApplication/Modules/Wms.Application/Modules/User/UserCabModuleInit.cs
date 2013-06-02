using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.UserModule
{
    public class UserCabModuleInit: ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public UserCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            UserWorkItem item = _rootWorkItem.WorkItems.AddNew<UserWorkItem>("UserWorkItem");
            item.Items.AddNew<UserController>("UserController");
        }
    }
}
