using System.Collections.Generic;

namespace MES.Execute.Infos
{
    public class PurchaseOrderInfo
    {

        public string 供应商 { get; set; }

        public string 联系人 { get; set; }

        public string 联系电话 { get; set; }

        public string 传真 { get; set; }

        public string 邮箱 { get; set; }

        public string 采购员 { get; set; }

        public string 制单员 { get; set; }

        public string 预到货日期 { get; set; }

        public string 实际到货日期 { get; set; }

        public string 订购日期 { get; set; }

        public string 是否QC { get; set; }

        public string 采购合同号 { get; set; }

        public string 订购总价 { get; set; }

        public string 付款方式 { get; set; }

        public string 备注 { get; set; }

        public List<PurchaseOrderDetailInfo> Details { get; set; }
    }
}