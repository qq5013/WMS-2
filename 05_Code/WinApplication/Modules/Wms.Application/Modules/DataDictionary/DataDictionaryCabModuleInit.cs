using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace Modules.DataDictionaryModule
{
    public class DataDictionaryCabModuleInit: ModuleInit
    {
        private readonly WorkItem _rootWorkItem;

        [InjectionConstructor]
        public DataDictionaryCabModuleInit([ServiceDependency] WorkItem workItem)
        {
            _rootWorkItem = workItem;
        }

        public override void Load()
        {
            var workItem = _rootWorkItem.WorkItems.AddNew<DataDictionaryWorkItem>("DataDictionaryWorkItem");
            workItem.Items.AddNew<DataDictionaryController>("DataDictionaryController");
        }
    }
}
