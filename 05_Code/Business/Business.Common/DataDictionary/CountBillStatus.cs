namespace Business.Common.DataDictionary
{
    public enum CountBillStatus
    {
        Created = 30901,            // 制单
        FirstCounting = 30902,      // 初盘
        SecondCounting = 30903,     // 复盘
        Confirmed = 30904,          // 已审核
        Accounted = 30905,          // 已过账
        Cancelled = 30999           // 已作废
    }
}