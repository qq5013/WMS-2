using System.Collections.Generic;

namespace MES.Execute.Infos
{
    public class OutboundInfo
    {
        public string 发料仓库 { get; set; }
        public string 领料车间 { get; set; }
        public string 领料产线 { get; set; }
        public string 领料类型 { get; set; }
        public string 领料人 { get; set; }
        public string 领料时间 { get; set; }
        public string 发料人 { get; set; }
        public string 开单时间 { get; set; }
        public string 领料仓库 { get; set; }
        public string 备注 { get; set; }

        public List<OutboundDetailInfo> Details { get; set; }
    }
}