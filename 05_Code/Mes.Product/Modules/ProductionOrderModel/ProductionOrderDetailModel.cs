using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.ProductionOrderModel
{
    public class ProductionOrderDetailModel : ProductionOrderDetail, IDetailModel
    {
        public int TempId { get; set; }

        public string OperationName { get; set; }
    }
}