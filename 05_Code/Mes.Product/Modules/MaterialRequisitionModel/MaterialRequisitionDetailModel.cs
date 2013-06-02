using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.MaterialRequisitionModel
{
    public class MaterialRequisitionDetailModel : MaterialRequisitionDetail, IDetailModel
    {
        public int TempId { get; set; }

        public string OperationName { get; set; }
    }
}