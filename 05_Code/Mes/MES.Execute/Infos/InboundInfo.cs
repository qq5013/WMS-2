using System.Collections.Generic;
using System.ComponentModel;

namespace MES.Execute.Infos
{
    public class InboundInfo
    {
        [Description("供应商")]
        public string 供应商 { get; set; }

        [Description("送货人")]
        public string 送货人 { get; set; }

        [Description("送货车辆")]
        public string 送货车辆 { get; set; }

        [Description("收货仓库")]
        public string 收货仓库 { get; set; }

        [Description("收货时间")]
        public string 收货时间 { get; set; }

        [Description("采购员")]
        public string 采购员 { get; set; }

        [Description("入库类型")]
        public string 入库类型 { get; set;
        }
        [Description("备注")]
        public string 备注 { get; set; }

        [Description("验收员")]
        public string 验收员 { get; set; }

        [Description("明细")]
        public List<InboundDetailInfo> Details { get; set; }
    }
}