namespace Business.Common.DataDictionary
{
    public enum TransferBillStatus
    {
        Created = 32001,         // 制单
        Transfered = 32002,      // 已移货
        Confirmed = 32003,       // 已审核
        Cancelled = 32099        // 已作废
    }
}