using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.ProcessModule
{
    public class ProcessStepModel : ProcessStep, IDetailModel
    {
        public int TempId { get; set; }

        public string OperationName { get; set; }
    }
}