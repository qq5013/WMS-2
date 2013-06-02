using System.Collections.Generic;

namespace MES.Execute.Infos
{
    public class ProductionPlanInfo
    {
        public string 客户 { get; set; }
        public string 联系人 { get; set; }
        public string 订购日期 { get; set; }
        public string 交货日期 { get; set; }
        public string 交货地址 { get; set; }
        public string 下单员 { get; set; }
        public string 制单人 { get; set; }
        public string 制单日期 { get; set; }
        public string 备注 { get; set; }

        public List<ProductionPlanDetailInfo> Details { get; set; }
    }
}