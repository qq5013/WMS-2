using System.Collections.Generic;

namespace MES.Execute.Infos
{
    public class SalesOrderInfo
    {
        public string 客户 { get; set; }

        public string 定购日期 { get; set; }
        public string 定购人 { get; set; }
        public string 定购金额 { get; set; }

        public string 业务员 { get; set; }

        public string 交货日期 { get; set; }
        public string 付款方式 { get; set; }
        public string 交货地址 { get; set; }
        public string 运输方式 { get; set; }

        public string 制单人 { get; set; }

        public string 制单日期 { get; set; }
        public string SO状态 { get; set; }

        public string 备注 { get; set; }

        public List<SalesOrderDetailInfo> Details { get; set; }
    }
}