namespace Business.Common.DataDictionary
{
    public enum InboundBillStatus
    {
        Created = 31001,      // 制单
        Modified = 31002,     // 已修改
        Received = 31003,     // 已收货 
        Putaway = 31004,      // 已上架
        Cancelled = 31099     // 已作废 
    }
}