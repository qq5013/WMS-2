using System.Collections.Generic;

namespace MES.Execute.Infos
{
    public class ProductionOrderInfo
    {
        public string 客户 { get; set; }
        public string 订购日期 { get; set; }
        public string 交货日期 { get; set; }
        public string 制单人 { get; set; }
        public string 制单日期 { get; set; }

        public string
            工单类型 { get; set; }

        public string 备注 { get; set; }

        public List<ProductionOrderDetailInfo> Details { get; set; }
    }
}