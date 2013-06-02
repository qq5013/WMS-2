namespace Business.Common.DataDictionary
{
    public enum BillType
    {
        InboundPlan = 30101,      // 入库计划
        InboundBill = 30102,      // 入库单
        PutawayBill = 30103,      // 上架单
        CountBill = 30104,        // 盘点单
        TransferBill = 30105,     // 移货单
        OutboundPlan = 30106,     // 出库计划
        PickBill = 30107,         // 拣货单
        SortBill = 30108,         // 分拣单
        OutboundBill = 30109,     // 出库单
        Package = 30110,          // 包裹单
        ReplenishBill = 30111     // 补货单
    }
}