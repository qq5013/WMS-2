namespace Business.Common.DataDictionary
{
    public enum InboundPlanStatus
    {
        Created = 31201,          // 制单
        Modified = 31202,         // 已修改 
        Confirmed = 31203,        // 已审核 
        Receiving = 31204,        // 收货中
        PartialReceived = 31205,  // 部分收货 
        Received = 31206,         // 收货完成
        Closed = 31207,           // 已关闭 （部分收货，且确定无法继续收货）
        Cancelled = 31299         // 已作废
    }
}