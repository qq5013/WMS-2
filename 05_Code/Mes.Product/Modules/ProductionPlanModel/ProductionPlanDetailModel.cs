using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.ProductionPlanModel
{
    public class ProductionPlanDetailModel : ProductionPlanDetail,IDetailModel
    {
        public int TempId { get; set; }

        public string OperationName { get; set; }
    }
}