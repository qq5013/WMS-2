namespace Business.Common.DataDictionary
{
    public enum OutboundPlanStatus
    {
        Created = 31501,        // 制单
        Modified = 31502,       // 已修改
        Confirmed = 31503,      // 已审核
        Assigned = 31504,       // 已分配库存
        Picking = 31505,        // 拣货中
        Sorting = 31506,        // 分拣货中
        Issued = 31507,         // 已发货
        Deliveried = 31508,     // 交接配送
        Cancelled = 31599       // 已作废
    }
}